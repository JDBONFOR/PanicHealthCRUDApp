using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public partial class UsuarioEstado
    {
        public UsuarioEstado()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int UsuarioestadoIid { get; set; }
        public string UsuarioestadoDescripcion { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
