using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Paragraph
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Content { get; set; } = null!;
        public Guid FkArticle { get; set; }
        public Guid? FkParagraph { get; set; }
        public bool? Active { get; set; }

        public virtual Article FkArticleNavigation { get; set; } = null!;
        public virtual Paragraph FkParagraphNavigation { get; set; } = null!;
        public virtual ICollection<Paragraph> Paragraphs { get; set; } = null!;
    }
}
