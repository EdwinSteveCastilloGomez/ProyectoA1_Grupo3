using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Models;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;


namespace DataAcces
{
    public class DatabaseManager
    {
        public Nodo NodoOrigen { get; set; }

        string connectionString = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;

        public List<Nodo> CrearNodosDesdeBaseDeDatos()
        {
            List<Nodo> nodos = new List<Nodo>();

            // Conectando a la base de datos
            using (SqlConnection connection1 = new SqlConnection(connectionString))
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                connection1.Open();
                connection2.Open();


                // Recuperar datos de la tabla departamento
                string queryDepartamentos = "SELECT Nombre, Cabecera, DistanciDesdeCapital, poblacion, NumerodeMunicipios FROM DEPARTAMENTO";
                SqlCommand commandDepartamentos = new SqlCommand(queryDepartamentos, connection1);
                SqlDataReader readerDepartamentos = commandDepartamentos.ExecuteReader();
                while (readerDepartamentos.Read())
                {
                    string nombre = readerDepartamentos["Nombre"].ToString();
                    string cabecera = readerDepartamentos["Cabecera"].ToString();
                    decimal distancia = (decimal)readerDepartamentos["DistanciDesdeCapital"];
                    int poblacion = (int)readerDepartamentos["poblacion"];
                    int numMunicipios = (int)readerDepartamentos["NumerodeMunicipios"];
                    //Serar el datareader#1 para evitar error
          
                    // Recuperar lugares turísticos para este departamento
                    List<Lugar_Turistico> lugaresTuristicos = new List<Lugar_Turistico>();
                    string queryLugaresTuristicos = "SELECT Nombre FROM LUGAR_TURISTICO WHERE Departamento = @NombreDepartamento";
                    SqlCommand commandLugaresTuristicos = new SqlCommand(queryLugaresTuristicos, connection2);
                    commandLugaresTuristicos.Parameters.AddWithValue("@NombreDepartamento", nombre);
                    SqlDataReader readerLugaresTuristicos = commandLugaresTuristicos.ExecuteReader();
                    while (readerLugaresTuristicos.Read())
                    {
                        string nombreLugar = readerLugaresTuristicos["Nombre"].ToString();
                        lugaresTuristicos.Add(new Lugar_Turistico(nombreLugar, nombre));
                    }

                    Departamento departamento = new Departamento(nombre, cabecera, distancia, poblacion, numMunicipios, lugaresTuristicos);
                    Nodo nodo = new Nodo(departamento);
                    nodos.Add(nodo);

                    readerLugaresTuristicos.Close();
                }
                readerDepartamentos.Close();

                connection1.Close();
                connection2.Close();

            }

            // Establecer nodoOrigen y referencias entre los nodos según su posición

            foreach (Nodo nodo in nodos)
            {
                switch (nodo.Informacion.Nombre)
                {
                    case "Alta Verapaz":
                        nodo.LigaNorte = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Petén");
                        nodo.LigaSur = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Quiché");
                        nodo.LigaEste = null;
                        nodo.LigaOeste = null;
                        break;
                    case "Baja Verapaz":
                        nodo.LigaNorte = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Quiché");
                        nodo.LigaSur = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Guatemala");
                        nodo.LigaEste = null;
                        nodo.LigaOeste = null;
                        break;
                    case "Chimaltenango":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Sacatepéquez"); 
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Sololá"); 
                        break;
                    case "Chiquimula":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Zacapa"); 
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Jalapa"); 
                        break;
                    case "El Progreso":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Jalapa");
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Guatemala");
                        break;
                    case "Escuintla":
                        nodo.LigaNorte = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Santa Rosa");
                        nodo.LigaSur = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Jutiapa");
                        nodo.LigaEste = null;
                        nodo.LigaOeste = null;
                        break;
                    case "Guatemala":
                        NodoOrigen = nodo;//Asignando como NodoOrigen al nodo Guatemala.
                        nodo.LigaNorte = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Baja Verapaz");
                        nodo.LigaSur = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Santa Rosa");
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "El Progreso");
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Sacatepéquez");
                        break;
                    case "Huehuetenango":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Quetzaltenango");
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "San Marcos");
                        break;
                    case "Izabal":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = null;
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Zacapa");
                        break;
                    case "Jalapa":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Chiquimula");
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "El Progreso");
                        break;
                    case "Jutiapa":
                        nodo.LigaNorte = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Escuintla");
                        nodo.LigaSur = null;
                        nodo.LigaEste = null;
                        nodo.LigaOeste = null;
                        break;
                    case "Petén":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Alta Verapaz");
                        nodo.LigaEste = null;
                        nodo.LigaOeste = null;
                        break;
                    case "Quetzaltenango":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Retalhuleu");
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Huehuetenango");
                        break;
                    case "Quiché":
                        nodo.LigaNorte = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Alta Verapaz");
                        nodo.LigaSur = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Baja Verapaz");
                        nodo.LigaEste = null;
                        nodo.LigaOeste = null;
                        break;
                    case "Retalhuleu":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Suchitepéquez");
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Quetzaltenango");
                        break;
                    case "Sacatepéquez":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Guatemala");
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Chimaltenango");
                        break;
                    case "San Marcos":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Huehuetenango");
                        nodo.LigaOeste = null;
                        break;
                    case "Santa Rosa":
                        nodo.LigaNorte = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Guatemala");
                        nodo.LigaSur = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Escuintla");
                        nodo.LigaEste = null;
                        nodo.LigaOeste = null;
                        break;
                    case "Sololá":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Chimaltenango");
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Totonicapán");
                        break;
                    case "Suchitepéquez":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Totonicapán");
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Retalhuleu");
                        break;
                    case "Totonicapán":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Sololá");
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Suchitepéquez");
                        break;
                    case "Zacapa":
                        nodo.LigaNorte = null;
                        nodo.LigaSur = null;
                        nodo.LigaEste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Izabal");
                        nodo.LigaOeste = nodos.FirstOrDefault(x => x.Informacion.Nombre == "Chiquimula");
                        break;
                }
            }


            return nodos;
        }

    }
}


