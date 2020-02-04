namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmNumControlCompraDet
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label cantDigNumeroLabel;
            System.Windows.Forms.Label idDocumentoLabel;
            System.Windows.Forms.Label cantDigSerieLabel;
            System.Windows.Forms.Label serieLabel;
            System.Windows.Forms.Label numInicialLabel;
            System.Windows.Forms.Label numFinalLabel;
            System.Windows.Forms.Label label7;
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.usuarioRegistroTextBox = new System.Windows.Forms.TextBox();
            this.usuarioModificacionTextBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtCorrelativo = new ControlesWinForm.SuperTextBox();
            this.cboDocumentos = new System.Windows.Forms.ComboBox();
            this.txtCantNumero = new ControlesWinForm.SuperTextBox();
            this.txtSerie = new ControlesWinForm.SuperTextBox();
            this.txtCantSerie = new ControlesWinForm.SuperTextBox();
            this.txtNumInicial = new ControlesWinForm.SuperTextBox();
            this.txtNumFinal = new ControlesWinForm.SuperTextBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            cantDigNumeroLabel = new System.Windows.Forms.Label();
            idDocumentoLabel = new System.Windows.Forms.Label();
            cantDigSerieLabel = new System.Windows.Forms.Label();
            serieLabel = new System.Windows.Forms.Label();
            numInicialLabel = new System.Windows.Forms.Label();
            numFinalLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(563, 162);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(439, 162);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(384, 22);
            this.lblTitPnlBase.Text = "Control";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(733, 25);
            this.lblTituloPrincipal.Text = "Detale Control de Compra";
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.CtasPorPagar.NumControlCompraDetE);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(708, 0);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.txtCorrelativo);
            this.pnlBase.Controls.Add(this.cboDocumentos);
            this.pnlBase.Controls.Add(cantDigNumeroLabel);
            this.pnlBase.Controls.Add(idDocumentoLabel);
            this.pnlBase.Controls.Add(this.txtCantNumero);
            this.pnlBase.Controls.Add(cantDigSerieLabel);
            this.pnlBase.Controls.Add(this.txtSerie);
            this.pnlBase.Controls.Add(this.txtCantSerie);
            this.pnlBase.Controls.Add(serieLabel);
            this.pnlBase.Controls.Add(this.txtNumInicial);
            this.pnlBase.Controls.Add(this.txtNumFinal);
            this.pnlBase.Controls.Add(numInicialLabel);
            this.pnlBase.Controls.Add(numFinalLabel);
            this.pnlBase.Controls.Add(label7);
            this.pnlBase.Size = new System.Drawing.Size(386, 106);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(label7, 0);
            this.pnlBase.Controls.SetChildIndex(numFinalLabel, 0);
            this.pnlBase.Controls.SetChildIndex(numInicialLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNumFinal, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNumInicial, 0);
            this.pnlBase.Controls.SetChildIndex(serieLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCantSerie, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtSerie, 0);
            this.pnlBase.Controls.SetChildIndex(cantDigSerieLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCantNumero, 0);
            this.pnlBase.Controls.SetChildIndex(idDocumentoLabel, 0);
            this.pnlBase.Controls.SetChildIndex(cantDigNumeroLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboDocumentos, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCorrelativo, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(36, 100);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(36, 77);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(36, 32);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(36, 54);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // cantDigNumeroLabel
            // 
            cantDigNumeroLabel.AutoSize = true;
            cantDigNumeroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cantDigNumeroLabel.Location = new System.Drawing.Point(13, 78);
            cantDigNumeroLabel.Name = "cantDigNumeroLabel";
            cantDigNumeroLabel.Size = new System.Drawing.Size(67, 13);
            cantDigNumeroLabel.TabIndex = 269;
            cantDigNumeroLabel.Text = "Dígitos Núm.";
            // 
            // idDocumentoLabel
            // 
            idDocumentoLabel.AutoSize = true;
            idDocumentoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idDocumentoLabel.Location = new System.Drawing.Point(13, 32);
            idDocumentoLabel.Name = "idDocumentoLabel";
            idDocumentoLabel.Size = new System.Drawing.Size(61, 13);
            idDocumentoLabel.TabIndex = 274;
            idDocumentoLabel.Text = "Documento";
            // 
            // cantDigSerieLabel
            // 
            cantDigSerieLabel.AutoSize = true;
            cantDigSerieLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cantDigSerieLabel.Location = new System.Drawing.Point(13, 55);
            cantDigSerieLabel.Name = "cantDigSerieLabel";
            cantDigSerieLabel.Size = new System.Drawing.Size(66, 13);
            cantDigSerieLabel.TabIndex = 270;
            cantDigSerieLabel.Text = "Dígitos Serie";
            // 
            // serieLabel
            // 
            serieLabel.AutoSize = true;
            serieLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            serieLabel.Location = new System.Drawing.Point(127, 55);
            serieLabel.Name = "serieLabel";
            serieLabel.Size = new System.Drawing.Size(31, 13);
            serieLabel.TabIndex = 278;
            serieLabel.Text = "Serie";
            // 
            // numInicialLabel
            // 
            numInicialLabel.AutoSize = true;
            numInicialLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numInicialLabel.Location = new System.Drawing.Point(240, 53);
            numInicialLabel.Name = "numInicialLabel";
            numInicialLabel.Size = new System.Drawing.Size(57, 13);
            numInicialLabel.TabIndex = 277;
            numInicialLabel.Text = "Num. Final";
            // 
            // numFinalLabel
            // 
            numFinalLabel.AutoSize = true;
            numFinalLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numFinalLabel.Location = new System.Drawing.Point(240, 30);
            numFinalLabel.Name = "numFinalLabel";
            numFinalLabel.Size = new System.Drawing.Size(60, 13);
            numFinalLabel.TabIndex = 276;
            numFinalLabel.Text = "Num. Inicio";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(240, 75);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(60, 13);
            label7.TabIndex = 280;
            label7.Text = "Correlativo";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado4);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.textBox1);
            this.pnlAuditoria.Controls.Add(this.usuarioRegistroTextBox);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.usuarioModificacionTextBox);
            this.pnlAuditoria.Controls.Add(this.textBox2);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(399, 31);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(309, 126);
            this.pnlAuditoria.TabIndex = 256;
            // 
            // labelDegradado4
            // 
            this.labelDegradado4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado4.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado4.ForeColor = System.Drawing.Color.White;
            this.labelDegradado4.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado4.Name = "labelDegradado4";
            this.labelDegradado4.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado4.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado4.Size = new System.Drawing.Size(307, 20);
            this.labelDegradado4.TabIndex = 251;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "FechaModificacion", true));
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(145, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 21);
            this.textBox1.TabIndex = 304;
            // 
            // usuarioRegistroTextBox
            // 
            this.usuarioRegistroTextBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.usuarioRegistroTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuarioRegistroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "UsuarioRegistro", true));
            this.usuarioRegistroTextBox.Enabled = false;
            this.usuarioRegistroTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioRegistroTextBox.Location = new System.Drawing.Point(145, 27);
            this.usuarioRegistroTextBox.Name = "usuarioRegistroTextBox";
            this.usuarioRegistroTextBox.Size = new System.Drawing.Size(125, 21);
            this.usuarioRegistroTextBox.TabIndex = 300;
            // 
            // usuarioModificacionTextBox
            // 
            this.usuarioModificacionTextBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.usuarioModificacionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuarioModificacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "UsuarioModificacion", true));
            this.usuarioModificacionTextBox.Enabled = false;
            this.usuarioModificacionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioModificacionTextBox.Location = new System.Drawing.Point(145, 72);
            this.usuarioModificacionTextBox.Name = "usuarioModificacionTextBox";
            this.usuarioModificacionTextBox.Size = new System.Drawing.Size(125, 21);
            this.usuarioModificacionTextBox.TabIndex = 303;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "FechaRegistro", true));
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(145, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 21);
            this.textBox2.TabIndex = 301;
            // 
            // txtCorrelativo
            // 
            this.txtCorrelativo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCorrelativo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCorrelativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorrelativo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCorrelativo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "numCorrelativo", true));
            this.txtCorrelativo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorrelativo.Location = new System.Drawing.Point(303, 71);
            this.txtCorrelativo.Name = "txtCorrelativo";
            this.txtCorrelativo.Size = new System.Drawing.Size(67, 21);
            this.txtCorrelativo.TabIndex = 279;
            this.txtCorrelativo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCorrelativo.TextoVacio = "<Descripcion>";
            // 
            // cboDocumentos
            // 
            this.cboDocumentos.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsBase, "idDocumento", true));
            this.cboDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumentos.DropDownWidth = 200;
            this.cboDocumentos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumentos.FormattingEnabled = true;
            this.cboDocumentos.Location = new System.Drawing.Point(80, 28);
            this.cboDocumentos.Name = "cboDocumentos";
            this.cboDocumentos.Size = new System.Drawing.Size(154, 21);
            this.cboDocumentos.TabIndex = 259;
            this.cboDocumentos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDocumentos_KeyPress);
            // 
            // txtCantNumero
            // 
            this.txtCantNumero.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCantNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantNumero.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCantNumero.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "cantDigNumero", true));
            this.txtCantNumero.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantNumero.Location = new System.Drawing.Point(80, 73);
            this.txtCantNumero.Name = "txtCantNumero";
            this.txtCantNumero.Size = new System.Drawing.Size(33, 21);
            this.txtCantNumero.TabIndex = 262;
            this.txtCantNumero.Text = "0";
            this.txtCantNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantNumero.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCantNumero.TextoVacio = "<Descripcion>";
            this.txtCantNumero.TextChanged += new System.EventHandler(this.txtCantNumero_TextChanged);
            // 
            // txtSerie
            // 
            this.txtSerie.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerie.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerie.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSerie.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "Serie", true));
            this.txtSerie.Enabled = false;
            this.txtSerie.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(159, 51);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(63, 21);
            this.txtSerie.TabIndex = 261;
            this.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSerie.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerie.TextoVacio = "<Descripcion>";
            this.txtSerie.Enter += new System.EventHandler(this.txtSerie_Enter);
            // 
            // txtCantSerie
            // 
            this.txtCantSerie.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCantSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantSerie.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCantSerie.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "cantDigSerie", true));
            this.txtCantSerie.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantSerie.Location = new System.Drawing.Point(80, 51);
            this.txtCantSerie.Name = "txtCantSerie";
            this.txtCantSerie.Size = new System.Drawing.Size(33, 21);
            this.txtCantSerie.TabIndex = 260;
            this.txtCantSerie.Text = "0";
            this.txtCantSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantSerie.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCantSerie.TextoVacio = "<Descripcion>";
            this.txtCantSerie.TextChanged += new System.EventHandler(this.txtCantSerie_TextChanged);
            // 
            // txtNumInicial
            // 
            this.txtNumInicial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumInicial.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtNumInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumInicial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumInicial.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "numInicial", true));
            this.txtNumInicial.Enabled = false;
            this.txtNumInicial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumInicial.Location = new System.Drawing.Point(303, 26);
            this.txtNumInicial.Name = "txtNumInicial";
            this.txtNumInicial.Size = new System.Drawing.Size(67, 21);
            this.txtNumInicial.TabIndex = 263;
            this.txtNumInicial.Text = "0000000001";
            this.txtNumInicial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumInicial.TextoVacio = "<Descripcion>";
            this.txtNumInicial.Enter += new System.EventHandler(this.txtNumInicial_Enter);
            // 
            // txtNumFinal
            // 
            this.txtNumFinal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumFinal.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtNumFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumFinal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumFinal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "numFinal", true));
            this.txtNumFinal.Enabled = false;
            this.txtNumFinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumFinal.Location = new System.Drawing.Point(303, 49);
            this.txtNumFinal.Name = "txtNumFinal";
            this.txtNumFinal.Size = new System.Drawing.Size(67, 21);
            this.txtNumFinal.TabIndex = 264;
            this.txtNumFinal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumFinal.TextoVacio = "<Descripcion>";
            this.txtNumFinal.Enter += new System.EventHandler(this.txtNumFinal_Enter);
            // 
            // frmNumControlCompraDet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 194);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmNumControlCompraDet";
            this.Text = "frmNumControlCompraDet";
            this.Load += new System.EventHandler(this.frmNumControlCompraDet_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox usuarioRegistroTextBox;
        private System.Windows.Forms.TextBox usuarioModificacionTextBox;
        private System.Windows.Forms.TextBox textBox2;
        private ControlesWinForm.SuperTextBox txtCorrelativo;
        private System.Windows.Forms.ComboBox cboDocumentos;
        private ControlesWinForm.SuperTextBox txtCantNumero;
        private ControlesWinForm.SuperTextBox txtSerie;
        private ControlesWinForm.SuperTextBox txtCantSerie;
        private ControlesWinForm.SuperTextBox txtNumInicial;
        private ControlesWinForm.SuperTextBox txtNumFinal;
    }
}