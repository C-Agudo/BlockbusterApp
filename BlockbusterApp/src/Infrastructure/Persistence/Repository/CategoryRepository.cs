using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Context;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Persistence.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly IServiceScopeFactory scopeFactory;
        private IServiceScope scope;
        private BlockbusterAppContext dbContext;
        public CategoryRepository(BlockbusterAppContext context, IServiceScopeFactory scopeFactory) : base(context)
        {
            this.scopeFactory = scopeFactory;
            this.scope = scopeFactory.CreateScope();
            this.dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterAppContext>();
        }
        public void Add(Category category)
        {
            dbContext.Categories.Add(category);
        }
    }
}
