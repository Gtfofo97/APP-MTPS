using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using EN_MTPS;

namespace DAL_MTPS
{
    public class MunicipioDAL
    {
        public static List<Municipio> ObtenerMunicipio(int pId)
        {
            List<Municipio> municipio = new List<Municipio>();
            using (IDbConnection con = DBCommon.Conexion())
            {
                con.Open();
                string ssql = "select * from Municipio Where Departamento=@Id";
                SqlCommand comando = DBCommon.ObtenerComando(ssql, con) as SqlCommand;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@Id", pId);
                IDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    municipio.Add(new Municipio(lector.GetInt32(0),
                                                 lector.GetString(1),
                                                 lector.GetInt32(2)));
                }
                con.Close();
            }
            return municipio;
        }
    }
}
