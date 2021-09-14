using ABNAmro.Application.Interfaces.Persistence;
using ABNAmro.Domain.Interfaces;

namespace ABNAmro.Database.Repositories
{
    public interface IRepositoryProvider
    {
        IRepository<TEntity> Get<TEntity>()
            where TEntity : IEntity;
    }
}