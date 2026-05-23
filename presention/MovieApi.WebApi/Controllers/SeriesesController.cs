using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRS_design_pattern.Commands.SeriesCommands;
using MovieApi.Application.Features.CQRS_design_pattern.Handlers.SeriesHandlers;
using Newtonsoft.Json.Linq;


namespace SeriesApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesesController : ControllerBase
    {

        private readonly GetSeriesByIdQueryHandler _getSeriesByIdQueryHandler;
        private readonly GetSeriesQueryHandler _getSeriesQueryHandler;
        private readonly CreateSeriesCommandHandler _createSeriesCommandHandler;
        private readonly UpdateSeriesCommandHandler _updateSeriesCommandHandler;
        private readonly RemoveSeriesCommandHandler _removeSeriesCommandHandler;
        private readonly GetSeriesWithCategoryQueryHandler _getSeriesWithCategoryQueryHandler;

        public object CreateSeriesHandler { get; private set; }

        public SeriesesController(GetSeriesByIdQueryHandler getSeriesByIdQueryHandler, GetSeriesQueryHandler getSeriesQueryHandler, CreateSeriesCommandHandler createSeriesCommandHandler, UpdateSeriesCommandHandler updateSeriesCommandHandler, RemoveSeriesCommandHandler removeSeriesCommandHandler, GetSeriesWithCategoryQueryHandler getSeriesWithCategoryQueryHandler)
        {
            _getSeriesByIdQueryHandler = getSeriesByIdQueryHandler;
            _getSeriesQueryHandler = getSeriesQueryHandler;
            _createSeriesCommandHandler = createSeriesCommandHandler;
            _updateSeriesCommandHandler = updateSeriesCommandHandler;
            _removeSeriesCommandHandler = removeSeriesCommandHandler;
            _getSeriesWithCategoryQueryHandler = getSeriesWithCategoryQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> SeriesList()
        {
            var value = await _getSeriesQueryHandler.Handle();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSeries(CreateSeriesCommand command)
        {
            await _createSeriesCommandHandler.Handlers(command);
            return Ok("Dizi ekleme işleme başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveSeries(int id)
        {
            await _removeSeriesCommandHandler.Handlers(new RemoveSeriesCommand(id));
            return Ok("Dizi silme işlemi başarılı");
        }

        [HttpGet("getSeries")]
        public async Task<IActionResult> GetSeries(int id)
        {
            var value = await _getSeriesByIdQueryHandler.Handle(new GetSeriesByldQuery(id));
            return Ok(value);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeries(UpdateSeriesCommand command)
        {

            await _updateSeriesCommandHandler.Handlers(command);

            return Ok("Dizi günceleme işlemi başarılı");
        }


        [HttpGet("getSeriesWithCategory")]
        public async Task<IActionResult> GetSeriesWithCategory()
        {
            var values = await _getSeriesWithCategoryQueryHandler.Handle();
            return Ok(values);


        }
    }
}

