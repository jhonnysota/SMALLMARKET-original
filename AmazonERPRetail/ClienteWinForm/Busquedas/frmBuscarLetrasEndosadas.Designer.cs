namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarLetrasEndosadas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAuxiliar = new ControlesWinForm.SuperTextBox();
            this.txtEmpresa = new ControlesWinForm.SuperTextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.dgvLetras = new System.Windows.Forms.DataGridView();
            this.Escoger = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.razonSocialEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialAuxiliarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMonedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoLetrasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.letraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLetras = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLetras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(803, 19);
            this.lblTitPnlBase.Text = "Letras 0";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(818, 25);
            this.lblTituloPrincipal.Text = "Búsqueda de Letras Endosadas";
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Ventas.PlanillaBancosE);
            this.bsBase.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsBase_ListChanged);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(790, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.dgvLetras);
            this.pnlBase.Location = new System.Drawing.Point(6, 111);
            this.pnlBase.Size = new System.Drawing.Size(805, 257);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.dgvLetras, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(411, 375);
            this.btCancelar.Size = new System.Drawing.Size(112, 26);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(287, 375);
            this.btAceptar.Size = new System.Drawing.Size(112, 26);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLetras);
            this.panel1.Controls.Add(this.txtAuxiliar);
            this.panel1.Controls.Add(this.txtEmpresa);
            this.panel1.Controls.Add(this.btBuscar);
            this.panel1.Location = new System.Drawing.Point(6, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 81);
            this.panel1.TabIndex = 263;
            // 
            // txtAuxiliar
            // 
            this.txtAuxiliar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtAuxiliar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtAuxiliar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuxiliar.Location = new System.Drawing.Point(21, 48);
            this.txtAuxiliar.Name = "txtAuxiliar";
            this.txtAuxiliar.Size = new System.Drawing.Size(438, 20);
            this.txtAuxiliar.TabIndex = 305;
            this.txtAuxiliar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtAuxiliar.TextoVacio = "Razon Social del Auxiliar";
            this.txtAuxiliar.TextChanged += new System.EventHandler(this.txtAuxiliar_TextChanged);
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtEmpresa.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtEmpresa.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpresa.Location = new System.Drawing.Point(21, 25);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(438, 20);
            this.txtEmpresa.TabIndex = 304;
            this.txtEmpresa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtEmpresa.TextoVacio = "Razon Social de la Empresa";
            this.txtEmpresa.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            // 
            // btBuscar
            // 
            this.btBuscar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.busquedas;
            this.btBuscar.Location = new System.Drawing.Point(664, 0);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(62, 79);
            this.btBuscar.TabIndex = 303;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // dgvLetras
            // 
            this.dgvLetras.AllowUserToAddRows = false;
            this.dgvLetras.AllowUserToDeleteRows = false;
            this.dgvLetras.AutoGenerateColumns = false;
            this.dgvLetras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLetras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLetras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Escoger,
            this.razonSocialEmpresaDataGridViewTextBoxColumn,
            this.razonSocialAuxiliarDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.desMonedaDataGridViewTextBoxColumn,
            this.montoLetrasDataGridViewTextBoxColumn,
            this.letraDataGridViewTextBoxColumn,
            this.codCuentaDataGridViewTextBoxColumn});
            this.dgvLetras.DataSource = this.bsBase;
            this.dgvLetras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLetras.EnableHeadersVisualStyles = false;
            this.dgvLetras.Location = new System.Drawing.Point(0, 19);
            this.dgvLetras.Name = "dgvLetras";
            this.dgvLetras.Size = new System.Drawing.Size(803, 236);
            this.dgvLetras.TabIndex = 254;
            this.dgvLetras.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvLetras_CellPainting);
            this.dgvLetras.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLetras_CellValueChanged);
            this.dgvLetras.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvLetras_CurrentCellDirtyStateChanged);
            // 
            // Escoger
            // 
            this.Escoger.DataPropertyName = "Escoger";
            this.Escoger.HeaderText = "";
            this.Escoger.Name = "Escoger";
            this.Escoger.Width = 20;
            // 
            // razonSocialEmpresaDataGridViewTextBoxColumn
            // 
            this.razonSocialEmpresaDataGridViewTextBoxColumn.DataPropertyName = "RazonSocialEmpresa";
            this.razonSocialEmpresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.razonSocialEmpresaDataGridViewTextBoxColumn.Name = "razonSocialEmpresaDataGridViewTextBoxColumn";
            this.razonSocialEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialEmpresaDataGridViewTextBoxColumn.Width = 160;
            // 
            // razonSocialAuxiliarDataGridViewTextBoxColumn
            // 
            this.razonSocialAuxiliarDataGridViewTextBoxColumn.DataPropertyName = "RazonSocialAuxiliar";
            this.razonSocialAuxiliarDataGridViewTextBoxColumn.HeaderText = "Auxiliar";
            this.razonSocialAuxiliarDataGridViewTextBoxColumn.Name = "razonSocialAuxiliarDataGridViewTextBoxColumn";
            this.razonSocialAuxiliarDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialAuxiliarDataGridViewTextBoxColumn.Width = 200;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 70;
            // 
            // desMonedaDataGridViewTextBoxColumn
            // 
            this.desMonedaDataGridViewTextBoxColumn.DataPropertyName = "desMoneda";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.desMonedaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.desMonedaDataGridViewTextBoxColumn.HeaderText = "Mon.";
            this.desMonedaDataGridViewTextBoxColumn.Name = "desMonedaDataGridViewTextBoxColumn";
            this.desMonedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.desMonedaDataGridViewTextBoxColumn.Width = 30;
            // 
            // montoLetrasDataGridViewTextBoxColumn
            // 
            this.montoLetrasDataGridViewTextBoxColumn.DataPropertyName = "MontoLetras";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.montoLetrasDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.montoLetrasDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoLetrasDataGridViewTextBoxColumn.Name = "montoLetrasDataGridViewTextBoxColumn";
            this.montoLetrasDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoLetrasDataGridViewTextBoxColumn.Width = 80;
            // 
            // letraDataGridViewTextBoxColumn
            // 
            this.letraDataGridViewTextBoxColumn.DataPropertyName = "Letra";
            this.letraDataGridViewTextBoxColumn.HeaderText = "Letra";
            this.letraDataGridViewTextBoxColumn.Name = "letraDataGridViewTextBoxColumn";
            this.letraDataGridViewTextBoxColumn.ReadOnly = true;
            this.letraDataGridViewTextBoxColumn.Width = 90;
            // 
            // codCuentaDataGridViewTextBoxColumn
            // 
            this.codCuentaDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCuentaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.codCuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.codCuentaDataGridViewTextBoxColumn.Name = "codCuentaDataGridViewTextBoxColumn";
            this.codCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCuentaDataGridViewTextBoxColumn.Width = 70;
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(664, 18);
            this.lblLetras.TabIndex = 1573;
            this.lblLetras.Text = "Auxiliar";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBuscarLetrasEndosadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 410);
            this.Controls.Add(this.panel1);
            this.Name = "frmBuscarLetrasEndosadas";
            this.Text = "frmBuscarLetrasEndosadas";
            this.Load += new System.EventHandler(this.frmBuscarLetrasEndosadas_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvLetras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btBuscar;
        private ControlesWinForm.SuperTextBox txtAuxiliar;
        private System.Windows.Forms.DataGridView dgvLetras;
        private ControlesWinForm.SuperTextBox txtEmpresa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Escoger;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialAuxiliarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMonedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoLetrasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn letraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblLetras;
    }
}