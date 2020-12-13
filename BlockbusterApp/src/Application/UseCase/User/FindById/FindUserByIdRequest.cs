using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserByIdRequest : IRequest
    {
        public FindUserByIdRequest(string userId)
        {
            this.userId = new UserId(userId);
        }

        public UserId userId { get; }
    }
}
