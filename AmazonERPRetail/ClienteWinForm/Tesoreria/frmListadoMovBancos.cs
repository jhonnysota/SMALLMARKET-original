using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Entidades.Generales;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;
using ClienteWinForm.Contabilidad.Reportes;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmListadoMovBancos : FrmMantenimientoBase
    {

        public frmListadoMovBancos()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvMovimiento, true);
            LlenarCombos();
        }

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<BancosE> oListaBancos = null;
        List<ParTabla> oListaTipos = null;

        //Para el check del datagridview
        Int32 TotalChecks = 0;
        Int32 TotalCheckeados = 0;
        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            oListaBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oListaBancos.Add(new BancosE() { idPersona = Variables.Cero, SiglaComercial = Variables.Todos });
            ComboHelper.RellenarCombos<BancosE>(cboBancosEmpresa, (from x in oListaBancos orderby x.idPersona select x).ToList(), "idPersona", "SiglaComercial");

            oListaTipos = new List<ParTabla>
            {
                new ParTabla() { IdParTabla = 0, Nombre = Variables.Todos },
                new ParTabla() { IdParTabla = 1, Nombre = "INGRESOS" },
                new ParTabla() { IdParTabla = 2, Nombre = "EGRESOS" },
                new ParTabla() { IdParTabla = 3, Nombre = "TRANSF. ENTRE CTAS." },
                new ParTabla() { IdParTabla = 4, Nombre = "TRANSF. VINCULADAS" }
            };

            ComboHelper.RellenarCombos<ParTabla>(cboTipoMov, oListaTipos, "IdParTabla", "Nombre");

            List<Empresa> oListaEmpresas = AgenteMaestro.Proxy.ListarEmpresa("");
            oListaEmpresas.Add(new Empresa() { IdEmpresa = 0, NombreComercial = Variables.Todos });
            ComboHelper.LlenarCombos<Empresa>(cboEmpresas, (from x in oListaEmpresas orderby x.IdEmpresa select x).ToList(), "IdEmpresa", "NombreComercial");

            oListaEmpresas = null;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (!ValidarIngresoVentana())
                {
                    return;
                }

                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMovBancos);

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

                oFrm = new frmMovBancos(oListaBancos, oListaTipos)
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                if (!ValidarIngresoVentana())
                {
                    return;
                }

                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMovBancos);

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

                if (bsMovimientos.Current != null)
                {
                    Boolean Bloq = false;

                    if (((MovimientoBancosE)bsMovimientos.Current).tipMovimiento == 1 && ((MovimientoBancosE)bsMovimientos.Current).idMoviTrans > 0)
                    {
                        Bloq = true;
                    }

                    oFrm = new frmMovBancos(oListaBancos, oListaTipos, ((MovimientoBancosE)bsMovimientos.Current).idMovBanco, ((MovimientoBancosE)bsMovimientos.Current).indEstado, Bloq)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show(); 
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
                Int32 idBanco = Convert.ToInt32(cboBancosEmpresa.SelectedValue);
                Int32 idTipoMov = Convert.ToInt32(cboTipoMov.SelectedValue);
                String Estado = "CR";

                if (rbProvisionada.Checked)
                {
                    Estado = "PR";
                }

                List<MovimientoBancosE> oListaMovimientos = AgenteTesoreria.Proxy.ListarMovimientoBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idBanco, idTipoMov, dtpFecIni.Value, dtpFecFin.Value, Estado, chkDevolucion.Checked);

                if (Convert.ToInt32(cboTipoMov.SelectedValue) == 1 || Convert.ToInt32(cboTipoMov.SelectedValue) == 4)
                {
                    if (Convert.ToInt32(cboEmpresas.SelectedValue) != 0)
                    {
                        oListaMovimientos = (from x in oListaMovimientos where x.idEmpresaTrans == Convert.ToInt32(cboEmpresas.SelectedValue) select x).ToList();
                    }
                }

                bsMovimientos.DataSource = oListaMovimientos;
                bsMovimientos.ResetBindings(false);

                //Inicializando el checkbox del datagridview
                CheckBoxCab.Checked = false;
                HeaderCheckBoxClick(CheckBoxCab);

                TotalChecks = bsMovimientos.Count;
                TotalCheckeados = 0;
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
                if (((MovimientoBancosE)bsMovimientos.Current).indEstado == "CR") //Creado
                {
                    if (((MovimientoBancosE)bsMovimientos.Current).tipMovimiento == 1)
                    {
                        if (((MovimientoBancosE)bsMovimientos.Current).idMoviTrans > 0)
                        {
                            Global.MensajeFault("El registro no puede ser anulado porque es un ingreso por transferencia, debe ir a la empresa correspondiente para porder eliminarla.");
                            return;
                        }
                    }

                    Int32 resp = AgenteTesoreria.Proxy.CambiarEstadoMovBancos((MovimientoBancosE)bsMovimientos.Current, "AN", VariablesLocales.SesionUsuario.Credencial);

                    if (resp > 0)
                    {
                        Buscar();
                        Global.MensajeFault("Registro Anulado");
                    } 
                }
                else if (((MovimientoBancosE)bsMovimientos.Current).indEstado == "AN") //Anulado
                {
                    if (Global.MensajeConfirmacion("Este registro ya ha sido anulado.\n\rDesea eliminar el Movimiento?") == DialogResult.Yes)
                    {
                        Int32 resp = AgenteTesoreria.Proxy.EliminarMovBancosDetPorId(((MovimientoBancosE)bsMovimientos.Current).idMovBanco);
                        resp = AgenteTesoreria.Proxy.EliminarMovimientoBancos(((MovimientoBancosE)bsMovimientos.Current).idMovBanco);

                        if (resp > 0)
                        {
                            Global.MensajeFault("Movimiento Eliminado...!!!");
                            Buscar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarIngresoVentana()
        {
            if (cboBancosEmpresa.Items.Count == 1)
            {
                Global.MensajeFault("No hay Entidades Financieras.");
                return false;
            }

            if (cboTipoMov.Items.Count == 1)
            {
                Global.MensajeFault("No hay Tipo de Movimientos.");
                return false;
            }

            return base.ValidarIngresoVentana();
        }

        #endregion

        #region Eventos y procedimientos checkBox

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            indClickCab = true;

            foreach (DataGridViewRow Row in dgvMovimiento.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["CampoCheck"]).Value = HCheckBox.Checked;
            }

            dgvMovimiento.RefreshEdit();
            TotalCheckeados = HCheckBox.Checked ? TotalChecks : 0;
            indClickCab = false;
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void AñadirCheckBox()
        {
            CheckBoxCab = new CheckBox();
            CheckBoxCab.Size = new Size(15, 15);

            // Añadiendo el CheckBox dentro de la cabecera del datagridview
            dgvMovimiento.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvMovimiento.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - CheckBoxCab.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - CheckBoxCab.Height) / 2 + 1;

            //Cambiar la ubicacion del checkbox para que se quede en la cabecera
            CheckBoxCab.Location = oPoint;
        }

        private void FilaCheBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                //Modificando el contador de los check
                if ((bool)RCheckBox.Value && TotalCheckeados < TotalChecks)
                {
                    TotalCheckeados++;
                }
                else if (TotalCheckeados > 0)
                {
                    TotalCheckeados--;
                }

                //Cambiar estado de la casilla de la cabecera si es que se llenan todas las filas o viceversa.
                if (TotalCheckeados < TotalChecks)
                {
                    CheckBoxCab.Checked = false;
                }
                else if (TotalCheckeados == TotalChecks)
                {
                    CheckBoxCab.Checked = true;
                }
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmMovBancos oFrm = sender as frmMovBancos;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoMovBancos_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                dgvMovimiento.Columns[1].Visible = true;
            }

            AñadirCheckBox();
            
            CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
        }

        private void bsMovimientos_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsMovimientos.List.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvMovimiento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsMovimientos.List.Count > 0)
            {
                Editar();
            }
        }

        private void tsmiGenerarVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                String Comprobante = Convert.ToInt32(((MovimientoBancosE)bsMovimientos.Current).tipMovimiento) == 1 ? "04" : "05";
                ComprobantesFileE numFile = AgenteContabilidad.Proxy.ObtenerFilePorCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Comprobante,
                                                                                        ((MovimientoBancosE)bsMovimientos.Current).idMoneda.ToString(),
                                                                                        ((MovimientoBancosE)bsMovimientos.Current).numVerPlanCuentas,
                                                                                        ((MovimientoBancosE)bsMovimientos.Current).codCuenta);
                if (numFile != null)
                {
                    MovimientoBancosE oMovBanco = AgenteTesoreria.Proxy.ObtenerMovimientoBancos(((MovimientoBancosE)bsMovimientos.Current).idMovBanco, false);

                    if (oMovBanco.indEstado == "PR")
                    {
                        Global.MensajeComunicacion("Este registro ya se ha provisionado.");
                        Buscar();
                        return;
                    }

                    if (oMovBanco.indEstado == "AN")
                    {
                        Global.MensajeComunicacion("Este registro se encuentra anulado, no se puede provisionar.");
                        Buscar();
                        return;
                    }

                    oMovBanco.AnioPeriodo = oMovBanco.fecMovimiento.ToString("yyyy");
                    oMovBanco.MesPeriodo = oMovBanco.fecMovimiento.ToString("MM");
                    oMovBanco.idComprobante = numFile.idComprobante;
                    oMovBanco.numFile = numFile.numFile;
                    oMovBanco.numVoucher = ((MovimientoBancosE)bsMovimientos.Current).numVoucher;

                    string devuelto = AgenteTesoreria.Proxy.GenerarProvisionMovBancos(oMovBanco, VariablesLocales.SesionLocal.IdLocal, VariablesLocales.SesionUsuario.Credencial);

                    Global.MensajeComunicacion(String.Format("Se genero el asiento contable {0}.", devuelto));
                    Buscar();
                }
                else
                {
                    Global.MensajeComunicacion("No existe ningún File asociado con la cuenta contable del banco.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiImprimeVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                VoucherE oVoucher = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(((MovimientoBancosE)bsMovimientos.Current).idEmpresa, VariablesLocales.SesionLocal.IdLocal,
                                                                                    ((MovimientoBancosE)bsMovimientos.Current).AnioPeriodo, ((MovimientoBancosE)bsMovimientos.Current).MesPeriodo,
                                                                                    ((MovimientoBancosE)bsMovimientos.Current).numVoucher, ((MovimientoBancosE)bsMovimientos.Current).idComprobante,
                                                                                    ((MovimientoBancosE)bsMovimientos.Current).numFile);
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
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiEliminarVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (((MovimientoBancosE)bsMovimientos.Current).tipMovimiento == 4)
                {
                    MovimientoBancosE oMovTrans = AgenteTesoreria.Proxy.ObtenerMovimientoBancos(((MovimientoBancosE)bsMovimientos.Current).idMoviTrans, false);

                    if (oMovTrans != null)
                    {
                        if (oMovTrans.indEstado == "PR")
                        {
                            Global.MensajeFault("El registro no puede eliminar el Voucher, porque el INGRESO asociado ya se encuentra provisionado, debe ir a la empresa transferida y eliminar su Voucher.");
                            return;
                        } 
                    }
                }

                MovimientoBancosE oMovimiento = Colecciones.CopiarEntidad<MovimientoBancosE>((MovimientoBancosE)bsMovimientos.Current);
                Int32 Resp = AgenteTesoreria.Proxy.EliminarVoucherMovBancos(oMovimiento, VariablesLocales.SesionLocal.IdLocal, VariablesLocales.SesionUsuario.Credencial);

                if (Resp > 0)
                {
                    bsMovimientos.RemoveCurrent();
                    Global.MensajeComunicacion("El Voucher fue eliminado");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void rbRegistrado_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvMovimiento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((String)dgvMovimiento.Rows[e.RowIndex].Cells["indEstado"].Value == "AN")
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

        private void bsMovimientos_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (bsMovimientos.Current != null)
                {
                    if (rbRegistrado.Checked)
                    {
                        tsmiGenerarVoucher.Enabled = true;
                        tsmiVoucherMasivos.Enabled = true;
                        tsmiImprimeVoucher.Enabled = false;
                        tsmiLimpiarVoucher.Enabled = true;
                        tsmiEliminarVoucher.Enabled = false;
                        tsmiEliminarMasivo.Enabled = false;
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
                    }
                    else
                    {
                        tsmiGenerarVoucher.Enabled = false;
                        tsmiVoucherMasivos.Enabled = false;
                        tsmiImprimeVoucher.Enabled = true;
                        tsmiLimpiarVoucher.Enabled = false;
                        tsmiEliminarVoucher.Enabled = true;
                        tsmiEliminarMasivo.Enabled = true;
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
                    }
                }
                else
                {
                    tsmiGenerarVoucher.Enabled = false;
                    tsmiVoucherMasivos.Enabled = false;
                    tsmiImprimeVoucher.Enabled = false;
                    tsmiLimpiarVoucher.Enabled = false;
                    tsmiEliminarVoucher.Enabled = false;
                    tsmiEliminarMasivo.Enabled = false;
                    BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiVoucherMasivos_Click(object sender, EventArgs e)
        {
            try
            {
                if (TotalCheckeados > Variables.Cero)
                {
                    bsMovimientos.EndEdit();
                    List<MovimientoBancosE> oListaMovimientos = new List<MovimientoBancosE>();

                    foreach (MovimientoBancosE item in bsMovimientos.List)
                    {
                        if (item.CampoCheck)
                        {
                            if (item.indEstado == "CR")
                            {
                                item.idComprobante = Convert.ToInt32(item.tipMovimiento) == 1 ? "04" : "05";
                                oListaMovimientos.Add(item);
                            }
                            else
                            {
                                if (item.indEstado == "AN")
                                {
                                    Global.MensajeComunicacion(String.Format("Este registro {0} se obviará porque se encuentra anulado.", item.codMovBanco));
                                }
                            }
                        }
                    }

                    if (oListaMovimientos.Count > Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion("Desea generar los vouchers...") == DialogResult.Yes)
                        {
                            string resp = AgenteTesoreria.Proxy.ProvisionesMasivasMovBancos(oListaMovimientos, VariablesLocales.SesionLocal.IdLocal, VariablesLocales.SesionUsuario.Credencial);

                            if (resp == "ok")
                            {
                                Buscar();
                                Global.MensajeComunicacion("Se generaron todos los vouchers...");
                            }
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("Tiene que seleccionar algún item antes de generar los vouchers.");
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Tiene que seleccionar algún item antes de generar los vouchers.");
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
                MovimientoBancosE oMoviTemp = AgenteTesoreria.Proxy.ObtenerMovimientoBancos(((MovimientoBancosE)bsMovimientos.Current).idMovBanco, false);

                if (String.IsNullOrWhiteSpace(oMoviTemp.numVoucher))
                {
                    if (oMoviTemp.indEstado == "PR")
                    {
                        Global.MensajeComunicacion("No se puede limpiar porque este registro ya se encuentra provisionado.");
                    }
                    else if (oMoviTemp.indEstado == "AN")
                    {
                        Global.MensajeComunicacion("No se puede limpiar porque este registro esta anulado.");
                    }
                    else
                    {
                        ((MovimientoBancosE)bsMovimientos.Current).AnioPeriodo = String.Empty;
                        ((MovimientoBancosE)bsMovimientos.Current).MesPeriodo = String.Empty;
                        ((MovimientoBancosE)bsMovimientos.Current).idComprobante = String.Empty;
                        ((MovimientoBancosE)bsMovimientos.Current).numFile = String.Empty;
                        ((MovimientoBancosE)bsMovimientos.Current).numVoucher = String.Empty;

                        AgenteTesoreria.Proxy.ActualizarMovBancosConta(((MovimientoBancosE)bsMovimientos.Current));
                    }

                    Buscar();
                }
                else
                {
                    Global.MensajeComunicacion("El N° de voucher ya ha sido borrado.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiEliminarMasivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (TotalCheckeados > Variables.Cero)
                {
                    List<MovimientoBancosE> oListaMovimientos = new List<MovimientoBancosE>();

                    foreach (MovimientoBancosE item in bsMovimientos.List)
                    {
                        if (item.CampoCheck)
                        {
                            oListaMovimientos.Add(item);
                        }
                    }

                    if (oListaMovimientos.Count > Variables.Cero)
                    {
                        Int32 resp = AgenteTesoreria.Proxy.EliminarVoucherMasivoMovBancos(oListaMovimientos, VariablesLocales.SesionLocal.IdLocal, VariablesLocales.SesionUsuario.Credencial);

                        if (resp > 0)
                        {
                            Buscar();
                            Global.MensajeComunicacion("Se eliminaron todos los vouchers...");
                        }
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Tiene que seleccionar algún item antes de eliminar.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvMovimiento_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dgvMovimiento_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMovimiento.Rows.Count != 0)
            {
                if (!indClickCab)
                {
                    FilaCheBoxClick((DataGridViewCheckBoxCell)dgvMovimiento[e.ColumnIndex, e.RowIndex]);
                }
            }
        }

        private void dgvMovimiento_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvMovimiento.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvMovimiento.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tsmiCtaCte_Click(object sender, EventArgs e)
        {
            try
            {
                //MovimientoBancosE oMovi = AgenteTesoreria.Proxy.ObtenerMovimientoBancos(((MovimientoBancosE)bsMovimientos.Current).idMovBanco);

                if (bsMovimientos.Current != null)
                {
                    Int32 resp = AgenteTesoreria.Proxy.ActualizarMovBancosCtaCte((MovimientoBancosE)bsMovimientos.Current, VariablesLocales.SesionUsuario.Credencial);

                    if (resp > 0)
                    {
                        Global.MensajeComunicacion("Cta.Cte. actualizada...!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipoMov_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoMov.SelectedValue) == 1 || Convert.ToInt32(cboTipoMov.SelectedValue) == 4)
            {
                cboEmpresas.Enabled = true;
            }
            else
            {
                cboEmpresas.SelectedValue = 0;
                cboEmpresas.Enabled = false;
            }

            Buscar();
        }

        private void cboBancosEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        private void cboEmpresas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        private void chkDevolucion_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        #endregion

    }
}
