using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.Tests.Domain.UserAggregate.Mothers
{
    public class UserMother
    {
        public static User Create()
        {
            return new User
            (
                UserIdMother.Create(),
                UserEmailMother.Create(),
                UserHashedPasswordMother.Create(),
                UserFirstNameMother.Create(),
                UserLastNameMother.Create(),
                UserCountryMother.Create(),
                UserRoleMother.Create()
            );
        }
    }
}
