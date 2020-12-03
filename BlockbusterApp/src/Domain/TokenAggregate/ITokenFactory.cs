using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.TokenAggregate
{
    public interface ITokenFactory
    {
        public Token Create(Dictionary<string, string> payload);
    }
}
