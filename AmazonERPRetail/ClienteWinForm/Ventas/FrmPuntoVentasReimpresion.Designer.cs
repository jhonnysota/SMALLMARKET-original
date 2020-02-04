namespace ClienteWinForm.Ventas
{
    partial class FrmPuntoVentasReimpresion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.LblPedido = new System.Windows.Forms.Label();
            this.DtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.DgvDetalle = new System.Windows.Forms.DataGridView();
            this.nroDocAsociado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecEmisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numRucDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BsDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.BtBuscar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtGuardar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsDetalle)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(799, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "BUSQUEDA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TxtRazonSocial);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.DtpFecFin);
            this.panel1.Controls.Add(this.LblPedido);
            this.panel1.Controls.Add(this.DtpFecIni);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 59);
            this.panel1.TabIndex = 2089;
            // 
            // TxtRazonSocial
            // 
            this.TxtRazonSocial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.TxtRazonSocial.BackColor = System.Drawing.Color.White;
            this.TxtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRazonSocial.Location = new System.Drawing.Point(393, 29);
            this.TxtRazonSocial.Name = "TxtRazonSocial";
            this.TxtRazonSocial.Size = new System.Drawing.Size(391, 20);
            this.TxtRazonSocial.TabIndex = 0;
            this.TxtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.TxtRazonSocial.TextoVacio = "INGRESE LA RAZON SOCIAL";
            this.TxtRazonSocial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRazonSocial_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(211, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 1639;
            this.label3.Text = "Fecha Fin";
            // 
            // DtpFecFin
            // 
            this.DtpFecFin.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecFin.CustomFormat = "dd/MM/yyyy";
            this.DtpFecFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFecFin.Location = new System.Drawing.Point(278, 29);
            this.DtpFecFin.Name = "DtpFecFin";
            this.DtpFecFin.Size = new System.Drawing.Size(109, 20);
            this.DtpFecFin.TabIndex = 21;
            this.DtpFecFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DtpFecFin_KeyPress);
            // 
            // LblPedido
            // 
            this.LblPedido.AutoSize = true;
            this.LblPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPedido.Location = new System.Drawing.Point(16, 32);
            this.LblPedido.Name = "LblPedido";
            this.LblPedido.Size = new System.Drawing.Size(65, 13);
            this.LblPedido.TabIndex = 1637;
            this.LblPedido.Text = "Fecha Inicio";
            // 
            // DtpFecIni
            // 
            this.DtpFecIni.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecIni.CustomFormat = "dd/MM/yyyy";
            this.DtpFecIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFecIni.Location = new System.Drawing.Point(96, 29);
            this.DtpFecIni.Name = "DtpFecIni";
            this.DtpFecIni.Size = new System.Drawing.Size(109, 20);
            this.DtpFecIni.TabIndex = 20;
            this.DtpFecIni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DtpFecIni_KeyPress);
            // 
            // DgvDetalle
            // 
            this.DgvDetalle.AllowUserToAddRows = false;
            this.DgvDetalle.AllowUserToDeleteRows = false;
            this.DgvDetalle.AutoGenerateColumns = false;
            this.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nroDocAsociado,
            this.CodPedido,
            this.fecEmisionDataGridViewTextBoxColumn,
            this.idDocumentoDataGridViewTextBoxColumn,
            this.numSerieDataGridViewTextBoxColumn,
            this.numDocumentoDataGridViewTextBoxColumn,
            this.totTotal,
            this.RazonSocial,
            this.numRucDataGridViewTextBoxColumn});
            this.DgvDetalle.DataSource = this.BsDetalle;
            this.DgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDetalle.EnableHeadersVisualStyles = false;
            this.DgvDetalle.Location = new System.Drawing.Point(0, 21);
            this.DgvDetalle.Name = "DgvDetalle";
            this.DgvDetalle.ReadOnly = true;
            this.DgvDetalle.Size = new System.Drawing.Size(993, 302);
            this.DgvDetalle.TabIndex = 100;
            this.DgvDetalle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalle_CellDoubleClick);
            this.DgvDetalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvDetalle_KeyDown);
            // 
            // nroDocAsociado
            // 
            this.nroDocAsociado.DataPropertyName = "nroDocAsociado";
            this.nroDocAsociado.HeaderText = "ID";
            this.nroDocAsociado.Name = "nroDocAsociado";
            this.nroDocAsociado.ReadOnly = true;
            this.nroDocAsociado.Visible = false;
            this.nroDocAsociado.Width = 30;
            // 
            // CodPedido
            // 
            this.CodPedido.DataPropertyName = "CodPedido";
            this.CodPedido.HeaderText = "Pedido";
            this.CodPedido.Name = "CodPedido";
            this.CodPedido.ReadOnly = true;
            this.CodPedido.Width = 110;
            // 
            // fecEmisionDataGridViewTextBoxColumn
            // 
            this.fecEmisionDataGridViewTextBoxColumn.DataPropertyName = "fecEmision";
            this.fecEmisionDataGridViewTextBoxColumn.HeaderText = "Fec.Emisión";
            this.fecEmisionDataGridViewTextBoxColumn.Name = "fecEmisionDataGridViewTextBoxColumn";
            this.fecEmisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fecEmisionDataGridViewTextBoxColumn.Width = 80;
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "T.D.";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDocumentoDataGridViewTextBoxColumn.Width = 30;
            // 
            // numSerieDataGridViewTextBoxColumn
            // 
            this.numSerieDataGridViewTextBoxColumn.DataPropertyName = "numSerie";
            this.numSerieDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.numSerieDataGridViewTextBoxColumn.Name = "numSerieDataGridViewTextBoxColumn";
            this.numSerieDataGridViewTextBoxColumn.ReadOnly = true;
            this.numSerieDataGridViewTextBoxColumn.Width = 50;
            // 
            // numDocumentoDataGridViewTextBoxColumn
            // 
            this.numDocumentoDataGridViewTextBoxColumn.DataPropertyName = "numDocumento";
            this.numDocumentoDataGridViewTextBoxColumn.HeaderText = "Número";
            this.numDocumentoDataGridViewTextBoxColumn.Name = "numDocumentoDataGridViewTextBoxColumn";
            this.numDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.numDocumentoDataGridViewTextBoxColumn.Width = 70;
            // 
            // totTotal
            // 
            this.totTotal.DataPropertyName = "totTotal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.totTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.totTotal.HeaderText = "Total";
            this.totTotal.Name = "totTotal";
            this.totTotal.ReadOnly = true;
            this.totTotal.Width = 50;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Razón Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 300;
            // 
            // numRucDataGridViewTextBoxColumn
            // 
            this.numRucDataGridViewTextBoxColumn.DataPropertyName = "numRuc";
            this.numRucDataGridViewTextBoxColumn.HeaderText = "Ruc";
            this.numRucDataGridViewTextBoxColumn.Name = "numRucDataGridViewTextBoxColumn";
            this.numRucDataGridViewTextBoxColumn.ReadOnly = true;
            this.numRucDataGridViewTextBoxColumn.Width = 110;
            // 
            // BsDetalle
            // 
            this.BsDetalle.DataSource = typeof(Entidades.Ventas.EmisionDocumentoE);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(993, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "DOCUMENTO DE VENTAS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtBuscar
            // 
            this.BtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtBuscar.Image = global::ClienteWinForm.Properties.Resources.buscar_16x16neg;
            this.BtBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtBuscar.Location = new System.Drawing.Point(812, 4);
            this.BtBuscar.Name = "BtBuscar";
            this.BtBuscar.Size = new System.Drawing.Size(91, 58);
            this.BtBuscar.TabIndex = 2092;
            this.BtBuscar.TabStop = false;
            this.BtBuscar.Text = "Buscar";
            this.BtBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtBuscar.UseVisualStyleBackColor = true;
            this.BtBuscar.Click += new System.EventHandler(this.BtBuscar_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.DgvDetalle);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(5, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(995, 325);
            this.panel2.TabIndex = 2090;
            // 
            // BtGuardar
            // 
            this.BtGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtGuardar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtGuardar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.BtGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtGuardar.Location = new System.Drawing.Point(909, 4);
            this.BtGuardar.Name = "BtGuardar";
            this.BtGuardar.Size = new System.Drawing.Size(91, 58);
            this.BtGuardar.TabIndex = 2091;
            this.BtGuardar.TabStop = false;
            this.BtGuardar.Text = "Aceptar";
            this.BtGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtGuardar.UseVisualStyleBackColor = true;
            this.BtGuardar.Click += new System.EventHandler(this.BtGuardar_Click);
            // 
            // FrmPuntoVentasReimpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1004, 395);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtBuscar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BtGuardar);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmPuntoVentasReimpresion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documentos de Ventas para Impresión";
            this.Load += new System.EventHandler(this.FrmPuntoVentasReimpresion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPuntoVentasReimpresion_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsDetalle)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvDetalle;
        private System.Windows.Forms.BindingSource BsDetalle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtBuscar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtGuardar;
        private System.Windows.Forms.DateTimePicker DtpFecIni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpFecFin;
        private System.Windows.Forms.Label LblPedido;
        private ControlesWinForm.SuperTextBox TxtRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroDocAsociado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecEmisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn numRucDataGridViewTextBoxColumn;
    }
}