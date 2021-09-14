using System;
using System.Threading.Tasks;
using ABNAmro.Application.Commands;
using ABNAmro.CrossCutting.Extensions;
using ABNAmro.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace ABNAmro.Application.Services
{
    internal class ReadWriteService<TGetDto, TCreateDto, TEntity> : ReadOnlyService<TGetDto, TEntity>, IReadWriteService<TGetDto, TCreateDto, TEntity>
        where TEntity : class, IEntity
        where TGetDto : class
    {
        public ReadWriteService(IServiceProvider serviceProvider, ILogger<ReadWriteService<TGetDto, TCreateDto, TEntity>> logger)
            : base(serviceProvider, logger)
        {
            CreateCommand = serviceProvider.GetService<ICreateCommand<TCreateDto>>();
            Logger = logger.NullCheck(nameof(logger));
        }

        protected ICreateCommand<TCreateDto> CreateCommand { get; }

        protected ILogger<ReadWriteService<TGetDto, TCreateDto, TEntity>> Logger { get; }

        public virtual async Task<ServiceResponse<Guid>> Create(ServiceCreateContext<TCreateDto> context)
        {
            try
            {
                context.NullCheck(nameof(context));
                var id = await CreateCommand.ExecuteAsync(context.Dto);
                return ServiceResponse<Guid>.Success(id);
            }
            catch (Exception ex)
            {
                Logger.LogError($"An error occurred while getting all {typeof(TGetDto)}.", ex);
                return ServiceResponse<Guid>.Failure(ex.Message);
            }
        }
    }
}
