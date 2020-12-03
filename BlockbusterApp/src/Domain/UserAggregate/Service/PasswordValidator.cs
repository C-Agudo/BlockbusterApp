using BlockbusterApp.src.Domain.UserAggregate.Service.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate.Service
{
    public class PasswordValidator
    {
        public PasswordValidator()
        {

        }

        public void Validate(string requestPassword, string userPassword)
        {
            if(requestPassword != userPassword)
            {
                throw NotMatchedPasswordException.FromPassword();
            }
        }
    }
}
