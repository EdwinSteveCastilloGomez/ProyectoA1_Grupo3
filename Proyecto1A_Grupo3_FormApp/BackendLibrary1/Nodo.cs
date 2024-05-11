using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Models
{
    public class Nodo
    {
        public Departamento Informacion { get; set; }
        public Nodo LigaNorte {  get; set; }
        public Nodo LigaSur {  get; set; }
        public Nodo LigaEste { get; set; }
        public Nodo LigaOeste { get; set; }

        
        public Nodo(Departamento informacion)
        {
            Informacion = informacion;
            LigaNorte = null;
            LigaSur = null;
            LigaEste = null;
            LigaOeste = null;

        }

    }
}
