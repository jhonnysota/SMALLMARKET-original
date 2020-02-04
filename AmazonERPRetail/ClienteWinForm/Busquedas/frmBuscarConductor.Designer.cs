namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarConductor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvConductores = new System.Windows.Forms.DataGridView();
            this.idConductorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.licenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomResumidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtConductor = new ControlesWinForm.SuperTextBox();
            this.rbLicencia = new System.Windows.Forms.RadioButton();
            this.rbNombres = new System.Windows.Forms.RadioButton();
            this.lblLetras = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConductores)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Ventas.TransporteConductoresE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(154, 320);
            this.btnAceptar.Size = new System.Drawing.Size(100, 23);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(258, 320);
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(1068, 82);
            this.btnBuscar.Visible = false;
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(875, 78);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(576, 81);
            this.label1.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(576, 104);
            this.txtFiltro.Visible = false;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvConductores);
            this.gbResultados.Location = new System.Drawing.Point(3, 85);
            this.gbResultados.Size = new System.Drawing.Size(463, 229);
            // 
            // dgvConductores
            // 
            this.dgvConductores.AllowUserToAddRows = false;
            this.dgvConductores.AllowUserToDeleteRows = false;
            this.dgvConductores.AutoGenerateColumns = false;
            this.dgvConductores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConductores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idConductorDataGridViewTextBoxColumn,
            this.licenciaDataGridViewTextBoxColumn,
            this.nombresDataGridViewTextBoxColumn,
            this.nomResumidoDataGridViewTextBoxColumn});
            this.dgvConductores.DataSource = this.bsBase;
            this.dgvConductores.EnableHeadersVisualStyles = false;
            this.dgvConductores.Location = new System.Drawing.Point(5, 15);
            this.dgvConductores.Margin = new System.Windows.Forms.Padding(2);
            this.dgvConductores.Name = "dgvConductores";
            this.dgvConductores.ReadOnly = true;
            this.dgvConductores.RowTemplate.Height = 24;
            this.dgvConductores.Size = new System.Drawing.Size(451, 208);
            this.dgvConductores.TabIndex = 3;
            this.dgvConductores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConductores_CellDoubleClick);
            this.dgvConductores.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvConductores_CellFormatting);
            this.dgvConductores.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvConductores_CellPainting);
            // 
            // idConductorDataGridViewTextBoxColumn
            // 
            this.idConductorDataGridViewTextBoxColumn.DataPropertyName = "idConductor";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idConductorDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.idConductorDataGridViewTextBoxColumn.HeaderText = "Cód.";
            this.idConductorDataGridViewTextBoxColumn.Name = "idConductorDataGridViewTextBoxColumn";
            this.idConductorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // licenciaDataGridViewTextBoxColumn
            // 
            this.licenciaDataGridViewTextBoxColumn.DataPropertyName = "Licencia";
            this.licenciaDataGridViewTextBoxColumn.HeaderText = "Licencia";
            this.licenciaDataGridViewTextBoxColumn.Name = "licenciaDataGridViewTextBoxColumn";
            this.licenciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombresDataGridViewTextBoxColumn
            // 
            this.nombresDataGridViewTextBoxColumn.DataPropertyName = "Nombres";
            this.nombresDataGridViewTextBoxColumn.HeaderText = "Nombres Completos";
            this.nombresDataGridViewTextBoxColumn.Name = "nombresDataGridViewTextBoxColumn";
            this.nombresDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomResumidoDataGridViewTextBoxColumn
            // 
            this.nomResumidoDataGridViewTextBoxColumn.DataPropertyName = "nomResumido";
            this.nomResumidoDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nomResumidoDataGridViewTextBoxColumn.Name = "nomResumidoDataGridViewTextBoxColumn";
            this.nomResumidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLetras);
            this.panel1.Controls.Add(this.txtConductor);
            this.panel1.Controls.Add(this.rbLicencia);
            this.panel1.Controls.Add(this.rbNombres);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 79);
            this.panel1.TabIndex = 10;
            // 
            // txtConductor
            // 
            this.txtConductor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtConductor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtConductor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConductor.Location = new System.Drawing.Point(17, 48);
            this.txtConductor.Name = "txtConductor";
            this.txtConductor.Size = new System.Drawing.Size(407, 21);
            this.txtConductor.TabIndex = 250;
            this.txtConductor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtConductor.TextoVacio = "Ingrese Apellidos y Nombre o Licencia";
            this.txtConductor.TextChanged += new System.EventHandler(this.txtConductor_TextChanged);
            this.txtConductor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConductor_KeyDown);
            // 
            // rbLicencia
            // 
            this.rbLicencia.AutoSize = true;
            this.rbLicencia.Location = new System.Drawing.Point(158, 26);
            this.rbLicencia.Name = "rbLicencia";
            this.rbLicencia.Size = new System.Drawing.Size(65, 17);
            this.rbLicencia.TabIndex = 10;
            this.rbLicencia.Text = "Licencia";
            this.rbLicencia.UseVisualStyleBackColor = true;
            // 
            // rbNombres
            // 
            this.rbNombres.AutoSize = true;
            this.rbNombres.Checked = true;
            this.rbNombres.Location = new System.Drawing.Point(19, 26);
            this.rbNombres.Name = "rbNombres";
            this.rbNombres.Size = new System.Drawing.Size(120, 17);
            this.rbNombres.TabIndex = 8;
            this.rbNombres.TabStop = true;
            this.rbNombres.Text = "Apellidos y Nombres";
            this.rbNombres.UseVisualStyleBackColor = true;
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(463, 18);
            this.lblLetras.TabIndex = 1573;
            this.lblLetras.Text = "Parámetros de Búsqueda";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBuscarConductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 348);
            this.Controls.Add(this.panel1);
            this.Name = "frmBuscarConductor";
            this.Text = "Buscar Conductores";
            this.Load += new System.EventHandler(this.frmBuscarConductor_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConductores)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConductores;
        private System.Windows.Forms.DataGridViewTextBoxColumn idConductorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn licenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomResumidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private ControlesWinForm.SuperTextBox txtConductor;
        private System.Windows.Forms.RadioButton rbLicencia;
        private System.Windows.Forms.RadioButton rbNombres;
        private System.Windows.Forms.Label lblLetras;
    }
}