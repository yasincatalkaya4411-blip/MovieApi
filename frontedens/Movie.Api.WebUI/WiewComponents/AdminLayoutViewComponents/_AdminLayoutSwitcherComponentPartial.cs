using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.WiewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutSwitcherComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
