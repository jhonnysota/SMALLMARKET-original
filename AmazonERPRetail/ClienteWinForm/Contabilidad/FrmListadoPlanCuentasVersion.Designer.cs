namespace ClienteWinForm.Contabilidad
{
    partial class FrmListadoPlanCuentasVersion
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
            this.dgvPlanCuentas = new System.Windows.Forms.DataGridView();
            this.bsplanCuentasVersion = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecFinalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indVigente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsplanCuentasVersion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlanCuentas
            // 
            this.dgvPlanCuentas.AllowUserToAddRows = false;
            this.dgvPlanCuentas.AllowUserToDeleteRows = false;
            this.dgvPlanCuentas.AutoGenerateColumns = false;
            this.dgvPlanCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlanCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descripcionDataGridViewTextBoxColumn,
            this.fecInicioDataGridViewTextBoxColumn,
            this.fecFinalDataGridViewTextBoxColumn,
            this.indVigente});
            this.dgvPlanCuentas.DataSource = this.bsplanCuentasVersion;
            this.dgvPlanCuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanCuentas.EnableHeadersVisualStyles = false;
            this.dgvPlanCuentas.Location = new System.Drawing.Point(0, 23);
            this.dgvPlanCuentas.Name = "dgvPlanCuentas";
            this.dgvPlanCuentas.ReadOnly = true;
            this.dgvPlanCuentas.Size = new System.Drawing.Size(506, 283);
            this.dgvPlanCuentas.TabIndex = 253;
            this.dgvPlanCuentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanCuentas_CellDoubleClick);
            // 
            // bsplanCuentasVersion
            // 
            this.bsplanCuentasVersion.DataSource = typeof(Entidades.Contabilidad.PlanCuentasVersionE);
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
            this.lblRegistros.Size = new System.Drawing.Size(506, 23);
            this.lblRegistros.TabIndex = 254;
            this.lblRegistros.Text = "Registros";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn.Width = 200;
            // 
            // fecInicioDataGridViewTextBoxColumn
            // 
            this.fecInicioDataGridViewTextBoxColumn.DataPropertyName = "fecInicio";
            this.fecInicioDataGridViewTextBoxColumn.HeaderText = "Fecha Inicio";
            this.fecInicioDataGridViewTextBoxColumn.Name = "fecInicioDataGridViewTextBoxColumn";
            this.fecInicioDataGridViewTextBoxColumn.ReadOnly = true;
            this.fecInicioDataGridViewTextBoxColumn.Width = 120;
            // 
            // fecFinalDataGridViewTextBoxColumn
            // 
            this.fecFinalDataGridViewTextBoxColumn.DataPropertyName = "fecFinal";
            this.fecFinalDataGridViewTextBoxColumn.HeaderText = "Fecha Final";
            this.fecFinalDataGridViewTextBoxColumn.Name = "fecFinalDataGridViewTextBoxColumn";
            this.fecFinalDataGridViewTextBoxColumn.ReadOnly = true;
            this.fecFinalDataGridViewTextBoxColumn.Width = 120;
            // 
            // indVigente
            // 
            this.indVigente.DataPropertyName = "indVigente";
            this.indVigente.HeaderText = "Ind Vig.";
            this.indVigente.Name = "indVigente";
            this.indVigente.ReadOnly = true;
            this.indVigente.Width = 65;
            // 
            // FrmListadoPlanCuentasVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 306);
            this.Controls.Add(this.dgvPlanCuentas);
            this.Controls.Add(this.lblRegistros);
            this.MaximizeBox = false;
            this.Name = "FrmListadoPlanCuentasVersion";
            this.Text = "Listado de PlanCuentasVersion";
            this.Activated += new System.EventHandler(this.FrmListadoPlanCuentasVersion_Activated);
            this.Load += new System.EventHandler(this.FrmListadoPlanCuentasVersion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsplanCuentasVersion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlanCuentas;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsplanCuentasVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecFinalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indVigente;
    }
}