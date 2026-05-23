using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDessignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDessignPattern.Queries.CastQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task< IActionResult> CastList()
        {
            var value = await _mediator.Send(new GetCastQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommands commands)
        {
           await _mediator.Send(commands);
            return Ok("ekleme işlemi başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCast(int id)
        {
           await _mediator.Send(new RemoveCastCommands(id));
            return Ok("silme işlemi başarılı");
        }
        [HttpGet("GetCastById")]
        public async Task<IActionResult> GetCastById(int id)
        {
            var value = await _mediator.Send(new GetCastByIdQuery(id));
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommands commands)
        {
           await _mediator.Send(commands);
            return Ok("güncelleme işlemi başarılı");
        }
    }
}
