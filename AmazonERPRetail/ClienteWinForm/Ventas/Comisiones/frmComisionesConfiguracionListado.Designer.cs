namespace ClienteWinForm.Ventas.Comisiones
{
    partial class frmComisionesConfiguracionListado
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
            this.bsComisionesConfiguracion = new System.Windows.Forms.BindingSource(this.components);
            this.panel9 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.idComisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreZonaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDegradado8 = new MyLabelG.LabelDegradado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsComisionesConfiguracion)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsComisionesConfiguracion
            // 
            this.bsComisionesConfiguracion.DataSource = typeof(Entidades.Ventas.ComisionesConfiguracionE);
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.dgvListado);
            this.panel9.Controls.Add(this.labelDegradado8);
            this.panel9.Location = new System.Drawing.Point(1, 69);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(715, 280);
            this.panel9.TabIndex = 287;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idComisionDataGridViewTextBoxColumn,
            this.nombreZonaDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.usuarioRegistraDataGridViewTextBoxColumn,
            this.fechaRegistraDataGridViewTextBoxColumn,
            this.usuarioModificaDataGridViewTextBoxColumn,
            this.fechaModificaDataGridViewTextBoxColumn});
            this.dgvListado.DataSource = this.bsComisionesConfiguracion;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListado.EnableHeadersVisualStyles = false;
            this.dgvListado.Location = new System.Drawing.Point(0, 23);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(713, 255);
            this.dgvListado.TabIndex = 250;
            this.dgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellDoubleClick);
            // 
            // idComisionDataGridViewTextBoxColumn
            // 
            this.idComisionDataGridViewTextBoxColumn.DataPropertyName = "idComision";
            this.idComisionDataGridViewTextBoxColumn.HeaderText = "Código";
            this.idComisionDataGridViewTextBoxColumn.Name = "idComisionDataGridViewTextBoxColumn";
            this.idComisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.idComisionDataGridViewTextBoxColumn.Width = 50;
            // 
            // nombreZonaDataGridViewTextBoxColumn
            // 
            this.nombreZonaDataGridViewTextBoxColumn.DataPropertyName = "NombreZona";
            this.nombreZonaDataGridViewTextBoxColumn.HeaderText = "Zona";
            this.nombreZonaDataGridViewTextBoxColumn.Name = "nombreZonaDataGridViewTextBoxColumn";
            this.nombreZonaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreZonaDataGridViewTextBoxColumn.Width = 350;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDataGridViewTextBoxColumn.Width = 80;
            // 
            // usuarioRegistraDataGridViewTextBoxColumn
            // 
            this.usuarioRegistraDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistra";
            this.usuarioRegistraDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistraDataGridViewTextBoxColumn.Name = "usuarioRegistraDataGridViewTextBoxColumn";
            this.usuarioRegistraDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistraDataGridViewTextBoxColumn.Width = 120;
            // 
            // fechaRegistraDataGridViewTextBoxColumn
            // 
            this.fechaRegistraDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistra";
            this.fechaRegistraDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistraDataGridViewTextBoxColumn.Name = "fechaRegistraDataGridViewTextBoxColumn";
            this.fechaRegistraDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistraDataGridViewTextBoxColumn.Width = 120;
            // 
            // usuarioModificaDataGridViewTextBoxColumn
            // 
            this.usuarioModificaDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModifica";
            this.usuarioModificaDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificaDataGridViewTextBoxColumn.Name = "usuarioModificaDataGridViewTextBoxColumn";
            this.usuarioModificaDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificaDataGridViewTextBoxColumn.Width = 120;
            // 
            // fechaModificaDataGridViewTextBoxColumn
            // 
            this.fechaModificaDataGridViewTextBoxColumn.DataPropertyName = "FechaModifica";
            this.fechaModificaDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificaDataGridViewTextBoxColumn.Name = "fechaModificaDataGridViewTextBoxColumn";
            this.fechaModificaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificaDataGridViewTextBoxColumn.Width = 120;
            // 
            // labelDegradado8
            // 
            this.labelDegradado8.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado8.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado8.ForeColor = System.Drawing.Color.White;
            this.labelDegradado8.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado8.Name = "labelDegradado8";
            this.labelDegradado8.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado8.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado8.Size = new System.Drawing.Size(713, 23);
            this.labelDegradado8.TabIndex = 249;
            this.labelDegradado8.Text = "Zona Registradas";
            this.labelDegradado8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboPeriodo);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 63);
            this.panel1.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 344;
            this.label1.Text = "Del Periodo :";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Location = new System.Drawing.Point(72, 29);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(158, 21);
            this.cboPeriodo.TabIndex = 345;
            this.cboPeriodo.SelectionChangeCommitted += new System.EventHandler(this.cboPeriodo_SelectionChangeCommitted);
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(713, 20);
            this.labelDegradado1.TabIndex = 274;
            this.labelDegradado1.Text = "Filtro de Busquedad";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(237, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nombre Zona :";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(319, 30);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(379, 20);
            this.txtBuscar.TabIndex = 0;
            // 
            // frmComisionesConfiguracionListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 350);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmComisionesConfiguracionListado";
            this.Text = "Comisiones de Vendedores - Listado";
            this.Load += new System.EventHandler(this.frmComisionesConfiguracionListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsComisionesConfiguracion)).EndInit();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.BindingSource bsComisionesConfiguracion;
        private MyLabelG.LabelDegradado labelDegradado8;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreZonaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPeriodo;
    }
}