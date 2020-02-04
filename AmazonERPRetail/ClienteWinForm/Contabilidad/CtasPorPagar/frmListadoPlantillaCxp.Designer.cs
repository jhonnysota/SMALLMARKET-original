namespace ClienteWinForm.CtasPorPagar
{
    partial class frmListadoPlantillaCxp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvplantillacxp = new System.Windows.Forms.DataGridView();
            this.idPlantillaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desPlantillaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesnumFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoPlantillaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsplantillacxp = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvplantillacxp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsplantillacxp)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvplantillacxp);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(7, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 380);
            this.panel1.TabIndex = 270;
            // 
            // dgvplantillacxp
            // 
            this.dgvplantillacxp.AllowUserToAddRows = false;
            this.dgvplantillacxp.AllowUserToDeleteRows = false;
            this.dgvplantillacxp.AutoGenerateColumns = false;
            this.dgvplantillacxp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvplantillacxp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPlantillaDataGridViewTextBoxColumn,
            this.desPlantillaDataGridViewTextBoxColumn,
            this.idComprobanteDataGridViewTextBoxColumn,
            this.DesComprobante,
            this.numFileDataGridViewTextBoxColumn,
            this.DesnumFile,
            this.tipoPlantillaDataGridViewTextBoxColumn});
            this.dgvplantillacxp.DataSource = this.bsplantillacxp;
            this.dgvplantillacxp.EnableHeadersVisualStyles = false;
            this.dgvplantillacxp.Location = new System.Drawing.Point(-1, 24);
            this.dgvplantillacxp.Name = "dgvplantillacxp";
            this.dgvplantillacxp.ReadOnly = true;
            this.dgvplantillacxp.Size = new System.Drawing.Size(846, 348);
            this.dgvplantillacxp.TabIndex = 250;
            this.dgvplantillacxp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvplantillaCxp_CellDoubleClick);
            // 
            // idPlantillaDataGridViewTextBoxColumn
            // 
            this.idPlantillaDataGridViewTextBoxColumn.DataPropertyName = "idPlantilla";
            this.idPlantillaDataGridViewTextBoxColumn.HeaderText = "Nro.";
            this.idPlantillaDataGridViewTextBoxColumn.Name = "idPlantillaDataGridViewTextBoxColumn";
            this.idPlantillaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desPlantillaDataGridViewTextBoxColumn
            // 
            this.desPlantillaDataGridViewTextBoxColumn.DataPropertyName = "DesPlantilla";
            this.desPlantillaDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.desPlantillaDataGridViewTextBoxColumn.Name = "desPlantillaDataGridViewTextBoxColumn";
            this.desPlantillaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idComprobanteDataGridViewTextBoxColumn
            // 
            this.idComprobanteDataGridViewTextBoxColumn.DataPropertyName = "idComprobante";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idComprobanteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.idComprobanteDataGridViewTextBoxColumn.HeaderText = "Diario";
            this.idComprobanteDataGridViewTextBoxColumn.Name = "idComprobanteDataGridViewTextBoxColumn";
            this.idComprobanteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DesComprobante
            // 
            this.DesComprobante.DataPropertyName = "DesComprobante";
            this.DesComprobante.HeaderText = "Nombre de Diario";
            this.DesComprobante.Name = "DesComprobante";
            this.DesComprobante.ReadOnly = true;
            // 
            // numFileDataGridViewTextBoxColumn
            // 
            this.numFileDataGridViewTextBoxColumn.DataPropertyName = "numFile";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numFileDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.numFileDataGridViewTextBoxColumn.HeaderText = "Nro.File";
            this.numFileDataGridViewTextBoxColumn.Name = "numFileDataGridViewTextBoxColumn";
            this.numFileDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DesnumFile
            // 
            this.DesnumFile.DataPropertyName = "DesnumFile";
            this.DesnumFile.HeaderText = "Nombre de File";
            this.DesnumFile.Name = "DesnumFile";
            this.DesnumFile.ReadOnly = true;
            // 
            // tipoPlantillaDataGridViewTextBoxColumn
            // 
            this.tipoPlantillaDataGridViewTextBoxColumn.DataPropertyName = "TipoPlantilla";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipoPlantillaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.tipoPlantillaDataGridViewTextBoxColumn.HeaderText = "Tipo de Plantilla";
            this.tipoPlantillaDataGridViewTextBoxColumn.Name = "tipoPlantillaDataGridViewTextBoxColumn";
            this.tipoPlantillaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsplantillacxp
            // 
            this.bsplantillacxp.DataSource = typeof(Entidades.CtasPorPagar.Plantilla_ConceptoE);
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
            this.lblRegistros.Size = new System.Drawing.Size(852, 21);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Plantillas Cuentas Por Pagar";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dtpFin);
            this.panel2.Controls.Add(this.dtpInicio);
            this.panel2.Controls.Add(this.labelDegradado1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(8, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 64);
            this.panel2.TabIndex = 269;
            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(197, 32);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(94, 21);
            this.dtpFin.TabIndex = 267;
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(56, 32);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(94, 21);
            this.dtpInicio.TabIndex = 266;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(310, 21);
            this.labelDegradado1.TabIndex = 255;
            this.labelDegradado1.Text = "Fechas";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 263;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 262;
            this.label1.Text = "Desde";
            // 
            // frmListadoPlantillaCxp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 460);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmListadoPlantillaCxp";
            this.Text = "Plantillas Cuentas Por Pagar";
            this.Activated += new System.EventHandler(this.frmListadoPlantillaCxp_Activated);
            this.Load += new System.EventHandler(this.frmListadoPlantillaCxp_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvplantillacxp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsplantillacxp)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvplantillacxp;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsplantillacxp;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPlantillaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desPlantillaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesnumFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoPlantillaDataGridViewTextBoxColumn;
    }
}