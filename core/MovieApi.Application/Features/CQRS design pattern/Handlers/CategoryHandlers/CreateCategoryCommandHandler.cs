using MovieApi.Application.Features.CQRS_design_pattern.Commands.CategoryCommands;
using MovieApi.domain.entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    { 

        private readonly MovieContext _context;

        public CreateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handlers(CreateCategoryCommand command)
        {
            _context.Categories.Add(new Category
            {
                CategoryName = command.categoryname
            });
            await _context.SaveChangesAsync();
        }
    }
}
