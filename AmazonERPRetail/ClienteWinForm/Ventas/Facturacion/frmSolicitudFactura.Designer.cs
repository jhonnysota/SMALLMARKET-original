namespace ClienteWinForm.Ventas.Facturacion
{
    partial class frmSolicitudFactura
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.pnlBase = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblRuc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRucCliente = new System.Windows.Forms.Label();
            this.chkVentaSujeta = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblOtros = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblfactura = new System.Windows.Forms.Label();
            this.lblPartida = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTransporte = new System.Windows.Forms.Label();
            this.lblRucTransporte = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblFechaTraslado = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkOtros = new System.Windows.Forms.CheckBox();
            this.chkVenta = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.lblLicencia = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblInscripcion = new System.Windows.Forms.Label();
            this.chkCompra = new System.Windows.Forms.CheckBox();
            this.chkImportacion = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblGlosa = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desUMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PesoBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkItinerante = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkExportacion = new System.Windows.Forms.CheckBox();
            this.chkConsignacion = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkTransformacion = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDevolucion = new System.Windows.Forms.CheckBox();
            this.chkTrasEstablecimientos = new System.Windows.Forms.CheckBox();
            this.lblFecEmision = new System.Windows.Forms.Label();
            this.lblSenior = new System.Windows.Forms.Label();
            this.lblLlegada = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).BeginInit();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // bsDetalle
            // 
            this.bsDetalle.DataSource = typeof(Entidades.Ventas.EmisionDocumentoDetE);
            // 
            // pnlBase
            // 
            this.pnlBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBase.Controls.Add(this.pictureBox1);
            this.pnlBase.Controls.Add(this.label9);
            this.pnlBase.Controls.Add(this.panel1);
            this.pnlBase.Controls.Add(this.label10);
            this.pnlBase.Controls.Add(this.lblRucCliente);
            this.pnlBase.Controls.Add(this.chkVentaSujeta);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.lblOtros);
            this.pnlBase.Controls.Add(this.lblTipo);
            this.pnlBase.Controls.Add(this.label7);
            this.pnlBase.Controls.Add(this.lblfactura);
            this.pnlBase.Controls.Add(this.lblPartida);
            this.pnlBase.Controls.Add(this.Label12);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.panel6);
            this.pnlBase.Controls.Add(this.lblFechaTraslado);
            this.pnlBase.Controls.Add(this.label6);
            this.pnlBase.Controls.Add(this.label11);
            this.pnlBase.Controls.Add(this.chkOtros);
            this.pnlBase.Controls.Add(this.chkVenta);
            this.pnlBase.Controls.Add(this.panel5);
            this.pnlBase.Controls.Add(this.chkCompra);
            this.pnlBase.Controls.Add(this.chkImportacion);
            this.pnlBase.Controls.Add(this.panel3);
            this.pnlBase.Controls.Add(this.chkItinerante);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.chkExportacion);
            this.pnlBase.Controls.Add(this.chkConsignacion);
            this.pnlBase.Controls.Add(this.label16);
            this.pnlBase.Controls.Add(this.chkTransformacion);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.chkDevolucion);
            this.pnlBase.Controls.Add(this.chkTrasEstablecimientos);
            this.pnlBase.Controls.Add(this.lblFecEmision);
            this.pnlBase.Controls.Add(this.lblSenior);
            this.pnlBase.Controls.Add(this.lblLlegada);
            this.pnlBase.Location = new System.Drawing.Point(12, 12);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(745, 716);
            this.pnlBase.TabIndex = 391;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(416, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 363;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(29, 627);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 389;
            this.label9.Text = "Comprobante de Pago";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNumero);
            this.panel1.Controls.Add(this.lblSerie);
            this.panel1.Controls.Add(this.lblRuc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(465, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 114);
            this.panel1.TabIndex = 362;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.ForeColor = System.Drawing.Color.Red;
            this.lblNumero.Location = new System.Drawing.Point(107, 79);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(33, 22);
            this.lblNumero.TabIndex = 3;
            this.lblNumero.Text = "N°";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(9, 79);
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
            this.lblRuc.Size = new System.Drawing.Size(261, 23);
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
            this.label1.Location = new System.Drawing.Point(-1, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "SOLICITUD FACTURA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(196, 627);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "MOTIVO DE TRASLADO";
            // 
            // lblRucCliente
            // 
            this.lblRucCliente.AutoSize = true;
            this.lblRucCliente.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRucCliente.Location = new System.Drawing.Point(437, 251);
            this.lblRucCliente.Name = "lblRucCliente";
            this.lblRucCliente.Size = new System.Drawing.Size(0, 12);
            this.lblRucCliente.TabIndex = 366;
            // 
            // chkVentaSujeta
            // 
            this.chkVentaSujeta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVentaSujeta.Enabled = false;
            this.chkVentaSujeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVentaSujeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVentaSujeta.Location = new System.Drawing.Point(493, 674);
            this.chkVentaSujeta.Name = "chkVentaSujeta";
            this.chkVentaSujeta.Size = new System.Drawing.Size(137, 17);
            this.chkVentaSujeta.TabIndex = 388;
            this.chkVentaSujeta.Text = "10. Venta sujeta a confirmar";
            this.chkVentaSujeta.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(376, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 12);
            this.label4.TabIndex = 367;
            this.label4.Text = "RUC/DNI:";
            // 
            // lblOtros
            // 
            this.lblOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtros.Location = new System.Drawing.Point(558, 693);
            this.lblOtros.Name = "lblOtros";
            this.lblOtros.Size = new System.Drawing.Size(177, 13);
            this.lblOtros.TabIndex = 12;
            this.lblOtros.Text = "............................................................................";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(53, 661);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(0, 12);
            this.lblTipo.TabIndex = 376;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(373, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 12);
            this.label7.TabIndex = 369;
            this.label7.Text = "Punto de Llegada:";
            // 
            // lblfactura
            // 
            this.lblfactura.AutoSize = true;
            this.lblfactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfactura.Location = new System.Drawing.Point(53, 684);
            this.lblfactura.Name = "lblfactura";
            this.lblfactura.Size = new System.Drawing.Size(0, 12);
            this.lblfactura.TabIndex = 374;
            // 
            // lblPartida
            // 
            this.lblPartida.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartida.Location = new System.Drawing.Point(12, 170);
            this.lblPartida.Name = "lblPartida";
            this.lblPartida.Size = new System.Drawing.Size(354, 28);
            this.lblPartida.TabIndex = 370;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(13, 684);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(38, 12);
            this.Label12.TabIndex = 375;
            this.Label12.Text = "Número";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 12);
            this.label5.TabIndex = 371;
            this.label5.Text = "Punto de Partida:";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label21);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.lblTransporte);
            this.panel6.Controls.Add(this.lblRucTransporte);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Location = new System.Drawing.Point(375, 276);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(355, 86);
            this.panel6.TabIndex = 364;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.White;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Dock = System.Windows.Forms.DockStyle.Top;
            this.label21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(353, 15);
            this.label21.TabIndex = 2;
            this.label21.Text = "EMPRESA DE TRANSPORTES";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(193, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "Nombre, denominación o razón social:";
            // 
            // lblTransporte
            // 
            this.lblTransporte.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransporte.Location = new System.Drawing.Point(4, 39);
            this.lblTransporte.Name = "lblTransporte";
            this.lblTransporte.Size = new System.Drawing.Size(325, 22);
            this.lblTransporte.TabIndex = 6;
            // 
            // lblRucTransporte
            // 
            this.lblRucTransporte.AutoSize = true;
            this.lblRucTransporte.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRucTransporte.Location = new System.Drawing.Point(68, 67);
            this.lblRucTransporte.Name = "lblRucTransporte";
            this.lblRucTransporte.Size = new System.Drawing.Size(0, 10);
            this.lblRucTransporte.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(2, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 12);
            this.label15.TabIndex = 11;
            this.label15.Text = "N° de RUC:";
            // 
            // lblFechaTraslado
            // 
            this.lblFechaTraslado.AutoSize = true;
            this.lblFechaTraslado.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaTraslado.Location = new System.Drawing.Point(12, 219);
            this.lblFechaTraslado.Name = "lblFechaTraslado";
            this.lblFechaTraslado.Size = new System.Drawing.Size(0, 12);
            this.lblFechaTraslado.TabIndex = 372;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 661);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 12);
            this.label6.TabIndex = 377;
            this.label6.Text = "Tipo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 12);
            this.label11.TabIndex = 373;
            this.label11.Text = "Fecha de Inicio del Traslado:";
            // 
            // chkOtros
            // 
            this.chkOtros.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOtros.Enabled = false;
            this.chkOtros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOtros.Location = new System.Drawing.Point(493, 691);
            this.chkOtros.Name = "chkOtros";
            this.chkOtros.Size = new System.Drawing.Size(60, 17);
            this.chkOtros.TabIndex = 11;
            this.chkOtros.Text = "11. Otros";
            this.chkOtros.UseVisualStyleBackColor = true;
            // 
            // chkVenta
            // 
            this.chkVenta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVenta.Enabled = false;
            this.chkVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVenta.Location = new System.Drawing.Point(195, 640);
            this.chkVenta.Name = "chkVenta";
            this.chkVenta.Size = new System.Drawing.Size(102, 17);
            this.chkVenta.TabIndex = 2;
            this.chkVenta.Text = "1. Venta";
            this.chkVenta.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.label24);
            this.panel5.Controls.Add(this.lblPlaca);
            this.panel5.Controls.Add(this.lblLicencia);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.label22);
            this.panel5.Controls.Add(this.lblInscripcion);
            this.panel5.Location = new System.Drawing.Point(12, 265);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(360, 97);
            this.panel5.TabIndex = 363;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(358, 15);
            this.label19.TabIndex = 2;
            this.label19.Text = "UNIDAD DE TRANSPORTE Y CONDUCTOR(ES)";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(3, 27);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(134, 12);
            this.label24.TabIndex = 15;
            this.label24.Text = "Marca y Número de Placa:";
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.Location = new System.Drawing.Point(141, 29);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(0, 10);
            this.lblPlaca.TabIndex = 14;
            // 
            // lblLicencia
            // 
            this.lblLicencia.AutoSize = true;
            this.lblLicencia.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicencia.Location = new System.Drawing.Point(175, 70);
            this.lblLicencia.Name = "lblLicencia";
            this.lblLicencia.Size = new System.Drawing.Size(0, 10);
            this.lblLicencia.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(3, 48);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(165, 12);
            this.label20.TabIndex = 19;
            this.label20.Text = "N° de Constancia de Inscripción:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(3, 69);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(153, 12);
            this.label22.TabIndex = 17;
            this.label22.Text = "N°(s) de Licencia de Conducir:";
            // 
            // lblInscripcion
            // 
            this.lblInscripcion.AutoSize = true;
            this.lblInscripcion.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInscripcion.Location = new System.Drawing.Point(172, 50);
            this.lblInscripcion.Name = "lblInscripcion";
            this.lblInscripcion.Size = new System.Drawing.Size(0, 10);
            this.lblInscripcion.TabIndex = 18;
            // 
            // chkCompra
            // 
            this.chkCompra.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCompra.Enabled = false;
            this.chkCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompra.Location = new System.Drawing.Point(195, 657);
            this.chkCompra.Name = "chkCompra";
            this.chkCompra.Size = new System.Drawing.Size(102, 17);
            this.chkCompra.TabIndex = 3;
            this.chkCompra.Text = "2. Compra";
            this.chkCompra.UseVisualStyleBackColor = true;
            // 
            // chkImportacion
            // 
            this.chkImportacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkImportacion.Enabled = false;
            this.chkImportacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkImportacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImportacion.Location = new System.Drawing.Point(493, 657);
            this.chkImportacion.Name = "chkImportacion";
            this.chkImportacion.Size = new System.Drawing.Size(137, 17);
            this.chkImportacion.TabIndex = 7;
            this.chkImportacion.Text = "9. Importación";
            this.chkImportacion.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblGlosa);
            this.panel3.Controls.Add(this.dgvDetalle);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(11, 365);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(719, 257);
            this.panel3.TabIndex = 378;
            // 
            // lblGlosa
            // 
            this.lblGlosa.AutoSize = true;
            this.lblGlosa.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlosa.Location = new System.Drawing.Point(101, 168);
            this.lblGlosa.Name = "lblGlosa";
            this.lblGlosa.Size = new System.Drawing.Size(34, 13);
            this.lblGlosa.TabIndex = 11;
            this.lblGlosa.Text = "Glosa";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cantidadDataGridViewTextBoxColumn,
            this.nomArticuloDataGridViewTextBoxColumn,
            this.desUMedida,
            this.PesoBruto});
            this.dgvDetalle.DataSource = this.bsDetalle;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDetalle.Size = new System.Drawing.Size(717, 255);
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDetalle_CellPainting_1);
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "CANT.";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomArticuloDataGridViewTextBoxColumn
            // 
            this.nomArticuloDataGridViewTextBoxColumn.DataPropertyName = "nomArticulo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nomArticuloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.nomArticuloDataGridViewTextBoxColumn.HeaderText = "DESCRIPCION";
            this.nomArticuloDataGridViewTextBoxColumn.Name = "nomArticuloDataGridViewTextBoxColumn";
            this.nomArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desUMedida
            // 
            this.desUMedida.DataPropertyName = "desUMedida";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.desUMedida.DefaultCellStyle = dataGridViewCellStyle9;
            this.desUMedida.HeaderText = "UNIDAD DE MEDIDA";
            this.desUMedida.Name = "desUMedida";
            this.desUMedida.ReadOnly = true;
            // 
            // PesoBruto
            // 
            this.PesoBruto.DataPropertyName = "PesoBrutoCad";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PesoBruto.DefaultCellStyle = dataGridViewCellStyle10;
            this.PesoBruto.HeaderText = "PESO TOTAL";
            this.PesoBruto.Name = "PesoBruto";
            this.PesoBruto.ReadOnly = true;
            // 
            // chkItinerante
            // 
            this.chkItinerante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkItinerante.Enabled = false;
            this.chkItinerante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkItinerante.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItinerante.Location = new System.Drawing.Point(305, 691);
            this.chkItinerante.Name = "chkItinerante";
            this.chkItinerante.Size = new System.Drawing.Size(179, 17);
            this.chkItinerante.TabIndex = 9;
            this.chkItinerante.Text = "7. Trasl. por emisor itinerante de com. pago";
            this.chkItinerante.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 12);
            this.label2.TabIndex = 383;
            this.label2.Text = "Fecha de Emisión:";
            // 
            // chkExportacion
            // 
            this.chkExportacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkExportacion.Enabled = false;
            this.chkExportacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkExportacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExportacion.Location = new System.Drawing.Point(493, 640);
            this.chkExportacion.Name = "chkExportacion";
            this.chkExportacion.Size = new System.Drawing.Size(137, 17);
            this.chkExportacion.TabIndex = 10;
            this.chkExportacion.Text = "8. Exportación";
            this.chkExportacion.UseVisualStyleBackColor = true;
            // 
            // chkConsignacion
            // 
            this.chkConsignacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkConsignacion.Enabled = false;
            this.chkConsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkConsignacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConsignacion.Location = new System.Drawing.Point(195, 691);
            this.chkConsignacion.Name = "chkConsignacion";
            this.chkConsignacion.Size = new System.Drawing.Size(102, 17);
            this.chkConsignacion.TabIndex = 4;
            this.chkConsignacion.Text = "4. Consignación";
            this.chkConsignacion.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(13, 249);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 12);
            this.label16.TabIndex = 387;
            this.label16.Text = "Costo Mínimo:";
            // 
            // chkTransformacion
            // 
            this.chkTransformacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTransformacion.Enabled = false;
            this.chkTransformacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTransformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTransformacion.Location = new System.Drawing.Point(195, 674);
            this.chkTransformacion.Name = "chkTransformacion";
            this.chkTransformacion.Size = new System.Drawing.Size(102, 17);
            this.chkTransformacion.TabIndex = 6;
            this.chkTransformacion.Text = "3. Transformación";
            this.chkTransformacion.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(373, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 12);
            this.label3.TabIndex = 386;
            this.label3.Text = "Nombre, denominación o razón social del DESTINATARIO";
            // 
            // chkDevolucion
            // 
            this.chkDevolucion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDevolucion.Enabled = false;
            this.chkDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDevolucion.Location = new System.Drawing.Point(305, 640);
            this.chkDevolucion.Name = "chkDevolucion";
            this.chkDevolucion.Size = new System.Drawing.Size(178, 17);
            this.chkDevolucion.TabIndex = 5;
            this.chkDevolucion.Text = "5. Devolución";
            this.chkDevolucion.UseVisualStyleBackColor = true;
            // 
            // chkTrasEstablecimientos
            // 
            this.chkTrasEstablecimientos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTrasEstablecimientos.Enabled = false;
            this.chkTrasEstablecimientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTrasEstablecimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrasEstablecimientos.Location = new System.Drawing.Point(305, 657);
            this.chkTrasEstablecimientos.Name = "chkTrasEstablecimientos";
            this.chkTrasEstablecimientos.Size = new System.Drawing.Size(178, 28);
            this.chkTrasEstablecimientos.TabIndex = 8;
            this.chkTrasEstablecimientos.Text = "6. Traslado entre establecimientos\r\n     de una misma empresa";
            this.chkTrasEstablecimientos.UseVisualStyleBackColor = true;
            // 
            // lblFecEmision
            // 
            this.lblFecEmision.AutoSize = true;
            this.lblFecEmision.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecEmision.Location = new System.Drawing.Point(121, 134);
            this.lblFecEmision.Name = "lblFecEmision";
            this.lblFecEmision.Size = new System.Drawing.Size(0, 13);
            this.lblFecEmision.TabIndex = 384;
            // 
            // lblSenior
            // 
            this.lblSenior.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenior.Location = new System.Drawing.Point(372, 219);
            this.lblSenior.Name = "lblSenior";
            this.lblSenior.Size = new System.Drawing.Size(354, 28);
            this.lblSenior.TabIndex = 385;
            // 
            // lblLlegada
            // 
            this.lblLlegada.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLlegada.Location = new System.Drawing.Point(372, 156);
            this.lblLlegada.Name = "lblLlegada";
            this.lblLlegada.Size = new System.Drawing.Size(354, 42);
            this.lblLlegada.TabIndex = 368;
            // 
            // frmSolicitudFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(765, 737);
            this.Controls.Add(this.pnlBase);
            this.Name = "frmSolicitudFactura";
            this.Text = "Solicitud de Factura";
            this.Load += new System.EventHandler(this.frmSolicitudFactura_Load);
            this.SizeChanged += new System.EventHandler(this.frmSolicitudFactura_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsDetalle;
        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblRuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblRucCliente;
        private System.Windows.Forms.CheckBox chkVentaSujeta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOtros;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblfactura;
        private System.Windows.Forms.Label lblPartida;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTransporte;
        private System.Windows.Forms.Label lblRucTransporte;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblFechaTraslado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkOtros;
        private System.Windows.Forms.CheckBox chkVenta;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.Label lblLicencia;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblInscripcion;
        private System.Windows.Forms.CheckBox chkCompra;
        private System.Windows.Forms.CheckBox chkImportacion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblGlosa;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desUMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoBruto;
        private System.Windows.Forms.CheckBox chkItinerante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkExportacion;
        private System.Windows.Forms.CheckBox chkConsignacion;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkTransformacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkDevolucion;
        private System.Windows.Forms.CheckBox chkTrasEstablecimientos;
        private System.Windows.Forms.Label lblFecEmision;
        private System.Windows.Forms.Label lblSenior;
        private System.Windows.Forms.Label lblLlegada;
    }
}