using BlockbusterApp.src.Domain.CountryAggregate.Service.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.CountryAggregate.Service
{
    public class CountryFinderValidator
    {
        private ICountryRepository countryRepository;

        public CountryFinderValidator(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        public void Validate(CountryCode countryCode)
        {
            Country country = countryRepository.FindCountryByCode(countryCode);

            if (country == null)
            {
                throw CountryNotFoundException.FromCode(countryCode);
            }
        }
    }
}
