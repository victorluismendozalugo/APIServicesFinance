using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class GenerosModel
    {
        public int SucursalID { get; set; }
        public int GeneroID { get; set; }
        public string GeneroDescripcion { get; set; }
        public string GeneroEstatus { get; set; }
        public int GeneroResponsable { get; set; }
        public string GeneroFechaRegistro { get; set; }
    }
}
