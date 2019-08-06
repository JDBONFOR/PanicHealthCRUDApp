using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{    
    public partial class Usuario 
    { 
        public int usu_iid { get; set; }
        public string usu_dni { get; set; }
        public string usu_password { get; set; }
        public DateTime? usu_datecreated { get; set; }
        public int? usu_estado { get; set; }
        public int usu_tipo { get; set; }
        public string usu_email { get; set; }

        public UsuarioEstado UsuEstadoNavigation { get; set; }
        public UsuarioPaciente UsuI { get; set; }
        public UsuarioTipo UsuTipoNavigation { get; set; }
    }
}
