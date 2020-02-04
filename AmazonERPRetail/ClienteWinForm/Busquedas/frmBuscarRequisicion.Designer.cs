namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarRequisicion
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
            this.label2 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dgvRequisiscion = new System.Windows.Forms.DataGridView();
            this.idRequisicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numRequisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCCostos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCCostos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impCostoEstimado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Justificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisiscion)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Almacen.RequisicionE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(266, 349);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(372, 349);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(421, 41);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(756, 93);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 41);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(3, 64);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvRequisiscion);
            this.gbResultados.Location = new System.Drawing.Point(3, 91);
            this.gbResultados.Size = new System.Drawing.Size(469, 252);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 274;
            this.label2.Text = "Del";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(178, 17);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(94, 21);
            this.dtpHasta.TabIndex = 272;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(135, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 273;
            this.label3.Text = "Hasta";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(33, 17);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(94, 21);
            this.dtpDesde.TabIndex = 271;
            // 
            // dgvRequisiscion
            // 
            this.dgvRequisiscion.AllowUserToAddRows = false;
            this.dgvRequisiscion.AllowUserToDeleteRows = false;
            this.dgvRequisiscion.AutoGenerateColumns = false;
            this.dgvRequisiscion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequisiscion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRequisicionDataGridViewTextBoxColumn,
            this.idLocal,
            this.Nombre,
            this.numRequisicion,
            this.idCCostos,
            this.desCCostos,
            this.impCostoEstimado,
            this.Justificacion,
            this.Observacion});
            this.dgvRequisiscion.DataSource = this.bsBase;
            this.dgvRequisiscion.Location = new System.Drawing.Point(3, 19);
            this.dgvRequisiscion.Name = "dgvRequisiscion";
            this.dgvRequisiscion.ReadOnly = true;
            this.dgvRequisiscion.Size = new System.Drawing.Size(455, 227);
            this.dgvRequisiscion.TabIndex = 0;
            this.dgvRequisiscion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequisiscion_CellDoubleClick);
            this.dgvRequisiscion.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvRequisiscion_CellPainting);
            // 
            // idRequisicionDataGridViewTextBoxColumn
            // 
            this.idRequisicionDataGridViewTextBoxColumn.DataPropertyName = "idRequisicion";
            this.idRequisicionDataGridViewTextBoxColumn.HeaderText = "Requisicion";
            this.idRequisicionDataGridViewTextBoxColumn.Name = "idRequisicionDataGridViewTextBoxColumn";
            this.idRequisicionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idLocal
            // 
            this.idLocal.DataPropertyName = "idLocal";
            this.idLocal.HeaderText = "Local";
            this.idLocal.Name = "idLocal";
            this.idLocal.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // numRequisicion
            // 
            this.numRequisicion.DataPropertyName = "numRequisicion";
            this.numRequisicion.HeaderText = "numRequisicion";
            this.numRequisicion.Name = "numRequisicion";
            this.numRequisicion.ReadOnly = true;
            // 
            // idCCostos
            // 
            this.idCCostos.DataPropertyName = "idCCostos";
            this.idCCostos.HeaderText = "idCCostos";
            this.idCCostos.Name = "idCCostos";
            this.idCCostos.ReadOnly = true;
            // 
            // desCCostos
            // 
            this.desCCostos.DataPropertyName = "desCCostos";
            this.desCCostos.HeaderText = "desCCostos";
            this.desCCostos.Name = "desCCostos";
            this.desCCostos.ReadOnly = true;
            // 
            // impCostoEstimado
            // 
            this.impCostoEstimado.DataPropertyName = "impCostoEstimado";
            this.impCostoEstimado.HeaderText = "impCostoEstimado";
            this.impCostoEstimado.Name = "impCostoEstimado";
            this.impCostoEstimado.ReadOnly = true;
            // 
            // Justificacion
            // 
            this.Justificacion.DataPropertyName = "Justificacion";
            this.Justificacion.HeaderText = "Justificacion";
            this.Justificacion.Name = "Justificacion";
            this.Justificacion.ReadOnly = true;
            // 
            // Observacion
            // 
            this.Observacion.DataPropertyName = "Observacion";
            this.Observacion.HeaderText = "Observacion";
            this.Observacion.Name = "Observacion";
            this.Observacion.ReadOnly = true;
            // 
            // frmBuscarRequisicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 385);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDesde);
            this.Name = "frmBuscarRequisicion";
            this.Text = "Buscar Requisicion";
            this.Load += new System.EventHandler(this.frmBuscarRequisicion_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            this.Controls.SetChildIndex(this.dtpDesde, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dtpHasta, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisiscion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DataGridView dgvRequisiscion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRequisicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn numRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCCostos;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCCostos;
        private System.Windows.Forms.DataGridViewTextBoxColumn impCostoEstimado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Justificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacion;
    }
}