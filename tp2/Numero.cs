using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Numero
    {
        double _numero;

        public Numero():this(0)
        {
            
        }

       public Numero(double numero)
        {
            this._numero = numero;
        }

        public Numero(string cadena)
        {
            SetNumero(cadena);
        }

        static double ValidarNumero(string numero)
        {
            double res;
            if (double.TryParse(numero, out res))
                return res;
            else return 0;
        }

        public void SetNumero(string cadena)
        {
            this._numero = Numero.ValidarNumero(cadena);
        }

        public double GetNumero()
        {
            return this._numero;
        }

    }
}
