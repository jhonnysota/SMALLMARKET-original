namespace ClienteWinForm.Almacen.Reportes
{
    partial class frmReportePagos
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
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.bsProvisiones = new System.Windows.Forms.BindingSource(this.components);
            this.lblregistros = new MyLabelG.LabelDegradado();
            this.label3 = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesde = new System.Windows.Forms.DateTimePicker();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.btnExportar = new System.Windows.Forms.Button();
            this.FechaProvision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodPartidaPresu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesPartida = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvListado);
            this.panel2.Controls.Add(this.lblregistros);
            this.panel2.Location = new System.Drawing.Point(0, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1205, 394);
            this.panel2.TabIndex = 298;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaProvision,
            this.razonSocialDataGridViewTextBoxColumn,
            this.CodPartidaPresu,
            this.DesPartida,
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
            this.dgvListado.Size = new System.Drawing.Size(1203, 369);
            this.dgvListado.TabIndex = 248;
            this.dgvListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListado_CellFormatting);
            this.dgvListado.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListado_ColumnHeaderMouseClick);
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
            this.lblregistros.Size = new System.Drawing.Size(1203, 23);
            this.lblregistros.TabIndex = 249;
            this.lblregistros.Text = "registros";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1118, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 357;
            this.label3.Text = "Procesando ...";
            this.label3.Visible = false;
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(1076, 16);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(36, 34);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 355;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.Mostrar_Reporte;
            this.btBuscar.Location = new System.Drawing.Point(386, 8);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(57, 52);
            this.btBuscar.TabIndex = 356;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtHasta);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtDesde);
            this.panel4.Controls.Add(this.labelDegradado3);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(353, 60);
            this.panel4.TabIndex = 354;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 352;
            this.label2.Text = "al";
            // 
            // txtHasta
            // 
            this.txtHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtHasta.Location = new System.Drawing.Point(224, 29);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(108, 20);
            this.txtHasta.TabIndex = 351;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 266;
            this.label1.Text = "Del : ";
            // 
            // txtDesde
            // 
            this.txtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDesde.Location = new System.Drawing.Point(59, 29);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(108, 20);
            this.txtDesde.TabIndex = 350;
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(351, 21);
            this.labelDegradado3.TabIndex = 253;
            this.labelDegradado3.Text = "Periodo de Fechas";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Image = global::ClienteWinForm.Properties.Resources.Excel_Chico;
            this.btnExportar.Location = new System.Drawing.Point(463, 8);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(57, 52);
            this.btnExportar.TabIndex = 358;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click_1);
            // 
            // FechaProvision
            // 
            this.FechaProvision.DataPropertyName = "FechaProvision";
            this.FechaProvision.HeaderText = "Operación";
            this.FechaProvision.Name = "FechaProvision";
            this.FechaProvision.ReadOnly = true;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 150;
            // 
            // CodPartidaPresu
            // 
            this.CodPartidaPresu.DataPropertyName = "CodPartidaPresu";
            this.CodPartidaPresu.HeaderText = "Codigo";
            this.CodPartidaPresu.Name = "CodPartidaPresu";
            this.CodPartidaPresu.ReadOnly = true;
            this.CodPartidaPresu.Width = 60;
            // 
            // DesPartida
            // 
            this.DesPartida.DataPropertyName = "desPartidaPresu";
            this.DesPartida.HeaderText = "Partida Presupuestaria";
            this.DesPartida.Name = "DesPartida";
            this.DesPartida.ReadOnly = true;
            this.DesPartida.Width = 140;
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
            this.idDocumento.Width = 35;
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
            this.numDocumentoDataGridViewTextBoxColumn.HeaderText = "Número";
            this.numDocumentoDataGridViewTextBoxColumn.Name = "numDocumentoDataGridViewTextBoxColumn";
            this.numDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.numDocumentoDataGridViewTextBoxColumn.Width = 90;
            // 
            // tipCambioDataGridViewTextBoxColumn
            // 
            this.tipCambioDataGridViewTextBoxColumn.DataPropertyName = "TipCambio";
            this.tipCambioDataGridViewTextBoxColumn.HeaderText = "TC";
            this.tipCambioDataGridViewTextBoxColumn.Name = "tipCambioDataGridViewTextBoxColumn";
            this.tipCambioDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipCambioDataGridViewTextBoxColumn.Width = 40;
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
            this.impTotalBase.Width = 90;
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
            this.impTotalSecun.Width = 90;
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
            // frmReportePagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1207, 463);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "frmReportePagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.frmReporteEEFFGanaciasPerdidasDetalle_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProvisiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvListado;
        private MyLabelG.LabelDegradado lblregistros;
        private System.Windows.Forms.BindingSource bsProvisiones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDesde;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaProvision;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodPartidaPresu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesPartida;
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