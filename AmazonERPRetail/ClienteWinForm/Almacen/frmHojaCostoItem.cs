using ClienteWinForm.Busquedas;
using Entidades.Almacen;
using Entidades.Maestros;
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

namespace ClienteWinForm.Ventas
{
    public partial class frmHojaCostoItem : frmResponseBase
    {
        #region Constructor

        public frmHojaCostoItem()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarComboBox();
        }

        //Nuevo
        public frmHojaCostoItem(List<HojaCostoItemE> oLista = null)
            : this()
        {
            oListaHojaItem = oLista;
        }

        //Editar
        public frmHojaCostoItem(HojaCostoItemE oPrecioTemp_, List<HojaCostoItemE> oLista = null)
            :this()
        {
            HojacostoItem = oPrecioTemp_;
            oListaHojaItem = oLista;
        }

      #endregion

        #region Variables

        public HojaCostoItemE HojacostoItem = null;
        List<HojaCostoItemE> oListaHojaItem = null;
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        void LlenarComboBox()
        {
            cboNivel.DataSource = Global.CargarTipoNivel();
            cboNivel.ValueMember = "id";
            cboNivel.DisplayMember = "Nombre";
            cboNivel.SelectedValue = Variables.Cero.ToString();


        }

        void CalcularMontos()
        {
            Decimal MontoTotal = 0;

            if (txtPreciounit.Text != ""  && txtCantidad.Text != "" && txtCambio.Text != "")
            {
              MontoTotal = Math.Round(Convert.ToDecimal(txtPreciounit.Text) * Convert.ToDecimal(txtCantidad.Text), 2);
              txtTotalFob.Text = Convert.ToString(MontoTotal);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (HojacostoItem == null)
            {
                HojacostoItem = new HojaCostoItemE();

                HojacostoItem.CostoUnitarioME = 0;
                HojacostoItem.CostoTotalME = 0;

                HojacostoItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                HojacostoItem.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                HojacostoItem.idLocal = VariablesLocales.SesionLocal.IdLocal;
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

            }
            else
            {
                if (HojacostoItem.Opcion == 0)
                {
                    HojacostoItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }
                txtCambio.Text = Convert.ToString(HojacostoItem.TCambio);
                cboNivel.SelectedValue = HojacostoItem.Nivel;
                txtidArticulo.Text = HojacostoItem.idArticulo.ToString();
                txtPartBancel.Text = HojacostoItem.PartidaArancelaria;
                txtCantidad.Text = Convert.ToString(HojacostoItem.Cantidad);
                txtPreciounit.Text = Convert.ToString(HojacostoItem.FobUnitario);
                txtPeso.Text = Convert.ToString(HojacostoItem.Peso);
                txtVolumen.Text = Convert.ToString(HojacostoItem.PesoUnitario);
                txtAdValorem.Text = Convert.ToString(HojacostoItem.AdValorem);
                txtTotalFob.Text = Convert.ToString(HojacostoItem.ValorFob);
                txtTotalDol.Text = Convert.ToString(HojacostoItem.ValorTotalDolares);
                txtUsuarioRegistro.Text = HojacostoItem.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(HojacostoItem.FechaRegistro);
                txtUsuarioModificacion.Text = HojacostoItem.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(HojacostoItem.FechaModificacion);

            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (HojacostoItem != null)
                {
                    HojacostoItem.Nivel = Convert.ToString(cboNivel.SelectedValue);
                    HojacostoItem.idArticulo = Convert.ToInt32(txtidArticulo.Text);
                    HojacostoItem.PartidaArancelaria = txtPartBancel.Text;
                    HojacostoItem.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                    HojacostoItem.FobUnitario = Convert.ToDecimal(txtPreciounit.Text);
                    HojacostoItem.ValorFob = Convert.ToDecimal(txtTotalFob.Text);
                    HojacostoItem.Peso = Convert.ToDecimal(txtPeso.Text);
                    HojacostoItem.PesoUnitario = Convert.ToDecimal(txtVolumen.Text);
                    HojacostoItem.AdValorem = Convert.ToDecimal(txtAdValorem.Text);
                    HojacostoItem.TCambio = Convert.ToDecimal(txtCambio.Text);
                    HojacostoItem.Opcion = HojacostoItem.Opcion;
                    HojacostoItem.ValorTotalDolares = Convert.ToDecimal(txtTotalDol.Text);

                    if (HojacostoItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        HojacostoItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        HojacostoItem.FechaRegistro = VariablesLocales.FechaHoy;
                        HojacostoItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        HojacostoItem.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        HojacostoItem.UsuarioModificacion = txtUsuarioModificacion.Text;
                        HojacostoItem.FechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
                    }

                    //CamposnoenFRM
                    HojacostoItem.nNivel = 0;
                    HojacostoItem.Nivelinv = "A";
                    HojacostoItem.Descripcion = "a";
                    HojacostoItem.ValorPeso = 0;
                    HojacostoItem.ValorVolumen = 0;
                    HojacostoItem.OtrosCostos = 0;
                    HojacostoItem.ValorCif = 0;
                    HojacostoItem.GstoAduana = 0;
                    HojacostoItem.GstoComision = 0;
                    HojacostoItem.GstoSeguro = 0;
                    HojacostoItem.GstoBancario = 0;
                    HojacostoItem.GstoOtros = 0;
                    HojacostoItem.CostoTotalMN = 0;
                    HojacostoItem.CostoUnitarioMN = 0;
                    HojacostoItem.FactorVenta = 0;
                    HojacostoItem.PrecioVenta = 0;
                    HojacostoItem.Utilidad = 0;

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

        private void frmHojaCostoItem_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btCredito_Click(object sender, EventArgs e)
        {
            frmBuscarArticulo oFrm = new frmBuscarArticulo();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Articulo != null)
            {
                txtidArticulo.Text = oFrm.Articulo.idArticulo.ToString("000000");
                txtDesArticulo.Text = oFrm.Articulo.nomArticulo;

            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularMontos();
        }

        private void txtPreciounit_TextChanged(object sender, EventArgs e)
        {
            CalcularMontos();
        }

        #endregion

        private void txtCambio_Validating(object sender, CancelEventArgs e)
        {
            Decimal TotalDol;
            TotalDol = HojacostoItem.ValorFob / Convert.ToDecimal(txtCambio.Text);
            TotalDol = Math.Round(TotalDol,2);

            txtTotalDol.Text = TotalDol.ToString("N2");

        }
    }
}
