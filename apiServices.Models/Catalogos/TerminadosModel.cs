using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class TerminadosModel
    {
        public int SucursalID { get; set; }
        public int TerminadoID { get; set; }
        public string TerminadoNombre { get; set; }
        public string TerminadoEstatus { get; set; }
        public int TerminadoResponsable { get; set; }
        public string TerminadoFechaRegistro { get; set; }
    }
}
