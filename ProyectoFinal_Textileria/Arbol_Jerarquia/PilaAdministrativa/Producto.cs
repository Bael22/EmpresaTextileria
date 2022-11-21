using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Textileria.PilaAdministrativa
{
    internal class Producto
    {
        public string codigo;
        public string producto;
        public int cantidad;
        public double precio;
        //public string hora;

        public Producto(string codigo, string producto, int cantidad, double precio)//, string hora)
        {
            this.codigo = codigo;
            this.producto = producto;
            this.cantidad = cantidad;
            this.precio = precio;
            //this.hora = hora;
        }
    }
}
