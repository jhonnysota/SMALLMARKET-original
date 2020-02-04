namespace ClienteWinForm.Contabilidad
{
    partial class frmListadoPresupuesto
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
            this.dgvPresupuesto = new System.Windows.Forms.DataGridView();
            this.bsPresupuesto = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPresupuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPresupuesto
            // 
            this.dgvPresupuesto.AllowUserToAddRows = false;
            this.dgvPresupuesto.AllowUserToDeleteRows = false;
            this.dgvPresupuesto.AutoGenerateColumns = false;
            this.dgvPresupuesto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPresupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresupuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descripcionDataGridViewTextBoxColumn,
            this.anioDataGridViewTextBoxColumn,
            this.NomMoneda});
            this.dgvPresupuesto.DataSource = this.bsPresupuesto;
            this.dgvPresupuesto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPresupuesto.EnableHeadersVisualStyles = false;
            this.dgvPresupuesto.Location = new System.Drawing.Point(0, 21);
            this.dgvPresupuesto.Name = "dgvPresupuesto";
            this.dgvPresupuesto.ReadOnly = true;
            this.dgvPresupuesto.Size = new System.Drawing.Size(467, 404);
            this.dgvPresupuesto.TabIndex = 252;
            this.dgvPresupuesto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPresupuesto_CellDoubleClick);
            this.dgvPresupuesto.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPresupuesto_CellFormatting);
            // 
            // bsPresupuesto
            // 
            this.bsPresupuesto.DataSource = typeof(Entidades.Contabilidad.PresupuestoE);
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
            this.lblRegistros.Size = new System.Drawing.Size(467, 21);
            this.lblRegistros.TabIndex = 251;
            this.lblRegistros.Text = "Documentos - 0 Registros";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn.Width = 200;
            // 
            // anioDataGridViewTextBoxColumn
            // 
            this.anioDataGridViewTextBoxColumn.DataPropertyName = "Anio";
            this.anioDataGridViewTextBoxColumn.HeaderText = "Anio";
            this.anioDataGridViewTextBoxColumn.Name = "anioDataGridViewTextBoxColumn";
            this.anioDataGridViewTextBoxColumn.ReadOnly = true;
            this.anioDataGridViewTextBoxColumn.Width = 80;
            // 
            // NomMoneda
            // 
            this.NomMoneda.DataPropertyName = "NomMoneda";
            this.NomMoneda.HeaderText = "Moneda";
            this.NomMoneda.Name = "NomMoneda";
            this.NomMoneda.ReadOnly = true;
            this.NomMoneda.Width = 150;
            // 
            // frmListadoPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 425);
            this.Controls.Add(this.dgvPresupuesto);
            this.Controls.Add(this.lblRegistros);
            this.MaximizeBox = false;
            this.Name = "frmListadoPresupuesto";
            this.Text = "Listado de Presupuesto";
            this.Activated += new System.EventHandler(this.frmListadoPresupuesto_Activated);
            this.Load += new System.EventHandler(this.frmListadoPresupuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPresupuesto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPresupuesto;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsPresupuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomMoneda;
    }
}