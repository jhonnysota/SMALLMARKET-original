using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Generales;
using Entidades.Ventas;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Maestros
{
    public partial class frmVendedor : FrmMantenimientoBase
    {

        #region Constructores

        public frmVendedor()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            LlenarCombos();
        }

        public frmVendedor(VendedoresE oVendedor_, Persona persona, Int32 Opcion)
            :this()
        {
            oVendedor = oVendedor_;
            oPersona = persona;
            OpcionGrabar = Opcion;
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }

        VendedoresE oVendedor = null;
        Persona oPersona = null;
        Int32 OpcionGrabar;
        String idUbigeo = String.Empty;
        String sNroDocumento = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            List<UbigeoE> ListaDepartamento = AgenteMaestro.Proxy.ListarDepartamentos();
            ListaDepartamento.Add(new UbigeoE() { Departamento = Variables.SeleccionDepartamento });
            ComboHelper.LlenarCombos<UbigeoE>(cboDepartamento, (from x in ListaDepartamento orderby x.Departamento select x).ToList(), "Departamento", "Departamento");

            List<ParTabla> oListaDivisiones = AgenteGeneral.Proxy.ListarParTablaPorNemo("DIVI");
            oListaDivisiones.Add(new ParTabla() { IdParTabla = 0, Nombre = Variables.Seleccione });
            ComboHelper.LlenarCombos<ParTabla>(cboDivision, (from x in oListaDivisiones orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");

            //Establecimientos
            List<EstablecimientosE> oListaEstablecimientos = AgenteMaestro.Proxy.ListarEstablecimientos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
            oListaEstablecimientos.Add(new EstablecimientosE() { idEstablecimiento = Variables.Cero, Descripcion = Variables.Seleccione });
            ComboHelper.LlenarCombos<EstablecimientosE>(cboEstablecimiento, (from x in oListaEstablecimientos orderby x.idEstablecimiento select x).ToList(), "idEstablecimiento", "Descripcion");
        }

        void LlenarProvincias(String Departamento)
        {
            List<UbigeoE> ListaProvincias = AgenteMaestro.Proxy.ListarProvincias(Departamento);
            UbigeoE CampoInicial = new UbigeoE() { Provincia = Variables.SeleccioneProvincia };
            ListaProvincias.Add(CampoInicial);
            ComboHelper.LlenarCombos<UbigeoE>(cboProvincia, (from x in ListaProvincias orderby x.Provincia select x).ToList(), "Provincia", "Provincia");

            cboProvincia.SelectedValue = Variables.SeleccioneProvincia;
            cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
        }

        void LlenarDistritos(String Departamento, String Provincia)
        {
            List<UbigeoE> ListaDistritos = AgenteMaestro.Proxy.ListarDistritos(Departamento, Provincia);
            UbigeoE CampoInicial = new UbigeoE() { idUbigeo = Variables.Cero.ToString(), Distrito = Variables.SeleccioneDistrito };
            ListaDistritos.Add(CampoInicial);

            ComboHelper.LlenarCombos<UbigeoE>(cboDistrito, (from x in ListaDistritos orderby x.idUbigeo select x).ToList(), "idUbigeo", "Distrito");
            cboDistrito.SelectedValue = Variables.Cero.ToString();
        }

        void GuardarDatos()
        {
            String Direccion = String.Empty;

            oVendedor.Persona.RazonSocial = txtApePat.Text.Trim() + " " + txtApeMat.Text.Trim() + " " + txtNombres.Text.Trim();
            oVendedor.Persona.ApePaterno = txtApePat.Text;
            oVendedor.Persona.ApeMaterno = txtApeMat.Text;
            oVendedor.Persona.Nombres = txtNombres.Text;
            oVendedor.Persona.Telefonos = txtTelefonos.Text.Trim();
            oVendedor.Persona.Correo = txtCorreo.Text.Trim();
            Direccion = txtDireccion.Text.Trim();
            oVendedor.Persona.DireccionCompleta = Direccion.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, "");
            oVendedor.Persona.idUbigeo = cboDistrito.SelectedValue.ToString();
            oVendedor.codVendedor = txtCodVendedor.Text;
            oVendedor.indSupervisor = indSup.Checked;
            oVendedor.ManejaCartera = chkCarteraClientes.Checked;
            oVendedor.idDivision = Convert.ToInt32(cboDivision.SelectedValue);
            oVendedor.idEstablecimiento = Convert.ToInt32(cboEstablecimiento.SelectedValue);
            oVendedor.idZona = cboZona.SelectedValue != null ? Convert.ToInt32(cboZona.SelectedValue) : (Int32?)null;

            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
            {
                oVendedor.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oPersona.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }

            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            {
                oVendedor.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oPersona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }

            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Actualizar))
            {
                oVendedor.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oPersona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void CargarDatos()
        {
            txtIdVendedor.Text = oVendedor.Persona.IdPersona.ToString();
            txtNroDocumento.Text = oVendedor.Persona.NroDocumento;
      
            // Personas
            txtApePat.Text = oVendedor.Persona.ApePaterno;
            txtApeMat.Text = oVendedor.Persona.ApeMaterno;
            txtNombres.Text = oVendedor.Persona.Nombres;
            txtTelefonos.Text = oVendedor.Persona.Telefonos;
            txtCorreo.Text = oVendedor.Persona.Correo;
            txtDireccion.Text = oVendedor.Persona.DireccionCompleta;
            txtCodVendedor.Text = oVendedor.codVendedor; 

            if (oVendedor.indEstado)
            {
                chkBaja.Checked = true;
                txtFecBaja.Text = oVendedor.fecBaja.ToString();
            }
            else
            {
                chkBaja.Checked = false;
                txtFecBaja.Text = String.Empty;
            }

            indSup.Checked = oVendedor.indSupervisor;
            chkCarteraClientes.Checked = oVendedor.ManejaCartera;
            cboDivision.SelectedValue = Convert.ToInt32(oVendedor.idDivision);
            if (oVendedor.idEstablecimiento != null)
            {
                cboEstablecimiento.SelectedValue = oVendedor.idEstablecimiento;
                cboEstablecimiento_SelectionChangeCommitted(new Object(), new EventArgs());
            }
           

            //Auditoria
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
            {
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();
            }
            else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Actualizar))
            {
                txtUsuRegistra.Text = oVendedor.UsuarioRegistro;
                txtRegistro.Text = oVendedor.FechaRegistro.ToString();
                txtUsuModifica.Text = oVendedor.UsuarioModificacion;
                txtModifica.Text = oVendedor.FechaModificacion.ToString();
            }
            else
            {
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();
            }

            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Actualizar))
            { 
                txtCodVendedor.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
            pnlDireccion.Enabled = Flag;
            //pnlNaturaleza.Enabled = Flag;
            pnlCondicion.Enabled = Flag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
            {
                oVendedor = new VendedoresE
                {
                    Persona = oPersona,
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idEstablecimiento = 0
                };

                cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
                cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());

                CargarDatos();
            }
            else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            {
                oVendedor = new VendedoresE
                {
                    Persona = oPersona,
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                };

                UbigeoE EUbigeo = AgenteMaestro.Proxy.RecuperarUbigeoPorId(oPersona.idUbigeo.ToString());

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
                oVendedor.Persona = oPersona;

                UbigeoE EUbigeo = AgenteMaestro.Proxy.RecuperarUbigeoPorId(oPersona.idUbigeo.ToString());

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
                Text = "Vendendores (" + oVendedor.Persona.RazonSocial + ")";
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oVendedor != null)
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
                            oVendedor = AgenteMaestro.Proxy.GrabarVendedor(oVendedor, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oVendedor = AgenteMaestro.Proxy.GrabarVendedor(oVendedor, EnumOpcionGrabar.InsertarSimple);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oVendedor = AgenteMaestro.Proxy.GrabarVendedor(oVendedor, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }

                    BloquearPaneles(false);
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

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<VendedoresE>(oVendedor);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (String.IsNullOrEmpty(txtNroDocumento.Text))
            {
                Global.MensajeFault("Tiene que colocar el número de documento.");
                return false;
            }

            if (String.IsNullOrEmpty(txtNombres.Text))
            {
                Global.MensajeFault("Tiene que colocar el nombre Del Vendedor.");
                return false;
            }

            if (oVendedor.Persona.IdPersona == 102003) //Solamente si es DNI
            {
                if (String.IsNullOrEmpty(txtApePat.Text))
                {
                    Global.MensajeFault("Tiene que colocar el Apellido Paterno del Vendedor.");
                    return false;
                }

                if (String.IsNullOrEmpty(txtApeMat.Text))
                {
                    Global.MensajeFault("Tiene que colocar el Apellido Materno del Vendedor.");
                    return false;
                }

                if (txtNroDocumento.Text.Length != Variables.NroCaracteresDNI)
                {
                    Global.MensajeFault("El N° de DNI tiene que tener 8 caracteres.");
                    return false;
                } 
            }

            return base.ValidarGrabacion();
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmVendedor_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
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

        private void btReniec_Click_1(object sender, EventArgs e)
        {
            frmBuscarDni oFrm = new frmBuscarDni();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Informacion != null)
            {
                StringBuilder NombreCompleto = new StringBuilder();
                                     
                txtNroDocumento.Text = oFrm.DNI;
                txtNombres.Text = oFrm.Informacion.Nombres;
                txtApePat.Text = oFrm.Informacion.ApePaterno;
                txtApeMat.Text = oFrm.Informacion.ApeMaterno;

                NombreCompleto.Append(oFrm.Informacion.ApePaterno);
                NombreCompleto.Append(" ");
                NombreCompleto.Append(oFrm.Informacion.ApeMaterno);
                NombreCompleto.Append(" ");
                NombreCompleto.Append(oFrm.Informacion.Nombres);
            }
        }

        private void chkBaja_Click(object sender, EventArgs e)
        {
            if (chkBaja.Checked)
            {
                if (string.IsNullOrEmpty(txtFecBaja.Text))
                {
                    oVendedor.fecBaja = DateTime.Now;
                    txtFecBaja.Text = DateTime.Now.ToString();
                }
            }
            else
            {
                txtFecBaja.Text = String.Empty;
            }
        }

        private void cboEstablecimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (VariablesLocales.oVenParametros.indZona)
                {
                    List<ZonaTrabajoE> oListaZonas = AgenteVentas.Proxy.ListarZonasPorIdEstablecimiento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, Convert.ToInt32(cboEstablecimiento.SelectedValue));
                    ComboHelper.LlenarCombos<ZonaTrabajoE>(cboZona, oListaZonas, "idZona", "Descripcion");

                    if (oListaZonas.Count > Variables.Cero && oListaZonas != null)
                    {
                        //int idZona = (oListaZonas.Where(x => x.Principal == true).Select(s => s.idZona).Single());
                        ZonaTrabajoE oZona = (oListaZonas.Where(x => x.Principal == true).SingleOrDefault());

                        if (oZona != null)
                        {
                            cboZona.SelectedValue = oZona.idZona;
                        }

                        cboZona.Enabled = true;
                    }
                    else
                    {
                        cboZona.DataSource = null;
                        cboZona.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Eventos

    }
}
