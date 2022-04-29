using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class EvidencesAuthor
    {
        public Guid FkEvidence { get; set; }
        public Guid FkAuthor { get; set; }
        public bool? Active { get; set; }

        public virtual User FkAuthorNavigation { get; set; } = null!;
        public virtual Evidence FkEvidenceNavigation { get; set; } = null!;
    }
}
