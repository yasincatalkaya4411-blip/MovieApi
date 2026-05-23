using MovieApi.Application.Features.CQRS_design_pattern.Commands.MovieCommands;
using MovieApi.domain.entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public static async Task Handle(CreateMovieCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task Handlers(CreateMovieCommand command)
        {
            _context.Movies.Add(new Movie
            {
                CoverImageUrl = command.CoverImageUrl,
                CreatedYear = command.CreatedYear,
                Description = command.Description,
                Duration = command.Duration,
                Rating = command.Rating,
                ReleaseDate = command.ReleaseDate,
                Status = command.Status,
                Title = command.Title,

            });
            await _context.SaveChangesAsync();
        }
    }
}
