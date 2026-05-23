using MovieApi.Application.Features.CQRS_design_pattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRS_design_pattern.Commands.SeriesCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Handlers.SeriesHandlers
{
    public class RemoveSeriesCommandHandler
    {
         
        private readonly MovieContext _context;

        public RemoveSeriesCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handlers(RemoveSeriesCommand command)
        {
            var value = await _context.Serieses.FindAsync(command.SeriesId);
            _context.Serieses.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
