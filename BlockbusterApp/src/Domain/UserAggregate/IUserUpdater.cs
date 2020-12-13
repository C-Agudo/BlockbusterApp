using BlockbusterApp.src.Application.UseCase.User.Update;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public interface IUserUpdater
    {
        public Domain.UserAggregate.User Update(Domain.UserAggregate.User user, IRequest request);
    }
}
