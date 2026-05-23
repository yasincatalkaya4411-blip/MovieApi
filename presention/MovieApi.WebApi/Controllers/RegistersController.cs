using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRS_design_pattern.Commands.UserRegisterCommands;
using MovieApi.Application.Features.CQRS_design_pattern.Handlers.UserRegisterHandlers;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {

        private readonly CreateUserRegisterCommandHandler _CreateUserRegisterCommandHandler;

        public RegistersController(CreateUserRegisterCommandHandler createUserRegisterCommandHandler)
        {
            _CreateUserRegisterCommandHandler = createUserRegisterCommandHandler;
        }
    

    [HttpPost]
        public async Task<IActionResult> CreateUserRegister(CreateUserRegisterCommand command)
        {
            var result = await _CreateUserRegisterCommandHandler.Handle(command);
            if (result.Succeeded)
                return Ok("Kullanıcı başarıyla eklendi");
            return BadRequest(string.Join("; ", result.Errors.Select(e => e.Description)));
        }
        [HttpPost("bulk")]
        public async Task<IActionResult> CreateUserRegisterBulk(List<CreateUserRegisterCommand> commands)
        {
            var failures = new List<object>();
            int successCount = 0;

            foreach (var command in commands)
            {
                var result = await _CreateUserRegisterCommandHandler.Handle(command);
                if (result.Succeeded)
                {
                    successCount++;
                }
                else
                {
                    failures.Add(new
                    {
                        Username = command.Username,
                        Errors = result.Errors.Select(e => e.Description)
                    });
                }
            }

            if (failures.Count == 0)
            {
                return Ok($"{successCount} kullanıcı başarıyla eklendi.");
            }

            return Ok(new
            {
                Message = $"{successCount} kullanıcı başarıyla eklendi, {failures.Count} kullanıcıda hata oluştu.",
                Failures = failures
            });
        }
    }
}