using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDessignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDessignPattern.Handlers.CastHandlers
{
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommands>
    {
        private readonly MovieContext _context;

        public RemoveCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCastCommands request, CancellationToken cancellationToken)
        {
            var value = await _context.casts.FindAsync(new object[] { request.CastId }, cancellationToken);
            if (value != null)
            {
                _context.casts.Remove(value);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
