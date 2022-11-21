using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Textileria.ColaSupervisionProductos
{
    internal class Cola
    {
        private Nodo primero;
        private Nodo ultimo;
        public Cola()
        {
            primero = null;
            ultimo = null;
        }
        public void insertarNodo(string producto)
        {
            Nodo nuevo = new Nodo();
            nuevo.Dato = producto;
            if (primero == null)
            {
                primero = nuevo;
                primero.Siguiente = null;
                ultimo = nuevo;
            }
            else
            {
                ultimo.Siguiente = nuevo;
                nuevo.Siguiente = null;
                ultimo = nuevo;
            }
        }
        public void verCola(Label productos)
        {
            Nodo actual = new Nodo();
            actual = primero;
            if (primero != null)
            {
                while (actual != null)
                {
                    productos.Text += actual.Dato + " - ";
                    actual = actual.Siguiente;
                }
            }
            /*else
            {
                MessageBox.Show("No se encontraron productos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }
        
        public void desencolarNodo()
        {
            if (primero != null)
            {
                primero = primero.Siguiente;
            }
            /*else
            {
                MessageBox.Show("No existen pedidos por revisar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }
        
    }
}
