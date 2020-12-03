using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.Tests.Domain.UserAggregate.Mothers
{
    public class UserHashedPasswordMother
    {
        public const string HASHED_PASSWORD = "76C19B61F8DE681E478ED0D99B25F4B6686E71914A4542CB5F9C45E19D405EF9AB4CF865C3677F8291CEF8561DCDE0212BC1964FDC64A8F693AB1BFD0476DC56";

        public static UserHashedPassword Create()
        {
            return new UserHashedPassword(HASHED_PASSWORD);
        }
    }
}
