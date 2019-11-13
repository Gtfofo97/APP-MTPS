using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN_MTPS;
using DAL_MTPS;

namespace BL_MTPS
{
    public class UsuarioBL
    {
        UsuarioDAL userDAL = new UsuarioDAL();

        public int AgregarUsuario(Usuario pUser)
        {
            return userDAL.AgregarUsuario(pUser);
        }

        public List<Usuario> ObtenerUsuario()
        {
            return userDAL.ObtenerUsuario();
        }

        public int Login(Usuario pUser)
        {
            return UsuarioDAL.Login(pUser);
        }

        public List<Usuario> Busqueda(string pNombre)
        {
            return UsuarioDAL.Busqueda(pNombre);
        }

        public int ActualizarUsuario(Usuario pUser)
        {
            return userDAL.ActualizarUsuario(pUser);
        }

        public int EliminarUsuario(Usuario pUser)
        {
            return userDAL.EliminarUsuario(pUser);
        }
    }
}
