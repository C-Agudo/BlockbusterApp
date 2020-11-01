using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.CountryAggregate
{
    public class CountryCode : StringValueObject
    {
        public CountryCode(string value) : base(value)
        {

        }
    }
}
