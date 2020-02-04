namespace ClienteWinForm.Contabilidad
{
    partial class frmEEFFItemCta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListadoEEFF = new System.Windows.Forms.DataGridView();
            this.bsEEFFItemCta = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCuenta = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCuenta = new ControlesWinForm.SuperTextBox();
            this.txtDesCuenta = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cboNivel = new System.Windows.Forms.ComboBox();
            this.cboCondicion = new System.Windows.Forms.ComboBox();
            this.lbltitulo = new MyLabelG.LabelDegradado();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuRegistro = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtUsuModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.idEEFFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEEFFItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEEFFItemCtaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPlaCtaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCondicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoNivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEEFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEEFFItemCta)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(546, 498);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCancelar.Size = new System.Drawing.Size(174, 37);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(366, 498);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAceptar.Size = new System.Drawing.Size(174, 37);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitPnlBase.Size = new System.Drawing.Size(386, 34);
            this.lblTitPnlBase.Text = "Auditoria";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTituloPrincipal.Size = new System.Drawing.Size(1095, 38);
            this.lblTituloPrincipal.Text = "Agregar Cuenta ";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(1052, 3);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.label24);
            this.pnlBase.Controls.Add(this.txtFechaModificacion);
            this.pnlBase.Controls.Add(this.txtUsuRegistro);
            this.pnlBase.Controls.Add(this.label25);
            this.pnlBase.Controls.Add(this.label29);
            this.pnlBase.Controls.Add(this.txtUsuModificacion);
            this.pnlBase.Controls.Add(this.txtFechaRegistro);
            this.pnlBase.Controls.Add(this.label31);
            this.pnlBase.Location = new System.Drawing.Point(688, 309);
            this.pnlBase.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.pnlBase.Size = new System.Drawing.Size(388, 179);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.label31, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtFechaRegistro, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtUsuModificacion, 0);
            this.pnlBase.Controls.SetChildIndex(this.label29, 0);
            this.pnlBase.Controls.SetChildIndex(this.label25, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtUsuRegistro, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtFechaModificacion, 0);
            this.pnlBase.Controls.SetChildIndex(this.label24, 0);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvListadoEEFF);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(9, 52);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1076, 253);
            this.panel5.TabIndex = 263;
            // 
            // dgvListadoEEFF
            // 
            this.dgvListadoEEFF.AllowUserToAddRows = false;
            this.dgvListadoEEFF.AllowUserToDeleteRows = false;
            this.dgvListadoEEFF.AutoGenerateColumns = false;
            this.dgvListadoEEFF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoEEFF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEEFFDataGridViewTextBoxColumn,
            this.Column1,
            this.idEEFFItemDataGridViewTextBoxColumn,
            this.idEEFFItemCtaDataGridViewTextBoxColumn,
            this.codPlaCtaDataGridViewTextBoxColumn,
            this.desCuenta,
            this.tipoCondicionDataGridViewTextBoxColumn,
            this.DesNivel,
            this.tipoNivelDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvListadoEEFF.DataSource = this.bsEEFFItemCta;
            this.dgvListadoEEFF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListadoEEFF.EnableHeadersVisualStyles = false;
            this.dgvListadoEEFF.Location = new System.Drawing.Point(0, 35);
            this.dgvListadoEEFF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvListadoEEFF.Name = "dgvListadoEEFF";
            this.dgvListadoEEFF.ReadOnly = true;
            this.dgvListadoEEFF.Size = new System.Drawing.Size(1074, 216);
            this.dgvListadoEEFF.TabIndex = 248;
            this.dgvListadoEEFF.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoEEFF_CellClick);
            // 
            // bsEEFFItemCta
            // 
            this.bsEEFFItemCta.DataSource = typeof(Entidades.Contabilidad.EEFFItemCtaE);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(1074, 35);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Cuentas - Registros";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btCuenta);
            this.panel1.Controls.Add(this.btnQuitar);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.txtCuenta);
            this.panel1.Controls.Add(this.txtDesCuenta);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.cboNivel);
            this.panel1.Controls.Add(this.cboCondicion);
            this.panel1.Controls.Add(this.lbltitulo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(10, 309);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 179);
            this.panel1.TabIndex = 266;
            // 
            // btCuenta
            // 
            this.btCuenta.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCuenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCuenta.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCuenta.Location = new System.Drawing.Point(618, 114);
            this.btCuenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCuenta.Name = "btCuenta";
            this.btCuenta.Size = new System.Drawing.Size(38, 31);
            this.btCuenta.TabIndex = 326;
            this.btCuenta.UseVisualStyleBackColor = true;
            this.btCuenta.Click += new System.EventHandler(this.btCuenta_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(570, -2);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(86, 35);
            this.btnQuitar.TabIndex = 269;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(476, -2);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(86, 35);
            this.btnAgregar.TabIndex = 268;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCuenta
            // 
            this.txtCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuenta.BackColor = System.Drawing.Color.White;
            this.txtCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuenta.Location = new System.Drawing.Point(106, 112);
            this.txtCuenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(102, 21);
            this.txtCuenta.TabIndex = 321;
            this.txtCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCuenta.TextoVacio = "<Descripcion>";
            // 
            // txtDesCuenta
            // 
            this.txtDesCuenta.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtDesCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesCuenta.Enabled = false;
            this.txtDesCuenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuenta.Location = new System.Drawing.Point(214, 112);
            this.txtDesCuenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDesCuenta.Name = "txtDesCuenta";
            this.txtDesCuenta.Size = new System.Drawing.Size(398, 21);
            this.txtDesCuenta.TabIndex = 323;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(21, 118);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 13);
            this.label21.TabIndex = 322;
            this.label21.Text = "Cuenta";
            // 
            // cboNivel
            // 
            this.cboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivel.DropDownWidth = 110;
            this.cboNivel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Location = new System.Drawing.Point(106, 77);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(505, 21);
            this.cboNivel.TabIndex = 265;
            // 
            // cboCondicion
            // 
            this.cboCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicion.DropDownWidth = 110;
            this.cboCondicion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCondicion.FormattingEnabled = true;
            this.cboCondicion.Location = new System.Drawing.Point(106, 43);
            this.cboCondicion.Name = "cboCondicion";
            this.cboCondicion.Size = new System.Drawing.Size(505, 21);
            this.cboCondicion.TabIndex = 264;
            // 
            // lbltitulo
            // 
            this.lbltitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltitulo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lbltitulo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.Color.White;
            this.lbltitulo.Location = new System.Drawing.Point(0, 0);
            this.lbltitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.PrimerColor = System.Drawing.Color.SlateGray;
            this.lbltitulo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lbltitulo.Size = new System.Drawing.Size(669, 32);
            this.lbltitulo.TabIndex = 253;
            this.lbltitulo.Text = "Datos";
            this.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Condición";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nivel";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(14, 146);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 13);
            this.label24.TabIndex = 257;
            this.label24.Text = "Fecha Modificacion";
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFechaModificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(176, 138);
            this.txtFechaModificacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(192, 20);
            this.txtFechaModificacion.TabIndex = 258;
            // 
            // txtUsuRegistro
            // 
            this.txtUsuRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuRegistro.Enabled = false;
            this.txtUsuRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistro.Location = new System.Drawing.Point(176, 42);
            this.txtUsuRegistro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuRegistro.Name = "txtUsuRegistro";
            this.txtUsuRegistro.Size = new System.Drawing.Size(192, 20);
            this.txtUsuRegistro.TabIndex = 252;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(14, 114);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(106, 13);
            this.label25.TabIndex = 255;
            this.label25.Text = "Usuario Modificacion";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(14, 49);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(85, 13);
            this.label29.TabIndex = 251;
            this.label29.Text = "Usuario Registro";
            // 
            // txtUsuModificacion
            // 
            this.txtUsuModificacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuModificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuModificacion.Enabled = false;
            this.txtUsuModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModificacion.Location = new System.Drawing.Point(176, 106);
            this.txtUsuModificacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuModificacion.Name = "txtUsuModificacion";
            this.txtUsuModificacion.Size = new System.Drawing.Size(192, 20);
            this.txtUsuModificacion.TabIndex = 256;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFechaRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(176, 74);
            this.txtFechaRegistro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(192, 20);
            this.txtFechaRegistro.TabIndex = 254;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(14, 82);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(79, 13);
            this.label31.TabIndex = 253;
            this.label31.Text = "Fecha Registro";
            // 
            // idEEFFDataGridViewTextBoxColumn
            // 
            this.idEEFFDataGridViewTextBoxColumn.DataPropertyName = "idEEFF";
            this.idEEFFDataGridViewTextBoxColumn.HeaderText = "idEEFF";
            this.idEEFFDataGridViewTextBoxColumn.Name = "idEEFFDataGridViewTextBoxColumn";
            this.idEEFFDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEEFFDataGridViewTextBoxColumn.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "idEmpresa";
            this.Column1.HeaderText = "idEmpresa";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // idEEFFItemDataGridViewTextBoxColumn
            // 
            this.idEEFFItemDataGridViewTextBoxColumn.DataPropertyName = "idEEFFItem";
            this.idEEFFItemDataGridViewTextBoxColumn.HeaderText = "idEEFFItem";
            this.idEEFFItemDataGridViewTextBoxColumn.Name = "idEEFFItemDataGridViewTextBoxColumn";
            this.idEEFFItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEEFFItemDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEEFFItemCtaDataGridViewTextBoxColumn
            // 
            this.idEEFFItemCtaDataGridViewTextBoxColumn.DataPropertyName = "idEEFFItemCta";
            this.idEEFFItemCtaDataGridViewTextBoxColumn.HeaderText = "idEEFFItemCta";
            this.idEEFFItemCtaDataGridViewTextBoxColumn.Name = "idEEFFItemCtaDataGridViewTextBoxColumn";
            this.idEEFFItemCtaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEEFFItemCtaDataGridViewTextBoxColumn.Visible = false;
            // 
            // codPlaCtaDataGridViewTextBoxColumn
            // 
            this.codPlaCtaDataGridViewTextBoxColumn.DataPropertyName = "CodPlaCta";
            this.codPlaCtaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.codPlaCtaDataGridViewTextBoxColumn.Name = "codPlaCtaDataGridViewTextBoxColumn";
            this.codPlaCtaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codPlaCtaDataGridViewTextBoxColumn.Width = 70;
            // 
            // desCuenta
            // 
            this.desCuenta.DataPropertyName = "desCuenta";
            this.desCuenta.HeaderText = "desCuenta";
            this.desCuenta.Name = "desCuenta";
            this.desCuenta.ReadOnly = true;
            this.desCuenta.Width = 300;
            // 
            // tipoCondicionDataGridViewTextBoxColumn
            // 
            this.tipoCondicionDataGridViewTextBoxColumn.DataPropertyName = "TipoCondicion";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipoCondicionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.tipoCondicionDataGridViewTextBoxColumn.HeaderText = "Condición";
            this.tipoCondicionDataGridViewTextBoxColumn.Name = "tipoCondicionDataGridViewTextBoxColumn";
            this.tipoCondicionDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoCondicionDataGridViewTextBoxColumn.Width = 80;
            // 
            // DesNivel
            // 
            this.DesNivel.DataPropertyName = "DesNivel";
            this.DesNivel.HeaderText = "Nivel";
            this.DesNivel.Name = "DesNivel";
            this.DesNivel.ReadOnly = true;
            // 
            // tipoNivelDataGridViewTextBoxColumn
            // 
            this.tipoNivelDataGridViewTextBoxColumn.DataPropertyName = "TipoNivel";
            this.tipoNivelDataGridViewTextBoxColumn.HeaderText = "TipoNivel";
            this.tipoNivelDataGridViewTextBoxColumn.Name = "tipoNivelDataGridViewTextBoxColumn";
            this.tipoNivelDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoNivelDataGridViewTextBoxColumn.Visible = false;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Visible = false;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmEEFFItemCta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 548);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.MaximizeBox = false;
            this.Name = "frmEEFFItemCta";
            this.Text = "Estados Financieros - Plan de Cuentas";
            this.Load += new System.EventHandler(this.frmEEFFItemCta_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEEFFItemCta_KeyPress);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEEFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEEFFItemCta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListadoEEFF;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsEEFFItemCta;
        private System.Windows.Forms.Panel panel1;
        private ControlesWinForm.SuperTextBox txtCuenta;
        private System.Windows.Forms.TextBox txtDesCuenta;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboNivel;
        private System.Windows.Forms.ComboBox cboCondicion;
        private MyLabelG.LabelDegradado lbltitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        //private System.Windows.Forms.DataGridViewTextBoxColumn numPlaCtaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuRegistro;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtUsuModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEEFFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEEFFItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEEFFItemCtaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPlaCtaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCondicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoNivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}