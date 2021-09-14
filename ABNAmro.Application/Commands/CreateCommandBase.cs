using System;
using System.Threading.Tasks;
using ABNAmro.CrossCutting.Extensions;
using ABNAmro.Database.Repositories;
using ABNAmro.Domain.Interfaces;
using AutoMapper;

namespace ABNAmro.Application.Commands
{
    internal abstract class CreateCommandBase<TDto, TEntity> : ICreateCommand<TDto>
        where TEntity : class, IEntity
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryProvider _repositoryProvider;

        protected CreateCommandBase(IRepositoryProvider repositoryProvider, IMapper mapper)
        {
            _repositoryProvider = repositoryProvider.NullCheck(nameof(repositoryProvider));
            _mapper = mapper.NullCheck(nameof(mapper));
        }

        public async virtual Task<Guid> ExecuteAsync(TDto dto)
        {
            dto.NullCheck(nameof(dto));

            var entity = _mapper.Map<TEntity>(dto);
            var repository = _repositoryProvider.Get<TEntity>();
            entity = await repository.AddAsync(entity);
            return entity.Id;
        }
    }
}
