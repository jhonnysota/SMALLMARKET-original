namespace ClienteWinForm.Ventas
{
    partial class frmCancelaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvMedioPago = new System.Windows.Forms.DataGridView();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMedioPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumentoReciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerieReciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumentoReciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecAbono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMonedaRecDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoRecibidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipCambioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMonedaDocuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoAplicarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desBancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFecha = new ControlesWinForm.SuperTextBox();
            this.txtIdDocumento = new ControlesWinForm.SuperTextBox();
            this.txtNumero = new ControlesWinForm.SuperTextBox();
            this.txtSerie = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTica = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMonto = new ControlesWinForm.SuperTextBox();
            this.txtMonedaDocu = new ControlesWinForm.SuperTextBox();
            this.cboMonedas = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboMedioPago = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumRec = new ControlesWinForm.SuperTextBox();
            this.txtSerieRec = new ControlesWinForm.SuperTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDocumentoRec = new System.Windows.Forms.ComboBox();
            this.txtMontoRec = new ControlesWinForm.SuperTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboBancos = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCuentasBancarias = new System.Windows.Forms.ComboBox();
            this.btInsertar = new System.Windows.Forms.Button();
            this.btBorrar = new System.Windows.Forms.Button();
            this.lblMonCan = new MyLabelG.LabelDegradado();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTotalCan = new MyLabelG.LabelDegradado();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecAbono = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.chkCobranza = new System.Windows.Forms.CheckBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedioPago)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(776, 20);
            this.lblTitPnlBase.Text = "Datos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(792, 25);
            this.lblTituloPrincipal.Text = "Cancelaciones";
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Ventas.EmisionDocumentoCancelacionE);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(763, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.chkCobranza);
            this.pnlBase.Controls.Add(this.label9);
            this.pnlBase.Controls.Add(this.dtpFecAbono);
            this.pnlBase.Controls.Add(this.label7);
            this.pnlBase.Controls.Add(this.cboCuentasBancarias);
            this.pnlBase.Controls.Add(this.label6);
            this.pnlBase.Controls.Add(this.cboBancos);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.txtMontoRec);
            this.pnlBase.Controls.Add(this.txtNumRec);
            this.pnlBase.Controls.Add(this.txtSerieRec);
            this.pnlBase.Controls.Add(this.label8);
            this.pnlBase.Controls.Add(this.cboDocumentoRec);
            this.pnlBase.Controls.Add(this.cboMedioPago);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.cboMonedas);
            this.pnlBase.Controls.Add(this.label12);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.txtTica);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.txtMonto);
            this.pnlBase.Controls.Add(this.txtMonedaDocu);
            this.pnlBase.Controls.Add(this.txtFecha);
            this.pnlBase.Controls.Add(this.txtIdDocumento);
            this.pnlBase.Controls.Add(this.txtNumero);
            this.pnlBase.Controls.Add(this.txtSerie);
            this.pnlBase.Location = new System.Drawing.Point(6, 28);
            this.pnlBase.Size = new System.Drawing.Size(778, 153);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtSerie, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNumero, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdDocumento, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtFecha, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMonedaDocu, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMonto, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtTica, 0);
            this.pnlBase.Controls.SetChildIndex(this.label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.label12, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboMonedas, 0);
            this.pnlBase.Controls.SetChildIndex(this.label3, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboMedioPago, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboDocumentoRec, 0);
            this.pnlBase.Controls.SetChildIndex(this.label8, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtSerieRec, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNumRec, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMontoRec, 0);
            this.pnlBase.Controls.SetChildIndex(this.label4, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboBancos, 0);
            this.pnlBase.Controls.SetChildIndex(this.label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboCuentasBancarias, 0);
            this.pnlBase.Controls.SetChildIndex(this.label7, 0);
            this.pnlBase.Controls.SetChildIndex(this.dtpFecAbono, 0);
            this.pnlBase.Controls.SetChildIndex(this.label9, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkCobranza, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(402, 376);
            this.btCancelar.Size = new System.Drawing.Size(115, 25);
            this.btCancelar.TabStop = false;
            // 
            // btAceptar
            // 
            this.btAceptar.Enabled = false;
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(278, 376);
            this.btAceptar.Size = new System.Drawing.Size(115, 25);
            this.btAceptar.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvMedioPago);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(6, 208);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(778, 163);
            this.panel5.TabIndex = 1672;
            // 
            // dgvMedioPago
            // 
            this.dgvMedioPago.AllowUserToAddRows = false;
            this.dgvMedioPago.AllowUserToDeleteRows = false;
            this.dgvMedioPago.AutoGenerateColumns = false;
            this.dgvMedioPago.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMedioPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedioPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemDataGridViewTextBoxColumn,
            this.desMedioPagoDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.idDocumentoReciDataGridViewTextBoxColumn,
            this.numSerieReciDataGridViewTextBoxColumn,
            this.numDocumentoReciDataGridViewTextBoxColumn,
            this.fecAbono,
            this.desMonedaRecDataGridViewTextBoxColumn,
            this.montoRecibidoDataGridViewTextBoxColumn,
            this.tipCambioDataGridViewTextBoxColumn,
            this.desMonedaDocuDataGridViewTextBoxColumn,
            this.montoAplicarDataGridViewTextBoxColumn,
            this.desBancoDataGridViewTextBoxColumn,
            this.codPlanilla,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvMedioPago.DataSource = this.bsBase;
            this.dgvMedioPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedioPago.EnableHeadersVisualStyles = false;
            this.dgvMedioPago.Location = new System.Drawing.Point(0, 18);
            this.dgvMedioPago.Name = "dgvMedioPago";
            this.dgvMedioPago.ReadOnly = true;
            this.dgvMedioPago.Size = new System.Drawing.Size(776, 143);
            this.dgvMedioPago.TabIndex = 250;
            this.dgvMedioPago.TabStop = false;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Item";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 30;
            // 
            // desMedioPagoDataGridViewTextBoxColumn
            // 
            this.desMedioPagoDataGridViewTextBoxColumn.DataPropertyName = "desMedioPago";
            this.desMedioPagoDataGridViewTextBoxColumn.HeaderText = "Medio Pago";
            this.desMedioPagoDataGridViewTextBoxColumn.Name = "desMedioPagoDataGridViewTextBoxColumn";
            this.desMedioPagoDataGridViewTextBoxColumn.ReadOnly = true;
            this.desMedioPagoDataGridViewTextBoxColumn.Width = 150;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 70;
            // 
            // idDocumentoReciDataGridViewTextBoxColumn
            // 
            this.idDocumentoReciDataGridViewTextBoxColumn.DataPropertyName = "idDocumentoReci";
            this.idDocumentoReciDataGridViewTextBoxColumn.HeaderText = "T.Doc.";
            this.idDocumentoReciDataGridViewTextBoxColumn.Name = "idDocumentoReciDataGridViewTextBoxColumn";
            this.idDocumentoReciDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDocumentoReciDataGridViewTextBoxColumn.Width = 40;
            // 
            // numSerieReciDataGridViewTextBoxColumn
            // 
            this.numSerieReciDataGridViewTextBoxColumn.DataPropertyName = "numSerieReci";
            this.numSerieReciDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.numSerieReciDataGridViewTextBoxColumn.Name = "numSerieReciDataGridViewTextBoxColumn";
            this.numSerieReciDataGridViewTextBoxColumn.ReadOnly = true;
            this.numSerieReciDataGridViewTextBoxColumn.Width = 50;
            // 
            // numDocumentoReciDataGridViewTextBoxColumn
            // 
            this.numDocumentoReciDataGridViewTextBoxColumn.DataPropertyName = "numDocumentoReci";
            this.numDocumentoReciDataGridViewTextBoxColumn.HeaderText = "Número";
            this.numDocumentoReciDataGridViewTextBoxColumn.Name = "numDocumentoReciDataGridViewTextBoxColumn";
            this.numDocumentoReciDataGridViewTextBoxColumn.ReadOnly = true;
            this.numDocumentoReciDataGridViewTextBoxColumn.Width = 70;
            // 
            // fecAbono
            // 
            this.fecAbono.DataPropertyName = "fecAbono";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.fecAbono.DefaultCellStyle = dataGridViewCellStyle1;
            this.fecAbono.HeaderText = "Fec.Abono";
            this.fecAbono.Name = "fecAbono";
            this.fecAbono.ReadOnly = true;
            this.fecAbono.Width = 70;
            // 
            // desMonedaRecDataGridViewTextBoxColumn
            // 
            this.desMonedaRecDataGridViewTextBoxColumn.DataPropertyName = "desMonedaRec";
            this.desMonedaRecDataGridViewTextBoxColumn.HeaderText = "Mon.Rec.";
            this.desMonedaRecDataGridViewTextBoxColumn.Name = "desMonedaRecDataGridViewTextBoxColumn";
            this.desMonedaRecDataGridViewTextBoxColumn.ReadOnly = true;
            this.desMonedaRecDataGridViewTextBoxColumn.ToolTipText = "Moneda recibida";
            this.desMonedaRecDataGridViewTextBoxColumn.Width = 60;
            // 
            // montoRecibidoDataGridViewTextBoxColumn
            // 
            this.montoRecibidoDataGridViewTextBoxColumn.DataPropertyName = "MontoRecibido";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.montoRecibidoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.montoRecibidoDataGridViewTextBoxColumn.HeaderText = "Imp. Rec.";
            this.montoRecibidoDataGridViewTextBoxColumn.Name = "montoRecibidoDataGridViewTextBoxColumn";
            this.montoRecibidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoRecibidoDataGridViewTextBoxColumn.ToolTipText = "Importe recibido";
            this.montoRecibidoDataGridViewTextBoxColumn.Width = 80;
            // 
            // tipCambioDataGridViewTextBoxColumn
            // 
            this.tipCambioDataGridViewTextBoxColumn.DataPropertyName = "tipCambio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            this.tipCambioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.tipCambioDataGridViewTextBoxColumn.HeaderText = "T.C.";
            this.tipCambioDataGridViewTextBoxColumn.Name = "tipCambioDataGridViewTextBoxColumn";
            this.tipCambioDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipCambioDataGridViewTextBoxColumn.Width = 45;
            // 
            // desMonedaDocuDataGridViewTextBoxColumn
            // 
            this.desMonedaDocuDataGridViewTextBoxColumn.DataPropertyName = "desMonedaDocu";
            this.desMonedaDocuDataGridViewTextBoxColumn.HeaderText = "Mon.";
            this.desMonedaDocuDataGridViewTextBoxColumn.Name = "desMonedaDocuDataGridViewTextBoxColumn";
            this.desMonedaDocuDataGridViewTextBoxColumn.ReadOnly = true;
            this.desMonedaDocuDataGridViewTextBoxColumn.Width = 50;
            // 
            // montoAplicarDataGridViewTextBoxColumn
            // 
            this.montoAplicarDataGridViewTextBoxColumn.DataPropertyName = "MontoAplicar";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.montoAplicarDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.montoAplicarDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoAplicarDataGridViewTextBoxColumn.Name = "montoAplicarDataGridViewTextBoxColumn";
            this.montoAplicarDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoAplicarDataGridViewTextBoxColumn.Width = 80;
            // 
            // desBancoDataGridViewTextBoxColumn
            // 
            this.desBancoDataGridViewTextBoxColumn.DataPropertyName = "desBanco";
            this.desBancoDataGridViewTextBoxColumn.HeaderText = "Banco";
            this.desBancoDataGridViewTextBoxColumn.Name = "desBancoDataGridViewTextBoxColumn";
            this.desBancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.desBancoDataGridViewTextBoxColumn.Width = 150;
            // 
            // codPlanilla
            // 
            this.codPlanilla.DataPropertyName = "codPlanilla";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codPlanilla.DefaultCellStyle = dataGridViewCellStyle5;
            this.codPlanilla.HeaderText = "N° Planilla";
            this.codPlanilla.Name = "codPlanilla";
            this.codPlanilla.ReadOnly = true;
            this.codPlanilla.Width = 80;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // txtFecha
            // 
            this.txtFecha.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFecha.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.ForeColor = System.Drawing.Color.DarkRed;
            this.txtFecha.Location = new System.Drawing.Point(313, 26);
            this.txtFecha.MaxLength = 500;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(88, 21);
            this.txtFecha.TabIndex = 1684;
            this.txtFecha.TabStop = false;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFecha.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtFecha.TextoVacio = "";
            // 
            // txtIdDocumento
            // 
            this.txtIdDocumento.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdDocumento.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdDocumento.ForeColor = System.Drawing.Color.DarkRed;
            this.txtIdDocumento.Location = new System.Drawing.Point(144, 26);
            this.txtIdDocumento.MaxLength = 20;
            this.txtIdDocumento.Name = "txtIdDocumento";
            this.txtIdDocumento.ReadOnly = true;
            this.txtIdDocumento.Size = new System.Drawing.Size(31, 21);
            this.txtIdDocumento.TabIndex = 1683;
            this.txtIdDocumento.TabStop = false;
            this.txtIdDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdDocumento.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdDocumento.TextoVacio = "";
            // 
            // txtNumero
            // 
            this.txtNumero.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtNumero.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.ForeColor = System.Drawing.Color.DarkRed;
            this.txtNumero.Location = new System.Drawing.Point(226, 26);
            this.txtNumero.MaxLength = 500;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(85, 21);
            this.txtNumero.TabIndex = 1682;
            this.txtNumero.TabStop = false;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumero.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumero.TextoVacio = "";
            // 
            // txtSerie
            // 
            this.txtSerie.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtSerie.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.ForeColor = System.Drawing.Color.DarkRed;
            this.txtSerie.Location = new System.Drawing.Point(177, 26);
            this.txtSerie.MaxLength = 20;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.ReadOnly = true;
            this.txtSerie.Size = new System.Drawing.Size(47, 21);
            this.txtSerie.TabIndex = 1681;
            this.txtSerie.TabStop = false;
            this.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSerie.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerie.TextoVacio = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(276, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1690;
            this.label2.Text = "T.C.";
            // 
            // txtTica
            // 
            this.txtTica.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTica.BackColor = System.Drawing.Color.White;
            this.txtTica.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTica.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTica.Location = new System.Drawing.Point(309, 54);
            this.txtTica.MaxLength = 20;
            this.txtTica.Name = "txtTica";
            this.txtTica.Size = new System.Drawing.Size(42, 20);
            this.txtTica.TabIndex = 2;
            this.txtTica.Text = "0.000";
            this.txtTica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTica.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTica.TextoVacio = "";
            this.txtTica.TextChanged += new System.EventHandler(this.txtTica_TextChanged);
            this.txtTica.Leave += new System.EventHandler(this.txtTica_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(14, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1688;
            this.label1.Text = "Monto Doc.";
            // 
            // txtMonto
            // 
            this.txtMonto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMonto.BackColor = System.Drawing.Color.White;
            this.txtMonto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtMonto.Location = new System.Drawing.Point(119, 54);
            this.txtMonto.MaxLength = 20;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(151, 20);
            this.txtMonto.TabIndex = 1;
            this.txtMonto.TabStop = false;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMonto.TextoVacio = "";
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // txtMonedaDocu
            // 
            this.txtMonedaDocu.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMonedaDocu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtMonedaDocu.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMonedaDocu.Enabled = false;
            this.txtMonedaDocu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonedaDocu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtMonedaDocu.Location = new System.Drawing.Point(80, 54);
            this.txtMonedaDocu.MaxLength = 20;
            this.txtMonedaDocu.Name = "txtMonedaDocu";
            this.txtMonedaDocu.ReadOnly = true;
            this.txtMonedaDocu.Size = new System.Drawing.Size(37, 20);
            this.txtMonedaDocu.TabIndex = 1686;
            this.txtMonedaDocu.TabStop = false;
            this.txtMonedaDocu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonedaDocu.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtMonedaDocu.TextoVacio = "";
            // 
            // cboMonedas
            // 
            this.cboMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonedas.ForeColor = System.Drawing.Color.Black;
            this.cboMonedas.FormattingEnabled = true;
            this.cboMonedas.Location = new System.Drawing.Point(420, 54);
            this.cboMonedas.Name = "cboMonedas";
            this.cboMonedas.Size = new System.Drawing.Size(118, 21);
            this.cboMonedas.TabIndex = 3;
            this.cboMonedas.SelectionChangeCommitted += new System.EventHandler(this.cboMonedas_SelectionChangeCommitted);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(357, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 1692;
            this.label12.Text = "Mon. Rec.";
            // 
            // cboMedioPago
            // 
            this.cboMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedioPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMedioPago.ForeColor = System.Drawing.Color.Black;
            this.cboMedioPago.FormattingEnabled = true;
            this.cboMedioPago.Location = new System.Drawing.Point(80, 77);
            this.cboMedioPago.Name = "cboMedioPago";
            this.cboMedioPago.Size = new System.Drawing.Size(271, 21);
            this.cboMedioPago.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 1694;
            this.label3.Text = "Medio Pago";
            // 
            // txtNumRec
            // 
            this.txtNumRec.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumRec.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNumRec.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumRec.Location = new System.Drawing.Point(667, 77);
            this.txtNumRec.Name = "txtNumRec";
            this.txtNumRec.Size = new System.Drawing.Size(98, 20);
            this.txtNumRec.TabIndex = 8;
            this.txtNumRec.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumRec.TextoVacio = "<Descripcion>";
            // 
            // txtSerieRec
            // 
            this.txtSerieRec.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerieRec.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSerieRec.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSerieRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerieRec.Location = new System.Drawing.Point(571, 77);
            this.txtSerieRec.Name = "txtSerieRec";
            this.txtSerieRec.Size = new System.Drawing.Size(90, 20);
            this.txtSerieRec.TabIndex = 7;
            this.txtSerieRec.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerieRec.TextoVacio = "<Descripcion>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(357, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 1698;
            this.label8.Text = "Dcto.";
            // 
            // cboDocumentoRec
            // 
            this.cboDocumentoRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumentoRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumentoRec.ForeColor = System.Drawing.Color.Black;
            this.cboDocumentoRec.FormattingEnabled = true;
            this.cboDocumentoRec.Location = new System.Drawing.Point(400, 77);
            this.cboDocumentoRec.Name = "cboDocumentoRec";
            this.cboDocumentoRec.Size = new System.Drawing.Size(165, 21);
            this.cboDocumentoRec.TabIndex = 6;
            // 
            // txtMontoRec
            // 
            this.txtMontoRec.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMontoRec.BackColor = System.Drawing.Color.White;
            this.txtMontoRec.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMontoRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoRec.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtMontoRec.Location = new System.Drawing.Point(613, 54);
            this.txtMontoRec.MaxLength = 20;
            this.txtMontoRec.Name = "txtMontoRec";
            this.txtMontoRec.Size = new System.Drawing.Size(152, 20);
            this.txtMontoRec.TabIndex = 4;
            this.txtMontoRec.Text = "0.00";
            this.txtMontoRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoRec.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMontoRec.TextoVacio = "";
            this.txtMontoRec.TextChanged += new System.EventHandler(this.txtMontoRec_TextChanged);
            this.txtMontoRec.Leave += new System.EventHandler(this.txtMontoRec_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(544, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 1700;
            this.label4.Text = "Monto Rec.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 1702;
            this.label6.Text = "Banco";
            // 
            // cboBancos
            // 
            this.cboBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBancos.DropDownWidth = 150;
            this.cboBancos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBancos.FormattingEnabled = true;
            this.cboBancos.Location = new System.Drawing.Point(80, 100);
            this.cboBancos.Name = "cboBancos";
            this.cboBancos.Size = new System.Drawing.Size(304, 21);
            this.cboBancos.TabIndex = 9;
            this.cboBancos.SelectionChangeCommitted += new System.EventHandler(this.cboBancos_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(389, 104);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 1704;
            this.label7.Text = "N° de cuenta";
            // 
            // cboCuentasBancarias
            // 
            this.cboCuentasBancarias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuentasBancarias.Enabled = false;
            this.cboCuentasBancarias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCuentasBancarias.FormattingEnabled = true;
            this.cboCuentasBancarias.Location = new System.Drawing.Point(461, 100);
            this.cboCuentasBancarias.Name = "cboCuentasBancarias";
            this.cboCuentasBancarias.Size = new System.Drawing.Size(304, 21);
            this.cboCuentasBancarias.TabIndex = 10;
            // 
            // btInsertar
            // 
            this.btInsertar.BackColor = System.Drawing.Color.Azure;
            this.btInsertar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btInsertar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btInsertar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInsertar.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btInsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInsertar.Location = new System.Drawing.Point(604, 184);
            this.btInsertar.Name = "btInsertar";
            this.btInsertar.Size = new System.Drawing.Size(88, 21);
            this.btInsertar.TabIndex = 1673;
            this.btInsertar.TabStop = false;
            this.btInsertar.Text = "Insertar";
            this.btInsertar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInsertar.UseVisualStyleBackColor = false;
            this.btInsertar.Click += new System.EventHandler(this.btInsertar_Click);
            // 
            // btBorrar
            // 
            this.btBorrar.BackColor = System.Drawing.Color.Azure;
            this.btBorrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBorrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBorrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBorrar.Image = global::ClienteWinForm.Properties.Resources.Row_Delete_16x16;
            this.btBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBorrar.Location = new System.Drawing.Point(695, 184);
            this.btBorrar.Name = "btBorrar";
            this.btBorrar.Size = new System.Drawing.Size(88, 21);
            this.btBorrar.TabIndex = 1674;
            this.btBorrar.TabStop = false;
            this.btBorrar.Text = "Quitar";
            this.btBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBorrar.UseVisualStyleBackColor = false;
            this.btBorrar.Click += new System.EventHandler(this.btBorrar_Click);
            // 
            // lblMonCan
            // 
            this.lblMonCan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonCan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMonCan.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblMonCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonCan.ForeColor = System.Drawing.Color.Black;
            this.lblMonCan.Location = new System.Drawing.Point(621, 378);
            this.lblMonCan.Name = "lblMonCan";
            this.lblMonCan.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblMonCan.Size = new System.Drawing.Size(43, 22);
            this.lblMonCan.TabIndex = 1676;
            this.lblMonCan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(563, 383);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 1675;
            this.label16.Text = "Moneda";
            // 
            // lblTotalCan
            // 
            this.lblTotalCan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCan.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTotalCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCan.ForeColor = System.Drawing.Color.Black;
            this.lblTotalCan.Location = new System.Drawing.Point(705, 378);
            this.lblTotalCan.Name = "lblTotalCan";
            this.lblTotalCan.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTotalCan.Size = new System.Drawing.Size(72, 22);
            this.lblTotalCan.TabIndex = 1678;
            this.lblTotalCan.Text = "0.00";
            this.lblTotalCan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(670, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 1677;
            this.label5.Text = "Total";
            // 
            // dtpFecAbono
            // 
            this.dtpFecAbono.CustomFormat = "dd/MM/yyyy";
            this.dtpFecAbono.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecAbono.Location = new System.Drawing.Point(80, 123);
            this.dtpFecAbono.Name = "dtpFecAbono";
            this.dtpFecAbono.Size = new System.Drawing.Size(112, 20);
            this.dtpFecAbono.TabIndex = 1705;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 1706;
            this.label9.Text = "Fec.Abono";
            // 
            // chkCobranza
            // 
            this.chkCobranza.AutoSize = true;
            this.chkCobranza.Enabled = false;
            this.chkCobranza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCobranza.Location = new System.Drawing.Point(280, 125);
            this.chkCobranza.Name = "chkCobranza";
            this.chkCobranza.Size = new System.Drawing.Size(104, 17);
            this.chkCobranza.TabIndex = 1707;
            this.chkCobranza.Text = "Varios Cobros";
            this.chkCobranza.UseVisualStyleBackColor = true;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(776, 18);
            this.lblRegistros.TabIndex = 1574;
            this.lblRegistros.Text = "Datos de Categoria";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCancelaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 413);
            this.Controls.Add(this.lblTotalCan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMonCan);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btInsertar);
            this.Controls.Add(this.btBorrar);
            this.Controls.Add(this.panel5);
            this.Name = "frmCancelaciones";
            this.Text = "frmCancelaciones";
            this.Load += new System.EventHandler(this.frmCancelaciones_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.btBorrar, 0);
            this.Controls.SetChildIndex(this.btInsertar, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.lblMonCan, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblTotalCan, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedioPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMedioPago;
        private System.Windows.Forms.Panel panel5;
        private ControlesWinForm.SuperTextBox txtFecha;
        private ControlesWinForm.SuperTextBox txtIdDocumento;
        private ControlesWinForm.SuperTextBox txtNumero;
        private ControlesWinForm.SuperTextBox txtSerie;
        private System.Windows.Forms.Label label2;
        private ControlesWinForm.SuperTextBox txtTica;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtMonto;
        private ControlesWinForm.SuperTextBox txtMonedaDocu;
        private System.Windows.Forms.ComboBox cboMonedas;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboMedioPago;
        private System.Windows.Forms.Label label3;
        private ControlesWinForm.SuperTextBox txtNumRec;
        private ControlesWinForm.SuperTextBox txtSerieRec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDocumentoRec;
        private System.Windows.Forms.Label label4;
        private ControlesWinForm.SuperTextBox txtMontoRec;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBancos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboCuentasBancarias;
        private System.Windows.Forms.Button btInsertar;
        private System.Windows.Forms.Button btBorrar;
        private MyLabelG.LabelDegradado lblMonCan;
        private System.Windows.Forms.Label label16;
        private MyLabelG.LabelDegradado lblTotalCan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFecAbono;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMedioPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoReciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerieReciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumentoReciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecAbono;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMonedaRecDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoRecibidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipCambioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMonedaDocuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoAplicarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desBancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox chkCobranza;
        private System.Windows.Forms.Label lblRegistros;
    }
}