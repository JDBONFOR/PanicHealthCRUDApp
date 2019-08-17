using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public class Paciente
    {
        
        public int pac_iid { get; set; }
        public string pac_numeroos { get; set; }
        public int? pac_os_iid { get; set; }
        public string pac_nombre { get; set; }
        public string pac_apellido { get; set; }
        public string pac_dni { get; set; }
        public int? pac_doc_iid { get; set; }
        public int? pac_prof_iid { get; set; }

    }
}
