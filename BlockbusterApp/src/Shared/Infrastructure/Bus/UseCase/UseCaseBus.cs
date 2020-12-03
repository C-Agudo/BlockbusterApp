using System;
using System.Collections.Generic;
using System.Diagnostics;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infrastructure.Bus.Middleware;

namespace BlockbusterApp.src.Shared.Infrastructure.Bus.UseCase
{
    public class UseCaseBus : IUseCaseBus
    {
        private Dictionary<string, IUseCase> useCases;
        private List<IMiddlewareHandler> middlewareHanders;

        public UseCaseBus()
        {
            useCases = new Dictionary<string, IUseCase>();
        }

        public void SetMiddlewares(List<IMiddlewareHandler> middlewareHanders)
        {
            this.middlewareHanders = middlewareHanders;
        }

        public void Subscribe(IUseCase useCase)
        {
            string useCaseFullName = useCase.GetType().ToString();
            useCases.Add(useCaseFullName, useCase);
        }

        public IResponse Dispatch(IRequest req)
        {
            string previousCallingClass = GetPreviousCallingClass();

            IMiddlewareHandler middlewareHandler = this.loadUseCase(req, previousCallingClass);
            middlewareHandler = this.loadHandlers(previousCallingClass, middlewareHandler);

            return middlewareHandler.Handle(req);
        }

        public static string GetPreviousCallingClass()
        {
            StackTrace stackTrace = new StackTrace();
            var mth = stackTrace.GetFrame(2).GetMethod();
            var cls = mth.ReflectedType.Name;

            return cls;
        }

        private IMiddlewareHandler loadUseCase(IRequest req, string previousCallingClass)
        {
            string requestNamespace = req.GetType().Namespace;            string requestName = req.GetType().Name;
            string useCaseName = requestName.Replace("Request", "UseCase");
            string useCaseFullName = requestNamespace + "." + useCaseName;

            if (!useCases.ContainsKey(useCaseFullName))
            {
                throw new Exception("Not exists the usecase " + useCaseFullName);
            }

            IUseCase useCase = this.useCases[useCaseFullName];


            IMiddlewareHandler middlewareHandler = new UseCaseMiddleware(useCase);

            return middlewareHandler;
        }

        private IMiddlewareHandler loadHandlers(string previousCallingClass, IMiddlewareHandler middlewareHandler)
        {
            foreach (IMiddlewareHandler handler in this.middlewareHanders)
            {
                //excludeTransactionMiddlewareWhenUseCaseBusIsNotExecutingFromController
                if (previousCallingClass != "Controller" && (handler.GetType().Name == "TransactionMiddleware" || handler.GetType().Name == "ExceptionMiddleware"))
                {
                    continue;
                }

                handler.SetNext(middlewareHandler);
                middlewareHandler = handler;
            }

            return middlewareHandler;
        }
    }
}
