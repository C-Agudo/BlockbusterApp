using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.Tests.Domain.UserAggregate.Mothers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.Tests.Domain.UserAggregate
{
    public class UserTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ItShouldCreateUserWhenSignUpIsCalled()
        {
            User user = UserMother.Create();

            User sut = User.SignUp
                (
                    UserIdMother.Create(),
                    UserEmailMother.Create(),
                    UserHashedPasswordMother.Create(),
                    UserFirstNameMother.Create(),
                    UserLastNameMother.Create(),
                    UserCountryMother.Create(),
                    UserRoleMother.Create()
                );

            Assert.AreEqual(user.userId.GetValue(), sut.userId.GetValue());
            Assert.AreEqual(user.userEmail.GetValue(), sut.userEmail.GetValue());
            Assert.AreEqual(user.userHashedPassword.GetValue(), sut.userHashedPassword.GetValue());
            Assert.AreEqual(user.userFirstname.GetValue(), sut.userFirstname.GetValue());
            Assert.AreEqual(user.userLastname.GetValue(), sut.userLastname.GetValue());
            Assert.AreEqual(user.userCountry.GetValue(), sut.userCountry.GetValue());
            Assert.AreEqual(user.userRole.GetValue(), sut.userRole.GetValue());

        }
    }
}
