using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.GetAll
{
    public class GetAllUsersAtributes : IAtributes
    {
        public string id;
        public string email;
        public string fistName;
        public string lastName;
        public string countryCode;
        public string role;

        public GetAllUsersAtributes
        (
            string id,
            string email,
            string fistName,
            string lastName,
            string countryCode,
            string role
        )
        {
            this.id = id;
            this.email = email;
            this.fistName = fistName;
            this.lastName = lastName;
            this.countryCode = countryCode;
            this.role = role;
        }
    }
}
