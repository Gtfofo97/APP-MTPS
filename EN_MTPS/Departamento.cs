using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_MTPS
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Departamento() { }
        public Departamento(int pId, string pNombre)
        {
            Id = pId;
            Nombre = pNombre;
        }
    }
}
