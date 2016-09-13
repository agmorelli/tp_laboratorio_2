using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Calculadora
    {
        public static double Operar(Numero n1, Numero n2, string operador)
        {
            double resultado = 0;
            switch (operador)
            {
                case "+":
                    resultado= n1.GetNumero() + n2.GetNumero();
                    break;

                case "-":
                    resultado = n1.GetNumero() - n2.GetNumero();
                    break;

                case "*":
                    resultado = n1.GetNumero() * n2.GetNumero();
                    break;

                case "/":
                    resultado = n1.GetNumero() / n2.GetNumero();
                    break;
            }
            return resultado;
        }
    }
}
