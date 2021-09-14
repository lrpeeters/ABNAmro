using System.Threading.Tasks;
using ABNAmro.Domain.Interfaces;

namespace ABNAmro.Application.Interfaces.Persistence
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
    }
}
