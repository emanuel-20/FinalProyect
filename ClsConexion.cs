using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.BaseDatos
{
    class ClsConexion
    {
        public SqlConnection conexion;
        private String _conexion { get; }

        public ClsConexion()
        {

            _conexion = "Data Source=DESKTOP-3MTD07G\\SQLEXPRESS;Initial Catalog=dbprogra1a;Integrated Security=True";

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
            conexion = new SqlConnection(_conexion);
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
            SqlDataReader dr;
            SqlCommand comm = new SqlCommand(sqll, conexion);
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
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-3MTD07G\\SQLEXPRESS;Initial Catalog=dbprogra1a;Integrated Security=True");
                conn.Open();
                string query = "select * from tb_música";

                SqlCommand cmd = new SqlCommand(query, conn);

                DataTable t1 = new DataTable();
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
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
        public void EjecutaSQLDirecto(String sqll)
        {
            abrirConexion();
            try
            {

                SqlCommand comm = new SqlCommand(sqll, conexion);
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
        public void EjecutaSQLManual(String sqll)
        {
            // se abre y cierra la conexino manualmente
            SqlCommand comm = new SqlCommand(sqll, conexion);
            comm.ExecuteReader();
        }
    }//end class
}
