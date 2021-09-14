using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ABNAmro.Application.Queries.Calculations;
using ABNAmro.CrossCutting.Extensions;
using ABNAmro.Worker.Calculators;

namespace ABNAmro.Worker.Processors
{
    internal class CalculationsProcessor : ICalculationsProcessor
    {
        private readonly IGetCalculationsWithoutProgressQuery _query;
        private readonly ICalculator _calculator;
        private const int RefreshRate = 5000;

        public CalculationsProcessor(IGetCalculationsWithoutProgressQuery query, ICalculator calculator)
        {
            _query = query.NullCheck(nameof(query));
            _calculator = calculator.NullCheck(nameof(calculator));
        }

        public async Task ExecuteAsync()
        {
            while (Continue())
            {
                var calculations = await _query.ExecuteAsync();
                FireAndForgetCalculations(calculations);
            }
        }

        private static bool Continue()
        {
            Thread.Sleep(RefreshRate);
            return true;
        }

        private void FireAndForgetCalculations(IEnumerable<GetCalculation> calculations)
        {
            foreach (var calculation in calculations)
            {
                // TODO: Restore parallel run of calculation (fire and forget), fix issue with db context used in multiple threads.
                Task.Run(() =>
                {
                    _calculator.Calculate(calculation);
                });
            }

            // No need to await the calculations here. They will continue to run in their own private galaxy and when they're done, well, they're done
        }
    }
}
