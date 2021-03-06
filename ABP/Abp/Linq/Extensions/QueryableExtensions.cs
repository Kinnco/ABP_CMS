using System;
using System.Linq;
using System.Linq.Expressions;
using Abp.Application.Services.Dto;

namespace Abp.Linq.Extensions
{
    /// <summary>
    /// Some useful extension methods for <see cref="IQueryable{T}"/>.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Used for paging. Can be used as an alternative to Skip(...).Take(...) chaining.
        /// </summary>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int maxResultCount)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return query.Skip(skipCount).Take(maxResultCount);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">查询条件</param>
        /// <param name="pageIndex">分页序号</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="totalCount">总数</param>
        /// <returns></returns>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int pageIndex, int pageSize,out int totalCount)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            var itemIndex = (pageIndex - 1) * pageSize;
            totalCount = query.Count();
            while (totalCount <= itemIndex && pageIndex > 1)
            {
                itemIndex = (--pageIndex - 1) * pageSize;
            }

            return query.Skip(itemIndex).Take(pageSize);
        }

        /// <summary>
        /// Used for paging with an <see cref="IPagedResultRequest"/> object.
        /// </summary>
        /// <param name="query">Queryable to apply paging</param>
        /// <param name="pagedResultRequest">An object implements <see cref="IPagedResultRequest"/> interface</param>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, IPagedResultRequest pagedResultRequest)
        {
            return query.PageBy(pagedResultRequest.SkipCount, pagedResultRequest.MaxResultCount);
        }

        /// <summary>
        /// Filters a <see cref="IQueryable{T}"/> by given predicate if given condition is true.
        /// </summary>
        /// <param name="query">Queryable to apply filtering</param>
        /// <param name="condition">A boolean value</param>
        /// <param name="predicate">Predicate to filter the query</param>
        /// <returns>Filtered or not filtered query based on <see cref="condition"/></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition
                ? query.Where(predicate)
                : query;
        }

        /// <summary>
        /// Filters a <see cref="IQueryable{T}"/> by given predicate if given condition is true.
        /// </summary>
        /// <param name="query">Queryable to apply filtering</param>
        /// <param name="condition">A boolean value</param>
        /// <param name="predicate">Predicate to filter the query</param>
        /// <returns>Filtered or not filtered query based on <see cref="condition"/></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, int, bool>> predicate)
        {
            return condition
                ? query.Where(predicate)
                : query;
        }
    }
}
