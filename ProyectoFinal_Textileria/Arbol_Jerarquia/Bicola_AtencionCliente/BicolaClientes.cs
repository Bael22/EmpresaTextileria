using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_Textileria.Bicola_AtencionCliente
{
    public partial class BicolaClientes : Form
    {
        public BicolaClientes()
        {
            InitializeComponent();
        }

        Bicola bicola;
        private void btnCrear_Click(object sender, EventArgs e)
        {
            bicola = new Bicola();
            MessageBox.Show("La cola se creo con éxito.", "BIENVENIDO.", MessageBoxButtons.OK);
        }

        private void btnEncolarIzq_Click(object sender, EventArgs e)
        {
            try
            {
                Nodo aux = null ;
                try {aux = bicola.buscar(txtNombre.Text); }//comprueba de que exista la bicola y el nombre
                catch(Exception ex){ MessageBox.Show("No se olvide crear la bicola", "Aviso", MessageBoxButtons.OK); }
                if (aux == null&&txtMonFinal.Text!="") { 
                    if (txtDato.Text=="1")
                {
                    Cliente client = new Cliente(txtNombre.Text, int.Parse(txtDNI.Text), int.Parse(txtTelef.Text), txtCorreo.Text,
                    txtDirec.Text, cbServicio.Text, int.Parse(txtcantidad.Text), double.Parse(txtMonVenta.Text), double.Parse(txtMonFinal.Text));

                    bicola.insertarIzquierda(int.Parse(txtDato.Text), client);
                    btnVerBicola_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Sólo el cliente VIP ingresa por izquierda.", "ALERTA", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                }else
                    MessageBox.Show("Nombre repetido o ausencia de algunos datos", "Alerta", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("El ingreso de datos es incorrectos.", "ALERTA", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void btnVerBicola_Click(object sender, EventArgs e)
        {
            if(bicola!=null)
            bicola.verDatos(txtMostrar);
        }

        private void btnEncolarDer_Click(object sender, EventArgs e)
        {
            try
            {
                Nodo aux = bicola.buscar(txtNombre.Text);
                if (aux == null&& txtMonFinal.Text != "")
                {
                    if (txtDato.Text== "3" || txtDato.Text=="2")
                {
                    Cliente client = new Cliente(txtNombre.Text, int.Parse(txtDNI.Text), int.Parse(txtTelef.Text), txtCorreo.Text,
                    txtDirec.Text, cbServicio.Text,int.Parse(txtcantidad.Text), double.Parse(txtMonVenta.Text), double.Parse(txtMonFinal.Text));
                    bicola.insertarDerecha(int.Parse(txtDato.Text), client);
                    btnVerBicola_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("El cliente VIP no ingresa por la derecha.", "ALERTA", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                }
                else
                    MessageBox.Show("Nombre repetido o ausencia de algunos datos", "Alerta", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("El ingreso de datos es incorrectos.", "ALERTA", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try { 
            Nodo aux = bicola.buscar(txtModificar.Text);
            if(aux == null)
            {
                MessageBox.Show(txtModificar.Text + " no está en la bicola", "Bicolas", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                string cliente = " ";
                
                if (aux.dato==1)
                {
                    cliente = "VIP"; 
                }
                if (aux.dato == 2)
                {
                    cliente = "Frecuente";
                }
                if (aux.dato == 3)
                {
                    cliente = "Nuevo";
                }

                MessageBox.Show("Ha sido encontrado el cliente: \nNombre: "+ aux.cliente.nombre+ "\nDNI: "+
                aux.cliente.DNI+ "\nTipo cliente: "+ cliente+ "\nTipo servicio: "+ aux.cliente.servicio
                + "\n Monto utilidad: " + aux.cliente.mFinal, "DATOS");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La Bicola no fue creada aun", "Aviso", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try { 
            Nodo aux = bicola.buscar(txtModificar.Text);
            if (aux == null)
            {
                MessageBox.Show(txtModificar.Text + " no está en la bicola", "Bicolas", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                Cliente guardar = new Cliente(txtNombre.Text, int.Parse(txtDNI.Text), int.Parse(txtTelef.Text), txtCorreo.Text,
                    txtDirec.Text, cbServicio.Text, int.Parse(txtcantidad.Text), double.Parse(txtMonVenta.Text), double.Parse(txtMonFinal.Text));
                aux.dato = int.Parse(txtDato.Text);
                aux.cliente = guardar;
                btnVerBicola_Click(sender, e);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La Bicola no fue creada aun", "Aviso", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }
        void ImprimirTxt(int i)//1 desencolar izq, 2 descolar derecha
        {
            if(bicola.primero!=null)
            { 
                StreamWriter escritor = File.AppendText("E:\\Documentos\\CICLOS UPN\\Ciclo 4" +
                   "\\ESTRUCTURA de DATOS\\" + "Evaluaciones\\ProyectoFinal_Textiles\\" +
                   "Bicola_RegistroClientes.txt");
                string texto = "";
                string cliente = " ";

                            
                if (i==1)
                {
                    if (bicola.primero.dato == 1) cliente = "VIP";
                    if (bicola.primero.dato == 2) cliente = "Frecuente";
                    if (bicola.primero.dato == 3) cliente = "Nuevo";
                    texto = cliente+ ";" + bicola.primero.cliente.nombre + ";" + bicola.primero.cliente.DNI
                        + ";" + bicola.primero.cliente.telef + ";" + bicola.primero.cliente.correo + ";" + bicola.primero.cliente.direccion
                        + ";" + bicola.primero.cliente.servicio + ";" + bicola.primero.cliente.cantidad + ";" + bicola.primero.cliente.mVenta + ";" + bicola.primero.cliente.mFinal;
                }
                if(i==2)
                {
                    if (bicola.ultimo.dato == 1) cliente = "VIP";
                    if (bicola.ultimo.dato == 2) cliente = "Frecuente";
                    if (bicola.ultimo.dato == 3) cliente = "Nuevo";
                    texto = cliente + ";" + bicola.ultimo.cliente.nombre + ";" + bicola.ultimo.cliente.DNI
                       + ";" + bicola.ultimo.cliente.telef + ";" + bicola.ultimo.cliente.correo + ";" + bicola.ultimo.cliente.direccion
                       + ";" + bicola.ultimo.cliente.servicio + ";" + bicola.ultimo.cliente.cantidad + ";" + bicola.ultimo.cliente.mVenta + ";" + bicola.ultimo.cliente.mFinal;
                }
                escritor.WriteLine(texto);
                escritor.Close();
            }
        }

        private void btnDesencolarDer_Click(object sender, EventArgs e)
        {
            try {
            if (bicola.ultimo.dato == 2)
            {
                    ImprimirTxt(2);
                bicola.desencolarDer();
                btnVerBicola_Click(sender, e);
            }
            else if ((bicola.ultimo.dato == 3 && bicola.ultimo.anterior.dato == 2)) 
            {
                DialogResult r = MessageBox.Show($" Cliente VIP o Nuevo están atascados con el cliente Frecuente. Por lo cual," +
                        $" Se desencolará a dichos clientes. ¿Está de acuerdo?", "Consulta Desencolar Derecha", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                        ImprimirTxt(2);
                        bicola.desencolarDer();
                        ImprimirTxt(2);
                        bicola.desencolarDer();

                    btnVerBicola_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Solo cliente frecuente puede salir por la derecha.", "ALERTA", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            }catch(Exception ex)
            {
                MessageBox.Show("No hay dato que descencolar por la derecha", "ALERTA", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }


        }

        private void btnDesencolarIzq_Click(object sender, EventArgs e)
        {
            try
            {
                if (bicola.primero.dato ==3 || bicola.primero.dato == 1)
            {
                    ImprimirTxt(1);
                    bicola.desncolarIzq();
                btnVerBicola_Click(sender, e);
            }
            else if ((bicola.primero.dato == 2 && bicola.primero.siguiente.dato == 3))
            {
                DialogResult r = MessageBox.Show($" Cliente Frecuente está atascado con el cliente VIP o Nuevo. Por lo cual," +
                        $" Se desencolará a dichos clientes. ¿Está de acuerdo?", "Consulta Desencolar Izquierda", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                        ImprimirTxt(1);
                        bicola.desncolarIzq();
                        ImprimirTxt(1);
                        bicola.desncolarIzq();

                    btnVerBicola_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Cliente fecuente no puede salir por la izquierda.", "ALERTA", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay dato que descencolar por la izquierda", "ALERTA", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }


        private void txtDato_TextChanged(object sender, EventArgs e)
        {
            try { 
            if (!(txtDato.Text == "1" || txtDato.Text == "2" || txtDato.Text == "3" || txtDato.Text == "" ))
            {
                MessageBox.Show("Solo se permite el ingreso al tipo de cliente VIP(1), Frecuente(2) o Nuevo(3)", "ALERTA", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                txtMonFinal.Text = "";
            }
            else
            {
                double monto1 = double.Parse(txtMonVenta.Text) * int.Parse(txtcantidad.Text);
                double montoCarga = 0;//IGV-descuento
                if (txtDato.Text == "1") montoCarga = 0.18 - 0.15;
                if (txtDato.Text == "2") montoCarga = 0.18 - 0.05;
                if (txtDato.Text == "3") montoCarga = 0.18 - 0.00;
                double mFin = monto1 + monto1 * montoCarga;

                txtMonFinal.Text = mFin + "";
            }
            }catch(Exception ex) { txtMonFinal.Text = "0"; }
        }

        private void txtMonVenta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                 double monto1= double.Parse(txtMonVenta.Text)*int.Parse(txtcantidad.Text);              
                txtMonFinal.Text = monto1+"";
            }
            catch (Exception ex)
            {
                txtMonFinal.Text = "";
            }
        }

        private void cbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbServicio.Text=="Fibra Natural")
            {
                txtMonVenta.Text = "31";
            }
            if (cbServicio.Text == "Hilandería")
            {
                txtMonVenta.Text = "44";
            }
            if (cbServicio.Text == "Tejeduría")
            {
                txtMonVenta.Text = "56";
            }
            if (cbServicio.Text == "Confección")
            {
                txtMonVenta.Text = "82";
            }
            if (cbServicio.Text == "Alta Costura")
            {
                txtMonVenta.Text = "116";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            try{ 
            if(!(int.Parse(txtcantidad.Text) >0|| txtcantidad.Text==""))
            {
                MessageBox.Show("ingrese una cantidad válida", "Aviso", MessageBoxButtons.OK);
            }
            }catch (Exception ex){
                MessageBox.Show("Ingrese valores de numeros enteros", "Aviso", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }
    }
}
