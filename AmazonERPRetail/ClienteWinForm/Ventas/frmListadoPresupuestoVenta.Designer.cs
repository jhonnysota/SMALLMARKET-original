namespace ClienteWinForm.Ventas
{
    partial class frmListadoPresupuestoVenta
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
            this.bsPresupuestoVenta = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvRetencion = new System.Windows.Forms.DataGridView();
            this.anioPresupuestoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipoArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMonedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsPresupuestoVenta)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetencion)).BeginInit();
            this.SuspendLayout();
            // 
            // bsPresupuestoVenta
            // 
            this.bsPresupuestoVenta.DataSource = typeof(Entidades.Ventas.PresupuestoVentaE);
            this.bsPresupuestoVenta.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsPresupuestoVenta_ListChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboAnio);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 62);
            this.panel1.TabIndex = 360;
            // 
            // cboAnio
            // 
            this.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(44, 29);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(95, 21);
            this.cboAnio.TabIndex = 313;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 314;
            this.label4.Text = "Año";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvRetencion);
            this.panel2.Controls.Add(this.LblTitulo);
            this.panel2.Location = new System.Drawing.Point(3, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 269);
            this.panel2.TabIndex = 359;
            // 
            // dgvRetencion
            // 
            this.dgvRetencion.AllowUserToAddRows = false;
            this.dgvRetencion.AllowUserToDeleteRows = false;
            this.dgvRetencion.AutoGenerateColumns = false;
            this.dgvRetencion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRetencion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRetencion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.anioPresupuestoDataGridViewTextBoxColumn1,
            this.vendedorDataGridViewTextBoxColumn,
            this.desTipoArticuloDataGridViewTextBoxColumn,
            this.desMonedaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn1,
            this.fechaRegistroDataGridViewTextBoxColumn1,
            this.usuarioModificacionDataGridViewTextBoxColumn1,
            this.fechaModificacionDataGridViewTextBoxColumn1});
            this.dgvRetencion.DataSource = this.bsPresupuestoVenta;
            this.dgvRetencion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRetencion.EnableHeadersVisualStyles = false;
            this.dgvRetencion.Location = new System.Drawing.Point(0, 18);
            this.dgvRetencion.Name = "dgvRetencion";
            this.dgvRetencion.ReadOnly = true;
            this.dgvRetencion.Size = new System.Drawing.Size(671, 249);
            this.dgvRetencion.TabIndex = 250;
            this.dgvRetencion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPresupuesto_CellDoubleClick);
            // 
            // anioPresupuestoDataGridViewTextBoxColumn1
            // 
            this.anioPresupuestoDataGridViewTextBoxColumn1.DataPropertyName = "AnioPresupuesto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.anioPresupuestoDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.anioPresupuestoDataGridViewTextBoxColumn1.HeaderText = "Año";
            this.anioPresupuestoDataGridViewTextBoxColumn1.Name = "anioPresupuestoDataGridViewTextBoxColumn1";
            this.anioPresupuestoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.anioPresupuestoDataGridViewTextBoxColumn1.Width = 50;
            // 
            // vendedorDataGridViewTextBoxColumn
            // 
            this.vendedorDataGridViewTextBoxColumn.DataPropertyName = "Vendedor";
            this.vendedorDataGridViewTextBoxColumn.HeaderText = "Vendedor";
            this.vendedorDataGridViewTextBoxColumn.Name = "vendedorDataGridViewTextBoxColumn";
            this.vendedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendedorDataGridViewTextBoxColumn.Width = 200;
            // 
            // desTipoArticuloDataGridViewTextBoxColumn
            // 
            this.desTipoArticuloDataGridViewTextBoxColumn.DataPropertyName = "DesTipoArticulo";
            this.desTipoArticuloDataGridViewTextBoxColumn.HeaderText = "Tip.Articulo";
            this.desTipoArticuloDataGridViewTextBoxColumn.Name = "desTipoArticuloDataGridViewTextBoxColumn";
            this.desTipoArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            this.desTipoArticuloDataGridViewTextBoxColumn.Width = 150;
            // 
            // desMonedaDataGridViewTextBoxColumn
            // 
            this.desMonedaDataGridViewTextBoxColumn.DataPropertyName = "DesMoneda";
            this.desMonedaDataGridViewTextBoxColumn.HeaderText = "Mon.";
            this.desMonedaDataGridViewTextBoxColumn.Name = "desMonedaDataGridViewTextBoxColumn";
            this.desMonedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.desMonedaDataGridViewTextBoxColumn.Width = 40;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn1
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn1.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn1.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn1.Name = "usuarioRegistroDataGridViewTextBoxColumn1";
            this.usuarioRegistroDataGridViewTextBoxColumn1.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn1.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn1
            // 
            this.fechaRegistroDataGridViewTextBoxColumn1.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaRegistroDataGridViewTextBoxColumn1.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn1.Name = "fechaRegistroDataGridViewTextBoxColumn1";
            this.fechaRegistroDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn1.Width = 130;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn1
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn1.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn1.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn1.Name = "usuarioModificacionDataGridViewTextBoxColumn1";
            this.usuarioModificacionDataGridViewTextBoxColumn1.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn1.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn1
            // 
            this.fechaModificacionDataGridViewTextBoxColumn1.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaModificacionDataGridViewTextBoxColumn1.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn1.Name = "fechaModificacionDataGridViewTextBoxColumn1";
            this.fechaModificacionDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn1.Width = 130;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 18);
            this.label3.TabIndex = 367;
            this.label3.Text = "Parámetros";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(671, 18);
            this.LblTitulo.TabIndex = 367;
            this.LblTitulo.Text = "Registros 0";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoPresupuestoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 339);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmListadoPresupuestoVenta";
            this.Text = "Listado de Presupuestos de Venta";
            this.Load += new System.EventHandler(this.frmListadoPresupuestoVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPresupuestoVenta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetencion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bsPresupuestoVenta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvRetencion;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn anioPresupuestoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipoArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMonedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTitulo;
    }
}