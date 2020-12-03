using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.Tests.Domain.UserAggregate.Mothers
{
    public class UserPasswordMother
    {
        public const string PASSWORD = "PAassword00";
        public static UserPassword Create()
        {
            return new UserPassword(PASSWORD);
        }
    }
}
