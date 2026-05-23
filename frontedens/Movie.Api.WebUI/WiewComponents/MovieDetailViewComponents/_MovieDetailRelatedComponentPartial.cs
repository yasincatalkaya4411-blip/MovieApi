using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.WiewComponents.MovieDetailViewComponents
{
    public class _MovieDetailRelatedComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
