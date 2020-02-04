namespace ClienteWinForm.Ventas.OT
{
    partial class frmOrdenTrabajoServicio
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
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label usuarioModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label label4;
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porIgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.igvDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesCostos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsOrdenTrabajoServicioItem = new System.Windows.Forms.BindingSource(this.components);
            this.labelDegradado12 = new MyLabelG.LabelDegradado();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.txtnumeroOT = new ControlesWinForm.SuperTextBox();
            this.txtDireccion = new ControlesWinForm.SuperTextBox();
            this.txtRazonCliente = new ControlesWinForm.SuperTextBox();
            this.txtRucCLiente = new ControlesWinForm.SuperTextBox();
            this.txtIdCliente = new ControlesWinForm.SuperTextBox();
            this.dtpFecEmision = new System.Windows.Forms.DateTimePicker();
            this.txtObservacion = new ControlesWinForm.SuperTextBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.btVerImagen = new System.Windows.Forms.Button();
            this.txtCotizacion = new ControlesWinForm.SuperTextBox();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.pnlAuditoria.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdenTrabajoServicioItem)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(7, 97);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificacion";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(7, 74);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(104, 13);
            usuarioModificacionLabel.TabIndex = 4;
            usuarioModificacionLabel.Text = "Usuario Modificacion";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(7, 28);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(86, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(7, 51);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 2;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.Location = new System.Drawing.Point(18, 53);
            label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(40, 13);
            label13.TabIndex = 1584;
            label13.Text = "Cliente";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(168, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(66, 13);
            label1.TabIndex = 360;
            label1.Text = "Fec. Emision";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(18, 99);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(67, 13);
            label5.TabIndex = 326;
            label5.Text = "Observacion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(18, 76);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(50, 13);
            label2.TabIndex = 1589;
            label2.Text = "Dirección";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(18, 31);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(28, 13);
            label3.TabIndex = 1585;
            label3.Text = "Nro.";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado2);
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(usuarioModificacionLabel);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Location = new System.Drawing.Point(647, 4);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(252, 174);
            this.pnlAuditoria.TabIndex = 110;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(250, 17);
            this.labelDegradado2.TabIndex = 253;
            this.labelDegradado2.Text = "Auditoria";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(115, 93);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(124, 21);
            this.txtFechaModificacion.TabIndex = 7;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(115, 24);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(124, 21);
            this.txtUsuarioRegistro.TabIndex = 1;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(115, 70);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(124, 21);
            this.txtUsuarioModificacion.TabIndex = 5;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(115, 47);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(124, 21);
            this.txtFechaRegistro.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.dgvItem);
            this.panel7.Controls.Add(this.labelDegradado12);
            this.panel7.Location = new System.Drawing.Point(4, 180);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(895, 205);
            this.panel7.TabIndex = 109;
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.AutoGenerateColumns = false;
            this.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemDataGridViewTextBoxColumn,
            this.DesArticulo,
            this.descripcionDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.Moneda,
            this.precioUnitarioDataGridViewTextBoxColumn,
            this.valorVentaDataGridViewTextBoxColumn,
            this.porIgv,
            this.igvDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.DesCostos,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvItem.DataSource = this.bsOrdenTrabajoServicioItem;
            this.dgvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItem.EnableHeadersVisualStyles = false;
            this.dgvItem.Location = new System.Drawing.Point(0, 17);
            this.dgvItem.Margin = new System.Windows.Forms.Padding(2);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowTemplate.Height = 24;
            this.dgvItem.Size = new System.Drawing.Size(893, 186);
            this.dgvItem.TabIndex = 98;
            this.dgvItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellDoubleClick);
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Item";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 35;
            // 
            // DesArticulo
            // 
            this.DesArticulo.DataPropertyName = "DesArticulo";
            this.DesArticulo.HeaderText = "Nombre del Servicio";
            this.DesArticulo.Name = "DesArticulo";
            this.DesArticulo.ReadOnly = true;
            this.DesArticulo.Width = 150;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn.Width = 250;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N4";
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cant.";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Width = 70;
            // 
            // Moneda
            // 
            this.Moneda.DataPropertyName = "Moneda";
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.ReadOnly = true;
            this.Moneda.Width = 80;
            // 
            // precioUnitarioDataGridViewTextBoxColumn
            // 
            this.precioUnitarioDataGridViewTextBoxColumn.DataPropertyName = "PrecioUnitario";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N5";
            this.precioUnitarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.precioUnitarioDataGridViewTextBoxColumn.HeaderText = "Prec. Unit.";
            this.precioUnitarioDataGridViewTextBoxColumn.Name = "precioUnitarioDataGridViewTextBoxColumn";
            this.precioUnitarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioUnitarioDataGridViewTextBoxColumn.Width = 80;
            // 
            // valorVentaDataGridViewTextBoxColumn
            // 
            this.valorVentaDataGridViewTextBoxColumn.DataPropertyName = "ValorVenta";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.valorVentaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.valorVentaDataGridViewTextBoxColumn.HeaderText = "SubTotal";
            this.valorVentaDataGridViewTextBoxColumn.Name = "valorVentaDataGridViewTextBoxColumn";
            this.valorVentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorVentaDataGridViewTextBoxColumn.Width = 80;
            // 
            // porIgv
            // 
            this.porIgv.DataPropertyName = "porIgv";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.porIgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.porIgv.HeaderText = "% Igv";
            this.porIgv.Name = "porIgv";
            this.porIgv.ReadOnly = true;
            this.porIgv.Width = 50;
            // 
            // igvDataGridViewTextBoxColumn
            // 
            this.igvDataGridViewTextBoxColumn.DataPropertyName = "Igv";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.igvDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.igvDataGridViewTextBoxColumn.HeaderText = "Igv";
            this.igvDataGridViewTextBoxColumn.Name = "igvDataGridViewTextBoxColumn";
            this.igvDataGridViewTextBoxColumn.ReadOnly = true;
            this.igvDataGridViewTextBoxColumn.Width = 80;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DesCostos
            // 
            this.DesCostos.DataPropertyName = "DesCostos";
            this.DesCostos.HeaderText = "DesCostos";
            this.DesCostos.Name = "DesCostos";
            this.DesCostos.ReadOnly = true;
            this.DesCostos.Width = 120;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 130;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // bsOrdenTrabajoServicioItem
            // 
            this.bsOrdenTrabajoServicioItem.DataSource = typeof(Entidades.Ventas.OrdenTrabajoServicioItemE);
            // 
            // labelDegradado12
            // 
            this.labelDegradado12.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado12.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado12.ForeColor = System.Drawing.Color.White;
            this.labelDegradado12.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado12.Name = "labelDegradado12";
            this.labelDegradado12.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado12.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado12.Size = new System.Drawing.Size(893, 17);
            this.labelDegradado12.TabIndex = 272;
            this.labelDegradado12.Text = "Detalle";
            this.labelDegradado12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(label4);
            this.pnlDetalle.Controls.Add(this.txtCotizacion);
            this.pnlDetalle.Controls.Add(this.btVerImagen);
            this.pnlDetalle.Controls.Add(this.txtnumeroOT);
            this.pnlDetalle.Controls.Add(label3);
            this.pnlDetalle.Controls.Add(label2);
            this.pnlDetalle.Controls.Add(this.txtDireccion);
            this.pnlDetalle.Controls.Add(this.txtRazonCliente);
            this.pnlDetalle.Controls.Add(this.txtRucCLiente);
            this.pnlDetalle.Controls.Add(this.txtIdCliente);
            this.pnlDetalle.Controls.Add(label13);
            this.pnlDetalle.Controls.Add(label1);
            this.pnlDetalle.Controls.Add(this.dtpFecEmision);
            this.pnlDetalle.Controls.Add(this.txtObservacion);
            this.pnlDetalle.Controls.Add(label5);
            this.pnlDetalle.Controls.Add(this.labelDegradado1);
            this.pnlDetalle.Location = new System.Drawing.Point(4, 4);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(640, 174);
            this.pnlDetalle.TabIndex = 108;
            // 
            // txtnumeroOT
            // 
            this.txtnumeroOT.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtnumeroOT.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtnumeroOT.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtnumeroOT.Location = new System.Drawing.Point(88, 27);
            this.txtnumeroOT.Name = "txtnumeroOT";
            this.txtnumeroOT.Size = new System.Drawing.Size(72, 20);
            this.txtnumeroOT.TabIndex = 1590;
            this.txtnumeroOT.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtnumeroOT.TextoVacio = "<Descripcion>";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDireccion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDireccion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(88, 72);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(533, 20);
            this.txtDireccion.TabIndex = 1588;
            this.txtDireccion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDireccion.TextoVacio = "<Descripcion>";
            // 
            // txtRazonCliente
            // 
            this.txtRazonCliente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonCliente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonCliente.Location = new System.Drawing.Point(242, 49);
            this.txtRazonCliente.Name = "txtRazonCliente";
            this.txtRazonCliente.Size = new System.Drawing.Size(379, 20);
            this.txtRazonCliente.TabIndex = 1587;
            this.txtRazonCliente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonCliente.TextoVacio = "<Descripcion>";
            this.txtRazonCliente.TextChanged += new System.EventHandler(this.txtRazonCliente_TextChanged);
            this.txtRazonCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonCliente_Validating);
            // 
            // txtRucCLiente
            // 
            this.txtRucCLiente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRucCLiente.BackColor = System.Drawing.Color.White;
            this.txtRucCLiente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRucCLiente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRucCLiente.Location = new System.Drawing.Point(163, 49);
            this.txtRucCLiente.Margin = new System.Windows.Forms.Padding(2);
            this.txtRucCLiente.Name = "txtRucCLiente";
            this.txtRucCLiente.Size = new System.Drawing.Size(76, 20);
            this.txtRucCLiente.TabIndex = 1586;
            this.txtRucCLiente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRucCLiente.TextoVacio = "<Descripcion>";
            this.txtRucCLiente.TextChanged += new System.EventHandler(this.txtRucCLiente_TextChanged);
            this.txtRucCLiente.Validating += new System.ComponentModel.CancelEventHandler(this.txtRucCLiente_Validating);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdCliente.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdCliente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(88, 49);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(72, 20);
            this.txtIdCliente.TabIndex = 1585;
            this.txtIdCliente.TabStop = false;
            this.txtIdCliente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdCliente.TextoVacio = "<Descripcion>";
            // 
            // dtpFecEmision
            // 
            this.dtpFecEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecEmision.Location = new System.Drawing.Point(237, 27);
            this.dtpFecEmision.Name = "dtpFecEmision";
            this.dtpFecEmision.Size = new System.Drawing.Size(95, 20);
            this.dtpFecEmision.TabIndex = 359;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtObservacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtObservacion.Location = new System.Drawing.Point(88, 95);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(533, 39);
            this.txtObservacion.TabIndex = 800;
            this.txtObservacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtObservacion.TextoVacio = "Observaciones Generales";
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(638, 17);
            this.labelDegradado1.TabIndex = 252;
            this.labelDegradado1.Text = "Datos Principales";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btVerImagen
            // 
            this.btVerImagen.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btVerImagen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btVerImagen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btVerImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVerImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVerImagen.Image = global::ClienteWinForm.Properties.Resources.ImagenVer;
            this.btVerImagen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVerImagen.Location = new System.Drawing.Point(224, 140);
            this.btVerImagen.Name = "btVerImagen";
            this.btVerImagen.Size = new System.Drawing.Size(123, 27);
            this.btVerImagen.TabIndex = 343;
            this.btVerImagen.TabStop = false;
            this.btVerImagen.Text = "Ver Imagen";
            this.btVerImagen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btVerImagen.UseVisualStyleBackColor = true;
            this.btVerImagen.Click += new System.EventHandler(this.btVerImagen_Click);
            // 
            // txtCotizacion
            // 
            this.txtCotizacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCotizacion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCotizacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCotizacion.Location = new System.Drawing.Point(89, 140);
            this.txtCotizacion.Name = "txtCotizacion";
            this.txtCotizacion.Size = new System.Drawing.Size(130, 20);
            this.txtCotizacion.TabIndex = 1591;
            this.txtCotizacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCotizacion.TextoVacio = "<Descripcion>";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(18, 143);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(60, 13);
            label4.TabIndex = 1592;
            label4.Text = "Cotizacion:";
            // 
            // frmOrdenTrabajoServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 385);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.pnlDetalle);
            this.MaximizeBox = false;
            this.Name = "frmOrdenTrabajoServicio";
            this.Text = "Orden Trabajo";
            this.Load += new System.EventHandler(this.frmOrdenTrabajoServicio_Load);
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdenTrabajoServicioItem)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dgvItem;
        private MyLabelG.LabelDegradado labelDegradado12;
        private System.Windows.Forms.Panel pnlDetalle;
        private ControlesWinForm.SuperTextBox txtObservacion;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.BindingSource bsOrdenTrabajoServicioItem;
        private System.Windows.Forms.DateTimePicker dtpFecEmision;
        public ControlesWinForm.SuperTextBox txtIdCliente;
        public ControlesWinForm.SuperTextBox txtRucCLiente;
        private ControlesWinForm.SuperTextBox txtRazonCliente;
        private ControlesWinForm.SuperTextBox txtDireccion;
        private ControlesWinForm.SuperTextBox txtnumeroOT;
        private System.Windows.Forms.Button btVerImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn porIgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn igvDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesCostos;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private ControlesWinForm.SuperTextBox txtCotizacion;
    }
}