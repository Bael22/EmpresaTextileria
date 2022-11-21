using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Textileria
{
    public partial class PanelPrincipal : Form
    {
        public PanelPrincipal()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text= "Bienvenido!! :)";
        }
        private Arbol_Jerarquia1 Arbol;
        private ArbolBinario_Montos.ArbolBinario ABinario;
        private ColaSupervisionProductos.ColaSupervision Cola;
        private Bicola_AtencionCliente.BicolaClientes Bicola;
        private PilaAdministrativa.PilaInventario Pila;
        private void arbolDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Arbol == null)
            {
                Arbol = new Arbol_Jerarquia1();
                Arbol.MdiParent = this;
                Arbol.FormClosed += new FormClosedEventHandler(CerrarFormularioArbol);
                Arbol.Show();
                toolStripStatusLabel1.Text = "Esta dentro del formulario Arbol de Cargos";
            }
            else
                Arbol.Activate();
        }
        public void CerrarFormularioArbol(object sender, FormClosedEventArgs e)
        {
            Arbol = null;
            toolStripStatusLabel1.Text = "Acabas de salir del Formulario " +
                "como tu de la vida de ella :'(";
        }
        public void CerrarFormularioArbolBi(object sender, FormClosedEventArgs e)
        {
            ABinario = null;
            toolStripStatusLabel1.Text = "Acabas de salir del Formulario " +
                "como tu de la vida de ella :'(";
        }
        public void CerrarFormularioCola(object sender, FormClosedEventArgs e)
        {
            Cola = null;
            toolStripStatusLabel1.Text = "Acabas de salir del Formulario " +
                "como tu de la vida de ella :'(";
        }
        public void CerrarFormularioBicola(object sender, FormClosedEventArgs e)
        {
            Bicola = null;
            toolStripStatusLabel1.Text = "Acabas de salir del Formulario " +
                "como tu de la vida de ella :'(";
        }
        public void CerrarFormularioPila(object sender, FormClosedEventArgs e)
        {
            Pila = null;
            toolStripStatusLabel1.Text = "Acabas de salir del Formulario " +
                "como tu de la vida de ella :'(";
        }

        private void btnarbolcargos_Click(object sender, EventArgs e)
        {
            arbolDeEmpleadosToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//ArbolBinario
        {
            arbolBinarioToolStripMenuItem_Click(sender, e);
        }


        private void arbolBinarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ABinario == null)
            {
                ABinario = new ArbolBinario_Montos.ArbolBinario();
                ABinario.MdiParent = this;
                ABinario.FormClosed += new FormClosedEventHandler(CerrarFormularioArbolBi);
                ABinario.Show();
                toolStripStatusLabel1.Text = "Esta dentro del formulario Arbol Binario de Montos";
            }
            else
                Arbol.Activate();
        }

        private void colasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Cola == null)
            {
                Cola = new ColaSupervisionProductos.ColaSupervision();
                Cola.MdiParent = this;
                Cola.FormClosed += new FormClosedEventHandler(CerrarFormularioCola);
                Cola.Show();
                toolStripStatusLabel1.Text = "Esta dentro del formulario de Supervision de Productos";
            }
            else
                Cola.Activate();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)//cola
        {
            colasToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)//bicola
        {
            bicolasToolStripMenuItem_Click(sender, e);
        }

        private void bicolasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Bicola == null)
            {
                Bicola = new Bicola_AtencionCliente.BicolaClientes();
                Bicola.MdiParent = this;
                Bicola.FormClosed += new FormClosedEventHandler(CerrarFormularioBicola);
                Bicola.Show();
                toolStripStatusLabel1.Text = "Esta dentro del formulario Arbol Binario de Montos";
            }
            else
                Bicola.Activate();
        }

        private void pilasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Pila == null)
            {
                Pila = new PilaAdministrativa.PilaInventario();
                Pila.MdiParent = this;
                Pila.FormClosed += new FormClosedEventHandler(CerrarFormularioPila);
                Pila.Show();
                toolStripStatusLabel1.Text = "Esta dentro del formulario Administración de Inventario tipo Pila";
            }
            else
                Pila.Activate();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            pilasToolStripMenuItem_Click(sender, e);
        }
    }
}
