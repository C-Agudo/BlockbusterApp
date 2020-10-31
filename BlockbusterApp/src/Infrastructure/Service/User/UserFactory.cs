using BlockbusterApp.src.Domain;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Infrastructure.Service.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Service.User
{
    public class UserFactory : IUserFactory
    {
        private IHashing hashing;
        public UserFactory(IHashing hashing)
        {
            this.hashing = hashing;
        }

        Domain.UserAggregate.User IUserFactory.Create
        (
            string id, 
            string email, 
            string password, 
            string repeatPassword, 
            string firstName, 
            string lastName, 
            string countryCode, 
            string role
        )
        {
            UserId userId = new UserId(id);
            UserEmail userEmail = new UserEmail(email);
            UserPassword userPassword = new UserPassword(password);
            UserFirstname userFirstname = new UserFirstname(firstName);
            UserLastname userLastname = new UserLastname(lastName);
            UserCountry userCountryCode = new UserCountry(countryCode);
            UserRole userRole = new UserRole(role);

            UserPassword.ValidateIsSamePassword(password, repeatPassword);
            UserHashedPassword userHashedPassword =  hashing.Hash(password);

            return Domain.UserAggregate.User.SignUp
            (
                userId,
                userEmail,
                userHashedPassword,
                userFirstname,
                userLastname,
                userCountryCode,
                userRole
            );
        }
    }
}
