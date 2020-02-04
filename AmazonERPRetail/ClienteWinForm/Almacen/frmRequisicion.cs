using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Almacen
{
    public partial class frmRequisicion : FrmMantenimientoBase
    {

        #region Constructores

        public frmRequisicion()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvItem, true);
            FormatoGrid(dgvProveedor, true);
            LlenarCombos();
        }

        //Nuevo
        public frmRequisicion(Int32 Local_)
           : this()
        {
            Local = Local_;
        }

        //Edición
        public frmRequisicion(RequisicionE oRequisicionTmp)
            : this()
        {
            oRequisicion = oRequisicionTmp;
        }

        public frmRequisicion(RequisicionE oRequisicionTmp, String Requisicion_)
            : this()
        {
            oRequisicion = oRequisicionTmp;
            Requisicion = Requisicion_;
        }

        #endregion

        #region Variables

        Int32 Local = 0;
        String Requisicion = String.Empty;
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        RequisicionE oRequisicion = null;
        List<RequisicionItemE> oListaEliminados = null;
        List<RequisicionProveedorE> oListaEliminados2 = null;
        Int32 Opcion = Variables.Cero;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oRequisicion.numRequisicion = txtNumRequisicion.Text;
            oRequisicion.tipRequisicion = Convert.ToInt32(cboTipoRequisicion.SelectedValue);
            oRequisicion.tipCompra = Convert.ToString(cboTipoCompra.SelectedValue);
            oRequisicion.FechaRequerida = dtpRequerida.Value.Date;
            oRequisicion.FechaSolicitud = dtpSolicitud.Value.Date;
            oRequisicion.idCCostos =txtIdCosto.Text;
            oRequisicion.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
            oRequisicion.impCostoEstimado = Convert.ToDecimal(txtEstimado.Text);
            oRequisicion.Justificacion = txtJustificacion.Text;
            oRequisicion.Observacion = txtAbreviacion.Text;
            oRequisicion.idAlmacenEntrega = Convert.ToInt32(cboAlmacen.SelectedValue);
            oRequisicion.idLocalAtencion = Convert.ToInt32(cboLocalAtencion.SelectedValue);
            oRequisicion.tipEstado = "PN";           
            oRequisicion.tipEstadoAtencion = "NA";
            oRequisicion.numLicitacion = "";
            oRequisicion.indLicitacion = "";
        }

        void LlenarCombos()
        {
            //////Moneda///////
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);


            List<ParTabla> ListaTipo = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ListaTipo.Add(new ParTabla { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoRequisicion, (from x in ListaTipo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);

            cboTipoCompra.DataSource = Global.CargarTipoCompra();
            cboTipoCompra.ValueMember = "id";
            cboTipoCompra.DisplayMember = "Nombre";

            ///Locales////
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboLocal, listaLocales, "idLocal", "Nombre", false);


            ///Locales2////
            List<LocalE> listaLocales2 = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                          where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                          select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboLocalAtencion, listaLocales2, "idLocal", "Nombre", false);

        }

        void EditarDetalle(DataGridViewCellEventArgs e, RequisicionItemE oReqItem)
        {
            try
            {
                if (bsRequisicionItem.Count > 0)
                {
                    frmRequisicionItem oFrm = new frmRequisicionItem(oReqItem, oRequisicion.tipRequisicion);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oRequisicion.ListaRequisicionItem[e.RowIndex] = oFrm.HojaReqItem;
                        bsRequisicionItem.DataSource = oRequisicion.ListaRequisicionItem;
                        bsRequisicionItem.ResetBindings(false);
                        base.AgregarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, RequisicionProveedorE oReqPro)
        {
            try
            {
                if (bsRequisicionProveedor.Count > 0)
                {
                    frmRequisicionProveedor oFrm = new frmRequisicionProveedor(oReqPro);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oRequisicion.ListaRequisionProveedor[e.RowIndex] = oFrm.HojaReqPro;
                        bsRequisicionProveedor.DataSource = oRequisicion.ListaRequisionProveedor;
                        bsRequisicionProveedor.ResetBindings(false);
                        base.AgregarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oRequisicion == null)
            {
                oRequisicion = new RequisicionE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = Local,
                    FechaRegistro = VariablesLocales.FechaHoy,
                    FechaModificacion = VariablesLocales.FechaHoy,
                    tipEstadoOC = "PN"
                };

                cboLocal.SelectedValue = Local;
                txtUsuarioRegistro.Text = oRequisicion.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = oRequisicion.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oRequisicion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = oRequisicion.FechaModificacion.ToString();
                cboAlmacen.Enabled = false;

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtNumRequisicion.Text = oRequisicion.numRequisicion;
                cboLocalAtencion.SelectedValue = oRequisicion.idLocalAtencion;
                cboTipoRequisicion.SelectedValue = oRequisicion.tipRequisicion;
                cboTipoCompra.SelectedValue = oRequisicion.tipCompra;
                dtpRequerida.Value = Convert.ToDateTime(oRequisicion.FechaRequerida);
                dtpSolicitud.Value = Convert.ToDateTime(oRequisicion.FechaSolicitud);
                txtIdCosto.Text = Convert.ToString(oRequisicion.idCCostos);
                txtCosto.Text = Convert.ToString(oRequisicion.desCCostos);
                cboMoneda.SelectedValue = oRequisicion.idMoneda;
                txtEstimado.Text = Convert.ToString(oRequisicion.impCostoEstimado);
                txtJustificacion.Text = oRequisicion.Justificacion;
                txtAbreviacion.Text = oRequisicion.Observacion;

                if (oRequisicion.idAlmacenEntrega != 0)
                {
                    cboTipoRequisicion_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboAlmacen.SelectedValue = oRequisicion.idAlmacenEntrega;
                }
                else
                {
                    cboTipoRequisicion_SelectionChangeCommitted(new Object(), new EventArgs());
                }

                txtUsuarioRegistro.Text = oRequisicion.UsuarioRegistro;
                txtFechaRegistro.Text = oRequisicion.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oRequisicion.UsuarioModificacion;
                txtFechaModificacion.Text = oRequisicion.FechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsRequisicionItem.DataSource = oRequisicion.ListaRequisicionItem;
            bsRequisicionItem.ResetBindings(false);

            bsRequisicionProveedor.DataSource = oRequisicion.ListaRequisionProveedor;
            bsRequisicionProveedor.ResetBindings(false);

            if (Requisicion == "NOEDITABLE" || oRequisicion.tipEstado == "AT")
            {
                panel1.Enabled = false;

                BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
                BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
                //BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
            else
            {
                base.Nuevo();
            }
        }

        public override void Grabar()
        {
            try
            {
                if (oRequisicion != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oRequisicion = AgenteAlmacen.Proxy.GrabarRequisicion(oRequisicion, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            if (oListaEliminados != null && oListaEliminados.Count > Variables.Cero)
                            {
                                foreach (RequisicionItemE item in oListaEliminados)
                                {
                                    oRequisicion.ListaRequisicionItem.Add(item);
                                }
                            }

                            if (oListaEliminados2 != null && oListaEliminados2.Count > Variables.Cero)
                            {
                                foreach (RequisicionProveedorE item in oListaEliminados2)
                                {
                                    oRequisicion.ListaRequisionProveedor.Add(item);
                                }
                            }

                            oRequisicion = AgenteAlmacen.Proxy.GrabarRequisicion(oRequisicion, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                            oListaEliminados = null;
                            oListaEliminados2 = null;
                        }
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<RequisicionE>(oRequisicion);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            try
            {
                if (tabControl1.SelectedTab == Item)
                {
                    if (oRequisicion.ListaRequisicionItem == null)
                    {
                        oRequisicion.ListaRequisicionItem = new List<RequisicionItemE>();
                    }

                    oRequisicion.tipRequisicion = Convert.ToInt32(cboTipoRequisicion.SelectedValue);

                    frmRequisicionItem oFrm = new frmRequisicionItem(oRequisicion.tipRequisicion);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        RequisicionItemE oReqItem = oFrm.HojaReqItem;
                        txtEstimado.Text = Convert.ToString(oReqItem.MontoTotal);
                        oRequisicion.ListaRequisicionItem.Add(oReqItem);
                        bsRequisicionItem.DataSource = oRequisicion.ListaRequisicionItem;
                        bsRequisicionItem.ResetBindings(false);
                        base.AgregarDetalle();
                    }

                }

                if (tabControl1.SelectedTab == Pro)
                {
                    if (oRequisicion.ListaRequisionProveedor == null)
                    {
                        oRequisicion.ListaRequisionProveedor = new List<RequisicionProveedorE>();
                    }

                    frmRequisicionProveedor oFrm = new frmRequisicionProveedor();

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        RequisicionProveedorE oReqPro = oFrm.HojaReqPro;
                        oRequisicion.ListaRequisionProveedor.Add(oReqPro);
                        bsRequisicionProveedor.DataSource = oRequisicion.ListaRequisionProveedor;
                        bsRequisicionProveedor.ResetBindings(false);
                        base.AgregarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (tabControl1.SelectedTab == Item)
                {
                    if (bsRequisicionItem.Current != null)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                        {
                            base.QuitarDetalle();

                            if (oListaEliminados == null)
                            {
                                oListaEliminados = new List<RequisicionItemE>();
                            }

                            oListaEliminados.Add((RequisicionItemE)bsRequisicionItem.Current);

                            foreach (RequisicionItemE item in oListaEliminados)
                            {
                                item.Opcion = (Int32)EnumOpcionGrabar.Eliminar;
                            }

                            oRequisicion.ListaRequisicionItem.RemoveAt(bsRequisicionItem.Position);

                            bsRequisicionItem.DataSource = oRequisicion.ListaRequisicionItem;
                            bsRequisicionItem.ResetBindings(false);
                        }
                    }
                }

                if (tabControl1.SelectedTab == Pro)
                {
                    if (bsRequisicionProveedor.Current != null)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                        {
                            base.QuitarDetalle();

                            if (oListaEliminados2 == null)
                            {
                                oListaEliminados2 = new List<RequisicionProveedorE>();
                            }

                            oListaEliminados2.Add((RequisicionProveedorE)bsRequisicionProveedor.Current);

                            foreach (RequisicionProveedorE item in oListaEliminados2)
                            {
                                item.Opcion = (Int32)EnumOpcionGrabar.Eliminar;
                            }

                            oRequisicion.ListaRequisionProveedor.RemoveAt(bsRequisicionProveedor.Position);

                            bsRequisicionProveedor.DataSource = oRequisicion.ListaRequisionProveedor;
                            bsRequisicionProveedor.ResetBindings(false);
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

        private void btCentroDeCosto_Click(object sender, EventArgs e)
        {
            FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto(2);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
            {
                txtIdCosto.Text = oFrm.CentroCosto.idCCostos;
                txtCosto.Text = oFrm.CentroCosto.desCCostos;
                oRequisicion.tipoCCosto = oFrm.CentroCosto.tipoCCosto;
            }
        }

        private void frmRequisicion_Load(object sender, EventArgs e)
        {
            Grid = false;
            //BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            //BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
            Nuevo();
        }

        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Requisicion != "NOEDITABLE")
            {
                if (oRequisicion.tipEstado != "AT")
                {
                    if (e.RowIndex != -1)
                    {
                        EditarDetalle(e, ((RequisicionItemE)bsRequisicionItem.Current));
                    }
                }
            }
        }

        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Requisicion != "NOEDITABLE")
            {
                if (oRequisicion.tipEstado != "AT")
                {
                    if (e.RowIndex != -1)
                    {
                        EditarDetalle(e, ((RequisicionProveedorE)bsRequisicionProveedor.Current));
                    }
                }
            }
        }

        private void cboTipoRequisicion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //Almacenes
                List<AlmacenE> ListarAlmacenes = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoRequisicion.SelectedValue));
                ListarAlmacenes.Add(new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Seleccione });
                ComboHelper.RellenarCombos(cboAlmacen, (from x in ListarAlmacenes orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen", false);
                cboAlmacen.Enabled = true;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
