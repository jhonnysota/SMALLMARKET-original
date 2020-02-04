namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarVehiculoTransporte
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvVehiculos = new System.Windows.Forms.DataGridView();
            this.idTransporteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desVehicularDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numPlacaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numInscripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtVehiculo = new ControlesWinForm.SuperTextBox();
            this.rbRuc = new System.Windows.Forms.RadioButton();
            this.rbPlaca = new System.Windows.Forms.RadioButton();
            this.lblLetras = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Ventas.TransporteVehiculosE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(128, 316);
            this.btnAceptar.Size = new System.Drawing.Size(105, 25);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(238, 316);
            this.btnCancelar.Size = new System.Drawing.Size(105, 25);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(1107, 82);
            this.btnBuscar.Visible = false;
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(914, 78);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(615, 81);
            this.label1.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(615, 104);
            this.txtFiltro.Visible = false;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvVehiculos);
            this.gbResultados.Location = new System.Drawing.Point(4, 85);
            this.gbResultados.Size = new System.Drawing.Size(462, 225);
            // 
            // dgvVehiculos
            // 
            this.dgvVehiculos.AllowUserToAddRows = false;
            this.dgvVehiculos.AllowUserToDeleteRows = false;
            this.dgvVehiculos.AutoGenerateColumns = false;
            this.dgvVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehiculos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTransporteDataGridViewTextBoxColumn,
            this.desVehicularDataGridViewTextBoxColumn,
            this.numPlacaDataGridViewTextBoxColumn,
            this.marcaDataGridViewTextBoxColumn,
            this.numInscripcionDataGridViewTextBoxColumn,
            this.capacidadDataGridViewTextBoxColumn});
            this.dgvVehiculos.DataSource = this.bsBase;
            this.dgvVehiculos.EnableHeadersVisualStyles = false;
            this.dgvVehiculos.Location = new System.Drawing.Point(5, 15);
            this.dgvVehiculos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvVehiculos.Name = "dgvVehiculos";
            this.dgvVehiculos.ReadOnly = true;
            this.dgvVehiculos.RowTemplate.Height = 24;
            this.dgvVehiculos.Size = new System.Drawing.Size(451, 204);
            this.dgvVehiculos.TabIndex = 3;
            this.dgvVehiculos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehiculos_CellDoubleClick);
            this.dgvVehiculos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvVehiculos_CellFormatting);
            this.dgvVehiculos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvVehiculos_CellPainting);
            // 
            // idTransporteDataGridViewTextBoxColumn
            // 
            this.idTransporteDataGridViewTextBoxColumn.DataPropertyName = "idTransporte";
            this.idTransporteDataGridViewTextBoxColumn.HeaderText = "idTransporte";
            this.idTransporteDataGridViewTextBoxColumn.Name = "idTransporteDataGridViewTextBoxColumn";
            this.idTransporteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTransporteDataGridViewTextBoxColumn.Visible = false;
            // 
            // desVehicularDataGridViewTextBoxColumn
            // 
            this.desVehicularDataGridViewTextBoxColumn.DataPropertyName = "desVehicular";
            this.desVehicularDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desVehicularDataGridViewTextBoxColumn.Name = "desVehicularDataGridViewTextBoxColumn";
            this.desVehicularDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numPlacaDataGridViewTextBoxColumn
            // 
            this.numPlacaDataGridViewTextBoxColumn.DataPropertyName = "numPlaca";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numPlacaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.numPlacaDataGridViewTextBoxColumn.HeaderText = "Placa";
            this.numPlacaDataGridViewTextBoxColumn.Name = "numPlacaDataGridViewTextBoxColumn";
            this.numPlacaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // marcaDataGridViewTextBoxColumn
            // 
            this.marcaDataGridViewTextBoxColumn.DataPropertyName = "Marca";
            this.marcaDataGridViewTextBoxColumn.HeaderText = "Marca";
            this.marcaDataGridViewTextBoxColumn.Name = "marcaDataGridViewTextBoxColumn";
            this.marcaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numInscripcionDataGridViewTextBoxColumn
            // 
            this.numInscripcionDataGridViewTextBoxColumn.DataPropertyName = "numInscripcion";
            this.numInscripcionDataGridViewTextBoxColumn.HeaderText = "N° Inscripcion";
            this.numInscripcionDataGridViewTextBoxColumn.Name = "numInscripcionDataGridViewTextBoxColumn";
            this.numInscripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // capacidadDataGridViewTextBoxColumn
            // 
            this.capacidadDataGridViewTextBoxColumn.DataPropertyName = "Capacidad";
            this.capacidadDataGridViewTextBoxColumn.HeaderText = "Capacidad";
            this.capacidadDataGridViewTextBoxColumn.Name = "capacidadDataGridViewTextBoxColumn";
            this.capacidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLetras);
            this.panel1.Controls.Add(this.txtVehiculo);
            this.panel1.Controls.Add(this.rbRuc);
            this.panel1.Controls.Add(this.rbPlaca);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 79);
            this.panel1.TabIndex = 10;
            // 
            // txtVehiculo
            // 
            this.txtVehiculo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtVehiculo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtVehiculo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehiculo.Location = new System.Drawing.Point(17, 48);
            this.txtVehiculo.Name = "txtVehiculo";
            this.txtVehiculo.Size = new System.Drawing.Size(425, 21);
            this.txtVehiculo.TabIndex = 250;
            this.txtVehiculo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtVehiculo.TextoVacio = "Ingrese Placa o Marca del vehículo";
            this.txtVehiculo.TextChanged += new System.EventHandler(this.txtVehiculo_TextChanged);
            this.txtVehiculo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVehiculo_KeyDown);
            // 
            // rbRuc
            // 
            this.rbRuc.AutoSize = true;
            this.rbRuc.Location = new System.Drawing.Point(113, 26);
            this.rbRuc.Name = "rbRuc";
            this.rbRuc.Size = new System.Drawing.Size(55, 17);
            this.rbRuc.TabIndex = 10;
            this.rbRuc.Text = "Marca";
            this.rbRuc.UseVisualStyleBackColor = true;
            // 
            // rbPlaca
            // 
            this.rbPlaca.AutoSize = true;
            this.rbPlaca.Checked = true;
            this.rbPlaca.Location = new System.Drawing.Point(19, 26);
            this.rbPlaca.Name = "rbPlaca";
            this.rbPlaca.Size = new System.Drawing.Size(52, 17);
            this.rbPlaca.TabIndex = 8;
            this.rbPlaca.TabStop = true;
            this.rbPlaca.Text = "Placa";
            this.rbPlaca.UseVisualStyleBackColor = true;
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(460, 18);
            this.lblLetras.TabIndex = 1573;
            this.lblLetras.Text = "Parámetros de Búsqueda";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBuscarVehiculoTransporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 346);
            this.Controls.Add(this.panel1);
            this.Name = "frmBuscarVehiculoTransporte";
            this.Text = "Buscar Vehiculo de Transporte";
            this.Load += new System.EventHandler(this.frmBuscarVehiculoTransporte_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVehiculos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTransporteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desVehicularDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numPlacaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numInscripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private ControlesWinForm.SuperTextBox txtVehiculo;
        private System.Windows.Forms.RadioButton rbRuc;
        private System.Windows.Forms.RadioButton rbPlaca;
        private System.Windows.Forms.Label lblLetras;
    }
}