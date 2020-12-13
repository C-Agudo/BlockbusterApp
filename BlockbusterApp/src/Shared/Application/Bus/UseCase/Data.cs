using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase
{
    public class Data
    {
        public const string USERS = "users";

        public string type { get; }
        public string id { get; }
        public IAtributes atributes { get; }

        public Data
        (
            string type,
            string id,
            IAtributes atributes
        )
        {
            this.type = type;
            this.id = id;
            this.atributes = atributes;
        }
    }
}
