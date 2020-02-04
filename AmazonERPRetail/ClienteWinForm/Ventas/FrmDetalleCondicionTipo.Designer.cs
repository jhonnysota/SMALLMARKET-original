namespace ClienteWinForm.Ventas
{
    partial class FrmDetalleCondicionTipo
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label idControlLabel;
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtFModificacion = new System.Windows.Forms.TextBox();
            this.txtURegistro = new System.Windows.Forms.TextBox();
            this.txtUModificacion = new System.Windows.Forms.TextBox();
            this.txtFRegistro = new System.Windows.Forms.TextBox();
            this.chkCredCob = new System.Windows.Forms.CheckBox();
            this.chkTFilial = new System.Windows.Forms.CheckBox();
            this.chkTGratuita = new System.Windows.Forms.CheckBox();
            this.chkSCobra = new System.Windows.Forms.CheckBox();
            this.chkCImpuesto = new System.Windows.Forms.CheckBox();
            this.chkncDescuento = new System.Windows.Forms.CheckBox();
            this.chkMUnidad = new System.Windows.Forms.CheckBox();
            this.chkCredito = new System.Windows.Forms.CheckBox();
            this.chkGLetra = new System.Windows.Forms.CheckBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDias = new System.Windows.Forms.DataGridView();
            this.diasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDias = new System.Windows.Forms.BindingSource(this.components);
            this.btDias = new System.Windows.Forms.Button();
            this.btQuitar = new System.Windows.Forms.Button();
            this.chkIndDias = new System.Windows.Forms.CheckBox();
            this.lblLetras = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            idControlLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDias)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(402, 19);
            this.lblTitPnlBase.Text = "Condicion";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(699, 25);
            this.lblTituloPrincipal.Text = "Detalle Condicion Tipo";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(670, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.dgvDias);
            this.pnlBase.Controls.Add(this.panel1);
            this.pnlBase.Controls.Add(descripcionLabel);
            this.pnlBase.Controls.Add(this.txtDescripcion);
            this.pnlBase.Controls.Add(idControlLabel);
            this.pnlBase.Controls.Add(this.txtCodigo);
            this.pnlBase.Location = new System.Drawing.Point(8, 28);
            this.pnlBase.Size = new System.Drawing.Size(404, 195);
            this.pnlBase.Controls.SetChildIndex(this.txtCodigo, 0);
            this.pnlBase.Controls.SetChildIndex(idControlLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.pnlBase.Controls.SetChildIndex(descripcionLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.panel1, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.dgvDias, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(351, 228);
            this.btCancelar.Size = new System.Drawing.Size(142, 25);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(205, 228);
            this.btAceptar.Size = new System.Drawing.Size(142, 25);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(16, 103);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(16, 80);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(16, 34);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(16, 57);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descripcionLabel.Location = new System.Drawing.Point(15, 51);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(61, 13);
            descripcionLabel.TabIndex = 278;
            descripcionLabel.Text = "Descripción";
            // 
            // idControlLabel
            // 
            idControlLabel.AutoSize = true;
            idControlLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idControlLabel.Location = new System.Drawing.Point(15, 29);
            idControlLabel.Name = "idControlLabel";
            idControlLabel.Size = new System.Drawing.Size(67, 13);
            idControlLabel.TabIndex = 279;
            idControlLabel.Text = "ID Condicion";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.lblLetras);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.txtFModificacion);
            this.pnlAuditoria.Controls.Add(this.txtURegistro);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtUModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFRegistro);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(415, 28);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(278, 135);
            this.pnlAuditoria.TabIndex = 256;
            // 
            // txtFModificacion
            // 
            this.txtFModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFModificacion.Enabled = false;
            this.txtFModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFModificacion.Location = new System.Drawing.Point(125, 99);
            this.txtFModificacion.Name = "txtFModificacion";
            this.txtFModificacion.Size = new System.Drawing.Size(134, 21);
            this.txtFModificacion.TabIndex = 304;
            // 
            // txtURegistro
            // 
            this.txtURegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtURegistro.Enabled = false;
            this.txtURegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURegistro.Location = new System.Drawing.Point(125, 30);
            this.txtURegistro.Name = "txtURegistro";
            this.txtURegistro.Size = new System.Drawing.Size(134, 21);
            this.txtURegistro.TabIndex = 300;
            // 
            // txtUModificacion
            // 
            this.txtUModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUModificacion.Enabled = false;
            this.txtUModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUModificacion.Location = new System.Drawing.Point(125, 76);
            this.txtUModificacion.Name = "txtUModificacion";
            this.txtUModificacion.Size = new System.Drawing.Size(134, 21);
            this.txtUModificacion.TabIndex = 303;
            // 
            // txtFRegistro
            // 
            this.txtFRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFRegistro.Enabled = false;
            this.txtFRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFRegistro.Location = new System.Drawing.Point(125, 53);
            this.txtFRegistro.Name = "txtFRegistro";
            this.txtFRegistro.Size = new System.Drawing.Size(134, 21);
            this.txtFRegistro.TabIndex = 301;
            // 
            // chkCredCob
            // 
            this.chkCredCob.AutoSize = true;
            this.chkCredCob.Location = new System.Drawing.Point(16, 91);
            this.chkCredCob.Name = "chkCredCob";
            this.chkCredCob.Size = new System.Drawing.Size(113, 17);
            this.chkCredCob.TabIndex = 289;
            this.chkCredCob.Text = "Crédito - Cobranza";
            this.chkCredCob.UseVisualStyleBackColor = true;
            // 
            // chkTFilial
            // 
            this.chkTFilial.AutoSize = true;
            this.chkTFilial.Location = new System.Drawing.Point(131, 69);
            this.chkTFilial.Name = "chkTFilial";
            this.chkTFilial.Size = new System.Drawing.Size(73, 17);
            this.chkTFilial.TabIndex = 288;
            this.chkTFilial.Text = "Tasa Filial";
            this.chkTFilial.UseVisualStyleBackColor = true;
            // 
            // chkTGratuita
            // 
            this.chkTGratuita.AutoSize = true;
            this.chkTGratuita.Location = new System.Drawing.Point(131, 3);
            this.chkTGratuita.Name = "chkTGratuita";
            this.chkTGratuita.Size = new System.Drawing.Size(90, 17);
            this.chkTGratuita.TabIndex = 287;
            this.chkTGratuita.Text = "Tasa Gratuita";
            this.chkTGratuita.UseVisualStyleBackColor = true;
            // 
            // chkSCobra
            // 
            this.chkSCobra.AutoSize = true;
            this.chkSCobra.Location = new System.Drawing.Point(16, 47);
            this.chkSCobra.Name = "chkSCobra";
            this.chkSCobra.Size = new System.Drawing.Size(70, 17);
            this.chkSCobra.TabIndex = 286;
            this.chkSCobra.Text = "Se Cobra";
            this.chkSCobra.UseVisualStyleBackColor = true;
            // 
            // chkCImpuesto
            // 
            this.chkCImpuesto.AutoSize = true;
            this.chkCImpuesto.Location = new System.Drawing.Point(131, 25);
            this.chkCImpuesto.Name = "chkCImpuesto";
            this.chkCImpuesto.Size = new System.Drawing.Size(91, 17);
            this.chkCImpuesto.TabIndex = 285;
            this.chkCImpuesto.Text = "Con Impuesto";
            this.chkCImpuesto.UseVisualStyleBackColor = true;
            // 
            // chkncDescuento
            // 
            this.chkncDescuento.AutoSize = true;
            this.chkncDescuento.Location = new System.Drawing.Point(131, 47);
            this.chkncDescuento.Name = "chkncDescuento";
            this.chkncDescuento.Size = new System.Drawing.Size(99, 17);
            this.chkncDescuento.TabIndex = 284;
            this.chkncDescuento.Text = "n.c. Descuento";
            this.chkncDescuento.UseVisualStyleBackColor = true;
            // 
            // chkMUnidad
            // 
            this.chkMUnidad.AutoSize = true;
            this.chkMUnidad.Location = new System.Drawing.Point(16, 69);
            this.chkMUnidad.Name = "chkMUnidad";
            this.chkMUnidad.Size = new System.Drawing.Size(98, 17);
            this.chkMUnidad.TabIndex = 283;
            this.chkMUnidad.Text = "Maneja Unidad";
            this.chkMUnidad.UseVisualStyleBackColor = true;
            // 
            // chkCredito
            // 
            this.chkCredito.AutoSize = true;
            this.chkCredito.Location = new System.Drawing.Point(16, 25);
            this.chkCredito.Name = "chkCredito";
            this.chkCredito.Size = new System.Drawing.Size(59, 17);
            this.chkCredito.TabIndex = 282;
            this.chkCredito.Text = "Credito";
            this.chkCredito.UseVisualStyleBackColor = true;
            // 
            // chkGLetra
            // 
            this.chkGLetra.AutoSize = true;
            this.chkGLetra.Location = new System.Drawing.Point(16, 3);
            this.chkGLetra.Name = "chkGLetra";
            this.chkGLetra.Size = new System.Drawing.Size(88, 17);
            this.chkGLetra.TabIndex = 281;
            this.chkGLetra.Text = "Genera Letra";
            this.chkGLetra.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(88, 47);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(184, 21);
            this.txtDescripcion.TabIndex = 277;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(88, 25);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(35, 21);
            this.txtCodigo.TabIndex = 280;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkTGratuita);
            this.panel1.Controls.Add(this.chkCredCob);
            this.panel1.Controls.Add(this.chkGLetra);
            this.panel1.Controls.Add(this.chkTFilial);
            this.panel1.Controls.Add(this.chkCredito);
            this.panel1.Controls.Add(this.chkMUnidad);
            this.panel1.Controls.Add(this.chkSCobra);
            this.panel1.Controls.Add(this.chkncDescuento);
            this.panel1.Controls.Add(this.chkCImpuesto);
            this.panel1.Location = new System.Drawing.Point(18, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 113);
            this.panel1.TabIndex = 290;
            // 
            // dgvDias
            // 
            this.dgvDias.AllowUserToAddRows = false;
            this.dgvDias.AllowUserToDeleteRows = false;
            this.dgvDias.AutoGenerateColumns = false;
            this.dgvDias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.diasDataGridViewTextBoxColumn});
            this.dgvDias.DataSource = this.bsDias;
            this.dgvDias.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvDias.EnableHeadersVisualStyles = false;
            this.dgvDias.Location = new System.Drawing.Point(287, 19);
            this.dgvDias.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDias.Name = "dgvDias";
            this.dgvDias.RowTemplate.Height = 24;
            this.dgvDias.Size = new System.Drawing.Size(115, 174);
            this.dgvDias.TabIndex = 252;
            this.dgvDias.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDias_CellValueChanged);
            this.dgvDias.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDias_DataError);
            // 
            // diasDataGridViewTextBoxColumn
            // 
            this.diasDataGridViewTextBoxColumn.DataPropertyName = "Dias";
            this.diasDataGridViewTextBoxColumn.HeaderText = "Dias";
            this.diasDataGridViewTextBoxColumn.Name = "diasDataGridViewTextBoxColumn";
            // 
            // bsDias
            // 
            this.bsDias.DataSource = typeof(Entidades.Ventas.CondicionDiasE);
            // 
            // btDias
            // 
            this.btDias.BackColor = System.Drawing.Color.Azure;
            this.btDias.Enabled = false;
            this.btDias.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btDias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btDias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btDias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDias.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btDias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDias.Location = new System.Drawing.Point(422, 195);
            this.btDias.Name = "btDias";
            this.btDias.Size = new System.Drawing.Size(109, 26);
            this.btDias.TabIndex = 1565;
            this.btDias.TabStop = false;
            this.btDias.Text = "Agregar Dias";
            this.btDias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDias.UseVisualStyleBackColor = false;
            this.btDias.Click += new System.EventHandler(this.btDias_Click);
            // 
            // btQuitar
            // 
            this.btQuitar.BackColor = System.Drawing.Color.Azure;
            this.btQuitar.Enabled = false;
            this.btQuitar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btQuitar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuitar.Image = global::ClienteWinForm.Properties.Resources.Row_Delete_16x16;
            this.btQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btQuitar.Location = new System.Drawing.Point(534, 195);
            this.btQuitar.Name = "btQuitar";
            this.btQuitar.Size = new System.Drawing.Size(109, 26);
            this.btQuitar.TabIndex = 1566;
            this.btQuitar.TabStop = false;
            this.btQuitar.Text = "Quitar Dias";
            this.btQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btQuitar.UseVisualStyleBackColor = false;
            this.btQuitar.Click += new System.EventHandler(this.btQuitar_Click);
            // 
            // chkIndDias
            // 
            this.chkIndDias.AutoSize = true;
            this.chkIndDias.BackColor = System.Drawing.Color.Azure;
            this.chkIndDias.Location = new System.Drawing.Point(423, 169);
            this.chkIndDias.Name = "chkIndDias";
            this.chkIndDias.Size = new System.Drawing.Size(82, 17);
            this.chkIndDias.TabIndex = 290;
            this.chkIndDias.Text = "Indicar Dias";
            this.chkIndDias.UseVisualStyleBackColor = false;
            this.chkIndDias.CheckedChanged += new System.EventHandler(this.chkIndDias_CheckedChanged);
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(276, 18);
            this.lblLetras.TabIndex = 1572;
            this.lblLetras.Text = "Auditoria";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmDetalleCondicionTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 261);
            this.Controls.Add(this.chkIndDias);
            this.Controls.Add(this.btQuitar);
            this.Controls.Add(this.btDias);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "FrmDetalleCondicionTipo";
            this.Text = "FrmDetalleCondicionTipo";
            this.Load += new System.EventHandler(this.FrmDetalleCondicionTipo_Load);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.btDias, 0);
            this.Controls.SetChildIndex(this.btQuitar, 0);
            this.Controls.SetChildIndex(this.chkIndDias, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFModificacion;
        private System.Windows.Forms.TextBox txtURegistro;
        private System.Windows.Forms.TextBox txtUModificacion;
        private System.Windows.Forms.TextBox txtFRegistro;
        private System.Windows.Forms.CheckBox chkCredCob;
        private System.Windows.Forms.CheckBox chkTFilial;
        private System.Windows.Forms.CheckBox chkTGratuita;
        private System.Windows.Forms.CheckBox chkSCobra;
        private System.Windows.Forms.CheckBox chkCImpuesto;
        private System.Windows.Forms.CheckBox chkncDescuento;
        private System.Windows.Forms.CheckBox chkMUnidad;
        private System.Windows.Forms.CheckBox chkCredito;
        private System.Windows.Forms.CheckBox chkGLetra;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDias;
        private System.Windows.Forms.Button btDias;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsDias;
        private System.Windows.Forms.Button btQuitar;
        private System.Windows.Forms.CheckBox chkIndDias;
        private System.Windows.Forms.Label lblLetras;
    }
}