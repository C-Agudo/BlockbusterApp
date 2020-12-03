using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.Find
{
    public class FindUserByEmailUseCase : IUseCase
    {
        private IUserRepository userRepository;
        private FindUserByEmailConverter userConverter;
        public FindUserByEmailUseCase
        (
            IUserRepository userRepository,
            FindUserByEmailConverter userConverter
        )
        {
            this.userRepository = userRepository;
            this.userConverter = userConverter;
        }
        public IResponse Execute(IRequest req)
        {
            FindUserByEmailRequest request = req as FindUserByEmailRequest;

            Domain.UserAggregate.User user = userRepository.FindUserByEmail(new UserEmail(request.Email));
            return userConverter.Convert(user);
        }
    }
}
