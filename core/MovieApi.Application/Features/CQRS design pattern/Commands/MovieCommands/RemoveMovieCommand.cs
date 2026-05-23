using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Commands.MovieCommands
{
     public class RemoveMovieCommand
     {
        public RemoveMovieCommand(int movieId)
        {
            MovieId = movieId;
        }

        public int MovieId { get; set; }

     }
}
