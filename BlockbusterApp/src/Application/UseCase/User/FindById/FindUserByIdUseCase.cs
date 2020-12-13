using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infrastructure.Security.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
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
        private IUserIdAuthorizator userIdAuthorizator;
        public FindUserByIdUseCase
        (
                IUserRepository userRepository,
                FindUserByIdConverter userConverter,
                FindByIdValidator findByIdValidator,
                IUserIdAuthorizator userIdAuthorizator
        )
        {
            this.userRepository = userRepository;
            this.userConverter = userConverter;
            this.findByIdValidator = findByIdValidator;
            this.userIdAuthorizator = userIdAuthorizator;
        }
        public IResponse Execute(IRequest req)
        {
            FindUserByIdRequest request = req as FindUserByIdRequest;
            userIdAuthorizator.Authorize(request.userId);
            Domain.UserAggregate.User user = userRepository.FindUserById(request.userId);
            findByIdValidator.Validate(user, request.userId);

            return userConverter.Convert(user);
        }
    }
}
