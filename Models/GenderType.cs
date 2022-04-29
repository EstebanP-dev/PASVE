using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class GenderType
    {
        public GenderType()
        {
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Abbreviation { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
