using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminCategoryDtos;
using MovieApi.Dto.Dtos.AdminMovieDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Movie.Api.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMovieController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AdminMovieController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult >MovieList()
        {
            var client = httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("/api/Movies/getMovieWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultMovieDto>>(jsondata) ?? new List<AdminResultMovieDto>();
                return View(values);
            }
            return View(new List<AdminResultMovieDto>());
        }
        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateAdminMovieDto CreateAdminMovieDto)
        {
            var client = httpClientFactory.CreateClient("MovieApi");
            var jsondata = JsonConvert.SerializeObject(CreateAdminMovieDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("/api/Movies", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MovieList");
            }
            return View();
        }
    }
}
