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
    public class EmpresaDAL
    {
        public int AgregarEmpresa(Empresa pEmpresa)
        {
            int result = 0;
            using (IDbConnection con = DBCommon.Conexion())
            {
                con.Open();
                string ssql = @"INSERT INTO REGISTRO_EMPRESA(FECHA, CANTIDAD_SUCURSALES, NoINSCRIPCION, NOMBRE_EMPRESA,
                GIRO, CAPITAL_ACTIVO, CAPITAL_SOCIAL, NIT, REPRESENTANTE_LEGAL, TELEFONO, DIRECCION_CASA_MATRIZ,
                PERSONA_DESIGNADA, ESTADO_EMPRESA, TIPO, DEPARTAMENTO, MUNICIPIO, FECHA_ACTUALIZACION)
                VALUES(@Fecha, @CantidadSucursales, @NoInscripcion, @NombreEmpresa, @Giro, @CapitalActivo,
                @CapitalSocial, @NIT, @RepresentanteLegal, @Telefono, @DireccionCasaMatriz,
                @PersonaDesignada, @EstadoEmpresa, @Tipo, @Departamento, @Municipio, @FechaActualizacion)";
                SqlCommand comando = DBCommon.ObtenerComando(ssql, con) as SqlCommand;
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@Fecha", pEmpresa.Fecha);
                comando.Parameters.AddWithValue("@CantidadSucursales", pEmpresa.CantidadSucursales);
                comando.Parameters.AddWithValue("@NoInscripcion", pEmpresa.NoInscripcion);
                comando.Parameters.AddWithValue("@NombreEmpresa", pEmpresa.NombreEmpresa);
                comando.Parameters.AddWithValue("@Giro", pEmpresa.Giro);
                comando.Parameters.AddWithValue("@CapitalActivo", pEmpresa.CapitalActivo);
                comando.Parameters.AddWithValue("@CapitalSocial", pEmpresa.CapitalSocial);
                comando.Parameters.AddWithValue("@NIT", pEmpresa.NIT);
                comando.Parameters.AddWithValue("@RepresentanteLegal", pEmpresa.RepresentanteLegal);
                comando.Parameters.AddWithValue("@Telefono", pEmpresa.Telefono);
                comando.Parameters.AddWithValue("@DireccionCasaMatriz", pEmpresa.DireccionCasaMatriz);
                comando.Parameters.AddWithValue("@PersonaDesignada", pEmpresa.PersonaDesignada);
                comando.Parameters.AddWithValue("@EstadoEmpresa", pEmpresa.EstadoEmpresa);
                comando.Parameters.AddWithValue("@Tipo", pEmpresa.Tipo);
                comando.Parameters.AddWithValue("@Departamento", pEmpresa.Departamento);
                comando.Parameters.AddWithValue("@Municipio", pEmpresa.Municipio);
                comando.Parameters.AddWithValue("@FechaActualizacion", pEmpresa.FechaActualizacion);
                result = comando.ExecuteNonQuery();

                con.Close();
            }
            return result;
        }

        public List<Empresa> ObtenerEmpresas()
        {
            List<Empresa> listaEmpre = new List<Empresa>();
            using (IDbConnection con = DBCommon.Conexion())
            {
                con.Open();
                string ssql = "SELECT * FROM REGISTRO_EMPRESA";

                SqlCommand comando = DBCommon.ObtenerComando(ssql, con) as SqlCommand;
                //la consulta no sera stored procedure sino que text
                comando.CommandType = CommandType.Text;

                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    listaEmpre.Add(new Empresa(reader.GetInt64(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), 
                        reader.GetString(5), reader.GetDecimal(6), reader.GetDecimal(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), 
                        reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetString(16),
                        reader.GetString(17)));
                }

                con.Close();
            }
            return listaEmpre;
        }

        public static List<Empresa> Busqueda(string pNombre)
        {
            List<Empresa> lista = new List<Empresa>();
            using (IDbConnection con = DBCommon.Conexion())
            {
                con.Open();
                string ssql = "SELECT * FROM REGISTRO_EMPRESA WHERE NOMBRE_EMPRESA LIKE '%{0}%'";
                string consulta = string.Format(ssql, pNombre);
                SqlCommand comando = DBCommon.ObtenerComando(consulta, con) as SqlCommand;
                comando.CommandType = CommandType.Text;
                
                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Empresa(reader.GetInt64(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4),
                        reader.GetString(5), reader.GetDecimal(6), reader.GetDecimal(7), reader.GetString(8), reader.GetString(9), reader.GetString(10),
                        reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetString(16),
                        reader.GetString(17)));
                }
                con.Close();
            }
            return lista;
        }

        public int ActualizarEmpresa(Empresa pEmpresa)
        {
            int result = 0;

            using (IDbConnection con = DBCommon.Conexion())
            {
                con.Open();
                string ssql = @"UPDATE REGISTRO_EMPRESA SET FECHA = @Fecha, CANTIDAD_SUCURSALES = @CantidadSucursales,
                                NoINSCRIPCION = @NoInscripcion, NOMBRE_EMPRESA = @NombreEmpresa, GIRO = @Giro,
                                CAPITAL_ACTIVO = @CapitalActivo, CAPITAL_SOCIAL = @CapitalSocial, NIT = @NIT,
                                REPRESENTANTE_LEGAL = @RepresentanteLegal, TELEFONO = @Telefono, 
                                DIRECCION_CASA_MATRIZ = @DireccionCasaMatriz, PERSONA_DESIGNADA = @PersonaDesignada,
                                ESTADO_EMPRESA = @EstadoEmpresa, TIPO = @Tipo, DEPARTAMENTO = @Departamento, 
                                MUNICIPIO = @Municipio, FECHA_ACTUALIZACION = @FechaActualizacion WHERE ID = @Id";
                SqlCommand comando = DBCommon.ObtenerComando(ssql, con) as SqlCommand;
                comando.CommandType = CommandType.Text;
                
                comando.Parameters.AddWithValue("@Fecha", pEmpresa.Fecha);
                comando.Parameters.AddWithValue("@CantidadSucursales", pEmpresa.CantidadSucursales);
                comando.Parameters.AddWithValue("@NoInscripcion", pEmpresa.NoInscripcion);
                comando.Parameters.AddWithValue("@NombreEmpresa", pEmpresa.NombreEmpresa);
                comando.Parameters.AddWithValue("@Giro", pEmpresa.Giro);
                comando.Parameters.AddWithValue("@CapitalActivo", pEmpresa.CapitalActivo);
                comando.Parameters.AddWithValue("@CapitalSocial", pEmpresa.CapitalSocial);
                comando.Parameters.AddWithValue("@NIT", pEmpresa.NIT);
                comando.Parameters.AddWithValue("@RepresentanteLegal", pEmpresa.RepresentanteLegal);
                comando.Parameters.AddWithValue("@Telefono", pEmpresa.Telefono);
                comando.Parameters.AddWithValue("@DireccionCasaMatriz", pEmpresa.DireccionCasaMatriz);
                comando.Parameters.AddWithValue("@PersonaDesignada", pEmpresa.PersonaDesignada);
                comando.Parameters.AddWithValue("@EstadoEmpresa", pEmpresa.EstadoEmpresa);
                comando.Parameters.AddWithValue("@Tipo", pEmpresa.Tipo);
                comando.Parameters.AddWithValue("@Departamento", pEmpresa.Departamento);
                comando.Parameters.AddWithValue("@Municipio", pEmpresa.Municipio);
                comando.Parameters.AddWithValue("@FechaActualizacion", pEmpresa.FechaActualizacion);
                comando.Parameters.AddWithValue("@Id", pEmpresa.Id);

                result = comando.ExecuteNonQuery();
                con.Close();
            }

                return result;
        }

        public int EliminarEmpresa(Empresa pEmpresa)
        {
            int result = 0;
            using (IDbConnection con = DBCommon.Conexion())
            {
                con.Open();
                string ssql = @"DELETE FROM REGISTRO_EMPRESA WHERE Id = @Id";
                SqlCommand comando = DBCommon.ObtenerComando(ssql, con) as SqlCommand;
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@Id", pEmpresa.Id);
                result = comando.ExecuteNonQuery();
                con.Close();
            }
            return result;
        }
    }
}
