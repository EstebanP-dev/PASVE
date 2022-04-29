using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Subject
    {
        public Subject()
        {
            SubjectsCareers = new HashSet<SubjectsCareer>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<SubjectsCareer> SubjectsCareers { get; set; }
    }
}
