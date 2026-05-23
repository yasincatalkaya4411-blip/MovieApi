using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRS_design_pattern.Results.CategoryResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly MovieContext _context;

        public GetCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values= await _context.Categories.ToListAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                categoryId = x.CategoryId,
                categoryname = x.CategoryName,
            }). ToList();

        }
    }
}
