using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Commands.SeriesCommands
{
    public class RemoveSeriesCommand
    {
        public int SeriesId { get; set; }

        public RemoveSeriesCommand(int seriesId)
        {
            SeriesId = seriesId;
        }
    }
}
