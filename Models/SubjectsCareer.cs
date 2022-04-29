using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class SubjectsCareer
    {
        public Guid FkSubject { get; set; }
        public Guid FkCareer { get; set; }
        public int Semester { get; set; }
        public bool? Active { get; set; }

        public virtual Career FkCareerNavigation { get; set; } = null!;
        public virtual Subject FkSubjectNavigation { get; set; } = null!;
    }
}
