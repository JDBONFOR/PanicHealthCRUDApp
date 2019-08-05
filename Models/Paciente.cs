using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            UsuarioPaciente = new HashSet<UsuarioPaciente>();
        }

        public int PacIid { get; set; }
        public string PacNumeroos { get; set; }
        public int? PacOsIid { get; set; }
        public string PacNombre { get; set; }
        public string PacApellido { get; set; }
        public string PacDni { get; set; }
        public int? PacDocIid { get; set; }
        public int? PacProfIid { get; set; }

        public TipoDocumento PacDocI { get; set; }
        public ObraSocial PacOsI { get; set; }
        public Profesional PacProfI { get; set; }
        public PacienteContacto PacienteContacto { get; set; }
        public PacienteHistorial PacienteHistorial { get; set; }
        public ICollection<UsuarioPaciente> UsuarioPaciente { get; set; }
    }
}
