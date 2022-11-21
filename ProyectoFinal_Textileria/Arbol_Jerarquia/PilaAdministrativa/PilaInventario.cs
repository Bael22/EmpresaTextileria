using System.IO;
namespace Proyecto_Textileria.PilaAdministrativa
{
    public partial class PilaInventario : Form
    {
        Pila pila;
        public PilaInventario()
        {
            InitializeComponent();
            pila = new Pila();
            leedato();
        }
        double precio = 0;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if(pila.buscarNodo(txtCodigo.Text)==false)
                    MessageBox.Show($"El codigo {txtCodigo.Text} no existe en la pila", "Pila",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se encontro dicho código", "Pila",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPila.Rows.Clear();
                    Nodo aux = pila.primero;
                    while (aux.Dato.codigo != txtCodigo.Text)
                        aux = aux.Siguiente;
                    dgvPila.Rows.Add(aux.Dato.codigo, aux.Dato.producto, aux.Dato.cantidad, aux.Dato.precio);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingresa un código", "Pila",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesapilar_Click(object sender, EventArgs e)
        {
            if (dgvPila.Rows.Count == 0)
            {
                MessageBox.Show("No hay elementos por desapilar", "Pila", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                pila.desapilar();
                pila.numElementos(lblCant);             
                btnVer_Click(sender, e);
                GrabarText(1);
            }
        }
        void ApilarAux(int i)
        {
            try
            {
                if (pila.buscarNodo(txtCodigo.Text) != true) {
                if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(cbProducto.Text)
                    || string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrEmpty(txtPrecio.Text)||
                    int.Parse(txtCantidad.Text)<1)
                {
                    MessageBox.Show("Existen campos vacíos o la cantidad es menor a 1.", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    pila.insertarNodo(new Producto(txtCodigo.Text, cbProducto.Text, int.Parse(txtCantidad.Text), double.Parse(txtPrecio.Text)));
                    limpiarTxt();
                    pila.numElementos(lblCant);
                    pila.verPila_DGV(listBox1, dgvPila);
                    GrabarText(i);
                }
                    }else
                         {
                         MessageBox.Show("El código se ha repetido, intente otro", "ERROR",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique que los datos sean de formato correcto", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnApilar_Click(object sender, EventArgs e)
        {
            ApilarAux(1);
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            pila.verPila_DGV(listBox1, dgvPila);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
        }
        private void leedato()//lee txt y agregar al dgv
        {
            
            StreamReader lector2 = new StreamReader("E:\\Documentos\\CICLOS UPN\\Ciclo 4\\" +
                "ESTRUCTURA de DATOS\\Evaluaciones\\ProyectoFinal_Textiles\\PedidosRegistrados.txt");
            string leido = lector2.ReadLine();
            dgvPila.Rows.Clear();
            
            while(leido!= null&&leido!="")
            {
                string[] dato = leido.Split('-');
                txtCodigo.Text = dato[0];cbProducto.Text = dato[1];
                txtCantidad.Text= dato[2];txtPrecio.Text=dato[3];
                ApilarAux(0);
                
                leido = lector2.ReadLine();
            }
            
            lector2.Close();
        }
        private void GrabarText(int i)//guardar para el txt
        {
            if (i == 1) { 
            File.Delete("E:\\Documentos\\CICLOS UPN\\Ciclo 4\\" +
                "ESTRUCTURA de DATOS\\Evaluaciones\\ProyectoFinal_Textiles\\PedidosRegistrados.txt");
            
            StreamWriter escritor = File.AppendText("E:\\Documentos\\CICLOS UPN\\Ciclo 4\\" +
                "ESTRUCTURA de DATOS\\Evaluaciones\\ProyectoFinal_Textiles\\PedidosRegistrados.txt");
            Nodo aux = pila.primero;
            while (aux != null)
            {
                string b = aux.Dato.codigo+"-"+aux.Dato.producto+"-"+aux.Dato.cantidad+"-"+aux.Dato.precio;
                escritor.WriteLine(b);
                aux = aux.Siguiente;
            }
            escritor.Close();
            }
        }
        private void limpiarTxt()
        {
            txtCodigo.Text = "";
            cbProducto.Text = "";
            txtCantidad.Text = "0";
            txtPrecio.Text = "0";            
            txtCantidad.Focus();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Paint(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Segoe UI",27);
            Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            e.Graphics.TranslateTransform(5, 470);
            e.Graphics.RotateTransform(270);
            e.Graphics.DrawString("Administración de Inventario", myfont, b, 0, 0);
        }

        private void PilaInventario_Load(object sender, EventArgs e)
        {

        }

        private void btnGernerar_Click(object sender, EventArgs e)
        {
           
            Random rnd = new Random();
            string a = "n00" + rnd.Next(1, 10000);
            while(pila.buscarNodo(a)!=false)
                a = "n00" + rnd.Next(1, 10000);
            txtCodigo.Text = a;
            
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            if (cbProducto.Text == "Algodón")
                precio = 34;
            if (cbProducto.Text == "Bonote")
                precio = 18;
            if (cbProducto.Text == "Cáñamo")
                precio = 78;
            if (cbProducto.Text == "Lino")
                precio = 20;
            if (cbProducto.Text == "Ramio")
                precio = 26;
            if (cbProducto.Text == "Sisal")
                precio = 20;
            if (cbProducto.Text == "Yute")
                precio = 14.5;
            if (cbProducto.Text == "Abacá")
                precio = 22.5;
            if (cbProducto.Text == "Angora")
                precio = 99.1;
            if (cbProducto.Text == "")
                precio = 0;
            double preciofin = precio * int.Parse(txtCantidad.Text);
            txtPrecio.Text = Math.Round(preciofin + (preciofin * 0.18),2) + "";
            }catch (Exception ex) { txtPrecio.Text = "0"; }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try {
                if ((int.Parse(txtCantidad.Text) > 0||txtCantidad.Text==""))
                    
                
                {
                    cbProducto_SelectedIndexChanged(sender, e);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Solo se aceptan cantidades enteras positivos", "Aviso-Pila",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}