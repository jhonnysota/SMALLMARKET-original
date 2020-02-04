namespace ClienteWinForm.Maestros
{
    partial class frmBancos
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
            this.bsCuentasBancarias = new System.Windows.Forms.BindingSource(this.components);
            this.pnlCondicion = new System.Windows.Forms.Panel();
            this.txtFecBaja = new ControlesWinForm.SuperTextBox();
            this.chkBaja = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCuentasBancarias = new System.Windows.Forms.DataGridView();
            this.tipCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMonedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVerPlanCuentasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numChequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formatoChequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indBajaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fecBajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDireccion = new System.Windows.Forms.Panel();
            this.cboDistrito = new System.Windows.Forms.ComboBox();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtWeb = new ControlesWinForm.SuperTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtCorreo = new ControlesWinForm.SuperTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtFax = new ControlesWinForm.SuperTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtTelefonos = new ControlesWinForm.SuperTextBox();
            this.txtDireccion = new ControlesWinForm.SuperTextBox();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.txtcodSunat = new ControlesWinForm.SuperTextBox();
            this.txtIdBanco = new ControlesWinForm.SuperTextBox();
            this.btSunat = new System.Windows.Forms.Button();
            this.lblComercial = new System.Windows.Forms.Label();
            this.txtComercial = new ControlesWinForm.SuperTextBox();
            this.lblRazon = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtRazon = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTipoPersona = new System.Windows.Forms.ComboBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuModificacion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsCuentasBancarias)).BeginInit();
            this.pnlCondicion.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasBancarias)).BeginInit();
            this.pnlDireccion.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsCuentasBancarias
            // 
            this.bsCuentasBancarias.DataSource = typeof(Entidades.Maestros.BancosCuentasE);
            // 
            // pnlCondicion
            // 
            this.pnlCondicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCondicion.Controls.Add(this.label10);
            this.pnlCondicion.Controls.Add(this.txtFecBaja);
            this.pnlCondicion.Controls.Add(this.chkBaja);
            this.pnlCondicion.Location = new System.Drawing.Point(777, 130);
            this.pnlCondicion.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCondicion.Name = "pnlCondicion";
            this.pnlCondicion.Size = new System.Drawing.Size(163, 133);
            this.pnlCondicion.TabIndex = 120;
            // 
            // txtFecBaja
            // 
            this.txtFecBaja.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFecBaja.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFecBaja.Enabled = false;
            this.txtFecBaja.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecBaja.Location = new System.Drawing.Point(7, 73);
            this.txtFecBaja.Margin = new System.Windows.Forms.Padding(2);
            this.txtFecBaja.Name = "txtFecBaja";
            this.txtFecBaja.Size = new System.Drawing.Size(148, 20);
            this.txtFecBaja.TabIndex = 100;
            this.txtFecBaja.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtFecBaja.TextoVacio = "<Descripcion>";
            // 
            // chkBaja
            // 
            this.chkBaja.AutoSize = true;
            this.chkBaja.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBaja.Enabled = false;
            this.chkBaja.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBaja.Location = new System.Drawing.Point(6, 52);
            this.chkBaja.Margin = new System.Windows.Forms.Padding(2);
            this.chkBaja.Name = "chkBaja";
            this.chkBaja.Size = new System.Drawing.Size(81, 17);
            this.chkBaja.TabIndex = 99;
            this.chkBaja.Text = "De Baja    ";
            this.chkBaja.UseVisualStyleBackColor = true;
            this.chkBaja.Click += new System.EventHandler(this.chkBaja_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvCuentasBancarias);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(4, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 133);
            this.panel2.TabIndex = 108;
            // 
            // dgvCuentasBancarias
            // 
            this.dgvCuentasBancarias.AllowUserToAddRows = false;
            this.dgvCuentasBancarias.AllowUserToDeleteRows = false;
            this.dgvCuentasBancarias.AutoGenerateColumns = false;
            this.dgvCuentasBancarias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCuentasBancarias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentasBancarias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipCuentaDataGridViewTextBoxColumn,
            this.numCuentaDataGridViewTextBoxColumn,
            this.idLocalDataGridViewTextBoxColumn,
            this.idMonedaDataGridViewTextBoxColumn,
            this.desMoneda,
            this.numVerPlanCuentasDataGridViewTextBoxColumn,
            this.desCuenta,
            this.numChequeDataGridViewTextBoxColumn,
            this.formatoChequeDataGridViewTextBoxColumn,
            this.indBajaDataGridViewCheckBoxColumn,
            this.fecBajaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvCuentasBancarias.DataSource = this.bsCuentasBancarias;
            this.dgvCuentasBancarias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCuentasBancarias.EnableHeadersVisualStyles = false;
            this.dgvCuentasBancarias.Location = new System.Drawing.Point(0, 18);
            this.dgvCuentasBancarias.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCuentasBancarias.Name = "dgvCuentasBancarias";
            this.dgvCuentasBancarias.ReadOnly = true;
            this.dgvCuentasBancarias.RowTemplate.Height = 24;
            this.dgvCuentasBancarias.Size = new System.Drawing.Size(768, 113);
            this.dgvCuentasBancarias.TabIndex = 98;
            this.dgvCuentasBancarias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuentasBancarias_CellDoubleClick);
            // 
            // tipCuentaDataGridViewTextBoxColumn
            // 
            this.tipCuentaDataGridViewTextBoxColumn.DataPropertyName = "desTipCuenta";
            this.tipCuentaDataGridViewTextBoxColumn.HeaderText = "Tipo Cta.";
            this.tipCuentaDataGridViewTextBoxColumn.Name = "tipCuentaDataGridViewTextBoxColumn";
            this.tipCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipCuentaDataGridViewTextBoxColumn.Width = 110;
            // 
            // numCuentaDataGridViewTextBoxColumn
            // 
            this.numCuentaDataGridViewTextBoxColumn.DataPropertyName = "numCuenta";
            this.numCuentaDataGridViewTextBoxColumn.HeaderText = "Nº Cuenta";
            this.numCuentaDataGridViewTextBoxColumn.Name = "numCuentaDataGridViewTextBoxColumn";
            this.numCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idLocalDataGridViewTextBoxColumn
            // 
            this.idLocalDataGridViewTextBoxColumn.DataPropertyName = "idLocal";
            this.idLocalDataGridViewTextBoxColumn.HeaderText = "idLocal";
            this.idLocalDataGridViewTextBoxColumn.Name = "idLocalDataGridViewTextBoxColumn";
            this.idLocalDataGridViewTextBoxColumn.ReadOnly = true;
            this.idLocalDataGridViewTextBoxColumn.Visible = false;
            // 
            // idMonedaDataGridViewTextBoxColumn
            // 
            this.idMonedaDataGridViewTextBoxColumn.DataPropertyName = "idMoneda";
            this.idMonedaDataGridViewTextBoxColumn.HeaderText = "idMoneda";
            this.idMonedaDataGridViewTextBoxColumn.Name = "idMonedaDataGridViewTextBoxColumn";
            this.idMonedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idMonedaDataGridViewTextBoxColumn.Visible = false;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            this.desMoneda.HeaderText = "Moneda";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 90;
            // 
            // numVerPlanCuentasDataGridViewTextBoxColumn
            // 
            this.numVerPlanCuentasDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            this.numVerPlanCuentasDataGridViewTextBoxColumn.HeaderText = "Cod. Cuenta";
            this.numVerPlanCuentasDataGridViewTextBoxColumn.Name = "numVerPlanCuentasDataGridViewTextBoxColumn";
            this.numVerPlanCuentasDataGridViewTextBoxColumn.ReadOnly = true;
            this.numVerPlanCuentasDataGridViewTextBoxColumn.Width = 85;
            // 
            // desCuenta
            // 
            this.desCuenta.DataPropertyName = "desCuenta";
            this.desCuenta.HeaderText = "Descripción";
            this.desCuenta.Name = "desCuenta";
            this.desCuenta.ReadOnly = true;
            this.desCuenta.Width = 150;
            // 
            // numChequeDataGridViewTextBoxColumn
            // 
            this.numChequeDataGridViewTextBoxColumn.DataPropertyName = "numCheque";
            this.numChequeDataGridViewTextBoxColumn.HeaderText = "Nº Cheque";
            this.numChequeDataGridViewTextBoxColumn.Name = "numChequeDataGridViewTextBoxColumn";
            this.numChequeDataGridViewTextBoxColumn.ReadOnly = true;
            this.numChequeDataGridViewTextBoxColumn.Width = 90;
            // 
            // formatoChequeDataGridViewTextBoxColumn
            // 
            this.formatoChequeDataGridViewTextBoxColumn.DataPropertyName = "FormatoCheque";
            this.formatoChequeDataGridViewTextBoxColumn.HeaderText = "Formato Cheque";
            this.formatoChequeDataGridViewTextBoxColumn.Name = "formatoChequeDataGridViewTextBoxColumn";
            this.formatoChequeDataGridViewTextBoxColumn.ReadOnly = true;
            this.formatoChequeDataGridViewTextBoxColumn.Width = 110;
            // 
            // indBajaDataGridViewCheckBoxColumn
            // 
            this.indBajaDataGridViewCheckBoxColumn.DataPropertyName = "indBaja";
            this.indBajaDataGridViewCheckBoxColumn.HeaderText = "de Baja";
            this.indBajaDataGridViewCheckBoxColumn.Name = "indBajaDataGridViewCheckBoxColumn";
            this.indBajaDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indBajaDataGridViewCheckBoxColumn.Width = 70;
            // 
            // fecBajaDataGridViewTextBoxColumn
            // 
            this.fecBajaDataGridViewTextBoxColumn.DataPropertyName = "fecBaja";
            this.fecBajaDataGridViewTextBoxColumn.HeaderText = "fecBaja";
            this.fecBajaDataGridViewTextBoxColumn.Name = "fecBajaDataGridViewTextBoxColumn";
            this.fecBajaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fecBajaDataGridViewTextBoxColumn.Visible = false;
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
            // pnlDireccion
            // 
            this.pnlDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDireccion.Controls.Add(this.label6);
            this.pnlDireccion.Controls.Add(this.cboDistrito);
            this.pnlDireccion.Controls.Add(this.cboDepartamento);
            this.pnlDireccion.Controls.Add(this.cboProvincia);
            this.pnlDireccion.Controls.Add(this.label21);
            this.pnlDireccion.Controls.Add(this.txtWeb);
            this.pnlDireccion.Controls.Add(this.label22);
            this.pnlDireccion.Controls.Add(this.txtCorreo);
            this.pnlDireccion.Controls.Add(this.label23);
            this.pnlDireccion.Controls.Add(this.txtFax);
            this.pnlDireccion.Controls.Add(this.label26);
            this.pnlDireccion.Controls.Add(this.txtTelefonos);
            this.pnlDireccion.Controls.Add(this.txtDireccion);
            this.pnlDireccion.Location = new System.Drawing.Point(608, 4);
            this.pnlDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDireccion.Name = "pnlDireccion";
            this.pnlDireccion.Size = new System.Drawing.Size(601, 123);
            this.pnlDireccion.TabIndex = 105;
            // 
            // cboDistrito
            // 
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(391, 27);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(199, 21);
            this.cboDistrito.TabIndex = 90;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(11, 27);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(174, 21);
            this.cboDepartamento.TabIndex = 88;
            this.cboDepartamento.SelectionChangeCommitted += new System.EventHandler(this.cboDepartamento_SelectionChangeCommitted);
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(189, 27);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(199, 21);
            this.cboProvincia.TabIndex = 89;
            this.cboProvincia.SelectionChangeCommitted += new System.EventHandler(this.cboProvincia_SelectionChangeCommitted);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(307, 97);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 13);
            this.label21.TabIndex = 125;
            this.label21.Text = "Página Web";
            // 
            // txtWeb
            // 
            this.txtWeb.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtWeb.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeb.Location = new System.Drawing.Point(373, 94);
            this.txtWeb.Margin = new System.Windows.Forms.Padding(2);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(218, 20);
            this.txtWeb.TabIndex = 95;
            this.txtWeb.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtWeb.TextoVacio = "<Descripcion>";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(12, 97);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 123;
            this.label22.Text = "E-mail";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCorreo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(80, 94);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(216, 20);
            this.txtCorreo.TabIndex = 94;
            this.txtCorreo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCorreo.TextoVacio = "<Descripcion>";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(489, 75);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(24, 13);
            this.label23.TabIndex = 121;
            this.label23.Text = "Fax";
            // 
            // txtFax
            // 
            this.txtFax.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFax.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(519, 72);
            this.txtFax.Margin = new System.Windows.Forms.Padding(2);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(72, 20);
            this.txtFax.TabIndex = 93;
            this.txtFax.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtFax.TextoVacio = "<Descripcion>";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(11, 75);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 13);
            this.label26.TabIndex = 115;
            this.label26.Text = "Telf./Cel.";
            // 
            // txtTelefonos
            // 
            this.txtTelefonos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTelefonos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTelefonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonos.Location = new System.Drawing.Point(80, 72);
            this.txtTelefonos.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefonos.Name = "txtTelefonos";
            this.txtTelefonos.Size = new System.Drawing.Size(405, 20);
            this.txtTelefonos.TabIndex = 92;
            this.txtTelefonos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtTelefonos.TextoVacio = "<Descripcion>";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDireccion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(11, 50);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(579, 20);
            this.txtDireccion.TabIndex = 91;
            this.txtDireccion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDireccion.TextoVacio = "Ingrese Dirección";
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.label1);
            this.pnlDatos.Controls.Add(this.cboTipoDocumento);
            this.pnlDatos.Controls.Add(this.txtcodSunat);
            this.pnlDatos.Controls.Add(this.txtIdBanco);
            this.pnlDatos.Controls.Add(this.btSunat);
            this.pnlDatos.Controls.Add(this.lblComercial);
            this.pnlDatos.Controls.Add(this.txtComercial);
            this.pnlDatos.Controls.Add(this.lblRazon);
            this.pnlDatos.Controls.Add(this.label9);
            this.pnlDatos.Controls.Add(this.txtRuc);
            this.pnlDatos.Controls.Add(this.txtRazon);
            this.pnlDatos.Controls.Add(this.label5);
            this.pnlDatos.Controls.Add(this.cboTipoPersona);
            this.pnlDatos.Location = new System.Drawing.Point(4, 4);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(601, 123);
            this.pnlDatos.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 275;
            this.label1.Text = "Cod. Sunat";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.DropDownWidth = 115;
            this.cboTipoDocumento.Enabled = false;
            this.cboTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(478, 27);
            this.cboTipoDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(115, 21);
            this.cboTipoDocumento.TabIndex = 273;
            this.cboTipoDocumento.SelectionChangeCommitted += new System.EventHandler(this.cboTipoDocumento_SelectionChangeCommitted);
            // 
            // txtcodSunat
            // 
            this.txtcodSunat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtcodSunat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtcodSunat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodSunat.Location = new System.Drawing.Point(101, 94);
            this.txtcodSunat.Margin = new System.Windows.Forms.Padding(2);
            this.txtcodSunat.Name = "txtcodSunat";
            this.txtcodSunat.Size = new System.Drawing.Size(72, 20);
            this.txtcodSunat.TabIndex = 274;
            this.txtcodSunat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtcodSunat.TextoVacio = "<Descripcion>";
            // 
            // txtIdBanco
            // 
            this.txtIdBanco.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdBanco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdBanco.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdBanco.Enabled = false;
            this.txtIdBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdBanco.Location = new System.Drawing.Point(227, 27);
            this.txtIdBanco.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdBanco.Name = "txtIdBanco";
            this.txtIdBanco.Size = new System.Drawing.Size(73, 20);
            this.txtIdBanco.TabIndex = 260;
            this.txtIdBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdBanco.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdBanco.TextoVacio = "<Descripcion>";
            // 
            // btSunat
            // 
            this.btSunat.BackColor = System.Drawing.Color.White;
            this.btSunat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSunat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btSunat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSunat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSunat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSunat.Image = global::ClienteWinForm.Properties.Resources.SUNAT;
            this.btSunat.Location = new System.Drawing.Point(416, 28);
            this.btSunat.Margin = new System.Windows.Forms.Padding(2);
            this.btSunat.Name = "btSunat";
            this.btSunat.Size = new System.Drawing.Size(59, 18);
            this.btSunat.TabIndex = 50;
            this.btSunat.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btSunat.UseVisualStyleBackColor = false;
            this.btSunat.Click += new System.EventHandler(this.btSunat_Click);
            // 
            // lblComercial
            // 
            this.lblComercial.AutoSize = true;
            this.lblComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComercial.Location = new System.Drawing.Point(7, 76);
            this.lblComercial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComercial.Name = "lblComercial";
            this.lblComercial.Size = new System.Drawing.Size(93, 13);
            this.lblComercial.TabIndex = 115;
            this.lblComercial.Text = "Nombre Comercial";
            // 
            // txtComercial
            // 
            this.txtComercial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtComercial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComercial.Location = new System.Drawing.Point(101, 72);
            this.txtComercial.Margin = new System.Windows.Forms.Padding(2);
            this.txtComercial.Name = "txtComercial";
            this.txtComercial.Size = new System.Drawing.Size(492, 20);
            this.txtComercial.TabIndex = 82;
            this.txtComercial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtComercial.TextoVacio = "<Descripcion>";
            // 
            // lblRazon
            // 
            this.lblRazon.AutoSize = true;
            this.lblRazon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazon.Location = new System.Drawing.Point(7, 54);
            this.lblRazon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRazon.Name = "lblRazon";
            this.lblRazon.Size = new System.Drawing.Size(70, 13);
            this.lblRazon.TabIndex = 105;
            this.lblRazon.Text = "Razón Social";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(302, 31);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 104;
            this.label9.Text = "RUC";
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.SystemColors.Info;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(333, 27);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(80, 20);
            this.txtRuc.TabIndex = 40;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "<Descripcion>";
            // 
            // txtRazon
            // 
            this.txtRazon.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazon.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazon.Location = new System.Drawing.Point(101, 50);
            this.txtRazon.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(492, 20);
            this.txtRazon.TabIndex = 81;
            this.txtRazon.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazon.TextoVacio = "<Descripcion>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Tipo Persona";
            // 
            // cboTipoPersona
            // 
            this.cboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPersona.Enabled = false;
            this.cboTipoPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoPersona.FormattingEnabled = true;
            this.cboTipoPersona.Location = new System.Drawing.Point(101, 27);
            this.cboTipoPersona.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoPersona.Name = "cboTipoPersona";
            this.cboTipoPersona.Size = new System.Drawing.Size(122, 21);
            this.cboTipoPersona.TabIndex = 30;
            this.cboTipoPersona.SelectionChangeCommitted += new System.EventHandler(this.cboTipoPersona_SelectionChangeCommitted);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label11);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistro);
            this.pnlAuditoria.Controls.Add(this.txtUsuModificacion);
            this.pnlAuditoria.Location = new System.Drawing.Point(942, 130);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(267, 133);
            this.pnlAuditoria.TabIndex = 104;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(13, 102);
            this.fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaModificacionLabel.Name = "fechaModificacionLabel";
            this.fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            this.fechaModificacionLabel.TabIndex = 6;
            this.fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(120, 98);
            this.txtFechaModificacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(133, 20);
            this.txtFechaModificacion.TabIndex = 0;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(120, 54);
            this.txtFechaRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtFechaRegistro.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario Registro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Registro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuario Modificación";
            // 
            // txtUsuRegistro
            // 
            this.txtUsuRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuRegistro.Enabled = false;
            this.txtUsuRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistro.Location = new System.Drawing.Point(120, 32);
            this.txtUsuRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistro.Name = "txtUsuRegistro";
            this.txtUsuRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtUsuRegistro.TabIndex = 0;
            // 
            // txtUsuModificacion
            // 
            this.txtUsuModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuModificacion.Enabled = false;
            this.txtUsuModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModificacion.Location = new System.Drawing.Point(120, 76);
            this.txtUsuModificacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModificacion.Name = "txtUsuModificacion";
            this.txtUsuModificacion.Size = new System.Drawing.Size(133, 20);
            this.txtUsuModificacion.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(599, 18);
            this.label8.TabIndex = 429;
            this.label8.Text = "Datos Principales";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(599, 18);
            this.label6.TabIndex = 429;
            this.label6.Text = "Ubicación";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(768, 18);
            this.label7.TabIndex = 429;
            this.label7.Text = "Cuentas Bancarias";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 18);
            this.label10.TabIndex = 429;
            this.label10.Text = "Condición";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(265, 18);
            this.label11.TabIndex = 347;
            this.label11.Text = "Auditoria";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 267);
            this.Controls.Add(this.pnlCondicion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlDireccion);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmBancos";
            this.Text = "Bancos";
            this.Load += new System.EventHandler(this.frmBancos_Load);
            this.Shown += new System.EventHandler(this.frmBancos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bsCuentasBancarias)).EndInit();
            this.pnlCondicion.ResumeLayout(false);
            this.pnlCondicion.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasBancarias)).EndInit();
            this.pnlDireccion.ResumeLayout(false);
            this.pnlDireccion.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDireccion;
        private System.Windows.Forms.ComboBox cboDistrito;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.Label label21;
        private ControlesWinForm.SuperTextBox txtWeb;
        private System.Windows.Forms.Label label22;
        private ControlesWinForm.SuperTextBox txtCorreo;
        private System.Windows.Forms.Label label23;
        private ControlesWinForm.SuperTextBox txtFax;
        private System.Windows.Forms.Label label26;
        private ControlesWinForm.SuperTextBox txtTelefonos;
        private ControlesWinForm.SuperTextBox txtDireccion;
        private System.Windows.Forms.Panel pnlDatos;
        private ControlesWinForm.SuperTextBox txtIdBanco;
        private System.Windows.Forms.Button btSunat;
        private System.Windows.Forms.Label lblComercial;
        private ControlesWinForm.SuperTextBox txtComercial;
        private System.Windows.Forms.Label lblRazon;
        private System.Windows.Forms.Label label9;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtRazon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTipoPersona;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.Label fechaModificacionLabel;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistro;
        private System.Windows.Forms.TextBox txtUsuModificacion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvCuentasBancarias;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtcodSunat;
        private System.Windows.Forms.Panel pnlCondicion;
        private ControlesWinForm.SuperTextBox txtFecBaja;
        private System.Windows.Forms.CheckBox chkBaja;
        private System.Windows.Forms.BindingSource bsCuentasBancarias;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMonedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVerPlanCuentasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn numChequeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formatoChequeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indBajaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecBajaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
    }
}