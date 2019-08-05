using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public partial class PacienteContacto
    {
        public int ConIid { get; set; }
        public int? ConPacIid { get; set; }
        public string ConTelCelular { get; set; }
        public string ConNombre { get; set; }
        public string ConApellido { get; set; }
        public string ConDireccion { get; set; }
        public string ConTelOther { get; set; }
        public int? ConParIid { get; set; }

        public Paciente ConI { get; set; }
        public TipoFamiliar ConParI { get; set; }
    }
}
