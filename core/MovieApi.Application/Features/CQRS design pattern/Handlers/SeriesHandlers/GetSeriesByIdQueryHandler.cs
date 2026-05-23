using MovieApi.Application.Features.CQRS_design_pattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRS_design_pattern.Queries.SeriesQueries;
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
    public class GetSeriesByIdQueryHandler
    {

        private readonly MovieContext context;
        private int id;

        public GetSeriesByIdQueryHandler(MovieContext context)
        {
            this.context = context;
        }


        public GetSeriesByIdQueryHandler(int id)
        {
            this.id = id;
        }

        public async Task<GetSeriesByIdQueryResult> Handle(GetSeriesByIdQuery query)
        {
            var value = await context.Serieses.FindAsync(query.SeriesId);
            return new GetSeriesByIdQueryResult
            {
                CoverImageUrl = value.CoverImageUrl,
                CreatedYear = value.CreatedYear,
                Description = value.Description,
                Rating = value.Rating,
                Status = value.Status,
                Title = value.Title,
                AverageEpisodeDuration = value.AverageEpisodeDuration,
                SeriesId = value.SeriesId,
                SeasonCount = value.SeasonCount,
                FirstAirDate = value.FirstAirDate,
                EpisodeCount = value.EpisodeCount,
                CategoryId = value.CategoryId
            };
        }
    }
    }
