using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using System.Xml.Serialization;
using System.Xml;

namespace EntidadesInstanciables
{
   
    
   public sealed class Instructor:PersonaGimnasio
    {
       
        Queue<Gimnasio.EClases> _clasesDelDia;
        static Random _random;

       

        //public Queue<Gimnasio.EClases> ClasesDelDia
        //{
        //    get { return this._clasesDelDia; }
        //    set { this._clasesDelDia = value; }
        //}
        public Random Random { get { return _random; } set { _random = value; } }
        

        #region Constructor
       static Instructor()    
       {
           _random=new Random();
           
 
       }
       public Instructor() : base() { }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
            this._randomClases();
        }
        #endregion

        #region Metodos

        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder c = new StringBuilder();
            c.AppendLine("CLASES DEL DIA:");
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                c.AppendLine(item.ToString());
            }
            return c.ToString();
        }

        void _randomClases()///////////////REVISAR ENTRA A MAS DE UN IF///////////////
        {
            if (_random.Next(4) == 0)
                this._clasesDelDia.Enqueue(Gimnasio.EClases.CrossFit);
            if (_random.Next(4) == 1)
                this._clasesDelDia.Enqueue(Gimnasio.EClases.Natacion);
            if (_random.Next(4) == 2)
                this._clasesDelDia.Enqueue(Gimnasio.EClases.Pilates);
            if (_random.Next(4) == 3)
                this._clasesDelDia.Enqueue(Gimnasio.EClases.Yoga);
        }

        #endregion

        #region Sobrecargas

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            foreach (Gimnasio.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
       {
           return !(i==clase);
       }
        #endregion


    }
}
