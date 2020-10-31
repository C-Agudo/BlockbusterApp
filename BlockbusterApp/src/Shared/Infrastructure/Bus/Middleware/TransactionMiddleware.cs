using System;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BlockbusterApp.src.Shared.Infrastructure.Bus.Middleware
{
    public class TransactionMiddleware : MiddlewareHandler
    {
        private BlockbusterAppContext blockbusterAppContext;

        public TransactionMiddleware(BlockbusterAppContext blockbusterAppContext)
        {
            this.blockbusterAppContext = blockbusterAppContext;
        }

        public override IResponse Handle(IRequest request)
        {
            var transaction = blockbusterAppContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            try
            {
                IResponse response = base.Handle(request);
                blockbusterAppContext.SaveChanges();
                transaction.Commit();
                return response;
            }
            catch(System.Exception e)
            {
                transaction.Rollback();
                throw e;
            }

            
        }
    }
}
