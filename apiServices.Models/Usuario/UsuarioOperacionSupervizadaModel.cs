using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Usuario
{
    public class UsuarioOperacionSupervizadaModel
    {
        public string Responsable { get; set; }
        public string Autorizador { get; set; }
        public string Fecha { get; set; }
        public string Operacion { get; set; }
        public string Password{ get; set; }
        public string Cliente { get; set; }
        public int Sucursal { get; set; }
    }
}
