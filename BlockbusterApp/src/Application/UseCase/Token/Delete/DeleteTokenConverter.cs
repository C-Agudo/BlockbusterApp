using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token.Delete
{
    public class DeleteTokenConverter
    {
        public IResponse Convert()
        {
            return new DeleteTokenResponse();
        }
    }
}
