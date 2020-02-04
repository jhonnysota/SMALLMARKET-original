namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteConceptoGastoDetalle
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPivot = new System.Windows.Forms.DataGridView();
            this.bsVoucherItem = new System.Windows.Forms.BindingSource(this.components);
            this.lblregistros = new MyLabelG.LabelDegradado();
            this.idComprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVoucherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desGlosaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPivot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVoucherItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvPivot);
            this.panel2.Controls.Add(this.lblregistros);
            this.panel2.Location = new System.Drawing.Point(1, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 433);
            this.panel2.TabIndex = 298;
            // 
            // dgvPivot
            // 
            this.dgvPivot.AllowUserToAddRows = false;
            this.dgvPivot.AllowUserToDeleteRows = false;
            this.dgvPivot.AutoGenerateColumns = false;
            this.dgvPivot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPivot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idComprobanteDataGridViewTextBoxColumn,
            this.numFileDataGridViewTextBoxColumn,
            this.numVoucherDataGridViewTextBoxColumn,
            this.numItemDataGridViewTextBoxColumn,
            this.codCuentaDataGridViewTextBoxColumn,
            this.fecDocumentoDataGridViewTextBoxColumn,
            this.idDocumentoDataGridViewTextBoxColumn,
            this.serDocumentoDataGridViewTextBoxColumn,
            this.numDocumento,
            this.impDebe,
            this.impHaber,
            this.desGlosaDataGridViewTextBoxColumn});
            this.dgvPivot.DataSource = this.bsVoucherItem;
            this.dgvPivot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPivot.EnableHeadersVisualStyles = false;
            this.dgvPivot.Location = new System.Drawing.Point(0, 23);
            this.dgvPivot.Name = "dgvPivot";
            this.dgvPivot.ReadOnly = true;
            this.dgvPivot.Size = new System.Drawing.Size(1026, 408);
            this.dgvPivot.TabIndex = 248;
            this.dgvPivot.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPivot_CellFormatting);
            // 
            // bsVoucherItem
            // 
            this.bsVoucherItem.DataSource = typeof(Entidades.Contabilidad.VoucherItemE);
            // 
            // lblregistros
            // 
            this.lblregistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblregistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblregistros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregistros.ForeColor = System.Drawing.Color.White;
            this.lblregistros.Location = new System.Drawing.Point(0, 0);
            this.lblregistros.Name = "lblregistros";
            this.lblregistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblregistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblregistros.Size = new System.Drawing.Size(1026, 23);
            this.lblregistros.TabIndex = 249;
            this.lblregistros.Text = "Detalle Concepto Gasto";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // idComprobanteDataGridViewTextBoxColumn
            // 
            this.idComprobanteDataGridViewTextBoxColumn.DataPropertyName = "idComprobante";
            this.idComprobanteDataGridViewTextBoxColumn.HeaderText = "Libro";
            this.idComprobanteDataGridViewTextBoxColumn.Name = "idComprobanteDataGridViewTextBoxColumn";
            this.idComprobanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idComprobanteDataGridViewTextBoxColumn.Width = 35;
            // 
            // numFileDataGridViewTextBoxColumn
            // 
            this.numFileDataGridViewTextBoxColumn.DataPropertyName = "numFile";
            this.numFileDataGridViewTextBoxColumn.HeaderText = "File";
            this.numFileDataGridViewTextBoxColumn.Name = "numFileDataGridViewTextBoxColumn";
            this.numFileDataGridViewTextBoxColumn.ReadOnly = true;
            this.numFileDataGridViewTextBoxColumn.Width = 35;
            // 
            // numVoucherDataGridViewTextBoxColumn
            // 
            this.numVoucherDataGridViewTextBoxColumn.DataPropertyName = "numVoucher";
            this.numVoucherDataGridViewTextBoxColumn.HeaderText = "Comprobante";
            this.numVoucherDataGridViewTextBoxColumn.Name = "numVoucherDataGridViewTextBoxColumn";
            this.numVoucherDataGridViewTextBoxColumn.ReadOnly = true;
            this.numVoucherDataGridViewTextBoxColumn.Width = 80;
            // 
            // numItemDataGridViewTextBoxColumn
            // 
            this.numItemDataGridViewTextBoxColumn.DataPropertyName = "numItem";
            this.numItemDataGridViewTextBoxColumn.HeaderText = "Item";
            this.numItemDataGridViewTextBoxColumn.Name = "numItemDataGridViewTextBoxColumn";
            this.numItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.numItemDataGridViewTextBoxColumn.Width = 50;
            // 
            // codCuentaDataGridViewTextBoxColumn
            // 
            this.codCuentaDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            this.codCuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.codCuentaDataGridViewTextBoxColumn.Name = "codCuentaDataGridViewTextBoxColumn";
            this.codCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCuentaDataGridViewTextBoxColumn.Width = 70;
            // 
            // fecDocumentoDataGridViewTextBoxColumn
            // 
            this.fecDocumentoDataGridViewTextBoxColumn.DataPropertyName = "fecDocumento";
            this.fecDocumentoDataGridViewTextBoxColumn.HeaderText = "F. Documento";
            this.fecDocumentoDataGridViewTextBoxColumn.Name = "fecDocumentoDataGridViewTextBoxColumn";
            this.fecDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "TD";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDocumentoDataGridViewTextBoxColumn.Width = 30;
            // 
            // serDocumentoDataGridViewTextBoxColumn
            // 
            this.serDocumentoDataGridViewTextBoxColumn.DataPropertyName = "serDocumento";
            this.serDocumentoDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.serDocumentoDataGridViewTextBoxColumn.Name = "serDocumentoDataGridViewTextBoxColumn";
            this.serDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.serDocumentoDataGridViewTextBoxColumn.Width = 40;
            // 
            // numDocumento
            // 
            this.numDocumento.DataPropertyName = "numDocumento";
            this.numDocumento.HeaderText = "Documento";
            this.numDocumento.Name = "numDocumento";
            this.numDocumento.ReadOnly = true;
            // 
            // impDebe
            // 
            this.impDebe.DataPropertyName = "impDebe";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.impDebe.DefaultCellStyle = dataGridViewCellStyle1;
            this.impDebe.HeaderText = "Debe";
            this.impDebe.Name = "impDebe";
            this.impDebe.ReadOnly = true;
            this.impDebe.Width = 90;
            // 
            // impHaber
            // 
            this.impHaber.DataPropertyName = "impHaber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.impHaber.DefaultCellStyle = dataGridViewCellStyle2;
            this.impHaber.HeaderText = "Haber";
            this.impHaber.Name = "impHaber";
            this.impHaber.ReadOnly = true;
            this.impHaber.Width = 90;
            // 
            // desGlosaDataGridViewTextBoxColumn
            // 
            this.desGlosaDataGridViewTextBoxColumn.DataPropertyName = "desGlosa";
            this.desGlosaDataGridViewTextBoxColumn.HeaderText = "Glosa";
            this.desGlosaDataGridViewTextBoxColumn.Name = "desGlosaDataGridViewTextBoxColumn";
            this.desGlosaDataGridViewTextBoxColumn.ReadOnly = true;
            this.desGlosaDataGridViewTextBoxColumn.Width = 250;
            // 
            // frmReporteConceptoGastoDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 436);
            this.Controls.Add(this.panel2);
            this.Name = "frmReporteConceptoGastoDetalle";
            this.Text = "Detalle Concepto Gasto";
            this.Load += new System.EventHandler(this.frmReporteConceptoGastoDetalle_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPivot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVoucherItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvPivot;
        private MyLabelG.LabelDegradado lblregistros;
        private System.Windows.Forms.BindingSource bsVoucherItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVoucherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn impDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn impHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn desGlosaDataGridViewTextBoxColumn;
    }
}