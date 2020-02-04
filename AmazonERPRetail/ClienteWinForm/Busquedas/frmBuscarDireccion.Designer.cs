namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarDireccion
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
            this.dgvCostosClasificacion = new System.Windows.Forms.DataGridView();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCortaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verificaStockDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.verificaLoteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tipoNumeracionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desResponsableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailResponsableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlfResponsableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCCostosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indEstadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fecBajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indUbiGenericaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUbicacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaLoteAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codEstablecimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCostosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desUbicacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esCalzadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tipoAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTemporalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostosClasificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Almacen.AlmacenE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(301, 281);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(407, 281);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(456, 21);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(1089, 180);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(817, 182);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(817, 205);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvCostosClasificacion);
            this.gbResultados.Location = new System.Drawing.Point(12, 12);
            this.gbResultados.Size = new System.Drawing.Size(438, 263);
            // 
            // dgvCostosClasificacion
            // 
            this.dgvCostosClasificacion.AllowUserToAddRows = false;
            this.dgvCostosClasificacion.AllowUserToDeleteRows = false;
            this.dgvCostosClasificacion.AutoGenerateColumns = false;
            this.dgvCostosClasificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostosClasificacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Direccion,
            this.idEmpresaDataGridViewTextBoxColumn,
            this.idAlmacenDataGridViewTextBoxColumn,
            this.claseDataGridViewTextBoxColumn,
            this.tipAlmacenDataGridViewTextBoxColumn,
            this.desAlmacenDataGridViewTextBoxColumn,
            this.desCortaDataGridViewTextBoxColumn,
            this.direccionDataGridViewTextBoxColumn,
            this.verificaStockDataGridViewCheckBoxColumn,
            this.verificaLoteDataGridViewCheckBoxColumn,
            this.tipoNumeracionDataGridViewTextBoxColumn,
            this.desResponsableDataGridViewTextBoxColumn,
            this.emailResponsableDataGridViewTextBoxColumn,
            this.tlfResponsableDataGridViewTextBoxColumn,
            this.idCCostosDataGridViewTextBoxColumn,
            this.indEstadoDataGridViewCheckBoxColumn,
            this.fecBajaDataGridViewTextBoxColumn,
            this.indUbiGenericaDataGridViewTextBoxColumn,
            this.idUbicacionDataGridViewTextBoxColumn,
            this.siglaLoteAlmacenDataGridViewTextBoxColumn,
            this.codEstablecimientoDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.desCostosDataGridViewTextBoxColumn,
            this.desUbicacionDataGridViewTextBoxColumn,
            this.esCalzadoDataGridViewCheckBoxColumn,
            this.tipoAlmacenDataGridViewTextBoxColumn,
            this.desTipAlmacenDataGridViewTextBoxColumn,
            this.desTemporalDataGridViewTextBoxColumn});
            this.dgvCostosClasificacion.DataSource = this.bsBase;
            this.dgvCostosClasificacion.Location = new System.Drawing.Point(7, 20);
            this.dgvCostosClasificacion.Name = "dgvCostosClasificacion";
            this.dgvCostosClasificacion.ReadOnly = true;
            this.dgvCostosClasificacion.Size = new System.Drawing.Size(425, 237);
            this.dgvCostosClasificacion.TabIndex = 0;
            this.dgvCostosClasificacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCostosClasificacion_CellDoubleClick);
            this.dgvCostosClasificacion.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCostosClasificacion_CellPainting);
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "Direccion";
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 400;
            // 
            // idEmpresaDataGridViewTextBoxColumn
            // 
            this.idEmpresaDataGridViewTextBoxColumn.DataPropertyName = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.HeaderText = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.Name = "idEmpresaDataGridViewTextBoxColumn";
            this.idEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idAlmacenDataGridViewTextBoxColumn
            // 
            this.idAlmacenDataGridViewTextBoxColumn.DataPropertyName = "idAlmacen";
            this.idAlmacenDataGridViewTextBoxColumn.HeaderText = "idAlmacen";
            this.idAlmacenDataGridViewTextBoxColumn.Name = "idAlmacenDataGridViewTextBoxColumn";
            this.idAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // claseDataGridViewTextBoxColumn
            // 
            this.claseDataGridViewTextBoxColumn.DataPropertyName = "Clase";
            this.claseDataGridViewTextBoxColumn.HeaderText = "Clase";
            this.claseDataGridViewTextBoxColumn.Name = "claseDataGridViewTextBoxColumn";
            this.claseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipAlmacenDataGridViewTextBoxColumn
            // 
            this.tipAlmacenDataGridViewTextBoxColumn.DataPropertyName = "tipAlmacen";
            this.tipAlmacenDataGridViewTextBoxColumn.HeaderText = "tipAlmacen";
            this.tipAlmacenDataGridViewTextBoxColumn.Name = "tipAlmacenDataGridViewTextBoxColumn";
            this.tipAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desAlmacenDataGridViewTextBoxColumn
            // 
            this.desAlmacenDataGridViewTextBoxColumn.DataPropertyName = "desAlmacen";
            this.desAlmacenDataGridViewTextBoxColumn.HeaderText = "desAlmacen";
            this.desAlmacenDataGridViewTextBoxColumn.Name = "desAlmacenDataGridViewTextBoxColumn";
            this.desAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desCortaDataGridViewTextBoxColumn
            // 
            this.desCortaDataGridViewTextBoxColumn.DataPropertyName = "desCorta";
            this.desCortaDataGridViewTextBoxColumn.HeaderText = "desCorta";
            this.desCortaDataGridViewTextBoxColumn.Name = "desCortaDataGridViewTextBoxColumn";
            this.desCortaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            this.direccionDataGridViewTextBoxColumn.HeaderText = "Direccion";
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            this.direccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // verificaStockDataGridViewCheckBoxColumn
            // 
            this.verificaStockDataGridViewCheckBoxColumn.DataPropertyName = "VerificaStock";
            this.verificaStockDataGridViewCheckBoxColumn.HeaderText = "VerificaStock";
            this.verificaStockDataGridViewCheckBoxColumn.Name = "verificaStockDataGridViewCheckBoxColumn";
            this.verificaStockDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // verificaLoteDataGridViewCheckBoxColumn
            // 
            this.verificaLoteDataGridViewCheckBoxColumn.DataPropertyName = "VerificaLote";
            this.verificaLoteDataGridViewCheckBoxColumn.HeaderText = "VerificaLote";
            this.verificaLoteDataGridViewCheckBoxColumn.Name = "verificaLoteDataGridViewCheckBoxColumn";
            this.verificaLoteDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // tipoNumeracionDataGridViewTextBoxColumn
            // 
            this.tipoNumeracionDataGridViewTextBoxColumn.DataPropertyName = "TipoNumeracion";
            this.tipoNumeracionDataGridViewTextBoxColumn.HeaderText = "TipoNumeracion";
            this.tipoNumeracionDataGridViewTextBoxColumn.Name = "tipoNumeracionDataGridViewTextBoxColumn";
            this.tipoNumeracionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desResponsableDataGridViewTextBoxColumn
            // 
            this.desResponsableDataGridViewTextBoxColumn.DataPropertyName = "desResponsable";
            this.desResponsableDataGridViewTextBoxColumn.HeaderText = "desResponsable";
            this.desResponsableDataGridViewTextBoxColumn.Name = "desResponsableDataGridViewTextBoxColumn";
            this.desResponsableDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailResponsableDataGridViewTextBoxColumn
            // 
            this.emailResponsableDataGridViewTextBoxColumn.DataPropertyName = "EmailResponsable";
            this.emailResponsableDataGridViewTextBoxColumn.HeaderText = "EmailResponsable";
            this.emailResponsableDataGridViewTextBoxColumn.Name = "emailResponsableDataGridViewTextBoxColumn";
            this.emailResponsableDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tlfResponsableDataGridViewTextBoxColumn
            // 
            this.tlfResponsableDataGridViewTextBoxColumn.DataPropertyName = "tlfResponsable";
            this.tlfResponsableDataGridViewTextBoxColumn.HeaderText = "tlfResponsable";
            this.tlfResponsableDataGridViewTextBoxColumn.Name = "tlfResponsableDataGridViewTextBoxColumn";
            this.tlfResponsableDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idCCostosDataGridViewTextBoxColumn
            // 
            this.idCCostosDataGridViewTextBoxColumn.DataPropertyName = "idCCostos";
            this.idCCostosDataGridViewTextBoxColumn.HeaderText = "idCCostos";
            this.idCCostosDataGridViewTextBoxColumn.Name = "idCCostosDataGridViewTextBoxColumn";
            this.idCCostosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // indEstadoDataGridViewCheckBoxColumn
            // 
            this.indEstadoDataGridViewCheckBoxColumn.DataPropertyName = "indEstado";
            this.indEstadoDataGridViewCheckBoxColumn.HeaderText = "indEstado";
            this.indEstadoDataGridViewCheckBoxColumn.Name = "indEstadoDataGridViewCheckBoxColumn";
            this.indEstadoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fecBajaDataGridViewTextBoxColumn
            // 
            this.fecBajaDataGridViewTextBoxColumn.DataPropertyName = "fecBaja";
            this.fecBajaDataGridViewTextBoxColumn.HeaderText = "fecBaja";
            this.fecBajaDataGridViewTextBoxColumn.Name = "fecBajaDataGridViewTextBoxColumn";
            this.fecBajaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // indUbiGenericaDataGridViewTextBoxColumn
            // 
            this.indUbiGenericaDataGridViewTextBoxColumn.DataPropertyName = "indUbiGenerica";
            this.indUbiGenericaDataGridViewTextBoxColumn.HeaderText = "indUbiGenerica";
            this.indUbiGenericaDataGridViewTextBoxColumn.Name = "indUbiGenericaDataGridViewTextBoxColumn";
            this.indUbiGenericaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idUbicacionDataGridViewTextBoxColumn
            // 
            this.idUbicacionDataGridViewTextBoxColumn.DataPropertyName = "idUbicacion";
            this.idUbicacionDataGridViewTextBoxColumn.HeaderText = "idUbicacion";
            this.idUbicacionDataGridViewTextBoxColumn.Name = "idUbicacionDataGridViewTextBoxColumn";
            this.idUbicacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // siglaLoteAlmacenDataGridViewTextBoxColumn
            // 
            this.siglaLoteAlmacenDataGridViewTextBoxColumn.DataPropertyName = "SiglaLoteAlmacen";
            this.siglaLoteAlmacenDataGridViewTextBoxColumn.HeaderText = "SiglaLoteAlmacen";
            this.siglaLoteAlmacenDataGridViewTextBoxColumn.Name = "siglaLoteAlmacenDataGridViewTextBoxColumn";
            this.siglaLoteAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codEstablecimientoDataGridViewTextBoxColumn
            // 
            this.codEstablecimientoDataGridViewTextBoxColumn.DataPropertyName = "CodEstablecimiento";
            this.codEstablecimientoDataGridViewTextBoxColumn.HeaderText = "CodEstablecimiento";
            this.codEstablecimientoDataGridViewTextBoxColumn.Name = "codEstablecimientoDataGridViewTextBoxColumn";
            this.codEstablecimientoDataGridViewTextBoxColumn.ReadOnly = true;
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
            // desCostosDataGridViewTextBoxColumn
            // 
            this.desCostosDataGridViewTextBoxColumn.DataPropertyName = "desCostos";
            this.desCostosDataGridViewTextBoxColumn.HeaderText = "desCostos";
            this.desCostosDataGridViewTextBoxColumn.Name = "desCostosDataGridViewTextBoxColumn";
            this.desCostosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desUbicacionDataGridViewTextBoxColumn
            // 
            this.desUbicacionDataGridViewTextBoxColumn.DataPropertyName = "desUbicacion";
            this.desUbicacionDataGridViewTextBoxColumn.HeaderText = "desUbicacion";
            this.desUbicacionDataGridViewTextBoxColumn.Name = "desUbicacionDataGridViewTextBoxColumn";
            this.desUbicacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // esCalzadoDataGridViewCheckBoxColumn
            // 
            this.esCalzadoDataGridViewCheckBoxColumn.DataPropertyName = "EsCalzado";
            this.esCalzadoDataGridViewCheckBoxColumn.HeaderText = "EsCalzado";
            this.esCalzadoDataGridViewCheckBoxColumn.Name = "esCalzadoDataGridViewCheckBoxColumn";
            this.esCalzadoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // tipoAlmacenDataGridViewTextBoxColumn
            // 
            this.tipoAlmacenDataGridViewTextBoxColumn.DataPropertyName = "TipoAlmacen";
            this.tipoAlmacenDataGridViewTextBoxColumn.HeaderText = "TipoAlmacen";
            this.tipoAlmacenDataGridViewTextBoxColumn.Name = "tipoAlmacenDataGridViewTextBoxColumn";
            this.tipoAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desTipAlmacenDataGridViewTextBoxColumn
            // 
            this.desTipAlmacenDataGridViewTextBoxColumn.DataPropertyName = "desTipAlmacen";
            this.desTipAlmacenDataGridViewTextBoxColumn.HeaderText = "desTipAlmacen";
            this.desTipAlmacenDataGridViewTextBoxColumn.Name = "desTipAlmacenDataGridViewTextBoxColumn";
            this.desTipAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desTemporalDataGridViewTextBoxColumn
            // 
            this.desTemporalDataGridViewTextBoxColumn.DataPropertyName = "desTemporal";
            this.desTemporalDataGridViewTextBoxColumn.HeaderText = "desTemporal";
            this.desTemporalDataGridViewTextBoxColumn.Name = "desTemporalDataGridViewTextBoxColumn";
            this.desTemporalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmBuscarDireccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 328);
            this.Name = "frmBuscarDireccion";
            this.Text = "Buscar Direcciones";
            this.Load += new System.EventHandler(this.frmBuscarCostosClasificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostosClasificacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCostosClasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn claseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCortaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn verificaStockDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn verificaLoteDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoNumeracionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desResponsableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailResponsableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tlfResponsableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCCostosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indEstadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecBajaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indUbiGenericaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUbicacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaLoteAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codEstablecimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCostosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desUbicacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn esCalzadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTemporalDataGridViewTextBoxColumn;
    }
}