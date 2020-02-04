namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteFlujoDeCajaDetalle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.rANGODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cODPARTIDAPRESDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pARTIDAPRESUDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lIBRODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nFILEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMERODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTEMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUENTADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHACOMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gLOSADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOCUMENTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHAEMISDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEBEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hABERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFlujoDeCaja = new System.Windows.Forms.BindingSource(this.components);
            this.lblregistros = new MyLabelG.LabelDegradado();
            this.btBuscar = new System.Windows.Forms.Button();
            this.txtSubDebe = new ControlesWinForm.SuperTextBox();
            this.txtSubHaber = new ControlesWinForm.SuperTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textrziq = new ControlesWinForm.SuperTextBox();
            this.textder = new ControlesWinForm.SuperTextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFlujoDeCaja)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvListado);
            this.panel2.Controls.Add(this.lblregistros);
            this.panel2.Location = new System.Drawing.Point(1, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1227, 274);
            this.panel2.TabIndex = 298;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rANGODataGridViewTextBoxColumn,
            this.cODPARTIDAPRESDataGridViewTextBoxColumn,
            this.pARTIDAPRESUDataGridViewTextBoxColumn,
            this.lIBRODataGridViewTextBoxColumn,
            this.nFILEDataGridViewTextBoxColumn,
            this.nUMERODataGridViewTextBoxColumn,
            this.iTEMDataGridViewTextBoxColumn,
            this.cUENTADataGridViewTextBoxColumn,
            this.fECHACOMPDataGridViewTextBoxColumn,
            this.gLOSADataGridViewTextBoxColumn,
            this.dOCUMENTODataGridViewTextBoxColumn,
            this.fECHAEMISDataGridViewTextBoxColumn,
            this.dEBEDataGridViewTextBoxColumn,
            this.hABERDataGridViewTextBoxColumn});
            this.dgvListado.DataSource = this.bsFlujoDeCaja;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.EnableHeadersVisualStyles = false;
            this.dgvListado.Location = new System.Drawing.Point(0, 23);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(1225, 249);
            this.dgvListado.TabIndex = 248;
            this.dgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellDoubleClick);
            this.dgvListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListado_CellFormatting);
            // 
            // rANGODataGridViewTextBoxColumn
            // 
            this.rANGODataGridViewTextBoxColumn.DataPropertyName = "RANGO";
            this.rANGODataGridViewTextBoxColumn.HeaderText = "RANGO";
            this.rANGODataGridViewTextBoxColumn.Name = "rANGODataGridViewTextBoxColumn";
            this.rANGODataGridViewTextBoxColumn.ReadOnly = true;
            this.rANGODataGridViewTextBoxColumn.Width = 50;
            // 
            // cODPARTIDAPRESDataGridViewTextBoxColumn
            // 
            this.cODPARTIDAPRESDataGridViewTextBoxColumn.DataPropertyName = "COD_PARTIDA_PRES";
            this.cODPARTIDAPRESDataGridViewTextBoxColumn.HeaderText = "COD_PARTIDA";
            this.cODPARTIDAPRESDataGridViewTextBoxColumn.Name = "cODPARTIDAPRESDataGridViewTextBoxColumn";
            this.cODPARTIDAPRESDataGridViewTextBoxColumn.ReadOnly = true;
            this.cODPARTIDAPRESDataGridViewTextBoxColumn.Width = 85;
            // 
            // pARTIDAPRESUDataGridViewTextBoxColumn
            // 
            this.pARTIDAPRESUDataGridViewTextBoxColumn.DataPropertyName = "PARTIDA_PRESU";
            this.pARTIDAPRESUDataGridViewTextBoxColumn.HeaderText = "PARTIDA_PRESU";
            this.pARTIDAPRESUDataGridViewTextBoxColumn.Name = "pARTIDAPRESUDataGridViewTextBoxColumn";
            this.pARTIDAPRESUDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lIBRODataGridViewTextBoxColumn
            // 
            this.lIBRODataGridViewTextBoxColumn.DataPropertyName = "LIBRO";
            this.lIBRODataGridViewTextBoxColumn.HeaderText = "LIBRO";
            this.lIBRODataGridViewTextBoxColumn.Name = "lIBRODataGridViewTextBoxColumn";
            this.lIBRODataGridViewTextBoxColumn.ReadOnly = true;
            this.lIBRODataGridViewTextBoxColumn.Width = 40;
            // 
            // nFILEDataGridViewTextBoxColumn
            // 
            this.nFILEDataGridViewTextBoxColumn.DataPropertyName = "NFILE";
            this.nFILEDataGridViewTextBoxColumn.HeaderText = "NFILE";
            this.nFILEDataGridViewTextBoxColumn.Name = "nFILEDataGridViewTextBoxColumn";
            this.nFILEDataGridViewTextBoxColumn.ReadOnly = true;
            this.nFILEDataGridViewTextBoxColumn.Width = 40;
            // 
            // nUMERODataGridViewTextBoxColumn
            // 
            this.nUMERODataGridViewTextBoxColumn.DataPropertyName = "NUMERO";
            this.nUMERODataGridViewTextBoxColumn.HeaderText = "NUMERO";
            this.nUMERODataGridViewTextBoxColumn.Name = "nUMERODataGridViewTextBoxColumn";
            this.nUMERODataGridViewTextBoxColumn.ReadOnly = true;
            this.nUMERODataGridViewTextBoxColumn.Width = 70;
            // 
            // iTEMDataGridViewTextBoxColumn
            // 
            this.iTEMDataGridViewTextBoxColumn.DataPropertyName = "ITEM";
            this.iTEMDataGridViewTextBoxColumn.HeaderText = "ITEM";
            this.iTEMDataGridViewTextBoxColumn.Name = "iTEMDataGridViewTextBoxColumn";
            this.iTEMDataGridViewTextBoxColumn.ReadOnly = true;
            this.iTEMDataGridViewTextBoxColumn.Width = 40;
            // 
            // cUENTADataGridViewTextBoxColumn
            // 
            this.cUENTADataGridViewTextBoxColumn.DataPropertyName = "CUENTA";
            this.cUENTADataGridViewTextBoxColumn.HeaderText = "CUENTA";
            this.cUENTADataGridViewTextBoxColumn.Name = "cUENTADataGridViewTextBoxColumn";
            this.cUENTADataGridViewTextBoxColumn.ReadOnly = true;
            this.cUENTADataGridViewTextBoxColumn.Width = 58;
            // 
            // fECHACOMPDataGridViewTextBoxColumn
            // 
            this.fECHACOMPDataGridViewTextBoxColumn.DataPropertyName = "FECHA_COMP";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.fECHACOMPDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fECHACOMPDataGridViewTextBoxColumn.HeaderText = "FECHA_COMP";
            this.fECHACOMPDataGridViewTextBoxColumn.Name = "fECHACOMPDataGridViewTextBoxColumn";
            this.fECHACOMPDataGridViewTextBoxColumn.ReadOnly = true;
            this.fECHACOMPDataGridViewTextBoxColumn.Width = 85;
            // 
            // gLOSADataGridViewTextBoxColumn
            // 
            this.gLOSADataGridViewTextBoxColumn.DataPropertyName = "GLOSA";
            this.gLOSADataGridViewTextBoxColumn.HeaderText = "GLOSA";
            this.gLOSADataGridViewTextBoxColumn.Name = "gLOSADataGridViewTextBoxColumn";
            this.gLOSADataGridViewTextBoxColumn.ReadOnly = true;
            this.gLOSADataGridViewTextBoxColumn.Width = 250;
            // 
            // dOCUMENTODataGridViewTextBoxColumn
            // 
            this.dOCUMENTODataGridViewTextBoxColumn.DataPropertyName = "DOCUMENTO";
            this.dOCUMENTODataGridViewTextBoxColumn.HeaderText = "DOCUMENTO";
            this.dOCUMENTODataGridViewTextBoxColumn.Name = "dOCUMENTODataGridViewTextBoxColumn";
            this.dOCUMENTODataGridViewTextBoxColumn.ReadOnly = true;
            this.dOCUMENTODataGridViewTextBoxColumn.Width = 78;
            // 
            // fECHAEMISDataGridViewTextBoxColumn
            // 
            this.fECHAEMISDataGridViewTextBoxColumn.DataPropertyName = "FECHA_EMIS";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.fECHAEMISDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fECHAEMISDataGridViewTextBoxColumn.HeaderText = "FECHA_EMIS";
            this.fECHAEMISDataGridViewTextBoxColumn.Name = "fECHAEMISDataGridViewTextBoxColumn";
            this.fECHAEMISDataGridViewTextBoxColumn.ReadOnly = true;
            this.fECHAEMISDataGridViewTextBoxColumn.Width = 80;
            // 
            // dEBEDataGridViewTextBoxColumn
            // 
            this.dEBEDataGridViewTextBoxColumn.DataPropertyName = "DEBE";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.dEBEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.dEBEDataGridViewTextBoxColumn.HeaderText = "DEBE";
            this.dEBEDataGridViewTextBoxColumn.Name = "dEBEDataGridViewTextBoxColumn";
            this.dEBEDataGridViewTextBoxColumn.ReadOnly = true;
            this.dEBEDataGridViewTextBoxColumn.Width = 110;
            // 
            // hABERDataGridViewTextBoxColumn
            // 
            this.hABERDataGridViewTextBoxColumn.DataPropertyName = "HABER";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.hABERDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.hABERDataGridViewTextBoxColumn.HeaderText = "HABER";
            this.hABERDataGridViewTextBoxColumn.Name = "hABERDataGridViewTextBoxColumn";
            this.hABERDataGridViewTextBoxColumn.ReadOnly = true;
            this.hABERDataGridViewTextBoxColumn.Width = 110;
            // 
            // bsFlujoDeCaja
            // 
            this.bsFlujoDeCaja.DataSource = typeof(Entidades.Contabilidad.FlujoDeCajaE);
            // 
            // lblregistros
            // 
            this.lblregistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblregistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblregistros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregistros.ForeColor = System.Drawing.Color.White;
            this.lblregistros.Location = new System.Drawing.Point(0, 0);
            this.lblregistros.Name = "lblregistros";
            this.lblregistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblregistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblregistros.Size = new System.Drawing.Size(1225, 23);
            this.lblregistros.TabIndex = 249;
            this.lblregistros.Text = "registros";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.Excel_Chico;
            this.btBuscar.Location = new System.Drawing.Point(906, 282);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(42, 33);
            this.btBuscar.TabIndex = 306;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // txtSubDebe
            // 
            this.txtSubDebe.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSubDebe.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSubDebe.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSubDebe.Enabled = false;
            this.txtSubDebe.Location = new System.Drawing.Point(1021, 279);
            this.txtSubDebe.Name = "txtSubDebe";
            this.txtSubDebe.Size = new System.Drawing.Size(90, 20);
            this.txtSubDebe.TabIndex = 303;
            this.txtSubDebe.Text = "0.00";
            this.txtSubDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubDebe.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSubDebe.TextoVacio = "<Descripcion>";
            // 
            // txtSubHaber
            // 
            this.txtSubHaber.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSubHaber.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSubHaber.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSubHaber.Enabled = false;
            this.txtSubHaber.Location = new System.Drawing.Point(1111, 279);
            this.txtSubHaber.Name = "txtSubHaber";
            this.txtSubHaber.Size = new System.Drawing.Size(90, 20);
            this.txtSubHaber.TabIndex = 304;
            this.txtSubHaber.Text = "0.00";
            this.txtSubHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubHaber.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSubHaber.TextoVacio = "<Descripcion>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(951, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 305;
            this.label4.Text = "SubTotales :";
            // 
            // textrziq
            // 
            this.textrziq.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.textrziq.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textrziq.ColorTextoVacio = System.Drawing.Color.Gray;
            this.textrziq.Enabled = false;
            this.textrziq.Location = new System.Drawing.Point(1021, 300);
            this.textrziq.Name = "textrziq";
            this.textrziq.Size = new System.Drawing.Size(90, 20);
            this.textrziq.TabIndex = 307;
            this.textrziq.Text = "0.00";
            this.textrziq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textrziq.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.textrziq.TextoVacio = "<Descripcion>";
            this.textrziq.Visible = false;
            // 
            // textder
            // 
            this.textder.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.textder.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textder.ColorTextoVacio = System.Drawing.Color.Gray;
            this.textder.Enabled = false;
            this.textder.Location = new System.Drawing.Point(1111, 300);
            this.textder.Name = "textder";
            this.textder.Size = new System.Drawing.Size(90, 20);
            this.textder.TabIndex = 308;
            this.textder.Text = "0.00";
            this.textder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textder.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.textder.TextoVacio = "<Descripcion>";
            this.textder.Visible = false;
            // 
            // frmReporteFlujoDeCajaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 324);
            this.Controls.Add(this.textder);
            this.Controls.Add(this.textrziq);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSubHaber);
            this.Controls.Add(this.txtSubDebe);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "frmReporteFlujoDeCajaDetalle";
            this.Text = "Estados Financieros - Ganancias y Perdidas - Detalle";
            this.Load += new System.EventHandler(this.frmReporteEEFFGanaciasPerdidasDetalle_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFlujoDeCaja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvListado;
        private MyLabelG.LabelDegradado lblregistros;
        private System.Windows.Forms.Button btBuscar;
        private ControlesWinForm.SuperTextBox txtSubDebe;
        private ControlesWinForm.SuperTextBox txtSubHaber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bsFlujoDeCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn rANGODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODPARTIDAPRESDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pARTIDAPRESUDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lIBRODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nFILEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMERODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTEMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUENTADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHACOMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gLOSADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOCUMENTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHAEMISDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEBEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hABERDataGridViewTextBoxColumn;
        private ControlesWinForm.SuperTextBox textrziq;
        private ControlesWinForm.SuperTextBox textder;
    }
}