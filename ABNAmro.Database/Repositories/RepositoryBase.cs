using System;
using System.Threading.Tasks;
using ABNAmro.Application.Interfaces.Persistence;
using ABNAmro.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ABNAmro.Database.Repositories
{
    internal abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected TContext DbContext { get; private set; }

        protected RepositoryBase(TContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            entity.CreatedAt = DateTime.UtcNow;
            var newEntity = await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return newEntity.Entity;
        }
    }
}
