using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Parameters
{
    public abstract class BaseQueryParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string TextSearch { get; set; }

        public BaseQueryParameter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public BaseQueryParameter(int pageNumber, int pageSize, string textSearch = null)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
            this.TextSearch = textSearch;
        }
    }
}
