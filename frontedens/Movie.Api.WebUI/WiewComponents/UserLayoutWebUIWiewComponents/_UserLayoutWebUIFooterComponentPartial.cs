using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.WiewComponents.UserLayoutWebUIWiewComponents
{
    public class _UserLayoutWebUIFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
