namespace ClienteWinForm.Seguridad
{
    partial class frmClonarTablas
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
            this.cboEmpresa1 = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtIdEmpresa = new System.Windows.Forms.TextBox();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvTablas = new System.Windows.Forms.DataGridView();
            this.checkDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTablas = new System.Windows.Forms.BindingSource(this.components);
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.cboSistemas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvTransferidos = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocialTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTransferidos = new System.Windows.Forms.BindingSource(this.components);
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.btTransferir = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTablas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransferidos)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboEmpresa1
            // 
            this.cboEmpresa1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresa1.FormattingEnabled = true;
            this.cboEmpresa1.Location = new System.Drawing.Point(16, 25);
            this.cboEmpresa1.Name = "cboEmpresa1";
            this.cboEmpresa1.Size = new System.Drawing.Size(409, 21);
            this.cboEmpresa1.TabIndex = 3;
            this.cboEmpresa1.SelectionChangeCommitted += new System.EventHandler(this.cboEmpresa1_SelectionChangeCommitted);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtRazonSocial);
            this.panel4.Controls.Add(this.txtIdEmpresa);
            this.panel4.Controls.Add(this.labelDegradado2);
            this.panel4.Location = new System.Drawing.Point(5, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 56);
            this.panel4.TabIndex = 358;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Location = new System.Drawing.Point(40, 26);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(397, 20);
            this.txtRazonSocial.TabIndex = 273;
            // 
            // txtIdEmpresa
            // 
            this.txtIdEmpresa.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtIdEmpresa.Enabled = false;
            this.txtIdEmpresa.Location = new System.Drawing.Point(10, 26);
            this.txtIdEmpresa.Name = "txtIdEmpresa";
            this.txtIdEmpresa.Size = new System.Drawing.Size(30, 20);
            this.txtIdEmpresa.TabIndex = 272;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(448, 20);
            this.labelDegradado2.TabIndex = 271;
            this.labelDegradado2.Text = "Empresa Principal";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvTablas);
            this.panel3.Controls.Add(this.labelDegradado1);
            this.panel3.Location = new System.Drawing.Point(4, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(451, 271);
            this.panel3.TabIndex = 360;
            // 
            // dgvTablas
            // 
            this.dgvTablas.AllowUserToAddRows = false;
            this.dgvTablas.AllowUserToDeleteRows = false;
            this.dgvTablas.AutoGenerateColumns = false;
            this.dgvTablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkDataGridViewCheckBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.ordenDataGridViewTextBoxColumn});
            this.dgvTablas.DataSource = this.bsTablas;
            this.dgvTablas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTablas.EnableHeadersVisualStyles = false;
            this.dgvTablas.Location = new System.Drawing.Point(0, 20);
            this.dgvTablas.Name = "dgvTablas";
            this.dgvTablas.Size = new System.Drawing.Size(449, 249);
            this.dgvTablas.TabIndex = 274;
            this.dgvTablas.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvTablas_CurrentCellDirtyStateChanged);
            // 
            // checkDataGridViewCheckBoxColumn
            // 
            this.checkDataGridViewCheckBoxColumn.DataPropertyName = "Check";
            this.checkDataGridViewCheckBoxColumn.HeaderText = "X";
            this.checkDataGridViewCheckBoxColumn.Name = "checkDataGridViewCheckBoxColumn";
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ordenDataGridViewTextBoxColumn
            // 
            this.ordenDataGridViewTextBoxColumn.DataPropertyName = "Orden";
            this.ordenDataGridViewTextBoxColumn.HeaderText = "Orden";
            this.ordenDataGridViewTextBoxColumn.Name = "ordenDataGridViewTextBoxColumn";
            this.ordenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsTablas
            // 
            this.bsTablas.DataSource = typeof(Entidades.Seguridad.ClonacionTablasE);
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(449, 20);
            this.labelDegradado1.TabIndex = 272;
            this.labelDegradado1.Text = "Tablas de BD";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSistemas
            // 
            this.cboSistemas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSistemas.FormattingEnabled = true;
            this.cboSistemas.Location = new System.Drawing.Point(60, 63);
            this.cboSistemas.Name = "cboSistemas";
            this.cboSistemas.Size = new System.Drawing.Size(215, 21);
            this.cboSistemas.TabIndex = 362;
            this.cboSistemas.SelectionChangeCommitted += new System.EventHandler(this.cboSistemas_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 361;
            this.label1.Text = "Sistemas";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvTransferidos);
            this.panel1.Controls.Add(this.labelDegradado3);
            this.panel1.Location = new System.Drawing.Point(520, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 271);
            this.panel1.TabIndex = 361;
            // 
            // dgvTransferidos
            // 
            this.dgvTransferidos.AllowUserToAddRows = false;
            this.dgvTransferidos.AllowUserToDeleteRows = false;
            this.dgvTransferidos.AutoGenerateColumns = false;
            this.dgvTransferidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar,
            this.Orden,
            this.descripcionDataGridViewTextBoxColumn1,
            this.RazonSocialTrans,
            this.RazonSocial});
            this.dgvTransferidos.DataSource = this.bsTransferidos;
            this.dgvTransferidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransferidos.EnableHeadersVisualStyles = false;
            this.dgvTransferidos.Location = new System.Drawing.Point(0, 20);
            this.dgvTransferidos.Name = "dgvTransferidos";
            this.dgvTransferidos.ReadOnly = true;
            this.dgvTransferidos.Size = new System.Drawing.Size(449, 249);
            this.dgvTransferidos.TabIndex = 274;
            this.dgvTransferidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransferidos_CellClick);
            this.dgvTransferidos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTransferidos_CellPainting);
            // 
            // Eliminar
            // 
            this.Eliminar.DataPropertyName = "Eliminar";
            this.Eliminar.HeaderText = "E.";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Text = "";
            this.Eliminar.ToolTipText = "Eliminar Información de Tabla";
            // 
            // Orden
            // 
            this.Orden.DataPropertyName = "Orden";
            this.Orden.HeaderText = "S.";
            this.Orden.Name = "Orden";
            this.Orden.ReadOnly = true;
            this.Orden.ToolTipText = "Secuencia para la eliminación de la información";
            // 
            // descripcionDataGridViewTextBoxColumn1
            // 
            this.descripcionDataGridViewTextBoxColumn1.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn1.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn1.Name = "descripcionDataGridViewTextBoxColumn1";
            this.descripcionDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // RazonSocialTrans
            // 
            this.RazonSocialTrans.DataPropertyName = "RazonSocialTrans";
            this.RazonSocialTrans.HeaderText = "Transferido a:";
            this.RazonSocialTrans.Name = "RazonSocialTrans";
            this.RazonSocialTrans.ReadOnly = true;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "De:";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            // 
            // bsTransferidos
            // 
            this.bsTransferidos.DataSource = typeof(Entidades.Seguridad.ClonacionTablasE);
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelDegradado3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(449, 20);
            this.labelDegradado3.TabIndex = 272;
            this.labelDegradado3.Text = "Tablas Transferidas";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelDegradado4);
            this.panel2.Controls.Add(this.cboEmpresa1);
            this.panel2.Location = new System.Drawing.Point(520, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 56);
            this.panel2.TabIndex = 359;
            // 
            // labelDegradado4
            // 
            this.labelDegradado4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado4.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelDegradado4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado4.ForeColor = System.Drawing.Color.White;
            this.labelDegradado4.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado4.Name = "labelDegradado4";
            this.labelDegradado4.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado4.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado4.Size = new System.Drawing.Size(448, 20);
            this.labelDegradado4.TabIndex = 271;
            this.labelDegradado4.Text = "Empresa a donde se transfiere";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btTransferir
            // 
            this.btTransferir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btTransferir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btTransferir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btTransferir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTransferir.Image = global::ClienteWinForm.Properties.Resources.Transfer;
            this.btTransferir.Location = new System.Drawing.Point(459, 180);
            this.btTransferir.Name = "btTransferir";
            this.btTransferir.Size = new System.Drawing.Size(57, 31);
            this.btTransferir.TabIndex = 363;
            this.btTransferir.UseVisualStyleBackColor = true;
            this.btTransferir.Click += new System.EventHandler(this.btTransferir_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn1.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Orden";
            this.dataGridViewTextBoxColumn2.HeaderText = "Orden";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "RazonSocialTrans";
            this.dataGridViewTextBoxColumn4.HeaderText = "Transferido a:";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "RazonSocial";
            this.dataGridViewTextBoxColumn5.HeaderText = "De:";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // frmClonarTablas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 363);
            this.Controls.Add(this.btTransferir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboSistemas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.MaximizeBox = false;
            this.Name = "frmClonarTablas";
            this.Text = "Clonar Tablas por Empresas";
            this.Load += new System.EventHandler(this.frmClonarTablas_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTablas)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransferidos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEmpresa1;
        private System.Windows.Forms.Panel panel4;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.BindingSource bsTablas;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvTablas;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtIdEmpresa;
        private System.Windows.Forms.ComboBox cboSistemas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvTransferidos;
        private System.Windows.Forms.BindingSource bsTransferidos;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.Panel panel2;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.Button btTransferir;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orden;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocialTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
    }
}