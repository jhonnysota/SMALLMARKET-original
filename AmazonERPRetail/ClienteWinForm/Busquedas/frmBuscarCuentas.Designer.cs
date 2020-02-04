namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarCuentas
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
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.idEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numNivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVerPlanCuentasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipAjuste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indNaturalezaCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCuentaGastos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indSolicitaAnexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indSolicitaCentroCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indAjuste_X_Cambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCambio_X_Compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaSup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaTransferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaGanancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaPerdida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indSolicitaDcto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCtaCte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipTituloNodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indUltNodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVerPartida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipPartidaPresu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPartidaPresu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCuentaCierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaCieDeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codColumnaCoven = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indNotaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indAnexoReferencial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCajaChica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCajaChica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCuentaExt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaExt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCtaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nudNivel = new System.Windows.Forms.NumericUpDown();
            this.rbPorCuenta = new System.Windows.Forms.RadioButton();
            this.rbPorDescripcion = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLetras = new System.Windows.Forms.Label();
            numHojaCostoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.btnAceptar.Location = new System.Drawing.Point(271, 368);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar.Size = new System.Drawing.Size(96, 27);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(373, 368);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Size = new System.Drawing.Size(96, 27);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Image = global::ClienteWinForm.Properties.Resources.busquedas;
            this.btnBuscar.Location = new System.Drawing.Point(408, 77);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Size = new System.Drawing.Size(60, 41);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(89, 357);
            this.chkAnulado.Margin = new System.Windows.Forms.Padding(2);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Size = new System.Drawing.Size(221, 13);
            this.label1.Text = "Ingrese Código o la Descripción de la Cuenta";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(7, 97);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFiltro.Size = new System.Drawing.Size(355, 20);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvCuentas);
            this.gbResultados.Location = new System.Drawing.Point(7, 122);
            this.gbResultados.Margin = new System.Windows.Forms.Padding(2);
            this.gbResultados.Padding = new System.Windows.Forms.Padding(2);
            this.gbResultados.Size = new System.Drawing.Size(463, 241);
            // 
            // numHojaCostoLabel
            // 
            numHojaCostoLabel.AutoSize = true;
            numHojaCostoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numHojaCostoLabel.Location = new System.Drawing.Point(370, 81);
            numHojaCostoLabel.Name = "numHojaCostoLabel";
            numHojaCostoLabel.Size = new System.Drawing.Size(30, 13);
            numHojaCostoLabel.TabIndex = 110;
            numHojaCostoLabel.Text = "Nivel";
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.AllowUserToAddRows = false;
            this.dgvCuentas.AllowUserToDeleteRows = false;
            this.dgvCuentas.AutoGenerateColumns = false;
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEmpresaDataGridViewTextBoxColumn,
            this.codCuentaDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.numNivelDataGridViewTextBoxColumn,
            this.numVerPlanCuentasDataGridViewTextBoxColumn,
            this.tipAjuste,
            this.idMoneda,
            this.indNaturalezaCta,
            this.indCuentaGastos,
            this.indBalance,
            this.indSolicitaAnexo,
            this.indSolicitaCentroCosto,
            this.indAjuste_X_Cambio,
            this.indCambio_X_Compra,
            this.codCuentaSup,
            this.codCuentaDestino,
            this.codCuentaTransferencia,
            this.codCuentaGanancia,
            this.codCuentaPerdida,
            this.indSolicitaDcto,
            this.indCtaCte,
            this.tipTituloNodo,
            this.indUltNodo,
            this.numVerPartida,
            this.tipPartidaPresu,
            this.codPartidaPresu,
            this.indCuentaCierre,
            this.codCuentaCieDeb,
            this.codColumnaCoven,
            this.indNotaIngreso,
            this.indAnexoReferencial,
            this.indCajaChica,
            this.tipoCajaChica,
            this.indCuentaExt,
            this.codCuentaExt,
            this.indCtaIngreso});
            this.dgvCuentas.DataSource = this.bsBase;
            this.dgvCuentas.EnableHeadersVisualStyles = false;
            this.dgvCuentas.Location = new System.Drawing.Point(8, 17);
            this.dgvCuentas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.ReadOnly = true;
            this.dgvCuentas.RowTemplate.Height = 24;
            this.dgvCuentas.Size = new System.Drawing.Size(447, 216);
            this.dgvCuentas.TabIndex = 0;
            this.dgvCuentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuentas_CellDoubleClick);
            this.dgvCuentas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCuentas_CellPainting);
            // 
            // idEmpresaDataGridViewTextBoxColumn
            // 
            this.idEmpresaDataGridViewTextBoxColumn.DataPropertyName = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.HeaderText = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.Name = "idEmpresaDataGridViewTextBoxColumn";
            this.idEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEmpresaDataGridViewTextBoxColumn.Visible = false;
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
            // numNivelDataGridViewTextBoxColumn
            // 
            this.numNivelDataGridViewTextBoxColumn.DataPropertyName = "numNivel";
            this.numNivelDataGridViewTextBoxColumn.HeaderText = "Nivel";
            this.numNivelDataGridViewTextBoxColumn.Name = "numNivelDataGridViewTextBoxColumn";
            this.numNivelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numVerPlanCuentasDataGridViewTextBoxColumn
            // 
            this.numVerPlanCuentasDataGridViewTextBoxColumn.DataPropertyName = "numVerPlanCuentas";
            this.numVerPlanCuentasDataGridViewTextBoxColumn.HeaderText = "numVerPlanCuentas";
            this.numVerPlanCuentasDataGridViewTextBoxColumn.Name = "numVerPlanCuentasDataGridViewTextBoxColumn";
            this.numVerPlanCuentasDataGridViewTextBoxColumn.ReadOnly = true;
            this.numVerPlanCuentasDataGridViewTextBoxColumn.Visible = false;
            // 
            // tipAjuste
            // 
            this.tipAjuste.DataPropertyName = "tipAjuste";
            this.tipAjuste.HeaderText = "tipAjuste";
            this.tipAjuste.Name = "tipAjuste";
            this.tipAjuste.ReadOnly = true;
            this.tipAjuste.Visible = false;
            // 
            // idMoneda
            // 
            this.idMoneda.DataPropertyName = "idMoneda";
            this.idMoneda.HeaderText = "idMoneda";
            this.idMoneda.Name = "idMoneda";
            this.idMoneda.ReadOnly = true;
            this.idMoneda.Visible = false;
            // 
            // indNaturalezaCta
            // 
            this.indNaturalezaCta.DataPropertyName = "indNaturalezaCta";
            this.indNaturalezaCta.HeaderText = "indNaturalezaCta";
            this.indNaturalezaCta.Name = "indNaturalezaCta";
            this.indNaturalezaCta.ReadOnly = true;
            this.indNaturalezaCta.Visible = false;
            // 
            // indCuentaGastos
            // 
            this.indCuentaGastos.DataPropertyName = "indCuentaGastos";
            this.indCuentaGastos.HeaderText = "indCuentaGastos";
            this.indCuentaGastos.Name = "indCuentaGastos";
            this.indCuentaGastos.ReadOnly = true;
            this.indCuentaGastos.Visible = false;
            // 
            // indBalance
            // 
            this.indBalance.DataPropertyName = "indBalance";
            this.indBalance.HeaderText = "indBalance";
            this.indBalance.Name = "indBalance";
            this.indBalance.ReadOnly = true;
            this.indBalance.Visible = false;
            // 
            // indSolicitaAnexo
            // 
            this.indSolicitaAnexo.DataPropertyName = "indSolicitaAnexo";
            this.indSolicitaAnexo.HeaderText = "indSolicitaAnexo";
            this.indSolicitaAnexo.Name = "indSolicitaAnexo";
            this.indSolicitaAnexo.ReadOnly = true;
            this.indSolicitaAnexo.Visible = false;
            // 
            // indSolicitaCentroCosto
            // 
            this.indSolicitaCentroCosto.DataPropertyName = "indSolicitaCentroCosto";
            this.indSolicitaCentroCosto.HeaderText = "indSolicitaCentroCosto";
            this.indSolicitaCentroCosto.Name = "indSolicitaCentroCosto";
            this.indSolicitaCentroCosto.ReadOnly = true;
            this.indSolicitaCentroCosto.Visible = false;
            // 
            // indAjuste_X_Cambio
            // 
            this.indAjuste_X_Cambio.DataPropertyName = "indAjuste_X_Cambio";
            this.indAjuste_X_Cambio.HeaderText = "indAjuste_X_Cambio";
            this.indAjuste_X_Cambio.Name = "indAjuste_X_Cambio";
            this.indAjuste_X_Cambio.ReadOnly = true;
            this.indAjuste_X_Cambio.Visible = false;
            // 
            // indCambio_X_Compra
            // 
            this.indCambio_X_Compra.DataPropertyName = "indCambio_X_Compra";
            this.indCambio_X_Compra.HeaderText = "indCambio_X_Compra";
            this.indCambio_X_Compra.Name = "indCambio_X_Compra";
            this.indCambio_X_Compra.ReadOnly = true;
            this.indCambio_X_Compra.Visible = false;
            // 
            // codCuentaSup
            // 
            this.codCuentaSup.DataPropertyName = "codCuentaSup";
            this.codCuentaSup.HeaderText = "codCuentaSup";
            this.codCuentaSup.Name = "codCuentaSup";
            this.codCuentaSup.ReadOnly = true;
            this.codCuentaSup.Visible = false;
            // 
            // codCuentaDestino
            // 
            this.codCuentaDestino.DataPropertyName = "codCuentaDestino";
            this.codCuentaDestino.HeaderText = "codCuentaDestino";
            this.codCuentaDestino.Name = "codCuentaDestino";
            this.codCuentaDestino.ReadOnly = true;
            this.codCuentaDestino.Visible = false;
            // 
            // codCuentaTransferencia
            // 
            this.codCuentaTransferencia.DataPropertyName = "codCuentaTransferencia";
            this.codCuentaTransferencia.HeaderText = "codCuentaTransferencia";
            this.codCuentaTransferencia.Name = "codCuentaTransferencia";
            this.codCuentaTransferencia.ReadOnly = true;
            this.codCuentaTransferencia.Visible = false;
            // 
            // codCuentaGanancia
            // 
            this.codCuentaGanancia.DataPropertyName = "codCuentaGanancia";
            this.codCuentaGanancia.HeaderText = "codCuentaGanancia";
            this.codCuentaGanancia.Name = "codCuentaGanancia";
            this.codCuentaGanancia.ReadOnly = true;
            this.codCuentaGanancia.Visible = false;
            // 
            // codCuentaPerdida
            // 
            this.codCuentaPerdida.DataPropertyName = "codCuentaPerdida";
            this.codCuentaPerdida.HeaderText = "codCuentaPerdida";
            this.codCuentaPerdida.Name = "codCuentaPerdida";
            this.codCuentaPerdida.ReadOnly = true;
            this.codCuentaPerdida.Visible = false;
            // 
            // indSolicitaDcto
            // 
            this.indSolicitaDcto.DataPropertyName = "indSolicitaDcto";
            this.indSolicitaDcto.HeaderText = "indSolicitaDcto";
            this.indSolicitaDcto.Name = "indSolicitaDcto";
            this.indSolicitaDcto.ReadOnly = true;
            this.indSolicitaDcto.Visible = false;
            // 
            // indCtaCte
            // 
            this.indCtaCte.DataPropertyName = "indCtaCte";
            this.indCtaCte.HeaderText = "indCtaCte";
            this.indCtaCte.Name = "indCtaCte";
            this.indCtaCte.ReadOnly = true;
            this.indCtaCte.Visible = false;
            // 
            // tipTituloNodo
            // 
            this.tipTituloNodo.DataPropertyName = "tipTituloNodo";
            this.tipTituloNodo.HeaderText = "tipTituloNodo";
            this.tipTituloNodo.Name = "tipTituloNodo";
            this.tipTituloNodo.ReadOnly = true;
            this.tipTituloNodo.Visible = false;
            // 
            // indUltNodo
            // 
            this.indUltNodo.DataPropertyName = "indUltNodo";
            this.indUltNodo.HeaderText = "indUltNodo";
            this.indUltNodo.Name = "indUltNodo";
            this.indUltNodo.ReadOnly = true;
            this.indUltNodo.Visible = false;
            // 
            // numVerPartida
            // 
            this.numVerPartida.DataPropertyName = "numVerPartida";
            this.numVerPartida.HeaderText = "numVerPartida";
            this.numVerPartida.Name = "numVerPartida";
            this.numVerPartida.ReadOnly = true;
            this.numVerPartida.Visible = false;
            // 
            // tipPartidaPresu
            // 
            this.tipPartidaPresu.DataPropertyName = "tipPartidaPresu";
            this.tipPartidaPresu.HeaderText = "tipPartidaPresu";
            this.tipPartidaPresu.Name = "tipPartidaPresu";
            this.tipPartidaPresu.ReadOnly = true;
            this.tipPartidaPresu.Visible = false;
            // 
            // codPartidaPresu
            // 
            this.codPartidaPresu.DataPropertyName = "codPartidaPresu";
            this.codPartidaPresu.HeaderText = "codPartidaPresu";
            this.codPartidaPresu.Name = "codPartidaPresu";
            this.codPartidaPresu.ReadOnly = true;
            this.codPartidaPresu.Visible = false;
            // 
            // indCuentaCierre
            // 
            this.indCuentaCierre.DataPropertyName = "indCuentaCierre";
            this.indCuentaCierre.HeaderText = "indCuentaCierre";
            this.indCuentaCierre.Name = "indCuentaCierre";
            this.indCuentaCierre.ReadOnly = true;
            this.indCuentaCierre.Visible = false;
            // 
            // codCuentaCieDeb
            // 
            this.codCuentaCieDeb.DataPropertyName = "codCuentaCieDeb";
            this.codCuentaCieDeb.HeaderText = "codCuentaCieDeb";
            this.codCuentaCieDeb.Name = "codCuentaCieDeb";
            this.codCuentaCieDeb.ReadOnly = true;
            this.codCuentaCieDeb.Visible = false;
            // 
            // codColumnaCoven
            // 
            this.codColumnaCoven.DataPropertyName = "codColumnaCoven";
            this.codColumnaCoven.HeaderText = "codColumnaCoven";
            this.codColumnaCoven.Name = "codColumnaCoven";
            this.codColumnaCoven.ReadOnly = true;
            this.codColumnaCoven.Visible = false;
            // 
            // indNotaIngreso
            // 
            this.indNotaIngreso.DataPropertyName = "indNotaIngreso";
            this.indNotaIngreso.HeaderText = "indNotaIngreso";
            this.indNotaIngreso.Name = "indNotaIngreso";
            this.indNotaIngreso.ReadOnly = true;
            this.indNotaIngreso.Visible = false;
            // 
            // indAnexoReferencial
            // 
            this.indAnexoReferencial.DataPropertyName = "indAnexoReferencial";
            this.indAnexoReferencial.HeaderText = "indAnexoReferencial";
            this.indAnexoReferencial.Name = "indAnexoReferencial";
            this.indAnexoReferencial.ReadOnly = true;
            this.indAnexoReferencial.Visible = false;
            // 
            // indCajaChica
            // 
            this.indCajaChica.DataPropertyName = "indCajaChica";
            this.indCajaChica.HeaderText = "indCajaChica";
            this.indCajaChica.Name = "indCajaChica";
            this.indCajaChica.ReadOnly = true;
            this.indCajaChica.Visible = false;
            // 
            // tipoCajaChica
            // 
            this.tipoCajaChica.DataPropertyName = "tipoCajaChica";
            this.tipoCajaChica.HeaderText = "tipoCajaChica";
            this.tipoCajaChica.Name = "tipoCajaChica";
            this.tipoCajaChica.ReadOnly = true;
            this.tipoCajaChica.Visible = false;
            // 
            // indCuentaExt
            // 
            this.indCuentaExt.DataPropertyName = "indCuentaExt";
            this.indCuentaExt.HeaderText = "indCuentaExt";
            this.indCuentaExt.Name = "indCuentaExt";
            this.indCuentaExt.ReadOnly = true;
            this.indCuentaExt.Visible = false;
            // 
            // codCuentaExt
            // 
            this.codCuentaExt.DataPropertyName = "codCuentaExt";
            this.codCuentaExt.HeaderText = "codCuentaExt";
            this.codCuentaExt.Name = "codCuentaExt";
            this.codCuentaExt.ReadOnly = true;
            this.codCuentaExt.Visible = false;
            // 
            // indCtaIngreso
            // 
            this.indCtaIngreso.DataPropertyName = "indCtaIngreso";
            this.indCtaIngreso.HeaderText = "indCtaIngreso";
            this.indCtaIngreso.Name = "indCtaIngreso";
            this.indCtaIngreso.ReadOnly = true;
            this.indCtaIngreso.Visible = false;
            // 
            // nudNivel
            // 
            this.nudNivel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNivel.Location = new System.Drawing.Point(367, 97);
            this.nudNivel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNivel.Name = "nudNivel";
            this.nudNivel.Size = new System.Drawing.Size(36, 21);
            this.nudNivel.TabIndex = 9;
            this.nudNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNivel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbPorCuenta
            // 
            this.rbPorCuenta.AutoSize = true;
            this.rbPorCuenta.Checked = true;
            this.rbPorCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPorCuenta.Location = new System.Drawing.Point(81, 31);
            this.rbPorCuenta.Name = "rbPorCuenta";
            this.rbPorCuenta.Size = new System.Drawing.Size(88, 17);
            this.rbPorCuenta.TabIndex = 111;
            this.rbPorCuenta.TabStop = true;
            this.rbPorCuenta.Text = "Por Cuenta";
            this.rbPorCuenta.UseVisualStyleBackColor = true;
            // 
            // rbPorDescripcion
            // 
            this.rbPorDescripcion.AutoSize = true;
            this.rbPorDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPorDescripcion.Location = new System.Drawing.Point(264, 31);
            this.rbPorDescripcion.Name = "rbPorDescripcion";
            this.rbPorDescripcion.Size = new System.Drawing.Size(115, 17);
            this.rbPorDescripcion.TabIndex = 112;
            this.rbPorDescripcion.Text = "Por Descripción";
            this.rbPorDescripcion.UseVisualStyleBackColor = true;
            this.rbPorDescripcion.CheckedChanged += new System.EventHandler(this.rbPorDescripcion_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLetras);
            this.panel1.Controls.Add(this.rbPorDescripcion);
            this.panel1.Controls.Add(this.rbPorCuenta);
            this.panel1.Location = new System.Drawing.Point(8, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 62);
            this.panel1.TabIndex = 113;
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
            // frmBuscarCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 401);
            this.Controls.Add(this.panel1);
            this.Controls.Add(numHojaCostoLabel);
            this.Controls.Add(this.nudNivel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmBuscarCuentas";
            this.Text = "Busqueda de Cuentas Contables";
            this.Load += new System.EventHandler(this.frmBuscarCuentas_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            this.Controls.SetChildIndex(this.nudNivel, 0);
            this.Controls.SetChildIndex(numHojaCostoLabel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.NumericUpDown nudNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numNivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVerPlanCuentasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipAjuste;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn indNaturalezaCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn indCuentaGastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn indBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn indSolicitaAnexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn indSolicitaCentroCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn indAjuste_X_Cambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn indCambio_X_Compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaSup;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaTransferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaGanancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaPerdida;
        private System.Windows.Forms.DataGridViewTextBoxColumn indSolicitaDcto;
        private System.Windows.Forms.DataGridViewTextBoxColumn indCtaCte;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipTituloNodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn indUltNodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVerPartida;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipPartidaPresu;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPartidaPresu;
        private System.Windows.Forms.DataGridViewTextBoxColumn indCuentaCierre;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaCieDeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn codColumnaCoven;
        private System.Windows.Forms.DataGridViewTextBoxColumn indNotaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn indAnexoReferencial;
        private System.Windows.Forms.DataGridViewTextBoxColumn indCajaChica;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCajaChica;
        private System.Windows.Forms.DataGridViewTextBoxColumn indCuentaExt;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaExt;
        private System.Windows.Forms.DataGridViewTextBoxColumn indCtaIngreso;
        private System.Windows.Forms.RadioButton rbPorCuenta;
        private System.Windows.Forms.RadioButton rbPorDescripcion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLetras;
    }
}