using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Archivo
{
    class ClsArchivo
    {
        public string[] LeerArchivo(string archivo)
        {
            String[] lineas = File.ReadAllLines(archivo);
            return lineas;
        }

        public string LeerTodoArchivo(string archivo)
        {
            string ContenidoArchivo;
            using (StreamReader reader = new StreamReader(archivo))
            {
                ContenidoArchivo = reader.ReadToEnd();
            }
            return ContenidoArchivo;
        }


        //puede tambien contener arreglo
        //sobre escribe el archivo si ya tiene informacion
        public void grabarArchivoNuevo(String archivo, String contenido)
        {
            File.WriteAllText(archivo, contenido);
        }

        public void agreagarDatosArchivo(String archivo, String Contenido)
        {
            using (StreamWriter sw = File.AppendText(archivo))
            {
                sw.WriteLine(Contenido);

            }
        }
    }//end class
}
