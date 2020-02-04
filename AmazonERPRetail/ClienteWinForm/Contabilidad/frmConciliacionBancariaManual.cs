using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmConciliacionBancariaManual : FrmBusquedaBase
    {

        #region Constructores

        public frmConciliacionBancariaManual()
        {
            InitializeComponent();
            FormatoGrid(dgvVoucherItem, true);
        }

        public frmConciliacionBancariaManual(Int32 PeriodoConciliacion_, VoucherItemE voucherItem, Int32 idBanco)
            :this()
        {
            oVoucher = voucherItem;
            PeriodoConciliacion = PeriodoConciliacion_;
            AnioConciliacion = Convert.ToInt32(VariablesLocales.PeriodoContable.AnioPeriodo);
            Banco = idBanco;

            txtLibro.Text = oVoucher.idComprobante;
            txtFile.Text = oVoucher.numFile;
            txtAsociado.Text = oVoucher.numVoucher;
            txtDocumento.Text = oVoucher.idDocumento + " " + oVoucher.serDocumento + "-" + oVoucher.numDocumento;
            txtMonto.Text = oVoucher.monto.ToString("N2");
        } 

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        VoucherItemE oVoucher = null;
        Int32 PeriodoConciliacion = 0;
        Int32 AnioConciliacion = 0;
        BancosConciliarE conciliado = new BancosConciliarE();
        Int32 Banco = 0;

        #endregion

        #region Procedimientos de Usuario

        void Sumar()
        {
            Decimal Monto = (from x in (List<BancosConciliarE>)bsBase.List
                                                        where x.chkEscoger == true
                                                        select x.Monto).Sum();

            txtMontoTotal.Text = Monto.ToString("N2");
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                List<BancosConciliarE> ListaBancoConciliado = AgenteContabilidad.Proxy.ListarBancosConciliar(Banco, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, AnioConciliacion, PeriodoConciliacion, oVoucher.codCuenta);
                String NoEncontro = "N";

                foreach (BancosConciliarE item in ListaBancoConciliado)
                {
                    if (item.AnioPeriodo == oVoucher.AnioPeriodo && item.MesPeriodo == oVoucher.MesPeriodo && item.idComprobante == oVoucher.idComprobante && item.numFile == oVoucher.numFile && item.numVoucher == oVoucher.numVoucher && item.numItem == oVoucher.numItem)// && item.Fecha.ToString("dd/MM/yyyy") == oVoucher.fecDocumento.Value.ToString("dd/MM/yyyy"))
                    {
                        NoEncontro = "S";
                        break;
                    }
                }

                if (NoEncontro == "N")
                {
                    List<BancosConciliarE> ConciliadosSinNumero = (from x in ListaBancoConciliado
                                                                   where x.AnioPeriodo == ""
                                                                   && x.MesPeriodo == ""
                                                                   && x.numVoucher == ""
                                                                   && x.idComprobante == ""
                                                                   && x.numFile == ""
                                                                   && x.numItem == ""
                                                                   select x).ToList();

                    txtLibro.BackColor = Valores.ColorAnulado;
                    txtFile.BackColor = Valores.ColorAnulado;
                    txtAsociado.BackColor = Valores.ColorAnulado;
                    txtDocumento.BackColor = Valores.ColorAnulado;
                    txtMonto.BackColor = Valores.ColorAnulado;

                    btDesvincular.Text = "Vincular Documento";
                    btDesvincular.Image = Properties.Resources.Vincular24x24;
                    bsBase.DataSource = ConciliadosSinNumero;
                }
                else
                {
                    List<BancosConciliarE> Conciliados = (from x in ListaBancoConciliado
                                                          where x.AnioPeriodo == oVoucher.AnioPeriodo
                                                          && x.MesPeriodo == oVoucher.MesPeriodo
                                                          && x.numVoucher == oVoucher.numVoucher
                                                          && x.idComprobante == oVoucher.idComprobante
                                                          && x.numFile == oVoucher.numFile
                                                          && x.numItem == oVoucher.numItem
                                                          select x).ToList();

                    txtMontoTotal.Text = Conciliados.Sum(x => x.Monto).ToString("N2");

                    btDesvincular.Text = "Desvincular Documentos";
                    btDesvincular.Image = Properties.Resources.Desvincular24x24;
                    bsBase.DataSource = Conciliados;
                }
                
                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            try
            {
                if (bsBase.Count > 0)
                {
                    conciliado = (BancosConciliarE)bsBase.Current;

                    conciliado.idLocal = oVoucher.idLocal;
                    conciliado.AnioPeriodo = oVoucher.AnioPeriodo;
                    conciliado.MesPeriodo = oVoucher.MesPeriodo;
                    conciliado.numVoucher = oVoucher.numVoucher;
                    conciliado.idComprobante = oVoucher.idComprobante;
                    conciliado.numFile = oVoucher.numFile;
                    conciliado.numItem = oVoucher.numItem;
                    oVoucher.indConciliadoBool = true;
                    AgenteContabilidad.Proxy.ActualizarBancosConciliar(conciliado);

                    base.Aceptar();
                }
                else
                {
                    Global.MensajeComunicacion("No hay datos. Presione Cancelar");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmConciliacionBancariaManual_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btDesvincular_Click(object sender, EventArgs e)
        {
            String Dato = btDesvincular.Text;
            List<BancosConciliarE> ListaConciliacion = (from x in (List<BancosConciliarE>)bsBase.List
                                                        where x.chkEscoger == true select x).ToList();

            if (ListaConciliacion == null || ListaConciliacion.Count == 0)
            {
                Global.MensajeAdvertencia("Debe escoger un item antes de " + Dato);
                return;
            }

            if (Dato.Substring(0, 3) == "Vin")
            {
                foreach (BancosConciliarE item in ListaConciliacion)
                {
                    item.idLocal = oVoucher.idLocal;
                    item.AnioPeriodo = oVoucher.AnioPeriodo;
                    item.MesPeriodo = oVoucher.MesPeriodo;
                    item.numVoucher = oVoucher.numVoucher;
                    item.idComprobante = oVoucher.idComprobante;
                    item.numFile = oVoucher.numFile;
                    item.numItem = oVoucher.numItem;

                    AgenteContabilidad.Proxy.ActualizarBancosConciliar(item);
                }

                oVoucher.indConciliado = "S";

                List<VoucherItemE> ListaTmp = new List<VoucherItemE>
                {
                    oVoucher
                };

                AgenteContabilidad.Proxy.GrabarVoucherItem(ListaTmp);
                Global.MensajeComunicacion("Documento Vinculado");
            }
            else
            {
                foreach (BancosConciliarE item in ListaConciliacion)
                {
                    item.idLocal = null;
                    item.AnioPeriodo = String.Empty;
                    item.MesPeriodo = String.Empty;
                    item.numVoucher = String.Empty;
                    item.idComprobante = String.Empty;
                    item.numFile = String.Empty;
                    item.numItem = String.Empty;

                    AgenteContabilidad.Proxy.ActualizarBancosConciliar(item);
                }

                oVoucher.indConciliado = "N";

                List<VoucherItemE> ListaTmp = new List<VoucherItemE>
                {
                    oVoucher
                };

                AgenteContabilidad.Proxy.GrabarVoucherItem(ListaTmp);
                Global.MensajeComunicacion("Documento Desvinculado");
            }

            base.Aceptar();
        }

        private void dgvVoucherItem_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvVoucherItem.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvVoucherItem.CommitEdit(DataGridViewDataErrorContexts.Commit);
                Sumar();
            }
        }

        #endregion

    }
}
