using System;
using System.Windows.Forms;

using Entidades.Ventas;
using Infraestructura;

namespace ClienteWinForm.Ventas
{
    public partial class frmEscogerDetraRete : Form
    {

        #region Constructores

        public frmEscogerDetraRete()
        {
            InitializeComponent();
        }

        public frmEscogerDetraRete(EmisionDocumentoE oVentas)
            :this()
        {
            Ejecutar = false;

            if (oVentas != null)
            {
                chkDetraccion.Checked = oVentas.AfectoDetraccion;
                chkRetencion.Checked = oVentas.AfectoRetencion;
            }

            oEmisionDoc = oVentas;
            RevisarImpuestos(oVentas);

            Ejecutar = true;
        }

        #endregion

        #region Variables

        EmisionDocumentoE oEmisionDoc = null;
        Boolean Ejecutar = false;
        public Decimal MontoSaldo = 0;

        #endregion

        #region Procedimientos de usuario

        void RevisarImpuestos(EmisionDocumentoE oVentas)
        {
            try
            {
                Decimal tot = oVentas.totTotal;

                if (chkDetraccion.Checked)
                {
                    Decimal detra = oVentas.MontoDetraccion;
                    MontoSaldo = tot - detra;
                    lblDetraccion.Text = "Total Doc: " + tot.ToString("N2") + "\n\rDetracción: " + detra.ToString("N2") + "\n\rTotal: " + MontoSaldo.ToString("N2");
                }
                else
                {
                    MontoSaldo = tot;
                    lblDetraccion.Text = "Total Doc: " + tot.ToString("N2") + "\n\rDetracción: 0.00" + "\n\rTotal: " + tot.ToString("N2");
                }

                if (chkRetencion.Checked)
                {
                    Decimal Retencion = 0;

                    if (VariablesLocales.oListaImpuestos[2] == null) //Retenciones
                    {
                        throw new Exception("Falta ingresar el impuesto de Retención en Maestros/Impuestos");
                    }

                    Retencion = Decimal.Round(tot * (VariablesLocales.oListaImpuestos[2].Porcentaje / 100), 2);
                    MontoSaldo = tot - Retencion;

                    lblRetencion.Text = "Total Doc: " + tot.ToString("N2") + "\n\rRetención: " + Retencion.ToString("N2") + "\n\rTotal: " + MontoSaldo.ToString("N2");
                }
                else
                {
                    lblRetencion.Text = "Total Doc: " + tot.ToString("N2") + "\n\rRetención: 0.00" + "\n\rTotal: " + tot.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

        #region Eventos

        private void frmEscogerDetraRete_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkDetraccion.Checked && chkRetencion.Checked)
                {
                    Global.MensajeAdvertencia("Solo debe escoger una sola opción.");
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkDetraccion_CheckedChanged(object sender, EventArgs e)
        {
            if (Ejecutar)
            {
                RevisarImpuestos(oEmisionDoc);
            }
        }

        private void chkRetencion_CheckedChanged(object sender, EventArgs e)
        {
            if (Ejecutar)
            {
                RevisarImpuestos(oEmisionDoc);
            }
        } 

        #endregion

    }
}
