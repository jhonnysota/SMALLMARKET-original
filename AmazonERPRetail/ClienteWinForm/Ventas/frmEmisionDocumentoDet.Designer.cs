namespace ClienteWinForm.Ventas
{
    partial class frmEmisionDocumentoDet
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
            this.pnlComprobante = new System.Windows.Forms.Panel();
            this.txtIdArticulo = new ControlesWinForm.SuperTextBox();
            this.chImpuesto = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCodigo = new ControlesWinForm.SuperTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrecVta = new ControlesWinForm.SuperTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIgv = new ControlesWinForm.SuperTextBox();
            this.txtIsc = new ControlesWinForm.SuperTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDsct3 = new ControlesWinForm.SuperTextBox();
            this.txtPorcDsct3 = new ControlesWinForm.SuperTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPorcIgv = new ControlesWinForm.SuperTextBox();
            this.txtPorcIsc = new ControlesWinForm.SuperTextBox();
            this.txtCantidad = new ControlesWinForm.SuperTextBox();
            this.txtValVenta = new ControlesWinForm.SuperTextBox();
            this.txtDsct2 = new ControlesWinForm.SuperTextBox();
            this.txtPorcDsct2 = new ControlesWinForm.SuperTextBox();
            this.txtDsct1 = new ControlesWinForm.SuperTextBox();
            this.txtPorcDsct1 = new ControlesWinForm.SuperTextBox();
            this.txtSubTotal = new ControlesWinForm.SuperTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.txtPrecio = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboTipoArticulo = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.txtTipDetra = new ControlesWinForm.SuperTextBox();
            this.txtTasa = new ControlesWinForm.SuperTextBox();
            this.chkDetra = new System.Windows.Forms.CheckBox();
            this.dgvArticulo = new System.Windows.Forms.DataGridView();
            this.codArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkCalculo = new System.Windows.Forms.CheckBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlComprobante.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Maestros.ArticuloServE);
            this.bsBase.CurrentChanged += new System.EventHandler(this.bsBase_CurrentChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(221, 318);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAceptar.Size = new System.Drawing.Size(120, 25);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(346, 318);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Size = new System.Drawing.Size(120, 25);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(1039, 23);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Visible = false;
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(918, 37);
            this.chkAnulado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(813, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(816, 34);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFiltro.Size = new System.Drawing.Size(96, 20);
            this.txtFiltro.Visible = false;
            // 
            // gbResultados
            // 
            this.gbResultados.Location = new System.Drawing.Point(777, 324);
            this.gbResultados.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbResultados.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbResultados.Size = new System.Drawing.Size(126, 23);
            this.gbResultados.TabIndex = 600;
            // 
            // pnlComprobante
            // 
            this.pnlComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlComprobante.Controls.Add(this.label10);
            this.pnlComprobante.Controls.Add(this.txtIdArticulo);
            this.pnlComprobante.Controls.Add(this.chImpuesto);
            this.pnlComprobante.Controls.Add(this.label17);
            this.pnlComprobante.Controls.Add(this.txtCodigo);
            this.pnlComprobante.Controls.Add(this.label9);
            this.pnlComprobante.Controls.Add(this.txtPrecVta);
            this.pnlComprobante.Controls.Add(this.label8);
            this.pnlComprobante.Controls.Add(this.txtIgv);
            this.pnlComprobante.Controls.Add(this.txtIsc);
            this.pnlComprobante.Controls.Add(this.label7);
            this.pnlComprobante.Controls.Add(this.label6);
            this.pnlComprobante.Controls.Add(this.label4);
            this.pnlComprobante.Controls.Add(this.txtDsct3);
            this.pnlComprobante.Controls.Add(this.txtPorcDsct3);
            this.pnlComprobante.Controls.Add(this.label3);
            this.pnlComprobante.Controls.Add(this.label2);
            this.pnlComprobante.Controls.Add(this.txtPorcIgv);
            this.pnlComprobante.Controls.Add(this.txtPorcIsc);
            this.pnlComprobante.Controls.Add(this.txtCantidad);
            this.pnlComprobante.Controls.Add(this.txtValVenta);
            this.pnlComprobante.Controls.Add(this.txtDsct2);
            this.pnlComprobante.Controls.Add(this.txtPorcDsct2);
            this.pnlComprobante.Controls.Add(this.txtDsct1);
            this.pnlComprobante.Controls.Add(this.txtPorcDsct1);
            this.pnlComprobante.Controls.Add(this.txtSubTotal);
            this.pnlComprobante.Controls.Add(this.label13);
            this.pnlComprobante.Controls.Add(this.txtDescripcion);
            this.pnlComprobante.Controls.Add(this.txtPrecio);
            this.pnlComprobante.Controls.Add(this.label5);
            this.pnlComprobante.Controls.Add(this.label12);
            this.pnlComprobante.Location = new System.Drawing.Point(3, 187);
            this.pnlComprobante.Name = "pnlComprobante";
            this.pnlComprobante.Size = new System.Drawing.Size(666, 125);
            this.pnlComprobante.TabIndex = 10;
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdArticulo.Enabled = false;
            this.txtIdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdArticulo.ForeColor = System.Drawing.Color.Blue;
            this.txtIdArticulo.Location = new System.Drawing.Point(64, 48);
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(63, 20);
            this.txtIdArticulo.TabIndex = 347;
            this.txtIdArticulo.TabStop = false;
            this.txtIdArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdArticulo.TextoVacio = "<Descripcion>";
            // 
            // chImpuesto
            // 
            this.chImpuesto.AutoSize = true;
            this.chImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chImpuesto.Location = new System.Drawing.Point(474, 51);
            this.chImpuesto.Name = "chImpuesto";
            this.chImpuesto.Size = new System.Drawing.Size(53, 17);
            this.chImpuesto.TabIndex = 346;
            this.chImpuesto.TabStop = false;
            this.chImpuesto.Text = "I.G.V.";
            this.chImpuesto.UseVisualStyleBackColor = true;
            this.chImpuesto.CheckedChanged += new System.EventHandler(this.chImpuesto_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(14, 76);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 345;
            this.label17.Text = "Cantidad";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtCodigo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.ForeColor = System.Drawing.Color.Blue;
            this.txtCodigo.Location = new System.Drawing.Point(64, 27);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(116, 20);
            this.txtCodigo.TabIndex = 15;
            this.txtCodigo.TabStop = false;
            this.txtCodigo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodigo.TextoVacio = "<Descripcion>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(532, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 342;
            this.label9.Text = "Precio Vta.";
            // 
            // txtPrecVta
            // 
            this.txtPrecVta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPrecVta.BackColor = System.Drawing.Color.White;
            this.txtPrecVta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPrecVta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecVta.Location = new System.Drawing.Point(534, 93);
            this.txtPrecVta.Name = "txtPrecVta";
            this.txtPrecVta.Size = new System.Drawing.Size(91, 20);
            this.txtPrecVta.TabIndex = 341;
            this.txtPrecVta.TabStop = false;
            this.txtPrecVta.Text = "0.00";
            this.txtPrecVta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecVta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPrecVta.TextoVacio = "<Descripcion>";
            this.txtPrecVta.TextChanged += new System.EventHandler(this.txtPrecVta_TextChanged);
            this.txtPrecVta.Leave += new System.EventHandler(this.txtPrecVta_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(528, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 340;
            this.label8.Text = "% Igv";
            // 
            // txtIgv
            // 
            this.txtIgv.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIgv.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIgv.Enabled = false;
            this.txtIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIgv.Location = new System.Drawing.Point(602, 48);
            this.txtIgv.Name = "txtIgv";
            this.txtIgv.Size = new System.Drawing.Size(54, 20);
            this.txtIgv.TabIndex = 339;
            this.txtIgv.TabStop = false;
            this.txtIgv.Text = "0.00";
            this.txtIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIgv.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtIgv.TextoVacio = "<Descripcion>";
            // 
            // txtIsc
            // 
            this.txtIsc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIsc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIsc.Enabled = false;
            this.txtIsc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIsc.Location = new System.Drawing.Point(602, 27);
            this.txtIsc.Name = "txtIsc";
            this.txtIsc.Size = new System.Drawing.Size(54, 20);
            this.txtIsc.TabIndex = 334;
            this.txtIsc.TabStop = false;
            this.txtIsc.Text = "0.00";
            this.txtIsc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIsc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtIsc.TextoVacio = "<Descripcion>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(528, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 333;
            this.label7.Text = "% Isc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(474, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 332;
            this.label6.Text = "Val. Venta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(376, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 331;
            this.label4.Text = "% Dsct  3";
            // 
            // txtDsct3
            // 
            this.txtDsct3.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDsct3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDsct3.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDsct3.Enabled = false;
            this.txtDsct3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDsct3.Location = new System.Drawing.Point(417, 93);
            this.txtDsct3.Name = "txtDsct3";
            this.txtDsct3.Size = new System.Drawing.Size(38, 20);
            this.txtDsct3.TabIndex = 330;
            this.txtDsct3.TabStop = false;
            this.txtDsct3.Text = "0.00";
            this.txtDsct3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDsct3.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtDsct3.TextoVacio = "<Descripcion>";
            // 
            // txtPorcDsct3
            // 
            this.txtPorcDsct3.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorcDsct3.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorcDsct3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcDsct3.Location = new System.Drawing.Point(379, 93);
            this.txtPorcDsct3.Name = "txtPorcDsct3";
            this.txtPorcDsct3.Size = new System.Drawing.Size(36, 20);
            this.txtPorcDsct3.TabIndex = 16;
            this.txtPorcDsct3.Text = "0.00";
            this.txtPorcDsct3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorcDsct3.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPorcDsct3.TextoVacio = "<Descripcion>";
            this.txtPorcDsct3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPorcDsct3_MouseClick);
            this.txtPorcDsct3.TextChanged += new System.EventHandler(this.txtPorcDsct3_TextChanged);
            this.txtPorcDsct3.Enter += new System.EventHandler(this.txtPorcDsct3_Enter);
            this.txtPorcDsct3.Leave += new System.EventHandler(this.txtPorcDsct3_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(303, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 328;
            this.label3.Text = "% Dsct  2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(229, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 327;
            this.label2.Text = "% Dsct  1";
            // 
            // txtPorcIgv
            // 
            this.txtPorcIgv.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorcIgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtPorcIgv.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorcIgv.Enabled = false;
            this.txtPorcIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcIgv.Location = new System.Drawing.Point(565, 48);
            this.txtPorcIgv.Name = "txtPorcIgv";
            this.txtPorcIgv.Size = new System.Drawing.Size(36, 20);
            this.txtPorcIgv.TabIndex = 11;
            this.txtPorcIgv.TabStop = false;
            this.txtPorcIgv.Text = "0.00";
            this.txtPorcIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorcIgv.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPorcIgv.TextoVacio = "<Descripcion>";
            this.txtPorcIgv.TextChanged += new System.EventHandler(this.txtPorcIgv_TextChanged);
            // 
            // txtPorcIsc
            // 
            this.txtPorcIsc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorcIsc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorcIsc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcIsc.Location = new System.Drawing.Point(564, 27);
            this.txtPorcIsc.Name = "txtPorcIsc";
            this.txtPorcIsc.Size = new System.Drawing.Size(37, 20);
            this.txtPorcIsc.TabIndex = 10;
            this.txtPorcIsc.TabStop = false;
            this.txtPorcIsc.Text = "0.00";
            this.txtPorcIsc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorcIsc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPorcIsc.TextoVacio = "<Descripcion>";
            this.txtPorcIsc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPorcIsc_MouseClick);
            this.txtPorcIsc.TextChanged += new System.EventHandler(this.txtPorcIsc_TextChanged);
            this.txtPorcIsc.Enter += new System.EventHandler(this.txtPorcIsc_Enter);
            this.txtPorcIsc.Leave += new System.EventHandler(this.txtPorcIsc_Leave);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCantidad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(10, 93);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(57, 20);
            this.txtCantidad.TabIndex = 12;
            this.txtCantidad.Text = "0.0000";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCantidad.TextoVacio = "<Descripcion>";
            this.txtCantidad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCantidad_MouseClick);
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.Enter += new System.EventHandler(this.txtCantidad_Enter);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // txtValVenta
            // 
            this.txtValVenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtValVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtValVenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtValVenta.Enabled = false;
            this.txtValVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValVenta.Location = new System.Drawing.Point(473, 93);
            this.txtValVenta.Name = "txtValVenta";
            this.txtValVenta.Size = new System.Drawing.Size(57, 20);
            this.txtValVenta.TabIndex = 322;
            this.txtValVenta.TabStop = false;
            this.txtValVenta.Text = "0.00";
            this.txtValVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValVenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtValVenta.TextoVacio = "<Descripcion>";
            // 
            // txtDsct2
            // 
            this.txtDsct2.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDsct2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDsct2.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDsct2.Enabled = false;
            this.txtDsct2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDsct2.Location = new System.Drawing.Point(338, 93);
            this.txtDsct2.Name = "txtDsct2";
            this.txtDsct2.Size = new System.Drawing.Size(38, 20);
            this.txtDsct2.TabIndex = 319;
            this.txtDsct2.TabStop = false;
            this.txtDsct2.Text = "0.00";
            this.txtDsct2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDsct2.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtDsct2.TextoVacio = "<Descripcion>";
            // 
            // txtPorcDsct2
            // 
            this.txtPorcDsct2.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorcDsct2.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorcDsct2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcDsct2.Location = new System.Drawing.Point(300, 93);
            this.txtPorcDsct2.Name = "txtPorcDsct2";
            this.txtPorcDsct2.Size = new System.Drawing.Size(36, 20);
            this.txtPorcDsct2.TabIndex = 15;
            this.txtPorcDsct2.Text = "0.00";
            this.txtPorcDsct2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorcDsct2.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPorcDsct2.TextoVacio = "<Descripcion>";
            this.txtPorcDsct2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPorcDsct2_MouseClick);
            this.txtPorcDsct2.TextChanged += new System.EventHandler(this.txtPorcDsct2_TextChanged);
            this.txtPorcDsct2.Enter += new System.EventHandler(this.txtPorcDsct2_Enter);
            this.txtPorcDsct2.Leave += new System.EventHandler(this.txtPorcDsct2_Leave);
            // 
            // txtDsct1
            // 
            this.txtDsct1.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDsct1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDsct1.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDsct1.Enabled = false;
            this.txtDsct1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDsct1.Location = new System.Drawing.Point(258, 93);
            this.txtDsct1.Name = "txtDsct1";
            this.txtDsct1.Size = new System.Drawing.Size(39, 20);
            this.txtDsct1.TabIndex = 317;
            this.txtDsct1.TabStop = false;
            this.txtDsct1.Text = "0.00";
            this.txtDsct1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDsct1.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtDsct1.TextoVacio = "<Descripcion>";
            // 
            // txtPorcDsct1
            // 
            this.txtPorcDsct1.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorcDsct1.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorcDsct1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcDsct1.Location = new System.Drawing.Point(222, 93);
            this.txtPorcDsct1.Name = "txtPorcDsct1";
            this.txtPorcDsct1.Size = new System.Drawing.Size(34, 20);
            this.txtPorcDsct1.TabIndex = 14;
            this.txtPorcDsct1.Text = "0.00";
            this.txtPorcDsct1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorcDsct1.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPorcDsct1.TextoVacio = "<Descripcion>";
            this.txtPorcDsct1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPorcDsct1_MouseClick);
            this.txtPorcDsct1.TextChanged += new System.EventHandler(this.txtPorcDsct1_TextChanged);
            this.txtPorcDsct1.Enter += new System.EventHandler(this.txtPorcDsct1_Enter);
            this.txtPorcDsct1.Leave += new System.EventHandler(this.txtPorcDsct1_Leave);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSubTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtSubTotal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(157, 93);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(57, 20);
            this.txtSubTotal.TabIndex = 315;
            this.txtSubTotal.TabStop = false;
            this.txtSubTotal.Text = "0.00";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubTotal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtSubTotal.TextoVacio = "<Descripcion>";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(159, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 314;
            this.label13.Text = "SubTotal";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AcceptsReturn = true;
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Empty;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(183, 27);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(287, 44);
            this.txtDescripcion.TabIndex = 11;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripcion.TextoVacio = "<Descripcion>";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPrecio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(70, 93);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(81, 20);
            this.txtPrecio.TabIndex = 13;
            this.txtPrecio.Text = "0.00000";
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPrecio.TextoVacio = "<Descripcion>";
            this.txtPrecio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPrecio_MouseClick);
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            this.txtPrecio.Enter += new System.EventHandler(this.txtPrecio_Enter);
            this.txtPrecio.Leave += new System.EventHandler(this.txtPrecio_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 304;
            this.label5.Text = "Precio";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 298;
            this.label12.Text = "Producto";
            // 
            // cboTipoArticulo
            // 
            this.cboTipoArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoArticulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoArticulo.FormattingEnabled = true;
            this.cboTipoArticulo.Location = new System.Drawing.Point(52, 26);
            this.cboTipoArticulo.Name = "cboTipoArticulo";
            this.cboTipoArticulo.Size = new System.Drawing.Size(235, 21);
            this.cboTipoArticulo.TabIndex = 2;
            this.cboTipoArticulo.SelectionChangeCommitted += new System.EventHandler(this.cboTipoArticulo_SelectionChangeCommitted);
            this.cboTipoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTipoArticulo_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(19, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 13);
            this.label16.TabIndex = 305;
            this.label16.Text = "Tipo";
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.lblRegistros);
            this.pnlDetalle.Controls.Add(this.txtTipDetra);
            this.pnlDetalle.Controls.Add(this.txtTasa);
            this.pnlDetalle.Controls.Add(this.chkDetra);
            this.pnlDetalle.Controls.Add(this.dgvArticulo);
            this.pnlDetalle.Controls.Add(this.cboTipoArticulo);
            this.pnlDetalle.Controls.Add(this.label16);
            this.pnlDetalle.Location = new System.Drawing.Point(3, 3);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(666, 181);
            this.pnlDetalle.TabIndex = 1;
            // 
            // txtTipDetra
            // 
            this.txtTipDetra.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTipDetra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtTipDetra.ColorTextoVacio = System.Drawing.SystemColors.GrayText;
            this.txtTipDetra.Enabled = false;
            this.txtTipDetra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipDetra.Location = new System.Drawing.Point(536, 26);
            this.txtTipDetra.Name = "txtTipDetra";
            this.txtTipDetra.Size = new System.Drawing.Size(57, 21);
            this.txtTipDetra.TabIndex = 1005;
            this.txtTipDetra.TabStop = false;
            this.txtTipDetra.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtTipDetra.TextoVacio = "<Descripcion>";
            // 
            // txtTasa
            // 
            this.txtTasa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTasa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtTasa.ColorTextoVacio = System.Drawing.SystemColors.GrayText;
            this.txtTasa.Enabled = false;
            this.txtTasa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTasa.ForeColor = System.Drawing.Color.Black;
            this.txtTasa.Location = new System.Drawing.Point(596, 26);
            this.txtTasa.Name = "txtTasa";
            this.txtTasa.Size = new System.Drawing.Size(57, 21);
            this.txtTasa.TabIndex = 1004;
            this.txtTasa.TabStop = false;
            this.txtTasa.Text = "0.00";
            this.txtTasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTasa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTasa.TextoVacio = "<Descripcion>";
            // 
            // chkDetra
            // 
            this.chkDetra.AutoSize = true;
            this.chkDetra.Enabled = false;
            this.chkDetra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDetra.Location = new System.Drawing.Point(453, 29);
            this.chkDetra.Name = "chkDetra";
            this.chkDetra.Size = new System.Drawing.Size(77, 17);
            this.chkDetra.TabIndex = 1003;
            this.chkDetra.TabStop = false;
            this.chkDetra.Text = "Detracción";
            this.chkDetra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDetra.UseVisualStyleBackColor = true;
            // 
            // dgvArticulo
            // 
            this.dgvArticulo.AllowUserToAddRows = false;
            this.dgvArticulo.AllowUserToDeleteRows = false;
            this.dgvArticulo.AutoGenerateColumns = false;
            this.dgvArticulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codArticuloDataGridViewTextBoxColumn,
            this.nomArticuloDataGridViewTextBoxColumn});
            this.dgvArticulo.DataSource = this.bsBase;
            this.dgvArticulo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvArticulo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvArticulo.EnableHeadersVisualStyles = false;
            this.dgvArticulo.Location = new System.Drawing.Point(0, 54);
            this.dgvArticulo.Name = "dgvArticulo";
            this.dgvArticulo.ReadOnly = true;
            this.dgvArticulo.Size = new System.Drawing.Size(664, 125);
            this.dgvArticulo.TabIndex = 3;
            this.dgvArticulo.TabStop = false;
            this.dgvArticulo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulo_CellDoubleClick);
            this.dgvArticulo.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvArticulo_CellPainting);
            this.dgvArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvArticulo_KeyDown);
            // 
            // codArticuloDataGridViewTextBoxColumn
            // 
            this.codArticuloDataGridViewTextBoxColumn.DataPropertyName = "codArticulo";
            this.codArticuloDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codArticuloDataGridViewTextBoxColumn.Name = "codArticuloDataGridViewTextBoxColumn";
            this.codArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomArticuloDataGridViewTextBoxColumn
            // 
            this.nomArticuloDataGridViewTextBoxColumn.DataPropertyName = "nomArticulo";
            this.nomArticuloDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.nomArticuloDataGridViewTextBoxColumn.Name = "nomArticuloDataGridViewTextBoxColumn";
            this.nomArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomArticuloDataGridViewTextBoxColumn.Width = 250;
            // 
            // chkCalculo
            // 
            this.chkCalculo.Checked = true;
            this.chkCalculo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCalculo.Location = new System.Drawing.Point(550, 320);
            this.chkCalculo.Name = "chkCalculo";
            this.chkCalculo.Size = new System.Drawing.Size(114, 17);
            this.chkCalculo.TabIndex = 601;
            this.chkCalculo.TabStop = false;
            this.chkCalculo.Text = "Ingresa en Calculo";
            this.chkCalculo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCalculo.UseVisualStyleBackColor = true;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(664, 18);
            this.lblRegistros.TabIndex = 1572;
            this.lblRegistros.Text = "Articulos";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(664, 18);
            this.label10.TabIndex = 1572;
            this.label10.Text = "Montos";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmEmisionDocumentoDet
            // 
            this.AcceptButton = null;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = null;
            this.ClientSize = new System.Drawing.Size(672, 349);
            this.Controls.Add(this.chkCalculo);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlComprobante);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmEmisionDocumentoDet";
            this.Text = "Emision de Documento";
            this.Load += new System.EventHandler(this.frmEmisionDocumentoDet_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            this.Controls.SetChildIndex(this.pnlComprobante, 0);
            this.Controls.SetChildIndex(this.pnlDetalle, 0);
            this.Controls.SetChildIndex(this.chkCalculo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlComprobante.ResumeLayout(false);
            this.pnlComprobante.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlComprobante;
        private ControlesWinForm.SuperTextBox txtCodigo;
        private System.Windows.Forms.Label label9;
        private ControlesWinForm.SuperTextBox txtPrecVta;
        private System.Windows.Forms.Label label8;
        private ControlesWinForm.SuperTextBox txtIgv;
        private ControlesWinForm.SuperTextBox txtIsc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private ControlesWinForm.SuperTextBox txtDsct3;
        private ControlesWinForm.SuperTextBox txtPorcDsct3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ControlesWinForm.SuperTextBox txtPorcIgv;
        private ControlesWinForm.SuperTextBox txtPorcIsc;
        private ControlesWinForm.SuperTextBox txtCantidad;
        private ControlesWinForm.SuperTextBox txtValVenta;
        private ControlesWinForm.SuperTextBox txtDsct2;
        private ControlesWinForm.SuperTextBox txtPorcDsct2;
        private ControlesWinForm.SuperTextBox txtDsct1;
        private ControlesWinForm.SuperTextBox txtPorcDsct1;
        private ControlesWinForm.SuperTextBox txtSubTotal;
        private System.Windows.Forms.Label label13;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private ControlesWinForm.SuperTextBox txtPrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboTipoArticulo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.DataGridView dgvArticulo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chImpuesto;
        private ControlesWinForm.SuperTextBox txtIdArticulo;
        private System.Windows.Forms.CheckBox chkCalculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticuloDataGridViewTextBoxColumn;
        private ControlesWinForm.SuperTextBox txtTipDetra;
        private ControlesWinForm.SuperTextBox txtTasa;
        private System.Windows.Forms.CheckBox chkDetra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblRegistros;
    }
}