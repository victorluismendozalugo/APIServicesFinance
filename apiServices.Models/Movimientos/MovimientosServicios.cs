namespace apiServices.Models.Movimientos
{
    public class MovimientosServicios
    {
        public int MovimientoID { get; set; }
        public int SucursalID { get; set; }
        public int TramiteID { get; set; }
        public string TramiteNombre { get; set; }
        public decimal Costo { get; set; }
        public bool Facturar { get; set; }
        public string RazonSocial { get; set; }
        public string RFC { get; set; }
        public string Correo { get; set; }
        public int EstadoID { get; set; }
        public int MunicipioID { get; set; }
        public int LocalidadID { get; set; }
        public string Domicilio { get; set; }
        public int CP { get; set; }
        public string Telefono { get; set; }
        public string ReferenciaBancaria { get; set; }
        public string Usuario { get; set; }
        public int UsuarioID { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaModificacion { get; set; }
        public string EstatusMovimiento { get; set; }
        public string SucursalIniciales
        {
            get
            {
                switch (SucursalID)
                {
                    case 1:
                        return "CLN";
                    case 2:
                        return "MAZ";
                    case 3:
                        return "GVE";
                    case 4:
                        return "GML";
                    case 5:
                        return "LMO";
                }
                return SucursalIniciales;
            }
        }

        public string SucursalNombre
        {
            get
            {
                switch (SucursalID)
                {
                    case 1:
                        return "CULIACAN";
                    case 2:
                        return "MAZATLAN";
                    case 3:
                        return "GUASAVE";
                    case 4:
                        return "GUAMUCHIL";
                    case 5:
                        return "LOS MOCHIS";
                }
                return SucursalNombre;
            }
        }

        public int TipoPagoID { get; set; }
        public string TipoPagoNombre
        {
            get
            {
                switch (TipoPagoID)
                {
                    case 1:
                        return "DEPOSITO";
                    case 2:
                        return "TRANSFERENCIA";
                    case 3:
                        return "TERMINAL";
                }
                return TipoPagoNombre;
            }
        }
    }
}
