using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.TokenAggregate
{
    public interface ITokenRepository
    {
        public void Add(Token token);
        public void Update(Token token);
        public Token FindById(TokenUserId userId);
        public void Delete(TokenUserId userId);


    }
}
