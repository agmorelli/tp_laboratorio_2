using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;


namespace EntidadesAbstractas
{

    public abstract class PersonaGimnasio:Persona
    {
        int _identificador;

        public PersonaGimnasio() : base() { }

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }

        public int Identificador 
        { 
            get{return this._identificador;}
            set
            {
                this._identificador = value;
            }
        }

        #region Metodos
        protected virtual string MostrarDatos()
            {
                StringBuilder c = new StringBuilder();
                c.AppendLine(base.ToString());
                c.Append("CARNET NUMERO: ");
                c.AppendLine(this._identificador.ToString());
                return c.ToString();
            }

        protected abstract string ParticiparEnClase();
        #endregion

        #region Sobrecargas

        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (pg1.GetType() == pg2.GetType() && pg1.DNI == pg2.DNI)
                return true;
            return false;
        }

        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        public override bool Equals(object obj)
        {
            return this == (PersonaGimnasio)obj;
        }


        #endregion



    }
}
