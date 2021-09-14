using System;
using System.Linq;
using System.Threading.Tasks;
using ABNAmro.Application.Interfaces.Persistence;
using ABNAmro.Domain.Progresses;
using Microsoft.EntityFrameworkCore;

namespace ABNAmro.Database.Repositories
{
    internal class ProgressRepository : RepositoryBase<Progress, ABNAmroContext>, IProgressRepository
    {
        public ProgressRepository(ABNAmroContext dbContext)
            : base(dbContext)
        { }

        public async Task<Progress> GetProgressForCalculationAsync(Guid calculationId)
        {
            return await DbContext.Progresses.AsQueryable()
                .Where(p => p.CalculationId == calculationId)
                .OrderByDescending(p => p.Percentage)
                .FirstOrDefaultAsync();
        }
    }
}
