using System;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infrastructure.Security.Authorization;

namespace BlockbusterApp.src.Shared.Infrastructure.Bus.Middleware
{
    public class UseCaseMiddleware : MiddlewareHandler
    {
        private IUseCase useCase;
        public UseCaseMiddleware(IUseCase useCase)
        {
            this.useCase = useCase;
        }

        public override IResponse Handle(IRequest request)
        {
            return useCase.Execute(request);
        }
    }
}
