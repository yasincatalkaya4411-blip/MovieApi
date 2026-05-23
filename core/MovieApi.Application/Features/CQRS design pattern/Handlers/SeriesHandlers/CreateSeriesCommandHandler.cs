using MovieApi.Application.Features.CQRS_design_pattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRS_design_pattern.Commands.SeriesCommands;
using MovieApi.domain.entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Handlers.SeriesHandlers
{
    public class CreateSeriesCommandHandler
    {
          

        private readonly MovieContext _context;

        public CreateSeriesCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handlers(CreateSeriesCommand command)
        {
            _context.Serieses.Add(new Series
            {
               CoverImageUrl= command.CoverImageUrl,
                CreatedYear = command.CreatedYear,
                Description = command.Description,
                Rating = command.Rating,
                Status= command.Status,
                Title = command.Title,
                AverageEpisodeDuration = command.AverageEpisodeDuration,
                CategoryId = command.CategoryId,
                EpisodeCount = command.EpisodeCount,
                FirstAirDate = command.FirstAirDate,
                SeasonCount = command.SeasonCount
            });
            await _context.SaveChangesAsync();
        }
    }
}
