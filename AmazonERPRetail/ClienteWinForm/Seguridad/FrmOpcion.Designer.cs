namespace ClienteWinForm.Seguridad
{
    partial class FrmOpcion
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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label grupoOpcionLabel;
            System.Windows.Forms.Label ordenLabel;
            System.Windows.Forms.Label idOpcionLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label ubicacionLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label tipoAplicacionLabel;
            System.Windows.Forms.Label fechaActualizacionLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label usuarioRegistrLabel;
            System.Windows.Forms.Label usuarioActualizacionLabel;
            this.richTexObservacion = new System.Windows.Forms.RichTextBox();
            this.OpcionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.nombreGrupoTextBox = new System.Windows.Forms.TextBox();
            this.ordenTextBox = new System.Windows.Forms.TextBox();
            this.grupoOpcionTextBox = new System.Windows.Forms.TextBox();
            this.idOpcionTextBox = new System.Windows.Forms.TextBox();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.cbTipoAplicacion = new System.Windows.Forms.ComboBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.ubicacionTextBox = new System.Windows.Forms.TextBox();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.fechaActualizacionTextBox = new System.Windows.Forms.TextBox();
            this.fechaRegistroTextBox = new System.Windows.Forms.TextBox();
            this.usuarioRegistrTextBox = new System.Windows.Forms.TextBox();
            this.usuarioActualizacionTextBox = new System.Windows.Forms.TextBox();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.pnllistado = new System.Windows.Forms.Panel();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.opcionDataGridView = new System.Windows.Forms.DataGridView();
            this.nombreGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListadoOpcionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            label5 = new System.Windows.Forms.Label();
            grupoOpcionLabel = new System.Windows.Forms.Label();
            ordenLabel = new System.Windows.Forms.Label();
            idOpcionLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            ubicacionLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            tipoAplicacionLabel = new System.Windows.Forms.Label();
            fechaActualizacionLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            usuarioRegistrLabel = new System.Windows.Forms.Label();
            usuarioActualizacionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OpcionBindingSource)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.pnllistado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opcionDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListadoOpcionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(831, 140);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 156;
            label5.Text = "OBSERVACION";
            // 
            // grupoOpcionLabel
            // 
            grupoOpcionLabel.AutoSize = true;
            grupoOpcionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            grupoOpcionLabel.Location = new System.Drawing.Point(455, 81);
            grupoOpcionLabel.Name = "grupoOpcionLabel";
            grupoOpcionLabel.Size = new System.Drawing.Size(42, 13);
            grupoOpcionLabel.TabIndex = 15;
            grupoOpcionLabel.Text = "GRUPO";
            // 
            // ordenLabel
            // 
            ordenLabel.AutoSize = true;
            ordenLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ordenLabel.Location = new System.Drawing.Point(455, 35);
            ordenLabel.Name = "ordenLabel";
            ordenLabel.Size = new System.Drawing.Size(42, 13);
            ordenLabel.TabIndex = 14;
            ordenLabel.Text = "ORDEN";
            // 
            // idOpcionLabel
            // 
            idOpcionLabel.AutoSize = true;
            idOpcionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idOpcionLabel.Location = new System.Drawing.Point(12, 35);
            idOpcionLabel.Name = "idOpcionLabel";
            idOpcionLabel.Size = new System.Drawing.Size(48, 13);
            idOpcionLabel.TabIndex = 0;
            idOpcionLabel.Text = "CODIGO";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descripcionLabel.Location = new System.Drawing.Point(12, 81);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(76, 13);
            descripcionLabel.TabIndex = 2;
            descripcionLabel.Text = "DESCRIPCION";
            // 
            // ubicacionLabel
            // 
            ubicacionLabel.AutoSize = true;
            ubicacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ubicacionLabel.Location = new System.Drawing.Point(455, 59);
            ubicacionLabel.Name = "ubicacionLabel";
            ubicacionLabel.Size = new System.Drawing.Size(64, 13);
            ubicacionLabel.TabIndex = 12;
            ubicacionLabel.Text = "UBICACIÓN";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nombreLabel.Location = new System.Drawing.Point(12, 59);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(49, 13);
            nombreLabel.TabIndex = 6;
            nombreLabel.Text = "NOMBRE";
            // 
            // tipoAplicacionLabel
            // 
            tipoAplicacionLabel.AutoSize = true;
            tipoAplicacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tipoAplicacionLabel.Location = new System.Drawing.Point(189, 35);
            tipoAplicacionLabel.Name = "tipoAplicacionLabel";
            tipoAplicacionLabel.Size = new System.Drawing.Size(96, 13);
            tipoAplicacionLabel.TabIndex = 8;
            tipoAplicacionLabel.Text = "TIPO APLICACION";
            // 
            // fechaActualizacionLabel
            // 
            fechaActualizacionLabel.AutoSize = true;
            fechaActualizacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaActualizacionLabel.Location = new System.Drawing.Point(10, 98);
            fechaActualizacionLabel.Name = "fechaActualizacionLabel";
            fechaActualizacionLabel.Size = new System.Drawing.Size(97, 13);
            fechaActualizacionLabel.TabIndex = 6;
            fechaActualizacionLabel.Text = "Fecha Modificacion";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(10, 54);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 4;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // usuarioRegistrLabel
            // 
            usuarioRegistrLabel.AutoSize = true;
            usuarioRegistrLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistrLabel.Location = new System.Drawing.Point(10, 32);
            usuarioRegistrLabel.Name = "usuarioRegistrLabel";
            usuarioRegistrLabel.Size = new System.Drawing.Size(86, 13);
            usuarioRegistrLabel.TabIndex = 0;
            usuarioRegistrLabel.Text = "Usuario Registro";
            // 
            // usuarioActualizacionLabel
            // 
            usuarioActualizacionLabel.AutoSize = true;
            usuarioActualizacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioActualizacionLabel.Location = new System.Drawing.Point(10, 76);
            usuarioActualizacionLabel.Name = "usuarioActualizacionLabel";
            usuarioActualizacionLabel.Size = new System.Drawing.Size(104, 13);
            usuarioActualizacionLabel.TabIndex = 2;
            usuarioActualizacionLabel.Text = "Usuario Modificacion";
            // 
            // richTexObservacion
            // 
            this.richTexObservacion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OpcionBindingSource, "Observacion", true));
            this.richTexObservacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTexObservacion.Location = new System.Drawing.Point(829, 156);
            this.richTexObservacion.Name = "richTexObservacion";
            this.richTexObservacion.Size = new System.Drawing.Size(261, 282);
            this.richTexObservacion.TabIndex = 158;
            this.richTexObservacion.Text = "";
            // 
            // OpcionBindingSource
            // 
            this.OpcionBindingSource.DataSource = typeof(Entidades.Seguridad.Opcion);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.nombreGrupoTextBox);
            this.pnlDetalle.Controls.Add(grupoOpcionLabel);
            this.pnlDetalle.Controls.Add(this.ordenTextBox);
            this.pnlDetalle.Controls.Add(this.grupoOpcionTextBox);
            this.pnlDetalle.Controls.Add(this.idOpcionTextBox);
            this.pnlDetalle.Controls.Add(ordenLabel);
            this.pnlDetalle.Controls.Add(idOpcionLabel);
            this.pnlDetalle.Controls.Add(this.descripcionTextBox);
            this.pnlDetalle.Controls.Add(descripcionLabel);
            this.pnlDetalle.Controls.Add(this.cbTipoAplicacion);
            this.pnlDetalle.Controls.Add(this.nombreTextBox);
            this.pnlDetalle.Controls.Add(ubicacionLabel);
            this.pnlDetalle.Controls.Add(nombreLabel);
            this.pnlDetalle.Controls.Add(this.ubicacionTextBox);
            this.pnlDetalle.Controls.Add(tipoAplicacionLabel);
            this.pnlDetalle.Controls.Add(this.labelDegradado3);
            this.pnlDetalle.Location = new System.Drawing.Point(5, 330);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(822, 108);
            this.pnlDetalle.TabIndex = 5;
            // 
            // nombreGrupoTextBox
            // 
            this.nombreGrupoTextBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.nombreGrupoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OpcionBindingSource, "nombreGrupo", true));
            this.nombreGrupoTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreGrupoTextBox.Location = new System.Drawing.Point(578, 76);
            this.nombreGrupoTextBox.Name = "nombreGrupoTextBox";
            this.nombreGrupoTextBox.ReadOnly = true;
            this.nombreGrupoTextBox.Size = new System.Drawing.Size(230, 21);
            this.nombreGrupoTextBox.TabIndex = 17;
            this.nombreGrupoTextBox.DoubleClick += new System.EventHandler(this.nombreGrupoTextBox_DoubleClick);
            // 
            // ordenTextBox
            // 
            this.ordenTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OpcionBindingSource, "Orden", true));
            this.ordenTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordenTextBox.Location = new System.Drawing.Point(523, 31);
            this.ordenTextBox.Name = "ordenTextBox";
            this.ordenTextBox.Size = new System.Drawing.Size(94, 21);
            this.ordenTextBox.TabIndex = 9;
            // 
            // grupoOpcionTextBox
            // 
            this.grupoOpcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OpcionBindingSource, "GrupoOpcion", true));
            this.grupoOpcionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupoOpcionTextBox.Location = new System.Drawing.Point(523, 76);
            this.grupoOpcionTextBox.Name = "grupoOpcionTextBox";
            this.grupoOpcionTextBox.Size = new System.Drawing.Size(54, 21);
            this.grupoOpcionTextBox.TabIndex = 11;
            this.grupoOpcionTextBox.DoubleClick += new System.EventHandler(this.grupoOpcionTextBox_DoubleClick);
            // 
            // idOpcionTextBox
            // 
            this.idOpcionTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.idOpcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OpcionBindingSource, "IdOpcion", true));
            this.idOpcionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idOpcionTextBox.Location = new System.Drawing.Point(94, 31);
            this.idOpcionTextBox.Name = "idOpcionTextBox";
            this.idOpcionTextBox.Size = new System.Drawing.Size(74, 21);
            this.idOpcionTextBox.TabIndex = 1;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OpcionBindingSource, "Descripcion", true));
            this.descripcionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descripcionTextBox.Location = new System.Drawing.Point(94, 76);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(352, 21);
            this.descripcionTextBox.TabIndex = 8;
            // 
            // cbTipoAplicacion
            // 
            this.cbTipoAplicacion.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.OpcionBindingSource, "TipoAplicacion", true));
            this.cbTipoAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoAplicacion.FormattingEnabled = true;
            this.cbTipoAplicacion.Location = new System.Drawing.Point(293, 31);
            this.cbTipoAplicacion.Name = "cbTipoAplicacion";
            this.cbTipoAplicacion.Size = new System.Drawing.Size(153, 22);
            this.cbTipoAplicacion.TabIndex = 6;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OpcionBindingSource, "Nombre", true));
            this.nombreTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreTextBox.Location = new System.Drawing.Point(94, 54);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(352, 21);
            this.nombreTextBox.TabIndex = 7;
            // 
            // ubicacionTextBox
            // 
            this.ubicacionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ubicacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OpcionBindingSource, "Ubicacion", true));
            this.ubicacionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ubicacionTextBox.Location = new System.Drawing.Point(523, 54);
            this.ubicacionTextBox.Name = "ubicacionTextBox";
            this.ubicacionTextBox.Size = new System.Drawing.Size(285, 21);
            this.ubicacionTextBox.TabIndex = 10;
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(820, 19);
            this.labelDegradado3.TabIndex = 250;
            this.labelDegradado3.Text = "Detalle";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(fechaActualizacionLabel);
            this.pnlAuditoria.Controls.Add(this.fechaActualizacionTextBox);
            this.pnlAuditoria.Controls.Add(this.fechaRegistroTextBox);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.usuarioRegistrTextBox);
            this.pnlAuditoria.Controls.Add(usuarioRegistrLabel);
            this.pnlAuditoria.Controls.Add(usuarioActualizacionLabel);
            this.pnlAuditoria.Controls.Add(this.usuarioActualizacionTextBox);
            this.pnlAuditoria.Controls.Add(this.labelDegradado2);
            this.pnlAuditoria.Enabled = false;
            this.pnlAuditoria.Location = new System.Drawing.Point(829, 4);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(261, 133);
            this.pnlAuditoria.TabIndex = 4;
            // 
            // fechaActualizacionTextBox
            // 
            this.fechaActualizacionTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.fechaActualizacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OpcionBindingSource, "FechaActualizacion", true));
            this.fechaActualizacionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaActualizacionTextBox.Location = new System.Drawing.Point(118, 94);
            this.fechaActualizacionTextBox.Name = "fechaActualizacionTextBox";
            this.fechaActualizacionTextBox.Size = new System.Drawing.Size(128, 21);
            this.fechaActualizacionTextBox.TabIndex = 7;
            // 
            // fechaRegistroTextBox
            // 
            this.fechaRegistroTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.fechaRegistroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OpcionBindingSource, "FechaRegistro", true));
            this.fechaRegistroTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaRegistroTextBox.Location = new System.Drawing.Point(118, 50);
            this.fechaRegistroTextBox.Name = "fechaRegistroTextBox";
            this.fechaRegistroTextBox.Size = new System.Drawing.Size(128, 21);
            this.fechaRegistroTextBox.TabIndex = 5;
            // 
            // usuarioRegistrTextBox
            // 
            this.usuarioRegistrTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.usuarioRegistrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OpcionBindingSource, "UsuarioRegistro", true));
            this.usuarioRegistrTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioRegistrTextBox.Location = new System.Drawing.Point(118, 28);
            this.usuarioRegistrTextBox.Name = "usuarioRegistrTextBox";
            this.usuarioRegistrTextBox.Size = new System.Drawing.Size(128, 21);
            this.usuarioRegistrTextBox.TabIndex = 1;
            // 
            // usuarioActualizacionTextBox
            // 
            this.usuarioActualizacionTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.usuarioActualizacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OpcionBindingSource, "UsuarioActualizacion", true));
            this.usuarioActualizacionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioActualizacionTextBox.Location = new System.Drawing.Point(118, 72);
            this.usuarioActualizacionTextBox.Name = "usuarioActualizacionTextBox";
            this.usuarioActualizacionTextBox.Size = new System.Drawing.Size(128, 21);
            this.usuarioActualizacionTextBox.TabIndex = 3;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(259, 19);
            this.labelDegradado2.TabIndex = 250;
            this.labelDegradado2.Text = "Auditoria";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnllistado
            // 
            this.pnllistado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnllistado.Controls.Add(this.BtnBuscar);
            this.pnllistado.Controls.Add(this.label1);
            this.pnllistado.Controls.Add(this.txtFiltro);
            this.pnllistado.Controls.Add(this.opcionDataGridView);
            this.pnllistado.Controls.Add(this.labelDegradado1);
            this.pnllistado.Location = new System.Drawing.Point(5, 4);
            this.pnllistado.Name = "pnllistado";
            this.pnllistado.Size = new System.Drawing.Size(822, 324);
            this.pnllistado.TabIndex = 3;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Enabled = false;
            this.BtnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.BtnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.Location = new System.Drawing.Point(645, 27);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(90, 23);
            this.BtnBuscar.TabIndex = 5;
            this.BtnBuscar.Text = "&BUSCAR";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "FILTRO";
            // 
            // txtFiltro
            // 
            this.txtFiltro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFiltro.Enabled = false;
            this.txtFiltro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(69, 29);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(557, 21);
            this.txtFiltro.TabIndex = 3;
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // opcionDataGridView
            // 
            this.opcionDataGridView.AllowUserToAddRows = false;
            this.opcionDataGridView.AllowUserToDeleteRows = false;
            this.opcionDataGridView.AllowUserToResizeColumns = false;
            this.opcionDataGridView.AllowUserToResizeRows = false;
            this.opcionDataGridView.AutoGenerateColumns = false;
            this.opcionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.opcionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreGrupo,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Orden});
            this.opcionDataGridView.DataSource = this.ListadoOpcionBindingSource;
            this.opcionDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.opcionDataGridView.EnableHeadersVisualStyles = false;
            this.opcionDataGridView.Location = new System.Drawing.Point(0, 57);
            this.opcionDataGridView.MultiSelect = false;
            this.opcionDataGridView.Name = "opcionDataGridView";
            this.opcionDataGridView.ReadOnly = true;
            this.opcionDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.opcionDataGridView.Size = new System.Drawing.Size(820, 265);
            this.opcionDataGridView.TabIndex = 0;
            // 
            // nombreGrupo
            // 
            this.nombreGrupo.DataPropertyName = "nombreGrupo";
            this.nombreGrupo.HeaderText = "Grupo";
            this.nombreGrupo.Name = "nombreGrupo";
            this.nombreGrupo.ReadOnly = true;
            this.nombreGrupo.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre Opción";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 190;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 190;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Ubicacion";
            this.dataGridViewTextBoxColumn4.HeaderText = "Ubicación";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // Orden
            // 
            this.Orden.DataPropertyName = "Orden";
            this.Orden.HeaderText = "Orden";
            this.Orden.Name = "Orden";
            this.Orden.ReadOnly = true;
            this.Orden.Width = 50;
            // 
            // ListadoOpcionBindingSource
            // 
            this.ListadoOpcionBindingSource.DataSource = typeof(Entidades.Seguridad.Opcion);
            this.ListadoOpcionBindingSource.CurrentChanged += new System.EventHandler(this.opcionBindingSource_CurrentChanged);
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
            this.labelDegradado1.Size = new System.Drawing.Size(820, 19);
            this.labelDegradado1.TabIndex = 249;
            this.labelDegradado1.Text = "Listado";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmOpcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 442);
            this.Controls.Add(label5);
            this.Controls.Add(this.richTexObservacion);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnllistado);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmOpcion";
            this.Text = "Opciones";
            this.Load += new System.EventHandler(this.FrmOpcion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OpcionBindingSource)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnllistado.ResumeLayout(false);
            this.pnllistado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opcionDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListadoOpcionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ubicacionTextBox;
        private System.Windows.Forms.BindingSource ListadoOpcionBindingSource;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.TextBox idOpcionTextBox;
        private System.Windows.Forms.TextBox fechaActualizacionTextBox;
        private System.Windows.Forms.TextBox fechaRegistroTextBox;
        private System.Windows.Forms.TextBox usuarioActualizacionTextBox;
        private System.Windows.Forms.TextBox usuarioRegistrTextBox;
        private System.Windows.Forms.ComboBox cbTipoAplicacion;
        private System.Windows.Forms.DataGridView opcionDataGridView;
        private System.Windows.Forms.BindingSource OpcionBindingSource;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.TextBox ordenTextBox;
        private System.Windows.Forms.TextBox nombreGrupoTextBox;
        private System.Windows.Forms.TextBox grupoOpcionTextBox;
        private System.Windows.Forms.Panel pnllistado;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.RichTextBox richTexObservacion;
        private MyLabelG.LabelDegradado labelDegradado3;
        private MyLabelG.LabelDegradado labelDegradado2;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orden;
        // private System.ServiceProcess.ServiceController serviceController1;
    }
}