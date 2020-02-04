using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;

namespace ClienteWinForm.Almacen
{
    public partial class frmListadoPuntosReque : FrmMantenimientoBase
    {
        public frmListadoPuntosReque()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvPuntos, true);
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPuntosReque);

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
                oFrm = new frmPuntosReque();
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
                List<RequerimientoPuntosE> ListaPuntos = AgenteAlmacen.Proxy.ListarRequerimientoPuntos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                bsPuntosReq.DataSource = ListaPuntos;
                bsPuntosReq.ResetBindings(false);

                base.Buscar();
                lblTitulo.Text = "Registros " + bsPuntosReq.Count.ToString();
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
                if (bsPuntosReq.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPuntosReque);

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

                    RequerimientoPuntosE oPunto = (RequerimientoPuntosE)bsPuntosReq.Current;
                    //sino existe la instancia se crea una nueva
                    oFrm = new frmPuntosReque(oPunto);
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
            //try
            //{
            //    if (bsCCostos.Count > Variables.Cero)
            //    {
            //        if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
            //        {
            //            AgenteMaestro.Proxy.AnularCCostos(((CCostosE)bsCCostos.Current).idEmpresa, ((CCostosE)bsCCostos.Current).idCCostos);
            //            Buscar();
            //            Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
            //            base.Anular();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeError(ex.Message);
            //}
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmPuntosReque oFrm = sender as frmPuntosReque;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoPuntosReque_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
        }

        private void dgvPuntos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        #endregion

    }
}
