using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Recursos;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoTipoTraslado : FrmMantenimientoBase
    {

        public frmListadoTipoTraslado()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            
            FormatoGrid(dgvDocumentos, true);
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<TipoTrasladoE> ListaTipoTraslado = null;

        #endregion

        #region ProcedimientosUsuario

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 64;
            dgvDocumentos.Columns[1].Width = 200;
            dgvDocumentos.Columns[2].Width = 90;
            dgvDocumentos.Columns[3].Width = 126;
            dgvDocumentos.Columns[4].Width = 90;
            dgvDocumentos.Columns[5].Width = 126;
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoTraslado);

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
                oFrm = new frmTipoTraslado
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
                bdTipoTraslado.DataSource = ListaTipoTraslado = AgenteVentas.Proxy.ListarTipoTraslado();
                bdTipoTraslado.ResetBindings(false);

                base.Buscar();
                LblTitulo.Text = "Registros " + bdTipoTraslado.Count.ToString();
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
                if (bdTipoTraslado.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoTraslado);

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
                    oFrm = new frmTipoTraslado(((TipoTrasladoE)bdTipoTraslado.Current).idTraslado)
                    {
                        MdiParent = MdiParent
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
                if (bdTipoTraslado.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.AnularTipoTraslado(((TipoTrasladoE)bdTipoTraslado.Current).idTraslado);
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
            frmTipoTraslado oFrm = sender as frmTipoTraslado;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoTipoTraslado_Load(object sender, EventArgs e)
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

        #endregion

    }
}
