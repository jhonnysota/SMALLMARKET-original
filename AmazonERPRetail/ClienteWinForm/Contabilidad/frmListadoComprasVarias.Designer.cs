namespace ClienteWinForm.Contabilidad
{
    partial class frmListadoComprasVarias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsComprasVarias = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNroActa = new ControlesWinForm.SuperTextBox();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipCambioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montAfecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montInafecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montIGVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indRectificacionDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fecRectificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsComprasVarias)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // bsComprasVarias
            // 
            this.bsComprasVarias.DataSource = typeof(Entidades.Contabilidad.ComprasVariasE);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtNroActa);
            this.panel3.Controls.Add(this.cboAnio);
            this.panel3.Controls.Add(this.labelDegradado3);
            this.panel3.Controls.Add(this.cboPeriodo);
            this.panel3.Location = new System.Drawing.Point(4, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(453, 60);
            this.panel3.TabIndex = 258;
            // 
            // txtNroActa
            // 
            this.txtNroActa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtNroActa.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNroActa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroActa.Location = new System.Drawing.Point(287, 28);
            this.txtNroActa.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroActa.Name = "txtNroActa";
            this.txtNroActa.Size = new System.Drawing.Size(151, 20);
            this.txtNroActa.TabIndex = 259;
            this.txtNroActa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNroActa.TextoVacio = "Ingrese Nro.  de Acta";
            this.txtNroActa.TextChanged += new System.EventHandler(this.txtNroActa_TextChanged);
            // 
            // cboAnio
            // 
            this.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(13, 28);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(83, 21);
            this.cboAnio.TabIndex = 250;
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(451, 20);
            this.labelDegradado3.TabIndex = 249;
            this.labelDegradado3.Text = "Parametros de Búsqueda";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Location = new System.Drawing.Point(101, 28);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(142, 21);
            this.cboPeriodo.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvDocumentos);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(4, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(937, 411);
            this.panel1.TabIndex = 257;
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AutoGenerateColumns = false;
            this.dgvDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RazonSocial,
            this.desMoneda,
            this.fecOperacion,
            this.numRegistro,
            this.tipDocumento,
            this.serDocumento,
            this.numDocumento,
            this.tipCambioDataGridViewTextBoxColumn,
            this.montAfecto,
            this.montInafecto,
            this.montIGVDataGridViewTextBoxColumn,
            this.montTotal,
            this.indRectificacionDataGridViewCheckBoxColumn,
            this.fecRectificacionDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvDocumentos.DataSource = this.bsComprasVarias;
            this.dgvDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentos.EnableHeadersVisualStyles = false;
            this.dgvDocumentos.Location = new System.Drawing.Point(0, 23);
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.ReadOnly = true;
            this.dgvDocumentos.Size = new System.Drawing.Size(935, 386);
            this.dgvDocumentos.TabIndex = 248;
            this.dgvDocumentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellDoubleClick);
            this.dgvDocumentos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDocumentos_ColumnHeaderMouseClick);
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
            this.lblRegistros.Size = new System.Drawing.Size(935, 23);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Compras Varias - Registro";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.Frozen = true;
            this.RazonSocial.HeaderText = "Razon Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.desMoneda.DefaultCellStyle = dataGridViewCellStyle1;
            this.desMoneda.HeaderText = "Mon.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            // 
            // fecOperacion
            // 
            this.fecOperacion.DataPropertyName = "fecOperacion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            this.fecOperacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.fecOperacion.HeaderText = "Fecha";
            this.fecOperacion.Name = "fecOperacion";
            this.fecOperacion.ReadOnly = true;
            // 
            // numRegistro
            // 
            this.numRegistro.DataPropertyName = "numRegistro";
            this.numRegistro.HeaderText = "Acta";
            this.numRegistro.Name = "numRegistro";
            this.numRegistro.ReadOnly = true;
            // 
            // tipDocumento
            // 
            this.tipDocumento.DataPropertyName = "tipDocumento";
            this.tipDocumento.HeaderText = "TD";
            this.tipDocumento.Name = "tipDocumento";
            this.tipDocumento.ReadOnly = true;
            // 
            // serDocumento
            // 
            this.serDocumento.DataPropertyName = "serDocumento";
            this.serDocumento.HeaderText = "Serie";
            this.serDocumento.Name = "serDocumento";
            this.serDocumento.ReadOnly = true;
            // 
            // numDocumento
            // 
            this.numDocumento.DataPropertyName = "numDocumento";
            this.numDocumento.HeaderText = "Num.Doc.";
            this.numDocumento.Name = "numDocumento";
            this.numDocumento.ReadOnly = true;
            // 
            // tipCambioDataGridViewTextBoxColumn
            // 
            this.tipCambioDataGridViewTextBoxColumn.DataPropertyName = "tipCambio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.tipCambioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.tipCambioDataGridViewTextBoxColumn.HeaderText = "T.C.";
            this.tipCambioDataGridViewTextBoxColumn.Name = "tipCambioDataGridViewTextBoxColumn";
            this.tipCambioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montAfecto
            // 
            this.montAfecto.DataPropertyName = "montAfecto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.montAfecto.DefaultCellStyle = dataGridViewCellStyle4;
            this.montAfecto.HeaderText = "Afecto";
            this.montAfecto.Name = "montAfecto";
            this.montAfecto.ReadOnly = true;
            // 
            // montInafecto
            // 
            this.montInafecto.DataPropertyName = "montInafecto";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.montInafecto.DefaultCellStyle = dataGridViewCellStyle5;
            this.montInafecto.HeaderText = "Inafecto";
            this.montInafecto.Name = "montInafecto";
            this.montInafecto.ReadOnly = true;
            // 
            // montIGVDataGridViewTextBoxColumn
            // 
            this.montIGVDataGridViewTextBoxColumn.DataPropertyName = "montIGV";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.montIGVDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.montIGVDataGridViewTextBoxColumn.HeaderText = "IGV";
            this.montIGVDataGridViewTextBoxColumn.Name = "montIGVDataGridViewTextBoxColumn";
            this.montIGVDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montTotal
            // 
            this.montTotal.DataPropertyName = "montTotal";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.montTotal.DefaultCellStyle = dataGridViewCellStyle7;
            this.montTotal.HeaderText = "Total";
            this.montTotal.Name = "montTotal";
            this.montTotal.ReadOnly = true;
            // 
            // indRectificacionDataGridViewCheckBoxColumn
            // 
            this.indRectificacionDataGridViewCheckBoxColumn.DataPropertyName = "indRectificacion";
            this.indRectificacionDataGridViewCheckBoxColumn.HeaderText = "I.R.";
            this.indRectificacionDataGridViewCheckBoxColumn.Name = "indRectificacionDataGridViewCheckBoxColumn";
            this.indRectificacionDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indRectificacionDataGridViewCheckBoxColumn.ToolTipText = "Indica Rectificación";
            // 
            // fecRectificacionDataGridViewTextBoxColumn
            // 
            this.fecRectificacionDataGridViewTextBoxColumn.DataPropertyName = "fecRectificacion";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecRectificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.fecRectificacionDataGridViewTextBoxColumn.HeaderText = "Fec.Rect.";
            this.fecRectificacionDataGridViewTextBoxColumn.Name = "fecRectificacionDataGridViewTextBoxColumn";
            this.fecRectificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmListadoComprasVarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(944, 487);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmListadoComprasVarias";
            this.Text = "Listado Compras Varias";
            this.Activated += new System.EventHandler(this.frmListadoComprasVarias_Activated);
            this.Load += new System.EventHandler(this.frmListadoComprasVarias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsComprasVarias)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDocumentos;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Panel panel3;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.BindingSource bsComprasVarias;
        private ControlesWinForm.SuperTextBox txtNroActa;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn numRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn serDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipCambioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montAfecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn montInafecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn montIGVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montTotal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indRectificacionDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecRectificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}