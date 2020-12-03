using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token.Update
{
    public class UpdateTokenResponse : IResponse
    {
        public string Token { get; }
        public UpdateTokenResponse(string token)
        {
            this.Token = token;
        }
    }
}
