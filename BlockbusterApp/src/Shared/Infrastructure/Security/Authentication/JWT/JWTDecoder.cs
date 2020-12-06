using BlockbusterApp.src.Domain.TokenAggregate;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Security.Authentication.JWT
{
    public class JWTDecoder : IJWTDecoder
    {
        
        public JWTDecoder()
        {

        }

        public TokenUserId DecodeUserId(string hashToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(hashToken);
            var tokenS = handler.ReadToken(hashToken) as JwtSecurityToken;
            var userId = tokenS.Claims.First(claim => claim.Type == "user_id").Value;

            return new TokenUserId(userId);
        }
    }
}
