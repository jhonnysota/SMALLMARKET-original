namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarProvisiones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProvisiones = new System.Windows.Forms.DataGridView();
            this.fechaProvisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProvisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rucDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.txtDocumento = new ControlesWinForm.SuperTextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.CtasPorPagar.ProvisionesE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(306, 397);
            this.btnAceptar.Size = new System.Drawing.Size(142, 28);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(457, 397);
            this.btnCancelar.Size = new System.Drawing.Size(142, 28);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(814, 17);
            this.btnBuscar.Size = new System.Drawing.Size(59, 51);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(884, 25);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(284, 27);
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.Text = "Ingrese la Razón Social";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(405, 23);
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // gbResultados
            // 
            this.gbResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultados.Controls.Add(this.label3);
            this.gbResultados.Controls.Add(this.label2);
            this.gbResultados.Controls.Add(this.txtDocumento);
            this.gbResultados.Controls.Add(this.label25);
            this.gbResultados.Controls.Add(this.dgvProvisiones);
            this.gbResultados.Controls.Add(this.dtpFecFin);
            this.gbResultados.Controls.Add(this.dtpFecIni);
            this.gbResultados.Location = new System.Drawing.Point(4, 2);
            this.gbResultados.Size = new System.Drawing.Size(897, 385);
            // 
            // dgvProvisiones
            // 
            this.dgvProvisiones.AllowUserToAddRows = false;
            this.dgvProvisiones.AllowUserToDeleteRows = false;
            this.dgvProvisiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProvisiones.AutoGenerateColumns = false;
            this.dgvProvisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProvisiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaProvisionDataGridViewTextBoxColumn,
            this.idProvisionDataGridViewTextBoxColumn,
            this.fechaDocumentoDataGridViewTextBoxColumn,
            this.idDocumentoDataGridViewTextBoxColumn,
            this.numSerieDataGridViewTextBoxColumn,
            this.numDocumentoDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.rucDataGridViewTextBoxColumn,
            this.DesEstado});
            this.dgvProvisiones.DataSource = this.bsBase;
            this.dgvProvisiones.EnableHeadersVisualStyles = false;
            this.dgvProvisiones.Location = new System.Drawing.Point(5, 73);
            this.dgvProvisiones.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProvisiones.Name = "dgvProvisiones";
            this.dgvProvisiones.ReadOnly = true;
            this.dgvProvisiones.RowTemplate.Height = 24;
            this.dgvProvisiones.Size = new System.Drawing.Size(887, 306);
            this.dgvProvisiones.TabIndex = 3;
            this.dgvProvisiones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProvisiones_CellDoubleClick);
            this.dgvProvisiones.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvProvisiones_CellPainting);
            this.dgvProvisiones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProvisiones_KeyDown);
            // 
            // fechaProvisionDataGridViewTextBoxColumn
            // 
            this.fechaProvisionDataGridViewTextBoxColumn.DataPropertyName = "FechaProvision";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.fechaProvisionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaProvisionDataGridViewTextBoxColumn.HeaderText = "Fec.Provisión";
            this.fechaProvisionDataGridViewTextBoxColumn.Name = "fechaProvisionDataGridViewTextBoxColumn";
            this.fechaProvisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaProvisionDataGridViewTextBoxColumn.Width = 90;
            // 
            // idProvisionDataGridViewTextBoxColumn
            // 
            this.idProvisionDataGridViewTextBoxColumn.DataPropertyName = "idProvision";
            dataGridViewCellStyle2.Format = "0000000";
            dataGridViewCellStyle2.NullValue = null;
            this.idProvisionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.idProvisionDataGridViewTextBoxColumn.HeaderText = "Nro.";
            this.idProvisionDataGridViewTextBoxColumn.Name = "idProvisionDataGridViewTextBoxColumn";
            this.idProvisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProvisionDataGridViewTextBoxColumn.Width = 60;
            // 
            // fechaDocumentoDataGridViewTextBoxColumn
            // 
            this.fechaDocumentoDataGridViewTextBoxColumn.DataPropertyName = "FechaDocumento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            this.fechaDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaDocumentoDataGridViewTextBoxColumn.HeaderText = "Fec.Doc.";
            this.fechaDocumentoDataGridViewTextBoxColumn.Name = "fechaDocumentoDataGridViewTextBoxColumn";
            this.fechaDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDocumentoDataGridViewTextBoxColumn.ToolTipText = "Fecha del documento";
            this.fechaDocumentoDataGridViewTextBoxColumn.Width = 70;
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "T.D.";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDocumentoDataGridViewTextBoxColumn.ToolTipText = "Tipo de documento";
            this.idDocumentoDataGridViewTextBoxColumn.Width = 50;
            // 
            // numSerieDataGridViewTextBoxColumn
            // 
            this.numSerieDataGridViewTextBoxColumn.DataPropertyName = "NumSerie";
            this.numSerieDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.numSerieDataGridViewTextBoxColumn.Name = "numSerieDataGridViewTextBoxColumn";
            this.numSerieDataGridViewTextBoxColumn.ReadOnly = true;
            this.numSerieDataGridViewTextBoxColumn.Width = 60;
            // 
            // numDocumentoDataGridViewTextBoxColumn
            // 
            this.numDocumentoDataGridViewTextBoxColumn.DataPropertyName = "NumDocumento";
            this.numDocumentoDataGridViewTextBoxColumn.HeaderText = "Num.Docum.";
            this.numDocumentoDataGridViewTextBoxColumn.Name = "numDocumentoDataGridViewTextBoxColumn";
            this.numDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.numDocumentoDataGridViewTextBoxColumn.Width = 85;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "Razón Social";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 250;
            // 
            // rucDataGridViewTextBoxColumn
            // 
            this.rucDataGridViewTextBoxColumn.DataPropertyName = "Ruc";
            this.rucDataGridViewTextBoxColumn.HeaderText = "Ruc";
            this.rucDataGridViewTextBoxColumn.Name = "rucDataGridViewTextBoxColumn";
            this.rucDataGridViewTextBoxColumn.ReadOnly = true;
            this.rucDataGridViewTextBoxColumn.Width = 80;
            // 
            // DesEstado
            // 
            this.DesEstado.DataPropertyName = "DesEstado";
            this.DesEstado.HeaderText = "Estado";
            this.DesEstado.Name = "DesEstado";
            this.DesEstado.ReadOnly = true;
            this.DesEstado.Width = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 366;
            this.label2.Text = "Del";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(154, 36);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 13);
            this.label25.TabIndex = 365;
            this.label25.Text = "Al";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(173, 32);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(97, 21);
            this.dtpFecFin.TabIndex = 364;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(53, 32);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(97, 21);
            this.dtpFecIni.TabIndex = 363;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDocumento.BackColor = System.Drawing.Color.White;
            this.txtDocumento.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(401, 45);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(175, 20);
            this.txtDocumento.TabIndex = 4;
            this.txtDocumento.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDocumento.TextoVacio = "Serie - Número";
            this.txtDocumento.TextChanged += new System.EventHandler(this.txtDocumento_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(286, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 367;
            this.label3.Text = "N° de Documento";
            // 
            // frmBuscarProvisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 431);
            this.Name = "frmBuscarProvisiones";
            this.Text = "Provisiones";
            this.Load += new System.EventHandler(this.frmBuscarProvisiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            this.gbResultados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvisiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProvisiones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaProvisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProvisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rucDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesEstado;
        private System.Windows.Forms.Label label3;
        private ControlesWinForm.SuperTextBox txtDocumento;
    }
}