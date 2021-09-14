using System;
using ABNAmro.Application.Interfaces.Persistence;
using ABNAmro.CrossCutting.Extensions;
using ABNAmro.Domain.Interfaces;

namespace ABNAmro.Database.Repositories
{
    internal class RepositoryProvider : IRepositoryProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public RepositoryProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider.NullCheck(nameof(serviceProvider));
        }

        public IRepository<TEntity> Get<TEntity>()
            where TEntity : IEntity
        {
            var repository = _serviceProvider.GetService<IRepository<TEntity>>();
            return repository;
        }
    }
}
