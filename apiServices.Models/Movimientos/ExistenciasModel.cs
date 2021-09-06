using apiServices.Models.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Movimientos
{
    public class ExistenciasModel : ProductosModel
    {
        //public int ProductoSucID { get; set; }
        //public int ProductoID { get; set; }
        public int ProdExistencia { get; set; }
        public int ProdRentas { get; set; }
        public int ProdDefectos { get; set; }
        public decimal ProdCostoRenta { get; set; }
        public decimal ProdCostoVenta { get; set; }
        public decimal ProdCostoGarantia { get; set; }
        public string UltimoMovimiento { get; set; }
        public int UsuarioResponsable { get; set; }
    }
}
