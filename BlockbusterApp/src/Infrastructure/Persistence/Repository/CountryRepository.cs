using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Context;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Persistence.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly IServiceScopeFactory scopeFactory;

        public CountryRepository(BlockbusterAppContext context, IServiceScopeFactory scopeFactory) : base(context)
        {
            this.scopeFactory = scopeFactory;

        }
        public Country FindCountryByCode(CountryCode code)
        {
            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterAppContext>();
                return dbContext.Countries.FirstOrDefault(c => c.code.GetValue() == c.code.GetValue());
            }
        }
    }
}
