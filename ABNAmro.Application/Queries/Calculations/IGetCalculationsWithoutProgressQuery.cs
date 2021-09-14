using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABNAmro.Application.Queries.Calculations
{
    public interface IGetCalculationsWithoutProgressQuery
    {
        Task<IEnumerable<GetCalculation>> ExecuteAsync();
    }
}
