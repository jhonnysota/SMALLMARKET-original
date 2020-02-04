using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Seguridad;
using Entidades.Contabilidad;
using Entidades.CtasPorCobrar;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Contabilidad.Reportes;
using System.Text;

namespace ClienteWinForm.CtasPorCobrar
{
    public partial class frmListadoPlanillaCobranza : FrmMantenimientoBase
    {
        
        #region Constructor

        public frmListadoPlanillaCobranza()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvListado, true, true);
            LlenarTipoPlanilla(VariablesLocales.SesionUsuario.Credencial);
            
        }

        #endregion

        #region Variables

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        CtasPorCobrarServiceAgent AgenteCtasCobrar { get { return new CtasPorCobrarServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<CobranzasE> oListCobranzatmp = null;
        List<ParTabla> TipoPlanilla = null;
        List<AsignarTipoCobranzaE> ListaTipoCobranza = null;
        Boolean Ordenar = false;
        
        #endregion

        #region Procedimientos de Usuario

        void LlenarTipoPlanilla(String Usuario)
        {
            try
            {
                if (Usuario == "SISTEMAS")
                {
                    TipoPlanilla = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPPLACO");
                    ComboHelper.LlenarCombos<ParTabla>(cboTipoCobranza, TipoPlanilla);
                }
                else
                {
                    ListaTipoCobranza = AgenteSeguridad.Proxy.ListarTipoCobranza(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, VariablesLocales.SesionUsuario.IdPersona);
                    ComboHelper.LlenarCombos<AsignarTipoCobranzaE>(cboTipoCobranza, ListaTipoCobranza, "idTipoPlanilla", "desTipoPlanilla");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private CobranzasE CurrentActual()
        {
            return (CobranzasE)bsCobranzas.Current;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPlanillaCobranza);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                Int32 Tipo = Convert.ToInt32(cboTipoCobranza.SelectedValue);
                oFrm = new frmPlanillaCobranza(TipoPlanilla, ListaTipoCobranza, Tipo)
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPlanillaCobranza);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmPlanillaCobranza(((CobranzasE)bsCobranzas.Current).idPlanilla, TipoPlanilla, ListaTipoCobranza)
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

        public override void Anular()
        {
            try
            {
                if (bsCobranzas.Current != null)
                {
                    if (!((CobranzasE)bsCobranzas.Current).EstadoDoc)
                    {
                        CobranzasE oCobranza = AgenteCtasCobrar.Proxy.ObtenerCobranzas(((CobranzasE)bsCobranzas.Current).idPlanilla, "N");

                        if (oCobranza != null)
                        {
                            if (oCobranza.VieneFact)
                            {
                                Global.MensajeFault("No se puede eliminar porque esta cobranza viene de Facturación, anule la Factura.");
                                return;
                            }
                        }

                        if (Global.MensajeConfirmacion("Desea eliminar el registro?") == DialogResult.Yes)
                        {
                            Int32 resp = AgenteCtasCobrar.Proxy.EliminarCobranzas((CobranzasE)bsCobranzas.Current);

                            if (resp > 0)
                            {
                                //List<CobranzasE> Lista = (List<CobranzasE>)bsCobranzas.List;
                                Buscar();
                                Global.MensajeFault("Registro Eliminado.");
                            }
                        } 
                    }
                    else
                    {
                        Global.MensajeFault("Primero tiene que volver a abrir la planilla.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                Int32 TipoPlanilla = Convert.ToInt32(cboTipoCobranza.SelectedValue);

                bsCobranzas.DataSource = oListCobranzatmp = AgenteCtasCobrar.Proxy.ListarCobranzas(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, TipoPlanilla, dtpInicio.Value.Date, dtpFinal.Value.Date);
                bsCobranzas.ResetBindings(false);
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
            frmPlanillaCobranza oFrm = sender as frmPlanillaCobranza;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoPlanillaCobranza_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());

            if (cboTipoCobranza.Items.Count > 0)
            {
                if (cboTipoCobranza.Items.Count == 1)
                {
                    cboTipoCobranza.Enabled = false;
                }
                else
                {
                    cboTipoCobranza.Enabled = true;
                }

                cboTipoCobranza_SelectionChangeCommitted(new Object(), new EventArgs());
                base.Grabar();
            }
            else
            {
                pnlCobranza.Enabled = false;
                pnlFechas.Enabled = false;
                pnlListado.Enabled = false;
                Global.MensajeFault("Este Usuario no tiene ninguna planilla de cobranza asignada.");
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }

            if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
            {
                dgvListado.Columns[0].Visible = false;
            }
        }

        private void cboTipoCobranza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
                {
                    if (!((AsignarTipoCobranzaE)cboTipoCobranza.SelectedItem).AbrirPlanilla)
                    {
                        tsmiAbrir.Enabled = false;
                    }
                    else
                    {
                        tsmiAbrir.Enabled = true;
                    }

                    if (!((AsignarTipoCobranzaE)cboTipoCobranza.SelectedItem).CerrarPlanilla)
                    {
                        tsmiCerrar.Enabled = false;
                    }
                    else
                    {
                        tsmiCerrar.Enabled = true;
                    }
                }
                else
                {
                    tsmiAbrir.Enabled = true;
                    tsmiCerrar.Enabled = true;
                }

                Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsCobranzas_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            lblRegistros.Text = "Registros " + bsCobranzas.List.Count.ToString();
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void tsmiCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsCobranzas.Current != null)
                {
                    CobranzasE current = CurrentActual();

                    if (!current.EstadoDoc)
                    {
                        String TipoPlanillaNemo = String.Empty;

                        if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                        {
                            TipoPlanillaNemo = ((ParTabla)cboTipoCobranza.SelectedItem).NemoTecnico;
                        }
                        else
                        {
                            AsignarTipoCobranzaE Permiso = (AsignarTipoCobranzaE)cboTipoCobranza.SelectedItem;

                            if (!Permiso.CerrarPlanilla)
                            {
                                Global.MensajeAdvertencia(String.Format("No tiene permiso para cerrar la PLANILLA {0}", Permiso.desTipoPlanilla));
                                return;
                            }

                            TipoPlanillaNemo = Permiso.NemoTecnico;
                        }

                        if (!String.IsNullOrEmpty(current.numVoucher))
                        {
                            VoucherE oVoucherExiste = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(current.idEmpresa, current.idLocal, current.AnioPeriodo, current.MesPeriodo, current.numVoucher, current.idComprobante, current.numFile);

                            if (oVoucherExiste != null)
                            {
                                Global.MensajeAdvertencia(String.Format("El Nro. de Voucher {0} {1}-{2} ya ha sido asignado a la Planilla {3}, limpie el número de voucher para poder generar uno nuevo.", oVoucherExiste.idComprobante, oVoucherExiste.numFile, oVoucherExiste.numVoucher, oVoucherExiste.numDocumentoPresu.Replace("SD", "").Trim()));
                                return;
                            }
                        }

                        String VoucherGenerado = AgenteCtasCobrar.Proxy.CerrarPlanillas(current.idPlanilla, current.idEmpresa, current.idLocal, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                        VariablesLocales.SesionUsuario.Credencial, TipoPlanillaNemo);
                        if (!String.IsNullOrWhiteSpace(VoucherGenerado.Trim()))
                        {
                            if (TipoPlanillaNemo == "PLALDES" || TipoPlanillaNemo == "PLACLT")
                            {
                                Global.MensajeComunicacion(VoucherGenerado);
                            }
                            else
                            {
                                if (String.IsNullOrWhiteSpace(current.numVoucher))
                                {
                                    Global.MensajeComunicacion(String.Format("Se generó el asiento {0}", VoucherGenerado));
                                }
                                else
                                {
                                    Global.MensajeComunicacion(String.Format("Se actualizó el asiento {0}", VoucherGenerado));
                                }
                            }
                            

                            Buscar();
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("La planilla ya se encuentra Cerrada.");
                    } 
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
                CobranzasE current = CurrentActual();

                if (current != null)
                {
                    if (current.EstadoDoc)
                    {
                        String TipoPlanillaNemo = String.Empty;
                        Boolean RevisionPlanillaCancelacion = false;

                        if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                        {
                            TipoPlanillaNemo = ((ParTabla)cboTipoCobranza.SelectedItem).NemoTecnico;
                        }
                        else
                        {
                            AsignarTipoCobranzaE Permiso = (AsignarTipoCobranzaE)cboTipoCobranza.SelectedItem;

                            if (!Permiso.AbrirPlanilla)
                            {
                                Global.MensajeAdvertencia(String.Format("No tiene permiso para abrir la PLANILLA {0}", Permiso.desTipoPlanilla));
                                return;
                            }

                            TipoPlanillaNemo = Permiso.NemoTecnico;
                        }

                        if (TipoPlanillaNemo == "PLALDES")
                        {
                            List<CobranzasItemDetE> ListaLetrasCobranzas = AgenteCtasCobrar.Proxy.ListarCobranzasLetrasPorPlanilla(current.idPlanilla);

                            if (ListaLetrasCobranzas != null && ListaLetrasCobranzas.Count > 0)
                            {
                                //Buscando el código del tipo de planilla de cancelación...
                                ParTabla tabla = AgenteGeneral.Proxy.ParTablaPorNemo("PLACALET");
                                RevisionPlanillaCancelacion = AgenteCtasCobrar.Proxy.RevisarPlanillaCancelacion(ListaLetrasCobranzas, current.idEmpresa, current.idLocal, tabla.IdParTabla);
                            }
                        }

                        if (!RevisionPlanillaCancelacion)
                        {
                            Int32 resp = AgenteCtasCobrar.Proxy.AbrirPlanilla(current, false, VariablesLocales.SesionUsuario.Credencial, TipoPlanillaNemo);

                            if (resp > 0)
                            {
                                Buscar();
                                Global.MensajeComunicacion("La planilla se abrió correctamente.");
                            }
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("La planilla ya se encuentra Abierta.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsCobranzas.Current != null)
                {
                    VoucherE oVoucher = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(((CobranzasE)bsCobranzas.Current).idEmpresa, VariablesLocales.SesionLocal.IdLocal,
                                                                                                    ((CobranzasE)bsCobranzas.Current).AnioPeriodo, ((CobranzasE)bsCobranzas.Current).MesPeriodo,
                                                                                                    ((CobranzasE)bsCobranzas.Current).numVoucher, ((CobranzasE)bsCobranzas.Current).idComprobante,
                                                                                                    ((CobranzasE)bsCobranzas.Current).numFile);
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

        private void tsmiLimpiarVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsCobranzas.Current != null)
                {
                    if (!((CobranzasE)bsCobranzas.Current).EstadoDoc)
                    {
                        Int32 resp = AgenteCtasCobrar.Proxy.LimpiarCobranzasVoucher(((CobranzasE)bsCobranzas.Current).idPlanilla, VariablesLocales.SesionUsuario.Credencial);

                        if (resp > 0)
                        {
                            Buscar();
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("Tiene que Abrir la Planilla antes de borrar el N° de Voucher.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (oListCobranzatmp != null && oListCobranzatmp.Count > Variables.Cero)
            {

                List<CobranzasE> res = (from x in oListCobranzatmp
                                        where x.numCheque.ToUpper().Contains(txtDescripcion.Text.ToUpper())
                                        select x).ToList();

                bsCobranzas.DataSource = res;

                lblRegistros.Text = "Registros " + bsCobranzas.Count.ToString();
            }
        }

        private void dgvListado_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListCobranzatmp != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                 
                    // POR FECHA 
                    if (e.ColumnIndex == dgvListado.Columns["Fecha"].Index)
                    {
                        if (Ordenar)
                        {
                            oListCobranzatmp = (from x in oListCobranzatmp orderby x.Fecha ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListCobranzatmp = (from x in oListCobranzatmp orderby x.Fecha descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR NUMCHEQUE
                    if (e.ColumnIndex == dgvListado.Columns["numCheque"].Index)
                    {
                        if (Ordenar)
                        {
                            oListCobranzatmp = (from x in oListCobranzatmp orderby x.numCheque ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListCobranzatmp = (from x in oListCobranzatmp orderby x.numCheque descending select x).ToList();
                            Ordenar = true;
                        }
                    }


                }

                bsCobranzas.DataSource = oListCobranzatmp;
            }
        }

        #endregion

        private void tsmiFusion_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 FilasSeleccionadas = dgvListado.Rows.GetRowCount(DataGridViewElementStates.Selected);

                if (FilasSeleccionadas > 1)
                {
                    List<CobranzasE> ListaCobranzas = new List<CobranzasE>();
                    StringBuilder CadMensaje = new StringBuilder();
                    CadMensaje.Append("Se van a combinar las planillas:\n\r");

                    foreach (DataGridViewRow Fila in dgvListado.Rows)
                    {
                        if (Fila.Selected)
                        {
                            CadMensaje.Append("   *** ").Append(((CobranzasE)Fila.DataBoundItem).codPlanilla).Append("\n\r");
                            ListaCobranzas.Add((CobranzasE)Fila.DataBoundItem);
                        }
                    }

                    if (Global.MensajeConfirmacion(CadMensaje.ToString()) == DialogResult.Yes)
                    {
                        Boolean resp = AgenteCtasCobrar.Proxy.CombinarPlanillas(ListaCobranzas, VariablesLocales.SesionUsuario.Credencial);

                        if (resp)
                        {
                            Buscar();
                            Global.MensajeComunicacion("Se combinaron las planillas.");
                        }
                    }
                }
                else
                {
                    Global.MensajeAdvertencia("Para combinar tiene que seleccionar al menos 2 filas.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiDocumentos_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }
    }
}
