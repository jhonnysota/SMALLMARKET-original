using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoEEFFItemHistorico : FrmMantenimientoBase
    {
        
        public frmListadoEEFFItemHistorico()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvDocumentos, true);
            LlenarCombos();
            
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<EEFFItemHistoricoE> ListaEEFFHistorico = null;

        #endregion


        void LlenarCombos()
        {
            /////EEFF////
            List<EEFFE> oListaEEFF = AgenteContabilidad.Proxy.ListarEEFF(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0, "", true);
            oListaEEFF.Add(new EEFFE { idEEFF = 0, desSeccion = "<SELECCIONE>" });
            ComboHelper.LlenarCombos<EEFFE>(cboEEFF, oListaEEFF.OrderBy(x => x.idEEFF).ToList(), "idEEFF", "desSeccion");

            //Cargando Años
            cboAnio.DataSource = FechasHelper.CargarAnios((VariablesLocales.FechaHoy.Year - 10), VariablesLocales.FechaHoy.Year);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";
            cboAnio.SelectedValue = VariablesLocales.PeriodoContable.AnioPeriodo;

        }

        #region Procedimiento Heredados

        //public override void Nuevo()
        //{
        //    try
        //    {
        //        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEEFFItemHistorico);

        //        if (oFrm != null)
        //        {
        //            if (oFrm.WindowState == FormWindowState.Minimized)
        //            {
        //                oFrm.WindowState = FormWindowState.Normal;
        //            }

        //            oFrm.BringToFront();
        //            return;
        //        }

        //        oFrm = new frmEEFFItemHistorico();
        //        oFrm.MdiParent = this.MdiParent;
        //        oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
        //        oFrm.Show();

        //    }
        //    catch (Exception ex)
        //    {
        //        Global.MensajeError(ex.Message);
        //    }
        //}

        public override void Buscar()
        {
            try
            {
                ListaEEFFHistorico = AgenteContabilidad.Proxy.ListarEEFFItemHistorico(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,Convert.ToInt32(cboEEFF.SelectedValue), Convert.ToString(cboAnio.SelectedValue));

                bsEEFFItemHistorico.DataSource = ListaEEFFHistorico;
                bsEEFFItemHistorico.ResetBindings(false);

                base.Buscar();
                lblRegistros.Text = " [ " + bsEEFFItemHistorico.Count.ToString() + " Registros ]";
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
                if (bsEEFFItemHistorico.Count > 0)
                {

                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEEFFItemHistorico);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    EEFFItemHistoricoE EEFFHISTORICO = (EEFFItemHistoricoE)bsEEFFItemHistorico.Current;

                    EEFFItemHistoricoE ItemExistente = null;

                    ItemExistente = AgenteContabilidad.Proxy.ObtenerEEFFItemHistorico(EEFFHISTORICO.idEmpresa, EEFFHISTORICO.idEEFF, EEFFHISTORICO.idEEFFItem, EEFFHISTORICO.AnioPeriodo);

                    if (ItemExistente != null)
                    {
                        EEFFHISTORICO = ItemExistente;
                    }

                    oFrm = new frmEEFFItemHistorico(EEFFHISTORICO);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
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
                if (bsEEFFItemHistorico.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteContabilidad.Proxy.EliminarEEFFItemHistorico(((EEFFItemHistoricoE)bsEEFFItemHistorico.Current).idEmpresa, ((EEFFItemHistoricoE)bsEEFFItemHistorico.Current).idEEFF, ((EEFFItemHistoricoE)bsEEFFItemHistorico.Current).idEEFFItem,((EEFFItemHistoricoE)bsEEFFItemHistorico.Current).AnioPeriodo);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                        base.Anular();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmEEFFItemHistorico oFrm = sender as frmEEFFItemHistorico;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoEEFFItemHistorico_Load(object sender, EventArgs e)
        {
            Grid = true;
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void frmListadoEEFFItemHistorico_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }


        #endregion

        private void dgvDocumentos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dgvDocumentos.Rows[e.RowIndex].Cells[2].Value.ToString() == "TOT" || dgvDocumentos.Rows[e.RowIndex].Cells[2].Value.ToString() == "TIT")
                    {

                        //e.CellStyle.Font = new Font(dgvListadoEEFF.Font, FontStyle.Bold);

                        if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                        {
                            dgvDocumentos.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = new Font(dgvDocumentos.Font, FontStyle.Bold);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }
    }
}
