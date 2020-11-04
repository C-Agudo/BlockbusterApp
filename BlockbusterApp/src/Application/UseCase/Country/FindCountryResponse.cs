using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Country
{
    public class FindCountryResponse : IResponse
    {
        public FindCountryResponse(string code, string tax)
        {
            this.Code = code;
            this.Tax = tax;
        }

        public string Code { get; }
        public string Tax { get; }

    }
}
