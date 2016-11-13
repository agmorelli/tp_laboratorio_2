using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        string _msjBase;

        public DniInvalidoException():base() { }

        public DniInvalidoException(Exception e):base(){}

        public DniInvalidoException(string msj)
            : base()
        {
            this._msjBase = msj;
        }

        public DniInvalidoException(string msj, Exception e):base()
        {}

    }
}
