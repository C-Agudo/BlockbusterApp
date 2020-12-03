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

        public string DecodeUserId(string hashToken)
        {
            var stream = hashToken;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = handler.ReadToken(stream) as JwtSecurityToken;
            var userId = tokenS.Claims.First(claim => claim.Type == "user_id").Value;

            return userId;
        }
    }
}
