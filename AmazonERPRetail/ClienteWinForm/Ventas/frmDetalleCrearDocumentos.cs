using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Ventas
{
    public partial class frmDetalleCrearDocumentos : frmResponseBase
    {

        #region Constructores

        public frmDetalleCrearDocumentos()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        public frmDetalleCrearDocumentos(PedidoCabE oPedidoTemp, String NroPed)
            :this()
        {
            oPedido = AgenteVentas.Proxy.RecuperarPedidoNacional(oPedidoTemp.idEmpresa, oPedidoTemp.idLocal, oPedidoTemp.idPedido);

            if (oPedido != null)
            {
                LlenarCombos(oPedidoTemp.NemoTipoDoc);

                if (!String.IsNullOrEmpty(NroPed))
                {
                    lblTituloPrincipal.Text = "Crear Documentos para el Nro. Ped. " + NroPed;
                }
                else
                {
                    lblTituloPrincipal.Text = "Creación de documentos";
                }
            }
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        PedidoCabE oPedido = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos(String TipoComprobante)
        {
            List<NumControlE> ControlDocumentos = AgenteVentas.Proxy.ListarNumControl(oPedido.idEmpresa, oPedido.idLocal);

            ComboHelper.LlenarCombos<NumControlE>(cboDocVentas, (from x in ControlDocumentos
                                                                 where x.idControl == 1 || x.idControl == 2 
                                                                 select x).ToList() , "idControl", "Descripcion");
            if (TipoComprobante == "TIPFACT")
            {
                cboDocVentas.SelectedValue = 1;
            }
            else
            {
                cboDocVentas.SelectedValue = 2;
            }

            cboDocVentas_SelectionChangeCommitted(new object(), new EventArgs());

            ComboHelper.LlenarCombos<NumControlE>(cboGuias, (from x in ControlDocumentos
                                                             where x.idControl == 3
                                                             select x).ToList(), "idControl", "Descripcion");

            List<NumControlDetE> oListaSeriesGuias = new List<NumControlDetE>((from x in VariablesLocales.ListaDetalleNumControl
                                                                               where x.idControl == Convert.ToInt32(cboGuias.SelectedValue)
                                                                               select x).ToList());



            ComboHelper.LlenarCombos<NumControlDetE>(cboSerieGuias, oListaSeriesGuias, "Serie", "Serie");

            if (oListaSeriesGuias.Count == 1)
            {
                cboSerieGuias.Enabled = false;
            }
            else if (oListaSeriesGuias.Count > 1)
            {
                cboSerieGuias.Enabled = true;
            }
        }


        #endregion

        #region Procedimientos Heredados

        public override bool ValidarGrabacion()
        {
            if (oPedido.ListaPedidoDet == null)
            {
                Global.MensajeFault("Este Pedido no tiene ningún item en el detalle. No puede crear los documentos.");
                return false;
            }

            if (oPedido.ListaPedidoDet.Count == Variables.Cero)
            {
                Global.MensajeFault("Este Pedido no tiene ningún item en el detalle. No puede crear los documentos.");
                return false;
            }

            foreach (PedidoDetE item in oPedido.ListaPedidoDet)
            {
                if (item.Cantidad <= Variables.Cero)
                {
                    Global.MensajeFault("El Pedido tiene ITEMS con cantidad 0. Revise por favor.");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        public override void Aceptar()
        {
            if (oPedido != null)
            {
                if (ValidarGrabacion())
                {
                    string Tipo = oPedido.NemoTipoDoc;
                  

                    AgenteVentas.Proxy.CrearDocumentos(oPedido, (cboSerieVenta.SelectedValue != null ? ((NumControlDetE)cboSerieVenta.SelectedItem).idDocumento : ""), (cboSerieVenta.SelectedValue != null ? cboSerieVenta.SelectedValue.ToString() : ""), Tipo, ((NumControlDetE)cboSerieGuias.SelectedItem).idDocumento, cboSerieGuias.SelectedValue.ToString(), VariablesLocales.SesionUsuario.Credencial);

                    base.Aceptar();  
                }
            }
        }

        #endregion

        #region Eventos

        private void frmDetalleCrearDocumentos_Load(object sender, EventArgs e)
        {

        }

        private void cboDocVentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<NumControlDetE> oListaDetalle = new List<NumControlDetE>((from x in VariablesLocales.ListaDetalleNumControl
                                                                           where x.idControl == Convert.ToInt32(cboDocVentas.SelectedValue) orderby x.Orden
                                                                           select x).ToList());

            ComboHelper.LlenarCombos<NumControlDetE>(cboSerieVenta, oListaDetalle, "Serie", "Serie");
            oListaDetalle = null;
           
        }

        #endregion

    }
}
