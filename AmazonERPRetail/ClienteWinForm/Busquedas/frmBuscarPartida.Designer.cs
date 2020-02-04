namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarPartida
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
            System.Windows.Forms.Label numHojaCostoLabel;
            this.dgvpartida = new System.Windows.Forms.DataGridView();
            this.codPartidaPresuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numNivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPartidaPresuSupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipTituloNodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indUltNodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indBajaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaBajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbGa = new System.Windows.Forms.RadioButton();
            this.rbRe = new System.Windows.Forms.RadioButton();
            this.nudNivel = new System.Windows.Forms.NumericUpDown();
            numHojaCostoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpartida)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Maestros.PartidaPresupuestariaE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(364, 386);
            this.btnAceptar.Size = new System.Drawing.Size(100, 26);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(470, 386);
            this.btnCancelar.Size = new System.Drawing.Size(100, 26);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(521, 28);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(13, 395);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(158, 35);
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.Text = "Ingrese la descripción";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(158, 53);
            this.txtFiltro.Size = new System.Drawing.Size(317, 20);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvpartida);
            this.gbResultados.Location = new System.Drawing.Point(5, 81);
            this.gbResultados.Size = new System.Drawing.Size(566, 299);
            // 
            // numHojaCostoLabel
            // 
            numHojaCostoLabel.AutoSize = true;
            numHojaCostoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numHojaCostoLabel.Location = new System.Drawing.Point(481, 35);
            numHojaCostoLabel.Name = "numHojaCostoLabel";
            numHojaCostoLabel.Size = new System.Drawing.Size(30, 13);
            numHojaCostoLabel.TabIndex = 112;
            numHojaCostoLabel.Text = "Nivel";
            // 
            // dgvpartida
            // 
            this.dgvpartida.AllowUserToAddRows = false;
            this.dgvpartida.AllowUserToDeleteRows = false;
            this.dgvpartida.AutoGenerateColumns = false;
            this.dgvpartida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpartida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codPartidaPresuDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.numNivelDataGridViewTextBoxColumn,
            this.codPartidaPresuSupDataGridViewTextBoxColumn,
            this.tipTituloNodoDataGridViewTextBoxColumn,
            this.indUltNodoDataGridViewTextBoxColumn,
            this.indBajaDataGridViewCheckBoxColumn,
            this.fechaBajaDataGridViewTextBoxColumn});
            this.dgvpartida.DataSource = this.bsBase;
            this.dgvpartida.Location = new System.Drawing.Point(8, 16);
            this.dgvpartida.Name = "dgvpartida";
            this.dgvpartida.ReadOnly = true;
            this.dgvpartida.Size = new System.Drawing.Size(549, 275);
            this.dgvpartida.TabIndex = 0;
            this.dgvpartida.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpartida_CellDoubleClick);
            this.dgvpartida.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvpartida_CellPainting);
            // 
            // codPartidaPresuDataGridViewTextBoxColumn
            // 
            this.codPartidaPresuDataGridViewTextBoxColumn.DataPropertyName = "codPartidaPresu";
            this.codPartidaPresuDataGridViewTextBoxColumn.HeaderText = "codPartidaPresu";
            this.codPartidaPresuDataGridViewTextBoxColumn.Name = "codPartidaPresuDataGridViewTextBoxColumn";
            this.codPartidaPresuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "desPartidaPresu";
            this.dataGridViewTextBoxColumn1.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "abrevPartidaPresu";
            this.dataGridViewTextBoxColumn2.HeaderText = "Abrev.";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // numNivelDataGridViewTextBoxColumn
            // 
            this.numNivelDataGridViewTextBoxColumn.DataPropertyName = "numNivel";
            this.numNivelDataGridViewTextBoxColumn.HeaderText = "Nivel";
            this.numNivelDataGridViewTextBoxColumn.Name = "numNivelDataGridViewTextBoxColumn";
            this.numNivelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codPartidaPresuSupDataGridViewTextBoxColumn
            // 
            this.codPartidaPresuSupDataGridViewTextBoxColumn.DataPropertyName = "codPartidaPresuSup";
            this.codPartidaPresuSupDataGridViewTextBoxColumn.HeaderText = "codPartidaPresuSup";
            this.codPartidaPresuSupDataGridViewTextBoxColumn.Name = "codPartidaPresuSupDataGridViewTextBoxColumn";
            this.codPartidaPresuSupDataGridViewTextBoxColumn.ReadOnly = true;
            this.codPartidaPresuSupDataGridViewTextBoxColumn.Visible = false;
            // 
            // tipTituloNodoDataGridViewTextBoxColumn
            // 
            this.tipTituloNodoDataGridViewTextBoxColumn.DataPropertyName = "tipTituloNodo";
            this.tipTituloNodoDataGridViewTextBoxColumn.HeaderText = "tipTituloNodo";
            this.tipTituloNodoDataGridViewTextBoxColumn.Name = "tipTituloNodoDataGridViewTextBoxColumn";
            this.tipTituloNodoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipTituloNodoDataGridViewTextBoxColumn.Visible = false;
            // 
            // indUltNodoDataGridViewTextBoxColumn
            // 
            this.indUltNodoDataGridViewTextBoxColumn.DataPropertyName = "indUltNodo";
            this.indUltNodoDataGridViewTextBoxColumn.HeaderText = "indUltNodo";
            this.indUltNodoDataGridViewTextBoxColumn.Name = "indUltNodoDataGridViewTextBoxColumn";
            this.indUltNodoDataGridViewTextBoxColumn.ReadOnly = true;
            this.indUltNodoDataGridViewTextBoxColumn.Visible = false;
            // 
            // indBajaDataGridViewCheckBoxColumn
            // 
            this.indBajaDataGridViewCheckBoxColumn.DataPropertyName = "indBaja";
            this.indBajaDataGridViewCheckBoxColumn.HeaderText = "indBaja";
            this.indBajaDataGridViewCheckBoxColumn.Name = "indBajaDataGridViewCheckBoxColumn";
            this.indBajaDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indBajaDataGridViewCheckBoxColumn.Visible = false;
            // 
            // fechaBajaDataGridViewTextBoxColumn
            // 
            this.fechaBajaDataGridViewTextBoxColumn.DataPropertyName = "FechaBaja";
            this.fechaBajaDataGridViewTextBoxColumn.HeaderText = "FechaBaja";
            this.fechaBajaDataGridViewTextBoxColumn.Name = "fechaBajaDataGridViewTextBoxColumn";
            this.fechaBajaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaBajaDataGridViewTextBoxColumn.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbGa);
            this.groupBox1.Controls.Add(this.rbRe);
            this.groupBox1.Location = new System.Drawing.Point(5, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 65);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // rbGa
            // 
            this.rbGa.AutoSize = true;
            this.rbGa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGa.Location = new System.Drawing.Point(19, 40);
            this.rbGa.Name = "rbGa";
            this.rbGa.Size = new System.Drawing.Size(107, 17);
            this.rbGa.TabIndex = 10;
            this.rbGa.Text = "Gastos - Partidas";
            this.rbGa.UseVisualStyleBackColor = true;
            // 
            // rbRe
            // 
            this.rbRe.AutoSize = true;
            this.rbRe.Checked = true;
            this.rbRe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRe.Location = new System.Drawing.Point(19, 17);
            this.rbRe.Name = "rbRe";
            this.rbRe.Size = new System.Drawing.Size(113, 17);
            this.rbRe.TabIndex = 9;
            this.rbRe.TabStop = true;
            this.rbRe.Text = "Recursos - Rubros";
            this.rbRe.UseVisualStyleBackColor = true;
            // 
            // nudNivel
            // 
            this.nudNivel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNivel.Location = new System.Drawing.Point(478, 53);
            this.nudNivel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNivel.Name = "nudNivel";
            this.nudNivel.Size = new System.Drawing.Size(36, 21);
            this.nudNivel.TabIndex = 111;
            this.nudNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNivel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmBuscarPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 417);
            this.Controls.Add(numHojaCostoLabel);
            this.Controls.Add(this.nudNivel);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBuscarPartida";
            this.Text = "Buscar Partida Presupuestal";
            this.Load += new System.EventHandler(this.frmBuscarPartida_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.nudNivel, 0);
            this.Controls.SetChildIndex(numHojaCostoLabel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpartida)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvpartida;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPartidaPresuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn numNivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPartidaPresuSupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipTituloNodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indUltNodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indBajaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaBajaDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbGa;
        private System.Windows.Forms.RadioButton rbRe;
        private System.Windows.Forms.NumericUpDown nudNivel;
    }
}