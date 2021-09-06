using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class TallasModel
    {
        public int SucursalID { get; set; }
        public int TallaID { get; set; }
        public string TallaNumero { get; set; }
        public string TallaEstatus { get; set; }
        public int TallaResponsable { get; set; }
        public string TallaFechaRegistro { get; set; }
    }
}
