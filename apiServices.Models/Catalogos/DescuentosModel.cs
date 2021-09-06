using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class DescuentosModel
    {
        public int SucursalID { get; set; }
        public int DescuentoID { get; set; }
        public int DescuentoPorcentaje { get; set; }
        public string DescuentoEstatus { get; set; }
        public int DescuentoResponsable { get; set; }
        public string DescuentoFechaRegistro { get; set; }
    }
}
