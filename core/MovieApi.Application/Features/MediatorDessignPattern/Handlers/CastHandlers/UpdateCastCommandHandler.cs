using MediatR;
using MovieApi.Application.Features.MediatorDessignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDessignPattern.Handlers.CastHandlers
{
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommands>
    {
        private readonly MovieContext _context;

        public UpdateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCastCommands request, CancellationToken cancellationToken)
        {
            var values = await _context.casts.FindAsync(request.CastId);
            values.Surname= request.Surname;
            values.OwerView= request.OwerView;
            values.Biography= request.Biography;
            values.ImageUrl= request.ImageUrl;
            values.Name= request.Name;
            values.Title= request.Title;
            await _context.SaveChangesAsync();
        }
    }
}
