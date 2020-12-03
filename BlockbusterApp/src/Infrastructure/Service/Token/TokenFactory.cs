using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Shared.Infrastructure.Security.Authentication.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Service.Token
{
    public class TokenFactory : ITokenFactory
    {
        private IJWTEncoder JWTEncoder;

        public TokenFactory(IJWTEncoder JWTEncoder)
        {
            this.JWTEncoder = JWTEncoder;
        }

        public Domain.TokenAggregate.Token Create(Dictionary<string, string> payload)
        {
            string hash = this.JWTEncoder.Encode(payload);
            TokenHash tokenHash = new TokenHash(hash);
            TokenUserId tokenUserId = new TokenUserId(payload["user_id"]);

            return Domain.TokenAggregate.Token.Create(tokenHash, tokenUserId);
        }
    }
}
