using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.CountryAggregate
{
    public class Country : AggregateRoot
    {
        public CountryId id { get; }
        public CountryCode code { get; }
        public CountryTax tax { get; }

        private Country(CountryId id, CountryCode code, CountryTax tax)
        {
            this.id = id;
            this.code = code;
            this.tax = tax;
        }

        public static Country Create(CountryId id,CountryCode code, CountryTax tax)
        {
            Country country = new Country(id, code, tax);
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
