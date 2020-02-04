using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Ventas;
using ClienteWinForm.Busquedas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Ventas
{
    public partial class frmPresupuestoVentaDetalle : frmResponseBase
    {

        #region Constructores

        public frmPresupuestoVentaDetalle()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        public frmPresupuestoVentaDetalle(PresupuestoVentaDetE oListaEstructuraTemp, Int32 TipoArt)
            : this()
        {
            oPresuDet = oListaEstructuraTemp;
            TipoArticulo = TipoArt;
        }

        public frmPresupuestoVentaDetalle(Int32 TipoArt)
         : this()
        {
            TipoArticulo = TipoArt;
        } 

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        public PresupuestoVentaDetE oPresuDet = null;
        Int32 TipoArticulo = 0;

        #endregion

        #region Procedimientos de Usuario

        void EsNuevoRegistro()
        {
            if (oPresuDet == null)
            {
                oPresuDet = new PresupuestoVentaDetE();
                oPresuDet.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                oPresuDet.Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;
                txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;

                cboEstablecimiento.SelectedValue = oPresuDet.idEstablecimiento;
                txtCodArticulo.Text = oPresuDet.idArticulo.ToString();
                txtDesArticulo.Text = oPresuDet.DesTipoArticulo;
                txtCantidad.Text = oPresuDet.Cantidad.Value.ToString("N2");
                txtPrecioUnit.Text = oPresuDet.PrecioUnit.Value.ToString("N2");
                txtTotal.Text = oPresuDet.Total.Value.ToString("N2");
                cboMes.SelectedValue = oPresuDet.Mes;

                txtUsuRegistra.Text = oPresuDet.UsuarioRegistro;
                txtFechaRegistro.Text = oPresuDet.FechaRegistro.ToString();
                txtUsuModifica.Text = oPresuDet.UsuarioModificacion;
                txtModifica.Text = oPresuDet.FechaModificacion.ToString();

                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;

                oPresuDet.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        void LlenarCombos()
        {
            List<EstablecimientosE> oListaEstablecimientos = AgenteMaestros.Proxy.ListarEstablecimientos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
            oListaEstablecimientos.Add(new EstablecimientosE() { idEstablecimiento = Variables.Cero, Descripcion = Variables.Seleccione });
            ComboHelper.LlenarCombos<EstablecimientosE>(cboEstablecimiento, (from x in oListaEstablecimientos orderby x.idEstablecimiento select x).ToList(), "idEstablecimiento", "Descripcion");

            /////MESINICIO////
            DataTable oDt = FechasHelper.CargarMeses(1, true, "MA");
            oDt.DefaultView.Sort = "MesId";
            cboMes.DataSource = oDt;
            cboMes.ValueMember = "MesId";
            cboMes.DisplayMember = "MesDes";
            cboMes.SelectedValue = "01";
        }

        #endregion

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            try
            {
                if (ValidarGrabacion())
                {
                    if (oPresuDet != null)
                    {
                        oPresuDet.idEstablecimiento = Convert.ToInt32(cboEstablecimiento.SelectedValue);
                        oPresuDet.idArticulo = Convert.ToInt32(txtCodArticulo.Text);
                        oPresuDet.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                        oPresuDet.PrecioUnit = Convert.ToDecimal(txtPrecioUnit.Text);
                        oPresuDet.Total = Convert.ToDecimal(txtTotal.Text);
                        oPresuDet.Mes = Convert.ToString(cboMes.SelectedValue);

                        if (oPresuDet.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                        {
                            oPresuDet.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                            oPresuDet.FechaRegistro = VariablesLocales.FechaHoy;
                            oPresuDet.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oPresuDet.FechaModificacion = VariablesLocales.FechaHoy;
                        }
                        else
                        {
                            oPresuDet.UsuarioRegistro = txtUsuRegistra.Text;
                            oPresuDet.FechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);
                            oPresuDet.UsuarioModificacion = txtUsuModifica.Text;
                            oPresuDet.FechaModificacion = VariablesLocales.FechaHoy;
                        }

                        base.Aceptar();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

        #region Eventos

        private void frmPresupuestoVentaDetalle_Load(object sender, EventArgs e)
        {
            EsNuevoRegistro();
        }

        private void btArticulo_Click(object sender, EventArgs e)
        {
            frmBuscarArticulo oFrm = new frmBuscarArticulo(TipoArticulo);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Articulo != null)
            {
                txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                txtIdArticulo.Text = oFrm.Articulo.idArticulo.ToString();
                txtDesArticulo.Text = oFrm.Articulo.nomArticulo;
                txtCodArticulo.Text = oFrm.Articulo.codArticulo;

                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
            }
        }

        private void txtCodArticulo_TextChanged(object sender, EventArgs e)
        {
            txtIdArticulo.Text = string.Empty;
            txtDesArticulo.Text = string.Empty;
        }

        private void txtDesArticulo_TextChanged(object sender, EventArgs e)
        {
            txtIdArticulo.Text = string.Empty;
            txtCodArticulo.Text = string.Empty;
        }

        private void txtCodArticulo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodArticulo.Text.Trim()) && string.IsNullOrEmpty(txtDesArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    List<ArticuloServE> oListaArticulos = AgenteMaestros.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa, TipoArticulo, txtCodArticulo.Text.Trim(), "");

                    if (oListaArticulos.Count > 1)
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

        private void txtDesArticulo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodArticulo.Text.Trim()) && !string.IsNullOrEmpty(txtDesArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    List<ArticuloServE> oListaArticulos = AgenteMaestros.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa, TipoArticulo, "", txtDesArticulo.Text.Trim());

                    if (oListaArticulos.Count > 1)
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
                        Global.MensajeFault("El descripción ingresada no existe, vuelva a probar por favor.");
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

        #endregion

    }
}
