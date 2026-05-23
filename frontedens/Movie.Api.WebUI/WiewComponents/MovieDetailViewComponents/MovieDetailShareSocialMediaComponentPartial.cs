using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.WiewComponents.MovieDetailViewComponents
{
    public class MovieDetailShareSocialMediaComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
                       return View();
        }

    }
}
