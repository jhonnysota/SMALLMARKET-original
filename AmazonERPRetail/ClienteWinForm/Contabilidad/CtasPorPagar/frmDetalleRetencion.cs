using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmDetalleRetencion : frmResponseBase
    {

        #region Constructor

        public frmDetalleRetencion()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        public frmDetalleRetencion(Decimal Tica_)
            : this()
        {
            Tica = Tica_;
        }

        public frmDetalleRetencion(RetencionItemE oDet, Decimal Tica_,Decimal MontoBasetmp)
            : this()
        {
            Tica = Tica_;
            montobasetmpold = MontoBasetmp;
            if (oDet.Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oDetalle = oDet;
            }
            else
            {
                oDetalle = AgenteCtasPorPagar.Proxy.ObtenerRetencionItem(oDet.idEmpresa, oDet.idLocal, oDet.serieCompRete, oDet.numeroCompRete, oDet.Item);
            }
        }

        #endregion

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        public RetencionItemE oDetalle = null;
        Decimal Tica = Variables.Cero;
        public Decimal montobasetmpold;
        #endregion

        #region Procedimiento de Usuario

        void LlenarCombos()
        { 
            //Documentos...
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);
            DocumentosE pd = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = " " + Variables.Seleccione };
            ListaDocumentos.Add(pd);
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumentos, (from x in ListaDocumentos
                                                                    where x.idDocumento == EnumTipoDocumentoVenta.FC.ToString()
                                                                    || x.idDocumento == EnumTipoDocumentoVenta.CR.ToString()
                                                                    || x.idDocumento == EnumTipoDocumentoVenta.DR.ToString()
                                                                    orderby x.desDocumento
                                                                    select x).ToList(), "idDocumento", "desDocumento", false);
            //Monedas
            ComboHelper.LlenarCombos<MonedasE>(cboMonedas, (from x in VariablesLocales.ListaMonedas
                                                            where x.idMoneda == Variables.Soles
                                                            || x.idMoneda == Variables.Dolares
                                                            select x).ToList(), "idMoneda", "desMoneda");
        }

        void Calcular()
        {
            Decimal MontoOrigen = Variables.Cero;
            Decimal.TryParse(txtMontoOrigen.Text, out MontoOrigen);

            if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
            {
                txtMontoSoles.Text = MontoOrigen.ToString("N2");
                txtmRetSoles.Text = Convert.ToDecimal(MontoOrigen * 0.03M).ToString("N2");
                txtmRetOrigen.Text = txtmRetSoles.Text;
            }
            else
            {
                txtMontoSoles.Text = Convert.ToDecimal(MontoOrigen * Tica).ToString("N2");
                txtmRetSoles.Text = Convert.ToDecimal((MontoOrigen * Tica) * 0.03M).ToString("N2");
                txtmRetOrigen.Text = Convert.ToDecimal(((MontoOrigen * Tica) * 0.03M) / Tica).ToString("N2");
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oDetalle == null)
            {
                oDetalle = new RetencionItemE();

                oDetalle.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oDetalle.idLocal = VariablesLocales.SesionLocal.IdLocal;

                txtURegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFModifica.Text = VariablesLocales.FechaHoy.ToString();

                oDetalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {

                montobasetmpold = montobasetmpold - oDetalle.MontoOrigen;
                txtMontoOrigen.TextChanged -= txtMontoOrigen_TextChanged;

                txtItem.Text = oDetalle.Item;
                cboDocumentos.SelectedValue = oDetalle.idDocumento;
                cboMonedas.SelectedValue = oDetalle.idMoneda;
                txtSerie.Text = oDetalle.serDocumento;
                txtNumero.Text = oDetalle.numDocumento;
                dtpFechaDoc.Value = oDetalle.fecDocumento;
                txtMontoOrigen.Text = oDetalle.MontoOrigen.ToString("N2");
                txtmRetOrigen.Text = oDetalle.MontoRetenidoOrigen.ToString("N2");
                txtMontoSoles.Text = oDetalle.MontoSoles.ToString("N2");
                txtmRetSoles.Text = oDetalle.MontoRetenidoSoles.ToString("N2");

                txtURegistro.Text = oDetalle.UsuarioRegistro;
                txtFRegistro.Text = oDetalle.FechaRegistro.ToString();
                txtUModifica.Text = oDetalle.UsuarioModificacion;
                txtFModifica.Text = oDetalle.FechaModificacion.ToString();

                if (oDetalle.Opcion == 0)
                {
                    oDetalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }
         

                txtMontoOrigen.TextChanged += txtMontoOrigen_TextChanged;
            }

            bsBase.DataSource = oDetalle;
            bsBase.ResetBindings(false);
            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
             {
                Decimal RetencionSoles = Variables.Cero;
                Decimal MontoOrigen = Variables.Cero;
                Decimal MontoSoles = Variables.Cero;
                Decimal RetencionOrigen = Variables.Cero;

                oDetalle.idDocumento = Convert.ToString(cboDocumentos.SelectedValue);
                oDetalle.serDocumento = txtSerie.Text;
                oDetalle.numDocumento = txtNumero.Text;
                oDetalle.fecDocumento = dtpFechaDoc.Value;
                oDetalle.idMoneda = Convert.ToString(cboMonedas.SelectedValue);
                oDetalle.desMoneda = ((MonedasE)cboMonedas.SelectedItem).desAbreviatura;

                Decimal.TryParse(txtMontoOrigen.Text, out MontoOrigen);
                oDetalle.MontoOrigen = Convert.ToDecimal(MontoOrigen);
                Decimal.TryParse(txtmRetOrigen.Text, out RetencionOrigen);
                oDetalle.MontoRetenidoOrigen = Convert.ToDecimal(RetencionOrigen);
                Decimal.TryParse(txtMontoSoles.Text, out MontoSoles);
                oDetalle.MontoSoles = Convert.ToDecimal(MontoSoles);
                Decimal.TryParse(txtmRetSoles.Text, out RetencionSoles);
                oDetalle.MontoRetenidoSoles = Convert.ToDecimal(RetencionSoles);

                montobasetmpold = montobasetmpold + oDetalle.MontoOrigen;

                if (oDetalle.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    oDetalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    oDetalle.FechaRegistro = VariablesLocales.FechaHoy;
                    oDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oDetalle.FechaModificacion = VariablesLocales.FechaHoy;
                }
                else
                {
                    oDetalle.UsuarioModificacion = txtUModifica.Text;
                    oDetalle.FechaModificacion = VariablesLocales.FechaHoy;
                }

                base.Aceptar();
             }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<RetencionItemE>(oDetalle);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmDetalleRetencion_Load(object sender, EventArgs e)
        {
            try
            {
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboMonedas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                txtMontoOrigen.TextChanged -= txtMontoOrigen_TextChanged;
                Calcular();
                txtMontoOrigen.TextChanged += txtMontoOrigen_TextChanged;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtMontoOrigen_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        #endregion

    }
}
