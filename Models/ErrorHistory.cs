using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class ErrorHistory
    {
        public int Code { get; set; }
        public string? Msgerror { get; set; }
        public int? ErrorNumber { get; set; }
        public int? ErrorSeverity { get; set; }
        public int? ErrorState { get; set; }
        public string? ErrorProcedure { get; set; }
        public int? ErrorLine { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
