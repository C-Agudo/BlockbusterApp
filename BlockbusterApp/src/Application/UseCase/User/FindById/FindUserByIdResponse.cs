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
            this.userId = user.userId.GetValue();
            this.userEmail = user.userEmail.GetValue();
            this.userFirstname = user.userFirstname.GetValue();
            this.userLastname = user.userLastname.GetValue();
            this.userCountry = user.userCountry.GetValue();
            this.userRole = user.userRole.GetValue();
        }

        public string userId { get; }
        public string userEmail { get; }
        public string userFirstname { get; }
        public string userLastname { get; }
        public string userCountry { get; }
        public string userRole { get; }

    }
}
