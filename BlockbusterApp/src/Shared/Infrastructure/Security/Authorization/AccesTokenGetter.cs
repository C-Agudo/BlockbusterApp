using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Security.Authorization
{
    public class AccesTokenGetter
    {
        private IHttpContextAccessor httpContextAccessor;

        public AccesTokenGetter(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetTokenFromHeader()
        {
            string accessToken = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            return accessToken;
        }
    }
}
