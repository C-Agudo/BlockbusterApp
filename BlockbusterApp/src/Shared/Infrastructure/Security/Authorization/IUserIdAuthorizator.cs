using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Security.Authorization
{
    public interface IUserIdAuthorizator
    {
        public void Authorize(UserId userId);

    }
}
