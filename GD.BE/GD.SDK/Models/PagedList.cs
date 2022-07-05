using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GD.SDK.Models
{
    public interface IPagedList : IList
    {
        int TotalCount { get; }
        int PageSize { get; }
        int PageNumber { get; }
        int PagesCount { get; }
    }
    public interface IPagedQueryable<T> : IQueryable<T>
    {
        int PageSize { get; }
        int PageNumber { get; }
    }
    public class PageQueryable<T> : IPagedQueryable<T>, IQueryable<T>
    {
        public int PageSize { get; protected set; }

        public int PageNumber { get; protected set; }

        public Type ElementType => typeof(T);

        public Expression Expression => queryable.Expression;

        public IQueryProvider Provider => queryable.Provider;

        protected IQueryable<T> queryable;

        public PageQueryable(IQueryable<T> queryable, int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            this.queryable = queryable;
        }
        IEnumerator IEnumerable.GetEnumerator() => queryable.GetEnumerator();

        public IEnumerator<T> GetEnumerator() => queryable.GetEnumerator();
    }
    public interface IPagedList<T> : IPagedList, IList<T> { }
    public class PagedList<T> : List<T>, IPagedList<T>
    {

        public int TotalCount { get;  set; }

        public int PageSize { get;  set; }

        public int PageNumber { get; set; }

        public int PagesCount { get; set; }

        public PagedList(IPagedList orther) : base()
        {
            TotalCount = orther.TotalCount;
            PageNumber = orther.PageNumber;
            PageSize = orther.PageSize;
            PagesCount = orther.PagesCount;
        }
        public PagedList(IPagedQueryable<T> queryable) : base()
        {
            if (queryable.PageSize > 0)
            {
                int skipCount = (queryable.PageNumber - 1) * queryable.PageSize;
                int takeCount = queryable.PageSize;
                TotalCount = queryable.Count();
                PageNumber = queryable.PageNumber;
                PageSize = queryable.PageSize;
                PagesCount = TotalCount % PageSize == 0 ? TotalCount / PageSize : TotalCount / PageSize + 1;
                AddRange(queryable.Skip(skipCount).Take(takeCount).ToList());
            }
            else
            {
                TotalCount = queryable.Count();
                PageNumber = 1;
                PageSize = -1;
                PagesCount = 1;
                AddRange(queryable.ToList());
            }
        }
        public PagedList(List<T> data, int currentPage, int pageCount, int pageSize, int rowCount) : base(data)
        {
            this.PageNumber = currentPage;
            this.PagesCount = pageCount;
            this.PageSize = pageSize;
            this.TotalCount = rowCount;
        }

        public PagedList() : base()
        {
            
        }
}
}
