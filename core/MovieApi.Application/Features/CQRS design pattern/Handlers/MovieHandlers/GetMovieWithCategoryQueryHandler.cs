using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRS_design_pattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Handlers.MovieHandlers
{
    public class GetMovieWithCategoryQueryHandler
    {
        private readonly MovieContext context;

        public GetMovieWithCategoryQueryHandler(MovieContext context)
        {
            this.context = context;
        }
        public async Task<List<GetMovieWithCategoryQueryResult>> Handle()
        {
            var values = await context.Movies.Include(y=>y.Category).ToListAsync();
            return values.Select(x => new GetMovieWithCategoryQueryResult
            {
                MovieId = x.MovieId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedYear = x.CreatedYear,
                Description = x.Description,
                Duration = x.Duration,
                Rating = x.Rating,
                ReleaseDate = x.ReleaseDate,
                Status = x.Status,
                Title = x.Title,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.CategoryName
            }).ToList();
        }
    }
}
