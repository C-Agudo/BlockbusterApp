using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.CategoryAggregate
{
    public class Category : AggregateRoot
    {
        [Key]
        public CategoryId categoryId { get; }
        public CategoryName categoryName { get; }

        private Category
        (
            CategoryId categoryId,
            CategoryName categoryName
        )
        {
            this.categoryId = categoryId;
            this.categoryName = categoryName;
        }

        public static Category Create
        (
            CategoryId categoryId,
            CategoryName categoryName
        )
        {
            Category category = new Category(categoryId, categoryName);
            return category;
        }
    }
}
