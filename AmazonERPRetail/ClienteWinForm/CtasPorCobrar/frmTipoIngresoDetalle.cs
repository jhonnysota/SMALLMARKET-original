using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Contabilidad;
using Entidades.CtasPorCobrar;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

namespace ClienteWinForm.CtasPorCobrar
{
    public partial class frmTipoIngresoDetalle : frmResponseBase
    {

        #region Constructores

        public frmTipoIngresoDetalle()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarCombos();
        }

        //Nuevo
        public frmTipoIngresoDetalle(String codCobro, String desCobro)
            :this()
        {
            txtCodTipo.Text = codCobro;
            txtDesTipo.Text = desCobro;
        }

        //Edición
        public frmTipoIngresoDetalle(TipoIngresosDetE TipoCobroDet)
            :this()
        {
            oIngresoDetalle = TipoCobroDet;
        } 

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public TipoIngresosDetE oIngresoDetalle = null;
        public List<TipoIngresosDetE> ListaIngresosDetalle = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            List<ParTabla> TipoPlanilla = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPPLACO");
            ComboHelper.LlenarCombos(cboTipoCobranza, TipoPlanilla);

            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes);
            ComboHelper.RellenarCombos(cboComprobantes, (from x in ListaTipoComprobante
                                                         orderby x.idComprobante
                                                         select x).ToList(), "idComprobante", "desComprobanteComp", false);
        }

        #endregion

        #region Procedimientos Herededados

        public override void Nuevo()
        {
            if (oIngresoDetalle == null)
            {
                oIngresoDetalle = new TipoIngresosDetE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    TipoCobro = txtCodTipo.Text,
                    Opcion = (Int32)EnumOpcionGrabar.Insertar
                };

                txtUsuarioRegistro.Text = txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                cboComprobantes_SelectionChangeCommitted(new Object(), new EventArgs());
                btAgregar.Enabled = true;
            }
            else
            {
                if (oIngresoDetalle.Opcion != (Int32)EnumOpcionGrabar.Insertar)
                {
                    oIngresoDetalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                txtCodTipo.Text = oIngresoDetalle.TipoCobro;
                txtDesTipo.Text = oIngresoDetalle.desTipoCobro;
                cboTipoCobranza.SelectedValue = Convert.ToInt32(oIngresoDetalle.TipoPlanilla);
                cboComprobantes.SelectedValue = oIngresoDetalle.idComprobante.ToString();
                cboComprobantes_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFile.SelectedValue = oIngresoDetalle.numFile.ToString();

                txtUsuarioRegistro.Text = oIngresoDetalle.UsuarioRegistro;
                txtUsuarioModificacion.Text = oIngresoDetalle.UsuarioModificacion;
                txtFechaRegistro.Text = oIngresoDetalle.FechaRegistro.ToString();
                txtFechaModificacion.Text = oIngresoDetalle.FechaModificacion.ToString();
            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            if (oIngresoDetalle != null)
            {
                oIngresoDetalle.TipoPlanilla = Convert.ToInt32(cboTipoCobranza.SelectedValue);
                oIngresoDetalle.desTipoPlanilla = ((ParTabla)cboTipoCobranza.SelectedItem).Nombre;
                oIngresoDetalle.idComprobante = cboComprobantes.SelectedValue.ToString();
                oIngresoDetalle.desComprobante = oIngresoDetalle.idComprobante + " - " + ((ComprobantesE)cboComprobantes.SelectedItem).Descripcion;
                oIngresoDetalle.numFile = cboFile.SelectedValue.ToString();
                oIngresoDetalle.desFile = oIngresoDetalle.numFile + " - " + ((ComprobantesFileE)cboFile.SelectedItem).Descripcion;

                if (oIngresoDetalle.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    oIngresoDetalle.UsuarioRegistro = oIngresoDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oIngresoDetalle.FechaRegistro = oIngresoDetalle.FechaModificacion = VariablesLocales.FechaHoy;
                }
                else
                {
                    oIngresoDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oIngresoDetalle.FechaModificacion = VariablesLocales.FechaHoy;
                }

                base.Aceptar();
            }
            else
            {
                if (ListaIngresosDetalle != null && ListaIngresosDetalle.Count > 0)
                {
                    base.Aceptar();
                }
            }
        }

        #endregion

        #region Eventos

        private void frmTipoIngresoDetalle_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void cboComprobantes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboComprobantes.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboComprobantes.SelectedItem).ListaComprobantesFiles);
                    ComboHelper.RellenarCombos(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                    if (ListaFiles != null && ListaFiles.Count > 0)
                    {
                        cboFile.Enabled = true;
                    }
                    else
                    {
                        cboFile.Enabled = false;
                    }

                    ListaFiles = null;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaIngresosDetalle == null)
                {
                    ListaIngresosDetalle = new List<TipoIngresosDetE>();
                }
                else
                {
                    TipoIngresosDetE Det = ListaIngresosDetalle.Find
                    (
                        delegate (TipoIngresosDetE d) { return d.TipoCobro == txtCodTipo.Text && d.TipoPlanilla == Convert.ToInt32(cboTipoCobranza.SelectedValue) && d.idComprobante == cboComprobantes.SelectedValue.ToString() && d.numFile == cboFile.SelectedValue.ToString(); }
                    );

                    if (Det != null)
                    {
                        Global.MensajeAdvertencia("Este Registro ya se encuentra agregado en la lista.");
                        return;
                    }
                }

                oIngresoDetalle = new TipoIngresosDetE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    TipoPlanilla = Convert.ToInt32(cboTipoCobranza.SelectedValue),
                    desTipoPlanilla = ((ParTabla)cboTipoCobranza.SelectedItem).Descripcion,
                    idComprobante = cboComprobantes.SelectedValue.ToString(),
                    desComprobante = cboComprobantes.SelectedValue.ToString() + " - " + ((ComprobantesE)cboComprobantes.SelectedItem).Descripcion,
                    numFile = cboFile.SelectedValue.ToString(),
                    desFile = cboFile.SelectedValue.ToString() + " - " + ((ComprobantesFileE)cboFile.SelectedItem).Descripcion,
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                    UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                    FechaRegistro = VariablesLocales.FechaHoy,
                    FechaModificacion = VariablesLocales.FechaHoy,
                    Opcion = (Int32)EnumOpcionGrabar.Insertar
                };

                ListaIngresosDetalle.Add(oIngresoDetalle);
                txtUsuarioRegistro.Text = txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                oIngresoDetalle = null;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

    }
}
