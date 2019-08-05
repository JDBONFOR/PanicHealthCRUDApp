using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public partial class TipoFamiliar
    {
        public TipoFamiliar()
        {
            PacienteContacto = new HashSet<PacienteContacto>();
        }

        public int ParIid { get; set; }
        public string ParDescripcion { get; set; }

        public ICollection<PacienteContacto> PacienteContacto { get; set; }
    }
}
