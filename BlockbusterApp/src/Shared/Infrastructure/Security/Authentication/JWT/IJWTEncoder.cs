using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Security.Authentication.JWT
{
    public interface IJWTEncoder
    {
        public string Encode(Dictionary<string, string> payload);
    }
}
