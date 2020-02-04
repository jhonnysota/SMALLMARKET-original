namespace ClienteWinForm.Maestros
{
    partial class FrmArticulosKit
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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvArticuloServ = new System.Windows.Forms.DataGridView();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.lblCant = new System.Windows.Forms.Label();
            this.Txtcantidad = new ControlesWinForm.SuperTextBox();
            this.btEliminarItem = new System.Windows.Forms.Button();
            this.btNuevoItem = new System.Windows.Forms.Button();
            this.idArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticuloServ)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(506, 21);
            this.lblTitPnlBase.Text = "Articulos para el KIT";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(528, 25);
            this.lblTituloPrincipal.Text = "KITS";
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Maestros.ArticuloKitE);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(501, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.dgvArticuloServ);
            this.pnlBase.Location = new System.Drawing.Point(8, 60);
            this.pnlBase.Size = new System.Drawing.Size(508, 184);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.dgvArticuloServ, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(195, 324);
            this.btCancelar.Size = new System.Drawing.Size(112, 34);
            this.btCancelar.Visible = false;
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(311, 324);
            this.btAceptar.Text = "Agregar";
            this.btAceptar.Visible = false;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(10, 39);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(65, 13);
            label10.TabIndex = 116;
            label10.Text = "Producto Kit";
            // 
            // dgvArticuloServ
            // 
            this.dgvArticuloServ.AllowUserToAddRows = false;
            this.dgvArticuloServ.AllowUserToDeleteRows = false;
            this.dgvArticuloServ.AutoGenerateColumns = false;
            this.dgvArticuloServ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArticuloServ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticuloServ.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idArticuloDataGridViewTextBoxColumn,
            this.NombreArticulo,
            this.cantidadDataGridViewTextBoxColumn});
            this.dgvArticuloServ.DataSource = this.bsBase;
            this.dgvArticuloServ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArticuloServ.EnableHeadersVisualStyles = false;
            this.dgvArticuloServ.Location = new System.Drawing.Point(0, 21);
            this.dgvArticuloServ.Name = "dgvArticuloServ";
            this.dgvArticuloServ.Size = new System.Drawing.Size(506, 161);
            this.dgvArticuloServ.TabIndex = 251;
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.TxtCodigo.Enabled = false;
            this.TxtCodigo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigo.Location = new System.Drawing.Point(81, 36);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(137, 20);
            this.TxtCodigo.TabIndex = 115;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.TxtDescripcion.Enabled = false;
            this.TxtDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescripcion.Location = new System.Drawing.Point(222, 36);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(293, 20);
            this.TxtDescripcion.TabIndex = 117;
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.BackColor = System.Drawing.Color.Transparent;
            this.lblCant.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCant.Location = new System.Drawing.Point(356, 252);
            this.lblCant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(50, 13);
            this.lblCant.TabIndex = 119;
            this.lblCant.Text = "Cantidad";
            // 
            // Txtcantidad
            // 
            this.Txtcantidad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.Txtcantidad.BackColor = System.Drawing.Color.White;
            this.Txtcantidad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.Txtcantidad.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtcantidad.Location = new System.Drawing.Point(410, 249);
            this.Txtcantidad.Margin = new System.Windows.Forms.Padding(2);
            this.Txtcantidad.Name = "Txtcantidad";
            this.Txtcantidad.Size = new System.Drawing.Size(105, 20);
            this.Txtcantidad.TabIndex = 118;
            this.Txtcantidad.Text = "0.00";
            this.Txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Txtcantidad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.Txtcantidad.TextoVacio = "<Descripcion>";
            this.Txtcantidad.Leave += new System.EventHandler(this.Txtcantidad_Leave);
            // 
            // btEliminarItem
            // 
            this.btEliminarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEliminarItem.BackColor = System.Drawing.Color.Azure;
            this.btEliminarItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEliminarItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btEliminarItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEliminarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEliminarItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarItem.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.btEliminarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminarItem.Location = new System.Drawing.Point(239, 272);
            this.btEliminarItem.Margin = new System.Windows.Forms.Padding(2);
            this.btEliminarItem.Name = "btEliminarItem";
            this.btEliminarItem.Size = new System.Drawing.Size(113, 26);
            this.btEliminarItem.TabIndex = 359;
            this.btEliminarItem.TabStop = false;
            this.btEliminarItem.Text = "Eliminar";
            this.btEliminarItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEliminarItem.UseVisualStyleBackColor = false;
            this.btEliminarItem.Click += new System.EventHandler(this.btEliminarItem_Click);
            // 
            // btNuevoItem
            // 
            this.btNuevoItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNuevoItem.BackColor = System.Drawing.Color.Azure;
            this.btNuevoItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btNuevoItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btNuevoItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btNuevoItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNuevoItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNuevoItem.Image = global::ClienteWinForm.Properties.Resources.plus;
            this.btNuevoItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNuevoItem.Location = new System.Drawing.Point(121, 272);
            this.btNuevoItem.Margin = new System.Windows.Forms.Padding(2);
            this.btNuevoItem.Name = "btNuevoItem";
            this.btNuevoItem.Size = new System.Drawing.Size(113, 26);
            this.btNuevoItem.TabIndex = 360;
            this.btNuevoItem.TabStop = false;
            this.btNuevoItem.Text = "Agregar";
            this.btNuevoItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNuevoItem.UseVisualStyleBackColor = false;
            this.btNuevoItem.Click += new System.EventHandler(this.btNuevoItem_Click);
            // 
            // idArticuloDataGridViewTextBoxColumn
            // 
            this.idArticuloDataGridViewTextBoxColumn.DataPropertyName = "CodArticulo";
            this.idArticuloDataGridViewTextBoxColumn.HeaderText = "Cód.";
            this.idArticuloDataGridViewTextBoxColumn.Name = "idArticuloDataGridViewTextBoxColumn";
            this.idArticuloDataGridViewTextBoxColumn.Width = 110;
            // 
            // NombreArticulo
            // 
            this.NombreArticulo.DataPropertyName = "NombreArticulo";
            this.NombreArticulo.HeaderText = "Articulo";
            this.NombreArticulo.Name = "NombreArticulo";
            this.NombreArticulo.Width = 250;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.Width = 90;
            // 
            // FrmArticulosKit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 305);
            this.Controls.Add(this.btEliminarItem);
            this.Controls.Add(this.btNuevoItem);
            this.Controls.Add(this.lblCant);
            this.Controls.Add(this.Txtcantidad);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.TxtCodigo);
            this.Controls.Add(label10);
            this.Name = "FrmArticulosKit";
            this.Text = "FrmArticulosKit";
            this.Load += new System.EventHandler(this.FrmArticulosKit_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(label10, 0);
            this.Controls.SetChildIndex(this.TxtCodigo, 0);
            this.Controls.SetChildIndex(this.TxtDescripcion, 0);
            this.Controls.SetChildIndex(this.Txtcantidad, 0);
            this.Controls.SetChildIndex(this.lblCant, 0);
            this.Controls.SetChildIndex(this.btNuevoItem, 0);
            this.Controls.SetChildIndex(this.btEliminarItem, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticuloServ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticuloServ;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label lblCant;
        private ControlesWinForm.SuperTextBox Txtcantidad;
        private System.Windows.Forms.Button btEliminarItem;
        private System.Windows.Forms.Button btNuevoItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
    }
}