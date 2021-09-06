using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class ClientesModel
    {
        public int ClienteID { get; set; }
        public int SucursalID { get; set; }
        public string CliNombre { get; set; }
        public string CliAPaterno { get; set; }
        public string CliAMaterno { get; set; }
        public string CliDomicilio { get; set; }
        public string CliReferencia { get; set; }
        public string CliCalle { get; set; }
        public int CliNumero { get; set; }
        public string CliCP { get; set; }
        public int CliCiudad { get; set; }
        public int CliEstado { get; set; }
        public string CliTelefono { get; set; }
        public string CliEmail { get; set; }
        public string CliEstatus { get; set; }
        public string CliFechaRegistro { get; set; }
        public int CliResponsable { get; set; }
    }
}
