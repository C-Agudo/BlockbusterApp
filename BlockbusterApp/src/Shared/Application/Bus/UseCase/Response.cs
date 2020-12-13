using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase
{
    public class Response
    {
        public List<Data> data { get;}
        public Response(List<Data> data)
        {
            this.data = data;
        }
    }
}
