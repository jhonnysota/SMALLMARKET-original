namespace ClienteWinForm.Almacen
{
    partial class frmConsultaStockMensual
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.chkDiferencia = new System.Windows.Forms.CheckBox();
            this.chkCero = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboalmacen = new System.Windows.Forms.ComboBox();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvOperacion = new System.Windows.Forms.DataGridView();
            this.codArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contenido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockFisico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsStock = new System.Windows.Forms.BindingSource(this.components);
            this.lblLetras = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStock)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLetras);
            this.panel1.Controls.Add(this.checkedListBox1);
            this.panel1.Controls.Add(this.chkDiferencia);
            this.panel1.Controls.Add(this.chkCero);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboalmacen);
            this.panel1.Controls.Add(this.cboAño);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboMes);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 107);
            this.panel1.TabIndex = 293;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(81, 55);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(159, 49);
            this.checkedListBox1.TabIndex = 323;
            // 
            // chkDiferencia
            // 
            this.chkDiferencia.AutoSize = true;
            this.chkDiferencia.Checked = true;
            this.chkDiferencia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDiferencia.Location = new System.Drawing.Point(467, 62);
            this.chkDiferencia.Name = "chkDiferencia";
            this.chkDiferencia.Size = new System.Drawing.Size(93, 17);
            this.chkDiferencia.TabIndex = 321;
            this.chkDiferencia.Text = "Diferente de 0";
            this.chkDiferencia.UseVisualStyleBackColor = true;
            // 
            // chkCero
            // 
            this.chkCero.AutoSize = true;
            this.chkCero.Location = new System.Drawing.Point(467, 30);
            this.chkCero.Name = "chkCero";
            this.chkCero.Size = new System.Drawing.Size(79, 17);
            this.chkCero.TabIndex = 314;
            this.chkCero.Text = "Incluir Cero";
            this.chkCero.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(231, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 320;
            this.label5.Text = "Almacen";
            // 
            // cboalmacen
            // 
            this.cboalmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboalmacen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboalmacen.FormattingEnabled = true;
            this.cboalmacen.Location = new System.Drawing.Point(284, 28);
            this.cboalmacen.Name = "cboalmacen";
            this.cboalmacen.Size = new System.Drawing.Size(158, 21);
            this.cboalmacen.TabIndex = 318;
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(38, 28);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(64, 21);
            this.cboAño.TabIndex = 311;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 312;
            this.label4.Text = "Año";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 308;
            this.label1.Text = "Mes";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(136, 28);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(78, 21);
            this.cboMes.TabIndex = 271;
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 313;
            this.label2.Text = "Categoria";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvOperacion);
            this.panel2.Controls.Add(this.lblRegistros);
            this.panel2.Location = new System.Drawing.Point(12, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(803, 400);
            this.panel2.TabIndex = 314;
            // 
            // dgvOperacion
            // 
            this.dgvOperacion.AllowUserToAddRows = false;
            this.dgvOperacion.AllowUserToDeleteRows = false;
            this.dgvOperacion.AutoGenerateColumns = false;
            this.dgvOperacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOperacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codArticuloDataGridViewTextBoxColumn,
            this.desArticuloDataGridViewTextBoxColumn,
            this.loteDataGridViewTextBoxColumn,
            this.canStock,
            this.UMedida,
            this.Contenido,
            this.UPres,
            this.StockFisico});
            this.dgvOperacion.DataSource = this.bsStock;
            this.dgvOperacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOperacion.EnableHeadersVisualStyles = false;
            this.dgvOperacion.Location = new System.Drawing.Point(0, 18);
            this.dgvOperacion.Name = "dgvOperacion";
            this.dgvOperacion.ReadOnly = true;
            this.dgvOperacion.Size = new System.Drawing.Size(801, 380);
            this.dgvOperacion.TabIndex = 1;
            // 
            // codArticuloDataGridViewTextBoxColumn
            // 
            this.codArticuloDataGridViewTextBoxColumn.DataPropertyName = "codArticulo";
            this.codArticuloDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.codArticuloDataGridViewTextBoxColumn.Name = "codArticuloDataGridViewTextBoxColumn";
            this.codArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desArticuloDataGridViewTextBoxColumn
            // 
            this.desArticuloDataGridViewTextBoxColumn.DataPropertyName = "desArticulo";
            this.desArticuloDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.desArticuloDataGridViewTextBoxColumn.Name = "desArticuloDataGridViewTextBoxColumn";
            this.desArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loteDataGridViewTextBoxColumn
            // 
            this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
            this.loteDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
            this.loteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // canStock
            // 
            this.canStock.DataPropertyName = "canStock";
            this.canStock.HeaderText = "Stock";
            this.canStock.Name = "canStock";
            this.canStock.ReadOnly = true;
            // 
            // UMedida
            // 
            this.UMedida.DataPropertyName = "UMedida";
            this.UMedida.HeaderText = "Uni.Med";
            this.UMedida.Name = "UMedida";
            this.UMedida.ReadOnly = true;
            // 
            // Contenido
            // 
            this.Contenido.DataPropertyName = "Contenido";
            this.Contenido.HeaderText = "Contenido";
            this.Contenido.Name = "Contenido";
            this.Contenido.ReadOnly = true;
            // 
            // UPres
            // 
            this.UPres.DataPropertyName = "UPres";
            this.UPres.HeaderText = "U.Pres";
            this.UPres.Name = "UPres";
            this.UPres.ReadOnly = true;
            // 
            // StockFisico
            // 
            this.StockFisico.DataPropertyName = "StockFisico";
            this.StockFisico.HeaderText = "StockFisico";
            this.StockFisico.Name = "StockFisico";
            this.StockFisico.ReadOnly = true;
            // 
            // bsStock
            // 
            this.bsStock.DataSource = typeof(Entidades.Almacen.StockE);
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(573, 18);
            this.lblLetras.TabIndex = 1580;
            this.lblLetras.Text = "Parámetros";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(801, 18);
            this.lblRegistros.TabIndex = 1580;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmConsultaStockMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 537);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "frmConsultaStockMensual";
            this.Text = "Consultar Stock Mensual";
            this.Load += new System.EventHandler(this.frmConsultaStockMensual_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboalmacen;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMes;
        protected internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkDiferencia;
        private System.Windows.Forms.CheckBox chkCero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvOperacion;
        private System.Windows.Forms.BindingSource bsStock;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn canStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn UMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contenido;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPres;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockFisico;
        private System.Windows.Forms.Label lblLetras;
        private System.Windows.Forms.Label lblRegistros;
    }
}