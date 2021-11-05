using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class SolicitudesModel
    {
        public int Sucursal { get; set; }
        public string Usuario { get; set; }
        public string Solicitud { get; set; }
        public string FechaCarga { get; set; }
        public string Estatus { get; set; }
        public string Responsable { get; set; }
    }
}
