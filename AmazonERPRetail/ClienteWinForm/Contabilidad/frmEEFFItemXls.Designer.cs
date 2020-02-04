namespace ClienteWinForm.Contabilidad
{
    partial class frmEEFFItemXls
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListadoEEFFitemXls = new System.Windows.Forms.DataGridView();
            this.idEMPRESADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEEFFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEEFFItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEEFFItemXlsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codcCostosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descCostos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsEEFFItemXls = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnAgregarTodosCCostos = new System.Windows.Forms.Button();
            this.txtCCostos = new ControlesWinForm.SuperTextBox();
            this.txtDesCCostos = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lbltitulo = new MyLabelG.LabelDegradado();
            this.label24 = new System.Windows.Forms.Label();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuRegistro = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtUsuModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.btCCosto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEEFFitemXls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEEFFItemXls)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(346, 336);
            this.btCancelar.Size = new System.Drawing.Size(116, 26);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(222, 336);
            this.btAceptar.Size = new System.Drawing.Size(116, 26);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(257, 22);
            this.lblTitPnlBase.Text = "Auditoria";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(646, 25);
            this.lblTituloPrincipal.Text = "Centro de Costos";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(617, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.label24);
            this.pnlBase.Controls.Add(this.txtFechaModificacion);
            this.pnlBase.Controls.Add(this.txtUsuRegistro);
            this.pnlBase.Controls.Add(this.label31);
            this.pnlBase.Controls.Add(this.label25);
            this.pnlBase.Controls.Add(this.txtFechaRegistro);
            this.pnlBase.Controls.Add(this.label29);
            this.pnlBase.Controls.Add(this.txtUsuModificacion);
            this.pnlBase.Location = new System.Drawing.Point(379, 205);
            this.pnlBase.Size = new System.Drawing.Size(259, 122);
            this.pnlBase.Controls.SetChildIndex(this.txtUsuModificacion, 0);
            this.pnlBase.Controls.SetChildIndex(this.label29, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtFechaRegistro, 0);
            this.pnlBase.Controls.SetChildIndex(this.label25, 0);
            this.pnlBase.Controls.SetChildIndex(this.label31, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtUsuRegistro, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtFechaModificacion, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.label24, 0);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvListadoEEFFitemXls);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(8, 30);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(630, 171);
            this.panel5.TabIndex = 267;
            // 
            // dgvListadoEEFFitemXls
            // 
            this.dgvListadoEEFFitemXls.AllowUserToAddRows = false;
            this.dgvListadoEEFFitemXls.AllowUserToDeleteRows = false;
            this.dgvListadoEEFFitemXls.AutoGenerateColumns = false;
            this.dgvListadoEEFFitemXls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoEEFFitemXls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEMPRESADataGridViewTextBoxColumn,
            this.idEEFFDataGridViewTextBoxColumn,
            this.idEEFFItemDataGridViewTextBoxColumn,
            this.idEEFFItemXlsDataGridViewTextBoxColumn,
            this.codcCostosDataGridViewTextBoxColumn,
            this.descCostos,
            this.filaDataGridViewTextBoxColumn,
            this.columnaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvListadoEEFFitemXls.DataSource = this.bsEEFFItemXls;
            this.dgvListadoEEFFitemXls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListadoEEFFitemXls.EnableHeadersVisualStyles = false;
            this.dgvListadoEEFFitemXls.Location = new System.Drawing.Point(0, 23);
            this.dgvListadoEEFFitemXls.Name = "dgvListadoEEFFitemXls";
            this.dgvListadoEEFFitemXls.Size = new System.Drawing.Size(628, 146);
            this.dgvListadoEEFFitemXls.TabIndex = 248;
            this.dgvListadoEEFFitemXls.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoEEFF_CellClick);
            // 
            // idEMPRESADataGridViewTextBoxColumn
            // 
            this.idEMPRESADataGridViewTextBoxColumn.DataPropertyName = "idEMPRESA";
            this.idEMPRESADataGridViewTextBoxColumn.HeaderText = "idEMPRESA";
            this.idEMPRESADataGridViewTextBoxColumn.Name = "idEMPRESADataGridViewTextBoxColumn";
            this.idEMPRESADataGridViewTextBoxColumn.Visible = false;
            // 
            // idEEFFDataGridViewTextBoxColumn
            // 
            this.idEEFFDataGridViewTextBoxColumn.DataPropertyName = "idEEFF";
            this.idEEFFDataGridViewTextBoxColumn.HeaderText = "idEEFF";
            this.idEEFFDataGridViewTextBoxColumn.Name = "idEEFFDataGridViewTextBoxColumn";
            this.idEEFFDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEEFFItemDataGridViewTextBoxColumn
            // 
            this.idEEFFItemDataGridViewTextBoxColumn.DataPropertyName = "idEEFFItem";
            this.idEEFFItemDataGridViewTextBoxColumn.HeaderText = "idEEFFItem";
            this.idEEFFItemDataGridViewTextBoxColumn.Name = "idEEFFItemDataGridViewTextBoxColumn";
            this.idEEFFItemDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEEFFItemXlsDataGridViewTextBoxColumn
            // 
            this.idEEFFItemXlsDataGridViewTextBoxColumn.DataPropertyName = "idEEFFItemXls";
            this.idEEFFItemXlsDataGridViewTextBoxColumn.HeaderText = "idEEFFItemXls";
            this.idEEFFItemXlsDataGridViewTextBoxColumn.Name = "idEEFFItemXlsDataGridViewTextBoxColumn";
            this.idEEFFItemXlsDataGridViewTextBoxColumn.Visible = false;
            // 
            // codcCostosDataGridViewTextBoxColumn
            // 
            this.codcCostosDataGridViewTextBoxColumn.DataPropertyName = "codcCostos";
            this.codcCostosDataGridViewTextBoxColumn.HeaderText = "C.Costos";
            this.codcCostosDataGridViewTextBoxColumn.Name = "codcCostosDataGridViewTextBoxColumn";
            this.codcCostosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descCostos
            // 
            this.descCostos.DataPropertyName = "descCostos";
            this.descCostos.HeaderText = "Descripción";
            this.descCostos.Name = "descCostos";
            this.descCostos.ReadOnly = true;
            this.descCostos.Width = 250;
            // 
            // filaDataGridViewTextBoxColumn
            // 
            this.filaDataGridViewTextBoxColumn.DataPropertyName = "fila";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.filaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.filaDataGridViewTextBoxColumn.HeaderText = "Fila";
            this.filaDataGridViewTextBoxColumn.MaxInputLength = 4;
            this.filaDataGridViewTextBoxColumn.Name = "filaDataGridViewTextBoxColumn";
            this.filaDataGridViewTextBoxColumn.Width = 60;
            // 
            // columnaDataGridViewTextBoxColumn
            // 
            this.columnaDataGridViewTextBoxColumn.DataPropertyName = "columna";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.columnaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.columnaDataGridViewTextBoxColumn.HeaderText = "Columna";
            this.columnaDataGridViewTextBoxColumn.Name = "columnaDataGridViewTextBoxColumn";
            this.columnaDataGridViewTextBoxColumn.Width = 60;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.Visible = false;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // bsEEFFItemXls
            // 
            this.bsEEFFItemXls.DataSource = typeof(Entidades.Contabilidad.EEFFItemXlsE);
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
            this.lblRegistros.Size = new System.Drawing.Size(628, 23);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Configuración ";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btCCosto);
            this.panel1.Controls.Add(this.btnQuitar);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.btnAgregarTodosCCostos);
            this.panel1.Controls.Add(this.txtCCostos);
            this.panel1.Controls.Add(this.txtDesCCostos);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.lbltitulo);
            this.panel1.Location = new System.Drawing.Point(8, 205);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 122);
            this.panel1.TabIndex = 268;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(307, -1);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(57, 23);
            this.btnQuitar.TabIndex = 271;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(244, -1);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(57, 23);
            this.btnAgregar.TabIndex = 270;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnAgregarTodosCCostos
            // 
            this.btnAgregarTodosCCostos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregarTodosCCostos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAgregarTodosCCostos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAgregarTodosCCostos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTodosCCostos.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTodosCCostos.Image = global::ClienteWinForm.Properties.Resources.Add_Reg;
            this.btnAgregarTodosCCostos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarTodosCCostos.Location = new System.Drawing.Point(67, 67);
            this.btnAgregarTodosCCostos.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarTodosCCostos.Name = "btnAgregarTodosCCostos";
            this.btnAgregarTodosCCostos.Size = new System.Drawing.Size(262, 26);
            this.btnAgregarTodosCCostos.TabIndex = 357;
            this.btnAgregarTodosCCostos.Text = "    Agregar Todos los Centro de Costos";
            this.btnAgregarTodosCCostos.UseVisualStyleBackColor = false;
            this.btnAgregarTodosCCostos.Click += new System.EventHandler(this.btnAgregarTodosCCostos_Click);
            // 
            // txtCCostos
            // 
            this.txtCCostos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCCostos.BackColor = System.Drawing.Color.White;
            this.txtCCostos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCostos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCCostos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCostos.Location = new System.Drawing.Point(67, 34);
            this.txtCCostos.Name = "txtCCostos";
            this.txtCCostos.Size = new System.Drawing.Size(69, 21);
            this.txtCCostos.TabIndex = 321;
            this.txtCCostos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCCostos.TextoVacio = "<Descripcion>";
            this.txtCCostos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCCostos_KeyPress);
            // 
            // txtDesCCostos
            // 
            this.txtDesCCostos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtDesCCostos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesCCostos.Enabled = false;
            this.txtDesCCostos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCCostos.Location = new System.Drawing.Point(139, 34);
            this.txtDesCCostos.Name = "txtDesCCostos";
            this.txtDesCCostos.Size = new System.Drawing.Size(190, 21);
            this.txtDesCCostos.TabIndex = 323;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(5, 38);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 13);
            this.label21.TabIndex = 322;
            this.label21.Text = "C. Costos :";
            // 
            // lbltitulo
            // 
            this.lbltitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltitulo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lbltitulo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.Color.White;
            this.lbltitulo.Location = new System.Drawing.Point(0, 0);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.PrimerColor = System.Drawing.Color.SlateGray;
            this.lbltitulo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lbltitulo.Size = new System.Drawing.Size(366, 21);
            this.lbltitulo.TabIndex = 253;
            this.lbltitulo.Text = "Datos";
            this.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(11, 97);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 13);
            this.label24.TabIndex = 275;
            this.label24.Text = "Fecha Modificacion";
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFechaModificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(119, 92);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(129, 20);
            this.txtFechaModificacion.TabIndex = 276;
            // 
            // txtUsuRegistro
            // 
            this.txtUsuRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuRegistro.Enabled = false;
            this.txtUsuRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistro.Location = new System.Drawing.Point(119, 29);
            this.txtUsuRegistro.Name = "txtUsuRegistro";
            this.txtUsuRegistro.Size = new System.Drawing.Size(129, 20);
            this.txtUsuRegistro.TabIndex = 270;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(11, 76);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(106, 13);
            this.label25.TabIndex = 273;
            this.label25.Text = "Usuario Modificacion";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(11, 34);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(85, 13);
            this.label29.TabIndex = 269;
            this.label29.Text = "Usuario Registro";
            // 
            // txtUsuModificacion
            // 
            this.txtUsuModificacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuModificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuModificacion.Enabled = false;
            this.txtUsuModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModificacion.Location = new System.Drawing.Point(119, 71);
            this.txtUsuModificacion.Name = "txtUsuModificacion";
            this.txtUsuModificacion.Size = new System.Drawing.Size(129, 20);
            this.txtUsuModificacion.TabIndex = 274;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFechaRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(119, 50);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(129, 20);
            this.txtFechaRegistro.TabIndex = 272;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(11, 55);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(79, 13);
            this.label31.TabIndex = 271;
            this.label31.Text = "Fecha Registro";
            // 
            // btCCosto
            // 
            this.btCCosto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCCosto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCCosto.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCCosto.Location = new System.Drawing.Point(332, 34);
            this.btCCosto.Name = "btCCosto";
            this.btCCosto.Size = new System.Drawing.Size(25, 20);
            this.btCCosto.TabIndex = 358;
            this.btCCosto.UseVisualStyleBackColor = true;
            this.btCCosto.Click += new System.EventHandler(this.btCCosto_Click);
            // 
            // frmEEFFItemXls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 370);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Name = "frmEEFFItemXls";
            this.Text = "Estados Financieros - Item - Excel";
            this.Load += new System.EventHandler(this.frmEEFFItemXls_Load);
            this.Shown += new System.EventHandler(this.frmEEFFItemXls_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEEFFItemXls_KeyPress);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEEFFitemXls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEEFFItemXls)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListadoEEFFitemXls;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Panel panel1;
        private ControlesWinForm.SuperTextBox txtCCostos;
        private System.Windows.Forms.TextBox txtDesCCostos;
        private System.Windows.Forms.Label label21;
        private MyLabelG.LabelDegradado lbltitulo;
        private System.Windows.Forms.Button btnAgregarTodosCCostos;
        private System.Windows.Forms.BindingSource bsEEFFItemXls;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEMPRESADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEEFFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEEFFItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEEFFItemXlsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codcCostosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descCostos;
        private System.Windows.Forms.DataGridViewTextBoxColumn filaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuRegistro;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtUsuModificacion;
        private System.Windows.Forms.Button btCCosto;
    }
}