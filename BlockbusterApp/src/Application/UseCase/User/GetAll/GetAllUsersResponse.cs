using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.GetAll
{
    public class GetAllUsersResponse : Response, IResponse
    {
        public GetAllUsersResponse(List<Data> data) : base(data)
        {
            
        }

        
    }
}
