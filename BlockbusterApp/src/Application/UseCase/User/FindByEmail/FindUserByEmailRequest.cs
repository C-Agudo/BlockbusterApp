using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.Find
{
    public class FindUserByEmailRequest : IRequest
    {
        public string Email { get; }
        public FindUserByEmailRequest(string email)
        {
            this.Email = email;
        }

    }
}
