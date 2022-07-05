using GD.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GD.SDK.Data
{
    public interface IAsyncChange :IAsyncQuery,IUnitOfWork
    {
        Task AddAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
        Task AddAsync<T>(IEnumerable<T> entity, CancellationToken cancellationToken) where T : class;
        Task UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
        Task UpdateAsync<T>(IEnumerable<T> entity, CancellationToken cancellationToken) where T : class;
        Task DeleteAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
        Task DeleteAsync<T>(IEnumerable<T> entity, CancellationToken cancellationToken) where T : class;
        Task AddOrUpdateAsync<T, TKey>(T entity, Expression<Func<T, TKey>> keySelector, CancellationToken cancellationToken = default) where T : class;
        Task AddOrUpdateAsync<T, TKey>(IEnumerable<T> entities, Expression<Func<T, TKey>> keySelector, CancellationToken cancellationToken = default) where T : class;

        Task BulkAddAsync<T>(IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class;
        Task BulkUpdateAsync<T>(IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class;
        Task BulkDeleteAsync<T>(IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class;
        Task BulkAddOrUpdateAsync<T>(IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class;
        Task BulkAddOrUpdateOrDeleteAsync<T>(IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class;
        Task TruncateAsync<T>(CancellationToken cancellationToken = default) where T : class;
        Task BulkReadAsync<T>(IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class;

        Task<int> SetAnchorAsync(CancellationToken cancellationToken = default);
    }
}
