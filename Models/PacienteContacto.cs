using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public class PacienteContacto
    {
        public int con_iid { get; set; }
        public int? con_pac_iid { get; set; }
        public string con_tel_celular { get; set; }
        public string con_nombre { get; set; }
        public string con_apellido { get; set; }
        public string con_direccion { get; set; }
        public string con_tel_other { get; set; }
        public int? con_par_iid { get; set; }
    }
}
