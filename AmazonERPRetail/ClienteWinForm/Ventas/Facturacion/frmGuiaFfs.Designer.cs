namespace ClienteWinForm.Ventas.Facturacion
{
    partial class frmGuiaFfs
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
            this.bsDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.lblOc = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkPrimaria = new System.Windows.Forms.CheckBox();
            this.chkItinerante = new System.Windows.Forms.CheckBox();
            this.chkMaterial = new System.Windows.Forms.CheckBox();
            this.chkBienes = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkVenta = new System.Windows.Forms.CheckBox();
            this.chkCompra = new System.Windows.Forms.CheckBox();
            this.chkConsignacion = new System.Windows.Forms.CheckBox();
            this.chkVentaSujeta = new System.Windows.Forms.CheckBox();
            this.chkTransformacion = new System.Windows.Forms.CheckBox();
            this.chkDevolucion = new System.Windows.Forms.CheckBox();
            this.chkTerceros = new System.Windows.Forms.CheckBox();
            this.chkTrasEstablecimientos = new System.Windows.Forms.CheckBox();
            this.chkExportacion = new System.Windows.Forms.CheckBox();
            this.chkImportacion = new System.Windows.Forms.CheckBox();
            this.chkOtros = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFechaTraslado = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTransporte = new System.Windows.Forms.Label();
            this.lblRucTransporte = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.lblLicencia = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSenior = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblGlosa = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioSinImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPartida = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLlegada = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRucCliente = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblRuc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBase = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsDetalle
            // 
            this.bsDetalle.DataSource = typeof(Entidades.Ventas.EmisionDocumentoDetE);
            // 
            // lblOc
            // 
            this.lblOc.AutoSize = true;
            this.lblOc.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOc.Location = new System.Drawing.Point(342, 268);
            this.lblOc.Name = "lblOc";
            this.lblOc.Size = new System.Drawing.Size(0, 12);
            this.lblOc.TabIndex = 428;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(313, 268);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 429;
            this.label12.Text = "O/C:";
            // 
            // lblPago
            // 
            this.lblPago.AutoSize = true;
            this.lblPago.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPago.Location = new System.Drawing.Point(269, 268);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(0, 12);
            this.lblPago.TabIndex = 426;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(199, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 12);
            this.label9.TabIndex = 427;
            this.label9.Text = "Cond. de Pago:";
            // 
            // lblCondicion
            // 
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondicion.Location = new System.Drawing.Point(93, 268);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(0, 12);
            this.lblCondicion.TabIndex = 424;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.chkPrimaria);
            this.panel4.Controls.Add(this.chkItinerante);
            this.panel4.Controls.Add(this.chkMaterial);
            this.panel4.Controls.Add(this.chkBienes);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.chkVenta);
            this.panel4.Controls.Add(this.chkCompra);
            this.panel4.Controls.Add(this.chkConsignacion);
            this.panel4.Controls.Add(this.chkVentaSujeta);
            this.panel4.Controls.Add(this.chkTransformacion);
            this.panel4.Controls.Add(this.chkDevolucion);
            this.panel4.Controls.Add(this.chkTerceros);
            this.panel4.Controls.Add(this.chkTrasEstablecimientos);
            this.panel4.Controls.Add(this.chkExportacion);
            this.panel4.Controls.Add(this.chkImportacion);
            this.panel4.Controls.Add(this.chkOtros);
            this.panel4.Location = new System.Drawing.Point(11, 285);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(709, 69);
            this.panel4.TabIndex = 404;
            // 
            // chkPrimaria
            // 
            this.chkPrimaria.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPrimaria.Enabled = false;
            this.chkPrimaria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPrimaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrimaria.Location = new System.Drawing.Point(522, -2);
            this.chkPrimaria.Name = "chkPrimaria";
            this.chkPrimaria.Size = new System.Drawing.Size(160, 17);
            this.chkPrimaria.TabIndex = 428;
            this.chkPrimaria.Text = "Traslado zona primaria";
            this.chkPrimaria.UseVisualStyleBackColor = true;
            // 
            // chkItinerante
            // 
            this.chkItinerante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkItinerante.Enabled = false;
            this.chkItinerante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkItinerante.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItinerante.Location = new System.Drawing.Point(522, 14);
            this.chkItinerante.Name = "chkItinerante";
            this.chkItinerante.Size = new System.Drawing.Size(160, 17);
            this.chkItinerante.TabIndex = 427;
            this.chkItinerante.Text = "Traslado por emisor itinerante";
            this.chkItinerante.UseVisualStyleBackColor = true;
            // 
            // chkMaterial
            // 
            this.chkMaterial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMaterial.Enabled = false;
            this.chkMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMaterial.Location = new System.Drawing.Point(358, -2);
            this.chkMaterial.Name = "chkMaterial";
            this.chkMaterial.Size = new System.Drawing.Size(137, 17);
            this.chkMaterial.TabIndex = 426;
            this.chkMaterial.Text = "Entrega de material";
            this.chkMaterial.UseVisualStyleBackColor = true;
            // 
            // chkBienes
            // 
            this.chkBienes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBienes.Enabled = false;
            this.chkBienes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBienes.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBienes.Location = new System.Drawing.Point(358, 14);
            this.chkBienes.Name = "chkBienes";
            this.chkBienes.Size = new System.Drawing.Size(137, 17);
            this.chkBienes.TabIndex = 425;
            this.chkBienes.Text = "Recojo de bienes";
            this.chkBienes.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 13);
            this.label10.TabIndex = 390;
            this.label10.Text = "MOTIVO DEL TRASLADO:";
            // 
            // chkVenta
            // 
            this.chkVenta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVenta.Enabled = false;
            this.chkVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVenta.Location = new System.Drawing.Point(12, 14);
            this.chkVenta.Name = "chkVenta";
            this.chkVenta.Size = new System.Drawing.Size(102, 17);
            this.chkVenta.TabIndex = 391;
            this.chkVenta.Text = "Venta";
            this.chkVenta.UseVisualStyleBackColor = true;
            // 
            // chkCompra
            // 
            this.chkCompra.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCompra.Enabled = false;
            this.chkCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompra.Location = new System.Drawing.Point(12, 30);
            this.chkCompra.Name = "chkCompra";
            this.chkCompra.Size = new System.Drawing.Size(102, 17);
            this.chkCompra.TabIndex = 392;
            this.chkCompra.Text = "Compra";
            this.chkCompra.UseVisualStyleBackColor = true;
            // 
            // chkConsignacion
            // 
            this.chkConsignacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkConsignacion.Enabled = false;
            this.chkConsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkConsignacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConsignacion.Location = new System.Drawing.Point(12, 47);
            this.chkConsignacion.Name = "chkConsignacion";
            this.chkConsignacion.Size = new System.Drawing.Size(102, 17);
            this.chkConsignacion.TabIndex = 393;
            this.chkConsignacion.Text = "Consignación";
            this.chkConsignacion.UseVisualStyleBackColor = true;
            // 
            // chkVentaSujeta
            // 
            this.chkVentaSujeta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVentaSujeta.Enabled = false;
            this.chkVentaSujeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVentaSujeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVentaSujeta.Location = new System.Drawing.Point(140, 14);
            this.chkVentaSujeta.Name = "chkVentaSujeta";
            this.chkVentaSujeta.Size = new System.Drawing.Size(199, 17);
            this.chkVentaSujeta.TabIndex = 424;
            this.chkVentaSujeta.Text = "Venta sujeta a confirmación por el comprador";
            this.chkVentaSujeta.UseVisualStyleBackColor = true;
            // 
            // chkTransformacion
            // 
            this.chkTransformacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTransformacion.Enabled = false;
            this.chkTransformacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTransformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTransformacion.Location = new System.Drawing.Point(522, 30);
            this.chkTransformacion.Name = "chkTransformacion";
            this.chkTransformacion.Size = new System.Drawing.Size(160, 17);
            this.chkTransformacion.TabIndex = 395;
            this.chkTransformacion.Text = "Traslado de bienes para transformación";
            this.chkTransformacion.UseVisualStyleBackColor = true;
            // 
            // chkDevolucion
            // 
            this.chkDevolucion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDevolucion.Enabled = false;
            this.chkDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDevolucion.Location = new System.Drawing.Point(140, 47);
            this.chkDevolucion.Name = "chkDevolucion";
            this.chkDevolucion.Size = new System.Drawing.Size(199, 17);
            this.chkDevolucion.TabIndex = 394;
            this.chkDevolucion.Text = "Devolución";
            this.chkDevolucion.UseVisualStyleBackColor = true;
            // 
            // chkTerceros
            // 
            this.chkTerceros.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTerceros.Enabled = false;
            this.chkTerceros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTerceros.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTerceros.Location = new System.Drawing.Point(140, -2);
            this.chkTerceros.Name = "chkTerceros";
            this.chkTerceros.Size = new System.Drawing.Size(199, 17);
            this.chkTerceros.TabIndex = 398;
            this.chkTerceros.Text = "Venta con entrega a terceros";
            this.chkTerceros.UseVisualStyleBackColor = true;
            // 
            // chkTrasEstablecimientos
            // 
            this.chkTrasEstablecimientos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTrasEstablecimientos.Enabled = false;
            this.chkTrasEstablecimientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTrasEstablecimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrasEstablecimientos.Location = new System.Drawing.Point(140, 30);
            this.chkTrasEstablecimientos.Name = "chkTrasEstablecimientos";
            this.chkTrasEstablecimientos.Size = new System.Drawing.Size(199, 17);
            this.chkTrasEstablecimientos.TabIndex = 397;
            this.chkTrasEstablecimientos.Text = "Traslado entre establecimientos de la misma empresa";
            this.chkTrasEstablecimientos.UseVisualStyleBackColor = true;
            // 
            // chkExportacion
            // 
            this.chkExportacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkExportacion.Enabled = false;
            this.chkExportacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkExportacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExportacion.Location = new System.Drawing.Point(358, 30);
            this.chkExportacion.Name = "chkExportacion";
            this.chkExportacion.Size = new System.Drawing.Size(137, 17);
            this.chkExportacion.TabIndex = 399;
            this.chkExportacion.Text = " Exportación";
            this.chkExportacion.UseVisualStyleBackColor = true;
            // 
            // chkImportacion
            // 
            this.chkImportacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkImportacion.Enabled = false;
            this.chkImportacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkImportacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImportacion.Location = new System.Drawing.Point(358, 47);
            this.chkImportacion.Name = "chkImportacion";
            this.chkImportacion.Size = new System.Drawing.Size(137, 17);
            this.chkImportacion.TabIndex = 396;
            this.chkImportacion.Text = "Importación";
            this.chkImportacion.UseVisualStyleBackColor = true;
            // 
            // chkOtros
            // 
            this.chkOtros.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOtros.Enabled = false;
            this.chkOtros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOtros.Location = new System.Drawing.Point(522, 47);
            this.chkOtros.Name = "chkOtros";
            this.chkOtros.Size = new System.Drawing.Size(160, 17);
            this.chkOtros.TabIndex = 400;
            this.chkOtros.Text = "Otros";
            this.chkOtros.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lblFechaTraslado);
            this.panel2.Location = new System.Drawing.Point(415, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 35);
            this.panel2.TabIndex = 406;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 12);
            this.label11.TabIndex = 413;
            this.label11.Text = "Fecha de Inicio del Traslado:";
            // 
            // lblFechaTraslado
            // 
            this.lblFechaTraslado.AutoSize = true;
            this.lblFechaTraslado.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaTraslado.Location = new System.Drawing.Point(161, 16);
            this.lblFechaTraslado.Name = "lblFechaTraslado";
            this.lblFechaTraslado.Size = new System.Drawing.Size(0, 12);
            this.lblFechaTraslado.TabIndex = 412;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.lblTransporte);
            this.panel6.Controls.Add(this.lblRucTransporte);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Location = new System.Drawing.Point(415, 157);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(305, 65);
            this.panel6.TabIndex = 405;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(303, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "Datos del Transportista: Denominación, Apellidos y Nombres:";
            // 
            // lblTransporte
            // 
            this.lblTransporte.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransporte.Location = new System.Drawing.Point(7, 17);
            this.lblTransporte.Name = "lblTransporte";
            this.lblTransporte.Size = new System.Drawing.Size(291, 22);
            this.lblTransporte.TabIndex = 6;
            // 
            // lblRucTransporte
            // 
            this.lblRucTransporte.AutoSize = true;
            this.lblRucTransporte.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRucTransporte.Location = new System.Drawing.Point(68, 45);
            this.lblRucTransporte.Name = "lblRucTransporte";
            this.lblRucTransporte.Size = new System.Drawing.Size(0, 10);
            this.lblRucTransporte.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 12);
            this.label15.TabIndex = 11;
            this.label15.Text = "R.U.C. N°";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label24);
            this.panel5.Controls.Add(this.lblPlaca);
            this.panel5.Controls.Add(this.lblLicencia);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.label22);
            this.panel5.Location = new System.Drawing.Point(415, 221);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(305, 65);
            this.panel5.TabIndex = 403;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(10, 20);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(78, 12);
            this.label24.TabIndex = 15;
            this.label24.Text = "Marca y Placa:";
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.Location = new System.Drawing.Point(112, 22);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(0, 10);
            this.lblPlaca.TabIndex = 14;
            // 
            // lblLicencia
            // 
            this.lblLicencia.AutoSize = true;
            this.lblLicencia.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicencia.Location = new System.Drawing.Point(146, 39);
            this.lblLicencia.Name = "lblLicencia";
            this.lblLicencia.Size = new System.Drawing.Size(0, 10);
            this.lblLicencia.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(2, -1);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(227, 12);
            this.label20.TabIndex = 19;
            this.label20.Text = "Datos de la Unidad de Transporte y Conductor";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(10, 38);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(123, 12);
            this.label22.TabIndex = 17;
            this.label22.Text = "Licencia de Conducir N°";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(9, 156);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 12);
            this.label16.TabIndex = 423;
            this.label16.Text = "Código:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 422;
            this.label3.Text = "Destinatario:";
            // 
            // lblSenior
            // 
            this.lblSenior.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenior.Location = new System.Drawing.Point(81, 125);
            this.lblSenior.Name = "lblSenior";
            this.lblSenior.Size = new System.Drawing.Size(314, 25);
            this.lblSenior.TabIndex = 421;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblGlosa);
            this.panel3.Controls.Add(this.dgvDetalle);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(11, 353);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(709, 354);
            this.panel3.TabIndex = 418;
            // 
            // lblGlosa
            // 
            this.lblGlosa.AutoSize = true;
            this.lblGlosa.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlosa.Location = new System.Drawing.Point(147, 329);
            this.lblGlosa.Name = "lblGlosa";
            this.lblGlosa.Size = new System.Drawing.Size(34, 13);
            this.lblGlosa.TabIndex = 11;
            this.lblGlosa.Text = "Glosa";
            this.lblGlosa.Visible = false;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cantidadDataGridViewTextBoxColumn,
            this.nomArticuloDataGridViewTextBoxColumn,
            this.PrecioSinImpuesto});
            this.dgvDetalle.DataSource = this.bsDetalle;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDetalle.Size = new System.Drawing.Size(707, 352);
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDetalle_CellPainting);
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "CANTIDAD";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomArticuloDataGridViewTextBoxColumn
            // 
            this.nomArticuloDataGridViewTextBoxColumn.DataPropertyName = "nomArticulo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nomArticuloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.nomArticuloDataGridViewTextBoxColumn.HeaderText = "DESCRIPCION";
            this.nomArticuloDataGridViewTextBoxColumn.Name = "nomArticuloDataGridViewTextBoxColumn";
            this.nomArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PrecioSinImpuesto
            // 
            this.PrecioSinImpuesto.DataPropertyName = "PrecioCad";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.PrecioSinImpuesto.DefaultCellStyle = dataGridViewCellStyle4;
            this.PrecioSinImpuesto.HeaderText = "PRECIO UNITARIO";
            this.PrecioSinImpuesto.Name = "PrecioSinImpuesto";
            this.PrecioSinImpuesto.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 12);
            this.label5.TabIndex = 411;
            this.label5.Text = "Punto de Partida:";
            // 
            // lblPartida
            // 
            this.lblPartida.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartida.Location = new System.Drawing.Point(9, 192);
            this.lblPartida.Name = "lblPartida";
            this.lblPartida.Size = new System.Drawing.Size(398, 25);
            this.lblPartida.TabIndex = 410;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 12);
            this.label7.TabIndex = 409;
            this.label7.Text = "Punto de Llegada:";
            // 
            // lblLlegada
            // 
            this.lblLlegada.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLlegada.Location = new System.Drawing.Point(9, 234);
            this.lblLlegada.Name = "lblLlegada";
            this.lblLlegada.Size = new System.Drawing.Size(398, 25);
            this.lblLlegada.TabIndex = 408;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(234, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 407;
            this.label4.Text = "R.U.C. N°:";
            // 
            // lblRucCliente
            // 
            this.lblRucCliente.AutoSize = true;
            this.lblRucCliente.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRucCliente.Location = new System.Drawing.Point(295, 156);
            this.lblRucCliente.Name = "lblRucCliente";
            this.lblRucCliente.Size = new System.Drawing.Size(0, 12);
            this.lblRucCliente.TabIndex = 406;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNumero);
            this.panel1.Controls.Add(this.lblSerie);
            this.panel1.Controls.Add(this.lblRuc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(415, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 114);
            this.panel1.TabIndex = 402;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.ForeColor = System.Drawing.Color.Red;
            this.lblNumero.Location = new System.Drawing.Point(114, 76);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(33, 22);
            this.lblNumero.TabIndex = 3;
            this.lblNumero.Text = "N°";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(16, 76);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(72, 22);
            this.lblSerie.TabIndex = 2;
            this.lblSerie.Text = "0000 - ";
            // 
            // lblRuc
            // 
            this.lblRuc.BackColor = System.Drawing.Color.White;
            this.lblRuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRuc.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuc.Location = new System.Drawing.Point(0, 0);
            this.lblRuc.Name = "lblRuc";
            this.lblRuc.Size = new System.Drawing.Size(303, 23);
            this.lblRuc.TabIndex = 1;
            this.lblRuc.Text = "R.U.C.";
            this.lblRuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "GUIA DE REMISION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(359, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 404;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 425;
            this.label2.Text = "Cond. de Venta:";
            // 
            // pnlBase
            // 
            this.pnlBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBase.Controls.Add(this.pictureBox1);
            this.pnlBase.Controls.Add(this.lblOc);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.label12);
            this.pnlBase.Controls.Add(this.panel1);
            this.pnlBase.Controls.Add(this.lblPago);
            this.pnlBase.Controls.Add(this.lblRucCliente);
            this.pnlBase.Controls.Add(this.label9);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.lblCondicion);
            this.pnlBase.Controls.Add(this.lblLlegada);
            this.pnlBase.Controls.Add(this.panel4);
            this.pnlBase.Controls.Add(this.label7);
            this.pnlBase.Controls.Add(this.panel2);
            this.pnlBase.Controls.Add(this.lblPartida);
            this.pnlBase.Controls.Add(this.panel6);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.panel5);
            this.pnlBase.Controls.Add(this.panel3);
            this.pnlBase.Controls.Add(this.label16);
            this.pnlBase.Controls.Add(this.lblSenior);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Location = new System.Drawing.Point(5, 5);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(735, 721);
            this.pnlBase.TabIndex = 430;
            // 
            // frmGuiaFfs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 734);
            this.Controls.Add(this.pnlBase);
            this.MaximizeBox = false;
            this.Name = "frmGuiaFfs";
            this.Text = "Vista Previa";
            this.Load += new System.EventHandler(this.frmGuiaFfs_Load);
            this.Resize += new System.EventHandler(this.frmGuiaFfs_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkVentaSujeta;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTransporte;
        private System.Windows.Forms.Label lblRucTransporte;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkOtros;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.Label lblLicencia;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox chkImportacion;
        private System.Windows.Forms.CheckBox chkTerceros;
        private System.Windows.Forms.CheckBox chkExportacion;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkTrasEstablecimientos;
        private System.Windows.Forms.Label lblSenior;
        private System.Windows.Forms.CheckBox chkDevolucion;
        private System.Windows.Forms.CheckBox chkTransformacion;
        private System.Windows.Forms.CheckBox chkConsignacion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblGlosa;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.BindingSource bsDetalle;
        private System.Windows.Forms.CheckBox chkCompra;
        private System.Windows.Forms.CheckBox chkVenta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblFechaTraslado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPartida;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblRuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRucCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkPrimaria;
        private System.Windows.Forms.CheckBox chkItinerante;
        private System.Windows.Forms.CheckBox chkMaterial;
        private System.Windows.Forms.CheckBox chkBienes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.Label lblLlegada;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblOc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioSinImpuesto;
    }
}