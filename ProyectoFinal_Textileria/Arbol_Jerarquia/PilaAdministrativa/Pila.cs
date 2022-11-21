using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Textileria.PilaAdministrativa
{
    internal class Pila
    {
        public Nodo primero;
        //Producto product;
        public Pila()
        {
            primero = null;
        }
        public void insertarNodo(Producto dato)
        {
            Nodo nuevo = new Nodo();
            nuevo.Dato = dato;
            nuevo.Siguiente = primero;
            primero = nuevo;
        }
        public void verPila_DGV(ListBox lst,DataGridView data)
        {
            
            Nodo actual =primero;          
            lst.Items.Clear();data.Rows.Clear();
            while(actual != null)
            {
                data.Rows.Add(actual.Dato.codigo, actual.Dato.producto,
                    actual.Dato.cantidad, actual.Dato.precio);
                lst.Items.Add(actual.Dato.codigo+"-" +actual.Dato.producto+"-"+ 
                    actual.Dato.cantidad+"(S/."+ actual.Dato.cantidad+")");
                lst.Items.Add("--------------------------------------------------");
                actual = actual.Siguiente;
            }
            
        }
        public bool buscarNodo(string dato)
        {
            
            Nodo actual = new Nodo();
            actual = primero;
            bool flag = false;
            if(primero!=null){
            
                string nodoBuscado = dato;
              while(actual !=null && flag == false)
              {
                if(actual.Dato.codigo == nodoBuscado)
                {                
                    flag = true;
                }
                actual = actual.Siguiente;
              }
            }
            //else MessageBox.Show("La pila está vacía", "Aviso",
                      //MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            return flag;
        }
        public void desapilar()
        {
            Nodo actual = new Nodo();
            actual = primero;
            if (actual != null)
            {
                actual = actual.Siguiente;
                primero = actual;
            }
            else
            {
                MessageBox.Show("La pila está vacía", "Pilas",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void numElementos(Label lbl)
        {
            Nodo actual =primero;
            
            int n = 0;
            lbl.Text = "Cantidad de productos: " + n;
            while (actual != null)
            {
                actual = actual.Siguiente;
                n++;
            }
            if (n > 0)
              lbl.Text = "Cantidad de productos: " + n;
            
        }
        

    }
}
