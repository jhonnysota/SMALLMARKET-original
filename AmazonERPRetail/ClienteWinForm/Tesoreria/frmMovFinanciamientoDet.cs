using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

using Entidades.Tesoreria;
using Infraestructura;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmMovFinanciamientoDet : frmResponseBase
    {

        #region Constructores

        public frmMovFinanciamientoDet()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvCronograma, true);
        }

        //Nuevo
        public frmMovFinanciamientoDet(MovimientoFinanciamientoDetE oDet)
            :this()
        {
            oMovimientoDet = oDet;
        }

        //Edición
        public frmMovFinanciamientoDet(List<MovimientoFinanciamientoDetE> oListaDet)
            :this()
        {
            oListaMovimientos = oListaDet;
        } 

        #endregion

        #region Variables

        MovimientoFinanciamientoDetE oMovimientoDet = null;
        public List<MovimientoFinanciamientoDetE> oListaMovimientos = null;

        #endregion

        #region Procedimientos de Usuario

        void SumarTotales()
        {
            if (oListaMovimientos != null && oListaMovimientos.Count > 0)
            {
                Decimal totAmortizacion = oListaMovimientos.Sum(x => x.Amortizacion);
                Decimal totIntereses = oListaMovimientos.Sum(x => x.Interes);
                Decimal totCuota = oListaMovimientos.Sum(x => x.ValorCuota);
                Decimal totComision = oListaMovimientos.Sum(x => x.Comision);
                Decimal totTotal = oListaMovimientos.Sum(x => x.Total);
                Decimal totInteresAD = oListaMovimientos.Sum(x => x.InteresPorDa);

                lblAmortizacion.Text = totAmortizacion.ToString("N2");
                lblInteres.Text = totIntereses.ToString("N2");
                lblCuota.Text = totCuota.ToString("N2");
                lblComision.Text = totComision.ToString("N2");
                lblTotal.Text = totTotal.ToString("N2");
                lblInteresDA.Text = totInteresAD.ToString("N2");
            }
            else
            {
                lblAmortizacion.Text = "0.00";
                lblInteres.Text = "0.00";
                lblCuota.Text = "0.00";
                lblComision.Text = "0.00";
                lblTotal.Text = "0.00";
                lblInteresDA.Text = "0.00";
            }
        }

        void Recalcular()
        {
            Int16 EsPrimero = 1;

            if (oListaMovimientos != null && oListaMovimientos.Count > 0)
            {
                TimeSpan diff;

                for (int i = 0; i <= oListaMovimientos.Count - 1; i++)
                {
                    if (EsPrimero == 1)
                    {
                        if (oListaMovimientos[i].Cambio == "D")
                        {
                            diff = oListaMovimientos[i].fecVenc - oListaMovimientos[i].fecEmision;
                            oListaMovimientos[i].DiasCuota = diff.Days; 
                        }
                        else
                        {
                            oListaMovimientos[i].fecVenc = oListaMovimientos[i].fecEmision.AddDays(oListaMovimientos[i].DiasCuota);
                        }

                        oListaMovimientos[i].DiasAcumulados = oListaMovimientos[i].DiasCuota;
                        oListaMovimientos[i].InteresPorDa = Convert.ToDecimal(1 / (Math.Pow(Convert.ToDouble(1 + (oListaMovimientos[i].Tea / 100)), Convert.ToDouble(oListaMovimientos[i].DiasAcumulados / 360M))));
                        EsPrimero = 2;
                    }
                    else
                    {
                        if (oListaMovimientos[i].Cambio == "D")
                        {
                            diff = oListaMovimientos[i].fecVenc - oListaMovimientos[i - 1].fecVenc;
                            oListaMovimientos[i].DiasCuota = diff.Days;
                        }
                        else
                        {
                            oListaMovimientos[i].fecVenc = oListaMovimientos[i - 1].fecVenc.AddDays(oListaMovimientos[i].DiasCuota);
                        }

                        oListaMovimientos[i].DiasAcumulados = oListaMovimientos[i - 1].DiasAcumulados + oListaMovimientos[i].DiasCuota;
                        oListaMovimientos[i].InteresPorDa = Convert.ToDecimal(1 / (Math.Pow(Convert.ToDouble(1 + (oListaMovimientos[i].Tea / 100)), Convert.ToDouble(oListaMovimientos[i].DiasAcumulados / 360M))));
                    }
                }

                EsPrimero = 1;
                Decimal SumaInteresDA = oListaMovimientos.Sum(x => x.InteresPorDa);
                Decimal ValorCuota = Convert.ToDecimal(txtCapital.Text) / SumaInteresDA;

                for (int i = 0; i <= oListaMovimientos.Count - 1; i++)
                {
                    oListaMovimientos[i].ValorCuota = ValorCuota;
                    oListaMovimientos[i].Total = oListaMovimientos[i].ValorCuota + oListaMovimientos[i].Comision;

                    if (EsPrimero == 1)
                    {
                        oListaMovimientos[i].Interes = oListaMovimientos[i].ImporteAmortizado * Convert.ToDecimal(Math.Pow(Convert.ToDouble(1 + (oListaMovimientos[i].Tea / 100)), Convert.ToDouble(oListaMovimientos[i].DiasCuota / 360M)) - 1);
                        oListaMovimientos[i].Amortizacion = oListaMovimientos[i].ValorCuota - oListaMovimientos[i].Interes;

                        EsPrimero = 2;
                    }
                    else
                    {
                        oListaMovimientos[i].ImporteAmortizado = oListaMovimientos[i - 1].ImporteAmortizado - oListaMovimientos[i - 1].Amortizacion;
                        oListaMovimientos[i].Interes = oListaMovimientos[i].ImporteAmortizado * Convert.ToDecimal(Math.Pow(Convert.ToDouble(1 + (oListaMovimientos[i].Tea / 100)), Convert.ToDouble(oListaMovimientos[i].DiasCuota / 360M)) - 1);
                        oListaMovimientos[i].Amortizacion = oListaMovimientos[i].ValorCuota - oListaMovimientos[i].Interes;
                    }
                }

                bsBase.DataSource = oListaMovimientos;
                bsBase.ResetBindings(false);
                SumarTotales();
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oListaMovimientos == null)
                {
                    oListaMovimientos = new List<MovimientoFinanciamientoDetE>();
                    Int16 EsPrimero = 1;

                    if (oMovimientoDet != null)
                    {
                        MovimientoFinanciamientoDetE oItem = null;
                        Int32 ItemCorre = 1;
                        TimeSpan diff;

                        for (int i = 1; i <= oMovimientoDet.Cuotas; i++)
                        {
                            oItem = new MovimientoFinanciamientoDetE();
                            oItem.Item = ItemCorre;
                            oItem.Tea = oMovimientoDet.Tea;
                            oItem.Tem = oMovimientoDet.Tem;
                            oItem.Comision = oMovimientoDet.Comision;
                            oItem.DeudaCapital = oMovimientoDet.DeudaCapital;
                            oItem.Cuotas = oMovimientoDet.Cuotas;
                            oItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                            oItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oItem.FechaRegistro = VariablesLocales.FechaHoy;
                            oItem.FechaModificacion = VariablesLocales.FechaHoy;

                            oListaMovimientos.Add(oItem);
                            ItemCorre++;
                        }

                        for (int i = 0; i <= oListaMovimientos.Count - 1; i++)
                        {
                            if (EsPrimero == 1)
                            {
                                oListaMovimientos[i].fecVenc = oMovimientoDet.fecVenc;
                                oListaMovimientos[i].DiasCuota = oMovimientoDet.DiasCuota;
                                oListaMovimientos[i].DiasAcumulados = oMovimientoDet.DiasCuota;
                                oListaMovimientos[i].InteresPorDa = Convert.ToDecimal(1 / (Math.Pow(Convert.ToDouble(1 + (oMovimientoDet.Tea / 100)), Convert.ToDouble(oListaMovimientos[i].DiasAcumulados / 360M))));
                                EsPrimero = 2;
                            }
                            else
                            {
                                oListaMovimientos[i].fecVenc = oListaMovimientos[i - 1].fecVenc.AddDays(oMovimientoDet.AumentoDias);
                                diff = oListaMovimientos[i].fecVenc - oListaMovimientos[i - 1].fecVenc;
                                oListaMovimientos[i].DiasCuota = diff.Days;
                                oListaMovimientos[i].DiasAcumulados = oListaMovimientos[i - 1].DiasAcumulados + oListaMovimientos[i].DiasCuota;
                                oListaMovimientos[i].InteresPorDa = Convert.ToDecimal(1 / (Math.Pow(Convert.ToDouble(1 + (oMovimientoDet.Tea / 100)), Convert.ToDouble(oListaMovimientos[i].DiasAcumulados / 360M))));
                            }
                        }

                        EsPrimero = 1;
                        Decimal SumaInteresDA = oListaMovimientos.Sum(x => x.InteresPorDa);
                        Decimal ValorCuota = oMovimientoDet.DeudaCapital / SumaInteresDA;

                        for (int i = 0; i <= oListaMovimientos.Count - 1; i++)
                        {
                            oListaMovimientos[i].ValorCuota = ValorCuota;
                            oListaMovimientos[i].Total = oListaMovimientos[i].ValorCuota + oListaMovimientos[i].Comision;

                            if (EsPrimero == 1)
                            {
                                oListaMovimientos[i].ImporteAmortizado = oMovimientoDet.DeudaCapital;
                                oListaMovimientos[i].Interes = oListaMovimientos[i].ImporteAmortizado * Convert.ToDecimal(Math.Pow(Convert.ToDouble(1 + (oMovimientoDet.Tea / 100)), Convert.ToDouble(oListaMovimientos[i].DiasCuota / 360M)) - 1);
                                oListaMovimientos[i].Amortizacion = oListaMovimientos[i].ValorCuota - oListaMovimientos[i].Interes;

                                EsPrimero = 2;
                            }
                            else
                            {
                                oListaMovimientos[i].ImporteAmortizado = oListaMovimientos[i - 1].ImporteAmortizado - oListaMovimientos[i - 1].Amortizacion;
                                oListaMovimientos[i].Interes = oListaMovimientos[i].ImporteAmortizado * Convert.ToDecimal(Math.Pow(Convert.ToDouble(1 + (oMovimientoDet.Tea / 100)), Convert.ToDouble(oListaMovimientos[i].DiasCuota / 360M)) - 1);
                                oListaMovimientos[i].Amortizacion = oListaMovimientos[i].ValorCuota - oListaMovimientos[i].Interes;
                            }
                        }
                    }
                }

                bsBase.DataSource = oListaMovimientos;
                bsBase.ResetBindings(false);
                SumarTotales();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Aceptar()
        {
            if (oListaMovimientos != null && oListaMovimientos.Count > 0)
            {
                base.Aceptar();
            }
            else
            {
                Global.MensajeComunicacion("Debe Presionar Cancelar.");
            }
        }

        #endregion

        #region Eventos

        private void frmMovFinanciamientoDet_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void bsBase_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblTitPnlBase.Text = "Registros " + bsBase.List.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsBase_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (bsBase.Current != null)
                {
                    txtCapital.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).DeudaCapital.ToString("N2");
                    txtTea.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).Tea.ToString("N2");
                    txtTem.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).Tem.ToString("N3");
                    txtNroCuotas.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).Cuotas.ToString("N2");
                    txtItem.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).Item.ToString();
                    txtImpAmortizado.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).ImporteAmortizado.ToString("N2");
                    txtAmortizacion.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).Amortizacion.ToString("N2");
                    txtInteres.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).Interes.ToString("N2");
                    txtValorCuota.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).ValorCuota.ToString("N2");
                    txtComision.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).Comision.ToString("N2");
                    txtTotal.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).Total.ToString("N2");
                    txtAcumulado.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).DiasAcumulados.ToString();
                    txtInteresAD.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).InteresPorDa.ToString("N2");

                    txtUsuRegistra.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).UsuarioRegistro;
                    txtUsuModifica.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).UsuarioModificacion;
                    txtFechaRegistro.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).FechaRegistro.ToString();
                    txtFechaModifica.Text = ((MovimientoFinanciamientoDetE)bsBase.Current).FechaModificacion.ToString();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dtpFecVenc_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (bsBase.Current != null)
                {
                    if (dtpFecVenc.Focused)
                    {
                        bsBase.EndEdit();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btRecalcular_Click(object sender, EventArgs e)
        {
            try
            {
                Recalcular();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDiasCuota_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (bsBase.Current != null)
                {
                    if (txtDiasCuota.Focused)
                    {
                        ((MovimientoFinanciamientoDetE)bsBase.Current).Cambio = "T";
                        bsBase.EndEdit();
                    }
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
