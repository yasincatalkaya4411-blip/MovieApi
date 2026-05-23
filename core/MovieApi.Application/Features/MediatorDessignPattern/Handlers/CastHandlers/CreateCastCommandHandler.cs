using MediatR;
using MovieApi.Application.Features.MediatorDessignPattern.Commands.CastCommands;
using MovieApi.domain.entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDessignPattern.Handlers.CastHandlers
{
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommands>
    {
        private readonly MovieContext _context;

        public CreateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCastCommands request, CancellationToken cancellationToken)
        {
          await _context.casts.AddAsync(new Cast
            {
                Biography = request.Biography,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
                OwerView = request.OwerView,
                Surname = request.Surname,
                Title = request.Title
            });
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
