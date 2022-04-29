using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PASVE.Models
{
    public partial class Evidence
    {
        [NotMapped]
        public IFormFile File { get; set; }
        
        [NotMapped]
        public List<Guid> Authors { get; set; }
    }
}
