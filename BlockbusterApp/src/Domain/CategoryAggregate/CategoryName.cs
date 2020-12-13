using BlockbusterApp.src.Shared.Domain;
using BlockbusterApp.src.Shared.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.CategoryAggregate
{
    public class CategoryName : StringValueObject
    {
        public const int MIN_LENGHT = 3;
        public const int MAX_LENGHT = 30;

        public CategoryName(string value) : base(value)
        {
            if (value.Length > MAX_LENGHT)
            {
                throw InvalidAttributeException.FromMaxLength("CategoryName", MAX_LENGHT);
            }

            if (value.Length < MIN_LENGHT)
            {
                throw InvalidAttributeException.FromMinLength("CategoryName", MIN_LENGHT);
            }
        }
    }
}
