using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Contabilidad.Reportes;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmReciboHonorariosListado : FrmMantenimientoBase
    {

        public frmReciboHonorariosListado()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvListado, false);
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        string AnioContable = VariablesLocales.FechaHoy.Year.ToString();
        string MesContable = VariablesLocales.FechaHoy.Month.ToString("00");
        List<ReciboHonorariosE> oLista = new List<ReciboHonorariosE>();

        #endregion

        #region Procedimientos

        void LlenarCombos()
        {
            Int32 AnioFin = 0;
            Int32 AnioInicio = 0;

            //Cargando Meses Contables
            cboMes.DataSource = FechasHelper.CargarMeses(1, true, "MA");
            cboMes.ValueMember = "MesId";
            cboMes.DisplayMember = "MesDes";

            //Cargando Años
            AnioFin = Convert.ToInt32(AnioContable);
            AnioInicio = AnioFin - 10;
            cboAnio.DataSource = FechasHelper.CargarAnios(AnioInicio, AnioFin + 2);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = MdiChildren.FirstOrDefault(x => x is frmReciboHonorarios);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                String Anio = Convert.ToString(cboAnio.SelectedValue);
                String Mes = Convert.ToString(cboMes.SelectedValue);

                oFrm = new frmReciboHonorarios(Anio, Mes)
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            Form oFrm = MdiChildren.FirstOrDefault(x => x is frmReciboHonorarios);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            String Anio = Convert.ToString(cboAnio.SelectedValue);
            String Mes = Convert.ToString(cboMes.SelectedValue);

            ReciboHonorariosE ERecHon = (ReciboHonorariosE)bsRecibohonorarios.Current;

            if (ERecHon != null)
            {
                oFrm = new frmReciboHonorarios(ERecHon, Anio, Mes)
                {
                    MdiParent = this.MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
        }

        public override void Buscar()
        {
            try
            {
                String Anio = cboAnio.SelectedValue.ToString();
                String Mes = cboMes.SelectedValue.ToString();
                String RazonSocial = txtFiltro.Text.Trim();
                String Tipo = "A";

                if (rbR.Checked)
                {
                    Tipo = "R";
                    dgvListado.Columns["idDocumento"].Visible = true;
                    dgvListado.Columns["serDocumento"].Visible = true;
                    dgvListado.Columns["numDocumento"].Visible = true;
                }
                else
                {
                    dgvListado.Columns["idDocumento"].Visible = false;
                    dgvListado.Columns["serDocumento"].Visible = false;
                    dgvListado.Columns["numDocumento"].Visible = false;
                }

                oLista = AgenteContabilidad.Proxy.ListarReciboHonorarios(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, Anio, Mes, RazonSocial, Tipo);

                bsRecibohonorarios.DataSource = oLista;
                bsRecibohonorarios.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            Int32 resp = Variables.Cero;
            ReciboHonorariosE reciboHonorarios = (ReciboHonorariosE)bsRecibohonorarios.Current;

            try
            {
                if (reciboHonorarios != null)
                {
                    if (!reciboHonorarios.indEstado)
                    {
                        if (bsRecibohonorarios.Count > Variables.Cero)
                        {
                            if (Global.MensajeConfirmacion(Mensajes.AvisoEliminacion) == DialogResult.Yes)
                            {
                                List<ReciboHonorariosDetE> oValidaDetalle = AgenteContabilidad.Proxy.ListarReciboHonorariosDet(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, ((ReciboHonorariosE)bsRecibohonorarios.Current).idReciboHonorarios);

                                if (oValidaDetalle.Count > 0)
                                {
                                    Global.MensajeComunicacion("Este Recibo Contiene Detalle Existente");
                                }
                                else
                                {
                                    resp = AgenteContabilidad.Proxy.EliminarReciboHonorarios(((ReciboHonorariosE)bsRecibohonorarios.Current).idEmpresa, ((ReciboHonorariosE)bsRecibohonorarios.Current).idLocal, ((ReciboHonorariosE)bsRecibohonorarios.Current).idReciboHonorarios);

                                    if (resp > 0)
                                    {
                                        Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                                        oLista.Remove((ReciboHonorariosE)bsRecibohonorarios.Current);
                                        bsRecibohonorarios.DataSource = oLista;
                                        bsRecibohonorarios.ResetBindings(false);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("Debe abrir el Recibo antes de eliminarlo...!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmReciboHonorarios oFrm = sender as frmReciboHonorarios;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmReciboHonorariosListado_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);

            LlenarCombos();
            cboAnio.SelectedValue = Convert.ToInt32(AnioContable);
            cboMes.SelectedValue = MesContable;

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                dgvListado.Columns["idReciboHonorarios"].Visible = true;
                button1.Visible = true;
            }
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    Editar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void bsRecibohonorarios_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsRecibohonorarios.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                ReciboHonorariosE recibo = (ReciboHonorariosE)bsRecibohonorarios.Current;

                if (!recibo.indEstado)
                {
                    ReciboHonorariosE oReciboHonorario = AgenteContabilidad.Proxy.ObtenerReciboHonorarios(recibo.idEmpresa, recibo.idLocal, recibo.idReciboHonorarios);

                    if (oReciboHonorario != null)
                    {
                        Int32 oResultado = AgenteContabilidad.Proxy.GeneraAsientoReciboHonorariosDet(oReciboHonorario, VariablesLocales.SesionUsuario.Credencial);

                        if (oResultado == 1)
                        {
                            Global.MensajeFault("Se Generó correctamente el Asiento Contable ");
                            Buscar();
                        }
                    }
                }
                else
                {
                    Global.MensajeFault("Este recibo ya se encuentra Cerrado");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                ReciboHonorariosE recibo = (ReciboHonorariosE)bsRecibohonorarios.Current;

                if (recibo != null)
                {
                    if (recibo.indEstado)
                    {
                        ReciboHonorariosE oReciboHonorario = AgenteContabilidad.Proxy.ObtenerReciboHonorarios(recibo.idEmpresa, recibo.idLocal, recibo.idReciboHonorarios);

                        foreach (ReciboHonorariosDetE item in oReciboHonorario.oListaRecibos)
                        {
                            item.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            AgenteContabilidad.Proxy.CerrarReciboHonorariosDet(item);
                        }

                        //ReciboHonorariosDetE oResultado = AgenteContabilidad.Proxy.CerrarReciboHonorariosDet(oReciboHonorario);
                        Global.MensajeComunicacion("Se abrió correctamente el Recibo por Honorario");
                        Buscar();
                    }
                    else
                    {
                        Global.MensajeComunicacion("El recibo debe estar Cerrado !!");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                ReciboHonorariosE recibo = (ReciboHonorariosE)bsRecibohonorarios.Current;

                if (recibo != null)
                {
                    VoucherE oVoucher = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(recibo.idEmpresa, recibo.idLocal, recibo.AnioPeriodo, recibo.MesPeriodo, recibo.numVoucher, recibo.idComprobante, recibo.numFile);

                    if (oVoucher != null)
                    {
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionVoucher);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmImpresionVoucher("N", oVoucher)
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiLimpiar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((Boolean)dgvListado.Rows[e.RowIndex].Cells["indEstado"].Value == true)
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorCerrado;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void rbA_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ReciboHonorariosE recibo = (ReciboHonorariosE)bsRecibohonorarios.Current;

                if (recibo != null)
                {
                    ReciboHonorariosE oReciboHonorario = AgenteContabilidad.Proxy.ObtenerReciboHonorarios(recibo.idEmpresa, recibo.idLocal, recibo.idReciboHonorarios);

                    foreach (ReciboHonorariosDetE item in oReciboHonorario.oListaRecibos)
                    {
                        item.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        AgenteContabilidad.Proxy.CerrarReciboHonorariosDet(item);
                    }

                    //ReciboHonorariosDetE oResultado = AgenteContabilidad.Proxy.CerrarReciboHonorariosDet(oReciboHonorario);
                    Global.MensajeComunicacion("Se abrió correctamente el Recibo por Honorario");
                    Buscar();
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
