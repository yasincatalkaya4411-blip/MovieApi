using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.WebUI.WiewComponents.MovieDetailViewComponents
{
    public class _MovieDetailOverwiewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
