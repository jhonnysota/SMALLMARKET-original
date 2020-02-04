using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;
using ClienteWinForm.Contabilidad.Reportes;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoPlanillaBancos : FrmMantenimientoBase
    {

        public frmListadoPlanillaBancos()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvPlanillas, true);
            LlenarCombos();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<BancosE> oListaBancos = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            oListaBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComboHelper.RellenarCombos<BancosE>(cboBancos, (from x in oListaBancos orderby x.idPersona select x).ToList(), "idPersona", "RazonSocial");

            cboProductos.DataSource = Global.CargarTipoProductosPlanilla();
            cboProductos.ValueMember = "id";
            cboProductos.DisplayMember = "Nombre";
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPlanillaBancos);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    //si la instancia existe la pongo en primer plano
                    oFrm.BringToFront();
                    return;
                }

                //sino existe la instancia se crea una nueva
                oFrm = new frmPlanillaBancos(oListaBancos)
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
            try
            {
                if (bsPlanilla.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPlanillaBancos);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmPlanillaBancos(((PlanillaBancosE)bsPlanilla.Current).idPlanillaBanco, oListaBancos)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
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
                String tipFecha = rbFecha.Checked ? "F" : "A";
                String Producto = rbTodosProd.Checked ? "%" : cboProductos.SelectedValue.ToString();
                Int32 idBanco = rbTodosBancos.Checked ? 0 : Convert.ToInt32(cboBancos.SelectedValue);
                String Tipo = "B"; //B = Por banco L = Por letras

                if (rbL.Checked)
                {
                    Tipo = "L";
                    dgvPlanillas.Columns["numCuenta"].HeaderText = "N° Letra";
                    dgvPlanillas.Columns["MontoAbono"].HeaderText = "Monto Letra";
                    dgvPlanillas.Columns["MontoLetras"].Visible = false;
                }
                else
                {
                    dgvPlanillas.Columns["numCuenta"].HeaderText = "N° Cuenta";
                    dgvPlanillas.Columns["MontoAbono"].HeaderText = "Monto Abono";
                    dgvPlanillas.Columns["MontoLetras"].Visible = true;
                }

                List<PlanillaBancosE> oListaPlanillas = AgenteVentas.Proxy.ListarPlanillaBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, 
                                                                                                idBanco, Producto, tipFecha, dtpFecIni.Value.Date, dtpFecFin.Value.Date, Tipo);
                bsPlanilla.DataSource = oListaPlanillas;
                bsPlanilla.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                PlanillaBancosE oPlanillaBanco = (PlanillaBancosE)bsPlanilla.Current;

                if (oPlanillaBanco.Generado || oPlanillaBanco.GeneradoRec)
                {
                    Global.MensajeFault("Primero tiene que eliminar los vouchers generados.");
                    return;
                }

                if (oPlanillaBanco.Estado != "ANULADO")
                {
                    if (Global.MensajeConfirmacion("Desea Anular el registro.") == DialogResult.Yes)
                    {
                        Int32 resp = AgenteVentas.Proxy.AnularPlanillaBancos(((PlanillaBancosE)bsPlanilla.Current).idPlanillaBanco, "", "", VariablesLocales.SesionUsuario.Credencial, "A", false, "R");

                        if (resp > 0)
                        {
                            Buscar();
                            Global.MensajeComunicacion("Registro Anulado.");
                        }
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion("Desea Eliminar el registro.") == DialogResult.Yes)
                    {
                        Int32 resp = AgenteVentas.Proxy.EliminarPlanillaBancos(((PlanillaBancosE)bsPlanilla.Current).idPlanillaBanco);

                        if (resp > 0)
                        {
                            Buscar();
                            Global.MensajeComunicacion("Registro Eliminado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmPlanillaBancos oFrm = sender as frmPlanillaBancos;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoPlanillaBancos_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            base.Grabar();

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                dgvPlanillas.Columns[0].Visible = true;
            }
        }

        private void rbTodosProd_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodosProd.Checked)
            {
                cboProductos.Enabled = false;
            }
            else
            {
                cboProductos.Enabled = true;
            }
        }

        private void rbTodosBancos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodosBancos.Checked)
            {
                cboBancos.Enabled = false;
            }
            else
            {
                cboBancos.Enabled = true;
            }
        }

        private void dgvPlanillas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (bsPlanilla.Current != null)
                {
                    Editar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvPlanillas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((String)dgvPlanillas.Rows[e.RowIndex].Cells["Estado"].Value == "ANULADO")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorAnulado;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsPlanilla_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                LblTitulo.Text = "Registros " + bsPlanilla.List.Count;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiGenerarVI_Click(object sender, EventArgs e)
        {
            try
            {
                if (((PlanillaBancosE)bsPlanilla.Current).Producto == "L")
                {
                    if (((PlanillaBancosE)bsPlanilla.Current).numFileRec == "0")
                    {
                        Global.MensajeComunicacion("Debe escoger un File antes de generar el asiento.");
                        return;
                    }

                    String VoucherGenerado = AgenteVentas.Proxy.GenerarAsientoLetrasDiferidas(((PlanillaBancosE)bsPlanilla.Current).idPlanillaBanco,
                                                                                                ((PlanillaBancosE)bsPlanilla.Current).idEmpresa,
                                                                                                ((PlanillaBancosE)bsPlanilla.Current).idLocal,
                                                                                                VariablesLocales.SesionUsuario.Credencial);
                    if (!String.IsNullOrWhiteSpace(VoucherGenerado.Trim()))
                    {
                        if (String.IsNullOrWhiteSpace(((PlanillaBancosE)bsPlanilla.Current).numVoucher))
                        {
                            Global.MensajeComunicacion(String.Format("Se actualizó el Asiento Contable {0}", VoucherGenerado));
                        }
                        else
                        {
                            Global.MensajeComunicacion(String.Format("Se generó el Asiento Contable {0}", VoucherGenerado));
                        }

                        Buscar();
                    }
                }
                else if (((PlanillaBancosE)bsPlanilla.Current).Producto == "D")
                {
                    if (((PlanillaBancosE)bsPlanilla.Current).GeneradoRec)
                    {
                        if (((PlanillaBancosE)bsPlanilla.Current).numFile == "0")
                        {
                            Global.MensajeComunicacion("Debe escoger un File antes de generar el asiento.");
                            return;
                        }

                        String VoucherGenerado = AgenteVentas.Proxy.GenerarAsientoLetrasDiferidas(((PlanillaBancosE)bsPlanilla.Current).idPlanillaBanco,
                                                                                                    ((PlanillaBancosE)bsPlanilla.Current).idEmpresa,
                                                                                                    ((PlanillaBancosE)bsPlanilla.Current).idLocal,
                                                                                                    VariablesLocales.SesionUsuario.Credencial);
                        if (!String.IsNullOrWhiteSpace(VoucherGenerado.Trim()))
                        {
                            if (!String.IsNullOrWhiteSpace(((PlanillaBancosE)bsPlanilla.Current).numVoucher))
                            {
                                Global.MensajeComunicacion(String.Format("Se actualizó el Asiento Contable {0}", VoucherGenerado));
                            }
                            else
                            {
                                Global.MensajeComunicacion(String.Format("Se generó el Asiento Contable {0}", VoucherGenerado));
                            }

                            Buscar();
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("Debe generar el asiento de reclasificación primero.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiGenerarVR_Click(object sender, EventArgs e)
        {
            try
            {
                if (((PlanillaBancosE)bsPlanilla.Current).numFileRec == "0")
                {
                    Global.MensajeComunicacion("Debe escoger un File antes de generar el asiento.");
                    return;
                }

                String VoucherGenerado = AgenteVentas.Proxy.GenerarAsientoReclasificacion(((PlanillaBancosE)bsPlanilla.Current).idPlanillaBanco,
                                                                                            ((PlanillaBancosE)bsPlanilla.Current).idEmpresa,
                                                                                            ((PlanillaBancosE)bsPlanilla.Current).idLocal,
                                                                                            VariablesLocales.SesionUsuario.Credencial);
                if (!String.IsNullOrWhiteSpace(VoucherGenerado.Trim()))
                {
                    if (!String.IsNullOrWhiteSpace(((PlanillaBancosE)bsPlanilla.Current).numVoucherRec))
                    {
                        Global.MensajeComunicacion(String.Format("Se actualizó el asiento de reclasificación {0}", VoucherGenerado));
                    }
                    else
                    {
                        Global.MensajeComunicacion(String.Format("Se generó el asiento de reclasificación {0}", VoucherGenerado));
                    }

                    Buscar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiImprimeVI_Click(object sender, EventArgs e)
        {
            try
            {
                if (((PlanillaBancosE)bsPlanilla.Current).Generado)
                {
                    VoucherE oVoucher = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(((PlanillaBancosE)bsPlanilla.Current).idEmpresa, VariablesLocales.SesionLocal.IdLocal,
                                                                                                ((PlanillaBancosE)bsPlanilla.Current).AnioPeriodo, ((PlanillaBancosE)bsPlanilla.Current).MesPeriodo,
                                                                                                ((PlanillaBancosE)bsPlanilla.Current).numVoucher, ((PlanillaBancosE)bsPlanilla.Current).idComprobante,
                                                                                                ((PlanillaBancosE)bsPlanilla.Current).numFile);
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

                        oFrm = new frmImpresionVoucher("N", oVoucher);
                        oFrm.MdiParent = MdiParent;
                        oFrm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiImprimeVR_Click(object sender, EventArgs e)
        {
            try
            {
                if (((PlanillaBancosE)bsPlanilla.Current).GeneradoRec)
                {
                    VoucherE oVoucher = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(((PlanillaBancosE)bsPlanilla.Current).idEmpresa, VariablesLocales.SesionLocal.IdLocal,
                                                                                                ((PlanillaBancosE)bsPlanilla.Current).AnioPeriodo, ((PlanillaBancosE)bsPlanilla.Current).MesPeriodo,
                                                                                                ((PlanillaBancosE)bsPlanilla.Current).numVoucherRec, ((PlanillaBancosE)bsPlanilla.Current).idComprobanteRec,
                                                                                                ((PlanillaBancosE)bsPlanilla.Current).numFileRec);
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

                        oFrm = new frmImpresionVoucher("N", oVoucher);
                        oFrm.MdiParent = MdiParent;
                        oFrm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiDescuento_Click(object sender, EventArgs e)
        {
            try
            {
                Global.MensajeComunicacion("En construcción...");
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiCobranza_Click(object sender, EventArgs e)
        {
            try
            {
                Global.MensajeComunicacion("En construcción...");
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsPlanilla_CurrentItemChanged(object sender, EventArgs e)
        {
            try
            {
                if (bsPlanilla.Current != null)
                {
                    //D = Letras en Descuento L = Cobranza Libre
                    if (((PlanillaBancosE)bsPlanilla.Current).Producto == "D")
                    {
                        tsmiGenerarVR.Enabled = true;
                        tsmiGenerarVI.Enabled = true;

                        if (((PlanillaBancosE)bsPlanilla.Current).GeneradoRec)
                        {
                            tsmiImprimeVR.Enabled = true;
                            tsmiEliminarVR.Enabled = true;
                        }
                        else
                        {
                            tsmiImprimeVR.Enabled = false;
                            tsmiEliminarVR.Enabled = false;
                        }

                        if (((PlanillaBancosE)bsPlanilla.Current).Generado)
                        {
                            tsmiImprimeVI.Enabled = true;
                            tsmiEliminarVI.Enabled = true;
                        }
                        else
                        {
                            tsmiImprimeVI.Enabled = false;
                            tsmiEliminarVI.Enabled = false;
                        }
                    }
                    else if (((PlanillaBancosE)bsPlanilla.Current).Producto == "L")
                    {
                        tsmiGenerarVR.Enabled = true;
                        tsmiGenerarVI.Enabled = false;

                        if (((PlanillaBancosE)bsPlanilla.Current).GeneradoRec)
                        {
                            tsmiImprimeVR.Enabled = true;
                            tsmiEliminarVR.Enabled = true;
                            tsmiEliminarVI.Enabled = false;
                            tsmiImprimeVI.Enabled = false;
                        }
                        else
                        {
                            tsmiImprimeVR.Enabled = false;
                            tsmiEliminarVR.Enabled = false;
                            tsmiEliminarVI.Enabled = false;
                            tsmiImprimeVI.Enabled = false;
                        }
                    }
                }
                else
                {
                    tsmiGenerarVI.Enabled = false;
                    tsmiImprimeVI.Enabled = false;
                    tsmiEliminarVI.Enabled = false;
                    tsmiGenerarVR.Enabled = false;
                    tsmiImprimeVR.Enabled = false;
                    tsmiEliminarVR.Enabled = false;
                    tsmiCobranza.Enabled = false;
                    tsmiDescuento.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiEliminarVR_Click(object sender, EventArgs e)
        {
            try
            {
                if (((PlanillaBancosE)bsPlanilla.Current).GeneradoRec)
                {
                    if (((PlanillaBancosE)bsPlanilla.Current).Producto == "D")
                    {
                        if (((PlanillaBancosE)bsPlanilla.Current).Generado)
                        {
                            Global.MensajeComunicacion("Debe eliminar primero el voucher de ingreso.");
                            return;
                        }
                    }

                    String Mensaje = AgenteVentas.Proxy.RevisarLetrasCobranzas((PlanillaBancosE)bsPlanilla.Current);

                    if (String.IsNullOrWhiteSpace(Mensaje))
                    {
                        Int32 resp = AgenteVentas.Proxy.EliminarAsientoLetras((PlanillaBancosE)bsPlanilla.Current, VariablesLocales.SesionUsuario.Credencial, "P", false, "R");

                        if (resp > 0)
                        {
                            //((PlanillaBancosE)bsPlanilla.Current).GeneradoRec = false;
                            //((PlanillaBancosE)bsPlanilla.Current).Estado = "EN PROCESO";
                            //bsPlanilla.ResetBindings(false);
                            Buscar();
                            Global.MensajeFault("El asiento contable se eliminó correctamente.");
                        } 
                    }
                    else
                    {
                        Global.MensajeAdvertencia(Mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiEliminarVI_Click(object sender, EventArgs e)
        {
            try
            {
                if (((PlanillaBancosE)bsPlanilla.Current).Generado)
                {
                    Int32 resp = 0;

                    if (((PlanillaBancosE)bsPlanilla.Current).Producto == "D")
                    {
                        resp = AgenteVentas.Proxy.EliminarAsientoLetras((PlanillaBancosE)bsPlanilla.Current, VariablesLocales.SesionUsuario.Credencial, "C", false, "N");
                    }
                    else
                    {
                        resp = AgenteVentas.Proxy.EliminarAsientoLetras((PlanillaBancosE)bsPlanilla.Current, VariablesLocales.SesionUsuario.Credencial, "P", false, "N");
                    }

                    if (resp > 0)
                    {
                        ((PlanillaBancosE)bsPlanilla.Current).Generado = false;
                        ((PlanillaBancosE)bsPlanilla.Current).Estado = "CERRADO";
                        bsPlanilla.ResetBindings(false);
                        Global.MensajeFault("El asiento contable se eliminó correctamente.");
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
