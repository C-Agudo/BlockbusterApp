using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class UserHashedPassword : StringValueObject
    {
        public UserHashedPassword(string value) : base(value)
        {

        }
    }
}
