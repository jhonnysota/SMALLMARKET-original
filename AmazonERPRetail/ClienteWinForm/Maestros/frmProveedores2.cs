using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using ClienteWinForm.Busquedas;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using ControlesWinForm;

namespace ClienteWinForm.Maestros
{
    public partial class frmProveedores2 : FrmMantenimientoBase
    {

        #region Constructores

        public frmProveedores2()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvContactos, true);
            FormatoGrid(dgvBancosCuentas, true);
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            LlenarCombos();
        }

        //Nuevos
        public frmProveedores2(ProveedorE proveedor, Persona persona, Int32 Opcion)
            : this()
        {
            oProveedor = proveedor;
            oPersona = persona;
            OpcionGrabar = Opcion;
        }

        //Edición
        public frmProveedores2(ProveedorE proveedor, Int32 Opcion)
            : this()
        {
            oProveedor = proveedor;
            OpcionGrabar = Opcion;
        }

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<ProveedorContactoE> oListaEliminados = null;
        List<ProveedorCuentaE> oListaEliminados2 = null;
        public ProveedorE oProveedor = null;
        Persona oPersona = null;
        public Int32 OpcionGrabar;
        String idUbigeo = String.Empty;
        String sNroDocumento = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Enumerando ParTabla
            List<EnumParTabla> ListaParTabla = new List<EnumParTabla>
            {
                EnumParTabla.TipoPersona,
                EnumParTabla.TipoContribuyente,
                EnumParTabla.TipoProveedor,
                EnumParTabla.RegimenEmpresa,
                EnumParTabla.CategoriaEmpresa,
                EnumParTabla.CanalVenta
            };

            Dictionary<EnumParTabla, List<ParTabla>> ListaParametros = AgenteGeneral.Proxy.ListarParTablaPorListaGrupo(ListaParTabla);

            ParTabla addNew = new ParTabla() { IdParTabla = 0, Nombre = Variables.Seleccione };
            ListaParametros[EnumParTabla.TipoContribuyente].Add(addNew);
            ListaParametros[EnumParTabla.RegimenEmpresa].Add(addNew);
            ListaParametros[EnumParTabla.CategoriaEmpresa].Add(addNew);
            ListaParametros[EnumParTabla.CanalVenta].Add(addNew);

            ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoPersona, ListaParametros[EnumParTabla.TipoPersona], "IdParTabla", "Nombre");
            ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoProveedor, ListaParametros[EnumParTabla.TipoProveedor], "IdParTabla", "Nombre");
            ComboHelper.RellenarCombos<List<ParTabla>>(cboConstitucion, (from x in ListaParametros[EnumParTabla.TipoContribuyente] orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");
            ComboHelper.RellenarCombos<List<ParTabla>>(cboRegimen, (from x in ListaParametros[EnumParTabla.RegimenEmpresa] orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");
            ComboHelper.RellenarCombos<List<ParTabla>>(cboCategoria, (from x in ListaParametros[EnumParTabla.CategoriaEmpresa] orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");
            ComboHelper.RellenarCombos<List<ParTabla>>(cboCanal, (from x in ListaParametros[EnumParTabla.CanalVenta] orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");

            //Departamentos
            List<UbigeoE> ListaDepartamento = AgenteMaestro.Proxy.ListarDepartamentos();
            UbigeoE CampoInicial = new UbigeoE() { Departamento = Variables.SeleccionDepartamento };
            ListaDepartamento.Add(CampoInicial);

            ComboHelper.LlenarCombos<UbigeoE>(cboDepartamento, (from x in ListaDepartamento orderby x.Departamento select x).ToList(), "Departamento", "Departamento");

            //Paises
            List<PaisesE> ListarPaises = AgenteGeneral.Proxy.ListarPaises();
            PaisesE p = new PaisesE() { idPais = Variables.Cero, Nombre = Variables.Seleccione };
            ListarPaises.Add(p);

            ComboHelper.LlenarCombos<PaisesE>(cboPaises, (from x in ListarPaises orderby x.idPais select x).ToList(), "idPais", "Nombre");
        }

        void LlenarProvincias(String Departamento)
        {
            List<UbigeoE> ListaProvincias = AgenteMaestro.Proxy.ListarProvincias(Departamento);
            ListaProvincias.Add(new UbigeoE() { Provincia = Variables.SeleccioneProvincia });
            ComboHelper.LlenarCombos<UbigeoE>(cboProvincia, (from x in ListaProvincias orderby x.Provincia select x).ToList(), "Provincia", "Provincia");

            cboProvincia.SelectedValue = Variables.SeleccioneProvincia;
            cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
        }

        void LlenarDistritos(String Departamento, String Provincia)
        {
            List<UbigeoE> ListaDistritos = AgenteMaestro.Proxy.ListarDistritos(Departamento, Provincia);
            ListaDistritos.Add(new UbigeoE() { idUbigeo = "0", Distrito = Variables.SeleccioneDistrito });

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
            else if (Convert.ToString(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Ruc).ToString())
            {
                List<ParTabla> ListaDocumentosNatural = new List<ParTabla>();
                ListaDocumentosNatural = (from x in ListaDocumentos
                                          select x).ToList();
                ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosNatural, "IdParTabla", "Nombre");

                cboTipoDocumento.Enabled = true;
            }//Persona Natural sin Ruc
            else if ((Convert.ToString(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc).ToString()))
            {
                List<ParTabla> ListaDocumentosJuridica = new List<ParTabla>();
                ListaDocumentosJuridica = (from x in ListaDocumentos
                                           where x.IdParTabla == Convert.ToInt32(EnumTipoDocumento.Dni)
                                           select x).ToList();
                ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosJuridica, "IdParTabla", "Nombre");

                cboTipoDocumento.Enabled = false;
            }//Otros
            else if ((Convert.ToString(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Otros).ToString()))
            {
                List<ParTabla> ListaDocumentosNatural = new List<ParTabla>();
                ListaDocumentosNatural = (from x in ListaDocumentos
                                          where (x.IdParTabla != Convert.ToInt32(EnumTipoDocumento.Ruc)) && (x.IdParTabla != Convert.ToInt32(EnumTipoDocumento.Dni))
                                          select x).ToList();
                ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosNatural, "IdParTabla", "Nombre");

                cboTipoDocumento.Enabled = true;
            }
            else
            {
                cboTipoDocumento.DataSource = null;
                cboTipoDocumento.Enabled = false;
            }
        }

        void GuardarDatos()
        {
            String Direccion = String.Empty;

            //Persona
            oProveedor.Persona.TipoPersona = Convert.ToInt32(cboTipoPersona.SelectedValue);

            if (String.IsNullOrEmpty(txtRazon.Text))
            {
                oProveedor.Persona.RazonSocial = txtApePat.Text.Trim() + " " + txtApeMat.Text.Trim() + " " + txtNombres.Text.Trim();
            }
            else
            {
                oProveedor.Persona.RazonSocial = txtRazon.Text.Trim();
            }

            if (Convert.ToInt32(cboTipoPersona.SelectedValue) == (Int32)enumTipoPersona.Juridica)
            {
                oProveedor.Persona.RUC = txtRuc.Text;
                oProveedor.Persona.NroDocumento = txtRuc.Text;
            }
            else if (Convert.ToInt32(cboTipoPersona.SelectedValue) == (Int32)enumTipoPersona.Natural_Ruc)
            {
                oProveedor.Persona.RUC = txtRuc.Text;

                if (string.IsNullOrEmpty(txtNroDocumento.Text.Trim()))
                {
                    oProveedor.Persona.NroDocumento = txtRuc.Text;
                }
                else
                {
                    oProveedor.Persona.NroDocumento = txtNroDocumento.Text;
                }
            }
            else
            {
                oProveedor.Persona.RUC = txtNroDocumento.Text;

                if (string.IsNullOrEmpty(txtNroDocumento.Text.Trim()))
                {
                    oProveedor.Persona.NroDocumento = txtRuc.Text;
                }
                else
                {
                    oProveedor.Persona.NroDocumento = txtNroDocumento.Text;
                }
            }

            oProveedor.Persona.ApePaterno = txtApePat.Text.Trim();
            oProveedor.Persona.ApeMaterno = txtApeMat.Text.Trim();
            oProveedor.Persona.Nombres = txtNombres.Text.Trim();
            oProveedor.Persona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
            oProveedor.Persona.Telefonos = txtTelefonos.Text.Trim();
            oProveedor.Persona.Fax = txtFax.Text;
            oProveedor.Persona.Correo = txtCorreo.Text;
            oProveedor.Persona.Web = txtWeb.Text;

            Direccion = txtDireccion.Text.Trim();
            oProveedor.Persona.DireccionCompleta = Direccion.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, "");
            oProveedor.Persona.idPais = Convert.ToInt32(cboPaises.SelectedValue);
            oProveedor.Persona.idUbigeo = cboDistrito.SelectedValue.ToString();
            oProveedor.Persona.PrincipalContribuyente = chkContribuyente.Checked;
            oProveedor.Persona.idCanalVenta = Convert.ToInt32(cboCanal.SelectedValue) != Variables.Cero ? Convert.ToInt32(cboCanal.SelectedValue) : (Nullable<Int32>)null;

            //Proveedor
            oProveedor.IdEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

            if (String.IsNullOrEmpty(txtComercial.Text))
            {
                oProveedor.SiglaComercial = txtApePat.Text.Trim() + " " + txtApeMat.Text.Trim() + " " + txtNombres.Text.Trim(); 
            }
            else
            {
                oProveedor.SiglaComercial = txtComercial.Text.Trim();
            }
            
            oProveedor.TipoProveedor = Convert.ToInt32(cboTipoProveedor.SelectedValue);
            oProveedor.fecInscripcion = dtpInscripcion.Checked ? dtpInscripcion.Value.Date : (Nullable<DateTime>)null;
            oProveedor.fecInicioActividad = dtpActividades.Checked ? dtpActividades.Value.Date : (Nullable<DateTime>)null;
            oProveedor.tipConstitucion = Convert.ToInt32(cboConstitucion.SelectedValue);
            oProveedor.tipRegimen = Convert.ToInt32(cboRegimen.SelectedValue);
            oProveedor.catProveedor = Convert.ToInt32(cboCategoria.SelectedValue);
            oProveedor.indBaja = chkBaja.Checked ? Variables.SI : Variables.NO;
            oProveedor.fecBaja = chkBaja.Checked ? Convert.ToDateTime(txtFecBaja.Text) : (Nullable<DateTime>)null;

            if (oProveedor.ListaProveedorCuenta != null && oProveedor.ListaProveedorCuenta.Count > 0)
            {
                if (oProveedor.ListaProveedorCuenta.Count == 1)
                {
                    oProveedor.ListaProveedorCuenta[0].BancoPorDefecto = true;
                    oProveedor.ListaProveedorCuenta[0].Opcion = oProveedor.ListaProveedorCuenta[0].Opcion == 0 ? (Int32)EnumOpcionGrabar.Actualizar : oProveedor.ListaProveedorCuenta[0].Opcion;
                }
                else
                {
                    // Moneda en Soles
                    ProveedorCuentaE pcSoles = oProveedor.ListaProveedorCuenta.Find
                    (
                        delegate (ProveedorCuentaE p) { return p.BancoPorDefecto == true && p.idMoneda == Variables.Soles; }
                    );

                    if (pcSoles == null)
                    {
                        ProveedorCuentaE pc = (from x in oProveedor.ListaProveedorCuenta where x.idMoneda == Variables.Soles select x).Take(1).FirstOrDefault();
                        //var p2 = oProveedor.ListaProveedorCuenta.Where(m => m.idMoneda == Variables.Soles).Take(1);

                        if (pc != null)
                        {
                            foreach (ProveedorCuentaE item in oProveedor.ListaProveedorCuenta)
                            {
                                if (item.idPersonaBanco == pc.idPersonaBanco && item.tipCuenta == pc.tipCuenta && item.idMoneda == pc.idMoneda && item.numCuenta == pc.numCuenta)
                                {
                                    item.BancoPorDefecto = true;
                                    item.Opcion = item.Opcion == 0 ? (Int32)EnumOpcionGrabar.Actualizar : item.Opcion;
                                    break;
                                }
                            } 
                        }
                    }

                    //Moneda Dolares
                    ProveedorCuentaE pcDolares = oProveedor.ListaProveedorCuenta.Find
                    (
                        delegate (ProveedorCuentaE p) { return p.BancoPorDefecto == true && p.idMoneda == Variables.Dolares; }
                    );

                    if (pcDolares == null)
                    {
                        ProveedorCuentaE pc = (from x in oProveedor.ListaProveedorCuenta where x.idMoneda == Variables.Dolares select x).Take(1).FirstOrDefault();

                        if (pc != null)
                        {
                            foreach (ProveedorCuentaE item in oProveedor.ListaProveedorCuenta)
                            {
                                if (item.idPersonaBanco == pc.idPersonaBanco && item.tipCuenta == pc.tipCuenta && item.idMoneda == pc.idMoneda && item.numCuenta == pc.numCuenta)
                                {
                                    item.BancoPorDefecto = true;
                                    item.Opcion = item.Opcion == 0 ? (Int32)EnumOpcionGrabar.Actualizar : item.Opcion;
                                    break;
                                }
                            } 
                        }
                    }
                }
            }

            //Auditoria
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
            {
                oProveedor.Persona.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oProveedor.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            {
                oProveedor.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oProveedor.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oProveedor.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oProveedor.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void CargarDatos()
        {
            // Personas
            cboTipoPersona.SelectedValue = oProveedor.Persona.TipoPersona;
            cboTipoPersona_SelectionChangeCommitted(new object(), new EventArgs());

            txtRazon.Text = oProveedor.Persona.RazonSocial;
            txtRuc.Text = oProveedor.Persona.RUC;
            txtNroDocumento.Text = oProveedor.Persona.NroDocumento;

            txtApePat.Text = oProveedor.Persona.ApePaterno;
            txtApeMat.Text = oProveedor.Persona.ApeMaterno;
            txtNombres.Text = oProveedor.Persona.Nombres;
            cboTipoDocumento.SelectedValue = oProveedor.Persona.TipoDocumento;
            txtTelefonos.Text = oProveedor.Persona.Telefonos;
            txtFax.Text = oProveedor.Persona.Fax;
            txtCorreo.Text = oProveedor.Persona.Correo;
            txtWeb.Text = oProveedor.Persona.Web;
            txtDireccion.Text = oProveedor.Persona.DireccionCompleta;
            chkContribuyente.Checked = oProveedor.Persona.PrincipalContribuyente;

            if (oProveedor.Persona.idCanalVenta != null && oProveedor.Persona.idCanalVenta != Variables.Cero)
            {
                cboCanal.SelectedValue = oProveedor.idCanalVenta;
            }

            //Proveedor
            txtComercial.Text = oProveedor.SiglaComercial;

            if (oProveedor.TipoProveedor != null && oProveedor.TipoProveedor != Variables.Cero)
            {
                cboTipoProveedor.SelectedValue = oProveedor.TipoProveedor;
            }

            if (!String.IsNullOrEmpty(oProveedor.fecInscripcion.ToString()))
            {
                dtpInscripcion.Checked = true;
                dtpInscripcion.Value = Convert.ToDateTime(oProveedor.fecInscripcion);
            }
            else
            {
                dtpInscripcion.Checked = false;
            }

            if (!String.IsNullOrEmpty(oProveedor.fecInicioActividad.ToString()))
            {
                dtpActividades.Checked = true;
                dtpActividades.Value = Convert.ToDateTime(oProveedor.fecInicioActividad);
            }
            else
            {
                dtpActividades.Checked = false;
            }

            if (oProveedor.tipConstitucion != null && oProveedor.tipConstitucion != Variables.Cero)
            {
                cboConstitucion.SelectedValue = oProveedor.tipConstitucion;
            }
            else
            {
                cboConstitucion.SelectedValue = Variables.Cero;
            }

            if (oProveedor.tipRegimen != null && oProveedor.tipRegimen != Variables.Cero)
            {
                cboRegimen.SelectedValue = oProveedor.tipRegimen;
            }
            else
            {
                cboRegimen.SelectedValue = Variables.Cero;
            }

            if (oProveedor.catProveedor != null && oProveedor.catProveedor != Variables.Cero)
            {
                cboCategoria.SelectedValue = oProveedor.catProveedor;
            }
            else
            {
                cboCategoria.SelectedValue = Variables.Cero;
            }

            if (oProveedor.indBaja == Variables.SI)
            {
                chkBaja.Checked = true;
                txtFecBaja.Text = oProveedor.fecBaja.ToString();
            }
            else
            {
                chkBaja.Checked = false;
                txtFecBaja.Text = String.Empty;
            }

            //Auditoria
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar) || OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            {
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                txtUsuRegistra.Text = oProveedor.UsuarioRegistro;
                txtRegistro.Text = oProveedor.FechaRegistro.ToString();
                txtUsuModifica.Text = oProveedor.UsuarioModificacion;
                txtModifica.Text = oProveedor.FechaModificacion.ToString();
            }
        }

        Boolean RevisarNroDocumento(String numero, String tipo)
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

        private void BloquearPaneles(Boolean bloquea)
        {
            pnlDatos.Enabled = bloquea;
            pnlDireccion.Enabled = bloquea;
            pnlNaturaleza.Enabled = bloquea;
            pnlCondicion.Enabled = bloquea;
        }

        void EditarDetalle(DataGridViewCellEventArgs e, ProveedorContactoE oProvItem)
        {
            try
            {
                if (bsProveedorContacto.Count > 0)
                {
                    frmProveedorContacto oFrm = new frmProveedorContacto(oProvItem);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oProveedor.ListaProveedorContacto[e.RowIndex] = oFrm.ProveedorContactosItem;
                        bsProveedorContacto.DataSource = oProveedor.ListaProveedorContacto;
                        bsProveedorContacto.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void EditarCuentasBancos(DataGridViewCellEventArgs e, ProveedorCuentaE oProvItem2)
        {
            try
            {
                if (bsProveedorCuenta.Count > 0)
                {
                    List<ProveedorCuentaE> oListaTemp = new List<ProveedorCuentaE>(oProveedor.ListaProveedorCuenta);
                    oListaTemp.Remove((ProveedorCuentaE)bsProveedorCuenta.Current);

                    frmProveedorCuenta oFrm = new frmProveedorCuenta(oProvItem2, oListaTemp);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oProveedor.ListaProveedorCuenta[e.RowIndex] = oFrm.ProveedorCuentaItem;
                        bsProveedorCuenta.DataSource = oProveedor.ListaProveedorCuenta;
                        bsProveedorCuenta.ResetBindings(false);
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
            try
            {
                if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
                {
                    //Persona(Pero estos datos vienen del form anterior) y Proveedor son nuevos...
                    oProveedor = new ProveedorE
                    {
                        Persona = oPersona
                    };

                    txtIdProveedor.Text = oProveedor.Persona.IdPersona.ToString();
                    dtpInscripcion.Checked = false;
                    dtpActividades.Checked = false;
                    cboPaises.SelectedValue = Variables.Cero;
                    cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());

                    CargarDatos();
                }
                else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
                {
                    //Persona existe y proveedor va hacer nuevo
                    oProveedor = new ProveedorE
                    {
                        Persona = oPersona
                    };

                    txtIdProveedor.Text = oProveedor.Persona.IdPersona.ToString("000000");
                    cboPaises.SelectedValue = oProveedor.Persona.idPais;
                    cboPaises_SelectionChangeCommitted(new object(), new EventArgs());

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
                    //Persona y Proveedor solo se actualiza
                    if (oProveedor.Persona.IdPersona == 0)
                    {
                        oProveedor.Persona = new Persona();
                        oProveedor.Persona = oPersona;
                    }

                    txtIdProveedor.Text = oProveedor.Persona.IdPersona.ToString("000000");
                    cboPaises.SelectedValue = oProveedor.Persona.idPais;
                    cboPaises_SelectionChangeCommitted(new object(), new EventArgs());

                    UbigeoE EUbigeo = AgenteMaestro.Proxy.RecuperarUbigeoPorId(oProveedor.Persona.idUbigeo.ToString());

                    if (EUbigeo.Departamento != null)
                    {
                        cboDepartamento.SelectedValue = EUbigeo.Departamento;
                        cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                        cboProvincia.SelectedValue = EUbigeo.Provincia;
                        cboProvincia_SelectionChangeCommitted(new Object(), new EventArgs());
                        cboDistrito.SelectedValue = oProveedor.Persona.idUbigeo;
                    }
                    else
                    {
                        cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
                        cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                    }

                    bsProveedorCuenta.DataSource = oProveedor.ListaProveedorCuenta;
                    bsProveedorCuenta.ResetBindings(false);

                    bsProveedorContacto.DataSource = oProveedor.ListaProveedorContacto;
                    bsProveedorContacto.ResetBindings(false);
                    CargarDatos();
                }

                base.Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                if (oProveedor != null)
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
                            oProveedor = AgenteMaestro.Proxy.GrabarProveedor(oProveedor, EnumOpcionGrabar.Insertar);
                            txtIdProveedor.Text = oProveedor.IdPersona.ToString("000000");
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oProveedor = AgenteMaestro.Proxy.GrabarProveedor(oProveedor, EnumOpcionGrabar.InsertarSimple);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            if (oListaEliminados != null && oListaEliminados.Count > Variables.Cero)
                            {
                                foreach (ProveedorContactoE item in oListaEliminados)
                                {
                                    oProveedor.ListaProveedorContacto.Add(item);
                                }
                            }

                            if (oListaEliminados2 != null && oListaEliminados2.Count > Variables.Cero)
                            {
                                foreach (ProveedorCuentaE item in oListaEliminados2)
                                {
                                    oProveedor.ListaProveedorCuenta.Add(item);
                                }
                            }

                            oProveedor = AgenteMaestro.Proxy.GrabarProveedor(oProveedor, EnumOpcionGrabar.Actualizar);
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
                MessageBox.Show(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<ProveedorE>(oProveedor);

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
            else if (Convert.ToInt32(cboTipoPersona.SelectedValue) == (Int32)enumTipoPersona.Natural_Sin_Ruc)
            {
                if (String.IsNullOrEmpty(txtNroDocumento.Text))
                {
                    Global.MensajeFault("Tiene que colocar el número de documento.");
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

        #endregion

        #region Eventos

        private void frmProveedores2_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();

            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
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
                    cboCanal.SelectedIndex = 1;

                    break;

                case 102002: //Personas Natural con Ruc
                    txtRazon.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtComercial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtApePat.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtApeMat.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNombres.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    cboCanal.SelectedIndex = 1;

                    break;
                case 102003: //Personas Natural sin Ruc
                    txtRazon.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtComercial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtApePat.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtApeMat.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNombres.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    cboCanal.SelectedIndex = 1;

                    break;

                case 102004: //Otros

                    txtRazon.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtComercial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtApePat.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtApeMat.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNombres.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    cboCanal.SelectedIndex = 2;

                    break;
                default:

                    txtRazon.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtComercial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtApePat.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtApeMat.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNombres.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    cboCanal.SelectedIndex = 0;

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
                case 101001: //DNI

                    if (Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc))
                    {
                        btSunat.Enabled = false;
                        btReniec.Enabled = true;

                        if (!String.IsNullOrEmpty(txtRuc.Text.Trim()))
                        {
                            txtNroDocumento.Text = txtRuc.Text.Trim();
                        }

                        txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                        txtNroDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
                        txtNroDocumento.MaxLength = 8;
                    }
                    else if (Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Ruc))
                    {
                        btSunat.Enabled = true;
                        btReniec.Enabled = false;
                        txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtNroDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
                        txtNroDocumento.MaxLength = 8;
                        txtRuc.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
                        txtRuc.MaxLength = 11;
                    }

                    break;

                case 101002: //Carnet de Extranjeria

                    btSunat.Enabled = false;
                    btReniec.Enabled = false;

                    if (!String.IsNullOrEmpty(txtRuc.Text.Trim()))
                    {
                        txtNroDocumento.Text = txtRuc.Text.Trim();
                    }

                    txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNroDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.Defecto;
                    txtNroDocumento.MaxLength = 20;

                    break;
                case 101003: //Cedula Diplomatica de Identidad

                    btSunat.Enabled = false;
                    btReniec.Enabled = false;
                    txtRuc.Enabled = false;

                    if (!String.IsNullOrEmpty(txtRuc.Text.Trim()))
                    {
                        txtNroDocumento.Text = txtRuc.Text.Trim();
                    }

                    txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNroDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.Defecto;
                    txtNroDocumento.MaxLength = 20;

                    break;

                case 101004: //RUC

                    if (Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Juridica))
                    {
                        btSunat.Enabled = true;
                        btReniec.Enabled = false;
                        txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtNroDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                        txtRuc.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
                        txtRuc.MaxLength = 11;
                    }
                    else if (Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Ruc))
                    {
                        btSunat.Enabled = true;
                        btReniec.Enabled = false;
                        txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtNroDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
                        txtNroDocumento.MaxLength = 8;
                        txtRuc.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
                        txtRuc.MaxLength = 11;
                    }

                    break;
                case 101005: //Otros

                    btSunat.Enabled = false;
                    btReniec.Enabled = false;

                    if (!String.IsNullOrEmpty(txtRuc.Text.Trim()))
                    {
                        txtNroDocumento.Text = txtRuc.Text.Trim();
                    }

                    txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNroDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.Defecto;
                    txtNroDocumento.MaxLength = 20;

                    break;

                case 101006: //Pasaporte

                    btSunat.Enabled = false;
                    btReniec.Enabled = false;

                    if (!String.IsNullOrEmpty(txtRuc.Text.Trim()))
                    {
                        txtNroDocumento.Text = txtRuc.Text.Trim();
                    }

                    txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNroDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.Defecto;
                    txtNroDocumento.MaxLength = 20;

                    break;

                default:

                    btSunat.Enabled = false;
                    btReniec.Enabled = false;
                    txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNroDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);

                    break;
            }
        }

        private void btSunat_Click(object sender, EventArgs e)
        {
            String RazonSocial = String.Empty;
            Int32 index = 0;

            try
            {
                frmBuscarRuc oFrm = new frmBuscarRuc();
                List<String> Padrones = null;
                String Direccion = String.Empty;

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

                            #region Juridicas

                            txtRazon.Text = oFrm.RazonSocial;
                            txtComercial.Text = oFrm.NomComercial;
                            txtTelefonos.Text = oFrm.Telefonos;

                            //Dirección
                            Direccion = Global.DejarSoloUnEspacio(oFrm.Direccion.Trim());
                            Padrones = new List<String>(oFrm.Padrones);

                            if (Padrones.Count > Variables.Cero)
                            {
                                Boolean Encuentro = false;

                                foreach (String item in Padrones)
                                {
                                    Encuentro = item.ToUpper().IndexOf("CONTRIBUYENTES") > 0;

                                    if (Encuentro)
                                    {
                                        chkContribuyente.Checked = true;
                                    }
                                }
                            }

                            Direccion = Direccion.Replace(oFrm.Departamento + " - " + oFrm.Provincia + " - " + oFrm.Distrito, "");
                            cboDepartamento.SelectedValue = oFrm.Departamento;
                            cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                            cboProvincia.SelectedValue = oFrm.Provincia;
                            cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
                            cboDistrito.Text = oFrm.Distrito;
                            txtDireccion.Text = Direccion.Trim();

                            dtpActividades.Value = Convert.ToDateTime(oFrm.FechaActividades);
                            dtpInscripcion.Value = Convert.ToDateTime(oFrm.FechaInscripcion);

                            index = cboConstitucion.FindString(oFrm.TipoContribuyente.Trim());
                            cboConstitucion.SelectedIndex = index;

                            #endregion

                            break;

                        case 102002: //Personas Natural con Ruc

                            #region Natural con RUC

                            txtRuc.Text = oFrm.Ruc;
                            txtRazon.Text = RazonSocial = oFrm.RazonSocial;
                            txtComercial.Text = oFrm.NomComercial;
                            txtNroDocumento.Text = oFrm.DNI;

                            if (!String.IsNullOrWhiteSpace(oFrm.DNI))
                            {
                                cboTipoDocumento.SelectedValue = Convert.ToInt32(EnumTipoDocumento.Dni);
                            }

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
                            Direccion = Global.DejarSoloUnEspacio(oFrm.Direccion.Trim());
                            Padrones = new List<String>(oFrm.Padrones);

                            if (Padrones.Count > Variables.Cero)
                            {
                                Boolean Encuentro = false;

                                foreach (String item in Padrones)
                                {
                                    Encuentro = item.ToUpper().IndexOf("CONTRIBUYENTES") > 0;

                                    if (Encuentro)
                                    {
                                        chkContribuyente.Checked = true;
                                    }
                                }
                            }

                            Direccion = Direccion.Replace(oFrm.Departamento + " - " + oFrm.Provincia + " - " + oFrm.Distrito, "");
                            cboDepartamento.SelectedValue = oFrm.Departamento;
                            cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                            cboProvincia.SelectedValue = oFrm.Provincia;
                            cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
                            cboDistrito.Text = oFrm.Distrito;
                            txtDireccion.Text = Direccion.Trim();

                            dtpActividades.Value = Convert.ToDateTime(oFrm.FechaActividades);
                            dtpInscripcion.Value = Convert.ToDateTime(oFrm.FechaInscripcion);
                            txtTelefonos.Text = oFrm.Telefonos;

                            index = cboConstitucion.FindString(oFrm.TipoContribuyente.Trim());
                            cboConstitucion.SelectedIndex = index;

                            #endregion

                            break;
                    }

                    cboPaises.SelectedValue = 90;
                    cboPaises_SelectionChangeCommitted(new Object(), new EventArgs());

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
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btReniec_Click(object sender, EventArgs e)
        {
            frmBuscarDni oFrm = new frmBuscarDni();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Informacion != null)
            {
                if (Convert.ToInt32(cboTipoPersona.SelectedValue) == 102003)
                {
                    StringBuilder NombreCompleto = new StringBuilder();

                    txtRuc.Text = oFrm.DNI;
                    txtNroDocumento.Text = oFrm.DNI;
                    txtNombres.Text = oFrm.Informacion.Nombres;
                    txtApePat.Text = oFrm.Informacion.ApePaterno;
                    txtApeMat.Text = oFrm.Informacion.ApeMaterno;

                    NombreCompleto.Append(oFrm.Informacion.ApePaterno);
                    NombreCompleto.Append(" ");
                    NombreCompleto.Append(oFrm.Informacion.ApeMaterno);
                    NombreCompleto.Append(" ");
                    NombreCompleto.Append(oFrm.Informacion.Nombres);
                    txtRazon.Text = NombreCompleto.ToString();
                    txtComercial.Text = NombreCompleto.ToString();
                }
            }
        }

        private void cboTipoPersona_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboTipoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dtpInscripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void chkBaja_Click(object sender, EventArgs e)
        {
            if (chkBaja.Checked)
            {
                if (String.IsNullOrEmpty(txtFecBaja.Text))
                {
                    oProveedor.fecBaja = DateTime.Now;
                    txtFecBaja.Text = DateTime.Now.ToString();
                }
            }
            else
            {
                txtFecBaja.Text = String.Empty;
            }
        }

        private void cboPaises_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboPaises.SelectedValue) == 90)
            {
                cboDepartamento.Enabled = true;
                cboProvincia.Enabled = true;
                cboDistrito.Enabled = true;
            }
            else
            {
                cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
                cboProvincia.SelectedValue = Variables.SeleccioneProvincia;
                cboDistrito.SelectedValue = "0";
                cboDepartamento.Enabled = false;
                cboProvincia.Enabled = false;
                cboDistrito.Enabled = false;
            }
        }

        private void btNuevaUbicacion_Click(object sender, EventArgs e)
        {
            try
            {
                List<ProveedorContactoE> oListaTemp = new List<ProveedorContactoE>(oProveedor.ListaProveedorContacto);

                frmProveedorContacto oFrm = new frmProveedorContacto(oListaTemp);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    ProveedorContactoE oProvItem = oFrm.ProveedorContactosItem;
                    oProveedor.ListaProveedorContacto.Add(oProvItem);
                    bsProveedorContacto.DataSource = oProveedor.ListaProveedorContacto;
                    bsProveedorContacto.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btEliminarUbicacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsProveedorContacto.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        oListaEliminados.Add((ProveedorContactoE)bsProveedorContacto.Current);
                        oProveedor.ListaProveedorContacto.RemoveAt(bsProveedorContacto.Position);

                        bsProveedorContacto.DataSource = oProveedor.ListaProveedorContacto;
                        bsProveedorContacto.ResetBindings(false);

                        base.QuitarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvContactos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((ProveedorContactoE)bsProveedorContacto.Current));
            }
        }

        private void btNuevoCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                frmProveedorCuenta oFrm = new frmProveedorCuenta(oProveedor.ListaProveedorCuenta);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    ProveedorCuentaE oProvItem = oFrm.ProveedorCuentaItem;
                    oProveedor.ListaProveedorCuenta.Add(oProvItem);
                    bsProveedorCuenta.DataSource = oProveedor.ListaProveedorCuenta;
                    bsProveedorCuenta.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btEliminarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsProveedorCuenta.Current != null)
                {
                    if (Global.MensajeConfirmacion("Se va a dar de baja la Cta. Bancaria escogida.") == DialogResult.Yes)
                    {
                        if (oListaEliminados2 == null)
                        {
                            oListaEliminados2 = new List<ProveedorCuentaE>();
                        }

                        //Actualizando el campo para saber que se va a realizar...
                        ((ProveedorCuentaE)bsProveedorCuenta.Current).Opcion = (Int32)EnumOpcionGrabar.Anular;
                        //Agregando a la lista de eliminados...
                        oListaEliminados2.Add((ProveedorCuentaE)bsProveedorCuenta.Current);
                        //Removiendo de la lista principal(temporalmente)...
                        oProveedor.ListaProveedorCuenta.RemoveAt(bsProveedorCuenta.Position);
                        //Actualizando la lista...
                        bsProveedorCuenta.DataSource = oProveedor.ListaProveedorCuenta;
                        bsProveedorCuenta.ResetBindings(false);

                        base.QuitarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvBancosCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarCuentasBancos(e, ((ProveedorCuentaE)bsProveedorCuenta.Current));
            }
        }

        private void chkIndBajaCB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIndBajaCB.Checked)
                {
                    dgvBancosCuentas.Columns[5].Visible = true;

                    if (oProveedor != null)
                    {
                        oProveedor.ListaProveedorCuenta = AgenteMaestro.Proxy.ListarProveedorCuenta(oProveedor.IdEmpresa, oProveedor.IdPersona, true);
                    }
                }
                else
                {
                    dgvBancosCuentas.Columns[5].Visible = false;

                    if (oProveedor != null)
                    {
                        oProveedor.ListaProveedorCuenta = AgenteMaestro.Proxy.ListarProveedorCuenta(oProveedor.IdEmpresa, oProveedor.IdPersona, false);
                    }
                }

                bsProveedorCuenta.DataSource = oProveedor.ListaProveedorCuenta;
                bsProveedorCuenta.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvBancosCuentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((Boolean)dgvBancosCuentas.Rows[e.RowIndex].Cells["indBaja"].Value == true)
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorAnulado;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
