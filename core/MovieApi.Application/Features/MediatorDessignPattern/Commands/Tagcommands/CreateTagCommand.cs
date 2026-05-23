using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDessignPattern.Commands.Tagcommands
{
   public class CreateTagCommand:IRequest
    {
        public string Title { get; set; }
    }
}
