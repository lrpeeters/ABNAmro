using ABNAmro.Database.Repositories;
using ABNAmro.Domain.Progresses;
using AutoMapper;

namespace ABNAmro.Application.Commands.Progresses
{
    internal class CreateProgressCommand : CreateCommandBase<CreateProgress, Progress>, ICreateProgressCommand
    {
        public CreateProgressCommand(IRepositoryProvider repositoryProvider, IMapper mapper)
            : base(repositoryProvider, mapper)
        {
        }
    }
}
