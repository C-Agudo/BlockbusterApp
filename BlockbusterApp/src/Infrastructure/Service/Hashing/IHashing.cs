using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Service.Hashing
{
    public interface IHashing
    {
        UserHashedPassword Hash(string password);
    }
}
