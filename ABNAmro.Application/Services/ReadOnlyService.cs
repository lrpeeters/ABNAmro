using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ABNAmro.Application.Queries;
using ABNAmro.CrossCutting.Extensions;
using ABNAmro.Domain.Interfaces;

namespace ABNAmro.Application.Services
{
    internal class ReadOnlyService<TGetDto, TEntity> : IReadOnlyService<TGetDto, TEntity>
        where TEntity : class, IEntity
        where TGetDto : class
    {
        protected IGetByIdQuery<TGetDto> GetQuery { get; }
        protected IGetMultipleQuery<TGetDto, TEntity> GetAllQuery { get; }

        private ILogger<ReadOnlyService<TGetDto, TEntity>> _logger { get; }

        public ReadOnlyService(IServiceProvider serviceProvider, ILogger<ReadOnlyService<TGetDto, TEntity>> logger)
        {
            GetQuery = serviceProvider.GetService<IGetByIdQuery<TGetDto>>();
            GetAllQuery = serviceProvider.GetService<IGetMultipleQuery<TGetDto, TEntity>>();
            _logger = logger.NullCheck(nameof(logger));
        }

        public virtual async Task<ServiceResponse<ICollection<TGetDto>>> Get(ServiceFilterContext<TEntity> context)
        {
            try
            {
                var filter = context.Filters.Combine();
                context.NullCheck(nameof(context));
                var results = await GetAllQuery.ExecuteAsync(context.Page, context.PageSize, filter);
                return ServiceResponse<ICollection<TGetDto>>.Success(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting all {typeof(TGetDto)}.", ex);
                return ServiceResponse<ICollection<TGetDto>>.Failure(ex.Message);
            }
        }

        public virtual async Task<ServiceResponse<TGetDto>> Get(ServiceIdContext context)
        {
            try
            {
                context.NullCheck(nameof(context));
                var result = await GetQuery.ExecuteAsync(context.Id);
                return ServiceResponse<TGetDto>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting all {typeof(TGetDto)}.", ex);
                return ServiceResponse<TGetDto>.Failure(ex.Message);
            }
        }
    }
}
