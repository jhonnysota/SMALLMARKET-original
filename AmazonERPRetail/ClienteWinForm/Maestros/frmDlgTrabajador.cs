using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Seguridad;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Maestros
{
    public partial class frmDlgTrabajador : FrmMantenimientoBase
    {

        #region Constructores

        public frmDlgTrabajador()
        {
            InitializeComponent();
        }

        public frmDlgTrabajador(Dictionary<EnumParTabla, List<ParTabla>> oListaParametros_, List<BancosE> oListaTipoBancos_, Int32 idLocal_)
            : this()
        {
            oListaParametros = oListaParametros_;
            oListaTipoBancos = oListaTipoBancos_;
            idLocal = idLocal_;
        }

        public frmDlgTrabajador(Dictionary<EnumParTabla, List<ParTabla>> oListaParametros_, List<BancosE> oListaTipoBancos_, String IDPla, String Anio, String Mes, String Period, Int32 idLocal_, Opcion opcion)
            : this()
        {
            Planilla = IDPla;
            AnioPla = Anio;
            MesPla = Mes;
            PerioPla = Period;
            oListaParametros = oListaParametros_;
            oListaTipoBancos = oListaTipoBancos_;
            idLocal = idLocal_;
        }

        #endregion

        #region Variables
        String documer;
        String Planilla;
        String AnioPla;
        String MesPla;
        String PerioPla;
        TrabajadorE vTrabajador = null;
        Persona persona = null;
        Int32 idLocal = 0;
        public int opcion;
        public int OpcionVentana = 0;
        public EnumTipoRolPersona Enumerado;
        public MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        public GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        Dictionary<EnumParTabla, List<ParTabla>> oListaParametros = new Dictionary<EnumParTabla, List<ParTabla>>();
        List<BancosE> oListaTipoBancos = new List<BancosE>();

        #endregion

        #region Eventos

        private void frmDlgTrabajador_Load(object sender, EventArgs e)
        {
            txtNroDocumento.Focus();
            List<ParTabla> ListaDocumentos = new List<ParTabla>();
            ListaDocumentos = AgenteGenerales.Proxy.ListarParTablaPorGrupo(Convert.ToInt32(EnumParTabla.TipoDocumento), "");
            List<ParTabla> ListaDocumentosNatural = new List<ParTabla>();
            ListaDocumentosNatural = (from x in ListaDocumentos
                                      where (x.IdParTabla != Convert.ToInt32(EnumTipoDocumento.Ruc)) && (x.IdParTabla != Convert.ToInt32(EnumTipoDocumento.Otros))
                                      select x).ToList();
            ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosNatural, "IdParTabla", "Nombre");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNroDocumento.Text.Length > 0)
            {
                Int32 ValidarTrabajador = 0;
                Persona vPersona = new Persona();
                vTrabajador = new TrabajadorE();
                persona = new Persona();
              
                persona.TipoPersona = Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc);
                persona.NroDocumento = txtNroDocumento.Text;
                persona.RUC = txtNroDocumento.Text;
                persona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                //vPersona = AgenteMaestros.Proxy.RecuperarPersonaPorNroDocumento(101001, persona.NroDocumento);

                switch (Enumerado)
                {
                    #region Trabajador

                    case EnumTipoRolPersona.Trabajador:

                        vPersona = AgenteMaestros.Proxy.RecuperarPersonaPorRUC(101001, persona.RUC);

                        if (vPersona != null)
                        {
                            //vTrabajador = AgenteMaestros.Proxy.RecuperarIDPersonaPorTrabajador(vPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                            //if (vTrabajador != null)
                            //{
                            //    MessageBox.Show("La persona ya es TRABAJADOR \n\r Utilice la Opcion Activar Trabajador.", "Trabajadores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //    //opcion = Convert.ToInt32(EnumOpcionGrabar.Actualizar);
                            //    //persona = vPersona;
                            //    //documer = "N";
                            //    ValidarTrabajador = 1;
                            //}
                            //else
                            //{
                            //    MessageBox.Show("La persona ya esta registrada en el Maestro de Personas. \n\r Complete los datos del TRABAJADOR.", "Trabajadores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //    persona = vPersona;
                            //    //persona.Nombres = persona.Correo;
                            //    opcion = Convert.ToInt32(EnumOpcionGrabar.InsertarSimple);
                            //    documer = "N";
                            //}
                        }
                        else
                        {
                            opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);
                        }

                        if (OpcionVentana != 0 && ValidarTrabajador == 0)
                        {
                            if (Planilla == null)
                            {
                                //Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTrabajador);

                                //if (oFrm != null)
                                //{
                                //    oFrm.BringToFront();
                                //    return;
                                //}
                                //vTrabajador = new TrabajadorE
                                //{
                                //    //sino existe la instancia se crea una nueva
                                //    idPersona = persona.IdPersona,
                                //    NroDocumento = persona.NroDocumento,
                                //    idUbigeoNacimiento = persona.idUbigeo,
                                //    FlagPeriodo = false
                                //};

                                //vTrabajador.NroDocumento = txtNroDocumento.Text;
                                //Boolean Remunera = false;

                                //oFrm = new frmTrabajador(oListaParametros, oListaTipoBancos, vTrabajador, persona, opcion, idLocal, documer, Remunera, OpcionSeguridad)
                                //{
                                //    MdiParent = MdiParent
                                //};
                                //oFrm.Show();
                            }
                            else
                            {
                                //Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTrabajador);

                                //if (oFrm != null)
                                //{
                                //    oFrm.BringToFront();
                                //    return;
                                //}

                                //vTrabajador = new TrabajadorE
                                //{
                                //    //sino existe la instancia se crea una nueva
                                //    idPersona = persona.IdPersona,
                                //    NroDocumento = persona.NroDocumento,

                                //    ApeMaterno = persona.ApeMaterno,
                                //    ApePaterno = persona.ApePaterno,
                                //    Nombres = persona.Nombres,

                                //    idUbigeoNacimiento = persona.idUbigeo,
                                //    FlagPeriodo = true
                                //};

                                //vTrabajador.NroDocumento = txtNroDocumento.Text;
                                //opcion = Convert.ToInt32(EnumOpcionGrabar.Insertar);

                                //oFrm = new frmTrabajador(oListaParametros, oListaTipoBancos, vTrabajador, persona, opcion, Planilla, AnioPla, MesPla, PerioPla, idLocal, documer, OpcionSeguridad)
                                //{
                                //    MdiParent = MdiParent
                                //};

                                //oFrm.Show();
                            }
                        }

                        Dispose();
                        break;

                        #endregion
                }
            }
            else
            {
            DialogResult = DialogResult.OK;
            Dispose();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        private void frmDlgTrabajador_KeyDown(object sender, KeyEventArgs e)
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
                    Cerrar();
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
