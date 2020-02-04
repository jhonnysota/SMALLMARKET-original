namespace ClienteWinForm.Generales
{
    partial class frmImpuestos
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label oididsjij;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.fechamod = new System.Windows.Forms.TextBox();
            this.usuarioRegistroTextBox = new System.Windows.Forms.TextBox();
            this.usuarioModificacionTextBox = new System.Windows.Forms.TextBox();
            this.txtFechareg = new System.Windows.Forms.TextBox();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.btCuenta = new System.Windows.Forms.Button();
            this.txtDesCuenta = new System.Windows.Forms.TextBox();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.txtDesA = new System.Windows.Forms.TextBox();
            this.txtIdImp = new System.Windows.Forms.TextBox();
            this.pnlDetalles = new System.Windows.Forms.Panel();
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecFinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsImpuestosLista = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            oididsjij = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.pnlAuditoria.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.pnlDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsImpuestosLista)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(11, 100);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(11, 77);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(11, 32);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(11, 54);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // oididsjij
            // 
            oididsjij.AutoSize = true;
            oididsjij.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            oididsjij.Location = new System.Drawing.Point(15, 31);
            oididsjij.Name = "oididsjij";
            oididsjij.Size = new System.Drawing.Size(69, 13);
            oididsjij.TabIndex = 250;
            oididsjij.Text = "Id. Impuesto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(15, 76);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(61, 13);
            label2.TabIndex = 267;
            label2.Text = "Descripción";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(15, 53);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(78, 13);
            label6.TabIndex = 268;
            label6.Text = "Código Cuenta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(15, 100);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(89, 13);
            label7.TabIndex = 269;
            label7.Text = "Des. Abreviatura";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label9);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.fechamod);
            this.pnlAuditoria.Controls.Add(this.usuarioRegistroTextBox);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.usuarioModificacionTextBox);
            this.pnlAuditoria.Controls.Add(this.txtFechareg);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(497, 4);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(262, 128);
            this.pnlAuditoria.TabIndex = 257;
            // 
            // fechamod
            // 
            this.fechamod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.fechamod.Enabled = false;
            this.fechamod.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechamod.Location = new System.Drawing.Point(120, 95);
            this.fechamod.Name = "fechamod";
            this.fechamod.Size = new System.Drawing.Size(125, 21);
            this.fechamod.TabIndex = 7;
            // 
            // usuarioRegistroTextBox
            // 
            this.usuarioRegistroTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.usuarioRegistroTextBox.Enabled = false;
            this.usuarioRegistroTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioRegistroTextBox.Location = new System.Drawing.Point(120, 27);
            this.usuarioRegistroTextBox.Name = "usuarioRegistroTextBox";
            this.usuarioRegistroTextBox.Size = new System.Drawing.Size(125, 21);
            this.usuarioRegistroTextBox.TabIndex = 1;
            // 
            // usuarioModificacionTextBox
            // 
            this.usuarioModificacionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.usuarioModificacionTextBox.Enabled = false;
            this.usuarioModificacionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioModificacionTextBox.Location = new System.Drawing.Point(120, 72);
            this.usuarioModificacionTextBox.Name = "usuarioModificacionTextBox";
            this.usuarioModificacionTextBox.Size = new System.Drawing.Size(125, 21);
            this.usuarioModificacionTextBox.TabIndex = 5;
            // 
            // txtFechareg
            // 
            this.txtFechareg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechareg.Enabled = false;
            this.txtFechareg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechareg.Location = new System.Drawing.Point(120, 49);
            this.txtFechareg.Name = "txtFechareg";
            this.txtFechareg.Size = new System.Drawing.Size(125, 21);
            this.txtFechareg.TabIndex = 3;
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.btCuenta);
            this.pnlDatos.Controls.Add(this.txtDesCuenta);
            this.pnlDatos.Controls.Add(label7);
            this.pnlDatos.Controls.Add(label6);
            this.pnlDatos.Controls.Add(label2);
            this.pnlDatos.Controls.Add(this.txtDes);
            this.pnlDatos.Controls.Add(this.txtCuenta);
            this.pnlDatos.Controls.Add(this.txtDesA);
            this.pnlDatos.Controls.Add(oididsjij);
            this.pnlDatos.Controls.Add(this.txtIdImp);
            this.pnlDatos.Location = new System.Drawing.Point(4, 4);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(489, 128);
            this.pnlDatos.TabIndex = 255;
            // 
            // btCuenta
            // 
            this.btCuenta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCuenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCuenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCuenta.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCuenta.Location = new System.Drawing.Point(446, 49);
            this.btCuenta.Name = "btCuenta";
            this.btCuenta.Size = new System.Drawing.Size(25, 20);
            this.btCuenta.TabIndex = 323;
            this.btCuenta.UseVisualStyleBackColor = true;
            this.btCuenta.Click += new System.EventHandler(this.btCuenta_Click);
            // 
            // txtDesCuenta
            // 
            this.txtDesCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDesCuenta.Enabled = false;
            this.txtDesCuenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuenta.Location = new System.Drawing.Point(188, 49);
            this.txtDesCuenta.Name = "txtDesCuenta";
            this.txtDesCuenta.Size = new System.Drawing.Size(255, 21);
            this.txtDesCuenta.TabIndex = 322;
            // 
            // txtDes
            // 
            this.txtDes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDes.Location = new System.Drawing.Point(116, 72);
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(355, 21);
            this.txtDes.TabIndex = 266;
            // 
            // txtCuenta
            // 
            this.txtCuenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuenta.Location = new System.Drawing.Point(116, 49);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(70, 21);
            this.txtCuenta.TabIndex = 265;
            // 
            // txtDesA
            // 
            this.txtDesA.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesA.Location = new System.Drawing.Point(116, 95);
            this.txtDesA.Name = "txtDesA";
            this.txtDesA.Size = new System.Drawing.Size(355, 21);
            this.txtDesA.TabIndex = 263;
            // 
            // txtIdImp
            // 
            this.txtIdImp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdImp.Location = new System.Drawing.Point(116, 26);
            this.txtIdImp.Name = "txtIdImp";
            this.txtIdImp.Size = new System.Drawing.Size(70, 21);
            this.txtIdImp.TabIndex = 2;
            // 
            // pnlDetalles
            // 
            this.pnlDetalles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalles.Controls.Add(this.dgvDocumentos);
            this.pnlDetalles.Controls.Add(this.lblRegistros);
            this.pnlDetalles.Location = new System.Drawing.Point(4, 135);
            this.pnlDetalles.Name = "pnlDetalles";
            this.pnlDetalles.Size = new System.Drawing.Size(755, 300);
            this.pnlDetalles.TabIndex = 256;
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AutoGenerateColumns = false;
            this.dgvDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemDataGridViewTextBoxColumn,
            this.fecInicioDataGridViewTextBoxColumn,
            this.fecFinDataGridViewTextBoxColumn,
            this.porcentajeDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvDocumentos.DataSource = this.bsImpuestosLista;
            this.dgvDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentos.EnableHeadersVisualStyles = false;
            this.dgvDocumentos.Location = new System.Drawing.Point(0, 18);
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.ReadOnly = true;
            this.dgvDocumentos.Size = new System.Drawing.Size(753, 280);
            this.dgvDocumentos.TabIndex = 5;
            this.dgvDocumentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellDoubleClick_1);
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Item";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fecInicioDataGridViewTextBoxColumn
            // 
            this.fecInicioDataGridViewTextBoxColumn.DataPropertyName = "fecInicio";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecInicioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fecInicioDataGridViewTextBoxColumn.HeaderText = "Fec. Inicio";
            this.fecInicioDataGridViewTextBoxColumn.Name = "fecInicioDataGridViewTextBoxColumn";
            this.fecInicioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fecFinDataGridViewTextBoxColumn
            // 
            this.fecFinDataGridViewTextBoxColumn.DataPropertyName = "fecFin";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecFinDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fecFinDataGridViewTextBoxColumn.HeaderText = "Fec. Fin";
            this.fecFinDataGridViewTextBoxColumn.Name = "fecFinDataGridViewTextBoxColumn";
            this.fecFinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // porcentajeDataGridViewTextBoxColumn
            // 
            this.porcentajeDataGridViewTextBoxColumn.DataPropertyName = "Porcentaje";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.porcentajeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.porcentajeDataGridViewTextBoxColumn.HeaderText = "Porcentaje";
            this.porcentajeDataGridViewTextBoxColumn.Name = "porcentajeDataGridViewTextBoxColumn";
            this.porcentajeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsImpuestosLista
            // 
            this.bsImpuestosLista.DataSource = typeof(Entidades.Generales.ImpuestosPeriodoE);
            this.bsImpuestosLista.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsImpuestosLista_ListChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(487, 18);
            this.label8.TabIndex = 429;
            this.label8.Text = "Datos Principales";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(260, 18);
            this.label9.TabIndex = 347;
            this.label9.Text = "Auditoria";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(753, 18);
            this.lblRegistros.TabIndex = 429;
            this.lblRegistros.Text = "Documentos";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(764, 439);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlDetalles);
            this.Name = "frmImpuestos";
            this.Text = "Impuestos";
            this.Activated += new System.EventHandler(this.frmImpuestos_Activated);
            this.Load += new System.EventHandler(this.frmImpuestos_Load);
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlDetalles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsImpuestosLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox fechamod;
        private System.Windows.Forms.TextBox usuarioRegistroTextBox;
        private System.Windows.Forms.TextBox usuarioModificacionTextBox;
        private System.Windows.Forms.TextBox txtFechareg;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.TextBox txtIdImp;
        private System.Windows.Forms.Panel pnlDetalles;
        private System.Windows.Forms.DataGridView dgvDocumentos;
        private System.Windows.Forms.BindingSource bsImpuestosLista;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.TextBox txtDesA;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecFinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btCuenta;
        private System.Windows.Forms.TextBox txtDesCuenta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRegistros;
    }
}