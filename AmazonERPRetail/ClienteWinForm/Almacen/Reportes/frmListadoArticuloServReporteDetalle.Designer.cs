namespace ClienteWinForm.Almacen.Reportes
{
    partial class frmListadoArticuloServReporteDetalle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRegistrosEntrada = new System.Windows.Forms.DataGridView();
            this.numCorrelativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumRequisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroGuiaRemision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOrdenCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsMovimientoAlmacen = new System.Windows.Forms.BindingSource(this.components);
            this.lblregistros = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrosEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimientoAlmacen)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "desOperacion";
            this.dataGridViewTextBoxColumn1.HeaderText = "Concepto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "desAlmacen";
            this.dataGridViewTextBoxColumn2.HeaderText = "Almacen";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 110;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RazonSocial";
            this.dataGridViewTextBoxColumn3.HeaderText = "Razon Social";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "desMoneda";
            this.dataGridViewTextBoxColumn4.HeaderText = "Moneda";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NumRequisicion";
            this.dataGridViewTextBoxColumn5.HeaderText = "Nº Requisicion";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "NumeroGuiaRemision";
            this.dataGridViewTextBoxColumn6.HeaderText = "Nº Guia Remision";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "idOrdenCompra";
            this.dataGridViewTextBoxColumn7.HeaderText = "idOrdenCompra";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn8.HeaderText = "Usuario Reg.";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvRegistrosEntrada);
            this.panel1.Controls.Add(this.lblregistros);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 428);
            this.panel1.TabIndex = 272;
            // 
            // dgvRegistrosEntrada
            // 
            this.dgvRegistrosEntrada.AllowUserToAddRows = false;
            this.dgvRegistrosEntrada.AllowUserToDeleteRows = false;
            this.dgvRegistrosEntrada.AutoGenerateColumns = false;
            this.dgvRegistrosEntrada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRegistrosEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistrosEntrada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numCorrelativo,
            this.desAlmacen,
            this.desOperacion,
            this.Cantidad,
            this.RazonSocial,
            this.desMoneda,
            this.NumRequisicion,
            this.NumeroGuiaRemision,
            this.idOrdenCompra,
            this.UsuarioRegistro,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvRegistrosEntrada.DataSource = this.bsMovimientoAlmacen;
            this.dgvRegistrosEntrada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegistrosEntrada.EnableHeadersVisualStyles = false;
            this.dgvRegistrosEntrada.Location = new System.Drawing.Point(0, 18);
            this.dgvRegistrosEntrada.Name = "dgvRegistrosEntrada";
            this.dgvRegistrosEntrada.ReadOnly = true;
            this.dgvRegistrosEntrada.Size = new System.Drawing.Size(930, 408);
            this.dgvRegistrosEntrada.TabIndex = 1;
            this.dgvRegistrosEntrada.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistrosEntrada_CellDoubleClick);
            // 
            // numCorrelativo
            // 
            this.numCorrelativo.DataPropertyName = "numCorrelativo";
            this.numCorrelativo.HeaderText = "N° Correlativo";
            this.numCorrelativo.Name = "numCorrelativo";
            this.numCorrelativo.ReadOnly = true;
            this.numCorrelativo.Width = 110;
            // 
            // desAlmacen
            // 
            this.desAlmacen.DataPropertyName = "desAlmacen";
            this.desAlmacen.HeaderText = "Almacen";
            this.desAlmacen.Name = "desAlmacen";
            this.desAlmacen.ReadOnly = true;
            this.desAlmacen.Width = 120;
            // 
            // desOperacion
            // 
            this.desOperacion.DataPropertyName = "desOperacion";
            this.desOperacion.HeaderText = "Operación";
            this.desOperacion.Name = "desOperacion";
            this.desOperacion.ReadOnly = true;
            this.desOperacion.Width = 160;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 60;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Procedencia";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 180;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            this.desMoneda.HeaderText = "Moneda";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 90;
            // 
            // NumRequisicion
            // 
            this.NumRequisicion.DataPropertyName = "NumRequisicion";
            this.NumRequisicion.HeaderText = "Nº Requisicion";
            this.NumRequisicion.Name = "NumRequisicion";
            this.NumRequisicion.ReadOnly = true;
            this.NumRequisicion.Width = 120;
            // 
            // NumeroGuiaRemision
            // 
            this.NumeroGuiaRemision.DataPropertyName = "Guia";
            this.NumeroGuiaRemision.HeaderText = "Nº Guia Remision";
            this.NumeroGuiaRemision.Name = "NumeroGuiaRemision";
            this.NumeroGuiaRemision.ReadOnly = true;
            this.NumeroGuiaRemision.Width = 150;
            // 
            // idOrdenCompra
            // 
            this.idOrdenCompra.DataPropertyName = "idOrdenCompra";
            this.idOrdenCompra.HeaderText = "idOrdenCompra";
            this.idOrdenCompra.Name = "idOrdenCompra";
            this.idOrdenCompra.ReadOnly = true;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.DataPropertyName = "UsuarioRegistro";
            this.UsuarioRegistro.HeaderText = "Usuario Reg.";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            this.UsuarioRegistro.ReadOnly = true;
            this.UsuarioRegistro.Width = 120;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle2.Format = "d";
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle3.Format = "d";
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsMovimientoAlmacen
            // 
            this.bsMovimientoAlmacen.DataSource = typeof(Entidades.Almacen.OperacionE);
            // 
            // lblregistros
            // 
            this.lblregistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblregistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblregistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregistros.Location = new System.Drawing.Point(0, 0);
            this.lblregistros.Name = "lblregistros";
            this.lblregistros.Size = new System.Drawing.Size(930, 18);
            this.lblregistros.TabIndex = 1574;
            this.lblregistros.Text = "Registros 0";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoArticuloServReporteDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(935, 432);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoArticuloServReporteDetalle";
            this.Text = "Detalle de Movimientos de Articulo";
            this.Load += new System.EventHandler(this.frmEntradaAlmacenes_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrosEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimientoAlmacen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvRegistrosEntrada;
        private System.Windows.Forms.BindingSource bsMovimientoAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn numCorrelativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecProcesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn desOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDocumentoReferenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn impTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroGuiaRemision;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrdenCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAnulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioAnulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblregistros;
    }
}