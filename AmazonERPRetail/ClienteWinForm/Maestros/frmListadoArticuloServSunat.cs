using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Recursos;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoArticuloServSunat : FrmMantenimientoBase
    {

        public frmListadoArticuloServSunat()
        {
            InitializeComponent();
            FormatoGrid(dgvArticuloServSunat, true);
            
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmArticuloServSunat);

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
                oFrm = new frmArticuloServSunat
                {
                    MdiParent = this.MdiParent
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
                List<ArticuloServSunatE> ListaArtSrvSunat = AgenteMaestro.Proxy.ListarArticuloServSunat(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsArticuloServSunat.DataSource = ListaArtSrvSunat;
                bsArticuloServSunat.ResetBindings(false);
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
                if (bsArticuloServSunat.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmArticuloServSunat);

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
                    oFrm = new frmArticuloServSunat((ArticuloServSunatE)bsArticuloServSunat.Current)
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
                if (bsArticuloServSunat.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminacion) == DialogResult.Yes)
                    {
                        AgenteMaestro.Proxy.EliminarArticuloServSunat(((ArticuloServSunatE)bsArticuloServSunat.Current).idEmpresa, ((ArticuloServSunatE)bsArticuloServSunat.Current).CodigoSunat);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
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
            frmArticuloServSunat oFrm = sender as frmArticuloServSunat;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoArticuloServSunat_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            Buscar();
        }

        private void dgvArticuloServSunat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    Editar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsArticuloServSunat_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblTitulo.Text = "Registros " + bsArticuloServSunat.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
