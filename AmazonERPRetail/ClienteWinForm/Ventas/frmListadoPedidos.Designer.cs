namespace ClienteWinForm.Ventas
{
    partial class frmListadoPedidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlOpciones = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.RbFactura = new System.Windows.Forms.RadioButton();
            this.RbEntrega = new System.Windows.Forms.RadioButton();
            this.RbPedido = new System.Windows.Forms.RadioButton();
            this.RbCotizacion = new System.Windows.Forms.RadioButton();
            this.txtNombresVendedor = new ControlesWinForm.SuperTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEstados = new System.Windows.Forms.ComboBox();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.txtPedido = new ControlesWinForm.SuperTextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.idPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FecCotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FecPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FecFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desFacturarDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendedorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroGuia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totsubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOrdenCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorreoEnviado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsPedido = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiConvertir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCrear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMandar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCopiar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGeneraOC = new System.Windows.Forms.ToolStripMenuItem();
            this.tssLineamprimirBarras = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiImprimirBarras = new System.Windows.Forms.ToolStripMenuItem();
            this.bsPedidos = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.LblRegistros = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn56 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn58 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn59 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn62 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn63 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn64 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn65 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn66 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn67 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn68 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn69 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn70 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn71 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn72 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn73 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn74 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn75 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn76 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn77 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn78 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn79 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn81 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn82 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn83 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn84 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn85 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn86 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn87 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn88 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn89 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn90 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn91 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn92 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn93 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn94 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn95 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn96 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn97 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn98 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn99 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btDesvincular = new System.Windows.Forms.Button();
            this.pnlOpciones.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.cmsPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOpciones.Controls.Add(this.label2);
            this.pnlOpciones.Controls.Add(this.RbFactura);
            this.pnlOpciones.Controls.Add(this.RbEntrega);
            this.pnlOpciones.Controls.Add(this.RbPedido);
            this.pnlOpciones.Controls.Add(this.RbCotizacion);
            this.pnlOpciones.Controls.Add(this.txtNombresVendedor);
            this.pnlOpciones.Controls.Add(this.label3);
            this.pnlOpciones.Controls.Add(this.label1);
            this.pnlOpciones.Controls.Add(this.cboEstados);
            this.pnlOpciones.Controls.Add(this.dtpInicio);
            this.pnlOpciones.Controls.Add(this.dtpFin);
            this.pnlOpciones.Controls.Add(this.txtPedido);
            this.pnlOpciones.Controls.Add(this.btnBuscar);
            this.pnlOpciones.Controls.Add(this.txtDescripcion);
            this.pnlOpciones.Location = new System.Drawing.Point(3, 3);
            this.pnlOpciones.Name = "pnlOpciones";
            this.pnlOpciones.Size = new System.Drawing.Size(918, 85);
            this.pnlOpciones.TabIndex = 301;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(916, 18);
            this.label2.TabIndex = 367;
            this.label2.Text = "Opciones de Búsqueda";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RbFactura
            // 
            this.RbFactura.AutoSize = true;
            this.RbFactura.Location = new System.Drawing.Point(311, 32);
            this.RbFactura.Name = "RbFactura";
            this.RbFactura.Size = new System.Drawing.Size(67, 17);
            this.RbFactura.TabIndex = 323;
            this.RbFactura.Text = "Fec.Fac.";
            this.RbFactura.UseVisualStyleBackColor = true;
            // 
            // RbEntrega
            // 
            this.RbEntrega.AutoSize = true;
            this.RbEntrega.Location = new System.Drawing.Point(386, 32);
            this.RbEntrega.Name = "RbEntrega";
            this.RbEntrega.Size = new System.Drawing.Size(65, 17);
            this.RbEntrega.TabIndex = 322;
            this.RbEntrega.Text = "Fec.Ent.";
            this.RbEntrega.UseVisualStyleBackColor = true;
            // 
            // RbPedido
            // 
            this.RbPedido.AutoSize = true;
            this.RbPedido.Location = new System.Drawing.Point(235, 32);
            this.RbPedido.Name = "RbPedido";
            this.RbPedido.Size = new System.Drawing.Size(68, 17);
            this.RbPedido.TabIndex = 321;
            this.RbPedido.Text = "Fec.Ped.";
            this.RbPedido.UseVisualStyleBackColor = true;
            // 
            // RbCotizacion
            // 
            this.RbCotizacion.AutoSize = true;
            this.RbCotizacion.Checked = true;
            this.RbCotizacion.Location = new System.Drawing.Point(162, 32);
            this.RbCotizacion.Name = "RbCotizacion";
            this.RbCotizacion.Size = new System.Drawing.Size(65, 17);
            this.RbCotizacion.TabIndex = 320;
            this.RbCotizacion.TabStop = true;
            this.RbCotizacion.Text = "Fec.Cot.";
            this.RbCotizacion.UseVisualStyleBackColor = true;
            // 
            // txtNombresVendedor
            // 
            this.txtNombresVendedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtNombresVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtNombresVendedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombresVendedor.Enabled = false;
            this.txtNombresVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombresVendedor.Location = new System.Drawing.Point(454, 53);
            this.txtNombresVendedor.Name = "txtNombresVendedor";
            this.txtNombresVendedor.Size = new System.Drawing.Size(443, 20);
            this.txtNombresVendedor.TabIndex = 319;
            this.txtNombresVendedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombresVendedor.TextoVacio = "Nombre Vendedor";
            this.txtNombresVendedor.TextChanged += new System.EventHandler(this.txtNombresVendedor_TextChanged);
            this.txtNombresVendedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombresVendedor_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(556, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 255;
            this.label3.Text = "Al";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(680, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 264;
            this.label1.Text = "Por Estados";
            // 
            // cboEstados
            // 
            this.cboEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstados.FormattingEnabled = true;
            this.cboEstados.Location = new System.Drawing.Point(747, 29);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Size = new System.Drawing.Size(150, 21);
            this.cboEstados.TabIndex = 262;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(454, 30);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(2);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(92, 20);
            this.dtpInicio.TabIndex = 252;
            // 
            // dtpFin
            // 
            this.dtpFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(583, 30);
            this.dtpFin.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(92, 20);
            this.dtpFin.TabIndex = 253;
            // 
            // txtPedido
            // 
            this.txtPedido.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtPedido.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPedido.Location = new System.Drawing.Point(18, 30);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(116, 20);
            this.txtPedido.TabIndex = 260;
            this.txtPedido.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtPedido.TextoVacio = "Cód.Pedido";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.btnBuscar.Location = new System.Drawing.Point(1217, 33);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(83, 59);
            this.btnBuscar.TabIndex = 154;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Visible = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(18, 53);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(430, 20);
            this.txtDescripcion.TabIndex = 263;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripcion.TextoVacio = "Razón Social";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvPedidos);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.LblRegistros);
            this.panel1.Location = new System.Drawing.Point(3, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1230, 349);
            this.panel1.TabIndex = 300;
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.AutoGenerateColumns = false;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPedido,
            this.DesEstado,
            this.FecCotizacion,
            this.FecPedido,
            this.FecFactura,
            this.codPedidoDataGridViewTextBoxColumn,
            this.desFacturarDataGridViewTextBoxColumn1,
            this.vendedorDataGridViewTextBoxColumn1,
            this.nroFactura,
            this.NroGuia,
            this.totsubTotal,
            this.totTotal,
            this.idOrdenCompra,
            this.CorreoEnviado,
            this.usuarioRegistroDataGridViewTextBoxColumn1,
            this.fechaRegistroDataGridViewTextBoxColumn1,
            this.usuarioModificacionDataGridViewTextBoxColumn1,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.Estado});
            this.dgvPedidos.ContextMenuStrip = this.cmsPedido;
            this.dgvPedidos.DataSource = this.bsPedidos;
            this.dgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidos.EnableHeadersVisualStyles = false;
            this.dgvPedidos.Location = new System.Drawing.Point(0, 18);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.Size = new System.Drawing.Size(1228, 329);
            this.dgvPedidos.TabIndex = 302;
            this.dgvPedidos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellDoubleClick);
            this.dgvPedidos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPedidos_CellFormatting);
            // 
            // idPedido
            // 
            this.idPedido.DataPropertyName = "idPedido";
            this.idPedido.HeaderText = "ID.";
            this.idPedido.Name = "idPedido";
            this.idPedido.ReadOnly = true;
            this.idPedido.Width = 50;
            // 
            // DesEstado
            // 
            this.DesEstado.DataPropertyName = "DesEstado";
            this.DesEstado.HeaderText = "Estado";
            this.DesEstado.Name = "DesEstado";
            this.DesEstado.ReadOnly = true;
            this.DesEstado.Width = 90;
            // 
            // FecCotizacion
            // 
            this.FecCotizacion.DataPropertyName = "FecCotizacion";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FecCotizacion.DefaultCellStyle = dataGridViewCellStyle1;
            this.FecCotizacion.HeaderText = "Fec.Cot.";
            this.FecCotizacion.Name = "FecCotizacion";
            this.FecCotizacion.ReadOnly = true;
            this.FecCotizacion.ToolTipText = "Fecha de la cotización";
            this.FecCotizacion.Width = 80;
            // 
            // FecPedido
            // 
            this.FecPedido.DataPropertyName = "FecPedido";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FecPedido.DefaultCellStyle = dataGridViewCellStyle2;
            this.FecPedido.HeaderText = "Fec.Ped.";
            this.FecPedido.Name = "FecPedido";
            this.FecPedido.ReadOnly = true;
            this.FecPedido.ToolTipText = "Fecha del Pedido";
            this.FecPedido.Width = 80;
            // 
            // FecFactura
            // 
            this.FecFactura.DataPropertyName = "FecFactura";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FecFactura.DefaultCellStyle = dataGridViewCellStyle3;
            this.FecFactura.HeaderText = "Fec.Fac.";
            this.FecFactura.Name = "FecFactura";
            this.FecFactura.ReadOnly = true;
            this.FecFactura.ToolTipText = "Fecha de la factura";
            this.FecFactura.Width = 80;
            // 
            // codPedidoDataGridViewTextBoxColumn
            // 
            this.codPedidoDataGridViewTextBoxColumn.DataPropertyName = "codPedidoCad";
            this.codPedidoDataGridViewTextBoxColumn.HeaderText = "Cód.Pedido";
            this.codPedidoDataGridViewTextBoxColumn.Name = "codPedidoDataGridViewTextBoxColumn";
            this.codPedidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codPedidoDataGridViewTextBoxColumn.Width = 80;
            // 
            // desFacturarDataGridViewTextBoxColumn1
            // 
            this.desFacturarDataGridViewTextBoxColumn1.DataPropertyName = "desFacturar";
            this.desFacturarDataGridViewTextBoxColumn1.HeaderText = "Razón Social";
            this.desFacturarDataGridViewTextBoxColumn1.Name = "desFacturarDataGridViewTextBoxColumn1";
            this.desFacturarDataGridViewTextBoxColumn1.ReadOnly = true;
            this.desFacturarDataGridViewTextBoxColumn1.Width = 200;
            // 
            // vendedorDataGridViewTextBoxColumn1
            // 
            this.vendedorDataGridViewTextBoxColumn1.DataPropertyName = "Vendedor";
            this.vendedorDataGridViewTextBoxColumn1.HeaderText = "Vendedor";
            this.vendedorDataGridViewTextBoxColumn1.Name = "vendedorDataGridViewTextBoxColumn1";
            this.vendedorDataGridViewTextBoxColumn1.ReadOnly = true;
            this.vendedorDataGridViewTextBoxColumn1.Width = 200;
            // 
            // nroFactura
            // 
            this.nroFactura.DataPropertyName = "nroFactura";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nroFactura.DefaultCellStyle = dataGridViewCellStyle4;
            this.nroFactura.HeaderText = "Nro. Doc. Venta";
            this.nroFactura.Name = "nroFactura";
            this.nroFactura.ReadOnly = true;
            this.nroFactura.Width = 110;
            // 
            // NroGuia
            // 
            this.NroGuia.DataPropertyName = "NroGuia";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NroGuia.DefaultCellStyle = dataGridViewCellStyle5;
            this.NroGuia.HeaderText = "Nro. Guia";
            this.NroGuia.Name = "NroGuia";
            this.NroGuia.ReadOnly = true;
            this.NroGuia.Width = 90;
            // 
            // totsubTotal
            // 
            this.totsubTotal.DataPropertyName = "totsubTotal";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.totsubTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.totsubTotal.HeaderText = "SubTotal";
            this.totsubTotal.Name = "totsubTotal";
            this.totsubTotal.ReadOnly = true;
            this.totsubTotal.Width = 80;
            // 
            // totTotal
            // 
            this.totTotal.DataPropertyName = "totTotal";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.totTotal.DefaultCellStyle = dataGridViewCellStyle7;
            this.totTotal.HeaderText = "Total";
            this.totTotal.Name = "totTotal";
            this.totTotal.ReadOnly = true;
            this.totTotal.Width = 80;
            // 
            // idOrdenCompra
            // 
            this.idOrdenCompra.DataPropertyName = "numOrdenCompra";
            this.idOrdenCompra.HeaderText = "O.C.";
            this.idOrdenCompra.Name = "idOrdenCompra";
            this.idOrdenCompra.ReadOnly = true;
            this.idOrdenCompra.Width = 90;
            // 
            // CorreoEnviado
            // 
            this.CorreoEnviado.DataPropertyName = "CorreoEnviado";
            this.CorreoEnviado.HeaderText = "C.E.";
            this.CorreoEnviado.Name = "CorreoEnviado";
            this.CorreoEnviado.ReadOnly = true;
            this.CorreoEnviado.ToolTipText = "Correo Enviado";
            this.CorreoEnviado.Width = 30;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn1
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn1.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn1.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn1.Name = "usuarioRegistroDataGridViewTextBoxColumn1";
            this.usuarioRegistroDataGridViewTextBoxColumn1.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn1.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn1
            // 
            this.fechaRegistroDataGridViewTextBoxColumn1.DataPropertyName = "fechaRegistro";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.fechaRegistroDataGridViewTextBoxColumn1.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn1.Name = "fechaRegistroDataGridViewTextBoxColumn1";
            this.fechaRegistroDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn1.Width = 120;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn1
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn1.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn1.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn1.Name = "usuarioModificacionDataGridViewTextBoxColumn1";
            this.usuarioModificacionDataGridViewTextBoxColumn1.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn1.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "fechaModificacion";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // cmsPedido
            // 
            this.cmsPedido.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConvertir,
            this.tsmiCrear,
            this.tsmiMandar,
            this.toolStripSeparator1,
            this.tsmiCopiar,
            this.tsmiGeneraOC,
            this.tssLineamprimirBarras,
            this.tsmiImprimirBarras});
            this.cmsPedido.Name = "cmsFactura";
            this.cmsPedido.Size = new System.Drawing.Size(176, 148);
            // 
            // tsmiConvertir
            // 
            this.tsmiConvertir.Name = "tsmiConvertir";
            this.tsmiConvertir.Size = new System.Drawing.Size(175, 22);
            this.tsmiConvertir.Text = "Convertir a Pedido";
            this.tsmiConvertir.Click += new System.EventHandler(this.TsmiConvertir_Click);
            // 
            // tsmiCrear
            // 
            this.tsmiCrear.Image = global::ClienteWinForm.Properties.Resources.CrearDocumentos;
            this.tsmiCrear.Name = "tsmiCrear";
            this.tsmiCrear.Size = new System.Drawing.Size(175, 22);
            this.tsmiCrear.Text = "Crear Documentos";
            this.tsmiCrear.Click += new System.EventHandler(this.tsmiCrear_Click);
            // 
            // tsmiMandar
            // 
            this.tsmiMandar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsmiMandar.Image = global::ClienteWinForm.Properties.Resources.Enviar_Correo;
            this.tsmiMandar.Name = "tsmiMandar";
            this.tsmiMandar.Size = new System.Drawing.Size(175, 22);
            this.tsmiMandar.Text = "Mandar por Correo";
            this.tsmiMandar.Click += new System.EventHandler(this.tsmiMandar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // tsmiCopiar
            // 
            this.tsmiCopiar.Image = global::ClienteWinForm.Properties.Resources.Copiar32x32;
            this.tsmiCopiar.Name = "tsmiCopiar";
            this.tsmiCopiar.Size = new System.Drawing.Size(175, 22);
            this.tsmiCopiar.Text = "Copiar Pedido";
            this.tsmiCopiar.Click += new System.EventHandler(this.tsmiCopiar_Click);
            // 
            // tsmiGeneraOC
            // 
            this.tsmiGeneraOC.Image = global::ClienteWinForm.Properties.Resources.Calcular_Letras_32x32;
            this.tsmiGeneraOC.Name = "tsmiGeneraOC";
            this.tsmiGeneraOC.Size = new System.Drawing.Size(175, 22);
            this.tsmiGeneraOC.Text = "Genera O.C. A.yV.";
            this.tsmiGeneraOC.Visible = false;
            this.tsmiGeneraOC.Click += new System.EventHandler(this.tsmiGeneraOC_Click);
            // 
            // tssLineamprimirBarras
            // 
            this.tssLineamprimirBarras.Name = "tssLineamprimirBarras";
            this.tssLineamprimirBarras.Size = new System.Drawing.Size(172, 6);
            this.tssLineamprimirBarras.Visible = false;
            // 
            // tsmiImprimirBarras
            // 
            this.tsmiImprimirBarras.Image = global::ClienteWinForm.Properties.Resources.barcode;
            this.tsmiImprimirBarras.Name = "tsmiImprimirBarras";
            this.tsmiImprimirBarras.Size = new System.Drawing.Size(175, 22);
            this.tsmiImprimirBarras.Text = "Imprimir Etiquetas";
            this.tsmiImprimirBarras.Visible = false;
            this.tsmiImprimirBarras.Click += new System.EventHandler(this.tsmiImprimirBarras_Click);
            // 
            // bsPedidos
            // 
            this.bsPedidos.DataSource = typeof(Entidades.Ventas.PedidoCabE);
            this.bsPedidos.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsPedidos_ListChanged);
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // LblRegistros
            // 
            this.LblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.LblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRegistros.Location = new System.Drawing.Point(0, 0);
            this.LblRegistros.Name = "LblRegistros";
            this.LblRegistros.Size = new System.Drawing.Size(1228, 18);
            this.LblRegistros.TabIndex = 367;
            this.LblRegistros.Text = "Registros 0";
            this.LblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "idEmpresa";
            this.dataGridViewTextBoxColumn1.HeaderText = "idEmpresa";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "idLocal";
            this.dataGridViewTextBoxColumn2.HeaderText = "idLocal";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "id_pedido";
            this.dataGridViewTextBoxColumn3.HeaderText = "id_pedido";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CodPedido";
            this.dataGridViewTextBoxColumn4.HeaderText = "CodPedido";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Fecha";
            this.dataGridViewTextBoxColumn5.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "idConsignatario";
            this.dataGridViewTextBoxColumn6.HeaderText = "idConsignatario";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "idNotificar";
            this.dataGridViewTextBoxColumn7.HeaderText = "idNotificar";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "idConsFitosanitario";
            this.dataGridViewTextBoxColumn8.HeaderText = "idConsFitosanitario";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "idFacturar";
            this.dataGridViewTextBoxColumn9.HeaderText = "idFacturar";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "idBroker";
            this.dataGridViewTextBoxColumn10.HeaderText = "idBroker";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "idSemanaEmbarque";
            this.dataGridViewTextBoxColumn11.HeaderText = "idSemanaEmbarque";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "idPaisOrigen";
            this.dataGridViewTextBoxColumn12.HeaderText = "idPaisOrigen";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "idOrigen";
            this.dataGridViewTextBoxColumn13.HeaderText = "idOrigen";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "idPaisDestino";
            this.dataGridViewTextBoxColumn14.HeaderText = "idPaisDestino";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "idDestino";
            this.dataGridViewTextBoxColumn15.HeaderText = "idDestino";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "idFlete";
            this.dataGridViewTextBoxColumn16.HeaderText = "idFlete";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "idBlEmision";
            this.dataGridViewTextBoxColumn17.HeaderText = "idBlEmision";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "idTipoCompra";
            this.dataGridViewTextBoxColumn18.HeaderText = "idTipoCompra";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "idIncoterms";
            this.dataGridViewTextBoxColumn19.HeaderText = "idIncoterms";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "idMoneda";
            this.dataGridViewTextBoxColumn20.HeaderText = "idMoneda";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Observacion";
            this.dataGridViewTextBoxColumn21.HeaderText = "Observacion";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "idOperador";
            this.dataGridViewTextBoxColumn22.HeaderText = "idOperador";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Estado";
            this.dataGridViewTextBoxColumn23.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Reserva";
            this.dataGridViewTextBoxColumn24.HeaderText = "Reserva";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "idNaviera";
            this.dataGridViewTextBoxColumn25.HeaderText = "idNaviera";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "Eta";
            this.dataGridViewTextBoxColumn26.HeaderText = "Eta";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "Etd";
            this.dataGridViewTextBoxColumn27.HeaderText = "Etd";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "Barco";
            this.dataGridViewTextBoxColumn28.HeaderText = "Barco";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "AlmacenIngreso";
            this.dataGridViewTextBoxColumn29.HeaderText = "AlmacenIngreso";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "FechaPosic";
            this.dataGridViewTextBoxColumn30.HeaderText = "FechaPosic";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "FechaInspeccion";
            this.dataGridViewTextBoxColumn31.HeaderText = "FechaInspeccion";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "Contenedor";
            this.dataGridViewTextBoxColumn32.HeaderText = "Contenedor";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.DataPropertyName = "TermografosNum";
            this.dataGridViewTextBoxColumn33.HeaderText = "TermografosNum";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "TermografosNum2";
            this.dataGridViewTextBoxColumn34.HeaderText = "TermografosNum2";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "TermografosUbi";
            this.dataGridViewTextBoxColumn35.HeaderText = "TermografosUbi";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "TermografosUbi2";
            this.dataGridViewTextBoxColumn36.HeaderText = "TermografosUbi2";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.DataPropertyName = "PrecintoOperador";
            this.dataGridViewTextBoxColumn37.HeaderText = "PrecintoOperador";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "PrecintoNaviera";
            this.dataGridViewTextBoxColumn38.HeaderText = "PrecintoNaviera";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "PrecintoSenasa";
            this.dataGridViewTextBoxColumn39.HeaderText = "PrecintoSenasa";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "PrecintoAduana";
            this.dataGridViewTextBoxColumn40.HeaderText = "PrecintoAduana";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "PrecintoOtro";
            this.dataGridViewTextBoxColumn41.HeaderText = "PrecintoOtro";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.DataPropertyName = "NroGuia";
            this.dataGridViewTextBoxColumn42.HeaderText = "NroGuia";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.DataPropertyName = "nroDocReferencia";
            this.dataGridViewTextBoxColumn43.HeaderText = "nroDocReferencia";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.DataPropertyName = "fecFactura";
            this.dataGridViewTextBoxColumn44.HeaderText = "fecFactura";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.DataPropertyName = "nroFactura";
            this.dataGridViewTextBoxColumn45.HeaderText = "nroFactura";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.DataPropertyName = "nroBl";
            this.dataGridViewTextBoxColumn46.HeaderText = "nroBl";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.DataPropertyName = "nroDam";
            this.dataGridViewTextBoxColumn47.HeaderText = "nroDam";
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.DataPropertyName = "idVendedor";
            this.dataGridViewTextBoxColumn48.HeaderText = "idVendedor";
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.DataPropertyName = "idEstablecimiento";
            this.dataGridViewTextBoxColumn49.HeaderText = "idEstablecimiento";
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.DataPropertyName = "idZona";
            this.dataGridViewTextBoxColumn50.HeaderText = "idZona";
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.DataPropertyName = "idPedido";
            this.dataGridViewTextBoxColumn51.HeaderText = "idPedido";
            this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            // 
            // dataGridViewTextBoxColumn52
            // 
            this.dataGridViewTextBoxColumn52.DataPropertyName = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn52.HeaderText = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.DataPropertyName = "fechaRegistro";
            this.dataGridViewTextBoxColumn53.HeaderText = "fechaRegistro";
            this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            // 
            // dataGridViewTextBoxColumn54
            // 
            this.dataGridViewTextBoxColumn54.DataPropertyName = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn54.HeaderText = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn54.Name = "dataGridViewTextBoxColumn54";
            // 
            // dataGridViewTextBoxColumn55
            // 
            this.dataGridViewTextBoxColumn55.DataPropertyName = "fechaModificacion";
            this.dataGridViewTextBoxColumn55.HeaderText = "fechaModificacion";
            this.dataGridViewTextBoxColumn55.Name = "dataGridViewTextBoxColumn55";
            // 
            // dataGridViewTextBoxColumn56
            // 
            this.dataGridViewTextBoxColumn56.DataPropertyName = "RazonSocial";
            this.dataGridViewTextBoxColumn56.HeaderText = "RazonSocial";
            this.dataGridViewTextBoxColumn56.Name = "dataGridViewTextBoxColumn56";
            // 
            // dataGridViewTextBoxColumn57
            // 
            this.dataGridViewTextBoxColumn57.DataPropertyName = "desOrigen";
            this.dataGridViewTextBoxColumn57.HeaderText = "desOrigen";
            this.dataGridViewTextBoxColumn57.Name = "dataGridViewTextBoxColumn57";
            // 
            // dataGridViewTextBoxColumn58
            // 
            this.dataGridViewTextBoxColumn58.DataPropertyName = "desDestino";
            this.dataGridViewTextBoxColumn58.HeaderText = "desDestino";
            this.dataGridViewTextBoxColumn58.Name = "dataGridViewTextBoxColumn58";
            // 
            // dataGridViewTextBoxColumn59
            // 
            this.dataGridViewTextBoxColumn59.DataPropertyName = "desFlete";
            this.dataGridViewTextBoxColumn59.HeaderText = "desFlete";
            this.dataGridViewTextBoxColumn59.Name = "dataGridViewTextBoxColumn59";
            // 
            // dataGridViewTextBoxColumn60
            // 
            this.dataGridViewTextBoxColumn60.DataPropertyName = "desBlEmision";
            this.dataGridViewTextBoxColumn60.HeaderText = "desBlEmision";
            this.dataGridViewTextBoxColumn60.Name = "dataGridViewTextBoxColumn60";
            // 
            // dataGridViewTextBoxColumn61
            // 
            this.dataGridViewTextBoxColumn61.DataPropertyName = "desTipoCompra";
            this.dataGridViewTextBoxColumn61.HeaderText = "desTipoCompra";
            this.dataGridViewTextBoxColumn61.Name = "dataGridViewTextBoxColumn61";
            // 
            // dataGridViewTextBoxColumn62
            // 
            this.dataGridViewTextBoxColumn62.DataPropertyName = "desIncoterms";
            this.dataGridViewTextBoxColumn62.HeaderText = "desIncoterms";
            this.dataGridViewTextBoxColumn62.Name = "dataGridViewTextBoxColumn62";
            // 
            // dataGridViewTextBoxColumn63
            // 
            this.dataGridViewTextBoxColumn63.DataPropertyName = "desMoneda";
            this.dataGridViewTextBoxColumn63.HeaderText = "desMoneda";
            this.dataGridViewTextBoxColumn63.Name = "dataGridViewTextBoxColumn63";
            // 
            // dataGridViewTextBoxColumn64
            // 
            this.dataGridViewTextBoxColumn64.DataPropertyName = "desConsignatario";
            this.dataGridViewTextBoxColumn64.HeaderText = "desConsignatario";
            this.dataGridViewTextBoxColumn64.Name = "dataGridViewTextBoxColumn64";
            // 
            // dataGridViewTextBoxColumn65
            // 
            this.dataGridViewTextBoxColumn65.DataPropertyName = "desNotificador";
            this.dataGridViewTextBoxColumn65.HeaderText = "desNotificador";
            this.dataGridViewTextBoxColumn65.Name = "dataGridViewTextBoxColumn65";
            // 
            // dataGridViewTextBoxColumn66
            // 
            this.dataGridViewTextBoxColumn66.DataPropertyName = "desFitosanitario";
            this.dataGridViewTextBoxColumn66.HeaderText = "desFitosanitario";
            this.dataGridViewTextBoxColumn66.Name = "dataGridViewTextBoxColumn66";
            // 
            // dataGridViewTextBoxColumn67
            // 
            this.dataGridViewTextBoxColumn67.DataPropertyName = "desFacturar";
            this.dataGridViewTextBoxColumn67.HeaderText = "desFacturar";
            this.dataGridViewTextBoxColumn67.Name = "dataGridViewTextBoxColumn67";
            // 
            // dataGridViewTextBoxColumn68
            // 
            this.dataGridViewTextBoxColumn68.DataPropertyName = "desBroker";
            this.dataGridViewTextBoxColumn68.HeaderText = "desBroker";
            this.dataGridViewTextBoxColumn68.Name = "dataGridViewTextBoxColumn68";
            // 
            // dataGridViewTextBoxColumn69
            // 
            this.dataGridViewTextBoxColumn69.DataPropertyName = "DireccionCompleta";
            this.dataGridViewTextBoxColumn69.HeaderText = "DireccionCompleta";
            this.dataGridViewTextBoxColumn69.Name = "dataGridViewTextBoxColumn69";
            // 
            // dataGridViewTextBoxColumn70
            // 
            this.dataGridViewTextBoxColumn70.DataPropertyName = "desOperadorLog";
            this.dataGridViewTextBoxColumn70.HeaderText = "desOperadorLog";
            this.dataGridViewTextBoxColumn70.Name = "dataGridViewTextBoxColumn70";
            // 
            // dataGridViewTextBoxColumn71
            // 
            this.dataGridViewTextBoxColumn71.DataPropertyName = "dirConsignatario";
            this.dataGridViewTextBoxColumn71.HeaderText = "dirConsignatario";
            this.dataGridViewTextBoxColumn71.Name = "dataGridViewTextBoxColumn71";
            // 
            // dataGridViewTextBoxColumn72
            // 
            this.dataGridViewTextBoxColumn72.DataPropertyName = "telConsignatario";
            this.dataGridViewTextBoxColumn72.HeaderText = "telConsignatario";
            this.dataGridViewTextBoxColumn72.Name = "dataGridViewTextBoxColumn72";
            // 
            // dataGridViewTextBoxColumn73
            // 
            this.dataGridViewTextBoxColumn73.DataPropertyName = "FaxConsignatario";
            this.dataGridViewTextBoxColumn73.HeaderText = "FaxConsignatario";
            this.dataGridViewTextBoxColumn73.Name = "dataGridViewTextBoxColumn73";
            // 
            // dataGridViewTextBoxColumn74
            // 
            this.dataGridViewTextBoxColumn74.DataPropertyName = "EmailConsignatario";
            this.dataGridViewTextBoxColumn74.HeaderText = "EmailConsignatario";
            this.dataGridViewTextBoxColumn74.Name = "dataGridViewTextBoxColumn74";
            // 
            // dataGridViewTextBoxColumn75
            // 
            this.dataGridViewTextBoxColumn75.DataPropertyName = "dirFitosanitario";
            this.dataGridViewTextBoxColumn75.HeaderText = "dirFitosanitario";
            this.dataGridViewTextBoxColumn75.Name = "dataGridViewTextBoxColumn75";
            // 
            // dataGridViewTextBoxColumn76
            // 
            this.dataGridViewTextBoxColumn76.DataPropertyName = "telFitosanitario";
            this.dataGridViewTextBoxColumn76.HeaderText = "telFitosanitario";
            this.dataGridViewTextBoxColumn76.Name = "dataGridViewTextBoxColumn76";
            // 
            // dataGridViewTextBoxColumn77
            // 
            this.dataGridViewTextBoxColumn77.DataPropertyName = "FaxFitosanitario";
            this.dataGridViewTextBoxColumn77.HeaderText = "FaxFitosanitario";
            this.dataGridViewTextBoxColumn77.Name = "dataGridViewTextBoxColumn77";
            // 
            // dataGridViewTextBoxColumn78
            // 
            this.dataGridViewTextBoxColumn78.DataPropertyName = "EmailFitosanitario";
            this.dataGridViewTextBoxColumn78.HeaderText = "EmailFitosanitario";
            this.dataGridViewTextBoxColumn78.Name = "dataGridViewTextBoxColumn78";
            // 
            // dataGridViewTextBoxColumn79
            // 
            this.dataGridViewTextBoxColumn79.DataPropertyName = "dirNotificador";
            this.dataGridViewTextBoxColumn79.HeaderText = "dirNotificador";
            this.dataGridViewTextBoxColumn79.Name = "dataGridViewTextBoxColumn79";
            // 
            // dataGridViewTextBoxColumn80
            // 
            this.dataGridViewTextBoxColumn80.DataPropertyName = "telNotificador";
            this.dataGridViewTextBoxColumn80.HeaderText = "telNotificador";
            this.dataGridViewTextBoxColumn80.Name = "dataGridViewTextBoxColumn80";
            // 
            // dataGridViewTextBoxColumn81
            // 
            this.dataGridViewTextBoxColumn81.DataPropertyName = "FaxNotificador";
            this.dataGridViewTextBoxColumn81.HeaderText = "FaxNotificador";
            this.dataGridViewTextBoxColumn81.Name = "dataGridViewTextBoxColumn81";
            // 
            // dataGridViewTextBoxColumn82
            // 
            this.dataGridViewTextBoxColumn82.DataPropertyName = "EmailNotificador";
            this.dataGridViewTextBoxColumn82.HeaderText = "EmailNotificador";
            this.dataGridViewTextBoxColumn82.Name = "dataGridViewTextBoxColumn82";
            // 
            // dataGridViewTextBoxColumn83
            // 
            this.dataGridViewTextBoxColumn83.DataPropertyName = "desNaviera";
            this.dataGridViewTextBoxColumn83.HeaderText = "desNaviera";
            this.dataGridViewTextBoxColumn83.Name = "dataGridViewTextBoxColumn83";
            // 
            // dataGridViewTextBoxColumn84
            // 
            this.dataGridViewTextBoxColumn84.DataPropertyName = "sEmail";
            this.dataGridViewTextBoxColumn84.HeaderText = "sEmail";
            this.dataGridViewTextBoxColumn84.Name = "dataGridViewTextBoxColumn84";
            // 
            // dataGridViewTextBoxColumn85
            // 
            this.dataGridViewTextBoxColumn85.DataPropertyName = "EmailOperadorLog";
            this.dataGridViewTextBoxColumn85.HeaderText = "EmailOperadorLog";
            this.dataGridViewTextBoxColumn85.Name = "dataGridViewTextBoxColumn85";
            // 
            // dataGridViewTextBoxColumn86
            // 
            this.dataGridViewTextBoxColumn86.DataPropertyName = "desAlmacenIngreso";
            this.dataGridViewTextBoxColumn86.HeaderText = "desAlmacenIngreso";
            this.dataGridViewTextBoxColumn86.Name = "dataGridViewTextBoxColumn86";
            // 
            // dataGridViewTextBoxColumn87
            // 
            this.dataGridViewTextBoxColumn87.DataPropertyName = "desArticulo";
            this.dataGridViewTextBoxColumn87.HeaderText = "desArticulo";
            this.dataGridViewTextBoxColumn87.Name = "dataGridViewTextBoxColumn87";
            // 
            // dataGridViewTextBoxColumn88
            // 
            this.dataGridViewTextBoxColumn88.DataPropertyName = "desPresentacion";
            this.dataGridViewTextBoxColumn88.HeaderText = "desPresentacion";
            this.dataGridViewTextBoxColumn88.Name = "dataGridViewTextBoxColumn88";
            // 
            // dataGridViewTextBoxColumn89
            // 
            this.dataGridViewTextBoxColumn89.DataPropertyName = "desMarca";
            this.dataGridViewTextBoxColumn89.HeaderText = "desMarca";
            this.dataGridViewTextBoxColumn89.Name = "dataGridViewTextBoxColumn89";
            // 
            // dataGridViewTextBoxColumn90
            // 
            this.dataGridViewTextBoxColumn90.DataPropertyName = "Cantidad";
            this.dataGridViewTextBoxColumn90.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn90.Name = "dataGridViewTextBoxColumn90";
            // 
            // dataGridViewTextBoxColumn91
            // 
            this.dataGridViewTextBoxColumn91.DataPropertyName = "PesoBruto";
            this.dataGridViewTextBoxColumn91.HeaderText = "PesoBruto";
            this.dataGridViewTextBoxColumn91.Name = "dataGridViewTextBoxColumn91";
            // 
            // dataGridViewTextBoxColumn92
            // 
            this.dataGridViewTextBoxColumn92.DataPropertyName = "PesoNeto";
            this.dataGridViewTextBoxColumn92.HeaderText = "PesoNeto";
            this.dataGridViewTextBoxColumn92.Name = "dataGridViewTextBoxColumn92";
            // 
            // dataGridViewTextBoxColumn93
            // 
            this.dataGridViewTextBoxColumn93.DataPropertyName = "Fda";
            this.dataGridViewTextBoxColumn93.HeaderText = "Fda";
            this.dataGridViewTextBoxColumn93.Name = "dataGridViewTextBoxColumn93";
            // 
            // dataGridViewTextBoxColumn94
            // 
            this.dataGridViewTextBoxColumn94.DataPropertyName = "PaisOrigen";
            this.dataGridViewTextBoxColumn94.HeaderText = "PaisOrigen";
            this.dataGridViewTextBoxColumn94.Name = "dataGridViewTextBoxColumn94";
            // 
            // dataGridViewTextBoxColumn95
            // 
            this.dataGridViewTextBoxColumn95.DataPropertyName = "PaisDestino";
            this.dataGridViewTextBoxColumn95.HeaderText = "PaisDestino";
            this.dataGridViewTextBoxColumn95.Name = "dataGridViewTextBoxColumn95";
            // 
            // dataGridViewTextBoxColumn96
            // 
            this.dataGridViewTextBoxColumn96.DataPropertyName = "dirAlmacenIngreso";
            this.dataGridViewTextBoxColumn96.HeaderText = "dirAlmacenIngreso";
            this.dataGridViewTextBoxColumn96.Name = "dataGridViewTextBoxColumn96";
            // 
            // dataGridViewTextBoxColumn97
            // 
            this.dataGridViewTextBoxColumn97.DataPropertyName = "totCajasContBruto";
            this.dataGridViewTextBoxColumn97.HeaderText = "totCajasContBruto";
            this.dataGridViewTextBoxColumn97.Name = "dataGridViewTextBoxColumn97";
            // 
            // dataGridViewTextBoxColumn98
            // 
            this.dataGridViewTextBoxColumn98.DataPropertyName = "totCajasContNeto";
            this.dataGridViewTextBoxColumn98.HeaderText = "totCajasContNeto";
            this.dataGridViewTextBoxColumn98.Name = "dataGridViewTextBoxColumn98";
            // 
            // dataGridViewTextBoxColumn99
            // 
            this.dataGridViewTextBoxColumn99.DataPropertyName = "DescripcionEnBl";
            this.dataGridViewTextBoxColumn99.HeaderText = "DescripcionEnBl";
            this.dataGridViewTextBoxColumn99.Name = "dataGridViewTextBoxColumn99";
            // 
            // dataGridViewTextBoxColumn100
            // 
            this.dataGridViewTextBoxColumn100.DataPropertyName = "ValorFactura";
            this.dataGridViewTextBoxColumn100.HeaderText = "ValorFactura";
            this.dataGridViewTextBoxColumn100.Name = "dataGridViewTextBoxColumn100";
            // 
            // btDesvincular
            // 
            this.btDesvincular.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btDesvincular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btDesvincular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btDesvincular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDesvincular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDesvincular.Image = global::ClienteWinForm.Properties.Resources.Desvincular_16x16;
            this.btDesvincular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDesvincular.Location = new System.Drawing.Point(927, 30);
            this.btDesvincular.Name = "btDesvincular";
            this.btDesvincular.Size = new System.Drawing.Size(196, 56);
            this.btDesvincular.TabIndex = 307;
            this.btDesvincular.TabStop = false;
            this.btDesvincular.Text = "Desvincular Doc. de Ventas";
            this.btDesvincular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDesvincular.UseVisualStyleBackColor = true;
            this.btDesvincular.Click += new System.EventHandler(this.btDesvincular_Click);
            // 
            // frmListadoPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 443);
            this.Controls.Add(this.btDesvincular);
            this.Controls.Add(this.pnlOpciones);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoPedidos";
            this.Text = "Lista de Pedidos";
            this.Load += new System.EventHandler(this.frmPedidos_Load);
            this.pnlOpciones.ResumeLayout(false);
            this.pnlOpciones.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.cmsPedido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsPedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOpciones;
        private ControlesWinForm.SuperTextBox txtPedido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        protected internal System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel1;
        protected internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bsPedidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn54;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn55;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn56;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn57;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn58;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn59;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn60;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn61;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn62;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn63;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn64;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn65;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn66;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn67;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn68;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn69;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn70;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn71;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn72;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn73;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn74;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn75;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn76;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn77;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn78;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn79;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn80;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn81;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn82;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn83;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn84;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn85;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn86;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn87;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn88;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn89;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn90;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn91;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn92;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn93;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn94;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn95;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn96;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn97;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn98;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn99;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn100;
        private System.Windows.Forms.ComboBox cboEstados;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsPedido;
        private System.Windows.Forms.ToolStripMenuItem tsmiCrear;
        private System.Windows.Forms.ToolStripMenuItem tsmiMandar;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopiar;
        private System.Windows.Forms.Button btDesvincular;
        private ControlesWinForm.SuperTextBox txtNombresVendedor;
        private System.Windows.Forms.ToolStripMenuItem tsmiGeneraOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator tssLineamprimirBarras;
        private System.Windows.Forms.ToolStripMenuItem tsmiImprimirBarras;
        private System.Windows.Forms.RadioButton RbCotizacion;
        private System.Windows.Forms.RadioButton RbEntrega;
        private System.Windows.Forms.RadioButton RbPedido;
        private System.Windows.Forms.RadioButton RbFactura;
        private System.Windows.Forms.ToolStripMenuItem tsmiConvertir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FecCotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FecPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn FecFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desFacturarDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendedorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroGuia;
        private System.Windows.Forms.DataGridViewTextBoxColumn totsubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn totTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrdenCompra;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CorreoEnviado;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}