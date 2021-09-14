using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABNAmro.Application.Interfaces.Persistence;
using ABNAmro.Domain.Calculations;
using Microsoft.EntityFrameworkCore;

namespace ABNAmro.Database.Repositories
{
    internal class CalculationRepository : RepositoryBase<Calculation, ABNAmroContext>, ICalculationRepository
    {
        public CalculationRepository(ABNAmroContext dbContext)
            : base(dbContext)
        { }

        public async Task<IEnumerable<Calculation>> GetCalculationsWithoutProgressAsync()
        {
            return await DbContext.Calculations.AsQueryable()
                .Where(c => !DbContext.Progresses.Any(p => p.CalculationId == c.Id))
                .ToListAsync();
        }
    }
}
