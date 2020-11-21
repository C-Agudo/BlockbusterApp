using BlockbusterApp.src.Application.UseCase.Country;
using BlockbusterApp.src.Domain;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Domain.Event;
using BlockbusterApp.src.Shared.Infrastructure.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User
{
    public class SignUpUserUseCase : IUseCase
    {
        private IUserFactory userFactory;
        private SignUpUserValidator userValidator;
        private IUserRepository userRepository;
        private UserConverter userConverter;
        private IEventProvider eventProvider;
        private IUseCaseBus useCaseBus;
        public SignUpUserUseCase
        (
            IUserFactory userFactory, 
            SignUpUserValidator userValidator, 
            IUserRepository userRepository, 
            UserConverter userConverter, 
            IEventProvider eventProvider,
            IUseCaseBus useCaseBus
        )
        {
            this.userFactory = userFactory;
            this.userValidator = userValidator;
            this.userRepository = userRepository;
            this.userConverter = userConverter;
            this.eventProvider = eventProvider;
            this.useCaseBus = useCaseBus;
        }

        public IResponse Execute(IRequest req)
        {
            SignUpUserRequest request = req as SignUpUserRequest;
            Domain.UserAggregate.User user = userFactory.Create
            (
                request.Id,
                request.Email,
                request.Password,
                request.RepeatPassword,
                request.Firstname,
                request.Lastname,
                request.Country,
                request.Role
            );

            eventProvider.RecordEvents(user.ReleaseEvents());
            userValidator.Validate(user.userEmail);
            useCaseBus.Dispatch(new FindCountryRequest(user.userCountry.GetValue()));
            userRepository.Add(user);
            return userConverter.Convert();
        }
    }
}
