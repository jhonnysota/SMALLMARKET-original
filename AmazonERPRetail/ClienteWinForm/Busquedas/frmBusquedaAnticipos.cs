using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBusquedaAnticipos : FrmBusquedaBase
    {

        #region Constructores

        public frmBusquedaAnticipos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvAnticipos);
        }

        public frmBusquedaAnticipos(Int32 idPersona_, string RazonSocial_)
            :this()
        {
            Text = RazonSocial_;
            idPersona = idPersona_;
        } 

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public AnticiposE oAnticipo = null;
        Int32 idPersona = 0;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                bsBase.DataSource = AgenteVentas.Proxy.ListarAnticipos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idPersona);

                if (bsBase.Count > 0)
                {
                    dgvAnticipos.Enabled = true;
                    dgvAnticipos.Focus();
                    dgvAnticipos.CurrentRow.Cells[3].Selected = true;
                }
                else
                {
                    Global.MensajeComunicacion("Este cliente no posee ningún anticipo.");
                    dgvAnticipos.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

            base.Buscar();
        }

        protected override void Aceptar()
        {
            try
            {
                if (bsBase.Count > 0)
                {
                    if (((AnticiposE)bsBase.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        Global.MensajeComunicacion("Este documento tiene que estar emitido, antes de aplicarlo.");
                        return;
                    }

                    oAnticipo = (AnticiposE)bsBase.Current;

                    if (oAnticipo.TotalSaldo != oAnticipo.TotalSaldoTmp)
                    {
                        Decimal TotalAnticipoInicial = oAnticipo.TotalSaldoTmp;
                        Decimal IgvAnticipoInicial = oAnticipo.IgvAnticipo;
                        Decimal SubTotalAnticipoInicial = oAnticipo.SubTotalAnticipo;
                        Decimal TotalSaldo = oAnticipo.TotalSaldo;
                        Decimal Igv = VariablesLocales.oListaImpuestos[0].Porcentaje / 100;

                        Igv += 1;

                        //Anticipo
                        oAnticipo.TotalAnticipo = TotalSaldo;

                        if (IgvAnticipoInicial > 0)
                        {
                            oAnticipo.IgvAnticipo = oAnticipo.TotalAnticipo - decimal.Round(oAnticipo.TotalAnticipo / Igv, 2);
                        }

                        oAnticipo.SubTotalAnticipo = oAnticipo.TotalAnticipo - oAnticipo.IgvAnticipo;

                        //Saldos
                        oAnticipo.SubTotalSaldo = SubTotalAnticipoInicial - oAnticipo.SubTotalAnticipo;
                        oAnticipo.IgvSaldo = IgvAnticipoInicial - oAnticipo.IgvAnticipo;
                        oAnticipo.TotalSaldo = TotalAnticipoInicial - oAnticipo.TotalAnticipo;
                    }

                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmBusquedaAnticipos_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvAnticipos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvAnticipos, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvAnticipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }

        #endregion

    }
}
