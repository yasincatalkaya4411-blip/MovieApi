using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.Controllers
{
    public class UserWebUILayoutController : Controller
    {
        public IActionResult LayoutUI()
        {
            return View();
        }
    }
}
