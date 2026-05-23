using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminCategoryDtos;
using Newtonsoft.Json;
using System.Text;

namespace Movie.Api.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AdminCategoryController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CategoryList()
        {
            var client = httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultCategoryDto>>(jsondata) ?? new List<AdminResultCategoryDto>();
                return View(values);
            }
            return View(new List<AdminResultCategoryDto>());
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(AdminCreateCategoryDto AdminCreateCategoryDto)
        {
            var client = httpClientFactory.CreateClient("MovieApi");
            var jsondata = JsonConvert.SerializeObject(AdminCreateCategoryDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("/api/Categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.DeleteAsync("/api/Categories?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList", "AdminCategory", new { area = "Admin" });
            }
            return View();
        }

    }
}
