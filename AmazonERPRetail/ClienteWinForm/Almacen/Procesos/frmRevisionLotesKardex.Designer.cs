namespace ClienteWinForm.Almacen.Procesos
{
    partial class frmRevisionLotesKardex
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
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocMovAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsKardex = new System.Windows.Forms.BindingSource(this.components);
            this.btEliminarLotes = new System.Windows.Forms.Button();
            this.lblregistros = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKardex)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvListado);
            this.panel1.Controls.Add(this.lblregistros);
            this.panel1.Location = new System.Drawing.Point(3, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 438);
            this.panel1.TabIndex = 273;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loteDataGridViewTextBoxColumn,
            this.numDocMovAlmacenDataGridViewTextBoxColumn,
            this.desAlmacenDataGridViewTextBoxColumn});
            this.dgvListado.DataSource = this.bsKardex;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.EnableHeadersVisualStyles = false;
            this.dgvListado.Location = new System.Drawing.Point(0, 18);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(520, 418);
            this.dgvListado.TabIndex = 1;
            // 
            // loteDataGridViewTextBoxColumn
            // 
            this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
            this.loteDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
            this.loteDataGridViewTextBoxColumn.ReadOnly = true;
            this.loteDataGridViewTextBoxColumn.Width = 60;
            // 
            // numDocMovAlmacenDataGridViewTextBoxColumn
            // 
            this.numDocMovAlmacenDataGridViewTextBoxColumn.DataPropertyName = "numDocMovAlmacen";
            this.numDocMovAlmacenDataGridViewTextBoxColumn.HeaderText = "N° Doc.Almacén";
            this.numDocMovAlmacenDataGridViewTextBoxColumn.Name = "numDocMovAlmacenDataGridViewTextBoxColumn";
            this.numDocMovAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            this.numDocMovAlmacenDataGridViewTextBoxColumn.Width = 120;
            // 
            // desAlmacenDataGridViewTextBoxColumn
            // 
            this.desAlmacenDataGridViewTextBoxColumn.DataPropertyName = "desAlmacen";
            this.desAlmacenDataGridViewTextBoxColumn.HeaderText = "Almacen";
            this.desAlmacenDataGridViewTextBoxColumn.Name = "desAlmacenDataGridViewTextBoxColumn";
            this.desAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            this.desAlmacenDataGridViewTextBoxColumn.Width = 250;
            // 
            // bsKardex
            // 
            this.bsKardex.DataSource = typeof(Entidades.Almacen.kardexE);
            // 
            // btEliminarLotes
            // 
            this.btEliminarLotes.BackColor = System.Drawing.Color.Azure;
            this.btEliminarLotes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEliminarLotes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btEliminarLotes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEliminarLotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEliminarLotes.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarLotes.Image = global::ClienteWinForm.Properties.Resources.borrar_registro;
            this.btEliminarLotes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminarLotes.Location = new System.Drawing.Point(3, 5);
            this.btEliminarLotes.Margin = new System.Windows.Forms.Padding(2);
            this.btEliminarLotes.Name = "btEliminarLotes";
            this.btEliminarLotes.Size = new System.Drawing.Size(120, 22);
            this.btEliminarLotes.TabIndex = 317;
            this.btEliminarLotes.Text = "Eliminar Lotes";
            this.btEliminarLotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEliminarLotes.UseVisualStyleBackColor = false;
            this.btEliminarLotes.Click += new System.EventHandler(this.btEliminarLotes_Click);
            // 
            // lblregistros
            // 
            this.lblregistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblregistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblregistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregistros.Location = new System.Drawing.Point(0, 0);
            this.lblregistros.Name = "lblregistros";
            this.lblregistros.Size = new System.Drawing.Size(520, 18);
            this.lblregistros.TabIndex = 1574;
            this.lblregistros.Text = "0 Registros";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmRevisionLotesKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(528, 473);
            this.Controls.Add(this.btEliminarLotes);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "frmRevisionLotesKardex";
            this.Text = "Revisión de Lotes";
            this.Load += new System.EventHandler(this.frmRevisionLotesKardex_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKardex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.BindingSource bsKardex;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocMovAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btEliminarLotes;
        private System.Windows.Forms.Label lblregistros;
    }
}