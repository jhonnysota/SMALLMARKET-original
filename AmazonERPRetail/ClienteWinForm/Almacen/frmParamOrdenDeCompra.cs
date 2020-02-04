using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Recursos;

namespace ClienteWinForm.Almacen
{
    public partial class frmParamOrdenDeCompra : FrmMantenimientoBase
    {

        public frmParamOrdenDeCompra()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            LlenarCombos();
        }

        #region Variables

        Int32 opcion;
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        OrdenCompraParametrosE oOrdenCompraParam = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Llenando las monedas
            List<MonedasE> listaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.LlenarCombos<MonedasE>(cboMonedas, (from x in listaMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desMoneda");

            //Tipo de Orden
            List<ParTabla> ListarTipos = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ComboHelper.RellenarCombos<ParTabla>(cboTipoOrden, (from x in ListarTipos orderby x.IdParTabla select x).ToList(), "idParTabla", "Nombre", false);

            //Tipo de Orden
            List<ParTabla> ListarOrigen = AgenteGeneral.Proxy.ListarParTablaPorGrupo((Int32)EnumParTabla.OrigenOrdenCompra, "");
            ListarOrigen.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<ParTabla>(cboOrigen, (from x in ListarOrigen orderby x.IdParTabla select x).ToList(), "idParTabla", "Nombre", false);

            //Tipo de Orden
            List<ParTabla> ListarModalidad = AgenteGeneral.Proxy.ListarParTablaPorGrupo((Int32)EnumParTabla.ModalidadOrdenCompra, "");
            ListarModalidad.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<ParTabla>(cboModalidad, (from x in ListarModalidad orderby x.IdParTabla select x).ToList(), "idParTabla", "Nombre", false);
        } 

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            string empresa = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
            oOrdenCompraParam = AgenteAlmacen.Proxy.ObtenerOrdenCompraParam(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            if (oOrdenCompraParam == null)
            {
                oOrdenCompraParam = new OrdenCompraParametrosE();
                oOrdenCompraParam.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                cboTipoOrden.SelectedIndex = oOrdenCompraParam.tipOrdenCompra;
                cboOrigen.SelectedIndex = oOrdenCompraParam.tipSecuenciaFlujo;
                cboModalidad.SelectedIndex = oOrdenCompraParam.tipModalCompra;
                cboMonedas.SelectedIndex = oOrdenCompraParam.idMoneda;
                chkPartida.Checked = oOrdenCompraParam.indPartPresupuestal;

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                oOrdenCompraParam.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oOrdenCompraParam.tipOrdenCompra = cboTipoOrden.SelectedIndex;
                oOrdenCompraParam.tipSecuenciaFlujo = cboOrigen.SelectedIndex;
                oOrdenCompraParam.tipModalCompra = cboModalidad.SelectedIndex;
                oOrdenCompraParam.idMoneda = cboMonedas.SelectedIndex;
                oOrdenCompraParam.indPartPresupuestal = chkPartida.Checked;

                if (oOrdenCompraParam != null)
                {
                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        oOrdenCompraParam = AgenteAlmacen.Proxy.InsertarOrdenCompraParam(oOrdenCompraParam);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Actualizar)
                    {
                        oOrdenCompraParam = AgenteAlmacen.Proxy.ActualizarOrdenCompraParam(oOrdenCompraParam);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }

                    VariablesLocales.oComprasParametros = oOrdenCompraParam;
                }

                base.Grabar();
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmParamOrdenDeCompra_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

    }
}
