using ABNAmro.Database.Repositories;
using ABNAmro.Domain.Calculations;
using AutoMapper;

namespace ABNAmro.Application.Commands.Calculations
{
    internal class CreateCalculationCommand : CreateCommandBase<CreateCalculation, Calculation>, ICreateCalculationCommand
    {
        public CreateCalculationCommand(IRepositoryProvider repositoryProvider, IMapper mapper)
            : base(repositoryProvider, mapper)
        {
        }
    }
}
