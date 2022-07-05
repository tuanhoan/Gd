using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GD.SDK.Models;

namespace GD.SDK.Data.EFService
{
    public interface IBulkOperation
    {
        Task BulkAddAsync<T>(DbContext dbContext, IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class;
        Task BulkUpdateAsync<T>(DbContext dbContext, IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class;
        Task BulkDeleteAsync<T>(DbContext dbContext, IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class;
        Task BulkAddOrUpdateAsync<T>(DbContext dbContext, IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class;
        Task BulkAddOrUpdateOrDeleteAsync<T>(DbContext dbContext, IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class;
        Task TruncateAsync<T>(DbContext dbContext, CancellationToken cancellationToken = default) where T : class;
        Task BulkReadAsync<T>(DbContext dbContext, IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class;
    }
}
