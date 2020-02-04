namespace ClienteWinForm.Almacen
{
    partial class frmEntradaDetalleSalidasLote
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
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvitems = new System.Windows.Forms.DataGridView();
            this.Correlativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOperacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipMovimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desOperacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desDetalleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indValorizarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indServicioDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.automaticoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codSunatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indOrdentrabajoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indTransferenciaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indConsumoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indProveedorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indClienteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indEstadisticoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indOrdenCompraDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indConversionDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indDevolucionDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indCostoVentaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indDocumentoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indReferenciaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ordenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMovimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomSunatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contaRegDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipMovimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTemporalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.lblregistros = new System.Windows.Forms.Label();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.lblregistros);
            this.pnlDetalle.Controls.Add(this.dgvitems);
            this.pnlDetalle.Location = new System.Drawing.Point(4, 3);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(759, 346);
            this.pnlDetalle.TabIndex = 298;
            // 
            // dgvitems
            // 
            this.dgvitems.AllowUserToAddRows = false;
            this.dgvitems.AllowUserToDeleteRows = false;
            this.dgvitems.AutoGenerateColumns = false;
            this.dgvitems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvitems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Correlativo,
            this.Lote,
            this.idEmpresaDataGridViewTextBoxColumn,
            this.idOperacionDataGridViewTextBoxColumn,
            this.tipAlmacenDataGridViewTextBoxColumn,
            this.tipMovimientoDataGridViewTextBoxColumn,
            this.desOperacionDataGridViewTextBoxColumn,
            this.desDetalleDataGridViewTextBoxColumn,
            this.indValorizarDataGridViewCheckBoxColumn,
            this.indServicioDataGridViewCheckBoxColumn,
            this.automaticoDataGridViewCheckBoxColumn,
            this.codSunatDataGridViewTextBoxColumn,
            this.indOrdentrabajoDataGridViewCheckBoxColumn,
            this.indTransferenciaDataGridViewCheckBoxColumn,
            this.indConsumoDataGridViewCheckBoxColumn,
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn,
            this.indProveedorDataGridViewCheckBoxColumn,
            this.indClienteDataGridViewCheckBoxColumn,
            this.indEstadisticoDataGridViewCheckBoxColumn,
            this.indOrdenCompraDataGridViewCheckBoxColumn,
            this.indConversionDataGridViewCheckBoxColumn,
            this.indDevolucionDataGridViewCheckBoxColumn,
            this.indCostoVentaDataGridViewCheckBoxColumn,
            this.indDocumentoDataGridViewCheckBoxColumn,
            this.indReferenciaDataGridViewCheckBoxColumn,
            this.ordenDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.desAlmacenDataGridViewTextBoxColumn,
            this.desMovimientoDataGridViewTextBoxColumn,
            this.tipoAlmacenDataGridViewTextBoxColumn,
            this.nomSunatDataGridViewTextBoxColumn,
            this.contaRegDataGridViewTextBoxColumn,
            this.nombreEmpresaDataGridViewTextBoxColumn,
            this.desTipAlmacenDataGridViewTextBoxColumn,
            this.desTipMovimientoDataGridViewTextBoxColumn,
            this.desTemporalDataGridViewTextBoxColumn});
            this.dgvitems.DataSource = this.bsDetalle;
            this.dgvitems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvitems.EnableHeadersVisualStyles = false;
            this.dgvitems.Location = new System.Drawing.Point(0, 0);
            this.dgvitems.Name = "dgvitems";
            this.dgvitems.ReadOnly = true;
            this.dgvitems.Size = new System.Drawing.Size(757, 344);
            this.dgvitems.TabIndex = 1;
            this.dgvitems.TabStop = false;
            // 
            // Correlativo
            // 
            this.Correlativo.DataPropertyName = "Correlativo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Correlativo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Correlativo.HeaderText = "Cód.";
            this.Correlativo.Name = "Correlativo";
            this.Correlativo.ReadOnly = true;
            this.Correlativo.Width = 90;
            // 
            // Lote
            // 
            this.Lote.DataPropertyName = "Lote";
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            this.Lote.Width = 80;
            // 
            // idEmpresaDataGridViewTextBoxColumn
            // 
            this.idEmpresaDataGridViewTextBoxColumn.DataPropertyName = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.HeaderText = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.Name = "idEmpresaDataGridViewTextBoxColumn";
            this.idEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idOperacionDataGridViewTextBoxColumn
            // 
            this.idOperacionDataGridViewTextBoxColumn.DataPropertyName = "idOperacion";
            this.idOperacionDataGridViewTextBoxColumn.HeaderText = "idOperacion";
            this.idOperacionDataGridViewTextBoxColumn.Name = "idOperacionDataGridViewTextBoxColumn";
            this.idOperacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipAlmacenDataGridViewTextBoxColumn
            // 
            this.tipAlmacenDataGridViewTextBoxColumn.DataPropertyName = "tipAlmacen";
            this.tipAlmacenDataGridViewTextBoxColumn.HeaderText = "tipAlmacen";
            this.tipAlmacenDataGridViewTextBoxColumn.Name = "tipAlmacenDataGridViewTextBoxColumn";
            this.tipAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipMovimientoDataGridViewTextBoxColumn
            // 
            this.tipMovimientoDataGridViewTextBoxColumn.DataPropertyName = "tipMovimiento";
            this.tipMovimientoDataGridViewTextBoxColumn.HeaderText = "tipMovimiento";
            this.tipMovimientoDataGridViewTextBoxColumn.Name = "tipMovimientoDataGridViewTextBoxColumn";
            this.tipMovimientoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desOperacionDataGridViewTextBoxColumn
            // 
            this.desOperacionDataGridViewTextBoxColumn.DataPropertyName = "desOperacion";
            this.desOperacionDataGridViewTextBoxColumn.HeaderText = "desOperacion";
            this.desOperacionDataGridViewTextBoxColumn.Name = "desOperacionDataGridViewTextBoxColumn";
            this.desOperacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desDetalleDataGridViewTextBoxColumn
            // 
            this.desDetalleDataGridViewTextBoxColumn.DataPropertyName = "desDetalle";
            this.desDetalleDataGridViewTextBoxColumn.HeaderText = "desDetalle";
            this.desDetalleDataGridViewTextBoxColumn.Name = "desDetalleDataGridViewTextBoxColumn";
            this.desDetalleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // indValorizarDataGridViewCheckBoxColumn
            // 
            this.indValorizarDataGridViewCheckBoxColumn.DataPropertyName = "indValorizar";
            this.indValorizarDataGridViewCheckBoxColumn.HeaderText = "indValorizar";
            this.indValorizarDataGridViewCheckBoxColumn.Name = "indValorizarDataGridViewCheckBoxColumn";
            this.indValorizarDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indServicioDataGridViewCheckBoxColumn
            // 
            this.indServicioDataGridViewCheckBoxColumn.DataPropertyName = "indServicio";
            this.indServicioDataGridViewCheckBoxColumn.HeaderText = "indServicio";
            this.indServicioDataGridViewCheckBoxColumn.Name = "indServicioDataGridViewCheckBoxColumn";
            this.indServicioDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // automaticoDataGridViewCheckBoxColumn
            // 
            this.automaticoDataGridViewCheckBoxColumn.DataPropertyName = "automatico";
            this.automaticoDataGridViewCheckBoxColumn.HeaderText = "automatico";
            this.automaticoDataGridViewCheckBoxColumn.Name = "automaticoDataGridViewCheckBoxColumn";
            this.automaticoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // codSunatDataGridViewTextBoxColumn
            // 
            this.codSunatDataGridViewTextBoxColumn.DataPropertyName = "codSunat";
            this.codSunatDataGridViewTextBoxColumn.HeaderText = "codSunat";
            this.codSunatDataGridViewTextBoxColumn.Name = "codSunatDataGridViewTextBoxColumn";
            this.codSunatDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // indOrdentrabajoDataGridViewCheckBoxColumn
            // 
            this.indOrdentrabajoDataGridViewCheckBoxColumn.DataPropertyName = "indOrdentrabajo";
            this.indOrdentrabajoDataGridViewCheckBoxColumn.HeaderText = "indOrdentrabajo";
            this.indOrdentrabajoDataGridViewCheckBoxColumn.Name = "indOrdentrabajoDataGridViewCheckBoxColumn";
            this.indOrdentrabajoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indTransferenciaDataGridViewCheckBoxColumn
            // 
            this.indTransferenciaDataGridViewCheckBoxColumn.DataPropertyName = "indTransferencia";
            this.indTransferenciaDataGridViewCheckBoxColumn.HeaderText = "indTransferencia";
            this.indTransferenciaDataGridViewCheckBoxColumn.Name = "indTransferenciaDataGridViewCheckBoxColumn";
            this.indTransferenciaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indConsumoDataGridViewCheckBoxColumn
            // 
            this.indConsumoDataGridViewCheckBoxColumn.DataPropertyName = "indConsumo";
            this.indConsumoDataGridViewCheckBoxColumn.HeaderText = "indConsumo";
            this.indConsumoDataGridViewCheckBoxColumn.Name = "indConsumoDataGridViewCheckBoxColumn";
            this.indConsumoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indDocumentoAutomaticoDataGridViewCheckBoxColumn
            // 
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn.DataPropertyName = "indDocumentoAutomatico";
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn.HeaderText = "indDocumentoAutomatico";
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn.Name = "indDocumentoAutomaticoDataGridViewCheckBoxColumn";
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indProveedorDataGridViewCheckBoxColumn
            // 
            this.indProveedorDataGridViewCheckBoxColumn.DataPropertyName = "indProveedor";
            this.indProveedorDataGridViewCheckBoxColumn.HeaderText = "indProveedor";
            this.indProveedorDataGridViewCheckBoxColumn.Name = "indProveedorDataGridViewCheckBoxColumn";
            this.indProveedorDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indClienteDataGridViewCheckBoxColumn
            // 
            this.indClienteDataGridViewCheckBoxColumn.DataPropertyName = "indCliente";
            this.indClienteDataGridViewCheckBoxColumn.HeaderText = "indCliente";
            this.indClienteDataGridViewCheckBoxColumn.Name = "indClienteDataGridViewCheckBoxColumn";
            this.indClienteDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indEstadisticoDataGridViewCheckBoxColumn
            // 
            this.indEstadisticoDataGridViewCheckBoxColumn.DataPropertyName = "indEstadistico";
            this.indEstadisticoDataGridViewCheckBoxColumn.HeaderText = "indEstadistico";
            this.indEstadisticoDataGridViewCheckBoxColumn.Name = "indEstadisticoDataGridViewCheckBoxColumn";
            this.indEstadisticoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indOrdenCompraDataGridViewCheckBoxColumn
            // 
            this.indOrdenCompraDataGridViewCheckBoxColumn.DataPropertyName = "indOrdenCompra";
            this.indOrdenCompraDataGridViewCheckBoxColumn.HeaderText = "indOrdenCompra";
            this.indOrdenCompraDataGridViewCheckBoxColumn.Name = "indOrdenCompraDataGridViewCheckBoxColumn";
            this.indOrdenCompraDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indConversionDataGridViewCheckBoxColumn
            // 
            this.indConversionDataGridViewCheckBoxColumn.DataPropertyName = "indConversion";
            this.indConversionDataGridViewCheckBoxColumn.HeaderText = "indConversion";
            this.indConversionDataGridViewCheckBoxColumn.Name = "indConversionDataGridViewCheckBoxColumn";
            this.indConversionDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indDevolucionDataGridViewCheckBoxColumn
            // 
            this.indDevolucionDataGridViewCheckBoxColumn.DataPropertyName = "indDevolucion";
            this.indDevolucionDataGridViewCheckBoxColumn.HeaderText = "indDevolucion";
            this.indDevolucionDataGridViewCheckBoxColumn.Name = "indDevolucionDataGridViewCheckBoxColumn";
            this.indDevolucionDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indCostoVentaDataGridViewCheckBoxColumn
            // 
            this.indCostoVentaDataGridViewCheckBoxColumn.DataPropertyName = "indCostoVenta";
            this.indCostoVentaDataGridViewCheckBoxColumn.HeaderText = "indCostoVenta";
            this.indCostoVentaDataGridViewCheckBoxColumn.Name = "indCostoVentaDataGridViewCheckBoxColumn";
            this.indCostoVentaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indDocumentoDataGridViewCheckBoxColumn
            // 
            this.indDocumentoDataGridViewCheckBoxColumn.DataPropertyName = "indDocumento";
            this.indDocumentoDataGridViewCheckBoxColumn.HeaderText = "indDocumento";
            this.indDocumentoDataGridViewCheckBoxColumn.Name = "indDocumentoDataGridViewCheckBoxColumn";
            this.indDocumentoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indReferenciaDataGridViewCheckBoxColumn
            // 
            this.indReferenciaDataGridViewCheckBoxColumn.DataPropertyName = "indReferencia";
            this.indReferenciaDataGridViewCheckBoxColumn.HeaderText = "indReferencia";
            this.indReferenciaDataGridViewCheckBoxColumn.Name = "indReferenciaDataGridViewCheckBoxColumn";
            this.indReferenciaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // ordenDataGridViewTextBoxColumn
            // 
            this.ordenDataGridViewTextBoxColumn.DataPropertyName = "orden";
            this.ordenDataGridViewTextBoxColumn.HeaderText = "orden";
            this.ordenDataGridViewTextBoxColumn.Name = "ordenDataGridViewTextBoxColumn";
            this.ordenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desAlmacenDataGridViewTextBoxColumn
            // 
            this.desAlmacenDataGridViewTextBoxColumn.DataPropertyName = "desAlmacen";
            this.desAlmacenDataGridViewTextBoxColumn.HeaderText = "desAlmacen";
            this.desAlmacenDataGridViewTextBoxColumn.Name = "desAlmacenDataGridViewTextBoxColumn";
            this.desAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desMovimientoDataGridViewTextBoxColumn
            // 
            this.desMovimientoDataGridViewTextBoxColumn.DataPropertyName = "desMovimiento";
            this.desMovimientoDataGridViewTextBoxColumn.HeaderText = "desMovimiento";
            this.desMovimientoDataGridViewTextBoxColumn.Name = "desMovimientoDataGridViewTextBoxColumn";
            this.desMovimientoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoAlmacenDataGridViewTextBoxColumn
            // 
            this.tipoAlmacenDataGridViewTextBoxColumn.DataPropertyName = "TipoAlmacen";
            this.tipoAlmacenDataGridViewTextBoxColumn.HeaderText = "TipoAlmacen";
            this.tipoAlmacenDataGridViewTextBoxColumn.Name = "tipoAlmacenDataGridViewTextBoxColumn";
            this.tipoAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomSunatDataGridViewTextBoxColumn
            // 
            this.nomSunatDataGridViewTextBoxColumn.DataPropertyName = "nomSunat";
            this.nomSunatDataGridViewTextBoxColumn.HeaderText = "nomSunat";
            this.nomSunatDataGridViewTextBoxColumn.Name = "nomSunatDataGridViewTextBoxColumn";
            this.nomSunatDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contaRegDataGridViewTextBoxColumn
            // 
            this.contaRegDataGridViewTextBoxColumn.DataPropertyName = "ContaReg";
            this.contaRegDataGridViewTextBoxColumn.HeaderText = "ContaReg";
            this.contaRegDataGridViewTextBoxColumn.Name = "contaRegDataGridViewTextBoxColumn";
            this.contaRegDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreEmpresaDataGridViewTextBoxColumn
            // 
            this.nombreEmpresaDataGridViewTextBoxColumn.DataPropertyName = "NombreEmpresa";
            this.nombreEmpresaDataGridViewTextBoxColumn.HeaderText = "NombreEmpresa";
            this.nombreEmpresaDataGridViewTextBoxColumn.Name = "nombreEmpresaDataGridViewTextBoxColumn";
            this.nombreEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desTipAlmacenDataGridViewTextBoxColumn
            // 
            this.desTipAlmacenDataGridViewTextBoxColumn.DataPropertyName = "desTipAlmacen";
            this.desTipAlmacenDataGridViewTextBoxColumn.HeaderText = "desTipAlmacen";
            this.desTipAlmacenDataGridViewTextBoxColumn.Name = "desTipAlmacenDataGridViewTextBoxColumn";
            this.desTipAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desTipMovimientoDataGridViewTextBoxColumn
            // 
            this.desTipMovimientoDataGridViewTextBoxColumn.DataPropertyName = "desTipMovimiento";
            this.desTipMovimientoDataGridViewTextBoxColumn.HeaderText = "desTipMovimiento";
            this.desTipMovimientoDataGridViewTextBoxColumn.Name = "desTipMovimientoDataGridViewTextBoxColumn";
            this.desTipMovimientoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desTemporalDataGridViewTextBoxColumn
            // 
            this.desTemporalDataGridViewTextBoxColumn.DataPropertyName = "desTemporal";
            this.desTemporalDataGridViewTextBoxColumn.HeaderText = "desTemporal";
            this.desTemporalDataGridViewTextBoxColumn.Name = "desTemporalDataGridViewTextBoxColumn";
            this.desTemporalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsDetalle
            // 
            this.bsDetalle.DataSource = typeof(Entidades.Almacen.OperacionE);
            // 
            // lblregistros
            // 
            this.lblregistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblregistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblregistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregistros.Location = new System.Drawing.Point(0, 0);
            this.lblregistros.Name = "lblregistros";
            this.lblregistros.Size = new System.Drawing.Size(757, 18);
            this.lblregistros.TabIndex = 1580;
            this.lblregistros.Text = "Detalle";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmEntradaDetalleSalidasLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(766, 352);
            this.Controls.Add(this.pnlDetalle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEntradaDetalleSalidasLote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Salidas por Lote";
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.DataGridView dgvitems;
        private System.Windows.Forms.BindingSource bsDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correlativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecProcesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoRefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serieDocumentoRefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDocumentoRefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOperacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipMovimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desOperacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desDetalleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indValorizarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indServicioDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn automaticoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSunatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indOrdentrabajoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indTransferenciaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indConsumoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indDocumentoAutomaticoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indProveedorDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indClienteDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indEstadisticoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indOrdenCompraDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indConversionDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indDevolucionDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indCostoVentaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indDocumentoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indReferenciaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMovimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomSunatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contaRegDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipMovimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTemporalDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblregistros;
    }
}