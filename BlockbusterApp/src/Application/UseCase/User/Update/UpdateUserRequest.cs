using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.Update
{
    public class UpdateUserRequest : IRequest
    {
        public UpdateUserRequest(string userId, string password, string firstName, string lastName)
        {
            this.UserId = new UserId(userId);
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public UserId UserId { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
