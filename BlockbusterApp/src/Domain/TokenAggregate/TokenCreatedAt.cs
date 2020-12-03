using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.TokenAggregate
{
    public class TokenCreatedAt : DateTimeValueObject
    {
        public TokenCreatedAt(DateTime value) : base(value)
        {

        }
    }
}