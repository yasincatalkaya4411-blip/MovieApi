using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.UserRegisterDtos;
using Newtonsoft.Json;
using System.Text;

namespace Movie.Api.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ActionName("SignUp")]
        public async Task<IActionResult> SignUpPost(CreateUserRegisterDto createUserRegisterDto)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var jsonData = JsonConvert.SerializeObject(createUserRegisterDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/Registers", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Movie");
            }
            var errorBody = await response.Content.ReadAsStringAsync();
            ViewBag.Error = "Kayıt başarısız: " + (string.IsNullOrEmpty(errorBody) ? response.ReasonPhrase : errorBody);
            return View("SignUp", createUserRegisterDto);

        }
    }
}
