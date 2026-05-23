using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Commands.CategoryCommands
{
    public class CreateCategoryCommand
    {
        public string categoryname { get; set; }

    }
}
