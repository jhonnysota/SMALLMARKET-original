namespace ClienteWinForm.Maestros
{
    partial class frmListadoDocumentos
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
            this.bsDocumentos = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkIndBaja = new System.Windows.Forms.CheckBox();
            this.txtDocumento = new ControlesWinForm.SuperTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.idDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoSunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indBaja = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.LblRegistros = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocumentos)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // bsDocumentos
            // 
            this.bsDocumentos.DataSource = typeof(Entidades.Maestros.DocumentosE);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LblRegistros);
            this.panel2.Controls.Add(this.chkIndBaja);
            this.panel2.Controls.Add(this.txtDocumento);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 58);
            this.panel2.TabIndex = 76;
            // 
            // chkIndBaja
            // 
            this.chkIndBaja.AutoSize = true;
            this.chkIndBaja.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndBaja.Location = new System.Drawing.Point(452, 29);
            this.chkIndBaja.Name = "chkIndBaja";
            this.chkIndBaja.Size = new System.Drawing.Size(134, 17);
            this.chkIndBaja.TabIndex = 270;
            this.chkIndBaja.Text = "Incluir Doc. de Baja";
            this.chkIndBaja.UseVisualStyleBackColor = true;
            this.chkIndBaja.CheckedChanged += new System.EventHandler(this.chkIndBaja_CheckedChanged);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDocumento.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDocumento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(20, 27);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(417, 20);
            this.txtDocumento.TabIndex = 20;
            this.txtDocumento.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDocumento.TextoVacio = "Ingrese nombre del documento";
            this.txtDocumento.TextChanged += new System.EventHandler(this.txtDocumento_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvDocumentos);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(4, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 340);
            this.panel1.TabIndex = 75;
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AutoGenerateColumns = false;
            this.dgvDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDocumentoDataGridViewTextBoxColumn,
            this.desDocumento,
            this.CodigoSunat,
            this.indBaja,
            this.UsuarioRegistro,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvDocumentos.DataSource = this.bsDocumentos;
            this.dgvDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentos.EnableHeadersVisualStyles = false;
            this.dgvDocumentos.Location = new System.Drawing.Point(0, 18);
            this.dgvDocumentos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.ReadOnly = true;
            this.dgvDocumentos.RowTemplate.Height = 24;
            this.dgvDocumentos.Size = new System.Drawing.Size(615, 320);
            this.dgvDocumentos.TabIndex = 80;
            this.dgvDocumentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellDoubleClick);
            this.dgvDocumentos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocumentos_CellFormatting);
            this.dgvDocumentos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDocumentos_ColumnHeaderMouseClick);
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "TD";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desDocumento
            // 
            this.desDocumento.DataPropertyName = "desDocumento";
            this.desDocumento.HeaderText = "Nombres";
            this.desDocumento.Name = "desDocumento";
            this.desDocumento.ReadOnly = true;
            // 
            // CodigoSunat
            // 
            this.CodigoSunat.DataPropertyName = "CodigoSunat";
            this.CodigoSunat.HeaderText = "Cod.Sunat";
            this.CodigoSunat.Name = "CodigoSunat";
            this.CodigoSunat.ReadOnly = true;
            // 
            // indBaja
            // 
            this.indBaja.DataPropertyName = "indBaja";
            this.indBaja.HeaderText = "I.B.";
            this.indBaja.Name = "indBaja";
            this.indBaja.ReadOnly = true;
            this.indBaja.ToolTipText = "Indica dado de baja";
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UsuarioRegistro.DefaultCellStyle = dataGridViewCellStyle2;
            this.UsuarioRegistro.HeaderText = "Usuario Reg.";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            this.UsuarioRegistro.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
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
            // LblRegistros
            // 
            this.LblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.LblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRegistros.Location = new System.Drawing.Point(0, 0);
            this.LblRegistros.Name = "LblRegistros";
            this.LblRegistros.Size = new System.Drawing.Size(615, 18);
            this.LblRegistros.TabIndex = 1008;
            this.LblRegistros.Text = "Parámetros de Búsqueda";
            this.LblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(615, 18);
            this.lblTitulo.TabIndex = 429;
            this.lblTitulo.Text = "Registros 0";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 407);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoDocumentos";
            this.Text = "Listado Documentos";
            this.Load += new System.EventHandler(this.frmListadoDocumentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsDocumentos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDocumentos;
        private System.Windows.Forms.BindingSource bsDocumentos;
        protected internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkIndBaja;
        private ControlesWinForm.SuperTextBox txtDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoSunat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indBaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label LblRegistros;
        private System.Windows.Forms.Label lblTitulo;
    }
}