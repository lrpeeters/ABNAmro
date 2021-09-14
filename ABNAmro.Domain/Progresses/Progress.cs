using System;
using ABNAmro.Domain.Calculations;

namespace ABNAmro.Domain.Progresses
{
    public class Progress : EntityBase
    {
        public Guid CalculationId { get; set; }

        public decimal Percentage { get; set; }
        public decimal CalculationResult { get; set; }
        public Calculation Calculation { get; set; }
    }
}
