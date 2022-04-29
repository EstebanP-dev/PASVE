using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class UsersCareer
    {
        public Guid FkUser { get; set; }
        public Guid FkCareer { get; set; }
        public bool? Active { get; set; }

        public virtual Career FkCareerNavigation { get; set; } = null!;
        public virtual User FkUserNavigation { get; set; } = null!;
    }
}
