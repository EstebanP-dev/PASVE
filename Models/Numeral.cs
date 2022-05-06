using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Numeral
    {
        public Numeral()
        {
            InverseFkNumeralNavigation = new HashSet<Numeral>();
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Content { get; set; } = null!;
        public Guid FkSection { get; set; }
        public Guid? FkNumeral { get; set; }
        public bool? Active { get; set; }

        public virtual Numeral? FkNumeralNavigation { get; set; }
        public virtual Section FkSectionNavigation { get; set; } = null!;
        public virtual ICollection<Numeral> InverseFkNumeralNavigation { get; set; }
    }
}
