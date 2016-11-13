using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EntidadesAbstractas;
using Archivos;
using System.Xml.Serialization;
using System.Xml;

namespace EntidadesInstanciables
{
    [Serializable]
    
    public class Jornada
    {
        List<Alumno> _alumnos;
        Gimnasio.EClases _clase;
        Instructor _instructor;

        public List<Alumno> Alumnos { get { return this._alumnos; } set { this._alumnos = value; } }
        public Gimnasio.EClases Clase { get { return this._clase; } set { this._clase = value; } }
        public Instructor Instructor { get { return this._instructor; } set { this._instructor = value; } }

        #region Constructores

        Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
 
        }

        #endregion

        #region Sobrecargas

        public static bool operator ==(Jornada j, Alumno a)
        {
            if (a == j._clase)
                return true;
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                {
                    Console.WriteLine("El alumno ya se encuentra cargado en la jornada");
                    return j;
                }
            }
            j._alumnos.Add(a);
            return j;
        }

        public override string ToString()
        {
            StringBuilder c = new StringBuilder();
            c.AppendLine("----JORNADA----");
            c.Append("CLASES DE ");
            c.AppendLine(this._clase.ToString());
            c.Append("POR ");
            c.AppendLine(this._instructor.ToString());
            foreach (Alumno item in this._alumnos)
            {
                c.AppendLine(item.ToString());
            }
            return c.ToString();
        }
#endregion

        #region Metodos
        public static bool Guardar(Jornada j)
        {
           return new Texto().Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +@"\Jornada.txt",j.ToString());
 
        }

        public static bool Leer(string archivo, out string datos)
        {

           return new Texto().Leer(archivo, out datos);
          
        }


        #endregion
    }
}
