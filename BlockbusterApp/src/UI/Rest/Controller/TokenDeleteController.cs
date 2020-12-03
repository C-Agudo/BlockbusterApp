using BlockbusterApp.src.Application.UseCase.Token.Delete;
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
    public class TokenDeleteController : Shared.UI.Rest.Controller.Controller
    {
        public TokenDeleteController(IUseCaseBus useCaseBus) : base(useCaseBus)
        {
        }

        [AllowAnonymous]
        [HttpDelete(Name = nameof(DeleteToken))]
        public IActionResult DeleteToken(DeleteTokenRequest request)
        {
            return Dispatch(request);
        }
    }
}
