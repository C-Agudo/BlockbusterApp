using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserByIdRequest : IRequest
    {
        public FindUserByIdRequest(UserId userId)
        {
            this.userId = userId;
        }

        public UserId userId { get; }
    }
}
