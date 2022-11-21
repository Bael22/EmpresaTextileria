using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Textileria.Bicola_AtencionCliente
{
    internal class Nodo
    {
        public int dato;
        public Cliente cliente;
        public Nodo siguiente;
        public Nodo anterior;
        public Nodo(int dat, Nodo ant, Nodo sig)
        {
            dato = dat;
            siguiente = sig;
            anterior = ant;
        }
    }
}
