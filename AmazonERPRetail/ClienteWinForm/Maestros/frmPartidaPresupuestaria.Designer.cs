namespace ClienteWinForm.Maestros
{
    partial class frmPartidaPresupuestaria
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
            System.Windows.Forms.Label abrevPartidaPresuLabel;
            System.Windows.Forms.Label codPartidaPresuLabel;
            System.Windows.Forms.Label codPartidaPresuSupLabel;
            System.Windows.Forms.Label desPartidaPresuLabel;
            System.Windows.Forms.Label fechaBajaLabel;
            System.Windows.Forms.Label indUltNodoLabel;
            System.Windows.Forms.Label numNivelLabel;
            System.Windows.Forms.Label tipPartidaPresuLabel;
            System.Windows.Forms.Label tipTituloNodoLabel;
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
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
            this.txtAbreviatura = new ControlesWinForm.SuperTextBox();
            this.txtCodPartida = new ControlesWinForm.SuperTextBox();
            this.txtCodSuperior = new ControlesWinForm.SuperTextBox();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.dtpFecBaja = new System.Windows.Forms.DateTimePicker();
            this.chkIndicaBaja = new System.Windows.Forms.CheckBox();
            this.cboIndicaUltimo = new System.Windows.Forms.ComboBox();
            this.nudNivel = new System.Windows.Forms.NumericUpDown();
            this.cboTipoPartida = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.cboTitulo = new System.Windows.Forms.ComboBox();
            this.btBuscarCodigo = new System.Windows.Forms.Button();
            abrevPartidaPresuLabel = new System.Windows.Forms.Label();
            codPartidaPresuLabel = new System.Windows.Forms.Label();
            codPartidaPresuSupLabel = new System.Windows.Forms.Label();
            desPartidaPresuLabel = new System.Windows.Forms.Label();
            fechaBajaLabel = new System.Windows.Forms.Label();
            indUltNodoLabel = new System.Windows.Forms.Label();
            numNivelLabel = new System.Windows.Forms.Label();
            tipPartidaPresuLabel = new System.Windows.Forms.Label();
            tipTituloNodoLabel = new System.Windows.Forms.Label();
            this.pnlDatos.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.btBuscarCodigo);
            this.pnlDatos.Controls.Add(this.cboTitulo);
            this.pnlDatos.Controls.Add(abrevPartidaPresuLabel);
            this.pnlDatos.Controls.Add(this.txtAbreviatura);
            this.pnlDatos.Controls.Add(codPartidaPresuLabel);
            this.pnlDatos.Controls.Add(this.txtCodPartida);
            this.pnlDatos.Controls.Add(codPartidaPresuSupLabel);
            this.pnlDatos.Controls.Add(this.txtCodSuperior);
            this.pnlDatos.Controls.Add(desPartidaPresuLabel);
            this.pnlDatos.Controls.Add(this.txtDescripcion);
            this.pnlDatos.Controls.Add(indUltNodoLabel);
            this.pnlDatos.Controls.Add(this.cboIndicaUltimo);
            this.pnlDatos.Controls.Add(numNivelLabel);
            this.pnlDatos.Controls.Add(this.nudNivel);
            this.pnlDatos.Controls.Add(tipPartidaPresuLabel);
            this.pnlDatos.Controls.Add(this.cboTipoPartida);
            this.pnlDatos.Controls.Add(tipTituloNodoLabel);
            this.pnlDatos.Controls.Add(this.labelDegradado2);
            this.pnlDatos.Location = new System.Drawing.Point(6, 5);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(317, 219);
            this.pnlDatos.TabIndex = 11;
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
            this.labelDegradado2.Size = new System.Drawing.Size(315, 20);
            this.labelDegradado2.TabIndex = 270;
            this.labelDegradado2.Text = "Principales";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.pnlAuditoria.Location = new System.Drawing.Point(325, 6);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(267, 133);
            this.pnlAuditoria.TabIndex = 29;
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
            this.labelDegradado5.Size = new System.Drawing.Size(265, 20);
            this.labelDegradado5.TabIndex = 274;
            this.labelDegradado5.Text = "Auditoria";
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(13, 100);
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
            this.txtModifica.Location = new System.Drawing.Point(120, 96);
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
            this.txtRegistro.Location = new System.Drawing.Point(120, 53);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtRegistro.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 36);
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
            this.label3.Location = new System.Drawing.Point(13, 57);
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
            this.label4.Location = new System.Drawing.Point(13, 79);
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
            this.txtUsuRegistra.Location = new System.Drawing.Point(120, 32);
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
            this.txtUsuModifica.Location = new System.Drawing.Point(120, 75);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(133, 20);
            this.txtUsuModifica.TabIndex = 0;
            // 
            // abrevPartidaPresuLabel
            // 
            abrevPartidaPresuLabel.AutoSize = true;
            abrevPartidaPresuLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            abrevPartidaPresuLabel.Location = new System.Drawing.Point(17, 122);
            abrevPartidaPresuLabel.Name = "abrevPartidaPresuLabel";
            abrevPartidaPresuLabel.Size = new System.Drawing.Size(64, 13);
            abrevPartidaPresuLabel.TabIndex = 270;
            abrevPartidaPresuLabel.Text = "Abreviatura";
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtAbreviatura.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAbreviatura.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbreviatura.Location = new System.Drawing.Point(96, 119);
            this.txtAbreviatura.Name = "txtAbreviatura";
            this.txtAbreviatura.Size = new System.Drawing.Size(200, 20);
            this.txtAbreviatura.TabIndex = 271;
            this.txtAbreviatura.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtAbreviatura.TextoVacio = "<Descripcion>";
            // 
            // codPartidaPresuLabel
            // 
            codPartidaPresuLabel.AutoSize = true;
            codPartidaPresuLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codPartidaPresuLabel.Location = new System.Drawing.Point(17, 77);
            codPartidaPresuLabel.Name = "codPartidaPresuLabel";
            codPartidaPresuLabel.Size = new System.Drawing.Size(40, 13);
            codPartidaPresuLabel.TabIndex = 272;
            codPartidaPresuLabel.Text = "Código";
            // 
            // txtCodPartida
            // 
            this.txtCodPartida.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodPartida.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodPartida.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPartida.Location = new System.Drawing.Point(96, 74);
            this.txtCodPartida.Name = "txtCodPartida";
            this.txtCodPartida.Size = new System.Drawing.Size(100, 20);
            this.txtCodPartida.TabIndex = 273;
            this.txtCodPartida.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodPartida.TextoVacio = "<Descripcion>";
            // 
            // codPartidaPresuSupLabel
            // 
            codPartidaPresuSupLabel.AutoSize = true;
            codPartidaPresuSupLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codPartidaPresuSupLabel.Location = new System.Drawing.Point(17, 31);
            codPartidaPresuSupLabel.Name = "codPartidaPresuSupLabel";
            codPartidaPresuSupLabel.Size = new System.Drawing.Size(73, 13);
            codPartidaPresuSupLabel.TabIndex = 274;
            codPartidaPresuSupLabel.Text = "Cód. Superior";
            // 
            // txtCodSuperior
            // 
            this.txtCodSuperior.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodSuperior.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCodSuperior.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodSuperior.Enabled = false;
            this.txtCodSuperior.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodSuperior.Location = new System.Drawing.Point(96, 28);
            this.txtCodSuperior.Name = "txtCodSuperior";
            this.txtCodSuperior.Size = new System.Drawing.Size(100, 20);
            this.txtCodSuperior.TabIndex = 275;
            this.txtCodSuperior.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodSuperior.TextoVacio = "<Descripcion>";
            // 
            // desPartidaPresuLabel
            // 
            desPartidaPresuLabel.AutoSize = true;
            desPartidaPresuLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            desPartidaPresuLabel.Location = new System.Drawing.Point(17, 99);
            desPartidaPresuLabel.Name = "desPartidaPresuLabel";
            desPartidaPresuLabel.Size = new System.Drawing.Size(61, 13);
            desPartidaPresuLabel.TabIndex = 276;
            desPartidaPresuLabel.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(96, 96);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 20);
            this.txtDescripcion.TabIndex = 277;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripcion.TextoVacio = "<Descripcion>";
            // 
            // fechaBajaLabel
            // 
            fechaBajaLabel.AutoSize = true;
            fechaBajaLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaBajaLabel.Location = new System.Drawing.Point(57, 56);
            fechaBajaLabel.Name = "fechaBajaLabel";
            fechaBajaLabel.Size = new System.Drawing.Size(60, 13);
            fechaBajaLabel.TabIndex = 278;
            fechaBajaLabel.Text = "Fecha Baja";
            // 
            // dtpFecBaja
            // 
            this.dtpFecBaja.CustomFormat = "dd/MM/yyyy";
            this.dtpFecBaja.Enabled = false;
            this.dtpFecBaja.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecBaja.Location = new System.Drawing.Point(128, 52);
            this.dtpFecBaja.Name = "dtpFecBaja";
            this.dtpFecBaja.Size = new System.Drawing.Size(96, 20);
            this.dtpFecBaja.TabIndex = 279;
            // 
            // chkIndicaBaja
            // 
            this.chkIndicaBaja.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndicaBaja.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndicaBaja.Location = new System.Drawing.Point(57, 27);
            this.chkIndicaBaja.Name = "chkIndicaBaja";
            this.chkIndicaBaja.Size = new System.Drawing.Size(85, 24);
            this.chkIndicaBaja.TabIndex = 287;
            this.chkIndicaBaja.Text = "Indica Baja";
            this.chkIndicaBaja.UseVisualStyleBackColor = true;
            this.chkIndicaBaja.CheckedChanged += new System.EventHandler(this.chkIndicaBaja_CheckedChanged);
            // 
            // indUltNodoLabel
            // 
            indUltNodoLabel.AutoSize = true;
            indUltNodoLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            indUltNodoLabel.Location = new System.Drawing.Point(17, 145);
            indUltNodoLabel.Name = "indUltNodoLabel";
            indUltNodoLabel.Size = new System.Drawing.Size(52, 13);
            indUltNodoLabel.TabIndex = 288;
            indUltNodoLabel.Text = "Ult. Nodo";
            // 
            // cboIndicaUltimo
            // 
            this.cboIndicaUltimo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIndicaUltimo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIndicaUltimo.FormattingEnabled = true;
            this.cboIndicaUltimo.Location = new System.Drawing.Point(96, 142);
            this.cboIndicaUltimo.Name = "cboIndicaUltimo";
            this.cboIndicaUltimo.Size = new System.Drawing.Size(45, 21);
            this.cboIndicaUltimo.TabIndex = 289;
            // 
            // numNivelLabel
            // 
            numNivelLabel.AutoSize = true;
            numNivelLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numNivelLabel.Location = new System.Drawing.Point(17, 167);
            numNivelLabel.Name = "numNivelLabel";
            numNivelLabel.Size = new System.Drawing.Size(30, 13);
            numNivelLabel.TabIndex = 290;
            numNivelLabel.Text = "Nivel";
            // 
            // nudNivel
            // 
            this.nudNivel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNivel.Location = new System.Drawing.Point(96, 166);
            this.nudNivel.Name = "nudNivel";
            this.nudNivel.Size = new System.Drawing.Size(45, 20);
            this.nudNivel.TabIndex = 291;
            // 
            // tipPartidaPresuLabel
            // 
            tipPartidaPresuLabel.AutoSize = true;
            tipPartidaPresuLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tipPartidaPresuLabel.Location = new System.Drawing.Point(17, 54);
            tipPartidaPresuLabel.Name = "tipPartidaPresuLabel";
            tipPartidaPresuLabel.Size = new System.Drawing.Size(64, 13);
            tipPartidaPresuLabel.TabIndex = 292;
            tipPartidaPresuLabel.Text = "Tipo Partida";
            // 
            // cboTipoPartida
            // 
            this.cboTipoPartida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPartida.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoPartida.FormattingEnabled = true;
            this.cboTipoPartida.Location = new System.Drawing.Point(96, 51);
            this.cboTipoPartida.Name = "cboTipoPartida";
            this.cboTipoPartida.Size = new System.Drawing.Size(200, 21);
            this.cboTipoPartida.TabIndex = 293;
            // 
            // tipTituloNodoLabel
            // 
            tipTituloNodoLabel.AutoSize = true;
            tipTituloNodoLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tipTituloNodoLabel.Location = new System.Drawing.Point(17, 191);
            tipTituloNodoLabel.Name = "tipTituloNodoLabel";
            tipTituloNodoLabel.Size = new System.Drawing.Size(61, 13);
            tipTituloNodoLabel.TabIndex = 294;
            tipTituloNodoLabel.Text = "Titulo Nodo";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Controls.Add(this.dtpFecBaja);
            this.panel1.Controls.Add(fechaBajaLabel);
            this.panel1.Controls.Add(this.chkIndicaBaja);
            this.panel1.Location = new System.Drawing.Point(325, 143);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 81);
            this.panel1.TabIndex = 275;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(265, 20);
            this.labelDegradado1.TabIndex = 274;
            this.labelDegradado1.Text = "Estado";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTitulo
            // 
            this.cboTitulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTitulo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTitulo.FormattingEnabled = true;
            this.cboTitulo.Location = new System.Drawing.Point(96, 188);
            this.cboTitulo.Name = "cboTitulo";
            this.cboTitulo.Size = new System.Drawing.Size(200, 21);
            this.cboTitulo.TabIndex = 295;
            // 
            // btBuscarCodigo
            // 
            this.btBuscarCodigo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscarCodigo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btBuscarCodigo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarCodigo.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btBuscarCodigo.Location = new System.Drawing.Point(197, 29);
            this.btBuscarCodigo.Name = "btBuscarCodigo";
            this.btBuscarCodigo.Size = new System.Drawing.Size(25, 19);
            this.btBuscarCodigo.TabIndex = 322;
            this.btBuscarCodigo.UseVisualStyleBackColor = true;
            this.btBuscarCodigo.Click += new System.EventHandler(this.btBuscarCodigo_Click);
            // 
            // frmPartidaPresupuestaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 229);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnlDatos);
            this.MaximizeBox = false;
            this.Name = "frmPartidaPresupuestaria";
            this.Text = "Partida Presupuestaria";
            this.Load += new System.EventHandler(this.frmPartidaPresupuestaria_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatos;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.ComboBox cboTitulo;
        private ControlesWinForm.SuperTextBox txtAbreviatura;
        private ControlesWinForm.SuperTextBox txtCodPartida;
        private ControlesWinForm.SuperTextBox txtCodSuperior;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cboIndicaUltimo;
        private System.Windows.Forms.NumericUpDown nudNivel;
        private System.Windows.Forms.ComboBox cboTipoPartida;
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
        private System.Windows.Forms.DateTimePicker dtpFecBaja;
        private System.Windows.Forms.CheckBox chkIndicaBaja;
        private System.Windows.Forms.Panel panel1;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btBuscarCodigo;
    }
}