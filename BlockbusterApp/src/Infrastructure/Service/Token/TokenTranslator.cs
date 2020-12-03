using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Service.Token
{
    public class TokenTranslator
    {
        public Dictionary<string, string> FromRepresentationToPayload(Domain.UserAggregate.User user)
        {
            return new Dictionary<string, string>()
            {
                ["user_id"] = user.userId.GetValue(),
                ["email"] = user.userEmail.GetValue(),
                ["first_name"] = user.userFirstname.GetValue(),
                ["last_name"] = user.userLastname.GetValue(),
                ["role"] = user.userRole.GetValue(),
            };
        }
    }
}
