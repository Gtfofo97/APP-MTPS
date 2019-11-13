using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EN_MTPS
{
    public class Usuario
    {
        public Int64 Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Clave { get; set; }

        //constructor vacio
        public Usuario() { }

        //constructor parametrizado
        public Usuario(Int64 pId, string pNombre, string pEmail, string pUsername, string pClave)
        {
            Id = pId;
            Nombre = pNombre;
            Email = pEmail;
            Username = pUsername;
            Clave = pClave;
        }

        //constructor que toma solo los datos personales
        public Usuario(Int64 pId, string pNombre, string pEmail, string pUsername)
        {
            Id = pId;
            Nombre = pNombre;
            Email = pEmail;
            Username = pUsername;
        }
    }
}
