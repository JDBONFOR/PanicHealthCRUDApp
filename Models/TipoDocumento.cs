using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Paciente = new HashSet<Paciente>();
        }

        public int DocIid { get; set; }
        public string DocDescripcion { get; set; }

        public ICollection<Paciente> Paciente { get; set; }
    }
}
