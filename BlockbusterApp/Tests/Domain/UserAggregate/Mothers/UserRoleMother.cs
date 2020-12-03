using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.Tests.Domain.UserAggregate.Mothers
{
    public class UserRoleMother
    {
        public static UserRole Create()
        {
            return new UserRole(UserRole.ROLE_USER);
        }
    }
}
