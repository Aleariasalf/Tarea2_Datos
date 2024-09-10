using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_Datos
{
    internal class Nodo
    {
        public int Valor { get; set; }

        public Nodo Siguiente { get; set; }

        public Nodo Anterior { get; set; }

        public Nodo(int value) 
        {
            this.Valor = value;
            this.Siguiente = null;
            this.Anterior = null;
            
        }
    }
}
