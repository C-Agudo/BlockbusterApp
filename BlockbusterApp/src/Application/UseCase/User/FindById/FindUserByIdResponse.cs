using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserByIdResponse : IResponse
    {
        public FindUserByIdResponse(Domain.UserAggregate.User user)
        {
            this.userId = user.userId;
            this.userEmail = user.userEmail;
            this.userFirstname = user.userFirstname;
            this.userLastname = user.userLastname;
            this.userCountry = user.userCountry;
            this.userRole = user.userRole;
        }

        public UserId userId { get; }
        public UserEmail userEmail { get; }
        public UserFirstname userFirstname { get; }
        public UserLastname userLastname { get; }
        public UserCountry userCountry { get; }
        public UserRole userRole { get; }

    }
}
