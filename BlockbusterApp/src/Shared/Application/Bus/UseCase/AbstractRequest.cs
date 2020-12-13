using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase
{
    public abstract class AbstractRequest : IRequest
    {
        private Pagination pagination;

        public AbstractRequest(IQueryCollection query)
        {
            this.pagination = new Pagination(query);
        }

        public Dictionary<string, int> Page()
        {
            return pagination.Page();
        }
    }
}
