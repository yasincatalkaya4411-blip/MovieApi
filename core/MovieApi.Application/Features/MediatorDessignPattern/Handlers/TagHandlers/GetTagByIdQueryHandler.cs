using MediatR;
using MovieApi.Application.Features.MediatorDessignPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDessignPattern.Results.TagResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDessignPattern.Handlers.TagHandlers
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetTagByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.tags.FindAsync(new object[] { request.TagId }, cancellationToken);
            if (value == null)
                return null!;

            return new GetTagByIdQueryResult
            {
                TagId = value.TagId,
                Title = value.Title
            };
        }
    }
}
