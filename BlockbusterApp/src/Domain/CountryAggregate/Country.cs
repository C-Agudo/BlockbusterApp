using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.CountryAggregate
{
    public class Country : AggregateRoot
    {
        private CountryCode code { get; }
        private CountryTax tax { get; }

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

        public string GetCode()
        {
            return this.code.GetValue();
        }

        public string GetTax()
        {
            return this.tax.GetValue();
        }
    }
}
