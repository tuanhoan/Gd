using System;
using System.Collections.Generic;
using System.Text;

namespace GD.Models
{
    public class QueryModel<TEntity> where TEntity : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public TEntity Entity { get; set; }
        //public IDictionary<string, SortDesc>
    }

    public class SortDesc
    {
        public int Order { get; set; }
        public SortDirection Direction { get; set; }
    }
    public enum SortDirection
    {
        ASC,
        DESC
    }
}
