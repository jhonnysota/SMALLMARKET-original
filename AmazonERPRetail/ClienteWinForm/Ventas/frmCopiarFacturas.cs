using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Ventas
{
    public partial class frmCopiarFacturas : frmResponseBase
    {

        #region Constructores
        
        public frmCopiarFacturas()
        {
            InitializeComponent();
        }

        public frmCopiarFacturas(EmisionDocumentoE Emidoctmp)
          : this()
        {
            EmiDoc = Emidoctmp;
        } 

        #endregion

        #region Variables

        public EmisionDocumentoE EmiDoc = new EmisionDocumentoE();
        public EmisionDocumentoE EmiDocTMP = new EmisionDocumentoE();
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }

        #endregion

        void LlenarCombos()
        {

            List<NumControlDetE> ListaDetalle = new List<NumControlDetE>(from x in VariablesLocales.ListaDetalleNumControl
                                                                         where x.idControl == 1
                                                                         && x.idDocumento == "FV"
                                                                         select x).ToList();

            ComboHelper.LlenarCombos<NumControlDetE>(cboSeries, ListaDetalle, "Serie", "Serie");

        }

        public override void Aceptar()
        {
            try
            {
                if (ValidarGrabacion())
                {
                    EmiDocTMP.numSerie = cboSeries.SelectedValue.ToString();
                    EmiDocTMP.fecEmision = dtpEmision.Value.ToString("yyyyMMdd");
                    EmiDocTMP.tipCambio = Convert.ToDecimal(txtTica.Text);

                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        String DevolverNumeroCorrelativo(String Correlativo, Int32 cantDigitos)
        {
            Int32 Numero = 0;
            String numFinal = String.Empty;

            if (String.IsNullOrEmpty(Correlativo))
            {
                Numero = Variables.Cero;
            }
            else
            {
                Numero = Convert.ToInt32(Correlativo);
            }

            Numero++;
            numFinal = Numero.ToString().PadLeft(cantDigitos, '0');
            return numFinal;
        }

        #region Eventos

        private void frmCopiarFacturas_Load(object sender, EventArgs e)
        {
            LlenarCombos();
            dtpProceso_ValueChanged(new object(), new EventArgs());
            cboSeries_SelectionChangeCommitted(new object(), new EventArgs());
        }

        private void cboSeries_SelectionChangeCommitted(object sender, EventArgs e)
        {
            NumControlDetE Detalle = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, 1,
            "FV", cboSeries.SelectedValue.ToString());

            if (Detalle != null)
            {
                txtNumDocumento.MaxLength = Convert.ToInt32(Detalle.cantDigNumero);
                txtNumDocumento.Text = DevolverNumeroCorrelativo(Detalle.numCorrelativo, Convert.ToInt32(Detalle.cantDigNumero));
                EmiDocTMP.numDocumento = txtNumDocumento.Text;
            }
        }


        private void dtpProceso_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime Fecha = dtpEmision.Value.Date;
                TipoCambioE Tica = VariablesLocales.RetornaTipoCambio("01", Fecha);

                if (Tica != null)
                {
                    txtTica.Text = Tica.valVenta.ToString("N3");
                }
                else
                {
                    txtTica.Text = Variables.ValorCeroDecimal.ToString("N3");
                    dtpEmision.Focus();
                    Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

    }
}
