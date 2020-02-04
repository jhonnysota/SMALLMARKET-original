using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Almacen
{
    public partial class frmListadoAprobarRequisicion : FrmMantenimientoBase
    {

        public frmListadoAprobarRequisicion()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvRequisiciones, true);
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<RequisicionE> ListaRequisiciones = null;

        #endregion

        #region Procedimientos Heredados

        public override void Editar()
        {
            try
            {
                if (bsRequisicion.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmRequisicion);

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

                    RequisicionE ERequisicion = (RequisicionE)bsRequisicion.Current;

                    if (ERequisicion != null)
                    {
                        ERequisicion.ListaRequisicionItem = AgenteAlmacen.Proxy.ListarRequisicionItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,ERequisicion.idRequisicion);
                        ERequisicion.ListaRequisionProveedor = AgenteAlmacen.Proxy.ListarRequisicionProveedor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, ERequisicion.idRequisicion);
                        String Requisicion = "NOEDITABLE";

                        oFrm = new frmRequisicion(ERequisicion, Requisicion)
                        {
                            MdiParent = MdiParent
                        };

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

        public override void Buscar()
        {
            try
            {
                DateTime fecIni = dtpInicio.Value.Date;
                DateTime fecFin = dtpFinal.Value.Date;
                String Estado = String.Empty;

                if (RPorAprobar.Checked)
                {
                    Estado = "PN";
                    
                }
                if (RAprobados.Checked)
                {
                    Estado = "AT";
                }
                if (RAprobados.Checked)
                {
                    Estado = "";
                }

                bsRequisicion.DataSource = ListaRequisiciones = AgenteAlmacen.Proxy.ListarRequisicionAprobacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, fecIni, fecFin, Estado);
                bsRequisicion.ResetBindings(false);

                base.Buscar();
                lblRegistros.Text = "Registros " + bsRequisicion.Count.ToString();
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
            frmRequisicion oFrm = sender as frmRequisicion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoAprobarRequisicion_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();
            base.Grabar();
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
        }

        private void dgvRequisiciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void Aprobar_Click(object sender, EventArgs e)
        {
            if ((RequisicionE)bsRequisicion.Current != null)
            {
                RequisicionE ERequisicion = (RequisicionE)bsRequisicion.Current;

                if (Global.MensajeConfirmacion("¿Desea Aprobar La Requisicion?") == DialogResult.Yes)
                {
                    ERequisicion = AgenteAlmacen.Proxy.ActivarRequisicion(ERequisicion);
                    Global.MensajeComunicacion("Se Aprobo La Requisicion");
                }

                Buscar();
            }
        }

        private void RPorAprobar_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void RAprobados_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void RAmbos_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        #endregion

    }
}
