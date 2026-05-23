using MediatR;
using MovieApi.Application.Features.MediatorDessignPattern.Results.TagResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDessignPattern.Queries.TagQueries
{
    public class GetTagQuery:IRequest<List<GetTagQueryResult>>
    {
    }
}
