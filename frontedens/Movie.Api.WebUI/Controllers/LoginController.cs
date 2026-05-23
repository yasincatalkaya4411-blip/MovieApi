using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
