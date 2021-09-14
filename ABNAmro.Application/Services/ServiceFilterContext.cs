using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ABNAmro.Application.Services
{
    public class ServiceFilterContext<TEntity> : ServicePagingContext
    {
        public IEnumerable<Expression<Func<TEntity, bool>>> Filters { get; set; }
    }
}
