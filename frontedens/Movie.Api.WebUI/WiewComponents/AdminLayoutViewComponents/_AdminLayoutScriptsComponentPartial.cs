using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.WiewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
