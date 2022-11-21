using System.IO;
using System.Windows.Forms;
namespace Proyecto_Textileria
{
    public partial class Arbol_Jerarquia1 : Form
    {
        public Arbol_Jerarquia1()
        {
            InitializeComponent();
            LlenarArbolPredeterminado();
            InsertarAux();//insertamos los datos guardados previamente
        }
        NodoArbol raiz, seleccionado;string cod1="";bool flagult = false;
       void LlenarArbolPredeterminado()//datos de cargos
        {//presenciamos los codigos reservados
            raiz = new NodoArbol("n00251", "Cargos de la Empresa", "","","");
            raiz.hijo = new NodoArbol("n00252", "Atencion al cliente", "", "", "");
            raiz.hijo.hermano = new NodoArbol("n00253", "Supervision de Productos", "", "", "");
            raiz.hijo.hermano.hermano = new NodoArbol("n00254", "Almacenamiento y Administracion", "", "", "");
            LlenarTreeView();
        }
        void GuardarTxt(int i)//guarda en el txt de base de datos
        {
            if (i == 1) { 
            StreamWriter writer=File.AppendText("E:\\Documentos\\CICLOS UPN\\Ciclo 4" +
                "\\ESTRUCTURA de DATOS\\" +
                "Evaluaciones\\ProyectoFinal_Textiles\\RegistroTrabajadores.txt");
            string dato = "";
            if (cbcargo.Text == "Atencion al cliente") dato = "n00252,";
            if (cbcargo.Text == "Supervision de Productos") dato = "n00253,";
            if (cbcargo.Text == "Almacenamiento y Administracion") dato = "n00254,";
            dato += txtcodigo.Text + "," + txtnombre.Text + "," + txtdni.Text + "," +
                cbcargo.Text + "," +cbhorario.Text;
            writer.WriteLine(dato);
            writer.Close();
            }
        }
        void EliminarTxt()
        {
            StreamReader reader = new StreamReader("E:\\Documentos\\CICLOS UPN\\Ciclo 4" +
                "\\ESTRUCTURA de DATOS\\" +
                "Evaluaciones\\ProyectoFinal_Textiles\\RegistroTrabajadores.txt");
            StreamWriter writer = File.AppendText("E:\\Documentos\\CICLOS UPN\\Ciclo 4" +
                "\\ESTRUCTURA de DATOS\\" +
                "Evaluaciones\\ProyectoFinal_Textiles\\RegistroTrabajadores1.txt");
            string linea=reader.ReadLine();
            while(linea != null)
            {
                string[] dato = linea.Split(',');
                if(txtcodigo.Text!=dato[1])
                writer.WriteLine(linea);
                else
                { }
                linea = reader.ReadLine();
            }reader.Close();writer.Close();
            File.Delete("E:\\Documentos\\CICLOS UPN\\Ciclo 4" +
                "\\ESTRUCTURA de DATOS\\" +"Evaluaciones\\ProyectoFinal_Textiles\\" +
                "RegistroTrabajadores.txt");//elimina el viejo
            File.Move("E:\\Documentos\\CICLOS UPN\\Ciclo 4" +
                "\\ESTRUCTURA de DATOS\\" + "Evaluaciones\\ProyectoFinal_Textiles\\" +
                "RegistroTrabajadores1.txt", //reemplaza la copia por el viejo.
                "E:\\Documentos\\CICLOS UPN\\Ciclo 4" +
                "\\ESTRUCTURA de DATOS\\" + "Evaluaciones\\ProyectoFinal_Textiles\\" +
                "RegistroTrabajadores.txt");

        }
        void InsertarAux()//lee el txt de base de datos
        {
            StreamReader reader = new StreamReader("E:\\Documentos\\CICLOS UPN\\Ciclo 4" +
                "\\ESTRUCTURA de DATOS\\" +
                "Evaluaciones\\ProyectoFinal_Textiles\\RegistroTrabajadores.txt");
            string linea=reader.ReadLine();
            while(linea!=""&&linea!=null)
            {
                string[] dato = linea.Split(',');
                txtcodigo.Text=dato[0];cod1=dato[1];txtnombre.Text=dato[2];txtdni.Text = dato[3];
                cbcargo.Text = dato[4];cbhorario.Text=dato[5];
                Insertar(0);
                linea=reader.ReadLine();
            }reader.Close();cod1 = ""; LlenarTreeView();
        }
        void NodoSeleccionado(NodoArbol nodo)
        {
            seleccionado = nodo;
            lblnodoselec.Text = "Cargo Seleccionado: " + nodo.nombre;
            if (!(seleccionado == raiz.hijo || seleccionado == raiz.hijo.hermano ||
                seleccionado == raiz.hijo.hermano.hermano))
                lblnodoselec.Text = "";
        }
        void limpiar()
        {
            txtcodigo.Text = "";
            txtdni.Text = "";
            txtnombre.Text = "";
            cbcargo.Text = "";
            cbhorario.Text = "";
            
        }
        void Insertar(int i)
        {
            //podemos ingresar con el codigo reservado de cada cargo, esto es mas para insertar datos ya guardados
            NodoArbol aux = buscar(txtcodigo.Text, raiz);
            if (aux != null)
            {
                if (aux.codigo == "n00252" || aux.codigo == "n00253" || aux.codigo == "n00254")
                {
                    seleccionado = aux; string codig = cod1;
                    if (codig == "")
                    {
                        Random rnd = new Random();
                        codig = "0" + rnd.Next(1, 10000000);
                        while (buscar(codig, raiz) != null)
                            codig = "0" + rnd.Next(1, 10000000);
                    }
                    txtcodigo.Text = codig;
                }
            }
            if (seleccionado != raiz && seleccionado != null && seleccionado.nombre == cbcargo.Text)
            {
                if (txtcodigo.Text != "" && txtdni.Text != "" && txtdni.Text != "" && cbcargo.Text != ""
                    && cbhorario.Text != "")
                {
                    bool flag = false;
                    string cod = txtcodigo.Text;
                    if (seleccionado.hijo == null && buscar(txtcodigo.Text, raiz) == null)
                    {
                        seleccionado.hijo = new NodoArbol(cod, txtnombre.Text,
                            txtdni.Text, cbcargo.Text, cbhorario.Text);
                        flag = true;
                    }
                    else
                    {
                        if (buscar(txtcodigo.Text, raiz) == null)
                        {
                            NodoArbol hermanito = seleccionado.hijo;
                            while (hermanito.hermano != null)
                                hermanito = hermanito.hermano;
                            if (hermanito.hermano == null)
                            {
                                hermanito.hermano = new NodoArbol(cod, txtnombre.Text,
                                txtdni.Text, cbcargo.Text, cbhorario.Text);
                                
                                flag = true;
                            }
                        }
                    }
                    if (flag == false)
                        MessageBox.Show("El código ya existe, seleccione otro", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        if (i == 1)
                            MessageBox.Show($"Bienvenido: \nCódigo: {cod}\nNombre: " +
                                $"{txtnombre.Text}\nDNI: {txtdni.Text}\nCargo: {cbcargo.Text}" +
                                $"\nHorario: {cbhorario.Text}", "Usuario nuevo",MessageBoxButtons.OK);
                        GuardarTxt(i);
                        limpiar();
                        LlenarTreeView();
                        seleccionado = null; lblnodoselec.Text = "";
                        if(i==1)flagult = true;
                    }
                }
                else
                    MessageBox.Show("Necesita rellenar todos los datos para poder registrar " +
                        "un nuevo Usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Seleccione un cargo adecuado", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            LlenarTreeView();
        }
        private void btninsetar_Click(object sender, EventArgs e)
        {
            string ejem = txtnombre.Text.ToLower();
            if(!(ejem == "cargos de la empresa"|| ejem == "atencion al cliente"
                || ejem == "supervision de productos"|| ejem == "almacenamiento y administracion"))
            { Insertar(1);//lleva 1 porque los datos que se inserten al arbol, se iran al archivo txt
              if(flagult==true)
                  groupBox1.Enabled = false; flagult = false; 
            }else
                MessageBox.Show("No use nombres Reservados", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {//aparte de seleccionar el nodo, deshabilitara las casillas si que esta seleccionada
            //alguna casilla con dato previo nuestro o la raiz. Asi podremos visualizar el dato
            NodoSeleccionado((NodoArbol)e.Node.Tag);
            if (!(seleccionado == raiz.hijo || seleccionado == raiz.hijo.hermano ||
                seleccionado == raiz.hijo.hermano.hermano))
            {
                if (seleccionado == raiz)
                { txtnombre.Text = ""; txtcodigo.Text = "";                   
                    cbcargo.Text = ""; 
                }
                else { 
                txtcodigo.Text = seleccionado.codigo; 
                txtdni.Text = seleccionado.dni; 
                txtnombre.Text = seleccionado.nombre;                 
                cbcargo.Text = seleccionado.cargo; 
                cbhorario.Text = seleccionado.horario;
                }
                txtcodigo.Enabled = false; cbhorario.Enabled = false; cbcargo.Enabled = false;
                txtnombre.Enabled = false; txtdni.Enabled = false;
            }
            else
            {
                txtcodigo.Enabled = true;
                txtdni.Enabled = true;
                txtnombre.Enabled = true;
                cbcargo.Enabled = true;
                cbhorario.Enabled = true;
                limpiar();
                cbcargo.Text = seleccionado.nombre;
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            bool flag = false;bool flageliminar = false;
           if(!(seleccionado == raiz.hijo || seleccionado == raiz.hijo.hermano ||
                seleccionado == raiz.hijo.hermano.hermano||seleccionado==raiz))
            {
                if (seleccionado != null)
                {
                    if(buscar(seleccionado.codigo,raiz)!=null)
                    {
                        flag = true;
                        DialogResult r = MessageBox.Show($"Se eliminara es usuario {seleccionado.nombre}" +
                            $", desea continuar?", "Consulta", MessageBoxButtons.YesNo);
                        if (r == DialogResult.Yes)
                        {  flageliminar = Eliminar(seleccionado.codigo);
                           
                        }
                    }
                }
                
            }
            if (txtcodigo.Text != "" && flag == false)
            {
                NodoArbol ab = buscar(txtcodigo.Text, raiz);
                if (ab != null)
                {
                    flag = true;
                    DialogResult r = MessageBox.Show($"Se eliminara es usuario {ab.nombre}" +
                            $", desea continuar?", "Consulta", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        flageliminar = Eliminar(txtcodigo.Text); 
                    }
                    
                }
            }
            if (flag == true && flageliminar == true)
            {
                LlenarTreeView();
                EliminarTxt();
                limpiar();
            }
            if (flag == false)
                MessageBox.Show("Código incorrecto o aun no ha seleccionado un dato para eliminarlo ",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        void MostrarNodo(NodoArbol n, TreeNode padre)
        {
            if (n == null) return;
            TreeNode Nodonuevo = new TreeNode();
            if (padre == null)
            {
                padre = new TreeNode();
                Nodonuevo.Text = n.nombre;
                Nodonuevo.Tag = n;
                treeView1.Nodes.Add(Nodonuevo);
            }
            else
            {
                if (!(n == raiz.hijo || n == raiz.hijo.hermano ||
                n == raiz.hijo.hermano.hermano))
                    Nodonuevo.Text = $"{n.nombre} ({n.codigo})";
                else
                    Nodonuevo.Text = $"{n.nombre}";
                Nodonuevo.Tag = n;
                padre.Nodes.Add(Nodonuevo);
            }
            if (n.hijo != null)
                MostrarNodo(n.hijo, Nodonuevo);
            if (n.hermano != null)
                MostrarNodo(n.hermano, padre);
        }
        void LlenarTreeView()
        {
            treeView1.Nodes.Clear();
            MostrarNodo(raiz, null);
            treeView1.ExpandAll();
        }
        NodoArbol Eliminar(NodoArbol nodo,string cod)//i=0 busca  i=1 eliminar
        {//si el dato a eliminar tiene hermanos, estos se mueven al dato eliminado
            if(cod == nodo.codigo)
            {
                if(nodo.hermano!=null)
                {
                    NodoArbol temp = nodo;
                    temp = null;
                    nodo=nodo.hermano;
                }
                else
                  nodo = null;

            }
            if (nodo != null) { 
            if(nodo.hijo!=null) nodo.hijo= Eliminar(nodo.hijo,cod);
            if (nodo.hermano != null) nodo.hermano = Eliminar(nodo.hermano,cod );
            }
            return nodo;
        }
        bool Eliminar(string a)
        {//verifica si existe el dato y luego lo elimina
            bool t1 = false, t2 = false;
            if (buscar(a, raiz) != null) t1 = true;
             Eliminar( raiz, a);
            if (buscar(a, raiz) == null) t2 = true;
            if (t1 && t2)
            { MessageBox.Show("Se ha eliminado el Usuario"); return true; }
            else
            { 
                return false;
            }
        }

         NodoArbol buscar(string cod,NodoArbol tn)//da null si no esta
        {
            NodoArbol encontrado = null;
            if (tn == null) return encontrado;
            if (cod == tn.codigo) return tn;
            if (tn.hijo != null)//procesa hijos
            {
                encontrado = buscar(cod, tn.hijo);
                if (encontrado != null)
                    return encontrado;
            }
            if (tn.hermano != null)//procesa hermano
            {
                encontrado = buscar(cod, tn.hermano);
                if (encontrado != null)
                    return encontrado;
            }
            return encontrado;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            //if(txtcodigo.Text==)
            buscar(txtcodigo.Text);
            
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            limpiar();seleccionado = null;lblnodoselec.Text = "";
            txtcodigo.Enabled = true;
            txtdni.Enabled = true;
            txtnombre.Enabled = true;
            cbcargo.Enabled = true;
            cbhorario.Enabled = true;
        }

        void buscar(string a)
        {
            NodoArbol ab = buscar(a, raiz);
            if ( ab!= null)
            { MessageBox.Show($"Si se encuentra el usuario del código {a}");
                txtnombre.Text = ab.nombre;txtdni.Text = ab.dni;cbcargo.Text = ab.cargo;
                cbhorario.Text = ab.horario;
            }
            else
                MessageBox.Show($"No se encuentra el usuario del código {a}");
        }
    }
}