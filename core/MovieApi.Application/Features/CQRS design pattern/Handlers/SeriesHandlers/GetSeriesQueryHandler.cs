using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRS_design_pattern.Results.MovieResults;
using MovieApi.Application.Features.CQRS_design_pattern.Results.SeriesResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Handlers.SeriesHandlers
{
    public class GetSeriesQueryHandler
    {

        private readonly MovieContext _context;

        public GetSeriesQueryHandler(MovieContext context)
        {
            this._context = context;
        }
        public async Task<List<GetSeriesQueryResult>> Handle()
        {
            var values = await _context.Serieses.ToListAsync();
            return values.Select(x => new GetSeriesQueryResult
            {
                CoverImageUrl = x.CoverImageUrl,
                CreatedYear = x.CreatedYear,
                Description = x.Description,
                Rating = x.Rating,
                Status = x.Status,
                Title = x.Title,
                AverageEpisodeDuration = x.AverageEpisodeDuration,
                CategoryId = x.CategoryId,
                EpisodeCount = x.EpisodeCount,
                FirstAirDate = x.FirstAirDate,
                SeasonCount = x.SeasonCount,
                SeriesId = x.SeriesId
            }).ToList();
        }
    }
}