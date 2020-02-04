namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarSucursalCliente
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
            this.dgvSucursales = new System.Windows.Forms.DataGridView();
            this.idDireccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionSucursalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionCompletaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(533, 20);
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(548, 25);
            this.lblTituloPrincipal.Text = "Busqueda de Sucursales de Clientes";
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Maestros.PersonaDireccionE);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(520, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.dgvSucursales);
            this.pnlBase.Location = new System.Drawing.Point(6, 29);
            this.pnlBase.Size = new System.Drawing.Size(535, 257);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.dgvSucursales, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(274, 294);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(150, 294);
            // 
            // dgvSucursales
            // 
            this.dgvSucursales.AllowUserToAddRows = false;
            this.dgvSucursales.AllowUserToDeleteRows = false;
            this.dgvSucursales.AutoGenerateColumns = false;
            this.dgvSucursales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSucursales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDireccionDataGridViewTextBoxColumn,
            this.descripcionSucursalDataGridViewTextBoxColumn,
            this.direccionCompletaDataGridViewTextBoxColumn});
            this.dgvSucursales.DataSource = this.bsBase;
            this.dgvSucursales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSucursales.EnableHeadersVisualStyles = false;
            this.dgvSucursales.Location = new System.Drawing.Point(0, 20);
            this.dgvSucursales.Name = "dgvSucursales";
            this.dgvSucursales.ReadOnly = true;
            this.dgvSucursales.Size = new System.Drawing.Size(533, 235);
            this.dgvSucursales.TabIndex = 251;
            this.dgvSucursales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSucursales_CellDoubleClick);
            this.dgvSucursales.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSucursales_KeyDown);
            // 
            // idDireccionDataGridViewTextBoxColumn
            // 
            this.idDireccionDataGridViewTextBoxColumn.DataPropertyName = "IdDireccion";
            this.idDireccionDataGridViewTextBoxColumn.HeaderText = "Id.";
            this.idDireccionDataGridViewTextBoxColumn.Name = "idDireccionDataGridViewTextBoxColumn";
            this.idDireccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionSucursalDataGridViewTextBoxColumn
            // 
            this.descripcionSucursalDataGridViewTextBoxColumn.DataPropertyName = "DescripcionSucursal";
            this.descripcionSucursalDataGridViewTextBoxColumn.HeaderText = "Sucursal";
            this.descripcionSucursalDataGridViewTextBoxColumn.Name = "descripcionSucursalDataGridViewTextBoxColumn";
            this.descripcionSucursalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direccionCompletaDataGridViewTextBoxColumn
            // 
            this.direccionCompletaDataGridViewTextBoxColumn.DataPropertyName = "DireccionCompleta";
            this.direccionCompletaDataGridViewTextBoxColumn.HeaderText = "Dirección";
            this.direccionCompletaDataGridViewTextBoxColumn.Name = "direccionCompletaDataGridViewTextBoxColumn";
            this.direccionCompletaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmBuscarSucursalCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 332);
            this.Name = "frmBuscarSucursalCliente";
            this.Text = "frmBuscarSucursalCliente";
            this.Load += new System.EventHandler(this.frmBuscarSucursalCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSucursales;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDireccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionSucursalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionCompletaDataGridViewTextBoxColumn;
    }
}