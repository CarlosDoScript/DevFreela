using DevFreela.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginGoogleUser
{
    public class LoginGoogleUserCommand : IRequest<LoginUserViewModel>
    {
        public AuthenticateResult AuthenticateResult { get; set; }
    }
}
