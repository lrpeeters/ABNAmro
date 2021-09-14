using System;
using System.Threading.Tasks;
using ABNAmro.Domain.Interfaces;

namespace ABNAmro.Application.Services
{
    public interface IReadWriteService<TGetDto, TCreateDto, TEntity> : IReadOnlyService<TGetDto, TEntity>
        where TEntity : class, IEntity
        where TGetDto : class
    {
        Task<ServiceResponse<Guid>> Create(ServiceCreateContext<TCreateDto> context);
    }
}