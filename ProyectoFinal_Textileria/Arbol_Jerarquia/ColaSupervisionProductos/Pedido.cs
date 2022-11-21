using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Textileria.ColaSupervisionProductos
{
    internal class Pedido
    {
        public string codigo;
        public string producto;
        public int cantidad;
        public int precio;

        public Pedido(string codigo, string producto, int cantidad, int precio)
        {
            this.codigo = codigo;
            this.producto = producto;
            this.cantidad = cantidad;
            this.precio = precio;
        }
    }
}
