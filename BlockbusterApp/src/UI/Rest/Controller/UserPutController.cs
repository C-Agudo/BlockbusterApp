using BlockbusterApp.src.Application.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
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
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserPutController : ControllerBase
    {
        private IUseCaseBus useCaseBus;

        public UserPutController(IUseCaseBus useCaseBus)
        {
            this.useCaseBus = useCaseBus;
        }

        [AllowAnonymous]
        [HttpPut(Name = nameof(SignUp))]
        public IActionResult SignUp(SignUpUserRequest request)
        {
            IResponse response = this.useCaseBus.Dispatch(request);
            return Ok(response);
        }
    }
}
