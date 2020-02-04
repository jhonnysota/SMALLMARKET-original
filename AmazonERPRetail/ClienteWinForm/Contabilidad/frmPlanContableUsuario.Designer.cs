namespace ClienteWinForm.Contabilidad
{
    partial class frmPlanContableUsuario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvListaCuentas = new System.Windows.Forms.DataGridView();
            this.bsCuentas = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListaUsuario = new System.Windows.Forms.DataGridView();
            this.bsCuentasUsuario = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistrosUsuario = new MyLabelG.LabelDegradado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new MyLabelG.LabelDegradado();
            this.label1 = new System.Windows.Forms.Label();
            this.codCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFile = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMoneda2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCuentas)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCuentasUsuario)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvListaCuentas);
            this.panel3.Controls.Add(this.lblRegistros);
            this.panel3.Location = new System.Drawing.Point(624, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(363, 388);
            this.panel3.TabIndex = 265;
            // 
            // dgvListaCuentas
            // 
            this.dgvListaCuentas.AllowUserToAddRows = false;
            this.dgvListaCuentas.AllowUserToDeleteRows = false;
            this.dgvListaCuentas.AutoGenerateColumns = false;
            this.dgvListaCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codCuentaDataGridViewTextBoxColumn1,
            this.descripcionDataGridViewTextBoxColumn1,
            this.idMoneda2});
            this.dgvListaCuentas.DataSource = this.bsCuentas;
            this.dgvListaCuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListaCuentas.EnableHeadersVisualStyles = false;
            this.dgvListaCuentas.Location = new System.Drawing.Point(0, 23);
            this.dgvListaCuentas.Name = "dgvListaCuentas";
            this.dgvListaCuentas.ReadOnly = true;
            this.dgvListaCuentas.Size = new System.Drawing.Size(361, 363);
            this.dgvListaCuentas.TabIndex = 0;
            this.dgvListaCuentas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListaCuentas_CellFormatting);
            this.dgvListaCuentas.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvListaCuentas_CurrentCellDirtyStateChanged);
            this.dgvListaCuentas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvListaCuentas_DataError);
            // 
            // bsCuentas
            // 
            this.bsCuentas.DataSource = typeof(Entidades.Contabilidad.PlanCuentasDifCambioUsuarioE);
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
            this.lblRegistros.Size = new System.Drawing.Size(361, 23);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Cuentas";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvListaUsuario);
            this.panel5.Controls.Add(this.lblRegistrosUsuario);
            this.panel5.Location = new System.Drawing.Point(3, 83);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(614, 388);
            this.panel5.TabIndex = 264;
            // 
            // dgvListaUsuario
            // 
            this.dgvListaUsuario.AllowUserToAddRows = false;
            this.dgvListaUsuario.AllowUserToDeleteRows = false;
            this.dgvListaUsuario.AutoGenerateColumns = false;
            this.dgvListaUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codCuenta,
            this.Descripcion,
            this.numFile,
            this.UsuarioRegistro,
            this.FechaRegistro,
            this.UsuarioModificacion,
            this.FechaModificacion,
            this.idMoneda});
            this.dgvListaUsuario.DataSource = this.bsCuentasUsuario;
            this.dgvListaUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListaUsuario.EnableHeadersVisualStyles = false;
            this.dgvListaUsuario.Location = new System.Drawing.Point(0, 23);
            this.dgvListaUsuario.Name = "dgvListaUsuario";
            this.dgvListaUsuario.Size = new System.Drawing.Size(612, 363);
            this.dgvListaUsuario.TabIndex = 0;
            this.dgvListaUsuario.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListaUsuario_CellFormatting);
            this.dgvListaUsuario.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListaUsuario_ColumnHeaderMouseClick);
            this.dgvListaUsuario.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvListaUsuario_CurrentCellDirtyStateChanged);
            this.dgvListaUsuario.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvListaUsuario_DataError);
            // 
            // bsCuentasUsuario
            // 
            this.bsCuentasUsuario.DataSource = typeof(Entidades.Contabilidad.PlanCuentasDifCambioUsuarioE);
            // 
            // lblRegistrosUsuario
            // 
            this.lblRegistrosUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistrosUsuario.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistrosUsuario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosUsuario.ForeColor = System.Drawing.Color.White;
            this.lblRegistrosUsuario.Location = new System.Drawing.Point(0, 0);
            this.lblRegistrosUsuario.Name = "lblRegistrosUsuario";
            this.lblRegistrosUsuario.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistrosUsuario.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistrosUsuario.Size = new System.Drawing.Size(612, 23);
            this.lblRegistrosUsuario.TabIndex = 249;
            this.lblRegistrosUsuario.Text = "Cuentas Asginadas";
            this.lblRegistrosUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelDegradado1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtCuenta);
            this.panel2.Location = new System.Drawing.Point(624, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(362, 76);
            this.panel2.TabIndex = 263;
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
            this.labelDegradado1.Size = new System.Drawing.Size(360, 21);
            this.labelDegradado1.TabIndex = 253;
            this.labelDegradado1.Text = "Cuentas - Diferencia de Cambio";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filtrar : ";
            // 
            // txtCuenta
            // 
            this.txtCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCuenta.Location = new System.Drawing.Point(65, 35);
            this.txtCuenta.MaxLength = 50;
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(239, 20);
            this.txtCuenta.TabIndex = 0;
            this.txtCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuenta_KeyPress);
            this.txtCuenta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCuenta_KeyUp);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboUsuario);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 76);
            this.panel1.TabIndex = 262;
            // 
            // cboUsuario
            // 
            this.cboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Location = new System.Drawing.Point(64, 35);
            this.cboUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(319, 21);
            this.cboUsuario.TabIndex = 254;
            this.cboUsuario.SelectionChangeCommitted += new System.EventHandler(this.cboUsuario_SelectionChangeCommitted);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblTitulo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTitulo.Size = new System.Drawing.Size(613, 21);
            this.lblTitulo.TabIndex = 253;
            this.lblTitulo.Text = "Asignación de Usuario";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario : ";
            // 
            // codCuenta
            // 
            this.codCuenta.DataPropertyName = "codCuenta";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCuenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.codCuenta.Frozen = true;
            this.codCuenta.HeaderText = "Cuenta";
            this.codCuenta.Name = "codCuenta";
            this.codCuenta.Width = 55;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.Frozen = true;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 220;
            // 
            // numFile
            // 
            this.numFile.DataPropertyName = "numFile";
            this.numFile.Frozen = true;
            this.numFile.HeaderText = "File";
            this.numFile.Name = "numFile";
            this.numFile.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.numFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.numFile.Width = 320;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.DataPropertyName = "UsuarioRegistro";
            this.UsuarioRegistro.Frozen = true;
            this.UsuarioRegistro.HeaderText = "Usuario Reg.";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.DataPropertyName = "FechaRegistro";
            this.FechaRegistro.Frozen = true;
            this.FechaRegistro.HeaderText = "Fecha Reg.";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.Width = 120;
            // 
            // UsuarioModificacion
            // 
            this.UsuarioModificacion.DataPropertyName = "UsuarioModificacion";
            this.UsuarioModificacion.Frozen = true;
            this.UsuarioModificacion.HeaderText = "Usuario Mod.";
            this.UsuarioModificacion.Name = "UsuarioModificacion";
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.DataPropertyName = "FechaModificacion";
            this.FechaModificacion.Frozen = true;
            this.FechaModificacion.HeaderText = "Fecha Mod.";
            this.FechaModificacion.Name = "FechaModificacion";
            this.FechaModificacion.Width = 120;
            // 
            // idMoneda
            // 
            this.idMoneda.DataPropertyName = "idMoneda";
            this.idMoneda.Frozen = true;
            this.idMoneda.HeaderText = "idMoneda";
            this.idMoneda.Name = "idMoneda";
            this.idMoneda.Width = 5;
            // 
            // codCuentaDataGridViewTextBoxColumn1
            // 
            this.codCuentaDataGridViewTextBoxColumn1.DataPropertyName = "codCuenta";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCuentaDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.codCuentaDataGridViewTextBoxColumn1.Frozen = true;
            this.codCuentaDataGridViewTextBoxColumn1.HeaderText = "Cuenta";
            this.codCuentaDataGridViewTextBoxColumn1.Name = "codCuentaDataGridViewTextBoxColumn1";
            this.codCuentaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.codCuentaDataGridViewTextBoxColumn1.Width = 55;
            // 
            // descripcionDataGridViewTextBoxColumn1
            // 
            this.descripcionDataGridViewTextBoxColumn1.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn1.Frozen = true;
            this.descripcionDataGridViewTextBoxColumn1.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn1.Name = "descripcionDataGridViewTextBoxColumn1";
            this.descripcionDataGridViewTextBoxColumn1.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn1.Width = 335;
            // 
            // idMoneda2
            // 
            this.idMoneda2.DataPropertyName = "idMoneda";
            this.idMoneda2.Frozen = true;
            this.idMoneda2.HeaderText = "idMoneda";
            this.idMoneda2.Name = "idMoneda2";
            this.idMoneda2.ReadOnly = true;
            this.idMoneda2.Width = 5;
            // 
            // frmPlanContableUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 470);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPlanContableUsuario";
            this.Text = "Plan Contable por Usuario";
            this.Load += new System.EventHandler(this.frmPlanContableUsuario_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCuentas)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCuentasUsuario)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MyLabelG.LabelDegradado lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListaUsuario;
        private MyLabelG.LabelDegradado lblRegistrosUsuario;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvListaCuentas;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.BindingSource bsCuentas;
        private System.Windows.Forms.BindingSource bsCuentasUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewComboBoxColumn numFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMoneda2;
    }
}