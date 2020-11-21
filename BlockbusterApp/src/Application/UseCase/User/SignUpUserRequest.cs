using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User
{
    public class SignUpUserRequest : IRequest
    {
        public SignUpUserRequest
        (
            string id,
            string email,
            string password,
            string repeatPassword,
            string firstname,
            string lastname,
            string country,
            string role
        )
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.RepeatPassword = repeatPassword;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Country = country;
            this.Role = role;
        }

        public string Id { get; }
        public string Email { get; }
        public string Password { get; }
        public string RepeatPassword { get; }
        public string Firstname { get; }
        public string Lastname { get; }
        public string Country { get; }
        public string Role { get; }

    }
}
