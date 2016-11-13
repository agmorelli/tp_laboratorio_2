using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using EntidadesAbstractas;
using System.Xml.Serialization;
using System.Xml;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Persona))]
    [XmlInclude(typeof(PersonaGimnasio))]
   public class Gimnasio
    {
        List<Alumno> _alumnos;
        List<Instructor> _instuctores;
        List<Jornada> _jornada;

        public enum EClases
        {
            CrossFit,
            Natacion,
            Pilates,
            Yoga
        }

        public List<Alumno> Alumnos { get { return this._alumnos; } set { this._alumnos = value; } }
        public List<Instructor> Instructores { get { return this._instuctores; } set { this._instuctores = value; } }
        public List<Jornada> Jornada { get { return this._jornada; } set { this._jornada = value; } }

        #region constructores
        
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instuctores = new List<Instructor>();
            this._jornada=new List<Jornada>();
        }
#endregion

        #region Indexadores
        public Jornada this[int index]
        {
            get {
                if (index > this._jornada.Count || index < 0)
                    return null;
                else
                return this._jornada[index]; 
            }
        }


        #endregion

        #region Sobrecargas

        public static bool operator ==(Gimnasio g, Alumno a)
        {
            foreach (Alumno item in g._alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Gimnasio g, Instructor i)
        {
            foreach (Instructor item in g._instuctores)
            {
                if (item == i)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            foreach (Instructor item in g._instuctores)
            {
                if (item == clase)
                    return item;
            }
            throw new SinInstructorException();
        }

        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            foreach (Instructor item in g._instuctores)
            {
                if (item != clase)
                    return item;    
            }
            throw new SinInstructorException();////////////////// preguntar que debe devolver en caso de que no haya instructor que no pueda dar esa clase
        }

        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            Jornada j= new Jornada(clase, g == clase);
            foreach (Alumno item in g._alumnos)
            {
                if (item == clase)
                    j += item;
            }
            g._jornada.Add(j);

            return g;
        }

        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (g == a)
                throw new AlumnoRepetidoException();
            else
            g._alumnos.Add(a);
            return g;
        }

        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g == i)
            {
                Console.WriteLine("El instructor ya esta dando clases en el gimnasio.");
                return g;
            }
            else
                g._instuctores.Add(i);
            return g;
 
        }

        public override string ToString()
        {
            return Gimnasio.Mostrar(this);
        }

        #endregion

        #region Metodos

        static string Mostrar(Gimnasio gim)
        {
            StringBuilder c = new StringBuilder();
            c.AppendLine("Lista de Alumnos:");
            foreach (Alumno item in gim._alumnos)
            {
                c.AppendLine(item.ToString());
            }

            c.AppendLine("Lista de instructores:");
            foreach (Instructor item in gim._instuctores)
            {
                c.AppendLine(item.ToString());
            }

            c.AppendLine("Lista de Jornadas:");
            foreach (Jornada item in gim._jornada)
            {
                c.AppendLine(item.ToString());

                c.AppendLine("<---------------------------------------------------------->");
            }
            return c.ToString();

        }

       public static bool Guardar(Gimnasio gim)
   {
       return new Xml<Gimnasio>().Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gimnasio.xml", gim);
   }

       public static Gimnasio Leer(string archivo)
       {
           Gimnasio aux;
           new Xml<Gimnasio>().Leer(archivo, out aux);

           return aux;

       }

        #endregion
    }
}
