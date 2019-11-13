using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_MTPS
{
    public class Empresa
    {
        public Int64 Id { get; set; }
        public string Fecha { get; set; }
        public int CantidadSucursales { get; set; }
        public string NoInscripcion { get; set; }
        public string NombreEmpresa { get; set; }
        public string Giro { get; set; }
        public decimal CapitalActivo { get; set; }
        public decimal CapitalSocial { get; set; }
        public string NIT { get; set; }
        public string RepresentanteLegal { get; set; }
        public string Telefono { get; set; }
        public string DireccionCasaMatriz { get; set; }
        public string PersonaDesignada { get; set; }
        public string EstadoEmpresa { get; set; }
        public string Tipo { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string FechaActualizacion { get; set; }


        //constructor vacio
        public Empresa() { }

        //constructor parametrizado
        public Empresa(Int64 pId, string pFecha, int pCantidadSucursales, string pNoInscripcion, string pNombreEmpresa, string pGiro, 
            Decimal pCapitalActivo, Decimal pCapitalSocial, string pNIT, string pRepresentanteLegal, string pTelefono, string pDireccionCasaMatriz,
            string pPersonaDesignada, string pEstadoEmpresa, string pTipo, string pDepartamento, string pMunicipio, string pFechaActualizacion)
        {
            Id = pId;
            Fecha = pFecha;
            CantidadSucursales = pCantidadSucursales;
            NoInscripcion = pNoInscripcion;
            NombreEmpresa = pNombreEmpresa;
            Giro = pGiro;
            CapitalActivo = pCapitalActivo;
            CapitalSocial = pCapitalSocial;
            NIT = pNIT;
            RepresentanteLegal = pRepresentanteLegal;
            Telefono = pTelefono;
            DireccionCasaMatriz = pDireccionCasaMatriz;
            PersonaDesignada = pPersonaDesignada;
            EstadoEmpresa = pEstadoEmpresa;
            Tipo = pTipo;
            Departamento = pDepartamento;
            Municipio = pMunicipio;
            FechaActualizacion = pFechaActualizacion;
        }
        
    }
}
