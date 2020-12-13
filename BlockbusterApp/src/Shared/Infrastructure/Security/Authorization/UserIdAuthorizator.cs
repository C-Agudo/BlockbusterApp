using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infrastructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Security.Authorization
{
    public class UserIdAuthorizator : IUserIdAuthorizator
    {
        
        private IJWTDecoder decoder;
        private AccesTokenGetter accesTokenGetter;
        private UserIdAuthorizationValidator validator;
        public UserIdAuthorizator
        (
            IJWTDecoder decoder,
            AccesTokenGetter accesTokenGetter,
            UserIdAuthorizationValidator validator
        )
        {
            this.decoder = decoder;
            this.accesTokenGetter = accesTokenGetter;
            this.validator = validator;
        }
        public void Authorize(UserId userId)
        {
            string accesToken = accesTokenGetter.GetTokenFromHeader();
            TokenUserId userIdFromToken = decoder.DecodeUserId(accesToken);
            validator.Validate(userId, userIdFromToken);
        }
    }
}
