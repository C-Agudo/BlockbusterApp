using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.CountryAggregate
{
    public interface ICountryRepository
    {
        Country FindCountryByCode(CountryCode code);
    }
}
