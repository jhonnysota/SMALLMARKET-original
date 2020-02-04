namespace ClienteWinForm.Ventas
{
    partial class frmListadoSelListaPrecio
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
            this.dgvPrecios = new System.Windows.Forms.DataGridView();
            this.idListaPrecioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsListaPrecio = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.ACe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListaPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Black;
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(78, 349);
            this.btnAceptar.Size = new System.Drawing.Size(119, 34);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Black;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(201, 349);
            this.btnCancelar.Size = new System.Drawing.Size(119, 34);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(1167, 106);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(1228, 72);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1134, 36);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(1253, 95);
            this.txtFiltro.Size = new System.Drawing.Size(50, 20);
            // 
            // gbResultados
            // 
            this.gbResultados.Location = new System.Drawing.Point(1167, 106);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvPrecios);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 334);
            this.panel1.TabIndex = 78;
            // 
            // dgvPrecios
            // 
            this.dgvPrecios.AllowUserToAddRows = false;
            this.dgvPrecios.AllowUserToDeleteRows = false;
            this.dgvPrecios.AutoGenerateColumns = false;
            this.dgvPrecios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrecios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idListaPrecioDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.desMoneda});
            this.dgvPrecios.DataSource = this.bsListaPrecio;
            this.dgvPrecios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrecios.EnableHeadersVisualStyles = false;
            this.dgvPrecios.Location = new System.Drawing.Point(0, 22);
            this.dgvPrecios.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPrecios.Name = "dgvPrecios";
            this.dgvPrecios.ReadOnly = true;
            this.dgvPrecios.RowTemplate.Height = 24;
            this.dgvPrecios.Size = new System.Drawing.Size(388, 310);
            this.dgvPrecios.TabIndex = 80;
            this.dgvPrecios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrecios_CellDoubleClick);
            // 
            // idListaPrecioDataGridViewTextBoxColumn
            // 
            this.idListaPrecioDataGridViewTextBoxColumn.DataPropertyName = "idListaPrecio";
            this.idListaPrecioDataGridViewTextBoxColumn.FillWeight = 200F;
            this.idListaPrecioDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idListaPrecioDataGridViewTextBoxColumn.Name = "idListaPrecioDataGridViewTextBoxColumn";
            this.idListaPrecioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idListaPrecioDataGridViewTextBoxColumn.Width = 30;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.FillWeight = 170F;
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDataGridViewTextBoxColumn.Width = 200;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            this.desMoneda.FillWeight = 170F;
            this.desMoneda.HeaderText = "Moneda";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            // 
            // bsListaPrecio
            // 
            this.bsListaPrecio.DataSource = typeof(Entidades.Ventas.ListaPrecioE);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.Black;
            this.lblRegistros.SegundoColor = System.Drawing.Color.White;
            this.lblRegistros.Size = new System.Drawing.Size(388, 22);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ACe
            // 
            this.ACe.Location = new System.Drawing.Point(1137, 77);
            this.ACe.Name = "ACe";
            this.ACe.Size = new System.Drawing.Size(75, 23);
            this.ACe.TabIndex = 79;
            this.ACe.Text = "Aceptar";
            this.ACe.UseVisualStyleBackColor = true;
            // 
            // frmListadoSelListaPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(397, 396);
            this.Controls.Add(this.ACe);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoSelListaPrecio";
            this.Text = "Seleccion de Lista Precio";
            this.Load += new System.EventHandler(this.frmListadoSelListaPrecio_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.ACe, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListaPrecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPrecios;
        private System.Windows.Forms.BindingSource bsListaPrecio;
        private System.Windows.Forms.Button ACe;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn idListaPrecioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
    }
}