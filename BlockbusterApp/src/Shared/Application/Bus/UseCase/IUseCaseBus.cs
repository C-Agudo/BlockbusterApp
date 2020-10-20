using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase
{
    public interface IUseCaseBus
    {
        void Subscribe(IUseCase useCase);
        IResponse Dispatch(IRequest req);
    }
}
