using System;
using System.Threading.Tasks;
using ABNAmro.Application.Interfaces.Persistence;
using ABNAmro.CrossCutting.Extensions;
using AutoMapper;

namespace ABNAmro.Application.Queries.Progresses
{
    internal class GetProgressByCalculationQuery : IGetProgressByCalculationQuery
    {
        private readonly IProgressRepository _repository;
        private readonly IMapper _mapper;

        public GetProgressByCalculationQuery(IProgressRepository repository, IMapper mapper)
        {
            _repository = repository.NullCheck(nameof(repository));
            _mapper = mapper.NullCheck(nameof(mapper));
        }

        public async Task<GetProgress> ExecuteAsync(Guid calculationId)
        {
            var progress = await _repository.GetProgressForCalculationAsync(calculationId);
            var getProgress = _mapper.Map<GetProgress>(progress);
            return getProgress;
        }
    }
}
