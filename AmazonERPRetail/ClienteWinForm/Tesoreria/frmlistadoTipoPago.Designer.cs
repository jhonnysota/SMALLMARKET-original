namespace ClienteWinForm.Tesoreria
{
    partial class frmlistadoTipoPago
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsTipoPago = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTitulo = new MyLabelG.LabelDegradado();
            this.codTipoPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipoPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indTipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codTipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indDetalle = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HabilitarDatos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indSolProv = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indEstado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsTipoPago)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // bsTipoPago
            // 
            this.bsTipoPago.DataSource = typeof(Entidades.Tesoreria.TipoPagoE);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvDocumentos);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 274);
            this.panel1.TabIndex = 78;
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AutoGenerateColumns = false;
            this.dgvDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvDocumentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codTipoPagoDataGridViewTextBoxColumn,
            this.desTipoPagoDataGridViewTextBoxColumn,
            this.indTipoDataGridViewTextBoxColumn,
            this.codTipoDataGridViewTextBoxColumn,
            this.indDetalle,
            this.HabilitarDatos,
            this.indSolProv,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.indEstado});
            this.dgvDocumentos.DataSource = this.bsTipoPago;
            this.dgvDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentos.EnableHeadersVisualStyles = false;
            this.dgvDocumentos.Location = new System.Drawing.Point(0, 18);
            this.dgvDocumentos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.ReadOnly = true;
            this.dgvDocumentos.RowTemplate.Height = 24;
            this.dgvDocumentos.Size = new System.Drawing.Size(640, 254);
            this.dgvDocumentos.TabIndex = 80;
            this.dgvDocumentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellDoubleClick);
            this.dgvDocumentos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocumentos_CellFormatting);
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblTitulo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTitulo.Size = new System.Drawing.Size(640, 18);
            this.lblTitulo.TabIndex = 270;
            this.lblTitulo.Text = "Registros 0";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // codTipoPagoDataGridViewTextBoxColumn
            // 
            this.codTipoPagoDataGridViewTextBoxColumn.DataPropertyName = "codTipoPago";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codTipoPagoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.codTipoPagoDataGridViewTextBoxColumn.HeaderText = "Cód.";
            this.codTipoPagoDataGridViewTextBoxColumn.Name = "codTipoPagoDataGridViewTextBoxColumn";
            this.codTipoPagoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desTipoPagoDataGridViewTextBoxColumn
            // 
            this.desTipoPagoDataGridViewTextBoxColumn.DataPropertyName = "desTipoPago";
            this.desTipoPagoDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desTipoPagoDataGridViewTextBoxColumn.Name = "desTipoPagoDataGridViewTextBoxColumn";
            this.desTipoPagoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // indTipoDataGridViewTextBoxColumn
            // 
            this.indTipoDataGridViewTextBoxColumn.DataPropertyName = "indTipo";
            this.indTipoDataGridViewTextBoxColumn.HeaderText = "Ind.Tip.";
            this.indTipoDataGridViewTextBoxColumn.Name = "indTipoDataGridViewTextBoxColumn";
            this.indTipoDataGridViewTextBoxColumn.ReadOnly = true;
            this.indTipoDataGridViewTextBoxColumn.Visible = false;
            // 
            // codTipoDataGridViewTextBoxColumn
            // 
            this.codTipoDataGridViewTextBoxColumn.DataPropertyName = "codTipo";
            this.codTipoDataGridViewTextBoxColumn.HeaderText = "codTipo";
            this.codTipoDataGridViewTextBoxColumn.Name = "codTipoDataGridViewTextBoxColumn";
            this.codTipoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codTipoDataGridViewTextBoxColumn.Visible = false;
            // 
            // indDetalle
            // 
            this.indDetalle.DataPropertyName = "indDetalle";
            this.indDetalle.HeaderText = "ConDetalle";
            this.indDetalle.Name = "indDetalle";
            this.indDetalle.ReadOnly = true;
            this.indDetalle.Width = 65;
            // 
            // HabilitarDatos
            // 
            this.HabilitarDatos.DataPropertyName = "HabilitarDatos";
            this.HabilitarDatos.HeaderText = "HabilitarOP";
            this.HabilitarDatos.Name = "HabilitarDatos";
            this.HabilitarDatos.ReadOnly = true;
            this.HabilitarDatos.Width = 66;
            // 
            // indSolProv
            // 
            this.indSolProv.DataPropertyName = "indSolProv";
            this.indSolProv.HeaderText = "ConSolProv.";
            this.indSolProv.Name = "indSolProv";
            this.indSolProv.ReadOnly = true;
            this.indSolProv.Width = 72;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // indEstado
            // 
            this.indEstado.DataPropertyName = "indEstado";
            this.indEstado.HeaderText = "indEstado";
            this.indEstado.Name = "indEstado";
            this.indEstado.ReadOnly = true;
            this.indEstado.Visible = false;
            // 
            // frmlistadoTipoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(642, 274);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmlistadoTipoPago";
            this.Text = "Listado de Tipos de Pago";
            this.Load += new System.EventHandler(this.frmlistadoTipoPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsTipoPago)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDocumentos;
        protected internal System.Windows.Forms.Button button1;
        private MyLabelG.LabelDegradado lblTitulo;
        private System.Windows.Forms.BindingSource bsTipoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn codTipoPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipoPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indTipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codTipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indDetalle;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HabilitarDatos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indSolProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indEstado;
    }
}