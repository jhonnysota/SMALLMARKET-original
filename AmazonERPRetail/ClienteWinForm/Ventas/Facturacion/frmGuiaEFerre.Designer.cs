namespace ClienteWinForm.Ventas.Facturacion
{
    partial class frmGuiaEFerre
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
            this.bsDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.pnlBase = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.chkTrasEstablecimientos = new System.Windows.Forms.CheckBox();
            this.chkDevolucion = new System.Windows.Forms.CheckBox();
            this.chkTransformacion = new System.Windows.Forms.CheckBox();
            this.chkConsignacion = new System.Windows.Forms.CheckBox();
            this.chkExportacion = new System.Windows.Forms.CheckBox();
            this.chkItinerante = new System.Windows.Forms.CheckBox();
            this.chkImportacion = new System.Windows.Forms.CheckBox();
            this.chkCompra = new System.Windows.Forms.CheckBox();
            this.chkVenta = new System.Windows.Forms.CheckBox();
            this.chkOtros = new System.Windows.Forms.CheckBox();
            this.lblOtros = new System.Windows.Forms.Label();
            this.chkVentaSujeta = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.lblfactura = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSenior = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRucCliente = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblLlegada = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblPartida = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.lblFechaTraslado = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.lblFecEmision = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblRuc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.lblLicencia = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblInscripcion = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblGlosa = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PesoBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.pnlBase.Controls.Add(this.panel10);
            this.pnlBase.Controls.Add(this.panel6);
            this.pnlBase.Controls.Add(this.panel9);
            this.pnlBase.Controls.Add(this.panel8);
            this.pnlBase.Controls.Add(this.panel7);
            this.pnlBase.Controls.Add(this.panel4);
            this.pnlBase.Controls.Add(this.panel2);
            this.pnlBase.Controls.Add(this.label14);
            this.pnlBase.Controls.Add(this.label17);
            this.pnlBase.Controls.Add(this.label13);
            this.pnlBase.Controls.Add(this.pictureBox1);
            this.pnlBase.Controls.Add(this.panel1);
            this.pnlBase.Controls.Add(this.panel5);
            this.pnlBase.Controls.Add(this.panel3);
            this.pnlBase.Location = new System.Drawing.Point(7, 7);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(745, 716);
            this.pnlBase.TabIndex = 391;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.label10);
            this.panel10.Controls.Add(this.chkTrasEstablecimientos);
            this.panel10.Controls.Add(this.chkDevolucion);
            this.panel10.Controls.Add(this.chkTransformacion);
            this.panel10.Controls.Add(this.chkConsignacion);
            this.panel10.Controls.Add(this.chkExportacion);
            this.panel10.Controls.Add(this.chkItinerante);
            this.panel10.Controls.Add(this.chkImportacion);
            this.panel10.Controls.Add(this.chkCompra);
            this.panel10.Controls.Add(this.chkVenta);
            this.panel10.Controls.Add(this.chkOtros);
            this.panel10.Controls.Add(this.lblOtros);
            this.panel10.Controls.Add(this.chkVentaSujeta);
            this.panel10.Location = new System.Drawing.Point(186, 618);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(544, 92);
            this.panel10.TabIndex = 394;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(145)))), ((int)(((byte)(60)))));
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(542, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "MOTIVO DE TRASLADO";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkTrasEstablecimientos
            // 
            this.chkTrasEstablecimientos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTrasEstablecimientos.Enabled = false;
            this.chkTrasEstablecimientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTrasEstablecimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrasEstablecimientos.Location = new System.Drawing.Point(112, 37);
            this.chkTrasEstablecimientos.Name = "chkTrasEstablecimientos";
            this.chkTrasEstablecimientos.Size = new System.Drawing.Size(178, 28);
            this.chkTrasEstablecimientos.TabIndex = 8;
            this.chkTrasEstablecimientos.Text = "6. Traslado entre establecimientos\r\n     de una misma empresa";
            this.chkTrasEstablecimientos.UseVisualStyleBackColor = true;
            // 
            // chkDevolucion
            // 
            this.chkDevolucion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDevolucion.Enabled = false;
            this.chkDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDevolucion.Location = new System.Drawing.Point(112, 20);
            this.chkDevolucion.Name = "chkDevolucion";
            this.chkDevolucion.Size = new System.Drawing.Size(178, 17);
            this.chkDevolucion.TabIndex = 5;
            this.chkDevolucion.Text = "5. Devolución";
            this.chkDevolucion.UseVisualStyleBackColor = true;
            // 
            // chkTransformacion
            // 
            this.chkTransformacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTransformacion.Enabled = false;
            this.chkTransformacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTransformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTransformacion.Location = new System.Drawing.Point(2, 54);
            this.chkTransformacion.Name = "chkTransformacion";
            this.chkTransformacion.Size = new System.Drawing.Size(102, 17);
            this.chkTransformacion.TabIndex = 6;
            this.chkTransformacion.Text = "3. Transformación";
            this.chkTransformacion.UseVisualStyleBackColor = true;
            // 
            // chkConsignacion
            // 
            this.chkConsignacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkConsignacion.Enabled = false;
            this.chkConsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkConsignacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConsignacion.Location = new System.Drawing.Point(2, 71);
            this.chkConsignacion.Name = "chkConsignacion";
            this.chkConsignacion.Size = new System.Drawing.Size(102, 17);
            this.chkConsignacion.TabIndex = 4;
            this.chkConsignacion.Text = "4. Consignación";
            this.chkConsignacion.UseVisualStyleBackColor = true;
            // 
            // chkExportacion
            // 
            this.chkExportacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkExportacion.Enabled = false;
            this.chkExportacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkExportacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExportacion.Location = new System.Drawing.Point(300, 20);
            this.chkExportacion.Name = "chkExportacion";
            this.chkExportacion.Size = new System.Drawing.Size(137, 17);
            this.chkExportacion.TabIndex = 10;
            this.chkExportacion.Text = "8. Exportación";
            this.chkExportacion.UseVisualStyleBackColor = true;
            // 
            // chkItinerante
            // 
            this.chkItinerante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkItinerante.Enabled = false;
            this.chkItinerante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkItinerante.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItinerante.Location = new System.Drawing.Point(112, 71);
            this.chkItinerante.Name = "chkItinerante";
            this.chkItinerante.Size = new System.Drawing.Size(179, 17);
            this.chkItinerante.TabIndex = 9;
            this.chkItinerante.Text = "7. Trasl. por emisor itinerante de com. pago";
            this.chkItinerante.UseVisualStyleBackColor = true;
            // 
            // chkImportacion
            // 
            this.chkImportacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkImportacion.Enabled = false;
            this.chkImportacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkImportacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImportacion.Location = new System.Drawing.Point(300, 37);
            this.chkImportacion.Name = "chkImportacion";
            this.chkImportacion.Size = new System.Drawing.Size(137, 17);
            this.chkImportacion.TabIndex = 7;
            this.chkImportacion.Text = "9. Importación";
            this.chkImportacion.UseVisualStyleBackColor = true;
            // 
            // chkCompra
            // 
            this.chkCompra.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCompra.Enabled = false;
            this.chkCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompra.Location = new System.Drawing.Point(2, 37);
            this.chkCompra.Name = "chkCompra";
            this.chkCompra.Size = new System.Drawing.Size(102, 17);
            this.chkCompra.TabIndex = 3;
            this.chkCompra.Text = "2. Compra";
            this.chkCompra.UseVisualStyleBackColor = true;
            // 
            // chkVenta
            // 
            this.chkVenta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVenta.Enabled = false;
            this.chkVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVenta.Location = new System.Drawing.Point(2, 20);
            this.chkVenta.Name = "chkVenta";
            this.chkVenta.Size = new System.Drawing.Size(102, 17);
            this.chkVenta.TabIndex = 2;
            this.chkVenta.Text = "1. Venta";
            this.chkVenta.UseVisualStyleBackColor = true;
            // 
            // chkOtros
            // 
            this.chkOtros.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOtros.Enabled = false;
            this.chkOtros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOtros.Location = new System.Drawing.Point(300, 71);
            this.chkOtros.Name = "chkOtros";
            this.chkOtros.Size = new System.Drawing.Size(60, 17);
            this.chkOtros.TabIndex = 11;
            this.chkOtros.Text = "11. Otros";
            this.chkOtros.UseVisualStyleBackColor = true;
            // 
            // lblOtros
            // 
            this.lblOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtros.Location = new System.Drawing.Point(365, 73);
            this.lblOtros.Name = "lblOtros";
            this.lblOtros.Size = new System.Drawing.Size(177, 13);
            this.lblOtros.TabIndex = 12;
            this.lblOtros.Text = "............................................................................";
            // 
            // chkVentaSujeta
            // 
            this.chkVentaSujeta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVentaSujeta.Enabled = false;
            this.chkVentaSujeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVentaSujeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVentaSujeta.Location = new System.Drawing.Point(300, 54);
            this.chkVentaSujeta.Name = "chkVentaSujeta";
            this.chkVentaSujeta.Size = new System.Drawing.Size(137, 17);
            this.chkVentaSujeta.TabIndex = 388;
            this.chkVentaSujeta.Text = "10. Venta sujeta a confirmar";
            this.chkVentaSujeta.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.lblTipo);
            this.panel6.Controls.Add(this.Label12);
            this.panel6.Controls.Add(this.lblfactura);
            this.panel6.Location = new System.Drawing.Point(11, 618);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(169, 54);
            this.panel6.TabIndex = 393;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 13);
            this.label9.TabIndex = 389;
            this.label9.Text = "COMPROBANTE DE PAGO";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 12);
            this.label6.TabIndex = 377;
            this.label6.Text = "Tipo:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(40, 18);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(0, 12);
            this.lblTipo.TabIndex = 376;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(9, 36);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(19, 12);
            this.Label12.TabIndex = 375;
            this.Label12.Text = "N°:";
            // 
            // lblfactura
            // 
            this.lblfactura.AutoSize = true;
            this.lblfactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfactura.Location = new System.Drawing.Point(40, 36);
            this.lblfactura.Name = "lblfactura";
            this.lblfactura.Size = new System.Drawing.Size(0, 12);
            this.lblfactura.TabIndex = 374;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Controls.Add(this.lblSenior);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Controls.Add(this.lblRucCliente);
            this.panel9.Location = new System.Drawing.Point(11, 227);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(358, 59);
            this.panel9.TabIndex = 386;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(186, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 10);
            this.label2.TabIndex = 387;
            this.label2.Text = "Doc. Ident.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 386;
            this.label3.Text = "DESTINATARIO:";
            // 
            // lblSenior
            // 
            this.lblSenior.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenior.Location = new System.Drawing.Point(1, 15);
            this.lblSenior.Name = "lblSenior";
            this.lblSenior.Size = new System.Drawing.Size(354, 23);
            this.lblSenior.TabIndex = 385;
            this.lblSenior.Text = "Nombre o Razón Social:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 10);
            this.label4.TabIndex = 367;
            this.label4.Text = "R.U.C.:";
            // 
            // lblRucCliente
            // 
            this.lblRucCliente.AutoSize = true;
            this.lblRucCliente.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRucCliente.Location = new System.Drawing.Point(48, 42);
            this.lblRucCliente.Name = "lblRucCliente";
            this.lblRucCliente.Size = new System.Drawing.Size(0, 10);
            this.lblRucCliente.TabIndex = 366;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.lblLlegada);
            this.panel8.Location = new System.Drawing.Point(372, 196);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(358, 28);
            this.panel8.TabIndex = 386;
            // 
            // lblLlegada
            // 
            this.lblLlegada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLlegada.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLlegada.Location = new System.Drawing.Point(0, 0);
            this.lblLlegada.Name = "lblLlegada";
            this.lblLlegada.Size = new System.Drawing.Size(356, 26);
            this.lblLlegada.TabIndex = 368;
            this.lblLlegada.Text = "PUNTO DE LLEGADA:";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblPartida);
            this.panel7.Location = new System.Drawing.Point(11, 196);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(358, 28);
            this.panel7.TabIndex = 385;
            // 
            // lblPartida
            // 
            this.lblPartida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPartida.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartida.Location = new System.Drawing.Point(0, 0);
            this.lblPartida.Name = "lblPartida";
            this.lblPartida.Size = new System.Drawing.Size(356, 26);
            this.lblPartida.TabIndex = 370;
            this.lblPartida.Text = "PUNTO DE PARTIDA:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.lblFechaTraslado);
            this.panel4.Location = new System.Drawing.Point(241, 159);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(192, 31);
            this.panel4.TabIndex = 364;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(145)))), ((int)(((byte)(60)))));
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 29);
            this.label18.TabIndex = 0;
            this.label18.Text = "Fecha de Inicio\r\ndel Traslado";
            // 
            // lblFechaTraslado
            // 
            this.lblFechaTraslado.AutoSize = true;
            this.lblFechaTraslado.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaTraslado.Location = new System.Drawing.Point(107, 9);
            this.lblFechaTraslado.Name = "lblFechaTraslado";
            this.lblFechaTraslado.Size = new System.Drawing.Size(0, 12);
            this.lblFechaTraslado.TabIndex = 372;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.lblFecEmision);
            this.panel2.Location = new System.Drawing.Point(11, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 31);
            this.panel2.TabIndex = 363;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(145)))), ((int)(((byte)(60)))));
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label26.Dock = System.Windows.Forms.DockStyle.Left;
            this.label26.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(0, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 29);
            this.label26.TabIndex = 0;
            this.label26.Text = "Fecha de\r\nEmisión";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFecEmision
            // 
            this.lblFecEmision.AutoSize = true;
            this.lblFecEmision.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecEmision.Location = new System.Drawing.Point(88, 9);
            this.lblFecEmision.Name = "lblFecEmision";
            this.lblFecEmision.Size = new System.Drawing.Size(0, 13);
            this.lblFecEmision.TabIndex = 384;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(350, 42);
            this.label14.TabIndex = 391;
            this.label14.Text = "Pj. Carlos Zavala Loayza Nro. 150 Asoc. 24 de Junio - Lima-Lima-San Martin de Por" +
    "res\r\nTelf.: 571-0871 RPC: 989524035 RPC: 984119094\r\nE-mail: calzadoenzoferre@hot" +
    "mail.com";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(145)))), ((int)(((byte)(60)))));
            this.label17.Location = new System.Drawing.Point(361, 89);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 30);
            this.label17.TabIndex = 392;
            this.label17.Text = "Atendemos Pedidos\r\na Provincias";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(349, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 30);
            this.label13.TabIndex = 390;
            this.label13.Text = "Modelos Exclusivos de\r\nvestir, sport y casual.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(329, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 363;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNumero);
            this.panel1.Controls.Add(this.lblSerie);
            this.panel1.Controls.Add(this.lblRuc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(467, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 122);
            this.panel1.TabIndex = 362;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.ForeColor = System.Drawing.Color.Red;
            this.lblNumero.Location = new System.Drawing.Point(103, 83);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(33, 22);
            this.lblNumero.TabIndex = 3;
            this.lblNumero.Text = "N°";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(20, 83);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(72, 22);
            this.lblSerie.TabIndex = 2;
            this.lblSerie.Text = "0000 - ";
            // 
            // lblRuc
            // 
            this.lblRuc.BackColor = System.Drawing.Color.White;
            this.lblRuc.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuc.Location = new System.Drawing.Point(0, 7);
            this.lblRuc.Name = "lblRuc";
            this.lblRuc.Size = new System.Drawing.Size(261, 23);
            this.lblRuc.TabIndex = 1;
            this.lblRuc.Text = "R.U.C.";
            this.lblRuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(145)))), ((int)(((byte)(60)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "GUIA DE REMISION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panel5.Location = new System.Drawing.Point(372, 227);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(358, 59);
            this.panel5.TabIndex = 363;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(356, 15);
            this.label19.TabIndex = 2;
            this.label19.Text = "UNIDAD DE TRANSPORTE Y CONDUCTOR";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(3, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(104, 10);
            this.label24.TabIndex = 15;
            this.label24.Text = "Vehículo, marca y placa N°:";
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.Location = new System.Drawing.Point(120, 18);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(0, 10);
            this.lblPlaca.TabIndex = 14;
            // 
            // lblLicencia
            // 
            this.lblLicencia.AutoSize = true;
            this.lblLicencia.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicencia.Location = new System.Drawing.Point(120, 46);
            this.lblLicencia.Name = "lblLicencia";
            this.lblLicencia.Size = new System.Drawing.Size(0, 10);
            this.lblLicencia.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(3, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(110, 10);
            this.label20.TabIndex = 19;
            this.label20.Text = "Certificado de Inscripción N°:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(3, 46);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(92, 10);
            this.label22.TabIndex = 17;
            this.label22.Text = "Licencia de Conducir N°:";
            // 
            // lblInscripcion
            // 
            this.lblInscripcion.AutoSize = true;
            this.lblInscripcion.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInscripcion.Location = new System.Drawing.Point(120, 33);
            this.lblInscripcion.Name = "lblInscripcion";
            this.lblInscripcion.Size = new System.Drawing.Size(0, 10);
            this.lblInscripcion.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblGlosa);
            this.panel3.Controls.Add(this.dgvDetalle);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(11, 289);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(719, 327);
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
            this.lblGlosa.Visible = false;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(145)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cantidadDataGridViewTextBoxColumn,
            this.nomArticuloDataGridViewTextBoxColumn,
            this.Lote,
            this.PesoBruto,
            this.Total});
            this.dgvDetalle.DataSource = this.bsDetalle;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDetalle.Size = new System.Drawing.Size(717, 325);
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
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "CANT.";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomArticuloDataGridViewTextBoxColumn
            // 
            this.nomArticuloDataGridViewTextBoxColumn.DataPropertyName = "nomArticulo";
            this.nomArticuloDataGridViewTextBoxColumn.HeaderText = "DESCRIPCION";
            this.nomArticuloDataGridViewTextBoxColumn.Name = "nomArticuloDataGridViewTextBoxColumn";
            this.nomArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Lote
            // 
            this.Lote.DataPropertyName = "Lote";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Lote.DefaultCellStyle = dataGridViewCellStyle3;
            this.Lote.HeaderText = "Talla";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            // 
            // PesoBruto
            // 
            this.PesoBruto.DataPropertyName = "PesoBrutoCad";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PesoBruto.DefaultCellStyle = dataGridViewCellStyle4;
            this.PesoBruto.HeaderText = "Peso Total";
            this.PesoBruto.Name = "PesoBruto";
            this.PesoBruto.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "TotalCad";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Total.DefaultCellStyle = dataGridViewCellStyle5;
            this.Total.HeaderText = "Costo Mínimo del Traslado";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // frmGuiaEFerre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(759, 730);
            this.Controls.Add(this.pnlBase);
            this.MaximizeBox = false;
            this.Name = "frmGuiaEFerre";
            this.Text = "Vista Previa";
            this.Load += new System.EventHandler(this.frmGuiaEFerre_Load);
            this.SizeChanged += new System.EventHandler(this.frmGuiaGenesis_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkVentaSujeta;
        private System.Windows.Forms.Label lblOtros;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblRuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRucCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblfactura;
        private System.Windows.Forms.Label lblPartida;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.Label lblFechaTraslado;
        private System.Windows.Forms.Label label6;
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
        private System.Windows.Forms.BindingSource bsDetalle;
        private System.Windows.Forms.CheckBox chkItinerante;
        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.CheckBox chkExportacion;
        private System.Windows.Forms.CheckBox chkConsignacion;
        private System.Windows.Forms.CheckBox chkTransformacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkDevolucion;
        private System.Windows.Forms.CheckBox chkTrasEstablecimientos;
        private System.Windows.Forms.Label lblFecEmision;
        private System.Windows.Forms.Label lblSenior;
        private System.Windows.Forms.Label lblLlegada;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}