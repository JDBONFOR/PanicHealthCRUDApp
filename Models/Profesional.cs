using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public partial class Profesional
    {
        public Profesional()
        {
            Paciente = new HashSet<Paciente>();
        }

        public int ProfIid { get; set; }
        public string ProfDescripcion { get; set; }
        public string ProfNombre { get; set; }
        public string ProfApellido { get; set; }
        public string ProfEmail { get; set; }
        public string ProfTelefono { get; set; }
        public string ProfMatricula { get; set; }

        public ICollection<Paciente> Paciente { get; set; }
    }
}
