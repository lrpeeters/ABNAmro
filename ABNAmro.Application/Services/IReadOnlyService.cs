using System.Collections.Generic;
using System.Threading.Tasks;
using ABNAmro.Domain.Interfaces;

namespace ABNAmro.Application.Services
{
    public interface IReadOnlyService<TGetDto, TEntity>
        where TEntity : class, IEntity
        where TGetDto : class
    {
        Task<ServiceResponse<ICollection<TGetDto>>> Get(ServiceFilterContext<TEntity> context);
        Task<ServiceResponse<TGetDto>> Get(ServiceIdContext context);
    }
}