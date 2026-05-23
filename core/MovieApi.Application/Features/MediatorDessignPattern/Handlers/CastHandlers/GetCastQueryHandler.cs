using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDessignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDessignPattern.Results.CastResult;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDessignPattern.Handlers.CastHandlers
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResults>>
    {
        private readonly MovieContext _context;

        public GetCastQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetCastQueryResults>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.casts.ToListAsync();
            return values.Select(x => new GetCastQueryResults
            {
                Biography = x.Biography,
                CastId = x.CastId,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                OwerView = x.OwerView,
                Surname = x.Surname,
                Title = x.Title,
            }).ToList();
        }
    }
}
