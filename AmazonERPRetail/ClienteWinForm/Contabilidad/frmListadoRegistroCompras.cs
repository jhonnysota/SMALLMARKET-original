using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoRegistroCompras : FrmMantenimientoBase
    {
        public frmListadoRegistroCompras()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvCompras, true);

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                dgvCompras.Columns[0].Visible = true;
            }

            
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<RegistroCompras2E> oListaRegCompras = null;
        private bool Ordenar;

        #endregion

        #region Procedimientos de Usuario

        void LlenaCombo()
        {
            cboTipoCompra.DataSource = Global.CargarTipoCompraConta();
            cboTipoCompra.DisplayMember = "Nombre";
            cboTipoCompra.ValueMember = "id";
        }

        #endregion
        
        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = null;

                if (Convert.ToInt32(cboTipoCompra.SelectedValue) == 1)
                {

                }
                else
                {
                    oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmRegistroComprasNoDom);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmRegistroComprasNoDom(Convert.ToInt32(cboTipoCompra.SelectedValue));
                    oFrm.MdiParent = MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrmNoDom_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVoucher);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                //if (Voucher != null)
                //{

                //    oFrm = new frmVoucher(Voucher.idEmpresa, Voucher.idLocal, Voucher.AnioPeriodo, Voucher.MesPeriodo, Voucher.numVoucher, Voucher.idComprobante, Voucher.numFile);
                //    oFrm.MdiParent = this.MdiParent;
                //    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                //    oFrm.Show();
                //}

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
                //VoucherE Voucher = (VoucherE)bsListadoVouchers.Current;

                //ComprobantesE com = (from x in VariablesLocales.oListaComprobantes
                //                     where x.idComprobante == ((VoucherE)bsListadoVouchers.Current).idComprobante
                //                     select x).FirstOrDefault();
                //ComprobantesFileE file = (from x in com.ListaComprobantesFiles
                //                          where x.numFile == ((VoucherE)bsListadoVouchers.Current).numFile
                //                          select x).FirstOrDefault();
                //if (file.flagAutomatico)
                //{
                //    Global.MensajeComunicacion("Este Comprobante es Automatico Eliminelo desde el Modulo que lo Genero !!");
                //    return;
                //}

                //if (Voucher != null)
                //{
                //    if (Global.MensajeConfirmacion(String.Format("Desea eliminar el Voucher {0}", Voucher.numVoucher)) == DialogResult.Yes)
                //    {
                //        AgenteContabilidad.Proxy.AnularVoucher(Voucher.idEmpresa, Voucher.idLocal, Voucher.AnioPeriodo, Voucher.MesPeriodo, Voucher.numVoucher, Voucher.idComprobante, Voucher.numFile, VariablesLocales.SesionUsuario.Credencial, "E");
                //        //Buscar();
                //        bsListadoVouchers.Remove(Voucher);
                //        Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                //        base.Anular();
                //    }
                //}

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                if (dtpInicio.Value > dtpFinal.Value)
                {
                    Global.MensajeComunicacion("La fecha de inicio no puede ser mayor a la fecha final.");
                    return;
                }

                oListaRegCompras = AgenteContabilidad.Proxy.ListarRegistroCompras(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal,
                                                                                    Convert.ToInt32(cboTipoCompra.SelectedValue), dtpInicio.Value.Date, dtpFinal.Value.Date);

                bsListadoRegCompras.DataSource = oListaRegCompras;
                bsListadoRegCompras.ResetBindings(false);

                lblRegistros.Text = " Registros " + bsListadoRegCompras.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override Boolean ValidarIngresoVentana()
        {
            return base.ValidarIngresoVentana();
        }

        #endregion

        #region Eventos de Usuario

        private void oFrmNoDom_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmRegistroComprasNoDom oFrm = sender as frmRegistroComprasNoDom;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                if (oListaRegCompras != null)
                {
                    //if (oFrm.Opcion == (Int32)EnumOpcionGrabar.Actualizar)
                    //{
                    //    for (Int32 i = 0; i < oListaRegCompras.Count - 1; i++)
                    //    {
                    //        //if (ListarVouchers[i].idEmpresa == oFrm.oVoucher.idEmpresa && ListarVouchers[i].idLocal == oFrm.oVoucher.idLocal
                    //        //    && ListarVouchers[i].AnioPeriodo == oFrm.oVoucher.AnioPeriodo && ListarVouchers[i].MesPeriodo == oFrm.oVoucher.MesPeriodo
                    //        //    && ListarVouchers[i].numVoucher == oFrm.oVoucher.numVoucher && ListarVouchers[i].idComprobante == oFrm.oVoucher.idComprobante
                    //        //    && ListarVouchers[i].numFile == oFrm.oVoucher.numFile)
                    //        //{
                    //        //    ListarVouchers[i] = oFrm.oVoucher;
                    //        //    i = ListarVouchers.Count;
                    //        //}
                    //    }
                    //}
                    //else
                    //{
                    //    //oListaRegCompras.Add(oFrm.oVoucher);
                    //    bsListadoRegCompras.MovePrevious();
                    //}

                    //bsListadoRegCompras.DataSource = oListaRegCompras;
                    //bsListadoRegCompras.ResetBindings(false);
                }
            }
        }

        #endregion

        #region Eventos

        private void frmListadoRegistroCompras_Load(object sender, EventArgs e)
        {
            Grid = true;
            LlenaCombo();
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());

            base.Grabar();
        }

        private void dgvCompras_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((bool)dgvCompras.Rows[e.RowIndex].Cells["indVoucher"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorSunat;
                }
            }
        }

        private void dgvCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvCompras_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaRegCompras != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Por Fecha de Operación
                    if (e.ColumnIndex == dgvCompras.Columns["fecOperacion"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaRegCompras = (from x in oListaRegCompras orderby x.fecOperacion ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaRegCompras = (from x in oListaRegCompras orderby x.fecOperacion descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por Fecha del Documento
                    if (e.ColumnIndex == dgvCompras.Columns["fecEmisDocumento"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaRegCompras = (from x in oListaRegCompras orderby x.fecEmisDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaRegCompras = (from x in oListaRegCompras orderby x.fecEmisDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por Serie
                    if (e.ColumnIndex == dgvCompras.Columns["serDocumento"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaRegCompras = (from x in oListaRegCompras orderby x.serDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaRegCompras = (from x in oListaRegCompras orderby x.serDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por número del documento
                    if (e.ColumnIndex == dgvCompras.Columns["numDocumento"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaRegCompras = (from x in oListaRegCompras orderby x.numDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaRegCompras = (from x in oListaRegCompras orderby x.numDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                }
            }
        }

        private void tsmiGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsListadoRegCompras.List.Count > 0)
                {
                    String Mes = ((RegistroCompras2E)bsListadoRegCompras.Current).MesPeriodo;
                    String Anio = ((RegistroCompras2E)bsListadoRegCompras.Current).AnioPeriodo;
                    String idComprobante = ((RegistroCompras2E)bsListadoRegCompras.Current).idComprobante;
                    String numFile = ((RegistroCompras2E)bsListadoRegCompras.Current).numFile;
                    String codCuenta = ((RegistroCompras2E)bsListadoRegCompras.Current).codCuenta;

                    if (!string.IsNullOrEmpty(Mes) && !string.IsNullOrEmpty(Anio) && !string.IsNullOrEmpty(idComprobante) && !string.IsNullOrEmpty(numFile) && !string.IsNullOrEmpty(codCuenta))
                    {
                        PeriodosE oPeriodoContable = new ContabilidadServiceAgent().Proxy.ObtenerPeriodoPorMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Anio, Mes);

                        if (oPeriodoContable != null)
                        {
                            if (oPeriodoContable.indCierre)
                            {
                                Global.MensajeComunicacion("El mes se encuentra cerrado. No puede enviar Asientos");
                            }
                            else
                            {
                                if (Global.MensajeConfirmacion("Seguro de Generar Asiento S/N") == DialogResult.Yes)
                                {
                                    RegistroCompras2E oRegistroCompras = AgenteContabilidad.Proxy.GenerarAsientoCompras(((RegistroCompras2E)bsListadoRegCompras.Current).idEmpresa,
                                                                                                                ((RegistroCompras2E)bsListadoRegCompras.Current).idLocal,
                                                                                                                ((RegistroCompras2E)bsListadoRegCompras.Current).idRegCompras,
                                                                                                                VariablesLocales.SesionUsuario.Credencial);
                                    if (oRegistroCompras != null)
                                    {
                                        Global.MensajeComunicacion(String.Format("Se generó el Asiento Contable {0} {1}-{2}", oRegistroCompras.idComprobante, oRegistroCompras.numFile, oRegistroCompras.numVoucher));
                                    }
                                    else
                                    {
                                        Global.MensajeFault("Hubo algunos inconvenientes al generar el Asiento Contable.");
                                    }
                                }
                            }
                        }
                        else
                        {
                            Global.MensajeComunicacion("No se encuentran los Periodos.");
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("Faltan algunos datos antes de generar el asiento contable. Verifique por favor...");
                    }
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
