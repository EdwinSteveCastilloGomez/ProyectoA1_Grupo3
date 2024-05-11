using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Lugar_Turistico
    {
        public string Nombre {  get; set; }
        public string Departamentlocalidad { get; set; }

        public Lugar_Turistico(string nombre,string departamentolocalidad)
        {
            Nombre = nombre;
            Departamentlocalidad = departamentolocalidad;
        }
    }
}
