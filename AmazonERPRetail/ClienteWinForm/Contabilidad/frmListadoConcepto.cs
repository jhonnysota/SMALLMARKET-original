using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Recursos;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoConcepto : FrmMantenimientoBase
    {
        
        public frmListadoConcepto()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvDocumentos, true);
            AnchoColumnas();
            
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<ConceptoGastoE> ListaConceptoGasto = null;

        #endregion

        #region ProcedimientosUsuario

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 74; //codigo 
            dgvDocumentos.Columns[1].Width = 250; //descripcion
            dgvDocumentos.Columns[2].Width = 90; //usuario reg 
            dgvDocumentos.Columns[3].Width = 126; //fecha reg 
            dgvDocumentos.Columns[4].Width = 90; //usuario mod
            dgvDocumentos.Columns[5].Width = 126; //fecha mod 
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmConcepto);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmConcepto();
                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();

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
                ListaConceptoGasto = AgenteContabilidad.Proxy.ListarConceptoGasto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                bsConceptoGasto.DataSource = ListaConceptoGasto;
                bsConceptoGasto.ResetBindings(false);

                base.Buscar();
                lblRegistros.Text = "Conceptos [ " + bsConceptoGasto.Count.ToString() + " Registros ]";
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
                if (bsConceptoGasto.Count > 0)
                {

                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmConcepto);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }


                    oFrm = new frmConcepto(((ConceptoGastoE)bsConceptoGasto.Current).idConcepto, ((ConceptoGastoE)bsConceptoGasto.Current).idEmpresa);
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
                if (bsConceptoGasto.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteContabilidad.Proxy.EliminarConceptoGasto(((ConceptoGastoE)bsConceptoGasto.Current).idConcepto, (((ConceptoGastoE)bsConceptoGasto.Current).idEmpresa));
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
            frmConcepto oFrm = sender as frmConcepto;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoConcepto_Load(object sender, EventArgs e)
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

        private void frmListadoConcepto_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        } 

        #endregion
    }
}
