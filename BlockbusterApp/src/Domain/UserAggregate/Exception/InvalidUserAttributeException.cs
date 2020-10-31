using BlockbusterApp.src.Shared.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate.Exception
{
    public class InvalidUserAttributeException : InvalidAttributeException
    {
        public InvalidUserAttributeException(string message) : base(message) { }

    }

}
