using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Almacen
{
    public partial class frmListadoAprobarOrdenDeCompra : FrmMantenimientoBase
    {

        public frmListadoAprobarOrdenDeCompra()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvListadoOC, false);
            AnchoColumnas();
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        Int32 idPersona = Variables.Cero;
        List<OrdenCompraE> oListaOrdernCompra;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvListadoOC.Columns[0].Width = 30; //ID
            dgvListadoOC.Columns[1].Width = 80; //Nro Orden de compra
            dgvListadoOC.Columns[2].Width = 95; //Tipo
            dgvListadoOC.Columns[3].Width = 110; //Modalidad
            dgvListadoOC.Columns[4].Width = 80; //Tipo de Compra
            dgvListadoOC.Columns[5].Width = 70; //Fecha Emision
            dgvListadoOC.Columns[6].Width = 70; //Fecha Requerida
            dgvListadoOC.Columns[7].Width = 240; //Razon Social
            dgvListadoOC.Columns[8].Width = 80; //Estado
            dgvListadoOC.Columns[9].Width = 80; //Estado almacen
            dgvListadoOC.Columns[10].Width = 35; //Moneda
            dgvListadoOC.Columns[11].Width = 70; //Total
            dgvListadoOC.Columns[12].Width = 70; //Venta
            dgvListadoOC.Columns[13].Width = 70; //IGV
            dgvListadoOC.Columns[14].Width = 90; //Usuario Aprobaciónn
            dgvListadoOC.Columns[15].Width = 120; //Fecha de Aprobación
            dgvListadoOC.Columns[16].Width = 90; //Usuario Registro
            dgvListadoOC.Columns[17].Width = 120; //Fecha Registro
            dgvListadoOC.Columns[18].Width = 90; //Usuario Modificación
            dgvListadoOC.Columns[19].Width = 120; //Fecha Modificación

        }

        #endregion

        #region Procedimientos Heredados

        public override void Editar()
        {
            try
            {
                if (bsOrdenesCompras.Count > 0)
                {
                    Form oFrm = this.MdiChildren.FirstOrDefault(x => x is frmOrdenDeCompra);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmOrdenDeCompra((OrdenCompraE)bsOrdenesCompras.Current)
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

        public override void Buscar()
        {
            try
            {
                DateTime fecIni = dtpInicio.Value.Date;
                DateTime fecFin = dtpFinal.Value.Date;
                Int32 idProveedor = rbTodos.Checked ? Variables.Cero : idPersona;
                String Estado = String.Empty; 
                if (RPorAprobar.Checked == true)
                {
                    Estado = "PN";
                }

                if (RAprobados.Checked == true)
                {
                    Estado = "AP";
                }

                if (rbototal.Checked == true)
                {
                    Estado = "AT";
                }

                if (rbototal.Checked == true)
                {
                    Estado = "AN";
                }
                if (RAmbos.Checked == true)
                {
                    Estado = "";
                }

                oListaOrdernCompra = AgenteAlmacen.Proxy.ListarOrdenCompraActivos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idProveedor, fecIni, fecFin, "", Estado);

                bsOrdenesCompras.DataSource = oListaOrdernCompra;
                bsOrdenesCompras.ResetBindings(false);

                lblRegistros.Text = "Registros " + bsOrdenesCompras.Count.ToString();
                base.Buscar();
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
            frmOrdenDeCompra oFrm = sender as frmOrdenDeCompra;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoActivarOdenDeCompra_Load(object sender, EventArgs e)
        {
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
        }

        private void btProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaProveedor oFrm = new frmBusquedaProveedor();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProveedor != null)
                {
                    idPersona = oFrm.oProveedor.IdPersona;
                    txtRuc.Text = oFrm.oProveedor.RUC;
                    txtRazonSocial.Text = oFrm.oProveedor.RazonSocial;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvListadoOC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void activarOrdenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((OrdenCompraE)bsOrdenesCompras.Current != null)
            {
                OrdenCompraE EOrdenCompra = (OrdenCompraE)bsOrdenesCompras.Current;

                if (EOrdenCompra.tipEstado == "PN")
                {
                    if (Global.MensajeConfirmacion("¿Desea Aprobar El Orden De Compra?") == DialogResult.Yes)
                    {
                        EOrdenCompra = AgenteAlmacen.Proxy.ActivarOrdenCompraActivos(EOrdenCompra);
                        Global.MensajeComunicacion("Se Aprobo La Orden De Compra");
                        Buscar();
                    }
                }
            }
        }

        #endregion

    }
}
