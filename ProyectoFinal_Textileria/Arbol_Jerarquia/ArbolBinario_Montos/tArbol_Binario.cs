using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Textileria.ArbolBinario_Montos
{
    internal class tArbol_Binario
    {
        public tNodo_Arbol tRaiz, taux;
        public static int tnum=0;
        public double mayor = 0,menor=1000000000000,promedio=0;
        public bool flag1 = false;
        public tArbol_Binario()
        {
            taux = new tNodo_Arbol();
        }
        public tArbol_Binario(tNodo_Arbol nueva_raiz)
        {
            tRaiz = nueva_raiz;
        }
        public void Insertar(double tx)
        {
            if (tRaiz == null)
            {
               if(tx > 0) { 
                   tRaiz = new tNodo_Arbol(tx, null, null, null);
                   tRaiz.tnivel = 0;tnum++;
               }else
                        MessageBox.Show("El valor debe ser mayor a 0");
                }
            else
            { 
                  if (tx > 0 )
                  { tRaiz = tRaiz.Insertar(tx, tRaiz, tRaiz.tnivel); }
                  else
                    MessageBox.Show("El valor debe ser mayor a 0");
                  
                
            }
           
        }
        public void DibujarArbol(Graphics grafo, Font fuente, Brush relleno,
            Brush rellenoFuente, Pen lapiz, Brush encuentro)
        {
            int tx =310;
            int ty = 75;
            if (tRaiz == null)
                return;
            tRaiz.PosicionNodo(ref tx, ty);
            tRaiz.DibujarRama(grafo, lapiz);
            tRaiz.DibujarNodo(grafo, fuente, relleno, rellenoFuente,
                lapiz, encuentro);
        }
        public tNodo_Arbol tBuscar(double texto, tNodo_Arbol tn)
        {
            tNodo_Arbol tencontrado = null;
            if (tn == null) return tencontrado;
            if (texto==tn.tinfo)
            {
                
                return tn; }
            if (tn.tIzquierdo != null)//procesa hijos
            {
                
                tencontrado=tBuscar(texto, tn.tIzquierdo);
                if (tencontrado != null)
                    return tencontrado;
            }
            if (tn.tDerecho != null)//procesa hermano
            {
                
                tencontrado = tBuscar(texto, tn.tDerecho);
                if (tencontrado != null)
                    return tencontrado;
            }
            return tencontrado;
        }
        public void tBuscar(double texto)
        {
            if(tBuscar(texto,tRaiz)!=null)
                MessageBox.Show($"Si se encuentra el dato {texto}");
            else
                MessageBox.Show($"No se encuentra el dato {texto}");
        }
        public tNodo_Arbol tEliminar(double texto, tNodo_Arbol tn)
        {
            if (tn == null) return tn;
            if (texto < tn.tinfo) tn.tIzquierdo = tEliminar(texto, tn.tIzquierdo);//actualiza
            if (texto > tn.tinfo) tn.tDerecho= tEliminar(texto, tn.tDerecho);
            if(texto==tn.tinfo)//para elimnar el nodo y lo que tiene abajo: tn = null;return tn;

            {//Siempre elimina y actualiza
                if(tn.tIzquierdo==null&&tn.tDerecho==null)
                {
                    tn = null;tnum--;
                    return tn;
                }
                else if(tn.tDerecho==null)
                {
                    tNodo_Arbol temp = tn; temp = null;//eliminar el dato
                    tn = tn.tIzquierdo;//actualizar la ruta que llega a este
                     tnum--;
                }
                else if (tn.tIzquierdo == null)
                {
                    tNodo_Arbol temp = tn; temp = null;
                    tn = tn.tDerecho;
                     tnum--;
                }
                else
                {
                    tn = null; tnum--;
                    return tn;
                }
            }
            return tn;
        }
        public void tEliminar(double texto)
        {
            bool t1=false, t2=false;
            if (tBuscar(texto, tRaiz) != null) t1 = true;
            tEliminar(texto, tRaiz);
            if (tBuscar(texto, tRaiz) == null) t2 = true;
            if (t1 && t2)
            { MessageBox.Show("Se ha eliminado el Dato");
                mayor = 0;
            }
            else
                MessageBox.Show("No se puede eliminar un dato que no hay");
        }
        public void tInorden(tNodo_Arbol tab,ref string tdato)
        {
            if(tab!=null)
            {
                tInorden(tab.tIzquierdo,ref tdato);
                tdato += tab.tinfo+" - ";
                tInorden(tab.tDerecho, ref tdato);
            }
        }
        public void tInorden(TextBox txt)
        {
            txt.Clear();
            string tdato = "";
            tInorden(tRaiz, ref tdato);
            txt.Text = tdato;
        }
        public void tPrenorden(tNodo_Arbol tab, ref string tdato)
        {
            if (tab != null)
            {
                tdato += tab.tinfo + " - ";
                tPrenorden(tab.tIzquierdo, ref tdato);
                
                tPrenorden(tab.tDerecho, ref tdato);
            }
        }
        public void tPrenorden(TextBox txt)
        {
            txt.Clear();
            string tdato = "";
            tPrenorden(tRaiz, ref tdato);
            txt.Text = tdato;
        }
        public void tPostnorden(tNodo_Arbol tab, ref string tdato)
        {
            if (tab != null)
            {
                
                tPostnorden(tab.tIzquierdo, ref tdato);

                tPostnorden(tab.tDerecho, ref tdato);
                tdato += tab.tinfo + " - ";
            }
        }
        public void tPostnorden(TextBox txt)
        {
            txt.Clear();
            string tdato = "";
            tPostnorden(tRaiz, ref tdato);
            txt.Text = tdato;
        }
        int tAlto(tNodo_Arbol tn)
        {
            if (tn == null) return 0;
            int izq = tAlto(tn.tIzquierdo) + 1;
            int der = tAlto(tn.tDerecho) + 1;
            return Math.Max(izq, der);
        }
        void contador(tNodo_Arbol tn,ref int  num)
        {
            if (tn != null)
            {
                contador(tn.tIzquierdo, ref num);
                contador(tn.tDerecho, ref num);
                num++;
                if (tn.tinfo > mayor) mayor = tn.tinfo;//hallando el mayor
                if (tn.tinfo < menor) menor = tn.tinfo;//hallando el menor
                if(tn!=tRaiz)
                { promedio += tn.tinfo;
                    
                }
            }
        }
        public void tEvaluar(Label taltura,Label telement,Label mmayor, Label mmenor)
        {
            if (tRaiz != null) { 
            taltura.Text = "Alto: " + tAlto(tRaiz);
                int numero = 0;
                contador(tRaiz, ref numero);
                telement.Text = "Nº elementos: "+numero;
                mmayor.Text = "Monto Mayor: \n    " + mayor;
                mmenor.Text = "Monto Menor: \n    " + menor;
                if (flag1 != false) {
                    promedio = (promedio / (numero - 1));
                    tRaiz.tinfo =Math.Round(promedio, 1);
                }
                promedio = 0; 
            }
        }
    }
}
