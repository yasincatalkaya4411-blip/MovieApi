using MovieApi.Application.Features.CQRS_design_pattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handlers(UpdateCategoryCommand command)
        {
            var value = await _context.Categories.FindAsync(command.categoryId);
            if (value is null)
            {
                return;
            }

            value.CategoryName = command.categoryname;
            await _context.SaveChangesAsync();
        }
        
    }
}
