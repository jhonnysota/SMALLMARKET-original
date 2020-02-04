namespace ClienteWinForm.Tesoreria
{
    partial class frmListadoMovFinanciamiento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvMovimiento = new System.Windows.Forms.DataGridView();
            this.bsMovimientos = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.cboBancosEmpresa = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.cboLineaCredito = new System.Windows.Forms.ComboBox();
            this.idMovimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codMovimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecEmisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecVencimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impSolicitadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimientos)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvMovimiento);
            this.pnlDetalle.Controls.Add(this.lblRegistros);
            this.pnlDetalle.Location = new System.Drawing.Point(4, 63);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(873, 289);
            this.pnlDetalle.TabIndex = 363;
            // 
            // dgvMovimiento
            // 
            this.dgvMovimiento.AllowUserToAddRows = false;
            this.dgvMovimiento.AllowUserToDeleteRows = false;
            this.dgvMovimiento.AutoGenerateColumns = false;
            this.dgvMovimiento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvMovimiento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMovimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMovimientoDataGridViewTextBoxColumn,
            this.codMovimientoDataGridViewTextBoxColumn,
            this.desLinea,
            this.nroDocumentoDataGridViewTextBoxColumn,
            this.desBanco,
            this.fecEmisionDataGridViewTextBoxColumn,
            this.fecVencimientoDataGridViewTextBoxColumn,
            this.nroCuentaDataGridViewTextBoxColumn,
            this.desMoneda,
            this.impSolicitadoDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvMovimiento.DataSource = this.bsMovimientos;
            this.dgvMovimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimiento.EnableHeadersVisualStyles = false;
            this.dgvMovimiento.Location = new System.Drawing.Point(0, 18);
            this.dgvMovimiento.Name = "dgvMovimiento";
            this.dgvMovimiento.ReadOnly = true;
            this.dgvMovimiento.Size = new System.Drawing.Size(871, 269);
            this.dgvMovimiento.TabIndex = 248;
            this.dgvMovimiento.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimiento_CellDoubleClick);
            // 
            // bsMovimientos
            // 
            this.bsMovimientos.DataSource = typeof(Entidades.Tesoreria.MovimientoFinanciamientoE);
            this.bsMovimientos.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsMovimientos_ListChanged);
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
            this.lblRegistros.Size = new System.Drawing.Size(871, 18);
            this.lblRegistros.TabIndex = 258;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.dtpFecFin);
            this.panel2.Controls.Add(this.dtpFecIni);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.cboBancosEmpresa);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.labelDegradado1);
            this.panel2.Controls.Add(this.cboLineaCredito);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 56);
            this.panel2.TabIndex = 370;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 371;
            this.label1.Text = "Del";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(126, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 13);
            this.label25.TabIndex = 370;
            this.label25.Text = "Al";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(143, 27);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(87, 20);
            this.dtpFecFin.TabIndex = 369;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(36, 27);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(87, 20);
            this.dtpFecIni.TabIndex = 368;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(247, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 367;
            this.label13.Text = "Bancos";
            // 
            // cboBancosEmpresa
            // 
            this.cboBancosEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBancosEmpresa.DropDownWidth = 150;
            this.cboBancosEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBancosEmpresa.FormattingEnabled = true;
            this.cboBancosEmpresa.Location = new System.Drawing.Point(292, 27);
            this.cboBancosEmpresa.Name = "cboBancosEmpresa";
            this.cboBancosEmpresa.Size = new System.Drawing.Size(177, 21);
            this.cboBancosEmpresa.TabIndex = 366;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(483, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 13);
            this.label16.TabIndex = 363;
            this.label16.Text = "Tipo Linea de Crédito";
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
            this.labelDegradado1.Size = new System.Drawing.Size(790, 18);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Opciones de Busqueda";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLineaCredito
            // 
            this.cboLineaCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLineaCredito.DropDownWidth = 132;
            this.cboLineaCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLineaCredito.FormattingEnabled = true;
            this.cboLineaCredito.Location = new System.Drawing.Point(595, 27);
            this.cboLineaCredito.Name = "cboLineaCredito";
            this.cboLineaCredito.Size = new System.Drawing.Size(177, 21);
            this.cboLineaCredito.TabIndex = 360;
            // 
            // idMovimientoDataGridViewTextBoxColumn
            // 
            this.idMovimientoDataGridViewTextBoxColumn.DataPropertyName = "idMovimiento";
            this.idMovimientoDataGridViewTextBoxColumn.HeaderText = "Id.";
            this.idMovimientoDataGridViewTextBoxColumn.Name = "idMovimientoDataGridViewTextBoxColumn";
            this.idMovimientoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idMovimientoDataGridViewTextBoxColumn.Visible = false;
            this.idMovimientoDataGridViewTextBoxColumn.Width = 40;
            // 
            // codMovimientoDataGridViewTextBoxColumn
            // 
            this.codMovimientoDataGridViewTextBoxColumn.DataPropertyName = "codMovimiento";
            this.codMovimientoDataGridViewTextBoxColumn.HeaderText = "Cód.";
            this.codMovimientoDataGridViewTextBoxColumn.Name = "codMovimientoDataGridViewTextBoxColumn";
            this.codMovimientoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codMovimientoDataGridViewTextBoxColumn.Width = 70;
            // 
            // desLinea
            // 
            this.desLinea.DataPropertyName = "desLinea";
            this.desLinea.HeaderText = "Tip.Linea";
            this.desLinea.Name = "desLinea";
            this.desLinea.ReadOnly = true;
            this.desLinea.Width = 70;
            // 
            // nroDocumentoDataGridViewTextBoxColumn
            // 
            this.nroDocumentoDataGridViewTextBoxColumn.DataPropertyName = "nroDocumento";
            this.nroDocumentoDataGridViewTextBoxColumn.HeaderText = "Nro.Doc.";
            this.nroDocumentoDataGridViewTextBoxColumn.Name = "nroDocumentoDataGridViewTextBoxColumn";
            this.nroDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desBanco
            // 
            this.desBanco.DataPropertyName = "desBanco";
            this.desBanco.HeaderText = "Banco";
            this.desBanco.Name = "desBanco";
            this.desBanco.ReadOnly = true;
            this.desBanco.Width = 80;
            // 
            // fecEmisionDataGridViewTextBoxColumn
            // 
            this.fecEmisionDataGridViewTextBoxColumn.DataPropertyName = "fecEmision";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            this.fecEmisionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fecEmisionDataGridViewTextBoxColumn.HeaderText = "Fec.Emis.";
            this.fecEmisionDataGridViewTextBoxColumn.Name = "fecEmisionDataGridViewTextBoxColumn";
            this.fecEmisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fecEmisionDataGridViewTextBoxColumn.Width = 75;
            // 
            // fecVencimientoDataGridViewTextBoxColumn
            // 
            this.fecVencimientoDataGridViewTextBoxColumn.DataPropertyName = "fecVencimiento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            this.fecVencimientoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fecVencimientoDataGridViewTextBoxColumn.HeaderText = "Fec.Venc.";
            this.fecVencimientoDataGridViewTextBoxColumn.Name = "fecVencimientoDataGridViewTextBoxColumn";
            this.fecVencimientoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fecVencimientoDataGridViewTextBoxColumn.Width = 75;
            // 
            // nroCuentaDataGridViewTextBoxColumn
            // 
            this.nroCuentaDataGridViewTextBoxColumn.DataPropertyName = "nroCuenta";
            this.nroCuentaDataGridViewTextBoxColumn.HeaderText = "Nro. Cuenta";
            this.nroCuentaDataGridViewTextBoxColumn.Name = "nroCuentaDataGridViewTextBoxColumn";
            this.nroCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            this.desMoneda.HeaderText = "Mon.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 40;
            // 
            // impSolicitadoDataGridViewTextBoxColumn
            // 
            this.impSolicitadoDataGridViewTextBoxColumn.DataPropertyName = "impSolicitado";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.impSolicitadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.impSolicitadoDataGridViewTextBoxColumn.HeaderText = "Importe Sol.";
            this.impSolicitadoDataGridViewTextBoxColumn.Name = "impSolicitadoDataGridViewTextBoxColumn";
            this.impSolicitadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.impSolicitadoDataGridViewTextBoxColumn.Width = 90;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 130;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // frmListadoMovFinanciamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 356);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlDetalle);
            this.MaximizeBox = false;
            this.Name = "frmListadoMovFinanciamiento";
            this.Text = "Listado Movimientos de Financiamiento";
            this.Load += new System.EventHandler(this.frmListadoMovFinanciamiento_Load);
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimientos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.DataGridView dgvMovimiento;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsMovimientos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboBancosEmpresa;
        private System.Windows.Forms.Label label16;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.ComboBox cboLineaCredito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMovimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codMovimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecEmisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecVencimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn impSolicitadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}