using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.WiewComponents.UserLayoutWebUIWiewComponents
{
    public class _UserLayoutWebUINavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
