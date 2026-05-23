using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminReviewDtos;
using Newtonsoft.Json;

namespace Movie.Api.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminReviewController : Controller
    {
          private readonly IHttpClientFactory httpClientFactory;

        public AdminReviewController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ReviewList(int page = 1, int pageSize = 10)
        {
            var client = httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync($"/api/Reviews?page={page}&pageSize={pageSize}");
            
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultReviewDto>>(jsondata) ?? new List<AdminResultReviewDto>();

                if (responseMessage.Headers.TryGetValues("X-Total-Count", out var headerValues))
                {
                    if (int.TryParse(headerValues.FirstOrDefault(), out int totalCount))
                    {
                        ViewBag.TotalCount = totalCount;
                        ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                    }
                }
                else
                {
                    ViewBag.TotalCount = values.Count;
                    ViewBag.TotalPages = 1;
                }

                ViewBag.CurrentPage = page;
                ViewBag.PageSize = pageSize;

                return View(values);
            }

            ViewBag.TotalCount = 0;
            ViewBag.TotalPages = 1;
            ViewBag.CurrentPage = 1;
            ViewBag.PageSize = 10;

            return View(new List<AdminResultReviewDto>());
        }
    }
}
