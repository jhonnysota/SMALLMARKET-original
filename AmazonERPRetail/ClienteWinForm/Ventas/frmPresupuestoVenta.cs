using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmPresupuestoVenta : FrmMantenimientoBase
    {

        #region Constructores

        public frmPresupuestoVenta()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
            FormatoGrid(dgvPresuDetalle, true);
        }

        public frmPresupuestoVenta(PresupuestoVentaE NC)
            :this()
        {
            PresVenta = AgenteCtasPorPagar.Proxy.ObtenerPresupuestoVentaCompleto(NC.idEmpresa, NC.AnioPresupuesto, NC.idVendedor);
            Text = "Presupuesto de Venta (Edición)";
        } 

        #endregion

        #region Variables
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        VentasServiceAgent AgenteCtasPorPagar { get { return new VentasServiceAgent(); } }
        PresupuestoVentaE PresVenta = null;
        List<PresupuestoVentaDetE> FilesEliminados = null;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        Int32 opcion = 0;
        List<ParTabla> ListaTipoArticulo = null;
        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //////Moneda///////
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);
            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;

            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";

            cboTipoArticulo.DataSource = null;
            ListaTipoArticulo = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ParTabla p = new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione };
            ListaTipoArticulo.Add(p);

            ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in ListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);



        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
            pnlDetalles.Enabled = Flag;
        }

        void GuardarDatos()
        {
            PresVenta.AnioPresupuesto = Convert.ToString(cboAño.SelectedValue);
            PresVenta.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
            PresVenta.idTipoArticulo = Convert.ToInt32(cboTipoArticulo.SelectedValue);
            PresVenta.UsuarioModificacion = txtusumod.Text;
            PresVenta.UsuarioRegistro = txtusuRegistro.Text;
            PresVenta.FechaModificacion = Convert.ToDateTime(txtfechamod.Text);
            PresVenta.FechaRegistro = Convert.ToDateTime(txtFechareg.Text);
        }

        void EditarDetalle(DataGridViewCellEventArgs e, PresupuestoVentaDetE oHojaItem)
        {
            try
            {
                if (bsPresupuestoVentaDet.Count > 0)
                {
                    frmPresupuestoVentaDetalle oFrm = new frmPresupuestoVentaDetalle(oHojaItem, PresVenta.idTipoArticulo.Value);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        PresVenta.ListaPresupuestoVentaDet[e.RowIndex] = oFrm.oPresuDet;
                        bsPresupuestoVentaDet.DataSource = PresVenta.ListaPresupuestoVentaDet;
                        bsPresupuestoVentaDet.ResetBindings(false);
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
            if (PresVenta == null)
            {
                PresVenta = new PresupuestoVentaE()
                {
                    ListaPresupuestoVentaDet = new List<PresupuestoVentaDetE>(),
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    AnioPresupuesto = Convert.ToString(cboAño.SelectedValue)
                };

                txtusuRegistro.Text = PresVenta.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                PresVenta.FechaRegistro = VariablesLocales.FechaHoy;
                txtFechareg.Text = Convert.ToString(PresVenta.FechaRegistro);
                txtusumod.Text = PresVenta.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                PresVenta.FechaModificacion = VariablesLocales.FechaHoy;
                txtfechamod.Text = Convert.ToString(PresVenta.FechaModificacion);
                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                if (PresVenta.ListaPresupuestoVentaDet == null)
                {
                    PresVenta.ListaPresupuestoVentaDet = new List<PresupuestoVentaDetE>();
                }

                cboAño.SelectedValue = PresVenta.AnioPresupuesto;
                cboMoneda.SelectedValue = PresVenta.idMoneda;
                cboTipoArticulo.SelectedValue = PresVenta.idTipoArticulo;
                cboAño.Enabled = false;
                btProveedor.Enabled = false;
                txtVendedor.Text = PresVenta.Vendedor;

                PresVenta.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                PresVenta.FechaModificacion = VariablesLocales.FechaHoy;

                txtusuRegistro.Text = PresVenta.UsuarioRegistro;
                txtFechareg.Text = Convert.ToString(PresVenta.FechaRegistro);
                txtusumod.Text = PresVenta.UsuarioModificacion;
                txtfechamod.Text = Convert.ToString(PresVenta.FechaModificacion);
                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsPresupuestoVentaDet.DataSource = PresVenta.ListaPresupuestoVentaDet;
            bsPresupuestoVentaDet.ResetBindings(false);
            FilesEliminados = new List<PresupuestoVentaDetE>();

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (PresVenta != null)
                {
                    GuardarDatos();
                    bsPresupuestoVentaDet.EndEdit();

                    if (!ValidarGrabacion()) { return; }

                    if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            PresVenta = AgenteCtasPorPagar.Proxy.GrabarPresupuestoVenta(PresVenta, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            PresVenta = AgenteCtasPorPagar.Proxy.GrabarPresupuestoVenta(PresVenta, EnumOpcionGrabar.Actualizar);

                            if (FilesEliminados != null && FilesEliminados.Count > Variables.Cero)
                            {
                                PresupuestoVentaE numTmp = new PresupuestoVentaE();
                                numTmp = PresVenta;
                                numTmp.ListaPresupuestoVentaDet = new List<PresupuestoVentaDetE>(FilesEliminados);
                                FilesEliminados = new List<PresupuestoVentaDetE>();
                            }

                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }
                
                //bsPresupuestoVentaDet.ResetBindings(false);

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void AgregarDetalle()
        {
            try
            {
                frmPresupuestoVentaDetalle oFrm = new frmPresupuestoVentaDetalle(PresVenta.idTipoArticulo.Value);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPresuDet != null)
                {
                    PresVenta.ListaPresupuestoVentaDet.Add(oFrm.oPresuDet);
                    bsPresupuestoVentaDet.DataSource = PresVenta.ListaPresupuestoVentaDet;
                    bsPresupuestoVentaDet.ResetBindings(false);
                    base.AgregarDetalle();
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
                if (bsPresupuestoVentaDet.Current != null)
                {
                    if (PresVenta.ListaPresupuestoVentaDet != null && PresVenta.ListaPresupuestoVentaDet.Count > Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                            return;

                        bsPresupuestoVentaDet.EndEdit();

                        PresupuestoVentaDetE tmp = (PresupuestoVentaDetE)bsPresupuestoVentaDet.Current;
                        tmp.Opcion = (Int32)EnumOpcionGrabar.Eliminar;

                        FilesEliminados.Add(tmp);
                        PresVenta.ListaPresupuestoVentaDet.RemoveAt(bsPresupuestoVentaDet.Position);
                        bsPresupuestoVentaDet.DataSource = PresVenta.ListaPresupuestoVentaDet;
                        bsPresupuestoVentaDet.ResetBindings(false);

                        base.QuitarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<PresupuestoVentaE>(PresVenta);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmPresupuestoVenta_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();

            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
        }

        private void btProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarVendedor oFrm = new frmBuscarVendedor();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oVendedor != null)
                {
                    PresVenta.idVendedor = oFrm.oVendedor.idPersona;
                    txtVendedor.Text = oFrm.oVendedor.RazonSocial;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvPresuDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((PresupuestoVentaDetE)bsPresupuestoVentaDet.Current));
            }
        }

        private void bsPresupuestoVentaDet_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                if (bsPresupuestoVentaDet.Count > 0)
                {
                    LblRegistros.Text = "Articulos " + bsPresupuestoVentaDet.Count.ToString();
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
