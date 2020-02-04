namespace ClienteWinForm.Maestros
{
    partial class frmDocumentos
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvImpuestos = new System.Windows.Forms.DataGridView();
            this.idImpuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desImpuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsListaImpuestos = new System.Windows.Forms.BindingSource(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.chkIndDepAduanera = new System.Windows.Forms.CheckBox();
            this.cboAduanas = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAlmacen = new System.Windows.Forms.CheckBox();
            this.chkTesoreria = new System.Windows.Forms.CheckBox();
            this.chkCreditoFiscal = new System.Windows.Forms.CheckBox();
            this.chkNoDom = new System.Windows.Forms.CheckBox();
            this.chkRegCompras = new System.Windows.Forms.CheckBox();
            this.chkReDoc = new System.Windows.Forms.CheckBox();
            this.chkFecVencimiento = new System.Windows.Forms.CheckBox();
            this.chkViaticos = new System.Windows.Forms.CheckBox();
            this.chkIndReferencia = new System.Windows.Forms.CheckBox();
            this.chbDocumentoVentas = new System.Windows.Forms.CheckBox();
            this.chkDocReferencia = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMedioPago = new System.Windows.Forms.ComboBox();
            this.txtDesCorta = new ControlesWinForm.SuperTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRazon = new System.Windows.Forms.Label();
            this.txtCodSunat = new ControlesWinForm.SuperTextBox();
            this.txtCodDoc = new ControlesWinForm.SuperTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDebeHaber = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.lblComercial = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btActivar = new System.Windows.Forms.Button();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.lblBaja = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpuestos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListaImpuestos)).BeginInit();
            this.pnlDatos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvImpuestos);
            this.panel5.Controls.Add(this.lblTitulo);
            this.panel5.Location = new System.Drawing.Point(523, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(264, 278);
            this.panel5.TabIndex = 200;
            // 
            // dgvImpuestos
            // 
            this.dgvImpuestos.AllowUserToAddRows = false;
            this.dgvImpuestos.AllowUserToDeleteRows = false;
            this.dgvImpuestos.AutoGenerateColumns = false;
            this.dgvImpuestos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvImpuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImpuestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idImpuestoDataGridViewTextBoxColumn,
            this.desImpuestoDataGridViewTextBoxColumn});
            this.dgvImpuestos.DataSource = this.bsListaImpuestos;
            this.dgvImpuestos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImpuestos.EnableHeadersVisualStyles = false;
            this.dgvImpuestos.Location = new System.Drawing.Point(0, 18);
            this.dgvImpuestos.Name = "dgvImpuestos";
            this.dgvImpuestos.ReadOnly = true;
            this.dgvImpuestos.Size = new System.Drawing.Size(262, 258);
            this.dgvImpuestos.TabIndex = 201;
            this.dgvImpuestos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImpuestos_CellDoubleClick);
            // 
            // idImpuestoDataGridViewTextBoxColumn
            // 
            this.idImpuestoDataGridViewTextBoxColumn.DataPropertyName = "idImpuesto";
            this.idImpuestoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.idImpuestoDataGridViewTextBoxColumn.Name = "idImpuestoDataGridViewTextBoxColumn";
            this.idImpuestoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desImpuestoDataGridViewTextBoxColumn
            // 
            this.desImpuestoDataGridViewTextBoxColumn.DataPropertyName = "desImpuesto";
            this.desImpuestoDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desImpuestoDataGridViewTextBoxColumn.Name = "desImpuestoDataGridViewTextBoxColumn";
            this.desImpuestoDataGridViewTextBoxColumn.ReadOnly = true;
            this.desImpuestoDataGridViewTextBoxColumn.Width = 225;
            // 
            // bsListaImpuestos
            // 
            this.bsListaImpuestos.DataSource = typeof(Entidades.Generales.ImpuestosDocumentosE);
            this.bsListaImpuestos.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsListaImpuestos_ListChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(262, 18);
            this.lblTitulo.TabIndex = 429;
            this.lblTitulo.Text = "Impuestos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.label6);
            this.pnlDatos.Controls.Add(this.chkIndDepAduanera);
            this.pnlDatos.Controls.Add(this.cboAduanas);
            this.pnlDatos.Controls.Add(this.panel1);
            this.pnlDatos.Controls.Add(this.label1);
            this.pnlDatos.Controls.Add(this.cboMedioPago);
            this.pnlDatos.Controls.Add(this.txtDesCorta);
            this.pnlDatos.Controls.Add(this.label10);
            this.pnlDatos.Controls.Add(this.lblRazon);
            this.pnlDatos.Controls.Add(this.txtCodSunat);
            this.pnlDatos.Controls.Add(this.txtCodDoc);
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.cboDebeHaber);
            this.pnlDatos.Controls.Add(this.txtDescripcion);
            this.pnlDatos.Controls.Add(this.lblComercial);
            this.pnlDatos.Controls.Add(this.label5);
            this.pnlDatos.Location = new System.Drawing.Point(3, 3);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(518, 204);
            this.pnlDatos.TabIndex = 10;
            this.pnlDatos.TabStop = true;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(516, 18);
            this.label6.TabIndex = 429;
            this.label6.Text = "Datos Principales";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIndDepAduanera
            // 
            this.chkIndDepAduanera.AutoSize = true;
            this.chkIndDepAduanera.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndDepAduanera.Location = new System.Drawing.Point(239, 75);
            this.chkIndDepAduanera.Name = "chkIndDepAduanera";
            this.chkIndDepAduanera.Size = new System.Drawing.Size(101, 17);
            this.chkIndDepAduanera.TabIndex = 24;
            this.chkIndDepAduanera.TabStop = false;
            this.chkIndDepAduanera.Text = "Ind.Dep.Aduan.";
            this.chkIndDepAduanera.UseVisualStyleBackColor = true;
            this.chkIndDepAduanera.CheckedChanged += new System.EventHandler(this.chkIndDepAduanera_CheckedChanged);
            // 
            // cboAduanas
            // 
            this.cboAduanas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAduanas.DropDownWidth = 250;
            this.cboAduanas.Enabled = false;
            this.cboAduanas.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAduanas.FormattingEnabled = true;
            this.cboAduanas.Location = new System.Drawing.Point(343, 72);
            this.cboAduanas.Margin = new System.Windows.Forms.Padding(2);
            this.cboAduanas.Name = "cboAduanas";
            this.cboAduanas.Size = new System.Drawing.Size(164, 21);
            this.cboAduanas.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkAlmacen);
            this.panel1.Controls.Add(this.chkTesoreria);
            this.panel1.Controls.Add(this.chkCreditoFiscal);
            this.panel1.Controls.Add(this.chkNoDom);
            this.panel1.Controls.Add(this.chkRegCompras);
            this.panel1.Controls.Add(this.chkReDoc);
            this.panel1.Controls.Add(this.chkFecVencimiento);
            this.panel1.Controls.Add(this.chkViaticos);
            this.panel1.Controls.Add(this.chkIndReferencia);
            this.panel1.Controls.Add(this.chbDocumentoVentas);
            this.panel1.Controls.Add(this.chkDocReferencia);
            this.panel1.Location = new System.Drawing.Point(5, 99);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 98);
            this.panel1.TabIndex = 275;
            // 
            // chkAlmacen
            // 
            this.chkAlmacen.AutoSize = true;
            this.chkAlmacen.Location = new System.Drawing.Point(350, 71);
            this.chkAlmacen.Name = "chkAlmacen";
            this.chkAlmacen.Size = new System.Drawing.Size(92, 17);
            this.chkAlmacen.TabIndex = 27;
            this.chkAlmacen.TabStop = false;
            this.chkAlmacen.Text = "Para Almacén";
            this.chkAlmacen.UseVisualStyleBackColor = true;
            // 
            // chkTesoreria
            // 
            this.chkTesoreria.AutoSize = true;
            this.chkTesoreria.Location = new System.Drawing.Point(10, 71);
            this.chkTesoreria.Name = "chkTesoreria";
            this.chkTesoreria.Size = new System.Drawing.Size(95, 17);
            this.chkTesoreria.TabIndex = 26;
            this.chkTesoreria.TabStop = false;
            this.chkTesoreria.Text = "Para Tesoreria";
            this.chkTesoreria.UseVisualStyleBackColor = true;
            // 
            // chkCreditoFiscal
            // 
            this.chkCreditoFiscal.AutoSize = true;
            this.chkCreditoFiscal.Location = new System.Drawing.Point(183, 51);
            this.chkCreditoFiscal.Name = "chkCreditoFiscal";
            this.chkCreditoFiscal.Size = new System.Drawing.Size(110, 17);
            this.chkCreditoFiscal.TabIndex = 25;
            this.chkCreditoFiscal.TabStop = false;
            this.chkCreditoFiscal.Text = "Ind. Crédito Fiscal";
            this.chkCreditoFiscal.UseVisualStyleBackColor = true;
            // 
            // chkNoDom
            // 
            this.chkNoDom.AutoSize = true;
            this.chkNoDom.Location = new System.Drawing.Point(10, 51);
            this.chkNoDom.Name = "chkNoDom";
            this.chkNoDom.Size = new System.Drawing.Size(126, 17);
            this.chkNoDom.TabIndex = 24;
            this.chkNoDom.TabStop = false;
            this.chkNoDom.Text = "Documento No Dom.";
            this.chkNoDom.UseVisualStyleBackColor = true;
            // 
            // chkRegCompras
            // 
            this.chkRegCompras.AutoSize = true;
            this.chkRegCompras.Location = new System.Drawing.Point(183, 11);
            this.chkRegCompras.Name = "chkRegCompras";
            this.chkRegCompras.Size = new System.Drawing.Size(124, 17);
            this.chkRegCompras.TabIndex = 23;
            this.chkRegCompras.TabStop = false;
            this.chkRegCompras.Text = "Registro de Compras";
            this.chkRegCompras.UseVisualStyleBackColor = true;
            // 
            // chkReDoc
            // 
            this.chkReDoc.AutoSize = true;
            this.chkReDoc.Location = new System.Drawing.Point(350, 11);
            this.chkReDoc.Name = "chkReDoc";
            this.chkReDoc.Size = new System.Drawing.Size(145, 17);
            this.chkReDoc.TabIndex = 22;
            this.chkReDoc.TabStop = false;
            this.chkReDoc.Text = "Recepcionar Documento";
            this.chkReDoc.UseVisualStyleBackColor = true;
            // 
            // chkFecVencimiento
            // 
            this.chkFecVencimiento.AutoSize = true;
            this.chkFecVencimiento.Location = new System.Drawing.Point(350, 31);
            this.chkFecVencimiento.Name = "chkFecVencimiento";
            this.chkFecVencimiento.Size = new System.Drawing.Size(110, 17);
            this.chkFecVencimiento.TabIndex = 18;
            this.chkFecVencimiento.TabStop = false;
            this.chkFecVencimiento.Text = "Indica Fec. Venc.";
            this.chkFecVencimiento.UseVisualStyleBackColor = true;
            // 
            // chkViaticos
            // 
            this.chkViaticos.AutoSize = true;
            this.chkViaticos.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.chkViaticos.Location = new System.Drawing.Point(183, 71);
            this.chkViaticos.Name = "chkViaticos";
            this.chkViaticos.Size = new System.Drawing.Size(81, 17);
            this.chkViaticos.TabIndex = 17;
            this.chkViaticos.TabStop = false;
            this.chkViaticos.Text = "Ind.Viáticos";
            this.chkViaticos.UseVisualStyleBackColor = true;
            // 
            // chkIndReferencia
            // 
            this.chkIndReferencia.AutoSize = true;
            this.chkIndReferencia.Location = new System.Drawing.Point(10, 31);
            this.chkIndReferencia.Name = "chkIndReferencia";
            this.chkIndReferencia.Size = new System.Drawing.Size(168, 17);
            this.chkIndReferencia.TabIndex = 20;
            this.chkIndReferencia.TabStop = false;
            this.chkIndReferencia.Text = "Indica Documento Referencia";
            this.chkIndReferencia.UseVisualStyleBackColor = true;
            // 
            // chbDocumentoVentas
            // 
            this.chbDocumentoVentas.AutoSize = true;
            this.chbDocumentoVentas.Location = new System.Drawing.Point(10, 11);
            this.chbDocumentoVentas.Name = "chbDocumentoVentas";
            this.chbDocumentoVentas.Size = new System.Drawing.Size(116, 17);
            this.chbDocumentoVentas.TabIndex = 19;
            this.chbDocumentoVentas.TabStop = false;
            this.chbDocumentoVentas.Text = "Registro de Ventas";
            this.chbDocumentoVentas.UseVisualStyleBackColor = true;
            // 
            // chkDocReferencia
            // 
            this.chkDocReferencia.AutoSize = true;
            this.chkDocReferencia.Location = new System.Drawing.Point(183, 31);
            this.chkDocReferencia.Name = "chkDocReferencia";
            this.chkDocReferencia.Size = new System.Drawing.Size(163, 17);
            this.chkDocReferencia.TabIndex = 21;
            this.chkDocReferencia.TabStop = false;
            this.chkDocReferencia.Text = "Docum. se puede referenciar";
            this.chkDocReferencia.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 281;
            this.label1.Text = "Medio Pago";
            // 
            // cboMedioPago
            // 
            this.cboMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedioPago.DropDownWidth = 300;
            this.cboMedioPago.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMedioPago.FormattingEnabled = true;
            this.cboMedioPago.Location = new System.Drawing.Point(88, 72);
            this.cboMedioPago.Margin = new System.Windows.Forms.Padding(2);
            this.cboMedioPago.Name = "cboMedioPago";
            this.cboMedioPago.Size = new System.Drawing.Size(150, 21);
            this.cboMedioPago.TabIndex = 7;
            // 
            // txtDesCorta
            // 
            this.txtDesCorta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesCorta.BackColor = System.Drawing.Color.White;
            this.txtDesCorta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesCorta.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCorta.Location = new System.Drawing.Point(343, 49);
            this.txtDesCorta.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesCorta.Name = "txtDesCorta";
            this.txtDesCorta.Size = new System.Drawing.Size(164, 20);
            this.txtDesCorta.TabIndex = 3;
            this.txtDesCorta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesCorta.TextoVacio = "<Descripcion>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(157, 31);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 273;
            this.label10.Text = "Cód.Sunat";
            // 
            // lblRazon
            // 
            this.lblRazon.AutoSize = true;
            this.lblRazon.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazon.Location = new System.Drawing.Point(13, 53);
            this.lblRazon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRazon.Name = "lblRazon";
            this.lblRazon.Size = new System.Drawing.Size(61, 13);
            this.lblRazon.TabIndex = 105;
            this.lblRazon.Text = "Descripción";
            // 
            // txtCodSunat
            // 
            this.txtCodSunat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodSunat.BackColor = System.Drawing.Color.White;
            this.txtCodSunat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodSunat.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodSunat.Location = new System.Drawing.Point(218, 27);
            this.txtCodSunat.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodSunat.Name = "txtCodSunat";
            this.txtCodSunat.Size = new System.Drawing.Size(48, 20);
            this.txtCodSunat.TabIndex = 6;
            this.txtCodSunat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodSunat.TextoVacio = "<Descripcion>";
            // 
            // txtCodDoc
            // 
            this.txtCodDoc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodDoc.BackColor = System.Drawing.Color.White;
            this.txtCodDoc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodDoc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodDoc.Location = new System.Drawing.Point(88, 27);
            this.txtCodDoc.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodDoc.Name = "txtCodDoc";
            this.txtCodDoc.Size = new System.Drawing.Size(64, 20);
            this.txtCodDoc.TabIndex = 1;
            this.txtCodDoc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodDoc.TextoVacio = "<Descripcion>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 101;
            this.label8.Text = "Cód.Doc.";
            // 
            // cboDebeHaber
            // 
            this.cboDebeHaber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDebeHaber.DropDownWidth = 79;
            this.cboDebeHaber.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDebeHaber.FormattingEnabled = true;
            this.cboDebeHaber.Location = new System.Drawing.Point(343, 26);
            this.cboDebeHaber.Margin = new System.Windows.Forms.Padding(2);
            this.cboDebeHaber.Name = "cboDebeHaber";
            this.cboDebeHaber.Size = new System.Drawing.Size(164, 21);
            this.cboDebeHaber.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(88, 49);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(178, 20);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripcion.TextoVacio = "<Descripcion>";
            // 
            // lblComercial
            // 
            this.lblComercial.AutoSize = true;
            this.lblComercial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComercial.Location = new System.Drawing.Point(272, 53);
            this.lblComercial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComercial.Name = "lblComercial";
            this.lblComercial.Size = new System.Drawing.Size(59, 13);
            this.lblComercial.TabIndex = 115;
            this.lblComercial.Text = "Des. Corta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(272, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Ind. Deb/Hab";
            // 
            // btActivar
            // 
            this.btActivar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btActivar.BackgroundImage = global::ClienteWinForm.Properties.Resources.ok;
            this.btActivar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btActivar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btActivar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btActivar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btActivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btActivar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActivar.Location = new System.Drawing.Point(531, 307);
            this.btActivar.Margin = new System.Windows.Forms.Padding(2);
            this.btActivar.Name = "btActivar";
            this.btActivar.Size = new System.Drawing.Size(34, 26);
            this.btActivar.TabIndex = 282;
            this.btActivar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btActivar.UseVisualStyleBackColor = false;
            this.btActivar.Visible = false;
            this.btActivar.Click += new System.EventHandler(this.btActivar_Click);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label7);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(3, 210);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(518, 71);
            this.pnlAuditoria.TabIndex = 122;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(516, 18);
            this.label7.TabIndex = 429;
            this.label7.Text = "Auditoria";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(270, 48);
            this.fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaModificacionLabel.Name = "fechaModificacionLabel";
            this.fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            this.fechaModificacionLabel.TabIndex = 6;
            this.fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(369, 44);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(135, 20);
            this.txtModifica.TabIndex = 126;
            // 
            // txtRegistro
            // 
            this.txtRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRegistro.Enabled = false;
            this.txtRegistro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(369, 23);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(135, 20);
            this.txtRegistro.TabIndex = 124;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario Registro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(270, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Registro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuario Modificación";
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(119, 23);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(135, 20);
            this.txtUsuRegistra.TabIndex = 123;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(119, 44);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(135, 20);
            this.txtUsuModifica.TabIndex = 125;
            // 
            // lblBaja
            // 
            this.lblBaja.AutoSize = true;
            this.lblBaja.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaja.ForeColor = System.Drawing.Color.Red;
            this.lblBaja.Location = new System.Drawing.Point(526, 191);
            this.lblBaja.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBaja.Name = "lblBaja";
            this.lblBaja.Size = new System.Drawing.Size(0, 13);
            this.lblBaja.TabIndex = 283;
            // 
            // frmDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 284);
            this.Controls.Add(this.lblBaja);
            this.Controls.Add(this.btActivar);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmDocumentos";
            this.Text = "Documentos";
            this.Load += new System.EventHandler(this.frmDocumentos_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpuestos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListaImpuestos)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.Label fechaModificacionLabel;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.Panel pnlDatos;
        private ControlesWinForm.SuperTextBox txtDesCorta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblRazon;
        private ControlesWinForm.SuperTextBox txtCodSunat;
        private ControlesWinForm.SuperTextBox txtCodDoc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDebeHaber;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private System.Windows.Forms.Label lblComercial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkViaticos;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvImpuestos;
        private System.Windows.Forms.BindingSource bsListaImpuestos;
        private System.Windows.Forms.CheckBox chbDocumentoVentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMedioPago;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkFecVencimiento;
        private System.Windows.Forms.CheckBox chkIndReferencia;
        private System.Windows.Forms.CheckBox chkDocReferencia;
        private System.Windows.Forms.Button btActivar;
        private System.Windows.Forms.Label lblBaja;
        private System.Windows.Forms.CheckBox chkReDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn idImpuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desImpuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cboAduanas;
        private System.Windows.Forms.CheckBox chkRegCompras;
        private System.Windows.Forms.CheckBox chkIndDepAduanera;
        private System.Windows.Forms.CheckBox chkCreditoFiscal;
        private System.Windows.Forms.CheckBox chkNoDom;
        private System.Windows.Forms.CheckBox chkTesoreria;
        private System.Windows.Forms.CheckBox chkAlmacen;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}