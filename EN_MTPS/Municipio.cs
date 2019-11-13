using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_MTPS
{
    public class Municipio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Departamento { get; set; }
        public Municipio() { }
        public Municipio(int pId, string pNombre, int pDepartamento)
        {
            Id = pId;
            Nombre = pNombre;
            Departamento = pDepartamento;
        }
    }
}
