using Entidades.CtasPorPagar;
using Infraestructura;
using Infraestructura.Enumerados;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.CtasPorPagar
{
    public partial class frmListadoPlantillaCxp : FrmMantenimientoBase
    {
        #region Constructor

        public frmListadoPlantillaCxp()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvplantillacxp, true);
        }

        #endregion

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        Plantilla_ConceptoE PlantillaCxp = null;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvplantillacxp.Columns[0].Width = 40;  // id de Plantilla
            dgvplantillacxp.Columns[1].Width = 180; // Nombre de la Plantilla
            dgvplantillacxp.Columns[2].Width = 45;  // Codigo de Comprobante
            dgvplantillacxp.Columns[3].Width = 150; // Nombre de Comprobante
            dgvplantillacxp.Columns[4].Width = 45;  // Codigo de File
            dgvplantillacxp.Columns[5].Width = 150; // Nombre de File
            dgvplantillacxp.Columns[6].Width = 120; // Nombre de File

        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPlantillaCxp);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmPlantillaCxp();
                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            //base.Nuevo();
        }

        public override void Editar()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPlantillaCxp);

                if (bsplantillacxp.Count > Variables.Cero)
                {
                    if (oFrm != null)
                    {
                        oFrm.BringToFront();
                        return;
                    }

                    PlantillaCxp = (Plantilla_ConceptoE)bsplantillacxp.Current;

                    oFrm = new frmPlantillaCxp(PlantillaCxp.idEmpresa,PlantillaCxp.idPlantilla);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            //base.Editar();
        }

        public override void Buscar()
        {
            try
            {
                bsplantillacxp.DataSource = AgenteCtasPorPagar.Proxy.ListarPlantilla_Concepto(VariablesLocales.SesionLocal.IdEmpresa);

                lblRegistros.Text = "Plantillas [" + bsplantillacxp.Count.ToString() + " Registros ]";
                //dgvprovision.AutoResizeColumns();
                BloquearOpcion(EnumOpcionMenuBarra.Anular, true);

                //dgvprovision.AutoResizeColumns();
                base.Buscar();
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
            frmPlantillaCxp oFrm = sender as frmPlantillaCxp;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoPlantillaCxp_Load(object sender, EventArgs e)
        {
            Grid = true;
            AnchoColumnas();
        }

        private void frmListadoPlantillaCxp_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        private void dgvplantillaCxp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        #endregion

    }
}
