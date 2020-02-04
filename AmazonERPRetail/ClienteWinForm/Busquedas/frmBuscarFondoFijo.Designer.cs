namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarFondoFijo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvFondos = new MyDataGridViewAgrupado.DataGridViewAgrupado();
            this.desTipoFondo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroResponsableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desResponsableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMonedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoAutorizadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFondos)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Tesoreria.FondoFijoE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(289, 338);
            this.btnAceptar.Size = new System.Drawing.Size(124, 28);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(420, 338);
            this.btnCancelar.Size = new System.Drawing.Size(124, 28);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(930, 369);
            this.btnBuscar.Visible = false;
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(1226, 317);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(927, 320);
            this.label1.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(927, 343);
            this.txtFiltro.Visible = false;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvFondos);
            this.gbResultados.Location = new System.Drawing.Point(4, 3);
            this.gbResultados.Size = new System.Drawing.Size(824, 328);
            // 
            // dgvFondos
            // 
            this.dgvFondos.AllowUserToAddRows = false;
            this.dgvFondos.AllowUserToDeleteRows = false;
            this.dgvFondos.AutoGenerateColumns = false;
            this.dgvFondos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFondos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desTipoFondo,
            this.nroResponsableDataGridViewTextBoxColumn,
            this.desResponsableDataGridViewTextBoxColumn,
            this.desMonedaDataGridViewTextBoxColumn,
            this.montoAutorizadoDataGridViewTextBoxColumn,
            this.codCuentaDataGridViewTextBoxColumn,
            this.desCuentaDataGridViewTextBoxColumn});
            this.dgvFondos.DataSource = this.bsBase;
            this.dgvFondos.EnableHeadersVisualStyles = false;
            this.dgvFondos.GrupoColumnas = null;
            this.dgvFondos.Location = new System.Drawing.Point(6, 15);
            this.dgvFondos.Name = "dgvFondos";
            this.dgvFondos.ReadOnly = true;
            this.dgvFondos.Size = new System.Drawing.Size(811, 306);
            this.dgvFondos.TabIndex = 8;
            this.dgvFondos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFondos_CellDoubleClick);
            this.dgvFondos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvFondos_CellPainting);
            // 
            // desTipoFondo
            // 
            this.desTipoFondo.DataPropertyName = "desTipoFondo";
            this.desTipoFondo.HeaderText = "Tipo";
            this.desTipoFondo.Name = "desTipoFondo";
            this.desTipoFondo.ReadOnly = true;
            this.desTipoFondo.Width = 120;
            // 
            // nroResponsableDataGridViewTextBoxColumn
            // 
            this.nroResponsableDataGridViewTextBoxColumn.DataPropertyName = "nroResponsable";
            this.nroResponsableDataGridViewTextBoxColumn.HeaderText = "Ruc/Nro.Ide.";
            this.nroResponsableDataGridViewTextBoxColumn.Name = "nroResponsableDataGridViewTextBoxColumn";
            this.nroResponsableDataGridViewTextBoxColumn.ReadOnly = true;
            this.nroResponsableDataGridViewTextBoxColumn.Width = 88;
            // 
            // desResponsableDataGridViewTextBoxColumn
            // 
            this.desResponsableDataGridViewTextBoxColumn.DataPropertyName = "desResponsable";
            this.desResponsableDataGridViewTextBoxColumn.HeaderText = "Responsable";
            this.desResponsableDataGridViewTextBoxColumn.Name = "desResponsableDataGridViewTextBoxColumn";
            this.desResponsableDataGridViewTextBoxColumn.ReadOnly = true;
            this.desResponsableDataGridViewTextBoxColumn.Width = 250;
            // 
            // desMonedaDataGridViewTextBoxColumn
            // 
            this.desMonedaDataGridViewTextBoxColumn.DataPropertyName = "desMoneda";
            this.desMonedaDataGridViewTextBoxColumn.HeaderText = "Mon.";
            this.desMonedaDataGridViewTextBoxColumn.Name = "desMonedaDataGridViewTextBoxColumn";
            this.desMonedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.desMonedaDataGridViewTextBoxColumn.Width = 40;
            // 
            // montoAutorizadoDataGridViewTextBoxColumn
            // 
            this.montoAutorizadoDataGridViewTextBoxColumn.DataPropertyName = "MontoAutorizado";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.montoAutorizadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.montoAutorizadoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoAutorizadoDataGridViewTextBoxColumn.Name = "montoAutorizadoDataGridViewTextBoxColumn";
            this.montoAutorizadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoAutorizadoDataGridViewTextBoxColumn.Width = 80;
            // 
            // codCuentaDataGridViewTextBoxColumn
            // 
            this.codCuentaDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCuentaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.codCuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.codCuentaDataGridViewTextBoxColumn.Name = "codCuentaDataGridViewTextBoxColumn";
            this.codCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCuentaDataGridViewTextBoxColumn.Width = 60;
            // 
            // desCuentaDataGridViewTextBoxColumn
            // 
            this.desCuentaDataGridViewTextBoxColumn.DataPropertyName = "desCuenta";
            this.desCuentaDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desCuentaDataGridViewTextBoxColumn.Name = "desCuentaDataGridViewTextBoxColumn";
            this.desCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.desCuentaDataGridViewTextBoxColumn.Width = 150;
            // 
            // frmBuscarFondoFijo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 372);
            this.Name = "frmBuscarFondoFijo";
            this.Text = "Buscar Responsable";
            this.Load += new System.EventHandler(this.frmBuscarFondoFijo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFondos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyDataGridViewAgrupado.DataGridViewAgrupado dgvFondos;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipoFondo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroResponsableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desResponsableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMonedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoAutorizadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCuentaDataGridViewTextBoxColumn;
    }
}