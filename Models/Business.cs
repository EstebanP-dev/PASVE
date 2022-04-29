using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Business
    {
        public Business()
        {
            Branches = new HashSet<Branch>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
    }
}
