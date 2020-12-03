using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.FindById
{
    public class FindUserByIdUseCase : IUseCase
    {
        private IUserRepository userRepository;
        private FindUserByIdConverter userConverter;
        private FindByIdValidator findByIdValidator;
        public FindUserByIdUseCase
        (
                IUserRepository userRepository,
                FindUserByIdConverter userConverter,
                FindByIdValidator findByIdValidator
        )
        {
            this.userRepository = userRepository;
            this.userConverter = userConverter;
            this.findByIdValidator = findByIdValidator;
        }
        public IResponse Execute(IRequest req)
        {
            FindUserByIdRequest request = req as FindUserByIdRequest;
            Domain.UserAggregate.User user = userRepository.FindUserById(request.userId);
            findByIdValidator.Validate(user, request.userId);

            return userConverter.Convert(user);
        }
    }
}
