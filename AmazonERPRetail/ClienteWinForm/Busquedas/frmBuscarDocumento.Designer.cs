namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarDocumento
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
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.myCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecEmisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Ventas.EmisionDocumentoE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(17, 294);
            this.btnAceptar.Size = new System.Drawing.Size(100, 31);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(123, 294);
            this.btnCancelar.Size = new System.Drawing.Size(100, 31);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(191, 5);
            this.btnBuscar.Size = new System.Drawing.Size(31, 25);
            this.btnBuscar.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 5);
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.Text = "Tipo";
            this.label1.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(275, 299);
            this.txtFiltro.Size = new System.Drawing.Size(84, 20);
            this.txtFiltro.Visible = false;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvDocumentos);
            this.gbResultados.Location = new System.Drawing.Point(6, 5);
            this.gbResultados.Size = new System.Drawing.Size(230, 281);
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AutoGenerateColumns = false;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.myCheck,
            this.idDocumentoDataGridViewTextBoxColumn,
            this.numSerieDataGridViewTextBoxColumn,
            this.numDocumentoDataGridViewTextBoxColumn,
            this.fecEmisionDataGridViewTextBoxColumn,
            this.idEmpresa,
            this.idLocal});
            this.dgvDocumentos.DataSource = this.bsBase;
            this.dgvDocumentos.Enabled = false;
            this.dgvDocumentos.EnableHeadersVisualStyles = false;
            this.dgvDocumentos.Location = new System.Drawing.Point(6, 16);
            this.dgvDocumentos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.RowTemplate.Height = 24;
            this.dgvDocumentos.Size = new System.Drawing.Size(217, 260);
            this.dgvDocumentos.TabIndex = 2;
            this.dgvDocumentos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDocumentos_CellPainting);
            this.dgvDocumentos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellValueChanged);
            this.dgvDocumentos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDocumentos_CurrentCellDirtyStateChanged);
            // 
            // myCheck
            // 
            this.myCheck.DataPropertyName = "Check";
            this.myCheck.HeaderText = "";
            this.myCheck.Name = "myCheck";
            this.myCheck.Width = 30;
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "TD";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.Width = 70;
            // 
            // numSerieDataGridViewTextBoxColumn
            // 
            this.numSerieDataGridViewTextBoxColumn.DataPropertyName = "numSerie";
            this.numSerieDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.numSerieDataGridViewTextBoxColumn.Name = "numSerieDataGridViewTextBoxColumn";
            this.numSerieDataGridViewTextBoxColumn.Width = 70;
            // 
            // numDocumentoDataGridViewTextBoxColumn
            // 
            this.numDocumentoDataGridViewTextBoxColumn.DataPropertyName = "numDocumento";
            this.numDocumentoDataGridViewTextBoxColumn.HeaderText = "Numero";
            this.numDocumentoDataGridViewTextBoxColumn.Name = "numDocumentoDataGridViewTextBoxColumn";
            this.numDocumentoDataGridViewTextBoxColumn.Width = 70;
            // 
            // fecEmisionDataGridViewTextBoxColumn
            // 
            this.fecEmisionDataGridViewTextBoxColumn.DataPropertyName = "fecEmision";
            this.fecEmisionDataGridViewTextBoxColumn.HeaderText = "Fec.Emis.";
            this.fecEmisionDataGridViewTextBoxColumn.Name = "fecEmisionDataGridViewTextBoxColumn";
            // 
            // idEmpresa
            // 
            this.idEmpresa.DataPropertyName = "idEmpresa";
            this.idEmpresa.HeaderText = "idEmpresa";
            this.idEmpresa.Name = "idEmpresa";
            // 
            // idLocal
            // 
            this.idLocal.DataPropertyName = "idLocal";
            this.idLocal.HeaderText = "idLocal";
            this.idLocal.Name = "idLocal";
            // 
            // frmBuscarDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 331);
            this.Name = "frmBuscarDocumento";
            this.Text = "Busqueda Documentos";
            this.Load += new System.EventHandler(this.frmBuscarDocumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocumentos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn myCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecEmisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLocal;


    }
}