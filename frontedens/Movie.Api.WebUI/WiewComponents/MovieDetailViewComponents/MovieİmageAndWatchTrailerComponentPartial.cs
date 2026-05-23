using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Movie.Api.WebUI.WiewComponents.MovieDetailViewComponents
{
    public class MovieİmageAndWatchTrailerComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
