using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Service.Token
{
    public class TokenAdapter
    {
        private TokenFacade tokenFacade;
        private TokenTranslator tokenTranslator;

        public TokenAdapter(TokenFacade tokenFacade, TokenTranslator tokenTranslator)
        {
            this.tokenFacade = tokenFacade;
            this.tokenTranslator = tokenTranslator;
        }

        public Dictionary<string, string> FindPayloadFromEmailAndPassword(string email, string password)
        {
            Domain.UserAggregate.User user = this.tokenFacade.FindUserFromEmailAndPassword(email, password);
            return this.tokenTranslator.FromRepresentationToPayload(user);
        }
    }
}
