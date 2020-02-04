namespace ClienteWinForm.Contabilidad
{
    partial class frmVoucherItemCCostos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucherItemCCostos));
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.cboDgvIdCostos = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportePorcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtImporteTotal = new ControlesWinForm.SuperTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPorcentaje = new MyLabelG.LabelDegradado();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotal = new MyLabelG.LabelDegradado();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(242, 348);
            this.btCancelar.Size = new System.Drawing.Size(119, 26);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(118, 348);
            this.btAceptar.Size = new System.Drawing.Size(119, 26);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(460, 22);
            this.lblTitPnlBase.Text = "Centro de Costos ";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(481, 25);
            this.lblTituloPrincipal.Text = "Distribución por Centro de Costos";
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Contabilidad.VoucherItemCCostosE);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(510, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.lblTotal);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.lblPorcentaje);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.txtImporteTotal);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.btnQuitar);
            this.pnlBase.Controls.Add(this.btnAgregar);
            this.pnlBase.Controls.Add(this.pnlDetalle);
            this.pnlBase.Location = new System.Drawing.Point(9, 31);
            this.pnlBase.Size = new System.Drawing.Size(462, 311);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.pnlDetalle, 0);
            this.pnlBase.Controls.SetChildIndex(this.btnAgregar, 0);
            this.pnlBase.Controls.SetChildIndex(this.btnQuitar, 0);
            this.pnlBase.Controls.SetChildIndex(this.label4, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtImporteTotal, 0);
            this.pnlBase.Controls.SetChildIndex(this.label5, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblPorcentaje, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTotal, 0);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvListado);
            this.pnlDetalle.Controls.Add(this.labelDegradado1);
            this.pnlDetalle.Location = new System.Drawing.Point(6, 63);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(447, 208);
            this.pnlDetalle.TabIndex = 1506;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cboDgvIdCostos,
            this.Porcentaje,
            this.ImportePorcentaje});
            this.dgvListado.DataSource = this.bsBase;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.EnableHeadersVisualStyles = false;
            this.dgvListado.Location = new System.Drawing.Point(0, 20);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.Size = new System.Drawing.Size(445, 186);
            this.dgvListado.TabIndex = 248;
            this.dgvListado.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellEndEdit);
            this.dgvListado.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellEnter);
            this.dgvListado.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellValueChanged);
            this.dgvListado.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvListado_DataError);
            this.dgvListado.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvListado_EditingControlShowing);
            this.dgvListado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvListado_KeyPress);
            // 
            // cboDgvIdCostos
            // 
            this.cboDgvIdCostos.DataPropertyName = "idCCostos";
            this.cboDgvIdCostos.HeaderText = "C.Costos";
            this.cboDgvIdCostos.Name = "cboDgvIdCostos";
            this.cboDgvIdCostos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboDgvIdCostos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Porcentaje
            // 
            this.Porcentaje.DataPropertyName = "Porcentaje";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.Porcentaje.DefaultCellStyle = dataGridViewCellStyle1;
            this.Porcentaje.HeaderText = "Porcentaje";
            this.Porcentaje.Name = "Porcentaje";
            // 
            // ImportePorcentaje
            // 
            this.ImportePorcentaje.DataPropertyName = "ImportePorcentaje";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.ImportePorcentaje.DefaultCellStyle = dataGridViewCellStyle2;
            this.ImportePorcentaje.HeaderText = "Total";
            this.ImportePorcentaje.Name = "ImportePorcentaje";
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(445, 20);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Centro de Costos";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnQuitar
            // 
            this.btnQuitar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnQuitar.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnQuitar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitar.Location = new System.Drawing.Point(368, 34);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(84, 22);
            this.btnQuitar.TabIndex = 260;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregar.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.Location = new System.Drawing.Point(280, 34);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(84, 23);
            this.btnAgregar.TabIndex = 259;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtImporteTotal.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtImporteTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImporteTotal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtImporteTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteTotal.Location = new System.Drawing.Point(84, 35);
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.Size = new System.Drawing.Size(103, 20);
            this.txtImporteTotal.TabIndex = 1514;
            this.txtImporteTotal.Text = "0.00";
            this.txtImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporteTotal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtImporteTotal.TextoVacio = "<Descripcion>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 1513;
            this.label4.Text = "Importe Total";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPorcentaje.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.ForeColor = System.Drawing.Color.Black;
            this.lblPorcentaje.Location = new System.Drawing.Point(244, 279);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblPorcentaje.Size = new System.Drawing.Size(84, 22);
            this.lblPorcentaje.TabIndex = 1516;
            this.lblPorcentaje.Text = "0.00";
            this.lblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(182, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 1515;
            this.label5.Text = "Porcentaje";
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(367, 279);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTotal.Size = new System.Drawing.Size(84, 22);
            this.lblTotal.TabIndex = 1518;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(334, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1517;
            this.label1.Text = "Total";
            // 
            // frmVoucherItemCCostos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 384);
            this.Name = "frmVoucherItemCCostos";
            this.Text = "Agregar Registros";
            this.Load += new System.EventHandler(this.frmVoucherItemCCostos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.DataGridView dgvListado;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private ControlesWinForm.SuperTextBox txtImporteTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboDgvIdCostos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportePorcentaje;
        private MyLabelG.LabelDegradado lblTotal;
        private System.Windows.Forms.Label label1;
        private MyLabelG.LabelDegradado lblPorcentaje;
        private System.Windows.Forms.Label label5;
    }
}