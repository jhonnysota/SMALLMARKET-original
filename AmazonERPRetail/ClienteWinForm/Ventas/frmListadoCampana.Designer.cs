namespace ClienteWinForm.Ventas
{
    partial class frmListadoCampana
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsCampana = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.idCampanaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.focusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.estadoPrecioDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.estadoDirectorasDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mostrarPedWebDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mostrarDevWebDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.esDiferidoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.estadoActivarArticuloDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsCampana)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // bsCampana
            // 
            this.bsCampana.DataSource = typeof(Entidades.Ventas.CampanaE);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvDocumentos);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 296);
            this.panel1.TabIndex = 78;
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AutoGenerateColumns = false;
            this.dgvDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCampanaDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.inicioDataGridViewTextBoxColumn,
            this.finDataGridViewTextBoxColumn,
            this.focusDataGridViewCheckBoxColumn,
            this.estadoPrecioDataGridViewCheckBoxColumn,
            this.estadoDirectorasDataGridViewCheckBoxColumn,
            this.mostrarPedWebDataGridViewCheckBoxColumn,
            this.mostrarDevWebDataGridViewCheckBoxColumn,
            this.esDiferidoDataGridViewCheckBoxColumn,
            this.estadoActivarArticuloDataGridViewCheckBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvDocumentos.DataSource = this.bsCampana;
            this.dgvDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentos.EnableHeadersVisualStyles = false;
            this.dgvDocumentos.Location = new System.Drawing.Point(0, 18);
            this.dgvDocumentos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.ReadOnly = true;
            this.dgvDocumentos.RowTemplate.Height = 24;
            this.dgvDocumentos.Size = new System.Drawing.Size(797, 276);
            this.dgvDocumentos.TabIndex = 80;
            this.dgvDocumentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellDoubleClick);
            // 
            // idCampanaDataGridViewTextBoxColumn
            // 
            this.idCampanaDataGridViewTextBoxColumn.DataPropertyName = "idCampana";
            this.idCampanaDataGridViewTextBoxColumn.HeaderText = "ID ";
            this.idCampanaDataGridViewTextBoxColumn.Name = "idCampanaDataGridViewTextBoxColumn";
            this.idCampanaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inicioDataGridViewTextBoxColumn
            // 
            this.inicioDataGridViewTextBoxColumn.DataPropertyName = "Inicio";
            this.inicioDataGridViewTextBoxColumn.HeaderText = "Inicio";
            this.inicioDataGridViewTextBoxColumn.Name = "inicioDataGridViewTextBoxColumn";
            this.inicioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // finDataGridViewTextBoxColumn
            // 
            this.finDataGridViewTextBoxColumn.DataPropertyName = "Fin";
            this.finDataGridViewTextBoxColumn.HeaderText = "Fin";
            this.finDataGridViewTextBoxColumn.Name = "finDataGridViewTextBoxColumn";
            this.finDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // focusDataGridViewCheckBoxColumn
            // 
            this.focusDataGridViewCheckBoxColumn.DataPropertyName = "Focus";
            this.focusDataGridViewCheckBoxColumn.HeaderText = "Focus";
            this.focusDataGridViewCheckBoxColumn.Name = "focusDataGridViewCheckBoxColumn";
            this.focusDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // estadoPrecioDataGridViewCheckBoxColumn
            // 
            this.estadoPrecioDataGridViewCheckBoxColumn.DataPropertyName = "EstadoPrecio";
            this.estadoPrecioDataGridViewCheckBoxColumn.HeaderText = "Estado Precio";
            this.estadoPrecioDataGridViewCheckBoxColumn.Name = "estadoPrecioDataGridViewCheckBoxColumn";
            this.estadoPrecioDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // estadoDirectorasDataGridViewCheckBoxColumn
            // 
            this.estadoDirectorasDataGridViewCheckBoxColumn.DataPropertyName = "EstadoDirectoras";
            this.estadoDirectorasDataGridViewCheckBoxColumn.HeaderText = "Estado Directoras";
            this.estadoDirectorasDataGridViewCheckBoxColumn.Name = "estadoDirectorasDataGridViewCheckBoxColumn";
            this.estadoDirectorasDataGridViewCheckBoxColumn.ReadOnly = true;
            this.estadoDirectorasDataGridViewCheckBoxColumn.Width = 125;
            // 
            // mostrarPedWebDataGridViewCheckBoxColumn
            // 
            this.mostrarPedWebDataGridViewCheckBoxColumn.DataPropertyName = "MostrarPedWeb";
            this.mostrarPedWebDataGridViewCheckBoxColumn.HeaderText = "Ped. Web";
            this.mostrarPedWebDataGridViewCheckBoxColumn.Name = "mostrarPedWebDataGridViewCheckBoxColumn";
            this.mostrarPedWebDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // mostrarDevWebDataGridViewCheckBoxColumn
            // 
            this.mostrarDevWebDataGridViewCheckBoxColumn.DataPropertyName = "MostrarDevWeb";
            this.mostrarDevWebDataGridViewCheckBoxColumn.HeaderText = "Dev.Web";
            this.mostrarDevWebDataGridViewCheckBoxColumn.Name = "mostrarDevWebDataGridViewCheckBoxColumn";
            this.mostrarDevWebDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // esDiferidoDataGridViewCheckBoxColumn
            // 
            this.esDiferidoDataGridViewCheckBoxColumn.DataPropertyName = "EsDiferido";
            this.esDiferidoDataGridViewCheckBoxColumn.HeaderText = "Es Diferido";
            this.esDiferidoDataGridViewCheckBoxColumn.Name = "esDiferidoDataGridViewCheckBoxColumn";
            this.esDiferidoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // estadoActivarArticuloDataGridViewCheckBoxColumn
            // 
            this.estadoActivarArticuloDataGridViewCheckBoxColumn.DataPropertyName = "EstadoActivarArticulo";
            this.estadoActivarArticuloDataGridViewCheckBoxColumn.HeaderText = "Activar Articulo";
            this.estadoActivarArticuloDataGridViewCheckBoxColumn.Name = "estadoActivarArticuloDataGridViewCheckBoxColumn";
            this.estadoActivarArticuloDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
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
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(797, 18);
            this.lblTitulo.TabIndex = 368;
            this.lblTitulo.Text = "Registros 0";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoCampana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(808, 304);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoCampana";
            this.Text = "Listado de Campañas";
            this.Activated += new System.EventHandler(this.frmListadoCampana_Activated);
            this.Load += new System.EventHandler(this.frmListadoCampana_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsCampana)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDocumentos;
        protected internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bsCampana;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCampanaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn focusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estadoPrecioDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estadoDirectorasDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mostrarPedWebDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mostrarDevWebDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn esDiferidoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estadoActivarArticuloDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblTitulo;
    }
}