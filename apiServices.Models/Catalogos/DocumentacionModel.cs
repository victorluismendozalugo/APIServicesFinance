using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class DocumentacionModel
    {
        public int UsuarioID { get; set; }
        public int IDSolicitud { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apaterno { get; set; }
        public string Amaterno { get; set; }
        public string Correo { get; set; }
        public string NombreCompleto { get; set; }
        public int SucursalID { get; set; }
        public string Identificacion { get; set; }
        public string CompDomicilio { get; set; }
        public string CompIngresos { get; set; }
        public string ReferenciaNombre1 { get; set; }
        public string ReferenciaTelefono1 { get; set; }
        public string ReferenciaNombre2 { get; set; }
        public string ReferenciaTelefono2 { get; set; }
        public string FechaRegistro { get; set; }
        public int PorcentajeDoc { get; set; }
        public int TipoUsuario { get; set; }

        public int IDCliente { get; set; }
        public int IDSucursal { get; set; }
        public string DondeSeEntero { get; set; }
        public string Genero { get; set; }
        public string FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string PaisNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string curp { get; set; }
        public string rfc { get; set; }
        public string NivelEstudios { get; set; }
        public string EdoCivil { get; set; }
        public string Ocupacion { get; set; }
        public string CalleNumero { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public int TiempoVivir { get; set; }
        public string Celular { get; set; }
        public string TelefonoCasa { get; set; }
        public string EntidadFederativa { get; set; }
        public string NombreEmpresa { get; set; }
        public string CalleNumeroEmpresa { get; set; }
        public string ColoniaEmpresa { get; set; }
        public string CodigoPostalEmpresa { get; set; }
        public string MunicipioEmpresa { get; set; }
        public string EstadoEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }
        public int Antiguedad { get; set; }
        public string IngresoMensual { get; set; }
        public string FrecuenciaPago { get; set; }
        public string NombreConyugue { get; set; }
        public string ApellidoPConyugue { get; set; }
        public string ApellidoMConyugue { get; set; }
        public string TelefonoConyugue { get; set; }
        public string CelularConyugue { get; set; }
        public string OcupacionConyugue { get; set; }
        public string IngresoMensualConyugue { get; set; }
        public string BancoCredito { get; set; }
        public string CtaClabeTarjeta { get; set; }

        public string ReferenciaNombre3 { get; set; }
        public string ReferenciaTelefono3 { get; set; }
        public string ReferenciaNombre4 { get; set; }
        public string ReferenciaTelefono4 { get; set; }

        public string TipoVivienda { get; set; }
        public string Parentesco1 { get; set; }
        public string Parentesco2 { get; set; }
        public string Parentesco3 { get; set; }
        public string Parentesco4 { get; set; }

        public int MontoSolicitado { get; set; }
        public int InteresOrdinario { get; set; }
        public int TotalPagar { get; set; }
        public int ValorXpago { get; set; }
        public int TipoCliente { get; set; }
        public string Estatus { get; set; }

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

                    default:
                        return "";

                }
            }
        }
    }

    public class DocumentacionModel2 {
        public string Identificacion { get; set; }
        public string CompDomicilio { get; set; }
        public string CompIngresos { get; set; }

    }
}
