using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Seguridad;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ControlesWinForm;
using ClienteWinForm.Seguridad;
using ClienteWinForm.Tesoreria;

namespace ClienteWinForm.Maestros
{

    public partial class FrmDlgPersona : FrmMantenimientoBase
    {

        #region Constructores

        public FrmDlgPersona()
        {
            InitializeComponent();
        }
        
        public FrmDlgPersona(String TipoFondoNuevo_)
           : this()
        {
            TipoFondo = TipoFondoNuevo_;
        }

        #endregion

        #region Variables

        public Persona oPersona = null;
        public ClienteE vCliente = null;
        public ProveedorE vProveedor = null;
        public Usuario vUsuario = null;
        public OpeLogisticoE vOperador = null;
        public BancosE vBanco = null;
        public VendedoresE vVendedor = null;
        public FondoFijoE vFondoFijo = null;
        String TipoFondo = String.Empty;
        public Int32 Opcion;
        public Int32 OpcionVentana = 0;
        //Se debe de enviar el tipo de persona (cliente, proveedor, trabajador, etc), y agregarlo en el switch
        public EnumTipoRolPersona Enumerado;
        String Existe = String.Empty;
        public GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        public MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        public SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }

        #endregion

        #region Procedimientos Usuario

        private void LlenarCombos()
        {
            List<EnumParTabla> listaPartabla = new List<EnumParTabla>
            {
                EnumParTabla.TipoPersona
            };

            Dictionary<EnumParTabla, List<ParTabla>> listaParametro = AgenteGenerales.Proxy.ListarParTablaPorListaGrupo(listaPartabla);
            ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoPersona, listaParametro[EnumParTabla.TipoPersona], "IdParTabla", "Nombre");
        }

        private void ListarComboPorTipoDocumento()
        {
            List<ParTabla> ListaDocumentos = new List<ParTabla>();
            ListaDocumentos = AgenteGenerales.Proxy.ListarParTablaPorGrupo(Convert.ToInt32(EnumParTabla.TipoDocumento), "");

            // Persona Jurídica
            if (Convert.ToString(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Juridica).ToString())
            {
                List<ParTabla> ListaDocumentosJuridica = new List<ParTabla>();
                ListaDocumentosJuridica = (from x in ListaDocumentos where x.IdParTabla == Convert.ToInt32(EnumTipoDocumento.Ruc) select x).ToList();
                ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosJuridica, "IdParTabla", "Nombre");

                cboTipoDocumento.Enabled = false;
                txtNroDocumento.Enabled = true;
                txtNroDocumento.MaxLength = 11;
                txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
                txtNroDocumento.Focus();
            }
            // Persona Natural con Ruc
            else if (Convert.ToString(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Ruc).ToString())
            {
                List<ParTabla> ListaDocumentosNatural = new List<ParTabla>();
                ListaDocumentosNatural = (from x in ListaDocumentos where x.IdParTabla == Convert.ToInt32(EnumTipoDocumento.Ruc) select x).ToList();
                ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosNatural, "IdParTabla", "Nombre");

                txtNroDocumento.Enabled = true;
                txtNroDocumento.MaxLength = 11;
                txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
                cboTipoDocumento.Enabled = false;
                cboTipoDocumento.SelectedValue = (int)EnumTipoDocumento.Ruc;

                txtNroDocumento.Focus();
            }
            // Persona Natural sin Ruc
            else if (Convert.ToString(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc).ToString())
            {
                List<ParTabla> ListaNaturalSinRuc = new List<ParTabla>();
                ListaNaturalSinRuc = (from x in ListaDocumentos where x.IdParTabla == Convert.ToInt32(EnumTipoDocumento.Dni) select x).ToList();
                ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaNaturalSinRuc, "IdParTabla", "Nombre");

                txtNroDocumento.Enabled = true;
                txtNroDocumento.MaxLength = 8;
                txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
                cboTipoDocumento.Enabled = false;
                txtNroDocumento.Focus();
            }
            // Otros
            else if (Convert.ToString(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Otros).ToString())
            {
                List<ParTabla> ListaDocumentosNatural = new List<ParTabla>();
                ListaDocumentosNatural = (from x in ListaDocumentos where x.IdParTabla != Convert.ToInt32(EnumTipoDocumento.Ruc) && x.IdParTabla != Convert.ToInt32(EnumTipoDocumento.Dni) select x).ToList();
                ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosNatural, "IdParTabla", "Nombre");

                txtNroDocumento.Enabled = true;
                txtNroDocumento.MaxLength = 20;
                txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.Defecto;
                cboTipoDocumento.Enabled = true;
                cboTipoDocumento.Focus();

                if (TipoFondo == "168")
                {
                    cboTipoDocumento.Enabled = false;                  
                }

                if (TipoFondo == "102")
                {
                    cboTipoPersona.Enabled = false;
                    cboTipoDocumento.Enabled = false;
                    cboTipoDocumento.SelectedIndex = 1;
                }
            }
            else
            {
                cboTipoDocumento.Enabled = false;
                txtNroDocumento.Text = String.Empty;
                txtNroDocumento.Enabled = false;
            }
        }

        #endregion

        #region Eventos

        private void FrmDlgPersona_Load(object sender, EventArgs e)
        {
            LlenarCombos();

            if (TipoFondo == "168")
            {
                if (Enumerado == EnumTipoRolPersona.FondosFijos)
                {
                    cboTipoPersona.SelectedValue = Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc);
                    cboTipoPersona.Enabled = false;
                }
            }

            if (TipoFondo == "102")
            {
                if (Enumerado == EnumTipoRolPersona.FondosFijos)
                {
                    cboTipoPersona.SelectedValue = Convert.ToInt32(enumTipoPersona.Otros);
                }
            }

            if (TipoFondo == "")
            {
                switch (Enumerado)
                {
                    case EnumTipoRolPersona.Cliente:
                        cboTipoPersona.SelectedValue = Convert.ToInt32(enumTipoPersona.Juridica);
                        break;
                    case EnumTipoRolPersona.Proveedor:
                        cboTipoPersona.SelectedValue = Convert.ToInt32(enumTipoPersona.Juridica);
                        break;
                    case EnumTipoRolPersona.Trabajador:
                        cboTipoPersona.SelectedValue = Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc);
                        break;
                    case EnumTipoRolPersona.Usuario:
                        cboTipoPersona.SelectedValue = Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc);
                        break;
                    case EnumTipoRolPersona.Chofer:
                        break;
                    case EnumTipoRolPersona.Vendedor:
                        cboTipoPersona.SelectedValue = Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc);
                        break;
                    case EnumTipoRolPersona.OperadorLog:
                        cboTipoPersona.SelectedValue = Convert.ToInt32(enumTipoPersona.Juridica);
                        break;
                    case EnumTipoRolPersona.Bancos:
                        cboTipoPersona.SelectedValue = Convert.ToInt32(enumTipoPersona.Juridica);
                        break;
                    default:
                        break;
                }
            }

            txtNroDocumento.Focus();
            cboTipoPersona_SelectionChangeCommitted(new object(), new EventArgs());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtNroDocumento.Text) && Convert.ToString(cboTipoPersona.SelectedValue).CompareTo(Convert.ToInt32(enumTipoPersona.Juridica).ToString()) == 0)
                {
                    Global.MensajeFault("Debe ingresar Nro. de Documento");
                    txtNroDocumento.Focus();
                    return;
                }
                else if (txtNroDocumento.TextLength != 11 && Convert.ToString(cboTipoPersona.SelectedValue).CompareTo(Convert.ToInt32(enumTipoPersona.Juridica).ToString()) == 0)
                {
                    Global.MensajeFault("El RUC debe ser de 11 dígitos");
                    txtNroDocumento.Focus();
                    return;
                }
                else if (txtNroDocumento.TextLength != 8 && Convert.ToString(cboTipoPersona.SelectedValue).CompareTo(Convert.ToInt32(enumTipoPersona.Natural_Ruc).ToString()) == 0 && Convert.ToString(cboTipoDocumento.SelectedValue).CompareTo(Convert.ToInt32(EnumTipoDocumento.Dni).ToString()) == 0)
                {
                    Global.MensajeFault("El DNI debe ser de 8 dígitos");
                    txtNroDocumento.Focus();
                    return;
                }
                else if (txtNroDocumento.Text.Substring(0, 1) == "1" && Convert.ToString(cboTipoPersona.SelectedValue).CompareTo(Convert.ToInt32(enumTipoPersona.Juridica).ToString()) == 0)
                {
                    Global.MensajeFault("Debe escoger otro tipo de persona.\n\rEl número es de una Persona Natural c/s ruc.");
                    return;
                }
                else if (txtNroDocumento.Text.Substring(0, 1) == "2" && Convert.ToString(cboTipoPersona.SelectedValue).CompareTo(Convert.ToInt32(enumTipoPersona.Natural_Ruc).ToString()) == 0)
                {
                    Global.MensajeFault("Debe escoger otro tipo de persona.\n\rEl número es de una Persona Jurídica");
                    return;
                }
                else if (txtNroDocumento.TextLength != 8 && Convert.ToString(cboTipoPersona.SelectedValue).CompareTo(Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc).ToString()) == 0 && Convert.ToString(cboTipoDocumento.SelectedValue).CompareTo(Convert.ToInt32(EnumTipoDocumento.Dni).ToString()) == 0)
                {
                    Global.MensajeFault("El DNI debe ser de 8 dígitos");
                    txtNroDocumento.Focus();
                    return;
                }
                else
                {
                    Persona vPersona = new Persona();

                    oPersona = new Persona();
                    vCliente = new ClienteE();
                    vProveedor = new ProveedorE();
                    vUsuario = new Usuario();
                    vOperador = new OpeLogisticoE();
                    vBanco = new BancosE();
                    vVendedor = new VendedoresE();
                    vFondoFijo = new FondoFijoE();

                    //Persona Juridica
                    if (Convert.ToString(cboTipoPersona.SelectedValue).CompareTo(Convert.ToInt32(enumTipoPersona.Juridica).ToString()) == 0)
                    {
                        oPersona.TipoPersona = Convert.ToInt32(cboTipoPersona.SelectedValue); //Convert.ToInt32(enumTipoPersona.Juridica);
                        oPersona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);  //Convert.ToInt32(EnumTipoDocumento.Ruc);
                        oPersona.RUC = txtNroDocumento.Text.Trim();

                        vPersona = AgenteMaestros.Proxy.RecuperarPersonaPorNroDocumento(oPersona.RUC);

                        switch (Enumerado)
                        {
                            #region Cliente

                            case EnumTipoRolPersona.Cliente:

                                if (vPersona != null)
                                {
                                    vCliente = AgenteMaestros.Proxy.RecuperarClientePorId(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "N");

                                    if (vCliente != null)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como Cliente.\n\rActualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del Cliente.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmClientes);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmClientes(vCliente, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };
                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Proveedor

                            case EnumTipoRolPersona.Proveedor:

                                DialogResult = DialogResult.OK;

                                if (vPersona != null)
                                {
                                    vProveedor = AgenteMaestros.Proxy.RecuperarProveedorPorID(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "N");

                                    if (vProveedor.IdPersona != 0)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como Proveedor. \n\r Actualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del Proveedor.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProveedores2);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmProveedores2(vProveedor, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };

                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Usuario

                            case EnumTipoRolPersona.Usuario:

                                DialogResult = DialogResult.OK;

                                if (vPersona != null)
                                {
                                    vUsuario = AgenteSeguridad.Proxy.RecuperarUsuarioPorCodigo(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "S");

                                    if (vUsuario.IdPersona != 0)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como Usuario. \n\r Actualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        vUsuario.Persona = vPersona;
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del Usuario.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmUsuario);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new FrmUsuario(vUsuario, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };
                                    oFrm.Show();
                                }

                                break;
                            #endregion

                            #region Chofer
                            case EnumTipoRolPersona.Chofer:

                                //if (vPersona != null)
                                //{
                                //    vChofer = AgenteMaestros.Proxy.RecuperarChoferPorID(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                                //    if (vChofer.IdPersona != 0)
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA COMO CHOFER. \n\r ACTUALICE SUS DATOS.");
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                //        persona = vPersona;
                                //    }
                                //    else
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA. \n\r COMPLETE LOS DATOS DEL CHOFER.");
                                //        persona = vPersona;
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                //    }
                                //}
                                //else
                                //{
                                //    // if (Infraestructura.Global.MensajeConfirmacion() == DialogResult.No)
                                //    // {
                                //    //     return;
                                //    // }
                                //    opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                //}
                                break;
                            #endregion

                            #region Vendedor

                            case EnumTipoRolPersona.Vendedor:

                                if (vPersona != null)
                                {
                                    vVendedor = AgenteMaestros.Proxy.RecuperarVendedorPorId(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                                    if (vVendedor != null && vVendedor.idPersona != 0)
                                    {
                                        MessageBox.Show("La persona ya esta registrada como Vendedor.\n\rActualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        MessageBox.Show("La persona ya esta registrada. \n\r Complete los datos del Vendedor.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                    oPersona.TipoPersona = Convert.ToInt32(enumTipoPersona.Juridica);
                                    oPersona.TipoDocumento = Convert.ToInt32(EnumTipoDocumento.Ruc);
                                    oPersona.RUC = txtNroDocumento.Text;
                                    oPersona.NroDocumento = txtNroDocumento.Text;
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVendedor);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmVendedor(vVendedor, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };
                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Trabajador

                            case EnumTipoRolPersona.Trabajador:

                                //if (vPersona != null)
                                //{
                                //    vTrabajador = AgenteRRHH.Proxy.RecuperarTrabajadorPorCodigo(vTrabajador.IdEmpresa, vTrabajador.IdPersona);

                                //    if (vTrabajador.IdPersona != 0)
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA COMO TRABAJADOR. \n\r ACTUALICE SUS DATOS.");
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                //        persona = vPersona;
                                //        //persona.Nombres = persona.Nombres;
                                //    }
                                //    else
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA. \n\r COMPLETE LOS DATOS DEL TRABAJADOR.");
                                //        persona = vPersona;
                                //        //persona.Nombres = persona.Nombres;
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                //    }
                                //}
                                //else
                                //{
                                //    // if (Infraestructura.Global.MensajeConfirmacion() == DialogResult.No)
                                //    // {
                                //    //     return;
                                //    // }
                                //    opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                //}
                                break;
                            #endregion

                            #region Operador Logistico

                            case EnumTipoRolPersona.OperadorLog:

                                if (vPersona != null)
                                {
                                    vOperador = AgenteMaestros.Proxy.RecuperarOpeLogPorId(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                                    if (vOperador != null)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como Operador Logístico.\n\rActualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del Operador Logístico.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOperadorLogistico);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmOperadorLogistico(vOperador, oPersona, Opcion);
                                    oFrm.MdiParent = this.MdiParent;
                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Bancos

                            case EnumTipoRolPersona.Bancos:

                                if (vPersona != null)
                                {
                                    vBanco = AgenteMaestros.Proxy.RecuperarBancoPorId(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "N");

                                    if (vBanco != null)
                                    {
                                        Global.MensajeComunicacion("Este auxiliar ya esta registrado como Banco.\n\rActualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("Este auxiliar ya esta registrado. \n\r Complete los datos para el Banco.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmBancos);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmBancos(vBanco, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };

                                    oFrm.Show();
                                }

                                break;

                            #endregion
                        }
                    }
                    // Persona Natural con Ruc
                    else if (Convert.ToString(cboTipoPersona.SelectedValue).CompareTo(Convert.ToInt32(enumTipoPersona.Natural_Ruc).ToString()) == 0)
                    {
                        oPersona.TipoPersona = Convert.ToInt32(cboTipoPersona.SelectedValue); //Convert.ToInt32(enumTipoPersona.Natural_Ruc);
                        oPersona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue); //Convert.ToInt32(EnumTipoDocumento.Dni);
                        oPersona.RUC = txtNroDocumento.Text;

                        vPersona = AgenteMaestros.Proxy.RecuperarPersonaPorNroDocumento(oPersona.RUC);

                        switch (Enumerado)
                        {
                            #region Cliente

                            case EnumTipoRolPersona.Cliente:

                                if (vPersona != null)
                                {
                                    vCliente = AgenteMaestros.Proxy.RecuperarClientePorId(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "N");

                                    if (vCliente != null)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como Cliente.\n\rActualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del Cliente.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmClientes);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmClientes(vCliente, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };
                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Proveedor

                            case EnumTipoRolPersona.Proveedor:

                                DialogResult = DialogResult.OK;

                                if (vPersona != null)
                                {
                                    vProveedor = AgenteMaestros.Proxy.RecuperarProveedorPorID(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "N");

                                    if (vProveedor.IdPersona != 0)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como Proveedor. \n\r Actualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del Proveedor.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProveedores2);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmProveedores2(vProveedor, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };

                                    oFrm.Show();
                                }

                                break;
                            #endregion

                            #region Usuario

                            case EnumTipoRolPersona.Usuario:

                                DialogResult = DialogResult.OK;

                                if (vPersona != null)
                                {
                                    vUsuario = AgenteSeguridad.Proxy.RecuperarUsuarioPorCodigo(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "S");

                                    if (vUsuario.IdPersona != 0)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como Usuario. \n\r Actualice los datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        vUsuario.Persona = vPersona;
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del Usuario.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmUsuario);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new FrmUsuario(vUsuario, oPersona, Opcion);
                                    oFrm.MdiParent = MdiParent;
                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Chofer
                            case EnumTipoRolPersona.Chofer:

                                //if (vPersona != null)
                                //{
                                //    vChofer = AgenteMaestros.Proxy.RecuperarChoferPorID(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                                //    if (vChofer.IdPersona != 0)
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA COMO CHOFER. \n\r ACTUALICE SUS DATOS.");
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                //        persona = vPersona;
                                //    }
                                //    else
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA. \n\r COMPLETE LOS DATOS DEL CHOFER.");
                                //        persona = vPersona;
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                //    }
                                //}
                                //else
                                //{
                                //    // if (Infraestructura.Global.MensajeConfirmacion() == DialogResult.No)
                                //    // {
                                //    //     return;
                                //    //}
                                //    opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                //}
                                break;
                            #endregion

                            #region Vendedor

                            case EnumTipoRolPersona.Vendedor:

                                if (vPersona != null)
                                {
                                    vVendedor = AgenteMaestros.Proxy.RecuperarVendedorPorId(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                                    if (vVendedor != null && vVendedor.idPersona != 0)
                                    {
                                        MessageBox.Show("La persona ya esta registrada como Vendedor.\n\rActualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        MessageBox.Show("La persona ya esta registrada. \n\r Complete los datos del Vendedor.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                    oPersona.TipoPersona = Convert.ToInt32(enumTipoPersona.Natural_Ruc);
                                    oPersona.TipoDocumento = Convert.ToInt32(EnumTipoDocumento.Ruc);
                                    oPersona.RUC = txtNroDocumento.Text;
                                    oPersona.NroDocumento = txtNroDocumento.Text;
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVendedor);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmVendedor(vVendedor, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };

                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Trabajador

                            case EnumTipoRolPersona.Trabajador:

                                //if (vPersona != null)
                                //{
                                //    vTrabajador = AgenteRRHH.Proxy.RecuperarTrabajadorPorCodigo(VariablesLocales.SesionLocal.IdEmpresa, vPersona.IdPersona);

                                //    if (vTrabajador.IdPersona != 0)
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA COMO TRABAJADOR. \n\r ACTUALICE SUS DATOS.");
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                //        persona = vPersona;
                                //    }
                                //    else
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA. \n\r COMPLETE LOS DATOS DEL TRABAJADOR.");
                                //        persona = vPersona;
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                //    }
                                //}
                                //else
                                //{
                                //    opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                //}
                                break;
                            #endregion

                            #region Operador Logistico

                            case EnumTipoRolPersona.OperadorLog:

                                if (vPersona != null)
                                {
                                    vOperador = AgenteMaestros.Proxy.RecuperarOpeLogPorId(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                                    if (vCliente != null)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como Operador Logístico.\n\rActualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del Operador Logístico.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOperadorLogistico);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmOperadorLogistico(vOperador, oPersona, Opcion);
                                    oFrm.MdiParent = this.MdiParent;
                                    oFrm.Show();
                                }

                                break;

                            #endregion
                        }
                    }
                    // Persona Natural sin RUC
                    else if (cboTipoPersona.SelectedValue.ToString().Equals(Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc).ToString()) == true)
                    {
                        oPersona.TipoPersona = Convert.ToInt32(cboTipoPersona.SelectedValue); //Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc);
                        oPersona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                        oPersona.NroDocumento = txtNroDocumento.Text;
                        oPersona.RUC = txtNroDocumento.Text;
                        vPersona = AgenteMaestros.Proxy.RecuperarPersonaPorDNI(oPersona.RUC);

                        switch (Enumerado)
                        {
                            #region Cliente

                            case EnumTipoRolPersona.Cliente:

                                if (vPersona != null)
                                {
                                    vCliente = AgenteMaestros.Proxy.RecuperarClientePorId(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "N");

                                    if (vCliente != null)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como Cliente.\n\rActualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del Cliente.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmClientes);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmClientes(vCliente, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };

                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Proveedor

                            case EnumTipoRolPersona.Proveedor:

                                DialogResult = DialogResult.OK;

                                if (vPersona != null)
                                {
                                    vProveedor = AgenteMaestros.Proxy.RecuperarProveedorPorID(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "N");

                                    if (vProveedor.IdPersona != 0)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como Proveedor. \n\r Actualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del Proveedor.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProveedores2);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmProveedores2(vProveedor, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };

                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Usuario

                            case EnumTipoRolPersona.Usuario:

                                DialogResult = DialogResult.OK;

                                if (vPersona != null)
                                {
                                    vUsuario = AgenteSeguridad.Proxy.RecuperarUsuarioPorCodigo(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "S");

                                    if (vUsuario.IdPersona != 0)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como Usuario. \n\r Actualice los datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        vUsuario.Persona = vPersona;
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del Usuario.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmUsuario);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new FrmUsuario(vUsuario, oPersona, Opcion);
                                    oFrm.MdiParent = MdiParent;
                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Chofer
                            case EnumTipoRolPersona.Chofer:

                                //if (vPersona != null)
                                //{
                                //    vChofer = AgenteMaestros.Proxy.RecuperarChoferPorID(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                                //    if (vChofer.IdPersona != 0)
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA COMO CHOFER. \n\r ACTUALICE SUS DATOS.");
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                //        persona = vPersona;
                                //    }
                                //    else
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA. \n\r COMPLETE LOS DATOS DEL CHOFER.");
                                //        persona = vPersona;
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                //    }
                                //}
                                //else
                                //{
                                //    if (Infraestructura.Global.MensajeConfirmacion() == DialogResult.No)
                                //    {
                                //        return;
                                //    }
                                //    opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                //}
                                break;
                            #endregion

                            #region Vendedor

                            case EnumTipoRolPersona.Vendedor:

                                if (vPersona != null)
                                {
                                    vVendedor = AgenteMaestros.Proxy.RecuperarVendedorPorId(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                                    if (vVendedor != null && vVendedor.idPersona != 0)
                                    {
                                        MessageBox.Show("La persona ya esta registrada como Vendedor.\n\rActualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        MessageBox.Show("La persona ya esta registrada. \n\r Complete los datos del Vendedor.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                    oPersona.TipoPersona = Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc);
                                    oPersona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                                    oPersona.NroDocumento = txtNroDocumento.Text;
                                    oPersona.RUC = txtNroDocumento.Text;
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVendedor);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmVendedor(vVendedor, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };

                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Trabajador

                            case EnumTipoRolPersona.Trabajador:

                                //if (vPersona != null)
                                //{
                                //    vTrabajador = AgenteRRHH.Proxy.RecuperarTrabajadorPorCodigo(VariablesLocales.SesionLocal.IdEmpresa, vPersona.IdPersona);

                                //    if (vTrabajador.IdPersona != 0)
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA COMO TRABAJADOR. \n\r ACTUALICE SUS DATOS.");
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                //        persona = vPersona;
                                //    }
                                //    else
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA. \n\r COMPLETE LOS DATOS DEL TRABAJADOR.");
                                //        persona = vPersona;
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                //    }
                                //}
                                //else
                                //{
                                //    opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                //}
                                break;
                            #endregion

                            #region Operador Logistico

                            case EnumTipoRolPersona.OperadorLog:

                                Global.MensajeComunicacion("No puede ser Persona Natural");
                                break;

                            #endregion

                            #region FondosFijos

                            case EnumTipoRolPersona.FondosFijos:

                                if (vPersona != null)
                                {
                                    vFondoFijo = AgenteTesoreria.Proxy.ObtenerFondoFijo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, vPersona.IdPersona);

                                    if (vFondoFijo != null && vFondoFijo.idPersona != 0)
                                    {
                                        MessageBox.Show("La persona ya esta registrada en Fondo Fijo.\n\rActualice sus datos .");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        MessageBox.Show("La persona ya esta registrada. \n\r Complete los datos.");
                                        oPersona = vPersona;
                                        vFondoFijo = new FondoFijoE();
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                        Existe = "s";
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                    oPersona.TipoPersona = Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc);
                                    oPersona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                                    oPersona.NroDocumento = txtNroDocumento.Text;
                                    oPersona.RUC = txtNroDocumento.Text;
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmFondoFijo);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    vFondoFijo.idPersona = oPersona.IdPersona;
                                    vFondoFijo.desFondo = oPersona.RazonSocial;
                                    vFondoFijo.desPersona = oPersona.Nombres;
                                    vFondoFijo.TipoFondo = TipoFondo;

                                    oPersona.TipoPersona = Convert.ToInt32(enumTipoPersona.Otros);
                                    oPersona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmFondoFijo(vFondoFijo, oPersona, Opcion, Existe)
                                    {
                                        MdiParent = MdiParent
                                    };

                                    oFrm.Show();
                                }
                                break;

                         #endregion
                        }
                    }
                    // OTROS
                    else if (cboTipoPersona.SelectedValue.ToString().Equals(Convert.ToInt32(enumTipoPersona.Otros).ToString()) == true)
                    {
                        oPersona.TipoPersona = Convert.ToInt32(cboTipoPersona.SelectedValue); //Convert.ToInt32(enumTipoPersona.Otros);
                        oPersona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                        oPersona.NroDocumento = txtNroDocumento.Text;
                        oPersona.RUC = txtNroDocumento.Text;

                        vPersona = AgenteMaestros.Proxy.RecuperarPersonaPorNroDocumento(oPersona.RUC);

                        switch (Enumerado)
                        {
                            #region Cliente

                            case EnumTipoRolPersona.Cliente:

                                if (vPersona != null)
                                {
                                    vCliente = AgenteMaestros.Proxy.RecuperarClientePorId(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "N");

                                    if (vCliente != null)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como Cliente.\n\rActualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del Cliente.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmClientes);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmClientes(vCliente, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };

                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Proveedor

                            case EnumTipoRolPersona.Proveedor:

                                DialogResult = DialogResult.OK;

                                if (vPersona != null)
                                {
                                    vProveedor = AgenteMaestros.Proxy.RecuperarProveedorPorID(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "N");

                                    if (vProveedor.IdPersona != 0)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como Proveedor. \n\r Actualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del Proveedor.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProveedores2);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmProveedores2(vProveedor, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };

                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Usuario

                            case EnumTipoRolPersona.Usuario:

                                this.DialogResult = DialogResult.OK;

                                if (vPersona != null)
                                {
                                    vUsuario = AgenteSeguridad.Proxy.RecuperarUsuarioPorCodigo(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "S");

                                    if (vUsuario.IdPersona != 0)
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada como usuario. \n\r Actualice los datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("La persona ya esta registrada. \n\r Complete los datos del usuario.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                }

                                if (OpcionVentana != 0)
                                {
                                    FrmUsuario oFrm = new FrmUsuario();

                                    if (oFrm.ValidarIngresoVentana())
                                    {
                                        oFrm.MdiParent = this.MdiParent;
                                        oFrm.OpcionGrabar = Opcion;
                                        oFrm.oPersona = oPersona;
                                        oFrm.oUsuario = vUsuario;

                                        oFrm.Show();
                                    }
                                }

                                break;

                            #endregion

                            #region Chofer
                            case EnumTipoRolPersona.Chofer:

                                //if (vPersona != null)
                                //{
                                //    vChofer = AgenteMaestros.Proxy.RecuperarChoferPorID(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                                //    if (vChofer.IdPersona != 0)
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA COMO CHOFER. \n\r ACTUALICE SUS DATOS.");
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                //        persona = vPersona;
                                //    }
                                //    else
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA. \n\r COMPLETE LOS DATOS DEL CHOFER.");
                                //        persona = vPersona;
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                //    }
                                //}
                                //else
                                //{
                                //    // if (Infraestructura.Global.MensajeConfirmacion() == DialogResult.No)
                                //    // {
                                //    //     return;
                                //    //}
                                //    opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                //}
                                break;
                            #endregion

                            #region Vendedor

                            case EnumTipoRolPersona.Vendedor:

                                if (vPersona != null)
                                {
                                    vVendedor = AgenteMaestros.Proxy.RecuperarVendedorPorId(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                                    if (vVendedor != null && vVendedor.idPersona != 0)
                                    {
                                        MessageBox.Show("La persona ya esta registrada como Vendedor.\n\rActualice sus datos por favor.");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        MessageBox.Show("La persona ya esta registrada. \n\r Complete los datos del Vendedor.");
                                        oPersona = vPersona;
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                    oPersona.TipoPersona = Convert.ToInt32(enumTipoPersona.Otros);
                                    oPersona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                                    oPersona.NroDocumento = txtNroDocumento.Text;
                                    oPersona.RUC = txtNroDocumento.Text;
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVendedor);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmVendedor(vVendedor, oPersona, Opcion)
                                    {
                                        MdiParent = MdiParent
                                    };

                                    oFrm.Show();
                                }

                                break;

                            #endregion

                            #region Trabajador

                            case EnumTipoRolPersona.Trabajador:

                                //if (vPersona != null)
                                //{
                                //    vTrabajador = AgenteRRHH.Proxy.RecuperarTrabajadorPorCodigo(VariablesLocales.SesionLocal.IdEmpresa, vPersona.IdPersona);

                                //    if (vTrabajador.IdPersona != 0)
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA COMO TRABAJADOR. \n\r ACTUALICE SUS DATOS.");
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                //        persona = vPersona;
                                //    }
                                //    else
                                //    {
                                //        MessageBox.Show("LA PERSONA YA ESTA REGISTRADA. \n\r COMPLETE LOS DATOS DEL TRABAJADOR.");
                                //        persona = vPersona;
                                //        opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                //    }
                                //}
                                //else
                                //{
                                //    opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                //}
                                break;
                            #endregion

                            #region Operador Logistico

                            case EnumTipoRolPersona.OperadorLog:

                                Global.MensajeComunicacion("No puede ser Otro tipo de documento");
                                break;

                            #endregion

                            #region Fondos Fijos

                            case EnumTipoRolPersona.FondosFijos:

                                if (vPersona != null)
                                {
                                    vFondoFijo = AgenteTesoreria.Proxy.ObtenerFondoFijo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, vPersona.IdPersona);

                                    if (vFondoFijo != null && vFondoFijo.idPersona != 0)
                                    {
                                        MessageBox.Show("La persona ya esta registrada en Fondo Fijo.\n\rActualice sus datos .");
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                        oPersona = vPersona;
                                    }
                                    else
                                    {
                                        MessageBox.Show("La persona ya esta registrada. \n\r Complete los datos del Vendedor.");
                                        oPersona = vPersona;
                                        vFondoFijo = new FondoFijoE();
                                        Opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                                    }
                                }
                                else
                                {
                                    Opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                                    oPersona.TipoPersona = Convert.ToInt32(enumTipoPersona.Otros);
                                    oPersona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                                    oPersona.NroDocumento = txtNroDocumento.Text;
                                    oPersona.RUC = txtNroDocumento.Text;
                                }

                                if (OpcionVentana != 0)
                                {
                                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmFondoFijo);

                                    if (oFrm != null)
                                    {
                                        oFrm.BringToFront();
                                        return;
                                    }

                                    oPersona.TipoPersona = Convert.ToInt32(enumTipoPersona.Otros);
                                    oPersona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                                    vFondoFijo.idPersona = oPersona.IdPersona;
                                    vFondoFijo.desFondo = oPersona.RazonSocial;
                                    vFondoFijo.TipoFondo = TipoFondo;

                                    //sino existe la instancia se crea una nueva
                                    oFrm = new frmFondoFijo(vFondoFijo, oPersona, Opcion, Existe); //TipoFondo, Doc, oPersona.TipoPersona, oPersona.TipoDocumento, oPersona, Existe);
                                    oFrm.MdiParent = MdiParent;
                                    oFrm.Show();
                                }

                                break;

                                #endregion
                        }
                    }

                    Dispose();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboTipoPersona_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ListarComboPorTipoDocumento();
        }

        private void cboTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTipoDocumento.SelectedValue.ToString() == Convert.ToInt32(EnumTipoDocumento.Dni).ToString())
            {
                txtNroDocumento.MaxLength = 8;
                txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
            }
            else if (cboTipoDocumento.SelectedValue.ToString() == Convert.ToInt32(EnumTipoDocumento.Ruc).ToString())
            {
                txtNroDocumento.MaxLength = 11;
                txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
            }
            else
            {
                txtNroDocumento.MaxLength = 25;
                txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.Defecto;
            }
        }

        private void FrmDlgPersona_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: //Aceptar
                    btnAceptar.PerformClick();
                    break;
                case Keys.F6: //Cancelar
                    btnCancelar.PerformClick();
                    break;
                
                case Keys.Escape: //Salir del formulario
                    //btnCancelar.PerformClick();
                    Cerrar();
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
