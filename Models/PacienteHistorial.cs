using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public partial class PacienteHistorial
    {
        public int HistPacIid { get; set; }
        public int? HistPacRenglon { get; set; }
        public decimal? HistPacLatlong { get; set; }
        public int? HistPacAccIid { get; set; }
        public string HistPacResult { get; set; }
        public DateTime? HistPacDatecreated { get; set; }

        public AccionTipo HistPacAccI { get; set; }
        public Paciente HistPacI { get; set; }
    }
}
