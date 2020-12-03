using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Context;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Persistence.Repository
{
    public class TokenRepository : Repository<Token>, ITokenRepository
    {
        private readonly IServiceScopeFactory scopeFactory; 
        private IServiceScope scope;
        private BlockbusterAppContext dbContext;
        public TokenRepository(BlockbusterAppContext context, IServiceScopeFactory scopeFactory) : base(context)
        {
            this.scopeFactory = scopeFactory;
            this.scope = scopeFactory.CreateScope();
            this.dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterAppContext>();
        }
        public void Add(Token token)
        {
            dbContext.Tokens.Add(token);
        }

        public void Update(Token token)
        {
            Token dbToken = this.FindById(token.userId);

            if (dbToken.hash != token.hash)
            {
                dbToken.SetTokenHash(token.hash);
            }
            if (dbToken.updatedAt != token.updatedAt)
            {
                dbToken.SetTokenUpdatedAt(token.updatedAt);
            }

            dbContext.Tokens.Update(dbToken);
        }

        public Token FindById(TokenUserId userId)
        {
            return dbContext.Tokens.FirstOrDefault(c => c.userId.GetValue() == c.userId.GetValue());
        }

        public void Delete(string userId)
        {
            DbSet.Remove(DbSet.Find(new TokenUserId(userId)));
        }
    }
}
