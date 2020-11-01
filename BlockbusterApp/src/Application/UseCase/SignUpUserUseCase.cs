using BlockbusterApp.src.Domain;
using BlockbusterApp.src.Domain.CountryAggregate.Service;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase
{
    public class SignUpUserUseCase : IUseCase
    {
        private IUserFactory userFactory;
        private SignUpUserValidator userValidator;
        private IUserRepository userRepository;
        private UserConverter userConverter;
        private CountryCodeValidatorAdapter countryValidator;
        public SignUpUserUseCase(IUserFactory userFactory, SignUpUserValidator userValidator, IUserRepository userRepository, UserConverter userConverter, CountryCodeValidatorAdapter countryValidator)
        {
            this.userFactory = userFactory;
            this.userValidator = userValidator;
            this.userRepository = userRepository;
            this.userConverter = userConverter;
            this.countryValidator = countryValidator;

        }

        public IResponse Execute(IRequest req)
        {
            SignUpUserRequest request = req as SignUpUserRequest;
            User user = userFactory.Create
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

            userValidator.Validate(user.userEmail);
            countryValidator.Validate(user.userCountry);
            userRepository.Add(user);
            return userConverter.Convert();
        }
    }
}
