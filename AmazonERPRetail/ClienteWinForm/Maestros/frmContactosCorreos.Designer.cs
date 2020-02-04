namespace ClienteWinForm.Maestros
{
    partial class frmContactosCorreos
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
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.lvCorreos = new System.Windows.Forms.ListView();
            this.Correos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nombres = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.cboGrupo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(361, 22);
            this.lblTitPnlBase.Text = "Lista";
            this.lblTitPnlBase.Visible = false;
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(378, 25);
            this.lblTituloPrincipal.Text = "Cuentas de Correo";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(351, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBase.Controls.Add(this.dgvContactos);
            this.pnlBase.Controls.Add(this.lvCorreos);
            this.pnlBase.Location = new System.Drawing.Point(8, 60);
            this.pnlBase.Size = new System.Drawing.Size(363, 356);
            this.pnlBase.Controls.SetChildIndex(this.lvCorreos, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.dgvContactos, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(178, 421);
            this.btCancelar.Visible = false;
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(54, 421);
            this.btAceptar.Visible = false;
            // 
            // dgvContactos
            // 
            this.dgvContactos.AllowUserToAddRows = false;
            this.dgvContactos.AllowUserToDeleteRows = false;
            this.dgvContactos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvContactos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContactos.EnableHeadersVisualStyles = false;
            this.dgvContactos.Location = new System.Drawing.Point(0, 22);
            this.dgvContactos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvContactos.MultiSelect = false;
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvContactos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvContactos.RowTemplate.Height = 24;
            this.dgvContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContactos.Size = new System.Drawing.Size(361, 332);
            this.dgvContactos.TabIndex = 251;
            this.dgvContactos.Visible = false;
            this.dgvContactos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContactos_CellDoubleClick);
            // 
            // lvCorreos
            // 
            this.lvCorreos.BackColor = System.Drawing.Color.White;
            this.lvCorreos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Correos,
            this.Nombres});
            this.lvCorreos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCorreos.ForeColor = System.Drawing.Color.Navy;
            this.lvCorreos.FullRowSelect = true;
            this.lvCorreos.HideSelection = false;
            this.lvCorreos.Location = new System.Drawing.Point(0, 0);
            this.lvCorreos.Name = "lvCorreos";
            this.lvCorreos.Size = new System.Drawing.Size(361, 354);
            this.lvCorreos.TabIndex = 0;
            this.lvCorreos.UseCompatibleStateImageBehavior = false;
            this.lvCorreos.View = System.Windows.Forms.View.Details;
            this.lvCorreos.Visible = false;
            this.lvCorreos.DoubleClick += new System.EventHandler(this.lvCorreos_DoubleClick);
            // 
            // Correos
            // 
            this.Correos.Text = "Correos";
            this.Correos.Width = 210;
            // 
            // Nombres
            // 
            this.Nombres.Text = "Apellidos y Nombres";
            this.Nombres.Width = 320;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 300;
            this.label1.Text = "Escoger Grupo";
            // 
            // cboGrupo
            // 
            this.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGrupo.FormattingEnabled = true;
            this.cboGrupo.Location = new System.Drawing.Point(99, 33);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(224, 21);
            this.cboGrupo.TabIndex = 299;
            // 
            // frmContactosCorreos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 423);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboGrupo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmContactosCorreos";
            this.Text = "Seleccionar Contacto";
            this.Load += new System.EventHandler(this.frmContactosCorreos_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.cboGrupo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContactos;
        private System.Windows.Forms.ListView lvCorreos;
        private System.Windows.Forms.ColumnHeader Correos;
        private System.Windows.Forms.ColumnHeader Nombres;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cboGrupo;
    }
}