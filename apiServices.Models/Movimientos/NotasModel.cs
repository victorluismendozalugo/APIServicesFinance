using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Movimientos
{
    public class NotasModel
    {
        public int NotaID { get; set; }
        public int SucursalID { get; set; }
        public int ClienteID { get; set; }
        public string FechaMovimiento { get; set; }
        public string FechaEvento { get; set; }
        public string FechaEntrega { get; set; }
        public string FechaDevolucion { get; set; }
        public int DescuentoID { get; set; }
        public int Tipogancho { get; set; }
        public string Estatus { get; set; }
        public int UsuarioRegistro { get; set; }
        public List<NotaDetalle> NotaDetalle { get; set; }
        public List<NotaPagos> NotaPagos { get; set; }
        public double Abonos { get; set; }
        public double SaldoRestante { get; set; }
        public double SubTotal { get; set; }
        public int ProdCantidad { get; set; }

        //estas propiadades se usan para verificar la disponibilidad
        public string ProductoCod { get; set; }
        public bool Disponible { get; set; }
    }

    public class NotaDetalle
    {
        public int NotaID { get; set; }
        public int SucursalID { get; set; }
        public int ProductoID { get; set; }
        public string ProductoCod { get; set; }
        public double ProdPrecioRenta { get; set; }
        public double ProdPrecioVenta { get; set; }
        public double ProdPrecioGarantia { get; set; }
        public string ProductoDescCorta { get; set; }
        public string ProductoDescLarga { get; set; }
        public string ColorNombre { get; set; }
        public int ProdCantidad { get; set; }

    }

    public class NotaPagos
    {
        public int NotaID { get; set; }
        public int SucursalID { get; set; }
        public int PagoID { get; set; }
        public string PagoNombre { get; set; }
        public string PagoFecha { get; set; }
        public double PagoImporte { get; set; }
    }
}
