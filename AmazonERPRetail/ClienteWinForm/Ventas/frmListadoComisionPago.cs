using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoComisionPago : FrmMantenimientoBase
    {

        public frmListadoComisionPago()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            
            FormatoGrid(dgvDocumentos, true);
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                bsComisionPago.DataSource = AgenteVentas.Proxy.ListarcomisionPago();
                bsComisionPago.ResetBindings(false);

                lblRegistros.Text = " [ " + bsComisionPago.Count.ToString() + " Registros ]";
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsComisionPago.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.EliminarcomisionPago(((comisionPagoE)bsComisionPago.Current).idEmpresa, ((comisionPagoE)bsComisionPago.Current).idCalculo);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                        base.Anular();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        private void frmListadoComisionPago_Load(object sender, EventArgs e)
        {
            Grid = true;

            Buscar();

            BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
        }
    }
}
