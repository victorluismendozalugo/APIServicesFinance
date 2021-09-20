namespace apiServices.Models.Notificaciones
{
    public class NotificacionesModel
    {
        public int NotificacionID { get; set; }
        public int Sucursal { get; set; }
        public string Remitente { get; set; }
        public string Receptor { get; set; }
        public string Fecha { get; set; }
        public string Previa { get; set; }
        public string Texto { get; set; }
        public string Imagen { get; set; }
        public string Estatus { get; set; }

    }
}
