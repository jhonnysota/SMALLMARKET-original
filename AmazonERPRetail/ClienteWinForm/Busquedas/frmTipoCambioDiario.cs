using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;
using ConsultasOnline;

namespace ClienteWinForm.Busquedas
{
    public partial class frmTipoCambioDiario : FrmMantenimientoBase
    {

        #region Constructores
        
        public frmTipoCambioDiario()
        {
            InitializeComponent();
        }

        public frmTipoCambioDiario(String com, String ven)
            : this()
        {
            Venta = ven;
            Compra = com;

            txtCompra.Text = Compra;
            txtVenta.Text = Venta;
            DesdeMenu = false;
        }

        #endregion Constructores

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        DateTime Fecha = VariablesLocales.FechaHoy;
        String Venta;
        String Compra;
        Boolean DesdeMenu = true;

        #endregion Variables

        #region Procedimientos de Usuario

        void Aceptar()
        {
            try
            {
                if (DesdeMenu)
                {
                    String ValorVenta = txtVenta.Text;
                    String ValorCompra = txtCompra.Text;

                    if (ValorCompra == Variables.ValorCeroDecimal.ToString("N2") && ValorVenta == Variables.ValorCeroDecimal.ToString("N2"))
                    {
                        Global.MensajeFault("No hay tipo de cambio para este día.");
                        return;
                    }

                    if (Global.MensajeConfirmacion(String.Format("Desea guardar el tipo de cambio del dia {0}", dtpFecha.Value.ToString("dd/MM/yyyy"))) == DialogResult.Yes)
                    {
                        TipoCambioE oTica = new TipoCambioE()
                        {
                            idMoneda = Variables.Dolares,
                            fecCambio = dtpFecha.Value.ToString("yyyyMMdd"),
                            valCompra = Convert.ToDecimal(txtCompra.Text),
                            valVenta = Convert.ToDecimal(txtVenta.Text),
                            valVentaCaja = Variables.ValorCeroDecimal,
                            valCompraCaja = Variables.ValorCeroDecimal,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                        };

                        if (oTica != null)
                        {
                            AgenteGeneral.Proxy.GrabarTipoCambioPorDia(oTica);

                            if (oTica.fecCambio.Insert(6, "-").Insert(4, "-") == VariablesLocales.FechaHoy.ToString("yyyy-MM-dd"))
                            {
                                VariablesLocales.TipoCambioDelDia = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia("02", oTica.fecCambio);
                            }
                        } 
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void ObtenerTipoCambio(DateTime FechaActual)
        {
            SunatTica oTicaPorDia = new SunatTica();

            if (oTicaPorDia.ObtenerPorFecha(FechaActual.Day, FechaActual.Month, FechaActual.Year))
            {
                txtCompra.Text = oTicaPorDia.Compra.ToString();
                txtVenta.Text = oTicaPorDia.Venta.ToString();
                this.Text = "MES: " + FechasHelper.NombreMes(Convert.ToInt32(FechaActual.ToString("MM"))).ToUpper();
            }
            else
            {
                txtVenta.Text = Variables.ValorCeroDecimal.ToString("N2");
                txtCompra.Text = Variables.ValorCeroDecimal.ToString("N2");
                Global.MensajeFault(String.Format("No existe Tipo de Cambio para esta fecha {0}", FechaActual.ToString("dd/MM/yyyy")));
            }

            /* Por si acaso
            String sDia = FechaActual.Day.ToString();
            String sCompra = String.Empty;
            String sVenta = String.Empty;

            oTicaPorDia.sAnio = FechaActual.ToString("yyyy");
            oTicaPorDia.sMes = FechaActual.ToString("MM");

            DataTable oDt = oTicaPorDia.ObtenerTipoCambioMesPasado;

            if (oDt.Rows.Count > Variables.ValorCero)
            {
                sCompra = (from DataRow dr in oDt.AsEnumerable()
                           where Convert.ToString(dr["Dia"]).Trim() == sDia
                           select Convert.ToString(dr["Compra"])).FirstOrDefault();
                sVenta = (from DataRow dr in oDt.AsEnumerable()
                          where Convert.ToString(dr["Dia"]).Trim() == sDia
                          select Convert.ToString(dr["Venta"])).FirstOrDefault();

                if (!String.IsNullOrEmpty(sCompra) && !String.IsNullOrEmpty(sVenta))
                {
                    txtCompra.Text = sCompra;
                    txtVenta.Text = sVenta;
                    this.Text = "MES: " + Global.NombreMes(Convert.ToInt32(FechaActual.ToString("MM"))).ToUpper();
                }
                else
                {
                    txtVenta.Text = Variables.ValorCeroDecimal.ToString("N2");
                    txtCompra.Text = Variables.ValorCeroDecimal.ToString("N2");
                    MessageBox.Show("No hay Tipo de Cambio aun para este dia...");
                }
            }
            else
            {
                MessageBox.Show("La página de Sunat esta tardando en cargar mas de los debido o exíste algún problema.\n\rVuelva a intentarlo mas tarde...");
            }*/
        }

        #endregion Procedimientos de Usuario

        #region Eventos

        private void frmTipoCambioDiario_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "MES: " + FechasHelper.NombreMes(Convert.ToInt32(Fecha.ToString("MM"))).ToUpper();

                if (DesdeMenu)
                {
                    dtpFecha.ValueChanged -= new EventHandler(dtpFecha_ValueChanged);
                    dtpFecha.Enabled = true;
                    dtpFecha.Value = Fecha.Date;
                    dtpFecha.ValueChanged += new EventHandler(dtpFecha_ValueChanged);
                    btAceptar.Text = "Guardar";
                }
                else
                {
                    dtpFecha.ValueChanged -= new EventHandler(dtpFecha_ValueChanged);
                    dtpFecha.Value = Fecha.Date;

                    TipoCambioE oTica = new TipoCambioE()
                    {
                        idMoneda = Variables.Dolares,
                        fecCambio = Fecha.ToString("yyyyMMdd"),
                        valCompra = Convert.ToDecimal(txtCompra.Text),
                        valVenta = Convert.ToDecimal(txtVenta.Text),
                        valVentaCaja = Variables.ValorCeroDecimal,
                        valCompraCaja = Variables.ValorCeroDecimal,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                    };

                    if (oTica != null)
                    {
                        AgenteGeneral.Proxy.GrabarTipoCambioPorDia(oTica);

                        //if (Convert.ToDateTime(oTica.fecCambio).Date == VariablesLocales.FechaHoy.Date)
                        //{
                        //    VariablesLocales.TipoCambioDelDia = oTica;
                        //}
                        if (oTica.fecCambio.Insert(6, "-").Insert(4, "-") == VariablesLocales.FechaHoy.ToString("yyyy-MM-dd"))
                        {
                            VariablesLocales.TipoCambioDelDia = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia("02", oTica.fecCambio);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            DateTime MiFecha = ((DateTimePicker)sender).Value;
            lblFechaLarga.Text = MiFecha.ToLongDateString();
            ObtenerTipoCambio(MiFecha);
        }

        private void frmTipoCambioDiario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Aceptar();
            }
        }

        #endregion

    }
}
