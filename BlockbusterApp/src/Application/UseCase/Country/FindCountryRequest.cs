using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Country
{
    public class FindCountryRequest : IRequest
    {
        public FindCountryRequest(string countryCode)
        {
            this.CountryCode = countryCode;
        }

        public string CountryCode { get; }
    }
}
