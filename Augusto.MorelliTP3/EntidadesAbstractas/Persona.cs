using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;
using System.Xml;

namespace EntidadesAbstractas
{
    
   
    public abstract class Persona
    {
        string _nombre;
        string _apellido;
        int _dni;
        ENacionalidad _nacionalidad;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Constructores

        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            StringToDni = dni;
        }
        #endregion

        #region Propiedades
        public string Nombre 
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }

        public int DNI 
        {
            get { return this._dni; }
            set
            {
                try
                {
                    this._dni = ValidarDni(this._nacionalidad, value);
                }
                catch (DniInvalidoException e)
                {
                    throw new NacionalidadInvalidaException(e.Message);

                }
            }
        }
       
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string StringToDni
        { 
            set 
            { 
                DNI = int.Parse(value); 
            } 
        }

        #endregion

        #region Metodos

        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato > 89999999 || dato < 1))
                throw new DniInvalidoException("La nacionalidad no coincide con el numero del DNI");
                if(nacionalidad==ENacionalidad.Extranjero&& (dato>999999999||dato<90000000))

                    throw new DniInvalidoException("La nacionalidad no coincide con el numero del DNI");
            else
 
            return dato; 
        }

        #endregion

        #region Sobrecargas

        public override string ToString()
        {
            StringBuilder c = new StringBuilder();
            c.Append("NOMBRE COMPLETO: ");
            c.Append(this._nombre + ", ");
            c.AppendLine(this._apellido);
            c.Append("DNI: ");
            c.AppendLine(this._dni.ToString());
            c.Append("NACIONALIDAD: ");
            c.AppendLine(this._nacionalidad.ToString());
            return c.ToString();
        }

        #endregion

    }
}
