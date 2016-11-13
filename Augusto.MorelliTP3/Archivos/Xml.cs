using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;


namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlTextWriter tw = new XmlTextWriter(archivo, Encoding.UTF8);
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(tw, datos);
                tw.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new ArchivosException(e);
                
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlTextReader rd = new XmlTextReader(archivo);
                XmlSerializer xs = new XmlSerializer(typeof(T));
                datos = (T)xs.Deserialize(rd);
               
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
