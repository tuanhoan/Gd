
using GD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GD.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace GD.Data.EFService
{
    public abstract class EfQuery<TContext> : IAsyncQuery
         where TContext : DbContext
    {
        protected readonly TContext dbContext;
        protected readonly IServiceProvider serviceProvider;

        public EfQuery(IServiceProvider serviceProvider)
        {
            this.dbContext = serviceProvider.GetService<TContext>();
            this.serviceProvider = serviceProvider;
        }

        public virtual IQueryable<T> AsQueryable<T>() where T : class => dbContext.Set<T>().AsNoTracking();
        public Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
            => AsQueryable<T>().FirstOrDefaultAsync<T>(predicate, cancellationToken);
        public Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc, CancellationToken cancellationToken = default) where T : class
            => AsQueryable<T>().Ordering(orderFunc).FirstOrDefaultAsync<T>(predicate, cancellationToken);
        public Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
           => AsQueryable<T>().CountAsync<T>(predicate, cancellationToken);
        public Task<TView> GetAsync<T,TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, TView>> selector, CancellationToken cancellationToken = default) where T : class where TView : class
           => AsQueryable<T>().Where(predicate).Select(selector).FirstOrDefaultAsync(cancellationToken);
        public Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
        { 
            return AsQueryable<T>().AnyAsync(predicate, cancellationToken); 
        }
        public Task<List<T>> GetAllEntities<T>( Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class
           => AsQueryable<T>().Ordering(orderFunc).ToListAsync(cancellationToken);
        public Task<List<TView>> GetAllEntities<T,TView>(Expression<Func<T, TView>> selector, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class where TView : class
          => AsQueryable<T>().Ordering(orderFunc).Select(selector).ToListAsync(cancellationToken);

        public Task<IPagedList<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate, int page, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class 
            => AsQueryable<T>().Where(predicate).Ordering(orderFunc).PageResultAsync(page, pageSize, cancellationToken);
        public Task<IPagedList<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate, IList<Expression<Func<T, object>>> includeExpressions, int page, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class
            => AsQueryable<T>().Where(predicate).Includes(includeExpressions).Ordering(orderFunc).PageResultAsync(page, pageSize, cancellationToken);
        public Task<IPagedList<TView>> QueryAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, TView>> selector, int page, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class where TView : class 
            => AsQueryable<T>().Where(predicate).Ordering(orderFunc).Select(selector).PageResultAsync(page, pageSize, cancellationToken); 
        public Task<IPagedList<TView>> QueryAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, TView>> selector, IList<Expression<Func<T, object>>> includeExpressions, int page, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class where TView : class 
            => AsQueryable<T>().Where(predicate).Includes(includeExpressions).Ordering(orderFunc).Select(selector).PageResultAsync(page, pageSize, cancellationToken);
        public Task<List<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class 
            => AsQueryable<T>().Where(predicate).Ordering(orderFunc).ToListAsync(cancellationToken);
        public Task<List<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate, IList<Expression<Func<T, object>>> includeExpressions, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class 
            => AsQueryable<T>().Where(predicate).Includes(includeExpressions).Ordering(orderFunc).ToListAsync(cancellationToken); 
        public Task<List<TView>> QueryAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, TView>> selector, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class where TView : class 
            => AsQueryable<T>().Where(predicate).Ordering(orderFunc).Select(selector).ToListAsync(cancellationToken);
        public Task<List<TView>> QueryAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, TView>> selector, IList<Expression<Func<T, object>>> includeExpressions, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class where TView : class 
            => AsQueryable<T>().Where(predicate).Includes(includeExpressions).Ordering(orderFunc).Select(selector).ToListAsync(cancellationToken); 
        public Task<IPagedList<TView>> QueryManyAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, IEnumerable<TView>>> selector, int page, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class where TView : class 
            => AsQueryable<T>().Where(predicate).Ordering(orderFunc).SelectMany(selector).PageResultAsync(page, pageSize, cancellationToken); 
        public Task<IPagedList<TView>> QueryManyAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, IEnumerable<TView>>> selector, IList<Expression<Func<T, object>>> includeExpressions, int page, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class where TView : class 
            => AsQueryable<T>().Where(predicate).Includes(includeExpressions).Ordering(orderFunc).SelectMany(selector).PageResultAsync(page, pageSize, cancellationToken);
        public Task<List<TView>> QueryManyAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, IEnumerable<TView>>> selector, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class where TView : class 
            => AsQueryable<T>().Where(predicate).Ordering(orderFunc).SelectMany(selector).ToListAsync(cancellationToken); 
        public Task<List<TView>> QueryManyAsync<T, TView>(Expression<Func<T, bool>> predicate, Expression<Func<T, IEnumerable<TView>>> selector, IList<Expression<Func<T, object>>> includeExpressions, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc = null, CancellationToken cancellationToken = default) where T : class where TView : class =>
            AsQueryable<T>().Where(predicate).Includes(includeExpressions).Ordering(orderFunc).SelectMany(selector).ToListAsync(cancellationToken);
        public DataTable ExecuteQuery(string storeName, out int returnValue, Dictionary<string, object> parameters = null)
        {
            returnValue = 0;
            DataTable dataTable = new DataTable();
            DbConnection connection = this.dbContext.Database.GetDbConnection();
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);
            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = storeName;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public List<DataTable> ExecuteQueryDataSet(string storeName, out int returnValue, Dictionary<string, object> parameters = null)
        {
            returnValue = 0;
            DataTable dataTable = new DataTable();
            DbConnection connection = this.dbContext.Database.GetDbConnection();
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);
            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = storeName;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataTable);
                }
                var resultParam = new SqlParameter("@ReturnValue", DbType.Int32);
                var ds = new DataSet();
                var da = new SqlDataAdapter((SqlCommand)cmd);
                da.Fill(ds);
                da.Dispose();
                returnValue = (int)resultParam.Value;
                connection.Close();
                var listDataTable = new List<DataTable>();
                foreach (DataTable t in ds.Tables)
                {
                    listDataTable.Add(t);
                }
                return listDataTable;
            }
        }

        public List<DataTable> ExecuteQueryDataSet(string storeName, params SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            DbConnection connection = this.dbContext.Database.GetDbConnection();
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);
            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = storeName;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataTable);
                }
                var resultParam = new SqlParameter("@ReturnValue", DbType.Int32);
                var ds = new DataSet();
                var da = new SqlDataAdapter((SqlCommand)cmd);
                da.Fill(ds);
                da.Dispose();
                connection.Close();
                var listDataTable = new List<DataTable>();
                foreach (DataTable t in ds.Tables)
                {
                    listDataTable.Add(t);
                }
                return listDataTable;
            }
        }

        public object ExecuteSqlCommandWithReturn(string storeName, params SqlParameter[] parameters)
        {
            object rs = 0;
            if (parameters == null || parameters.Length <= 0) return rs;
            DataTable dataTable = new DataTable();
            DbConnection connection = this.dbContext.Database.GetDbConnection();
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);
            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = storeName;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                cmd.ExecuteNonQuery();
                rs = cmd.Parameters["returnVal"].Value;
                return rs;
            }
        }
        public List<T> ExecuteStoredProcedureList<T>(string commandText, params SqlParameter[] parameters) where T : class
        {
            if (parameters == null || parameters.Length <= 0) return null;
            var getParamValue = new List<object>();
            int count = 0;

            for (var i = 0; i <= parameters.Length - 1; i++)
            {
                var p = parameters[i] as SqlParameter;
                if (p == null) continue;
                if (i == 0) commandText += " ";
                else commandText += ", ";
                //commandText += i == 0 ? " " : ", ";
                if (p.Value == DBNull.Value)
                {
                    commandText += p.ParameterName + "=NULL";
                }
                else
                {
                    commandText += p.ParameterName + "={" + count + "}";
                    getParamValue.Add(p.Value);
                    count++;
                }
            }
            var rs = dbContext.Set<T>().FromSqlRaw(commandText, getParamValue.ToArray()).ToList();
            return rs;
        }
    }
}
