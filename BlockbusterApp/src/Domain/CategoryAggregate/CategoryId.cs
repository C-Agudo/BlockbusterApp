using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.CategoryAggregate
{
    public class CategoryId : UUID
    {
        public CategoryId(string message) : base(message)
        {

        }
    }
}
