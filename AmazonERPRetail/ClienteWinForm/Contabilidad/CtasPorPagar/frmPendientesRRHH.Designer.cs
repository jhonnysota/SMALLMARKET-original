namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmPendientesRRHH
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdCliente = new ControlesWinForm.SuperTextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.dgvDocumentosPendientes = new System.Windows.Forms.DataGridView();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desGlosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentosPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(447, 453);
            this.btCancelar.Size = new System.Drawing.Size(128, 32);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(312, 453);
            this.btAceptar.Size = new System.Drawing.Size(128, 32);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(867, 17);
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(885, 25);
            this.lblTituloPrincipal.Text = "Pendientes Recibos por Honorarios";
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Tesoreria.CtaCteE);
            this.bsBase.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsBase_ListChanged);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(855, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.dgvDocumentosPendientes);
            this.pnlBase.Location = new System.Drawing.Point(8, 96);
            this.pnlBase.Size = new System.Drawing.Size(869, 350);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.dgvDocumentosPendientes, 0);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Controls.Add(this.btBuscar);
            this.panel1.Controls.Add(this.chkTodos);
            this.panel1.Controls.Add(this.txtRuc);
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.labelDegradado2);
            this.panel1.Location = new System.Drawing.Point(8, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 66);
            this.panel1.TabIndex = 261;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdCliente.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdCliente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(106, 29);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(48, 20);
            this.txtIdCliente.TabIndex = 304;
            this.txtIdCliente.TabStop = false;
            this.txtIdCliente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdCliente.TextoVacio = "";
            // 
            // btBuscar
            // 
            this.btBuscar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscar.FlatAppearance.BorderSize = 0;
            this.btBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.busquedas;
            this.btBuscar.Location = new System.Drawing.Point(774, 17);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(93, 47);
            this.btBuscar.TabIndex = 303;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Checked = true;
            this.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodos.Location = new System.Drawing.Point(48, 31);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(56, 17);
            this.chkTodos.TabIndex = 261;
            this.chkTodos.Text = "Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Enabled = false;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(156, 29);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(80, 20);
            this.txtRuc.TabIndex = 300;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "<Descripcion>";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(239, 29);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(517, 20);
            this.txtRazonSocial.TabIndex = 302;
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRazonSocial_KeyPress);
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
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
            this.labelDegradado2.Size = new System.Drawing.Size(867, 17);
            this.labelDegradado2.TabIndex = 258;
            this.labelDegradado2.Text = "Auxiliar";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDocumentosPendientes
            // 
            this.dgvDocumentosPendientes.AllowUserToAddRows = false;
            this.dgvDocumentosPendientes.AllowUserToDeleteRows = false;
            this.dgvDocumentosPendientes.AutoGenerateColumns = false;
            this.dgvDocumentosPendientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocumentosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentosPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.razonSocialDataGridViewTextBoxColumn,
            this.desGlosa,
            this.codCuentaDataGridViewTextBoxColumn,
            this.idDocumento,
            this.numSerie,
            this.numDocumento,
            this.FechaDocumento,
            this.desMoneda,
            this.Saldo});
            this.dgvDocumentosPendientes.DataSource = this.bsBase;
            this.dgvDocumentosPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentosPendientes.EnableHeadersVisualStyles = false;
            this.dgvDocumentosPendientes.Location = new System.Drawing.Point(0, 17);
            this.dgvDocumentosPendientes.Name = "dgvDocumentosPendientes";
            this.dgvDocumentosPendientes.ReadOnly = true;
            this.dgvDocumentosPendientes.Size = new System.Drawing.Size(867, 331);
            this.dgvDocumentosPendientes.TabIndex = 252;
            this.dgvDocumentosPendientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentosPendientes_CellDoubleClick);
            this.dgvDocumentosPendientes.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDocumentosPendientes_CellPainting);
            this.dgvDocumentosPendientes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentosPendientes_CellValueChanged);
            this.dgvDocumentosPendientes.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDocumentosPendientes_CurrentCellDirtyStateChanged);
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "Razón Social";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 200;
            // 
            // desGlosa
            // 
            this.desGlosa.DataPropertyName = "desGlosa";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desGlosa.DefaultCellStyle = dataGridViewCellStyle1;
            this.desGlosa.HeaderText = "Concepto";
            this.desGlosa.Name = "desGlosa";
            this.desGlosa.ReadOnly = true;
            this.desGlosa.Width = 150;
            // 
            // codCuentaDataGridViewTextBoxColumn
            // 
            this.codCuentaDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            this.codCuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.codCuentaDataGridViewTextBoxColumn.Name = "codCuentaDataGridViewTextBoxColumn";
            this.codCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCuentaDataGridViewTextBoxColumn.Width = 50;
            // 
            // idDocumento
            // 
            this.idDocumento.DataPropertyName = "idDocumento";
            this.idDocumento.HeaderText = "T.D.";
            this.idDocumento.Name = "idDocumento";
            this.idDocumento.ReadOnly = true;
            this.idDocumento.Width = 30;
            // 
            // numSerie
            // 
            this.numSerie.DataPropertyName = "numSerie";
            this.numSerie.HeaderText = "Serie";
            this.numSerie.Name = "numSerie";
            this.numSerie.ReadOnly = true;
            this.numSerie.Width = 40;
            // 
            // numDocumento
            // 
            this.numDocumento.DataPropertyName = "numDocumento";
            this.numDocumento.HeaderText = "Número";
            this.numDocumento.Name = "numDocumento";
            this.numDocumento.ReadOnly = true;
            this.numDocumento.Width = 70;
            // 
            // FechaDocumento
            // 
            this.FechaDocumento.DataPropertyName = "FechaDocumento";
            this.FechaDocumento.HeaderText = "Fec.Doc.";
            this.FechaDocumento.Name = "FechaDocumento";
            this.FechaDocumento.ReadOnly = true;
            this.FechaDocumento.Width = 70;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.desMoneda.DefaultCellStyle = dataGridViewCellStyle2;
            this.desMoneda.HeaderText = "Mon.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 40;
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Saldo.HeaderText = "Neto";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            this.Saldo.Width = 80;
            // 
            // frmPendientesRRHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 496);
            this.Controls.Add(this.panel1);
            this.Name = "frmPendientesRRHH";
            this.Text = "frmPendientesRRHH";
            this.Load += new System.EventHandler(this.frmPendientesRRHH_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentosPendientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ControlesWinForm.SuperTextBox txtIdCliente;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.CheckBox chkTodos;
        private ControlesWinForm.SuperTextBox txtRuc;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.DataGridView dgvDocumentosPendientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desGlosa;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
    }
}