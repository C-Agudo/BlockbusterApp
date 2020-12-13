using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service.Exception;
using BlockbusterApp.src.Shared.Infrastructure.Security.Authorization.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Security.Authorization
{
    public class UserIdAuthorizationValidator
    {
        public void Validate(UserId userId, TokenUserId fromTokenUserId)
        {
            if(userId.GetValue() != fromTokenUserId.GetValue())
            {
                throw UserNotAuthorizedException.FromId();
            }
        }
    }
}
