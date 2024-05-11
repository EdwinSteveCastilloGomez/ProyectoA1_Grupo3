using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAcces;

namespace InterfazForms1
{
    public partial class FormPrincipal : Form
    {

        private DatabaseManager databaseManager;
        private List<Nodo> nodos;
        private List<Departamento> departamentosVisitados;
        public FormPrincipal()
        {
            InitializeComponent();
            databaseManager = new DatabaseManager();           
            nodos = databaseManager.CrearNodosDesdeBaseDeDatos();

            foreach (Nodo nodo in nodos)
            {
                cmbx_Departamento1.Items.Add(nodo.Informacion.Nombre);
                cmbx_departamento2.Items.Add(nodo.Informacion.Nombre);

            }

            cmbx_Departamento1.SelectedIndexChanged += cmbx_Departamento_SelectedIndexChanged;
            cmbx_departamento2.SelectedIndexChanged += cmbx_Departamento_SelectedIndexChanged;


        }

        private void btn1_Click(object sender, EventArgs e)
        {
              
            if (cmbx_Departamento1.SelectedItem == null)
            {
                MessageBox.Show("escoja el departamento#1");
            }else if (cmbx_departamento2.SelectedItem != null)
            {
                MessageBox.Show("esta funcion solo requiere departamento#1");
            }
            else
            {
                string nombreDepartamentoSeleccionado = cmbx_Departamento1.SelectedItem.ToString();
                Nodo nodoDepartamento = EncontrarNodoPorDepartamento(nombreDepartamentoSeleccionado);
                // Si se encontró el nodo correspondiente al departamento

                if (nodoDepartamento != null)
                {
                    textb_Distanciadepartamento.Text = nodoDepartamento.Informacion.DistanciaDesdeCapital.ToString();

                    DataTable dataTableDepartamento = new DataTable();
                    dataTableDepartamento.Columns.Add("Nombre");
                    dataTableDepartamento.Columns.Add("Cabecera");
                    dataTableDepartamento.Columns.Add("DistanciaDesdeCapital");
                    dataTableDepartamento.Columns.Add("Poblacion");
                    dataTableDepartamento.Columns.Add("NumeroDeMunicipios");

                    // Agrega una fila al DataTable con la información del departamento
                    DataRow row = dataTableDepartamento.NewRow();
                    row["Nombre"] = nodoDepartamento.Informacion.Nombre;
                    row["Cabecera"] = nodoDepartamento.Informacion.Cabecera;
                    row["DistanciaDesdeCapital"] = nodoDepartamento.Informacion.DistanciaDesdeCapital;
                    row["Poblacion"] = nodoDepartamento.Informacion.Poblacion;
                    row["NumeroDeMunicipios"] = nodoDepartamento.Informacion.NumerodeMunicipios;
                    dataTableDepartamento.Rows.Add(row);

                    // Asigna el DataTable al DataGridView
                    dtgv1.DataSource = dataTableDepartamento;
                }
                else
                {
                    textb_Distanciadepartamento.Text = "Departamento no encontrado";
                    MessageBox.Show("Departamento no encontrado");
                }
            }
                  
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (cmbx_Departamento1.SelectedItem == null && cmbx_departamento2.SelectedItem == null)
            {
                MessageBox.Show("seleccione los 2 departamentos");

            }else if (cmbx_Departamento1.SelectedItem == null || cmbx_departamento2.SelectedItem == null)
            {
                MessageBox.Show("seleccione los 2 departamentos");

            }else
            {
                string nombreDepartamento1 = cmbx_Departamento1.SelectedItem.ToString();
                string nombreDepartamento2 = cmbx_departamento2.SelectedItem.ToString();
                // Encuentra los nodos correspondientes a los departamentos seleccionados
                Nodo nodoDepartamento1 = EncontrarNodoPorDepartamento(nombreDepartamento1);
                Nodo nodoDepartamento2 = EncontrarNodoPorDepartamento(nombreDepartamento2);

                // Si se encontraron los nodos correspondientes a ambos departamentos
                if (nodoDepartamento1 != null && nodoDepartamento2 != null)
                {
                    // Calcula la distancia entre los departamentos utilizando la información de distancia desde la capital
                    decimal distancia = Math.Abs(nodoDepartamento1.Informacion.DistanciaDesdeCapital - nodoDepartamento2.Informacion.DistanciaDesdeCapital);

                    // Muestra la distancia entre los departamentos en una TextBox
                    txtb_distentredepartamentos.Text = distancia.ToString();
                }
                else
                {
                    // Si no se encontró alguno de los departamentos, muestra un mensaje de error
                    txtb_distentredepartamentos.Text = "Uno o ambos departamentos no encontrados";
                }
            }
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            List<Departamento> top10Departamentos = new List<Departamento>();

            // Inicializa una cola para el recorrido en anchura (BFS)
            Queue<Nodo> cola = new Queue<Nodo>();
            HashSet<Nodo> visitados = new HashSet<Nodo>();
            cola.Enqueue(databaseManager.NodoOrigen);

            while (cola.Count > 0)
            {
                Nodo nodoActual = cola.Dequeue();
                visitados.Add(nodoActual);

                // Agrega el departamento correspondiente al nodo actual a la lista de top10Departamentos
                top10Departamentos.Add(nodoActual.Informacion);

                // Si la lista supera los 10 elementos, ordena y selecciona los primeros 10 departamentos con la distancia más grande
                if (top10Departamentos.Count > 10)
                {
                    top10Departamentos = top10Departamentos.OrderByDescending(d => d.DistanciaDesdeCapital).Take(10).ToList();
                }

                // Agrega los nodos adyacentes no visitados a la cola
                if (nodoActual.LigaNorte != null && !visitados.Contains(nodoActual.LigaNorte))
                {
                    cola.Enqueue(nodoActual.LigaNorte);
                }
                if (nodoActual.LigaSur != null && !visitados.Contains(nodoActual.LigaSur))
                {
                    cola.Enqueue(nodoActual.LigaSur);
                }
                if (nodoActual.LigaEste != null && !visitados.Contains(nodoActual.LigaEste))
                {
                    cola.Enqueue(nodoActual.LigaEste);
                }
                if (nodoActual.LigaOeste != null && !visitados.Contains(nodoActual.LigaOeste))
                {
                    cola.Enqueue(nodoActual.LigaOeste);
                }
            }

            // Muestra los 10 departamentos con la distancia desde la capital más grande en el DataGridView
            MostrarTop10DepartamentosEnDataGridView(top10Departamentos);
        }
        private void btn4_Click(object sender, EventArgs e)
        {

            if (cmbx_Departamento1.SelectedItem == null)
            {
                MessageBox.Show("escoja el departamento#1");
            }
            else if (cmbx_departamento2.SelectedItem != null)
            {
                MessageBox.Show("esta funcion solo requiere departamento#1");
            }
            else
            {
                departamentosVisitados = new List<Departamento>();

                // Obtiene el nombre del departamento seleccionado en el ComboBox
                string nombreDepartamentoObjetivo = cmbx_Departamento1.SelectedItem.ToString();

                // Encuentra el nodo correspondiente al departamento objetivo
                Nodo nodoDepartamentoObjetivo = EncontrarNodoPorDepartamento(nombreDepartamentoObjetivo);

                // Si se encontró el nodo correspondiente al departamento objetivo
                if (nodoDepartamentoObjetivo != null)
                {
                    // Realiza un recorrido en profundidad (DFS) desde NodoOrigen hasta el departamento objetivo
                    DFS_ListarDepartamentosVisitados(databaseManager.NodoOrigen, nodoDepartamentoObjetivo);

                    // Muestra los departamentos visitados en el DataGridView
                    MostrarDepartamentosVisitadosEnDataGridView(departamentosVisitados);
                }
                else
                {
                    // Si no se encontró el departamento objetivo, muestra un mensaje de error
                    MessageBox.Show("Departamento objetivo no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                           
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            List<Departamento> top10Departamentos = new List<Departamento>();

            // Inicializa una cola para el recorrido en anchura (BFS)
            Queue<Nodo> cola = new Queue<Nodo>();
            HashSet<Nodo> visitados = new HashSet<Nodo>();
            cola.Enqueue(databaseManager.NodoOrigen);

            while (cola.Count > 0)
            {
                Nodo nodoActual = cola.Dequeue();
                visitados.Add(nodoActual);

                // Agrega el departamento correspondiente al nodo actual a la lista de top10Departamentos
                top10Departamentos.Add(nodoActual.Informacion);

                // Si la lista supera los 10 elementos, ordena y selecciona los primeros 10 departamentos con la distancia más pequeña
                if (top10Departamentos.Count > 10)
                {
                    top10Departamentos = top10Departamentos.OrderBy(d => d.DistanciaDesdeCapital).Take(10).ToList();
                }

                // Agrega los nodos adyacentes no visitados a la cola
                if (nodoActual.LigaNorte != null && !visitados.Contains(nodoActual.LigaNorte))
                {
                    cola.Enqueue(nodoActual.LigaNorte);
                }
                if (nodoActual.LigaSur != null && !visitados.Contains(nodoActual.LigaSur))
                {
                    cola.Enqueue(nodoActual.LigaSur);
                }
                if (nodoActual.LigaEste != null && !visitados.Contains(nodoActual.LigaEste))
                {
                    cola.Enqueue(nodoActual.LigaEste);
                }
                if (nodoActual.LigaOeste != null && !visitados.Contains(nodoActual.LigaOeste))
                {
                    cola.Enqueue(nodoActual.LigaOeste);
                }
            }

            // Muestra los 10 departamentos con la distancia desde la capital más pequeña en el DataGridView
            MostrarTop10DepartamentosEnDataGridView(top10Departamentos);

        }

        private void cmbx_Departamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //Metodos de las funciones-------------------------------------------

        private Nodo EncontrarNodoPorDepartamento(string nombreDepartamento)
        {
            // Inicia el recorrido en profundidad (DFS) desde el NodoOrigen
            Stack<Nodo> stack = new Stack<Nodo>();
            HashSet<Nodo> visitados = new HashSet<Nodo>();
            stack.Push(databaseManager.NodoOrigen);

            while (stack.Count > 0)
            {
                Nodo nodoActual = stack.Pop();
                visitados.Add(nodoActual);

                // Si el nodo actual corresponde al departamento buscado, devuelve este nodo
                if (nodoActual.Informacion.Nombre == nombreDepartamento)
                {
                    return nodoActual;
                }

                // Agrega los nodos adyacentes no visitados a la pila
                if (nodoActual.LigaNorte != null && !visitados.Contains(nodoActual.LigaNorte))
                {
                    stack.Push(nodoActual.LigaNorte);
                }
                if (nodoActual.LigaSur != null && !visitados.Contains(nodoActual.LigaSur))
                {
                    stack.Push(nodoActual.LigaSur);
                }
                if (nodoActual.LigaEste != null && !visitados.Contains(nodoActual.LigaEste))
                {
                    stack.Push(nodoActual.LigaEste);
                }
                if (nodoActual.LigaOeste != null && !visitados.Contains(nodoActual.LigaOeste))
                {
                    stack.Push(nodoActual.LigaOeste);
                }
            }

            // Si no se encontró el departamento, devuelve null
            return null;
        }

        //enlistar el top 10 de los departamentos buscados segun el criterio de distancia
        private void MostrarTop10DepartamentosEnDataGridView(List<Departamento> top10Departamentos)
        {
            // Crea un DataTable para almacenar la información de los departamentos
            DataTable dataTableTop10 = new DataTable();
            dataTableTop10.Columns.Add("Nombre");
            dataTableTop10.Columns.Add("Cabecera");
            dataTableTop10.Columns.Add("DistanciaDesdeCapital");
            dataTableTop10.Columns.Add("Poblacion");
            dataTableTop10.Columns.Add("NumeroDeMunicipios");

            // Agrega las filas al DataTable con la información de los departamentos
            foreach (Departamento departamento in top10Departamentos)
            {
                DataRow row = dataTableTop10.NewRow();
                row["Nombre"] = departamento.Nombre;
                row["Cabecera"] = departamento.Cabecera;
                row["DistanciaDesdeCapital"] = departamento.DistanciaDesdeCapital;
                row["Poblacion"] = departamento.Poblacion;
                row["NumeroDeMunicipios"] = departamento.NumerodeMunicipios;
                dataTableTop10.Rows.Add(row);
            }

            // Asigna el DataTable al DataGridView
            dtgv1.DataSource = dataTableTop10;
        }

        //Ensita los departamentos visitados para llegar al destino.
        private void DFS_ListarDepartamentosVisitados(Nodo nodoActual, Nodo nodoObjetivo)
        {
            // Inicializa una pila para el recorrido en profundidad (DFS)
            Stack<Nodo> stack = new Stack<Nodo>();
            HashSet<Nodo> visitados = new HashSet<Nodo>();
            Dictionary<Nodo, Nodo> previos = new Dictionary<Nodo, Nodo>();

            stack.Push(nodoActual);

            while (stack.Count > 0)
            {
                Nodo nodo = stack.Pop();
                visitados.Add(nodo);

                // Si se encuentra el nodo objetivo, reconstruye el camino desde el NodoOrigen hasta el nodo objetivo
                if (nodo == nodoObjetivo)
                {
                    ReconstructPath(previos, nodoObjetivo);
                    return;
                }

                // Agrega los nodos adyacentes no visitados a la pila
                if (nodo.LigaNorte != null && !visitados.Contains(nodo.LigaNorte))
                {
                    stack.Push(nodo.LigaNorte);
                    previos[nodo.LigaNorte] = nodo;
                }
                if (nodo.LigaSur != null && !visitados.Contains(nodo.LigaSur))
                {
                    stack.Push(nodo.LigaSur);
                    previos[nodo.LigaSur] = nodo;
                }
                if (nodo.LigaEste != null && !visitados.Contains(nodo.LigaEste))
                {
                    stack.Push(nodo.LigaEste);
                    previos[nodo.LigaEste] = nodo;
                }
                if (nodo.LigaOeste != null && !visitados.Contains(nodo.LigaOeste))
                {
                    stack.Push(nodo.LigaOeste);
                    previos[nodo.LigaOeste] = nodo;
                }
            }
        }

        private void ReconstructPath(Dictionary<Nodo, Nodo> previos, Nodo nodoObjetivo)
        {
            Nodo nodoActual = nodoObjetivo;
            while (previos.ContainsKey(nodoActual))
            {
                departamentosVisitados.Add(nodoActual.Informacion);
                nodoActual = previos[nodoActual];
            }
            departamentosVisitados.Reverse(); // Invierte la lista para que los departamentos visitados estén en el orden correcto
        }

        private void MostrarDepartamentosVisitadosEnDataGridView(List<Departamento> departamentosVisitados)
        {
            // Crea un DataTable para almacenar la información de los departamentos visitados
            DataTable dataTableDepartamentosVisitados = new DataTable();
            dataTableDepartamentosVisitados.Columns.Add("Nombre");
            dataTableDepartamentosVisitados.Columns.Add("Cabecera");
            dataTableDepartamentosVisitados.Columns.Add("DistanciaDesdeCapital");
            dataTableDepartamentosVisitados.Columns.Add("Poblacion");
            dataTableDepartamentosVisitados.Columns.Add("NumeroDeMunicipios");

            // Agrega las filas al DataTable con la información de los departamentos visitados
            foreach (Departamento departamento in departamentosVisitados)
            {
                DataRow row = dataTableDepartamentosVisitados.NewRow();
                row["Nombre"] = departamento.Nombre;
                row["Cabecera"] = departamento.Cabecera;
                row["DistanciaDesdeCapital"] = departamento.DistanciaDesdeCapital;
                row["Poblacion"] = departamento.Poblacion;
                row["NumeroDeMunicipios"] = departamento.NumerodeMunicipios;
                dataTableDepartamentosVisitados.Rows.Add(row);
            }

            // Asigna el DataTable al DataGridView
            dtgv1.DataSource = dataTableDepartamentosVisitados;
        }
    }
}
    