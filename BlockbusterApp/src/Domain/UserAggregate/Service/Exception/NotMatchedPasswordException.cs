using BlockbusterApp.src.Shared.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate.Service.Exception
{
    public class NotMatchedPasswordException : ValidationException
    {
        public NotMatchedPasswordException(string value) : base(value)
        {

        }
        public static NotMatchedPasswordException FromPassword()
        {
            return new NotMatchedPasswordException("Not Matched Password");
        }
    }
}
