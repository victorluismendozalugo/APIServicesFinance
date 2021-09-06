using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class ConcCobrosModel
    {
        public int SucursalID { get; set; }
        public int ConceptoID { get; set; }
        public string ConceptoDesc { get; set; }
        public double ConceptoCosto { get; set; }
        public string ConceptoEstatus { get; set; }
        public int ConceptoResponsable { get; set; }
        public string ConceptoFechaRegistro { get; set; }
    }
}
