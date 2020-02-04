namespace ClienteWinForm.Contabilidad
{
    partial class frmListadoCuentasMigracion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsMigracion = new System.Windows.Forms.BindingSource(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentadestinoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombredestinoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaorigenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreorigenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreccosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsMigracion)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // bsMigracion
            // 
            this.bsMigracion.DataSource = typeof(Entidades.Contabilidad.CuentasMigracionE);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvListado);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(4, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1258, 500);
            this.panel5.TabIndex = 307;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoDataGridViewTextBoxColumn,
            this.cuentadestinoDataGridViewTextBoxColumn,
            this.nombredestinoDataGridViewTextBoxColumn,
            this.cuentaorigenDataGridViewTextBoxColumn,
            this.nombreorigenDataGridViewTextBoxColumn,
            this.ccosto,
            this.nombreccosto,
            this.codCuentaDataGridViewTextBoxColumn,
            this.desCuentaDataGridViewTextBoxColumn});
            this.dgvListado.DataSource = this.bsMigracion;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.EnableHeadersVisualStyles = false;
            this.dgvListado.Location = new System.Drawing.Point(0, 22);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(1256, 476);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            this.dgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellDoubleClick);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(1256, 22);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = " Registros Importados";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "tipo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cuentadestinoDataGridViewTextBoxColumn
            // 
            this.cuentadestinoDataGridViewTextBoxColumn.DataPropertyName = "cuentadestino";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cuentadestinoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cuentadestinoDataGridViewTextBoxColumn.HeaderText = "Cta.Destino";
            this.cuentadestinoDataGridViewTextBoxColumn.Name = "cuentadestinoDataGridViewTextBoxColumn";
            this.cuentadestinoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cuentadestinoDataGridViewTextBoxColumn.Width = 60;
            // 
            // nombredestinoDataGridViewTextBoxColumn
            // 
            this.nombredestinoDataGridViewTextBoxColumn.DataPropertyName = "nombredestino";
            this.nombredestinoDataGridViewTextBoxColumn.HeaderText = "Nombre Destino";
            this.nombredestinoDataGridViewTextBoxColumn.Name = "nombredestinoDataGridViewTextBoxColumn";
            this.nombredestinoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombredestinoDataGridViewTextBoxColumn.Width = 80;
            // 
            // cuentaorigenDataGridViewTextBoxColumn
            // 
            this.cuentaorigenDataGridViewTextBoxColumn.DataPropertyName = "cuentaorigen";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cuentaorigenDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.cuentaorigenDataGridViewTextBoxColumn.HeaderText = "Cta.Origen";
            this.cuentaorigenDataGridViewTextBoxColumn.Name = "cuentaorigenDataGridViewTextBoxColumn";
            this.cuentaorigenDataGridViewTextBoxColumn.ReadOnly = true;
            this.cuentaorigenDataGridViewTextBoxColumn.Width = 60;
            // 
            // nombreorigenDataGridViewTextBoxColumn
            // 
            this.nombreorigenDataGridViewTextBoxColumn.DataPropertyName = "nombreorigen";
            this.nombreorigenDataGridViewTextBoxColumn.HeaderText = "Nombre Origen";
            this.nombreorigenDataGridViewTextBoxColumn.Name = "nombreorigenDataGridViewTextBoxColumn";
            this.nombreorigenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ccosto
            // 
            this.ccosto.DataPropertyName = "ccosto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ccosto.DefaultCellStyle = dataGridViewCellStyle4;
            this.ccosto.HeaderText = "C.Costos";
            this.ccosto.Name = "ccosto";
            this.ccosto.ReadOnly = true;
            this.ccosto.Width = 60;
            // 
            // nombreccosto
            // 
            this.nombreccosto.DataPropertyName = "nombreccosto";
            this.nombreccosto.HeaderText = "Descripción C.C.";
            this.nombreccosto.Name = "nombreccosto";
            this.nombreccosto.ReadOnly = true;
            // 
            // codCuentaDataGridViewTextBoxColumn
            // 
            this.codCuentaDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCuentaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.codCuentaDataGridViewTextBoxColumn.HeaderText = "Cta.Indusoft";
            this.codCuentaDataGridViewTextBoxColumn.Name = "codCuentaDataGridViewTextBoxColumn";
            this.codCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCuentaDataGridViewTextBoxColumn.Width = 60;
            // 
            // desCuentaDataGridViewTextBoxColumn
            // 
            this.desCuentaDataGridViewTextBoxColumn.DataPropertyName = "desCuenta";
            this.desCuentaDataGridViewTextBoxColumn.HeaderText = "Nombre Cta. Indusoft";
            this.desCuentaDataGridViewTextBoxColumn.Name = "desCuentaDataGridViewTextBoxColumn";
            this.desCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmListadoCuentasMigracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 506);
            this.Controls.Add(this.panel5);
            this.MaximizeBox = false;
            this.Name = "frmListadoCuentasMigracion";
            this.Text = "Listado de Migración";
            this.Load += new System.EventHandler(this.frmListadoCuentasMigracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsMigracion)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListado;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsMigracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentadestinoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombredestinoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaorigenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreorigenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreccosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCuentaDataGridViewTextBoxColumn;
    }
}