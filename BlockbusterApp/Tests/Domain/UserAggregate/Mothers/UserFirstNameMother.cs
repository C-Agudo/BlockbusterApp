using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.Tests.Domain.UserAggregate.Mothers
{
    public class UserFirstNameMother
    {
        public const string FIRST_NAME = "FirstName";
        public static UserFirstname Create()
        {
            return new UserFirstname(FIRST_NAME);
        }
    }
}
