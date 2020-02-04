namespace ClienteWinForm.Busquedas
{
    partial class frmListarPersonasPorFiltro
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
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.cliDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.proDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.traDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.banDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rUCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionCompletaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(844, 326);
            this.btCancelar.Visible = false;
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(720, 326);
            this.btAceptar.Visible = false;
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(932, 20);
            this.lblTitPnlBase.Text = "Registros";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(948, 25);
            this.lblTituloPrincipal.TabIndex = 200;
            this.lblTituloPrincipal.Text = "Lista de Auxiliares";
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Maestros.Persona);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(919, 2);
            this.btCerrar.TabIndex = 100;
            // 
            // pnlBase
            // 
            this.pnlBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBase.Controls.Add(this.dgvPersonas);
            this.pnlBase.Location = new System.Drawing.Point(7, 54);
            this.pnlBase.Size = new System.Drawing.Size(934, 281);
            this.pnlBase.TabIndex = 1;
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.dgvPersonas, 0);
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.AllowUserToAddRows = false;
            this.dgvPersonas.AllowUserToDeleteRows = false;
            this.dgvPersonas.AutoGenerateColumns = false;
            this.dgvPersonas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cliDataGridViewCheckBoxColumn,
            this.proDataGridViewCheckBoxColumn,
            this.traDataGridViewCheckBoxColumn,
            this.banDataGridViewCheckBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.rUCDataGridViewTextBoxColumn,
            this.direccionCompletaDataGridViewTextBoxColumn,
            this.Correo});
            this.dgvPersonas.DataSource = this.bsBase;
            this.dgvPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonas.EnableHeadersVisualStyles = false;
            this.dgvPersonas.Location = new System.Drawing.Point(0, 20);
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.ReadOnly = true;
            this.dgvPersonas.Size = new System.Drawing.Size(932, 259);
            this.dgvPersonas.TabIndex = 2;
            this.dgvPersonas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonas_CellDoubleClick);
            this.dgvPersonas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPersonas_KeyDown);
            // 
            // cliDataGridViewCheckBoxColumn
            // 
            this.cliDataGridViewCheckBoxColumn.DataPropertyName = "Cli";
            this.cliDataGridViewCheckBoxColumn.HeaderText = "C.";
            this.cliDataGridViewCheckBoxColumn.Name = "cliDataGridViewCheckBoxColumn";
            this.cliDataGridViewCheckBoxColumn.ReadOnly = true;
            this.cliDataGridViewCheckBoxColumn.ToolTipText = "Si es Cliente";
            // 
            // proDataGridViewCheckBoxColumn
            // 
            this.proDataGridViewCheckBoxColumn.DataPropertyName = "Pro";
            this.proDataGridViewCheckBoxColumn.HeaderText = "P.";
            this.proDataGridViewCheckBoxColumn.Name = "proDataGridViewCheckBoxColumn";
            this.proDataGridViewCheckBoxColumn.ReadOnly = true;
            this.proDataGridViewCheckBoxColumn.ToolTipText = "Si es proveedor";
            // 
            // traDataGridViewCheckBoxColumn
            // 
            this.traDataGridViewCheckBoxColumn.DataPropertyName = "Tra";
            this.traDataGridViewCheckBoxColumn.HeaderText = "T.";
            this.traDataGridViewCheckBoxColumn.Name = "traDataGridViewCheckBoxColumn";
            this.traDataGridViewCheckBoxColumn.ReadOnly = true;
            this.traDataGridViewCheckBoxColumn.ToolTipText = "Si es trabajador";
            // 
            // banDataGridViewCheckBoxColumn
            // 
            this.banDataGridViewCheckBoxColumn.DataPropertyName = "Ban";
            this.banDataGridViewCheckBoxColumn.HeaderText = "B.";
            this.banDataGridViewCheckBoxColumn.Name = "banDataGridViewCheckBoxColumn";
            this.banDataGridViewCheckBoxColumn.ReadOnly = true;
            this.banDataGridViewCheckBoxColumn.ToolTipText = "Si es banco";
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "Razón Social";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rUCDataGridViewTextBoxColumn
            // 
            this.rUCDataGridViewTextBoxColumn.DataPropertyName = "RUC";
            this.rUCDataGridViewTextBoxColumn.HeaderText = "RUC";
            this.rUCDataGridViewTextBoxColumn.Name = "rUCDataGridViewTextBoxColumn";
            this.rUCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direccionCompletaDataGridViewTextBoxColumn
            // 
            this.direccionCompletaDataGridViewTextBoxColumn.DataPropertyName = "DireccionCompleta";
            this.direccionCompletaDataGridViewTextBoxColumn.HeaderText = "Dirección";
            this.direccionCompletaDataGridViewTextBoxColumn.Name = "direccionCompletaDataGridViewTextBoxColumn";
            this.direccionCompletaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Correo
            // 
            this.Correo.DataPropertyName = "Correo";
            this.Correo.HeaderText = "Correo";
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(11, 29);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(97, 20);
            this.txtRuc.TabIndex = 200;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuc.TextoVacio = "Ingrese Ruc";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(112, 29);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(426, 20);
            this.txtRazonSocial.TabIndex = 201;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "Ingrese Razon Social";
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            // 
            // frmListarPersonasPorFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 340);
            this.Controls.Add(this.txtRuc);
            this.Controls.Add(this.txtRazonSocial);
            this.Name = "frmListarPersonasPorFiltro";
            this.Text = "frmListarPersonasPorFiltro";
            this.Load += new System.EventHandler(this.frmListarPersonasPorFiltro_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.txtRazonSocial, 0);
            this.Controls.SetChildIndex(this.txtRuc, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cliDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn proDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn traDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn banDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rUCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionCompletaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
    }
}