namespace ClienteWinForm.Contabilidad
{
    partial class frmListadoEEFFItemHistorico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.secItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoTabla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldosolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldodolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsEEFFItemHistorico = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.cboEEFF = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new MyLabelG.LabelDegradado();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEEFFItemHistorico)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvDocumentos);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(3, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 329);
            this.panel1.TabIndex = 257;
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AutoGenerateColumns = false;
            this.dgvDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.secItem,
            this.desItem,
            this.TipoTabla,
            this.saldosolDataGridViewTextBoxColumn,
            this.saldodolDataGridViewTextBoxColumn});
            this.dgvDocumentos.DataSource = this.bsEEFFItemHistorico;
            this.dgvDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentos.EnableHeadersVisualStyles = false;
            this.dgvDocumentos.Location = new System.Drawing.Point(0, 23);
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.ReadOnly = true;
            this.dgvDocumentos.Size = new System.Drawing.Size(786, 304);
            this.dgvDocumentos.TabIndex = 248;
            this.dgvDocumentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellDoubleClick);
            this.dgvDocumentos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocumentos_CellFormatting);
            // 
            // secItem
            // 
            this.secItem.DataPropertyName = "secItem";
            this.secItem.HeaderText = "Item";
            this.secItem.Name = "secItem";
            this.secItem.ReadOnly = true;
            this.secItem.Width = 60;
            // 
            // desItem
            // 
            this.desItem.DataPropertyName = "desItem";
            this.desItem.HeaderText = "Descripcion Item";
            this.desItem.Name = "desItem";
            this.desItem.ReadOnly = true;
            this.desItem.Width = 380;
            // 
            // TipoTabla
            // 
            this.TipoTabla.DataPropertyName = "TipoTabla";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TipoTabla.DefaultCellStyle = dataGridViewCellStyle7;
            this.TipoTabla.HeaderText = "Tipo Tabla";
            this.TipoTabla.Name = "TipoTabla";
            this.TipoTabla.ReadOnly = true;
            // 
            // saldosolDataGridViewTextBoxColumn
            // 
            this.saldosolDataGridViewTextBoxColumn.DataPropertyName = "saldo_sol";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.saldosolDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.saldosolDataGridViewTextBoxColumn.HeaderText = "Soles";
            this.saldosolDataGridViewTextBoxColumn.Name = "saldosolDataGridViewTextBoxColumn";
            this.saldosolDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saldodolDataGridViewTextBoxColumn
            // 
            this.saldodolDataGridViewTextBoxColumn.DataPropertyName = "saldo_dol";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.saldodolDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.saldodolDataGridViewTextBoxColumn.HeaderText = "Dolares";
            this.saldodolDataGridViewTextBoxColumn.Name = "saldodolDataGridViewTextBoxColumn";
            this.saldodolDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsEEFFItemHistorico
            // 
            this.bsEEFFItemHistorico.DataSource = typeof(Entidades.Contabilidad.EEFFItemHistoricoE);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(786, 23);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Registros";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cboAnio);
            this.panel2.Controls.Add(this.cboEEFF);
            this.panel2.Controls.Add(this.lblTitulo);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(3, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 65);
            this.panel2.TabIndex = 1106;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(274, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 506;
            this.label6.Text = "Año";
            // 
            // cboAnio
            // 
            this.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(305, 27);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(82, 21);
            this.cboAnio.TabIndex = 505;
            // 
            // cboEEFF
            // 
            this.cboEEFF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEEFF.DropDownWidth = 110;
            this.cboEEFF.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEEFF.FormattingEnabled = true;
            this.cboEEFF.Location = new System.Drawing.Point(46, 28);
            this.cboEEFF.Margin = new System.Windows.Forms.Padding(2);
            this.cboEEFF.Name = "cboEEFF";
            this.cboEEFF.Size = new System.Drawing.Size(224, 21);
            this.cboEEFF.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblTitulo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTitulo.Size = new System.Drawing.Size(401, 21);
            this.lblTitulo.TabIndex = 253;
            this.lblTitulo.Text = "Datos Principales";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "EEFF";
            // 
            // frmListadoEEFFItemHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 399);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoEEFFItemHistorico";
            this.Text = "Listado Estados Financieros Item Histórico";
            this.Activated += new System.EventHandler(this.frmListadoEEFFItemHistorico_Activated);
            this.Load += new System.EventHandler(this.frmListadoEEFFItemHistorico_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEEFFItemHistorico)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDocumentos;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsEEFFItemHistorico;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboEEFF;
        private MyLabelG.LabelDegradado lblTitulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.DataGridViewTextBoxColumn secItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn desItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoTabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldosolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldodolDataGridViewTextBoxColumn;
    }
}