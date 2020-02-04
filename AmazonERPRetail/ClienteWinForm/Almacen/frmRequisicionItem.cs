using ClienteWinForm.Busquedas;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Almacen
{
    public partial class frmRequisicionItem : frmResponseBase
    {
        public frmRequisicionItem()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

        }

        public frmRequisicionItem(RequisicionItemE oLista32, Int32 TipRequisicion)
            : this()
        {
            HojaReqItem = oLista32;
            oReq = TipRequisicion;
        }

        public frmRequisicionItem( Int32 TipRequisicion_)
           : this()
        {
            Requisicion = TipRequisicion_;
        }


        #region Variables

        public RequisicionItemE HojaReqItem = null;
        Int32 oReq = 0;
        Int32 Requisicion = 0;
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (HojaReqItem == null)
            {
                HojaReqItem = new RequisicionItemE();

                HojaReqItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                HojaReqItem.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                HojaReqItem.idLocal = VariablesLocales.SesionLocal.IdLocal;
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                if (HojaReqItem.Opcion == 0)
                {
                    HojaReqItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                txtCantidad.Text = Convert.ToString(HojaReqItem.CantidadRequerida);
                txtDesArticulo.Text = HojaReqItem.DesArticulo;
                txtidArticulo.Text = Convert.ToString(HojaReqItem.idArticulo);
                txtMonto.Text = Convert.ToString(HojaReqItem.MontoEstimado);
                txtEspecificacion.Text = HojaReqItem.Especificacion;
                txtMontoTotal.Text = Convert.ToString(HojaReqItem.MontoTotal);


                txtUsuarioRegistro.Text = HojaReqItem.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(HojaReqItem.FechaRegistro);
                txtUsuarioModificacion.Text = HojaReqItem.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(HojaReqItem.FechaModificacion);
                

            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {

                if (HojaReqItem != null)
                {
                    HojaReqItem.idArticulo = Convert.ToInt32(txtidArticulo.Text);
                    HojaReqItem.MontoEstimado = Convert.ToDecimal(txtMonto.Text);
                    HojaReqItem.Especificacion = txtEspecificacion.Text;
                    HojaReqItem.CantidadOrdenada = Convert.ToDecimal(txtCantidad.Text);
                    HojaReqItem.CantidadRequerida = Convert.ToDecimal(txtCantidad.Text);
                    HojaReqItem.DesArticulo = txtDesArticulo.Text;
                    HojaReqItem.Opcion = HojaReqItem.Opcion;
                    HojaReqItem.MontoTotal = Convert.ToDecimal(txtMontoTotal.Text);
                    if (HojaReqItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        HojaReqItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        HojaReqItem.FechaRegistro = VariablesLocales.FechaHoy;
                        HojaReqItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        HojaReqItem.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        HojaReqItem.UsuarioModificacion = txtUsuarioModificacion.Text;
                        HojaReqItem.FechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
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

        private void frmRequisicionItem_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btCredito_Click(object sender, EventArgs e)
        {
            try
            {
                if (oReq == 0)
                {
                    if (Requisicion != 0)
                    {
                        frmBuscarArticulo oFrm1 = new frmBuscarArticulo(Requisicion, "");

                        if (oFrm1.ShowDialog() == DialogResult.OK && oFrm1.Articulo != null)
                        {
                            txtidArticulo.Text = Convert.ToString(oFrm1.Articulo.idArticulo);
                            txtDesArticulo.Text = oFrm1.Articulo.nomArticulo;
                        }
                    }
                }
                if (oReq != 0)
                {
                    frmBuscarArticulo oFrm = new frmBuscarArticulo(oReq,"");

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Articulo != null)
                    {
                        txtidArticulo.Text = Convert.ToString(oFrm.Articulo.idArticulo);
                        txtDesArticulo.Text = oFrm.Articulo.nomArticulo;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            Decimal Mont = Convert.ToDecimal(txtMonto.Text);
            Decimal Cant = Convert.ToDecimal(txtCantidad.Text);
            Decimal TOTAL = Mont * Cant;
            txtMontoTotal.Text = TOTAL.ToString("N2");

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            Decimal Mont = Convert.ToDecimal(txtMonto.Text);
            Decimal Cant = Convert.ToDecimal(txtCantidad.Text);
            Decimal TOTAL = Mont * Cant;
            txtMontoTotal.Text = TOTAL.ToString("N2");
        }
    }
}
