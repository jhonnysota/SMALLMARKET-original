namespace ClienteWinForm.Tesoreria
{
    partial class frmListadoFinanciamiento
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkIncluir = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboBancosEmpresa = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.cboLineaCredito = new System.Windows.Forms.ComboBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvFinanciamiento = new System.Windows.Forms.DataGridView();
            this.bsFinanciamiento = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.idFinanciamientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desBancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMonedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indEstado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fecBajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinanciamiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFinanciamiento)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkIncluir);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.cboBancosEmpresa);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.labelDegradado1);
            this.panel2.Controls.Add(this.cboLineaCredito);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(701, 56);
            this.panel2.TabIndex = 369;
            // 
            // chkIncluir
            // 
            this.chkIncluir.AutoSize = true;
            this.chkIncluir.Location = new System.Drawing.Point(562, 29);
            this.chkIncluir.Name = "chkIncluir";
            this.chkIncluir.Size = new System.Drawing.Size(101, 17);
            this.chkIncluir.TabIndex = 259;
            this.chkIncluir.Text = "Incluir Anulados";
            this.chkIncluir.UseVisualStyleBackColor = true;
            this.chkIncluir.CheckedChanged += new System.EventHandler(this.chkIncluir_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(25, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 367;
            this.label13.Text = "Bancos";
            // 
            // cboBancosEmpresa
            // 
            this.cboBancosEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBancosEmpresa.DropDownWidth = 150;
            this.cboBancosEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBancosEmpresa.FormattingEnabled = true;
            this.cboBancosEmpresa.Items.AddRange(new object[] {
            "Pendiente",
            "Cancelados"});
            this.cboBancosEmpresa.Location = new System.Drawing.Point(70, 27);
            this.cboBancosEmpresa.Name = "cboBancosEmpresa";
            this.cboBancosEmpresa.Size = new System.Drawing.Size(177, 21);
            this.cboBancosEmpresa.TabIndex = 366;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(255, 31);
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
            this.labelDegradado1.Size = new System.Drawing.Size(699, 18);
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
            this.cboLineaCredito.Items.AddRange(new object[] {
            "Pendiente",
            "Cancelados"});
            this.cboLineaCredito.Location = new System.Drawing.Point(367, 27);
            this.cboLineaCredito.Name = "cboLineaCredito";
            this.cboLineaCredito.Size = new System.Drawing.Size(177, 21);
            this.cboLineaCredito.TabIndex = 360;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvFinanciamiento);
            this.pnlDetalle.Controls.Add(this.lblRegistros);
            this.pnlDetalle.Location = new System.Drawing.Point(4, 63);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(927, 279);
            this.pnlDetalle.TabIndex = 361;
            // 
            // dgvFinanciamiento
            // 
            this.dgvFinanciamiento.AllowUserToAddRows = false;
            this.dgvFinanciamiento.AllowUserToDeleteRows = false;
            this.dgvFinanciamiento.AutoGenerateColumns = false;
            this.dgvFinanciamiento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvFinanciamiento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFinanciamiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinanciamiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFinanciamientoDataGridViewTextBoxColumn,
            this.desBancoDataGridViewTextBoxColumn,
            this.desMonedaDataGridViewTextBoxColumn,
            this.desLinea,
            this.fechaDataGridViewTextBoxColumn,
            this.importeDataGridViewTextBoxColumn,
            this.indEstado,
            this.fecBajaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvFinanciamiento.DataSource = this.bsFinanciamiento;
            this.dgvFinanciamiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFinanciamiento.EnableHeadersVisualStyles = false;
            this.dgvFinanciamiento.Location = new System.Drawing.Point(0, 18);
            this.dgvFinanciamiento.Name = "dgvFinanciamiento";
            this.dgvFinanciamiento.ReadOnly = true;
            this.dgvFinanciamiento.Size = new System.Drawing.Size(925, 259);
            this.dgvFinanciamiento.TabIndex = 248;
            this.dgvFinanciamiento.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFinanciamiento_CellDoubleClick);
            this.dgvFinanciamiento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFinanciamiento_CellFormatting);
            // 
            // bsFinanciamiento
            // 
            this.bsFinanciamiento.DataSource = typeof(Entidades.Tesoreria.FinanciamientoE);
            this.bsFinanciamiento.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsFinanciamiento_ListChanged);
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
            this.lblRegistros.Size = new System.Drawing.Size(925, 18);
            this.lblRegistros.TabIndex = 258;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // idFinanciamientoDataGridViewTextBoxColumn
            // 
            this.idFinanciamientoDataGridViewTextBoxColumn.DataPropertyName = "idFinanciamiento";
            this.idFinanciamientoDataGridViewTextBoxColumn.HeaderText = "Id.";
            this.idFinanciamientoDataGridViewTextBoxColumn.Name = "idFinanciamientoDataGridViewTextBoxColumn";
            this.idFinanciamientoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idFinanciamientoDataGridViewTextBoxColumn.Width = 40;
            // 
            // desBancoDataGridViewTextBoxColumn
            // 
            this.desBancoDataGridViewTextBoxColumn.DataPropertyName = "desBanco";
            this.desBancoDataGridViewTextBoxColumn.HeaderText = "Banco";
            this.desBancoDataGridViewTextBoxColumn.Name = "desBancoDataGridViewTextBoxColumn";
            this.desBancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.desBancoDataGridViewTextBoxColumn.Width = 200;
            // 
            // desMonedaDataGridViewTextBoxColumn
            // 
            this.desMonedaDataGridViewTextBoxColumn.DataPropertyName = "desMoneda";
            this.desMonedaDataGridViewTextBoxColumn.HeaderText = "Mon.";
            this.desMonedaDataGridViewTextBoxColumn.Name = "desMonedaDataGridViewTextBoxColumn";
            this.desMonedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.desMonedaDataGridViewTextBoxColumn.Width = 50;
            // 
            // desLinea
            // 
            this.desLinea.DataPropertyName = "desLinea";
            this.desLinea.HeaderText = "Tip.Linea Créd.";
            this.desLinea.Name = "desLinea";
            this.desLinea.ReadOnly = true;
            this.desLinea.Width = 200;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 80;
            // 
            // importeDataGridViewTextBoxColumn
            // 
            this.importeDataGridViewTextBoxColumn.DataPropertyName = "Importe";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.importeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.importeDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.importeDataGridViewTextBoxColumn.Name = "importeDataGridViewTextBoxColumn";
            this.importeDataGridViewTextBoxColumn.ReadOnly = true;
            this.importeDataGridViewTextBoxColumn.Width = 90;
            // 
            // indEstado
            // 
            this.indEstado.DataPropertyName = "indEstado";
            this.indEstado.HeaderText = "I.B.";
            this.indEstado.Name = "indEstado";
            this.indEstado.ReadOnly = true;
            this.indEstado.Visible = false;
            this.indEstado.Width = 30;
            // 
            // fecBajaDataGridViewTextBoxColumn
            // 
            this.fecBajaDataGridViewTextBoxColumn.DataPropertyName = "fecBaja";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecBajaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fecBajaDataGridViewTextBoxColumn.HeaderText = "Fec. Baja";
            this.fecBajaDataGridViewTextBoxColumn.Name = "fecBajaDataGridViewTextBoxColumn";
            this.fecBajaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fecBajaDataGridViewTextBoxColumn.Visible = false;
            this.fecBajaDataGridViewTextBoxColumn.Width = 130;
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
            // frmListadoFinanciamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 345);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlDetalle);
            this.MaximizeBox = false;
            this.Name = "frmListadoFinanciamiento";
            this.Text = "Listado de Financiamientos";
            this.Load += new System.EventHandler(this.frmListadoFinanciamiento_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinanciamiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFinanciamiento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.CheckBox chkIncluir;
        private System.Windows.Forms.DataGridView dgvFinanciamiento;
        private System.Windows.Forms.BindingSource bsFinanciamiento;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboBancosEmpresa;
        private System.Windows.Forms.Label label16;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.ComboBox cboLineaCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFinanciamientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desBancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMonedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecBajaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}