namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarCuentasMigraciones
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
            this.numHojaCostoLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbPorDescripcion = new System.Windows.Forms.RadioButton();
            this.rbPorCuenta = new System.Windows.Forms.RadioButton();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.numVerPlanCuentasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nudNivel = new System.Windows.Forms.NumericUpDown();
            this.lblCuenta = new MyLabelG.LabelDegradado();
            this.lblDesCuenta = new MyLabelG.LabelDegradado();
            this.lblNombreOrigen = new MyLabelG.LabelDegradado();
            this.lblCtaOrigen = new MyLabelG.LabelDegradado();
            this.lblNombreCostos = new MyLabelG.LabelDegradado();
            this.lblCodCosto = new MyLabelG.LabelDegradado();
            this.lblLetras = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Contabilidad.PlanCuentasE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(207, 363);
            this.btnAceptar.Size = new System.Drawing.Size(111, 24);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(321, 363);
            this.btnCancelar.Size = new System.Drawing.Size(111, 24);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(554, 106);
            this.btnBuscar.Size = new System.Drawing.Size(78, 43);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(686, 381);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 111);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(6, 128);
            this.txtFiltro.Size = new System.Drawing.Size(458, 20);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvCuentas);
            this.gbResultados.Location = new System.Drawing.Point(6, 151);
            this.gbResultados.Size = new System.Drawing.Size(626, 205);
            // 
            // numHojaCostoLabel
            // 
            this.numHojaCostoLabel.AutoSize = true;
            this.numHojaCostoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHojaCostoLabel.Location = new System.Drawing.Point(469, 108);
            this.numHojaCostoLabel.Name = "numHojaCostoLabel";
            this.numHojaCostoLabel.Size = new System.Drawing.Size(30, 13);
            this.numHojaCostoLabel.TabIndex = 116;
            this.numHojaCostoLabel.Text = "Nivel";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLetras);
            this.panel1.Controls.Add(this.rbPorDescripcion);
            this.panel1.Controls.Add(this.rbPorCuenta);
            this.panel1.Location = new System.Drawing.Point(6, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 44);
            this.panel1.TabIndex = 114;
            // 
            // rbPorDescripcion
            // 
            this.rbPorDescripcion.AutoSize = true;
            this.rbPorDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPorDescripcion.Location = new System.Drawing.Point(264, 21);
            this.rbPorDescripcion.Name = "rbPorDescripcion";
            this.rbPorDescripcion.Size = new System.Drawing.Size(115, 17);
            this.rbPorDescripcion.TabIndex = 112;
            this.rbPorDescripcion.Text = "Por Descripción";
            this.rbPorDescripcion.UseVisualStyleBackColor = true;
            // 
            // rbPorCuenta
            // 
            this.rbPorCuenta.AutoSize = true;
            this.rbPorCuenta.Checked = true;
            this.rbPorCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPorCuenta.Location = new System.Drawing.Point(81, 21);
            this.rbPorCuenta.Name = "rbPorCuenta";
            this.rbPorCuenta.Size = new System.Drawing.Size(88, 17);
            this.rbPorCuenta.TabIndex = 111;
            this.rbPorCuenta.TabStop = true;
            this.rbPorCuenta.Text = "Por Cuenta";
            this.rbPorCuenta.UseVisualStyleBackColor = true;
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.AllowUserToAddRows = false;
            this.dgvCuentas.AllowUserToDeleteRows = false;
            this.dgvCuentas.AutoGenerateColumns = false;
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numVerPlanCuentasDataGridViewTextBoxColumn,
            this.codCuentaDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn});
            this.dgvCuentas.DataSource = this.bsBase;
            this.dgvCuentas.EnableHeadersVisualStyles = false;
            this.dgvCuentas.Location = new System.Drawing.Point(5, 16);
            this.dgvCuentas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.ReadOnly = true;
            this.dgvCuentas.RowTemplate.Height = 24;
            this.dgvCuentas.Size = new System.Drawing.Size(616, 184);
            this.dgvCuentas.TabIndex = 1;
            this.dgvCuentas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuentas_CellContentDoubleClick);
            this.dgvCuentas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCuentas_CellPainting);
            // 
            // numVerPlanCuentasDataGridViewTextBoxColumn
            // 
            this.numVerPlanCuentasDataGridViewTextBoxColumn.DataPropertyName = "numVerPlanCuentas";
            this.numVerPlanCuentasDataGridViewTextBoxColumn.HeaderText = "Ver.P.C.";
            this.numVerPlanCuentasDataGridViewTextBoxColumn.Name = "numVerPlanCuentasDataGridViewTextBoxColumn";
            this.numVerPlanCuentasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codCuentaDataGridViewTextBoxColumn
            // 
            this.codCuentaDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            this.codCuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.codCuentaDataGridViewTextBoxColumn.Name = "codCuentaDataGridViewTextBoxColumn";
            this.codCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nudNivel
            // 
            this.nudNivel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNivel.Location = new System.Drawing.Point(466, 128);
            this.nudNivel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNivel.Name = "nudNivel";
            this.nudNivel.Size = new System.Drawing.Size(36, 21);
            this.nudNivel.TabIndex = 115;
            this.nudNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNivel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCuenta
            // 
            this.lblCuenta.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblCuenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuenta.ForeColor = System.Drawing.Color.Black;
            this.lblCuenta.Location = new System.Drawing.Point(7, 3);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblCuenta.Size = new System.Drawing.Size(169, 19);
            this.lblCuenta.TabIndex = 250;
            this.lblCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDesCuenta
            // 
            this.lblDesCuenta.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblDesCuenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesCuenta.ForeColor = System.Drawing.Color.Black;
            this.lblDesCuenta.Location = new System.Drawing.Point(182, 3);
            this.lblDesCuenta.Name = "lblDesCuenta";
            this.lblDesCuenta.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblDesCuenta.SegundoColor = System.Drawing.Color.White;
            this.lblDesCuenta.Size = new System.Drawing.Size(450, 19);
            this.lblDesCuenta.TabIndex = 251;
            this.lblDesCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNombreOrigen
            // 
            this.lblNombreOrigen.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblNombreOrigen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreOrigen.ForeColor = System.Drawing.Color.Black;
            this.lblNombreOrigen.Location = new System.Drawing.Point(182, 22);
            this.lblNombreOrigen.Name = "lblNombreOrigen";
            this.lblNombreOrigen.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblNombreOrigen.SegundoColor = System.Drawing.Color.White;
            this.lblNombreOrigen.Size = new System.Drawing.Size(450, 19);
            this.lblNombreOrigen.TabIndex = 253;
            this.lblNombreOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCtaOrigen
            // 
            this.lblCtaOrigen.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblCtaOrigen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtaOrigen.ForeColor = System.Drawing.Color.Black;
            this.lblCtaOrigen.Location = new System.Drawing.Point(7, 22);
            this.lblCtaOrigen.Name = "lblCtaOrigen";
            this.lblCtaOrigen.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblCtaOrigen.Size = new System.Drawing.Size(169, 19);
            this.lblCtaOrigen.TabIndex = 252;
            this.lblCtaOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNombreCostos
            // 
            this.lblNombreCostos.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblNombreCostos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCostos.ForeColor = System.Drawing.Color.Black;
            this.lblNombreCostos.Location = new System.Drawing.Point(182, 41);
            this.lblNombreCostos.Name = "lblNombreCostos";
            this.lblNombreCostos.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblNombreCostos.SegundoColor = System.Drawing.Color.White;
            this.lblNombreCostos.Size = new System.Drawing.Size(450, 19);
            this.lblNombreCostos.TabIndex = 255;
            this.lblNombreCostos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCodCosto
            // 
            this.lblCodCosto.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblCodCosto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodCosto.ForeColor = System.Drawing.Color.Black;
            this.lblCodCosto.Location = new System.Drawing.Point(7, 41);
            this.lblCodCosto.Name = "lblCodCosto";
            this.lblCodCosto.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblCodCosto.Size = new System.Drawing.Size(169, 19);
            this.lblCodCosto.TabIndex = 254;
            this.lblCodCosto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(458, 18);
            this.lblLetras.TabIndex = 1574;
            this.lblLetras.Text = "Parámetros de Búsqueda";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBuscarCuentasMigraciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 392);
            this.Controls.Add(this.lblNombreCostos);
            this.Controls.Add(this.lblCodCosto);
            this.Controls.Add(this.lblNombreOrigen);
            this.Controls.Add(this.lblCtaOrigen);
            this.Controls.Add(this.lblDesCuenta);
            this.Controls.Add(this.lblCuenta);
            this.Controls.Add(this.numHojaCostoLabel);
            this.Controls.Add(this.nudNivel);
            this.Controls.Add(this.panel1);
            this.Name = "frmBuscarCuentasMigraciones";
            this.Text = "Buscar Cuentas Concar";
            this.Load += new System.EventHandler(this.frmBuscarCuentasMigraciones_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.nudNivel, 0);
            this.Controls.SetChildIndex(this.numHojaCostoLabel, 0);
            this.Controls.SetChildIndex(this.lblCuenta, 0);
            this.Controls.SetChildIndex(this.lblDesCuenta, 0);
            this.Controls.SetChildIndex(this.lblCtaOrigen, 0);
            this.Controls.SetChildIndex(this.lblNombreOrigen, 0);
            this.Controls.SetChildIndex(this.lblCodCosto, 0);
            this.Controls.SetChildIndex(this.lblNombreCostos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbPorDescripcion;
        private System.Windows.Forms.RadioButton rbPorCuenta;
        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVerPlanCuentasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.NumericUpDown nudNivel;
        private MyLabelG.LabelDegradado lblCuenta;
        private MyLabelG.LabelDegradado lblDesCuenta;
        private System.Windows.Forms.Label numHojaCostoLabel;
        private MyLabelG.LabelDegradado lblNombreOrigen;
        private MyLabelG.LabelDegradado lblCtaOrigen;
        private MyLabelG.LabelDegradado lblNombreCostos;
        private MyLabelG.LabelDegradado lblCodCosto;
        private System.Windows.Forms.Label lblLetras;
    }
}