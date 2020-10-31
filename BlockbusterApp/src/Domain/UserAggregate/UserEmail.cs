using BlockbusterApp.src.Domain.UserAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class UserEmail : StringValueObject
    {
        public UserEmail(string value) : base(value)
        {
            try
            {
                new System.Net.Mail.MailAddress(value);
            }
            catch
            {
                throw InvalidUserAttributeException.FromValue("email",value);
            }
        }
    }
}
