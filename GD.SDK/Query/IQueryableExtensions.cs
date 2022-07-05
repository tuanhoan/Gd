using GD.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

namespace Microsoft.EntityFrameworkCore
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Ordering<T>(this IQueryable<T> query, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunc)
        {
            if (orderFunc != default)
            {
                query = orderFunc(query);
            }
            return query;

        }

        public static IQueryable<T> Includes<T>(this IQueryable<T> query, IList<Expression<Func<T, object>>> includeExpressions) where T : class
        {
            if (includeExpressions == default) return query;
            foreach (var inc in includeExpressions)
            {
                query = query.Include(inc);
            }
            return query;
        }

        public static IQueryable<T> Ordering<T>(this IQueryable<T> query, string ordering)
        {
            return string.IsNullOrWhiteSpace(ordering) ? query : query.OrderBy(ordering);
        }

        public static async Task<IPagedList<T>> PageResultAsync<T>(this IQueryable<T> query, int page, int pageSize, CancellationToken cancellationToken = default)
        {
            var result = query.PageResult(page, pageSize);
            var data = await result.Queryable.ToListAsync(cancellationToken);
            return new PagedList<T>(data, result.CurrentPage, result.PageCount, result.PageSize, result.RowCount);
        }

        public static async Task ForEachAsync<T>(this IQueryable<T> enumerable, Func<T, Task> action, CancellationToken cancellationToken) //Now with Func returning Task
        {
            var asyncEnumerable = (IDbAsyncEnumerable<T>)enumerable;
            using (var enumerator = asyncEnumerable.GetAsyncEnumerator())
            {

                if (await enumerator.MoveNextAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
                {
                    Task<bool> moveNextTask;
                    do
                    {
                        var current = enumerator.Current;
                        moveNextTask = enumerator.MoveNextAsync(cancellationToken);
                        await action(current); //now with await
                    }
                    while (await moveNextTask.ConfigureAwait(continueOnCapturedContext: false));
                }
            }
        }

        private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();

        private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");

        private static readonly PropertyInfo NodeTypeProviderField = QueryCompilerTypeInfo.DeclaredProperties.Single(x => x.Name == "NodeTypeProvider");

        private static readonly MethodInfo CreateQueryParserMethod = QueryCompilerTypeInfo.DeclaredMethods.First(x => x.Name == "CreateQueryParser");

        private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");

        private static readonly PropertyInfo DatabaseDependenciesField
            = typeof(Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");
    }

}
