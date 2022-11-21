using System;
using System.Drawing;
using System.IO;
namespace Proyecto_Textileria.ArbolBinario_Montos
{
    public partial class ArbolBinario : Form
    {
        public ArbolBinario()
        {
            InitializeComponent();
            Leertxt();
        }
        tArbol_Binario abb;
        Graphics g;
        
        void InsertarAux()
        {
            try
            {
                abb.Insertar(Math.Round(double.Parse(ttxtoperacion.Text),1));
                ttxtoperacion.Clear();
                
                abb.tEvaluar(tlblaltura, tlblnumelementos, lblmayor,lblmenor);
                Refresh();
            }
            catch (Exception ex)
            { MessageBox.Show("Ingrese un numeros y no otros formatos", "Aviso", MessageBoxButtons.OK); }
        }
        private void tbtningresar_Click(object sender, EventArgs e)
        {
            InsertarAux();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g = e.Graphics;
            abb.DibujarArbol(g, this.Font, Brushes.AliceBlue, Brushes.Black,
                Pens.White, Brushes.Black);
        }

        private void tbtnbuscar_Click(object sender, EventArgs e)
        {
            try { 
            abb.tBuscar(double.Parse(ttxtoperacion.Text));
            }catch (Exception ex) {
                MessageBox.Show("El dato debe ser un numero entero", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbtneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                abb.tEliminar(double.Parse(ttxtoperacion.Text));
                Refresh();
                Refresh();
                abb.tEvaluar(tlblaltura, tlblnumelementos,lblmayor,lblmenor);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha ingresado un numero", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tlblrecorrido.Text = "Recorrido InOrden:";
            abb.tInorden(ttxtrecorrido);
        }

        private void tbtnpostorden_Click(object sender, EventArgs e)
        {
            tlblrecorrido.Text = "Recorrido PostOrden:";
            abb.tPostnorden(ttxtrecorrido);
        }

        private void tbtnPreorden_Click(object sender, EventArgs e)
        {
            tlblrecorrido.Text = "Recorrido PreOrden:";
            abb.tPrenorden(ttxtrecorrido);
        }
        void Leertxt()
        {
            abb = new tArbol_Binario();
            StreamReader lector = new StreamReader("E:\\Documentos\\CICLOS UPN\\Ciclo 4" +
                   "\\ESTRUCTURA de DATOS\\" + "Evaluaciones\\ProyectoFinal_Textiles\\" +
                   "Bicola_RegistroClientes.txt");
            string leido=lector.ReadLine();
            double promedio1 = 0;int cont = 0;
            while (leido != null)
            {
                string[] dato = leido.Split(';');
                promedio1 += double.Parse(dato[9]);
                cont++;
                leido = lector.ReadLine();
            }
            promedio1 = promedio1 / cont;promedio1 = Math.Round(promedio1, 1);
            ttxtoperacion.Text =promedio1.ToString();
            InsertarAux();
            lector.Close();
            //datos guardados
            StreamReader lector1 = new StreamReader("E:\\Documentos\\CICLOS UPN\\Ciclo 4" +
                   "\\ESTRUCTURA de DATOS\\" + "Evaluaciones\\ProyectoFinal_Textiles\\" +
                   "Bicola_RegistroClientes.txt");
            string leido1 = lector1.ReadLine();
            while (leido1!=null)
            {
                string[] dato = leido1.Split(';');
                ttxtoperacion.Text = Math.Round(double.Parse(dato[9]), 1)+"";
                InsertarAux();
                leido1=lector1.ReadLine();
            }
            lector1.Close();
            abb.flag1 = true;
        }
    }
}