namespace ClienteWinForm.Tesoreria
{
    partial class frmAperturaCtaCte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAperturaCtaCte));
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.txtidpersona = new ControlesWinForm.SuperTextBox();
            this.btPersona = new System.Windows.Forms.Button();
            this.btCuenta = new System.Windows.Forms.Button();
            this.cboDocumento = new System.Windows.Forms.ComboBox();
            this.btBuscaPartida = new System.Windows.Forms.Button();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.txtCodPartida = new ControlesWinForm.SuperTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTipPartida = new ControlesWinForm.SuperTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cboDebHab = new System.Windows.Forms.ComboBox();
            this.txtImporte = new ControlesWinForm.SuperTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTica = new ControlesWinForm.SuperTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpFecEm = new System.Windows.Forms.DateTimePicker();
            this.txtNumero = new ControlesWinForm.SuperTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSerie = new ControlesWinForm.SuperTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGlosa = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecOp = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodCuenta = new ControlesWinForm.SuperTextBox();
            this.txtCod = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado5 = new MyLabelG.LabelDegradado();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.pnlDatos.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.txtidpersona);
            this.pnlDatos.Controls.Add(this.btPersona);
            this.pnlDatos.Controls.Add(this.btCuenta);
            this.pnlDatos.Controls.Add(this.cboDocumento);
            this.pnlDatos.Controls.Add(this.btBuscaPartida);
            this.pnlDatos.Controls.Add(this.cboMoneda);
            this.pnlDatos.Controls.Add(this.txtCodPartida);
            this.pnlDatos.Controls.Add(this.label16);
            this.pnlDatos.Controls.Add(this.txtTipPartida);
            this.pnlDatos.Controls.Add(this.label17);
            this.pnlDatos.Controls.Add(this.label15);
            this.pnlDatos.Controls.Add(this.cboDebHab);
            this.pnlDatos.Controls.Add(this.txtImporte);
            this.pnlDatos.Controls.Add(this.label14);
            this.pnlDatos.Controls.Add(this.label13);
            this.pnlDatos.Controls.Add(this.txtTica);
            this.pnlDatos.Controls.Add(this.label12);
            this.pnlDatos.Controls.Add(this.label11);
            this.pnlDatos.Controls.Add(this.dtpFecEm);
            this.pnlDatos.Controls.Add(this.txtNumero);
            this.pnlDatos.Controls.Add(this.label10);
            this.pnlDatos.Controls.Add(this.txtSerie);
            this.pnlDatos.Controls.Add(this.label9);
            this.pnlDatos.Controls.Add(this.label6);
            this.pnlDatos.Controls.Add(this.txtGlosa);
            this.pnlDatos.Controls.Add(this.label5);
            this.pnlDatos.Controls.Add(this.dtpFecOp);
            this.pnlDatos.Controls.Add(this.label1);
            this.pnlDatos.Controls.Add(this.txtCodCuenta);
            this.pnlDatos.Controls.Add(this.txtCod);
            this.pnlDatos.Controls.Add(this.labelDegradado2);
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Location = new System.Drawing.Point(3, 4);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(759, 144);
            this.pnlDatos.TabIndex = 133;
            // 
            // txtidpersona
            // 
            this.txtidpersona.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtidpersona.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtidpersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtidpersona.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtidpersona.Enabled = false;
            this.txtidpersona.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidpersona.Location = new System.Drawing.Point(101, 75);
            this.txtidpersona.Margin = new System.Windows.Forms.Padding(2);
            this.txtidpersona.Name = "txtidpersona";
            this.txtidpersona.Size = new System.Drawing.Size(96, 20);
            this.txtidpersona.TabIndex = 333;
            this.txtidpersona.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtidpersona.TextoVacio = "<Descripcion>";
            // 
            // btPersona
            // 
            this.btPersona.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btPersona.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btPersona.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btPersona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPersona.Image = ((System.Drawing.Image)(resources.GetObject("btPersona.Image")));
            this.btPersona.Location = new System.Drawing.Point(202, 73);
            this.btPersona.Name = "btPersona";
            this.btPersona.Size = new System.Drawing.Size(25, 20);
            this.btPersona.TabIndex = 332;
            this.btPersona.UseVisualStyleBackColor = true;
            this.btPersona.Click += new System.EventHandler(this.btPersona_Click);
            // 
            // btCuenta
            // 
            this.btCuenta.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCuenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCuenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btCuenta.Image")));
            this.btCuenta.Location = new System.Drawing.Point(202, 50);
            this.btCuenta.Name = "btCuenta";
            this.btCuenta.Size = new System.Drawing.Size(25, 20);
            this.btCuenta.TabIndex = 331;
            this.btCuenta.UseVisualStyleBackColor = true;
            this.btCuenta.Click += new System.EventHandler(this.btCuenta_Click);
            // 
            // cboDocumento
            // 
            this.cboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumento.DropDownWidth = 250;
            this.cboDocumento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumento.FormattingEnabled = true;
            this.cboDocumento.Location = new System.Drawing.Point(334, 47);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Size = new System.Drawing.Size(138, 21);
            this.cboDocumento.TabIndex = 330;
            // 
            // btBuscaPartida
            // 
            this.btBuscaPartida.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscaPartida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btBuscaPartida.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscaPartida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscaPartida.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btBuscaPartida.Location = new System.Drawing.Point(459, 118);
            this.btBuscaPartida.Name = "btBuscaPartida";
            this.btBuscaPartida.Size = new System.Drawing.Size(26, 20);
            this.btBuscaPartida.TabIndex = 329;
            this.btBuscaPartida.UseVisualStyleBackColor = true;
            this.btBuscaPartida.Click += new System.EventHandler(this.btBuscaPartida_Click);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(648, 93);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(96, 21);
            this.cboMoneda.TabIndex = 321;
            // 
            // txtCodPartida
            // 
            this.txtCodPartida.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodPartida.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCodPartida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodPartida.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodPartida.Enabled = false;
            this.txtCodPartida.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPartida.Location = new System.Drawing.Point(334, 118);
            this.txtCodPartida.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodPartida.Name = "txtCodPartida";
            this.txtCodPartida.Size = new System.Drawing.Size(123, 20);
            this.txtCodPartida.TabIndex = 309;
            this.txtCodPartida.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodPartida.TextoVacio = "<Descripcion>";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(268, 122);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 308;
            this.label16.Text = "Cod. Partida";
            // 
            // txtTipPartida
            // 
            this.txtTipPartida.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTipPartida.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtTipPartida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipPartida.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTipPartida.Enabled = false;
            this.txtTipPartida.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipPartida.Location = new System.Drawing.Point(101, 120);
            this.txtTipPartida.Margin = new System.Windows.Forms.Padding(2);
            this.txtTipPartida.Name = "txtTipPartida";
            this.txtTipPartida.Size = new System.Drawing.Size(162, 20);
            this.txtTipPartida.TabIndex = 307;
            this.txtTipPartida.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtTipPartida.TextoVacio = "<Descripcion>";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 124);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 13);
            this.label17.TabIndex = 306;
            this.label17.Text = "Tip. Partida";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 101);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 305;
            this.label15.Text = "Ind. Deb/Hab";
            // 
            // cboDebHab
            // 
            this.cboDebHab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDebHab.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDebHab.FormattingEnabled = true;
            this.cboDebHab.Location = new System.Drawing.Point(101, 97);
            this.cboDebHab.Margin = new System.Windows.Forms.Padding(2);
            this.cboDebHab.Name = "cboDebHab";
            this.cboDebHab.Size = new System.Drawing.Size(96, 21);
            this.cboDebHab.TabIndex = 304;
            // 
            // txtImporte
            // 
            this.txtImporte.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtImporte.BackColor = System.Drawing.Color.White;
            this.txtImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImporte.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtImporte.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporte.Location = new System.Drawing.Point(648, 117);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(59, 20);
            this.txtImporte.TabIndex = 303;
            this.txtImporte.Text = "0.00";
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtImporte.TextoVacio = "<Descripcion>";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(586, 121);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 302;
            this.label14.Text = "Importe";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(583, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 300;
            this.label13.Text = " Moneda";
            // 
            // txtTica
            // 
            this.txtTica.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTica.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtTica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTica.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTica.Enabled = false;
            this.txtTica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTica.Location = new System.Drawing.Point(648, 71);
            this.txtTica.Margin = new System.Windows.Forms.Padding(2);
            this.txtTica.Name = "txtTica";
            this.txtTica.Size = new System.Drawing.Size(59, 20);
            this.txtTica.TabIndex = 299;
            this.txtTica.Text = "0.00";
            this.txtTica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTica.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtTica.TextoVacio = "<Descripcion>";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(583, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 298;
            this.label12.Text = "Tip. Cambio";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(580, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 297;
            this.label11.Text = "Fec. Emision";
            // 
            // dtpFecEm
            // 
            this.dtpFecEm.CustomFormat = "dd/MM/yyyy";
            this.dtpFecEm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecEm.Location = new System.Drawing.Point(648, 47);
            this.dtpFecEm.Name = "dtpFecEm";
            this.dtpFecEm.Size = new System.Drawing.Size(96, 20);
            this.dtpFecEm.TabIndex = 296;
            // 
            // txtNumero
            // 
            this.txtNumero.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumero.BackColor = System.Drawing.Color.White;
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumero.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumero.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(334, 94);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(138, 20);
            this.txtNumero.TabIndex = 295;
            this.txtNumero.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumero.TextoVacio = "<Descripcion>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(270, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 294;
            this.label10.Text = "Número";
            // 
            // txtSerie
            // 
            this.txtSerie.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerie.BackColor = System.Drawing.Color.White;
            this.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerie.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSerie.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(334, 71);
            this.txtSerie.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(138, 20);
            this.txtSerie.TabIndex = 293;
            this.txtSerie.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerie.TextoVacio = "<Descripcion>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 292;
            this.label9.Text = "Serie";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 290;
            this.label6.Text = "Documento";
            // 
            // txtGlosa
            // 
            this.txtGlosa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtGlosa.BackColor = System.Drawing.Color.White;
            this.txtGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGlosa.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtGlosa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGlosa.Location = new System.Drawing.Point(334, 25);
            this.txtGlosa.Margin = new System.Windows.Forms.Padding(2);
            this.txtGlosa.Name = "txtGlosa";
            this.txtGlosa.Size = new System.Drawing.Size(410, 20);
            this.txtGlosa.TabIndex = 289;
            this.txtGlosa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtGlosa.TextoVacio = "<Descripcion>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 288;
            this.label5.Text = "Glosa";
            // 
            // dtpFecOp
            // 
            this.dtpFecOp.CustomFormat = "dd/MM/yyyy";
            this.dtpFecOp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecOp.Location = new System.Drawing.Point(101, 25);
            this.dtpFecOp.Name = "dtpFecOp";
            this.dtpFecOp.Size = new System.Drawing.Size(96, 20);
            this.dtpFecOp.TabIndex = 287;
            this.dtpFecOp.ValueChanged += new System.EventHandler(this.dtpFecOp_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 286;
            this.label1.Text = "Id Persona";
            // 
            // txtCodCuenta
            // 
            this.txtCodCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodCuenta.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCodCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodCuenta.Enabled = false;
            this.txtCodCuenta.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCuenta.Location = new System.Drawing.Point(101, 50);
            this.txtCodCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodCuenta.Name = "txtCodCuenta";
            this.txtCodCuenta.Size = new System.Drawing.Size(96, 20);
            this.txtCodCuenta.TabIndex = 273;
            this.txtCodCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodCuenta.TextoVacio = "<Descripcion>";
            // 
            // txtCod
            // 
            this.txtCod.AutoSize = true;
            this.txtCod.Location = new System.Drawing.Point(6, 55);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(94, 13);
            this.txtCod.TabIndex = 272;
            this.txtCod.Text = "Codigo De Cuenta";
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(757, 20);
            this.labelDegradado2.TabIndex = 270;
            this.labelDegradado2.Text = "Principales";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 101;
            this.label8.Text = "Fecha Operacion";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado5);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(766, 4);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(265, 121);
            this.pnlAuditoria.TabIndex = 132;
            // 
            // labelDegradado5
            // 
            this.labelDegradado5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado5.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado5.ForeColor = System.Drawing.Color.White;
            this.labelDegradado5.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado5.Name = "labelDegradado5";
            this.labelDegradado5.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado5.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado5.Size = new System.Drawing.Size(263, 20);
            this.labelDegradado5.TabIndex = 274;
            this.labelDegradado5.Text = "Auditoria";
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(15, 96);
            this.fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaModificacionLabel.Name = "fechaModificacionLabel";
            this.fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            this.fechaModificacionLabel.TabIndex = 6;
            this.fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtModifica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(122, 92);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(133, 20);
            this.txtModifica.TabIndex = 0;
            // 
            // txtRegistro
            // 
            this.txtRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegistro.Enabled = false;
            this.txtRegistro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(122, 50);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtRegistro.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 33);
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
            this.label3.Location = new System.Drawing.Point(15, 54);
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
            this.label4.Location = new System.Drawing.Point(15, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuario Modificación";
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuRegistra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(122, 29);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(133, 20);
            this.txtUsuRegistra.TabIndex = 0;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuModifica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(122, 71);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(133, 20);
            this.txtUsuModifica.TabIndex = 0;
            // 
            // frmAperturaCtaCte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 151);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmAperturaCtaCte";
            this.Text = "Apertura Cuenta Corriente";
            this.Load += new System.EventHandler(this.frmAperturaCtaCte_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtCodCuenta;
        private System.Windows.Forms.Label txtCod;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado5;
        private System.Windows.Forms.Label fechaModificacionLabel;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.DateTimePicker dtpFecOp;
        private ControlesWinForm.SuperTextBox txtGlosa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFecEm;
        private System.Windows.Forms.Label label11;
        private ControlesWinForm.SuperTextBox txtTica;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private ControlesWinForm.SuperTextBox txtImporte;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboDebHab;
        private ControlesWinForm.SuperTextBox txtCodPartida;
        private System.Windows.Forms.Label label16;
        private ControlesWinForm.SuperTextBox txtTipPartida;
        private System.Windows.Forms.Label label17;
        private ControlesWinForm.SuperTextBox txtNumero;
        private System.Windows.Forms.Label label10;
        private ControlesWinForm.SuperTextBox txtSerie;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Button btBuscaPartida;
        private System.Windows.Forms.ComboBox cboDocumento;
        private System.Windows.Forms.Button btCuenta;
        private System.Windows.Forms.Button btPersona;
        private ControlesWinForm.SuperTextBox txtidpersona;
    }
}