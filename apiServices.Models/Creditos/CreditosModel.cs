using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Creditos
{
    public class CreditosModel
    {
        public int IDCredito { get; set; }
        public string Cliente { get; set; }
        public double MontoSolicitado { get; set; }
        public double InteresOrdinario { get; set; }
        public double TotalPagar { get; set; }
        public double ValorXPago { get; set; }
        public string FechaAutorizacion { get; set; }
        public string FechaDeposito { get; set; }
        public string Estatus { get; set; }
        public string Responsable { get; set; }
        public double MontoAbonado { get; set; }
        public int NumeroAbono { get; set; }
        public double FechaAbono { get; set; }
    }
}
