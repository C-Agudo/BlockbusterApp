using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Repository;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

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
            using IServiceScope scope = scopeFactory.CreateScope();
            User user = dbContext.Users.SingleOrDefault(u => u.userEmail.GetValue() == userEmail.GetValue());
            return user;
        }
        public User FindUserById(UserId userId)
        {
            using IServiceScope scope = scopeFactory.CreateScope();
            return dbContext.Users.FirstOrDefault(c => c.userId.GetValue() == userId.GetValue());
        }

        public void Update(User updatedUser)
        {
            dbContext.Users.Update(updatedUser);
        }

        public List<User> GetUsers(Dictionary<string, int> page)
        {
            return dbContext.Users.Skip((page[Pagination.STR_NUMBER]-1) * page[Pagination.STR_SIZE]).ToList();
        }
    }
}
