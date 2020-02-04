namespace ClienteWinForm.Almacen
{
    partial class frmRequisicion
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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label13;
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Prin = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboLocalAtencion = new System.Windows.Forms.ComboBox();
            this.cboLocal = new System.Windows.Forms.ComboBox();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.dtpRequerida = new System.Windows.Forms.DateTimePicker();
            this.dtpSolicitud = new System.Windows.Forms.DateTimePicker();
            this.txtAbreviacion = new ControlesWinForm.SuperTextBox();
            this.txtEstimado = new ControlesWinForm.SuperTextBox();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.cboTipoRequisicion = new System.Windows.Forms.ComboBox();
            this.txtIdCosto = new ControlesWinForm.SuperTextBox();
            this.cboTipoCompra = new System.Windows.Forms.ComboBox();
            this.btCentroDeCosto = new System.Windows.Forms.Button();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtNumRequisicion = new ControlesWinForm.SuperTextBox();
            this.txtJustificacion = new ControlesWinForm.SuperTextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.Item = new System.Windows.Forms.TabPage();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.desArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadRequeridaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoEstimadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.especificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsRequisicionItem = new System.Windows.Forms.BindingSource(this.components);
            this.Pro = new System.Windows.Forms.TabPage();
            this.dgvProveedor = new System.Windows.Forms.DataGridView();
            this.idPersonaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desPersonaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsRequisicionProveedor = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLetras = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Prin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.Item.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicionItem)).BeginInit();
            this.Pro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicionProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(7, 101);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificacion";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(7, 78);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(104, 13);
            usuarioModificacionLabel.TabIndex = 4;
            usuarioModificacionLabel.Text = "Usuario Modificacion";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(7, 32);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(86, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(7, 55);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 2;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(15, 57);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(85, 13);
            label10.TabIndex = 333;
            label10.Text = "Nro° Requisicion";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(16, 182);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(65, 13);
            label9.TabIndex = 335;
            label9.Text = "Justificacion";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(16, 129);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(86, 13);
            label8.TabIndex = 253;
            label8.Text = "Centro de Costo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(256, 103);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(67, 13);
            label6.TabIndex = 182;
            label6.Text = "Tipo Compra";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(248, 56);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(78, 13);
            label5.TabIndex = 346;
            label5.Text = "Fecha Solicitud";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.Location = new System.Drawing.Point(238, 80);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(88, 13);
            label12.TabIndex = 348;
            label12.Text = "Fecha Requerida";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(15, 82);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 13);
            label1.TabIndex = 350;
            label1.Text = "Tipo Requisicion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(16, 152);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(45, 13);
            label2.TabIndex = 352;
            label2.Text = "Moneda";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(240, 151);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(72, 13);
            label3.TabIndex = 353;
            label3.Text = "Importe Total";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(15, 318);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(67, 13);
            label4.TabIndex = 355;
            label4.Text = "Observacion";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(16, 107);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(80, 13);
            label7.TabIndex = 360;
            label7.Text = "Alm. Solicitante";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(15, 34);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(83, 13);
            label11.TabIndex = 362;
            label11.Text = "Local Solicitante";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.Location = new System.Drawing.Point(240, 33);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(76, 13);
            label13.TabIndex = 364;
            label13.Text = "Local Atención";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Prin);
            this.tabControl1.Controls.Add(this.Item);
            this.tabControl1.Controls.Add(this.Pro);
            this.tabControl1.Location = new System.Drawing.Point(6, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(716, 434);
            this.tabControl1.TabIndex = 0;
            // 
            // Prin
            // 
            this.Prin.BackColor = System.Drawing.Color.Azure;
            this.Prin.Controls.Add(this.panel1);
            this.Prin.Controls.Add(this.pnlAuditoria);
            this.Prin.Location = new System.Drawing.Point(4, 22);
            this.Prin.Name = "Prin";
            this.Prin.Padding = new System.Windows.Forms.Padding(3);
            this.Prin.Size = new System.Drawing.Size(708, 408);
            this.Prin.TabIndex = 0;
            this.Prin.Text = "Requisicion";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLetras);
            this.panel1.Controls.Add(label13);
            this.panel1.Controls.Add(this.cboLocalAtencion);
            this.panel1.Controls.Add(label11);
            this.panel1.Controls.Add(this.cboLocal);
            this.panel1.Controls.Add(label7);
            this.panel1.Controls.Add(this.cboAlmacen);
            this.panel1.Controls.Add(this.dtpRequerida);
            this.panel1.Controls.Add(this.dtpSolicitud);
            this.panel1.Controls.Add(this.txtAbreviacion);
            this.panel1.Controls.Add(label4);
            this.panel1.Controls.Add(this.txtEstimado);
            this.panel1.Controls.Add(label3);
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(this.cboMoneda);
            this.panel1.Controls.Add(label1);
            this.panel1.Controls.Add(this.cboTipoRequisicion);
            this.panel1.Controls.Add(label12);
            this.panel1.Controls.Add(label5);
            this.panel1.Controls.Add(this.txtIdCosto);
            this.panel1.Controls.Add(label6);
            this.panel1.Controls.Add(label8);
            this.panel1.Controls.Add(this.cboTipoCompra);
            this.panel1.Controls.Add(label9);
            this.panel1.Controls.Add(label10);
            this.panel1.Controls.Add(this.btCentroDeCosto);
            this.panel1.Controls.Add(this.txtCosto);
            this.panel1.Controls.Add(this.txtNumRequisicion);
            this.panel1.Controls.Add(this.txtJustificacion);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 396);
            this.panel1.TabIndex = 347;
            // 
            // cboLocalAtencion
            // 
            this.cboLocalAtencion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalAtencion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocalAtencion.FormattingEnabled = true;
            this.cboLocalAtencion.Location = new System.Drawing.Point(329, 30);
            this.cboLocalAtencion.Name = "cboLocalAtencion";
            this.cboLocalAtencion.Size = new System.Drawing.Size(98, 21);
            this.cboLocalAtencion.TabIndex = 363;
            // 
            // cboLocal
            // 
            this.cboLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocal.Enabled = false;
            this.cboLocal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocal.FormattingEnabled = true;
            this.cboLocal.Location = new System.Drawing.Point(106, 30);
            this.cboLocal.Name = "cboLocal";
            this.cboLocal.Size = new System.Drawing.Size(127, 21);
            this.cboLocal.TabIndex = 361;
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(106, 101);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(143, 21);
            this.cboAlmacen.TabIndex = 359;
            // 
            // dtpRequerida
            // 
            this.dtpRequerida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRequerida.Location = new System.Drawing.Point(329, 77);
            this.dtpRequerida.Name = "dtpRequerida";
            this.dtpRequerida.Size = new System.Drawing.Size(95, 20);
            this.dtpRequerida.TabIndex = 358;
            // 
            // dtpSolicitud
            // 
            this.dtpSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSolicitud.Location = new System.Drawing.Point(329, 54);
            this.dtpSolicitud.Name = "dtpSolicitud";
            this.dtpSolicitud.Size = new System.Drawing.Size(95, 20);
            this.dtpSolicitud.TabIndex = 357;
            // 
            // txtAbreviacion
            // 
            this.txtAbreviacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtAbreviacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAbreviacion.Location = new System.Drawing.Point(18, 335);
            this.txtAbreviacion.Multiline = true;
            this.txtAbreviacion.Name = "txtAbreviacion";
            this.txtAbreviacion.Size = new System.Drawing.Size(408, 33);
            this.txtAbreviacion.TabIndex = 356;
            this.txtAbreviacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtAbreviacion.TextoVacio = "<Descripcion>";
            // 
            // txtEstimado
            // 
            this.txtEstimado.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEstimado.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEstimado.Enabled = false;
            this.txtEstimado.Location = new System.Drawing.Point(321, 148);
            this.txtEstimado.Name = "txtEstimado";
            this.txtEstimado.Size = new System.Drawing.Size(106, 20);
            this.txtEstimado.TabIndex = 354;
            this.txtEstimado.Text = "0.00";
            this.txtEstimado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEstimado.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtEstimado.TextoVacio = "<Descripcion>";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(106, 147);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(127, 21);
            this.cboMoneda.TabIndex = 351;
            // 
            // cboTipoRequisicion
            // 
            this.cboTipoRequisicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoRequisicion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoRequisicion.FormattingEnabled = true;
            this.cboTipoRequisicion.Location = new System.Drawing.Point(106, 78);
            this.cboTipoRequisicion.Name = "cboTipoRequisicion";
            this.cboTipoRequisicion.Size = new System.Drawing.Size(127, 21);
            this.cboTipoRequisicion.TabIndex = 349;
            this.cboTipoRequisicion.SelectionChangeCommitted += new System.EventHandler(this.cboTipoRequisicion_SelectionChangeCommitted);
            // 
            // txtIdCosto
            // 
            this.txtIdCosto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdCosto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdCosto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdCosto.Enabled = false;
            this.txtIdCosto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCosto.Location = new System.Drawing.Point(106, 125);
            this.txtIdCosto.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdCosto.Name = "txtIdCosto";
            this.txtIdCosto.Size = new System.Drawing.Size(65, 20);
            this.txtIdCosto.TabIndex = 103;
            this.txtIdCosto.TabStop = false;
            this.txtIdCosto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdCosto.TextoVacio = "<Descripcion>";
            // 
            // cboTipoCompra
            // 
            this.cboTipoCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCompra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoCompra.FormattingEnabled = true;
            this.cboTipoCompra.Location = new System.Drawing.Point(326, 101);
            this.cboTipoCompra.Name = "cboTipoCompra";
            this.cboTipoCompra.Size = new System.Drawing.Size(98, 21);
            this.cboTipoCompra.TabIndex = 110;
            // 
            // btCentroDeCosto
            // 
            this.btCentroDeCosto.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCentroDeCosto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCentroDeCosto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCentroDeCosto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCentroDeCosto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCentroDeCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCentroDeCosto.Location = new System.Drawing.Point(403, 126);
            this.btCentroDeCosto.Name = "btCentroDeCosto";
            this.btCentroDeCosto.Size = new System.Drawing.Size(22, 18);
            this.btCentroDeCosto.TabIndex = 324;
            this.btCentroDeCosto.TabStop = false;
            this.btCentroDeCosto.UseVisualStyleBackColor = true;
            this.btCentroDeCosto.Click += new System.EventHandler(this.btCentroDeCosto_Click);
            // 
            // txtCosto
            // 
            this.txtCosto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtCosto.Enabled = false;
            this.txtCosto.Location = new System.Drawing.Point(175, 125);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(223, 20);
            this.txtCosto.TabIndex = 104;
            this.txtCosto.TabStop = false;
            // 
            // txtNumRequisicion
            // 
            this.txtNumRequisicion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumRequisicion.BackColor = System.Drawing.Color.White;
            this.txtNumRequisicion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumRequisicion.Enabled = false;
            this.txtNumRequisicion.Location = new System.Drawing.Point(106, 54);
            this.txtNumRequisicion.Name = "txtNumRequisicion";
            this.txtNumRequisicion.Size = new System.Drawing.Size(127, 20);
            this.txtNumRequisicion.TabIndex = 105;
            this.txtNumRequisicion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumRequisicion.TextoVacio = "<Descripcion>";
            // 
            // txtJustificacion
            // 
            this.txtJustificacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtJustificacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtJustificacion.Location = new System.Drawing.Point(19, 207);
            this.txtJustificacion.Multiline = true;
            this.txtJustificacion.Name = "txtJustificacion";
            this.txtJustificacion.Size = new System.Drawing.Size(408, 108);
            this.txtJustificacion.TabIndex = 108;
            this.txtJustificacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtJustificacion.TextoVacio = "<Descripcion>";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label14);
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(usuarioModificacionLabel);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Location = new System.Drawing.Point(448, 6);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(252, 131);
            this.pnlAuditoria.TabIndex = 101;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(116, 97);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(123, 21);
            this.txtFechaModificacion.TabIndex = 7;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(116, 28);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(123, 21);
            this.txtUsuarioRegistro.TabIndex = 1;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(116, 74);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(123, 21);
            this.txtUsuarioModificacion.TabIndex = 5;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(116, 51);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(123, 21);
            this.txtFechaRegistro.TabIndex = 3;
            // 
            // Item
            // 
            this.Item.BackColor = System.Drawing.Color.Azure;
            this.Item.Controls.Add(this.dgvItem);
            this.Item.Location = new System.Drawing.Point(4, 22);
            this.Item.Name = "Item";
            this.Item.Padding = new System.Windows.Forms.Padding(3);
            this.Item.Size = new System.Drawing.Size(708, 408);
            this.Item.TabIndex = 1;
            this.Item.Text = "Requisicion Item";
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.AutoGenerateColumns = false;
            this.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desArticuloDataGridViewTextBoxColumn,
            this.cantidadRequeridaDataGridViewTextBoxColumn,
            this.montoEstimadoDataGridViewTextBoxColumn,
            this.especificacionDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvItem.DataSource = this.bsRequisicionItem;
            this.dgvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItem.EnableHeadersVisualStyles = false;
            this.dgvItem.Location = new System.Drawing.Point(3, 3);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.Size = new System.Drawing.Size(702, 402);
            this.dgvItem.TabIndex = 2;
            this.dgvItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellDoubleClick);
            // 
            // desArticuloDataGridViewTextBoxColumn
            // 
            this.desArticuloDataGridViewTextBoxColumn.DataPropertyName = "DesArticulo";
            this.desArticuloDataGridViewTextBoxColumn.HeaderText = "Articulo";
            this.desArticuloDataGridViewTextBoxColumn.Name = "desArticuloDataGridViewTextBoxColumn";
            this.desArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            this.desArticuloDataGridViewTextBoxColumn.Width = 160;
            // 
            // cantidadRequeridaDataGridViewTextBoxColumn
            // 
            this.cantidadRequeridaDataGridViewTextBoxColumn.DataPropertyName = "CantidadRequerida";
            this.cantidadRequeridaDataGridViewTextBoxColumn.HeaderText = "Cant. Req.";
            this.cantidadRequeridaDataGridViewTextBoxColumn.Name = "cantidadRequeridaDataGridViewTextBoxColumn";
            this.cantidadRequeridaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montoEstimadoDataGridViewTextBoxColumn
            // 
            this.montoEstimadoDataGridViewTextBoxColumn.DataPropertyName = "MontoEstimado";
            this.montoEstimadoDataGridViewTextBoxColumn.HeaderText = "Precio Uni.";
            this.montoEstimadoDataGridViewTextBoxColumn.Name = "montoEstimadoDataGridViewTextBoxColumn";
            this.montoEstimadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // especificacionDataGridViewTextBoxColumn
            // 
            this.especificacionDataGridViewTextBoxColumn.DataPropertyName = "Especificacion";
            this.especificacionDataGridViewTextBoxColumn.HeaderText = "Especificacion";
            this.especificacionDataGridViewTextBoxColumn.Name = "especificacionDataGridViewTextBoxColumn";
            this.especificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 120;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // bsRequisicionItem
            // 
            this.bsRequisicionItem.DataSource = typeof(Entidades.Almacen.RequisicionItemE);
            // 
            // Pro
            // 
            this.Pro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Pro.Controls.Add(this.dgvProveedor);
            this.Pro.Location = new System.Drawing.Point(4, 22);
            this.Pro.Name = "Pro";
            this.Pro.Size = new System.Drawing.Size(708, 408);
            this.Pro.TabIndex = 2;
            this.Pro.Text = "Requisicion Proveedor";
            // 
            // dgvProveedor
            // 
            this.dgvProveedor.AllowUserToAddRows = false;
            this.dgvProveedor.AllowUserToDeleteRows = false;
            this.dgvProveedor.AutoGenerateColumns = false;
            this.dgvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPersonaDataGridViewTextBoxColumn,
            this.desPersonaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn1,
            this.fechaRegistroDataGridViewTextBoxColumn1,
            this.usuarioModificacionDataGridViewTextBoxColumn1,
            this.fechaModificacionDataGridViewTextBoxColumn1});
            this.dgvProveedor.DataSource = this.bsRequisicionProveedor;
            this.dgvProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProveedor.EnableHeadersVisualStyles = false;
            this.dgvProveedor.Location = new System.Drawing.Point(0, 0);
            this.dgvProveedor.Name = "dgvProveedor";
            this.dgvProveedor.ReadOnly = true;
            this.dgvProveedor.Size = new System.Drawing.Size(708, 408);
            this.dgvProveedor.TabIndex = 2;
            this.dgvProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedor_CellDoubleClick);
            // 
            // idPersonaDataGridViewTextBoxColumn
            // 
            this.idPersonaDataGridViewTextBoxColumn.DataPropertyName = "idPersona";
            this.idPersonaDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idPersonaDataGridViewTextBoxColumn.Name = "idPersonaDataGridViewTextBoxColumn";
            this.idPersonaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPersonaDataGridViewTextBoxColumn.Width = 40;
            // 
            // desPersonaDataGridViewTextBoxColumn
            // 
            this.desPersonaDataGridViewTextBoxColumn.DataPropertyName = "DesPersona";
            this.desPersonaDataGridViewTextBoxColumn.HeaderText = "Persona";
            this.desPersonaDataGridViewTextBoxColumn.Name = "desPersonaDataGridViewTextBoxColumn";
            this.desPersonaDataGridViewTextBoxColumn.ReadOnly = true;
            this.desPersonaDataGridViewTextBoxColumn.Width = 210;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn1
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn1.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn1.HeaderText = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn1.Name = "usuarioRegistroDataGridViewTextBoxColumn1";
            this.usuarioRegistroDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn1
            // 
            this.fechaRegistroDataGridViewTextBoxColumn1.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn1.HeaderText = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn1.Name = "fechaRegistroDataGridViewTextBoxColumn1";
            this.fechaRegistroDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn1
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn1.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn1.HeaderText = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn1.Name = "usuarioModificacionDataGridViewTextBoxColumn1";
            this.usuarioModificacionDataGridViewTextBoxColumn1.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn1.Width = 120;
            // 
            // fechaModificacionDataGridViewTextBoxColumn1
            // 
            this.fechaModificacionDataGridViewTextBoxColumn1.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn1.HeaderText = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn1.Name = "fechaModificacionDataGridViewTextBoxColumn1";
            this.fechaModificacionDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn1.Width = 130;
            // 
            // bsRequisicionProveedor
            // 
            this.bsRequisicionProveedor.DataSource = typeof(Entidades.Almacen.RequisicionProveedorE);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "idEmpresa";
            this.dataGridViewTextBoxColumn1.HeaderText = "idEmpresa";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "idRequisicion";
            this.dataGridViewTextBoxColumn2.HeaderText = "idRequisicion";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "idItem";
            this.dataGridViewTextBoxColumn3.HeaderText = "idItem";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "idLocal";
            this.dataGridViewTextBoxColumn4.HeaderText = "idLocal";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "idArticulo";
            this.dataGridViewTextBoxColumn5.HeaderText = "idArticulo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "CantidadRequerida";
            this.dataGridViewTextBoxColumn6.HeaderText = "CantidadRequerida";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "idMoneda";
            this.dataGridViewTextBoxColumn7.HeaderText = "idMoneda";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "MontoEstimado";
            this.dataGridViewTextBoxColumn8.HeaderText = "MontoEstimado";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Especificacion";
            this.dataGridViewTextBoxColumn9.HeaderText = "Especificacion";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "CantidadOrdenada";
            this.dataGridViewTextBoxColumn10.HeaderText = "CantidadOrdenada";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn11.HeaderText = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "FechaRegistro";
            this.dataGridViewTextBoxColumn12.HeaderText = "FechaRegistro";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn13.HeaderText = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "FechaModificacion";
            this.dataGridViewTextBoxColumn14.HeaderText = "FechaModificacion";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Opcion";
            this.dataGridViewTextBoxColumn15.HeaderText = "Opcion";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "idEmpresa";
            this.dataGridViewTextBoxColumn16.HeaderText = "idEmpresa";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "idRequisicion";
            this.dataGridViewTextBoxColumn17.HeaderText = "idRequisicion";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "idPersona";
            this.dataGridViewTextBoxColumn18.HeaderText = "idPersona";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn19.HeaderText = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "FechaRegistro";
            this.dataGridViewTextBoxColumn20.HeaderText = "FechaRegistro";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn21.HeaderText = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "FechaModificacion";
            this.dataGridViewTextBoxColumn22.HeaderText = "FechaModificacion";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Opcion";
            this.dataGridViewTextBoxColumn23.HeaderText = "Opcion";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(434, 18);
            this.lblLetras.TabIndex = 1578;
            this.lblLetras.Text = "Datos Principales";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(250, 18);
            this.label14.TabIndex = 1578;
            this.label14.Text = "Auditoria";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmRequisicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 451);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmRequisicion";
            this.Text = "Requisicion";
            this.Load += new System.EventHandler(this.frmRequisicion_Load);
            this.tabControl1.ResumeLayout(false);
            this.Prin.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.Item.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicionItem)).EndInit();
            this.Pro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicionProveedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Prin;
        private System.Windows.Forms.TabPage Item;
        private System.Windows.Forms.TabPage Pro;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboTipoRequisicion;
        private ControlesWinForm.SuperTextBox txtIdCosto;
        private System.Windows.Forms.ComboBox cboTipoCompra;
        private System.Windows.Forms.Button btCentroDeCosto;
        private System.Windows.Forms.TextBox txtCosto;
        private ControlesWinForm.SuperTextBox txtNumRequisicion;
        private ControlesWinForm.SuperTextBox txtJustificacion;
        private System.Windows.Forms.ComboBox cboMoneda;
        private ControlesWinForm.SuperTextBox txtEstimado;
        private ControlesWinForm.SuperTextBox txtAbreviacion;
        private System.Windows.Forms.DateTimePicker dtpRequerida;
        private System.Windows.Forms.DateTimePicker dtpSolicitud;
        private System.Windows.Forms.BindingSource bsRequisicionItem;
        private System.Windows.Forms.BindingSource bsRequisicionProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private System.Windows.Forms.ComboBox cboLocalAtencion;
        private System.Windows.Forms.ComboBox cboLocal;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.DataGridView dgvProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn desArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadRequeridaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoEstimadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn especificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPersonaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desPersonaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label lblLetras;
        private System.Windows.Forms.Label label14;
    }
}