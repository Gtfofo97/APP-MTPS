using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN_MTPS;
using System.Data;
using System.Data.SqlClient;

namespace DAL_MTPS
{
    public class UsuarioDAL
    {
        public int AgregarUsuario(Usuario pUsuario)
        {
            int result = 0;
            using (IDbConnection con = DBCommon.Conexion())
            {
                con.Open();
                string ssql = @"INSERT INTO USUARIO(NOMBRE, EMAIL, USERNAME, CLAVE) VALUES(@Nombre, @Email, @Username, @Clave)";
                SqlCommand comando = DBCommon.ObtenerComando(ssql, con) as SqlCommand;
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
                comando.Parameters.AddWithValue("@Username", pUsuario.Username);
                comando.Parameters.AddWithValue("@Email", pUsuario.Email);
                comando.Parameters.AddWithValue("@Clave", pUsuario.Clave);
                result = comando.ExecuteNonQuery();

                con.Close();
            }
            return result;
        }

        public List<Usuario> ObtenerUsuario()
        {
            List<Usuario> listaUsers = new List<Usuario>();
            using (IDbConnection con = DBCommon.Conexion())
            {
                con.Open();
                string ssql = "SELECT * FROM USUARIO";

                SqlCommand comando = DBCommon.ObtenerComando(ssql, con) as SqlCommand;
                //la consulta no sera stored procedure sino que text
                comando.CommandType = CommandType.Text;

                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    listaUsers.Add(new Usuario(reader.GetInt64(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                }

                con.Close();
            }
            return listaUsers;
        }

        public static List<Usuario>Busqueda(string pNombre)
        {
            List<Usuario> lista = new List<Usuario>();
            using (IDbConnection con = DBCommon.Conexion())
            {
                con.Open();
                string ssql = "SELECT * FROM USUARIO WHERE NOMBRE LIKE '%{0}%'";
                string consulta = string.Format(ssql, pNombre);
                SqlCommand comando = DBCommon.ObtenerComando(consulta, con) as SqlCommand;
                comando.CommandType = CommandType.Text;

                //comando.Parameters.AddWithValue("@b", pNombre);
                IDataReader lector = comando.ExecuteReader();
                while(lector.Read())
                {
                    Usuario user = new Usuario();
                    user.Id = lector.GetInt64(0);
                    user.Nombre = lector.GetString(1);
                    user.Email = lector.GetString(2);
                    user.Username = lector.GetString(3);
                    user.Clave = lector.GetString(4);

                    lista.Add(user);
                }
                con.Close();
            }
            return lista;
        }

        public int ActualizarUsuario(Usuario pUsuario)
        {
            int result = 0;
            using (IDbConnection con = DBCommon.Conexion())
            {
                con.Open();
                string ssql = @"UPDATE USUARIO SET NOMBRE = @Nombre, USERNAME = @Username, EMAIL = @Email, CLAVE = @Clave
                                WHERE ID = @Id";
                SqlCommand comando = DBCommon.ObtenerComando(ssql, con) as SqlCommand;
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
                comando.Parameters.AddWithValue("@Username", pUsuario.Username);
                comando.Parameters.AddWithValue("@Email", pUsuario.Email);
                comando.Parameters.AddWithValue("@Clave", pUsuario.Clave);
                comando.Parameters.AddWithValue("@Id", pUsuario.Id);
                result = comando.ExecuteNonQuery();

                con.Close();
            }
                return result;
        }

        public int EliminarUsuario(Usuario pUsuario)
        {
            int result = 0;
            using (IDbConnection con = DBCommon.Conexion())
            {
                con.Open();
                string ssql = @"DELETE FROM USUARIO WHERE Id = @Id";
                SqlCommand comando = DBCommon.ObtenerComando(ssql, con) as SqlCommand;
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@Id", pUsuario.Id);
                result = comando.ExecuteNonQuery();
                con.Close();
            }
            return result;
        }


        public static int Login(Usuario pUsuario)
        {
            int ListaUsuario = 0;
            using (IDbConnection con = DBCommon.Conexion())
            {
                con.Open();
                string ssql = @"SELECT USERNAME, CLAVE FROM USUARIO WHERE USERNAME = @Username AND CLAVE = @Clave";
                SqlCommand comando = DBCommon.ObtenerComando(ssql, con) as SqlCommand;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("Username", pUsuario.Username);
                comando.Parameters.AddWithValue("Clave", pUsuario.Clave);
                IDataReader _reader = comando.ExecuteReader();
                if (_reader.Read())
                {
                    ListaUsuario = 1;
                }
                else
                {
                    ListaUsuario = 0;
                }
                con.Close();
            }
            return ListaUsuario;
        }
    }
}
