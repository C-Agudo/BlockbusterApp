using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate.Service.Exception
{
    public class UserNotFoundByIdException : ValidationException
    {
        public UserNotFoundByIdException(string value) : base(value)
        {

        }

        public static UserNotFoundByIdException FromId(UserId userId)
        {
            return new UserNotFoundByIdException(string.Format("User not found with id " + userId.GetValue()));
        }
    }
}
