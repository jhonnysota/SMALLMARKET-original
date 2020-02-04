namespace ClienteWinForm.CtasPorCobrar
{
    partial class frmListadoTipoIngresos
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
            this.pnlListado = new System.Windows.Forms.Panel();
            this.dgvIngresos = new System.Windows.Forms.DataGridView();
            this.bsTipoIngresos = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.btCopiar = new System.Windows.Forms.Button();
            this.tipoCobroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filtroCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCtaProvisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaSolesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDolaresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTipoIngresos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlListado
            // 
            this.pnlListado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlListado.Controls.Add(this.dgvIngresos);
            this.pnlListado.Controls.Add(this.lblRegistros);
            this.pnlListado.Location = new System.Drawing.Point(4, 4);
            this.pnlListado.Name = "pnlListado";
            this.pnlListado.Size = new System.Drawing.Size(845, 360);
            this.pnlListado.TabIndex = 300;
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.AllowUserToAddRows = false;
            this.dgvIngresos.AllowUserToDeleteRows = false;
            this.dgvIngresos.AutoGenerateColumns = false;
            this.dgvIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoCobroDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.selCuentaDataGridViewTextBoxColumn,
            this.filtroCuentaDataGridViewTextBoxColumn,
            this.indCtaProvisionDataGridViewTextBoxColumn,
            this.codCuentaSolesDataGridViewTextBoxColumn,
            this.codCuentaDolaresDataGridViewTextBoxColumn,
            this.UsuarioRegistro,
            this.FechaRegistro,
            this.UsuarioModificacion,
            this.FechaModificacion});
            this.dgvIngresos.DataSource = this.bsTipoIngresos;
            this.dgvIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngresos.EnableHeadersVisualStyles = false;
            this.dgvIngresos.Location = new System.Drawing.Point(0, 19);
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.ReadOnly = true;
            this.dgvIngresos.Size = new System.Drawing.Size(843, 339);
            this.dgvIngresos.TabIndex = 250;
            this.dgvIngresos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngresos_CellDoubleClick);
            // 
            // bsTipoIngresos
            // 
            this.bsTipoIngresos.DataSource = typeof(Entidades.CtasPorCobrar.TipoIngresosE);
            this.bsTipoIngresos.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsTipoIngresos_ListChanged);
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
            this.lblRegistros.Size = new System.Drawing.Size(843, 19);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btCopiar
            // 
            this.btCopiar.Enabled = false;
            this.btCopiar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCopiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCopiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCopiar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCopiar.Image = global::ClienteWinForm.Properties.Resources.Copiar16x16;
            this.btCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCopiar.Location = new System.Drawing.Point(717, 369);
            this.btCopiar.Name = "btCopiar";
            this.btCopiar.Size = new System.Drawing.Size(83, 25);
            this.btCopiar.TabIndex = 609;
            this.btCopiar.Text = "Copiar de";
            this.btCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCopiar.UseVisualStyleBackColor = true;
            this.btCopiar.Click += new System.EventHandler(this.btCopiar_Click);
            // 
            // tipoCobroDataGridViewTextBoxColumn
            // 
            this.tipoCobroDataGridViewTextBoxColumn.DataPropertyName = "TipoCobro";
            this.tipoCobroDataGridViewTextBoxColumn.HeaderText = "Cód.";
            this.tipoCobroDataGridViewTextBoxColumn.Name = "tipoCobroDataGridViewTextBoxColumn";
            this.tipoCobroDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoCobroDataGridViewTextBoxColumn.Width = 40;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn.Width = 250;
            // 
            // selCuentaDataGridViewTextBoxColumn
            // 
            this.selCuentaDataGridViewTextBoxColumn.DataPropertyName = "SelCuenta";
            this.selCuentaDataGridViewTextBoxColumn.HeaderText = "Sel.Cta.";
            this.selCuentaDataGridViewTextBoxColumn.Name = "selCuentaDataGridViewTextBoxColumn";
            this.selCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.selCuentaDataGridViewTextBoxColumn.Width = 50;
            // 
            // filtroCuentaDataGridViewTextBoxColumn
            // 
            this.filtroCuentaDataGridViewTextBoxColumn.DataPropertyName = "filtroCuenta";
            this.filtroCuentaDataGridViewTextBoxColumn.HeaderText = "Filtro Cta.";
            this.filtroCuentaDataGridViewTextBoxColumn.Name = "filtroCuentaDataGridViewTextBoxColumn";
            this.filtroCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.filtroCuentaDataGridViewTextBoxColumn.Width = 80;
            // 
            // indCtaProvisionDataGridViewTextBoxColumn
            // 
            this.indCtaProvisionDataGridViewTextBoxColumn.DataPropertyName = "indCtaProvision";
            this.indCtaProvisionDataGridViewTextBoxColumn.HeaderText = "Ind.Cta.Prov.";
            this.indCtaProvisionDataGridViewTextBoxColumn.Name = "indCtaProvisionDataGridViewTextBoxColumn";
            this.indCtaProvisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.indCtaProvisionDataGridViewTextBoxColumn.Width = 50;
            // 
            // codCuentaSolesDataGridViewTextBoxColumn
            // 
            this.codCuentaSolesDataGridViewTextBoxColumn.DataPropertyName = "codCuentaSoles";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCuentaSolesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.codCuentaSolesDataGridViewTextBoxColumn.HeaderText = "Cta.Prov. S/.";
            this.codCuentaSolesDataGridViewTextBoxColumn.Name = "codCuentaSolesDataGridViewTextBoxColumn";
            this.codCuentaSolesDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCuentaSolesDataGridViewTextBoxColumn.Width = 90;
            // 
            // codCuentaDolaresDataGridViewTextBoxColumn
            // 
            this.codCuentaDolaresDataGridViewTextBoxColumn.DataPropertyName = "codCuentaDolares";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCuentaDolaresDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.codCuentaDolaresDataGridViewTextBoxColumn.HeaderText = "Cta.Prov. US$";
            this.codCuentaDolaresDataGridViewTextBoxColumn.Name = "codCuentaDolaresDataGridViewTextBoxColumn";
            this.codCuentaDolaresDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCuentaDolaresDataGridViewTextBoxColumn.Width = 90;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.DataPropertyName = "UsuarioRegistro";
            this.UsuarioRegistro.HeaderText = "Usuario Reg.";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            this.UsuarioRegistro.ReadOnly = true;
            this.UsuarioRegistro.Width = 90;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FechaRegistro.DefaultCellStyle = dataGridViewCellStyle3;
            this.FechaRegistro.HeaderText = "Fecha Reg.";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            this.FechaRegistro.Width = 130;
            // 
            // UsuarioModificacion
            // 
            this.UsuarioModificacion.DataPropertyName = "UsuarioModificacion";
            this.UsuarioModificacion.HeaderText = "Usuario Mod.";
            this.UsuarioModificacion.Name = "UsuarioModificacion";
            this.UsuarioModificacion.ReadOnly = true;
            this.UsuarioModificacion.Width = 90;
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FechaModificacion.DefaultCellStyle = dataGridViewCellStyle4;
            this.FechaModificacion.HeaderText = "Fecha Mod.";
            this.FechaModificacion.Name = "FechaModificacion";
            this.FechaModificacion.ReadOnly = true;
            this.FechaModificacion.Width = 130;
            // 
            // frmListadoTipoIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 398);
            this.Controls.Add(this.btCopiar);
            this.Controls.Add(this.pnlListado);
            this.MaximizeBox = false;
            this.Name = "frmListadoTipoIngresos";
            this.Text = "Listado Tipo de Cobranzas";
            this.Load += new System.EventHandler(this.frmListadoTipoIngresos_Load);
            this.pnlListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTipoIngresos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlListado;
        private System.Windows.Forms.DataGridView dgvIngresos;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsTipoIngresos;
        private System.Windows.Forms.Button btCopiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCobroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn selCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filtroCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indCtaProvisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaSolesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDolaresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
    }
}