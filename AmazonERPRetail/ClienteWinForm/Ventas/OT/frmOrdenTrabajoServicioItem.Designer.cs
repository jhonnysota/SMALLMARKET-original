namespace ClienteWinForm.Ventas
{
    partial class frmOrdenTrabajoServicioItem
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
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado5 = new MyLabelG.LabelDegradado();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.txtTotal = new ControlesWinForm.SuperTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtValorVenta = new ControlesWinForm.SuperTextBox();
            this.txtIGV = new ControlesWinForm.SuperTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCantidad = new ControlesWinForm.SuperTextBox();
            this.txtPrecioUnitario = new ControlesWinForm.SuperTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDesArticulo = new ControlesWinForm.SuperTextBox();
            this.txtCodArticulo = new ControlesWinForm.SuperTextBox();
            this.txtIdArticulo = new ControlesWinForm.SuperTextBox();
            this.dtpFecEntrega = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btBuscarArticulo = new System.Windows.Forms.Button();
            this.Nombre = new System.Windows.Forms.Label();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.chImpuesto = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPorcIgv = new ControlesWinForm.SuperTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(616, 255);
            this.btCancelar.Size = new System.Drawing.Size(112, 30);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(492, 255);
            this.btAceptar.Size = new System.Drawing.Size(112, 31);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(460, 22);
            this.lblTitPnlBase.Text = "Principales";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(750, 25);
            this.lblTituloPrincipal.Text = "Orden Trabajo Detalle";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(722, 1);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.chImpuesto);
            this.pnlBase.Controls.Add(this.label11);
            this.pnlBase.Controls.Add(this.txtTotal);
            this.pnlBase.Controls.Add(this.txtPorcIgv);
            this.pnlBase.Controls.Add(this.label10);
            this.pnlBase.Controls.Add(this.txtValorVenta);
            this.pnlBase.Controls.Add(this.txtIGV);
            this.pnlBase.Controls.Add(this.label8);
            this.pnlBase.Controls.Add(this.label9);
            this.pnlBase.Controls.Add(this.txtCantidad);
            this.pnlBase.Controls.Add(this.txtPrecioUnitario);
            this.pnlBase.Controls.Add(this.label14);
            this.pnlBase.Controls.Add(this.label13);
            this.pnlBase.Controls.Add(this.cboMoneda);
            this.pnlBase.Controls.Add(this.label12);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.txtDesArticulo);
            this.pnlBase.Controls.Add(this.txtCodArticulo);
            this.pnlBase.Controls.Add(this.txtIdArticulo);
            this.pnlBase.Controls.Add(this.dtpFecEntrega);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.btBuscarArticulo);
            this.pnlBase.Controls.Add(this.Nombre);
            this.pnlBase.Controls.Add(this.txtDescripcion);
            this.pnlBase.Location = new System.Drawing.Point(9, 29);
            this.pnlBase.Size = new System.Drawing.Size(462, 302);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.pnlBase.Controls.SetChildIndex(this.Nombre, 0);
            this.pnlBase.Controls.SetChildIndex(this.btBuscarArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.dtpFecEntrega, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCodArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.label5, 0);
            this.pnlBase.Controls.SetChildIndex(this.label12, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboMoneda, 0);
            this.pnlBase.Controls.SetChildIndex(this.label13, 0);
            this.pnlBase.Controls.SetChildIndex(this.label14, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtPrecioUnitario, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCantidad, 0);
            this.pnlBase.Controls.SetChildIndex(this.label9, 0);
            this.pnlBase.Controls.SetChildIndex(this.label8, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIGV, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtValorVenta, 0);
            this.pnlBase.Controls.SetChildIndex(this.label10, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtPorcIgv, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtTotal, 0);
            this.pnlBase.Controls.SetChildIndex(this.label11, 0);
            this.pnlBase.Controls.SetChildIndex(this.chImpuesto, 0);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado5);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(475, 29);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(265, 121);
            this.pnlAuditoria.TabIndex = 130;
            // 
            // labelDegradado5
            // 
            this.labelDegradado5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado5.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado5.ForeColor = System.Drawing.Color.White;
            this.labelDegradado5.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado5.Name = "labelDegradado5";
            this.labelDegradado5.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado5.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado5.Size = new System.Drawing.Size(263, 20);
            this.labelDegradado5.TabIndex = 274;
            this.labelDegradado5.Text = "Auditoria";
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(12, 97);
            this.fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaModificacionLabel.Name = "fechaModificacionLabel";
            this.fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            this.fechaModificacionLabel.TabIndex = 6;
            this.fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(119, 93);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(133, 20);
            this.txtModifica.TabIndex = 0;
            this.txtModifica.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(119, 49);
            this.txtFechaRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtFechaRegistro.TabIndex = 0;
            this.txtFechaRegistro.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario Registro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Registro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuario Modificación";
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(119, 27);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(133, 20);
            this.txtUsuRegistra.TabIndex = 0;
            this.txtUsuRegistra.TabStop = false;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(119, 71);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(133, 20);
            this.txtUsuModifica.TabIndex = 0;
            this.txtUsuModifica.TabStop = false;
            // 
            // txtTotal
            // 
            this.txtTotal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTotal.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(375, 275);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(73, 20);
            this.txtTotal.TabIndex = 1079;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTotal.TextoVacio = "<Descripcion>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(340, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 1080;
            this.label10.Text = "Total";
            // 
            // txtValorVenta
            // 
            this.txtValorVenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtValorVenta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtValorVenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtValorVenta.Enabled = false;
            this.txtValorVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorVenta.Location = new System.Drawing.Point(375, 209);
            this.txtValorVenta.Name = "txtValorVenta";
            this.txtValorVenta.Size = new System.Drawing.Size(73, 20);
            this.txtValorVenta.TabIndex = 1075;
            this.txtValorVenta.Text = "0.00";
            this.txtValorVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorVenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtValorVenta.TextoVacio = "<Descripcion>";
            // 
            // txtIGV
            // 
            this.txtIGV.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIGV.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIGV.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIGV.Enabled = false;
            this.txtIGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIGV.Location = new System.Drawing.Point(375, 253);
            this.txtIGV.Name = "txtIGV";
            this.txtIGV.Size = new System.Drawing.Size(73, 20);
            this.txtIGV.TabIndex = 1076;
            this.txtIGV.Text = "0.00";
            this.txtIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIGV.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtIGV.TextoVacio = "<Descripcion>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(309, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 1078;
            this.label8.Text = "Valor Venta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(346, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 1077;
            this.label9.Text = "IGV";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCantidad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(89, 209);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(63, 20);
            this.txtCantidad.TabIndex = 1071;
            this.txtCantidad.Text = "0.00";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCantidad.TextoVacio = "<Descripcion>";
            this.txtCantidad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCantidad_MouseClick);
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.Enter += new System.EventHandler(this.txtCantidad_Enter);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPrecioUnitario.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPrecioUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioUnitario.Location = new System.Drawing.Point(219, 209);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(78, 20);
            this.txtPrecioUnitario.TabIndex = 1072;
            this.txtPrecioUnitario.Text = "0.00";
            this.txtPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecioUnitario.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPrecioUnitario.TextoVacio = "<Descripcion>";
            this.txtPrecioUnitario.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPrecioUnitario_MouseClick);
            this.txtPrecioUnitario.TextChanged += new System.EventHandler(this.txtPrecioUnitario_TextChanged);
            this.txtPrecioUnitario.Enter += new System.EventHandler(this.txtPrecioUnitario_Enter);
            this.txtPrecioUnitario.Leave += new System.EventHandler(this.txtPrecioUnitario_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(9, 215);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 1074;
            this.label14.Text = "Cantidad";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(155, 213);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 1073;
            this.label13.Text = "Precio Unit.";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(230, 185);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(124, 21);
            this.cboMoneda.TabIndex = 1069;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(180, 189);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 1070;
            this.label12.Text = "Moneda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 1060;
            this.label5.Text = "Servicio";
            // 
            // txtDesArticulo
            // 
            this.txtDesArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesArticulo.BackColor = System.Drawing.Color.White;
            this.txtDesArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesArticulo.Location = new System.Drawing.Point(144, 27);
            this.txtDesArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesArticulo.Name = "txtDesArticulo";
            this.txtDesArticulo.Size = new System.Drawing.Size(278, 20);
            this.txtDesArticulo.TabIndex = 1059;
            this.txtDesArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesArticulo.TextoVacio = "<Descripcion>";
            this.txtDesArticulo.TextChanged += new System.EventHandler(this.txtDesArticulo_TextChanged);
            this.txtDesArticulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesArticulo_Validating);
            // 
            // txtCodArticulo
            // 
            this.txtCodArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodArticulo.BackColor = System.Drawing.Color.White;
            this.txtCodArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodArticulo.Location = new System.Drawing.Point(89, 27);
            this.txtCodArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodArticulo.Name = "txtCodArticulo";
            this.txtCodArticulo.Size = new System.Drawing.Size(53, 20);
            this.txtCodArticulo.TabIndex = 1058;
            this.txtCodArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodArticulo.TextoVacio = "<Descripcion>";
            this.txtCodArticulo.TextChanged += new System.EventHandler(this.txtCodArticulo_TextChanged);
            this.txtCodArticulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodArticulo_Validating);
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdArticulo.BackColor = System.Drawing.Color.White;
            this.txtIdArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdArticulo.Location = new System.Drawing.Point(68, 27);
            this.txtIdArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(9, 20);
            this.txtIdArticulo.TabIndex = 1061;
            this.txtIdArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdArticulo.TextoVacio = "<Descripcion>";
            this.txtIdArticulo.Visible = false;
            // 
            // dtpFecEntrega
            // 
            this.dtpFecEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecEntrega.Location = new System.Drawing.Point(89, 186);
            this.dtpFecEntrega.Name = "dtpFecEntrega";
            this.dtpFecEntrega.Size = new System.Drawing.Size(83, 20);
            this.dtpFecEntrega.TabIndex = 1057;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 189);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1056;
            this.label1.Text = "Fecha Entrega";
            // 
            // btBuscarArticulo
            // 
            this.btBuscarArticulo.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btBuscarArticulo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btBuscarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarArticulo.Location = new System.Drawing.Point(425, 27);
            this.btBuscarArticulo.Name = "btBuscarArticulo";
            this.btBuscarArticulo.Size = new System.Drawing.Size(24, 19);
            this.btBuscarArticulo.TabIndex = 1051;
            this.btBuscarArticulo.TabStop = false;
            this.btBuscarArticulo.UseVisualStyleBackColor = true;
            this.btBuscarArticulo.Click += new System.EventHandler(this.btBuscarArticulo_Click);
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre.Location = new System.Drawing.Point(9, 52);
            this.Nombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(63, 13);
            this.Nombre.TabIndex = 1050;
            this.Nombre.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(89, 51);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(358, 129);
            this.txtDescripcion.TabIndex = 1048;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripcion.TextoVacio = "Detalle Usado para Facturar";
            // 
            // chImpuesto
            // 
            this.chImpuesto.AutoSize = true;
            this.chImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chImpuesto.Location = new System.Drawing.Point(283, 234);
            this.chImpuesto.Name = "chImpuesto";
            this.chImpuesto.Size = new System.Drawing.Size(53, 17);
            this.chImpuesto.TabIndex = 349;
            this.chImpuesto.TabStop = false;
            this.chImpuesto.Text = "I.G.V.";
            this.chImpuesto.UseVisualStyleBackColor = true;
            this.chImpuesto.CheckedChanged += new System.EventHandler(this.chImpuesto_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(338, 234);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 348;
            this.label11.Text = "% Igv";
            // 
            // txtPorcIgv
            // 
            this.txtPorcIgv.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorcIgv.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPorcIgv.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorcIgv.Enabled = false;
            this.txtPorcIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcIgv.Location = new System.Drawing.Point(375, 231);
            this.txtPorcIgv.Name = "txtPorcIgv";
            this.txtPorcIgv.Size = new System.Drawing.Size(73, 20);
            this.txtPorcIgv.TabIndex = 347;
            this.txtPorcIgv.TabStop = false;
            this.txtPorcIgv.Text = "0.00";
            this.txtPorcIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorcIgv.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPorcIgv.TextoVacio = "<Descripcion>";
            this.txtPorcIgv.TextChanged += new System.EventHandler(this.txtPorcIgv_TextChanged);
            // 
            // frmOrdenTrabajoServicioItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 338);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmOrdenTrabajoServicioItem";
            this.Text = "Orden Trabajo Servicio Item";
            this.Load += new System.EventHandler(this.frmOrdenTrabajoServicioItem_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado5;
        private System.Windows.Forms.Label fechaModificacionLabel;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private ControlesWinForm.SuperTextBox txtTotal;
        private System.Windows.Forms.Label label10;
        private ControlesWinForm.SuperTextBox txtValorVenta;
        private ControlesWinForm.SuperTextBox txtIGV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ControlesWinForm.SuperTextBox txtCantidad;
        private ControlesWinForm.SuperTextBox txtPrecioUnitario;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private ControlesWinForm.SuperTextBox txtDesArticulo;
        private ControlesWinForm.SuperTextBox txtCodArticulo;
        private ControlesWinForm.SuperTextBox txtIdArticulo;
        private System.Windows.Forms.DateTimePicker dtpFecEntrega;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btBuscarArticulo;
        private System.Windows.Forms.Label Nombre;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private System.Windows.Forms.CheckBox chImpuesto;
        private System.Windows.Forms.Label label11;
        private ControlesWinForm.SuperTextBox txtPorcIgv;
    }
}