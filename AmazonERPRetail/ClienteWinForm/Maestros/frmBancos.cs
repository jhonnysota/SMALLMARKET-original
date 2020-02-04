using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using ClienteWinForm.Busquedas;
using Entidades.Maestros;
using Entidades.Generales;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using ControlesWinForm;

namespace ClienteWinForm.Maestros
{
    public partial class frmBancos : FrmMantenimientoBase
    {

        #region Constructores

        public frmBancos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            FormatoGrid(dgvCuentasBancarias, true);
            LlenarCombos();
        }

        //Nuevo
        public frmBancos(BancosE oBanco_, Persona persona, Int32 Opcion)
            : this()
        {
            oBanco = oBanco_;
            oPersona = persona;
            OpcionGrabar = Opcion;
        }

        //Edición
        public frmBancos(BancosE oBanco_, Int32 Opcion)
            :this()
        {
            oBanco = oBanco_;
            OpcionGrabar = Opcion;
        }

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }

        public BancosE oBanco = null;
        public Int32 OpcionGrabar;
        Persona oPersona = null;
        String idUbigeo = String.Empty;
        String sNroDocumento = String.Empty;
        UbigeoE EUbigeo = new UbigeoE();

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            List<EnumParTabla> ListaParTabla = new List<EnumParTabla>
            {
                EnumParTabla.TipoPersona,
                EnumParTabla.TipoContribuyente
            };

            Dictionary<EnumParTabla, List<ParTabla>> ListaParametros = AgenteGeneral.Proxy.ListarParTablaPorListaGrupo(ListaParTabla);

            //TIPO PERSONA
            ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoPersona, ListaParametros[EnumParTabla.TipoPersona], "IdParTabla", "Nombre");
            ListaParametros[EnumParTabla.TipoContribuyente].Add(new ParTabla { IdParTabla = 0, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoPersona, ListaParametros[EnumParTabla.TipoPersona], "IdParTabla", "Nombre");

            List<UbigeoE> ListaDepartamento = AgenteMaestros.Proxy.ListarDepartamentos();
            ListaDepartamento.Add(new UbigeoE { Departamento = Variables.SeleccionDepartamento });
            ComboHelper.LlenarCombos<UbigeoE>(cboDepartamento, (from x in ListaDepartamento orderby x.Departamento select x).ToList(), "Departamento", "Departamento");

            cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
            cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
        }

        void LlenarProvincias(String Departamento)
        {
            List<UbigeoE> ListaProvincias = AgenteMaestros.Proxy.ListarProvincias(Departamento);
            ListaProvincias.Add(new UbigeoE { Provincia = Variables.SeleccioneProvincia });
            ComboHelper.LlenarCombos<UbigeoE>(cboProvincia, (from x in ListaProvincias orderby x.Provincia select x).ToList(), "Provincia", "Provincia");

            cboProvincia.SelectedValue = Variables.SeleccioneProvincia;
            cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
        }

        void LlenarDistritos(String Departamento, String Provincia)
        {
            List<UbigeoE> ListaDistritos = AgenteMaestros.Proxy.ListarDistritos(Departamento, Provincia);
            ListaDistritos.Add(new UbigeoE { idUbigeo = Variables.Cero.ToString(), Distrito = Variables.SeleccioneDistrito });

            ComboHelper.LlenarCombos<UbigeoE>(cboDistrito, (from x in ListaDistritos orderby x.idUbigeo select x).ToList(), "idUbigeo", "Distrito");
            cboDistrito.SelectedValue = Variables.Cero.ToString();
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

                //cboTipoDocumento.Enabled = false;
            }
            else
            {
                cboTipoDocumento.DataSource = null;
                //cboTipoDocumento.Enabled = false;
            }
        }

        Boolean RevisarNroDocumento(String numero)
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
                    Global.MensajeComunicacion(String.Format("El número de digitos de {0} es incorrecto...", numero));
                    return false;
                }
            }

            return true;
        }

        Boolean validaExitePersonaEnBanco()
        {

            if (oBanco.idPersona == 0)
            {
                BancosE oBancoExiste = AgenteMaestros.Proxy.RecuperarBancoPorRUC(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtRuc.Text);

                if (oBancoExiste == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        Boolean validaExiteRucEnPersona()
        {
            Boolean oValida = false;

            Persona oPersona = AgenteMaestros.Proxy.RecuperarPersonaPorRUC(Convert.ToInt32(cboTipoDocumento.SelectedValue.ToString()), txtRuc.Text);

            if (oBanco.Persona != null )
            {
                if (oPersona != null)
                {
                    if (oBanco.Persona.IdPersona != oPersona.IdPersona)
                    {
                        return true;
                    }
                }
                
            }

            return oValida;
        }

        void GuardarDatos()
        {
            String Direccion = String.Empty;

            //Persona
            oBanco.Persona.TipoPersona = Convert.ToInt32(cboTipoPersona.SelectedValue);
            oBanco.Persona.RazonSocial = txtRazon.Text.Trim();
            oBanco.Persona.RUC = txtRuc.Text;
            oBanco.Persona.NroDocumento = txtRuc.Text;

            oBanco.Persona.ApePaterno = String.Empty;
            oBanco.Persona.ApeMaterno = String.Empty;
            oBanco.Persona.Nombres = String.Empty;
            oBanco.Persona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
            oBanco.Persona.Telefonos = txtTelefonos.Text.Trim();
            oBanco.Persona.Fax = txtFax.Text;
            oBanco.Persona.Correo = txtCorreo.Text;
            oBanco.Persona.Web = txtWeb.Text;

            Direccion = txtDireccion.Text.Trim();
            oBanco.Persona.DireccionCompleta = Direccion.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, "");
            oBanco.Persona.idPais = 90; //Perú
            oBanco.Persona.idUbigeo = cboDistrito.SelectedValue.ToString();
            oBanco.Persona.AgenteRetenedor = false;

            //Banco
            oBanco.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            oBanco.SiglaComercial = txtComercial.Text.Trim();
            oBanco.codSunat = txtcodSunat.Text.Trim();
            oBanco.indBaja = chkBaja.Checked;
            oBanco.fecBaja = chkBaja.Checked ? Convert.ToDateTime(txtFecBaja.Text) : (Nullable<DateTime>)null;

            //Auditoria
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
            {
                oBanco.Persona.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oBanco.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            {
                oBanco.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oBanco.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oBanco.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oBanco.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void CargarDatos()
        {
            // Personas
            cboTipoPersona.SelectedValue = oBanco.Persona.TipoPersona;
            cboTipoPersona_SelectionChangeCommitted(new object(), new EventArgs());

            txtRazon.Text = oBanco.Persona.RazonSocial;
            txtRuc.Text = oBanco.Persona.RUC;
            cboTipoDocumento.SelectedValue = oBanco.Persona.TipoDocumento;
            txtTelefonos.Text = oBanco.Persona.Telefonos;
            txtFax.Text = oBanco.Persona.Fax;
            txtCorreo.Text = oBanco.Persona.Correo;
            txtWeb.Text = oBanco.Persona.Web;
            txtDireccion.Text = oBanco.Persona.DireccionCompleta;

            //Banco
            txtComercial.Text = oBanco.SiglaComercial;
            txtcodSunat.Text = oBanco.codSunat;

            if (oBanco.indBaja)
            {
                chkBaja.Checked = true;
                txtFecBaja.Text = oBanco.fecBaja.ToString();
            }
            else
            {
                chkBaja.Checked = false;
                txtFecBaja.Text = String.Empty;
            }

            //Auditoria
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar) || OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            {
                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                txtUsuRegistro.Text = oBanco.UsuarioRegistro;
                txtFechaRegistro.Text = oBanco.FechaRegistro.ToString();
                txtUsuModificacion.Text = oBanco.UsuarioModificacion;
                txtFechaModificacion.Text = oBanco.FechaModificacion.ToString();
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, BancosCuentasE oCuentaBanco)
        {
            try
            {
                if (bsCuentasBancarias.Count > 0)
                {
                    Boolean Modificar = true;

                    frmBancoCuenta oFrm = new frmBancoCuenta(oCuentaBanco, Modificar);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oBancoCuenta != null)
                    {
                        oBanco.ListaCuentas[e.RowIndex] = oFrm.oBancoCuenta;
                        bsCuentasBancarias.DataSource = oBanco.ListaCuentas;
                        bsCuentasBancarias.ResetBindings(false);
                        base.AgregarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
            {
                oBanco = new BancosE
                {
                    Persona = oPersona
                };

                txtIdBanco.Text = oBanco.Persona.IdPersona.ToString();
                cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
                cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());

                CargarDatos();
            }
            else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            {
                oBanco = new BancosE
                {
                    Persona = oPersona
                };

                txtIdBanco.Text = oBanco.Persona.IdPersona.ToString("000000");
                UbigeoE EUbigeo = AgenteMaestros.Proxy.RecuperarUbigeoPorId(oPersona.idUbigeo.ToString());

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
                //Persona y Proveedor solo se actualiza
                if (oBanco.Persona.IdPersona == 0)
                {
                    oBanco.Persona = new Persona();
                    oBanco.Persona = oPersona;
                }

                txtIdBanco.Text = oBanco.Persona.IdPersona.ToString("000000");
                UbigeoE EUbigeo = AgenteMaestros.Proxy.RecuperarUbigeoPorId(oBanco.Persona.idUbigeo.ToString());

                if (EUbigeo.Departamento != null)
                {
                    cboDepartamento.SelectedValue = EUbigeo.Departamento;
                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                    cboProvincia.SelectedValue = EUbigeo.Provincia;
                    cboProvincia_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboDistrito.SelectedValue = oBanco.Persona.idUbigeo;
                }
                else
                {
                    cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                }

                CargarDatos();
            }

            bsCuentasBancarias.DataSource = oBanco.ListaCuentas;
            bsCuentasBancarias.ResetBindings(false);

            base.Nuevo();
        }

        public override void AgregarDetalle()
        {
            try
            {
                frmBancoCuenta oFrm = new frmBancoCuenta();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oBancoCuenta != null)
                {
                    BancosCuentasE oCuentaBanco = oFrm.oBancoCuenta;
                    
                    oBanco.ListaCuentas.Add(oCuentaBanco);
                    bsCuentasBancarias.DataSource = oBanco.ListaCuentas;
                    bsCuentasBancarias.ResetBindings(false);
                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            if (bsCuentasBancarias.Current != null)
            {
                if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                {
                    oBanco.ListaCuentas.RemoveAt(bsCuentasBancarias.Position);
                    bsCuentasBancarias.DataSource = oBanco.ListaCuentas;
                    bsCuentasBancarias.ResetBindings(false);
                    base.QuitarDetalle();
                }
            }
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<BancosE>(oBanco);

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

            if (txtRuc.Text.Trim().Length == 0)
            {
                Global.MensajeAdvertencia("Debe de ingresar el RUC");
                return false;
            }
            else if (txtRazon.Text.Trim().Length == 0)
            {
                Global.MensajeAdvertencia("Debe de ingresar la Razón Social");
                return false;
            }
            else if (validaExiteRucEnPersona())
            {
                Global.MensajeAdvertencia("El Ruc ya esta existe en otro registro");
                return false;
            }
            else if (validaExitePersonaEnBanco())
            {
                Global.MensajeAdvertencia("El Ruc ya esta ingresado en banco");
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void Grabar()
        {
            try
            {
                bsCuentasBancarias.EndEdit();
                GuardarDatos();

                if (!ValidarGrabacion())
                {
                    return;
                }

                if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        oBanco = AgenteMaestros.Proxy.GrabarBanco(oBanco, EnumOpcionGrabar.Insertar);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        oBanco = AgenteMaestros.Proxy.GrabarBanco(oBanco, EnumOpcionGrabar.InsertarSimple);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        oBanco = AgenteMaestros.Proxy.GrabarBanco(oBanco, EnumOpcionGrabar.Actualizar);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmBancos_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();

                //if (oBanco == null)
                //{
                //    oBanco = new BancosE();
                //    oBanco.idPersona = 0;
                //    oBanco.idEmpresa = 0;
                //}

                //LlenarTipoDocumento();

                //if (oBanco.idPersona != 0 && oBanco.idEmpresa != 0)
                //{
                //    cboTipoPersona.SelectedValue = oBanco.Persona.TipoPersona;               
                //    cboDepartamento.SelectedValue = EUbigeo.Departamento;
                //    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                //    cboProvincia.SelectedValue = EUbigeo.Provincia;
                //    cboProvincia_SelectionChangeCommitted(new Object(), new EventArgs());
                //    cboDistrito.SelectedValue = oBanco.Persona.idUbigeo;

                //    // SISTEMA
                //    txtUsuRegistro.Text = oBanco.UsuarioRegistro;
                //    txtFechaRegistro.Text = oBanco.FechaRegistro.ToString();
                //    txtUsuModificacion.Text = oBanco.UsuarioModificacion;
                //    txtFechaModificacion.Text = oBanco.FechaModificacion.ToString();
                //}
                //else 
                //{   
                //    txtIdCliente.Text = oBanco.idPersona.ToString();

                //    txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                //    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                //    txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                //    txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
                //}

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
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

            Int32 num = 0;
            //Int32 index = 0;

            frmBuscarRuc oFrm = new frmBuscarRuc();
            List<String> ListaUbigeo;

            if (RevisarNroDocumento(txtRuc.Text) == false)
            {
                txtRuc.Focus();
                return;
            }

            oFrm.Ruc = txtRuc.Text;

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Informacion != null)
            {                
                txtRuc.Text = oFrm.Ruc;
                txtRazon.Text = oFrm.RazonSocial;
                txtComercial.Text = oFrm.NomComercial;
                sDir = oFrm.Direccion;

                for (Int32 i = 0; i < cboDepartamento.Items.Count; i++)
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
                //dtpActividades.Value = Convert.ToDateTime(oFrm.FechaActividades);
                //dtpInscripcion.Value = Convert.ToDateTime(oFrm.FechaInscripcion);
                txtTelefonos.Text = oFrm.Telefonos;

                //index = cboConstitucion.FindString(oFrm.TipoContribuyente.Trim());
                //cboConstitucion.SelectedIndex = index;

                if (oFrm.EstadoContribuyente.Substring(0, 4).Equals("BAJA") == true || oFrm.EstadoContribuyente == "SUSPENSION TEMPORAL")
                {
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

                LlenarTipoDocumento();
            }
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
            LlenarTipoDocumento();
            cboTipoDocumento_SelectionChangeCommitted(new object(), new EventArgs());
        }

        private void cboTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Juridica))
            {
                //btSunat.Enabled = true;
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRuc.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
                txtRuc.MaxLength = 11;
            }
            else
            {
                Global.MensajeFault("El banco solo puede ser una Persona Jurídica");
            }
        }

        private void dgvCuentasBancarias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, (BancosCuentasE)bsCuentasBancarias.Current);
            }
        }

        private void chkBaja_Click(object sender, EventArgs e)
        {
            if (chkBaja.Checked)
            {
                if (string.IsNullOrEmpty(txtFecBaja.Text))
                {
                    oBanco.fecBaja = DateTime.Now;
                    txtFecBaja.Text = DateTime.Now.ToString();
                }
            }
            else
            {
                txtFecBaja.Text = String.Empty;
            }
        }

        private void frmBancos_Shown(object sender, EventArgs e)
        {
            txtRuc.Focus();
        }

        #endregion 

    }
}
