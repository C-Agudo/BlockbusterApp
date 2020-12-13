using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token
{
    public class CreateTokenResponse : IResponse
    {
        public string Token { get; }
        public CreateTokenResponse(string token)
        {
            this.Token = token;
        }


    }
}
