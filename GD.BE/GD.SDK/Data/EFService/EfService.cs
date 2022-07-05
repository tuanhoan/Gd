using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using GD.SDK.Data;
using GD.SDK.Data.EFService;
using GD.SDK.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GD.SDK.EFService
{
    public abstract class EfChange<TContext> : EfQuery<TContext>, IAsyncChange, IAsyncQuery, IUnitOfWork
         where TContext : DbContext
    {
        public readonly IBulkOperation _bulkOperation;
        protected IDbContextTransaction _dbContextTransaction;
        protected bool _commited = false;
        public EfChange(IServiceProvider serviceProvider, IBulkOperation bulkOperation) : base(serviceProvider)
        {
            this._bulkOperation = bulkOperation;

            var transaction = dbContext.Database.CurrentTransaction;
            if (transaction == null)
            {
                this._dbContextTransaction = dbContext.Database.BeginTransaction();
            }
            else
            {
                this._dbContextTransaction = transaction;
            }

        }

        public async Task<int> SetAnchorAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }

        public override IQueryable<T> AsQueryable<T>() where T : class
            => dbContext.Set<T>();

        public virtual async Task AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
        {
            await dbContext.Set<T>().AddAsync(entity, cancellationToken);
            return;
        }

        public virtual Task AddAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class
        {
            return dbContext.Set<T>().AddRangeAsync(entities, cancellationToken);
        }

        public virtual Task UpdateAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class
        {
            dbContext.UpdateRange(entities);
            return Task.CompletedTask;
        }
        public virtual Task UpdateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
        {
            dbContext.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class
        {
            dbContext.Set<T>().RemoveRange(entities);
            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
        {
            dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
        {
            dbContext.Set<T>().RemoveRange(dbContext.Set<T>().Where<T>(predicate));
            return Task.CompletedTask;
        }

        public Task AddOrUpdateAsync<T, TKey>(T entity, Expression<Func<T, TKey>> keySelector, CancellationToken cancellationToken = default) where T : class
        {
            return AddOrUpdateAsync(new List<T> { entity }, keySelector, cancellationToken);
        }

        public async Task AddOrUpdateAsync<T, TKey>(IEnumerable<T> entities, Expression<Func<T, TKey>> keySelector, CancellationToken cancellationToken = default) where T : class
        {
            entities =  entities.ToArray();

            var keyFunc = keySelector.Compile();
            var predicates = new List<string>();
            var predicateParams = new List<object>();

            if (keySelector.Body.NodeType == ExpressionType.MemberAccess)
            {
                var prop = (keySelector.Body as MemberExpression).Member;
                for (int i = 0; i < entities.Count(); i++)
                {
                    var entity = entities.ElementAt(i);
                    predicates.Add($"{prop.Name} = @{i}");
                    predicateParams.Add(keyFunc(entity));
                }
            }
            else
            {
                var tempKeyProps = keyFunc(entities.First()).GetType().GetProperties().Select(e => e.Name).ToArray();
                var keyProps = typeof(T).GetProperties().Where(e => tempKeyProps.Contains(e.Name)).ToArray();

                var index = 0;
                foreach (var entity in entities)
                {
                    var predicate = new List<string>();
                    foreach (var prop in keyProps)
                    {
                        predicate.Add($"{prop.Name} = @{index++}");
                        if (prop.PropertyType == typeof(DateTime))
                            predicateParams.Add((DateTime)prop.GetValue(entity));
                        else if (prop.PropertyType == typeof(DateTime?))
                            predicateParams.Add((DateTime?)prop.GetValue(entity));
                        else
                            predicateParams.Add(prop.GetValue(entity));
                    }
                    predicates.Add($"({string.Join(" AND ", predicate)})");
                }

            }

            var existedEntries = await dbContext.Set<T>().Where(string.Join(" OR ", predicates), predicateParams.ToArray()).ToListAsync(cancellationToken);
            foreach (var entity in entities)
            {
                var entry = existedEntries.FirstOrDefault(existed => keyFunc(existed).Equals(keyFunc(entity)));
                if (entry == null)
                {
                    dbContext.Set<T>().Add(entity);
                }
                else
                {
                    dbContext.Entry(entry).CurrentValues.SetValues(entity);
                }
            }
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            var affectedRecords = await dbContext.SaveChangesAsync(cancellationToken);
            await _dbContextTransaction.CommitAsync();
            _commited = true;
            return affectedRecords;
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).     
                    if (!_commited)
                    {
                        var transaction = dbContext.Database.CurrentTransaction;
                        if(transaction != null)
                            _dbContextTransaction.Rollback();
                    }
                      
                    _dbContextTransaction.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }

        }
        public Task BulkAddAsync<T>(IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class
        {
            return _bulkOperation.BulkAddAsync(this.dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkUpdateAsync<T>(IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class
        {
            return _bulkOperation.BulkUpdateAsync(this.dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkDeleteAsync<T>(IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class
        {
            return _bulkOperation.BulkDeleteAsync(this.dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task BulkAddOrUpdateAsync<T>(IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class
        {
            return _bulkOperation.BulkAddOrUpdateAsync(this.dbContext, entities, bulkOptions, progress, cancellationToken);
        }
        public Task BulkAddOrUpdateOrDeleteAsync<T>(IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class
        {
            return _bulkOperation.BulkAddOrUpdateOrDeleteAsync(this.dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public Task TruncateAsync<T>(CancellationToken cancellationToken = default) where T : class
        {
            return _bulkOperation.TruncateAsync<T>(this.dbContext, cancellationToken);
        }

        public Task BulkReadAsync<T>(IList<T> entities, BulkOptions bulkOptions = null, Action<decimal> progress = null, CancellationToken cancellationToken = default) where T : class
        {
            return _bulkOperation.BulkReadAsync(this.dbContext, entities, bulkOptions, progress, cancellationToken);
        }

        public void Dispose()
        {
            var transaction = dbContext.Database.CurrentTransaction;
            if (transaction != null)
            {
                disposedValue = true;
                _commited = true;
            }
            if (!disposedValue)
                Dispose(true);
        }
        #endregion

    }
}
