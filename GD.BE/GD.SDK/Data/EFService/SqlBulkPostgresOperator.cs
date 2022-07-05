using GD.SDK.Data.EFService;
using EFCore.BulkExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GD.SDK.Models;

namespace GD.SDK.Metadata
{
    public class SqlServerBulkOperation : IBulkOperation
    {
        private BulkConfig ConvertToBulkConfig(BulkOptions bulkOptions)
        {
            var config = new BulkConfig { UseTempDB = true };
            if (bulkOptions != null)
            {
                config.BatchSize = bulkOptions.BatchSize;
                config.EnableStreaming = bulkOptions.EnableStreaming;
                config.SetOutputIdentity = bulkOptions.SetOutputIdentity;
                config.UseTempDB = bulkOptions.UseTempDB;
                config.TrackingEntities = bulkOptions.TrackingEntities;
                config.SqlBulkCopyOptions = (SqlBulkCopyOptions)bulkOptions.BulkCopyOptions;
                config.UpdateByProperties = bulkOptions.KeyProperties;
                //config.SkipUpdateProperties = bulkOptions.SkipUpdateProperties;
            }
            return config;
        }
        public Task BulkAddAsync<T>(DbContext dbContext, IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class
        {
            var bulkConfig = ConvertToBulkConfig(bulkOptions);
            return dbContext.BulkInsertAsync(entities, bulkConfig, progress, null, cancellationToken);
        }

        public Task BulkAddOrUpdateAsync<T>(DbContext dbContext, IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class
        {
            var bulkConfig = ConvertToBulkConfig(bulkOptions);
            return dbContext.BulkInsertOrUpdateAsync(entities, bulkConfig, progress, null, cancellationToken);
        }

        public Task BulkAddOrUpdateOrDeleteAsync<T>(DbContext dbContext, IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class
        {
            var bulkConfig = ConvertToBulkConfig(bulkOptions);
            return dbContext.BulkInsertOrUpdateOrDeleteAsync(entities, bulkConfig, progress, null, cancellationToken);
        }

        public Task BulkDeleteAsync<T>(DbContext dbContext, IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class
        {
            var bulkConfig = ConvertToBulkConfig(bulkOptions);
            return dbContext.BulkDeleteAsync(entities, bulkConfig, progress, null, cancellationToken);
        }
        public Task BulkReadAsync<T>(DbContext dbContext, IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class
        {
            var bulkConfig = ConvertToBulkConfig(bulkOptions);
            return dbContext.BulkReadAsync(entities, bulkConfig, progress, null, cancellationToken);
        }

        public Task BulkUpdateAsync<T>(DbContext dbContext, IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class
        {
            var bulkConfig = ConvertToBulkConfig(bulkOptions);
            return dbContext.BulkUpdateAsync(entities, bulkConfig, progress, null, cancellationToken);
        }

        public Task TruncateAsync<T>(DbContext dbContext, CancellationToken cancellationToken = default) where T : class
        {
            return dbContext.TruncateAsync<T>(null, cancellationToken);
        }
    }
}
