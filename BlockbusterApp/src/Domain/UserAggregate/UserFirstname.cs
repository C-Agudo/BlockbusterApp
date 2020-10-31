using BlockbusterApp.src.Domain.UserAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class UserFirstname : StringValueObject
    {
        const int MIN_LENGHT = 3;
        const int MAX_LENGHT = 15;


        public UserFirstname(string value) : base(value)
        {
            if (value.Length > MAX_LENGHT)
            {
                throw InvalidUserAttributeException.FromMaxLength("FirstName", MAX_LENGHT);
            }

            if (value.Length < MIN_LENGHT)
            {
                throw InvalidUserAttributeException.FromMinLength("FirstName", MIN_LENGHT);
            }
        }

    }
}
