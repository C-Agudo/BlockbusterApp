using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infrastructure.Bus.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.UI.Rest.Controller
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users/{Id}")]
    [ApiController]
    public class UserGetController : Shared.UI.Rest.Controller.Controller
    {
        public UserGetController(IUseCaseBus useCaseBus) : base(useCaseBus)
        {
        }

        [Authorize(Roles = UserRole.ROLE_USER+","+UserRole.ROLE_ADMIN)]
        [HttpGet(Name = nameof(GetUser))]
        public IActionResult GetUser(FindUserByIdRequest request)
        {
            return Dispatch(request);
        }
    }
}
