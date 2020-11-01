using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.CountryAggregate
{
    public class Country : AggregateRoot
    {
        private CountryCode code;
        private CountryTax tax;

        private Country(CountryCode code, CountryTax tax)
        {
            this.code = code;
            this.tax = tax;
        }

        public static Country Create(CountryCode code, CountryTax tax)
        {
            Country country = new Country(code, tax);
            return country;
        }
    }
}
