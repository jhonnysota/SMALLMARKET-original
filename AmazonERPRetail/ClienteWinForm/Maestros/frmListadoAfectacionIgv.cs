using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoAfectacionIgv : FrmMantenimientoBase
    {

        public frmListadoAfectacionIgv()
        {
            InitializeComponent();
            FormatoGrid(dgvAfectacion, true);
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmAfectacionIgv);

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

                //sino existe la instancia se crea una nueva
                oFrm = new frmAfectacionIgv
                {
                    MdiParent = MdiParent
                };

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
                List<AfectacionIgvE> ListaCap = AgenteMaestro.Proxy.ListarAfectacionIgv(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsAfectacionIgv.DataSource = ListaCap;
                bsAfectacionIgv.ResetBindings(false);
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
                if (bsAfectacionIgv.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmAfectacionIgv);

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

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmAfectacionIgv((AfectacionIgvE)bsAfectacionIgv.Current)
                    {
                        MdiParent = this.MdiParent
                    };

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
                if (bsAfectacionIgv.Current is AfectacionIgvE current)
                {
                    if (!current.indEstado)
                    {
                        if (Global.MensajeConfirmacion("Desea dar de baja al registro") == DialogResult.Yes)
                        {
                            AgenteMaestro.Proxy.EliminarAfectacionIgv(current.idEmpresa, current.idAfectacion, true, VariablesLocales.SesionUsuario.Credencial);
                            Buscar();
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion("Desea volver Activar el registro") == DialogResult.Yes)
                        {
                            AgenteMaestro.Proxy.EliminarAfectacionIgv(current.idEmpresa, current.idAfectacion, false, VariablesLocales.SesionUsuario.Credencial);
                            Buscar();
                        }
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
            frmAfectacionIgv oFrm = sender as frmAfectacionIgv;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoAfectacionIgv_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            Buscar();
        }

        private void dgvCapellada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvAfectacion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvAfectacion.Rows[e.RowIndex].Cells["indEstado"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }
        }

        private void bsAfectacionIgv_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsAfectacionIgv.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
