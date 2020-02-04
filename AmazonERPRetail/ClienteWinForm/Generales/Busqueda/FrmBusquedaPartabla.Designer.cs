namespace ClienteWinForm.Generales.Busqueda
{
    partial class FrmBusquedaPartabla
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
            this.cbGruposParTabla = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.parTablaDataGridView = new System.Windows.Forms.DataGridView();
            this.parTablaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CkeckAgregar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parTablaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parTablaBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(453, 370);
            // 
            // btnCanceñar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(559, 370);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(595, 22);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(372, 22);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.Text = "GRUPO :";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(73, 50);
            this.txtFiltro.Size = new System.Drawing.Size(339, 20);
            // 
            // gbResultados
            // 
            this.gbResultados.Location = new System.Drawing.Point(754, 370);
            this.gbResultados.Size = new System.Drawing.Size(27, 24);
            // 
            // cbGruposParTabla
            // 
            this.cbGruposParTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGruposParTabla.FormattingEnabled = true;
            this.cbGruposParTabla.Location = new System.Drawing.Point(73, 23);
            this.cbGruposParTabla.Name = "cbGruposParTabla";
            this.cbGruposParTabla.Size = new System.Drawing.Size(270, 21);
            this.cbGruposParTabla.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "FILTRO :";
            // 
            // parTablaDataGridView
            // 
            this.parTablaDataGridView.AllowUserToAddRows = false;
            this.parTablaDataGridView.AllowUserToDeleteRows = false;
            this.parTablaDataGridView.AllowUserToResizeRows = false;
            this.parTablaDataGridView.AutoGenerateColumns = false;
            this.parTablaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parTablaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.CkeckAgregar});
            this.parTablaDataGridView.DataSource = this.parTablaBindingSource;
            this.parTablaDataGridView.Location = new System.Drawing.Point(-1, 23);
            this.parTablaDataGridView.MultiSelect = false;
            this.parTablaDataGridView.Name = "parTablaDataGridView";
            this.parTablaDataGridView.RowHeadersVisible = false;
            this.parTablaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.parTablaDataGridView.Size = new System.Drawing.Size(658, 263);
            this.parTablaDataGridView.TabIndex = 0;
            this.parTablaDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.parTablaDataGridView_CellDoubleClick);
            // 
            // parTablaBindingSource
            // 
            this.parTablaBindingSource.DataSource = typeof(Entidades.Generales.ParTabla);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.parTablaDataGridView);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 287);
            this.panel1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SlateGray;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(657, 23);
            this.label4.TabIndex = 97;
            this.label4.Text = "Datos ParTabla";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IdParTabla";
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo:";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 160;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NemoTecnico";
            this.dataGridViewTextBoxColumn4.HeaderText = "NemoTecnico";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // CkeckAgregar
            // 
            this.CkeckAgregar.DataPropertyName = "CkeckAgregar";
            this.CkeckAgregar.HeaderText = "";
            this.CkeckAgregar.Name = "CkeckAgregar";
            this.CkeckAgregar.Width = 30;
            // 
            // FrmBusquedaPartabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 405);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbGruposParTabla);
            this.Name = "FrmBusquedaPartabla";
            this.Text = "BUSQUEDA DE PARTABLA ";
            this.Load += new System.EventHandler(this.FrmBusquedaPartabla_Load);
            this.Controls.SetChildIndex(this.cbGruposParTabla, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parTablaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parTablaBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource parTablaBindingSource;
        private System.Windows.Forms.ComboBox cbGruposParTabla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView parTablaDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CkeckAgregar;
    }
}