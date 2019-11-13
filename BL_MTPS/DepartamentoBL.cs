using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EN_MTPS;
using DAL_MTPS;

namespace BL_MTPS
{
    public class DepartamentoBL
    {
        DepartamentoDAL dal = new DepartamentoDAL();
        public List<Departamento> Mostrar()
        {
            return dal.MostrarDepartamentos();
        }
    }
}
