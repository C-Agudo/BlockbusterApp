using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.Tests.Domain.UserAggregate.Mothers
{
    public class UserLastNameMother
    {
        public const string LAST_NAME = "LastName";
        public static UserLastname Create()
        {
            return new UserLastname(LAST_NAME);
        }
    }
}
