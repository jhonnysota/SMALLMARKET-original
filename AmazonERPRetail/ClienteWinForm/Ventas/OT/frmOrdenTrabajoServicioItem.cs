using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmOrdenTrabajoServicioItem : frmResponseBase
    {

        #region Constructor

        public frmOrdenTrabajoServicioItem()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
        }

        public frmOrdenTrabajoServicioItem(OrdenTrabajoServicioItemE oOrdenTrabajoservItem_)
            : this()
        {
            oOrdenTrabajoServicioItem = oOrdenTrabajoservItem_;
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        Int32 ContadorReg = 1;
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public OrdenTrabajoServicioItemE oOrdenTrabajoServicioItem = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //////Moneda///////
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);

            List<ParTabla> ListarTipos = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
        }

        void Calcular()
        {
            #region Variables

            Decimal Cantidad = Variables.Cero;
            Decimal Precio = Variables.Cero;
            Decimal Igv = Variables.Cero;
            Decimal ValorVenta = Variables.Cero;
            Decimal porIgv = Variables.Cero;

            #endregion

            #region Parseando para evitar errores de escritura

            Decimal.TryParse(txtCantidad.Text, out Cantidad);
            Decimal.TryParse(txtPrecioUnitario.Text, out Precio);

            txtValorVenta.Text = (Precio * Cantidad).ToString("N2");
            Decimal.TryParse(txtValorVenta.Text, out ValorVenta);

            //Impuesto General a la Venta
            Decimal.TryParse(txtPorcIgv.Text, out porIgv);
            txtIGV.Text = ((ValorVenta) * (porIgv / 100)).ToString("N2");
            Decimal.TryParse(txtIGV.Text, out Igv);

            //Total General
            txtTotal.Text = (ValorVenta + Igv).ToString("N2");

            #endregion
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oOrdenTrabajoServicioItem == null)
            {
                oOrdenTrabajoServicioItem = new OrdenTrabajoServicioItemE();
                oOrdenTrabajoServicioItem.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oOrdenTrabajoServicioItem.idLocal = VariablesLocales.SesionLocal.IdLocal;

                oOrdenTrabajoServicioItem.UsuarioRegistro = txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();
                oOrdenTrabajoServicioItem.Estado = "P";
                oOrdenTrabajoServicioItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;
                
                txtIdArticulo.Text = Convert.ToString(oOrdenTrabajoServicioItem.idArticulo);
                txtDesArticulo.Text = oOrdenTrabajoServicioItem.desArticulo;
                txtCodArticulo.Text = oOrdenTrabajoServicioItem.codArticulo;
                txtDescripcion.Text = oOrdenTrabajoServicioItem.Descripcion;
                dtpFecEntrega.Value = oOrdenTrabajoServicioItem.FechaEntrega.Value;
                cboMoneda.SelectedValue = oOrdenTrabajoServicioItem.idMoneda;
                txtCantidad.Text = Convert.ToString(oOrdenTrabajoServicioItem.Cantidad);
                txtPrecioUnitario.Text = Convert.ToString(oOrdenTrabajoServicioItem.PrecioUnitario);
                txtValorVenta.Text = Convert.ToString(oOrdenTrabajoServicioItem.ValorVenta);
              
                if (oOrdenTrabajoServicioItem.flgIgv)
                 {
                    chImpuesto.Checked = true;
                 }

                txtPorcIgv.Text = Convert.ToString(oOrdenTrabajoServicioItem.porIgv);
                txtIGV.Text = Convert.ToString(oOrdenTrabajoServicioItem.Igv);
                txtTotal.Text = Convert.ToString(oOrdenTrabajoServicioItem.Total);

                txtUsuRegistra.Text = oOrdenTrabajoServicioItem.UsuarioRegistro;
                txtUsuModifica.Text = oOrdenTrabajoServicioItem.UsuarioModificacion;
                txtFechaRegistro.Text = oOrdenTrabajoServicioItem.FechaRegistro.ToString();
                txtModifica.Text = oOrdenTrabajoServicioItem.FechaModificacion.ToString();

                oOrdenTrabajoServicioItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                if (oOrdenTrabajoServicioItem.Opcion != (Int32)EnumOpcionGrabar.Insertar)
                {
                    oOrdenTrabajoServicioItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }


                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;

            }
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<OrdenTrabajoServicioItemE>(oOrdenTrabajoServicioItem);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (ContadorReg>99)
            {
                Global.MensajeError("Ha Superado el Maximo de Registros");
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void Aceptar()
        {
            try
            {
                if (oOrdenTrabajoServicioItem != null)
                {

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (oOrdenTrabajoServicioItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        List<OrdenTrabajoServicioItemE> Olistas = AgenteVentas.Proxy.ListarOrdenTrabajoServicioItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                    VariablesLocales.SesionLocal.IdLocal,
                                                                                                                    oOrdenTrabajoServicioItem.idOT);
                        if(Olistas.Count == 0)
                        {
                            ContadorReg = 1;
                        }
                        else
                        {
                            ContadorReg = ContadorReg + Olistas.Count;
                        }
                    
                        if (ContadorReg >= 0)
                        {
                            oOrdenTrabajoServicioItem.Item = "0"+Convert.ToString(ContadorReg);
                        }

                        if (ContadorReg >= 10)
                        {
                            oOrdenTrabajoServicioItem.Item = Convert.ToString(ContadorReg);
                        }
                    }
               
                    oOrdenTrabajoServicioItem.idArticulo = Convert.ToInt32(txtIdArticulo.Text);
                    oOrdenTrabajoServicioItem.idCCostos = "";
                    oOrdenTrabajoServicioItem.Descripcion = txtDescripcion.Text;
                    oOrdenTrabajoServicioItem.FechaEntrega = dtpFecEntrega.Value;
                    oOrdenTrabajoServicioItem.idTipoArticuloProducto = 0;
                    oOrdenTrabajoServicioItem.idArticuloProducto = 0;
                    oOrdenTrabajoServicioItem.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
                    oOrdenTrabajoServicioItem.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                    oOrdenTrabajoServicioItem.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
                    oOrdenTrabajoServicioItem.ValorVenta = Convert.ToDecimal(txtValorVenta.Text);
                    oOrdenTrabajoServicioItem.flgIgv = chImpuesto.Checked;
                    oOrdenTrabajoServicioItem.porIgv = Convert.ToDecimal(txtPorcIgv.Text);
                    oOrdenTrabajoServicioItem.Igv = Convert.ToDecimal(txtIGV.Text);
                    oOrdenTrabajoServicioItem.Total = Convert.ToDecimal(txtTotal.Text);
                    oOrdenTrabajoServicioItem.Opcion = oOrdenTrabajoServicioItem.Opcion;

                    if (oOrdenTrabajoServicioItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        oOrdenTrabajoServicioItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oOrdenTrabajoServicioItem.FechaRegistro = VariablesLocales.FechaHoy;
                        oOrdenTrabajoServicioItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oOrdenTrabajoServicioItem.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        oOrdenTrabajoServicioItem.UsuarioModificacion = txtUsuModifica.Text;
                        oOrdenTrabajoServicioItem.FechaModificacion = Convert.ToDateTime(txtModifica.Text);
                    }

                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmOrdenTrabajoServicioItem_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmBuscarArticulo oFrm = new frmBuscarArticulo(333016, "");

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Articulo != null)
            {
                txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                txtIdArticulo.Text = oFrm.Articulo.idArticulo.ToString();
                txtCodArticulo.Text = oFrm.Articulo.codArticulo;
                txtDesArticulo.Text = oFrm.Articulo.nomArticulo.ToString();

                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
            }
        }

        private void txtDesArticulo_TextChanged(object sender, EventArgs e)
        {
            txtIdArticulo.Text = string.Empty;
            txtCodArticulo.Text = string.Empty;
        }

        private void txtCodArticulo_TextChanged(object sender, EventArgs e)
        {
            txtIdArticulo.Text = string.Empty;
            txtDesArticulo.Text = string.Empty;
        }

        private void txtDesArticulo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodArticulo.Text.Trim()) && !string.IsNullOrEmpty(txtDesArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    List<ArticuloServE> oListaArticulos = AgenteMaestros.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa, 333018, "", txtDesArticulo.Text.Trim());

                    if (oListaArticulos.Count >= 1)
                    {
                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                        }
                    }
                    else if (oListaArticulos.Count == 1)
                    {
                        txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
                        txtCodArticulo.Text = oListaArticulos[0].codArticulo;
                        txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
                    }
                    else
                    {
                        Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
                        txtIdArticulo.Text = string.Empty;
                        txtCodArticulo.Text = string.Empty;
                        txtDesArticulo.Text = string.Empty;
                        txtCodArticulo.Focus();
                    }

                    txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCodArticulo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodArticulo.Text.Trim()) && string.IsNullOrEmpty(txtDesArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    List<ArticuloServE> oListaArticulos = AgenteMaestros.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa, 333018, txtCodArticulo.Text.Trim(), "");

                    if (oListaArticulos.Count >= 1)
                    {
                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                        }
                    }
                    else if (oListaArticulos.Count == 1)
                    {
                        txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
                        txtCodArticulo.Text = oListaArticulos[0].codArticulo;
                        txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
                    }
                    else
                    {
                        Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
                        txtIdArticulo.Text = string.Empty;
                        txtCodArticulo.Text = string.Empty;
                        txtDesArticulo.Text = string.Empty;
                        txtCodArticulo.Focus();
                    }

                    txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void chImpuesto_CheckedChanged(object sender, EventArgs e)
        {
            if (chImpuesto.Checked)
            {
                ImpuestosPeriodoE objImpuestoPeriodo = AgenteGeneral.Proxy.ObtenerImpuestosPeriodo(1, 1);
                txtPorcIgv.Text = (objImpuestoPeriodo.Porcentaje).ToString();
            }
            else
            {
                txtPorcIgv.Text = "0.00";
            }
        }

        private void txtPorcIgv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
        }

        private void txtCantidad_MouseClick(object sender, MouseEventArgs e)
        {
            txtCantidad.SelectAll();
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            txtCantidad.Text = Global.FormatoDecimal(txtCantidad.Text, 4);
        }

        private void txtPrecioUnitario_Enter(object sender, EventArgs e)
        {
            txtPrecioUnitario.SelectAll();
        }

        private void txtPrecioUnitario_Leave(object sender, EventArgs e)
        {
            txtPrecioUnitario.Text = Global.FormatoDecimal(txtPrecioUnitario.Text, 5);
        }

        private void txtPrecioUnitario_MouseClick(object sender, MouseEventArgs e)
        {
            txtPrecioUnitario.SelectAll();
        }

        #endregion

    }
}
