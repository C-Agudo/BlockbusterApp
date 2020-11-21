using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.CountryAggregate
{
    public class CountryId : UUID
    {
        public CountryId(string message) : base(message)
        {

        }
    }
}
