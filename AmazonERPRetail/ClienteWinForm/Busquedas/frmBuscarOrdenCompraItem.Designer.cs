namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarOrdenCompraItem
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
            this.dgvOrden = new System.Windows.Forms.DataGridView();
            this.tipMovimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumentoAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUbicacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impCostoUnitarioBaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impCostoUnitarioRefeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impTotalBaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impTotalRefeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCalidadDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indConformidadDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idCCostosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCCostosUsoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCCostosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idArticuloUsoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroEnvasesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorizadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nroParteProdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idItemCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioAnulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaAnulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsHojaCostoItem = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHojaCostoItem)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Almacen.MovimientoAlmacenItemE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(342, 254);
            this.btnAceptar.Size = new System.Drawing.Size(100, 26);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(448, 254);
            this.btnCancelar.Size = new System.Drawing.Size(100, 26);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(701, 148);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(1059, 59);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(760, 62);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(760, 85);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvOrden);
            this.gbResultados.Location = new System.Drawing.Point(5, 3);
            this.gbResultados.Size = new System.Drawing.Size(544, 246);
            // 
            // dgvOrden
            // 
            this.dgvOrden.AllowUserToAddRows = false;
            this.dgvOrden.AllowUserToDeleteRows = false;
            this.dgvOrden.AutoGenerateColumns = false;
            this.dgvOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrden.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipMovimientoDataGridViewTextBoxColumn,
            this.idDocumentoAlmacenDataGridViewTextBoxColumn,
            this.idItemDataGridViewTextBoxColumn,
            this.numItemDataGridViewTextBoxColumn,
            this.idArticuloDataGridViewTextBoxColumn,
            this.loteDataGridViewTextBoxColumn,
            this.idUbicacionDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.impCostoUnitarioBaseDataGridViewTextBoxColumn,
            this.impCostoUnitarioRefeDataGridViewTextBoxColumn,
            this.impTotalBaseDataGridViewTextBoxColumn,
            this.impTotalRefeDataGridViewTextBoxColumn,
            this.indCalidadDataGridViewCheckBoxColumn,
            this.indConformidadDataGridViewCheckBoxColumn,
            this.idCCostosDataGridViewTextBoxColumn,
            this.idCCostosUsoDataGridViewTextBoxColumn,
            this.desCCostosDataGridViewTextBoxColumn,
            this.idArticuloUsoDataGridViewTextBoxColumn,
            this.nroEnvasesDataGridViewTextBoxColumn,
            this.valorizadoDataGridViewCheckBoxColumn,
            this.nroParteProdDataGridViewTextBoxColumn,
            this.idItemCompraDataGridViewTextBoxColumn,
            this.usuarioAnulaDataGridViewTextBoxColumn,
            this.fechaAnulaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.codArticuloDataGridViewTextBoxColumn,
            this.nomArticuloDataGridViewTextBoxColumn,
            this.opcionDataGridViewTextBoxColumn});
            this.dgvOrden.DataSource = this.bsBase;
            this.dgvOrden.Location = new System.Drawing.Point(5, 14);
            this.dgvOrden.Name = "dgvOrden";
            this.dgvOrden.ReadOnly = true;
            this.dgvOrden.Size = new System.Drawing.Size(534, 228);
            this.dgvOrden.TabIndex = 0;
            this.dgvOrden.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrden_CellDoubleClick);
            // 
            // tipMovimientoDataGridViewTextBoxColumn
            // 
            this.tipMovimientoDataGridViewTextBoxColumn.DataPropertyName = "tipMovimiento";
            this.tipMovimientoDataGridViewTextBoxColumn.HeaderText = "tipMovimiento";
            this.tipMovimientoDataGridViewTextBoxColumn.Name = "tipMovimientoDataGridViewTextBoxColumn";
            this.tipMovimientoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idDocumentoAlmacenDataGridViewTextBoxColumn
            // 
            this.idDocumentoAlmacenDataGridViewTextBoxColumn.DataPropertyName = "idDocumentoAlmacen";
            this.idDocumentoAlmacenDataGridViewTextBoxColumn.HeaderText = "idDocumentoAlmacen";
            this.idDocumentoAlmacenDataGridViewTextBoxColumn.Name = "idDocumentoAlmacenDataGridViewTextBoxColumn";
            this.idDocumentoAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idItemDataGridViewTextBoxColumn
            // 
            this.idItemDataGridViewTextBoxColumn.DataPropertyName = "idItem";
            this.idItemDataGridViewTextBoxColumn.HeaderText = "idItem";
            this.idItemDataGridViewTextBoxColumn.Name = "idItemDataGridViewTextBoxColumn";
            this.idItemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numItemDataGridViewTextBoxColumn
            // 
            this.numItemDataGridViewTextBoxColumn.DataPropertyName = "numItem";
            this.numItemDataGridViewTextBoxColumn.HeaderText = "numItem";
            this.numItemDataGridViewTextBoxColumn.Name = "numItemDataGridViewTextBoxColumn";
            this.numItemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idArticuloDataGridViewTextBoxColumn
            // 
            this.idArticuloDataGridViewTextBoxColumn.DataPropertyName = "idArticulo";
            this.idArticuloDataGridViewTextBoxColumn.HeaderText = "idArticulo";
            this.idArticuloDataGridViewTextBoxColumn.Name = "idArticuloDataGridViewTextBoxColumn";
            this.idArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loteDataGridViewTextBoxColumn
            // 
            this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
            this.loteDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
            this.loteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idUbicacionDataGridViewTextBoxColumn
            // 
            this.idUbicacionDataGridViewTextBoxColumn.DataPropertyName = "idUbicacion";
            this.idUbicacionDataGridViewTextBoxColumn.HeaderText = "idUbicacion";
            this.idUbicacionDataGridViewTextBoxColumn.Name = "idUbicacionDataGridViewTextBoxColumn";
            this.idUbicacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // impCostoUnitarioBaseDataGridViewTextBoxColumn
            // 
            this.impCostoUnitarioBaseDataGridViewTextBoxColumn.DataPropertyName = "ImpCostoUnitarioBase";
            this.impCostoUnitarioBaseDataGridViewTextBoxColumn.HeaderText = "ImpCostoUnitarioBase";
            this.impCostoUnitarioBaseDataGridViewTextBoxColumn.Name = "impCostoUnitarioBaseDataGridViewTextBoxColumn";
            this.impCostoUnitarioBaseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // impCostoUnitarioRefeDataGridViewTextBoxColumn
            // 
            this.impCostoUnitarioRefeDataGridViewTextBoxColumn.DataPropertyName = "ImpCostoUnitarioRefe";
            this.impCostoUnitarioRefeDataGridViewTextBoxColumn.HeaderText = "ImpCostoUnitarioRefe";
            this.impCostoUnitarioRefeDataGridViewTextBoxColumn.Name = "impCostoUnitarioRefeDataGridViewTextBoxColumn";
            this.impCostoUnitarioRefeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // impTotalBaseDataGridViewTextBoxColumn
            // 
            this.impTotalBaseDataGridViewTextBoxColumn.DataPropertyName = "ImpTotalBase";
            this.impTotalBaseDataGridViewTextBoxColumn.HeaderText = "ImpTotalBase";
            this.impTotalBaseDataGridViewTextBoxColumn.Name = "impTotalBaseDataGridViewTextBoxColumn";
            this.impTotalBaseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // impTotalRefeDataGridViewTextBoxColumn
            // 
            this.impTotalRefeDataGridViewTextBoxColumn.DataPropertyName = "ImpTotalRefe";
            this.impTotalRefeDataGridViewTextBoxColumn.HeaderText = "ImpTotalRefe";
            this.impTotalRefeDataGridViewTextBoxColumn.Name = "impTotalRefeDataGridViewTextBoxColumn";
            this.impTotalRefeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // indCalidadDataGridViewCheckBoxColumn
            // 
            this.indCalidadDataGridViewCheckBoxColumn.DataPropertyName = "indCalidad";
            this.indCalidadDataGridViewCheckBoxColumn.HeaderText = "indCalidad";
            this.indCalidadDataGridViewCheckBoxColumn.Name = "indCalidadDataGridViewCheckBoxColumn";
            this.indCalidadDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indConformidadDataGridViewCheckBoxColumn
            // 
            this.indConformidadDataGridViewCheckBoxColumn.DataPropertyName = "indConformidad";
            this.indConformidadDataGridViewCheckBoxColumn.HeaderText = "indConformidad";
            this.indConformidadDataGridViewCheckBoxColumn.Name = "indConformidadDataGridViewCheckBoxColumn";
            this.indConformidadDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // idCCostosDataGridViewTextBoxColumn
            // 
            this.idCCostosDataGridViewTextBoxColumn.DataPropertyName = "idCCostos";
            this.idCCostosDataGridViewTextBoxColumn.HeaderText = "idCCostos";
            this.idCCostosDataGridViewTextBoxColumn.Name = "idCCostosDataGridViewTextBoxColumn";
            this.idCCostosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idCCostosUsoDataGridViewTextBoxColumn
            // 
            this.idCCostosUsoDataGridViewTextBoxColumn.DataPropertyName = "idCCostosUso";
            this.idCCostosUsoDataGridViewTextBoxColumn.HeaderText = "idCCostosUso";
            this.idCCostosUsoDataGridViewTextBoxColumn.Name = "idCCostosUsoDataGridViewTextBoxColumn";
            this.idCCostosUsoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desCCostosDataGridViewTextBoxColumn
            // 
            this.desCCostosDataGridViewTextBoxColumn.DataPropertyName = "desCCostos";
            this.desCCostosDataGridViewTextBoxColumn.HeaderText = "desCCostos";
            this.desCCostosDataGridViewTextBoxColumn.Name = "desCCostosDataGridViewTextBoxColumn";
            this.desCCostosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idArticuloUsoDataGridViewTextBoxColumn
            // 
            this.idArticuloUsoDataGridViewTextBoxColumn.DataPropertyName = "idArticuloUso";
            this.idArticuloUsoDataGridViewTextBoxColumn.HeaderText = "idArticuloUso";
            this.idArticuloUsoDataGridViewTextBoxColumn.Name = "idArticuloUsoDataGridViewTextBoxColumn";
            this.idArticuloUsoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nroEnvasesDataGridViewTextBoxColumn
            // 
            this.nroEnvasesDataGridViewTextBoxColumn.DataPropertyName = "nroEnvases";
            this.nroEnvasesDataGridViewTextBoxColumn.HeaderText = "nroEnvases";
            this.nroEnvasesDataGridViewTextBoxColumn.Name = "nroEnvasesDataGridViewTextBoxColumn";
            this.nroEnvasesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorizadoDataGridViewCheckBoxColumn
            // 
            this.valorizadoDataGridViewCheckBoxColumn.DataPropertyName = "Valorizado";
            this.valorizadoDataGridViewCheckBoxColumn.HeaderText = "Valorizado";
            this.valorizadoDataGridViewCheckBoxColumn.Name = "valorizadoDataGridViewCheckBoxColumn";
            this.valorizadoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // nroParteProdDataGridViewTextBoxColumn
            // 
            this.nroParteProdDataGridViewTextBoxColumn.DataPropertyName = "nroParteProd";
            this.nroParteProdDataGridViewTextBoxColumn.HeaderText = "nroParteProd";
            this.nroParteProdDataGridViewTextBoxColumn.Name = "nroParteProdDataGridViewTextBoxColumn";
            this.nroParteProdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idItemCompraDataGridViewTextBoxColumn
            // 
            this.idItemCompraDataGridViewTextBoxColumn.DataPropertyName = "idItemCompra";
            this.idItemCompraDataGridViewTextBoxColumn.HeaderText = "idItemCompra";
            this.idItemCompraDataGridViewTextBoxColumn.Name = "idItemCompraDataGridViewTextBoxColumn";
            this.idItemCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioAnulaDataGridViewTextBoxColumn
            // 
            this.usuarioAnulaDataGridViewTextBoxColumn.DataPropertyName = "UsuarioAnula";
            this.usuarioAnulaDataGridViewTextBoxColumn.HeaderText = "UsuarioAnula";
            this.usuarioAnulaDataGridViewTextBoxColumn.Name = "usuarioAnulaDataGridViewTextBoxColumn";
            this.usuarioAnulaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaAnulaDataGridViewTextBoxColumn
            // 
            this.fechaAnulaDataGridViewTextBoxColumn.DataPropertyName = "FechaAnula";
            this.fechaAnulaDataGridViewTextBoxColumn.HeaderText = "FechaAnula";
            this.fechaAnulaDataGridViewTextBoxColumn.Name = "fechaAnulaDataGridViewTextBoxColumn";
            this.fechaAnulaDataGridViewTextBoxColumn.ReadOnly = true;
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
            // codArticuloDataGridViewTextBoxColumn
            // 
            this.codArticuloDataGridViewTextBoxColumn.DataPropertyName = "codArticulo";
            this.codArticuloDataGridViewTextBoxColumn.HeaderText = "codArticulo";
            this.codArticuloDataGridViewTextBoxColumn.Name = "codArticuloDataGridViewTextBoxColumn";
            this.codArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomArticuloDataGridViewTextBoxColumn
            // 
            this.nomArticuloDataGridViewTextBoxColumn.DataPropertyName = "nomArticulo";
            this.nomArticuloDataGridViewTextBoxColumn.HeaderText = "nomArticulo";
            this.nomArticuloDataGridViewTextBoxColumn.Name = "nomArticuloDataGridViewTextBoxColumn";
            this.nomArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // opcionDataGridViewTextBoxColumn
            // 
            this.opcionDataGridViewTextBoxColumn.DataPropertyName = "Opcion";
            this.opcionDataGridViewTextBoxColumn.HeaderText = "Opcion";
            this.opcionDataGridViewTextBoxColumn.Name = "opcionDataGridViewTextBoxColumn";
            this.opcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsHojaCostoItem
            // 
            this.bsHojaCostoItem.DataSource = typeof(Entidades.Almacen.HojaCostoItemE);
            // 
            // frmBuscarOrdenCompraItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 285);
            this.Name = "frmBuscarOrdenCompraItem";
            this.Text = "Buscar Orden Compra Item";
            this.Load += new System.EventHandler(this.frmBuscarOrdenCompraItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHojaCostoItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrden;
        private System.Windows.Forms.BindingSource bsHojaCostoItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipMovimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUbicacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impCostoUnitarioBaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impCostoUnitarioRefeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impTotalBaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impTotalRefeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indCalidadDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indConformidadDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCCostosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCCostosUsoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCCostosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArticuloUsoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroEnvasesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn valorizadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroParteProdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idItemCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioAnulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAnulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oLoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn opcionDataGridViewTextBoxColumn;
    }
}