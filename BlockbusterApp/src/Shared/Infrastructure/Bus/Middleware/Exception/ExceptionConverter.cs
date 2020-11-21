using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Bus.Middleware.Exception
{
    public class ExceptionConverter
    {
        public ExceptionConverter()
        {

        }

        public IResponse Convert(string code, string message)
        {
            return new ExceptionResponse(code, message);
        }
    }
}
