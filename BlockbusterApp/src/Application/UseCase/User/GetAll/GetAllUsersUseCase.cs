using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.GetAll
{
    public class GetAllUsersUseCase : IUseCase
    {
        private IUserRepository userRepository;
        private GetAllUsersConverter usersConverter;

        public GetAllUsersUseCase
        (
            IUserRepository userRepository,
            GetAllUsersConverter usersConverter
        )
        {
            this.userRepository = userRepository;
            this.usersConverter = usersConverter;
        }

        public IResponse Execute(IRequest req)
        {
            GetAllUsersRequest request = req as GetAllUsersRequest;

            List<Domain.UserAggregate.User> users = userRepository.GetUsers(request.Page());

            return usersConverter.Convert(users);
        }
    }
}
