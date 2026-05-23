using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Features.CQRS_design_pattern.Commands.UserRegisterCommands;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS_design_pattern.Handlers.UserRegisterHandlers
{
    public class CreateUserRegisterCommandHandler
    {
        private readonly MovieContext _MovieContext;

        private readonly UserManager<AppUser> _UserManeger;

        public CreateUserRegisterCommandHandler(MovieContext movieContext, UserManager<AppUser> userManeger)
        {
            _MovieContext = movieContext;
            _UserManeger = userManeger;
        }
        public async Task<IdentityResult> Handle(CreateUserRegisterCommand command)
        {
            var user = new AppUser()
            {
                Name = command.Name ?? "",
                Surname = command.Surname ?? "",
                Email = command.Email ?? "",
                UserName = command.Username ?? "",
                ImageUrl = "" // Veritabanında required olduğu için
            };
            return await _UserManeger.CreateAsync(user, command.Password);
        }
    }
}
