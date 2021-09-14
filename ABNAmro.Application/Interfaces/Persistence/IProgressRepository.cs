using System;
using System.Threading.Tasks;
using ABNAmro.Domain.Progresses;

namespace ABNAmro.Application.Interfaces.Persistence
{
    public interface IProgressRepository : IRepository<Progress>
    {
        Task<Progress> GetProgressForCalculationAsync(Guid calculationId);
    }
}
