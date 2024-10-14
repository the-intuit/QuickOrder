using Menu.Common.Enums;
using Menu.Common.SearchCriteria;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Menu.Repositories.EF.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, SearchCriteriaBase searchCriteria)
        {
            var skipCount = searchCriteria.PageSize * (searchCriteria.Page - 1);
            return query.OrderBy(searchCriteria.SortColumn, searchCriteria.Direction)
                .Skip(skipCount)
                .Take(searchCriteria.PageSize);
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string columnName, SortDirection direction)
        {
            var type = typeof(T);
            var property = type.GetProperty(columnName);
            var parameter = Expression.Parameter(type, "p");
            var propertyAcccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAcccess, parameter);
            var resultExpression = direction == SortDirection.Ascending
                ? Expression.Call(typeof(Queryable), "OrderBy", new[] { type, property.PropertyType }, query.Expression, Expression.Quote(orderByExpression))
                : Expression.Call(typeof(Queryable), "OrderByDescending", new[] { type, property.PropertyType }, query.Expression, Expression.Quote(orderByExpression));

            return query.Provider.CreateQuery<T>(resultExpression);
        }
    }
}
