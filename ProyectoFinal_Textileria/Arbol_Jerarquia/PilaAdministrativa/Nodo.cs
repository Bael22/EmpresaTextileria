using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto_Textileria.PilaAdministrativa
{ 
    internal class Nodo
    {
        private Producto dato;
        private Nodo siguiente;

       

        public Producto Dato { get => dato; set => dato = value; }
        internal Nodo Siguiente { get => siguiente; set => siguiente = value; }
        
        
    }
}
