using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.Tests.Domain.UserAggregate.Mothers
{
    public class UserEmailMother
    {
        public const string EMAIL = "xxx@gmail.com";
        public static UserEmail Create()
        {
            return new UserEmail(EMAIL);
        }
    }
}
