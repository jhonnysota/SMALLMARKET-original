namespace ClienteWinForm.Almacen.Reportes
{
    partial class frmListadoArticuloServReporte
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvArticuloServ = new System.Windows.Forms.DataGridView();
            this.DesTipoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsArticuloServ = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new System.Windows.Forms.Label();
            this.chkIncluir = new System.Windows.Forms.CheckBox();
            this.txtBuscar = new ControlesWinForm.SuperTextBox();
            this.cboTipoArticulo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLetras = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticuloServ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsArticuloServ)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvArticuloServ);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(3, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 422);
            this.panel1.TabIndex = 256;
            // 
            // dgvArticuloServ
            // 
            this.dgvArticuloServ.AllowUserToAddRows = false;
            this.dgvArticuloServ.AllowUserToDeleteRows = false;
            this.dgvArticuloServ.AutoGenerateColumns = false;
            this.dgvArticuloServ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArticuloServ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticuloServ.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DesTipoArticulo,
            this.codArticuloDataGridViewTextBoxColumn,
            this.nomArticuloDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn});
            this.dgvArticuloServ.DataSource = this.bsArticuloServ;
            this.dgvArticuloServ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArticuloServ.EnableHeadersVisualStyles = false;
            this.dgvArticuloServ.Location = new System.Drawing.Point(0, 18);
            this.dgvArticuloServ.Name = "dgvArticuloServ";
            this.dgvArticuloServ.ReadOnly = true;
            this.dgvArticuloServ.Size = new System.Drawing.Size(870, 402);
            this.dgvArticuloServ.TabIndex = 248;
            this.dgvArticuloServ.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticuloServ_CellDoubleClick);
            // 
            // DesTipoArticulo
            // 
            this.DesTipoArticulo.DataPropertyName = "DesTipoArticulo";
            this.DesTipoArticulo.HeaderText = "Clase";
            this.DesTipoArticulo.Name = "DesTipoArticulo";
            this.DesTipoArticulo.ReadOnly = true;
            this.DesTipoArticulo.Width = 120;
            // 
            // codArticuloDataGridViewTextBoxColumn
            // 
            this.codArticuloDataGridViewTextBoxColumn.DataPropertyName = "codArticulo";
            this.codArticuloDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codArticuloDataGridViewTextBoxColumn.Name = "codArticuloDataGridViewTextBoxColumn";
            this.codArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            this.codArticuloDataGridViewTextBoxColumn.Width = 80;
            // 
            // nomArticuloDataGridViewTextBoxColumn
            // 
            this.nomArticuloDataGridViewTextBoxColumn.DataPropertyName = "nomArticulo";
            this.nomArticuloDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.nomArticuloDataGridViewTextBoxColumn.Name = "nomArticuloDataGridViewTextBoxColumn";
            this.nomArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomArticuloDataGridViewTextBoxColumn.Width = 350;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Stock";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Width = 60;
            // 
            // bsArticuloServ
            // 
            this.bsArticuloServ.DataSource = typeof(Entidades.Maestros.ArticuloServE);
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(870, 18);
            this.lblRegistros.TabIndex = 1573;
            this.lblRegistros.Text = "Registros";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIncluir
            // 
            this.chkIncluir.AutoSize = true;
            this.chkIncluir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncluir.Location = new System.Drawing.Point(705, 32);
            this.chkIncluir.Name = "chkIncluir";
            this.chkIncluir.Size = new System.Drawing.Size(160, 17);
            this.chkIncluir.TabIndex = 255;
            this.chkIncluir.Text = "Incluir Articulos de Baja";
            this.chkIncluir.UseVisualStyleBackColor = true;
            this.chkIncluir.Visible = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtBuscar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(263, 30);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(429, 21);
            this.txtBuscar.TabIndex = 253;
            this.txtBuscar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtBuscar.TextoVacio = "Ingrese nombre del Articulo";
            this.txtBuscar.Visible = false;
            // 
            // cboTipoArticulo
            // 
            this.cboTipoArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoArticulo.FormattingEnabled = true;
            this.cboTipoArticulo.Location = new System.Drawing.Point(56, 30);
            this.cboTipoArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoArticulo.Name = "cboTipoArticulo";
            this.cboTipoArticulo.Size = new System.Drawing.Size(199, 21);
            this.cboTipoArticulo.TabIndex = 257;
            this.cboTipoArticulo.SelectedIndexChanged += new System.EventHandler(this.cboTipoArticulo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 258;
            this.label2.Text = "Clase :";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblLetras);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtBuscar);
            this.panel2.Controls.Add(this.cboTipoArticulo);
            this.panel2.Controls.Add(this.chkIncluir);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(872, 63);
            this.panel2.TabIndex = 257;
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(870, 18);
            this.lblLetras.TabIndex = 1573;
            this.lblLetras.Text = "Parámetros de Búsqueda";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codArticulo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "codArticulo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "nomArticulo";
            this.dataGridViewTextBoxColumn2.HeaderText = "nomArticulo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "nomArticuloLargo";
            this.dataGridViewTextBoxColumn3.HeaderText = "nomArticuloLargo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "nomCorto";
            this.dataGridViewTextBoxColumn4.HeaderText = "nomCorto";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CodExterno";
            this.dataGridViewTextBoxColumn5.HeaderText = "CodExterno";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // frmListadoArticuloServReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 494);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoArticuloServReporte";
            this.Text = "Reporte Articulos";
            this.Load += new System.EventHandler(this.frmListadoArticuloServ_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticuloServ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsArticuloServ)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlesWinForm.SuperTextBox txtBuscar;
        private System.Windows.Forms.CheckBox chkIncluir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvArticuloServ;
        private System.Windows.Forms.BindingSource bsArticuloServ;
        private System.Windows.Forms.ComboBox cboTipoArticulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesTipoArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblLetras;
    }
}