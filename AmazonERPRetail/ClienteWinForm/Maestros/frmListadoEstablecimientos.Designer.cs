namespace ClienteWinForm.Maestros
{
    partial class frmListadoEstablecimientos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label5;
            this.panel2 = new System.Windows.Forms.Panel();
            this.btBuscarEmpresa = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRuc = new System.Windows.Forms.Label();
            this.lblCodigoEmpresa = new System.Windows.Forms.Label();
            this.lblRazon = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboEstablecimiento = new System.Windows.Forms.ComboBox();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvEstablecimientos = new MyDataGridViewAgrupado.DataGridViewAgrupado();
            this.btInsertarZona = new System.Windows.Forms.Button();
            this.btBorrarZona = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.button1 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.btInsertarInfluencia = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btQuitarInfluencia = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstablecimientos)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(293, 27);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 13);
            label1.TabIndex = 1004;
            label1.Text = "Zona";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(46, 27);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(33, 13);
            label5.TabIndex = 1005;
            label5.Text = "Local";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btBuscarEmpresa);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblRuc);
            this.panel2.Controls.Add(this.lblCodigoEmpresa);
            this.panel2.Controls.Add(this.lblRazon);
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(633, 62);
            this.panel2.TabIndex = 253;
            // 
            // btBuscarEmpresa
            // 
            this.btBuscarEmpresa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarEmpresa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarEmpresa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarEmpresa.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarEmpresa.Location = new System.Drawing.Point(593, 32);
            this.btBuscarEmpresa.Name = "btBuscarEmpresa";
            this.btBuscarEmpresa.Size = new System.Drawing.Size(25, 20);
            this.btBuscarEmpresa.TabIndex = 320;
            this.btBuscarEmpresa.UseVisualStyleBackColor = true;
            this.btBuscarEmpresa.Click += new System.EventHandler(this.btBuscarEmpresa_Click);
            // 
            // button2
            // 
            this.button2.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button2.Location = new System.Drawing.Point(1217, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 59);
            this.button2.TabIndex = 154;
            this.button2.Text = "BUSCAR";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(494, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 21);
            this.label4.TabIndex = 252;
            this.label4.Text = "RUC";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(43, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(452, 21);
            this.label3.TabIndex = 251;
            this.label3.Text = "Razón Social";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 21);
            this.label2.TabIndex = 247;
            this.label2.Text = "Cod";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRuc
            // 
            this.lblRuc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRuc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuc.Location = new System.Drawing.Point(494, 30);
            this.lblRuc.Name = "lblRuc";
            this.lblRuc.Size = new System.Drawing.Size(97, 23);
            this.lblRuc.TabIndex = 250;
            this.lblRuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCodigoEmpresa
            // 
            this.lblCodigoEmpresa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCodigoEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCodigoEmpresa.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoEmpresa.Location = new System.Drawing.Point(10, 30);
            this.lblCodigoEmpresa.Name = "lblCodigoEmpresa";
            this.lblCodigoEmpresa.Size = new System.Drawing.Size(34, 23);
            this.lblCodigoEmpresa.TabIndex = 248;
            this.lblCodigoEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRazon
            // 
            this.lblRazon.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRazon.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazon.Location = new System.Drawing.Point(43, 30);
            this.lblRazon.Name = "lblRazon";
            this.lblRazon.Size = new System.Drawing.Size(452, 23);
            this.lblRazon.TabIndex = 249;
            this.lblRazon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(label5);
            this.panel1.Controls.Add(label1);
            this.panel1.Controls.Add(this.cboEstablecimiento);
            this.panel1.Controls.Add(this.cboSucursal);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(5, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 53);
            this.panel1.TabIndex = 321;
            // 
            // cboEstablecimiento
            // 
            this.cboEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstablecimiento.FormattingEnabled = true;
            this.cboEstablecimiento.Location = new System.Drawing.Point(327, 23);
            this.cboEstablecimiento.Name = "cboEstablecimiento";
            this.cboEstablecimiento.Size = new System.Drawing.Size(241, 21);
            this.cboEstablecimiento.TabIndex = 1003;
            this.cboEstablecimiento.SelectionChangeCommitted += new System.EventHandler(this.cboEstablecimiento_SelectionChangeCommitted);
            // 
            // cboSucursal
            // 
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(82, 23);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(187, 21);
            this.cboSucursal.TabIndex = 1002;
            this.cboSucursal.SelectionChangeCommitted += new System.EventHandler(this.cboSucursal_SelectionChangeCommitted);
            // 
            // button3
            // 
            this.button3.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button3.Location = new System.Drawing.Point(1217, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 59);
            this.button3.TabIndex = 154;
            this.button3.Text = "BUSCAR";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvEstablecimientos);
            this.panel3.Controls.Add(this.lblRegistros);
            this.panel3.Location = new System.Drawing.Point(5, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(633, 293);
            this.panel3.TabIndex = 322;
            // 
            // dgvEstablecimientos
            // 
            this.dgvEstablecimientos.AllowUserToAddRows = false;
            this.dgvEstablecimientos.AllowUserToDeleteRows = false;
            this.dgvEstablecimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstablecimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEstablecimientos.EnableHeadersVisualStyles = false;
            this.dgvEstablecimientos.GrupoColumnas = null;
            this.dgvEstablecimientos.Location = new System.Drawing.Point(0, 18);
            this.dgvEstablecimientos.Name = "dgvEstablecimientos";
            this.dgvEstablecimientos.ReadOnly = true;
            this.dgvEstablecimientos.Size = new System.Drawing.Size(631, 273);
            this.dgvEstablecimientos.TabIndex = 255;
            this.dgvEstablecimientos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstablecimientos_CellDoubleClick);
            // 
            // btInsertarZona
            // 
            this.btInsertarZona.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btInsertarZona.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btInsertarZona.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btInsertarZona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInsertarZona.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btInsertarZona.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInsertarZona.Location = new System.Drawing.Point(108, 3);
            this.btInsertarZona.Name = "btInsertarZona";
            this.btInsertarZona.Size = new System.Drawing.Size(71, 21);
            this.btInsertarZona.TabIndex = 1566;
            this.btInsertarZona.TabStop = false;
            this.btInsertarZona.Text = "Nuevo";
            this.btInsertarZona.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInsertarZona.UseVisualStyleBackColor = true;
            this.btInsertarZona.Click += new System.EventHandler(this.btInsertarZona_Click);
            // 
            // btBorrarZona
            // 
            this.btBorrarZona.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBorrarZona.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btBorrarZona.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBorrarZona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBorrarZona.Image = global::ClienteWinForm.Properties.Resources.Row_Delete_16x16;
            this.btBorrarZona.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBorrarZona.Location = new System.Drawing.Point(182, 3);
            this.btBorrarZona.Name = "btBorrarZona";
            this.btBorrarZona.Size = new System.Drawing.Size(71, 21);
            this.btBorrarZona.TabIndex = 1567;
            this.btBorrarZona.TabStop = false;
            this.btBorrarZona.Text = "Eliminar";
            this.btBorrarZona.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBorrarZona.UseVisualStyleBackColor = true;
            this.btBorrarZona.Click += new System.EventHandler(this.btBorrarZona_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.labelDegradado1);
            this.panel4.Controls.Add(this.btInsertarZona);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.btBorrarZona);
            this.panel4.Location = new System.Drawing.Point(74, 419);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(259, 30);
            this.panel4.TabIndex = 1568;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.Black;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.labelDegradado1.SegundoColor = System.Drawing.Color.White;
            this.labelDegradado1.Size = new System.Drawing.Size(90, 28);
            this.labelDegradado1.TabIndex = 321;
            this.labelDegradado1.Text = "Zona";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.labelDegradado3);
            this.panel5.Controls.Add(this.btInsertarInfluencia);
            this.panel5.Controls.Add(this.button5);
            this.panel5.Controls.Add(this.btQuitarInfluencia);
            this.panel5.Location = new System.Drawing.Point(336, 419);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(302, 30);
            this.panel5.TabIndex = 1569;
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.Black;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.labelDegradado3.SegundoColor = System.Drawing.Color.White;
            this.labelDegradado3.Size = new System.Drawing.Size(146, 28);
            this.labelDegradado3.TabIndex = 321;
            this.labelDegradado3.Text = "Zona de Influencia";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btInsertarInfluencia
            // 
            this.btInsertarInfluencia.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btInsertarInfluencia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btInsertarInfluencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btInsertarInfluencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInsertarInfluencia.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btInsertarInfluencia.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInsertarInfluencia.Location = new System.Drawing.Point(149, 3);
            this.btInsertarInfluencia.Name = "btInsertarInfluencia";
            this.btInsertarInfluencia.Size = new System.Drawing.Size(71, 21);
            this.btInsertarInfluencia.TabIndex = 1566;
            this.btInsertarInfluencia.TabStop = false;
            this.btInsertarInfluencia.Text = "Nuevo";
            this.btInsertarInfluencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInsertarInfluencia.UseVisualStyleBackColor = true;
            this.btInsertarInfluencia.Click += new System.EventHandler(this.btInsertarInfluencia_Click);
            // 
            // button5
            // 
            this.button5.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button5.Location = new System.Drawing.Point(1217, 33);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 59);
            this.button5.TabIndex = 154;
            this.button5.Text = "BUSCAR";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            // 
            // btQuitarInfluencia
            // 
            this.btQuitarInfluencia.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btQuitarInfluencia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btQuitarInfluencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btQuitarInfluencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQuitarInfluencia.Image = global::ClienteWinForm.Properties.Resources.Row_Delete_16x16;
            this.btQuitarInfluencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btQuitarInfluencia.Location = new System.Drawing.Point(223, 3);
            this.btQuitarInfluencia.Name = "btQuitarInfluencia";
            this.btQuitarInfluencia.Size = new System.Drawing.Size(71, 21);
            this.btQuitarInfluencia.TabIndex = 1567;
            this.btQuitarInfluencia.TabStop = false;
            this.btQuitarInfluencia.Text = "Eliminar";
            this.btQuitarInfluencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btQuitarInfluencia.UseVisualStyleBackColor = true;
            this.btQuitarInfluencia.Click += new System.EventHandler(this.btQuitarInfluencia_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(631, 18);
            this.label8.TabIndex = 1006;
            this.label8.Text = "Parámetros de Búsqueda";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(631, 18);
            this.lblRegistros.TabIndex = 429;
            this.lblRegistros.Text = "Datos Principales";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoEstablecimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 452);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmListadoEstablecimientos";
            this.Text = "Listado de Zonas";
            this.Load += new System.EventHandler(this.frmListadoEstablecimientos_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstablecimientos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btBuscarEmpresa;
        protected internal System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRuc;
        private System.Windows.Forms.Label lblCodigoEmpresa;
        private System.Windows.Forms.Label lblRazon;
        private System.Windows.Forms.Panel panel1;
        protected internal System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboSucursal;
        private MyDataGridViewAgrupado.DataGridViewAgrupado dgvEstablecimientos;
        private System.Windows.Forms.ComboBox cboEstablecimiento;
        private System.Windows.Forms.Button btInsertarZona;
        private System.Windows.Forms.Button btBorrarZona;
        private System.Windows.Forms.Panel panel4;
        private MyLabelG.LabelDegradado labelDegradado1;
        protected internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel5;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.Button btInsertarInfluencia;
        protected internal System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btQuitarInfluencia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRegistros;
    }
}