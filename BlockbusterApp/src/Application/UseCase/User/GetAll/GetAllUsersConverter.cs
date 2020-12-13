using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.GetAll
{
    public class GetAllUsersConverter
    {
        public IResponse Convert(IEnumerable<Domain.UserAggregate.User> users)
        {
            List<Data> usersConverted = new List<Data>();
            
            foreach (var user in users)
            {

                string id = user.userId.GetValue();
                string email = user.userEmail.GetValue();
                string firstName = user.userFirstname.GetValue();
                string lastName = user.userLastname.GetValue();
                string countryCode = user.userCountry.GetValue();
                string role = user.userRole.GetValue();

                GetAllUsersAtributes atributes = new GetAllUsersAtributes(id,email,firstName,lastName,countryCode,role);
                Data data = new Data(Data.USERS, id, atributes);
                usersConverted.Add(data);
            }

            GetAllUsersResponse response = new GetAllUsersResponse(usersConverted);

            return response;
        }
    }
}
