using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Repository;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Persistence.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IServiceScopeFactory scopeFactory;
        private IServiceScope scope;
        private BlockbusterAppContext dbContext;
        public UserRepository(BlockbusterAppContext context, IServiceScopeFactory scopeFactory) : base(context)
        {
            this.scopeFactory = scopeFactory;
            this.scope = scopeFactory.CreateScope();
            this.dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterAppContext>();
        }
        public void Add(User user)
        {
                dbContext.Users.Add(user);
        }

        public User FindUserByEmail(UserEmail userEmail)
        {
            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                return dbContext.Users.FirstOrDefault(c => c.userEmail.GetValue() == c.userEmail.GetValue());
            }
        }
    }
}
