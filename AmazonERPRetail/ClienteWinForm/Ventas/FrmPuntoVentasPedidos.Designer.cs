namespace ClienteWinForm.Ventas
{
    partial class FrmPuntoVentasPedidos
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
            this.TxtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvDetalle = new System.Windows.Forms.DataGridView();
            this.idPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPedidoCadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FecPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMonedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BsPedidos = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtGuardar = new System.Windows.Forms.Button();
            this.BtBuscar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsPedidos)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtRazonSocial
            // 
            this.TxtRazonSocial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.TxtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtRazonSocial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRazonSocial.Location = new System.Drawing.Point(21, 28);
            this.TxtRazonSocial.Name = "TxtRazonSocial";
            this.TxtRazonSocial.Size = new System.Drawing.Size(684, 21);
            this.TxtRazonSocial.TabIndex = 1;
            this.TxtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.TxtRazonSocial.TextoVacio = "INGRESE LA RAZON SOCIAL";
            this.TxtRazonSocial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRazonSocial_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(725, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "BUSQUEDA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TxtRazonSocial);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 59);
            this.panel1.TabIndex = 2085;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(919, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "PEDIDOS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvDetalle
            // 
            this.DgvDetalle.AllowUserToAddRows = false;
            this.DgvDetalle.AllowUserToDeleteRows = false;
            this.DgvDetalle.AutoGenerateColumns = false;
            this.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPedido,
            this.codPedidoCadDataGridViewTextBoxColumn,
            this.FecPedido,
            this.RazonSocial,
            this.desMonedaDataGridViewTextBoxColumn,
            this.totTotal});
            this.DgvDetalle.DataSource = this.BsPedidos;
            this.DgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDetalle.EnableHeadersVisualStyles = false;
            this.DgvDetalle.Location = new System.Drawing.Point(0, 21);
            this.DgvDetalle.Name = "DgvDetalle";
            this.DgvDetalle.ReadOnly = true;
            this.DgvDetalle.Size = new System.Drawing.Size(919, 302);
            this.DgvDetalle.TabIndex = 100;
            this.DgvDetalle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalle_CellDoubleClick);
            this.DgvDetalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvDetalle_KeyDown);
            // 
            // idPedido
            // 
            this.idPedido.DataPropertyName = "idPedido";
            this.idPedido.HeaderText = "ID";
            this.idPedido.Name = "idPedido";
            this.idPedido.ReadOnly = true;
            this.idPedido.Visible = false;
            this.idPedido.Width = 30;
            // 
            // codPedidoCadDataGridViewTextBoxColumn
            // 
            this.codPedidoCadDataGridViewTextBoxColumn.DataPropertyName = "codPedidoCad";
            this.codPedidoCadDataGridViewTextBoxColumn.HeaderText = "Cód.Pedido";
            this.codPedidoCadDataGridViewTextBoxColumn.Name = "codPedidoCadDataGridViewTextBoxColumn";
            this.codPedidoCadDataGridViewTextBoxColumn.ReadOnly = true;
            this.codPedidoCadDataGridViewTextBoxColumn.Width = 120;
            // 
            // FecPedido
            // 
            this.FecPedido.DataPropertyName = "FecPedido";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.FecPedido.DefaultCellStyle = dataGridViewCellStyle1;
            this.FecPedido.HeaderText = "Fec.Pedido";
            this.FecPedido.Name = "FecPedido";
            this.FecPedido.ReadOnly = true;
            this.FecPedido.Width = 80;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Razón Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 480;
            // 
            // desMonedaDataGridViewTextBoxColumn
            // 
            this.desMonedaDataGridViewTextBoxColumn.DataPropertyName = "desMoneda";
            this.desMonedaDataGridViewTextBoxColumn.HeaderText = "Mon.";
            this.desMonedaDataGridViewTextBoxColumn.Name = "desMonedaDataGridViewTextBoxColumn";
            this.desMonedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.desMonedaDataGridViewTextBoxColumn.Width = 60;
            // 
            // totTotal
            // 
            this.totTotal.DataPropertyName = "totTotal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.totTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.totTotal.HeaderText = "Total";
            this.totTotal.Name = "totTotal";
            this.totTotal.ReadOnly = true;
            this.totTotal.Width = 110;
            // 
            // BsPedidos
            // 
            this.BsPedidos.DataSource = typeof(Entidades.Ventas.PedidoCabE);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.DgvDetalle);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(5, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(921, 325);
            this.panel2.TabIndex = 2086;
            // 
            // BtGuardar
            // 
            this.BtGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtGuardar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtGuardar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.BtGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtGuardar.Location = new System.Drawing.Point(835, 5);
            this.BtGuardar.Name = "BtGuardar";
            this.BtGuardar.Size = new System.Drawing.Size(91, 55);
            this.BtGuardar.TabIndex = 2087;
            this.BtGuardar.TabStop = false;
            this.BtGuardar.Text = "Agregar";
            this.BtGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtGuardar.UseVisualStyleBackColor = true;
            this.BtGuardar.Click += new System.EventHandler(this.BtGuardar_Click);
            // 
            // BtBuscar
            // 
            this.BtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtBuscar.Image = global::ClienteWinForm.Properties.Resources.buscar_16x16neg;
            this.BtBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtBuscar.Location = new System.Drawing.Point(738, 5);
            this.BtBuscar.Name = "BtBuscar";
            this.BtBuscar.Size = new System.Drawing.Size(91, 55);
            this.BtBuscar.TabIndex = 2088;
            this.BtBuscar.TabStop = false;
            this.BtBuscar.Text = "Buscar";
            this.BtBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtBuscar.UseVisualStyleBackColor = true;
            this.BtBuscar.Click += new System.EventHandler(this.BtBuscar_Click);
            // 
            // FrmPuntoVentasPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(930, 395);
            this.Controls.Add(this.BtBuscar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BtGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmPuntoVentasPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Pedidos Pendientes";
            this.Load += new System.EventHandler(this.FrmPuntoVentasPedidos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPuntoVentasPedidos_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsPedidos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlesWinForm.SuperTextBox TxtRazonSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvDetalle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtGuardar;
        private System.Windows.Forms.BindingSource BsPedidos;
        private System.Windows.Forms.Button BtBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPedidoCadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FecPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMonedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totTotal;
    }
}