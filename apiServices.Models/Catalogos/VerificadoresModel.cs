using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class VerificadoresModel
    {
        public int IDSucursal { get; set; }
        public int IDVerificador { get; set; }
        public string Nombre { get; set; }
        public string Apaterno { get; set; }
        public string Amaterno { get; set; }
        public string FechaRegistro { get; set; }
        public string Estatus { get; set; }
        public string NombreCompleto
        {
            get
            {
                return Nombre + ' ' + Apaterno + ' ' + Amaterno;
            }
        }

        public int IDCredito { get; set; }
        public string Cliente { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal TotalPagar { get; set; }
        public decimal SaldoPendiente { get; set; }
        public decimal ValorXPago { get; set; }
        public string UltimoAbono { get; set; }
        public int NumeroPagos { get; set; }
        public int TotalPagos { get; set; }
        public string FechaDeposito { get; set; }

        public int Semana { get; set; }
        public int NumeroAbono { get; set; }
        public string FechaAabonar { get; set; }
        public string FechaAbono { get; set; }
        public decimal MontoAbonado { get; set; }

    }
}
