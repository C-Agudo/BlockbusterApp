using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain
{
    public interface IUserFactory
    {
        User Create
        (
            string id,
            string email,
            string password,
            string repeatPassword,
            string firstName,
            string lastName,
            string countryCode,
            string role
        );
    }
}
