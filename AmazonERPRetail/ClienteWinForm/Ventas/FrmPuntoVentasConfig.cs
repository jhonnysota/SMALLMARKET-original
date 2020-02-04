using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;
using Entidades.Almacen;

namespace ClienteWinForm.Ventas
{
    public partial class FrmPuntoVentasConfig : FrmMantenimientoBase
    {

        public FrmPuntoVentasConfig()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombo();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        SalesPointE oConfigPtoVta = null;

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombo()
        {
            //Tipos de Documentos
            List<UsuarioSeriesE> ListaDocumentos = AgenteSeguridad.Proxy.ListarUsuarioSeriesPtoVta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionUsuario.IdPersona);
            ListaDocumentos.Add(new UsuarioSeriesE { idDocumento = "A", desDocumento = Variables.Escoger });
            ComboHelper.RellenarCombos<UsuarioSeriesE>(CboTipoFac, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento");
            ComboHelper.RellenarCombos<UsuarioSeriesE>(CboTipoBol, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento");

            //Tipo de Impresora
            List<ParTabla> ListaTipos = new List<ParTabla>
            {
                new ParTabla { ValorCadena = "M", Nombre = "Matricial" },
                new ParTabla { ValorCadena = "T", Nombre = "Térmica" },
            };
            ComboHelper.RellenarCombos<ParTabla>(CboTipoPrint, ListaTipos, "ValorCadena", "Nombre");

            //Almacenes
            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0);
            oListaAlmacen.Add(new AlmacenE { idAlmacen = 0, desAlmacen = Variables.Seleccione });
            ComboHelper.LlenarCombos<AlmacenE>(CboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
        }

        private void GuardarDatos()
        {
            oConfigPtoVta.Host = TxtHost.Text;
            oConfigPtoVta.Descripcion = TxtDescripcion.Text.Trim();
            oConfigPtoVta.SerieCaja = TxtSerieCaja.Text.Trim();
            oConfigPtoVta.TipoImpresora = CboTipoPrint.SelectedValue.ToString();
            oConfigPtoVta.Impresora = TxtImpresora.Text;
            oConfigPtoVta.PtoCobro = ChkCobro.Checked;
            oConfigPtoVta.TituloFac = TxtTituloFac.Text.Trim();
            oConfigPtoVta.IdFactura = CboTipoFac.SelectedValue.ToString();
            oConfigPtoVta.SerieFactura = TxtSerieFac.Text;
            oConfigPtoVta.TituloBol = TxtTituloBol.Text;
            oConfigPtoVta.IdBoleta = CboTipoBol.SelectedValue.ToString();
            oConfigPtoVta.SerieBoleta = TxtSerieBol.Text;
            oConfigPtoVta.MostrarPrevio = ChkPrevio.Checked;
            oConfigPtoVta.idAlmacen = Convert.ToInt32(CboAlmacen.SelectedValue);
            oConfigPtoVta.Head1 = TxtHeader1.Text.Trim();
            oConfigPtoVta.Head2 = TxtHeader2.Text.Trim();
            oConfigPtoVta.Head3 = TxtHeader3.Text.Trim();
            oConfigPtoVta.Head4 = TxtHeader4.Text.Trim();
            oConfigPtoVta.Head5 = TxtHeader5.Text.Trim();
            oConfigPtoVta.Head6 = TxtHeader6.Text.Trim();
            oConfigPtoVta.Foot1 = TxtFoot1.Text.Trim();
            oConfigPtoVta.Foot2 = TxtFoot2.Text.Trim();
            oConfigPtoVta.Foot3 = TxtFoot3.Text.Trim();
            oConfigPtoVta.Foot4 = TxtFoot4.Text.Trim();
            oConfigPtoVta.Foot5 = TxtFoot5.Text.Trim();
            oConfigPtoVta.Foot6 = TxtFoot6.Text.Trim();

            if (oConfigPtoVta.IdSalesPoint == 0)
            {
                oConfigPtoVta.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oConfigPtoVta.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oConfigPtoVta == null)
            {
                oConfigPtoVta = new SalesPointE()
                {
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                };
            }
            else
            {
                TxtHost.Text = oConfigPtoVta.Host;
                TxtDescripcion.Text = oConfigPtoVta.Descripcion;
                TxtSerieCaja.Text = oConfigPtoVta.SerieCaja;
                CboTipoPrint.SelectedValue = oConfigPtoVta.TipoImpresora;
                TxtImpresora.Text = oConfigPtoVta.Impresora;
                ChkCobro.Checked = oConfigPtoVta.PtoCobro;
                TxtTituloFac.Text = oConfigPtoVta.TituloFac;
                CboTipoFac.SelectedValue = oConfigPtoVta.IdFactura;
                TxtSerieFac.Text = oConfigPtoVta.SerieFactura;
                TxtTituloBol.Text = oConfigPtoVta.TituloBol;
                CboTipoBol.SelectedValue = oConfigPtoVta.IdBoleta;
                TxtSerieBol.Text = oConfigPtoVta.SerieBoleta;
                ChkPrevio.Checked = oConfigPtoVta.MostrarPrevio;
                CboAlmacen.SelectedValue = oConfigPtoVta.idAlmacen;
                TxtHeader1.Text = oConfigPtoVta.Head1;
                TxtHeader2.Text = oConfigPtoVta.Head2;
                TxtHeader3.Text = oConfigPtoVta.Head3;
                TxtHeader4.Text = oConfigPtoVta.Head4;
                TxtHeader5.Text = oConfigPtoVta.Head5;
                TxtHeader6.Text = oConfigPtoVta.Head6;
                TxtFoot1.Text = oConfigPtoVta.Foot1;
                TxtFoot2.Text = oConfigPtoVta.Foot2;
                TxtFoot3.Text = oConfigPtoVta.Foot3;
                TxtFoot4.Text = oConfigPtoVta.Foot4;
                TxtFoot5.Text = oConfigPtoVta.Foot5;
                TxtFoot6.Text = oConfigPtoVta.Foot6;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oConfigPtoVta != null)
                {
                    GuardarDatos();

                    if (oConfigPtoVta.IdSalesPoint == 0)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            VariablesLocales.oSalesPoint = oConfigPtoVta = AgenteVentas.Proxy.InsertarSalesPoint(oConfigPtoVta);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            VariablesLocales.oSalesPoint = oConfigPtoVta = AgenteVentas.Proxy.ActualizarSalesPoint(oConfigPtoVta);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }

                    base.Grabar();
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void FrmPuntoVentasConfig_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                oConfigPtoVta = Colecciones.CopiarEntidad<SalesPointE>(VariablesLocales.oSalesPoint);
                Nuevo();
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void CboTipoFac_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (CboTipoFac.SelectedItem != null)
                {
                    TxtSerieFac.Text = ((UsuarioSeriesE)CboTipoFac.SelectedItem).numSerie;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void CboTipoBol_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CboTipoBol.SelectedItem != null)
                {
                    TxtSerieBol.Text = ((UsuarioSeriesE)CboTipoBol.SelectedItem).numSerie;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtBuscarHost_Click(object sender, EventArgs e)
        {
            try
            {
                TxtHost.Text = System.Net.Dns.GetHostName();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtBuscarImpresora_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarImpresoras oFrm = new frmBuscarImpresoras();

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    TxtImpresora.Text = oFrm.NombreImpresora;
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
