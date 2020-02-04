namespace ClienteWinForm.Almacen.Reportes
{
    partial class FrmListadoKardexValorizadoPorLote
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
            this.PnlFechas = new System.Windows.Forms.Panel();
            this.lblregistros = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.PnlAlmacen = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoAlmacen = new System.Windows.Forms.ComboBox();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.btObtener = new System.Windows.Forms.Button();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.PnlArticulo = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomArt = new ControlesWinForm.SuperTextBox();
            this.txtArt = new ControlesWinForm.SuperTextBox();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbUno = new System.Windows.Forms.RadioButton();
            this.btExportar = new System.Windows.Forms.Button();
            this.cmsFormatos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmFormato1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFormato2 = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlLote = new System.Windows.Forms.Panel();
            this.chkLote = new System.Windows.Forms.CheckBox();
            this.txtLote = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkLoteAlmacen = new System.Windows.Forms.CheckBox();
            this.txtLoteAlmacen = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bskardexValorizado = new System.Windows.Forms.BindingSource(this.components);
            this.PnlNav = new System.Windows.Forms.Panel();
            this.PnlFechas.SuspendLayout();
            this.PnlAlmacen.SuspendLayout();
            this.PnlArticulo.SuspendLayout();
            this.cmsFormatos.SuspendLayout();
            this.PnlLote.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bskardexValorizado)).BeginInit();
            this.PnlNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlFechas
            // 
            this.PnlFechas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlFechas.Controls.Add(this.lblregistros);
            this.PnlFechas.Controls.Add(this.label1);
            this.PnlFechas.Controls.Add(this.dtpFinal);
            this.PnlFechas.Controls.Add(this.label2);
            this.PnlFechas.Controls.Add(this.dtpInicio);
            this.PnlFechas.Location = new System.Drawing.Point(3, 3);
            this.PnlFechas.Name = "PnlFechas";
            this.PnlFechas.Size = new System.Drawing.Size(245, 80);
            this.PnlFechas.TabIndex = 273;
            // 
            // lblregistros
            // 
            this.lblregistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblregistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblregistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregistros.Location = new System.Drawing.Point(0, 0);
            this.lblregistros.Name = "lblregistros";
            this.lblregistros.Size = new System.Drawing.Size(243, 18);
            this.lblregistros.TabIndex = 1576;
            this.lblregistros.Text = "Fechas";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 262;
            this.label1.Text = "De";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(142, 35);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(94, 21);
            this.dtpFinal.TabIndex = 260;
            this.dtpFinal.Value = new System.DateTime(2016, 12, 31, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 261;
            this.label2.Text = "a";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(31, 36);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(94, 21);
            this.dtpInicio.TabIndex = 259;
            this.dtpInicio.Value = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            // 
            // PnlAlmacen
            // 
            this.PnlAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlAlmacen.Controls.Add(this.label3);
            this.PnlAlmacen.Controls.Add(this.cboTipoAlmacen);
            this.PnlAlmacen.Controls.Add(this.cboAlmacen);
            this.PnlAlmacen.Location = new System.Drawing.Point(251, 3);
            this.PnlAlmacen.Name = "PnlAlmacen";
            this.PnlAlmacen.Size = new System.Drawing.Size(244, 80);
            this.PnlAlmacen.TabIndex = 275;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 18);
            this.label3.TabIndex = 1576;
            this.label3.Text = "Almacén";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTipoAlmacen
            // 
            this.cboTipoAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAlmacen.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoAlmacen.FormattingEnabled = true;
            this.cboTipoAlmacen.Location = new System.Drawing.Point(7, 26);
            this.cboTipoAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoAlmacen.Name = "cboTipoAlmacen";
            this.cboTipoAlmacen.Size = new System.Drawing.Size(227, 21);
            this.cboTipoAlmacen.TabIndex = 349;
            this.cboTipoAlmacen.SelectionChangeCommitted += new System.EventHandler(this.cboTipoAlmacen_SelectionChangeCommitted);
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(7, 50);
            this.cboAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(227, 21);
            this.cboAlmacen.TabIndex = 261;
            // 
            // btObtener
            // 
            this.btObtener.BackColor = System.Drawing.Color.Azure;
            this.btObtener.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btObtener.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btObtener.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btObtener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btObtener.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btObtener.Image = global::ClienteWinForm.Properties.Resources.Mostrar_Reporte;
            this.btObtener.Location = new System.Drawing.Point(1045, 21);
            this.btObtener.Margin = new System.Windows.Forms.Padding(2);
            this.btObtener.Name = "btObtener";
            this.btObtener.Size = new System.Drawing.Size(51, 48);
            this.btObtener.TabIndex = 288;
            this.btObtener.UseVisualStyleBackColor = false;
            this.btObtener.Click += new System.EventHandler(this.btObtener_Click);
            // 
            // wbNavegador
            // 
            this.wbNavegador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbNavegador.Location = new System.Drawing.Point(0, 0);
            this.wbNavegador.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNavegador.Name = "wbNavegador";
            this.wbNavegador.Size = new System.Drawing.Size(1166, 303);
            this.wbNavegador.TabIndex = 330;
            // 
            // PnlArticulo
            // 
            this.PnlArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlArticulo.Controls.Add(this.label4);
            this.PnlArticulo.Controls.Add(this.txtNomArt);
            this.PnlArticulo.Controls.Add(this.txtArt);
            this.PnlArticulo.Controls.Add(this.rbTodos);
            this.PnlArticulo.Controls.Add(this.rbUno);
            this.PnlArticulo.Location = new System.Drawing.Point(498, 3);
            this.PnlArticulo.Name = "PnlArticulo";
            this.PnlArticulo.Size = new System.Drawing.Size(365, 80);
            this.PnlArticulo.TabIndex = 276;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(363, 18);
            this.label4.TabIndex = 1576;
            this.label4.Text = "Artículo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNomArt
            // 
            this.txtNomArt.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtNomArt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtNomArt.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNomArt.Enabled = false;
            this.txtNomArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomArt.Location = new System.Drawing.Point(67, 47);
            this.txtNomArt.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomArt.Name = "txtNomArt";
            this.txtNomArt.Size = new System.Drawing.Size(289, 20);
            this.txtNomArt.TabIndex = 332;
            this.txtNomArt.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNomArt.TextoVacio = "Producto";
            this.txtNomArt.TextChanged += new System.EventHandler(this.txtNomArt_TextChanged);
            this.txtNomArt.Validating += new System.ComponentModel.CancelEventHandler(this.txtNomArt_Validating);
            // 
            // txtArt
            // 
            this.txtArt.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtArt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtArt.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtArt.Enabled = false;
            this.txtArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArt.Location = new System.Drawing.Point(4, 47);
            this.txtArt.Margin = new System.Windows.Forms.Padding(2);
            this.txtArt.Name = "txtArt";
            this.txtArt.Size = new System.Drawing.Size(61, 20);
            this.txtArt.TabIndex = 331;
            this.txtArt.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtArt.TextoVacio = "Código";
            this.txtArt.TextChanged += new System.EventHandler(this.txtArt_TextChanged);
            this.txtArt.Validating += new System.ComponentModel.CancelEventHandler(this.txtArt_Validating);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodos.Location = new System.Drawing.Point(8, 26);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(54, 17);
            this.rbTodos.TabIndex = 354;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // rbUno
            // 
            this.rbUno.AutoSize = true;
            this.rbUno.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUno.Location = new System.Drawing.Point(72, 26);
            this.rbUno.Name = "rbUno";
            this.rbUno.Size = new System.Drawing.Size(66, 17);
            this.rbUno.TabIndex = 353;
            this.rbUno.Text = "Solo uno";
            this.rbUno.UseVisualStyleBackColor = true;
            this.rbUno.CheckedChanged += new System.EventHandler(this.rbUno_CheckedChanged);
            // 
            // btExportar
            // 
            this.btExportar.BackColor = System.Drawing.Color.Azure;
            this.btExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExportar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExportar.Image = global::ClienteWinForm.Properties.Resources.Excel_Chico;
            this.btExportar.Location = new System.Drawing.Point(1100, 21);
            this.btExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btExportar.Name = "btExportar";
            this.btExportar.Size = new System.Drawing.Size(51, 48);
            this.btExportar.TabIndex = 335;
            this.btExportar.UseVisualStyleBackColor = false;
            this.btExportar.Click += new System.EventHandler(this.btExportar_Click);
            this.btExportar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btExportar_MouseUp);
            // 
            // cmsFormatos
            // 
            this.cmsFormatos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsFormatos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFormato1,
            this.tsmFormato2});
            this.cmsFormatos.Name = "cmsFormatos";
            this.cmsFormatos.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsFormatos.Size = new System.Drawing.Size(161, 48);
            // 
            // tsmFormato1
            // 
            this.tsmFormato1.Name = "tsmFormato1";
            this.tsmFormato1.Size = new System.Drawing.Size(160, 22);
            this.tsmFormato1.Text = "Formato Listado";
            this.tsmFormato1.Click += new System.EventHandler(this.tsmFormato1_Click);
            // 
            // tsmFormato2
            // 
            this.tsmFormato2.Name = "tsmFormato2";
            this.tsmFormato2.Size = new System.Drawing.Size(160, 22);
            this.tsmFormato2.Text = "Formato Kardex";
            this.tsmFormato2.Click += new System.EventHandler(this.tsmFormato2_Click);
            // 
            // PnlLote
            // 
            this.PnlLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlLote.Controls.Add(this.chkLote);
            this.PnlLote.Controls.Add(this.txtLote);
            this.PnlLote.Controls.Add(this.label5);
            this.PnlLote.Location = new System.Drawing.Point(866, 3);
            this.PnlLote.Name = "PnlLote";
            this.PnlLote.Size = new System.Drawing.Size(137, 80);
            this.PnlLote.TabIndex = 336;
            // 
            // chkLote
            // 
            this.chkLote.AutoSize = true;
            this.chkLote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.chkLote.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLote.ForeColor = System.Drawing.Color.Black;
            this.chkLote.Location = new System.Drawing.Point(0, 0);
            this.chkLote.Name = "chkLote";
            this.chkLote.Size = new System.Drawing.Size(77, 17);
            this.chkLote.TabIndex = 355;
            this.chkLote.Text = "Con Lote";
            this.chkLote.UseVisualStyleBackColor = false;
            this.chkLote.CheckedChanged += new System.EventHandler(this.chkLote_CheckedChanged);
            // 
            // txtLote
            // 
            this.txtLote.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtLote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtLote.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtLote.Enabled = false;
            this.txtLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLote.Location = new System.Drawing.Point(14, 38);
            this.txtLote.Margin = new System.Windows.Forms.Padding(2);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(106, 20);
            this.txtLote.TabIndex = 354;
            this.txtLote.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtLote.TextoVacio = "Lote";
            this.txtLote.TextChanged += new System.EventHandler(this.txtLote_TextChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 18);
            this.label5.TabIndex = 1576;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.chkLoteAlmacen);
            this.panel5.Controls.Add(this.txtLoteAlmacen);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(1006, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(31, 80);
            this.panel5.TabIndex = 337;
            this.panel5.Visible = false;
            // 
            // chkLoteAlmacen
            // 
            this.chkLoteAlmacen.AutoSize = true;
            this.chkLoteAlmacen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.chkLoteAlmacen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLoteAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLoteAlmacen.ForeColor = System.Drawing.Color.Black;
            this.chkLoteAlmacen.Location = new System.Drawing.Point(1, 0);
            this.chkLoteAlmacen.Name = "chkLoteAlmacen";
            this.chkLoteAlmacen.Size = new System.Drawing.Size(129, 17);
            this.chkLoteAlmacen.TabIndex = 355;
            this.chkLoteAlmacen.Text = "Con Lote Almacen";
            this.chkLoteAlmacen.UseVisualStyleBackColor = false;
            this.chkLoteAlmacen.CheckedChanged += new System.EventHandler(this.chkLoteAlmacen_CheckedChanged);
            // 
            // txtLoteAlmacen
            // 
            this.txtLoteAlmacen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtLoteAlmacen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtLoteAlmacen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtLoteAlmacen.Enabled = false;
            this.txtLoteAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoteAlmacen.Location = new System.Drawing.Point(23, 37);
            this.txtLoteAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoteAlmacen.Name = "txtLoteAlmacen";
            this.txtLoteAlmacen.Size = new System.Drawing.Size(106, 20);
            this.txtLoteAlmacen.TabIndex = 354;
            this.txtLoteAlmacen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtLoteAlmacen.TextoVacio = "Lote Almacen";
            this.txtLoteAlmacen.TextChanged += new System.EventHandler(this.txtLoteAlmacen_TextChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 18);
            this.label6.TabIndex = 1576;
            this.label6.Text = "Fechas";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bskardexValorizado
            // 
            this.bskardexValorizado.DataSource = typeof(Entidades.Almacen.KardexValorizadoE);
            // 
            // PnlNav
            // 
            this.PnlNav.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlNav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlNav.Controls.Add(this.wbNavegador);
            this.PnlNav.Location = new System.Drawing.Point(3, 85);
            this.PnlNav.Name = "PnlNav";
            this.PnlNav.Size = new System.Drawing.Size(1168, 305);
            this.PnlNav.TabIndex = 338;
            // 
            // FrmListadoKardexValorizadoPorLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 393);
            this.Controls.Add(this.PnlNav);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.PnlLote);
            this.Controls.Add(this.btExportar);
            this.Controls.Add(this.PnlArticulo);
            this.Controls.Add(this.btObtener);
            this.Controls.Add(this.PnlAlmacen);
            this.Controls.Add(this.PnlFechas);
            this.Name = "FrmListadoKardexValorizadoPorLote";
            this.Text = "Kárdex Valorizado por Lote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmListadoKardexValorizado_FormClosing);
            this.Load += new System.EventHandler(this.FrmListadoKardexValorizado_Load);
            this.PnlFechas.ResumeLayout(false);
            this.PnlFechas.PerformLayout();
            this.PnlAlmacen.ResumeLayout(false);
            this.PnlArticulo.ResumeLayout(false);
            this.PnlArticulo.PerformLayout();
            this.cmsFormatos.ResumeLayout(false);
            this.PnlLote.ResumeLayout(false);
            this.PnlLote.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bskardexValorizado)).EndInit();
            this.PnlNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlFechas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Panel PnlAlmacen;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private System.Windows.Forms.BindingSource bskardexValorizado;
        private System.Windows.Forms.Button btObtener;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.Panel PnlArticulo;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbUno;
        private ControlesWinForm.SuperTextBox txtArt;
        private ControlesWinForm.SuperTextBox txtNomArt;
        private System.Windows.Forms.Button btExportar;
        private System.Windows.Forms.ContextMenuStrip cmsFormatos;
        private System.Windows.Forms.ToolStripMenuItem tsmFormato1;
        private System.Windows.Forms.ToolStripMenuItem tsmFormato2;
        private System.Windows.Forms.Panel PnlLote;
        private ControlesWinForm.SuperTextBox txtLote;
        private System.Windows.Forms.CheckBox chkLote;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chkLoteAlmacen;
        private ControlesWinForm.SuperTextBox txtLoteAlmacen;
        private System.Windows.Forms.ComboBox cboTipoAlmacen;
        private System.Windows.Forms.Label lblregistros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel PnlNav;
    }
}