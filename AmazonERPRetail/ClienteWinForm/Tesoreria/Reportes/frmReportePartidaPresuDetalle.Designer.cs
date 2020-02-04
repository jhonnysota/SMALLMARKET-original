namespace ClienteWinForm.Almacen.Reportes
{
    partial class frmReportePartidaPresuDetalle
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
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.bsProvisiones = new System.Windows.Forms.BindingSource(this.components);
            this.lblregistros = new MyLabelG.LabelDegradado();
            this.fechaProvisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desProvisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVencimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipCambioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codMonedaProvisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impTotalBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impTotalSecun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoProvisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVoucherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProvisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnExportar);
            this.panel2.Controls.Add(this.dgvListado);
            this.panel2.Controls.Add(this.lblregistros);
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1212, 320);
            this.panel2.TabIndex = 298;
            // 
            // btnExportar
            // 
            this.btnExportar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExportar.Image = global::ClienteWinForm.Properties.Resources.Excel_Chico;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(1095, 0);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(106, 23);
            this.btnExportar.TabIndex = 250;
            this.btnExportar.Text = "Exportar  ";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaProvisionDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.desProvisionDataGridViewTextBoxColumn,
            this.fechaDocumentoDataGridViewTextBoxColumn,
            this.fechaVencimientoDataGridViewTextBoxColumn,
            this.idDocumento,
            this.desDocumento,
            this.numSerieDataGridViewTextBoxColumn,
            this.numDocumentoDataGridViewTextBoxColumn,
            this.tipCambioDataGridViewTextBoxColumn,
            this.codMonedaProvisionDataGridViewTextBoxColumn,
            this.impTotalBase,
            this.impTotalSecun,
            this.estadoProvisionDataGridViewTextBoxColumn,
            this.idComprobanteDataGridViewTextBoxColumn,
            this.numFileDataGridViewTextBoxColumn,
            this.numVoucherDataGridViewTextBoxColumn,
            this.codCuentaDataGridViewTextBoxColumn,
            this.desCuentaDataGridViewTextBoxColumn});
            this.dgvListado.DataSource = this.bsProvisiones;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.EnableHeadersVisualStyles = false;
            this.dgvListado.Location = new System.Drawing.Point(0, 23);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(1210, 295);
            this.dgvListado.TabIndex = 248;
            this.dgvListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListado_CellFormatting);
            // 
            // bsProvisiones
            // 
            this.bsProvisiones.DataSource = typeof(Entidades.CtasPorPagar.ProvisionesE);
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
            this.lblregistros.Size = new System.Drawing.Size(1210, 23);
            this.lblregistros.TabIndex = 249;
            this.lblregistros.Text = "registros";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fechaProvisionDataGridViewTextBoxColumn
            // 
            this.fechaProvisionDataGridViewTextBoxColumn.DataPropertyName = "FechaProvision";
            this.fechaProvisionDataGridViewTextBoxColumn.HeaderText = "F. Provision";
            this.fechaProvisionDataGridViewTextBoxColumn.Name = "fechaProvisionDataGridViewTextBoxColumn";
            this.fechaProvisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaProvisionDataGridViewTextBoxColumn.Width = 95;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 150;
            // 
            // desProvisionDataGridViewTextBoxColumn
            // 
            this.desProvisionDataGridViewTextBoxColumn.DataPropertyName = "DesProvision";
            this.desProvisionDataGridViewTextBoxColumn.HeaderText = "Provision";
            this.desProvisionDataGridViewTextBoxColumn.Name = "desProvisionDataGridViewTextBoxColumn";
            this.desProvisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.desProvisionDataGridViewTextBoxColumn.Width = 150;
            // 
            // fechaDocumentoDataGridViewTextBoxColumn
            // 
            this.fechaDocumentoDataGridViewTextBoxColumn.DataPropertyName = "FechaDocumento";
            this.fechaDocumentoDataGridViewTextBoxColumn.HeaderText = "F. Documento";
            this.fechaDocumentoDataGridViewTextBoxColumn.Name = "fechaDocumentoDataGridViewTextBoxColumn";
            this.fechaDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDocumentoDataGridViewTextBoxColumn.Width = 115;
            // 
            // fechaVencimientoDataGridViewTextBoxColumn
            // 
            this.fechaVencimientoDataGridViewTextBoxColumn.DataPropertyName = "FechaVencimiento";
            this.fechaVencimientoDataGridViewTextBoxColumn.HeaderText = "F. Vencimiento";
            this.fechaVencimientoDataGridViewTextBoxColumn.Name = "fechaVencimientoDataGridViewTextBoxColumn";
            this.fechaVencimientoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaVencimientoDataGridViewTextBoxColumn.Width = 115;
            // 
            // idDocumento
            // 
            this.idDocumento.DataPropertyName = "idDocumento";
            this.idDocumento.HeaderText = "Tipo";
            this.idDocumento.Name = "idDocumento";
            this.idDocumento.ReadOnly = true;
            this.idDocumento.Width = 45;
            // 
            // desDocumento
            // 
            this.desDocumento.DataPropertyName = "desDocumento";
            this.desDocumento.HeaderText = "Documento";
            this.desDocumento.Name = "desDocumento";
            this.desDocumento.ReadOnly = true;
            // 
            // numSerieDataGridViewTextBoxColumn
            // 
            this.numSerieDataGridViewTextBoxColumn.DataPropertyName = "NumSerie";
            this.numSerieDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.numSerieDataGridViewTextBoxColumn.Name = "numSerieDataGridViewTextBoxColumn";
            this.numSerieDataGridViewTextBoxColumn.ReadOnly = true;
            this.numSerieDataGridViewTextBoxColumn.Width = 40;
            // 
            // numDocumentoDataGridViewTextBoxColumn
            // 
            this.numDocumentoDataGridViewTextBoxColumn.DataPropertyName = "NumDocumento";
            this.numDocumentoDataGridViewTextBoxColumn.HeaderText = "Numero";
            this.numDocumentoDataGridViewTextBoxColumn.Name = "numDocumentoDataGridViewTextBoxColumn";
            this.numDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.numDocumentoDataGridViewTextBoxColumn.Width = 85;
            // 
            // tipCambioDataGridViewTextBoxColumn
            // 
            this.tipCambioDataGridViewTextBoxColumn.DataPropertyName = "TipCambio";
            this.tipCambioDataGridViewTextBoxColumn.HeaderText = "TC";
            this.tipCambioDataGridViewTextBoxColumn.Name = "tipCambioDataGridViewTextBoxColumn";
            this.tipCambioDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipCambioDataGridViewTextBoxColumn.Width = 50;
            // 
            // codMonedaProvisionDataGridViewTextBoxColumn
            // 
            this.codMonedaProvisionDataGridViewTextBoxColumn.DataPropertyName = "CodMonedaProvision";
            this.codMonedaProvisionDataGridViewTextBoxColumn.HeaderText = "Mon";
            this.codMonedaProvisionDataGridViewTextBoxColumn.Name = "codMonedaProvisionDataGridViewTextBoxColumn";
            this.codMonedaProvisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.codMonedaProvisionDataGridViewTextBoxColumn.Width = 40;
            // 
            // impTotalBase
            // 
            this.impTotalBase.DataPropertyName = "impTotalBase";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.impTotalBase.DefaultCellStyle = dataGridViewCellStyle1;
            this.impTotalBase.HeaderText = "Soles";
            this.impTotalBase.Name = "impTotalBase";
            this.impTotalBase.ReadOnly = true;
            // 
            // impTotalSecun
            // 
            this.impTotalSecun.DataPropertyName = "impTotalSecun";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.impTotalSecun.DefaultCellStyle = dataGridViewCellStyle2;
            this.impTotalSecun.HeaderText = "Dolares";
            this.impTotalSecun.Name = "impTotalSecun";
            this.impTotalSecun.ReadOnly = true;
            // 
            // estadoProvisionDataGridViewTextBoxColumn
            // 
            this.estadoProvisionDataGridViewTextBoxColumn.DataPropertyName = "EstadoProvision";
            this.estadoProvisionDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoProvisionDataGridViewTextBoxColumn.Name = "estadoProvisionDataGridViewTextBoxColumn";
            this.estadoProvisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoProvisionDataGridViewTextBoxColumn.Width = 60;
            // 
            // idComprobanteDataGridViewTextBoxColumn
            // 
            this.idComprobanteDataGridViewTextBoxColumn.DataPropertyName = "idComprobante";
            this.idComprobanteDataGridViewTextBoxColumn.HeaderText = "Libro";
            this.idComprobanteDataGridViewTextBoxColumn.Name = "idComprobanteDataGridViewTextBoxColumn";
            this.idComprobanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idComprobanteDataGridViewTextBoxColumn.Width = 45;
            // 
            // numFileDataGridViewTextBoxColumn
            // 
            this.numFileDataGridViewTextBoxColumn.DataPropertyName = "numFile";
            this.numFileDataGridViewTextBoxColumn.HeaderText = "File";
            this.numFileDataGridViewTextBoxColumn.Name = "numFileDataGridViewTextBoxColumn";
            this.numFileDataGridViewTextBoxColumn.ReadOnly = true;
            this.numFileDataGridViewTextBoxColumn.Width = 40;
            // 
            // numVoucherDataGridViewTextBoxColumn
            // 
            this.numVoucherDataGridViewTextBoxColumn.DataPropertyName = "numVoucher";
            this.numVoucherDataGridViewTextBoxColumn.HeaderText = "Comprobante";
            this.numVoucherDataGridViewTextBoxColumn.Name = "numVoucherDataGridViewTextBoxColumn";
            this.numVoucherDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codCuentaDataGridViewTextBoxColumn
            // 
            this.codCuentaDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            this.codCuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.codCuentaDataGridViewTextBoxColumn.Name = "codCuentaDataGridViewTextBoxColumn";
            this.codCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desCuentaDataGridViewTextBoxColumn
            // 
            this.desCuentaDataGridViewTextBoxColumn.DataPropertyName = "DesCuenta";
            this.desCuentaDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desCuentaDataGridViewTextBoxColumn.Name = "desCuentaDataGridViewTextBoxColumn";
            this.desCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmReportePartidaPresuDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 325);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "frmReportePartidaPresuDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Provisiones de Partida Presupuestaria";
            this.Load += new System.EventHandler(this.frmReporteEEFFGanaciasPerdidasDetalle_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProvisiones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvListado;
        private MyLabelG.LabelDegradado lblregistros;
        private System.Windows.Forms.BindingSource bsProvisiones;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaProvisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desProvisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVencimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn desDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipCambioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codMonedaProvisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impTotalBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn impTotalSecun;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoProvisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVoucherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCuentaDataGridViewTextBoxColumn;
    }
}