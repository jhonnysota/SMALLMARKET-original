using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
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
    public partial class frmListadoPlanCuentasSunat : FrmMantenimientoBase
    {
        
        public frmListadoPlanCuentasSunat()
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPlanCuentasSunat);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmPlanCuentasSunat();
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
                if (bsPlanCuentasSunat.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPlanCuentasSunat);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    PlanCuentasSunatE PlanCuentasSunat = (PlanCuentasSunatE)bsPlanCuentasSunat.Current;

                    if (PlanCuentasSunat != null)
                    {
                        oFrm = new frmPlanCuentasSunat(PlanCuentasSunat);
                        oFrm.MdiParent = this.MdiParent;
                        oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                        oFrm.Show();
                    }
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
                if (bsPlanCuentasSunat.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteContabilidad.Proxy.EliminarPlanCuentasSunat(((PlanCuentasSunatE)bsPlanCuentasSunat.Current).codCuentaSunat);
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

        public override void Buscar()
        {
            try
            {
                bsPlanCuentasSunat.DataSource = AgenteContabilidad.Proxy.ListarPlanCuentasSunat();
                bsPlanCuentasSunat.ResetBindings(false);

                lblRegistros.Text = "Plan Cuentas Sunat - " + bsPlanCuentasSunat.Count.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            base.Buscar();
        }

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmPlanCuentasSunat oFrm = sender as frmPlanCuentasSunat;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }


        #endregion

        private void frmListadoPlanCuentasSunat_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();
        }

        private void frmListadoPlanCuentasSunat_Activated(object sender, EventArgs e)
        {
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
        }

        private void dgvPlanCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }
    }
}
