using System;
using System.Threading;
using ABNAmro.Application.Queries.Calculations;
using ABNAmro.CrossCutting.Extensions;
using ABNAmro.Worker.Processors;

namespace ABNAmro.Worker.Calculators
{
    public class LetterMatchCalculator : ICalculator
    {
        private readonly IProgressWriter _progressWriter;
        private const int Delay = 5000;

        public LetterMatchCalculator(IProgressWriter progressWriter)
        {
            _progressWriter = progressWriter.NullCheck(nameof(progressWriter));
        }

        public void Calculate(GetCalculation calculation)
        {
            if (calculation == null || string.IsNullOrWhiteSpace(calculation.Input1) || string.IsNullOrWhiteSpace(calculation.Input2))
            {
                return;
            }

            Console.WriteLine($"Calculating calculation {calculation.Id} with input: {calculation.Input1} and {calculation.Input2}");

            var input1Length = calculation.Input1.Length;
            var letterMatchCount = 0;
            for (var i = 0; i < input1Length; i++)
            {
                var percentageComplete = ((i + 1) / (decimal)input1Length) * 100;

                if (calculation.Input2.Contains(calculation.Input1[i]))
                {
                    letterMatchCount++;
                }

                var letterMatchPercentage = (letterMatchCount / (decimal)input1Length) * 100;

                // This is a bit cheating, as one might argue that it is not the calculator's responsibility to write the progress. For simplicity, I do it here.
                _progressWriter.WriteAsync(calculation.Id, percentageComplete, letterMatchPercentage);

                // Because this is supposed to be a calculation that takes up to a minute to end, delay it a bit here
                Thread.Sleep(Delay);
            }
        }
    }
}
