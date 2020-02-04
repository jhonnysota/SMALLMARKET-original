namespace ClienteWinForm.Almacen
{
    partial class frmListadoConceptos
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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label1;
            this.bsConceptos = new System.Windows.Forms.BindingSource(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtDesConcepto = new ControlesWinForm.SuperTextBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvConceptos = new System.Windows.Forms.DataGridView();
            this.indCompras = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indTesoreria = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indCobranzas = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indPlanillas = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaAdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaVen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btCopiar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsConceptos)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(300, 28);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(63, 13);
            label10.TabIndex = 302;
            label10.Text = "Descripción";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(28, 28);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 13);
            label1.TabIndex = 303;
            label1.Text = "Tipo Concepto";
            // 
            // bsConceptos
            // 
            this.bsConceptos.DataSource = typeof(Entidades.Almacen.ConceptosVariosE);
            this.bsConceptos.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsConceptos_ListChanged);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lblTitulo);
            this.panel6.Controls.Add(label1);
            this.panel6.Controls.Add(label10);
            this.panel6.Controls.Add(this.txtDesConcepto);
            this.panel6.Controls.Add(this.cboTipo);
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(784, 55);
            this.panel6.TabIndex = 299;
            // 
            // txtDesConcepto
            // 
            this.txtDesConcepto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesConcepto.BackColor = System.Drawing.Color.White;
            this.txtDesConcepto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesConcepto.Location = new System.Drawing.Point(368, 24);
            this.txtDesConcepto.Name = "txtDesConcepto";
            this.txtDesConcepto.Size = new System.Drawing.Size(384, 20);
            this.txtDesConcepto.TabIndex = 301;
            this.txtDesConcepto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesConcepto.TextoVacio = "<Descripcion>";
            this.txtDesConcepto.TextChanged += new System.EventHandler(this.txtDesConcepto_TextChanged);
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipo.ForeColor = System.Drawing.Color.Black;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(108, 24);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(187, 21);
            this.cboTipo.TabIndex = 262;
            this.cboTipo.SelectionChangeCommitted += new System.EventHandler(this.cboTipo_SelectionChangeCommitted);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvConceptos);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(3, 61);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1180, 297);
            this.panel5.TabIndex = 300;
            // 
            // dgvConceptos
            // 
            this.dgvConceptos.AllowUserToAddRows = false;
            this.dgvConceptos.AllowUserToDeleteRows = false;
            this.dgvConceptos.AutoGenerateColumns = false;
            this.dgvConceptos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indCompras,
            this.indTesoreria,
            this.indCobranzas,
            this.indPlanillas,
            this.idConcepto,
            this.codConcepto,
            this.descripcionDataGridViewTextBoxColumn,
            this.codCuentaAdm,
            this.codCuentaVen,
            this.codCuentaPro,
            this.codCuentaFin,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvConceptos.DataSource = this.bsConceptos;
            this.dgvConceptos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConceptos.EnableHeadersVisualStyles = false;
            this.dgvConceptos.Location = new System.Drawing.Point(0, 18);
            this.dgvConceptos.Name = "dgvConceptos";
            this.dgvConceptos.ReadOnly = true;
            this.dgvConceptos.Size = new System.Drawing.Size(1178, 277);
            this.dgvConceptos.TabIndex = 250;
            this.dgvConceptos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConceptos_CellDoubleClick);
            // 
            // indCompras
            // 
            this.indCompras.DataPropertyName = "indCompras";
            this.indCompras.HeaderText = "Comp.";
            this.indCompras.Name = "indCompras";
            this.indCompras.ReadOnly = true;
            this.indCompras.ToolTipText = "Compras";
            this.indCompras.Width = 45;
            // 
            // indTesoreria
            // 
            this.indTesoreria.DataPropertyName = "indTesoreria";
            this.indTesoreria.HeaderText = "Teso.";
            this.indTesoreria.Name = "indTesoreria";
            this.indTesoreria.ReadOnly = true;
            this.indTesoreria.ToolTipText = "Tesoreria";
            this.indTesoreria.Width = 40;
            // 
            // indCobranzas
            // 
            this.indCobranzas.DataPropertyName = "indCobranzas";
            this.indCobranzas.HeaderText = "Cobr.";
            this.indCobranzas.Name = "indCobranzas";
            this.indCobranzas.ReadOnly = true;
            this.indCobranzas.ToolTipText = "Cobranzas";
            this.indCobranzas.Width = 40;
            // 
            // indPlanillas
            // 
            this.indPlanillas.DataPropertyName = "indPlanillas";
            this.indPlanillas.HeaderText = "Plan.";
            this.indPlanillas.Name = "indPlanillas";
            this.indPlanillas.ReadOnly = true;
            this.indPlanillas.ToolTipText = "Planillas/Asistencia";
            this.indPlanillas.Width = 40;
            // 
            // idConcepto
            // 
            this.idConcepto.DataPropertyName = "idConcepto";
            this.idConcepto.HeaderText = "ID.";
            this.idConcepto.Name = "idConcepto";
            this.idConcepto.ReadOnly = true;
            this.idConcepto.Visible = false;
            this.idConcepto.Width = 50;
            // 
            // codConcepto
            // 
            this.codConcepto.DataPropertyName = "codConcepto";
            this.codConcepto.HeaderText = "Código";
            this.codConcepto.Name = "codConcepto";
            this.codConcepto.ReadOnly = true;
            this.codConcepto.Width = 70;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn.Width = 320;
            // 
            // codCuentaAdm
            // 
            this.codCuentaAdm.DataPropertyName = "codCuentaAdm";
            this.codCuentaAdm.HeaderText = "Cod. Cuenta Adm.";
            this.codCuentaAdm.Name = "codCuentaAdm";
            this.codCuentaAdm.ReadOnly = true;
            this.codCuentaAdm.Width = 120;
            // 
            // codCuentaVen
            // 
            this.codCuentaVen.DataPropertyName = "codCuentaVen";
            this.codCuentaVen.HeaderText = "Cod. Cuenta Ven.";
            this.codCuentaVen.Name = "codCuentaVen";
            this.codCuentaVen.ReadOnly = true;
            this.codCuentaVen.Width = 120;
            // 
            // codCuentaPro
            // 
            this.codCuentaPro.DataPropertyName = "codCuentaPro";
            this.codCuentaPro.HeaderText = "Cod. Cuenta Pro.";
            this.codCuentaPro.Name = "codCuentaPro";
            this.codCuentaPro.ReadOnly = true;
            this.codCuentaPro.Width = 120;
            // 
            // codCuentaFin
            // 
            this.codCuentaFin.DataPropertyName = "codCuentaFin";
            this.codCuentaFin.HeaderText = "Cod. Cuenta Fin";
            this.codCuentaFin.Name = "codCuentaFin";
            this.codCuentaFin.ReadOnly = true;
            this.codCuentaFin.Width = 120;
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
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 120;
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
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
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
            this.btCopiar.Location = new System.Drawing.Point(1075, 362);
            this.btCopiar.Name = "btCopiar";
            this.btCopiar.Size = new System.Drawing.Size(101, 25);
            this.btCopiar.TabIndex = 610;
            this.btCopiar.Text = "Copiar de";
            this.btCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCopiar.UseVisualStyleBackColor = true;
            this.btCopiar.Click += new System.EventHandler(this.btCopiar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(782, 18);
            this.lblTitulo.TabIndex = 1582;
            this.lblTitulo.Text = "Opciones de Búsqueda";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(1178, 18);
            this.lblRegistros.TabIndex = 1582;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoConceptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 392);
            this.Controls.Add(this.btCopiar);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Name = "frmListadoConceptos";
            this.Text = "Listado de Conceptos Varios - Compras";
            this.Load += new System.EventHandler(this.frmListadoConceptos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsConceptos)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvConceptos;
        //private System.Windows.Forms.DataGridViewTextBoxColumn idGastosServicioDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn codGastosServicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsConceptos;
        private ControlesWinForm.SuperTextBox txtDesConcepto;
        private System.Windows.Forms.Button btCopiar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indCompras;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indTesoreria;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indCobranzas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indPlanillas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaAdm;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaVen;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblRegistros;
    }
}