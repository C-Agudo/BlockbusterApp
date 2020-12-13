using BlockbusterApp.src.Application.UseCase.Category;
using BlockbusterApp.src.Domain.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Service.Category
{
    public class CategoryFactory : ICategoryFactory
    {
        public Domain.CategoryAggregate.Category Create(string id, string name)
        {
            CategoryId categoryId = new CategoryId(id);
            CategoryName categoryName = new CategoryName(name);

            Domain.CategoryAggregate.Category category = Domain.CategoryAggregate.Category.Create(categoryId, categoryName);
            return category;
        }
    }
}
