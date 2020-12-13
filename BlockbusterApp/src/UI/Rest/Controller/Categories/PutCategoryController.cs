using BlockbusterApp.src.Application.UseCase.Category.Create;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infrastructure.Bus.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.UI.Rest.Controller.Categories
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/categories")]
    [ApiController]
    public class PutCategoryController : Shared.UI.Rest.Controller.Controller
    {

        public PutCategoryController(IUseCaseBus useCaseBus) : base(useCaseBus)
        {
        }

        [Authorize(Roles = UserRole.ROLE_ADMIN)]
        [HttpPut]
        public IActionResult Create(CreateCategoryRequest request)
        {
            return Dispatch(request);
        }
    }
}
