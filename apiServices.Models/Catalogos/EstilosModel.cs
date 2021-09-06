using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class EstilosModel
    {
        public int SucursalID { get; set; }
        public int EstiloID { get; set; }
        public string EstiloNombre { get; set; }
        public string EstiloEstatus { get; set; }
        public int EstiloResponsable { get; set; }
        public string EstiloFechaRegistro { get; set; }
    }
}
