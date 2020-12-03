using BlockbusterApp.src.Domain.UserAggregate.Service.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate.Service
{
    public class FindByIdValidator
    {
        public FindByIdValidator()
        {
            
        }
        public void Validate(User user, UserId userId)
        {
            if (user == null)
            {
                throw UserNotFoundByIdException.FromId(userId);
            }
        }
    }
}
