namespace ClienteWinForm.Contabilidad
{
    partial class FrmPlanCuentasVersion
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
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label idControlLabel;
            System.Windows.Forms.Label label2;
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.cboIndVig = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvEstructura = new System.Windows.Forms.DataGridView();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numNivelEstrucDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numLongiEstrucDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indFteFinanciamientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indMonedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsplanCuentasEstruc = new System.Windows.Forms.BindingSource(this.components);
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            idControlLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.pnlAuditoria.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstructura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsplanCuentasEstruc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(11, 100);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(11, 78);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(11, 34);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(11, 56);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descripcionLabel.Location = new System.Drawing.Point(21, 55);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(61, 13);
            descripcionLabel.TabIndex = 259;
            descripcionLabel.Text = "Descripción";
            // 
            // idControlLabel
            // 
            idControlLabel.AutoSize = true;
            idControlLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idControlLabel.Location = new System.Drawing.Point(21, 34);
            idControlLabel.Name = "idControlLabel";
            idControlLabel.Size = new System.Drawing.Size(82, 13);
            idControlLabel.TabIndex = 260;
            idControlLabel.Text = "Numero Cuenta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(21, 79);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(44, 13);
            label2.TabIndex = 291;
            label2.Text = "Ind Vig.";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado2);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Controls.Add(this.txtRegistro);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(312, 1);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(259, 126);
            this.pnlAuditoria.TabIndex = 257;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(257, 21);
            this.labelDegradado2.TabIndex = 251;
            this.labelDegradado2.Text = "Auditoria";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtModifica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(120, 95);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(125, 21);
            this.txtModifica.TabIndex = 7;
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuRegistra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(120, 29);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(125, 21);
            this.txtUsuRegistra.TabIndex = 1;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuModifica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(120, 73);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(125, 21);
            this.txtUsuModifica.TabIndex = 5;
            // 
            // txtRegistro
            // 
            this.txtRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegistro.Enabled = false;
            this.txtRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(120, 51);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(125, 21);
            this.txtRegistro.TabIndex = 3;
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.cboIndVig);
            this.pnlDatos.Controls.Add(label2);
            this.pnlDatos.Controls.Add(descripcionLabel);
            this.pnlDatos.Controls.Add(this.txtDescripcion);
            this.pnlDatos.Controls.Add(idControlLabel);
            this.pnlDatos.Controls.Add(this.txtNum);
            this.pnlDatos.Controls.Add(this.labelDegradado1);
            this.pnlDatos.Location = new System.Drawing.Point(0, 1);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(311, 126);
            this.pnlDatos.TabIndex = 256;
            // 
            // cboIndVig
            // 
            this.cboIndVig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIndVig.DropDownWidth = 79;
            this.cboIndVig.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIndVig.FormattingEnabled = true;
            this.cboIndVig.Location = new System.Drawing.Point(108, 76);
            this.cboIndVig.Margin = new System.Windows.Forms.Padding(2);
            this.cboIndVig.Name = "cboIndVig";
            this.cboIndVig.Size = new System.Drawing.Size(164, 21);
            this.cboIndVig.TabIndex = 292;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(109, 53);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(177, 21);
            this.txtDescripcion.TabIndex = 258;
            // 
            // txtNum
            // 
            this.txtNum.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNum.Enabled = false;
            this.txtNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum.Location = new System.Drawing.Point(109, 30);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(35, 21);
            this.txtNum.TabIndex = 261;
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.labelDegradado1.Size = new System.Drawing.Size(309, 21);
            this.labelDegradado1.TabIndex = 250;
            this.labelDegradado1.Text = "Datos";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvEstructura);
            this.panel1.Controls.Add(this.labelDegradado3);
            this.panel1.Location = new System.Drawing.Point(0, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 290);
            this.panel1.TabIndex = 258;
            // 
            // dgvEstructura
            // 
            this.dgvEstructura.AllowUserToAddRows = false;
            this.dgvEstructura.AllowUserToDeleteRows = false;
            this.dgvEstructura.AutoGenerateColumns = false;
            this.dgvEstructura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEstructura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstructura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numNivelEstrucDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.numLongiEstrucDataGridViewTextBoxColumn,
            this.indFteFinanciamientoDataGridViewTextBoxColumn,
            this.indMonedaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvEstructura.DataSource = this.bsplanCuentasEstruc;
            this.dgvEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEstructura.EnableHeadersVisualStyles = false;
            this.dgvEstructura.Location = new System.Drawing.Point(0, 21);
            this.dgvEstructura.Name = "dgvEstructura";
            this.dgvEstructura.ReadOnly = true;
            this.dgvEstructura.Size = new System.Drawing.Size(569, 267);
            this.dgvEstructura.TabIndex = 259;
            this.dgvEstructura.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstructura_CellDoubleClick);
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(569, 21);
            this.labelDegradado3.TabIndex = 250;
            this.labelDegradado3.Text = "Datos";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "numNivelEstruc";
            this.dataGridViewTextBoxColumn1.HeaderText = "Num.NivelEstr.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "numLongiEstruc";
            this.dataGridViewTextBoxColumn3.HeaderText = "Num.Long.Estr.";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "indFteFinanciamiento";
            this.dataGridViewTextBoxColumn4.HeaderText = "IndFteFinan.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "indMoneda";
            this.dataGridViewTextBoxColumn5.HeaderText = "IndMoneda";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn6.HeaderText = "Usuario Reg.";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FechaRegistro";
            this.dataGridViewTextBoxColumn7.HeaderText = "Fecha Reg.";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn8.HeaderText = "Usuario Mod.";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 90;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "FechaModificacion";
            this.dataGridViewTextBoxColumn9.HeaderText = "Fecha Mod.";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // numNivelEstrucDataGridViewTextBoxColumn
            // 
            this.numNivelEstrucDataGridViewTextBoxColumn.DataPropertyName = "numNivelEstruc";
            this.numNivelEstrucDataGridViewTextBoxColumn.HeaderText = "Num.NivelEstr.";
            this.numNivelEstrucDataGridViewTextBoxColumn.Name = "numNivelEstrucDataGridViewTextBoxColumn";
            this.numNivelEstrucDataGridViewTextBoxColumn.ReadOnly = true;
            this.numNivelEstrucDataGridViewTextBoxColumn.Width = 80;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numLongiEstrucDataGridViewTextBoxColumn
            // 
            this.numLongiEstrucDataGridViewTextBoxColumn.DataPropertyName = "numLongiEstruc";
            this.numLongiEstrucDataGridViewTextBoxColumn.HeaderText = "Num.Long.Estr.";
            this.numLongiEstrucDataGridViewTextBoxColumn.Name = "numLongiEstrucDataGridViewTextBoxColumn";
            this.numLongiEstrucDataGridViewTextBoxColumn.ReadOnly = true;
            this.numLongiEstrucDataGridViewTextBoxColumn.Width = 80;
            // 
            // indFteFinanciamientoDataGridViewTextBoxColumn
            // 
            this.indFteFinanciamientoDataGridViewTextBoxColumn.DataPropertyName = "indFteFinanciamiento";
            this.indFteFinanciamientoDataGridViewTextBoxColumn.HeaderText = "IndFteFinan.";
            this.indFteFinanciamientoDataGridViewTextBoxColumn.Name = "indFteFinanciamientoDataGridViewTextBoxColumn";
            this.indFteFinanciamientoDataGridViewTextBoxColumn.ReadOnly = true;
            this.indFteFinanciamientoDataGridViewTextBoxColumn.Width = 80;
            // 
            // indMonedaDataGridViewTextBoxColumn
            // 
            this.indMonedaDataGridViewTextBoxColumn.DataPropertyName = "indMoneda";
            this.indMonedaDataGridViewTextBoxColumn.HeaderText = "IndMoneda";
            this.indMonedaDataGridViewTextBoxColumn.Name = "indMonedaDataGridViewTextBoxColumn";
            this.indMonedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.indMonedaDataGridViewTextBoxColumn.Width = 80;
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
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // bsplanCuentasEstruc
            // 
            this.bsplanCuentasEstruc.DataSource = typeof(Entidades.Contabilidad.PlanCuentasEstrucE);
            // 
            // FrmPlanCuentasVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 419);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnlDatos);
            this.MaximizeBox = false;
            this.Name = "FrmPlanCuentasVersion";
            this.Text = "Plan Cuentas Version";
            this.Load += new System.EventHandler(this.FrmPlanCuentasVersion_Load);
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstructura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsplanCuentasEstruc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.Panel pnlDatos;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvEstructura;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.BindingSource bsplanCuentasEstruc;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn numNivelEstrucDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numLongiEstrucDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indFteFinanciamientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indMonedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cboIndVig;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}