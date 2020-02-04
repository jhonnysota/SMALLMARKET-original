namespace ClienteWinForm.CtasPorCobrar
{
    partial class frmPlanillaCobranzaDetalle
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
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCtaDestino = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCtaProvision = new ControlesWinForm.SuperTextBox();
            this.txtDesCtaDestino = new ControlesWinForm.SuperTextBox();
            this.txtDesAuxiliar = new ControlesWinForm.SuperTextBox();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtDesCtaProvisión = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpCobranza = new System.Windows.Forms.DateTimePicker();
            this.chkDifCancelado = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTipCambio = new ControlesWinForm.SuperTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDocumento = new System.Windows.Forms.ComboBox();
            this.txtSerie = new ControlesWinForm.SuperTextBox();
            this.txtCheque = new ControlesWinForm.SuperTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpVen = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMonto = new ControlesWinForm.SuperTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtGasCom = new ControlesWinForm.SuperTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtInteres = new ControlesWinForm.SuperTextBox();
            this.txtDescripción = new ControlesWinForm.SuperTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.pnlListado = new System.Windows.Forms.Panel();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonedaReci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoReci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipCambioReci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMonedaReci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.txtFModificacion = new System.Windows.Forms.TextBox();
            this.txtURegistro = new System.Windows.Forms.TextBox();
            this.txtUModificacion = new System.Windows.Forms.TextBox();
            this.txtFRegistro = new System.Windows.Forms.TextBox();
            this.cboTipoCobranza = new System.Windows.Forms.ComboBox();
            this.btPendientes = new System.Windows.Forms.Button();
            this.btEliminarCanje = new System.Windows.Forms.Button();
            this.cboMon = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtRecibido = new ControlesWinForm.SuperTextBox();
            this.pnlOtros = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.chkIndPresupuesto = new System.Windows.Forms.CheckBox();
            this.cboConceptoInteres = new System.Windows.Forms.ComboBox();
            this.txtRucBanco = new ControlesWinForm.SuperTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTipPartida = new System.Windows.Forms.TextBox();
            this.cboConceptoGasto = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtObservación = new ControlesWinForm.SuperTextBox();
            this.btPresupuesto = new System.Windows.Forms.Button();
            this.txtDesPartida = new System.Windows.Forms.TextBox();
            this.txtCodPartida = new System.Windows.Forms.TextBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.txtDesBanco = new ControlesWinForm.SuperTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdBanco = new ControlesWinForm.SuperTextBox();
            this.btPorPagar = new System.Windows.Forms.Button();
            this.txtRucAuxiliar = new ControlesWinForm.SuperTextBox();
            this.txtRazonAuxiliar = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btLetras = new System.Windows.Forms.Button();
            this.btTercero = new System.Windows.Forms.Button();
            label13 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.pnlOtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(909, 391);
            this.btCancelar.Size = new System.Drawing.Size(132, 27);
            this.btCancelar.TabStop = false;
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(771, 391);
            this.btAceptar.Size = new System.Drawing.Size(132, 27);
            this.btAceptar.TabStop = false;
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(600, 18);
            this.lblTitPnlBase.Text = "Principales";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(1294, 25);
            this.lblTituloPrincipal.Text = "Cobranza";
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.CtasPorCobrar.CobranzasItemDetE);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(1265, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.txtRucAuxiliar);
            this.pnlBase.Controls.Add(this.txtRazonAuxiliar);
            this.pnlBase.Controls.Add(this.label6);
            this.pnlBase.Controls.Add(this.dtpCobranza);
            this.pnlBase.Controls.Add(this.lblFecha);
            this.pnlBase.Controls.Add(this.dtpFecha);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.label18);
            this.pnlBase.Controls.Add(this.txtDescripción);
            this.pnlBase.Controls.Add(this.txtDesCtaDestino);
            this.pnlBase.Controls.Add(this.chkDifCancelado);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.txtCtaProvision);
            this.pnlBase.Controls.Add(this.label9);
            this.pnlBase.Controls.Add(this.txtCtaDestino);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.cboTipoCobranza);
            this.pnlBase.Controls.Add(this.txtDesCtaProvisión);
            this.pnlBase.Location = new System.Drawing.Point(9, 29);
            this.pnlBase.Size = new System.Drawing.Size(602, 121);
            this.pnlBase.Controls.SetChildIndex(this.txtDesCtaProvisión, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboTipoCobranza, 0);
            this.pnlBase.Controls.SetChildIndex(this.label4, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCtaDestino, 0);
            this.pnlBase.Controls.SetChildIndex(this.label9, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCtaProvision, 0);
            this.pnlBase.Controls.SetChildIndex(this.label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkDifCancelado, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesCtaDestino, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDescripción, 0);
            this.pnlBase.Controls.SetChildIndex(this.label18, 0);
            this.pnlBase.Controls.SetChildIndex(this.label5, 0);
            this.pnlBase.Controls.SetChildIndex(this.dtpFecha, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblFecha, 0);
            this.pnlBase.Controls.SetChildIndex(this.dtpCobranza, 0);
            this.pnlBase.Controls.SetChildIndex(this.label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtRazonAuxiliar, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtRucAuxiliar, 0);
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.Location = new System.Drawing.Point(288, 52);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(97, 13);
            label13.TabIndex = 6;
            label13.Text = "Fecha Modificación";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label19.Location = new System.Drawing.Point(288, 29);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(104, 13);
            label19.TabIndex = 4;
            label19.Text = "Usuario Modificación";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label20.Location = new System.Drawing.Point(27, 29);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(86, 13);
            label20.TabIndex = 0;
            label20.Text = "Usuario Registro";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label21.Location = new System.Drawing.Point(27, 51);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(79, 13);
            label21.TabIndex = 2;
            label21.Text = "Fecha Registro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 273;
            this.label4.Text = "Tipo Cobro";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 283;
            this.label9.Text = "Cta. Destino";
            // 
            // txtCtaDestino
            // 
            this.txtCtaDestino.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCtaDestino.BackColor = System.Drawing.Color.White;
            this.txtCtaDestino.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCtaDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCtaDestino.Location = new System.Drawing.Point(79, 48);
            this.txtCtaDestino.Name = "txtCtaDestino";
            this.txtCtaDestino.Size = new System.Drawing.Size(76, 20);
            this.txtCtaDestino.TabIndex = 4;
            this.txtCtaDestino.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCtaDestino.TextoVacio = "<Descripcion>";
            this.txtCtaDestino.TextChanged += new System.EventHandler(this.txtCtaDestino_TextChanged);
            this.txtCtaDestino.Validating += new System.ComponentModel.CancelEventHandler(this.txtCtaDestino_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(617, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 285;
            this.label1.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 287;
            this.label2.Text = "Cta. Provisión";
            // 
            // txtCtaProvision
            // 
            this.txtCtaProvision.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCtaProvision.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCtaProvision.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCtaProvision.Enabled = false;
            this.txtCtaProvision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCtaProvision.Location = new System.Drawing.Point(79, 70);
            this.txtCtaProvision.Name = "txtCtaProvision";
            this.txtCtaProvision.Size = new System.Drawing.Size(76, 20);
            this.txtCtaProvision.TabIndex = 8;
            this.txtCtaProvision.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCtaProvision.TextoVacio = "<Descripcion>";
            this.txtCtaProvision.TextChanged += new System.EventHandler(this.txtCtaProvision_TextChanged);
            this.txtCtaProvision.Validating += new System.ComponentModel.CancelEventHandler(this.txtCtaProvision_Validating);
            // 
            // txtDesCtaDestino
            // 
            this.txtDesCtaDestino.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesCtaDestino.BackColor = System.Drawing.Color.White;
            this.txtDesCtaDestino.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesCtaDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCtaDestino.Location = new System.Drawing.Point(157, 48);
            this.txtDesCtaDestino.Name = "txtDesCtaDestino";
            this.txtDesCtaDestino.Size = new System.Drawing.Size(431, 20);
            this.txtDesCtaDestino.TabIndex = 5;
            this.txtDesCtaDestino.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesCtaDestino.TextoVacio = "<Descripcion>";
            this.txtDesCtaDestino.TextChanged += new System.EventHandler(this.txtDesCtaDestino_TextChanged);
            this.txtDesCtaDestino.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesCtaDestino_Validating);
            // 
            // txtDesAuxiliar
            // 
            this.txtDesAuxiliar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesAuxiliar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDesAuxiliar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesAuxiliar.Location = new System.Drawing.Point(738, 36);
            this.txtDesAuxiliar.Name = "txtDesAuxiliar";
            this.txtDesAuxiliar.Size = new System.Drawing.Size(438, 20);
            this.txtDesAuxiliar.TabIndex = 7;
            this.txtDesAuxiliar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesAuxiliar.TextoVacio = "Razon Social";
            this.txtDesAuxiliar.TextChanged += new System.EventHandler(this.txtDesAuxiliar_TextChanged);
            this.txtDesAuxiliar.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesAuxiliar_Validating);
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(660, 36);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(76, 20);
            this.txtRuc.TabIndex = 6;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuc.TextoVacio = "DNI";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtDni_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtDni_Validating);
            // 
            // txtDesCtaProvisión
            // 
            this.txtDesCtaProvisión.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesCtaProvisión.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCtaProvisión.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesCtaProvisión.Enabled = false;
            this.txtDesCtaProvisión.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCtaProvisión.Location = new System.Drawing.Point(157, 70);
            this.txtDesCtaProvisión.Name = "txtDesCtaProvisión";
            this.txtDesCtaProvisión.Size = new System.Drawing.Size(431, 20);
            this.txtDesCtaProvisión.TabIndex = 9;
            this.txtDesCtaProvisión.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesCtaProvisión.TextoVacio = "<Descripcion>";
            this.txtDesCtaProvisión.TextChanged += new System.EventHandler(this.txtDesCtaProvisión_TextChanged);
            this.txtDesCtaProvisión.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesCtaProvisión_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(298, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 295;
            this.label5.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(338, 25);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(79, 20);
            this.dtpFecha.TabIndex = 2;
            this.dtpFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFecha_KeyPress);
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(420, 29);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(88, 13);
            this.lblFecha.TabIndex = 297;
            this.lblFecha.Text = "Fec.Cancelación";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpCobranza
            // 
            this.dtpCobranza.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCobranza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCobranza.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCobranza.Location = new System.Drawing.Point(509, 25);
            this.dtpCobranza.Name = "dtpCobranza";
            this.dtpCobranza.Size = new System.Drawing.Size(79, 20);
            this.dtpCobranza.TabIndex = 3;
            this.dtpCobranza.ValueChanged += new System.EventHandler(this.dtpCobranza_ValueChanged);
            this.dtpCobranza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpCobranza_KeyPress);
            // 
            // chkDifCancelado
            // 
            this.chkDifCancelado.AutoSize = true;
            this.chkDifCancelado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDifCancelado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDifCancelado.Location = new System.Drawing.Point(443, 97);
            this.chkDifCancelado.Name = "chkDifCancelado";
            this.chkDifCancelado.Size = new System.Drawing.Size(142, 17);
            this.chkDifCancelado.TabIndex = 298;
            this.chkDifCancelado.TabStop = false;
            this.chkDifCancelado.Text = "Cheque Dif. Cancelando";
            this.chkDifCancelado.UseVisualStyleBackColor = true;
            this.chkDifCancelado.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 300;
            this.label7.Text = "T.C.";
            // 
            // txtTipCambio
            // 
            this.txtTipCambio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTipCambio.BackColor = System.Drawing.Color.White;
            this.txtTipCambio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTipCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipCambio.Location = new System.Drawing.Point(73, 27);
            this.txtTipCambio.Name = "txtTipCambio";
            this.txtTipCambio.Size = new System.Drawing.Size(48, 20);
            this.txtTipCambio.TabIndex = 10;
            this.txtTipCambio.Text = "0.000";
            this.txtTipCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTipCambio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTipCambio.TextoVacio = "<Descripcion>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(123, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 302;
            this.label8.Text = "Dcto.";
            // 
            // cboDocumento
            // 
            this.cboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumento.ForeColor = System.Drawing.Color.Black;
            this.cboDocumento.FormattingEnabled = true;
            this.cboDocumento.Location = new System.Drawing.Point(159, 27);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Size = new System.Drawing.Size(165, 21);
            this.cboDocumento.TabIndex = 11;
            this.cboDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDocumento_KeyPress);
            // 
            // txtSerie
            // 
            this.txtSerie.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerie.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSerie.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(327, 27);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(51, 20);
            this.txtSerie.TabIndex = 12;
            this.txtSerie.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerie.TextoVacio = "<Descripcion>";
            // 
            // txtCheque
            // 
            this.txtCheque.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCheque.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCheque.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheque.Location = new System.Drawing.Point(381, 27);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(92, 20);
            this.txtCheque.TabIndex = 13;
            this.txtCheque.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCheque.TextoVacio = "<Descripcion>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(474, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 306;
            this.label10.Text = "Venc.";
            this.label10.Visible = false;
            // 
            // dtpVen
            // 
            this.dtpVen.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpVen.Enabled = false;
            this.dtpVen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpVen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVen.Location = new System.Drawing.Point(507, 27);
            this.dtpVen.Name = "dtpVen";
            this.dtpVen.Size = new System.Drawing.Size(79, 20);
            this.dtpVen.TabIndex = 14;
            this.dtpVen.Visible = false;
            this.dtpVen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpVen_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 308;
            this.label11.Text = "Monto";
            // 
            // txtMonto
            // 
            this.txtMonto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMonto.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMonto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(73, 50);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(77, 20);
            this.txtMonto.TabIndex = 15;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMonto.TextoVacio = "<Descripcion>";
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(157, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 310;
            this.label12.Text = "Mon.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 316;
            this.label14.Text = "Gas./Comis.";
            // 
            // txtGasCom
            // 
            this.txtGasCom.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtGasCom.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtGasCom.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtGasCom.Enabled = false;
            this.txtGasCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGasCom.Location = new System.Drawing.Point(73, 73);
            this.txtGasCom.Name = "txtGasCom";
            this.txtGasCom.Size = new System.Drawing.Size(48, 20);
            this.txtGasCom.TabIndex = 19;
            this.txtGasCom.Text = "0.00";
            this.txtGasCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGasCom.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtGasCom.TextoVacio = "<Descripcion>";
            this.txtGasCom.TextChanged += new System.EventHandler(this.txtGasCom_TextChanged);
            this.txtGasCom.Leave += new System.EventHandler(this.txtGasCom_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 100);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 318;
            this.label15.Text = "Interés";
            // 
            // txtInteres
            // 
            this.txtInteres.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtInteres.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtInteres.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtInteres.Enabled = false;
            this.txtInteres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInteres.Location = new System.Drawing.Point(73, 96);
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.Size = new System.Drawing.Size(48, 20);
            this.txtInteres.TabIndex = 22;
            this.txtInteres.Text = "0.00";
            this.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInteres.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtInteres.TextoVacio = "<Descripcion>";
            this.txtInteres.TextChanged += new System.EventHandler(this.txtInteres_TextChanged);
            this.txtInteres.Leave += new System.EventHandler(this.txtInteres_Leave);
            // 
            // txtDescripción
            // 
            this.txtDescripción.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDescripción.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDescripción.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripción.Location = new System.Drawing.Point(90, 248);
            this.txtDescripción.Multiline = true;
            this.txtDescripción.Name = "txtDescripción";
            this.txtDescripción.Size = new System.Drawing.Size(296, 73);
            this.txtDescripción.TabIndex = 342;
            this.txtDescripción.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripción.TextoVacio = "<Descripcion>";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 251);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 13);
            this.label18.TabIndex = 343;
            this.label18.Text = "Descripción";
            // 
            // pnlListado
            // 
            this.pnlListado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlListado.Controls.Add(this.dgvDetalle);
            this.pnlListado.Controls.Add(this.lblRegistros);
            this.pnlListado.Location = new System.Drawing.Point(614, 91);
            this.pnlListado.Name = "pnlListado";
            this.pnlListado.Size = new System.Drawing.Size(670, 297);
            this.pnlListado.TabIndex = 301;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RazonSocial,
            this.idDocumentoDataGridViewTextBoxColumn,
            this.numSerieDataGridViewTextBoxColumn,
            this.numDocumentoDataGridViewTextBoxColumn,
            this.Moneda,
            this.Monto,
            this.MonedaReci,
            this.MontoReci,
            this.tipCambioReci,
            this.codCuenta,
            this.fecEmision,
            this.fecVencimiento,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.idMoneda,
            this.idMonedaReci});
            this.dgvDetalle.DataSource = this.bsBase;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 18);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(668, 277);
            this.dgvDetalle.TabIndex = 250;
            this.dgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellEndEdit);
            this.dgvDetalle.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellEnter);
            this.dgvDetalle.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetalle_CellFormatting);
            this.dgvDetalle.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellValueChanged);
            this.dgvDetalle.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetalle_DataError);
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Razón Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.Width = 150;
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "TD";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.Width = 40;
            // 
            // numSerieDataGridViewTextBoxColumn
            // 
            this.numSerieDataGridViewTextBoxColumn.DataPropertyName = "numSerie";
            this.numSerieDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.numSerieDataGridViewTextBoxColumn.Name = "numSerieDataGridViewTextBoxColumn";
            this.numSerieDataGridViewTextBoxColumn.Width = 40;
            // 
            // numDocumentoDataGridViewTextBoxColumn
            // 
            this.numDocumentoDataGridViewTextBoxColumn.DataPropertyName = "numDocumento";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.numDocumentoDataGridViewTextBoxColumn.HeaderText = "Número";
            this.numDocumentoDataGridViewTextBoxColumn.Name = "numDocumentoDataGridViewTextBoxColumn";
            this.numDocumentoDataGridViewTextBoxColumn.Width = 80;
            // 
            // Moneda
            // 
            this.Moneda.DataPropertyName = "Moneda";
            this.Moneda.HeaderText = "Mon.";
            this.Moneda.Name = "Moneda";
            this.Moneda.Width = 40;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Monto.DefaultCellStyle = dataGridViewCellStyle2;
            this.Monto.HeaderText = "Amortizado";
            this.Monto.Name = "Monto";
            this.Monto.Width = 80;
            // 
            // MonedaReci
            // 
            this.MonedaReci.DataPropertyName = "MonedaReci";
            this.MonedaReci.HeaderText = "Mon.R.";
            this.MonedaReci.Name = "MonedaReci";
            this.MonedaReci.Width = 45;
            // 
            // MontoReci
            // 
            this.MontoReci.DataPropertyName = "MontoReci";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.MontoReci.DefaultCellStyle = dataGridViewCellStyle3;
            this.MontoReci.HeaderText = "Monto Rec.";
            this.MontoReci.Name = "MontoReci";
            this.MontoReci.Width = 80;
            // 
            // tipCambioReci
            // 
            this.tipCambioReci.DataPropertyName = "tipCambioReci";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.tipCambioReci.DefaultCellStyle = dataGridViewCellStyle4;
            this.tipCambioReci.HeaderText = "T.C.";
            this.tipCambioReci.Name = "tipCambioReci";
            this.tipCambioReci.Width = 40;
            // 
            // codCuenta
            // 
            this.codCuenta.DataPropertyName = "codCuenta";
            this.codCuenta.HeaderText = "Cuenta";
            this.codCuenta.Name = "codCuenta";
            this.codCuenta.Width = 80;
            // 
            // fecEmision
            // 
            this.fecEmision.DataPropertyName = "fecEmision";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            this.fecEmision.DefaultCellStyle = dataGridViewCellStyle5;
            this.fecEmision.HeaderText = "Fecha";
            this.fecEmision.Name = "fecEmision";
            this.fecEmision.Width = 70;
            // 
            // fecVencimiento
            // 
            this.fecVencimiento.DataPropertyName = "fecVencimiento";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "d";
            this.fecVencimiento.DefaultCellStyle = dataGridViewCellStyle6;
            this.fecVencimiento.HeaderText = "Vcmto";
            this.fecVencimiento.Name = "fecVencimiento";
            this.fecVencimiento.Width = 70;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 130;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // idMoneda
            // 
            this.idMoneda.DataPropertyName = "idMoneda";
            this.idMoneda.HeaderText = "idMoneda";
            this.idMoneda.Name = "idMoneda";
            this.idMoneda.Visible = false;
            // 
            // idMonedaReci
            // 
            this.idMonedaReci.DataPropertyName = "idMonedaReci";
            this.idMonedaReci.HeaderText = "idMonedaReci";
            this.idMonedaReci.Name = "idMonedaReci";
            this.idMonedaReci.Visible = false;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(668, 18);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Detalle";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado4);
            this.pnlAuditoria.Controls.Add(label13);
            this.pnlAuditoria.Controls.Add(this.txtFModificacion);
            this.pnlAuditoria.Controls.Add(this.txtURegistro);
            this.pnlAuditoria.Controls.Add(label19);
            this.pnlAuditoria.Controls.Add(label20);
            this.pnlAuditoria.Controls.Add(this.txtUModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFRegistro);
            this.pnlAuditoria.Controls.Add(label21);
            this.pnlAuditoria.Location = new System.Drawing.Point(9, 344);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(602, 76);
            this.pnlAuditoria.TabIndex = 344;
            // 
            // labelDegradado4
            // 
            this.labelDegradado4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado4.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado4.ForeColor = System.Drawing.Color.White;
            this.labelDegradado4.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado4.Name = "labelDegradado4";
            this.labelDegradado4.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado4.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado4.Size = new System.Drawing.Size(600, 18);
            this.labelDegradado4.TabIndex = 251;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFModificacion
            // 
            this.txtFModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFModificacion.Enabled = false;
            this.txtFModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFModificacion.Location = new System.Drawing.Point(397, 47);
            this.txtFModificacion.Name = "txtFModificacion";
            this.txtFModificacion.Size = new System.Drawing.Size(157, 21);
            this.txtFModificacion.TabIndex = 304;
            this.txtFModificacion.TabStop = false;
            // 
            // txtURegistro
            // 
            this.txtURegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtURegistro.Enabled = false;
            this.txtURegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURegistro.Location = new System.Drawing.Point(124, 24);
            this.txtURegistro.Name = "txtURegistro";
            this.txtURegistro.Size = new System.Drawing.Size(157, 21);
            this.txtURegistro.TabIndex = 300;
            this.txtURegistro.TabStop = false;
            // 
            // txtUModificacion
            // 
            this.txtUModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUModificacion.Enabled = false;
            this.txtUModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUModificacion.Location = new System.Drawing.Point(397, 24);
            this.txtUModificacion.Name = "txtUModificacion";
            this.txtUModificacion.Size = new System.Drawing.Size(157, 21);
            this.txtUModificacion.TabIndex = 303;
            this.txtUModificacion.TabStop = false;
            // 
            // txtFRegistro
            // 
            this.txtFRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFRegistro.Enabled = false;
            this.txtFRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFRegistro.Location = new System.Drawing.Point(124, 46);
            this.txtFRegistro.Name = "txtFRegistro";
            this.txtFRegistro.Size = new System.Drawing.Size(157, 21);
            this.txtFRegistro.TabIndex = 301;
            this.txtFRegistro.TabStop = false;
            // 
            // cboTipoCobranza
            // 
            this.cboTipoCobranza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCobranza.DropDownWidth = 240;
            this.cboTipoCobranza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoCobranza.ForeColor = System.Drawing.Color.Black;
            this.cboTipoCobranza.FormattingEnabled = true;
            this.cboTipoCobranza.Location = new System.Drawing.Point(79, 25);
            this.cboTipoCobranza.Name = "cboTipoCobranza";
            this.cboTipoCobranza.Size = new System.Drawing.Size(217, 21);
            this.cboTipoCobranza.TabIndex = 1;
            this.cboTipoCobranza.SelectionChangeCommitted += new System.EventHandler(this.cboTipoCobranza_SelectionChangeCommitted);
            // 
            // btPendientes
            // 
            this.btPendientes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btPendientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btPendientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPendientes.Image = global::ClienteWinForm.Properties.Resources.CrearDocumentos;
            this.btPendientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPendientes.Location = new System.Drawing.Point(617, 62);
            this.btPendientes.Name = "btPendientes";
            this.btPendientes.Size = new System.Drawing.Size(140, 23);
            this.btPendientes.TabIndex = 319;
            this.btPendientes.TabStop = false;
            this.btPendientes.Text = "Pendientes por Cobrar";
            this.btPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPendientes.UseVisualStyleBackColor = true;
            this.btPendientes.Click += new System.EventHandler(this.btPendientes_Click);
            // 
            // btEliminarCanje
            // 
            this.btEliminarCanje.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btEliminarCanje.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btEliminarCanje.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btEliminarCanje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEliminarCanje.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.btEliminarCanje.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminarCanje.Location = new System.Drawing.Point(1207, 62);
            this.btEliminarCanje.Name = "btEliminarCanje";
            this.btEliminarCanje.Size = new System.Drawing.Size(74, 23);
            this.btEliminarCanje.TabIndex = 320;
            this.btEliminarCanje.TabStop = false;
            this.btEliminarCanje.Text = "Eliminar";
            this.btEliminarCanje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEliminarCanje.UseVisualStyleBackColor = true;
            this.btEliminarCanje.Click += new System.EventHandler(this.btEliminarCanje_Click);
            // 
            // cboMon
            // 
            this.cboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMon.Enabled = false;
            this.cboMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMon.ForeColor = System.Drawing.Color.Black;
            this.cboMon.FormattingEnabled = true;
            this.cboMon.Location = new System.Drawing.Point(190, 50);
            this.cboMon.Name = "cboMon";
            this.cboMon.Size = new System.Drawing.Size(50, 21);
            this.cboMon.TabIndex = 16;
            this.cboMon.SelectionChangeCommitted += new System.EventHandler(this.cboMon_SelectionChangeCommitted);
            this.cboMon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMon_KeyPress);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1066, 401);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(76, 13);
            this.label22.TabIndex = 324;
            this.label22.Text = "Total Recibido";
            // 
            // txtRecibido
            // 
            this.txtRecibido.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRecibido.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRecibido.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRecibido.Enabled = false;
            this.txtRecibido.Location = new System.Drawing.Point(1148, 398);
            this.txtRecibido.Name = "txtRecibido";
            this.txtRecibido.Size = new System.Drawing.Size(73, 20);
            this.txtRecibido.TabIndex = 323;
            this.txtRecibido.TabStop = false;
            this.txtRecibido.Text = "0.00";
            this.txtRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRecibido.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtRecibido.TextoVacio = "<Descripcion>";
            // 
            // pnlOtros
            // 
            this.pnlOtros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOtros.Controls.Add(this.label23);
            this.pnlOtros.Controls.Add(this.chkIndPresupuesto);
            this.pnlOtros.Controls.Add(this.cboConceptoInteres);
            this.pnlOtros.Controls.Add(this.txtRucBanco);
            this.pnlOtros.Controls.Add(this.label17);
            this.pnlOtros.Controls.Add(this.txtTipPartida);
            this.pnlOtros.Controls.Add(this.cboConceptoGasto);
            this.pnlOtros.Controls.Add(this.label16);
            this.pnlOtros.Controls.Add(this.txtObservación);
            this.pnlOtros.Controls.Add(this.btPresupuesto);
            this.pnlOtros.Controls.Add(this.txtDesPartida);
            this.pnlOtros.Controls.Add(this.txtCodPartida);
            this.pnlOtros.Controls.Add(this.labelDegradado1);
            this.pnlOtros.Controls.Add(this.txtDesBanco);
            this.pnlOtros.Controls.Add(this.label3);
            this.pnlOtros.Controls.Add(this.txtCheque);
            this.pnlOtros.Controls.Add(this.txtSerie);
            this.pnlOtros.Controls.Add(this.txtIdBanco);
            this.pnlOtros.Controls.Add(this.label8);
            this.pnlOtros.Controls.Add(this.label7);
            this.pnlOtros.Controls.Add(this.txtTipCambio);
            this.pnlOtros.Controls.Add(this.cboDocumento);
            this.pnlOtros.Controls.Add(this.cboMon);
            this.pnlOtros.Controls.Add(this.label12);
            this.pnlOtros.Controls.Add(this.label11);
            this.pnlOtros.Controls.Add(this.txtMonto);
            this.pnlOtros.Controls.Add(this.dtpVen);
            this.pnlOtros.Controls.Add(this.label10);
            this.pnlOtros.Controls.Add(this.txtGasCom);
            this.pnlOtros.Controls.Add(this.label14);
            this.pnlOtros.Controls.Add(this.txtInteres);
            this.pnlOtros.Controls.Add(this.label15);
            this.pnlOtros.Location = new System.Drawing.Point(9, 152);
            this.pnlOtros.Name = "pnlOtros";
            this.pnlOtros.Size = new System.Drawing.Size(602, 190);
            this.pnlOtros.TabIndex = 364;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(132, 100);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 13);
            this.label23.TabIndex = 368;
            this.label23.Text = "Concepto";
            // 
            // chkIndPresupuesto
            // 
            this.chkIndPresupuesto.AutoSize = true;
            this.chkIndPresupuesto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndPresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndPresupuesto.Location = new System.Drawing.Point(7, 161);
            this.chkIndPresupuesto.Name = "chkIndPresupuesto";
            this.chkIndPresupuesto.Size = new System.Drawing.Size(80, 17);
            this.chkIndPresupuesto.TabIndex = 26;
            this.chkIndPresupuesto.Text = "Ind.Presup.";
            this.chkIndPresupuesto.UseVisualStyleBackColor = true;
            this.chkIndPresupuesto.CheckedChanged += new System.EventHandler(this.chkIndPresupuesto_CheckedChanged);
            // 
            // cboConceptoInteres
            // 
            this.cboConceptoInteres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConceptoInteres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboConceptoInteres.ForeColor = System.Drawing.Color.Black;
            this.cboConceptoInteres.FormattingEnabled = true;
            this.cboConceptoInteres.Location = new System.Drawing.Point(190, 96);
            this.cboConceptoInteres.Name = "cboConceptoInteres";
            this.cboConceptoInteres.Size = new System.Drawing.Size(398, 21);
            this.cboConceptoInteres.TabIndex = 367;
            this.cboConceptoInteres.SelectionChangeCommitted += new System.EventHandler(this.cboConceptoInteres_SelectionChangeCommitted);
            // 
            // txtRucBanco
            // 
            this.txtRucBanco.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRucBanco.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRucBanco.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRucBanco.Enabled = false;
            this.txtRucBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRucBanco.Location = new System.Drawing.Point(284, 50);
            this.txtRucBanco.Name = "txtRucBanco";
            this.txtRucBanco.Size = new System.Drawing.Size(75, 20);
            this.txtRucBanco.TabIndex = 17;
            this.txtRucBanco.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRucBanco.TextoVacio = "DNI";
            this.txtRucBanco.TextChanged += new System.EventHandler(this.txtRucBanco_TextChanged);
            this.txtRucBanco.Validating += new System.ComponentModel.CancelEventHandler(this.txtRucBanco_Validating);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(132, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 13);
            this.label17.TabIndex = 366;
            this.label17.Text = "Concepto";
            // 
            // txtTipPartida
            // 
            this.txtTipPartida.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTipPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipPartida.Location = new System.Drawing.Point(75, 160);
            this.txtTipPartida.Name = "txtTipPartida";
            this.txtTipPartida.ReadOnly = true;
            this.txtTipPartida.Size = new System.Drawing.Size(13, 20);
            this.txtTipPartida.TabIndex = 806;
            this.txtTipPartida.TabStop = false;
            this.txtTipPartida.Visible = false;
            // 
            // cboConceptoGasto
            // 
            this.cboConceptoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConceptoGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboConceptoGasto.ForeColor = System.Drawing.Color.Black;
            this.cboConceptoGasto.FormattingEnabled = true;
            this.cboConceptoGasto.Location = new System.Drawing.Point(190, 73);
            this.cboConceptoGasto.Name = "cboConceptoGasto";
            this.cboConceptoGasto.Size = new System.Drawing.Size(398, 21);
            this.cboConceptoGasto.TabIndex = 365;
            this.cboConceptoGasto.SelectionChangeCommitted += new System.EventHandler(this.cboConceptoGasto_SelectionChangeCommitted);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 131);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 805;
            this.label16.Text = "Descripción";
            // 
            // txtObservación
            // 
            this.txtObservación.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtObservación.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtObservación.Location = new System.Drawing.Point(73, 119);
            this.txtObservación.Multiline = true;
            this.txtObservación.Name = "txtObservación";
            this.txtObservación.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservación.Size = new System.Drawing.Size(515, 37);
            this.txtObservación.TabIndex = 25;
            this.txtObservación.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtObservación.TextoVacio = "<Descripcion>";
            // 
            // btPresupuesto
            // 
            this.btPresupuesto.Enabled = false;
            this.btPresupuesto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btPresupuesto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btPresupuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPresupuesto.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btPresupuesto.Location = new System.Drawing.Point(563, 160);
            this.btPresupuesto.Name = "btPresupuesto";
            this.btPresupuesto.Size = new System.Drawing.Size(25, 19);
            this.btPresupuesto.TabIndex = 803;
            this.btPresupuesto.TabStop = false;
            this.btPresupuesto.UseVisualStyleBackColor = true;
            this.btPresupuesto.Click += new System.EventHandler(this.btPresupuesto_Click);
            // 
            // txtDesPartida
            // 
            this.txtDesPartida.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesPartida.Location = new System.Drawing.Point(180, 159);
            this.txtDesPartida.Name = "txtDesPartida";
            this.txtDesPartida.ReadOnly = true;
            this.txtDesPartida.Size = new System.Drawing.Size(380, 20);
            this.txtDesPartida.TabIndex = 802;
            this.txtDesPartida.TabStop = false;
            // 
            // txtCodPartida
            // 
            this.txtCodPartida.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPartida.Location = new System.Drawing.Point(92, 159);
            this.txtCodPartida.Name = "txtCodPartida";
            this.txtCodPartida.ReadOnly = true;
            this.txtCodPartida.Size = new System.Drawing.Size(86, 20);
            this.txtCodPartida.TabIndex = 801;
            this.txtCodPartida.TabStop = false;
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
            this.labelDegradado1.Size = new System.Drawing.Size(600, 18);
            this.labelDegradado1.TabIndex = 800;
            this.labelDegradado1.Text = "Otros";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDesBanco
            // 
            this.txtDesBanco.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesBanco.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesBanco.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesBanco.Enabled = false;
            this.txtDesBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesBanco.Location = new System.Drawing.Point(361, 50);
            this.txtDesBanco.Name = "txtDesBanco";
            this.txtDesBanco.Size = new System.Drawing.Size(227, 20);
            this.txtDesBanco.TabIndex = 18;
            this.txtDesBanco.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesBanco.TextoVacio = "Razon Social";
            this.txtDesBanco.TextChanged += new System.EventHandler(this.txtDesBanco_TextChanged);
            this.txtDesBanco.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesBanco_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(244, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 345;
            this.label3.Text = "Banco";
            // 
            // txtIdBanco
            // 
            this.txtIdBanco.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdBanco.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdBanco.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdBanco.Enabled = false;
            this.txtIdBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdBanco.Location = new System.Drawing.Point(284, 50);
            this.txtIdBanco.Name = "txtIdBanco";
            this.txtIdBanco.Size = new System.Drawing.Size(10, 20);
            this.txtIdBanco.TabIndex = 344;
            this.txtIdBanco.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdBanco.TextoVacio = "<Descripcion>";
            this.txtIdBanco.Visible = false;
            // 
            // btPorPagar
            // 
            this.btPorPagar.Enabled = false;
            this.btPorPagar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btPorPagar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btPorPagar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btPorPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPorPagar.Image = global::ClienteWinForm.Properties.Resources.CrearDocumentos;
            this.btPorPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPorPagar.Location = new System.Drawing.Point(760, 62);
            this.btPorPagar.Name = "btPorPagar";
            this.btPorPagar.Size = new System.Drawing.Size(140, 23);
            this.btPorPagar.TabIndex = 365;
            this.btPorPagar.TabStop = false;
            this.btPorPagar.Text = "Pendientes por Pagar";
            this.btPorPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPorPagar.UseVisualStyleBackColor = true;
            this.btPorPagar.Click += new System.EventHandler(this.btPorPagar_Click);
            // 
            // txtRucAuxiliar
            // 
            this.txtRucAuxiliar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRucAuxiliar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRucAuxiliar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRucAuxiliar.Enabled = false;
            this.txtRucAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRucAuxiliar.Location = new System.Drawing.Point(79, 92);
            this.txtRucAuxiliar.Name = "txtRucAuxiliar";
            this.txtRucAuxiliar.Size = new System.Drawing.Size(76, 20);
            this.txtRucAuxiliar.TabIndex = 366;
            this.txtRucAuxiliar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRucAuxiliar.TextoVacio = "DNI";
            this.txtRucAuxiliar.TextChanged += new System.EventHandler(this.txtRucAuxiliar_TextChanged);
            this.txtRucAuxiliar.Validating += new System.ComponentModel.CancelEventHandler(this.txtRucAuxiliar_Validating);
            // 
            // txtRazonAuxiliar
            // 
            this.txtRazonAuxiliar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonAuxiliar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRazonAuxiliar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonAuxiliar.Enabled = false;
            this.txtRazonAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonAuxiliar.Location = new System.Drawing.Point(157, 92);
            this.txtRazonAuxiliar.Name = "txtRazonAuxiliar";
            this.txtRazonAuxiliar.Size = new System.Drawing.Size(431, 20);
            this.txtRazonAuxiliar.TabIndex = 367;
            this.txtRazonAuxiliar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonAuxiliar.TextoVacio = "Razon Social";
            this.txtRazonAuxiliar.TextChanged += new System.EventHandler(this.txtRazonAuxiliar_TextChanged);
            this.txtRazonAuxiliar.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonAuxiliar_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 368;
            this.label6.Text = "Auxiliar";
            // 
            // btLetras
            // 
            this.btLetras.Enabled = false;
            this.btLetras.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btLetras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btLetras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btLetras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLetras.Image = global::ClienteWinForm.Properties.Resources.CrearDocumentos;
            this.btLetras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLetras.Location = new System.Drawing.Point(903, 62);
            this.btLetras.Name = "btLetras";
            this.btLetras.Size = new System.Drawing.Size(178, 23);
            this.btLetras.TabIndex = 366;
            this.btLetras.TabStop = false;
            this.btLetras.Text = "Letras en Dscto. o Endosadas";
            this.btLetras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLetras.UseVisualStyleBackColor = true;
            this.btLetras.Click += new System.EventHandler(this.btLetras_Click);
            // 
            // btTercero
            // 
            this.btTercero.Enabled = false;
            this.btTercero.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btTercero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btTercero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btTercero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTercero.Image = global::ClienteWinForm.Properties.Resources.CrearDocumentos;
            this.btTercero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTercero.Location = new System.Drawing.Point(1084, 62);
            this.btTercero.Name = "btTercero";
            this.btTercero.Size = new System.Drawing.Size(120, 23);
            this.btTercero.TabIndex = 367;
            this.btTercero.TabStop = false;
            this.btTercero.Text = "Letras de Tercero";
            this.btTercero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btTercero.UseVisualStyleBackColor = true;
            this.btTercero.Click += new System.EventHandler(this.btTercero_Click);
            // 
            // frmPlanillaCobranzaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 426);
            this.Controls.Add(this.btTercero);
            this.Controls.Add(this.btLetras);
            this.Controls.Add(this.btPorPagar);
            this.Controls.Add(this.pnlOtros);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtRecibido);
            this.Controls.Add(this.btEliminarCanje);
            this.Controls.Add(this.btPendientes);
            this.Controls.Add(this.pnlListado);
            this.Controls.Add(this.txtRuc);
            this.Controls.Add(this.txtDesAuxiliar);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPlanillaCobranzaDetalle";
            this.Text = "frmPlanillaCobranzaDetalle";
            this.Load += new System.EventHandler(this.frmPlanillaCobranzaDetalle_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.txtDesAuxiliar, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.txtRuc, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlListado, 0);
            this.Controls.SetChildIndex(this.btPendientes, 0);
            this.Controls.SetChildIndex(this.btEliminarCanje, 0);
            this.Controls.SetChildIndex(this.txtRecibido, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.pnlOtros, 0);
            this.Controls.SetChildIndex(this.btPorPagar, 0);
            this.Controls.SetChildIndex(this.btLetras, 0);
            this.Controls.SetChildIndex(this.btTercero, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlOtros.ResumeLayout(false);
            this.pnlOtros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private ControlesWinForm.SuperTextBox txtDesCtaProvisión;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtDesAuxiliar;
        private ControlesWinForm.SuperTextBox txtDesCtaDestino;
        private System.Windows.Forms.Label label2;
        private ControlesWinForm.SuperTextBox txtCtaProvision;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private ControlesWinForm.SuperTextBox txtCtaDestino;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpCobranza;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private ControlesWinForm.SuperTextBox txtMonto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpVen;
        private ControlesWinForm.SuperTextBox txtCheque;
        private ControlesWinForm.SuperTextBox txtSerie;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDocumento;
        private System.Windows.Forms.Label label7;
        private ControlesWinForm.SuperTextBox txtTipCambio;
        private System.Windows.Forms.CheckBox chkDifCancelado;
        private System.Windows.Forms.Label label15;
        private ControlesWinForm.SuperTextBox txtInteres;
        private System.Windows.Forms.Label label14;
        private ControlesWinForm.SuperTextBox txtGasCom;
        private System.Windows.Forms.Label label18;
        private ControlesWinForm.SuperTextBox txtDescripción;
        private System.Windows.Forms.Panel pnlListado;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox txtFModificacion;
        private System.Windows.Forms.TextBox txtURegistro;
        private System.Windows.Forms.TextBox txtUModificacion;
        private System.Windows.Forms.TextBox txtFRegistro;
        private System.Windows.Forms.ComboBox cboTipoCobranza;
        private System.Windows.Forms.Button btPendientes;
        private System.Windows.Forms.Button btEliminarCanje;
        private System.Windows.Forms.ComboBox cboMon;
        private System.Windows.Forms.Label label22;
        private ControlesWinForm.SuperTextBox txtRecibido;
        private System.Windows.Forms.Panel pnlOtros;
        private System.Windows.Forms.CheckBox chkIndPresupuesto;
        private ControlesWinForm.SuperTextBox txtRucBanco;
        private MyLabelG.LabelDegradado labelDegradado1;
        private ControlesWinForm.SuperTextBox txtDesBanco;
        private System.Windows.Forms.Label label3;
        private ControlesWinForm.SuperTextBox txtIdBanco;
        private System.Windows.Forms.Button btPresupuesto;
        private System.Windows.Forms.TextBox txtDesPartida;
        private System.Windows.Forms.TextBox txtCodPartida;
        private System.Windows.Forms.Label label16;
        private ControlesWinForm.SuperTextBox txtObservación;
        private System.Windows.Forms.TextBox txtTipPartida;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboConceptoGasto;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cboConceptoInteres;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonedaReci;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoReci;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipCambioReci;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMonedaReci;
        private System.Windows.Forms.Button btPorPagar;
        private ControlesWinForm.SuperTextBox txtRucAuxiliar;
        private ControlesWinForm.SuperTextBox txtRazonAuxiliar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btLetras;
        private System.Windows.Forms.Button btTercero;
    }
}