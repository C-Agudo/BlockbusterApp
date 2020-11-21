using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Bus.Middleware.Exception
{
    public class ExceptionResponse : IResponse
    {
        public ExceptionResponse(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public string Code { get; }
        public string Message { get; }
    }
}
