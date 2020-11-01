using BlockbusterApp.src.Shared.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.CountryAggregate.Service.Exception
{
    public class CountryNotFoundException : ValidationException
    {
        public CountryNotFoundException(string value) : base(value)
        {

        }

        public static CountryNotFoundException FromCode(CountryCode countryCode)
        {
            return new CountryNotFoundException(string.Format("Country {0} " + countryCode.GetValue() + " not is available"));
        }
    {
    }
}
