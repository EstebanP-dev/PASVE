using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Article
    {
        public Article()
        {
            Paragraphs = new HashSet<Paragraph>();
            Sections = new HashSet<Section>();
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } = null!;
        public Guid FkChapter { get; set; }
        public bool? Active { get; set; }

        public virtual Chapter FkChapterNavigation { get; set; } = null!;
        public virtual ICollection<Paragraph> Paragraphs { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
