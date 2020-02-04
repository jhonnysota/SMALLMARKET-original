namespace ClienteWinForm.Maestros
{
    partial class FrmArea
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            this.bsListadoAreas = new System.Windows.Forms.BindingSource(this.components);
            this.dgvAreas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.bsAreas = new System.Windows.Forms.BindingSource(this.components);
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.txtIdArea = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoAreas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAreas)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(8, 104);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(8, 39);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(86, 13);
            label3.TabIndex = 0;
            label3.Text = "Usuario Registro";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(8, 62);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(79, 13);
            label4.TabIndex = 4;
            label4.Text = "Fecha Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(8, 82);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(104, 13);
            label5.TabIndex = 2;
            label5.Text = "Usuario Modificación";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(7, 38);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(52, 13);
            label9.TabIndex = 0;
            label9.Text = "Cód Area";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(7, 61);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(61, 13);
            label10.TabIndex = 4;
            label10.Text = "Descripción";
            // 
            // bsListadoAreas
            // 
            this.bsListadoAreas.DataSource = typeof(Entidades.Maestros.Area);
            this.bsListadoAreas.CurrentChanged += new System.EventHandler(this.bsListadoAreas_CurrentChanged);
            // 
            // dgvAreas
            // 
            this.dgvAreas.AllowUserToAddRows = false;
            this.dgvAreas.AllowUserToDeleteRows = false;
            this.dgvAreas.AutoGenerateColumns = false;
            this.dgvAreas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAreas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAreas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dgvAreas.DataSource = this.bsListadoAreas;
            this.dgvAreas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAreas.EnableHeadersVisualStyles = false;
            this.dgvAreas.Location = new System.Drawing.Point(0, 19);
            this.dgvAreas.Name = "dgvAreas";
            this.dgvAreas.ReadOnly = true;
            this.dgvAreas.RowTemplate.Height = 24;
            this.dgvAreas.Size = new System.Drawing.Size(285, 209);
            this.dgvAreas.TabIndex = 2;
            this.dgvAreas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAreas_CellFormatting);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "idArea";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cód. Area";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "idEmpresa";
            this.dataGridViewTextBoxColumn2.HeaderText = "idEmpresa";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "idLocal";
            this.dataGridViewTextBoxColumn3.HeaderText = "idLocal";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "descripcion";
            this.dataGridViewTextBoxColumn4.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "estado";
            this.dataGridViewTextBoxColumn5.HeaderText = "estado";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn6.HeaderText = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FechaRegistro";
            this.dataGridViewTextBoxColumn7.HeaderText = "FechaRegistro";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn8.HeaderText = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "FechaModificacion";
            this.dataGridViewTextBoxColumn9.HeaderText = "FechaModificacion";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAreas, "descripcion", true));
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(75, 56);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(202, 20);
            this.txtDescripcion.TabIndex = 3;
            // 
            // bsAreas
            // 
            this.bsAreas.DataSource = typeof(Entidades.Maestros.Area);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado3);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtRegistro);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(293, 96);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(287, 137);
            this.pnlAuditoria.TabIndex = 29;
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
            this.labelDegradado3.Size = new System.Drawing.Size(285, 19);
            this.labelDegradado3.TabIndex = 253;
            this.labelDegradado3.Text = "Auditoria";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtModifica.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAreas, "FechaModificacion", true));
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(120, 100);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(155, 20);
            this.txtModifica.TabIndex = 0;
            // 
            // txtRegistro
            // 
            this.txtRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRegistro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAreas, "FechaRegistro", true));
            this.txtRegistro.Enabled = false;
            this.txtRegistro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(120, 58);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(155, 20);
            this.txtRegistro.TabIndex = 0;
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuRegistra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAreas, "UsuarioRegistro", true));
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(121, 37);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(155, 20);
            this.txtUsuRegistra.TabIndex = 0;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuModifica.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAreas, "UsuarioModificacion", true));
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(120, 79);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(155, 20);
            this.txtUsuModifica.TabIndex = 0;
            // 
            // txtIdArea
            // 
            this.txtIdArea.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdArea.Enabled = false;
            this.txtIdArea.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdArea.Location = new System.Drawing.Point(75, 34);
            this.txtIdArea.Name = "txtIdArea";
            this.txtIdArea.Size = new System.Drawing.Size(57, 20);
            this.txtIdArea.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvAreas);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 230);
            this.panel1.TabIndex = 32;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(285, 19);
            this.labelDegradado1.TabIndex = 252;
            this.labelDegradado1.Text = "Registros";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEstado
            // 
            this.chkEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEstado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEstado.Location = new System.Drawing.Point(144, 34);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(77, 22);
            this.chkEstado.TabIndex = 33;
            this.chkEstado.Text = "Estado";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelDegradado2);
            this.panel2.Controls.Add(this.chkEstado);
            this.panel2.Controls.Add(this.txtIdArea);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(label10);
            this.panel2.Controls.Add(label9);
            this.panel2.Location = new System.Drawing.Point(293, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 90);
            this.panel2.TabIndex = 34;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(285, 19);
            this.labelDegradado2.TabIndex = 253;
            this.labelDegradado2.Text = "Datos";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(583, 237);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAuditoria);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "FrmArea";
            this.Text = "AREAS";
            this.Load += new System.EventHandler(this.FrmArea_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmArea_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoAreas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAreas)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsListadoAreas;
        private System.Windows.Forms.DataGridView dgvAreas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.BindingSource bsAreas;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.TextBox txtIdArea;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Panel panel2;
        private MyLabelG.LabelDegradado labelDegradado3;
        private MyLabelG.LabelDegradado labelDegradado1;
        private MyLabelG.LabelDegradado labelDegradado2;


    }
}