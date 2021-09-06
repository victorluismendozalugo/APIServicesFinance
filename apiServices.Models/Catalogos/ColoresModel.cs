using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class ColoresModel
    {
        public int SucursalID { get; set; }
        public int ColorID { get; set; }
        public string ColorNombre { get; set; }
        public string ColorEstatus { get; set; }
        public int ColorResponsable { get; set; }
        public string ColorFechaRegistro { get; set; }
    }
}
