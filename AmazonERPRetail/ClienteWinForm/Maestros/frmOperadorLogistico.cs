using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
//using Negocio;
using ClienteWinForm.Busquedas;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
//using ControlesWinForm;

namespace ClienteWinForm.Maestros
{
    public partial class frmOperadorLogistico : FrmMantenimientoBase
    {

        #region Constructores

        public frmOperadorLogistico()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        public frmOperadorLogistico(OpeLogisticoE Operador, Persona persona, Int32 Opcion)
            : this()
        {
            oLogistico = Operador;
            oPersona = persona;
            OpcionGrabar = Opcion;
        }

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        public OpeLogisticoE oLogistico = null;
        public Persona oPersona = null;
        public Int32 OpcionGrabar;
        String idUbigeo = String.Empty;
        String sNroDocumento = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void EsNuevoRegistro()
        {
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
            {
                oLogistico = new OpeLogisticoE();
                oLogistico.Persona = new Persona();
                oLogistico.Persona = oPersona;

                txtIdOperador.Text = oLogistico.Persona.IdPersona.ToString();
                cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
                cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());

                CargarDatos();
            }
            else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            {
                oLogistico = new OpeLogisticoE();
                oLogistico.Persona = new Persona();
                oLogistico.Persona = oPersona;

                txtIdOperador.Text = oLogistico.Persona.IdPersona.ToString("000000");
                UbigeoE EUbigeo = new UbigeoE();
                EUbigeo = AgenteMaestro.Proxy.RecuperarUbigeoPorId(oPersona.idUbigeo.ToString());

                if (EUbigeo.Departamento != null)
                {
                    cboDepartamento.SelectedValue = EUbigeo.Departamento;
                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                    cboProvincia.SelectedValue = EUbigeo.Provincia;
                    cboProvincia_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboDistrito.SelectedValue = oPersona.idUbigeo;
                }
                else
                {
                    cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                }

                CargarDatos();
            }
            else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Actualizar))
            {
                oLogistico.Persona = new Persona();
                oLogistico.Persona = oPersona;

                txtIdOperador.Text = oLogistico.Persona.IdPersona.ToString("000000");
                UbigeoE EUbigeo = new UbigeoE();
                EUbigeo = AgenteMaestro.Proxy.RecuperarUbigeoPorId(oPersona.idUbigeo.ToString());

                if (EUbigeo.Departamento != null)
                {
                    cboDepartamento.SelectedValue = EUbigeo.Departamento;
                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                    cboProvincia.SelectedValue = EUbigeo.Provincia;
                    cboProvincia_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboDistrito.SelectedValue = oPersona.idUbigeo;
                }
                else
                {
                    cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                }

                CargarDatos();
            }
            cboTipoPersona.Enabled = false;
            base.Nuevo();
        }

        void LlenarCombos()
        {
            List<EnumParTabla> ListaParTabla = new List<EnumParTabla>();
            ListaParTabla.Add(EnumParTabla.TipoPersona);

            Dictionary<EnumParTabla, List<ParTabla>> ListaParametros = AgenteGeneral.Proxy.ListarParTablaPorListaGrupo(ListaParTabla);
            ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoPersona, ListaParametros[EnumParTabla.TipoPersona], "IdParTabla", "Nombre");

            List<UbigeoE> ListaDepartamento = AgenteMaestro.Proxy.ListarDepartamentos();
            UbigeoE CampoInicial = new UbigeoE();
            CampoInicial.Departamento = Variables.SeleccionDepartamento;
            ListaDepartamento.Add(CampoInicial);

            ComboHelper.LlenarCombos<UbigeoE>(cboDepartamento, (from x in ListaDepartamento orderby x.Departamento select x).ToList(), "Departamento", "Departamento");
        }

        void LlenarProvincias(String Departamento)
        {
            List<UbigeoE> ListaProvincias = AgenteMaestro.Proxy.ListarProvincias(Departamento);
            UbigeoE CampoInicial = new UbigeoE();
            CampoInicial.Provincia = Variables.SeleccioneProvincia;
            ListaProvincias.Add(CampoInicial);
            ComboHelper.LlenarCombos<UbigeoE>(cboProvincia, (from x in ListaProvincias orderby x.Provincia select x).ToList(), "Provincia", "Provincia");

            cboProvincia.SelectedValue = Variables.SeleccioneProvincia;
            cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
        }

        void LlenarDistritos(String Departamento, String Provincia)
        {
            List<UbigeoE> ListaDistritos = AgenteMaestro.Proxy.ListarDistritos(Departamento, Provincia);
            UbigeoE CampoInicial = new UbigeoE();
            CampoInicial.idUbigeo = "0";
            CampoInicial.Distrito = Variables.SeleccioneDistrito;
            ListaDistritos.Add(CampoInicial);

            ComboHelper.LlenarCombos<UbigeoE>(cboDistrito, (from x in ListaDistritos orderby x.idUbigeo select x).ToList(), "idUbigeo", "Distrito");
            cboDistrito.SelectedValue = "0";
        }

        void LlenarTipoDocumento()
        {
            List<ParTabla> ListaDocumentos = new List<ParTabla>();
            ListaDocumentos = AgenteGeneral.Proxy.ListarParTablaPorGrupo(Convert.ToInt32(EnumParTabla.TipoDocumento), "");

            //Persona Jurídica
            if (Convert.ToString(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Juridica).ToString())
            {
                List<ParTabla> ListaDocumentosJuridica = new List<ParTabla>();
                ListaDocumentosJuridica = (from x in ListaDocumentos
                                           where x.IdParTabla == Convert.ToInt32(EnumTipoDocumento.Ruc)
                                           select x).ToList();
                ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosJuridica, "IdParTabla", "Nombre");

                cboTipoDocumento.Enabled = false;
            }//Persona Natural con Ruc
            //else if (Convert.ToString(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Ruc).ToString())
            //{
            //    List<ParTabla> ListaDocumentosNatural = new List<ParTabla>();
            //    ListaDocumentosNatural = (from x in ListaDocumentos
            //                              where x.IdParTabla != Convert.ToInt32(EnumTipoDocumento.Ruc)
            //                              select x).ToList();
            //    ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosNatural, "IdParTabla", "Nombre");

            //    cboTipoDocumento.Enabled = true;
            //}//Persona Natural sin Ruc
            //else if ((Convert.ToString(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc).ToString()))
            //{
            //    List<ParTabla> ListaDocumentosJuridica = new List<ParTabla>();
            //    ListaDocumentosJuridica = (from x in ListaDocumentos
            //                               where x.IdParTabla == Convert.ToInt32(EnumTipoDocumento.Dni)
            //                               select x).ToList();
            //    ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosJuridica, "IdParTabla", "Nombre");

            //    cboTipoDocumento.Enabled = false;
            //}//Otros
            //else if ((Convert.ToString(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Otros).ToString()))
            //{
            //    List<ParTabla> ListaDocumentosNatural = new List<ParTabla>();
            //    ListaDocumentosNatural = (from x in ListaDocumentos
            //                              where (x.IdParTabla != Convert.ToInt32(EnumTipoDocumento.Ruc)) && (x.IdParTabla != Convert.ToInt32(EnumTipoDocumento.Dni))
            //                              select x).ToList();
            //    ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosNatural, "IdParTabla", "Nombre");

            //    cboTipoDocumento.Enabled = true;
            //}
            else
            {
                cboTipoDocumento.DataSource = null;
                cboTipoDocumento.Enabled = false;
            }
        }

        bool RevisarNroDocumento(String numero, String tipo)
        {
            if (tipo == "dni")
            {
                if (String.IsNullOrEmpty(numero))
                {
                    Global.MensajeComunicacion("Debe colocar un Nro. de DNI...");
                    txtRuc.Focus();
                    return false;
                }
                else
                {
                    if (numero.Length != Variables.NroCaracteresDNI)
                    {
                        Global.MensajeComunicacion("El número de digitos es incorrecto...");
                        return false;
                    }
                }
            }
            else
            {
                if (String.IsNullOrEmpty(numero))
                {
                    Global.MensajeComunicacion("Debe colocar un Nro. de RUC...");
                    txtRuc.Focus();
                    return false;
                }
                else
                {
                    if (numero.Length != Variables.NroCaracteresRUC)
                    {
                        Global.MensajeComunicacion("El número de digitos es incorrecto...");
                        return false;
                    }
                }
            }

            return true;
        }

        void GuardarDatos()
        {
            String Direccion = String.Empty;

            //Persona
            oLogistico.Persona.TipoPersona = Convert.ToInt32(cboTipoPersona.SelectedValue);
            oLogistico.Persona.RazonSocial = txtRazon.Text;

            if (Convert.ToInt32(cboTipoPersona.SelectedValue) == (Int32)enumTipoPersona.Juridica || Convert.ToInt32(cboTipoPersona.SelectedValue) == (Int32)enumTipoPersona.Natural_Ruc)
            {
                oLogistico.Persona.RUC = txtRuc.Text;
                oLogistico.Persona.NroDocumento = String.Empty;
            }
            else
            {
                oLogistico.Persona.RUC = txtRuc.Text;
                oLogistico.Persona.NroDocumento = txtRuc.Text;
            }

            oLogistico.Persona.ApePaterno = txtApePat.Text;
            oLogistico.Persona.ApeMaterno = txtApeMat.Text;
            oLogistico.Persona.Nombres = txtNombres.Text;
            oLogistico.Persona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
            oLogistico.Persona.Telefonos = txtTelefonos.Text;
            oLogistico.Persona.Fax = txtFax.Text;
            oLogistico.Persona.Correo = txtCorreo.Text;
            oLogistico.Persona.Web = txtWeb.Text;

            Direccion = txtDireccion.Text.Trim();
            Direccion = Direccion.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, "");
            oLogistico.Persona.idUbigeo = cboDistrito.SelectedValue.ToString();

            //Operador Logistico
            oLogistico.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            oLogistico.SiglaComercial = txtComercial.Text;
            oLogistico.indBaja = chkBaja.Checked;
            oLogistico.fecBaja = chkBaja.Checked ? Convert.ToDateTime(txtFecBaja.Text) : (Nullable<DateTime>)null;

            //Auditoria
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
            {
                oLogistico.Persona.UsuarioRegistro = txtUsuRegistra.Text;
                oLogistico.Persona.FechaRegistro = VariablesLocales.FechaHoy;
                oLogistico.Persona.UsuarioModificacion = txtUsuModifica.Text;
                oLogistico.Persona.FechaModificacion = VariablesLocales.FechaHoy;

                oLogistico.UsuarioRegistro = txtUsuRegistra.Text;
                oLogistico.FechaRegistro = VariablesLocales.FechaHoy;
                oLogistico.UsuarioModificacion = txtUsuModifica.Text;
                oLogistico.FechaModificacion = VariablesLocales.FechaHoy;
            }
            else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            {
                oLogistico.Persona.UsuarioModificacion = txtUsuModifica.Text;
                oLogistico.Persona.FechaModificacion = VariablesLocales.FechaHoy;

                oLogistico.UsuarioRegistro = txtUsuRegistra.Text;
                oLogistico.FechaRegistro = VariablesLocales.FechaHoy;
                oLogistico.UsuarioModificacion = txtUsuModifica.Text;
                oLogistico.FechaModificacion = VariablesLocales.FechaHoy;
            }
            else
            {
                oLogistico.Persona.UsuarioModificacion = txtUsuModifica.Text;
                oLogistico.Persona.FechaModificacion = VariablesLocales.FechaHoy;

                oLogistico.UsuarioModificacion = txtUsuModifica.Text;
                oLogistico.FechaModificacion = VariablesLocales.FechaHoy; ;
            }
        }

        void CargarDatos()
        {
            // Personas
            cboTipoPersona.SelectedValue = oLogistico.Persona.TipoPersona;
            cboTipoPersona_SelectionChangeCommitted(new object(), new EventArgs());

            txtRazon.Text = oLogistico.Persona.RazonSocial;
            txtRuc.Text = oLogistico.Persona.RUC;

            txtApePat.Text = oLogistico.Persona.ApePaterno;
            txtApeMat.Text = oLogistico.Persona.ApeMaterno;
            txtNombres.Text = oLogistico.Persona.Nombres;
            cboTipoDocumento.SelectedValue = oLogistico.Persona.TipoDocumento;
            txtTelefonos.Text = oLogistico.Persona.Telefonos;
            txtFax.Text = oLogistico.Persona.Fax;
            txtCorreo.Text = oLogistico.Persona.Correo;
            txtWeb.Text = oLogistico.Persona.Web;
            txtDireccion.Text = oLogistico.Persona.DireccionCompleta;

            // Operador Logístico
            txtComercial.Text = oLogistico.SiglaComercial;

            if (oLogistico.indBaja)
            {
                chkBaja.Checked = true;
                txtFecBaja.Text = oLogistico.fecBaja.ToString();
            }

            // Auditoria
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
            {
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                txtUsuRegistra.Text = oLogistico.UsuarioRegistro;
                txtRegistro.Text = oLogistico.FechaRegistro.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();
            }
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
            pnlDireccion.Enabled = Flag;
            pnlCondicion.Enabled = Flag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            //FrmDlgPersona oFrm = new FrmDlgPersona();
            //oFrm.Enumerado = EnumTipoRolPersona.Proveedor;

            //if (oFrm.ShowDialog() == DialogResult.OK)
            //{
            //    BloquearPaneles(true);

            //    if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
            //    {
            //        EProveedor = oFrm.vProveedor;
            //        EProveedor.Persona = new Persona();
            //        EProveedor.Persona = oFrm.persona;

            //        txtIdProveedor.Text = "0";

            //        EProveedor.TipoProveedor = Convert.ToInt32(cboTipoProveedor.SelectedValue);
            //        EProveedor.tipConstitucion = 0;
            //        EProveedor.catProveedor = 0;
            //        EProveedor.tipRegimen = 0;

            //        EProveedor.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            //        EProveedor.FechaRegistro = VariablesLocales.FechaHoy;
            //        EProveedor.Persona.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            //        EProveedor.Persona.FechaRegistro = VariablesLocales.FechaHoy;

            //        EProveedor.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            //        EProveedor.FechaModificacion = VariablesLocales.FechaHoy;
            //        EProveedor.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            //        EProveedor.Persona.FechaModificacion = VariablesLocales.FechaHoy;

            //    }
            //    else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            //    {
            //        EProveedor = oFrm.vProveedor;
            //        EProveedor.Persona = new Persona();
            //        EProveedor.Persona = oFrm.persona;

            //        UbigeoE EUbigeo = new UbigeoE();
            //        EUbigeo = AgenteMaestro.Proxy.RecuperarUbigeoPorId(EPersona.idUbigeo.ToString());
            //        txtIdProveedor.Text = EProveedor.Persona.IdPersona.ToString("0000000000");

            //        if (EUbigeo.Departamento != null)
            //        {
            //            cboDepartamento.SelectedValue = EUbigeo.Departamento;
            //            cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
            //            cboProvincia.SelectedValue = EUbigeo.Provincia;
            //            cboProvincia_SelectionChangeCommitted(new Object(), new EventArgs());
            //            cboDistrito.SelectedValue = EPersona.idUbigeo;
            //        }

            //        EProveedor.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            //        EProveedor.FechaRegistro = VariablesLocales.FechaHoy;

            //        EProveedor.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            //        EProveedor.Persona.FechaModificacion = VariablesLocales.FechaHoy;
            //    }
            //    else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Actualizar))
            //    {
            //        EProveedor = oFrm.vProveedor;
            //        EProveedor.Persona = new Persona();
            //        EProveedor.Persona = oFrm.persona;

            //        UbigeoE EUbigeo = new UbigeoE();
            //        EUbigeo = AgenteMaestro.Proxy.RecuperarUbigeoPorId(EPersona.idUbigeo.ToString());

            //        if (EUbigeo.Departamento != null)
            //        {
            //            cboDepartamento.SelectedValue = EUbigeo.Departamento;
            //            cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
            //            cboProvincia.SelectedValue = EUbigeo.Provincia;
            //            cboProvincia_SelectionChangeCommitted(new Object(), new EventArgs());
            //            cboDistrito.SelectedValue = EPersona.idUbigeo;
            //        }

            //        if (EProveedor.indBaja == Variables.valorSI)
            //        {
            //            chkBaja.Checked = true;
            //            txtFecBaja.Text = EProveedor.fecBaja.ToString();
            //        }

            //        txtIdProveedor.Text = EProveedor.Persona.IdPersona.ToString("0000000000");
            //        EProveedor.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            //        EProveedor.FechaModificacion = VariablesLocales.FechaHoy;
            //        EProveedor.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            //        EProveedor.Persona.FechaModificacion = VariablesLocales.FechaHoy;
            //    }

            //    bsProveedor.DataSource = EProveedor;
            //    bsPersona.DataSource = EProveedor.Persona;
            //    bsPersona.ResetBindings(false);
            //    bsProveedor.ResetBindings(false);
            //    bFlag = true;

            //    base.Nuevo();
            //}
        }

        public override void Grabar()
        {
            try
            {
                if (oLogistico != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oLogistico = AgenteMaestro.Proxy.GrabarOpeLogistico(oLogistico, EnumOpcionGrabar.Insertar);
                            txtIdOperador.Text = oLogistico.idPersona.ToString("000000");
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oLogistico = AgenteMaestro.Proxy.GrabarOpeLogistico(oLogistico, EnumOpcionGrabar.InsertarSimple);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oLogistico = AgenteMaestro.Proxy.GrabarOpeLogistico(oLogistico, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }

                    BloquearPaneles(false);
                }

                base.Grabar();
                //pnlAuditoria.Focus();
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Editar()
        {
            BloquearPaneles(true);
            base.Editar();
            //BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
        }

        public override void Cancelar()
        {
            BloquearPaneles(false);
            base.Cancelar();
            //BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
        }

        public override void Cerrar()
        {
            base.Cerrar();
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<OpeLogisticoE>(oLogistico);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (Convert.ToInt32(cboTipoPersona.SelectedValue) == (Int32)enumTipoPersona.Juridica || Convert.ToInt32(cboTipoPersona.SelectedValue) == (Int32)enumTipoPersona.Natural_Ruc)
            {
                if (String.IsNullOrEmpty(txtRuc.Text))
                {
                    Global.MensajeFault("Tiene que colocar el número de RUC.");
                    return false;
                }

                if (txtRuc.Text.Length != Variables.NroCaracteresRUC)
                {
                    Global.MensajeFault("El N° de RUC tiene que tener 11 caracteres.");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmOperadorLogistico_Load(object sender, EventArgs e)
        {
            Grid = false;
            EsNuevoRegistro();
        }

        private void frmOperadorLogistico_Activated(object sender, EventArgs e)
        {

        }

        private void cboDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LlenarProvincias(cboDepartamento.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LlenarDistritos(cboDepartamento.SelectedValue.ToString(), cboProvincia.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboTipoPersona_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Int32 tipPersona = Convert.ToInt32(cboTipoPersona.SelectedValue);

            switch (tipPersona)
            {
                case 102001: //Personas Juridicas
                    txtRazon.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtComercial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtApePat.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtApeMat.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNombres.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                    break;
                case 102002: //Personas Natural con Ruc
                    txtRazon.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtComercial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtApePat.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtApeMat.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNombres.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                    break;
                case 102003: //Personas Natural sin Ruc
                    txtRazon.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtComercial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtApePat.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtApeMat.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNombres.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                    break;
                case 102004: //Otros

                    txtRazon.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtComercial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtApePat.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtApeMat.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNombres.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                    break;
                default:

                    txtRazon.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtComercial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtApePat.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtApeMat.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNombres.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);

                    break;
            }

            LlenarTipoDocumento();
            cboTipoDocumento_SelectionChangeCommitted(new object(), new EventArgs());
        }

        private void cboTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Int32 tipDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);

            switch (tipDocumento)
            {
                //case 101001: //DNI

                //    if (Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc))
                //    {
                //        btSunat.Enabled = false;
                //        txtRuc.Enabled = false;
                //        txtRuc.BackColor = SystemColors.InactiveCaption;
                //    }
                //    else if (Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Ruc))
                //    {
                //        btSunat.Enabled = true;
                //        txtRuc.Enabled = true;
                //        txtRuc.BackColor = Color.White;
                //    }

                //    break;

                //case 101002: //Carnet de Extranjeria

                //    btSunat.Enabled = false;
                //    txtRuc.Enabled = false;
                //    txtRuc.BackColor = SystemColors.InactiveCaption;

                //    break;
                //case 101003: //Cedula Diplomatica de Identidad

                //    btSunat.Enabled = false;
                //    txtRuc.Enabled = false;
                //    txtRuc.BackColor = SystemColors.InactiveCaption;

                //    break;

                case 101004: //RUC

                    if (Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Juridica))
                    {
                        btSunat.Enabled = true;
                        txtRuc.Enabled = true;
                        txtRuc.BackColor = Color.White;

                        //txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
                        //txtNroDocumento.MaxLength = 8;
                    }
                    else if (Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Ruc))
                    {
                        btSunat.Enabled = true;
                        txtRuc.Enabled = true;
                        txtRuc.BackColor = Color.White;
                    }

                    break;
                //case 101005: //Otros

                //    btSunat.Enabled = false;
                //    txtRuc.Enabled = false;
                //    txtRuc.BackColor = SystemColors.InactiveCaption;

                //    break;

                //case 101006: //Pasaporte

                //    btSunat.Enabled = false;
                //    txtRuc.Enabled = false;
                //    txtRuc.BackColor = SystemColors.InactiveCaption;

                //    break;

                default:

                    break;
            }
        }

        private void btSunat_Click(object sender, EventArgs e)
        {
            String sDir = String.Empty;
            String dirTemp = String.Empty;
            String sDep = String.Empty;
            String sPro = String.Empty;
            String sDis = String.Empty;
            String RazonSocial = String.Empty;

            int num = 0;
            //int index = 0;

            frmBuscarRuc oFrm = new frmBuscarRuc();
            List<String> ListaUbigeo;

            if (RevisarNroDocumento(txtRuc.Text, "ruc") == false)
            {
                txtRuc.Focus();
                return;
            }

            oFrm.Ruc = txtRuc.Text;

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Informacion != null)
            {
                switch (Convert.ToInt32(cboTipoPersona.SelectedValue))
                {
                    case 102001: //Personas Juridicas
                        txtRuc.Text = oFrm.Ruc;
                        txtRazon.Text = oFrm.RazonSocial;
                        txtComercial.Text = oFrm.NomComercial;
                        sDir = oFrm.Direccion;

                        for (int i = 0; i < cboDepartamento.Items.Count; i++)
                        {
                            num = sDir.IndexOf(cboDepartamento.GetItemText(cboDepartamento.Items[i]));

                            if (num >= 20)
                            {
                                dirTemp = Global.Extraer(sDir, num);
                                ListaUbigeo = new List<String>(dirTemp.Split('-'));

                                num = ListaUbigeo[0].IndexOf(")");

                                if (num > 0)
                                {
                                    ListaUbigeo[0] = ListaUbigeo[0].Substring(num + 1);
                                }

                                if (ListaUbigeo.Count != 0)
                                {
                                    sDep = ListaUbigeo[0].Trim().ToString();
                                    sPro = ListaUbigeo[1].ToString().Trim();
                                    sDis = ListaUbigeo[2].Trim().ToString();

                                    cboDepartamento.SelectedValue = sDep.Trim();
                                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                                    cboProvincia.SelectedValue = sPro.Trim();
                                    cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
                                    cboDistrito.Text = sDis.Trim();

                                    break;
                                }
                            }
                        }

                        sDir = sDir.Replace(sDep + " - " + sPro + " - " + sDis, String.Empty);
                        sDir = sDir.Replace(sDep + "  - " + sPro + "  - " + sDis, String.Empty);
                        txtDireccion.Text = sDir.Trim();
                        txtTelefonos.Text = oFrm.Telefonos;

                        break;

                    case 102002: //Personas Natural con Ruc

                        txtRuc.Text = oFrm.Ruc;
                        txtRazon.Text = oFrm.RazonSocial;
                        txtComercial.Text = oFrm.NomComercial;

                        if (oFrm.Avisar)
                        {
                            txtApePat.Text = oFrm.ApellidosPaternos;
                            txtApeMat.Text = oFrm.ApellidosMaternos;
                            txtNombres.Text = oFrm.nombres;
                        }
                        else
                        {
                            List<String> NombreApellidos = new List<String>(RazonSocial.Split(' '));

                            if (NombreApellidos.Count() == 4)
                            {
                                txtApePat.Text = NombreApellidos[0];
                                txtApeMat.Text = NombreApellidos[1];
                                txtNombres.Text = NombreApellidos[2] + " " + NombreApellidos[3];
                            }
                            else if (NombreApellidos.Count() == 3)
                            {
                                txtApePat.Text = NombreApellidos[0];
                                txtApeMat.Text = NombreApellidos[1];
                                txtNombres.Text = NombreApellidos[2];
                            }
                            else
                            {
                                txtApePat.Text = String.Empty;
                                txtApeMat.Text = String.Empty;
                                txtNombres.Text = RazonSocial;
                            }
                        }

                        //Direccion
                        sDir = oFrm.Direccion;

                        for (int i = 0; i < cboDepartamento.Items.Count; i++)
                        {
                            num = sDir.IndexOf(cboDepartamento.GetItemText(cboDepartamento.Items[i]));

                            if (num >= 20)
                            {
                                dirTemp = Global.Extraer(sDir, num);
                                ListaUbigeo = new List<String>(dirTemp.Split('-'));

                                num = ListaUbigeo[0].IndexOf(")");

                                if (num > 0)
                                {
                                    ListaUbigeo[0] = ListaUbigeo[0].Substring(num + 1);
                                }

                                if (ListaUbigeo.Count != 0)
                                {
                                    sDep = ListaUbigeo[0].Trim().ToString();
                                    sPro = ListaUbigeo[1].ToString().Trim();
                                    sDis = ListaUbigeo[2].Trim().ToString();

                                    cboDepartamento.SelectedValue = sDep;
                                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                                    cboProvincia.SelectedValue = sPro;
                                    cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
                                    cboDistrito.Text = sDis;
                                }
                            }
                        }

                        sDir = sDir.Replace(sDep + " - " + sPro + " - " + sDis, String.Empty);
                        sDir = sDir.Replace(sDep + "  - " + sPro + "  - " + sDis, String.Empty);
                        txtDireccion.Text = sDir.Trim();
                        txtTelefonos.Text = oFrm.Telefonos;

                        break;
                }

                if (oFrm.EstadoContribuyente.Substring(0, 4).Equals("BAJA") == true || oFrm.EstadoContribuyente == "SUSPENSION TEMPORAL")
                {
                    //EProveedor.indBaja = "S";
                    chkBaja.Checked = true;

                    if (!String.IsNullOrEmpty(oFrm.FechaBaja))
                    {
                        txtFecBaja.Text = oFrm.FechaBaja;
                    }
                    else
                    {
                        txtFecBaja.Text = DateTime.Now.ToString();
                    }
                }
            }
        }

        private void chkBaja_Click(object sender, EventArgs e)
        {
            if (chkBaja.Checked)
            {
                if (string.IsNullOrEmpty(txtFecBaja.Text))
                {
                    oLogistico.fecBaja = DateTime.Now;
                    txtFecBaja.Text = DateTime.Now.ToString();
                }
            }
            else
            {
                txtFecBaja.Text = string.Empty;
            }
        }

        #endregion

    }
}
