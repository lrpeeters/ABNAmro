using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABNAmro.Application.Interfaces.Persistence;
using ABNAmro.CrossCutting.Extensions;
using AutoMapper;

namespace ABNAmro.Application.Queries.Calculations
{
    internal class GetCalculationsWithoutProgressQuery : IGetCalculationsWithoutProgressQuery
    {
        private readonly ICalculationRepository _repository;
        private readonly IMapper _mapper;

        public GetCalculationsWithoutProgressQuery(ICalculationRepository repository, IMapper mapper)
        {
            _repository = repository.NullCheck(nameof(repository));
            _mapper = mapper.NullCheck(nameof(mapper));
        }

        public async Task<IEnumerable<GetCalculation>> ExecuteAsync()
        {
            var calculations = await _repository.GetCalculationsWithoutProgressAsync();
            return calculations
                .Select(c => _mapper.Map<GetCalculation>(c));
        }
    }
}
