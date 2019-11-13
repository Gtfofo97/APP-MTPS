using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EN_MTPS;
using DAL_MTPS;

namespace BL_MTPS
{
    public class MunicipioBL
    {
        public List<Municipio> ObtenerMunicipio(int pId)
        {
            return MunicipioDAL.ObtenerMunicipio(pId);
        }
    }
}
