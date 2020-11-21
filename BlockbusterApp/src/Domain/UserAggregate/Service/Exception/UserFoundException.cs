using BlockbusterApp.src.Shared.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate.Service.Exception
{
    public class UserFoundException : ValidationException
    {
        public UserFoundException(string value) : base(value)
        {

        }

        public static UserFoundException FromEmail(UserEmail userEmail)
        {
            return new UserFoundException(string.Format("Email " + userEmail.GetValue() + " is already used"));
        }
    }
}
