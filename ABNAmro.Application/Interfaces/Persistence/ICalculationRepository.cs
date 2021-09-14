using System.Collections.Generic;
using System.Threading.Tasks;
using ABNAmro.Domain.Calculations;

namespace ABNAmro.Application.Interfaces.Persistence
{
    public interface ICalculationRepository : IRepository<Calculation>
    {
        Task<IEnumerable<Calculation>> GetCalculationsWithoutProgressAsync();
    }
}
