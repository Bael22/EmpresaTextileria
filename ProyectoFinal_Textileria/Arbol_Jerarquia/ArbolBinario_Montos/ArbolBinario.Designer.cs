namespace Proyecto_Textileria.ArbolBinario_Montos
{
    partial class ArbolBinario
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbtningresar = new System.Windows.Forms.Button();
            this.tbtneliminar = new System.Windows.Forms.Button();
            this.tbtnbuscar = new System.Windows.Forms.Button();
            this.ttxtoperacion = new System.Windows.Forms.TextBox();
            this.tbtnPreorden = new System.Windows.Forms.Button();
            this.tbtnpostorden = new System.Windows.Forms.Button();
            this.tbtninorden = new System.Windows.Forms.Button();
            this.ttxtrecorrido = new System.Windows.Forms.TextBox();
            this.tlblrecorrido = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblmenor = new System.Windows.Forms.Label();
            this.lblmayor = new System.Windows.Forms.Label();
            this.tlblnumelementos = new System.Windows.Forms.Label();
            this.tlblaltura = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 75);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(231, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Árbol Binario de Montos";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tbtningresar);
            this.groupBox1.Controls.Add(this.tbtneliminar);
            this.groupBox1.Controls.Add(this.tbtnbuscar);
            this.groupBox1.Controls.Add(this.ttxtoperacion);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(0, 477);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(953, 60);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operaciones";
            // 
            // tbtningresar
            // 
            this.tbtningresar.BackColor = System.Drawing.Color.Transparent;
            this.tbtningresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbtningresar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbtningresar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbtningresar.Location = new System.Drawing.Point(174, 22);
            this.tbtningresar.Name = "tbtningresar";
            this.tbtningresar.Size = new System.Drawing.Size(190, 30);
            this.tbtningresar.TabIndex = 1;
            this.tbtningresar.Text = "Ingresar";
            this.tbtningresar.UseVisualStyleBackColor = false;
            this.tbtningresar.Click += new System.EventHandler(this.tbtningresar_Click);
            // 
            // tbtneliminar
            // 
            this.tbtneliminar.BackColor = System.Drawing.Color.Transparent;
            this.tbtneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbtneliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbtneliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbtneliminar.Location = new System.Drawing.Point(370, 22);
            this.tbtneliminar.Name = "tbtneliminar";
            this.tbtneliminar.Size = new System.Drawing.Size(188, 30);
            this.tbtneliminar.TabIndex = 1;
            this.tbtneliminar.Text = "Eliminar";
            this.tbtneliminar.UseVisualStyleBackColor = false;
            this.tbtneliminar.Click += new System.EventHandler(this.tbtneliminar_Click);
            // 
            // tbtnbuscar
            // 
            this.tbtnbuscar.BackColor = System.Drawing.Color.Transparent;
            this.tbtnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbtnbuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbtnbuscar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbtnbuscar.Location = new System.Drawing.Point(564, 22);
            this.tbtnbuscar.Name = "tbtnbuscar";
            this.tbtnbuscar.Size = new System.Drawing.Size(187, 30);
            this.tbtnbuscar.TabIndex = 1;
            this.tbtnbuscar.Text = "Buscar";
            this.tbtnbuscar.UseVisualStyleBackColor = false;
            this.tbtnbuscar.Click += new System.EventHandler(this.tbtnbuscar_Click);
            // 
            // ttxtoperacion
            // 
            this.ttxtoperacion.Location = new System.Drawing.Point(12, 22);
            this.ttxtoperacion.Name = "ttxtoperacion";
            this.ttxtoperacion.Size = new System.Drawing.Size(145, 27);
            this.ttxtoperacion.TabIndex = 0;
            // 
            // tbtnPreorden
            // 
            this.tbtnPreorden.BackColor = System.Drawing.Color.Transparent;
            this.tbtnPreorden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbtnPreorden.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tbtnPreorden.Location = new System.Drawing.Point(10, 174);
            this.tbtnPreorden.Name = "tbtnPreorden";
            this.tbtnPreorden.Size = new System.Drawing.Size(139, 50);
            this.tbtnPreorden.TabIndex = 2;
            this.tbtnPreorden.Text = "Recorrido PreOrden";
            this.tbtnPreorden.UseVisualStyleBackColor = false;
            this.tbtnPreorden.Click += new System.EventHandler(this.tbtnPreorden_Click);
            // 
            // tbtnpostorden
            // 
            this.tbtnpostorden.BackColor = System.Drawing.Color.Transparent;
            this.tbtnpostorden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbtnpostorden.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tbtnpostorden.Location = new System.Drawing.Point(10, 231);
            this.tbtnpostorden.Name = "tbtnpostorden";
            this.tbtnpostorden.Size = new System.Drawing.Size(139, 53);
            this.tbtnpostorden.TabIndex = 2;
            this.tbtnpostorden.Text = "Recorrido PostOrden";
            this.tbtnpostorden.UseVisualStyleBackColor = false;
            this.tbtnpostorden.Click += new System.EventHandler(this.tbtnpostorden_Click);
            // 
            // tbtninorden
            // 
            this.tbtninorden.BackColor = System.Drawing.Color.Transparent;
            this.tbtninorden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbtninorden.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tbtninorden.Location = new System.Drawing.Point(10, 290);
            this.tbtninorden.Name = "tbtninorden";
            this.tbtninorden.Size = new System.Drawing.Size(139, 55);
            this.tbtninorden.TabIndex = 2;
            this.tbtninorden.Text = "Recorrido InOrden";
            this.tbtninorden.UseVisualStyleBackColor = false;
            this.tbtninorden.Click += new System.EventHandler(this.button1_Click);
            // 
            // ttxtrecorrido
            // 
            this.ttxtrecorrido.Location = new System.Drawing.Point(6, 449);
            this.ttxtrecorrido.Name = "ttxtrecorrido";
            this.ttxtrecorrido.Size = new System.Drawing.Size(941, 27);
            this.ttxtrecorrido.TabIndex = 3;
            // 
            // tlblrecorrido
            // 
            this.tlblrecorrido.AutoSize = true;
            this.tlblrecorrido.BackColor = System.Drawing.Color.Transparent;
            this.tlblrecorrido.Location = new System.Drawing.Point(15, 426);
            this.tlblrecorrido.Name = "tlblrecorrido";
            this.tlblrecorrido.Size = new System.Drawing.Size(33, 20);
            this.tlblrecorrido.TabIndex = 4;
            this.tlblrecorrido.Text = "      ";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lblmenor);
            this.groupBox2.Controls.Add(this.lblmayor);
            this.groupBox2.Controls.Add(this.tlblnumelementos);
            this.groupBox2.Controls.Add(this.tlblaltura);
            this.groupBox2.Controls.Add(this.tbtnPreorden);
            this.groupBox2.Controls.Add(this.tbtninorden);
            this.groupBox2.Controls.Add(this.tbtnpostorden);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(798, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 354);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cuadro de Detalle";
            // 
            // lblmenor
            // 
            this.lblmenor.AutoSize = true;
            this.lblmenor.Location = new System.Drawing.Point(22, 71);
            this.lblmenor.Name = "lblmenor";
            this.lblmenor.Size = new System.Drawing.Size(106, 20);
            this.lblmenor.TabIndex = 6;
            this.lblmenor.Text = "Monto Menor";
            // 
            // lblmayor
            // 
            this.lblmayor.AutoSize = true;
            this.lblmayor.Location = new System.Drawing.Point(23, 23);
            this.lblmayor.Name = "lblmayor";
            this.lblmayor.Size = new System.Drawing.Size(105, 20);
            this.lblmayor.TabIndex = 6;
            this.lblmayor.Text = "Monto Mayor";
            // 
            // tlblnumelementos
            // 
            this.tlblnumelementos.AutoSize = true;
            this.tlblnumelementos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tlblnumelementos.Location = new System.Drawing.Point(23, 140);
            this.tlblnumelementos.Name = "tlblnumelementos";
            this.tlblnumelementos.Size = new System.Drawing.Size(105, 20);
            this.tlblnumelementos.TabIndex = 3;
            this.tlblnumelementos.Text = "Nº Elementos";
            // 
            // tlblaltura
            // 
            this.tlblaltura.AutoSize = true;
            this.tlblaltura.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tlblaltura.Location = new System.Drawing.Point(43, 115);
            this.tlblaltura.Name = "tlblaltura";
            this.tlblaltura.Size = new System.Drawing.Size(53, 20);
            this.tlblaltura.TabIndex = 3;
            this.tlblaltura.Text = "Altura";
            // 
            // ArbolBinario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BackgroundImage = global::Proyecto_Textileria.Properties.Resources.background_g7d8825848_1920;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(953, 537);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tlblrecorrido);
            this.Controls.Add(this.ttxtrecorrido);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ArbolBinario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Árbol Binario";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private GroupBox groupBox1;
        private Button tbtningresar;
        private Button tbtneliminar;
        private Button tbtnbuscar;
        private TextBox ttxtoperacion;
        private TextBox ttxtrecorrido;
        private Label tlblrecorrido;
        private Button tbtnPreorden;
        private Button tbtnpostorden;
        private Button tbtninorden;
        private GroupBox groupBox2;
        private Label tlblnumelementos;
        private Label tlblaltura;
        private Label lblmayor;
        private Label lblmenor;
    }
}