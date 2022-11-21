using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Textileria.ColaSupervisionProductos
{
    public partial class ColaSupervision : Form
    {
        int contador;
        public ColaSupervision()
        {
            InitializeComponent();
           
            labelcontador.Text= "Cantidad de \nregistros atendidos : " + CantidadRegistrados();
            leerDatos();
            contador = CantidadRegistrados();
        }
        Cola cola=new Cola();

        private int CantidadRegistrados()
        {
            StreamReader l = new StreamReader("E:\\Documentos\\CICLOS UPN\\Ciclo 4\\ESTRUCTURA de DATOS\\Evaluaciones\\ProyectoFinal_Textiles\\PedidosRevisados.txt");
            string str = l.ReadLine();int n = 0;
            while(str != null)
            {
                n++;
                str = l.ReadLine();
            }
            l.Close();
            return n;
        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo se permiten números.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo se permiten números.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo se permiten números.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            auxAgregar();
        }
        private void addRow(string codigo, string producto, string cantidad, string precio)
        {
            String[] row = {codigo,producto,cantidad,precio};
            dgvPila.Rows.Add(row);
        }
        void auxVerCola()
        {
            labelcola.Text = "Cola de productos : (Producto (cantidad))\n";
            cola.verCola(labelcola);
        }
        
        private void borrarRegistroDGV(object sender, EventArgs e)
        {
            if (dgvPila.Rows.Count != 0)
            {
                for (int i = 0; i < dgvPila.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        dgvPila.Rows.RemoveAt(i);
                        contador++;
                    }
                }
            }
            else
            {
                MessageBox.Show("No existen pedidos por revisar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            if(dgvPila.Rows.Count == 0)
            {
                MessageBox.Show("No existen pedidos por revisar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                StreamWriter escritor = File.AppendText("E:\\Documentos\\CICLOS UPN\\Ciclo 4\\ESTRUCTURA de DATOS\\Evaluaciones\\ProyectoFinal_Textiles\\PedidosRevisados.txt");
                string pedidos;
                pedidos = (string)this.dgvPila.Rows[0].Cells[0].Value + "-" + (string)this.dgvPila.Rows[0].Cells[1].Value + "-" + (string)this.dgvPila.Rows[0].Cells[2].Value + "-" + (string)this.dgvPila.Rows[0].Cells[3].Value;
                escritor.WriteLine(pedidos);
                escritor.Close();
                borrarRegistroDGV(sender, e);
                //contador++;
                lblCantR.Text = ""+contador.ToString();
                labelcontador.Text = "Cantidad de \nregistros atendidos : " + contador;
                cola.desencolarNodo();
                //borrarRegistroDGV(sender, e);
                auxVerCola();
                eliminarTodo();
            }
        }
        void auxAgregar()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text) && string.IsNullOrEmpty(txtProducto.Text) && string.IsNullOrEmpty(txtCantidad.Text) && string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Los campos están vacíos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtProducto.Text) || string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Debe completar todos los campos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
                dgvPila.Rows.Add(txtCodigo.Text, txtProducto.Text, txtCantidad.Text, txtPrecio.Text);
                //cola.insertarNodo(txtCodigo.Text);
                //Pedido pedido = new Pedido(txtCantidad.Text, txtProducto.Text, int.Parse(txtCantidad.Text), int.Parse(txtPrecio.Text));
                cola.insertarNodo("" + txtProducto.Text + " (" + txtCantidad.Text + ")");
                //cola.insertarNodo(txtPrecio.Text);
                StreamWriter sw = File.AppendText("E:\\Documentos\\CICLOS UPN\\Ciclo 4\\ESTRUCTURA de DATOS\\Evaluaciones\\ProyectoFinal_Textiles\\PedidosRegistrados.txt");
                sw.WriteLine(txtCodigo.Text + "-" + txtProducto.Text + "-" + txtCantidad.Text + "-" + txtPrecio.Text);
                sw.Close();
                txtCodigo.Text = "";
                txtProducto.Text = "";
                txtCantidad.Text = "";
                txtPrecio.Text = "";
                auxVerCola();
            
            
        }
        void leerDatos()
        {
            StreamReader lector = new StreamReader("E:\\Documentos\\CICLOS UPN\\Ciclo 4\\ESTRUCTURA de DATOS\\Evaluaciones\\ProyectoFinal_Textiles\\PedidosRegistrados.txt");
            string revisado=lector.ReadLine();
            dgvPila.Rows.Clear();
            while(revisado != null)
            {
                string[] dato=revisado.Split('-');
                dgvPila.Rows.Add(dato[0], dato[1], dato[2], dato[3]);
                cola.insertarNodo( dato[1] + " (" + dato[2] + ")");auxVerCola();//la cola se actualiza
                revisado =lector.ReadLine();
            }
            lector.Close();
        }
        void eliminarTodo()
        {
            StreamWriter escritor = File.AppendText("E:\\Documentos\\CICLOS UPN\\Ciclo 4\\ESTRUCTURA de DATOS\\Evaluaciones\\ProyectoFinal_Textiles\\PedidosRegistrados1.txt");
            StreamReader lector = new StreamReader("E:\\Documentos\\CICLOS UPN\\Ciclo 4\\ESTRUCTURA de DATOS\\Evaluaciones\\ProyectoFinal_Textiles\\PedidosRegistrados.txt");
            string linea = lector.ReadLine();//a1
            if(linea != null)
            { 
            linea = lector.ReadLine();//se elimina automaticamente el primer dato
            while (linea != null )
            {//Datos= a1,a2,a3,a4,a5,a6,a7,a8,b1   elimnar=a5
                    escritor.WriteLine(linea);
                    linea = lector.ReadLine();
                    
            }
            }
            escritor.Close();
            lector.Close();
            File.Delete("E:\\Documentos\\CICLOS UPN\\Ciclo 4\\ESTRUCTURA de DATOS\\Evaluaciones\\ProyectoFinal_Textiles\\PedidosRegistrados.txt");//elimina el viejo
            File.Move("E:\\Documentos\\CICLOS UPN\\Ciclo 4\\ESTRUCTURA de DATOS\\Evaluaciones\\ProyectoFinal_Textiles\\PedidosRegistrados1.txt", //reemplaza la copia por el viejo.
                "E:\\Documentos\\CICLOS UPN\\Ciclo 4\\ESTRUCTURA de DATOS\\Evaluaciones\\ProyectoFinal_Textiles\\PedidosRegistrados.txt");
            
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
