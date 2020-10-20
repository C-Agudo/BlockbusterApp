using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Bus.UseCase
{
    public class UseCaseBus : IUseCaseBus
    {
        private Dictionary<string, IUseCase> useCases;

        public UseCaseBus()
        {
            useCases = new Dictionary<string, IUseCase>();
        }

        public void Subscribe(IUseCase useCase)
        {
            string className = useCase.GetType().ToString();
            useCases.Add(className, useCase);
        }

        public IResponse Dispatch(IRequest req)
        {
            string className = req.GetType().ToString();
            string[] words = className.Split(new string[] { "Request" }, StringSplitOptions.None);

            string useCaseName = words[0] + "UseCase";

            if (!useCases.ContainsKey(useCaseName))
            {
                throw new Exception("Not exists the usecase " + useCaseName);
            }

            return useCases[useCaseName].Execute(req);
        }
    }
}
