using Entidades.Ventas;
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

namespace ClienteWinForm.Ventas
{
    public partial class FrmListadoCondicionTipo : FrmMantenimientoBase
    {

        public FrmListadoCondicionTipo()
        {            
            InitializeComponent();
            FormatoGrid(dgvDocumentos, true);
            
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCondicionTipo);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new FrmCondicionTipo();
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
                if (bsCondicionTipo.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCondicionTipo);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    CondicionTipoE numControlTmp = (CondicionTipoE)bsCondicionTipo.Current;

                    oFrm = new FrmCondicionTipo(numControlTmp);
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
                bsCondicionTipo.DataSource = AgenteVentas.Proxy.ListarCondicionTipo();
                bsCondicionTipo.ResetBindings(false);

                lblRegistros.Text = "Registros " + bsCondicionTipo.Count.ToString();
                //dgvDocumentos.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            base.Buscar();
        }

        #endregion        

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            FrmCondicionTipo oFrm = sender as FrmCondicionTipo;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #region Eventos

        private void FrmListadoCondicionTipo_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();
        }

        private void FrmListadoCondicionTipo_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        #endregion
        
    }
}
