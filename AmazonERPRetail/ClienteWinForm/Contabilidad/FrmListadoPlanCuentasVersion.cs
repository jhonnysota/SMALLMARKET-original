using Entidades.Contabilidad;
using Infraestructura;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad
{
    public partial class FrmListadoPlanCuentasVersion : FrmMantenimientoBase
    {

      public FrmListadoPlanCuentasVersion()
        {
            InitializeComponent();
            FormatoGrid(dgvPlanCuentas, true);
            
        }

      #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        #endregion

      #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmPlanCuentasVersion);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new FrmPlanCuentasVersion();
                oFrm.MdiParent = this.MdiParent;
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
                if (bsplanCuentasVersion.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmPlanCuentasVersion);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    PlanCuentasVersionE PVersion = (PlanCuentasVersionE)bsplanCuentasVersion.Current;

                    oFrm = new FrmPlanCuentasVersion(PVersion);
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
            if (bsplanCuentasVersion.Count > 0)
            {

            }
            //base.Anular();
        }

        public override void Buscar()
        {
            try
            {
                bsplanCuentasVersion.DataSource = AgenteContabilidad.Proxy.ListarPlanCuentasVersion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsplanCuentasVersion.ResetBindings(false);

                lblRegistros.Text = "Registros " + bsplanCuentasVersion.Count.ToString();
                //dgvDocumentos.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            base.Buscar();
        }

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            FrmPlanCuentasVersion oFrm = sender as FrmPlanCuentasVersion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion        

      #region Eventos

        private void FrmListadoPlanCuentasVersion_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();
        }

        private void FrmListadoPlanCuentasVersion_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        private void dgvPlanCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }           
             
        #endregion
        
    }
}
