using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad.Procesos
{
    public partial class frmProcesoAjusteDifCambio : FrmMantenimientoBase
    {

        public frmProcesoAjusteDifCambio()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvListaUsuario,true);
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        List<PlanCuentasDifCambioUsuarioE> oListaPlanCuentasAsignadas;
        PeriodosE oPeriodo;

        int idEmpresa;
        string ano;
        string mes;
        string plan;
        string UsuarioAsignado;
        string ProcesoActual;
        String Marquee = String.Empty;
        Int32 letra = 0;

        readonly BackgroundWorker _bw = new BackgroundWorker();

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            /////MES////
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            oDt.DefaultView.Sort = "MesId";
            cboMes.DataSource = oDt;
            cboMes.ValueMember = "MesId";
            cboMes.DisplayMember = "MesDes";
            cboMes.SelectedValue = "00"; // VariablesLocales.PeriodoContable.MesPeriodo;
        }

        void CargarDatos(string Credenciales)
        {
            string PlanCuenta = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
            int idEmpresa = VariablesLocales.SesionLocal.IdEmpresa;
            List<ComprobantesE> oListaComprobante = AgenteContabilidad.Proxy.ListarComprobantes(idEmpresa);
            oListaComprobante = oListaComprobante.Where(x => x.Descripcion.Contains("AJUSTE") == true).ToList();
            string idComprobante = oListaComprobante[0].idComprobante;

            List<ComprobantesFileE> ListaFiles = AgenteContabilidad.Proxy.ObtenerFilesPorIdComprobante(idEmpresa, idComprobante);
            oListaPlanCuentasAsignadas = AgenteContabilidad.Proxy.ObtenerPlanCuentasDifCambioUsuarioDolar(idEmpresa, PlanCuenta, Credenciales);

            for (int i = 0; i < oListaPlanCuentasAsignadas.Count; i++)
            {
                oListaPlanCuentasAsignadas[i].indSeleccionado = true;
                oListaPlanCuentasAsignadas[i].numFile = ListaFiles.Where(x => x.numFile == oListaPlanCuentasAsignadas[i].numFile).ToList()[0].Descripcion;
            }

            bsCuentasUsuario.DataSource = oListaPlanCuentasAsignadas;
            bsCuentasUsuario.ResetBindings(false);
        }

        Boolean validarMesPeriodo()
        {
            oPeriodo = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(idEmpresa, ano, cboMes.SelectedValue.ToString());

            if (oPeriodo != null && oPeriodo.TCCompra > 0 && oPeriodo.TCVenta > 0)
            {
                txtCompra.Text = oPeriodo.TCCompra.ToString();
                txtVenta.Text = oPeriodo.TCVenta.ToString();
                btEliminar.Enabled = true;
                return true;
            }
            else
            {
                Global.MensajeFault("El mes seleccionado no tiene configurado el TC Compra / Venta ");
                return false;
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string INCuenta = "";

                for (int i = 0; i < oListaPlanCuentasAsignadas.Count; i++)
                {

                    if (oListaPlanCuentasAsignadas[i].indSeleccionado)
                    {
                        INCuenta += oListaPlanCuentasAsignadas[i].codCuenta + (i < oListaPlanCuentasAsignadas.Count - 1 ? "," : "");
                    }
                }

                if (ProcesoActual == "E")
                {

                    AgenteContabilidad.Proxy.EliminarDiferenciaCambio(idEmpresa, ano, mes, INCuenta, plan, UsuarioAsignado);

                    AgenteContabilidad.Proxy.MayorizarMayor(idEmpresa,VariablesLocales.SesionLocal.IdLocal,mes,ano,mes,ano,VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas);

                }

                if (ProcesoActual == "P")
                {           

                    AgenteContabilidad.Proxy.ProcesoDiferenciaCambio(idEmpresa, ano, mes, INCuenta, plan, UsuarioAsignado);

                    AgenteContabilidad.Proxy.MayorizarMayor(idEmpresa, VariablesLocales.SesionLocal.IdLocal, mes, ano, mes, ano, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblprogress.Visible = false;
            _bw.CancelAsync();
            _bw.Dispose();
            Marquee = String.Empty;
            timer1.Enabled = false;
            Cursor = Cursors.Arrow;
            letra = 0;
            lblprogress.Text = String.Empty;

            if (ProcesoActual == "E")
            {

                Global.MensajeComunicacion("Se Elimino y Mayorizo con éxito");

                btProcesar.Enabled = true;
                btCancelar.Enabled = false;

            }

            if (ProcesoActual == "P")
            {
                Global.MensajeComunicacion("Se proceso con éxito");
                btCancelar.Enabled = false;
            }

        }

        #endregion

        #region Eventos

        private void frmPlanContableUsuario_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            ano = VariablesLocales.PeriodoContable.AnioPeriodo;
            List<Usuario> ListaTipoComprobante = AgenteSeguridad.Proxy.ListarUsuarioEmpresa(idEmpresa, "", "-1");
            ComboHelper.RellenarCombos<Usuario>(cboUsuario, ListaTipoComprobante, "Credencial", "NombreCompleto", false);

            LlenarCombo();
            cboUsuario.SelectedValue = VariablesLocales.SesionUsuario.Credencial;
            CargarDatos(VariablesLocales.SesionUsuario.Credencial);
            UsuarioAsignado = Convert.ToString(cboUsuario.SelectedValue);
        }

        private void cboUsuario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                UsuarioAsignado = Convert.ToString(cboUsuario.SelectedValue);
                CargarDatos(cboUsuario.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvListaUsuario.IsCurrentCellDirty)
            {
                dgvListaUsuario.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            if (validarMesPeriodo())
            {
                mes = cboMes.SelectedValue.ToString();
                plan = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                ProcesoActual = "P";

                //procesa
                pbProgress.Visible = true;
                lblprogress.Visible = true;
                _bw.RunWorkerAsync();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _bw.CancelAsync();
            Close();
        } 

        private void cboMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboMes.SelectedValue.ToString() != "0")
            {
                validarMesPeriodo();
            }
        }

        private void bsCuentasUsuario_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblRegistrosUsuario.Text = "Registros " + bsCuentasUsuario.List.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            _bw.CancelAsync();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListaUsuario.IsCurrentCellDirty)
            {
                dgvListaUsuario.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            if (validarMesPeriodo())
            {
                mes = cboMes.SelectedValue.ToString();
                plan = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                ProcesoActual = "E";
                btCancelar.Enabled = true;

                //procesa

                lblprogress.Visible = true;
                timer1.Enabled = true;
                Cursor = Cursors.WaitCursor;
                Marquee = "Eliminando y Mayorizando .....";
                pbProgress.Visible = true;


                pbProgress.Visible = true;
                lblprogress.Visible = true;
                _bw.RunWorkerAsync();
            }
        }

        private void btProcesar_Click(object sender, EventArgs e)
        {
            if (dgvListaUsuario.IsCurrentCellDirty)
            {
                dgvListaUsuario.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            if (validarMesPeriodo())
            {
                mes = cboMes.SelectedValue.ToString();
                plan = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                ProcesoActual = "P";
                btCancelar.Enabled = true;

                lblprogress.Visible = true;
                timer1.Enabled = true;
                Cursor = Cursors.WaitCursor;
                Marquee = "Generando Asientos y Mayorizando .....";
                pbProgress.Visible = true;

                //procesa
                pbProgress.Visible = true;
                lblprogress.Visible = true;
                _bw.RunWorkerAsync();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            letra += 1;

            if (letra == Marquee.Length)
            {
                lblprogress.Text = String.Empty;
                letra = 0;
            }
            else
            {
                lblprogress.Text += Marquee.Substring(letra - 1, 1);
            }
        }

        #endregion

    }
}
