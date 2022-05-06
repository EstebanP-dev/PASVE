using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Chapter
    {
        public Chapter()
        {
            Articles = new HashSet<Article>();
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
