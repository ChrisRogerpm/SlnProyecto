using System;
using System.Collections.Generic;
using System.Text;

namespace Entidad
{
    public class UsuarioEntidad
    {
        public int idUsuario { get; set; }
        public string idTipoUsuario { get; set; }
        public string email { get; set; }
        public string password { get; set; }        
        public int estado { get; set; }
    }
}
