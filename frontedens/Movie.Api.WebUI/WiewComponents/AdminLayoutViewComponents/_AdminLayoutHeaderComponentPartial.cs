using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.WiewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
