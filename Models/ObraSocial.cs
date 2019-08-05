using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public partial class ObraSocial
    {
        public ObraSocial()
        {
            Paciente = new HashSet<Paciente>();
        }

        public int OsIid { get; set; }
        public string OsNombre { get; set; }
        public string OsTelefono { get; set; }
        public string OsDireccion { get; set; }

        public ICollection<Paciente> Paciente { get; set; }
    }
}
