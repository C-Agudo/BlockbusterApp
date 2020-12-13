using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Bus.UseCase
{
    public class Pagination
    {
        private Dictionary<string, int> page;
        public const int DEFAULT_PAGE_NUMBER = 1;
        public const int DEFAULT_PAGE_SIZE = 10;
        public const string QUERY_PAGE_NUMBER = "page[number]";
        public const string QUERY_PAGE_SIZE = "page[size]";
        public const string STR_NUMBER = "number";
        public const string STR_SIZE = "size";
        public const int MIN = 0;  
        public Pagination(IQueryCollection query)
        {
            this.SetPage(query[QUERY_PAGE_NUMBER], query[QUERY_PAGE_SIZE]);
        }

        private void SetPage(StringValues pageNumber, StringValues pageSize)
        {
            this.page = new Dictionary<string, int>();

            this.page.Add(STR_NUMBER, DEFAULT_PAGE_NUMBER);
            if(pageNumber.Count > MIN)
            {
                this.page[STR_NUMBER] = System.Int16.Parse(pageNumber.ToString());
            }

            this.page.Add(STR_SIZE, DEFAULT_PAGE_SIZE);
            if (pageSize.Count > MIN)
            {
                this.page[STR_SIZE] = System.Int16.Parse(pageSize.ToString());
            }
        }

        public Dictionary<string, int> Page()
        {
            return this.page;
        }
        
    }
}
