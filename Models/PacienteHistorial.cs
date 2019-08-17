using System;
using System.Collections.Generic;

namespace PanicHealth.Models
{
    public class PacienteHistorial
    {
        public int hist_pac_iid { get; set; }
        public int? hist_pac_renglon { get; set; }
        public decimal? hist_pac_latlong { get; set; }
        public int? hist_pac_acc_iid { get; set; }
        public string hist_pac_result { get; set; }
        public DateTime? hist_pac_datecreated { get; set; }
    }
}
