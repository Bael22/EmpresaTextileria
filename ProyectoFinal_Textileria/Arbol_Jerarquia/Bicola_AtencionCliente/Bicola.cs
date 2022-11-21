using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Textileria.Bicola_AtencionCliente
{
    internal class Bicola
    {
        public Nodo primero, ultimo;

        public Bicola()
        {
            primero = ultimo = null;
        }
        public void insertarDerecha(int dato, Cliente cliente)
        {
            Nodo nuevo = new Nodo(dato, primero, ultimo);
            nuevo.dato = dato;
            nuevo.cliente = cliente;
            if (primero == null)
            {
                primero = nuevo;
                primero.anterior = primero.siguiente = null;
                ultimo = primero;
            }
            else
            {
                ultimo.siguiente = nuevo;
                nuevo.siguiente = null;
                nuevo.anterior = ultimo;
                ultimo = nuevo;
            }
        }
        public void insertarIzquierda(int dato, Cliente cliente)
        {
            Nodo nuevo = new Nodo(dato, primero, ultimo);
            nuevo.dato = dato;
            nuevo.cliente = cliente;
            if (primero == null)
            {
                primero = nuevo;
                primero.anterior = primero.siguiente = null;
                ultimo = primero;
            }
            else
            {
                primero.anterior = nuevo;
                nuevo.siguiente = primero;
                nuevo.anterior = null;
                primero = nuevo;
            }
        }


        public void verDatos(TextBox bicola)
        {
            Nodo actual = primero;
            if (primero != null)
            {
                bicola.Text = "";
                while (actual != null)
                {
                    bicola.Text += actual.cliente.nombre+ $"({actual.dato})"+ " <=> ";
                    actual = actual.siguiente;
                }
            }
            else
            {
                bicola.Text = "";
                MessageBox.Show("La bicola esta vacía", "Aviso", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
        }


        public Nodo buscar(string valor)
        {
            Nodo seleccionado=null;
            if (primero != null) { 
            Nodo actual = primero;
            bool flag = false;
            while (actual != null && flag != true)
            {
                if (actual.cliente.nombre == valor)
                {
                    seleccionado = actual;
                    //MessageBox.Show(valor + " está en la bicola", "Bicolas", MessageBoxButtons.OK,
                      //MessageBoxIcon.Information);
                      flag = true;
                    return seleccionado;
                }
                actual = actual.siguiente;
            }
                //if (flag == false)
                //MessageBox.Show(valor + " no está en la bicola", "Bicolas", MessageBoxButtons.OK,
                //MessageBoxIcon.Information);
            }
            return seleccionado;
        }


        public void modificar(int valor, int reemplazo)
        {
            Nodo actual = primero;
            bool flag = false;
            while (actual != null && flag != true)
            {
                if (actual.dato == valor)
                {
                    actual.dato = reemplazo;
                    flag = true;
                }
                actual = actual.siguiente;
            }
            if (flag == false)
                MessageBox.Show(valor + " no está en la bicola para modificar",
                    "Bicolas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void desencolarDer()
        {
            if (primero != null)
            {
                if (primero==ultimo)
                {
                    primero = ultimo = null;
                }
                else
                {
                    //ultimo.anterior.siguiente = null;
                    //ultimo = ultimo.anterior;
                    ultimo = ultimo.anterior;
                    ultimo.siguiente = null;
                }
            }
        }
        public void desncolarIzq()
        {
            if (primero != null)
            {
                if (primero == ultimo)
                {
                    primero = ultimo = null;
                }
                else
                {
                    primero = primero.siguiente;
                    primero.anterior = null;

                }
            }
        }
    }
}

