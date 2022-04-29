using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
