using BlockbusterApp.src.Application.UseCase.User.Find;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infrastructure.Service.Hashing;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infrastructure.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Service.Token
{
    public class TokenFacade
    {
        private IUserRepository userRepository;
        private IUseCaseBus useCaseBus;
        private IHashing hashing;
        private PasswordValidator passwordValidator;

        public TokenFacade
        (
            IUserRepository userRepository, 
            IUseCaseBus useCaseBus, 
            IHashing hashing,
            PasswordValidator passwordValidator
        )
        {
            this.userRepository = userRepository;
            this.useCaseBus = useCaseBus;
            this.hashing = hashing;
            this.passwordValidator = passwordValidator;
        }

        public Domain.UserAggregate.User FindUserFromEmailAndPassword(string email, string password)
        {
            FindUserByEmailResponse res = (FindUserByEmailResponse)useCaseBus.Dispatch(new FindUserByEmailRequest(email));
            Domain.UserAggregate.User user = res.User;
            passwordValidator.Validate(hashing.Hash(password).GetValue(), user.userHashedPassword.GetValue());
            return user;
        }

    }
}
