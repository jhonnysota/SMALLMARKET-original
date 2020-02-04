namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteEEFFGananciasyPerdidasDetalle
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.bsVoucherItem = new System.Windows.Forms.BindingSource(this.components);
            this.lblregistros = new MyLabelG.LabelDegradado();
            this.txtDebe = new ControlesWinForm.SuperTextBox();
            this.txtHaber = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubHaber = new ControlesWinForm.SuperTextBox();
            this.txtSubDebe = new ControlesWinForm.SuperTextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.indSolicitaCentroCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desGlosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCCostos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVoucherItem)).BeginInit();
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
            this.indSolicitaCentroCosto,
            this.idComprobante,
            this.numFile,
            this.numVoucher,
            this.numItem,
            this.codCuenta,
            this.fecOperacion,
            this.desGlosa,
            this.desCCostos,
            this.DesPersona,
            this.idDocumento,
            this.serDocumento,
            this.numDocumento,
            this.fecDocumento,
            this.impDebe,
            this.impHaber});
            this.dgvListado.DataSource = this.bsVoucherItem;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.EnableHeadersVisualStyles = false;
            this.dgvListado.Location = new System.Drawing.Point(0, 23);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(1225, 249);
            this.dgvListado.TabIndex = 248;
            this.dgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellDoubleClick);
            this.dgvListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListado_CellFormatting);
            this.dgvListado.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListado_ColumnHeaderMouseClick);
            // 
            // bsVoucherItem
            // 
            this.bsVoucherItem.DataSource = typeof(Entidades.Contabilidad.VoucherItemE);
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
            // txtDebe
            // 
            this.txtDebe.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDebe.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDebe.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDebe.Enabled = false;
            this.txtDebe.Location = new System.Drawing.Point(1021, 299);
            this.txtDebe.Name = "txtDebe";
            this.txtDebe.Size = new System.Drawing.Size(90, 20);
            this.txtDebe.TabIndex = 299;
            this.txtDebe.Text = "0.00";
            this.txtDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDebe.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDebe.TextoVacio = "<Descripcion>";
            // 
            // txtHaber
            // 
            this.txtHaber.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtHaber.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtHaber.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtHaber.Enabled = false;
            this.txtHaber.Location = new System.Drawing.Point(1111, 299);
            this.txtHaber.Name = "txtHaber";
            this.txtHaber.Size = new System.Drawing.Size(90, 20);
            this.txtHaber.TabIndex = 300;
            this.txtHaber.Text = "0.00";
            this.txtHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHaber.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtHaber.TextoVacio = "<Descripcion>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(978, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 301;
            this.label1.Text = "Saldo :";
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
            // indSolicitaCentroCosto
            // 
            this.indSolicitaCentroCosto.DataPropertyName = "indSolicitaCentroCosto";
            this.indSolicitaCentroCosto.HeaderText = "";
            this.indSolicitaCentroCosto.Name = "indSolicitaCentroCosto";
            this.indSolicitaCentroCosto.ReadOnly = true;
            this.indSolicitaCentroCosto.Visible = false;
            // 
            // idComprobante
            // 
            this.idComprobante.DataPropertyName = "idComprobante";
            this.idComprobante.HeaderText = "Libro";
            this.idComprobante.Name = "idComprobante";
            this.idComprobante.ReadOnly = true;
            this.idComprobante.Width = 40;
            // 
            // numFile
            // 
            this.numFile.DataPropertyName = "numFile";
            this.numFile.HeaderText = "File";
            this.numFile.Name = "numFile";
            this.numFile.ReadOnly = true;
            this.numFile.Width = 40;
            // 
            // numVoucher
            // 
            this.numVoucher.DataPropertyName = "numVoucher";
            this.numVoucher.HeaderText = "Número";
            this.numVoucher.Name = "numVoucher";
            this.numVoucher.ReadOnly = true;
            this.numVoucher.Width = 70;
            // 
            // numItem
            // 
            this.numItem.DataPropertyName = "numItem";
            this.numItem.HeaderText = "Item";
            this.numItem.Name = "numItem";
            this.numItem.ReadOnly = true;
            this.numItem.Width = 40;
            // 
            // codCuenta
            // 
            this.codCuenta.DataPropertyName = "codCuenta";
            this.codCuenta.HeaderText = "Cuenta";
            this.codCuenta.Name = "codCuenta";
            this.codCuenta.ReadOnly = true;
            this.codCuenta.Width = 50;
            // 
            // fecOperacion
            // 
            this.fecOperacion.DataPropertyName = "fecOperacion";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecOperacion.DefaultCellStyle = dataGridViewCellStyle1;
            this.fecOperacion.HeaderText = "Fec. O.";
            this.fecOperacion.Name = "fecOperacion";
            this.fecOperacion.ReadOnly = true;
            this.fecOperacion.Width = 70;
            // 
            // desGlosa
            // 
            this.desGlosa.DataPropertyName = "desGlosa";
            this.desGlosa.HeaderText = "Glosa";
            this.desGlosa.Name = "desGlosa";
            this.desGlosa.ReadOnly = true;
            this.desGlosa.Width = 220;
            // 
            // desCCostos
            // 
            this.desCCostos.DataPropertyName = "desCCostos";
            this.desCCostos.HeaderText = "CCosto";
            this.desCCostos.Name = "desCCostos";
            this.desCCostos.ReadOnly = true;
            // 
            // DesPersona
            // 
            this.DesPersona.DataPropertyName = "DesPersona";
            this.DesPersona.HeaderText = "Descripcion";
            this.DesPersona.Name = "DesPersona";
            this.DesPersona.ReadOnly = true;
            this.DesPersona.Width = 160;
            // 
            // idDocumento
            // 
            this.idDocumento.DataPropertyName = "idDocumento";
            this.idDocumento.HeaderText = "TD";
            this.idDocumento.Name = "idDocumento";
            this.idDocumento.ReadOnly = true;
            this.idDocumento.Width = 30;
            // 
            // serDocumento
            // 
            this.serDocumento.DataPropertyName = "serDocumento";
            this.serDocumento.HeaderText = "Serie";
            this.serDocumento.Name = "serDocumento";
            this.serDocumento.ReadOnly = true;
            this.serDocumento.Width = 40;
            // 
            // numDocumento
            // 
            this.numDocumento.DataPropertyName = "numDocumento";
            this.numDocumento.HeaderText = "Numero";
            this.numDocumento.Name = "numDocumento";
            this.numDocumento.ReadOnly = true;
            this.numDocumento.Width = 70;
            // 
            // fecDocumento
            // 
            this.fecDocumento.DataPropertyName = "fecDocumento";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fecDocumento.DefaultCellStyle = dataGridViewCellStyle2;
            this.fecDocumento.HeaderText = "Emisión";
            this.fecDocumento.Name = "fecDocumento";
            this.fecDocumento.ReadOnly = true;
            this.fecDocumento.Width = 70;
            // 
            // impDebe
            // 
            this.impDebe.DataPropertyName = "impDebe";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.impDebe.DefaultCellStyle = dataGridViewCellStyle3;
            this.impDebe.HeaderText = "Debe";
            this.impDebe.Name = "impDebe";
            this.impDebe.ReadOnly = true;
            this.impDebe.Width = 90;
            // 
            // impHaber
            // 
            this.impHaber.DataPropertyName = "impHaber";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.impHaber.DefaultCellStyle = dataGridViewCellStyle4;
            this.impHaber.HeaderText = "Haber";
            this.impHaber.Name = "impHaber";
            this.impHaber.ReadOnly = true;
            this.impHaber.Width = 90;
            // 
            // frmReporteEEFFGananciasyPerdidasDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 324);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSubHaber);
            this.Controls.Add(this.txtSubDebe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHaber);
            this.Controls.Add(this.txtDebe);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "frmReporteEEFFGananciasyPerdidasDetalle";
            this.Text = "Estados Financieros - Ganancias y Perdidas - Detalle";
            this.Load += new System.EventHandler(this.frmReporteEEFFGanaciasPerdidasDetalle_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVoucherItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.BindingSource bsVoucherItem;
        private MyLabelG.LabelDegradado lblregistros;
        private ControlesWinForm.SuperTextBox txtDebe;
        private ControlesWinForm.SuperTextBox txtHaber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private ControlesWinForm.SuperTextBox txtSubHaber;
        private ControlesWinForm.SuperTextBox txtSubDebe;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn indSolicitaCentroCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn numItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn desGlosa;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCCostos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn serDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn impDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn impHaber;
    }
}