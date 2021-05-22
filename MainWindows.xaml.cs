using Pro.Archivo;
using Pro.BaseDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Pro
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Pro.dbprogra1aDataSet dbprogra1aDataSet = ((Pro.dbprogra1aDataSet)(this.FindResource("dbprogra1aDataSet")));
            // Cargar datos en la tabla tb_música. Puede modificar este código según sea necesario.
            Pro.dbprogra1aDataSetTableAdapters.tb_músicaTableAdapter dbprogra1aDataSettb_músicaTableAdapter = new Pro.dbprogra1aDataSetTableAdapters.tb_músicaTableAdapter();
            dbprogra1aDataSettb_músicaTableAdapter.Fill(dbprogra1aDataSet.tb_música);
            System.Windows.Data.CollectionViewSource tb_músicaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tb_músicaViewSource")));
            tb_músicaViewSource.View.MoveCurrentToFirst();
            ClsConexion cnx = new ClsConexion();
            ClsConexionMySQL msql = new ClsConexionMySQL();
            DataTable dt= cnx.consultaTablaDirecta1("select * from tb_música");
            dt = new DataTable();
            
        } 

        private void cargarArchivoExterno()
        {
            string fuente = @"C:\Users\User\Documents\crudPF.csv";
            ClsArchivo ar = new ClsArchivo();
            ClsConexion cn = new ClsConexion();

            //obtener todo el archivo en un arreglo
            string[] ArregloCD = ar.LeerArchivo(fuente);
            string sentencia_sql = "";
            int NumeroLinea = 0;

            //iteramos sobre el arreglo linea por linea
            //para luego convertirlo en datos individuales
            foreach(string linea in ArregloCD)
            {
                string[] datos = linea.Split(';');
                if (NumeroLinea > 0)
                {
                    sentencia_sql = "";
                    sentencia_sql = $"insert into tb_música values({datos[0]}, '{datos[1]}', '{datos[2]}', {datos[3]}, '{datos[4]}', {datos[5]})";
                    cn.EjecutaSQLDirecto(sentencia_sql);
                }
                NumeroLinea++;
            }//end foreach
            NumeroLinea = 0;
            
        }

private void ButtonBase(object sender, RoutedEventArgs e)
        {
            cargarArchivoExterno();
        }

        public DataTable cargarDatosDB(String condicion = "1=1")
        {
            ClsConexion cn = new ClsConexion();
            DataTable dt = new DataTable();
            string sentencia = $"select * from tb_música where {condicion}";
            dt = cn.consultaTablaDirecta(sentencia);
            return dt;
        }

        private void ButtonID(object sender, RoutedEventArgs e)
        {
            string id = txtTodo.Text.Trim();
            string condicion = $"ID = {id}";
            DataTable dt = cargarDatosDB(condicion); 
            
           
            if (dt.Rows.Count > 0)
            {
                string nombre = dt.Rows[0].Field<String>("nombre");
                txtResultados.Text = nombre;
            }
            else
            {
                txtResultados.Text = "Desafortunadamente no contamos con esa información :(.";
            }
        }

        private void ButtonNombre(object sender, RoutedEventArgs e)
        {
            string nombre = txtTodo.Text.Trim();
            nombre = nombre.Replace(' ', '%');

            string condicion = $" Nombre like ('%{nombre}%')";
            DataTable dt = cargarDatosDB(condicion);

            if (dt.Rows.Count > 0)
            {
                int id = dt.Rows[0].Field<Int32>("ID");
                txtResultados.Text = id+"";
            }
            else
            {
                txtResultados.Text = "Desafortunadamente no contamos con esa información :(.";
            }
        }

        private void ButtonBuscarTodo(object sender, RoutedEventArgs e)
        {
            cargarDatosDB();

        }

        private void ButtonAlbum(object sender, RoutedEventArgs e)
        {
            string album = txtTodo.Text.Trim();
            album = album.Replace(' ', '%');

            string condicion = $" Album like ('%{album}%')";
            DataTable dt = cargarDatosDB(condicion);

            if (dt.Rows.Count > 0)
            {
                string nombre = dt.Rows[0].Field<String>("Nombre");
                txtResultados.Text = nombre + "";
            }
            else
            {
                txtResultados.Text = "Desafortunadamente no contamos con esa información :(.";
            }
        }

        private void ButtonPrecio(object sender, RoutedEventArgs e)
        {
            string precio = txtTodo.Text.Trim();
            precio = precio.Replace(' ', '%');

            string condicion = $" Precio = ({precio})";
            DataTable dt = cargarDatosDB(condicion);

            if (dt.Rows.Count > 0)
            {
                string album = dt.Rows[0].Field<String>("Album");
                txtResultados.Text = album + "";
            }
            else
            {
                txtResultados.Text = "Desafortunadamente no contamos con esa información :(.";
            }
        }

        private void ButtonFecha(object sender, RoutedEventArgs e)
        {
            string fecha = txtTodo.Text.Trim();
            fecha = fecha.Replace(' ', '%');

            string condicion = $" fecha = ('{fecha}')";
            DataTable dt = cargarDatosDB(condicion);

            if (dt.Rows.Count > 0)
            {
                string album = dt.Rows[0].Field<String>("Album");
                txtResultados.Text = album + "";
            }
            else
            {
                txtResultados.Text = "Desafortunadamente no contamos con esa información :(.";
            }
        }

        private void ButtonCantidad(object sender, RoutedEventArgs e)
        {
            string cantidad = txtTodo.Text.Trim();
            cantidad = cantidad.Replace(' ', '%');

            string condicion = $" cantidad = ({cantidad})";
            DataTable dt = cargarDatosDB(condicion);

            if (dt.Rows.Count > 0)
            {
                string album = dt.Rows[0].Field<String>("Album");
                txtResultados.Text = album + "";
            }
            else
            {
                txtResultados.Text = "Desafortunadamente no contamos con esa información :(.";
            }
        }

        private void ButtonMySQL(object sender, RoutedEventArgs e)
        {
            string fuente = @"C:\Users\User\Documents\crudPF.csv";
            ClsArchivo ar = new ClsArchivo();
            ClsConexion cn = new ClsConexion();
            ClsConexionMySQL msql = new ClsConexionMySQL();

            //obtener todo el archivo en un arreglo
            string[] ArregloCD = ar.LeerArchivo(fuente);
            string sentencia_mysql = "";
            int NumeroLinea = 0;

            //iteramos sobre el arreglo linea por linea
            //para luego convertirlo en datos individuales
            foreach (string linea in ArregloCD)
            {
                string[] datos1 = linea.Split(';');
                if (NumeroLinea > 0)
                {
                    sentencia_mysql = "";
                    sentencia_mysql = $"insert into tb_música.música values({datos1[0]}, '{datos1[1]}', '{datos1[2]}', {datos1[3]}, '{datos1[4]}', {datos1[5]})";
                    msql.EjecutaMySQLDirecto(sentencia_mysql);
                }
                NumeroLinea++;
            }//end foreach
            NumeroLinea = 0;
        }
    }
}
