using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Infraestructura.Enumerados;
using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Seguridad;
using ControlesWinForm;

namespace ClienteWinForm.Maestros
{
    public partial class FrmDlgVendedor : FrmMantenimientoBase
    {
        public FrmDlgVendedor()
        {
            InitializeComponent();
        }

        public FrmDlgVendedor(String IDPla, String Anio, String Mes, String Period)
            :this()
        {
            Planilla = IDPla;
            AnioPla = Anio;
            MesPla = Mes;
            PerioPla = Period;
        }

        #region Variables

        public String Planilla;
        public String AnioPla;
        public String MesPla;
        public String PerioPla;
        public TrabajadorE vTrabajador = null;
        public Persona persona = null;
        public ClienteE vCliente = null;
        public ProveedorE vProveedor = null;
        public Usuario vUsuario = null;
        public OpeLogisticoE vOperador = null;
        public BancosE vBanco = null;
        //public Chofer vChofer = null;
        public VendedoresE vVendedor = null;
        //public Trabajador vTrabajador = null;

        public int opcion;
        public int OpcionVentana = 0;
        //Se debe de enviar el tipo de persona (cliente, proveedor, trabajador, etc), y agregarlo en el switch
        public EnumTipoRolPersona Enumerado;

        public GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        public MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        public SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }


        #endregion

        #region Procedimientos Usuario

        private void ListarComboPorTipoDocumento()
        {
            txtNroDocumento.Enabled = true;
            txtNroDocumento.MaxLength = 11;
            txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;

            txtNroDocumento.Focus();
        }

        #endregion

        private void FrmDlgVendedor_Load(object sender, EventArgs e)
        {               
            switch (Enumerado)
            {
                  case EnumTipoRolPersona.Vendedor:
                    break;
                case EnumTipoRolPersona.Trabajador:
                    break;
                  default:
                    break;
            }
            txtNroDocumento.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNroDocumento.Text.Length > 0)
            {
                Persona vPersona = new Persona();
                VendedoresE vVendedor = new VendedoresE();
                TrabajadorE vTrabajador = new TrabajadorE();
                vCliente = new ClienteE();
                vProveedor = new ProveedorE();
                vUsuario = new Usuario();
                persona = new Persona();
                vOperador = new OpeLogisticoE();
                vBanco = new BancosE();

                persona.TipoPersona = Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc);
                //persona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
            
                persona.NroDocumento = txtNroDocumento.Text;
                persona.RUC = txtNroDocumento.Text;
                vPersona = AgenteMaestros.Proxy.RecuperarPersonaPorNroDocumento(persona.NroDocumento);

                switch (Enumerado)
                {
                    #region Vendedor

                    case EnumTipoRolPersona.Vendedor:

                        if (vPersona != null)
                        {
                            vVendedor = AgenteMaestros.Proxy.RecuperarIDPersonaPorVendedor(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                            if (vVendedor != null)
                            {
                                MessageBox.Show("LA PERSONA YA ESTA REGISTRADA COMO VENDEDOR. \n\r ACTUALICE SUS DATOS.");
                                opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                                persona = vPersona;
                            }
                            else
                            {
                                MessageBox.Show("LA PERSONA YA ESTA REGISTRADA. \n\r COMPLETE LOS DATOS DEL VENDEDOR.");
                                persona = vPersona;
                                //persona.Nombres = persona.Correo;
                                opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                            }
                        }
                        else
                        {
                            opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                        }

                        if (OpcionVentana != 0)
                        {
                            Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVendedor);

                            if (oFrm != null)
                            {
                                oFrm.BringToFront();
                                return;
                            }

                            vVendedor = new VendedoresE();
                            //sino existe la instancia se crea una nueva
                            vVendedor.idPersona = persona.IdPersona;
                            vVendedor.NroDocumento = persona.NroDocumento;

                            //oFrm = new frmVendedor(vVendedor, persona, opcion);
                            //oFrm.MdiParent = MdiParent;
                            //oFrm.Show();
                        }

                        Dispose();
                        break;

                    #endregion
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        private void FrmDlgVendedor_KeyDown(object sender, KeyEventArgs e)
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
        
    }
}
