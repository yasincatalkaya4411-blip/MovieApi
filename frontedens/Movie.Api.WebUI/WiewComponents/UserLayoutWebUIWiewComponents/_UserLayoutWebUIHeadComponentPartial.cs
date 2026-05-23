using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.WiewComponents.UserLayoutWebUIWiewComponents
{
    public class UserLayoutWebUIHeadComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}