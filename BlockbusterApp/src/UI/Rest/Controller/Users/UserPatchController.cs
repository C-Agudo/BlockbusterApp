using BlockbusterApp.src.Application.UseCase.User.Update;
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
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    public class UserPatchController : Shared.UI.Rest.Controller.Controller
    {
        public UserPatchController(IUseCaseBus useCaseBus) : base(useCaseBus)
        {
        }

        [Authorize(Roles = UserRole.ROLE_USER + "," + UserRole.ROLE_ADMIN)]
        [HttpPatch(Name = nameof(UpdateUser))]
        public IActionResult UpdateUser(UpdateUserRequest request)
        {
            return Dispatch(request);
        }
    }
}
