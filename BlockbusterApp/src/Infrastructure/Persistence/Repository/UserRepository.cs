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

        public UserRepository(BlockbusterAppContext context, IServiceScopeFactory scopeFactory) : base(context)
        {
            this.scopeFactory = scopeFactory;
        }
        public void Add(User user)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterAppContext>();
                dbContext.Users.Add(user);
            }
        }

        public User FindUserByEmail(UserEmail userEmail)
        {
           using (IServiceScope scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterAppContext>();
                return dbContext.Users.FirstOrDefault(c => c.userEmail.GetValue() == c.userEmail.GetValue());
            }
        }
    }
}
