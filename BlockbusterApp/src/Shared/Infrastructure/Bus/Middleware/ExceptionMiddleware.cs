using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Domain.Exception;
using BlockbusterApp.src.Shared.Infrastructure.Bus.Middleware.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Bus.Middleware
{
    public class ExceptionMiddleware : MiddlewareHandler
    {
        private ExceptionConverter converter;
        public ExceptionMiddleware(ExceptionConverter converter)
        {
            this.converter = converter;
        }

        public override IResponse Handle(IRequest request)
        {
            try
            {
                IResponse response = base.Handle(request);
                return response;
            }
            catch(ValidationException validation)
            {
                return converter.Convert("400", validation.Message);
            }
            catch (System.Exception exception)
            {
                return converter.Convert("500", exception.Message);
            }
        }
    }
}
