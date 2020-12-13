using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Category.Create
{
    public class CreateCategoryRequest : IRequest
    {
        public string categoryId { get; }
        public string categoryName { get; }

        public CreateCategoryRequest(string categoryId, string categoryName)
        {
            this.categoryId = categoryId;
            this.categoryName = categoryName;
        }
    }
}
