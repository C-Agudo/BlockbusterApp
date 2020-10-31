using BlockbusterApp.src.Domain.UserAggregate.Service.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate.Service
{    
    public class SignUpUserValidator
    {
        private IUserRepository userRepository;
        public SignUpUserValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Validate(UserEmail userEmail)
        {
            User user = userRepository.FindUserByEmail(userEmail);

            if(user is User)
            {
                throw UserFoundException.FromEmail(userEmail);
            }
        }
    }
}
