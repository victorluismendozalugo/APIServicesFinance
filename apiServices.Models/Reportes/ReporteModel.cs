using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models
{
    public class ReporteModel
    {
        //procClientesReporteCon
        public int Sucursal { get; set; }
        public int IDUsuario { get; set; }
        public string Usuario { get; set; }
        public string NombreCompleto { get; set; }
        public string FechaRegistro { get; set; }
        public int RolID { get; set; }
        public string Estatus { get; set; }
        public string EdoCivil { get; set; }
        public string Ocupacion { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal InteresOrdinario { get; set; }
        public decimal TotalPagar { get; set; }
        public decimal ValorXpago { get; set; }
        public string FechaAutorizacion { get; set; }
        public string FechaDeposito { get; set; }
        public string FechaUltimoAbono { get; set; }
        public decimal UltimoAbono { get; set; }

        public string EstatusNombre
        {

            get
            {
                switch (Estatus)
                {
                    case "A":
                        return "PROSPECTO";

                    case "T":
                        return "AUTORIZADO";

                    case "B":
                        return "INACTIVO";

                    case "D":
                        return "DISPERSADO";
                    default:
                        return "";

                }
            }
        }
        public string TipoUsuario
        {

            get
            {
                switch (RolID)
                {
                    case 1:
                        return "ADMINISTRADOR";

                    case 2:
                        return "INVERSION";

                    case 3:
                        return "PRESTAMO";

                    default:
                        return "";

                }
            }
        }
        public string Verificador { get; set; }

    }
}
