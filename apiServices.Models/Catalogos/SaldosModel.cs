using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class SaldosModel
    {
        public int Movimiento { get; set; }
        public string Usuario { get; set; }
        public int Sucursal { get; set; }
        public string FechaRegistro { get; set; }
        public string TablaDocumento { get; set; }
        public int TipoCliente { get; set; }
        public string Estatus { get; set; }
    }
}
