using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public partial class AccionTipo
    {
        public AccionTipo()
        {
            PacienteHistorial = new HashSet<PacienteHistorial>();
        }

        public int AccIid { get; set; }
        public string AccDescripcion { get; set; }

        public ICollection<PacienteHistorial> PacienteHistorial { get; set; }
    }
}
