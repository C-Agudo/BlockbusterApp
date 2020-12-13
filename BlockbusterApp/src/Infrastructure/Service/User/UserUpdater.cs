using BlockbusterApp.src.Application.UseCase.User.Update;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Infrastructure.Service.Hashing;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Service.User
{
    public class UserUpdater : IUserUpdater
    {
        private IHashing hashing;
        public UserUpdater(IHashing hashing)
        {
            this.hashing = hashing;
        }
        public Domain.UserAggregate.User Update(Domain.UserAggregate.User user, IRequest req)
        {
            UpdateUserRequest request = req as UpdateUserRequest;

            UserHashedPassword requestHashedPassword = hashing.Hash(request.Password);
            if (user.userHashedPassword.GetValue() != requestHashedPassword.GetValue())
            {
                user.userHashedPassword = requestHashedPassword;
            }

            UserFirstname requestFirstName = new UserFirstname(request.FirstName);
            if (user.userFirstname.GetValue() != requestFirstName.GetValue())
            {
                user.userFirstname = requestFirstName;
            }

            UserLastname requestLastName = new UserLastname(request.LastName);
            if (user.userLastname.GetValue() != requestLastName.GetValue())
            {
                user.userLastname = requestLastName;
            }

            return user;
        }
    }
}
