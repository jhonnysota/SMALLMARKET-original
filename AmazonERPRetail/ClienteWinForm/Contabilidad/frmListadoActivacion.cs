using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using ClienteWinForm.Contabilidad.Reportes;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoActivacion : FrmMantenimientoBase
    {

        public frmListadoActivacion()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvActivacion , true);
            
        }

        #region Variables
  
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<ActivacionE> ListaActivacion = null;

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmActivacion);

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

                String Comprobante = String.Empty;
                String File = String.Empty;
                ActivacionE oActi = null;

                if (bsActivacion.List.Count > 1)
                {
                    oActi = (ActivacionE)bsActivacion.List[bsActivacion.List.Count - 1];

                    Comprobante = oActi.idComprobante;
                    File = oActi.numFile;
                }
                else if (bsActivacion.List.Count == 1)
                {
                    oActi = (ActivacionE)bsActivacion.List[0];

                    Comprobante = oActi.idComprobante;
                    File = oActi.numFile;
                }

                //sino existe la instancia se crea una nueva
                oFrm = new frmActivacion(Comprobante, File);
                oFrm.MdiParent = MdiParent;
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
                if (bsActivacion.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmActivacion);

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

                    String Comprobante = String.Empty;
                    String File = String.Empty;

                    if (bsActivacion.List.Count > 1)
                    {
                        ActivacionE oActi = (ActivacionE)bsActivacion.List[bsActivacion.Position == 0 ? 0 : bsActivacion.Position - 1];

                        Comprobante = oActi.idComprobante;
                        File = oActi.numFile;
                    }

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmActivacion(((ActivacionE)bsActivacion.Current).idActivacion, ((ActivacionE)bsActivacion.Current).idEmpresa, Comprobante, File);
                    oFrm.MdiParent = MdiParent;
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
                bsActivacion.DataSource = ListaActivacion = AgenteContabilidad.Proxy.ListarActivacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsActivacion.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmActivacion oFrm = sender as frmActivacion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoActivacion_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();

            if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
            {
                dgvActivacion.Columns[0].Visible = false;
            }
        }

        private void dgvActivacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void bsActivacion_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsActivacion.Count.ToString();
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
                if (bsActivacion.List.Count > 0)
                {
                    ActivacionE oActivacionVoucher = AgenteContabilidad.Proxy.GenerarVoucherCapitalizacion(((ActivacionE)bsActivacion.Current).idActivacion, ((ActivacionE)bsActivacion.Current).idEmpresa, VariablesLocales.SesionLocal.IdLocal, VariablesLocales.SesionUsuario.Credencial);

                    if (oActivacionVoucher != null)
                    {
                        Global.MensajeComunicacion(String.Format("Se generó el comprobante {0}-{1} {2}", oActivacionVoucher.idComprobante, oActivacionVoucher.numFile, oActivacionVoucher.numVoucher));
                        Buscar();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiVerVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(((ActivacionE)bsActivacion.Current).numVoucher) && !String.IsNullOrWhiteSpace(((ActivacionE)bsActivacion.Current).AnioPeriodo))
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

                    VoucherE VoucherRep = new VoucherE();
                    VoucherRep.AnioPeriodo = ((ActivacionE)bsActivacion.Current).AnioPeriodo;
                    VoucherRep.numVoucher = ((ActivacionE)bsActivacion.Current).numVoucher;
                    VoucherRep.idComprobante = ((ActivacionE)bsActivacion.Current).idComprobante;
                    VoucherRep.numFile = ((ActivacionE)bsActivacion.Current).numFile;
                    VoucherRep.MesPeriodo = ((ActivacionE)bsActivacion.Current).MesPeriodo;
                    VoucherRep.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    VoucherRep.idLocal = VariablesLocales.SesionLocal.IdLocal;

                    oFrm = new frmImpresionVoucher("N", VoucherRep);
                    oFrm.MdiParent = MdiParent;
                    oFrm.Show();
                }
                else
                {
                    Global.MensajeComunicacion("No se ha generado ningún comprobante para este registro.");
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
