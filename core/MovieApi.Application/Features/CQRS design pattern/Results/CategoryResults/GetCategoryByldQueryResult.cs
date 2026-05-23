using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Results.CategoryResults
{
    public class GetCategoryByldQueryResult
    {
        public int categoryId { get; set; }
        public string categoryname { get; set; }
    }
}
