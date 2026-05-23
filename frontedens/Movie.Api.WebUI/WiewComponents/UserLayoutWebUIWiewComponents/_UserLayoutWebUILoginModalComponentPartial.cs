using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.WiewComponents.UserLayoutWebUIWiewComponents
{
    public class _UserLayoutWebUILoginModalComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return  View();
        }
    }
}
