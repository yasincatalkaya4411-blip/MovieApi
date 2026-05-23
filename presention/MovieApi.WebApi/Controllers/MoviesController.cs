using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRS_design_pattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRS_design_pattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRS_design_pattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;
        private readonly GetMovieWithCategoryQueryHandler _getMovieWithCategoryQueryHandler;
        public object CreateMovieHandler { get; private set; }

        public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler, GetMovieWithCategoryQueryHandler getMovieWithCategoryQueryHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
            _getMovieWithCategoryQueryHandler = getMovieWithCategoryQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            var value = await _getMovieQueryHandler.Handle();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handlers(command);
            return Ok("film ekleme işleme başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveMovie(int id)
        {
            await _removeMovieCommandHandler.Handlers(new RemoveMovieCommand(id));
            return Ok("film silme işlemi başarılı");
        }

        [HttpGet("getmovie")]
        public async Task<IActionResult> Getmovie(int id)
        {
            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByldQuery(id));
            return Ok(value);
           
        }

        [HttpPut]
        public async Task<IActionResult>UpdateMovie(UpdateMovieCommand command)
        {

             await _updateMovieCommandHandler.Handlers(command);

            return Ok("film günceleme işlemi başarılı");
        }
        [HttpGet("getmoviewithcategory")]
        public async Task<IActionResult> GetMovieWithCategory()
        {
            var value= await _getMovieWithCategoryQueryHandler.Handle();
            return Ok(value);
        }
    } 
}

