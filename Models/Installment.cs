using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Installment
    {
        public Installment()
        {
            Evidences = new HashSet<Evidence>();
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid FkProject { get; set; }
        public bool IsComplete { get; set; }
        public bool? Active { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual ICollection<Evidence> Evidences { get; set; }
    }
}
