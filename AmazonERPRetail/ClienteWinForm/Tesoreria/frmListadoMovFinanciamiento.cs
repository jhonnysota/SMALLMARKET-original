using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmListadoMovFinanciamiento : FrmMantenimientoBase
    {

        public frmListadoMovFinanciamiento()
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
        List<TipoLineaCreditoE> oListaLineaCred = null;
        List<FinanciamientoE> oListaBancos = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            oListaBancos = AgenteTesoreria.Proxy.ListarBancosFinanciamiento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            FinanciamientoE Item = new FinanciamientoE() { idBanco = Variables.Cero, desBanco = Variables.Todos };
            oListaBancos.Add(Item);
            ComboHelper.RellenarCombos<FinanciamientoE>(cboBancosEmpresa, (from x in oListaBancos orderby x.idBanco select x).ToList(), "idBanco", "desBanco");

            oListaLineaCred = AgenteTesoreria.Proxy.ListarTipoLineaCredito(false);
            TipoLineaCreditoE LineaIni = new TipoLineaCreditoE() { idLinea = 0, Descripcion = Variables.Todos };
            oListaLineaCred.Add(LineaIni);
            ComboHelper.RellenarCombos<TipoLineaCreditoE>(cboLineaCredito, (from x in oListaLineaCred orderby x.idLinea select x).ToList(), "idLinea", "Descripcion");

            Item = null;
            LineaIni = null;
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMovFinanciamiento);

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

                oFrm = new frmMovFinanciamiento(oListaLineaCred, bsMovimientos.List.Count > 0 ? ((List<MovimientoFinanciamientoE>)bsMovimientos.DataSource) : null)
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMovFinanciamiento);

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

                List<MovimientoFinanciamientoE> oListaTemp = new List<MovimientoFinanciamientoE>(((List<MovimientoFinanciamientoE>)bsMovimientos.DataSource));

                oFrm = new frmMovFinanciamiento(((MovimientoFinanciamientoE)bsMovimientos.Current).idMovimiento, oListaLineaCred, oListaTemp)
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

        public override void Buscar()
        {
            try
            {
                Int32 idBanco = Convert.ToInt32(cboBancosEmpresa.SelectedValue);
                Int32 idLinea = Convert.ToInt32(cboLineaCredito.SelectedValue);

                bsMovimientos.DataSource = AgenteTesoreria.Proxy.ListarMovimientoFinanciamiento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLinea, idBanco, dtpFecIni.Value, dtpFecFin.Value);
                bsMovimientos.ResetBindings(false);   
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
                Int32 resp = AgenteTesoreria.Proxy.EliminarMovimientoFinanciamiento(((MovimientoFinanciamientoE)bsMovimientos.Current).idMovimiento);

                if (resp > 0)
                {
                    Buscar();
                    Global.MensajeFault("Se eliminó correctamente");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarIngresoVentana()
        {
            if (oListaBancos.Count == 1)
            {
                Global.MensajeFault("No hay Entidades Financieras.");
                return false;
            }

            if (oListaLineaCred.Count == 1)
            {
                Global.MensajeFault("No hay Tipo de Linea de Crédito.");
                return false;
            }

            return base.ValidarIngresoVentana();
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmMovFinanciamiento oFrm = sender as frmMovFinanciamiento;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoMovFinanciamiento_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                dgvMovimiento.Columns[0].Visible = true;
            }
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

        #endregion

    }
}
