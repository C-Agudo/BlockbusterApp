using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Country
{
    public class CountryConverter
    {
        public CountryConverter()
        {
            
        }

        public IResponse Convert(Domain.CountryAggregate.Country country)
        {
            return new FindCountryResponse(country.GetCode(), country.GetTax());
        }
    }
}
