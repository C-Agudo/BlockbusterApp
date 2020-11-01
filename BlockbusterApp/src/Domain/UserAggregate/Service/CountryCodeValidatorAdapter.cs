using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Domain.CountryAggregate.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate.Service
{
    public class CountryCodeValidatorAdapter
    {
        private GetCountryValidator countryValidator;
        public CountryCodeValidatorAdapter(GetCountryValidator countryValidator)
        {
            this.countryValidator = countryValidator;
        }

        public void Validate(UserCountry userCountry)
        {
            string userCountryCode = userCountry.GetValue();
            CountryCode countryCode = new CountryCode(userCountryCode);
            countryValidator.Validate(countryCode);
        }
    }
}
