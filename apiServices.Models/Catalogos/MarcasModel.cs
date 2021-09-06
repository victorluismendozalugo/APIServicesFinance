using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class MarcasModel : ProductosModel
    {
        public int SucursalID { get; set; }
        public int MarcaID { get; set; }
        public string MarcaNombre { get; set; }
        public string MarcaEstatus { get; set; }
        public int MarcaResponsable { get; set; }
        public string MarcaFechaRegistro { get; set; }
    }
}
