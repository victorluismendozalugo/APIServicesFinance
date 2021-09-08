namespace apiServices.Models.Usuario
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public int RolID { get; set; }
        public string Nombre { get; set; }
        public string NombreMenu { get; set; }
        public string Menu { get; set; }
        public string clase { get; set; }
        public int SucursalID { get; set; }
        public string modulo { get; set; }
    }
}