using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using ClienteWinForm.Busquedas;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using ControlesWinForm;

namespace ClienteWinForm.Maestros
{
    public partial class frmClientes : FrmMantenimientoBase
    {

        #region Constructores

        public frmClientes()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvSucursales, true);
            FormatoGrid(dgvAsociados, true);
            FormatoGrid(dgvAvales, true);
            LlenarCombos();
        }

        //Nuevo
        public frmClientes(ClienteE cliente, Persona persona, Int32 Opcion)
            : this()
        {
            oCliente = cliente;
            oPersona = persona;
            OpcionGrabar = Opcion;
        }

        //Edición
        public frmClientes(ClienteE oCliente_, Int32 Opcion)
            : this()
        {
            oCliente = oCliente_;
            OpcionGrabar = Opcion;
        }
        
        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        public ClienteE oCliente = null;
        Persona oPersona = null;
        public Int32 OpcionGrabar;
        String idUbigeo = String.Empty;
        String sNroDocumento = String.Empty;
        Int32 ClienteNormal = Variables.Cero;
        private ClienteE vCliente;
        private int opcion;

        #endregion

        #region Procedimientos de Usuario

        void EditarDetalle<T>(DataGridViewCellEventArgs e, T Entidad, String TipoEdicion)
        {
            try
            {
                if (TipoEdicion == "dir")
                {
                    if (bsPersonaDireccion.Count > 0)
                    {
                        frmDetallePersonaDireccion oFrm = new frmDetallePersonaDireccion(Entidad as PersonaDireccionE);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersonaDirección != null)
                        {
                            oCliente.Persona.ListaPersonaDireccion[e.RowIndex] = oFrm.oPersonaDirección;
                            bsPersonaDireccion.DataSource = oCliente.Persona.ListaPersonaDireccion;
                            bsPersonaDireccion.ResetBindings(false);
                            base.AgregarDetalle();
                        }
                    } 
                }
                else if(TipoEdicion == "refe")
                {
                    if (Convert.ToString(((ParTabla)cboTipoCliente.SelectedItem).NemoTecnico) == "TIPCLIREF")
                    {
                        if (bsClienteAsociados.Count > 0)
                        {
                            frmDetalleClienteAsociados oFrm = new frmDetalleClienteAsociados(Entidad as ClienteAsociadosE);

                            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oClienteAsociados != null)
                            {
                                oCliente.ListaClienteAsociados[e.RowIndex] = oFrm.oClienteAsociados;
                                bsClienteAsociados.DataSource = oCliente.ListaClienteAsociados;
                                bsClienteAsociados.ResetBindings(false);
                                base.AgregarDetalle();
                            }
                        }
                    }
                }
                else
                {
                    if (bsClienteAval.List.Count > Variables.Cero)
                    {
                        frmDetalleClienteAval oFrm = new frmDetalleClienteAval(Entidad as ClienteAvalE);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oClienteAval != null)
                        {
                            oCliente.ListaAvales[e.RowIndex] = oFrm.oClienteAval;
                            bsClienteAval.DataSource = oCliente.ListaAvales;
                            bsClienteAval.ResetBindings(false);
                            base.AgregarDetalle();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }       

        void LlenarCombos()
        {
            List<EnumParTabla> ListaParTabla = new List<EnumParTabla>
            {
                EnumParTabla.TipoPersona,
                EnumParTabla.TipoContribuyente,
                EnumParTabla.TipoCliente,
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

            ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoPersona, ListaParametros[EnumParTabla.TipoPersona]);
            ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoCliente, ListaParametros[EnumParTabla.TipoCliente]);
            ComboHelper.RellenarCombos<List<ParTabla>>(cboConstitucion, (from x in ListaParametros[EnumParTabla.TipoContribuyente] orderby x.IdParTabla select x).ToList());
            ComboHelper.RellenarCombos<List<ParTabla>>(cboRegimen, (from x in ListaParametros[EnumParTabla.RegimenEmpresa] orderby x.IdParTabla select x).ToList());
            ComboHelper.RellenarCombos<List<ParTabla>>(cboCategoria, (from x in ListaParametros[EnumParTabla.CategoriaEmpresa] orderby x.IdParTabla select x).ToList());
            ComboHelper.RellenarCombos<List<ParTabla>>(cboCanal, (from x in ListaParametros[EnumParTabla.CanalVenta] orderby x.IdParTabla select x).ToList());

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

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                    where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                    orderby x.idMoneda
                                    select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desMoneda";


            //Obteniendo el IdParTabla para el valor por defecto de Tipo de Cliente...
            ParTabla pCliente = ListaParametros[EnumParTabla.TipoCliente].Find
            (
                delegate (ParTabla pt) { return pt.NemoTecnico == "TIPCLINOR"; }
            );

            if (pCliente != null)
            {
                ClienteNormal = pCliente.IdParTabla;
            }
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
                                          //where x.IdParTabla != Convert.ToInt32(EnumTipoDocumento.Ruc)
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

        void GuardarDatos()
        {
            String Direccion = String.Empty;

            //Persona
            oCliente.Persona.TipoPersona = Convert.ToInt32(cboTipoPersona.SelectedValue);

            if (String.IsNullOrEmpty(txtRazon.Text))
            {
                oCliente.Persona.RazonSocial = txtApePat.Text.Trim() + " " + txtApeMat.Text.Trim() + " " + txtNombres.Text.Trim();
            }
            else
            {
                oCliente.Persona.RazonSocial = txtRazon.Text.Trim();
            }

            if (Convert.ToInt32(cboTipoPersona.SelectedValue) == (Int32)enumTipoPersona.Juridica)
            {
                oCliente.Persona.RUC = txtRuc.Text;
                oCliente.Persona.NroDocumento = String.Empty;
            }
            else if (Convert.ToInt32(cboTipoPersona.SelectedValue) == (Int32)enumTipoPersona.Natural_Ruc)
            {
                oCliente.Persona.RUC = txtRuc.Text;
                
                if (string.IsNullOrEmpty(txtNroDocumento.Text.Trim()))
                {
                    oCliente.Persona.NroDocumento = txtRuc.Text;
                }
                else
                {
                    oCliente.Persona.NroDocumento = txtNroDocumento.Text;
                }
            }
            else
            {
                oCliente.Persona.RUC = txtNroDocumento.Text;

                if (string.IsNullOrEmpty(txtNroDocumento.Text.Trim()))
                {
                    oCliente.Persona.NroDocumento = txtRuc.Text;
                }
                else
                {
                    oCliente.Persona.NroDocumento = txtNroDocumento.Text;
                }
            }

            oCliente.Persona.ApePaterno = txtApePat.Text;
            oCliente.Persona.ApeMaterno = txtApeMat.Text;
            oCliente.Persona.Nombres = txtNombres.Text;
            oCliente.Persona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);            
            oCliente.Persona.Telefonos = txtTelefonos.Text.Trim();
            oCliente.Persona.Fax = txtFax.Text;
            oCliente.Persona.Correo = txtCorreo.Text;
            oCliente.Persona.Web = txtWeb.Text;

            Direccion = txtDireccion.Text.Trim();
            oCliente.Persona.DireccionCompleta = Direccion.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, "");
            oCliente.Persona.idPais = Convert.ToInt32(cboPaises.SelectedValue);
            oCliente.Persona.idUbigeo = cboDistrito.SelectedValue.ToString();
            oCliente.Persona.AgenteRetenedor = chkRetencion.Checked;
            oCliente.Persona.idCanalVenta = Convert.ToInt32(cboCanal.SelectedValue) != Variables.Cero ? Convert.ToInt32(cboCanal.SelectedValue) : (Nullable<Int32>)null;

            //Cliente
            oCliente.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            
            if (String.IsNullOrEmpty(txtComercial.Text))
            {
                oCliente.SiglaComercial = txtApePat.Text.Trim() + " " + txtApeMat.Text.Trim() + " " + txtNombres.Text.Trim();
            }
            else
            {
                oCliente.SiglaComercial = txtComercial.Text.Trim();
            }
           oCliente.idMoneda = Convert.ToString(cboMoneda.SelectedValue);

            oCliente.TipoCliente = Convert.ToInt32(cboTipoCliente.SelectedValue);
            oCliente.fecInscripcion = dtpInscripcion.Checked ? dtpInscripcion.Value.Date : (Nullable<DateTime>)null;
            oCliente.fecInicioEmpresa = dtpActividades.Checked ? dtpActividades.Value.Date : (Nullable<DateTime>)null;
            oCliente.tipConstitucion = 1;// Convert.ToInt32(cboConstitucion.SelectedValue);
            oCliente.tipRegimen = Convert.ToInt32(cboRegimen.SelectedValue) != Variables.Cero ? Convert.ToInt32(cboRegimen.SelectedValue) : (Nullable<Int32>)null;
            oCliente.catCliente = Convert.ToInt32(cboCategoria.SelectedValue) != Variables.Cero ? Convert.ToInt32(cboCategoria.SelectedValue) : (Nullable<Int32>)null;
            oCliente.indEstado = chkBaja.Checked;
            oCliente.indVinculada = chkVinculado.Checked;
            oCliente.fecBaja = chkBaja.Checked ? Convert.ToDateTime(txtFecBaja.Text) : (Nullable<DateTime>)null;
            ///
            //Auditoria
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
            {
                oCliente.Persona.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oCliente.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            {
                oCliente.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oCliente.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oCliente.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oCliente.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void CargarDatos()
        {
            // Personas
            cboTipoPersona.SelectedValue = oCliente.Persona.TipoPersona;
            cboTipoPersona_SelectionChangeCommitted(new object(), new EventArgs());

            txtRazon.Text = oCliente.Persona.RazonSocial;
            txtRuc.Text = oCliente.Persona.RUC;
            txtNroDocumento.Text = oCliente.Persona.NroDocumento;

            txtApePat.Text = oCliente.Persona.ApePaterno;
            txtApeMat.Text = oCliente.Persona.ApeMaterno;
            txtNombres.Text = oCliente.Persona.Nombres;
            cboTipoDocumento.SelectedValue = oCliente.Persona.TipoDocumento;
            txtTelefonos.Text = oCliente.Persona.Telefonos;
            txtFax.Text = oCliente.Persona.Fax;
            txtCorreo.Text = oCliente.Persona.Correo;
            txtWeb.Text = oCliente.Persona.Web;
            txtDireccion.Text = oCliente.Persona.DireccionCompleta;
            chkRetencion.Checked = oCliente.Persona.AgenteRetenedor;


            if (oCliente.Persona.idCanalVenta != null && oCliente.Persona.idCanalVenta != Variables.Cero)
            {
                cboCanal.SelectedValue = oCliente.Persona.idCanalVenta;
            }

            //Cliente
            txtComercial.Text = oCliente.SiglaComercial;
            chkVinculado.Checked = oCliente.indVinculada;

            if (oCliente.TipoCliente != null && oCliente.TipoCliente != Variables.Cero)
            {
                cboTipoCliente.SelectedValue = oCliente.TipoCliente;

                if (Convert.ToInt32(oCliente.TipoCliente) == Variables.Cero)
                {
                    cboTipoCliente.SelectedValue = ClienteNormal;
                }
            }
            else
            {
                cboTipoCliente.SelectedValue = ClienteNormal;
            }

            if (!String.IsNullOrEmpty(oCliente.fecInscripcion.ToString()))
            {
                dtpInscripcion.Checked = true;
                dtpInscripcion.Value = Convert.ToDateTime(oCliente.fecInscripcion);
            }
            else
            {
                dtpInscripcion.Checked = false;
            }

            if (!String.IsNullOrEmpty(oCliente.fecInicioEmpresa.ToString()))
            {
                dtpActividades.Checked = true;
                dtpActividades.Value = Convert.ToDateTime(oCliente.fecInicioEmpresa);
            }
            else
            {
                dtpActividades.Checked = false;
            }

            if (oCliente.tipConstitucion != null && oCliente.tipConstitucion != Variables.Cero)
            {
                cboConstitucion.SelectedValue = oCliente.tipConstitucion;
            }
            else
            {
                cboConstitucion.SelectedValue = Variables.Cero;
            }

            if (oCliente.tipRegimen != null && oCliente.tipRegimen != Variables.Cero)
            {
                cboRegimen.SelectedValue = oCliente.tipRegimen;
            }
            else
            {
                cboRegimen.SelectedValue = Variables.Cero;
            }

            if (oCliente.catCliente != null && oCliente.catCliente != Variables.Cero)
            {
                cboCategoria.SelectedValue = oCliente.catCliente;
            }
            else
            {
                cboCategoria.SelectedValue = Variables.Cero;
            }

            if (oCliente.indEstado)
            {
                chkBaja.Checked = true;
                txtFecBaja.Text = oCliente.fecBaja.ToString();
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
                txtUsuRegistra.Text = oCliente.UsuarioRegistro;
                txtRegistro.Text = oCliente.FechaRegistro.ToString();
                txtUsuModifica.Text = oCliente.UsuarioModificacion;
                txtModifica.Text = oCliente.FechaModificacion.ToString();
            }
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
            pnlDireccion.Enabled = Flag;
            pnlNaturaleza.Enabled = Flag;
            pnlCondicion.Enabled = Flag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
            {
                oCliente = new ClienteE
                {
                    Persona = oPersona
                };

                txtIdCliente.Text = oCliente.Persona.IdPersona.ToString();
                dtpInscripcion.Checked = false;
                dtpActividades.Checked = false;
                cboPaises.SelectedValue = Variables.Cero;
                cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
                cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                cboMoneda.SelectedValue = oCliente.idMoneda;
                CargarDatos();
            }
            else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            {
                oCliente = new ClienteE
                {
                    Persona = oPersona
                };
                cboMoneda.SelectedValue = oCliente.idMoneda;
                txtIdCliente.Text = oCliente.Persona.IdPersona.ToString("000000");
                cboPaises.SelectedValue = oCliente.Persona.idPais;
                cboPaises_SelectionChangeCommitted(new object(), new EventArgs());

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
                //Persona y Proveedor solo se actualiza
                if (oCliente.Persona.IdPersona == 0)
                {
                    oCliente.Persona = new Persona();
                    oCliente.Persona = oPersona;
                }
                cboMoneda.SelectedValue = oCliente.idMoneda;
                txtIdCliente.Text = oCliente.Persona.IdPersona.ToString("000000");
                cboPaises.SelectedValue = oCliente.Persona.idPais;
                cboPaises_SelectionChangeCommitted(new object(), new EventArgs());

                UbigeoE EUbigeo = new UbigeoE();
                EUbigeo = AgenteMaestro.Proxy.RecuperarUbigeoPorId(oCliente.Persona.idUbigeo.ToString());

                if (EUbigeo.Departamento != null)
                {
                    cboDepartamento.SelectedValue = EUbigeo.Departamento;
                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                    cboProvincia.SelectedValue = EUbigeo.Provincia;
                    cboProvincia_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboDistrito.SelectedValue = oCliente.Persona.idUbigeo;
                }
                else
                {
                    cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                }

                CargarDatos();
            }

            bsPersonaDireccion.DataSource = oCliente.Persona.ListaPersonaDireccion;
            bsPersonaDireccion.ResetBindings(false);

            bsClienteAval.DataSource = oCliente.ListaAvales;
            bsClienteAval.ResetBindings(false);

            if (Convert.ToString(((ParTabla)cboTipoCliente.SelectedItem).NemoTecnico) == "TIPCLIREF")
            {
                bsClienteAsociados.DataSource = oCliente.ListaClienteAsociados;
                bsClienteAsociados.ResetBindings(false);
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oCliente != null)
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
                            oCliente = AgenteMaestro.Proxy.GrabarCliente(oCliente, EnumOpcionGrabar.Insertar);
                            txtIdCliente.Text = oCliente.idPersona.ToString("000000");
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oCliente = AgenteMaestro.Proxy.GrabarCliente(oCliente, EnumOpcionGrabar.InsertarSimple);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oCliente = AgenteMaestro.Proxy.GrabarCliente(oCliente, EnumOpcionGrabar.Actualizar);
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
            String Respuesta = ValidarEntidad<ClienteE>(oCliente);

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
            else if(Convert.ToInt32(cboTipoPersona.SelectedValue) == (Int32)enumTipoPersona.Natural_Sin_Ruc)
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

        public override void AgregarDetalle()
        {
            try
            {
                if (tbClientes.SelectedTab == tpSucursales)
                {
                    frmDetallePersonaDireccion oFrm = new frmDetallePersonaDireccion();

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        PersonaDireccionE oDireccion = oFrm.oPersonaDirección;

                        oCliente.Persona.ListaPersonaDireccion.Add(oDireccion);
                        bsPersonaDireccion.DataSource = oCliente.Persona.ListaPersonaDireccion;
                        bsPersonaDireccion.ResetBindings(false);

                        base.AgregarDetalle();
                    }
                }
                else if (tbClientes.SelectedTab == tpAsociados)
                {
                    if (Convert.ToString(((ParTabla)cboTipoCliente.SelectedItem).NemoTecnico) == "TIPCLIREF")
                    {
                        frmDetalleClienteAsociados oFrmA = new frmDetalleClienteAsociados();

                        if (oFrmA.ShowDialog() == DialogResult.OK)
                        {
                            ClienteAsociadosE oDirec = oFrmA.oClienteAsociados;

                            oCliente.ListaClienteAsociados.Add(oDirec);
                            bsClienteAsociados.DataSource = oCliente.ListaClienteAsociados;
                            bsClienteAsociados.ResetBindings(false);
                            base.AgregarDetalle();
                        }
                    }
                }
                else if (tbClientes.SelectedTab == tpAvales)
                {
                    frmDetalleClienteAval oFrm = new frmDetalleClienteAval();

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oClienteAval != null)
                    {
                        Int32 Item = 0;
                        ClienteAvalE oAval = oFrm.oClienteAval;

                        if (oCliente.ListaAvales.Count == Variables.Cero)
                        {
                            Item = 1;
                        }
                        else
                        {
                            Item = Convert.ToInt32(oCliente.ListaAvales.Max(mx => mx.idAval)) + 1;
                        }

                        oAval.idAval = Item;
                        oCliente.ListaAvales.Add(oAval);
                        bsClienteAval.DataSource = oCliente.ListaAvales;
                        bsClienteAval.ResetBindings(false);
                        base.AgregarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (tbClientes.SelectedTab == tpSucursales)
                {
                    if (bsPersonaDireccion.Current != null)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                        {
                            AgenteMaestro.Proxy.EliminarPersonaDireccion(((PersonaDireccionE)bsPersonaDireccion.Current).IdPersona, ((PersonaDireccionE)bsPersonaDireccion.Current).IdDireccion);
                            oCliente.Persona.ListaPersonaDireccion.RemoveAt(bsPersonaDireccion.Position);
                            bsPersonaDireccion.DataSource = oCliente.Persona.ListaPersonaDireccion;
                            bsPersonaDireccion.ResetBindings(false);

                            base.QuitarDetalle();
                        }
                    }
                }
                else if (tbClientes.SelectedTab == tpAsociados)
                {
                    String Valor = ((ParTabla)cboTipoCliente.SelectedItem).NemoTecnico;

                    if (Valor == "TIPCLIREF")
                    {
                        if (bsClienteAsociados.Current != null)
                        {
                            if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                            {
                                AgenteMaestro.Proxy.EliminarClienteAsociados(((ClienteAsociadosE)bsClienteAsociados.Current).idPersona, ((ClienteAsociadosE)bsClienteAsociados.Current).IdEmpresa, ((ClienteAsociadosE)bsClienteAsociados.Current).IdAsociado);
                                oCliente.ListaClienteAsociados.RemoveAt(bsClienteAsociados.Position);
                                bsClienteAsociados.DataSource = oCliente.ListaClienteAsociados;
                                bsClienteAsociados.ResetBindings(false);
                                base.QuitarDetalle();
                            }
                        }
                    }
                }
                else if (tbClientes.SelectedTab == tpAvales)
                {
                    if (bsClienteAval.Current != null)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                        {
                            AgenteMaestro.Proxy.EliminarClienteAval(((ClienteAvalE)bsClienteAval.Current).idEmpresa, ((ClienteAvalE)bsClienteAval.Current).idPersona);
                            oCliente.ListaAvales.RemoveAt(bsClienteAval.Position);
                            bsClienteAval.DataSource = oCliente.ListaAvales;
                            bsClienteAval.ResetBindings(false);
                            base.QuitarDetalle();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();

                if (Convert.ToString(((ParTabla)cboTipoCliente.SelectedItem).NemoTecnico) != "TIPCLIREF")
                {
                    tbClientes.TabPages.Remove(tpAsociados);
                }

                //BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
                //BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
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
            Int32 tipPersona = Convert.ToInt32(cboTipoPersona.SelectedValue);

            switch (tipPersona)
            {
                case 102001: //Personas Juridicas
                    txtRazon.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtComercial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtApePat.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtApeMat.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtNombres.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
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

                            //txtRuc.Text = oFrm.Ruc;
                            //txtRazon.Text = oFrm.RazonSocial;
                            //txtComercial.Text = oFrm.NomComercial;
                            //sDir = oFrm.Direccion;

                            //for (Int32 i = 0; i < cboDepartamento.Items.Count; i++)
                            //{
                            //    num = sDir.IndexOf(cboDepartamento.GetItemText(cboDepartamento.Items[i]));

                            //    if (num >= 20)
                            //    {
                            //        dirTemp = Global.Extraer(sDir, num);
                            //        ListaUbigeo = new List<String>(dirTemp.Split('-'));

                            //        num = ListaUbigeo[0].IndexOf(")");

                            //        if (num > 0)
                            //        {
                            //            ListaUbigeo[0] = ListaUbigeo[0].Substring(num + 1);
                            //        }

                            //        if (ListaUbigeo.Count != 0)
                            //        {
                            //            sDep = ListaUbigeo[0].Trim().ToString();
                            //            sPro = ListaUbigeo[1].ToString().Trim();
                            //            sDis = ListaUbigeo[2].Trim().ToString();

                            //            cboDepartamento.SelectedValue = sDep.Trim();
                            //            cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                            //            cboProvincia.SelectedValue = sPro.Trim();
                            //            cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
                            //            cboDistrito.Text = sDis.Trim();

                            //            break;
                            //        }
                            //    }
                            //}

                            //sDir = sDir.Replace(sDep + " - " + sPro + " - " + sDis, String.Empty);
                            //sDir = sDir.Replace(sDep + "  - " + sPro + "  - " + sDis, String.Empty);
                            //sDir = sDir.Replace(sDep + " - " + sPro + "  - " + sDis, String.Empty);
                            //txtDireccion.Text = sDir.Trim();
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
                                    //Encuentro = item.ToUpper().IndexOf("BUENOS CONTRIBUYENTES") > 0;

                                    //if (Encuentro)
                                    //{
                                    //    chkContribuyente.Checked = true;
                                    //}

                                    Encuentro = item.ToUpper().IndexOf("RETENCIÓN DE IGV") > 0;

                                    if (Encuentro)
                                    {
                                        chkRetencion.Checked = true;
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

                        case 102002: //Personas Natural con Ruc

                            #region Personas Natural con Ruc

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
                            //sDir = oFrm.Direccion;

                            //for (Int32 i = 0; i < cboDepartamento.Items.Count; i++)
                            //{
                            //    num = sDir.IndexOf(cboDepartamento.GetItemText(cboDepartamento.Items[i]));

                            //    if (num >= 20)
                            //    {
                            //        dirTemp = Global.Extraer(sDir, num);
                            //        ListaUbigeo = new List<String>(dirTemp.Split('-'));

                            //        num = ListaUbigeo[0].IndexOf(")");

                            //        if (num > 0)
                            //        {
                            //            ListaUbigeo[0] = ListaUbigeo[0].Substring(num + 1);
                            //        }

                            //        if (ListaUbigeo.Count != 0)
                            //        {
                            //            sDep = ListaUbigeo[0].Trim().ToString();
                            //            sPro = ListaUbigeo[1].ToString().Trim();
                            //            sDis = ListaUbigeo[2].Trim().ToString();

                            //            cboDepartamento.SelectedValue = sDep;
                            //            cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                            //            cboProvincia.SelectedValue = sPro;
                            //            cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
                            //            cboDistrito.Text = sDis;

                            //            break;
                            //        }
                            //    }
                            //}

                            //sDir = sDir.Replace(sDep + " - " + sPro + " - " + sDis, String.Empty);
                            //sDir = sDir.Replace(sDep + "  - " + sPro + "  - " + sDis, String.Empty);
                            //sDir = sDir.Replace(sDep + " - " + sPro + "  - " + sDis, String.Empty);
                            //txtDireccion.Text = sDir.Trim();
                            Direccion = Global.DejarSoloUnEspacio(oFrm.Direccion.Trim());
                            Padrones = new List<String>(oFrm.Padrones);

                            if (Padrones.Count > Variables.Cero)
                            {
                                Boolean Encuentro = false;

                                foreach (String item in Padrones)
                                {
                                    //Encuentro = item.ToUpper().IndexOf("BUENOS CONTRIBUYENTES") > 0;

                                    //if (Encuentro)
                                    //{
                                    //    chkContribuyente.Checked = true;
                                    //}

                                    Encuentro = item.ToUpper().IndexOf("RETENCIÓN DE IGV") > 0;

                                    if (Encuentro)
                                    {
                                        chkRetencion.Checked = true;
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
                    cboPaises.Enabled = false;
                   // cboPaises_SelectionChangeCommitted(new Object(), new EventArgs());

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
                    txtNombres.Text = oFrm.Informacion.Nombres.Replace("�", "Ñ");
                    txtApePat.Text = oFrm.Informacion.ApePaterno.Replace("�", "Ñ");
                    txtApeMat.Text = oFrm.Informacion.ApeMaterno.Replace("�", "Ñ");

                    NombreCompleto.Append(oFrm.Informacion.ApePaterno.Replace("�", "Ñ"));
                    NombreCompleto.Append(" ");
                    NombreCompleto.Append(oFrm.Informacion.ApeMaterno.Replace("�", "Ñ"));
                    NombreCompleto.Append(" ");
                    NombreCompleto.Append(oFrm.Informacion.Nombres.Replace("�", "Ñ"));
                    txtRazon.Text = NombreCompleto.ToString();
                    txtComercial.Text = NombreCompleto.ToString();
                }
            }
        }

        private void chkBaja_Click(object sender, EventArgs e)
        {
            if (chkBaja.Checked)
            {
                if (string.IsNullOrEmpty(txtFecBaja.Text))
                {
                    oCliente.fecBaja = DateTime.Now;
                    txtFecBaja.Text = DateTime.Now.ToString();
                }
            }
            else
            {
                txtFecBaja.Text = String.Empty;
            }
        }

        private void cboTipoPersona_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboTipoCliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dtpActividades_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }        

        private void btNuevaUbicacion_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarDetalle();
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
                QuitarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvSucursales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((PersonaDireccionE)bsPersonaDireccion.Current), "dir");
            }
        }

        private void btAgre_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btEli_Click(object sender, EventArgs e)
        {
            try
            {
                QuitarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvAsociados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((ClienteAsociadosE)bsClienteAsociados.Current), "refe");
            }
        }

        private void cboTipoCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToString(((ParTabla)cboTipoCliente.SelectedItem).NemoTecnico) == "TIPCLIREF")
            {
                if (tbClientes.TabPages.Count == 3)
                {
                    tbClientes.TabPages.Add(tpAsociados);
                }
            }
            else
            {
                tbClientes.TabPages.Remove(tpAsociados);
            }
        }

        private void btNuevoAval_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btQuitarAval_Click(object sender, EventArgs e)
        {
            try
            {
                QuitarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvAvales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((ClienteAvalE)bsClienteAval.Current), "aval");
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

        #endregion

    }
}
