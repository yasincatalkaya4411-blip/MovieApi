using MovieApi.Application.Features.CQRS_design_pattern.Queries.SeriesQueries;

namespace SeriesApi.WebApi.Controllers
{
    internal class GetSeriesByldQuery : GetSeriesByIdQuery
    {
        public GetSeriesByldQuery(int seriesId) : base(seriesId)
        {
        }
    }
}