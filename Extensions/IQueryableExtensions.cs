using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using bdeliv_services.Models;

namespace bdeliv_services.Extensions
{
    public static class IQueryableExtensions
    {

        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap) 
        {
            if(String.IsNullOrWhiteSpace(queryObj.SortBy) || !columnsMap.ContainsKey(queryObj.SortBy))
                return query;

            if(queryObj.IsSortAscending)
                return query.OrderBy(columnsMap[queryObj.SortBy]);
            else
                return query.OrderByDescending(columnsMap[queryObj.SortBy]);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj) 
        {
            if(queryObj.Page < 1) queryObj.Page = 1; 

            if(queryObj.PageSize < 1) queryObj.PageSize = 10;

            return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }

        public static IQueryable<Product> ApplyFiltering(this IQueryable<Product> query, ProductQuery queryObj) {
            
            if(queryObj.CategoryId.HasValue)
                query = query.Where(p => p.CategoryId == queryObj.CategoryId.Value); // .Value because CategoryId is Nullable (int?)

            if(queryObj.Name != null && queryObj.Name != "")
                query = query.Where(p => p.Name.Contains(queryObj.Name));
            
            return query;
        }
    }
}