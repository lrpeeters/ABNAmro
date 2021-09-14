using System;
using System.Threading.Tasks;

namespace ABNAmro.Application.Commands
{
    public interface ICreateCommand<TDto>
    {
        Task<Guid> ExecuteAsync(TDto dto);
    }
}
