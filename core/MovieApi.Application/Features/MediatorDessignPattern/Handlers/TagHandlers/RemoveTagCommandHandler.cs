using MediatR;
using MovieApi.Application.Features.MediatorDessignPattern.Commands.Tagcommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDessignPattern.Handlers.TagHandlers
{
    public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommand>
    {
        private readonly MovieContext _context;

        public RemoveTagCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveTagCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.tags.FindAsync(new object[] { request.TagId }, cancellationToken);
            if (value != null)
            {
                _context.tags.Remove(value);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
 