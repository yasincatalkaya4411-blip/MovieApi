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
    public class RemoveCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public RemoveCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handlers(RemoveCategoryCommand command)
        {
            var value = await _context.Categories.FindAsync(command.categoryId);
            _context.Categories.Remove(value);
            await _context.SaveChangesAsync();
        }

    }
 }

