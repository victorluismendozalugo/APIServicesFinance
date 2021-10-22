using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices.Models.Usuario
{
    public class UsuarioTipoModel
    {
        public string Usuario { get; set; }
        public int Sucursal { get; set; }
        public int RolID { get; set; }
        public string TipoUsuario
        {

            get
            {
                switch (RolID)
                {
                    case 1:
                        return "ADMINISTRADOR";

                    case 2:
                        return "INVERSION";

                    case 3:
                        return "PRESTAMO";

                    default:
                        return "";

                }
            }
        }
    }
}
