using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid FkCountry { get; set; }
        public bool? Active { get; set; }

        public virtual Country FkCountryNavigation { get; set; } = null!;
        public virtual ICollection<City> Cities { get; set; }
    }
}
