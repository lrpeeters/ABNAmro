using System;
using System.Threading.Tasks;

namespace ABNAmro.Application.Queries.Progresses
{
    public interface IGetProgressByCalculationQuery
    {
        Task<GetProgress> ExecuteAsync(Guid calculationId);
    }
}
