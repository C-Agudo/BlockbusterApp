using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.TokenAggregate
{
    public class TokenUpdatedAt : DateTimeValueObject
    {
        public TokenUpdatedAt(DateTime value) : base(value)
        {

        }
    }
}
