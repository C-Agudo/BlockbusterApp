using BlockbusterApp.src.Shared.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Security.Authorization.Exception
{
    public class UserNotAuthorizedException : ValidationException
    {
        public UserNotAuthorizedException(string value) : base(value)
        {

        }

        public static UserNotAuthorizedException FromId()
        {
            return new UserNotAuthorizedException("User not authorized");
        }
    }
}
