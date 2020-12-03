using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.Find
{
    public class FindUserByEmailResponse : IResponse
    {
        public FindUserByEmailResponse(Domain.UserAggregate.User user)
        {
            this.User = user;
        }

        public Domain.UserAggregate.User User { get; }

    }
}
