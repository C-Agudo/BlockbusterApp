using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token.Update
{
    public class UpdateTokenConverter
    {
        public IResponse Convert(Domain.TokenAggregate.Token token)
        {
            return new UpdateTokenResponse(token.hash.GetValue());
        }
    }
}
