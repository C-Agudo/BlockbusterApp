using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class UserCountry : StringValueObject
    {
        public UserCountry(string value) : base(value)
        {

        }
    }
}
