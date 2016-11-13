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
    
    
    public sealed class Alumno:PersonaGimnasio
    {
        Gimnasio.EClases _claseQueToma;
        EEstadoCuenta _estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            MesPrueba
        }

        #region Constructores

        public Alumno():base() { }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        public Gimnasio.EClases ClaseQueToma
        {
            get { return this._claseQueToma; }
            set{this._claseQueToma=value;} }

        public EEstadoCuenta EstadoCuenta
        {
            get { return this._estadoCuenta; }
            set { this._estadoCuenta = value; }
    }
     
    

        #region Metodos

        protected override string MostrarDatos()
        {
            StringBuilder c = new StringBuilder();
            c.AppendLine(base.MostrarDatos());
            c.Append("Estado De cuenta: ");
            c.AppendLine(this._estadoCuenta.ToString());
            c.AppendLine(this.ParticiparEnClase());
            return c.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE: " + this._claseQueToma.ToString();
        }

        #endregion

        #region Sobrecargas

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Gimnasio.EClases e)
        {
            if (a._claseQueToma == e && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }

        public static bool operator !=(Alumno a, Gimnasio.EClases e)
        {
            if (a._claseQueToma != e)
                return true;
            return false;
        }

        #endregion
    }
}
