using Microsoft.Data.SqlClient;
using GD.SDK.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GD.SDK.Data
{
    public interface IAsyncQuery
    {
        IQueryable<T> AsQueryable<T>() where T : class;
        Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class;
        Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc, CancellationToken cancellationToken = default) where T : class;
        Task<TView> GetAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, TView>> selector, CancellationToken cancellationToken = default) where T : class where TView : class;
        Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class;
        Task<List<TView>> GetAllEntities<T, TView>(Expression<Func<T, TView>> selector, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class where TView : class;
        Task<List<T>> GetAllEntities<T>(Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class;
        Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class;
        Task<IPagedList<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate,IList<Expression<Func<T, object>>> includeExpression ,int page, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = default, CancellationToken cancellationToken = default) where T : class;
        Task<IPagedList<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate, int page, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = default, CancellationToken cancellationToken = default) where T : class;
        Task<List<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate, IList<Expression<Func<T, object>>> includeExpression,  Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = default, CancellationToken cancellationToken = default) where T : class;
        Task<List<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = default, CancellationToken cancellationToken = default) where T : class;
        Task<List<TView>> QueryAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, TView>> selector, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class where TView : class;

       Task<IPagedList<TView>> QueryAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, TView>> selector, IList<Expression<Func<T, object>>> includeExpression, int page, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = default, CancellationToken cancellationToken = default)
            where T : class
            where TView: class;
        Task<IPagedList<TView>> QueryAsync<T,TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, TView>> selector, int page, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = default, CancellationToken cancellationToken = default)
            where T : class
            where TView : class;
        Task<IPagedList<TView>> QueryManyAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, IEnumerable<TView>>> selector, int page, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = default, CancellationToken cancellationToken = default)
           where T : class
           where TView : class;
        Task<IPagedList<TView>> QueryManyAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, IEnumerable<TView>>> selector, IList<Expression<Func<T, object>>> includeExpressions, int page, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = default, CancellationToken cancellationToken = default)
            where T : class
            where TView : class;
        Task<List<TView>> QueryManyAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, IEnumerable<TView>>> selector, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = default, CancellationToken cancellationToken = default)
            where T : class
            where TView : class;
        Task<List<TView>> QueryManyAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, IEnumerable<TView>>> selector, IList<Expression<Func<T, object>>> includeExpressions, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = default, CancellationToken cancellationToken = default)
            where T : class
            where TView : class;
        DataTable ExecuteQuery(string storeName, out int returnValue, Dictionary<string, object> parameters = null);
        List<DataTable> ExecuteQueryDataSet(string storeName, out int returnValue, Dictionary<string, object> parameters = null);
        List<DataTable> ExecuteQueryDataSet(string storeName, params SqlParameter[] parameters);
        object ExecuteSqlCommandWithReturn(string storeName, params SqlParameter[] parameters);
        List<T> ExecuteStoredProcedureList<T>(string commandText, params SqlParameter[] parameters) where T : class;

    }
}
