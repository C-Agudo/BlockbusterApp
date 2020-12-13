using BlockbusterApp.src.Application.UseCase.Token;
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
    public class TokenPostController : Shared.UI.Rest.Controller.Controller
    {
        public TokenPostController(IUseCaseBus useCaseBus) : base(useCaseBus)
        {
        }

        [AllowAnonymous]
        [HttpPost(Name = nameof(Loggin))]
        public IActionResult Loggin(CreateTokenRequest request)
        {
            return Dispatch(request);
        }
    }
}
