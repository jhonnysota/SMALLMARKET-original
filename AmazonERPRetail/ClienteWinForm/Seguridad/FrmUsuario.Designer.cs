namespace ClienteWinForm.Seguridad
{
    partial class FrmUsuario
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
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label usuarioModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label idActivoLabel;
            System.Windows.Forms.Label credencialLabel;
            System.Windows.Forms.Label idPersonaLabel;
            System.Windows.Forms.Label claveLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.ImageList imageList1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbUsuarios = new System.Windows.Forms.TabControl();
            this.tpUsuario = new System.Windows.Forms.TabPage();
            this.cboDistrito = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtFecModificacion = new System.Windows.Forms.TextBox();
            this.txtFecRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.btClave = new System.Windows.Forms.Button();
            this.txtNombreCorto = new ControlesWinForm.SuperTextBox();
            this.txtCorreo = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.txtClave = new ControlesWinForm.SuperTextBox();
            this.txtCredencial = new ControlesWinForm.SuperTextBox();
            this.txtNombres = new ControlesWinForm.SuperTextBox();
            this.txtComMat = new ControlesWinForm.SuperTextBox();
            this.txtRazPat = new ControlesWinForm.SuperTextBox();
            this.btReniec = new System.Windows.Forms.Button();
            this.txtNroDocumento = new ControlesWinForm.SuperTextBox();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.btSunat = new System.Windows.Forms.Button();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.cboTipoPersona = new System.Windows.Forms.ComboBox();
            this.txtIdPersona = new System.Windows.Forms.TextBox();
            this.apeMaternoLabel = new System.Windows.Forms.Label();
            this.apePaternoLabel = new System.Windows.Forms.Label();
            this.nombresLabel = new System.Windows.Forms.Label();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.tpUbicacion = new System.Windows.Forms.TabPage();
            this.pnlCCostos = new System.Windows.Forms.Panel();
            this.dgvCostos = new System.Windows.Forms.DataGridView();
            this.idCCostosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCCostos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCCostos = new System.Windows.Forms.BindingSource(this.components);
            this.tpPlanilla = new System.Windows.Forms.TabPage();
            this.dgvPlanilla = new System.Windows.Forms.DataGridView();
            this.idPersonaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPlanillasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerRemun = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsUsuarioPlanilla = new System.Windows.Forms.BindingSource(this.components);
            this.tpSeries = new System.Windows.Forms.TabPage();
            this.dgvSeries = new System.Windows.Forms.DataGridView();
            this.idDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsSeries = new System.Windows.Forms.BindingSource(this.components);
            this.tpUsuarioAlmacen = new System.Windows.Forms.TabPage();
            this.dgvUsuarioAlmacen = new System.Windows.Forms.DataGridView();
            this.idAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsUsuarioAlmacen = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            idActivoLabel = new System.Windows.Forms.Label();
            credencialLabel = new System.Windows.Forms.Label();
            idPersonaLabel = new System.Windows.Forms.Label();
            claveLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tbUsuarios.SuspendLayout();
            this.tpUsuario.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.tpUbicacion.SuspendLayout();
            this.pnlCCostos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCCostos)).BeginInit();
            this.tpPlanilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuarioPlanilla)).BeginInit();
            this.tpSeries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSeries)).BeginInit();
            this.tpUsuarioAlmacen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarioAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuarioAlmacen)).BeginInit();
            this.SuspendLayout();
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(8, 93);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(8, 72);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(106, 13);
            usuarioModificacionLabel.TabIndex = 4;
            usuarioModificacionLabel.Text = "Usuario Modificación";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(8, 30);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(85, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(8, 51);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 2;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(325, 142);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(72, 13);
            label3.TabIndex = 251;
            label3.Text = "Nombre Corto";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(226, 119);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(39, 13);
            label5.TabIndex = 170;
            label5.Text = "N°Doc";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(13, 119);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 13);
            label1.TabIndex = 166;
            label1.Text = "Tipo Doc.";
            // 
            // idActivoLabel
            // 
            idActivoLabel.AutoSize = true;
            idActivoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idActivoLabel.Location = new System.Drawing.Point(171, 31);
            idActivoLabel.Name = "idActivoLabel";
            idActivoLabel.Size = new System.Drawing.Size(70, 13);
            idActivoLabel.TabIndex = 165;
            idActivoLabel.Text = "Tipo Persona";
            // 
            // credencialLabel
            // 
            credencialLabel.AutoSize = true;
            credencialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            credencialLabel.Location = new System.Drawing.Point(13, 164);
            credencialLabel.Name = "credencialLabel";
            credencialLabel.Size = new System.Drawing.Size(57, 13);
            credencialLabel.TabIndex = 2;
            credencialLabel.Text = "Credencial";
            // 
            // idPersonaLabel
            // 
            idPersonaLabel.AutoSize = true;
            idPersonaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idPersonaLabel.Location = new System.Drawing.Point(13, 31);
            idPersonaLabel.Name = "idPersonaLabel";
            idPersonaLabel.Size = new System.Drawing.Size(40, 13);
            idPersonaLabel.TabIndex = 15;
            idPersonaLabel.Text = "Código";
            // 
            // claveLabel
            // 
            claveLabel.AutoSize = true;
            claveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            claveLabel.Location = new System.Drawing.Point(196, 164);
            claveLabel.Name = "claveLabel";
            claveLabel.Size = new System.Drawing.Size(34, 13);
            claveLabel.TabIndex = 6;
            claveLabel.Text = "Clave";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(376, 31);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(30, 13);
            label2.TabIndex = 168;
            label2.Text = "RUC";
            // 
            // imageList1
            // 
            imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            imageList1.Images.SetKeyName(0, "AgregarPersonas.png");
            imageList1.Images.SetKeyName(1, "Location-icon_16x16.png");
            imageList1.Images.SetKeyName(2, "CrearDocumentos.png");
            imageList1.Images.SetKeyName(3, "op.png");
            imageList1.Images.SetKeyName(4, "Push_Pin16x16.png");
            imageList1.Images.SetKeyName(5, "Nuevo_Grande.png");
            // 
            // tbUsuarios
            // 
            this.tbUsuarios.Controls.Add(this.tpUsuario);
            this.tbUsuarios.Controls.Add(this.tpUbicacion);
            this.tbUsuarios.Controls.Add(this.tpPlanilla);
            this.tbUsuarios.Controls.Add(this.tpSeries);
            this.tbUsuarios.Controls.Add(this.tpUsuarioAlmacen);
            this.tbUsuarios.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsuarios.ImageList = imageList1;
            this.tbUsuarios.Location = new System.Drawing.Point(3, 3);
            this.tbUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.tbUsuarios.Name = "tbUsuarios";
            this.tbUsuarios.SelectedIndex = 0;
            this.tbUsuarios.Size = new System.Drawing.Size(845, 224);
            this.tbUsuarios.TabIndex = 112;
            this.tbUsuarios.SelectedIndexChanged += new System.EventHandler(this.tbUsuarios_SelectedIndexChanged);
            // 
            // tpUsuario
            // 
            this.tpUsuario.AutoScroll = true;
            this.tpUsuario.BackColor = System.Drawing.Color.Azure;
            this.tpUsuario.Controls.Add(this.cboDistrito);
            this.tpUsuario.Controls.Add(this.cboProvincia);
            this.tpUsuario.Controls.Add(this.pnlAuditoria);
            this.tpUsuario.Controls.Add(this.pnlDetalle);
            this.tpUsuario.Controls.Add(this.cboDepartamento);
            this.tpUsuario.ImageIndex = 0;
            this.tpUsuario.Location = new System.Drawing.Point(4, 23);
            this.tpUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.tpUsuario.Name = "tpUsuario";
            this.tpUsuario.Padding = new System.Windows.Forms.Padding(2);
            this.tpUsuario.Size = new System.Drawing.Size(837, 197);
            this.tpUsuario.TabIndex = 0;
            this.tpUsuario.Text = "Usuario ";
            // 
            // cboDistrito
            // 
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(572, 171);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(246, 22);
            this.cboDistrito.TabIndex = 111;
            this.cboDistrito.Visible = false;
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(572, 148);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(246, 22);
            this.cboProvincia.TabIndex = 110;
            this.cboProvincia.Visible = false;
            this.cboProvincia.SelectionChangeCommitted += new System.EventHandler(this.cboProvincia_SelectionChangeCommitted);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtFecModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFecRegistro);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(usuarioModificacionLabel);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Location = new System.Drawing.Point(572, 4);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(259, 118);
            this.pnlAuditoria.TabIndex = 4;
            // 
            // txtFecModificacion
            // 
            this.txtFecModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFecModificacion.Enabled = false;
            this.txtFecModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecModificacion.Location = new System.Drawing.Point(114, 89);
            this.txtFecModificacion.Name = "txtFecModificacion";
            this.txtFecModificacion.Size = new System.Drawing.Size(131, 20);
            this.txtFecModificacion.TabIndex = 7;
            // 
            // txtFecRegistro
            // 
            this.txtFecRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFecRegistro.Enabled = false;
            this.txtFecRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecRegistro.Location = new System.Drawing.Point(114, 47);
            this.txtFecRegistro.Name = "txtFecRegistro";
            this.txtFecRegistro.Size = new System.Drawing.Size(131, 20);
            this.txtFecRegistro.TabIndex = 3;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(114, 26);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(131, 20);
            this.txtUsuarioRegistro.TabIndex = 1;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(114, 68);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(131, 20);
            this.txtUsuarioModificacion.TabIndex = 5;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BackColor = System.Drawing.Color.Azure;
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.btClave);
            this.pnlDetalle.Controls.Add(this.txtNombreCorto);
            this.pnlDetalle.Controls.Add(label3);
            this.pnlDetalle.Controls.Add(this.txtCorreo);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.chkEstado);
            this.pnlDetalle.Controls.Add(this.txtClave);
            this.pnlDetalle.Controls.Add(this.txtCredencial);
            this.pnlDetalle.Controls.Add(this.txtNombres);
            this.pnlDetalle.Controls.Add(this.txtComMat);
            this.pnlDetalle.Controls.Add(this.txtRazPat);
            this.pnlDetalle.Controls.Add(this.btReniec);
            this.pnlDetalle.Controls.Add(this.txtNroDocumento);
            this.pnlDetalle.Controls.Add(label5);
            this.pnlDetalle.Controls.Add(this.cboTipoDocumento);
            this.pnlDetalle.Controls.Add(label1);
            this.pnlDetalle.Controls.Add(this.btSunat);
            this.pnlDetalle.Controls.Add(this.txtRuc);
            this.pnlDetalle.Controls.Add(idActivoLabel);
            this.pnlDetalle.Controls.Add(this.cboTipoPersona);
            this.pnlDetalle.Controls.Add(credencialLabel);
            this.pnlDetalle.Controls.Add(this.txtIdPersona);
            this.pnlDetalle.Controls.Add(this.apeMaternoLabel);
            this.pnlDetalle.Controls.Add(this.apePaternoLabel);
            this.pnlDetalle.Controls.Add(idPersonaLabel);
            this.pnlDetalle.Controls.Add(this.nombresLabel);
            this.pnlDetalle.Controls.Add(claveLabel);
            this.pnlDetalle.Controls.Add(label2);
            this.pnlDetalle.Location = new System.Drawing.Point(4, 4);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(566, 189);
            this.pnlDetalle.TabIndex = 3;
            // 
            // btClave
            // 
            this.btClave.BackColor = System.Drawing.Color.Azure;
            this.btClave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btClave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btClave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClave.Location = new System.Drawing.Point(326, 160);
            this.btClave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btClave.Name = "btClave";
            this.btClave.Size = new System.Drawing.Size(70, 20);
            this.btClave.TabIndex = 253;
            this.btClave.Text = "Ver Clave";
            this.btClave.UseVisualStyleBackColor = false;
            this.btClave.Visible = false;
            this.btClave.Click += new System.EventHandler(this.btClave_Click);
            // 
            // txtNombreCorto
            // 
            this.txtNombreCorto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombreCorto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombreCorto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCorto.Location = new System.Drawing.Point(399, 138);
            this.txtNombreCorto.Name = "txtNombreCorto";
            this.txtNombreCorto.Size = new System.Drawing.Size(152, 20);
            this.txtNombreCorto.TabIndex = 252;
            this.txtNombreCorto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombreCorto.TextoVacio = "<Descripcion>";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCorreo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(93, 138);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(231, 20);
            this.txtCorreo.TabIndex = 6;
            this.txtCorreo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCorreo.TextoVacio = "<Descripcion>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 179;
            this.label6.Text = "E-mail";
            // 
            // chkEstado
            // 
            this.chkEstado.Enabled = false;
            this.chkEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEstado.Location = new System.Drawing.Point(454, 163);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(93, 20);
            this.chkEstado.TabIndex = 2;
            this.chkEstado.Text = "De Baja";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // txtClave
            // 
            this.txtClave.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtClave.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(231, 160);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(93, 20);
            this.txtClave.TabIndex = 8;
            this.txtClave.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtClave.TextoVacio = "<Descripcion>";
            // 
            // txtCredencial
            // 
            this.txtCredencial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCredencial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCredencial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCredencial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredencial.Location = new System.Drawing.Point(93, 160);
            this.txtCredencial.Name = "txtCredencial";
            this.txtCredencial.Size = new System.Drawing.Size(101, 20);
            this.txtCredencial.TabIndex = 7;
            this.txtCredencial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCredencial.TextoVacio = "<Descripcion>";
            // 
            // txtNombres
            // 
            this.txtNombres.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombres.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombres.Location = new System.Drawing.Point(93, 93);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(459, 20);
            this.txtNombres.TabIndex = 4;
            this.txtNombres.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombres.TextoVacio = "<Descripcion>";
            // 
            // txtComMat
            // 
            this.txtComMat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtComMat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtComMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComMat.Location = new System.Drawing.Point(93, 71);
            this.txtComMat.Name = "txtComMat";
            this.txtComMat.Size = new System.Drawing.Size(459, 20);
            this.txtComMat.TabIndex = 3;
            this.txtComMat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtComMat.TextoVacio = "<Descripcion>";
            // 
            // txtRazPat
            // 
            this.txtRazPat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazPat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazPat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazPat.Location = new System.Drawing.Point(93, 49);
            this.txtRazPat.Name = "txtRazPat";
            this.txtRazPat.Size = new System.Drawing.Size(459, 20);
            this.txtRazPat.TabIndex = 2;
            this.txtRazPat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazPat.TextoVacio = "<Descripcion>";
            // 
            // btReniec
            // 
            this.btReniec.BackColor = System.Drawing.Color.Azure;
            this.btReniec.Enabled = false;
            this.btReniec.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btReniec.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btReniec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btReniec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReniec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReniec.Image = global::ClienteWinForm.Properties.Resources.reniec;
            this.btReniec.Location = new System.Drawing.Point(343, 115);
            this.btReniec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btReniec.Name = "btReniec";
            this.btReniec.Size = new System.Drawing.Size(57, 19);
            this.btReniec.TabIndex = 172;
            this.btReniec.UseVisualStyleBackColor = false;
            this.btReniec.Click += new System.EventHandler(this.btReniec_Click);
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroDocumento.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNroDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDocumento.Location = new System.Drawing.Point(269, 115);
            this.txtNroDocumento.MaxLength = 20;
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(72, 20);
            this.txtNroDocumento.TabIndex = 5;
            this.txtNroDocumento.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNroDocumento.TextoVacio = "<Descripcion>";
            this.txtNroDocumento.TextChanged += new System.EventHandler(this.txtNroDocumento_TextChanged);
            this.txtNroDocumento.Leave += new System.EventHandler(this.txtNroDocumento_Leave);
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.Enabled = false;
            this.cboTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(93, 115);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(132, 21);
            this.cboTipoDocumento.TabIndex = 164;
            this.cboTipoDocumento.SelectionChangeCommitted += new System.EventHandler(this.cboTipoDocumento_SelectionChangeCommitted);
            // 
            // btSunat
            // 
            this.btSunat.BackColor = System.Drawing.Color.Azure;
            this.btSunat.Enabled = false;
            this.btSunat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSunat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btSunat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSunat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSunat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSunat.Image = global::ClienteWinForm.Properties.Resources.SUNAT;
            this.btSunat.Location = new System.Drawing.Point(494, 27);
            this.btSunat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSunat.Name = "btSunat";
            this.btSunat.Size = new System.Drawing.Size(57, 19);
            this.btSunat.TabIndex = 171;
            this.btSunat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSunat.UseVisualStyleBackColor = false;
            this.btSunat.Click += new System.EventHandler(this.btSunat_Click);
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(409, 27);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(83, 20);
            this.txtRuc.TabIndex = 1;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "<Descripcion>";
            // 
            // cboTipoPersona
            // 
            this.cboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoPersona.FormattingEnabled = true;
            this.cboTipoPersona.Location = new System.Drawing.Point(244, 26);
            this.cboTipoPersona.Name = "cboTipoPersona";
            this.cboTipoPersona.Size = new System.Drawing.Size(131, 21);
            this.cboTipoPersona.TabIndex = 163;
            this.cboTipoPersona.SelectionChangeCommitted += new System.EventHandler(this.cboTipoPersona_SelectionChangeCommitted);
            // 
            // txtIdPersona
            // 
            this.txtIdPersona.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdPersona.Enabled = false;
            this.txtIdPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdPersona.Location = new System.Drawing.Point(93, 27);
            this.txtIdPersona.Name = "txtIdPersona";
            this.txtIdPersona.Size = new System.Drawing.Size(75, 20);
            this.txtIdPersona.TabIndex = 16;
            // 
            // apeMaternoLabel
            // 
            this.apeMaternoLabel.AutoSize = true;
            this.apeMaternoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apeMaternoLabel.Location = new System.Drawing.Point(13, 75);
            this.apeMaternoLabel.Name = "apeMaternoLabel";
            this.apeMaternoLabel.Size = new System.Drawing.Size(71, 13);
            this.apeMaternoLabel.TabIndex = 7;
            this.apeMaternoLabel.Text = "Ape. Materno";
            // 
            // apePaternoLabel
            // 
            this.apePaternoLabel.AutoSize = true;
            this.apePaternoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apePaternoLabel.Location = new System.Drawing.Point(13, 53);
            this.apePaternoLabel.Name = "apePaternoLabel";
            this.apePaternoLabel.Size = new System.Drawing.Size(69, 13);
            this.apePaternoLabel.TabIndex = 8;
            this.apePaternoLabel.Text = "Ape. Paterno";
            // 
            // nombresLabel
            // 
            this.nombresLabel.AutoSize = true;
            this.nombresLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombresLabel.Location = new System.Drawing.Point(13, 97);
            this.nombresLabel.Name = "nombresLabel";
            this.nombresLabel.Size = new System.Drawing.Size(49, 13);
            this.nombresLabel.TabIndex = 17;
            this.nombresLabel.Text = "Nombres";
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(572, 125);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(246, 22);
            this.cboDepartamento.TabIndex = 109;
            this.cboDepartamento.Visible = false;
            this.cboDepartamento.SelectionChangeCommitted += new System.EventHandler(this.cboDepartamento_SelectionChangeCommitted);
            // 
            // tpUbicacion
            // 
            this.tpUbicacion.BackColor = System.Drawing.Color.LightGray;
            this.tpUbicacion.Controls.Add(this.pnlCCostos);
            this.tpUbicacion.ImageIndex = 1;
            this.tpUbicacion.Location = new System.Drawing.Point(4, 23);
            this.tpUbicacion.Margin = new System.Windows.Forms.Padding(2);
            this.tpUbicacion.Name = "tpUbicacion";
            this.tpUbicacion.Padding = new System.Windows.Forms.Padding(2);
            this.tpUbicacion.Size = new System.Drawing.Size(837, 197);
            this.tpUbicacion.TabIndex = 2;
            this.tpUbicacion.Text = "C.Costos";
            // 
            // pnlCCostos
            // 
            this.pnlCCostos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCCostos.Controls.Add(this.dgvCostos);
            this.pnlCCostos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCCostos.Location = new System.Drawing.Point(2, 2);
            this.pnlCCostos.Name = "pnlCCostos";
            this.pnlCCostos.Size = new System.Drawing.Size(833, 193);
            this.pnlCCostos.TabIndex = 356;
            // 
            // dgvCostos
            // 
            this.dgvCostos.AllowUserToAddRows = false;
            this.dgvCostos.AllowUserToDeleteRows = false;
            this.dgvCostos.AutoGenerateColumns = false;
            this.dgvCostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCCostosDataGridViewTextBoxColumn,
            this.desCCostos,
            this.usuarioRegistroDataGridViewTextBoxColumn3,
            this.fechaRegistroDataGridViewTextBoxColumn3,
            this.usuarioModificacionDataGridViewTextBoxColumn3,
            this.fechaModificacionDataGridViewTextBoxColumn3});
            this.dgvCostos.DataSource = this.bsCCostos;
            this.dgvCostos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCostos.EnableHeadersVisualStyles = false;
            this.dgvCostos.Location = new System.Drawing.Point(0, 0);
            this.dgvCostos.Name = "dgvCostos";
            this.dgvCostos.ReadOnly = true;
            this.dgvCostos.Size = new System.Drawing.Size(831, 191);
            this.dgvCostos.TabIndex = 3;
            // 
            // idCCostosDataGridViewTextBoxColumn
            // 
            this.idCCostosDataGridViewTextBoxColumn.DataPropertyName = "idCCostos";
            this.idCCostosDataGridViewTextBoxColumn.HeaderText = "ID.";
            this.idCCostosDataGridViewTextBoxColumn.Name = "idCCostosDataGridViewTextBoxColumn";
            this.idCCostosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desCCostos
            // 
            this.desCCostos.DataPropertyName = "desCCostos";
            this.desCCostos.HeaderText = "Descripción";
            this.desCCostos.Name = "desCCostos";
            this.desCCostos.ReadOnly = true;
            this.desCCostos.Width = 250;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn3
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn3.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn3.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn3.Name = "usuarioRegistroDataGridViewTextBoxColumn3";
            this.usuarioRegistroDataGridViewTextBoxColumn3.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn3.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn3
            // 
            this.fechaRegistroDataGridViewTextBoxColumn3.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaRegistroDataGridViewTextBoxColumn3.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn3.Name = "fechaRegistroDataGridViewTextBoxColumn3";
            this.fechaRegistroDataGridViewTextBoxColumn3.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn3.Width = 120;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn3
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn3.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn3.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn3.Name = "usuarioModificacionDataGridViewTextBoxColumn3";
            this.usuarioModificacionDataGridViewTextBoxColumn3.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn3.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn3
            // 
            this.fechaModificacionDataGridViewTextBoxColumn3.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaModificacionDataGridViewTextBoxColumn3.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn3.Name = "fechaModificacionDataGridViewTextBoxColumn3";
            this.fechaModificacionDataGridViewTextBoxColumn3.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn3.Width = 120;
            // 
            // bsCCostos
            // 
            this.bsCCostos.DataSource = typeof(Entidades.Seguridad.UsuarioCCostosE);
            // 
            // tpPlanilla
            // 
            this.tpPlanilla.BackColor = System.Drawing.Color.LightGray;
            this.tpPlanilla.Controls.Add(this.dgvPlanilla);
            this.tpPlanilla.ImageIndex = 2;
            this.tpPlanilla.Location = new System.Drawing.Point(4, 23);
            this.tpPlanilla.Name = "tpPlanilla";
            this.tpPlanilla.Size = new System.Drawing.Size(837, 197);
            this.tpPlanilla.TabIndex = 3;
            this.tpPlanilla.Text = "Planilla";
            // 
            // dgvPlanilla
            // 
            this.dgvPlanilla.AllowUserToAddRows = false;
            this.dgvPlanilla.AllowUserToDeleteRows = false;
            this.dgvPlanilla.AutoGenerateColumns = false;
            this.dgvPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPersonaDataGridViewTextBoxColumn,
            this.idPlanillasDataGridViewTextBoxColumn,
            this.VerRemun,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvPlanilla.DataSource = this.bsUsuarioPlanilla;
            this.dgvPlanilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanilla.EnableHeadersVisualStyles = false;
            this.dgvPlanilla.Location = new System.Drawing.Point(0, 0);
            this.dgvPlanilla.Name = "dgvPlanilla";
            this.dgvPlanilla.Size = new System.Drawing.Size(837, 197);
            this.dgvPlanilla.TabIndex = 0;
            this.dgvPlanilla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanilla_CellEndEdit);
            this.dgvPlanilla.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPlanilla_CellFormatting);
            // 
            // idPersonaDataGridViewTextBoxColumn
            // 
            this.idPersonaDataGridViewTextBoxColumn.DataPropertyName = "idPersona";
            this.idPersonaDataGridViewTextBoxColumn.HeaderText = "Persona";
            this.idPersonaDataGridViewTextBoxColumn.Name = "idPersonaDataGridViewTextBoxColumn";
            // 
            // idPlanillasDataGridViewTextBoxColumn
            // 
            this.idPlanillasDataGridViewTextBoxColumn.DataPropertyName = "idPlanillas";
            this.idPlanillasDataGridViewTextBoxColumn.HeaderText = "Planillas";
            this.idPlanillasDataGridViewTextBoxColumn.Name = "idPlanillasDataGridViewTextBoxColumn";
            // 
            // VerRemun
            // 
            this.VerRemun.DataPropertyName = "VerRemun";
            this.VerRemun.HeaderText = "Ver Remun";
            this.VerRemun.Name = "VerRemun";
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 120;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // bsUsuarioPlanilla
            // 
            this.bsUsuarioPlanilla.DataSource = typeof(Entidades.Seguridad.UsuarioPlanillaE);
            // 
            // tpSeries
            // 
            this.tpSeries.BackColor = System.Drawing.Color.LightGray;
            this.tpSeries.Controls.Add(this.dgvSeries);
            this.tpSeries.ImageIndex = 3;
            this.tpSeries.Location = new System.Drawing.Point(4, 23);
            this.tpSeries.Name = "tpSeries";
            this.tpSeries.Padding = new System.Windows.Forms.Padding(3);
            this.tpSeries.Size = new System.Drawing.Size(837, 197);
            this.tpSeries.TabIndex = 4;
            this.tpSeries.Text = "Series";
            // 
            // dgvSeries
            // 
            this.dgvSeries.AllowUserToAddRows = false;
            this.dgvSeries.AllowUserToDeleteRows = false;
            this.dgvSeries.AutoGenerateColumns = false;
            this.dgvSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDocumentoDataGridViewTextBoxColumn,
            this.desDocumento,
            this.numSerieDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn1,
            this.fechaRegistroDataGridViewTextBoxColumn1,
            this.usuarioModificacionDataGridViewTextBoxColumn1,
            this.fechaModificacionDataGridViewTextBoxColumn1});
            this.dgvSeries.DataSource = this.bsSeries;
            this.dgvSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSeries.EnableHeadersVisualStyles = false;
            this.dgvSeries.Location = new System.Drawing.Point(3, 3);
            this.dgvSeries.Name = "dgvSeries";
            this.dgvSeries.ReadOnly = true;
            this.dgvSeries.Size = new System.Drawing.Size(831, 191);
            this.dgvSeries.TabIndex = 1;
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "Id.Doc.";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDocumentoDataGridViewTextBoxColumn.Width = 50;
            // 
            // desDocumento
            // 
            this.desDocumento.DataPropertyName = "desDocumento";
            this.desDocumento.HeaderText = "Documento";
            this.desDocumento.Name = "desDocumento";
            this.desDocumento.ReadOnly = true;
            this.desDocumento.Width = 200;
            // 
            // numSerieDataGridViewTextBoxColumn
            // 
            this.numSerieDataGridViewTextBoxColumn.DataPropertyName = "numSerie";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numSerieDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.numSerieDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.numSerieDataGridViewTextBoxColumn.Name = "numSerieDataGridViewTextBoxColumn";
            this.numSerieDataGridViewTextBoxColumn.ReadOnly = true;
            this.numSerieDataGridViewTextBoxColumn.Width = 50;
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
            this.fechaRegistroDataGridViewTextBoxColumn1.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
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
            // fechaModificacionDataGridViewTextBoxColumn1
            // 
            this.fechaModificacionDataGridViewTextBoxColumn1.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.fechaModificacionDataGridViewTextBoxColumn1.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn1.Name = "fechaModificacionDataGridViewTextBoxColumn1";
            this.fechaModificacionDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn1.Width = 120;
            // 
            // bsSeries
            // 
            this.bsSeries.DataSource = typeof(Entidades.Seguridad.UsuarioSeriesE);
            // 
            // tpUsuarioAlmacen
            // 
            this.tpUsuarioAlmacen.BackColor = System.Drawing.Color.LightGray;
            this.tpUsuarioAlmacen.Controls.Add(this.dgvUsuarioAlmacen);
            this.tpUsuarioAlmacen.ImageIndex = 5;
            this.tpUsuarioAlmacen.Location = new System.Drawing.Point(4, 23);
            this.tpUsuarioAlmacen.Name = "tpUsuarioAlmacen";
            this.tpUsuarioAlmacen.Size = new System.Drawing.Size(837, 197);
            this.tpUsuarioAlmacen.TabIndex = 6;
            this.tpUsuarioAlmacen.Text = "Usuario Almacen";
            // 
            // dgvUsuarioAlmacen
            // 
            this.dgvUsuarioAlmacen.AllowUserToAddRows = false;
            this.dgvUsuarioAlmacen.AllowUserToDeleteRows = false;
            this.dgvUsuarioAlmacen.AutoGenerateColumns = false;
            this.dgvUsuarioAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarioAlmacen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAlmacen,
            this.DesAlmacen,
            this.usuarioRegistroDataGridViewTextBoxColumn4,
            this.fechaRegistroDataGridViewTextBoxColumn4,
            this.usuarioModificacionDataGridViewTextBoxColumn4,
            this.fechaModificacionDataGridViewTextBoxColumn4});
            this.dgvUsuarioAlmacen.DataSource = this.bsUsuarioAlmacen;
            this.dgvUsuarioAlmacen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarioAlmacen.EnableHeadersVisualStyles = false;
            this.dgvUsuarioAlmacen.Location = new System.Drawing.Point(0, 0);
            this.dgvUsuarioAlmacen.Name = "dgvUsuarioAlmacen";
            this.dgvUsuarioAlmacen.ReadOnly = true;
            this.dgvUsuarioAlmacen.Size = new System.Drawing.Size(837, 197);
            this.dgvUsuarioAlmacen.TabIndex = 3;
            // 
            // idAlmacen
            // 
            this.idAlmacen.DataPropertyName = "idAlmacen";
            this.idAlmacen.HeaderText = "ID Alm.";
            this.idAlmacen.Name = "idAlmacen";
            this.idAlmacen.ReadOnly = true;
            this.idAlmacen.Width = 75;
            // 
            // DesAlmacen
            // 
            this.DesAlmacen.DataPropertyName = "DesAlmacen";
            this.DesAlmacen.HeaderText = "Almacen";
            this.DesAlmacen.Name = "DesAlmacen";
            this.DesAlmacen.ReadOnly = true;
            this.DesAlmacen.Width = 180;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn4
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn4.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn4.HeaderText = "Usuario Registro";
            this.usuarioRegistroDataGridViewTextBoxColumn4.Name = "usuarioRegistroDataGridViewTextBoxColumn4";
            this.usuarioRegistroDataGridViewTextBoxColumn4.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn4.Width = 140;
            // 
            // fechaRegistroDataGridViewTextBoxColumn4
            // 
            this.fechaRegistroDataGridViewTextBoxColumn4.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn4.HeaderText = "Fecha Registro";
            this.fechaRegistroDataGridViewTextBoxColumn4.Name = "fechaRegistroDataGridViewTextBoxColumn4";
            this.fechaRegistroDataGridViewTextBoxColumn4.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn4.Width = 130;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn4
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn4.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn4.HeaderText = "Usuario Modificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn4.Name = "usuarioModificacionDataGridViewTextBoxColumn4";
            this.usuarioModificacionDataGridViewTextBoxColumn4.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn4.Width = 140;
            // 
            // fechaModificacionDataGridViewTextBoxColumn4
            // 
            this.fechaModificacionDataGridViewTextBoxColumn4.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn4.HeaderText = "Fecha Modificacion";
            this.fechaModificacionDataGridViewTextBoxColumn4.Name = "fechaModificacionDataGridViewTextBoxColumn4";
            this.fechaModificacionDataGridViewTextBoxColumn4.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn4.Width = 130;
            // 
            // bsUsuarioAlmacen
            // 
            this.bsUsuarioAlmacen.DataSource = typeof(Entidades.Seguridad.UsuarioAlmacenE);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(257, 18);
            this.label4.TabIndex = 348;
            this.label4.Text = "Auditoria";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(564, 18);
            this.label7.TabIndex = 348;
            this.label7.Text = "Detalle";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 230);
            this.Controls.Add(this.tbUsuarios);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmUsuario";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.FrmUsuario_Load);
            this.tbUsuarios.ResumeLayout(false);
            this.tpUsuario.ResumeLayout(false);
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.tpUbicacion.ResumeLayout(false);
            this.pnlCCostos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCCostos)).EndInit();
            this.tpPlanilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuarioPlanilla)).EndInit();
            this.tpSeries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSeries)).EndInit();
            this.tpUsuarioAlmacen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarioAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuarioAlmacen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtFecModificacion;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFecRegistro;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtIdPersona;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Label nombresLabel;
        private System.Windows.Forms.Label apePaternoLabel;
        private System.Windows.Forms.Label apeMaternoLabel;
        //private System.Windows.Forms.BindingSource direccionesBindingSource;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.ComboBox cboTipoPersona;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtNroDocumento;
        private System.Windows.Forms.Button btSunat;
        private System.Windows.Forms.Button btReniec;
        private ControlesWinForm.SuperTextBox txtNombres;
        private ControlesWinForm.SuperTextBox txtComMat;
        private ControlesWinForm.SuperTextBox txtRazPat;
        private ControlesWinForm.SuperTextBox txtCorreo;
        private System.Windows.Forms.Label label6;
        private ControlesWinForm.SuperTextBox txtClave;
        private ControlesWinForm.SuperTextBox txtCredencial;
        private System.Windows.Forms.ComboBox cboDistrito;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.TabControl tbUsuarios;
        private System.Windows.Forms.TabPage tpUsuario;
        private System.Windows.Forms.TabPage tpUbicacion;
        private System.Windows.Forms.Panel pnlCCostos;
        private System.Windows.Forms.TabPage tpPlanilla;
        private System.Windows.Forms.DataGridView dgvPlanilla;
        private System.Windows.Forms.BindingSource bsUsuarioPlanilla;
        private ControlesWinForm.SuperTextBox txtNombreCorto;
        private System.Windows.Forms.Button btClave;
        private System.Windows.Forms.TabPage tpSeries;
        private System.Windows.Forms.DataGridView dgvSeries;
        private System.Windows.Forms.BindingSource bsSeries;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource bsCCostos;
        private System.Windows.Forms.DataGridView dgvCostos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCCostosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCCostos;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPersonaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPlanillasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VerRemun;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tpUsuarioAlmacen;
        private System.Windows.Forms.BindingSource bsUsuarioAlmacen;
        private System.Windows.Forms.DataGridView dgvUsuarioAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
    }
}