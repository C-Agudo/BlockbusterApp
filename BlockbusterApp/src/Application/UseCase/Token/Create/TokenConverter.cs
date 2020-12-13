using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token
{
    public class TokenConverter
    {
        public TokenConverter()
        {

        }

        public IResponse Convert(Domain.TokenAggregate.Token token)
        {
            return new CreateTokenResponse(token.hash.GetValue());
        }
    }
}
