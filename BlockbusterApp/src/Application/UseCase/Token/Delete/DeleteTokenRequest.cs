using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token.Delete
{
    public class DeleteTokenRequest : IRequest
    {
        public DeleteTokenRequest(string token)
        {
            this.Token = token;
        }

        public string Token { get; }
    }
}
