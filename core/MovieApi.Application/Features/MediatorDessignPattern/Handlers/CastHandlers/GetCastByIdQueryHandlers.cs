using MediatR;
using MovieApi.Application.Features.MediatorDessignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDessignPattern.Results.CastResult;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDessignPattern.Handlers.CastHandlers
{
    public class GetCastByIdQueryHandlers : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetCastByIdQueryHandlers(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {
                Biography = values.Biography,
                CastId = values.CastId,
                ImageUrl = values.ImageUrl,
                Name = values.Name,
                OwerView = values.OwerView,
                Surname = values.Surname,
                Title = values.Title

            };
        }
    }
}
