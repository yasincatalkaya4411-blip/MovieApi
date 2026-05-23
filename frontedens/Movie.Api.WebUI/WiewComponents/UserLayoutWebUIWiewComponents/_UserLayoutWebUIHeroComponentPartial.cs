using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.WiewComponents.UserLayoutWebUIWiewComponents
{
    public class _UserLayoutWebUIHeroComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
                       return View();
        }
    }
}
