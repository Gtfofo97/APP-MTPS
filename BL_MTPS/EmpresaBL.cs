using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN_MTPS;
using DAL_MTPS;

namespace BL_MTPS
{
    public class EmpresaBL
    {
        EmpresaDAL empreDAL = new EmpresaDAL();

        public int AgregarEmpresa(Empresa pEmpresa)
        {
            return empreDAL.AgregarEmpresa(pEmpresa);
        }

        public List<Empresa> ObtenerEmpresas()
        {
            return empreDAL.ObtenerEmpresas();
        }

        public List<Empresa> Busqueda(string pNombre)
        {
            return EmpresaDAL.Busqueda(pNombre);
        }

        public int ActualizarEmpresa(Empresa pEmpresa)
        {
            return empreDAL.ActualizarEmpresa(pEmpresa);
        }

        public int EliminarEmpresa(Empresa pEmpresa)
        {
            return empreDAL.EliminarEmpresa(pEmpresa);
        }
    }
}
