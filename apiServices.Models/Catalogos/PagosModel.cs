using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class PagosModel
    {
        public int SucursalID { get; set; }
        public int PagoID { get; set; }
        public string PagoNombre { get; set; }
        public string PagoEstatus { get; set; }
        public int PagoResponsable { get; set; }
        public string PagoFechaRegistro { get; set; }
    }
}
