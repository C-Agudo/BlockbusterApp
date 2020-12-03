using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserByIdConverter
    {
        public IResponse Convert(Domain.UserAggregate.User user)
        {
            return new FindUserByIdResponse(user);
        }
    }
}
