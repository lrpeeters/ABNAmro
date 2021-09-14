using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ABNAmro.Domain.Interfaces;

namespace ABNAmro.Database.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> FilterExpression<TEntity>(this IQueryable<TEntity> query, Expression expression)
        {
            if (query == null || expression == null)
            {
                return query;
            }

            var methodExpr = (MethodCallExpression)expression;
            var quoteExpr = (UnaryExpression)methodExpr.Arguments[1];
            var funcExpr = (Expression<Func<TEntity, bool>>)quoteExpr.Operand;
            return query.Where(funcExpr);
        }

        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> expression)
        {
            if (query == null || expression == null)
            {
                return query;
            }

            return query.Where(expression);
        }

        public static IQueryable<TEntity> Include<TEntity>(this IQueryable<TEntity> query, ICollection<string> includes)
            where TEntity : class, IEntity
        {
            if (query == null || includes == null)
            {
                return query;
            }

            return includes.Aggregate(query, (query, path) => query.Include(path));
        }

        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query, Expression expression)
        {
            if (query == null || expression == null)
            {
                return query;
            }

            var orderByProperties = expression.GetOrderByPropertyNames();
            var isFirstOrderBy = true;

            foreach (var property in orderByProperties)
            {
                var isDescending = property.Value.Equals("descending", StringComparison.InvariantCultureIgnoreCase);

                ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity), property.Key);
                MemberExpression expressionProperty = Expression.Property(parameterExpression, property.Key);
                Expression convertedExpression = Expression.Convert(expressionProperty, typeof(object));
                Expression<Func<TEntity, dynamic>> sortExpression = Expression.Lambda<Func<TEntity, dynamic>>(convertedExpression, new[] { parameterExpression });


                if (isDescending)
                {
                    query = isFirstOrderBy ? query.OrderByDescending(sortExpression) : (query as IOrderedQueryable<TEntity>).ThenByDescending(sortExpression);
                }
                else
                {
                    query = isFirstOrderBy ? query.OrderBy(sortExpression) : (query as IOrderedQueryable<TEntity>).ThenBy(sortExpression);
                }

                isFirstOrderBy = false;
            }

            return query;
        }

        private static Dictionary<string, string> GetOrderByPropertyNames(this Expression expression)
        {
            var orderByProperties = new Dictionary<string, string>();
            var methodCallExpression = (MethodCallExpression)expression;

            foreach (var argument in methodCallExpression.Arguments)
            {
                if (argument is MethodCallExpression)
                {
                    var orderByPropertyNames = GetOrderByPropertyNames(argument);

                    foreach (var propertyNames in orderByPropertyNames)
                    {
                        if (!orderByProperties.Keys.Contains(propertyNames.Key))
                        {
                            orderByProperties.Add(propertyNames.Key, propertyNames.Value);
                        }
                    }
                }
                else if (argument is UnaryExpression unaryExpression)
                {
                    var lambdaExpression = (LambdaExpression)unaryExpression.Operand;
                    var memberExpression = (MemberExpression)lambdaExpression.Body;
                    var propertyInfo = (PropertyInfo)memberExpression.Member;
                    var propertyName = propertyInfo.Name;

                    orderByProperties.Add(propertyName, expression.IsOrderbyMethodDescending(propertyName) ? "descending" : "ascending");
                }
            }

            return orderByProperties;
        }

        private static bool IsOrderbyMethodDescending(this Expression expression, string propertyName)
        {
            var expressionString = expression.ToString();
            var propertyNameStartPosition = expressionString.IndexOf($"$it.{propertyName}");
            var methodStartPosition = expressionString.Substring(0, propertyNameStartPosition).LastIndexOf(".");
            var fullMethod = expressionString.Substring(methodStartPosition, propertyNameStartPosition - methodStartPosition + $"$it.{propertyName}".Length);

            return fullMethod.Contains("descending", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
