namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmProvisionLiquidacion
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
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label numFileLabel;
            System.Windows.Forms.Label impMonedaOrigenLabel;
            System.Windows.Forms.Label idProvisionLabel;
            System.Windows.Forms.Label numDiasVenLabel;
            System.Windows.Forms.Label idPersonaLabel;
            System.Windows.Forms.Label fechaDocumentoLabel;
            System.Windows.Forms.Label desProvisionLabel;
            System.Windows.Forms.Label codMonedaProvisionLabel1;
            System.Windows.Forms.Label codCuentaLabel;
            System.Windows.Forms.Label idDocumentoLabel1;
            System.Windows.Forms.Label fechaProvisionLabel;
            System.Windows.Forms.Label fechaVencimientoLabel;
            System.Windows.Forms.Label numGuiaLabel;
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label29;
            System.Windows.Forms.Label label31;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label impAjusteSecunLabel;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label impAjusteBaseLabel;
            System.Windows.Forms.Label impExonSecunLabel;
            System.Windows.Forms.Label impImpuestoBaseLabel;
            System.Windows.Forms.Label impTotalBaseLabel;
            System.Windows.Forms.Label impImpuestoSecunLabel;
            System.Windows.Forms.Label impImponSecunLabel;
            System.Windows.Forms.Label impExonBaseLabel;
            System.Windows.Forms.Label impTotalSecunLabel;
            System.Windows.Forms.Label impImponBaseLabel;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label tipo_detraccionLabel;
            System.Windows.Forms.Label ret_numeroLabel;
            System.Windows.Forms.Label tasa_detraccionLabel;
            System.Windows.Forms.Label ret_fechaLabel;
            System.Windows.Forms.Label monto_detraccionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProvisionLiquidacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bsprovisionesccosto = new System.Windows.Forms.BindingSource(this.components);
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.tProvision = new System.Windows.Forms.TabControl();
            this.tpProvision = new System.Windows.Forms.TabPage();
            this.pnlProvision1 = new System.Windows.Forms.Panel();
            this.pnlDetraccion = new System.Windows.Forms.Panel();
            this.txtMontoDetraD = new ControlesWinForm.SuperTextBox();
            this.chkPagoDetra = new System.Windows.Forms.CheckBox();
            this.chkDetraccion = new System.Windows.Forms.CheckBox();
            this.txtNumDetraccion = new ControlesWinForm.SuperTextBox();
            this.txtMontoDetraS = new ControlesWinForm.SuperTextBox();
            this.cbotipodetraccion = new System.Windows.Forms.ComboBox();
            this.txtTasaDetra = new ControlesWinForm.SuperTextBox();
            this.dtpFecRetencion = new System.Windows.Forms.DateTimePicker();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.pnlProvision = new System.Windows.Forms.Panel();
            this.chkConversion = new System.Windows.Forms.CheckBox();
            this.btConversion = new System.Windows.Forms.Button();
            this.txtCodConversion = new System.Windows.Forms.TextBox();
            this.btCosto = new System.Windows.Forms.Button();
            this.txtNumHojaCosto = new ControlesWinForm.SuperTextBox();
            this.chkIndCosto = new System.Windows.Forms.CheckBox();
            this.chkIndDistribucion = new System.Windows.Forms.CheckBox();
            this.dtpFecRef = new System.Windows.Forms.DateTimePicker();
            this.cboReferencia = new System.Windows.Forms.ComboBox();
            this.txtSerieRef = new ControlesWinForm.SuperTextBox();
            this.txtNumRef = new ControlesWinForm.SuperTextBox();
            this.btReparable = new System.Windows.Forms.Button();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtIdProveedor = new ControlesWinForm.SuperTextBox();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.txtIdProvision = new System.Windows.Forms.TextBox();
            this.dtpFecDocumento = new System.Windows.Forms.DateTimePicker();
            this.txtNumDiasVen = new ControlesWinForm.SuperTextBox();
            this.txtTipCambio = new ControlesWinForm.SuperTextBox();
            this.cboDocumento = new System.Windows.Forms.ComboBox();
            this.chkIndCalcAuto = new System.Windows.Forms.CheckBox();
            this.txtDesEstado = new System.Windows.Forms.TextBox();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.dtpFechaProvision = new System.Windows.Forms.DateTimePicker();
            this.dtpFecVencimiento = new System.Windows.Forms.DateTimePicker();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.txtSerie = new ControlesWinForm.SuperTextBox();
            this.txtNumero = new ControlesWinForm.SuperTextBox();
            this.txtImporteOrigen = new ControlesWinForm.SuperTextBox();
            this.txtGuia = new ControlesWinForm.SuperTextBox();
            this.txtCodCuenta = new ControlesWinForm.SuperTextBox();
            this.txtDesCuenta = new ControlesWinForm.SuperTextBox();
            this.txtDesProvision = new ControlesWinForm.SuperTextBox();
            this.cboTipoAsiento = new System.Windows.Forms.ComboBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado9 = new MyLabelG.LabelDegradado();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.pnlMontos = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTotalSecu = new ControlesWinForm.SuperTextBox();
            this.txtAjusteSecu = new ControlesWinForm.SuperTextBox();
            this.txtExoneradoSecu = new ControlesWinForm.SuperTextBox();
            this.txtImpuestoSecu = new ControlesWinForm.SuperTextBox();
            this.txtBaseSecu = new ControlesWinForm.SuperTextBox();
            this.txtTotal = new ControlesWinForm.SuperTextBox();
            this.txtAjuste = new ControlesWinForm.SuperTextBox();
            this.txtExonerado = new ControlesWinForm.SuperTextBox();
            this.txtImpuesto = new ControlesWinForm.SuperTextBox();
            this.labelDegradado5 = new MyLabelG.LabelDegradado();
            this.txtBaseImponible = new ControlesWinForm.SuperTextBox();
            this.tpDetalle = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btConceptos = new System.Windows.Forms.Button();
            this.btActivos = new System.Windows.Forms.Button();
            this.btServicios = new System.Windows.Forms.Button();
            this.btGastos = new System.Windows.Forms.Button();
            this.btArticulos = new System.Windows.Forms.Button();
            this.dgvprovisionesccosto = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesColumnaCoven = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            numFileLabel = new System.Windows.Forms.Label();
            impMonedaOrigenLabel = new System.Windows.Forms.Label();
            idProvisionLabel = new System.Windows.Forms.Label();
            numDiasVenLabel = new System.Windows.Forms.Label();
            idPersonaLabel = new System.Windows.Forms.Label();
            fechaDocumentoLabel = new System.Windows.Forms.Label();
            desProvisionLabel = new System.Windows.Forms.Label();
            codMonedaProvisionLabel1 = new System.Windows.Forms.Label();
            codCuentaLabel = new System.Windows.Forms.Label();
            idDocumentoLabel1 = new System.Windows.Forms.Label();
            fechaProvisionLabel = new System.Windows.Forms.Label();
            fechaVencimientoLabel = new System.Windows.Forms.Label();
            numGuiaLabel = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            impAjusteSecunLabel = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            impAjusteBaseLabel = new System.Windows.Forms.Label();
            impExonSecunLabel = new System.Windows.Forms.Label();
            impImpuestoBaseLabel = new System.Windows.Forms.Label();
            impTotalBaseLabel = new System.Windows.Forms.Label();
            impImpuestoSecunLabel = new System.Windows.Forms.Label();
            impImponSecunLabel = new System.Windows.Forms.Label();
            impExonBaseLabel = new System.Windows.Forms.Label();
            impTotalSecunLabel = new System.Windows.Forms.Label();
            impImponBaseLabel = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            tipo_detraccionLabel = new System.Windows.Forms.Label();
            ret_numeroLabel = new System.Windows.Forms.Label();
            tasa_detraccionLabel = new System.Windows.Forms.Label();
            ret_fechaLabel = new System.Windows.Forms.Label();
            monto_detraccionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsprovisionesccosto)).BeginInit();
            this.tProvision.SuspendLayout();
            this.tpProvision.SuspendLayout();
            this.pnlProvision1.SuspendLayout();
            this.pnlDetraccion.SuspendLayout();
            this.pnlProvision.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.pnlMontos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tpDetalle.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvprovisionesccosto)).BeginInit();
            this.SuspendLayout();
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label19.Location = new System.Drawing.Point(392, 92);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(60, 13);
            label19.TabIndex = 390;
            label19.Text = "Fecha Ref.";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label20.Location = new System.Drawing.Point(7, 92);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(79, 13);
            label20.TabIndex = 391;
            label20.Text = "Documen. Ref.";
            // 
            // numFileLabel
            // 
            numFileLabel.AutoSize = true;
            numFileLabel.Location = new System.Drawing.Point(7, 115);
            numFileLabel.Name = "numFileLabel";
            numFileLabel.Size = new System.Drawing.Size(66, 13);
            numFileLabel.TabIndex = 65;
            numFileLabel.Text = "Tipo Asiento";
            // 
            // impMonedaOrigenLabel
            // 
            impMonedaOrigenLabel.AutoSize = true;
            impMonedaOrigenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            impMonedaOrigenLabel.Location = new System.Drawing.Point(651, 70);
            impMonedaOrigenLabel.Name = "impMonedaOrigenLabel";
            impMonedaOrigenLabel.Size = new System.Drawing.Size(37, 13);
            impMonedaOrigenLabel.TabIndex = 361;
            impMonedaOrigenLabel.Text = "Monto";
            // 
            // idProvisionLabel
            // 
            idProvisionLabel.AutoSize = true;
            idProvisionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idProvisionLabel.Location = new System.Drawing.Point(7, 26);
            idProvisionLabel.Name = "idProvisionLabel";
            idProvisionLabel.Size = new System.Drawing.Size(27, 13);
            idProvisionLabel.TabIndex = 35;
            idProvisionLabel.Text = "Nro.";
            // 
            // numDiasVenLabel
            // 
            numDiasVenLabel.AutoSize = true;
            numDiasVenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numDiasVenLabel.Location = new System.Drawing.Point(215, 160);
            numDiasVenLabel.Name = "numDiasVenLabel";
            numDiasVenLabel.Size = new System.Drawing.Size(28, 13);
            numDiasVenLabel.TabIndex = 61;
            numDiasVenLabel.Text = "Dias";
            // 
            // idPersonaLabel
            // 
            idPersonaLabel.AutoSize = true;
            idPersonaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idPersonaLabel.Location = new System.Drawing.Point(7, 48);
            idPersonaLabel.Name = "idPersonaLabel";
            idPersonaLabel.Size = new System.Drawing.Size(56, 13);
            idPersonaLabel.TabIndex = 31;
            idPersonaLabel.Text = "Proveedor";
            // 
            // fechaDocumentoLabel
            // 
            fechaDocumentoLabel.AutoSize = true;
            fechaDocumentoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaDocumentoLabel.Location = new System.Drawing.Point(392, 70);
            fechaDocumentoLabel.Name = "fechaDocumentoLabel";
            fechaDocumentoLabel.Size = new System.Drawing.Size(63, 13);
            fechaDocumentoLabel.TabIndex = 13;
            fechaDocumentoLabel.Text = "Fecha Doc.";
            // 
            // desProvisionLabel
            // 
            desProvisionLabel.AutoSize = true;
            desProvisionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            desProvisionLabel.Location = new System.Drawing.Point(432, 114);
            desProvisionLabel.Name = "desProvisionLabel";
            desProvisionLabel.Size = new System.Drawing.Size(34, 13);
            desProvisionLabel.TabIndex = 9;
            desProvisionLabel.Text = "Glosa";
            // 
            // codMonedaProvisionLabel1
            // 
            codMonedaProvisionLabel1.AutoSize = true;
            codMonedaProvisionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codMonedaProvisionLabel1.Location = new System.Drawing.Point(536, 70);
            codMonedaProvisionLabel1.Name = "codMonedaProvisionLabel1";
            codMonedaProvisionLabel1.Size = new System.Drawing.Size(46, 13);
            codMonedaProvisionLabel1.TabIndex = 86;
            codMonedaProvisionLabel1.Text = "Moneda";
            // 
            // codCuentaLabel
            // 
            codCuentaLabel.AutoSize = true;
            codCuentaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codCuentaLabel.Location = new System.Drawing.Point(7, 138);
            codCuentaLabel.Name = "codCuentaLabel";
            codCuentaLabel.Size = new System.Drawing.Size(41, 13);
            codCuentaLabel.TabIndex = 3;
            codCuentaLabel.Text = "Cuenta";
            // 
            // idDocumentoLabel1
            // 
            idDocumentoLabel1.AutoSize = true;
            idDocumentoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idDocumentoLabel1.Location = new System.Drawing.Point(7, 70);
            idDocumentoLabel1.Name = "idDocumentoLabel1";
            idDocumentoLabel1.Size = new System.Drawing.Size(62, 13);
            idDocumentoLabel1.TabIndex = 87;
            idDocumentoLabel1.Text = "Documento";
            // 
            // fechaProvisionLabel
            // 
            fechaProvisionLabel.AutoSize = true;
            fechaProvisionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaProvisionLabel.Location = new System.Drawing.Point(148, 26);
            fechaProvisionLabel.Name = "fechaProvisionLabel";
            fechaProvisionLabel.Size = new System.Drawing.Size(40, 13);
            fechaProvisionLabel.TabIndex = 15;
            fechaProvisionLabel.Text = "Fecha ";
            // 
            // fechaVencimientoLabel
            // 
            fechaVencimientoLabel.AutoSize = true;
            fechaVencimientoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaVencimientoLabel.Location = new System.Drawing.Point(291, 160);
            fechaVencimientoLabel.Name = "fechaVencimientoLabel";
            fechaVencimientoLabel.Size = new System.Drawing.Size(56, 13);
            fechaVencimientoLabel.TabIndex = 17;
            fechaVencimientoLabel.Text = "Fec.Venc.";
            // 
            // numGuiaLabel
            // 
            numGuiaLabel.AutoSize = true;
            numGuiaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numGuiaLabel.Location = new System.Drawing.Point(650, 93);
            numGuiaLabel.Name = "numGuiaLabel";
            numGuiaLabel.Size = new System.Drawing.Size(57, 13);
            numGuiaLabel.TabIndex = 67;
            numGuiaLabel.Text = "Num. Guia";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label24.Location = new System.Drawing.Point(16, 102);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(97, 13);
            label24.TabIndex = 6;
            label24.Text = "Fecha Modificacion";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.Location = new System.Drawing.Point(16, 80);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(104, 13);
            label25.TabIndex = 4;
            label25.Text = "Usuario Modificacion";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label29.Location = new System.Drawing.Point(16, 36);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(86, 13);
            label29.TabIndex = 0;
            label29.Text = "Usuario Registro";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label31.Location = new System.Drawing.Point(16, 58);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(79, 13);
            label31.TabIndex = 2;
            label31.Text = "Fecha Registro";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(71, 50);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(22, 13);
            label3.TabIndex = 343;
            label3.Text = "S/.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(259, 71);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(28, 13);
            label8.TabIndex = 348;
            label8.Text = "US$";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(259, 50);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(28, 13);
            label7.TabIndex = 347;
            label7.Text = "US$";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(71, 71);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(22, 13);
            label4.TabIndex = 344;
            label4.Text = "S/.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(71, 29);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(22, 13);
            label2.TabIndex = 342;
            label2.Text = "S/.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(259, 29);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(28, 13);
            label1.TabIndex = 341;
            label1.Text = "US$";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(259, 92);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(28, 13);
            label9.TabIndex = 349;
            label9.Text = "US$";
            // 
            // impAjusteSecunLabel
            // 
            impAjusteSecunLabel.AutoSize = true;
            impAjusteSecunLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            impAjusteSecunLabel.Location = new System.Drawing.Point(199, 92);
            impAjusteSecunLabel.Name = "impAjusteSecunLabel";
            impAjusteSecunLabel.Size = new System.Drawing.Size(36, 13);
            impAjusteSecunLabel.TabIndex = 41;
            impAjusteSecunLabel.Text = "Ajuste";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(71, 113);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(22, 13);
            label6.TabIndex = 346;
            label6.Text = "S/.";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(259, 113);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(28, 13);
            label10.TabIndex = 350;
            label10.Text = "US$";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(71, 92);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(22, 13);
            label5.TabIndex = 345;
            label5.Text = "S/.";
            // 
            // impAjusteBaseLabel
            // 
            impAjusteBaseLabel.AutoSize = true;
            impAjusteBaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            impAjusteBaseLabel.Location = new System.Drawing.Point(11, 92);
            impAjusteBaseLabel.Name = "impAjusteBaseLabel";
            impAjusteBaseLabel.Size = new System.Drawing.Size(36, 13);
            impAjusteBaseLabel.TabIndex = 39;
            impAjusteBaseLabel.Text = "Ajuste";
            // 
            // impExonSecunLabel
            // 
            impExonSecunLabel.AutoSize = true;
            impExonSecunLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            impExonSecunLabel.Location = new System.Drawing.Point(199, 71);
            impExonSecunLabel.Name = "impExonSecunLabel";
            impExonSecunLabel.Size = new System.Drawing.Size(58, 13);
            impExonSecunLabel.TabIndex = 45;
            impExonSecunLabel.Text = "Exonerado";
            // 
            // impImpuestoBaseLabel
            // 
            impImpuestoBaseLabel.AutoSize = true;
            impImpuestoBaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            impImpuestoBaseLabel.Location = new System.Drawing.Point(11, 50);
            impImpuestoBaseLabel.Name = "impImpuestoBaseLabel";
            impImpuestoBaseLabel.Size = new System.Drawing.Size(50, 13);
            impImpuestoBaseLabel.TabIndex = 334;
            impImpuestoBaseLabel.Text = "Impuesto";
            // 
            // impTotalBaseLabel
            // 
            impTotalBaseLabel.AutoSize = true;
            impTotalBaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            impTotalBaseLabel.Location = new System.Drawing.Point(11, 113);
            impTotalBaseLabel.Name = "impTotalBaseLabel";
            impTotalBaseLabel.Size = new System.Drawing.Size(31, 13);
            impTotalBaseLabel.TabIndex = 51;
            impTotalBaseLabel.Text = "Total";
            // 
            // impImpuestoSecunLabel
            // 
            impImpuestoSecunLabel.AutoSize = true;
            impImpuestoSecunLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            impImpuestoSecunLabel.Location = new System.Drawing.Point(199, 50);
            impImpuestoSecunLabel.Name = "impImpuestoSecunLabel";
            impImpuestoSecunLabel.Size = new System.Drawing.Size(50, 13);
            impImpuestoSecunLabel.TabIndex = 335;
            impImpuestoSecunLabel.Text = "Impuesto";
            // 
            // impImponSecunLabel
            // 
            impImponSecunLabel.AutoSize = true;
            impImponSecunLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            impImponSecunLabel.Location = new System.Drawing.Point(199, 29);
            impImponSecunLabel.Name = "impImponSecunLabel";
            impImponSecunLabel.Size = new System.Drawing.Size(52, 13);
            impImponSecunLabel.TabIndex = 49;
            impImponSecunLabel.Text = "Imponible";
            // 
            // impExonBaseLabel
            // 
            impExonBaseLabel.AutoSize = true;
            impExonBaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            impExonBaseLabel.Location = new System.Drawing.Point(11, 71);
            impExonBaseLabel.Name = "impExonBaseLabel";
            impExonBaseLabel.Size = new System.Drawing.Size(58, 13);
            impExonBaseLabel.TabIndex = 43;
            impExonBaseLabel.Text = "Exonerado";
            // 
            // impTotalSecunLabel
            // 
            impTotalSecunLabel.AutoSize = true;
            impTotalSecunLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            impTotalSecunLabel.Location = new System.Drawing.Point(199, 113);
            impTotalSecunLabel.Name = "impTotalSecunLabel";
            impTotalSecunLabel.Size = new System.Drawing.Size(31, 13);
            impTotalSecunLabel.TabIndex = 53;
            impTotalSecunLabel.Text = "Total";
            // 
            // impImponBaseLabel
            // 
            impImponBaseLabel.AutoSize = true;
            impImponBaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            impImponBaseLabel.Location = new System.Drawing.Point(11, 29);
            impImponBaseLabel.Name = "impImponBaseLabel";
            impImponBaseLabel.Size = new System.Drawing.Size(52, 13);
            impImponBaseLabel.TabIndex = 47;
            impImponBaseLabel.Text = "Imponible";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label23.Location = new System.Drawing.Point(674, 27);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(61, 13);
            label23.TabIndex = 394;
            label23.Text = "Monto US$";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(542, 27);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(16, 13);
            label11.TabIndex = 307;
            label11.Text = "%";
            // 
            // tipo_detraccionLabel
            // 
            tipo_detraccionLabel.AutoSize = true;
            tipo_detraccionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tipo_detraccionLabel.Location = new System.Drawing.Point(227, 27);
            tipo_detraccionLabel.Name = "tipo_detraccionLabel";
            tipo_detraccionLabel.Size = new System.Drawing.Size(28, 13);
            tipo_detraccionLabel.TabIndex = 83;
            tipo_detraccionLabel.Text = "Tipo";
            // 
            // ret_numeroLabel
            // 
            ret_numeroLabel.AutoSize = true;
            ret_numeroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ret_numeroLabel.Location = new System.Drawing.Point(5, 27);
            ret_numeroLabel.Name = "ret_numeroLabel";
            ret_numeroLabel.Size = new System.Drawing.Size(44, 13);
            ret_numeroLabel.TabIndex = 77;
            ret_numeroLabel.Text = "Número";
            // 
            // tasa_detraccionLabel
            // 
            tasa_detraccionLabel.AutoSize = true;
            tasa_detraccionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tasa_detraccionLabel.Location = new System.Drawing.Point(474, 27);
            tasa_detraccionLabel.Name = "tasa_detraccionLabel";
            tasa_detraccionLabel.Size = new System.Drawing.Size(31, 13);
            tasa_detraccionLabel.TabIndex = 79;
            tasa_detraccionLabel.Text = "Tasa";
            // 
            // ret_fechaLabel
            // 
            ret_fechaLabel.AutoSize = true;
            ret_fechaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ret_fechaLabel.Location = new System.Drawing.Point(118, 27);
            ret_fechaLabel.Name = "ret_fechaLabel";
            ret_fechaLabel.Size = new System.Drawing.Size(37, 13);
            ret_fechaLabel.TabIndex = 75;
            ret_fechaLabel.Text = "Fecha";
            // 
            // monto_detraccionLabel
            // 
            monto_detraccionLabel.AutoSize = true;
            monto_detraccionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            monto_detraccionLabel.Location = new System.Drawing.Point(561, 27);
            monto_detraccionLabel.Name = "monto_detraccionLabel";
            monto_detraccionLabel.Size = new System.Drawing.Size(52, 13);
            monto_detraccionLabel.TabIndex = 59;
            monto_detraccionLabel.Text = "Monto S/";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Generate-tables.png");
            this.imageList1.Images.SetKeyName(1, "documents-yellow-edit-icon.png");
            this.imageList1.Images.SetKeyName(2, "Symbols-Tips-icon.png");
            // 
            // bsprovisionesccosto
            // 
            this.bsprovisionesccosto.DataSource = typeof(Entidades.CtasPorPagar.Provisiones_PorCCostoE);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Image = global::ClienteWinForm.Properties.Resources.cancel;
            this.btCancelar.Location = new System.Drawing.Point(420, 435);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(116, 24);
            this.btCancelar.TabIndex = 388;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.btAceptar.Location = new System.Drawing.Point(296, 435);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(116, 24);
            this.btAceptar.TabIndex = 387;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAceptar.UseVisualStyleBackColor = false;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // tProvision
            // 
            this.tProvision.Controls.Add(this.tpProvision);
            this.tProvision.Controls.Add(this.tpDetalle);
            this.tProvision.ImageList = this.imageList1;
            this.tProvision.Location = new System.Drawing.Point(3, 4);
            this.tProvision.Name = "tProvision";
            this.tProvision.SelectedIndex = 0;
            this.tProvision.Size = new System.Drawing.Size(827, 426);
            this.tProvision.TabIndex = 365;
            // 
            // tpProvision
            // 
            this.tpProvision.AutoScroll = true;
            this.tpProvision.Controls.Add(this.pnlProvision1);
            this.tpProvision.ImageIndex = 0;
            this.tpProvision.Location = new System.Drawing.Point(4, 29);
            this.tpProvision.Name = "tpProvision";
            this.tpProvision.Padding = new System.Windows.Forms.Padding(3);
            this.tpProvision.Size = new System.Drawing.Size(819, 393);
            this.tpProvision.TabIndex = 0;
            this.tpProvision.Text = "Principal";
            this.tpProvision.UseVisualStyleBackColor = true;
            // 
            // pnlProvision1
            // 
            this.pnlProvision1.AutoScroll = true;
            this.pnlProvision1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlProvision1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProvision1.Controls.Add(this.pnlDetraccion);
            this.pnlProvision1.Controls.Add(this.pnlProvision);
            this.pnlProvision1.Controls.Add(this.pnlAuditoria);
            this.pnlProvision1.Controls.Add(this.pnlMontos);
            this.pnlProvision1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProvision1.Location = new System.Drawing.Point(3, 3);
            this.pnlProvision1.Name = "pnlProvision1";
            this.pnlProvision1.Size = new System.Drawing.Size(813, 387);
            this.pnlProvision1.TabIndex = 108;
            // 
            // pnlDetraccion
            // 
            this.pnlDetraccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetraccion.Controls.Add(this.txtMontoDetraD);
            this.pnlDetraccion.Controls.Add(label23);
            this.pnlDetraccion.Controls.Add(this.chkPagoDetra);
            this.pnlDetraccion.Controls.Add(label11);
            this.pnlDetraccion.Controls.Add(this.chkDetraccion);
            this.pnlDetraccion.Controls.Add(this.txtNumDetraccion);
            this.pnlDetraccion.Controls.Add(this.txtMontoDetraS);
            this.pnlDetraccion.Controls.Add(this.cbotipodetraccion);
            this.pnlDetraccion.Controls.Add(tipo_detraccionLabel);
            this.pnlDetraccion.Controls.Add(ret_numeroLabel);
            this.pnlDetraccion.Controls.Add(this.txtTasaDetra);
            this.pnlDetraccion.Controls.Add(tasa_detraccionLabel);
            this.pnlDetraccion.Controls.Add(ret_fechaLabel);
            this.pnlDetraccion.Controls.Add(this.dtpFecRetencion);
            this.pnlDetraccion.Controls.Add(monto_detraccionLabel);
            this.pnlDetraccion.Controls.Add(this.labelDegradado4);
            this.pnlDetraccion.Location = new System.Drawing.Point(2, 188);
            this.pnlDetraccion.Name = "pnlDetraccion";
            this.pnlDetraccion.Size = new System.Drawing.Size(805, 51);
            this.pnlDetraccion.TabIndex = 392;
            // 
            // txtMontoDetraD
            // 
            this.txtMontoDetraD.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMontoDetraD.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMontoDetraD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMontoDetraD.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMontoDetraD.Enabled = false;
            this.txtMontoDetraD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoDetraD.Location = new System.Drawing.Point(737, 23);
            this.txtMontoDetraD.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoDetraD.Name = "txtMontoDetraD";
            this.txtMontoDetraD.Size = new System.Drawing.Size(54, 20);
            this.txtMontoDetraD.TabIndex = 395;
            this.txtMontoDetraD.TabStop = false;
            this.txtMontoDetraD.Text = "0.00";
            this.txtMontoDetraD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoDetraD.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMontoDetraD.TextoVacio = "<Descripcion>";
            // 
            // chkPagoDetra
            // 
            this.chkPagoDetra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPagoDetra.AutoSize = true;
            this.chkPagoDetra.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPagoDetra.Enabled = false;
            this.chkPagoDetra.Location = new System.Drawing.Point(705, 0);
            this.chkPagoDetra.Name = "chkPagoDetra";
            this.chkPagoDetra.Size = new System.Drawing.Size(95, 17);
            this.chkPagoDetra.TabIndex = 393;
            this.chkPagoDetra.Text = "Empresa Paga";
            this.chkPagoDetra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPagoDetra.UseVisualStyleBackColor = true;
            // 
            // chkDetraccion
            // 
            this.chkDetraccion.BackColor = System.Drawing.Color.SlateGray;
            this.chkDetraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDetraccion.ForeColor = System.Drawing.Color.White;
            this.chkDetraccion.Location = new System.Drawing.Point(0, 1);
            this.chkDetraccion.Name = "chkDetraccion";
            this.chkDetraccion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDetraccion.Size = new System.Drawing.Size(96, 15);
            this.chkDetraccion.TabIndex = 301;
            this.chkDetraccion.Text = "Detracción";
            this.chkDetraccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDetraccion.UseVisualStyleBackColor = false;
            this.chkDetraccion.CheckedChanged += new System.EventHandler(this.chkDetraccion_CheckedChanged);
            // 
            // txtNumDetraccion
            // 
            this.txtNumDetraccion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumDetraccion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNumDetraccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumDetraccion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumDetraccion.Enabled = false;
            this.txtNumDetraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDetraccion.Location = new System.Drawing.Point(51, 23);
            this.txtNumDetraccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumDetraccion.Name = "txtNumDetraccion";
            this.txtNumDetraccion.Size = new System.Drawing.Size(65, 20);
            this.txtNumDetraccion.TabIndex = 302;
            this.txtNumDetraccion.TabStop = false;
            this.txtNumDetraccion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtNumDetraccion.TextoVacio = "<Descripcion>";
            // 
            // txtMontoDetraS
            // 
            this.txtMontoDetraS.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMontoDetraS.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMontoDetraS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMontoDetraS.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMontoDetraS.Enabled = false;
            this.txtMontoDetraS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoDetraS.Location = new System.Drawing.Point(616, 23);
            this.txtMontoDetraS.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoDetraS.Name = "txtMontoDetraS";
            this.txtMontoDetraS.Size = new System.Drawing.Size(54, 20);
            this.txtMontoDetraS.TabIndex = 306;
            this.txtMontoDetraS.TabStop = false;
            this.txtMontoDetraS.Text = "0.00";
            this.txtMontoDetraS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoDetraS.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMontoDetraS.TextoVacio = "<Descripcion>";
            // 
            // cbotipodetraccion
            // 
            this.cbotipodetraccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotipodetraccion.DropDownWidth = 200;
            this.cbotipodetraccion.Enabled = false;
            this.cbotipodetraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbotipodetraccion.FormattingEnabled = true;
            this.cbotipodetraccion.Location = new System.Drawing.Point(258, 23);
            this.cbotipodetraccion.Name = "cbotipodetraccion";
            this.cbotipodetraccion.Size = new System.Drawing.Size(214, 21);
            this.cbotipodetraccion.TabIndex = 304;
            this.cbotipodetraccion.SelectionChangeCommitted += new System.EventHandler(this.cbotipodetraccion_SelectionChangeCommitted);
            // 
            // txtTasaDetra
            // 
            this.txtTasaDetra.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTasaDetra.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTasaDetra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTasaDetra.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTasaDetra.Enabled = false;
            this.txtTasaDetra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTasaDetra.Location = new System.Drawing.Point(509, 23);
            this.txtTasaDetra.Margin = new System.Windows.Forms.Padding(2);
            this.txtTasaDetra.Name = "txtTasaDetra";
            this.txtTasaDetra.Size = new System.Drawing.Size(33, 20);
            this.txtTasaDetra.TabIndex = 305;
            this.txtTasaDetra.TabStop = false;
            this.txtTasaDetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTasaDetra.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTasaDetra.TextoVacio = "<Descripcion>";
            // 
            // dtpFecRetencion
            // 
            this.dtpFecRetencion.CustomFormat = "dd/MM/yy";
            this.dtpFecRetencion.Enabled = false;
            this.dtpFecRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecRetencion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecRetencion.Location = new System.Drawing.Point(158, 23);
            this.dtpFecRetencion.Name = "dtpFecRetencion";
            this.dtpFecRetencion.Size = new System.Drawing.Size(67, 20);
            this.dtpFecRetencion.TabIndex = 303;
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
            this.labelDegradado4.Size = new System.Drawing.Size(803, 17);
            this.labelDegradado4.TabIndex = 252;
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlProvision
            // 
            this.pnlProvision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProvision.Controls.Add(this.chkConversion);
            this.pnlProvision.Controls.Add(this.btConversion);
            this.pnlProvision.Controls.Add(this.txtCodConversion);
            this.pnlProvision.Controls.Add(this.btCosto);
            this.pnlProvision.Controls.Add(this.txtNumHojaCosto);
            this.pnlProvision.Controls.Add(this.chkIndCosto);
            this.pnlProvision.Controls.Add(this.chkIndDistribucion);
            this.pnlProvision.Controls.Add(this.dtpFecRef);
            this.pnlProvision.Controls.Add(this.cboReferencia);
            this.pnlProvision.Controls.Add(label19);
            this.pnlProvision.Controls.Add(label20);
            this.pnlProvision.Controls.Add(this.txtSerieRef);
            this.pnlProvision.Controls.Add(this.txtNumRef);
            this.pnlProvision.Controls.Add(this.btReparable);
            this.pnlProvision.Controls.Add(this.txtRuc);
            this.pnlProvision.Controls.Add(numFileLabel);
            this.pnlProvision.Controls.Add(this.txtIdProveedor);
            this.pnlProvision.Controls.Add(this.labelDegradado3);
            this.pnlProvision.Controls.Add(this.txtIdProvision);
            this.pnlProvision.Controls.Add(impMonedaOrigenLabel);
            this.pnlProvision.Controls.Add(this.dtpFecDocumento);
            this.pnlProvision.Controls.Add(this.txtNumDiasVen);
            this.pnlProvision.Controls.Add(idProvisionLabel);
            this.pnlProvision.Controls.Add(this.txtTipCambio);
            this.pnlProvision.Controls.Add(this.cboDocumento);
            this.pnlProvision.Controls.Add(this.chkIndCalcAuto);
            this.pnlProvision.Controls.Add(numDiasVenLabel);
            this.pnlProvision.Controls.Add(this.txtDesEstado);
            this.pnlProvision.Controls.Add(idPersonaLabel);
            this.pnlProvision.Controls.Add(fechaDocumentoLabel);
            this.pnlProvision.Controls.Add(desProvisionLabel);
            this.pnlProvision.Controls.Add(codMonedaProvisionLabel1);
            this.pnlProvision.Controls.Add(codCuentaLabel);
            this.pnlProvision.Controls.Add(this.cboMoneda);
            this.pnlProvision.Controls.Add(idDocumentoLabel1);
            this.pnlProvision.Controls.Add(fechaProvisionLabel);
            this.pnlProvision.Controls.Add(this.dtpFechaProvision);
            this.pnlProvision.Controls.Add(fechaVencimientoLabel);
            this.pnlProvision.Controls.Add(this.dtpFecVencimiento);
            this.pnlProvision.Controls.Add(numGuiaLabel);
            this.pnlProvision.Controls.Add(this.txtRazonSocial);
            this.pnlProvision.Controls.Add(this.txtSerie);
            this.pnlProvision.Controls.Add(this.txtNumero);
            this.pnlProvision.Controls.Add(this.txtImporteOrigen);
            this.pnlProvision.Controls.Add(this.txtGuia);
            this.pnlProvision.Controls.Add(this.txtCodCuenta);
            this.pnlProvision.Controls.Add(this.txtDesCuenta);
            this.pnlProvision.Controls.Add(this.txtDesProvision);
            this.pnlProvision.Controls.Add(this.cboTipoAsiento);
            this.pnlProvision.Location = new System.Drawing.Point(2, 3);
            this.pnlProvision.Name = "pnlProvision";
            this.pnlProvision.Size = new System.Drawing.Size(805, 183);
            this.pnlProvision.TabIndex = 390;
            // 
            // chkConversion
            // 
            this.chkConversion.AutoSize = true;
            this.chkConversion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkConversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConversion.Location = new System.Drawing.Point(456, 24);
            this.chkConversion.Name = "chkConversion";
            this.chkConversion.Size = new System.Drawing.Size(111, 17);
            this.chkConversion.TabIndex = 410;
            this.chkConversion.TabStop = false;
            this.chkConversion.Text = "Orden Conversión";
            this.chkConversion.UseVisualStyleBackColor = true;
            this.chkConversion.CheckedChanged += new System.EventHandler(this.chkConversion_CheckedChanged);
            // 
            // btConversion
            // 
            this.btConversion.Enabled = false;
            this.btConversion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btConversion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btConversion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btConversion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConversion.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btConversion.Location = new System.Drawing.Point(657, 23);
            this.btConversion.Name = "btConversion";
            this.btConversion.Size = new System.Drawing.Size(24, 19);
            this.btConversion.TabIndex = 408;
            this.btConversion.TabStop = false;
            this.btConversion.UseVisualStyleBackColor = true;
            this.btConversion.Click += new System.EventHandler(this.btConversion_Click);
            // 
            // txtCodConversion
            // 
            this.txtCodConversion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodConversion.Enabled = false;
            this.txtCodConversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodConversion.Location = new System.Drawing.Point(570, 22);
            this.txtCodConversion.Name = "txtCodConversion";
            this.txtCodConversion.Size = new System.Drawing.Size(85, 20);
            this.txtCodConversion.TabIndex = 409;
            this.txtCodConversion.TabStop = false;
            // 
            // btCosto
            // 
            this.btCosto.Enabled = false;
            this.btCosto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCosto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCosto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCosto.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCosto.Location = new System.Drawing.Point(427, 23);
            this.btCosto.Name = "btCosto";
            this.btCosto.Size = new System.Drawing.Size(24, 19);
            this.btCosto.TabIndex = 395;
            this.btCosto.TabStop = false;
            this.btCosto.UseVisualStyleBackColor = true;
            this.btCosto.Click += new System.EventHandler(this.btCosto_Click);
            // 
            // txtNumHojaCosto
            // 
            this.txtNumHojaCosto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumHojaCosto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNumHojaCosto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumHojaCosto.Enabled = false;
            this.txtNumHojaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumHojaCosto.Location = new System.Drawing.Point(354, 22);
            this.txtNumHojaCosto.Name = "txtNumHojaCosto";
            this.txtNumHojaCosto.Size = new System.Drawing.Size(71, 20);
            this.txtNumHojaCosto.TabIndex = 394;
            this.txtNumHojaCosto.TabStop = false;
            this.txtNumHojaCosto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumHojaCosto.TextoVacio = "<Descripcion>";
            // 
            // chkIndCosto
            // 
            this.chkIndCosto.AutoSize = true;
            this.chkIndCosto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndCosto.Location = new System.Drawing.Point(273, 24);
            this.chkIndCosto.Name = "chkIndCosto";
            this.chkIndCosto.Size = new System.Drawing.Size(78, 17);
            this.chkIndCosto.TabIndex = 393;
            this.chkIndCosto.TabStop = false;
            this.chkIndCosto.Text = "Hoja Costo";
            this.chkIndCosto.UseVisualStyleBackColor = true;
            this.chkIndCosto.CheckedChanged += new System.EventHandler(this.chkIndCosto_CheckedChanged);
            // 
            // chkIndDistribucion
            // 
            this.chkIndDistribucion.AutoSize = true;
            this.chkIndDistribucion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndDistribucion.Location = new System.Drawing.Point(6, 157);
            this.chkIndDistribucion.Name = "chkIndDistribucion";
            this.chkIndDistribucion.Size = new System.Drawing.Size(99, 17);
            this.chkIndDistribucion.TabIndex = 392;
            this.chkIndDistribucion.Text = "Ind.Distribución";
            this.chkIndDistribucion.UseVisualStyleBackColor = true;
            this.chkIndDistribucion.Visible = false;
            // 
            // dtpFecRef
            // 
            this.dtpFecRef.CustomFormat = "dd/MM/yy";
            this.dtpFecRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecRef.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecRef.Location = new System.Drawing.Point(454, 88);
            this.dtpFecRef.Name = "dtpFecRef";
            this.dtpFecRef.Size = new System.Drawing.Size(69, 20);
            this.dtpFecRef.TabIndex = 389;
            this.dtpFecRef.ValueChanged += new System.EventHandler(this.dtpFecRef_ValueChanged);
            // 
            // cboReferencia
            // 
            this.cboReferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReferencia.FormattingEnabled = true;
            this.cboReferencia.Location = new System.Drawing.Point(90, 88);
            this.cboReferencia.Name = "cboReferencia";
            this.cboReferencia.Size = new System.Drawing.Size(180, 21);
            this.cboReferencia.TabIndex = 386;
            // 
            // txtSerieRef
            // 
            this.txtSerieRef.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerieRef.BackColor = System.Drawing.Color.White;
            this.txtSerieRef.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSerieRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerieRef.Location = new System.Drawing.Point(273, 88);
            this.txtSerieRef.Name = "txtSerieRef";
            this.txtSerieRef.Size = new System.Drawing.Size(41, 20);
            this.txtSerieRef.TabIndex = 387;
            this.txtSerieRef.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerieRef.TextoVacio = "<Descripcion>";
            // 
            // txtNumRef
            // 
            this.txtNumRef.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumRef.BackColor = System.Drawing.Color.White;
            this.txtNumRef.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumRef.Location = new System.Drawing.Point(315, 88);
            this.txtNumRef.Name = "txtNumRef";
            this.txtNumRef.Size = new System.Drawing.Size(76, 20);
            this.txtNumRef.TabIndex = 388;
            this.txtNumRef.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumRef.TextoVacio = "<Descripcion>";
            // 
            // btReparable
            // 
            this.btReparable.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btReparable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btReparable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btReparable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReparable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReparable.Location = new System.Drawing.Point(751, 111);
            this.btReparable.Name = "btReparable";
            this.btReparable.Size = new System.Drawing.Size(43, 62);
            this.btReparable.TabIndex = 385;
            this.btReparable.TabStop = false;
            this.btReparable.Text = "Reparable";
            this.btReparable.UseVisualStyleBackColor = true;
            this.btReparable.Click += new System.EventHandler(this.btReparable_Click);
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.Color.White;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(147, 44);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(74, 20);
            this.txtRuc.TabIndex = 5;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "<Descripcion>";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // txtIdProveedor
            // 
            this.txtIdProveedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdProveedor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdProveedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdProveedor.Enabled = false;
            this.txtIdProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProveedor.Location = new System.Drawing.Point(90, 44);
            this.txtIdProveedor.Name = "txtIdProveedor";
            this.txtIdProveedor.Size = new System.Drawing.Size(56, 20);
            this.txtIdProveedor.TabIndex = 4;
            this.txtIdProveedor.TabStop = false;
            this.txtIdProveedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdProveedor.TextoVacio = "<Descripcion>";
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(803, 17);
            this.labelDegradado3.TabIndex = 252;
            this.labelDegradado3.Text = "Provisiones";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIdProvision
            // 
            this.txtIdProvision.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdProvision.Enabled = false;
            this.txtIdProvision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProvision.Location = new System.Drawing.Point(90, 22);
            this.txtIdProvision.Name = "txtIdProvision";
            this.txtIdProvision.Size = new System.Drawing.Size(56, 20);
            this.txtIdProvision.TabIndex = 1;
            this.txtIdProvision.TabStop = false;
            // 
            // dtpFecDocumento
            // 
            this.dtpFecDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecDocumento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDocumento.Location = new System.Drawing.Point(454, 66);
            this.dtpFecDocumento.Name = "dtpFecDocumento";
            this.dtpFecDocumento.Size = new System.Drawing.Size(81, 20);
            this.dtpFecDocumento.TabIndex = 11;
            this.dtpFecDocumento.ValueChanged += new System.EventHandler(this.dtpFecDocumento_ValueChanged);
            // 
            // txtNumDiasVen
            // 
            this.txtNumDiasVen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumDiasVen.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumDiasVen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumDiasVen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumDiasVen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDiasVen.Location = new System.Drawing.Point(245, 156);
            this.txtNumDiasVen.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumDiasVen.Name = "txtNumDiasVen";
            this.txtNumDiasVen.Size = new System.Drawing.Size(36, 20);
            this.txtNumDiasVen.TabIndex = 13;
            this.txtNumDiasVen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumDiasVen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtNumDiasVen.TextoVacio = "<Descripcion>";
            this.txtNumDiasVen.Leave += new System.EventHandler(this.txtNumDiasVen_Leave);
            // 
            // txtTipCambio
            // 
            this.txtTipCambio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTipCambio.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTipCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipCambio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTipCambio.Enabled = false;
            this.txtTipCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipCambio.Location = new System.Drawing.Point(602, 88);
            this.txtTipCambio.Margin = new System.Windows.Forms.Padding(2);
            this.txtTipCambio.Name = "txtTipCambio";
            this.txtTipCambio.Size = new System.Drawing.Size(45, 20);
            this.txtTipCambio.TabIndex = 12;
            this.txtTipCambio.TabStop = false;
            this.txtTipCambio.Text = "0.000";
            this.txtTipCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTipCambio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTipCambio.TextoVacio = "<Descripcion>";
            // 
            // cboDocumento
            // 
            this.cboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumento.FormattingEnabled = true;
            this.cboDocumento.Location = new System.Drawing.Point(90, 66);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Size = new System.Drawing.Size(180, 21);
            this.cboDocumento.TabIndex = 7;
            this.cboDocumento.SelectionChangeCommitted += new System.EventHandler(this.cboDocumento_SelectionChangeCommitted);
            this.cboDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDocumento_KeyPress);
            // 
            // chkIndCalcAuto
            // 
            this.chkIndCalcAuto.Checked = true;
            this.chkIndCalcAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIndCalcAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndCalcAuto.Location = new System.Drawing.Point(525, 90);
            this.chkIndCalcAuto.Name = "chkIndCalcAuto";
            this.chkIndCalcAuto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIndCalcAuto.Size = new System.Drawing.Size(75, 18);
            this.chkIndCalcAuto.TabIndex = 339;
            this.chkIndCalcAuto.TabStop = false;
            this.chkIndCalcAuto.Text = "T. C. Auto";
            this.chkIndCalcAuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndCalcAuto.UseVisualStyleBackColor = true;
            this.chkIndCalcAuto.CheckedChanged += new System.EventHandler(this.chkIndCalcAuto_CheckedChanged);
            // 
            // txtDesEstado
            // 
            this.txtDesEstado.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesEstado.Enabled = false;
            this.txtDesEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesEstado.Location = new System.Drawing.Point(686, 22);
            this.txtDesEstado.Name = "txtDesEstado";
            this.txtDesEstado.Size = new System.Drawing.Size(108, 20);
            this.txtDesEstado.TabIndex = 338;
            this.txtDesEstado.TabStop = false;
            this.txtDesEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(586, 66);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(61, 21);
            this.cboMoneda.TabIndex = 10;
            this.cboMoneda.SelectionChangeCommitted += new System.EventHandler(this.cboMoneda_SelectionChangeCommitted);
            // 
            // dtpFechaProvision
            // 
            this.dtpFechaProvision.CalendarMonthBackground = System.Drawing.Color.LightSteelBlue;
            this.dtpFechaProvision.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaProvision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaProvision.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaProvision.Location = new System.Drawing.Point(189, 22);
            this.dtpFechaProvision.Name = "dtpFechaProvision";
            this.dtpFechaProvision.Size = new System.Drawing.Size(81, 20);
            this.dtpFechaProvision.TabIndex = 2;
            this.dtpFechaProvision.Value = new System.DateTime(2017, 3, 7, 0, 0, 0, 0);
            // 
            // dtpFecVencimiento
            // 
            this.dtpFecVencimiento.Enabled = false;
            this.dtpFecVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecVencimiento.Location = new System.Drawing.Point(347, 156);
            this.dtpFecVencimiento.Name = "dtpFecVencimiento";
            this.dtpFecVencimiento.Size = new System.Drawing.Size(81, 20);
            this.dtpFecVencimiento.TabIndex = 14;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonSocial.BackColor = System.Drawing.Color.White;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(222, 44);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(572, 20);
            this.txtRazonSocial.TabIndex = 6;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "<Descripcion>";
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // txtSerie
            // 
            this.txtSerie.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerie.BackColor = System.Drawing.Color.White;
            this.txtSerie.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(273, 66);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(41, 20);
            this.txtSerie.TabIndex = 8;
            this.txtSerie.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerie.TextoVacio = "<Descripcion>";
            this.txtSerie.Leave += new System.EventHandler(this.txtSerie_Leave);
            // 
            // txtNumero
            // 
            this.txtNumero.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumero.BackColor = System.Drawing.Color.White;
            this.txtNumero.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(315, 66);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(76, 20);
            this.txtNumero.TabIndex = 9;
            this.txtNumero.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumero.TextoVacio = "<Descripcion>";
            this.txtNumero.Leave += new System.EventHandler(this.txtNumero_Leave);
            // 
            // txtImporteOrigen
            // 
            this.txtImporteOrigen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtImporteOrigen.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtImporteOrigen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtImporteOrigen.Enabled = false;
            this.txtImporteOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteOrigen.Location = new System.Drawing.Point(707, 66);
            this.txtImporteOrigen.Name = "txtImporteOrigen";
            this.txtImporteOrigen.Size = new System.Drawing.Size(87, 20);
            this.txtImporteOrigen.TabIndex = 373;
            this.txtImporteOrigen.TabStop = false;
            this.txtImporteOrigen.Text = "0.00";
            this.txtImporteOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporteOrigen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtImporteOrigen.TextoVacio = "<Descripcion>";
            // 
            // txtGuia
            // 
            this.txtGuia.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtGuia.BackColor = System.Drawing.SystemColors.Window;
            this.txtGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGuia.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtGuia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuia.Location = new System.Drawing.Point(709, 88);
            this.txtGuia.Margin = new System.Windows.Forms.Padding(2);
            this.txtGuia.Name = "txtGuia";
            this.txtGuia.Size = new System.Drawing.Size(85, 20);
            this.txtGuia.TabIndex = 15;
            this.txtGuia.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtGuia.TextoVacio = "<Descripcion>";
            // 
            // txtCodCuenta
            // 
            this.txtCodCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodCuenta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodCuenta.Enabled = false;
            this.txtCodCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCuenta.Location = new System.Drawing.Point(90, 134);
            this.txtCodCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodCuenta.Name = "txtCodCuenta";
            this.txtCodCuenta.Size = new System.Drawing.Size(56, 20);
            this.txtCodCuenta.TabIndex = 16;
            this.txtCodCuenta.TabStop = false;
            this.txtCodCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodCuenta.TextoVacio = "<Descripcion>";
            this.txtCodCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodCuenta_Validating);
            // 
            // txtDesCuenta
            // 
            this.txtDesCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesCuenta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesCuenta.Enabled = false;
            this.txtDesCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuenta.Location = new System.Drawing.Point(147, 134);
            this.txtDesCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesCuenta.Name = "txtDesCuenta";
            this.txtDesCuenta.Size = new System.Drawing.Size(281, 20);
            this.txtDesCuenta.TabIndex = 17;
            this.txtDesCuenta.TabStop = false;
            this.txtDesCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesCuenta.TextoVacio = "<Descripcion>";
            this.txtDesCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesCuenta_Validating);
            // 
            // txtDesProvision
            // 
            this.txtDesProvision.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesProvision.BackColor = System.Drawing.SystemColors.Window;
            this.txtDesProvision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesProvision.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesProvision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesProvision.Location = new System.Drawing.Point(466, 110);
            this.txtDesProvision.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesProvision.Multiline = true;
            this.txtDesProvision.Name = "txtDesProvision";
            this.txtDesProvision.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesProvision.Size = new System.Drawing.Size(280, 63);
            this.txtDesProvision.TabIndex = 17;
            this.txtDesProvision.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesProvision.TextoVacio = "<Descripcion>";
            // 
            // cboTipoAsiento
            // 
            this.cboTipoAsiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAsiento.DropDownWidth = 175;
            this.cboTipoAsiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoAsiento.FormattingEnabled = true;
            this.cboTipoAsiento.Location = new System.Drawing.Point(90, 111);
            this.cboTipoAsiento.Name = "cboTipoAsiento";
            this.cboTipoAsiento.Size = new System.Drawing.Size(338, 21);
            this.cboTipoAsiento.TabIndex = 16;
            this.cboTipoAsiento.SelectionChangeCommitted += new System.EventHandler(this.cboTipoAsiento_SelectionChangeCommitted);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado9);
            this.pnlAuditoria.Controls.Add(label24);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistro);
            this.pnlAuditoria.Controls.Add(label25);
            this.pnlAuditoria.Controls.Add(label29);
            this.pnlAuditoria.Controls.Add(this.txtUsuModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(label31);
            this.pnlAuditoria.Location = new System.Drawing.Point(529, 241);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(278, 139);
            this.pnlAuditoria.TabIndex = 389;
            // 
            // labelDegradado9
            // 
            this.labelDegradado9.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado9.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado9.ForeColor = System.Drawing.Color.White;
            this.labelDegradado9.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado9.Name = "labelDegradado9";
            this.labelDegradado9.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado9.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado9.Size = new System.Drawing.Size(276, 17);
            this.labelDegradado9.TabIndex = 253;
            this.labelDegradado9.Text = "Auditoria";
            this.labelDegradado9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(120, 98);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(141, 21);
            this.txtFechaModificacion.TabIndex = 7;
            this.txtFechaModificacion.TabStop = false;
            // 
            // txtUsuRegistro
            // 
            this.txtUsuRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuRegistro.Enabled = false;
            this.txtUsuRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistro.Location = new System.Drawing.Point(120, 32);
            this.txtUsuRegistro.Name = "txtUsuRegistro";
            this.txtUsuRegistro.Size = new System.Drawing.Size(141, 21);
            this.txtUsuRegistro.TabIndex = 1;
            this.txtUsuRegistro.TabStop = false;
            // 
            // txtUsuModificacion
            // 
            this.txtUsuModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuModificacion.Enabled = false;
            this.txtUsuModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModificacion.Location = new System.Drawing.Point(120, 76);
            this.txtUsuModificacion.Name = "txtUsuModificacion";
            this.txtUsuModificacion.Size = new System.Drawing.Size(141, 21);
            this.txtUsuModificacion.TabIndex = 5;
            this.txtUsuModificacion.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(120, 54);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(141, 21);
            this.txtFechaRegistro.TabIndex = 3;
            this.txtFechaRegistro.TabStop = false;
            // 
            // pnlMontos
            // 
            this.pnlMontos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMontos.Controls.Add(this.pictureBox1);
            this.pnlMontos.Controls.Add(this.txtTotalSecu);
            this.pnlMontos.Controls.Add(this.txtAjusteSecu);
            this.pnlMontos.Controls.Add(this.txtExoneradoSecu);
            this.pnlMontos.Controls.Add(this.txtImpuestoSecu);
            this.pnlMontos.Controls.Add(this.txtBaseSecu);
            this.pnlMontos.Controls.Add(this.txtTotal);
            this.pnlMontos.Controls.Add(this.txtAjuste);
            this.pnlMontos.Controls.Add(this.txtExonerado);
            this.pnlMontos.Controls.Add(this.txtImpuesto);
            this.pnlMontos.Controls.Add(this.labelDegradado5);
            this.pnlMontos.Controls.Add(label3);
            this.pnlMontos.Controls.Add(label8);
            this.pnlMontos.Controls.Add(label7);
            this.pnlMontos.Controls.Add(label4);
            this.pnlMontos.Controls.Add(label2);
            this.pnlMontos.Controls.Add(label1);
            this.pnlMontos.Controls.Add(label9);
            this.pnlMontos.Controls.Add(impAjusteSecunLabel);
            this.pnlMontos.Controls.Add(label6);
            this.pnlMontos.Controls.Add(label10);
            this.pnlMontos.Controls.Add(label5);
            this.pnlMontos.Controls.Add(impAjusteBaseLabel);
            this.pnlMontos.Controls.Add(impExonSecunLabel);
            this.pnlMontos.Controls.Add(impImpuestoBaseLabel);
            this.pnlMontos.Controls.Add(impTotalBaseLabel);
            this.pnlMontos.Controls.Add(impImpuestoSecunLabel);
            this.pnlMontos.Controls.Add(impImponSecunLabel);
            this.pnlMontos.Controls.Add(impExonBaseLabel);
            this.pnlMontos.Controls.Add(impTotalSecunLabel);
            this.pnlMontos.Controls.Add(impImponBaseLabel);
            this.pnlMontos.Controls.Add(this.txtBaseImponible);
            this.pnlMontos.Location = new System.Drawing.Point(2, 241);
            this.pnlMontos.Name = "pnlMontos";
            this.pnlMontos.Size = new System.Drawing.Size(524, 139);
            this.pnlMontos.TabIndex = 391;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ClienteWinForm.Properties.Resources.Billetes_Moneda;
            this.pictureBox1.Location = new System.Drawing.Point(409, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 391;
            this.pictureBox1.TabStop = false;
            // 
            // txtTotalSecu
            // 
            this.txtTotalSecu.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTotalSecu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotalSecu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalSecu.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTotalSecu.Enabled = false;
            this.txtTotalSecu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSecu.Location = new System.Drawing.Point(291, 109);
            this.txtTotalSecu.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalSecu.Name = "txtTotalSecu";
            this.txtTotalSecu.Size = new System.Drawing.Size(100, 20);
            this.txtTotalSecu.TabIndex = 390;
            this.txtTotalSecu.TabStop = false;
            this.txtTotalSecu.Text = "0.00";
            this.txtTotalSecu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalSecu.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTotalSecu.TextoVacio = "<Descripcion>";
            // 
            // txtAjusteSecu
            // 
            this.txtAjusteSecu.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtAjusteSecu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAjusteSecu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAjusteSecu.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAjusteSecu.Enabled = false;
            this.txtAjusteSecu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAjusteSecu.Location = new System.Drawing.Point(291, 88);
            this.txtAjusteSecu.Margin = new System.Windows.Forms.Padding(2);
            this.txtAjusteSecu.Name = "txtAjusteSecu";
            this.txtAjusteSecu.Size = new System.Drawing.Size(100, 20);
            this.txtAjusteSecu.TabIndex = 389;
            this.txtAjusteSecu.TabStop = false;
            this.txtAjusteSecu.Text = "0.00";
            this.txtAjusteSecu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAjusteSecu.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtAjusteSecu.TextoVacio = "<Descripcion>";
            // 
            // txtExoneradoSecu
            // 
            this.txtExoneradoSecu.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtExoneradoSecu.BackColor = System.Drawing.Color.White;
            this.txtExoneradoSecu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExoneradoSecu.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtExoneradoSecu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExoneradoSecu.Location = new System.Drawing.Point(291, 67);
            this.txtExoneradoSecu.Margin = new System.Windows.Forms.Padding(2);
            this.txtExoneradoSecu.Name = "txtExoneradoSecu";
            this.txtExoneradoSecu.Size = new System.Drawing.Size(100, 20);
            this.txtExoneradoSecu.TabIndex = 388;
            this.txtExoneradoSecu.Text = "0.00";
            this.txtExoneradoSecu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExoneradoSecu.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtExoneradoSecu.TextoVacio = "<Descripcion>";
            // 
            // txtImpuestoSecu
            // 
            this.txtImpuestoSecu.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtImpuestoSecu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtImpuestoSecu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImpuestoSecu.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtImpuestoSecu.Enabled = false;
            this.txtImpuestoSecu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpuestoSecu.Location = new System.Drawing.Point(291, 46);
            this.txtImpuestoSecu.Margin = new System.Windows.Forms.Padding(2);
            this.txtImpuestoSecu.Name = "txtImpuestoSecu";
            this.txtImpuestoSecu.Size = new System.Drawing.Size(100, 20);
            this.txtImpuestoSecu.TabIndex = 387;
            this.txtImpuestoSecu.TabStop = false;
            this.txtImpuestoSecu.Text = "0.00";
            this.txtImpuestoSecu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImpuestoSecu.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtImpuestoSecu.TextoVacio = "<Descripcion>";
            // 
            // txtBaseSecu
            // 
            this.txtBaseSecu.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtBaseSecu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBaseSecu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBaseSecu.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtBaseSecu.Enabled = false;
            this.txtBaseSecu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaseSecu.Location = new System.Drawing.Point(291, 25);
            this.txtBaseSecu.Margin = new System.Windows.Forms.Padding(2);
            this.txtBaseSecu.Name = "txtBaseSecu";
            this.txtBaseSecu.Size = new System.Drawing.Size(100, 20);
            this.txtBaseSecu.TabIndex = 386;
            this.txtBaseSecu.TabStop = false;
            this.txtBaseSecu.Text = "0.00";
            this.txtBaseSecu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBaseSecu.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtBaseSecu.TextoVacio = "<Descripcion>";
            // 
            // txtTotal
            // 
            this.txtTotal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTotal.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(94, 109);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 385;
            this.txtTotal.TabStop = false;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTotal.TextoVacio = "<Descripcion>";
            // 
            // txtAjuste
            // 
            this.txtAjuste.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtAjuste.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAjuste.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAjuste.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAjuste.Enabled = false;
            this.txtAjuste.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAjuste.Location = new System.Drawing.Point(94, 88);
            this.txtAjuste.Margin = new System.Windows.Forms.Padding(2);
            this.txtAjuste.Name = "txtAjuste";
            this.txtAjuste.Size = new System.Drawing.Size(100, 20);
            this.txtAjuste.TabIndex = 384;
            this.txtAjuste.TabStop = false;
            this.txtAjuste.Text = "0.00";
            this.txtAjuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAjuste.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtAjuste.TextoVacio = "<Descripcion>";
            // 
            // txtExonerado
            // 
            this.txtExonerado.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtExonerado.BackColor = System.Drawing.Color.White;
            this.txtExonerado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExonerado.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtExonerado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExonerado.Location = new System.Drawing.Point(94, 67);
            this.txtExonerado.Margin = new System.Windows.Forms.Padding(2);
            this.txtExonerado.Name = "txtExonerado";
            this.txtExonerado.Size = new System.Drawing.Size(100, 20);
            this.txtExonerado.TabIndex = 383;
            this.txtExonerado.Text = "0.00";
            this.txtExonerado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExonerado.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtExonerado.TextoVacio = "<Descripcion>";
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtImpuesto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtImpuesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImpuesto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtImpuesto.Enabled = false;
            this.txtImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpuesto.Location = new System.Drawing.Point(94, 46);
            this.txtImpuesto.Margin = new System.Windows.Forms.Padding(2);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.Size = new System.Drawing.Size(100, 20);
            this.txtImpuesto.TabIndex = 382;
            this.txtImpuesto.TabStop = false;
            this.txtImpuesto.Text = "0.00";
            this.txtImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImpuesto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtImpuesto.TextoVacio = "<Descripcion>";
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
            this.labelDegradado5.Size = new System.Drawing.Size(522, 17);
            this.labelDegradado5.TabIndex = 252;
            this.labelDegradado5.Text = "Montos";
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBaseImponible
            // 
            this.txtBaseImponible.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtBaseImponible.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBaseImponible.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBaseImponible.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtBaseImponible.Enabled = false;
            this.txtBaseImponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaseImponible.Location = new System.Drawing.Point(94, 25);
            this.txtBaseImponible.Margin = new System.Windows.Forms.Padding(2);
            this.txtBaseImponible.Name = "txtBaseImponible";
            this.txtBaseImponible.Size = new System.Drawing.Size(100, 20);
            this.txtBaseImponible.TabIndex = 381;
            this.txtBaseImponible.TabStop = false;
            this.txtBaseImponible.Text = "0.00";
            this.txtBaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBaseImponible.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtBaseImponible.TextoVacio = "<Descripcion>";
            // 
            // tpDetalle
            // 
            this.tpDetalle.Controls.Add(this.panel1);
            this.tpDetalle.ImageIndex = 1;
            this.tpDetalle.Location = new System.Drawing.Point(4, 29);
            this.tpDetalle.Name = "tpDetalle";
            this.tpDetalle.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetalle.Size = new System.Drawing.Size(819, 393);
            this.tpDetalle.TabIndex = 1;
            this.tpDetalle.Text = "Detalle";
            this.tpDetalle.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btConceptos);
            this.panel1.Controls.Add(this.btActivos);
            this.panel1.Controls.Add(this.btServicios);
            this.panel1.Controls.Add(this.btGastos);
            this.panel1.Controls.Add(this.btArticulos);
            this.panel1.Controls.Add(this.dgvprovisionesccosto);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 387);
            this.panel1.TabIndex = 0;
            // 
            // btConceptos
            // 
            this.btConceptos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btConceptos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btConceptos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btConceptos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConceptos.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btConceptos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btConceptos.Location = new System.Drawing.Point(3, 2);
            this.btConceptos.Name = "btConceptos";
            this.btConceptos.Size = new System.Drawing.Size(144, 21);
            this.btConceptos.TabIndex = 1570;
            this.btConceptos.TabStop = false;
            this.btConceptos.Text = "Gastos - Servicios";
            this.btConceptos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btConceptos.UseVisualStyleBackColor = true;
            this.btConceptos.Click += new System.EventHandler(this.btConceptos_Click);
            // 
            // btActivos
            // 
            this.btActivos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btActivos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btActivos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btActivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActivos.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btActivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btActivos.Location = new System.Drawing.Point(588, 2);
            this.btActivos.Name = "btActivos";
            this.btActivos.Size = new System.Drawing.Size(83, 21);
            this.btActivos.TabIndex = 1569;
            this.btActivos.TabStop = false;
            this.btActivos.Text = "Activos";
            this.btActivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btActivos.UseVisualStyleBackColor = true;
            this.btActivos.Visible = false;
            this.btActivos.Click += new System.EventHandler(this.btActivos_Click);
            // 
            // btServicios
            // 
            this.btServicios.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btServicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btServicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btServicios.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btServicios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btServicios.Location = new System.Drawing.Point(409, 2);
            this.btServicios.Name = "btServicios";
            this.btServicios.Size = new System.Drawing.Size(90, 21);
            this.btServicios.TabIndex = 1568;
            this.btServicios.TabStop = false;
            this.btServicios.Text = "Servicios";
            this.btServicios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btServicios.UseVisualStyleBackColor = true;
            this.btServicios.Visible = false;
            this.btServicios.Click += new System.EventHandler(this.btServicios_Click);
            // 
            // btGastos
            // 
            this.btGastos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btGastos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btGastos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btGastos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGastos.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btGastos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGastos.Location = new System.Drawing.Point(315, 2);
            this.btGastos.Name = "btGastos";
            this.btGastos.Size = new System.Drawing.Size(90, 21);
            this.btGastos.TabIndex = 1567;
            this.btGastos.TabStop = false;
            this.btGastos.Text = "Gastos";
            this.btGastos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGastos.UseVisualStyleBackColor = true;
            this.btGastos.Visible = false;
            this.btGastos.Click += new System.EventHandler(this.btGastos_Click);
            // 
            // btArticulos
            // 
            this.btArticulos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btArticulos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btArticulos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btArticulos.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btArticulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btArticulos.Location = new System.Drawing.Point(150, 2);
            this.btArticulos.Name = "btArticulos";
            this.btArticulos.Size = new System.Drawing.Size(83, 21);
            this.btArticulos.TabIndex = 1566;
            this.btArticulos.TabStop = false;
            this.btArticulos.Text = "Articulos";
            this.btArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btArticulos.UseVisualStyleBackColor = true;
            this.btArticulos.Visible = false;
            this.btArticulos.Click += new System.EventHandler(this.btArticulos_Click);
            // 
            // dgvprovisionesccosto
            // 
            this.dgvprovisionesccosto.AllowUserToAddRows = false;
            this.dgvprovisionesccosto.AllowUserToDeleteRows = false;
            this.dgvprovisionesccosto.AutoGenerateColumns = false;
            this.dgvprovisionesccosto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvprovisionesccosto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar,
            this.Modificar,
            this.dataGridViewTextBoxColumn4,
            this.Codigo,
            this.Descripcion,
            this.dataGridViewTextBoxColumn12,
            this.desMoneda,
            this.dataGridViewTextBoxColumn11,
            this.DesColumnaCoven,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.codCuenta,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18});
            this.dgvprovisionesccosto.DataSource = this.bsprovisionesccosto;
            this.dgvprovisionesccosto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvprovisionesccosto.EnableHeadersVisualStyles = false;
            this.dgvprovisionesccosto.Location = new System.Drawing.Point(0, 26);
            this.dgvprovisionesccosto.Name = "dgvprovisionesccosto";
            this.dgvprovisionesccosto.ReadOnly = true;
            this.dgvprovisionesccosto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvprovisionesccosto.Size = new System.Drawing.Size(813, 361);
            this.dgvprovisionesccosto.TabIndex = 252;
            this.dgvprovisionesccosto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvprovisionesccosto_CellClick);
            this.dgvprovisionesccosto.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvprovisionesccosto_CellPainting);
            // 
            // Eliminar
            // 
            this.Eliminar.DataPropertyName = "Eliminar";
            this.Eliminar.HeaderText = " ";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.ToolTipText = "Eliminar Detalle";
            this.Eliminar.Width = 32;
            // 
            // Modificar
            // 
            this.Modificar.DataPropertyName = "Modificar";
            this.Modificar.HeaderText = " ";
            this.Modificar.Name = "Modificar";
            this.Modificar.ReadOnly = true;
            this.Modificar.ToolTipText = "Modificar Detalle";
            this.Modificar.Width = 32;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "idItem";
            this.dataGridViewTextBoxColumn4.HeaderText = "Nro.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 40;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 150;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 250;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "idCCostos";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn12.HeaderText = "CCosto";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 80;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            this.desMoneda.HeaderText = "Mon.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 50;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "MontoCuenta";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn11.HeaderText = "Monto";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 90;
            // 
            // DesColumnaCoven
            // 
            this.DesColumnaCoven.DataPropertyName = "DesColumnaCoven";
            this.DesColumnaCoven.HeaderText = "Col.Compra";
            this.DesColumnaCoven.Name = "DesColumnaCoven";
            this.DesColumnaCoven.ReadOnly = true;
            this.DesColumnaCoven.Width = 120;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "desGlosa";
            this.dataGridViewTextBoxColumn13.HeaderText = "Glosa";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 90;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "impSoles";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn9.HeaderText = "Imp. S/.";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "impDolares";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn10.HeaderText = "Imp. US$";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // codCuenta
            // 
            this.codCuenta.DataPropertyName = "codCuenta";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCuenta.DefaultCellStyle = dataGridViewCellStyle5;
            this.codCuenta.HeaderText = "Cuenta";
            this.codCuenta.Name = "codCuenta";
            this.codCuenta.ReadOnly = true;
            this.codCuenta.Visible = false;
            this.codCuenta.Width = 80;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn15.HeaderText = "Usuario Reg.";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 90;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn16.HeaderText = "Fecha Reg.";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 120;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn17.HeaderText = "Usuario Mod.";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 90;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn18.HeaderText = "Fecha Mod.";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 120;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(813, 26);
            this.labelDegradado1.TabIndex = 252;
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmProvisionLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 465);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.tProvision);
            this.MaximizeBox = false;
            this.Name = "frmProvisionLiquidacion";
            this.Text = "Compras (Nuevo)";
            this.Load += new System.EventHandler(this.frmProvisionLiquidacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProvisionLiquidacion_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsprovisionesccosto)).EndInit();
            this.tProvision.ResumeLayout(false);
            this.tpProvision.ResumeLayout(false);
            this.pnlProvision1.ResumeLayout(false);
            this.pnlDetraccion.ResumeLayout(false);
            this.pnlDetraccion.PerformLayout();
            this.pnlProvision.ResumeLayout(false);
            this.pnlProvision.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlMontos.ResumeLayout(false);
            this.pnlMontos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tpDetalle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvprovisionesccosto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.BindingSource bsprovisionesccosto;
        private System.Windows.Forms.TabControl tProvision;
        private System.Windows.Forms.TabPage tpProvision;
        private System.Windows.Forms.Panel pnlProvision1;
        private System.Windows.Forms.Panel pnlProvision;
        private System.Windows.Forms.CheckBox chkIndDistribucion;
        private System.Windows.Forms.DateTimePicker dtpFecRef;
        private System.Windows.Forms.ComboBox cboReferencia;
        private ControlesWinForm.SuperTextBox txtSerieRef;
        private ControlesWinForm.SuperTextBox txtNumRef;
        private System.Windows.Forms.Button btReparable;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtIdProveedor;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.TextBox txtIdProvision;
        private System.Windows.Forms.DateTimePicker dtpFecDocumento;
        private ControlesWinForm.SuperTextBox txtNumDiasVen;
        private ControlesWinForm.SuperTextBox txtTipCambio;
        private System.Windows.Forms.ComboBox cboDocumento;
        private System.Windows.Forms.CheckBox chkIndCalcAuto;
        private System.Windows.Forms.TextBox txtDesEstado;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.DateTimePicker dtpFechaProvision;
        private System.Windows.Forms.DateTimePicker dtpFecVencimiento;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private ControlesWinForm.SuperTextBox txtSerie;
        private ControlesWinForm.SuperTextBox txtNumero;
        private ControlesWinForm.SuperTextBox txtImporteOrigen;
        private ControlesWinForm.SuperTextBox txtGuia;
        private ControlesWinForm.SuperTextBox txtCodCuenta;
        private ControlesWinForm.SuperTextBox txtDesCuenta;
        private ControlesWinForm.SuperTextBox txtDesProvision;
        private System.Windows.Forms.ComboBox cboTipoAsiento;
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado9;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuRegistro;
        private System.Windows.Forms.TextBox txtUsuModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Panel pnlMontos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ControlesWinForm.SuperTextBox txtTotalSecu;
        private ControlesWinForm.SuperTextBox txtAjusteSecu;
        private ControlesWinForm.SuperTextBox txtExoneradoSecu;
        private ControlesWinForm.SuperTextBox txtImpuestoSecu;
        private ControlesWinForm.SuperTextBox txtBaseSecu;
        private ControlesWinForm.SuperTextBox txtTotal;
        private ControlesWinForm.SuperTextBox txtAjuste;
        private ControlesWinForm.SuperTextBox txtExonerado;
        private ControlesWinForm.SuperTextBox txtImpuesto;
        private MyLabelG.LabelDegradado labelDegradado5;
        private ControlesWinForm.SuperTextBox txtBaseImponible;
        private System.Windows.Forms.TabPage tpDetalle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btActivos;
        private System.Windows.Forms.Button btServicios;
        private System.Windows.Forms.Button btGastos;
        private System.Windows.Forms.Button btArticulos;
        private System.Windows.Forms.DataGridView dgvprovisionesccosto;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesColumnaCoven;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private MyLabelG.LabelDegradado labelDegradado1;
        protected internal System.Windows.Forms.Button btCancelar;
        protected internal System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Panel pnlDetraccion;
        private ControlesWinForm.SuperTextBox txtMontoDetraD;
        private System.Windows.Forms.CheckBox chkPagoDetra;
        private System.Windows.Forms.CheckBox chkDetraccion;
        private ControlesWinForm.SuperTextBox txtNumDetraccion;
        private ControlesWinForm.SuperTextBox txtMontoDetraS;
        private System.Windows.Forms.ComboBox cbotipodetraccion;
        private ControlesWinForm.SuperTextBox txtTasaDetra;
        private System.Windows.Forms.DateTimePicker dtpFecRetencion;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.Button btConceptos;
        private System.Windows.Forms.Button btCosto;
        private ControlesWinForm.SuperTextBox txtNumHojaCosto;
        private System.Windows.Forms.CheckBox chkIndCosto;
        private System.Windows.Forms.CheckBox chkConversion;
        private System.Windows.Forms.Button btConversion;
        private System.Windows.Forms.TextBox txtCodConversion;
    }
}