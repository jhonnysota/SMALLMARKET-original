namespace ClienteWinForm.Contabilidad
{
    partial class frmCuentaContable
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label codColumnaCovenLabel;
            System.Windows.Forms.Label idMonedaLabel;
            System.Windows.Forms.Label indBalanceLabel;
            System.Windows.Forms.Label tipTituloNodoLabel;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label codCuentaTransferenciaLabel;
            System.Windows.Forms.Label codCuentaDestinoLabel;
            System.Windows.Forms.Label indCambio_X_CompraLabel;
            System.Windows.Forms.Label tipAjusteLabel;
            System.Windows.Forms.Label codCuentaGananciaLabel;
            System.Windows.Forms.Label codCuentaPedidaLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label codPartidaPresuLabel;
            System.Windows.Forms.Label codCuentaLabel;
            System.Windows.Forms.Label codCuentaSupLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            this.pnlRenta = new System.Windows.Forms.Panel();
            this.btQuitarTasa = new System.Windows.Forms.Button();
            this.btInsertarTasa = new System.Windows.Forms.Button();
            this.cboTasaCuenta = new System.Windows.Forms.ComboBox();
            this.cboTasa = new System.Windows.Forms.ComboBox();
            this.chkTasa = new System.Windows.Forms.CheckBox();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.pnlChecks = new System.Windows.Forms.Panel();
            this.btCcostos = new System.Windows.Forms.Button();
            this.btDocumento = new System.Windows.Forms.Button();
            this.btAuxiliar = new System.Windows.Forms.Button();
            this.cboTipoCajaChica = new System.Windows.Forms.ComboBox();
            this.chkCtaCte = new System.Windows.Forms.CheckBox();
            this.chkIndSolicitaDcto = new System.Windows.Forms.CheckBox();
            this.chkIndSolicitaCc = new System.Windows.Forms.CheckBox();
            this.chkIndNotaIngreso = new System.Windows.Forms.CheckBox();
            this.chkIndAnexoReferencial = new System.Windows.Forms.CheckBox();
            this.chkIndCajaChica = new System.Windows.Forms.CheckBox();
            this.chkIndCtaIngreso = new System.Windows.Forms.CheckBox();
            this.chkIndSolicitaAnexo = new System.Windows.Forms.CheckBox();
            this.pnlConfiguracion = new System.Windows.Forms.Panel();
            this.labelDegradado6 = new MyLabelG.LabelDegradado();
            this.cboColumnaCoVen = new System.Windows.Forms.ComboBox();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.cboTipoNodo = new System.Windows.Forms.ComboBox();
            this.cboBalance = new System.Windows.Forms.ComboBox();
            this.pblCierre = new System.Windows.Forms.Panel();
            this.txtDesCtaCierre = new System.Windows.Forms.TextBox();
            this.btCtaCierre = new System.Windows.Forms.Button();
            this.chkIndCtaCierre = new System.Windows.Forms.CheckBox();
            this.txtCtaCierre = new ControlesWinForm.SuperTextBox();
            this.labelDegradado5 = new MyLabelG.LabelDegradado();
            this.pnlGastos = new System.Windows.Forms.Panel();
            this.txtDesCtaDestino = new System.Windows.Forms.TextBox();
            this.btCtaDestino = new System.Windows.Forms.Button();
            this.txtDesCtaTransferencia = new System.Windows.Forms.TextBox();
            this.btCtaTransferencia = new System.Windows.Forms.Button();
            this.chkIndGasto = new System.Windows.Forms.CheckBox();
            this.txtCtaTransferencia = new ControlesWinForm.SuperTextBox();
            this.txtCtaDestino = new ControlesWinForm.SuperTextBox();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.pnlCambios = new System.Windows.Forms.Panel();
            this.cboCambioCompra = new System.Windows.Forms.ComboBox();
            this.cboTipoAjuste = new System.Windows.Forms.ComboBox();
            this.txtDesCtaPerdida = new System.Windows.Forms.TextBox();
            this.btCtaPerdida = new System.Windows.Forms.Button();
            this.txtDesCtaGanancia = new System.Windows.Forms.TextBox();
            this.btCtaGanancia = new System.Windows.Forms.Button();
            this.chkIndAjusteCambio = new System.Windows.Forms.CheckBox();
            this.txtCtaPerdida = new ControlesWinForm.SuperTextBox();
            this.txtCtaGanancia = new ControlesWinForm.SuperTextBox();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.pnlCuenta = new System.Windows.Forms.Panel();
            this.txtAuxiliar = new ControlesWinForm.SuperTextBox();
            this.txtTipPartidaPre = new ControlesWinForm.SuperTextBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.txtUltimoDigito = new ControlesWinForm.SuperTextBox();
            this.cboIndNaturaleza = new System.Windows.Forms.ComboBox();
            this.btPresupuesto = new System.Windows.Forms.Button();
            this.txtDesCuenta = new ControlesWinForm.SuperTextBox();
            this.txtCodPartidaPre = new ControlesWinForm.SuperTextBox();
            this.txtCuenta = new ControlesWinForm.SuperTextBox();
            this.pnlCuentaSup = new System.Windows.Forms.Panel();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.txtDesCtaSuperior = new System.Windows.Forms.TextBox();
            this.txtCtaSuperior = new ControlesWinForm.SuperTextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado7 = new MyLabelG.LabelDegradado();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkIndReporte = new System.Windows.Forms.CheckBox();
            this.labelDegradado8 = new MyLabelG.LabelDegradado();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtCCostos = new ControlesWinForm.SuperTextBox();
            this.btCentroC = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            codColumnaCovenLabel = new System.Windows.Forms.Label();
            idMonedaLabel = new System.Windows.Forms.Label();
            indBalanceLabel = new System.Windows.Forms.Label();
            tipTituloNodoLabel = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            codCuentaTransferenciaLabel = new System.Windows.Forms.Label();
            codCuentaDestinoLabel = new System.Windows.Forms.Label();
            indCambio_X_CompraLabel = new System.Windows.Forms.Label();
            tipAjusteLabel = new System.Windows.Forms.Label();
            codCuentaGananciaLabel = new System.Windows.Forms.Label();
            codCuentaPedidaLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            codPartidaPresuLabel = new System.Windows.Forms.Label();
            codCuentaLabel = new System.Windows.Forms.Label();
            codCuentaSupLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.pnlRenta.SuspendLayout();
            this.pnlChecks.SuspendLayout();
            this.pnlConfiguracion.SuspendLayout();
            this.pblCierre.SuspendLayout();
            this.pnlGastos.SuspendLayout();
            this.pnlCambios.SuspendLayout();
            this.pnlCuenta.SuspendLayout();
            this.pnlCuentaSup.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(322, 30);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(31, 13);
            label2.TabIndex = 254;
            label2.Text = "Tasa";
            // 
            // codColumnaCovenLabel
            // 
            codColumnaCovenLabel.AutoSize = true;
            codColumnaCovenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codColumnaCovenLabel.Location = new System.Drawing.Point(10, 96);
            codColumnaCovenLabel.Name = "codColumnaCovenLabel";
            codColumnaCovenLabel.Size = new System.Drawing.Size(82, 13);
            codColumnaCovenLabel.TabIndex = 156;
            codColumnaCovenLabel.Text = "Compra / Venta";
            // 
            // idMonedaLabel
            // 
            idMonedaLabel.AutoSize = true;
            idMonedaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idMonedaLabel.Location = new System.Drawing.Point(10, 74);
            idMonedaLabel.Name = "idMonedaLabel";
            idMonedaLabel.Size = new System.Drawing.Size(46, 13);
            idMonedaLabel.TabIndex = 155;
            idMonedaLabel.Text = "Moneda";
            // 
            // indBalanceLabel
            // 
            indBalanceLabel.AutoSize = true;
            indBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            indBalanceLabel.Location = new System.Drawing.Point(10, 30);
            indBalanceLabel.Name = "indBalanceLabel";
            indBalanceLabel.Size = new System.Drawing.Size(46, 13);
            indBalanceLabel.TabIndex = 153;
            indBalanceLabel.Text = "Balance";
            // 
            // tipTituloNodoLabel
            // 
            tipTituloNodoLabel.AutoSize = true;
            tipTituloNodoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tipTituloNodoLabel.Location = new System.Drawing.Point(10, 52);
            tipTituloNodoLabel.Name = "tipTituloNodoLabel";
            tipTituloNodoLabel.Size = new System.Drawing.Size(77, 13);
            tipTituloNodoLabel.TabIndex = 78;
            tipTituloNodoLabel.Text = "Titulo / Detalle";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(8, 31);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(71, 13);
            label9.TabIndex = 8;
            label9.Text = "Cuenta Cierre";
            // 
            // codCuentaTransferenciaLabel
            // 
            codCuentaTransferenciaLabel.AutoSize = true;
            codCuentaTransferenciaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codCuentaTransferenciaLabel.Location = new System.Drawing.Point(8, 31);
            codCuentaTransferenciaLabel.Name = "codCuentaTransferenciaLabel";
            codCuentaTransferenciaLabel.Size = new System.Drawing.Size(62, 13);
            codCuentaTransferenciaLabel.TabIndex = 16;
            codCuentaTransferenciaLabel.Text = "Cta. Transf.";
            // 
            // codCuentaDestinoLabel
            // 
            codCuentaDestinoLabel.AutoSize = true;
            codCuentaDestinoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codCuentaDestinoLabel.Location = new System.Drawing.Point(8, 53);
            codCuentaDestinoLabel.Name = "codCuentaDestinoLabel";
            codCuentaDestinoLabel.Size = new System.Drawing.Size(65, 13);
            codCuentaDestinoLabel.TabIndex = 6;
            codCuentaDestinoLabel.Text = "Cta. Destino";
            // 
            // indCambio_X_CompraLabel
            // 
            indCambio_X_CompraLabel.AutoSize = true;
            indCambio_X_CompraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            indCambio_X_CompraLabel.Location = new System.Drawing.Point(315, 30);
            indCambio_X_CompraLabel.Name = "indCambio_X_CompraLabel";
            indCambio_X_CompraLabel.Size = new System.Drawing.Size(66, 13);
            indCambio_X_CompraLabel.TabIndex = 164;
            indCambio_X_CompraLabel.Text = "Tipo Cambio";
            // 
            // tipAjusteLabel
            // 
            tipAjusteLabel.AutoSize = true;
            tipAjusteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tipAjusteLabel.Location = new System.Drawing.Point(8, 30);
            tipAjusteLabel.Name = "tipAjusteLabel";
            tipAjusteLabel.Size = new System.Drawing.Size(75, 13);
            tipAjusteLabel.TabIndex = 163;
            tipAjusteLabel.Text = "Tipo de Ajuste";
            // 
            // codCuentaGananciaLabel
            // 
            codCuentaGananciaLabel.AutoSize = true;
            codCuentaGananciaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codCuentaGananciaLabel.Location = new System.Drawing.Point(8, 53);
            codCuentaGananciaLabel.Name = "codCuentaGananciaLabel";
            codCuentaGananciaLabel.Size = new System.Drawing.Size(75, 13);
            codCuentaGananciaLabel.TabIndex = 10;
            codCuentaGananciaLabel.Text = "Cta. Ganancia";
            // 
            // codCuentaPedidaLabel
            // 
            codCuentaPedidaLabel.AutoSize = true;
            codCuentaPedidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codCuentaPedidaLabel.Location = new System.Drawing.Point(8, 75);
            codCuentaPedidaLabel.Name = "codCuentaPedidaLabel";
            codCuentaPedidaLabel.Size = new System.Drawing.Size(65, 13);
            codCuentaPedidaLabel.TabIndex = 12;
            codCuentaPedidaLabel.Text = "Cta. Perdida";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descripcionLabel.Location = new System.Drawing.Point(8, 55);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(63, 13);
            descripcionLabel.TabIndex = 22;
            descripcionLabel.Text = "Descripción";
            // 
            // codPartidaPresuLabel
            // 
            codPartidaPresuLabel.AutoSize = true;
            codPartidaPresuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codPartidaPresuLabel.Location = new System.Drawing.Point(321, 33);
            codPartidaPresuLabel.Name = "codPartidaPresuLabel";
            codPartidaPresuLabel.Size = new System.Drawing.Size(66, 13);
            codPartidaPresuLabel.TabIndex = 20;
            codPartidaPresuLabel.Text = "Presupuesto";
            // 
            // codCuentaLabel
            // 
            codCuentaLabel.AutoSize = true;
            codCuentaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codCuentaLabel.Location = new System.Drawing.Point(8, 33);
            codCuentaLabel.Name = "codCuentaLabel";
            codCuentaLabel.Size = new System.Drawing.Size(41, 13);
            codCuentaLabel.TabIndex = 2;
            codCuentaLabel.Text = "Cuenta";
            // 
            // codCuentaSupLabel
            // 
            codCuentaSupLabel.AutoSize = true;
            codCuentaSupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codCuentaSupLabel.Location = new System.Drawing.Point(7, 31);
            codCuentaSupLabel.Name = "codCuentaSupLabel";
            codCuentaSupLabel.Size = new System.Drawing.Size(83, 13);
            codCuentaSupLabel.TabIndex = 14;
            codCuentaSupLabel.Text = "Cuenta Superior";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(23, 94);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificacion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(23, 73);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(106, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificacion";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(23, 31);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(23, 52);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(-1, 30);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(44, 13);
            label6.TabIndex = 256;
            label6.Text = "Tasa C.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(8, 77);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(40, 13);
            label7.TabIndex = 253;
            label7.Text = "Auxiliar";
            // 
            // pnlRenta
            // 
            this.pnlRenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRenta.Controls.Add(this.btQuitarTasa);
            this.pnlRenta.Controls.Add(this.btInsertarTasa);
            this.pnlRenta.Controls.Add(label6);
            this.pnlRenta.Controls.Add(this.cboTasaCuenta);
            this.pnlRenta.Controls.Add(label2);
            this.pnlRenta.Controls.Add(this.cboTasa);
            this.pnlRenta.Controls.Add(this.chkTasa);
            this.pnlRenta.Controls.Add(this.labelDegradado2);
            this.pnlRenta.Location = new System.Drawing.Point(3, 416);
            this.pnlRenta.Name = "pnlRenta";
            this.pnlRenta.Size = new System.Drawing.Size(580, 59);
            this.pnlRenta.TabIndex = 254;
            // 
            // btQuitarTasa
            // 
            this.btQuitarTasa.BackgroundImage = global::ClienteWinForm.Properties.Resources.Row_Delete_16x16;
            this.btQuitarTasa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btQuitarTasa.Enabled = false;
            this.btQuitarTasa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btQuitarTasa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btQuitarTasa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQuitarTasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuitarTasa.Location = new System.Drawing.Point(296, 27);
            this.btQuitarTasa.Name = "btQuitarTasa";
            this.btQuitarTasa.Size = new System.Drawing.Size(22, 18);
            this.btQuitarTasa.TabIndex = 257;
            this.btQuitarTasa.UseVisualStyleBackColor = true;
            this.btQuitarTasa.Click += new System.EventHandler(this.btQuitarTasa_Click);
            // 
            // btInsertarTasa
            // 
            this.btInsertarTasa.BackgroundImage = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btInsertarTasa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btInsertarTasa.Enabled = false;
            this.btInsertarTasa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btInsertarTasa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btInsertarTasa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInsertarTasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInsertarTasa.Location = new System.Drawing.Point(271, 27);
            this.btInsertarTasa.Name = "btInsertarTasa";
            this.btInsertarTasa.Size = new System.Drawing.Size(22, 18);
            this.btInsertarTasa.TabIndex = 253;
            this.btInsertarTasa.UseVisualStyleBackColor = true;
            this.btInsertarTasa.Click += new System.EventHandler(this.btInsertarTasa_Click);
            // 
            // cboTasaCuenta
            // 
            this.cboTasaCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTasaCuenta.DropDownWidth = 280;
            this.cboTasaCuenta.Enabled = false;
            this.cboTasaCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTasaCuenta.FormattingEnabled = true;
            this.cboTasaCuenta.Location = new System.Drawing.Point(45, 26);
            this.cboTasaCuenta.Name = "cboTasaCuenta";
            this.cboTasaCuenta.Size = new System.Drawing.Size(220, 21);
            this.cboTasaCuenta.TabIndex = 255;
            // 
            // cboTasa
            // 
            this.cboTasa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTasa.DropDownWidth = 280;
            this.cboTasa.Enabled = false;
            this.cboTasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTasa.FormattingEnabled = true;
            this.cboTasa.Location = new System.Drawing.Point(355, 26);
            this.cboTasa.Name = "cboTasa";
            this.cboTasa.Size = new System.Drawing.Size(220, 21);
            this.cboTasa.TabIndex = 21;
            // 
            // chkTasa
            // 
            this.chkTasa.BackColor = System.Drawing.Color.LightSlateGray;
            this.chkTasa.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTasa.ForeColor = System.Drawing.Color.White;
            this.chkTasa.Location = new System.Drawing.Point(2, 0);
            this.chkTasa.Name = "chkTasa";
            this.chkTasa.Size = new System.Drawing.Size(181, 18);
            this.chkTasa.TabIndex = 51;
            this.chkTasa.TabStop = false;
            this.chkTasa.Text = "Indica Tasa para la renta";
            this.chkTasa.UseVisualStyleBackColor = false;
            this.chkTasa.CheckedChanged += new System.EventHandler(this.chkTasa_CheckedChanged);
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
            this.labelDegradado2.Size = new System.Drawing.Size(578, 18);
            this.labelDegradado2.TabIndex = 253;
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlChecks
            // 
            this.pnlChecks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChecks.Controls.Add(this.txtCCostos);
            this.pnlChecks.Controls.Add(this.btCentroC);
            this.pnlChecks.Controls.Add(this.btCcostos);
            this.pnlChecks.Controls.Add(this.btDocumento);
            this.pnlChecks.Controls.Add(this.btAuxiliar);
            this.pnlChecks.Controls.Add(this.cboTipoCajaChica);
            this.pnlChecks.Controls.Add(this.chkCtaCte);
            this.pnlChecks.Controls.Add(this.chkIndSolicitaDcto);
            this.pnlChecks.Controls.Add(this.chkIndSolicitaCc);
            this.pnlChecks.Controls.Add(this.chkIndNotaIngreso);
            this.pnlChecks.Controls.Add(this.chkIndAnexoReferencial);
            this.pnlChecks.Controls.Add(this.chkIndCajaChica);
            this.pnlChecks.Controls.Add(this.chkIndCtaIngreso);
            this.pnlChecks.Controls.Add(this.chkIndSolicitaAnexo);
            this.pnlChecks.Enabled = false;
            this.pnlChecks.Location = new System.Drawing.Point(585, 129);
            this.pnlChecks.Name = "pnlChecks";
            this.pnlChecks.Size = new System.Drawing.Size(320, 140);
            this.pnlChecks.TabIndex = 162;
            // 
            // btCcostos
            // 
            this.btCcostos.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btCcostos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCcostos.Enabled = false;
            this.btCcostos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCcostos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btCcostos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCcostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCcostos.Location = new System.Drawing.Point(130, 73);
            this.btCcostos.Name = "btCcostos";
            this.btCcostos.Size = new System.Drawing.Size(16, 15);
            this.btCcostos.TabIndex = 157;
            this.btCcostos.UseVisualStyleBackColor = true;
            this.btCcostos.Click += new System.EventHandler(this.btCcostos_Click);
            // 
            // btDocumento
            // 
            this.btDocumento.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btDocumento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btDocumento.Enabled = false;
            this.btDocumento.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btDocumento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDocumento.Location = new System.Drawing.Point(130, 53);
            this.btDocumento.Name = "btDocumento";
            this.btDocumento.Size = new System.Drawing.Size(16, 15);
            this.btDocumento.TabIndex = 156;
            this.btDocumento.UseVisualStyleBackColor = true;
            this.btDocumento.Click += new System.EventHandler(this.btDocumento_Click);
            // 
            // btAuxiliar
            // 
            this.btAuxiliar.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btAuxiliar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btAuxiliar.Enabled = false;
            this.btAuxiliar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAuxiliar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btAuxiliar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAuxiliar.Location = new System.Drawing.Point(130, 33);
            this.btAuxiliar.Name = "btAuxiliar";
            this.btAuxiliar.Size = new System.Drawing.Size(16, 15);
            this.btAuxiliar.TabIndex = 155;
            this.btAuxiliar.UseVisualStyleBackColor = true;
            this.btAuxiliar.Click += new System.EventHandler(this.btAuxiliar_Click);
            // 
            // cboTipoCajaChica
            // 
            this.cboTipoCajaChica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCajaChica.DropDownWidth = 200;
            this.cboTipoCajaChica.Enabled = false;
            this.cboTipoCajaChica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoCajaChica.FormattingEnabled = true;
            this.cboTipoCajaChica.Location = new System.Drawing.Point(155, 31);
            this.cboTipoCajaChica.Name = "cboTipoCajaChica";
            this.cboTipoCajaChica.Size = new System.Drawing.Size(155, 21);
            this.cboTipoCajaChica.TabIndex = 64;
            // 
            // chkCtaCte
            // 
            this.chkCtaCte.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCtaCte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCtaCte.Location = new System.Drawing.Point(7, 13);
            this.chkCtaCte.Name = "chkCtaCte";
            this.chkCtaCte.Size = new System.Drawing.Size(119, 16);
            this.chkCtaCte.TabIndex = 43;
            this.chkCtaCte.Text = "Cuenta Corriente";
            this.chkCtaCte.UseVisualStyleBackColor = true;
            // 
            // chkIndSolicitaDcto
            // 
            this.chkIndSolicitaDcto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndSolicitaDcto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndSolicitaDcto.Location = new System.Drawing.Point(7, 53);
            this.chkIndSolicitaDcto.Name = "chkIndSolicitaDcto";
            this.chkIndSolicitaDcto.Size = new System.Drawing.Size(119, 16);
            this.chkIndSolicitaDcto.TabIndex = 63;
            this.chkIndSolicitaDcto.Text = "Con Documento";
            this.chkIndSolicitaDcto.UseVisualStyleBackColor = true;
            // 
            // chkIndSolicitaCc
            // 
            this.chkIndSolicitaCc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndSolicitaCc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndSolicitaCc.Location = new System.Drawing.Point(7, 73);
            this.chkIndSolicitaCc.Name = "chkIndSolicitaCc";
            this.chkIndSolicitaCc.Size = new System.Drawing.Size(119, 16);
            this.chkIndSolicitaCc.TabIndex = 61;
            this.chkIndSolicitaCc.Text = "C. de Costos";
            this.chkIndSolicitaCc.UseVisualStyleBackColor = true;
            this.chkIndSolicitaCc.CheckedChanged += new System.EventHandler(this.chkIndSolicitaCc_CheckedChanged);
            // 
            // chkIndNotaIngreso
            // 
            this.chkIndNotaIngreso.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndNotaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndNotaIngreso.Location = new System.Drawing.Point(7, 93);
            this.chkIndNotaIngreso.Name = "chkIndNotaIngreso";
            this.chkIndNotaIngreso.Size = new System.Drawing.Size(119, 16);
            this.chkIndNotaIngreso.TabIndex = 57;
            this.chkIndNotaIngreso.Text = "Nota de Ingreso";
            this.chkIndNotaIngreso.UseVisualStyleBackColor = true;
            // 
            // chkIndAnexoReferencial
            // 
            this.chkIndAnexoReferencial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndAnexoReferencial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndAnexoReferencial.Location = new System.Drawing.Point(7, 113);
            this.chkIndAnexoReferencial.Name = "chkIndAnexoReferencial";
            this.chkIndAnexoReferencial.Size = new System.Drawing.Size(119, 16);
            this.chkIndAnexoReferencial.TabIndex = 35;
            this.chkIndAnexoReferencial.Text = "Anexo Referencial";
            this.chkIndAnexoReferencial.UseVisualStyleBackColor = true;
            // 
            // chkIndCajaChica
            // 
            this.chkIndCajaChica.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndCajaChica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndCajaChica.Location = new System.Drawing.Point(155, 9);
            this.chkIndCajaChica.Name = "chkIndCajaChica";
            this.chkIndCajaChica.Size = new System.Drawing.Size(155, 20);
            this.chkIndCajaChica.TabIndex = 39;
            this.chkIndCajaChica.Text = "Fondos Fijos";
            this.chkIndCajaChica.UseVisualStyleBackColor = true;
            this.chkIndCajaChica.CheckedChanged += new System.EventHandler(this.chkIndCajaChica_CheckedChanged);
            // 
            // chkIndCtaIngreso
            // 
            this.chkIndCtaIngreso.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndCtaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndCtaIngreso.Location = new System.Drawing.Point(155, 53);
            this.chkIndCtaIngreso.Name = "chkIndCtaIngreso";
            this.chkIndCtaIngreso.Size = new System.Drawing.Size(155, 20);
            this.chkIndCtaIngreso.TabIndex = 47;
            this.chkIndCtaIngreso.Text = "Módulo de Cobranzas";
            this.chkIndCtaIngreso.UseVisualStyleBackColor = true;
            // 
            // chkIndSolicitaAnexo
            // 
            this.chkIndSolicitaAnexo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndSolicitaAnexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndSolicitaAnexo.Location = new System.Drawing.Point(7, 33);
            this.chkIndSolicitaAnexo.Name = "chkIndSolicitaAnexo";
            this.chkIndSolicitaAnexo.Size = new System.Drawing.Size(119, 16);
            this.chkIndSolicitaAnexo.TabIndex = 65;
            this.chkIndSolicitaAnexo.Text = "Con Auxiliar";
            this.chkIndSolicitaAnexo.UseVisualStyleBackColor = true;
            // 
            // pnlConfiguracion
            // 
            this.pnlConfiguracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConfiguracion.Controls.Add(this.labelDegradado6);
            this.pnlConfiguracion.Controls.Add(codColumnaCovenLabel);
            this.pnlConfiguracion.Controls.Add(this.cboColumnaCoVen);
            this.pnlConfiguracion.Controls.Add(idMonedaLabel);
            this.pnlConfiguracion.Controls.Add(this.cboMoneda);
            this.pnlConfiguracion.Controls.Add(this.cboTipoNodo);
            this.pnlConfiguracion.Controls.Add(indBalanceLabel);
            this.pnlConfiguracion.Controls.Add(this.cboBalance);
            this.pnlConfiguracion.Controls.Add(tipTituloNodoLabel);
            this.pnlConfiguracion.Enabled = false;
            this.pnlConfiguracion.Location = new System.Drawing.Point(585, 3);
            this.pnlConfiguracion.Name = "pnlConfiguracion";
            this.pnlConfiguracion.Size = new System.Drawing.Size(320, 124);
            this.pnlConfiguracion.TabIndex = 161;
            // 
            // labelDegradado6
            // 
            this.labelDegradado6.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado6.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado6.ForeColor = System.Drawing.Color.White;
            this.labelDegradado6.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado6.Name = "labelDegradado6";
            this.labelDegradado6.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado6.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado6.Size = new System.Drawing.Size(318, 18);
            this.labelDegradado6.TabIndex = 253;
            this.labelDegradado6.Text = "Configuración";
            this.labelDegradado6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboColumnaCoVen
            // 
            this.cboColumnaCoVen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColumnaCoVen.DropDownWidth = 240;
            this.cboColumnaCoVen.Enabled = false;
            this.cboColumnaCoVen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboColumnaCoVen.FormattingEnabled = true;
            this.cboColumnaCoVen.Location = new System.Drawing.Point(95, 92);
            this.cboColumnaCoVen.Name = "cboColumnaCoVen";
            this.cboColumnaCoVen.Size = new System.Drawing.Size(207, 21);
            this.cboColumnaCoVen.TabIndex = 25;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(95, 70);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(207, 21);
            this.cboMoneda.TabIndex = 24;
            // 
            // cboTipoNodo
            // 
            this.cboTipoNodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoNodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoNodo.FormattingEnabled = true;
            this.cboTipoNodo.Location = new System.Drawing.Point(95, 48);
            this.cboTipoNodo.Name = "cboTipoNodo";
            this.cboTipoNodo.Size = new System.Drawing.Size(207, 21);
            this.cboTipoNodo.TabIndex = 23;
            this.cboTipoNodo.SelectionChangeCommitted += new System.EventHandler(this.cboTipoNodo_SelectionChangeCommitted);
            // 
            // cboBalance
            // 
            this.cboBalance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBalance.DropDownWidth = 200;
            this.cboBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBalance.FormattingEnabled = true;
            this.cboBalance.Location = new System.Drawing.Point(95, 26);
            this.cboBalance.Name = "cboBalance";
            this.cboBalance.Size = new System.Drawing.Size(207, 21);
            this.cboBalance.TabIndex = 22;
            // 
            // pblCierre
            // 
            this.pblCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pblCierre.Controls.Add(this.txtDesCtaCierre);
            this.pblCierre.Controls.Add(this.btCtaCierre);
            this.pblCierre.Controls.Add(this.chkIndCtaCierre);
            this.pblCierre.Controls.Add(label9);
            this.pblCierre.Controls.Add(this.txtCtaCierre);
            this.pblCierre.Controls.Add(this.labelDegradado5);
            this.pblCierre.Enabled = false;
            this.pblCierre.Location = new System.Drawing.Point(3, 355);
            this.pblCierre.Name = "pblCierre";
            this.pblCierre.Size = new System.Drawing.Size(580, 59);
            this.pblCierre.TabIndex = 167;
            // 
            // txtDesCtaCierre
            // 
            this.txtDesCtaCierre.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCtaCierre.Enabled = false;
            this.txtDesCtaCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCtaCierre.Location = new System.Drawing.Point(155, 27);
            this.txtDesCtaCierre.Name = "txtDesCtaCierre";
            this.txtDesCtaCierre.Size = new System.Drawing.Size(414, 20);
            this.txtDesCtaCierre.TabIndex = 20;
            this.txtDesCtaCierre.TextChanged += new System.EventHandler(this.txtDesCtaCierre_TextChanged);
            this.txtDesCtaCierre.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesCtaCierre_Validating);
            // 
            // btCtaCierre
            // 
            this.btCtaCierre.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btCtaCierre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btCtaCierre.Enabled = false;
            this.btCtaCierre.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCtaCierre.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btCtaCierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCtaCierre.Location = new System.Drawing.Point(599, 28);
            this.btCtaCierre.Name = "btCtaCierre";
            this.btCtaCierre.Size = new System.Drawing.Size(22, 18);
            this.btCtaCierre.TabIndex = 158;
            this.btCtaCierre.UseVisualStyleBackColor = true;
            this.btCtaCierre.Visible = false;
            this.btCtaCierre.Click += new System.EventHandler(this.btCtaCierre_Click);
            // 
            // chkIndCtaCierre
            // 
            this.chkIndCtaCierre.BackColor = System.Drawing.Color.LightSlateGray;
            this.chkIndCtaCierre.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndCtaCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndCtaCierre.ForeColor = System.Drawing.Color.White;
            this.chkIndCtaCierre.Location = new System.Drawing.Point(2, 0);
            this.chkIndCtaCierre.Name = "chkIndCtaCierre";
            this.chkIndCtaCierre.Size = new System.Drawing.Size(154, 18);
            this.chkIndCtaCierre.TabIndex = 51;
            this.chkIndCtaCierre.TabStop = false;
            this.chkIndCtaCierre.Text = "Cuenta Cierre";
            this.chkIndCtaCierre.UseVisualStyleBackColor = false;
            this.chkIndCtaCierre.CheckedChanged += new System.EventHandler(this.chkIndCtaCierre_CheckedChanged);
            // 
            // txtCtaCierre
            // 
            this.txtCtaCierre.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCtaCierre.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCtaCierre.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCtaCierre.Enabled = false;
            this.txtCtaCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCtaCierre.Location = new System.Drawing.Point(85, 27);
            this.txtCtaCierre.Name = "txtCtaCierre";
            this.txtCtaCierre.Size = new System.Drawing.Size(69, 20);
            this.txtCtaCierre.TabIndex = 19;
            this.txtCtaCierre.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCtaCierre.TextoVacio = "<Descripcion>";
            this.txtCtaCierre.TextChanged += new System.EventHandler(this.txtCtaCierre_TextChanged);
            this.txtCtaCierre.Leave += new System.EventHandler(this.txtCtaCierre_Leave);
            this.txtCtaCierre.Validating += new System.ComponentModel.CancelEventHandler(this.txtCtaCierre_Validating);
            // 
            // labelDegradado5
            // 
            this.labelDegradado5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado5.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado5.ForeColor = System.Drawing.Color.White;
            this.labelDegradado5.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado5.Name = "labelDegradado5";
            this.labelDegradado5.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado5.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado5.Size = new System.Drawing.Size(578, 18);
            this.labelDegradado5.TabIndex = 253;
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlGastos
            // 
            this.pnlGastos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGastos.Controls.Add(this.txtDesCtaDestino);
            this.pnlGastos.Controls.Add(this.btCtaDestino);
            this.pnlGastos.Controls.Add(this.txtDesCtaTransferencia);
            this.pnlGastos.Controls.Add(this.btCtaTransferencia);
            this.pnlGastos.Controls.Add(this.chkIndGasto);
            this.pnlGastos.Controls.Add(this.txtCtaTransferencia);
            this.pnlGastos.Controls.Add(codCuentaTransferenciaLabel);
            this.pnlGastos.Controls.Add(this.txtCtaDestino);
            this.pnlGastos.Controls.Add(codCuentaDestinoLabel);
            this.pnlGastos.Controls.Add(this.labelDegradado4);
            this.pnlGastos.Enabled = false;
            this.pnlGastos.Location = new System.Drawing.Point(3, 271);
            this.pnlGastos.Name = "pnlGastos";
            this.pnlGastos.Size = new System.Drawing.Size(580, 82);
            this.pnlGastos.TabIndex = 166;
            // 
            // txtDesCtaDestino
            // 
            this.txtDesCtaDestino.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCtaDestino.Enabled = false;
            this.txtDesCtaDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCtaDestino.Location = new System.Drawing.Point(155, 49);
            this.txtDesCtaDestino.Name = "txtDesCtaDestino";
            this.txtDesCtaDestino.Size = new System.Drawing.Size(415, 20);
            this.txtDesCtaDestino.TabIndex = 18;
            this.txtDesCtaDestino.TextChanged += new System.EventHandler(this.txtDesCtaDestino_TextChanged);
            this.txtDesCtaDestino.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesCtaDestino_Validating);
            // 
            // btCtaDestino
            // 
            this.btCtaDestino.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btCtaDestino.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btCtaDestino.Enabled = false;
            this.btCtaDestino.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCtaDestino.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btCtaDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCtaDestino.Location = new System.Drawing.Point(599, 50);
            this.btCtaDestino.Name = "btCtaDestino";
            this.btCtaDestino.Size = new System.Drawing.Size(22, 18);
            this.btCtaDestino.TabIndex = 162;
            this.btCtaDestino.UseVisualStyleBackColor = true;
            this.btCtaDestino.Visible = false;
            this.btCtaDestino.Click += new System.EventHandler(this.btCtaDestino_Click);
            // 
            // txtDesCtaTransferencia
            // 
            this.txtDesCtaTransferencia.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCtaTransferencia.Enabled = false;
            this.txtDesCtaTransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCtaTransferencia.Location = new System.Drawing.Point(155, 27);
            this.txtDesCtaTransferencia.Name = "txtDesCtaTransferencia";
            this.txtDesCtaTransferencia.Size = new System.Drawing.Size(415, 20);
            this.txtDesCtaTransferencia.TabIndex = 16;
            this.txtDesCtaTransferencia.TextChanged += new System.EventHandler(this.txtDesCtaTransferencia_TextChanged);
            this.txtDesCtaTransferencia.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesCtaTransferencia_Validating);
            // 
            // btCtaTransferencia
            // 
            this.btCtaTransferencia.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btCtaTransferencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btCtaTransferencia.Enabled = false;
            this.btCtaTransferencia.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCtaTransferencia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btCtaTransferencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCtaTransferencia.Location = new System.Drawing.Point(599, 28);
            this.btCtaTransferencia.Name = "btCtaTransferencia";
            this.btCtaTransferencia.Size = new System.Drawing.Size(22, 18);
            this.btCtaTransferencia.TabIndex = 158;
            this.btCtaTransferencia.UseVisualStyleBackColor = true;
            this.btCtaTransferencia.Visible = false;
            this.btCtaTransferencia.Click += new System.EventHandler(this.btCtaTransferencia_Click);
            // 
            // chkIndGasto
            // 
            this.chkIndGasto.BackColor = System.Drawing.Color.LightSlateGray;
            this.chkIndGasto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndGasto.ForeColor = System.Drawing.Color.White;
            this.chkIndGasto.Location = new System.Drawing.Point(2, 0);
            this.chkIndGasto.Name = "chkIndGasto";
            this.chkIndGasto.Size = new System.Drawing.Size(154, 18);
            this.chkIndGasto.TabIndex = 51;
            this.chkIndGasto.TabStop = false;
            this.chkIndGasto.Text = "Cuenta de Gastos";
            this.chkIndGasto.UseVisualStyleBackColor = false;
            this.chkIndGasto.CheckedChanged += new System.EventHandler(this.chkIndGasto_CheckedChanged);
            // 
            // txtCtaTransferencia
            // 
            this.txtCtaTransferencia.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCtaTransferencia.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCtaTransferencia.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCtaTransferencia.Enabled = false;
            this.txtCtaTransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCtaTransferencia.Location = new System.Drawing.Point(85, 27);
            this.txtCtaTransferencia.Name = "txtCtaTransferencia";
            this.txtCtaTransferencia.Size = new System.Drawing.Size(69, 20);
            this.txtCtaTransferencia.TabIndex = 15;
            this.txtCtaTransferencia.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCtaTransferencia.TextoVacio = "<Descripcion>";
            this.txtCtaTransferencia.TextChanged += new System.EventHandler(this.txtCtaTransferencia_TextChanged);
            this.txtCtaTransferencia.Validating += new System.ComponentModel.CancelEventHandler(this.txtCtaTransferencia_Validating);
            // 
            // txtCtaDestino
            // 
            this.txtCtaDestino.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCtaDestino.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCtaDestino.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCtaDestino.Enabled = false;
            this.txtCtaDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCtaDestino.Location = new System.Drawing.Point(85, 49);
            this.txtCtaDestino.Name = "txtCtaDestino";
            this.txtCtaDestino.Size = new System.Drawing.Size(69, 20);
            this.txtCtaDestino.TabIndex = 17;
            this.txtCtaDestino.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCtaDestino.TextoVacio = "<Descripcion>";
            this.txtCtaDestino.TextChanged += new System.EventHandler(this.txtCtaDestino_TextChanged);
            this.txtCtaDestino.Validating += new System.ComponentModel.CancelEventHandler(this.txtCtaDestino_Validating);
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
            this.labelDegradado4.Size = new System.Drawing.Size(578, 18);
            this.labelDegradado4.TabIndex = 253;
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCambios
            // 
            this.pnlCambios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCambios.Controls.Add(indCambio_X_CompraLabel);
            this.pnlCambios.Controls.Add(this.cboCambioCompra);
            this.pnlCambios.Controls.Add(tipAjusteLabel);
            this.pnlCambios.Controls.Add(this.cboTipoAjuste);
            this.pnlCambios.Controls.Add(this.txtDesCtaPerdida);
            this.pnlCambios.Controls.Add(this.btCtaPerdida);
            this.pnlCambios.Controls.Add(this.txtDesCtaGanancia);
            this.pnlCambios.Controls.Add(this.btCtaGanancia);
            this.pnlCambios.Controls.Add(this.chkIndAjusteCambio);
            this.pnlCambios.Controls.Add(codCuentaGananciaLabel);
            this.pnlCambios.Controls.Add(this.txtCtaPerdida);
            this.pnlCambios.Controls.Add(codCuentaPedidaLabel);
            this.pnlCambios.Controls.Add(this.txtCtaGanancia);
            this.pnlCambios.Controls.Add(this.labelDegradado3);
            this.pnlCambios.Enabled = false;
            this.pnlCambios.Location = new System.Drawing.Point(3, 168);
            this.pnlCambios.Name = "pnlCambios";
            this.pnlCambios.Size = new System.Drawing.Size(580, 101);
            this.pnlCambios.TabIndex = 159;
            // 
            // cboCambioCompra
            // 
            this.cboCambioCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCambioCompra.Enabled = false;
            this.cboCambioCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCambioCompra.FormattingEnabled = true;
            this.cboCambioCompra.Location = new System.Drawing.Point(384, 26);
            this.cboCambioCompra.Name = "cboCambioCompra";
            this.cboCambioCompra.Size = new System.Drawing.Size(186, 21);
            this.cboCambioCompra.TabIndex = 165;
            // 
            // cboTipoAjuste
            // 
            this.cboTipoAjuste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAjuste.DropDownWidth = 280;
            this.cboTipoAjuste.Enabled = false;
            this.cboTipoAjuste.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoAjuste.FormattingEnabled = true;
            this.cboTipoAjuste.Location = new System.Drawing.Point(85, 26);
            this.cboTipoAjuste.Name = "cboTipoAjuste";
            this.cboTipoAjuste.Size = new System.Drawing.Size(206, 21);
            this.cboTipoAjuste.TabIndex = 164;
            // 
            // txtDesCtaPerdida
            // 
            this.txtDesCtaPerdida.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCtaPerdida.Enabled = false;
            this.txtDesCtaPerdida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCtaPerdida.Location = new System.Drawing.Point(155, 71);
            this.txtDesCtaPerdida.Name = "txtDesCtaPerdida";
            this.txtDesCtaPerdida.Size = new System.Drawing.Size(415, 20);
            this.txtDesCtaPerdida.TabIndex = 14;
            this.txtDesCtaPerdida.TextChanged += new System.EventHandler(this.txtDesCtaPerdida_TextChanged);
            this.txtDesCtaPerdida.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesCtaPerdida_Validating);
            // 
            // btCtaPerdida
            // 
            this.btCtaPerdida.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btCtaPerdida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btCtaPerdida.Enabled = false;
            this.btCtaPerdida.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCtaPerdida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btCtaPerdida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCtaPerdida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCtaPerdida.Location = new System.Drawing.Point(600, 74);
            this.btCtaPerdida.Name = "btCtaPerdida";
            this.btCtaPerdida.Size = new System.Drawing.Size(22, 18);
            this.btCtaPerdida.TabIndex = 162;
            this.btCtaPerdida.UseVisualStyleBackColor = true;
            this.btCtaPerdida.Visible = false;
            this.btCtaPerdida.Click += new System.EventHandler(this.btCtaPerdida_Click);
            // 
            // txtDesCtaGanancia
            // 
            this.txtDesCtaGanancia.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCtaGanancia.Enabled = false;
            this.txtDesCtaGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCtaGanancia.Location = new System.Drawing.Point(155, 49);
            this.txtDesCtaGanancia.Name = "txtDesCtaGanancia";
            this.txtDesCtaGanancia.Size = new System.Drawing.Size(415, 20);
            this.txtDesCtaGanancia.TabIndex = 12;
            this.txtDesCtaGanancia.TextChanged += new System.EventHandler(this.txtDesCtaGanancia_TextChanged);
            this.txtDesCtaGanancia.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesCtaGanancia_Validating);
            // 
            // btCtaGanancia
            // 
            this.btCtaGanancia.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btCtaGanancia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btCtaGanancia.Enabled = false;
            this.btCtaGanancia.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCtaGanancia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btCtaGanancia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCtaGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCtaGanancia.Location = new System.Drawing.Point(600, 52);
            this.btCtaGanancia.Name = "btCtaGanancia";
            this.btCtaGanancia.Size = new System.Drawing.Size(22, 18);
            this.btCtaGanancia.TabIndex = 158;
            this.btCtaGanancia.UseVisualStyleBackColor = true;
            this.btCtaGanancia.Visible = false;
            this.btCtaGanancia.Click += new System.EventHandler(this.btCtaGanancia_Click);
            // 
            // chkIndAjusteCambio
            // 
            this.chkIndAjusteCambio.BackColor = System.Drawing.Color.LightSlateGray;
            this.chkIndAjusteCambio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndAjusteCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndAjusteCambio.ForeColor = System.Drawing.Color.White;
            this.chkIndAjusteCambio.Location = new System.Drawing.Point(2, 1);
            this.chkIndAjusteCambio.Name = "chkIndAjusteCambio";
            this.chkIndAjusteCambio.Size = new System.Drawing.Size(154, 15);
            this.chkIndAjusteCambio.TabIndex = 51;
            this.chkIndAjusteCambio.TabStop = false;
            this.chkIndAjusteCambio.Text = "Ajuste de Cambio";
            this.chkIndAjusteCambio.UseVisualStyleBackColor = false;
            this.chkIndAjusteCambio.CheckedChanged += new System.EventHandler(this.chkIndAjusteCambio_CheckedChanged);
            // 
            // txtCtaPerdida
            // 
            this.txtCtaPerdida.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCtaPerdida.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCtaPerdida.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCtaPerdida.Enabled = false;
            this.txtCtaPerdida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCtaPerdida.Location = new System.Drawing.Point(85, 71);
            this.txtCtaPerdida.Name = "txtCtaPerdida";
            this.txtCtaPerdida.Size = new System.Drawing.Size(69, 20);
            this.txtCtaPerdida.TabIndex = 13;
            this.txtCtaPerdida.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCtaPerdida.TextoVacio = "<Descripcion>";
            this.txtCtaPerdida.TextChanged += new System.EventHandler(this.txtCtaPerdida_TextChanged);
            this.txtCtaPerdida.Validating += new System.ComponentModel.CancelEventHandler(this.txtCtaPerdida_Validating);
            // 
            // txtCtaGanancia
            // 
            this.txtCtaGanancia.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCtaGanancia.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCtaGanancia.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCtaGanancia.Enabled = false;
            this.txtCtaGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCtaGanancia.Location = new System.Drawing.Point(85, 49);
            this.txtCtaGanancia.Name = "txtCtaGanancia";
            this.txtCtaGanancia.Size = new System.Drawing.Size(69, 20);
            this.txtCtaGanancia.TabIndex = 11;
            this.txtCtaGanancia.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCtaGanancia.TextoVacio = "<Descripcion>";
            this.txtCtaGanancia.TextChanged += new System.EventHandler(this.txtCtaGanancia_TextChanged);
            this.txtCtaGanancia.Validating += new System.ComponentModel.CancelEventHandler(this.txtCtaGanancia_Validating);
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(578, 18);
            this.labelDegradado3.TabIndex = 253;
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCuenta
            // 
            this.pnlCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCuenta.Controls.Add(this.txtAuxiliar);
            this.pnlCuenta.Controls.Add(label7);
            this.pnlCuenta.Controls.Add(this.txtTipPartidaPre);
            this.pnlCuenta.Controls.Add(this.labelDegradado1);
            this.pnlCuenta.Controls.Add(this.txtUltimoDigito);
            this.pnlCuenta.Controls.Add(this.cboIndNaturaleza);
            this.pnlCuenta.Controls.Add(this.btPresupuesto);
            this.pnlCuenta.Controls.Add(this.txtDesCuenta);
            this.pnlCuenta.Controls.Add(descripcionLabel);
            this.pnlCuenta.Controls.Add(codPartidaPresuLabel);
            this.pnlCuenta.Controls.Add(this.txtCodPartidaPre);
            this.pnlCuenta.Controls.Add(codCuentaLabel);
            this.pnlCuenta.Controls.Add(this.txtCuenta);
            this.pnlCuenta.Enabled = false;
            this.pnlCuenta.Location = new System.Drawing.Point(3, 64);
            this.pnlCuenta.Name = "pnlCuenta";
            this.pnlCuenta.Size = new System.Drawing.Size(580, 102);
            this.pnlCuenta.TabIndex = 154;
            // 
            // txtAuxiliar
            // 
            this.txtAuxiliar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtAuxiliar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuxiliar.Location = new System.Drawing.Point(85, 73);
            this.txtAuxiliar.Name = "txtAuxiliar";
            this.txtAuxiliar.Size = new System.Drawing.Size(488, 20);
            this.txtAuxiliar.TabIndex = 254;
            this.txtAuxiliar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtAuxiliar.TextoVacio = "<Descripcion>";
            this.txtAuxiliar.TextChanged += new System.EventHandler(this.txtAuxiliar_TextChanged);
            this.txtAuxiliar.Validating += new System.ComponentModel.CancelEventHandler(this.txtAuxiliar_Validating);
            // 
            // txtTipPartidaPre
            // 
            this.txtTipPartidaPre.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTipPartidaPre.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTipPartidaPre.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTipPartidaPre.Enabled = false;
            this.txtTipPartidaPre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipPartidaPre.Location = new System.Drawing.Point(390, 29);
            this.txtTipPartidaPre.Name = "txtTipPartidaPre";
            this.txtTipPartidaPre.Size = new System.Drawing.Size(53, 20);
            this.txtTipPartidaPre.TabIndex = 252;
            this.txtTipPartidaPre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTipPartidaPre.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtTipPartidaPre.TextoVacio = "<Descripcion>";
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
            this.labelDegradado1.Size = new System.Drawing.Size(578, 18);
            this.labelDegradado1.TabIndex = 251;
            this.labelDegradado1.Text = "Descripción";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUltimoDigito
            // 
            this.txtUltimoDigito.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtUltimoDigito.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUltimoDigito.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtUltimoDigito.Enabled = false;
            this.txtUltimoDigito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUltimoDigito.Location = new System.Drawing.Point(157, 29);
            this.txtUltimoDigito.MaxLength = 1;
            this.txtUltimoDigito.Name = "txtUltimoDigito";
            this.txtUltimoDigito.Size = new System.Drawing.Size(53, 20);
            this.txtUltimoDigito.TabIndex = 1;
            this.txtUltimoDigito.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtUltimoDigito.TextoVacio = "<Descripcion>";
            // 
            // cboIndNaturaleza
            // 
            this.cboIndNaturaleza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIndNaturaleza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIndNaturaleza.FormattingEnabled = true;
            this.cboIndNaturaleza.Location = new System.Drawing.Point(213, 29);
            this.cboIndNaturaleza.Name = "cboIndNaturaleza";
            this.cboIndNaturaleza.Size = new System.Drawing.Size(100, 21);
            this.cboIndNaturaleza.TabIndex = 1;
            // 
            // btPresupuesto
            // 
            this.btPresupuesto.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btPresupuesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btPresupuesto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btPresupuesto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btPresupuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPresupuesto.Location = new System.Drawing.Point(551, 30);
            this.btPresupuesto.Name = "btPresupuesto";
            this.btPresupuesto.Size = new System.Drawing.Size(22, 18);
            this.btPresupuesto.TabIndex = 154;
            this.btPresupuesto.UseVisualStyleBackColor = true;
            this.btPresupuesto.Click += new System.EventHandler(this.btPresupuesto_Click);
            // 
            // txtDesCuenta
            // 
            this.txtDesCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuenta.Location = new System.Drawing.Point(85, 51);
            this.txtDesCuenta.Name = "txtDesCuenta";
            this.txtDesCuenta.Size = new System.Drawing.Size(488, 20);
            this.txtDesCuenta.TabIndex = 23;
            this.txtDesCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesCuenta.TextoVacio = "<Descripcion>";
            // 
            // txtCodPartidaPre
            // 
            this.txtCodPartidaPre.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodPartidaPre.BackColor = System.Drawing.Color.White;
            this.txtCodPartidaPre.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodPartidaPre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPartidaPre.Location = new System.Drawing.Point(445, 29);
            this.txtCodPartidaPre.Name = "txtCodPartidaPre";
            this.txtCodPartidaPre.Size = new System.Drawing.Size(104, 20);
            this.txtCodPartidaPre.TabIndex = 21;
            this.txtCodPartidaPre.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodPartidaPre.TextoVacio = "<Descripcion>";
            this.txtCodPartidaPre.TextChanged += new System.EventHandler(this.txtCodPartidaPre_TextChanged);
            // 
            // txtCuenta
            // 
            this.txtCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuenta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuenta.Enabled = false;
            this.txtCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuenta.Location = new System.Drawing.Point(85, 29);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(70, 20);
            this.txtCuenta.TabIndex = 3;
            this.txtCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCuenta.TextoVacio = "<Descripcion>";
            // 
            // pnlCuentaSup
            // 
            this.pnlCuentaSup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCuentaSup.Controls.Add(this.lblRegistros);
            this.pnlCuentaSup.Controls.Add(this.txtDesCtaSuperior);
            this.pnlCuentaSup.Controls.Add(this.txtCtaSuperior);
            this.pnlCuentaSup.Controls.Add(codCuentaSupLabel);
            this.pnlCuentaSup.Location = new System.Drawing.Point(3, 3);
            this.pnlCuentaSup.Name = "pnlCuentaSup";
            this.pnlCuentaSup.Size = new System.Drawing.Size(580, 59);
            this.pnlCuentaSup.TabIndex = 85;
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
            this.lblRegistros.Size = new System.Drawing.Size(578, 18);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Nivel Superior";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDesCtaSuperior
            // 
            this.txtDesCtaSuperior.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCtaSuperior.Enabled = false;
            this.txtDesCtaSuperior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCtaSuperior.Location = new System.Drawing.Point(161, 27);
            this.txtDesCtaSuperior.Name = "txtDesCtaSuperior";
            this.txtDesCtaSuperior.Size = new System.Drawing.Size(402, 20);
            this.txtDesCtaSuperior.TabIndex = 160;
            // 
            // txtCtaSuperior
            // 
            this.txtCtaSuperior.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCtaSuperior.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCtaSuperior.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCtaSuperior.Enabled = false;
            this.txtCtaSuperior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCtaSuperior.Location = new System.Drawing.Point(92, 27);
            this.txtCtaSuperior.Name = "txtCtaSuperior";
            this.txtCtaSuperior.Size = new System.Drawing.Size(69, 20);
            this.txtCtaSuperior.TabIndex = 15;
            this.txtCtaSuperior.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCtaSuperior.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCtaSuperior.TextoVacio = "<Descripcion>";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado7);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(585, 355);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(320, 120);
            this.pnlAuditoria.TabIndex = 84;
            // 
            // labelDegradado7
            // 
            this.labelDegradado7.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado7.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado7.ForeColor = System.Drawing.Color.White;
            this.labelDegradado7.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado7.Name = "labelDegradado7";
            this.labelDegradado7.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado7.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado7.Size = new System.Drawing.Size(318, 18);
            this.labelDegradado7.TabIndex = 253;
            this.labelDegradado7.Text = "Auditoria";
            this.labelDegradado7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(140, 89);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(153, 20);
            this.txtFechaModificacion.TabIndex = 7;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(140, 26);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(153, 20);
            this.txtUsuarioRegistro.TabIndex = 1;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(140, 68);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(153, 20);
            this.txtUsuarioModificacion.TabIndex = 5;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(140, 47);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(153, 20);
            this.txtFechaRegistro.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkIndReporte);
            this.panel1.Controls.Add(this.labelDegradado8);
            this.panel1.Controls.Add(this.txtTitulo);
            this.panel1.Location = new System.Drawing.Point(585, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 82);
            this.panel1.TabIndex = 254;
            // 
            // chkIndReporte
            // 
            this.chkIndReporte.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndReporte.Location = new System.Drawing.Point(15, 26);
            this.chkIndReporte.Name = "chkIndReporte";
            this.chkIndReporte.Size = new System.Drawing.Size(133, 20);
            this.chkIndReporte.TabIndex = 254;
            this.chkIndReporte.Text = "Va para el reporte";
            this.chkIndReporte.UseVisualStyleBackColor = true;
            this.chkIndReporte.CheckedChanged += new System.EventHandler(this.chkIndReporte_CheckedChanged);
            // 
            // labelDegradado8
            // 
            this.labelDegradado8.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado8.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado8.ForeColor = System.Drawing.Color.White;
            this.labelDegradado8.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado8.Name = "labelDegradado8";
            this.labelDegradado8.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado8.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado8.Size = new System.Drawing.Size(318, 18);
            this.labelDegradado8.TabIndex = 253;
            this.labelDegradado8.Text = "Libro Diario Simplificado";
            this.labelDegradado8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTitulo
            // 
            this.txtTitulo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTitulo.Enabled = false;
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(15, 51);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(287, 20);
            this.txtTitulo.TabIndex = 1;
            // 
            // txtCCostos
            // 
            this.txtCCostos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCCostos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCCostos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCCostos.Enabled = false;
            this.txtCCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCostos.Location = new System.Drawing.Point(155, 71);
            this.txtCCostos.Name = "txtCCostos";
            this.txtCCostos.Size = new System.Drawing.Size(133, 20);
            this.txtCCostos.TabIndex = 1501;
            this.txtCCostos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCCostos.TextoVacio = "<Descripcion>";
            // 
            // btCentroC
            // 
            this.btCentroC.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCentroC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCentroC.Enabled = false;
            this.btCentroC.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCentroC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCentroC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCentroC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCentroC.Location = new System.Drawing.Point(294, 73);
            this.btCentroC.Name = "btCentroC";
            this.btCentroC.Size = new System.Drawing.Size(16, 16);
            this.btCentroC.TabIndex = 1502;
            this.btCentroC.TabStop = false;
            this.btCentroC.UseVisualStyleBackColor = true;
            this.btCentroC.Click += new System.EventHandler(this.btCentroC_Click);
            // 
            // frmCuentaContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(908, 478);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlRenta);
            this.Controls.Add(this.pnlChecks);
            this.Controls.Add(this.pnlConfiguracion);
            this.Controls.Add(this.pblCierre);
            this.Controls.Add(this.pnlGastos);
            this.Controls.Add(this.pnlCambios);
            this.Controls.Add(this.pnlCuenta);
            this.Controls.Add(this.pnlCuentaSup);
            this.Controls.Add(this.pnlAuditoria);
            this.MaximizeBox = false;
            this.Name = "frmCuentaContable";
            this.Text = "Cuenta Contable";
            this.Load += new System.EventHandler(this.frmCuentaContable_Load);
            this.pnlRenta.ResumeLayout(false);
            this.pnlRenta.PerformLayout();
            this.pnlChecks.ResumeLayout(false);
            this.pnlChecks.PerformLayout();
            this.pnlConfiguracion.ResumeLayout(false);
            this.pnlConfiguracion.PerformLayout();
            this.pblCierre.ResumeLayout(false);
            this.pblCierre.PerformLayout();
            this.pnlGastos.ResumeLayout(false);
            this.pnlGastos.PerformLayout();
            this.pnlCambios.ResumeLayout(false);
            this.pnlCambios.PerformLayout();
            this.pnlCuenta.ResumeLayout(false);
            this.pnlCuenta.PerformLayout();
            this.pnlCuentaSup.ResumeLayout(false);
            this.pnlCuentaSup.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ControlesWinForm.SuperTextBox txtCuenta;
        private ControlesWinForm.SuperTextBox txtCtaCierre;
        private ControlesWinForm.SuperTextBox txtCtaDestino;
        private ControlesWinForm.SuperTextBox txtCtaGanancia;
        private ControlesWinForm.SuperTextBox txtCtaPerdida;
        private ControlesWinForm.SuperTextBox txtCtaSuperior;
        private ControlesWinForm.SuperTextBox txtCtaTransferencia;
        private ControlesWinForm.SuperTextBox txtCodPartidaPre;
        private ControlesWinForm.SuperTextBox txtDesCuenta;
        private System.Windows.Forms.CheckBox chkIndAnexoReferencial;
        private System.Windows.Forms.CheckBox chkIndCajaChica;
        private System.Windows.Forms.CheckBox chkCtaCte;
        private System.Windows.Forms.CheckBox chkIndCtaIngreso;
        private System.Windows.Forms.CheckBox chkIndNotaIngreso;
        private System.Windows.Forms.CheckBox chkIndSolicitaCc;
        private System.Windows.Forms.CheckBox chkIndSolicitaDcto;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Panel pnlCuentaSup;
        private System.Windows.Forms.Panel pnlCuenta;
        private System.Windows.Forms.TextBox txtDesCtaSuperior;
        private ControlesWinForm.SuperTextBox txtUltimoDigito;
        private System.Windows.Forms.ComboBox cboIndNaturaleza;
        private System.Windows.Forms.Button btPresupuesto;
        private System.Windows.Forms.Panel pnlCambios;
        private System.Windows.Forms.ComboBox cboCambioCompra;
        private System.Windows.Forms.ComboBox cboTipoAjuste;
        private System.Windows.Forms.TextBox txtDesCtaPerdida;
        private System.Windows.Forms.Button btCtaPerdida;
        private System.Windows.Forms.TextBox txtDesCtaGanancia;
        private System.Windows.Forms.Button btCtaGanancia;
        private System.Windows.Forms.CheckBox chkIndAjusteCambio;
        private System.Windows.Forms.Panel pnlGastos;
        private System.Windows.Forms.TextBox txtDesCtaDestino;
        private System.Windows.Forms.Button btCtaDestino;
        private System.Windows.Forms.TextBox txtDesCtaTransferencia;
        private System.Windows.Forms.Button btCtaTransferencia;
        private System.Windows.Forms.CheckBox chkIndGasto;
        private System.Windows.Forms.Panel pblCierre;
        private System.Windows.Forms.TextBox txtDesCtaCierre;
        private System.Windows.Forms.Button btCtaCierre;
        private System.Windows.Forms.CheckBox chkIndCtaCierre;
        private System.Windows.Forms.Panel pnlConfiguracion;
        private System.Windows.Forms.ComboBox cboTipoNodo;
        private System.Windows.Forms.ComboBox cboBalance;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.ComboBox cboColumnaCoVen;
        private System.Windows.Forms.Panel pnlChecks;
        private System.Windows.Forms.ComboBox cboTipoCajaChica;
        private System.Windows.Forms.CheckBox chkIndSolicitaAnexo;
        private MyLabelG.LabelDegradado labelDegradado6;
        private MyLabelG.LabelDegradado labelDegradado5;
        private MyLabelG.LabelDegradado labelDegradado4;
        private MyLabelG.LabelDegradado labelDegradado3;
        private MyLabelG.LabelDegradado labelDegradado1;
        private MyLabelG.LabelDegradado lblRegistros;
        private MyLabelG.LabelDegradado labelDegradado7;
        private System.Windows.Forms.Panel pnlRenta;
        private System.Windows.Forms.ComboBox cboTasa;
        private System.Windows.Forms.CheckBox chkTasa;
        private MyLabelG.LabelDegradado labelDegradado2;
        private ControlesWinForm.SuperTextBox txtTipPartidaPre;
        private System.Windows.Forms.Button btQuitarTasa;
        private System.Windows.Forms.Button btInsertarTasa;
        private System.Windows.Forms.ComboBox cboTasaCuenta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkIndReporte;
        private MyLabelG.LabelDegradado labelDegradado8;
        private System.Windows.Forms.TextBox txtTitulo;
        private ControlesWinForm.SuperTextBox txtAuxiliar;
        private System.Windows.Forms.Button btAuxiliar;
        private System.Windows.Forms.Button btCcostos;
        private System.Windows.Forms.Button btDocumento;
        private ControlesWinForm.SuperTextBox txtCCostos;
        private System.Windows.Forms.Button btCentroC;
    }
}