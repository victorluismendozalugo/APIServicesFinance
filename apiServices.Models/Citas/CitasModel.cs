using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Citas
{
    public class CitasModel
    {
        public int CitaID { get; set; }
        public int CitaTipo { get; set; }
        public int SucursalID { get; set; }
        public string CitaFecha { get; set; }
        public int CitaDiaID { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteAp { get; set; }
        public string ClienteTelefono { get; set; }
        public string ClienteEmail { get; set; }
        public bool CitaEstatus { get; set; }
        public bool CitaConfirmacion { get; set; }
        public int CitaCantidadPersonas { get; set; }
    }

    public class TiposCitasModel
    {
        public int SucursalID { get; set; }
        public int TipoID { get; set; }
        public string TipoDescripcion { get; set; }
        public bool TipoEstatus { get; set; }
    }

    public class ConfiguracionCitasModel
    {
        public int CitaID { get; set; }
        public int SucursalID { get; set; }
        public int CitaDiaID { get; set; }
        public string CitaHora { get; set; }
        public string CitaFecha { get; set; }
        public bool EstatusCitaHora { get; set; }
    }
}
