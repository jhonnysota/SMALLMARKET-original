using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using ConsultasOnline;

namespace ClienteWinForm.Busquedas
{
    public partial class frmTipoCambioSbsPorMoneda : FrmMantenimientoBase
    {

        #region Constructores
        
        public frmTipoCambioSbsPorMoneda()
        {
            InitializeComponent();
        }

        public frmTipoCambioSbsPorMoneda(List<SbsTica> oLista)
            : this()
        {
            txtCompra.Text = oLista[0].Compra.ToString("N3");
            txtVenta.Text = oLista[0].Venta.ToString("N3");
        } 

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<SbsTica> oListaTica = new List<SbsTica>();
        DateTime FechaActual = VariablesLocales.FechaHoy;

        #endregion

        #region Procedimientos de Usuario

        void Aceptar()
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos
        
        private void frmTipoCambioSbs_Load(object sender, EventArgs e)
        {
            TipoCambioE oTica = new TipoCambioE()
            {
                idMoneda = Variables.Dolares,
                //fecCambio = FechaActual.Date.AddDays(1),
                valCompra = Convert.ToDecimal(txtCompra.Text),
                valVenta = Convert.ToDecimal(txtVenta.Text),
                valVentaCaja = Variables.ValorCeroDecimal,
                valCompraCaja = Variables.ValorCeroDecimal,
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
            };

            if (oTica != null)
            {
                lblGlosa.Text = "El Tipo de Cambio es para el día siguiente " + dtpFecha.Value.Date.AddDays(1).ToString("d");
                AgenteGeneral.Proxy.GrabarTipoCambioPorDia(oTica);
            }
        } 

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void frmTipoCambioSbsPorMoneda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Aceptar();
            }
        }

        #endregion

    }
}
