using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;

namespace ClienteWinForm.Tesoreria.Reportes
{
    public partial class frmReporteCtaCteComparativoDetalle : FrmMantenimientoBase
    {

        #region Constructores

        public frmReporteCtaCteComparativoDetalle()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvListado, true);
            FormatoGrid(dgvListado2, true);
        }

        public frmReporteCtaCteComparativoDetalle(List<VoucherItemE> oListaDetalle_, List<CtaCteE> oListaCtaCteDet_)
           :this()
        {
            oListaVoucherItem = oListaDetalle_;
            oListaCtaCteDet = oListaCtaCteDet_;

            decimal impSoles = oListaVoucherItem.Sum(x => x.impSoles);
            decimal impDolares = oListaVoucherItem.Sum(x => x.impDolares);

            txtSoles.Text = impSoles.ToString("N2");
            txtDolares.Text = impDolares.ToString("N2");

            bsVoucherItem.DataSource = oListaVoucherItem;
            bsVoucherItem.ResetBindings(false);

            bsCtaCteDet.DataSource = oListaCtaCteDet;
            bsCtaCteDet.ResetBindings(false);
        } 

        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteCtaCte { get { return new TesoreriaServiceAgent(); } }
        List<VoucherItemE> oListaVoucherItem = null;
        List<CtaCteE> oListaCtaCteDet = null;
        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        Boolean CambioAbono = false;
        Boolean CambioCargo = false;

        #endregion

        #region Eventos

        private void frmReporteCtaCteComparativoDetalle_Load(object sender, EventArgs e)
        {
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            //if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
            //{
            //    dgvListado2.Columns["idCtaCte"].Visible = false;
            //    dgvListado2.Columns["idCtaCteItem"].Visible = false;
            //}
        }

        private void btEliminarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                {
                    //Eliminando de la BD
                    Int32 resp = AgenteCtaCte.Proxy.EliminarMaeCtaCteDetallePorIdItem(((CtaCteE)bsCtaCteDet.Current).idCtaCteItem);

                    if (resp > 0)
                    {
                        //Eliminando de la lista
                        oListaCtaCteDet.Remove((CtaCteE)bsCtaCteDet.Current);
                        bsCtaCteDet.DataSource = oListaCtaCteDet;
                        bsCtaCteDet.ResetBindings(false);

                        Global.MensajeComunicacion("Fila eliminada...!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvListado2.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bsCtaCteDet.EndEdit();

                if (CambioAbono || CambioCargo)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        CtaCte_DetE ItemModificado = null;
                        Int32 resp = 0;

                        if (CambioAbono)
                        {
                            ItemModificado = new CtaCte_DetE()
                            {
                                idCtaCteItem = ((CtaCteE)bsCtaCteDet.Current).idCtaCteItem,
                                MontoMov = ((CtaCteE)bsCtaCteDet.Current).Abono,
                                FechaMovimiento = VariablesLocales.FechaHoy,
                                UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial
                            };

                            resp = AgenteCtaCte.Proxy.ActualizarMaeCtaCteDetPorIdItem(ItemModificado);

                            if (resp > 0)
                            {
                                Global.MensajeComunicacion("Abono actualizado...!!!");
                            }

                            CambioAbono = false;
                        }

                        if (CambioCargo)
                        {
                            ItemModificado = new CtaCte_DetE()
                            {
                                idCtaCteItem = ((CtaCteE)bsCtaCteDet.Current).idCtaCteItem,
                                MontoMov = ((CtaCteE)bsCtaCteDet.Current).Cargo,
                                FechaMovimiento = VariablesLocales.FechaHoy,
                                UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial
                            };

                            resp = AgenteCtaCte.Proxy.ActualizarMaeCtaCteDetPorIdItem(ItemModificado);

                            if (resp > 0)
                            {
                                Global.MensajeComunicacion("Cargo actualizado...!!!");
                            }

                            CambioAbono = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvListado2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dgvListado2.Rows[e.RowIndex].Cells["TipoAC"].Value.ToString() == "C")
                    {
                        dgvListado2.Rows[e.RowIndex].Cells["Cargo"].Style.SelectionBackColor = Color.White;
                        dgvListado2.Rows[e.RowIndex].Cells["Cargo"].Style.SelectionForeColor = SystemColors.Highlight;

                        dgvListado2.Rows[e.RowIndex].Cells["Cargo"].ReadOnly = false;
                        dgvListado2.Rows[e.RowIndex].Cells["Abono"].ReadOnly = true;
                    }

                    if (dgvListado2.Rows[e.RowIndex].Cells["TipoAC"].Value.ToString() == "A")
                    {
                        dgvListado2.Rows[e.RowIndex].Cells["Abono"].Style.SelectionBackColor = Color.White;
                        dgvListado2.Rows[e.RowIndex].Cells["Abono"].Style.SelectionForeColor = SystemColors.Highlight;

                        dgvListado2.Rows[e.RowIndex].Cells["Abono"].ReadOnly = false;
                        dgvListado2.Rows[e.RowIndex].Cells["Cargo"].ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvListado2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (bsCtaCteDet.List.Count > 0)
                {
                    if (dgvListado2.Columns[e.ColumnIndex].Name == "Abono")
                    {
                        CambioAbono = true;
                    }

                    if (dgvListado2.Columns[e.ColumnIndex].Name == "Cargo")
                    {
                        CambioCargo = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsCtaCteDet_CurrentChanged(object sender, EventArgs e)
        {
            if (CambioAbono)
            {
                CambioAbono = false;
            }

            if (CambioCargo)
            {
                CambioCargo = false;
            }
        }

        private void btRegenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.MensajeConfirmacion("Desea regenerar la Cta.Cte.") == DialogResult.Yes)
                {
                    Int32 resp = AgenteCtaCte.Proxy.RegenerarCtaCte(((CtaCteE)bsCtaCteDet.Current).idEmpresa, ((CtaCteE)bsCtaCteDet.Current).idPersona, ((CtaCteE)bsCtaCteDet.Current).idDocumentoMov, ((CtaCteE)bsCtaCteDet.Current).SerieMov, ((CtaCteE)bsCtaCteDet.Current).NumeroMov);

                    if (resp > 0)
                    {
                        Global.MensajeComunicacion("Se regeneró correctamente la Cta.Cte.!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btGenerarCtaCte_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaVoucherItem != null && oListaVoucherItem.Count > 0)
                {
                    if (Global.MensajeConfirmacion("Desea generar la Cta.Cte. a partir del voucher") == DialogResult.Yes)
                    {
                        Int32 resp = AgenteCtaCte.Proxy.GenerarCtaCtePorVoucherItem(((VoucherItemE)bsVoucherItem.Current).idEmpresa, ((VoucherItemE)bsVoucherItem.Current).idLocal, ((VoucherItemE)bsVoucherItem.Current).AnioPeriodo, ((VoucherItemE)bsVoucherItem.Current).MesPeriodo, ((VoucherItemE)bsVoucherItem.Current).numVoucher, ((VoucherItemE)bsVoucherItem.Current).idComprobante, ((VoucherItemE)bsVoucherItem.Current).numFile, ((VoucherItemE)bsVoucherItem.Current).numItem);

                        if (resp > 0)
                        {
                            Global.MensajeComunicacion("Se generó correctamente la Cta.Cte.!!!");
                            Buscar();
                        }
                    } 
                }
                else
                {
                    Global.MensajeComunicacion("No hay datos para generar la Cta.Cte.");
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
