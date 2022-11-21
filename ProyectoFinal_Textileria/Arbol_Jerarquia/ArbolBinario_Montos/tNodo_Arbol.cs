using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Textileria.ArbolBinario_Montos
{
    internal class tNodo_Arbol
    {
        public int  telementos, tnivel;
        public double tinfo;
        public tNodo_Arbol tIzquierdo, tDerecho, tPadre, tarbol;
        
        public tNodo_Arbol()
        {
        }
        public tNodo_Arbol(double tnueva_info, tNodo_Arbol tizquierdo,
            tNodo_Arbol tderecho, tNodo_Arbol tpadre)
        {
            tinfo = tnueva_info;
            tIzquierdo = tizquierdo;
            tDerecho = tderecho;
            tPadre = tpadre;
            telementos = 0;
        }
        
        public tNodo_Arbol Insertar(double tx, tNodo_Arbol t, int tlevel)
        {
            if (t == null)
            {
                t = new tNodo_Arbol(tx, null, null, null);
                t.tnivel = tlevel; telementos++;
            }
            else if (tx < t.tinfo)
            {
                tlevel++;//Podria poner tIzquierdo = Insertar(tx, t.tIzquierdo, tlevel);
                //pero, solo se actualizaria el valor tIzquierdo y no t.tIzquierdo,la cual
                //este ultimo es el verdadero recorrido de impresion,pues siempre ese mtd retorna un nodo.
                t.tIzquierdo = Insertar(tx, t.tIzquierdo, tlevel);
            }
            else if (tx > t.tinfo)
            {
                tlevel++;
                t.tDerecho = Insertar(tx, t.tDerecho, tlevel);
            }
            else
            {
                MessageBox.Show("El dato ya existe", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return t;
        }
        /**dibujando nodo--------------------------------------*/
        private const int tRadio = 40;
        private const int tDistanciaH = 80;
        private const int tDistanciaV = 10;
        private int tCoordenadaX, tCoordenadaY;

        public void PosicionNodo(ref int xmin, int ymin)
        {
            int aux1, aux2;
            tCoordenadaY = (int)(ymin + tRadio / 2);
            if (tIzquierdo != null)
                tIzquierdo.PosicionNodo(ref xmin, ymin + tRadio + tDistanciaV);
            if (tIzquierdo != null && tDerecho != null)
                xmin += tDistanciaH;
            if (tDerecho != null)
                tDerecho.PosicionNodo(ref xmin, ymin + tRadio + tDistanciaV);
            if (tIzquierdo != null && tDerecho != null)
                tCoordenadaX = (int)((tIzquierdo.tCoordenadaX + tDerecho.tCoordenadaX) / 2);
            else if (tIzquierdo != null)
            {
                aux1 = tIzquierdo.tCoordenadaX;
                tIzquierdo.tCoordenadaX = tCoordenadaX - 80;
                tCoordenadaX = aux1;
            }
            else if (tDerecho != null)
            {
                aux2 = tDerecho.tCoordenadaX;
                tDerecho.tCoordenadaX = tCoordenadaX + 80;
                tCoordenadaX = aux2;
            }
            else
            {
                tCoordenadaX = (int)(xmin + tRadio / 2);
                xmin += tRadio;
            }
        }
        public void DibujarRama(Graphics grafo, Pen lapiz)
        {
            if (tIzquierdo != null)
            {
                grafo.DrawLine(lapiz, tCoordenadaX, tCoordenadaY, tIzquierdo.tCoordenadaX,
                    tIzquierdo.tCoordenadaY);
                tIzquierdo.DibujarRama(grafo, lapiz); /*aqui estaba el error*/
            }
            if (tDerecho != null)
            {
                grafo.DrawLine(lapiz, tCoordenadaX, tCoordenadaY, tDerecho.tCoordenadaX,
                    tDerecho.tCoordenadaY);
                tDerecho.DibujarRama(grafo, lapiz);
            }
        }
        public void DibujarNodo(Graphics grafo, Font fuente, Brush relleno,
            Brush rellenoFuente, Pen lapiz, Brush encuentro)
        {
            Rectangle rect = new Rectangle((int)(tCoordenadaX - tRadio / 2),
                (int)(tCoordenadaY - tRadio / 2), tRadio, tRadio);/*otro error coord Y*/
            grafo.FillEllipse(encuentro, rect);//ni idea
            grafo.FillEllipse(relleno, rect);//cambia el color del numero contenido
            grafo.DrawEllipse(lapiz, rect);//color de los bordes de la figura

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            grafo.DrawString(tinfo.ToString(), fuente, rellenoFuente,
                tCoordenadaX, tCoordenadaY, format);

            if (tIzquierdo != null)
                tIzquierdo.DibujarNodo(grafo, fuente, relleno, rellenoFuente, lapiz, encuentro);
            if (tDerecho != null)
                tDerecho.DibujarNodo(grafo, fuente, relleno, rellenoFuente, lapiz, encuentro);
        }
    }
}
