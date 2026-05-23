using MovieApi.Application.Features.CQRS_design_pattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRS_design_pattern.Results.CategoryResults;
using MovieApi.domain.entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly MovieContext context;

        public GetCategoryByIdQueryHandler(MovieContext context)
        {
            this.context = context;
        }
        public async Task<GetCategoryByldQueryResult>Handle(GetCategoryByldQuery query)
        {
            var value = await context.Categories.FindAsync(query.categoryId);
            return new GetCategoryByldQueryResult
            {
                categoryId = value.CategoryId,
                categoryname = value.CategoryName
            };
        }
        
            
        
    }
}
