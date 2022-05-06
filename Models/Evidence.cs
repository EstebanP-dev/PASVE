using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Evidence
    {
        public Evidence()
        {
            EvidencesAuthors = new HashSet<EvidencesAuthor>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string Path { get; set; } = null!;
        public Guid FkInstallment { get; set; }
        public bool? Active { get; set; }
        public Guid LoadFor { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid? FkChapter { get; set; }
        public Guid? FkArticle { get; set; }
        public Guid? FkSection { get; set; }
        public Guid? FkParagraph { get; set; }
        public Guid? FkNumeral { get; set; }

        public virtual Installment FkInstallmentNavigation { get; set; } = null!;
        public virtual User LoadForNavigation { get; set; } = null!;
        public virtual ICollection<EvidencesAuthor> EvidencesAuthors { get; set; }
    }
}
