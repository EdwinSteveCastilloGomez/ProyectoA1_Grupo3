using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using Models;

namespace Models
{
    public class Departamento
    {
        public string Nombre { get; set; }
        public string Cabecera { get; set; }
        public decimal DistanciaDesdeCapital { get; set; }
        public int Poblacion { get; set; }
        public int NumerodeMunicipios { get; set; }
        public List<Lugar_Turistico> LugaresTuristicos { get; }

        public Departamento(string nombre, string cabecera, decimal distanciadesdecapital, int poblacion, int numeromunicipios, List<Lugar_Turistico> lugaresturisticos)
        {
            Nombre = nombre;
            Cabecera = cabecera;
            DistanciaDesdeCapital = distanciadesdecapital;
            Poblacion = poblacion;
            NumerodeMunicipios = numeromunicipios;
            LugaresTuristicos = lugaresturisticos;
        }

        public Departamento(string nombre, int poblacion)
        {
            Nombre = nombre;
            Poblacion = poblacion;
        }

    }
}
