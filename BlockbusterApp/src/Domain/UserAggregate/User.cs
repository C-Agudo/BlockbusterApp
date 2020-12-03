
using BlockbusterApp.src.Domain.UserAggregate.Event;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class User : AggregateRoot
    {
        public UserId userId { get; }
        public UserEmail userEmail { get; }
        public UserHashedPassword userHashedPassword { get; }
        public UserFirstname userFirstname { get; }
        public UserLastname userLastname { get; }
        public UserCountry userCountry { get; }
        public UserRole userRole { get; }

        public User 
        (
            UserId userId,
            UserEmail userEmail,
            UserHashedPassword userHashedPassword,
            UserFirstname userFirstname,
            UserLastname userLastname,
            UserCountry userCountry,
            UserRole userRole
        )
        {
            this.userId = userId;
            this.userEmail = userEmail;
            this.userHashedPassword = userHashedPassword;
            this.userFirstname = userFirstname;
            this.userLastname = userLastname;
            this.userCountry = userCountry;
            this.userRole = userRole;

        }

        public static User SignUp
        (   
            UserId userId, 
            UserEmail userEmail, 
            UserHashedPassword userHashedPassword,
            UserFirstname userFirstname,
            UserLastname userLastname,
            UserCountry userCountry,
            UserRole userRole
        )
        {
            User user =  new User
            (
                userId, 
                userEmail, 
                userHashedPassword, 
                userFirstname,
                userLastname,
                userCountry,
                userRole
            );

            user.Record(new UserSignedUpEvent(
                user.userId.GetValue(),
                new Dictionary<string, string>()
                    {
                        ["email"] = user.userEmail.GetValue(),
                        ["firstname"] = user.userFirstname.GetValue(),
                        ["lastname"] = user.userLastname.GetValue(),
                        ["role"] = user.userRole.GetValue()
                    }
            ));


            return user;
        }
    }
}
