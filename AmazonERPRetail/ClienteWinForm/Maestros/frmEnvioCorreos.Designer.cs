namespace ClienteWinForm.Maestros
{
    partial class frmEnvioCorreos
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.txtPara = new ControlesWinForm.SuperTextBox();
            this.txtCC = new ControlesWinForm.SuperTextBox();
            this.txtAsunto = new ControlesWinForm.SuperTextBox();
            this.txtMensaje = new ControlesWinForm.SuperTextBox();
            this.btAdjuntar = new System.Windows.Forms.Button();
            this.btEnviar = new System.Windows.Forms.Button();
            this.btPara = new System.Windows.Forms.Button();
            this.btCC = new System.Windows.Forms.Button();
            this.txtAdjunto = new ControlesWinForm.SuperTextBox();
            this.btQuitarAdjunto = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(659, 20);
            this.lblTitPnlBase.Text = "Nuevo Mensaje";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(677, 24);
            this.lblTituloPrincipal.Text = "Envio de Correos";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(651, 2);
            this.btCerrar.Size = new System.Drawing.Size(23, 20);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.btQuitarAdjunto);
            this.pnlBase.Controls.Add(this.txtAdjunto);
            this.pnlBase.Controls.Add(this.btCC);
            this.pnlBase.Controls.Add(this.btPara);
            this.pnlBase.Controls.Add(this.btEnviar);
            this.pnlBase.Controls.Add(this.btAdjuntar);
            this.pnlBase.Controls.Add(this.txtMensaje);
            this.pnlBase.Controls.Add(this.txtAsunto);
            this.pnlBase.Controls.Add(label2);
            this.pnlBase.Controls.Add(this.txtCC);
            this.pnlBase.Controls.Add(label1);
            this.pnlBase.Controls.Add(this.txtPara);
            this.pnlBase.Location = new System.Drawing.Point(7, 29);
            this.pnlBase.Size = new System.Drawing.Size(661, 295);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtPara, 0);
            this.pnlBase.Controls.SetChildIndex(label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCC, 0);
            this.pnlBase.Controls.SetChildIndex(label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtAsunto, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMensaje, 0);
            this.pnlBase.Controls.SetChildIndex(this.btAdjuntar, 0);
            this.pnlBase.Controls.SetChildIndex(this.btEnviar, 0);
            this.pnlBase.Controls.SetChildIndex(this.btPara, 0);
            this.pnlBase.Controls.SetChildIndex(this.btCC, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtAdjunto, 0);
            this.pnlBase.Controls.SetChildIndex(this.btQuitarAdjunto, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(354, 329);
            this.btCancelar.Visible = false;
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.Location = new System.Drawing.Point(305, 333);
            this.btAceptar.Size = new System.Drawing.Size(101, 25);
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btAceptar.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(70, 102);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(41, 13);
            label1.TabIndex = 322;
            label1.Text = "A&sunto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(70, 128);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(45, 13);
            label2.TabIndex = 324;
            label2.Text = "Adj&unto";
            // 
            // txtPara
            // 
            this.txtPara.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPara.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPara.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPara.Location = new System.Drawing.Point(143, 27);
            this.txtPara.Margin = new System.Windows.Forms.Padding(2);
            this.txtPara.Multiline = true;
            this.txtPara.Name = "txtPara";
            this.txtPara.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPara.Size = new System.Drawing.Size(507, 32);
            this.txtPara.TabIndex = 319;
            this.txtPara.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtPara.TextoVacio = "<Descripcion>";
            // 
            // txtCC
            // 
            this.txtCC.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCC.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCC.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCC.Location = new System.Drawing.Point(143, 62);
            this.txtCC.Margin = new System.Windows.Forms.Padding(2);
            this.txtCC.Multiline = true;
            this.txtCC.Name = "txtCC";
            this.txtCC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCC.Size = new System.Drawing.Size(507, 32);
            this.txtCC.TabIndex = 321;
            this.txtCC.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCC.TextoVacio = "<Descripcion>";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtAsunto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAsunto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsunto.Location = new System.Drawing.Point(143, 97);
            this.txtAsunto.Margin = new System.Windows.Forms.Padding(2);
            this.txtAsunto.Multiline = true;
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(434, 23);
            this.txtAsunto.TabIndex = 323;
            this.txtAsunto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtAsunto.TextoVacio = "<Descripcion>";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMensaje.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMensaje.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.Location = new System.Drawing.Point(8, 150);
            this.txtMensaje.Margin = new System.Windows.Forms.Padding(2);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensaje.Size = new System.Drawing.Size(642, 138);
            this.txtMensaje.TabIndex = 325;
            this.txtMensaje.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtMensaje.TextoVacio = "<Descripcion>";
            // 
            // btAdjuntar
            // 
            this.btAdjuntar.BackColor = System.Drawing.Color.Azure;
            this.btAdjuntar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAdjuntar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAdjuntar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAdjuntar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdjuntar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdjuntar.Image = global::ClienteWinForm.Properties.Resources.Adjuntar;
            this.btAdjuntar.Location = new System.Drawing.Point(581, 97);
            this.btAdjuntar.Margin = new System.Windows.Forms.Padding(2);
            this.btAdjuntar.Name = "btAdjuntar";
            this.btAdjuntar.Size = new System.Drawing.Size(69, 49);
            this.btAdjuntar.TabIndex = 327;
            this.btAdjuntar.Text = "      Adjuntar";
            this.btAdjuntar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAdjuntar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btAdjuntar.UseVisualStyleBackColor = false;
            this.btAdjuntar.Click += new System.EventHandler(this.btAdjuntar_Click);
            // 
            // btEnviar
            // 
            this.btEnviar.BackColor = System.Drawing.Color.Azure;
            this.btEnviar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEnviar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEnviar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnviar.Image = global::ClienteWinForm.Properties.Resources.Enviar_Correo;
            this.btEnviar.Location = new System.Drawing.Point(9, 27);
            this.btEnviar.Margin = new System.Windows.Forms.Padding(2);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(56, 119);
            this.btEnviar.TabIndex = 328;
            this.btEnviar.Text = "           Enviar";
            this.btEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btEnviar.UseVisualStyleBackColor = false;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // btPara
            // 
            this.btPara.BackColor = System.Drawing.Color.Azure;
            this.btPara.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btPara.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btPara.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btPara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPara.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPara.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPara.Location = new System.Drawing.Point(69, 28);
            this.btPara.Margin = new System.Windows.Forms.Padding(2);
            this.btPara.Name = "btPara";
            this.btPara.Size = new System.Drawing.Size(70, 23);
            this.btPara.TabIndex = 329;
            this.btPara.Text = "&Para...";
            this.btPara.UseVisualStyleBackColor = false;
            this.btPara.Click += new System.EventHandler(this.btPara_Click);
            // 
            // btCC
            // 
            this.btCC.BackColor = System.Drawing.Color.Azure;
            this.btCC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCC.Location = new System.Drawing.Point(69, 62);
            this.btCC.Margin = new System.Windows.Forms.Padding(2);
            this.btCC.Name = "btCC";
            this.btCC.Size = new System.Drawing.Size(70, 23);
            this.btCC.TabIndex = 330;
            this.btCC.Text = "&CC..";
            this.btCC.UseVisualStyleBackColor = false;
            this.btCC.Click += new System.EventHandler(this.btCC_Click);
            // 
            // txtAdjunto
            // 
            this.txtAdjunto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtAdjunto.BackColor = System.Drawing.Color.Azure;
            this.txtAdjunto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAdjunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjunto.Location = new System.Drawing.Point(143, 123);
            this.txtAdjunto.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdjunto.Multiline = true;
            this.txtAdjunto.Name = "txtAdjunto";
            this.txtAdjunto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAdjunto.Size = new System.Drawing.Size(411, 23);
            this.txtAdjunto.TabIndex = 331;
            this.txtAdjunto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtAdjunto.TextoVacio = "<Descripcion>";
            // 
            // btQuitarAdjunto
            // 
            this.btQuitarAdjunto.BackColor = System.Drawing.Color.Azure;
            this.btQuitarAdjunto.BackgroundImage = global::ClienteWinForm.Properties.Resources.cancel;
            this.btQuitarAdjunto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btQuitarAdjunto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btQuitarAdjunto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btQuitarAdjunto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btQuitarAdjunto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQuitarAdjunto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuitarAdjunto.Location = new System.Drawing.Point(554, 124);
            this.btQuitarAdjunto.Margin = new System.Windows.Forms.Padding(2);
            this.btQuitarAdjunto.Name = "btQuitarAdjunto";
            this.btQuitarAdjunto.Size = new System.Drawing.Size(22, 21);
            this.btQuitarAdjunto.TabIndex = 332;
            this.btQuitarAdjunto.UseVisualStyleBackColor = false;
            this.btQuitarAdjunto.Click += new System.EventHandler(this.btQuitarAdjunto_Click);
            // 
            // frmEnvioCorreos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 331);
            this.Name = "frmEnvioCorreos";
            this.Text = "frmEnvioCorreos";
            this.Load += new System.EventHandler(this.frmEnvioCorreos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlesWinForm.SuperTextBox txtAsunto;
        private ControlesWinForm.SuperTextBox txtCC;
        private ControlesWinForm.SuperTextBox txtPara;
        private ControlesWinForm.SuperTextBox txtMensaje;
        private System.Windows.Forms.Button btAdjuntar;
        private ControlesWinForm.SuperTextBox txtAdjunto;
        private System.Windows.Forms.Button btCC;
        private System.Windows.Forms.Button btPara;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.Button btQuitarAdjunto;
    }
}