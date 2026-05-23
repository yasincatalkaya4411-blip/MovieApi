using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminDto.AdminSeriesDtos;
using Newtonsoft.Json;
using System.Text;

namespace Series.Api.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSeriesController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AdminSeriesController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SeriesList()
        {
            var client = httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("/api/Serieses");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultSeriesDto>>(jsondata) ?? new List<AdminResultSeriesDto>();
                return View(values);
            }
            return View(new List<AdminResultSeriesDto>());
        }
        [HttpGet]
        public IActionResult CreateSeries()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSeries(CreateAdminSeriesDto createAdminSeriesDto)
        {
            var client = httpClientFactory.CreateClient("MovieApi");
            var jsondata = JsonConvert.SerializeObject(createAdminSeriesDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("/api/Serieses", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeriesList");
            }
            return View();
        }
    }
}
