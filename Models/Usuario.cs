using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public partial class Usuario
    {
        public int UsuIid { get; set; }
        public string UsuDni { get; set; }
        public string UsuPassword { get; set; }
        public DateTime? UsuDatecreated { get; set; }
        public int? UsuEstado { get; set; }
        public int UsuTipo { get; set; }
        public string UsuEmail { get; set; }

        public UsuarioEstado UsuEstadoNavigation { get; set; }
        public UsuarioPaciente UsuI { get; set; }
        public UsuarioTipo UsuTipoNavigation { get; set; }
    }
}
