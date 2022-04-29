using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class ProjectsClassesUser
    {
        public Guid FkProject { get; set; }
        public Guid FkClass { get; set; }
        public Guid FkUser { get; set; }
        public bool? Active { get; set; }

        public virtual Class FkClassNavigation { get; set; } = null!;
        public virtual Project FkProjectNavigation { get; set; } = null!;
        public virtual User FkUserNavigation { get; set; } = null!;
    }
}
