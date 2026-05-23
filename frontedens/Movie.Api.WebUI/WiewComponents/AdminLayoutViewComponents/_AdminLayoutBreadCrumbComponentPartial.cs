using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.WiewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutBreadCrumbComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
