using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Ventas;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura.Winform;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmRenovarCtaCte : FrmMantenimientoBase
    {

        public frmRenovarCtaCte()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvCtaCte, false);
            LlenarCombos();
        }

        #region Variables

        CtasPorPagarServiceAgent AgenteCtaPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<ProvisionesE> oListaDocumentosCompras = null;
        List<EmisionDocumentoE> oListaDocumentoVentas = null;
        Boolean Limpiar = false;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Tipo = String.Empty;
        Int32 resp = 0;
        BindingSource oBs = new BindingSource();

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            List<Empresa> oListaEmpresas = new List<Empresa>(VariablesLocales.SesionUsuario.UsuarioEmpresas);

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                Empresa oItemE = new Empresa() { IdEmpresa = 0, RazonSocial = Variables.Todos };
                oListaEmpresas.Add(oItemE);
                oItemE = null;
            }
            
            ComboHelper.RellenarCombos<Empresa>(cbEmpresa, (from x in oListaEmpresas orderby x.IdEmpresa select x).ToList(), "IdEmpresa", "RazonSocial");
            oListaEmpresas = null;

            List<SistemasE> oListaSistemas = AgenteGeneral.Proxy.ListarSistemas();

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                SistemasE oItemS = new SistemasE() { idSistema = 0, descripcion = Variables.Todos };
                oListaSistemas.Add(oItemS);
                oItemS = null;
            }
            
            ComboHelper.RellenarCombos<SistemasE>(cboSistema, (from x in oListaSistemas
                                                               where x.idSistema == 0 || x.idSistema == 2 || x.idSistema == 5
                                                               orderby x.idSistema select x).ToList(), "idSistema", "descripcion");
            oListaSistemas = null;
        }

        void Formato()
        {
            if (oListaDocumentosCompras != null && Convert.ToInt32(cboSistema.SelectedValue) == 5)//Compras
            {
                dgvCtaCte.Columns[0].Visible = false;
                dgvCtaCte.Columns[1].Visible = false;
                dgvCtaCte.Columns[7].Visible = false;
                dgvCtaCte.Columns[10].Visible = false;
                dgvCtaCte.Columns[11].Visible = false;
                dgvCtaCte.Columns[12].Visible = false;
                dgvCtaCte.Columns[13].Visible = false;
                dgvCtaCte.Columns[14].Visible = false;
                dgvCtaCte.Columns[16].Visible = false;
                dgvCtaCte.Columns[17].Visible = false;
                dgvCtaCte.Columns[18].Visible = false;
                dgvCtaCte.Columns[19].Visible = false;
                dgvCtaCte.Columns[20].Visible = false;
                dgvCtaCte.Columns[21].Visible = false;
                dgvCtaCte.Columns[22].Visible = false;

                dgvCtaCte.Columns[2].HeaderText = "Razón Social";
                dgvCtaCte.Columns[3].HeaderText = "TD";
                dgvCtaCte.Columns[4].HeaderText = "Serie";
                dgvCtaCte.Columns[5].HeaderText = "Número";
                dgvCtaCte.Columns[6].HeaderText = "Fecha";
                dgvCtaCte.Columns[8].HeaderText = "Mon.";
                dgvCtaCte.Columns[9].HeaderText = "Importe";
                dgvCtaCte.Columns[15].HeaderText = "Glosa";

                dgvCtaCte.Columns[2].Width = 300;
                dgvCtaCte.Columns[3].Width = 30;
                dgvCtaCte.Columns[4].Width = 45;
                dgvCtaCte.Columns[5].Width = 75;
                dgvCtaCte.Columns[6].Width = 70;
                dgvCtaCte.Columns[8].Width = 40;
                dgvCtaCte.Columns[9].Width = 80;
                dgvCtaCte.Columns[15].Width = 200;

                dgvCtaCte.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (oListaDocumentoVentas != null && Convert.ToInt32(cboSistema.SelectedValue) == 2)//Ventas
            {

            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DateTime Inicio = dtpFecIni.Value.Date;
                DateTime Fin = dtpFecFin.Value.Date;

                if (Tipo == "L")
                {
                    oListaDocumentosCompras = new List<ProvisionesE>();
                    oListaDocumentoVentas = new List<EmisionDocumentoE>();
                    resp = AgenteTesoreria.Proxy.EliminarCtaCteMasivo(Convert.ToInt32(cbEmpresa.SelectedValue), Convert.ToInt32(cboSistema.SelectedValue), Inicio, Fin);
                }
                else if (Tipo == "O")
                {
                    if (Convert.ToInt32(cboSistema.SelectedValue) == 5)
                    {
                        oListaDocumentosCompras = AgenteCtaPorPagar.Proxy.ListarProvisionesCtaCte(Convert.ToInt32(cbEmpresa.SelectedValue), Inicio, Fin);
                    }
                    else
                    {
                        oListaDocumentoVentas = new List<EmisionDocumentoE>();
                    }
                }
                else if(Tipo == "E")
                {
                    if (Convert.ToInt32(cboSistema.SelectedValue) == 5)
                    {
                        resp = AgenteTesoreria.Proxy.TransferirCtaCte(oListaDocumentosCompras, null, Convert.ToInt32(cboSistema.SelectedValue), VariablesLocales.SesionUsuario.Credencial);
                    }
                    else
                    {
                        resp = AgenteTesoreria.Proxy.TransferirCtaCte(null, oListaDocumentoVentas, Convert.ToInt32(cboSistema.SelectedValue), VariablesLocales.SesionUsuario.Credencial);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            dgvCtaCte.Cursor = Cursors.Arrow;
            pbProgress.Visible = false;
            pnlOpciones.Enabled = true;

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else if (e.Cancelled == true)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            else
            {
                if (Tipo == "L")
                {
                    if (resp > 0)
                    {
                        dgvCtaCte.DataSource = oBs.DataSource = null;
                        Global.MensajeComunicacion("Se ha limpiado la CtaCte correctamente.");
                    }
                }
                else if (Tipo == "O")
                {
                    if (oListaDocumentosCompras != null  && oListaDocumentosCompras.Count > 0)
                    {
                        var oLista = (from x in oListaDocumentosCompras
                                      select new
                                      {
                                          x.idEmpresa,
                                          x.idPersona,
                                          x.RazonSocial,
                                          x.idDocumento,
                                          x.NumSerie,
                                          x.NumDocumento,
                                          x.FechaDocumento,
                                          x.CodMonedaProvision,
                                          x.desMoneda,
                                          x.ImpMonedaOrigen,
                                          x.TipCambio,
                                          x.FechaVencimiento,
                                          x.NumVerPlanCuentas,
                                          x.codCuenta,
                                          x.DesCuenta,
                                          x.DesProvision,
                                          x.flagDetraccion,
                                          x.retNumero,
                                          x.retFecha,
                                          x.TipoDetraccion,
                                          x.TasaDetraccion,
                                          x.MontoDetraccion,
                                          x.indPagoDetra
                                      });

                        dgvCtaCte.DataSource = oBs.DataSource = (from x in oLista.ToList() orderby x.idEmpresa, x.FechaDocumento select x).ToList();
                        Formato();

                        Global.MensajeComunicacion("Se ha obtenido las compras.");
                    }

                    if (oListaDocumentoVentas != null && oListaDocumentoVentas.Count > 0)
                    {
                        Global.MensajeComunicacion("Se ha obtenido las ventas.");
                    }
                }
                else if (Tipo == "E")
                {
                    if (resp > 0)
                    {
                        Limpiar = false;
                        oListaDocumentosCompras = null;
                        oListaDocumentoVentas = null;
                        dgvCtaCte.DataSource = oBs.DataSource = null;

                        Global.MensajeComunicacion("Se ha transferido correctamente la Cta.Cte.");
                    }
                }
            }

            _bw.CancelAsync();
            _bw.Dispose();
        }

        private void oBs_ListChanged(object sender, ListChangedEventArgs e)
        {
            lblRegistros.Text = String.Format("Registros {0}", oBs.List.Count);
        }

        #endregion

        #region Eventos

        private void frmRenovarCtaCte_Load(object sender, EventArgs e)
        {
            Grid = true;
            //BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            cbEmpresa.SelectedValue = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
            //Habilitando los eventos para trabajar en segundo plano...
            CheckForIllegalCrossThreadCalls = false;

            oBs.ListChanged += new ListChangedEventHandler(oBs_ListChanged);
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar = true;
                Tipo = "L";
                dgvCtaCte.DataSource = oBs.DataSource = null;
                Cursor = Cursors.WaitCursor;
                pbProgress.Visible = true;
                pnlOpciones.Enabled = false;
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btObtener_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboSistema.SelectedValue) == 0)
                {
                    Global.MensajeComunicacion("Debe escoger un Sistemas");
                    cboSistema.Focus();
                    return;
                }

                Tipo = "O";
                lblRegistros.Text = "Registros 0";
                Cursor = Cursors.WaitCursor;
                pbProgress.Visible = true;
                pnlOpciones.Enabled = false;

                if (Convert.ToInt32(cboSistema.SelectedValue) == 5)
                {
                    oListaDocumentoVentas = null;
                    oListaDocumentosCompras = new List<ProvisionesE>();

                    var oLista = (from x in oListaDocumentosCompras
                                  select new
                                  {
                                      x.idEmpresa,
                                      x.idPersona,
                                      x.RazonSocial,
                                      x.idDocumento,
                                      x.NumSerie,
                                      x.NumDocumento,
                                      x.FechaDocumento,
                                      x.CodMonedaProvision,
                                      x.desMoneda,
                                      x.ImpMonedaOrigen,
                                      x.TipCambio,
                                      x.FechaVencimiento,
                                      x.NumVerPlanCuentas,
                                      x.codCuenta,
                                      x.DesCuenta,
                                      x.DesProvision,
                                      x.flagDetraccion,
                                      x.retNumero,
                                      x.retFecha,
                                      x.TipoDetraccion,
                                      x.TasaDetraccion,
                                      x.MontoDetraccion,
                                      x.indPagoDetra
                                  });

                    dgvCtaCte.DataSource = oBs.DataSource = (from x in oLista.ToList() orderby x.idEmpresa, x.FechaDocumento select x).ToList();
                }
                else
                {
                    oListaDocumentoVentas = new List<EmisionDocumentoE>();
                    oListaDocumentosCompras = null;
                }

                Formato();

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Limpiar)
                {
                    Global.MensajeComunicacion("Debe Limpiar la Cta.Cte. antes de insertar");
                    return;
                }

                if (Convert.ToInt32(cboSistema.SelectedValue) == 2)
                {
                    if (oListaDocumentoVentas == null || oListaDocumentoVentas.Count == 0)
                    {
                        Global.MensajeComunicacion("Debe obtener los datos Ventas antes de hacer los Ingresos a la Cta.Cte.");
                        return;
                    }
                }

                if (Convert.ToInt32(cboSistema.SelectedValue) == 5)
                {
                    if (oListaDocumentosCompras == null || oListaDocumentosCompras.Count == 0)
                    {
                        Global.MensajeComunicacion("Debe obtener los datos de Compras antes de hacer los Ingresos a la Cta.Cte.");
                        return;
                    }
                }

                Tipo = "E";
                Cursor = Cursors.WaitCursor;
                pbProgress.Visible = true;
                pnlOpciones.Enabled = false;

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

    }
}
