namespace ClienteWinForm.Tesoreria
{
    partial class frmListadoFondoFijo
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
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvFondoFijo = new System.Windows.Forms.DataGridView();
            this.numFondo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desFondo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoAutorizadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desResponsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFondoFijo = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.rbRendir = new System.Windows.Forms.RadioButton();
            this.rbFijos = new System.Windows.Forms.RadioButton();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFondoFijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFondoFijo)).BeginInit();
            this.pnlDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvFondoFijo);
            this.pnlDetalle.Controls.Add(this.lblRegistros);
            this.pnlDetalle.Location = new System.Drawing.Point(3, 63);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(904, 311);
            this.pnlDetalle.TabIndex = 359;
            // 
            // dgvFondoFijo
            // 
            this.dgvFondoFijo.AllowUserToAddRows = false;
            this.dgvFondoFijo.AllowUserToDeleteRows = false;
            this.dgvFondoFijo.AutoGenerateColumns = false;
            this.dgvFondoFijo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvFondoFijo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFondoFijo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFondoFijo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numFondo,
            this.desFondo,
            this.codCuentaDataGridViewTextBoxColumn,
            this.desCuenta,
            this.desMoneda,
            this.montoAutorizadoDataGridViewTextBoxColumn,
            this.desResponsable,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvFondoFijo.DataSource = this.bsFondoFijo;
            this.dgvFondoFijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFondoFijo.EnableHeadersVisualStyles = false;
            this.dgvFondoFijo.Location = new System.Drawing.Point(0, 16);
            this.dgvFondoFijo.Name = "dgvFondoFijo";
            this.dgvFondoFijo.ReadOnly = true;
            this.dgvFondoFijo.Size = new System.Drawing.Size(902, 293);
            this.dgvFondoFijo.TabIndex = 248;
            this.dgvFondoFijo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFondoFijo_CellDoubleClick);
            // 
            // numFondo
            // 
            this.numFondo.DataPropertyName = "numFondo";
            this.numFondo.HeaderText = "Ruc/N° Iden.";
            this.numFondo.Name = "numFondo";
            this.numFondo.ReadOnly = true;
            // 
            // desFondo
            // 
            this.desFondo.DataPropertyName = "desFondo";
            this.desFondo.HeaderText = "Fondo";
            this.desFondo.Name = "desFondo";
            this.desFondo.ReadOnly = true;
            this.desFondo.Width = 200;
            // 
            // codCuentaDataGridViewTextBoxColumn
            // 
            this.codCuentaDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCuentaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.codCuentaDataGridViewTextBoxColumn.HeaderText = "Cod.Cuenta";
            this.codCuentaDataGridViewTextBoxColumn.Name = "codCuentaDataGridViewTextBoxColumn";
            this.codCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCuentaDataGridViewTextBoxColumn.Width = 80;
            // 
            // desCuenta
            // 
            this.desCuenta.DataPropertyName = "desCuenta";
            this.desCuenta.HeaderText = "Cuenta";
            this.desCuenta.Name = "desCuenta";
            this.desCuenta.ReadOnly = true;
            this.desCuenta.Width = 200;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            this.desMoneda.HeaderText = "Moneda";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 80;
            // 
            // montoAutorizadoDataGridViewTextBoxColumn
            // 
            this.montoAutorizadoDataGridViewTextBoxColumn.DataPropertyName = "MontoAutorizado";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.montoAutorizadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.montoAutorizadoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoAutorizadoDataGridViewTextBoxColumn.Name = "montoAutorizadoDataGridViewTextBoxColumn";
            this.montoAutorizadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoAutorizadoDataGridViewTextBoxColumn.Width = 90;
            // 
            // desResponsable
            // 
            this.desResponsable.DataPropertyName = "desResponsable";
            this.desResponsable.HeaderText = "Responsable";
            this.desResponsable.Name = "desResponsable";
            this.desResponsable.ReadOnly = true;
            this.desResponsable.Width = 150;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 120;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // bsFondoFijo
            // 
            this.bsFondoFijo.DataSource = typeof(Entidades.Tesoreria.FondoFijoE);
            this.bsFondoFijo.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsFondoFijo_ListChanged);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(902, 16);
            this.lblRegistros.TabIndex = 258;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.rbRendir);
            this.pnlDatos.Controls.Add(this.rbFijos);
            this.pnlDatos.Controls.Add(this.labelDegradado2);
            this.pnlDatos.Location = new System.Drawing.Point(3, 3);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(256, 58);
            this.pnlDatos.TabIndex = 360;
            // 
            // rbRendir
            // 
            this.rbRendir.AutoSize = true;
            this.rbRendir.Location = new System.Drawing.Point(124, 29);
            this.rbRendir.Name = "rbRendir";
            this.rbRendir.Size = new System.Drawing.Size(110, 17);
            this.rbRendir.TabIndex = 272;
            this.rbRendir.Text = "Entregas a Rendir";
            this.rbRendir.UseVisualStyleBackColor = true;
            this.rbRendir.CheckedChanged += new System.EventHandler(this.rbRendir_CheckedChanged);
            // 
            // rbFijos
            // 
            this.rbFijos.AutoSize = true;
            this.rbFijos.Checked = true;
            this.rbFijos.Location = new System.Drawing.Point(22, 29);
            this.rbFijos.Name = "rbFijos";
            this.rbFijos.Size = new System.Drawing.Size(84, 17);
            this.rbFijos.TabIndex = 271;
            this.rbFijos.TabStop = true;
            this.rbFijos.Text = "Fondos Fijos";
            this.rbFijos.UseVisualStyleBackColor = true;
            this.rbFijos.CheckedChanged += new System.EventHandler(this.rbFijos_CheckedChanged);
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(254, 16);
            this.labelDegradado2.TabIndex = 270;
            this.labelDegradado2.Text = "Tipo";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoFondoFijo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 377);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlDetalle);
            this.MaximizeBox = false;
            this.Name = "frmListadoFondoFijo";
            this.Text = "Listado Fondo Fijo y Ctas. a Rendir";
            this.Load += new System.EventHandler(this.frmListadoFondoFijo_Load);
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFondoFijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFondoFijo)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.DataGridView dgvFondoFijo;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsFondoFijo;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.RadioButton rbRendir;
        private System.Windows.Forms.RadioButton rbFijos;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFondo;
        private System.Windows.Forms.DataGridViewTextBoxColumn desFondo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoAutorizadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desResponsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}