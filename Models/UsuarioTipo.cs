using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public partial class UsuarioTipo
    {
        public UsuarioTipo()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int UsutIid { get; set; }
        public string UsutDescripcion { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
