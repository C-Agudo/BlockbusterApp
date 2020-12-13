using BlockbusterApp.src.Application.UseCase.User.GetAll;
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
    public class GetUsersController : Shared.UI.Rest.Controller.Controller
    {

        public GetUsersController(IUseCaseBus useCaseBus) : base(useCaseBus)
        {
        }

        [Authorize(Roles = UserRole.ROLE_ADMIN)]
        [HttpGet]
        public IActionResult GetUsers()
        {
            GetAllUsersRequest request = new GetAllUsersRequest(HttpContext.Request.Query);
            return this.Dispatch(request);
        }
    }
}
