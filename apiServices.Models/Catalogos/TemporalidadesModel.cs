using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class TemporalidadesModel
    {
        public int SucursalID { get; set; }
        public int TemporalidadID { get; set; }
        public string TempNombre { get; set; }
        public string TempEstatus { get; set; }
        public int TempResponsable { get; set; }
        public string TempFechaRegistro { get; set; }
    }
}
