using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using Presentadora.AgenteServicio;
//using ConsultasOnline;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarRuc : Form
    {

        #region  Constructores
        
        public frmBuscarRuc()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            try
            {
                CargarImagen();
                txtRuc.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public frmBuscarRuc(String Tipo = "")
            : this()
        {
            TipoBusqueda = Tipo;
        } 

        #endregion

        #region Variables

        private String caracterRuc = String.Empty;
        private readonly BackgroundWorker _bw = new BackgroundWorker();
        
        public SunatRuc Informacion = null;
        public String Ruc;
        public String RazonSocial;
        public String TipoContribuyente;
        public String NomComercial;
        public String FechaInscripcion;
        public String FechaActividades;
        public String EstadoContribuyente;
        public String CondicionContribuyente;
        public String Direccion;
        public String Departamento;
        public String Provincia;
        public String Distrito;
        public String EmisionComprobante;
        public String ActividadExterior;
        public String SistemaContabilidad;
        public List<String> ActividadEconomica;
        public List<String> ComprobantesPago;
        public String EmisionElectronica;
        public List<String> ListaEmisionElectronica = null;
        public String EmisorElectronico;
        public String ComprobanteElectronico;
        public String AfiliacionPle;
        public List<String> Padrones;
        
        public String Telefonos;
        public String DNI;
        public String Profesion;
        public String nombres;
        public String ApellidosPaternos;
        public String ApellidosMaternos;
        public bool Avisar = false;
        public String RUS;
        public String FechaBaja;
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        UbigeoE DEPPRODISo = null;

        StringBuilder cadTemp = new StringBuilder();
        bool Busqueda = false;

        String Marquee = "Recuperando Informacion desde Sunat...";
        Int32 letra = 0;
        String TipoBusqueda = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void CargarImagen()
        {
            try
            {
                if (Informacion == null)
                {
                    Informacion = new SunatRuc();
                }

                txtCapcha.Text = String.Empty;
                pbCapcha.Image = Informacion.ObtenerCapcha;
            }
            catch (Exception ex)
            {
                if (!_bw.IsBusy)
                {
                    _bw.RunWorkerAsync();
                }
                else
                {
                    _bw.CancelAsync();
                }

                throw ex;
            }
        }

        void pLimpiarTextos()
        { 
            txtRazon.Text = String.Empty;
            txtTipo.Text = String.Empty;
            txtNombreComercial.Text = String.Empty;
            txtInscripcion.Text = String.Empty;
            txtInicio.Text = String.Empty;
            txtActividad.Text = String.Empty;
            txtEstado.Text = String.Empty;
            txtFecBaja.Text = String.Empty;
            txtCondicion.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtEmision.Text = String.Empty;
            txtActividad.Text = String.Empty;
            txtSistema.Text = String.Empty;
            txtProfesion.Text = String.Empty;
            cboActividad.DataSource = null;
            cboComprobantes.DataSource = null;
            cboEmisionElectronica.DataSource = null;
            txtEmisElec.Text = String.Empty;
            txtEmisorElec.Text = String.Empty;
            txtComprobantesElec.Text = String.Empty;
            txtPle.Text = String.Empty;
            cboPadrones.DataSource = null;
            lblEstado.Text = String.Empty;

            txtDni.Text = String.Empty;
            txtTelefonos.Text = String.Empty;
        }

        void pAceptar()
        {
            if (String.IsNullOrEmpty(Ruc) && String.IsNullOrEmpty(RazonSocial))
            {
                Global.MensajeError("No hay datos. Presione Cancelar.");
                return;
            }

            if (string.IsNullOrEmpty(txtDepartamento.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe escribir el departamento correspondiente a la dirección.");
                txtDepartamento.Focus();
                return;
            }
            
            if (string.IsNullOrEmpty(txtProvincia.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe escribir la provincia correspondiente a la dirección.");
                txtProvincia.Focus();
                return;
            }
            
            if (string.IsNullOrEmpty(txtDistrito.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe escribir el distrito correspondiente a la dirección.");
                txtDistrito.Focus();
                return;
            }

            Departamento = txtDepartamento.Text.Trim();
            Provincia = txtProvincia.Text.Trim();
            Distrito = txtDistrito.Text.Trim();

            if (EstadoContribuyente == "ACTIVO")
            {
                if (Avisar)
	            {
		            ApellidosPaternos = txtApePat.Text;
                    ApellidosMaternos = txtApeMat.Text;
                    nombres = txtNombres.Text;
	            }

                DialogResult = DialogResult.OK;
                Dispose();
            }
            else
            {
                if (Global.MensajeConfirmacion("El proveedor no esta ACTIVO o tiene problemas. Desea agregarlo de todas maneras") == DialogResult.Yes)
                {
                    if (Avisar)
                    {
                        ApellidosPaternos = txtApePat.Text;
                        ApellidosMaternos = txtApeMat.Text;
                        nombres = txtNombres.Text;
                    }

                    DialogResult = DialogResult.OK;
                    Dispose();
                }
            }
        }

        void pCancelar()
        {
            _bw.CancelAsync();
            _bw.Dispose();
            Cursor = Cursors.Arrow;
            pbProgress.Visible = false;
            pbProgress.Visible = false;
            lblMarquee.Visible = false;
            Busqueda = false;
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        void LimpiarLista()
        {
            cadTemp = new StringBuilder();

            for (Int32 i = 0; i < chkListDatos.Items.Count; i++)
            {
                chkListDatos.SetItemChecked(i, false);
            }
        }

        void ObtenerUbigeo(String Direccion)
        {
            String[] array = Direccion.Split('-');

            if (array.Length > 1)
            {
                Int32 num;
                Boolean flag = false;
                Int32 a = array.Length;
                String DirTemp = array[0].Trim();
                DirTemp = DirTemp.TrimEnd(' ');
                String[] ArrayDir = DirTemp.Split(' ');
                Int32 i = ArrayDir.Length;

                if (Direccion == "-")
                {
                    txtDepartamento.Text = "LIMA";
                    txtProvincia.Text = "LIMA";
                    txtDistrito.Text = "LIMA";
                }
                else
                {

                    flag = (num = ArrayDir[i - 1].Trim().IndexOf(")")) > 0;

                    if (flag)
                    {
                        txtDepartamento.Text = ArrayDir[i - 1].Trim().Substring(num + 1);
                    }
                    else
                    {
                        txtDepartamento.Text = ArrayDir[i - 1].Trim();
                    }

                    flag = (num = ArrayDir[i - 1].Trim().IndexOf(")")) > 0;

                    if (flag)
                    {
                        txtDepartamento.Text = ArrayDir[i - 1].Trim().Substring(num + 1);
                    }

                    flag = (num = ArrayDir[i - 1].Trim().IndexOf("(")) > 0;

                    if (flag)
                    {
                        txtDepartamento.Text = ArrayDir[i - 1].Trim().Substring(num + 1);
                    }

                    if (txtDepartamento.Text == "LIBERTAD")
                    {
                        txtDepartamento.Text = "LA LIBERTAD";
                    }

                    txtProvincia.Text = array[a - 2].Trim();
                    txtDistrito.Text = array[a - 1].Trim();
                }
            }
        }

        #endregion Procedimientos de Usuario

        #region Eventos de Usuario

        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                String sCaptcha = txtCapcha.Text.ToString();

                Ruc = txtRuc.Text.ToString();

                if (Ruc.Length != 11)
                {
                    Global.MensajeComunicacion("El RUC debe tener 11 caracteres...");

                    if (_bw.IsBusy)
                    {
                        _bw.CancelAsync();
                        Cursor = Cursors.Arrow;
                        pbProgress.Visible = false;
                        pbProgress.Visible = false;
                        lblMarquee.Visible = false;
                        Marquee = "Recuperando Informacion desde Sunat...";
                        letra = 0;
                    }
                    return;
                }

                Informacion.ObtenerInfo(Ruc, sCaptcha);
                
                switch (Informacion.GetResul)
                {
                    case SunatRuc.Resul.Ok:
                        RazonSocial = Informacion.RazonSocial;
                        TipoContribuyente = Informacion.TipoContribuyente;
                        NomComercial = Informacion.NombreComercial;
                        FechaInscripcion = Informacion.FechaInscripcion;
                        FechaActividades = Informacion.FechaActividades;
                        EstadoContribuyente = Informacion.EstadoContribuyente;
                        CondicionContribuyente = Informacion.CondicionContribuyente;
                        Direccion = Informacion.Direccion;
                        EmisionComprobante = Informacion.EmisionComprobante;
                        ActividadExterior = Informacion.ActividadExterior;
                        SistemaContabilidad = Informacion.SistemaContabilidad;
                        ActividadEconomica = Informacion.ActividadEconomica;
                        ComprobantesPago = Informacion.ComprobantesPago;

                        //if (Informacion.ListaEmisionElectronica != null & Informacion.ListaEmisionElectronica.Count > 0)
                        //{
                        //    ListaEmisionElectronica = Informacion.ListaEmisionElectronica;
                        //}
                        //else
                        //{
                        //    EmisionElectronica = Informacion.EmisionElectronica;
                        //    ListaEmisionElectronica = null;
                        //}

                        //EmisorElectronico = Informacion.EmisorElectronico;
                        //ComprobanteElectronico = Informacion.ComprobanteElectronico;
                        //AfiliacionPle = Informacion.AfiliacionPle;

                        Padrones = Informacion.Padrones;
                        Telefonos = Informacion.Telefonos;
                        DNI = Informacion.Dni;
                        RUS = Informacion.Rus;
                        FechaBaja = Informacion.FechaBaja;
                        Profesion = Informacion.Profesion;

                        break;
                    case SunatRuc.Resul.NoResul:
                        _bw.CancelAsync();
                        break;
                    case SunatRuc.Resul.ErrorCapcha:
                        _bw.CancelAsync();
                        Global.MensajeError("El codigo ingresado es incorrecto");
                        break;
                    case SunatRuc.Resul.Error:
                        _bw.CancelAsync();
                        break;
                    case SunatRuc.Resul.RucInvalido:
                        _bw.CancelAsync();
                        Global.MensajeFault("Por favor, ingrese numero de RUC valido");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblMarquee.Text = String.Empty;
            CargarImagen();
            txtRazon.Text = RazonSocial;
            txtTipo.Text = TipoContribuyente;
            txtNombreComercial.Text = NomComercial;
            txtInscripcion.Text = FechaInscripcion;
            txtInicio.Text = FechaActividades;
            txtEstado.Text = EstadoContribuyente;
            txtCondicion.Text = CondicionContribuyente;
            txtDireccion.Text = Direccion;
            ObtenerUbigeo(txtDireccion.Text.Trim());
            //sDis = sDis.Replace("�", "Ñ");
            Departamento = txtDepartamento.Text.Trim().Replace("�", "Ñ");
            Provincia = txtProvincia.Text.Trim().Replace("�", "Ñ");
            Distrito = txtDistrito.Text.Trim().Replace("�", "Ñ");
            txtEmision.Text = EmisionComprobante;
            txtActividad.Text = ActividadExterior;
            txtSistema.Text = SistemaContabilidad;
            cboActividad.DataSource = ActividadEconomica;
            cboComprobantes.DataSource = ComprobantesPago;

            if (ListaEmisionElectronica != null)
            {
                cboEmisionElectronica.DataSource = ListaEmisionElectronica;
                cboEmisionElectronica.Visible = true;
                txtEmisElec.Visible = false;
            }
            else
            {
                txtEmisElec.Text = EmisionElectronica;
                cboEmisionElectronica.Visible = false;
                txtEmisElec.Visible = true;
            }

            txtEmisorElec.Text = EmisorElectronico;
            txtComprobantesElec.Text = ComprobanteElectronico;
            txtPle.Text = AfiliacionPle;
            txtTelefonos.Text = Telefonos;
            
            if (caracterRuc.Equals("1"))
            {
                txtDni.Text = DNI;
                txtProfesion.Text = Profesion;
                btSeparar.Enabled = true;
            }
            else
            {
                btSeparar.Enabled = false;
            }

            if (RUS == "SI")
            {
                txtRus.Visible = true;
                label26.Visible = true;
                txtRus.Text = RUS;
                txtNombreComercial.Size = new Size(548, 22);

                if (EstadoContribuyente == "BAJA DEFINITIVA")
                {
                    label27.Visible = true;
                    txtFecBaja.Visible = true;
                    txtFecBaja.Text = FechaBaja;
                }
            }
            else
            {
                txtRus.Visible = false;
                label26.Visible = false;
                txtNombreComercial.Size = new Size(714, 22);
            }

            if (Padrones != null)
            {
                cboPadrones.DataSource = Padrones;
            }

            pbProgress.Visible = false;
            lblMarquee.Visible = false;
            lblMarquee.Text = String.Empty;
            Marquee = "Recuperando Informacion desde Sunat...";
            letra = 0;
            timer1.Enabled = false;
            Cursor = Cursors.Arrow;
            _bw.CancelAsync();
            _bw.Dispose();
            txtRuc.Focus();
            Busqueda = true;
        }

        public bool ValidarGrabacion()
        {
            DEPPRODISo = AgenteMaestros.Proxy.ObtenerubigeosunatPorDepProDis(txtDepartamento.Text,txtProvincia.Text,txtDistrito.Text);

            if (DEPPRODISo == null)
            {
                Global.MensajeFault("Digite un Departamento, Provincia o Distrito existente.");
                return false;
            }

            return true;
        }

        #endregion

        #region Eventos

        private void frmBuscarRuc_Load(object sender, EventArgs e)
        {
            txtRuc.Focus();
            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            Global.CrearToolTip(btBuscar, "Presionar F1.");
            Global.CrearToolTip(btAceptar, "Puede presionar F5.");
            Global.CrearToolTip(btCancelar, "Puede presionar F6.");
            Global.CrearToolTip(btSeparar, "Descomponer Razón Social");

            txtRuc.Text = Ruc;

            if (TipoBusqueda == "Menu")
            {
                btClientes.Visible = true;
                btProveedores.Visible = true;
            }
            else
            {
                btAceptar.Visible = true;
                btCancelar.Visible = true;
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            pbProgress.Visible = true;
            lblMarquee.Visible = true;
            timer1.Enabled = true;
            Cursor = Cursors.WaitCursor;

            if (!_bw.IsBusy)
            {
                _bw.RunWorkerAsync();    
            }
            else
            {
                _bw.CancelAsync();
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (Busqueda)
            {
                if (!ValidarGrabacion())
                {
                    return;
                }
                pAceptar();    
            }
            else
            {
                Global.MensajeComunicacion("El proceso de busqueda aún no ha terminado. \n\rPresione Cancelar");
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            pCancelar();
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            pLimpiarTextos();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            letra += 1;
            if (letra == Marquee.Length)
            {
                lblMarquee.Text = String.Empty;
                letra = 0;
            }
            else
            {
                lblMarquee.Text += Marquee.Substring(letra - 1, 1);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                CargarImagen();
                txtCapcha.SelectAll();
                txtCapcha.Focus();

                pLimpiarTextos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtRuc_Leave(object sender, EventArgs e)
        {
            caracterRuc = Global.Izquierda(txtRuc.Text, 1);

            if (caracterRuc.Equals("1"))
            {
                txtDni.Visible = true;
                label22.Visible = true;
                label24.Visible = true;
                txtProfesion.Visible = true;
                txtRazon.Size = new Size(604, 22);
            }
            else
            {
                txtDni.Visible = false;
                label22.Visible = false;
                label24.Visible = false;
                txtProfesion.Visible = false;
                txtRazon.Size = new Size(714, 22);
            }
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEstado.Text))
            {
                if (txtEstado.Text.Trim() == "ACTIVO")
                {
                    txtEstado.BackColor = Color.White;
                }
                else if (txtEstado.Text.Substring(0, 4) == "BAJA")
                {
                    txtEstado.BackColor = Color.Red;
                }
                else
                {
                    txtEstado.BackColor = Color.Yellow;
                }
            }
            else
            {
                txtEstado.BackColor = Color.White;
            }
        }

        private void txtCondicion_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCondicion.Text))
            {
                if (txtCondicion.Text.Substring(0, 2) == "NO")
                {
                    txtCondicion.BackColor = Color.Red;
                }
                else
                {
                    txtCondicion.BackColor = Color.White;
                }
            }
            else
            {
                txtCondicion.BackColor = Color.White;
            }
        }        

        private void btSeparar_Click(object sender, EventArgs e)
        {
            if (btSeparar.Text == ">>")
            {
                //AnchoTmp = this.Width;

                //for (Int32 i = this.Width; i <= AnchoTmp + 281; i++)
                //{
                //    this.Size = new Size(i, this.Height);
                //    a = i;
                //    //Thread.Sleep(1);
                //    Application.DoEvents();
                //}

                while (this.Width < 1315)
                {
                    this.Width++;
                    Application.DoEvents();
                }
                
                btSeparar.Text = "<<";
                panel2.Visible = true;
                Avisar = true;

                List<String> ListaNomApe = new List<String>(RazonSocial.Split(' '));
                chkListDatos.Items.Clear();

                foreach (String item in ListaNomApe)
                {
                    chkListDatos.Items.Add(item.ToString(), false);
                }
            }
            else
            {
                panel2.Visible = false;

                while (this.Width > 1032)
                {
                    this.Width--;
                    Application.DoEvents();
                }
                //for (Int32 s = a; s >= AnchoTmp; s--)
                //{
                //    this.Size = new Size(s, this.Height);
                //    //Thread.Sleep(1);
                //    Application.DoEvents();
                //}

                btSeparar.Text = ">>";
                Avisar = false;
            }
        }

        private void chkListDatos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch (e.NewValue)
            {
                case CheckState.Checked:
                    cadTemp.Append(chkListDatos.Text).Append(" ");

                    if (rbPat.Checked)
                    {
                        txtApePat.Text = cadTemp.ToString();
                    }

                    if (rbMat.Checked)
                    {
                        txtApeMat.Text = cadTemp.ToString();
                    }

                    if (rbNom.Checked)
                    {
                        txtNombres.Text = cadTemp.ToString();
                    }

                    break;
                case CheckState.Unchecked:

                    break;
                default:
                    break;
            }
        }

        private void rbPat_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarLista();
        }

        private void rbMat_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarLista();
        }

        private void rbNom_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarLista();
        }

        private void btClientes_Click(object sender, EventArgs e)
        {

        }

        private void frmBuscarRuc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    btBuscar.PerformClick();
                    break;
                case Keys.F5:
                    if (Busqueda)
                    {
                        pAceptar();
                    }
                    else
                    {
                        Global.MensajeComunicacion("El proceso de busqueda aun no ha terminado. \n\rPresione Cancelar");
                    }
                    break;
                case Keys.F6:
                    pCancelar();
                    break;
                case Keys.Escape:
                    pCancelar();
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
