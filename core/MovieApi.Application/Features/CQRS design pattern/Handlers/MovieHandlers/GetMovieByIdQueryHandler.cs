using MovieApi.Application.Features.CQRS_design_pattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRS_design_pattern.Results.CategoryResults;
using MovieApi.Application.Features.CQRS_design_pattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext context;
        private int id;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            this.context = context;
        }

        public GetMovieByIdQueryHandler(int id)
        {
            this.id = id;
        }

        public async Task<GetMovieByldQueryResult>Handle(GetMovieByldQuery query)
        {
            var value = await context.Movies.FindAsync(query.MovieId);
            return new GetMovieByldQueryResult
            {
                CoverImageUrl = value.CoverImageUrl,
                CreatedYear = value.CreatedYear,
                Description = value.Description,
                Duration = value.Duration,
                Rating = value.Rating,
                ReleaseDate = value.ReleaseDate,
                Status = value.Status,
                Title = value.Title,
            };
        }
    }
}
