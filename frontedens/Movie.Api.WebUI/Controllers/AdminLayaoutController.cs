using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.Controllers
{
    public class AdminLayaoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
