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
        public string Usuario { get; set; }
        public int SucursalID { get; set; }
        public string Identificacion { get; set; }
        public string CompDomicilio { get; set; }
        public string CompIngresos { get; set; }
        public string ReferenciaNombre1 { get; set; }
        public string ReferenciaTelefono1 { get; set; }
        public string ReferenciaNombre2 { get; set; }
        public string ReferenciaTelefono2 { get; set; }
        public string FechaRegistro { get; set; }
    }
}
