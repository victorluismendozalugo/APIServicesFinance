using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Catalogos
{
    public class ProductosModel
    {
        public int ProductoSucID { get; set; }
        public int ProductoID { get; set; }
        public string ProductoCod { get; set; }
        public string ProductoDescCorta { get; set; }
        public string ProductoDescLarga { get; set; }
        public int ProdColorID { get; set; }
        public string ColorNombre { get; set; }
        public int ProdGeneroID { get; set; }
        public string GeneroNombre { get; set; }
        public int ProdTallaID { get; set; }
        public int ProdTemporadaID { get; set; }
        public int ProdEstiloID { get; set; }
        public int ProdTerminadoID { get; set; }
        public int ProdMarcaID { get; set; }
        public string ProdEstatus { get; set; }
        public string ProdOcasion { get; set; }
        public string ProdFormalidad { get; set; }
        public int ProdUsuarioResponsable { get; set; }
        public string ProdFechaRegistro { get; set; }
        public string ProdImagen1 { get; set; }
        public string ProdImagen2 { get; set; }
        public string ProdImagen3 { get; set; }
        public string ProdImagen4 { get; set; }
        public double ProdPrecioRenta { get; set; }
        public double ProdPrecioVenta { get; set; }
        public double ProdPrecioGarantia { get; set; }
        public string EsServicio { get; set; }
    }
}
