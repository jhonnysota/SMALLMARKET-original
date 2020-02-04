namespace ClienteWinForm.Maestros
{
    partial class frmCCostosNumControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCentroCostos = new System.Windows.Forms.DataGridView();
            this.idCCostosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCCostosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCCostos = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCCostosSeries = new System.Windows.Forms.DataGridView();
            this.idDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCostosSerie = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.cboSeries = new System.Windows.Forms.ComboBox();
            this.btInsertar = new System.Windows.Forms.Button();
            this.btBorrar = new System.Windows.Forms.Button();
            this.idEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCCostosDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCCostosDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitulo1 = new System.Windows.Forms.Label();
            this.lblTitulo2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCentroCostos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCCostos)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCCostosSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCostosSerie)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvCentroCostos);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblTitulo1);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 301);
            this.panel1.TabIndex = 77;
            // 
            // dgvCentroCostos
            // 
            this.dgvCentroCostos.AllowUserToAddRows = false;
            this.dgvCentroCostos.AllowUserToDeleteRows = false;
            this.dgvCentroCostos.AutoGenerateColumns = false;
            this.dgvCentroCostos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCentroCostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCentroCostos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCCostosDataGridViewTextBoxColumn,
            this.desCCostosDataGridViewTextBoxColumn});
            this.dgvCentroCostos.DataSource = this.bsCCostos;
            this.dgvCentroCostos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCentroCostos.EnableHeadersVisualStyles = false;
            this.dgvCentroCostos.Location = new System.Drawing.Point(0, 18);
            this.dgvCentroCostos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCentroCostos.Name = "dgvCentroCostos";
            this.dgvCentroCostos.ReadOnly = true;
            this.dgvCentroCostos.RowTemplate.Height = 24;
            this.dgvCentroCostos.Size = new System.Drawing.Size(307, 281);
            this.dgvCentroCostos.TabIndex = 80;
            // 
            // idCCostosDataGridViewTextBoxColumn
            // 
            this.idCCostosDataGridViewTextBoxColumn.DataPropertyName = "idCCostos";
            this.idCCostosDataGridViewTextBoxColumn.HeaderText = "Cód.";
            this.idCCostosDataGridViewTextBoxColumn.Name = "idCCostosDataGridViewTextBoxColumn";
            this.idCCostosDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCCostosDataGridViewTextBoxColumn.Width = 70;
            // 
            // desCCostosDataGridViewTextBoxColumn
            // 
            this.desCCostosDataGridViewTextBoxColumn.DataPropertyName = "desCCostos";
            this.desCCostosDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desCCostosDataGridViewTextBoxColumn.Name = "desCCostosDataGridViewTextBoxColumn";
            this.desCCostosDataGridViewTextBoxColumn.ReadOnly = true;
            this.desCCostosDataGridViewTextBoxColumn.Width = 200;
            // 
            // bsCCostos
            // 
            this.bsCCostos.DataSource = typeof(Entidades.Maestros.CCostosE);
            this.bsCCostos.CurrentChanged += new System.EventHandler(this.bsCCostos_CurrentChanged);
            this.bsCCostos.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsCCostos_ListChanged);
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvCCostosSeries);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.lblTitulo2);
            this.panel2.Location = new System.Drawing.Point(317, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 248);
            this.panel2.TabIndex = 271;
            // 
            // dgvCCostosSeries
            // 
            this.dgvCCostosSeries.AllowUserToAddRows = false;
            this.dgvCCostosSeries.AllowUserToDeleteRows = false;
            this.dgvCCostosSeries.AutoGenerateColumns = false;
            this.dgvCCostosSeries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCCostosSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCCostosSeries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDocumento,
            this.Serie,
            this.idEmpresaDataGridViewTextBoxColumn,
            this.idCCostosDataGridViewTextBoxColumn1,
            this.idDocumentoDataGridViewTextBoxColumn,
            this.serieDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.desCCostosDataGridViewTextBoxColumn1});
            this.dgvCCostosSeries.DataSource = this.bsCostosSerie;
            this.dgvCCostosSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCCostosSeries.EnableHeadersVisualStyles = false;
            this.dgvCCostosSeries.Location = new System.Drawing.Point(0, 18);
            this.dgvCCostosSeries.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCCostosSeries.Name = "dgvCCostosSeries";
            this.dgvCCostosSeries.ReadOnly = true;
            this.dgvCCostosSeries.RowTemplate.Height = 24;
            this.dgvCCostosSeries.Size = new System.Drawing.Size(239, 228);
            this.dgvCCostosSeries.TabIndex = 80;
            // 
            // idDocumento
            // 
            this.idDocumento.DataPropertyName = "idDocumento";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDocumento.DefaultCellStyle = dataGridViewCellStyle1;
            this.idDocumento.HeaderText = "Tip.Doc.";
            this.idDocumento.Name = "idDocumento";
            this.idDocumento.ReadOnly = true;
            this.idDocumento.Width = 60;
            // 
            // Serie
            // 
            this.Serie.DataPropertyName = "Serie";
            this.Serie.HeaderText = "Serie";
            this.Serie.Name = "Serie";
            this.Serie.ReadOnly = true;
            this.Serie.Width = 110;
            // 
            // bsCostosSerie
            // 
            this.bsCostosSerie.DataMember = "ListaSeries";
            this.bsCostosSerie.DataSource = this.bsCCostos;
            this.bsCostosSerie.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsCostosSerie_ListChanged);
            // 
            // button2
            // 
            this.button2.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.button2.Location = new System.Drawing.Point(1217, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 59);
            this.button2.TabIndex = 154;
            this.button2.Text = "BUSCAR";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.DropDownWidth = 173;
            this.cboTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(317, 257);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(160, 21);
            this.cboTipoDocumento.TabIndex = 1508;
            this.cboTipoDocumento.SelectionChangeCommitted += new System.EventHandler(this.cboTipoDocumento_SelectionChangeCommitted);
            // 
            // cboSeries
            // 
            this.cboSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeries.DropDownWidth = 173;
            this.cboSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeries.FormattingEnabled = true;
            this.cboSeries.Location = new System.Drawing.Point(317, 280);
            this.cboSeries.Name = "cboSeries";
            this.cboSeries.Size = new System.Drawing.Size(160, 21);
            this.cboSeries.TabIndex = 1509;
            // 
            // btInsertar
            // 
            this.btInsertar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btInsertar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btInsertar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInsertar.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btInsertar.Location = new System.Drawing.Point(482, 269);
            this.btInsertar.Name = "btInsertar";
            this.btInsertar.Size = new System.Drawing.Size(34, 22);
            this.btInsertar.TabIndex = 1566;
            this.btInsertar.TabStop = false;
            this.btInsertar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInsertar.UseVisualStyleBackColor = true;
            this.btInsertar.Click += new System.EventHandler(this.btInsertar_Click);
            // 
            // btBorrar
            // 
            this.btBorrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBorrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBorrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBorrar.Image = global::ClienteWinForm.Properties.Resources.Row_Delete_16x16;
            this.btBorrar.Location = new System.Drawing.Point(519, 269);
            this.btBorrar.Name = "btBorrar";
            this.btBorrar.Size = new System.Drawing.Size(34, 22);
            this.btBorrar.TabIndex = 1567;
            this.btBorrar.TabStop = false;
            this.btBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBorrar.UseVisualStyleBackColor = true;
            this.btBorrar.Click += new System.EventHandler(this.btBorrar_Click);
            // 
            // idEmpresaDataGridViewTextBoxColumn
            // 
            this.idEmpresaDataGridViewTextBoxColumn.DataPropertyName = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.HeaderText = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.Name = "idEmpresaDataGridViewTextBoxColumn";
            this.idEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idCCostosDataGridViewTextBoxColumn1
            // 
            this.idCCostosDataGridViewTextBoxColumn1.DataPropertyName = "idCCostos";
            this.idCCostosDataGridViewTextBoxColumn1.HeaderText = "idCCostos";
            this.idCCostosDataGridViewTextBoxColumn1.Name = "idCCostosDataGridViewTextBoxColumn1";
            this.idCCostosDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "idDocumento";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serieDataGridViewTextBoxColumn
            // 
            this.serieDataGridViewTextBoxColumn.DataPropertyName = "Serie";
            this.serieDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.serieDataGridViewTextBoxColumn.Name = "serieDataGridViewTextBoxColumn";
            this.serieDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desCCostosDataGridViewTextBoxColumn1
            // 
            this.desCCostosDataGridViewTextBoxColumn1.DataPropertyName = "desCCostos";
            this.desCCostosDataGridViewTextBoxColumn1.HeaderText = "desCCostos";
            this.desCCostosDataGridViewTextBoxColumn1.Name = "desCCostosDataGridViewTextBoxColumn1";
            this.desCCostosDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // lblTitulo1
            // 
            this.lblTitulo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTitulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo1.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo1.Name = "lblTitulo1";
            this.lblTitulo1.Size = new System.Drawing.Size(307, 18);
            this.lblTitulo1.TabIndex = 1574;
            this.lblTitulo1.Text = "Registros 0";
            this.lblTitulo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo2
            // 
            this.lblTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo2.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo2.Name = "lblTitulo2";
            this.lblTitulo2.Size = new System.Drawing.Size(239, 18);
            this.lblTitulo2.TabIndex = 1574;
            this.lblTitulo2.Text = "Registros 0";
            this.lblTitulo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCCostosNumControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 308);
            this.Controls.Add(this.btInsertar);
            this.Controls.Add(this.btBorrar);
            this.Controls.Add(this.cboSeries);
            this.Controls.Add(this.cboTipoDocumento);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmCCostosNumControl";
            this.Text = "Series por C.Costo";
            this.Load += new System.EventHandler(this.frmCCostosNumControl_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCentroCostos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCCostos)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCCostosSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCostosSerie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsCCostos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCentroCostos;
        protected internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvCCostosSeries;
        protected internal System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource bsCostosSerie;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.ComboBox cboSeries;
        private System.Windows.Forms.Button btInsertar;
        private System.Windows.Forms.Button btBorrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCCostosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCCostosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serie;
        private System.Windows.Forms.Label lblTitulo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCCostosDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCCostosDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label lblTitulo2;
    }
}