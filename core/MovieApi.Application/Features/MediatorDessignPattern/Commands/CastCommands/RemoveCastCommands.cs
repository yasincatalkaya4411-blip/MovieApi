using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDessignPattern.Commands.CastCommands
{
    public class RemoveCastCommands: IRequest
    {
        public int CastId { get; set; }

        public RemoveCastCommands(int castId)
        {
            CastId = castId;
        }
    }
}
