using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Section
    {
        public Section()
        {
            Numerals = new HashSet<Numeral>();
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Content { get; set; } = null!;
        public Guid FkArticle { get; set; }
        public bool? Active { get; set; }
        public string? Name { get; set; }

        public virtual Article FkArticleNavigation { get; set; } = null!;
        public virtual ICollection<Numeral> Numerals { get; set; }
    }
}
