using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.Tests.Domain.UserAggregate.Mothers
{
    public class UserIdMother
    {
        public const string UUID = "31aab8f4-4a51-4c2a-b424-cc0e5e679053";
        public static UserId Create()
        {
            return new UserId(UUID);
        }
    }
}
