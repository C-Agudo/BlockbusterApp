using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infrastructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infrastructure.Security.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.Update
{
    public class UpdateUserUseCase : IUseCase
    {
        private IUseCaseBus useCaseBus;
        private FindByIdValidator findByIdValidator;
        private IUserIdAuthorizator userIdAuthorizator;
        private IUserRepository userRepository;
        private IUserUpdater userUpdater;
        private UpdateUserConverter userConverter;
        public UpdateUserUseCase
        (
            IUseCaseBus useCaseBus,
            FindByIdValidator findByIdValidator,
            IUserIdAuthorizator userIdAuthorizator,
            IUserRepository userRepository,
            IUserUpdater userUpdater,
            UpdateUserConverter userConverter
        )
        {
            this.useCaseBus = useCaseBus;
            this.findByIdValidator = findByIdValidator;
            this.userIdAuthorizator = userIdAuthorizator;
            this.userRepository = userRepository;
            this.userUpdater = userUpdater;
            this.userConverter = userConverter;
        }
        public IResponse Execute(IRequest req)
        {
            UpdateUserRequest request = req as UpdateUserRequest;

            userIdAuthorizator.Authorize(request.UserId);
            Domain.UserAggregate.User user = userRepository.FindUserById(request.UserId);
            findByIdValidator.Validate(user, request.UserId);
            Domain.UserAggregate.User updatedUser = userUpdater.Update(user, request);
            userRepository.Update(updatedUser);
            return userConverter.Convert();
        }
    }
}
