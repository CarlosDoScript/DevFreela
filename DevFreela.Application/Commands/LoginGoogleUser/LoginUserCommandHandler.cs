using DevFreela.Application.ViewModels;
using DevFreela.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginGoogleUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginGoogleUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserViewModel> Handle(LoginGoogleUserCommand request, CancellationToken cancellationToken)
        {
            var claimsPrincipal = request.AuthenticateResult.Principal;
            var email = claimsPrincipal.FindFirst(ClaimTypes.Email)?.Value;

            var token = _authService.GenerateJwtToken(email, Core.Enums.UserRoleEnum.Client);

            return new LoginUserViewModel(email, token);
        }
    }
}
