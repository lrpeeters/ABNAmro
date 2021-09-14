using System;

namespace ABNAmro.Application.Commands.Progresses
{
    public class CreateProgress
    {
        public Guid CalculationId { get; set; }
        public decimal Percentage { get; set; }
        public decimal LetterMatchPercentage { get; set; }
        public decimal CalculationResult { get; set; }
    }
}
