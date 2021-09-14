using System.Collections.Generic;
using ABNAmro.Domain.Progresses;

namespace ABNAmro.Domain.Calculations
{
    public class Calculation : EntityBase
    {
        public string Input1 { get; set; }
        public string Input2 { get; set; }
        public ICollection<Progress> Progresses { get; set; }
    }
}
