using BlockbusterApp.src.Domain.TokenAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Security.Authentication.JWT
{
    public interface IJWTDecoder
    {
        public TokenUserId DecodeUserId(string token);

    }
}
