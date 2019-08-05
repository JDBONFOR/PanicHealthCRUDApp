using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public partial class UsuarioPaciente
    {
        public int UsupUsuIid { get; set; }
        public int UsupPacIid { get; set; }

        public Paciente UsupPacI { get; set; }
        public Usuario Usuario { get; set; }
    }
}
