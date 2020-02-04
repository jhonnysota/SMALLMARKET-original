using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Infraestructura;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Entidades.Contabilidad;
using Entidades.Maestros;
using ClienteWinForm.Almacen;
using Infraestructura.Recursos;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoEEFF : FrmMantenimientoBase
    {

        public frmListadoEEFF()
        {
            InitializeComponent();
            FormatoGrid(dgvListadoEEFF, true);
            
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<EEFFE> oLista = new List<EEFFE>();

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                oLista = AgenteContabilidad.Proxy.ListarEEFF(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0, "", false);

                if (oLista.Count > 0)
                {
                    base.Grabar();
                    BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
                    bsEEFF.DataSource = oLista;
                    bsEEFF.ResetBindings(false);

                    lblRegistros.Text = "Estados Financieros - " + bsEEFF.Count.ToString() + " Registros";
                }
                else
                {
                    Global.MensajeComunicacion("No hay registro");
                }

                base.Buscar();
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
                if (bsEEFF.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEEFF);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmEEFF(((EEFFE)bsEEFF.Current).idEmpresa, ((EEFFE)bsEEFF.Current).idEEFF);
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

        public override void Nuevo()
        {
            try
            {
                if (!ValidarIngresoVentana())
                {
                    return;
                }

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEEFF);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmEEFF();

                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
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
                if (bsEEFF.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        AgenteContabilidad.Proxy.EliminarDetalleEEFF(((EEFFE)bsEEFF.Current).idEmpresa, ((EEFFE)bsEEFF.Current).idEEFF);
                        oLista.RemoveAt(bsEEFF.Position);
                        bsEEFF.DataSource = oLista;
                        bsEEFF.ResetBindings(false);
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

        private void frmListadoEEFF_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            Buscar();
        }

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmEEFF oFrm = sender as frmEEFF;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void dgvListadoEEFF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        } 

        #endregion        

    }
}
