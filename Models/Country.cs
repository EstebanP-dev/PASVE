using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
