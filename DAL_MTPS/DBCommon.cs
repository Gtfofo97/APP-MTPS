using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_MTPS
{
    class DBCommon
    {
        private static string Conn = @"Data Source=.;Initial Catalog=MTPSdb;Integrated Security=True";

        public static IDbConnection Conexion()
        {
            return new SqlConnection(Conn);
        }
        public static IDbCommand ObtenerComando(string pComando, IDbConnection pCnn)
        {
            return new SqlCommand(pComando, pCnn as SqlConnection);
        }
    }
}
