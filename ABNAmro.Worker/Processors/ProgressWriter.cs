using System;
using System.Threading.Tasks;
using ABNAmro.Application.Commands.Progresses;
using ABNAmro.CrossCutting.Extensions;

namespace ABNAmro.Worker.Processors
{
    internal class ProgressWriter : IProgressWriter
    {
        private readonly ICreateProgressCommand _createProgressCommand;

        public ProgressWriter(ICreateProgressCommand createProgressCommand)
        {
            _createProgressCommand = createProgressCommand.NullCheck(nameof(createProgressCommand));
        }

        public async Task WriteAsync(Guid calculationId, decimal percentageComplete, decimal calculationResult)
        {
            var createProgress = new CreateProgress
            {
                CalculationId = calculationId,
                Percentage = percentageComplete,
                CalculationResult = calculationResult
            };
            await _createProgressCommand.ExecuteAsync(createProgress);

        }
    }
}
