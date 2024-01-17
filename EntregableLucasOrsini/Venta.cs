using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregableLucasOrsini
{
    internal class Venta
    {
        private int _id;
        private string _comentarios;
        private int _idUsuario;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Comnetarios
        {
            get
            {
                return _comentarios;
            }
            set
            {
                _comentarios = value;
            }
        }

        public int IdUsuario
        {
            get
            {
                return _idUsuario;
            }
            set
            {
                _idUsuario = value;
            }
        }
    }
}
