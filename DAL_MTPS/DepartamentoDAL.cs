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
    public class DepartamentoDAL
    {
        public List<Departamento> MostrarDepartamentos()
        {
            List<Departamento> lista = new List<Departamento>();
            using (IDbConnection con = DBCommon.Conexion())
            {
                con.Open();
                string ssql = "select * from Departamento";
                SqlCommand comando = DBCommon.ObtenerComando(ssql, con) as SqlCommand;
                comando.CommandType = CommandType.Text;
                IDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    lista.Add(new Departamento(lector.GetInt32(0),
                                                 lector.GetString(1)));
                }
                con.Close();
            }

            return lista;
        }
    }
}
