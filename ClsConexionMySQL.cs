using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Pro.BaseDatos
{
    class ClsConexionMySQL
    {
        public MySqlConnection conexion;
        private String _conexion { get; }

        public ClsConexionMySQL()
        {

            _conexion = "Server=localhost; DataBase=tb_música; UID=root; Password = Umg$2019";

        }



        /// <summary>
        /// Cierra la conexion.
        /// </summary>
        public void cerrarConexionBD()
        {
            conexion.Close();
        }



        /// <summary>
        /// abre la conexion
        /// </summary>
        public void abrirConexion()
        {
            conexion = new MySqlConnection(_conexion);
            conexion.Open();
        }




        /// <summary>
        /// metodo que ejecuta una consulta, esta clase maneja la apertura y clausura a la base de datos
        /// </summary>
        /// <param name="sqll"></param>
        /// <returns></returns>
        public DataTable consultaTablaDirecta(String sqll)
        {
            abrirConexion();
            MySqlDataReader dr;
            MySqlCommand comm = new MySqlCommand(sqll, conexion);
            dr = comm.ExecuteReader();

            var dataTable = new DataTable();
            dataTable.Load(dr);
            cerrarConexionBD();
            return dataTable;
        }


        public DataTable consultaTablaDirecta1(String sqll)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Data Source=DESKTOP-3MTD07G\\SQLEXPRESS;Initial Catalog=dbprogra1a;Integrated Security=True");
                conn.Open();
                string query = "select * from tb_música";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                DataTable t1 = new DataTable();
                using (MySqlDataAdapter a = new MySqlDataAdapter(cmd))
                {
                    a.Fill(t1);
                }
                return t1;
            }
            catch (Exception ex)
            {
                var str = ex.Message;
                throw;
            }

        }


        /// <summary>
        /// ejecuta una instrucción de insersion, eliminación y actualización,
        /// esta clase se encarga de manejar las aperturas y clausuras de la conexion.
        /// </summary>
        /// <param name="sqll"></param>
        public void EjecutaMySQLDirecto(String sqll)
        {
            abrirConexion();
            try
            {

                MySqlCommand comm = new MySqlCommand(sqll, conexion);
                comm.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                cerrarConexionBD();
            }



        }




        /// <summary>
        /// ejecuta instrucciones SQL, pero el progromador debe manejar la apertura y clausura
        /// de las conexiones.
        /// </summary>
        /// <param name="sqll"></param>
        public void EjecutaMySQLManual(String sqll)
        {
            // se abre y cierra la conexino manualmente
            MySqlCommand comm = new MySqlCommand(sqll, conexion);
            comm.ExecuteReader();
        }

    }
    }
   
