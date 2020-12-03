using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.Tests.Domain.UserAggregate.Mothers
{
    public class UserCountryMother
    {
        public const string COUNTRY_CODE = "ES";
        public static UserCountry Create()
        {
            return new UserCountry(COUNTRY_CODE);
        }
    }
}
