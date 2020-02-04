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
    public partial class frmListadoComprasFile : FrmMantenimientoBase
    {
        public frmListadoComprasFile()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvDocumentos, true);
            
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<ComprasFileE> ListaComprasFile = null;

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmComprasFile);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmComprasFile();
                oFrm.MdiParent = MdiParent;
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
                ListaComprasFile = AgenteContabilidad.Proxy.ListarComprasFile(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                bsComprasFile.DataSource = ListaComprasFile;
                bsComprasFile.ResetBindings(false);

                base.Buscar();
                lblRegistros.Text = bsComprasFile.Count.ToString() + " Registros.";
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
                if (bsComprasFile.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmComprasFile);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmComprasFile((ComprasFileE)bsComprasFile.Current);
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

        public override void Anular()
        {
            try
            {
                if (bsComprasFile.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteContabilidad.Proxy.EliminarComprasFile(((ComprasFileE)bsComprasFile.Current).idCompraFile);
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

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmComprasFile oFrm = sender as frmComprasFile;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }


        #endregion

        #region Eventos

        private void frmListadoComprasFile_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void btObtener_Click(object sender, EventArgs e)
        {
            frmEmpresaComprasFile oFrm = new frmEmpresaComprasFile();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaFile != null && oFrm.oListaFile.Count > 0)
            {
                ListaComprasFile = new List<ComprasFileE>(oFrm.oListaFile);
                bsComprasFile.DataSource = ListaComprasFile;
                bsComprasFile.ResetBindings(false);
            }
        }

        #endregion

    }
}
