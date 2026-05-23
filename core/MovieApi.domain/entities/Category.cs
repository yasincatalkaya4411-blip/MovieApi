using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.domain.entities
{
    public class Category
    {
        // Kullanılmayan eski alanlar, EF tarafından haritalanmasın
        [NotMapped]
        public int categoryId { get; set; }

        public int CategoryId { get; set; }

        [NotMapped]
        public string? categoryname { get; set; }

        public string CategoryName { get; set; } = null!;

        public bool Status { get; set; }
        public int StatusId { get; set; }
        public string? Description { get; set; }
        public string DescriptionId { get; set; }
        public List<Movie> Movies { get; set; } 
        public List<Series> Serieses { get; set; } 

    }
}
