using System;
using System.Collections.Generic;
using System.Text;

namespace GD.Models
{
    public class  PagedResult<T>
    {
        public PagedResult(IEnumerable<T> data, int currentPage, int pageCount, int pageSize, int rowCount)
        {
            Data = data;
            CurrentPage = currentPage;
            PageCount = pageCount;
            PageSize = pageSize;
            RowCount = rowCount;
        }

        public IEnumerable<T> Data { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageCount { get; private set; }
        public int PageSize { get; private set; }
        public int RowCount { get; private set; }

    }
}
