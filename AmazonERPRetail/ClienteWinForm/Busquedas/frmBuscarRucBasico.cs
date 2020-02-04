using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Infraestructura;
using Infraestructura.Winform;
using Entidades.Maestros;
using Entidades.Generales;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarRucBasico : frmResponseBase
    {

        #region Constructores

        public frmBuscarRucBasico()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        public frmBuscarRucBasico(String Ruc_, Boolean ManejaCartera_ = false, Int32 idVendedor_ = 0)
            :this()
        {
            try
            {
                txtRuc.Text = Ruc_.Trim();
                CargarImagen();
                txtRuc.Focus();
                ManejaCartera = ManejaCartera_;
                idVendedor = idVendedor_;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        #endregion

        #region Variables

        private String caracterRuc = String.Empty;
        private readonly BackgroundWorker _bw = new BackgroundWorker();

        public SunatRuc Informacion = null;
        public String Ruc;
        public String RazonSocial;
        public String NomComercial;
        public String FechaInscripcion;
        public String FechaActividades;
        public String EstadoContribuyente;
        public String CondicionContribuyente;
        public String Direccion;
        public String FechaBaja;
        public String DNI;
        public List<String> Padrones;

        StringBuilder cadTemp = new StringBuilder();
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public Persona oPersona = null;

        String Marquee = "Recuperando Informacion desde Sunat...";
        Int32 letra = 0;
        String TipoBusqueda = String.Empty;
        Boolean ManejaCartera = false;
        Int32 idVendedor = 0;

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
            txtNombreComercial.Text = String.Empty;
            txtInscripcion.Text = String.Empty;
            txtInicio.Text = String.Empty;
            txtEstado.Text = String.Empty;
            txtFecBaja.Text = String.Empty;
            txtCondicion.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            cboPadrones.DataSource = null;
            txtDni.Text = String.Empty;
        }

        //void pAceptar()
        //{
        //    if (String.IsNullOrEmpty(Ruc) && String.IsNullOrEmpty(RazonSocial))
        //    {
        //        Global.MensajeError("No hay datos. Presione Cancelar.");
        //        return;
        //    }

        //    if (EstadoContribuyente == "ACTIVO")
        //    {
        //        DialogResult = DialogResult.OK;
        //        Dispose();
        //    }
        //    else
        //    {
        //        if (Global.MensajeAdvertencia("El proveedor no esta ACTIVO o tiene problemas. Desea agregarlo de todas maneras") == DialogResult.OK)
        //        {
        //            DialogResult = DialogResult.OK;
        //            Dispose();
        //        }
        //    }
        //}

        //void ObtenerUbigeo(String Direccion)
        //{
        //    String[] array = Direccion.Split('-');

        //    if (array.Length > 1)
        //    {
        //        Int32 num;
        //        Boolean flag = false;
        //        Int32 a = array.Length;
        //        String DirTemp = array[a - 3].Trim();
        //        DirTemp = DirTemp.TrimEnd(' ');
        //        String[] ArrayDir = DirTemp.Split(' ');
        //        Int32 i = ArrayDir.Length;

        //        flag = (num = ArrayDir[i - 1].Trim().IndexOf(")")) > 0;

        //        if (flag)
        //        {
        //            txtDepartamento.Text = ArrayDir[i - 1].Trim().Substring(num + 1);
        //        }

        //        flag = (num = ArrayDir[i - 1].Trim().IndexOf(")")) > 0;

        //        if (flag)
        //        {
        //            txtDepartamento.Text = ArrayDir[i - 1].Trim().Substring(num + 1);
        //        }

        //        flag = (num = ArrayDir[i - 1].Trim().IndexOf("(")) > 0;

        //        if (flag)
        //        {
        //            txtDepartamento.Text = ArrayDir[i - 1].Trim().Substring(num + 1);
        //        }

        //        txtProvincia.Text = array[a - 2].Trim();
        //        txtDistrito.Text = array[a - 1].Trim();
        //    }
        //}

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
                        NomComercial = Informacion.NombreComercial;
                        FechaInscripcion = Informacion.FechaInscripcion;
                        FechaActividades = Informacion.FechaActividades;
                        EstadoContribuyente = Informacion.EstadoContribuyente;
                        CondicionContribuyente = Informacion.CondicionContribuyente;
                        Direccion = Informacion.Direccion;
                        Padrones = Informacion.Padrones;
                        DNI = Informacion.Dni;
                        FechaBaja = Informacion.FechaBaja;

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
            txtNombreComercial.Text = NomComercial;
            txtInscripcion.Text = FechaInscripcion;
            txtInicio.Text = FechaActividades;
            txtEstado.Text = EstadoContribuyente;
            txtCondicion.Text = CondicionContribuyente;
            txtDireccion.Text = Direccion;
            cboPadrones.DataSource = Padrones;

            if (caracterRuc.Equals("1"))
            {
                txtDni.Text = DNI;
            }

            if (EstadoContribuyente == "BAJA DEFINITIVA")
            {
                label27.Visible = true;
                txtFecBaja.Visible = true;
                txtFecBaja.Text = FechaBaja;
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
        }

        #endregion

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            try
            {
                if (String.IsNullOrEmpty(Ruc) && String.IsNullOrEmpty(RazonSocial))
                {
                    Global.MensajeError("No hay datos. Presione Cancelar.");
                    return;
                }

                Persona oAuxiliar = AgenteMaestro.Proxy.ValidaRUCExistente(txtRuc.Text);

                if (oAuxiliar != null)
                {
                    Global.MensajeComunicacion("El RUC ingresado ya existe.");

                    if (idVendedor != 0 && ManejaCartera)
                    {
                        VendedoresCarteraE oClienteCartera = AgenteMaestro.Proxy.ObtenerCarteraPorIdCliente(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oAuxiliar.IdPersona);

                        if (oClienteCartera != null)
                        {
                            if (idVendedor != oClienteCartera.idVendedor)
                            {
                                Global.MensajeComunicacion(String.Format("El cliente {0} ya se encuentra asignado al Vendedor(a) {1}", oClienteCartera.desCliente, oClienteCartera.desVendedor));
                                return;
                            }
                        }

                        oPersona = oAuxiliar;
                    }
                }
                else
                {
                    //Tipo de Persona
                    ParTabla oParTabla = AgenteGeneral.Proxy.ParTablaPorNemo("PERJU");
                    Int32 tipPersona = 0;
                    Int32 tipDocPersona = 0;
                    Int32 idCanalVenta = 0;

                    if (oParTabla != null)
                    {
                        tipPersona = oParTabla.IdParTabla;
                    }
                    else
                    {
                        throw new Exception("No esta configurado el Tipo de Persona Jurídico en Parámetros Generales");
                    }

                    //Tipo de documento de identidad
                    oParTabla = AgenteGeneral.Proxy.ParTablaPorNemo("PERRUC");

                    if (oParTabla != null)
                    {
                        tipDocPersona = oParTabla.IdParTabla;
                    }
                    else
                    {
                        throw new Exception("No esta configurado el Tipo de Documento(RUC) en Parámetros Generales");
                    }

                    //Canal de Venta
                    oParTabla = AgenteGeneral.Proxy.ParTablaPorNemo("MERNAC");

                    if (oParTabla != null)
                    {
                        idCanalVenta = oParTabla.IdParTabla;
                    }
                    else
                    {
                        throw new Exception("No esta configurado los canales de venta en Parámetros Generales");
                    }

                    //Insertando la Persona
                    oPersona = new Persona()
                    {
                        TipoPersona = tipPersona,
                        RazonSocial = txtRazon.Text.Trim(),
                        RUC = txtRuc.Text.Trim(),
                        ApePaterno = String.Empty,
                        ApeMaterno = String.Empty,
                        Nombres = String.Empty,
                        TipoDocumento = tipDocPersona,
                        NroDocumento = txtRuc.Text.Trim(),
                        Telefonos = String.Empty,
                        Fax = String.Empty,
                        Correo = String.Empty,
                        Web = String.Empty,
                        DireccionCompleta = txtDireccion.Text.Trim(),
                        idPais = 90, //Peru
                        idUbigeo = String.Empty,
                        PrincipalContribuyente = false,
                        AgenteRetenedor = false,
                        idCanalVenta = idCanalVenta,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                    };

                    oPersona = AgenteMaestro.Proxy.InsertarPersona(oPersona);
                }

                base.Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Cancelar()
        {
            try
            {
                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                    _bw.Dispose();
                }
                
                Cursor = Cursors.Arrow;
                pbProgress.Visible = false;
                pbProgress.Visible = false;
                lblMarquee.Visible = false;
                base.Cancelar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmBuscarRucBasico_Load(object sender, EventArgs e)
        {
            txtRuc.Focus();
            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            Global.CrearToolTip(btBuscar, "Presionar F1.");
            Global.CrearToolTip(btAceptar, "Puede presionar F5.");
            Global.CrearToolTip(btCancelar, "Puede presionar F6.");
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
                txtRazon.Size = new Size(604, 22);
            }
            else
            {
                txtDni.Visible = false;
                label22.Visible = false;
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

        #endregion Eventos

    }
}
