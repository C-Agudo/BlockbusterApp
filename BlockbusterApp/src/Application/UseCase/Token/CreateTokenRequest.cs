using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token
{
    public class CreateTokenRequest : IRequest
    {
        public CreateTokenRequest(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public string Email { get; }
        public string Password { get; }

    }
}
