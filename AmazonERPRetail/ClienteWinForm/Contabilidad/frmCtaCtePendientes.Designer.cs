namespace ClienteWinForm.Contabilidad
{
    partial class frmCtaCtePendientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCuenta = new ControlesWinForm.SuperTextBox();
            this.txtDocumento = new ControlesWinForm.SuperTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.dgvDetalleCtaCte = new System.Windows.Forms.DataGridView();
            this.codCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMonedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoSolesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoDolaresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idCCostos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipPartidaPresu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPartidaPresu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSaldoSoles = new System.Windows.Forms.TextBox();
            this.txtSaldoDolares = new System.Windows.Forms.TextBox();
            this.lblPendiente = new System.Windows.Forms.Label();
            this.lblNaturaleza = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCtaCte)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(120, 410);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCancelar.Size = new System.Drawing.Size(106, 24);
            this.btCancelar.TabIndex = 200;
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(10, 410);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAceptar.Size = new System.Drawing.Size(106, 24);
            this.btAceptar.TabIndex = 100;
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitPnlBase.Size = new System.Drawing.Size(731, 19);
            this.lblTitPnlBase.Text = "Detalle";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloPrincipal.Size = new System.Drawing.Size(745, 25);
            this.lblTituloPrincipal.Text = "Documentos Pendientes";
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Contabilidad.conCtaCteItemE);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(717, 2);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btCerrar.TabStop = false;
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.dgvDetalleCtaCte);
            this.pnlBase.Location = new System.Drawing.Point(9, 89);
            this.pnlBase.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBase.Size = new System.Drawing.Size(733, 315);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.dgvDetalleCtaCte, 0);
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBusqueda.Controls.Add(this.label1);
            this.pnlBusqueda.Controls.Add(this.txtCuenta);
            this.pnlBusqueda.Controls.Add(this.txtDocumento);
            this.pnlBusqueda.Controls.Add(this.label21);
            this.pnlBusqueda.Controls.Add(this.labelDegradado1);
            this.pnlBusqueda.Location = new System.Drawing.Point(9, 29);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(443, 54);
            this.pnlBusqueda.TabIndex = 115;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 372;
            this.label1.Text = "Cuenta";
            // 
            // txtCuenta
            // 
            this.txtCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuenta.BackColor = System.Drawing.Color.White;
            this.txtCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuenta.Location = new System.Drawing.Point(262, 27);
            this.txtCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(160, 20);
            this.txtCuenta.TabIndex = 371;
            this.txtCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCuenta.TextoVacio = "000000";
            this.txtCuenta.TextChanged += new System.EventHandler(this.txtCuenta_TextChanged);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumento.ColorTextoVacio = System.Drawing.Color.Silver;
            this.txtDocumento.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(79, 26);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(126, 21);
            this.txtDocumento.TabIndex = 321;
            this.txtDocumento.TabStop = false;
            this.txtDocumento.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDocumento.TextoVacio = "000-0000000";
            this.txtDocumento.TextChanged += new System.EventHandler(this.txtDocumento_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(10, 30);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 13);
            this.label21.TabIndex = 322;
            this.label21.Text = "Documento";
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
            this.labelDegradado1.Size = new System.Drawing.Size(441, 18);
            this.labelDegradado1.TabIndex = 253;
            this.labelDegradado1.Text = "Busqueda";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDetalleCtaCte
            // 
            this.dgvDetalleCtaCte.AllowUserToAddRows = false;
            this.dgvDetalleCtaCte.AllowUserToDeleteRows = false;
            this.dgvDetalleCtaCte.AutoGenerateColumns = false;
            this.dgvDetalleCtaCte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleCtaCte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalleCtaCte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleCtaCte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codCuenta,
            this.idDocumentoDataGridViewTextBoxColumn,
            this.serDocumentoDataGridViewTextBoxColumn,
            this.numDocumentoDataGridViewTextBoxColumn,
            this.fecDocumentoDataGridViewTextBoxColumn,
            this.idMonedaDataGridViewTextBoxColumn,
            this.saldoSolesDataGridViewTextBoxColumn,
            this.saldoDolaresDataGridViewTextBoxColumn,
            this.dgvChk,
            this.idCCostos,
            this.tipPartidaPresu,
            this.codPartidaPresu});
            this.dgvDetalleCtaCte.DataSource = this.bsBase;
            this.dgvDetalleCtaCte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleCtaCte.EnableHeadersVisualStyles = false;
            this.dgvDetalleCtaCte.Location = new System.Drawing.Point(0, 19);
            this.dgvDetalleCtaCte.Name = "dgvDetalleCtaCte";
            this.dgvDetalleCtaCte.Size = new System.Drawing.Size(731, 294);
            this.dgvDetalleCtaCte.TabIndex = 1;
            this.dgvDetalleCtaCte.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDetalleCtaCte_CellPainting);
            this.dgvDetalleCtaCte.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleCtaCte_CellValueChanged);
            this.dgvDetalleCtaCte.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetalleCtaCte_ColumnHeaderMouseClick);
            this.dgvDetalleCtaCte.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDetalleCtaCte_CurrentCellDirtyStateChanged);
            // 
            // codCuenta
            // 
            this.codCuenta.DataPropertyName = "codCuenta";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCuenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.codCuenta.HeaderText = "Cuenta";
            this.codCuenta.Name = "codCuenta";
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "T.D.";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serDocumentoDataGridViewTextBoxColumn
            // 
            this.serDocumentoDataGridViewTextBoxColumn.DataPropertyName = "serDocumento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.serDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.serDocumentoDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.serDocumentoDataGridViewTextBoxColumn.Name = "serDocumentoDataGridViewTextBoxColumn";
            this.serDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numDocumentoDataGridViewTextBoxColumn
            // 
            this.numDocumentoDataGridViewTextBoxColumn.DataPropertyName = "numDocumento";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.numDocumentoDataGridViewTextBoxColumn.HeaderText = "Número";
            this.numDocumentoDataGridViewTextBoxColumn.Name = "numDocumentoDataGridViewTextBoxColumn";
            this.numDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fecDocumentoDataGridViewTextBoxColumn
            // 
            this.fecDocumentoDataGridViewTextBoxColumn.DataPropertyName = "fecDocumento";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fecDocumentoDataGridViewTextBoxColumn.HeaderText = "Emisión";
            this.fecDocumentoDataGridViewTextBoxColumn.Name = "fecDocumentoDataGridViewTextBoxColumn";
            this.fecDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idMonedaDataGridViewTextBoxColumn
            // 
            this.idMonedaDataGridViewTextBoxColumn.DataPropertyName = "desMoneda";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idMonedaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.idMonedaDataGridViewTextBoxColumn.HeaderText = "Mon.";
            this.idMonedaDataGridViewTextBoxColumn.Name = "idMonedaDataGridViewTextBoxColumn";
            this.idMonedaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saldoSolesDataGridViewTextBoxColumn
            // 
            this.saldoSolesDataGridViewTextBoxColumn.DataPropertyName = "SaldoSoles";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.saldoSolesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.saldoSolesDataGridViewTextBoxColumn.HeaderText = "Saldo S/.";
            this.saldoSolesDataGridViewTextBoxColumn.Name = "saldoSolesDataGridViewTextBoxColumn";
            this.saldoSolesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saldoDolaresDataGridViewTextBoxColumn
            // 
            this.saldoDolaresDataGridViewTextBoxColumn.DataPropertyName = "SaldoDolares";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.saldoDolaresDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.saldoDolaresDataGridViewTextBoxColumn.HeaderText = "Saldo US$";
            this.saldoDolaresDataGridViewTextBoxColumn.Name = "saldoDolaresDataGridViewTextBoxColumn";
            this.saldoDolaresDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dgvChk
            // 
            this.dgvChk.DataPropertyName = "Check";
            this.dgvChk.HeaderText = "";
            this.dgvChk.Name = "dgvChk";
            // 
            // idCCostos
            // 
            this.idCCostos.DataPropertyName = "idCCostos";
            this.idCCostos.HeaderText = "C.Costo";
            this.idCCostos.Name = "idCCostos";
            // 
            // tipPartidaPresu
            // 
            this.tipPartidaPresu.DataPropertyName = "tipPartidaPresu";
            this.tipPartidaPresu.HeaderText = "TG";
            this.tipPartidaPresu.Name = "tipPartidaPresu";
            // 
            // codPartidaPresu
            // 
            this.codPartidaPresu.DataPropertyName = "codPartidaPresu";
            this.codPartidaPresu.HeaderText = "Partida";
            this.codPartidaPresu.Name = "codPartidaPresu";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(245, 413);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 116;
            this.label13.Text = "S/.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(355, 413);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 13);
            this.label14.TabIndex = 117;
            this.label14.Text = "US$";
            // 
            // txtSaldoSoles
            // 
            this.txtSaldoSoles.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSaldoSoles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoSoles.Location = new System.Drawing.Point(270, 410);
            this.txtSaldoSoles.Name = "txtSaldoSoles";
            this.txtSaldoSoles.ReadOnly = true;
            this.txtSaldoSoles.Size = new System.Drawing.Size(76, 21);
            this.txtSaldoSoles.TabIndex = 118;
            this.txtSaldoSoles.TabStop = false;
            this.txtSaldoSoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSaldoDolares
            // 
            this.txtSaldoDolares.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSaldoDolares.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoDolares.Location = new System.Drawing.Point(386, 410);
            this.txtSaldoDolares.Name = "txtSaldoDolares";
            this.txtSaldoDolares.ReadOnly = true;
            this.txtSaldoDolares.Size = new System.Drawing.Size(76, 21);
            this.txtSaldoDolares.TabIndex = 119;
            this.txtSaldoDolares.TabStop = false;
            this.txtSaldoDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPendiente
            // 
            this.lblPendiente.AutoSize = true;
            this.lblPendiente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendiente.Location = new System.Drawing.Point(459, 38);
            this.lblPendiente.Name = "lblPendiente";
            this.lblPendiente.Size = new System.Drawing.Size(0, 13);
            this.lblPendiente.TabIndex = 323;
            // 
            // lblNaturaleza
            // 
            this.lblNaturaleza.AutoSize = true;
            this.lblNaturaleza.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaturaleza.Location = new System.Drawing.Point(459, 61);
            this.lblNaturaleza.Name = "lblNaturaleza";
            this.lblNaturaleza.Size = new System.Drawing.Size(0, 13);
            this.lblNaturaleza.TabIndex = 324;
            // 
            // frmCtaCtePendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 445);
            this.Controls.Add(this.lblNaturaleza);
            this.Controls.Add(this.lblPendiente);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtSaldoSoles);
            this.Controls.Add(this.txtSaldoDolares);
            this.Controls.Add(this.pnlBusqueda);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCtaCtePendientes";
            this.Text = "frmCtaCtePendientes";
            this.Load += new System.EventHandler(this.frmCtaCtePendientes_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlBusqueda, 0);
            this.Controls.SetChildIndex(this.txtSaldoDolares, 0);
            this.Controls.SetChildIndex(this.txtSaldoSoles, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.lblPendiente, 0);
            this.Controls.SetChildIndex(this.lblNaturaleza, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCtaCte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBusqueda;
        private ControlesWinForm.SuperTextBox txtDocumento;
        private System.Windows.Forms.Label label21;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.DataGridView dgvDetalleCtaCte;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSaldoSoles;
        private System.Windows.Forms.TextBox txtSaldoDolares;
        private System.Windows.Forms.Label lblPendiente;
        private System.Windows.Forms.Label lblNaturaleza;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMonedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoSolesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoDolaresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCCostos;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipPartidaPresu;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPartidaPresu;
    }
}