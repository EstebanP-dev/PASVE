using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class City
    {
        public City()
        {
            Branches = new HashSet<Branch>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid FkState { get; set; }
        public bool? Active { get; set; }

        public virtual State FkStateNavigation { get; set; } = null!;
        public virtual ICollection<Branch> Branches { get; set; }
    }
}
