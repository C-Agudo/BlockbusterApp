using BlockbusterApp.src.Application.UseCase.Token.Update;
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
    [Route("api/v{version:apiVersion}/tokens")]
    [ApiController]
    public class TokenPatchController : Shared.UI.Rest.Controller.Controller
    {
        public TokenPatchController(IUseCaseBus useCaseBus) : base(useCaseBus)
        {
        }

        [AllowAnonymous]
        [HttpPatch(Name = nameof(UpdateToken))]
        public IActionResult UpdateToken(UpdateTokenRequest request)
        {
            return Dispatch(request);
        }
    }
}

