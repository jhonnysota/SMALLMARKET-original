namespace ClienteWinForm.Contabilidad
{
    partial class frmPlanContable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanContable));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bsPlanCuentas = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvCuentas = new System.Windows.Forms.TreeView();
            this.tsMenuArbol = new System.Windows.Forms.ToolStrip();
            this.tsbExpandir = new System.Windows.Forms.ToolStripButton();
            this.tsbContraer = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCtaCteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indSolicitaDctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indSolicitaAnexoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indSolicitaCentroCostoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tsMenuArbol.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "System-Calendar-icon.png");
            this.imageList1.Images.SetKeyName(1, "Places-folder-yellow-icon2.png");
            this.imageList1.Images.SetKeyName(2, "folder-yellow-open-icon.png");
            this.imageList1.Images.SetKeyName(3, "Places-folder-blue-icon.png");
            this.imageList1.Images.SetKeyName(4, "folder-blue-open-icon.png");
            // 
            // bsPlanCuentas
            // 
            this.bsPlanCuentas.DataSource = typeof(Entidades.Contabilidad.PlanCuentasE);
            this.bsPlanCuentas.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsPlanCuentas_ListChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvCuentas);
            this.splitContainer1.Panel1.Controls.Add(this.tsMenuArbol);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1025, 465);
            this.splitContainer1.SplitterDistance = 457;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvCuentas
            // 
            this.tvCuentas.BackColor = System.Drawing.Color.White;
            this.tvCuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCuentas.Location = new System.Drawing.Point(0, 25);
            this.tvCuentas.Name = "tvCuentas";
            this.tvCuentas.Size = new System.Drawing.Size(457, 440);
            this.tvCuentas.TabIndex = 0;
            this.tvCuentas.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCuentas_AfterSelect);
            this.tvCuentas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvCuentas_MouseUp);
            // 
            // tsMenuArbol
            // 
            this.tsMenuArbol.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsMenuArbol.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMenuArbol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExpandir,
            this.tsbContraer});
            this.tsMenuArbol.Location = new System.Drawing.Point(0, 0);
            this.tsMenuArbol.Name = "tsMenuArbol";
            this.tsMenuArbol.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsMenuArbol.Size = new System.Drawing.Size(457, 25);
            this.tsMenuArbol.TabIndex = 1;
            this.tsMenuArbol.Text = "toolStrip1";
            // 
            // tsbExpandir
            // 
            this.tsbExpandir.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tsbExpandir.Image = ((System.Drawing.Image)(resources.GetObject("tsbExpandir.Image")));
            this.tsbExpandir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExpandir.Name = "tsbExpandir";
            this.tsbExpandir.Size = new System.Drawing.Size(69, 22);
            this.tsbExpandir.Text = "Expandir";
            this.tsbExpandir.Click += new System.EventHandler(this.tsbExpandir_Click);
            // 
            // tsbContraer
            // 
            this.tsbContraer.Image = ((System.Drawing.Image)(resources.GetObject("tsbContraer.Image")));
            this.tsbContraer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbContraer.Name = "tsbContraer";
            this.tsbContraer.Size = new System.Drawing.Size(70, 22);
            this.tsbContraer.Text = "Contraer";
            this.tsbContraer.Click += new System.EventHandler(this.tsbContraer_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvCuentas);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 465);
            this.panel1.TabIndex = 254;
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.AllowUserToAddRows = false;
            this.dgvCuentas.AllowUserToDeleteRows = false;
            this.dgvCuentas.AutoGenerateColumns = false;
            this.dgvCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codCuentaDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.indCtaCteDataGridViewTextBoxColumn,
            this.indSolicitaDctoDataGridViewTextBoxColumn,
            this.indSolicitaAnexoDataGridViewTextBoxColumn,
            this.indSolicitaCentroCostoDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvCuentas.DataSource = this.bsPlanCuentas;
            this.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCuentas.EnableHeadersVisualStyles = false;
            this.dgvCuentas.Location = new System.Drawing.Point(0, 22);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.ReadOnly = true;
            this.dgvCuentas.Size = new System.Drawing.Size(560, 441);
            this.dgvCuentas.TabIndex = 248;
            this.dgvCuentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuentas_CellDoubleClick);
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
            this.lblRegistros.Size = new System.Drawing.Size(560, 22);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // codCuentaDataGridViewTextBoxColumn
            // 
            this.codCuentaDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCuentaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.codCuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.codCuentaDataGridViewTextBoxColumn.Name = "codCuentaDataGridViewTextBoxColumn";
            this.codCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCuentaDataGridViewTextBoxColumn.Width = 60;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn.Width = 290;
            // 
            // indCtaCteDataGridViewTextBoxColumn
            // 
            this.indCtaCteDataGridViewTextBoxColumn.DataPropertyName = "indCtaCte";
            this.indCtaCteDataGridViewTextBoxColumn.HeaderText = "I.C.Cte.";
            this.indCtaCteDataGridViewTextBoxColumn.Name = "indCtaCteDataGridViewTextBoxColumn";
            this.indCtaCteDataGridViewTextBoxColumn.ReadOnly = true;
            this.indCtaCteDataGridViewTextBoxColumn.ToolTipText = "Indica si lleva Cta.Cte.";
            this.indCtaCteDataGridViewTextBoxColumn.Width = 45;
            // 
            // indSolicitaDctoDataGridViewTextBoxColumn
            // 
            this.indSolicitaDctoDataGridViewTextBoxColumn.DataPropertyName = "indSolicitaDcto";
            this.indSolicitaDctoDataGridViewTextBoxColumn.HeaderText = "I.Doc.";
            this.indSolicitaDctoDataGridViewTextBoxColumn.Name = "indSolicitaDctoDataGridViewTextBoxColumn";
            this.indSolicitaDctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.indSolicitaDctoDataGridViewTextBoxColumn.ToolTipText = "Indica si lleva documento";
            this.indSolicitaDctoDataGridViewTextBoxColumn.Width = 40;
            // 
            // indSolicitaAnexoDataGridViewTextBoxColumn
            // 
            this.indSolicitaAnexoDataGridViewTextBoxColumn.DataPropertyName = "indSolicitaAnexo";
            this.indSolicitaAnexoDataGridViewTextBoxColumn.HeaderText = "I.Aux.";
            this.indSolicitaAnexoDataGridViewTextBoxColumn.Name = "indSolicitaAnexoDataGridViewTextBoxColumn";
            this.indSolicitaAnexoDataGridViewTextBoxColumn.ReadOnly = true;
            this.indSolicitaAnexoDataGridViewTextBoxColumn.ToolTipText = "Indica si lleva Auxiliar";
            this.indSolicitaAnexoDataGridViewTextBoxColumn.Width = 40;
            // 
            // indSolicitaCentroCostoDataGridViewTextBoxColumn
            // 
            this.indSolicitaCentroCostoDataGridViewTextBoxColumn.DataPropertyName = "indSolicitaCentroCosto";
            this.indSolicitaCentroCostoDataGridViewTextBoxColumn.HeaderText = "I.C.C.";
            this.indSolicitaCentroCostoDataGridViewTextBoxColumn.Name = "indSolicitaCentroCostoDataGridViewTextBoxColumn";
            this.indSolicitaCentroCostoDataGridViewTextBoxColumn.ReadOnly = true;
            this.indSolicitaCentroCostoDataGridViewTextBoxColumn.ToolTipText = "Indica si lleva Centro de Costo";
            this.indSolicitaCentroCostoDataGridViewTextBoxColumn.Width = 40;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 130;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // frmPlanContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 465);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.Name = "frmPlanContable";
            this.Text = "Plan Contable";
            this.Load += new System.EventHandler(this.frmPlanContable_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPlanContable_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanCuentas)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tsMenuArbol.ResumeLayout(false);
            this.tsMenuArbol.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvCuentas;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip tsMenuArbol;
        private System.Windows.Forms.ToolStripButton tsbExpandir;
        private System.Windows.Forms.ToolStripButton tsbContraer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.BindingSource bsPlanCuentas;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indCtaCteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indSolicitaDctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indSolicitaAnexoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indSolicitaCentroCostoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}