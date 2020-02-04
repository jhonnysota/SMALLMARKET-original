using ClienteWinForm.Busquedas;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
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
    public partial class frmRequisicionProveedor : frmResponseBase
    {
        public frmRequisicionProveedor()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            
        }

        //Nuevo
        public frmRequisicionProveedor(RequisicionProveedorE oLista = null)
            : this()
        {
            HojaReqPro = oLista;
        }

        #region Variables

        public RequisicionProveedorE HojaReqPro = null;
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (HojaReqPro == null)
            {
                HojaReqPro = new RequisicionProveedorE();

                HojaReqPro.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                HojaReqPro.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                if (HojaReqPro.Opcion == 0)
                {
                    HojaReqPro.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                txtidProveedor.Text = Convert.ToString(HojaReqPro.idPersona);
                txtProveedor.Text = HojaReqPro.DesPersona;
                txtUsuarioRegistro.Text = HojaReqPro.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(HojaReqPro.FechaRegistro);
                txtUsuarioModificacion.Text = HojaReqPro.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(HojaReqPro.FechaModificacion);

            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {

                if (HojaReqPro != null)
                {
                    HojaReqPro.idPersona = Convert.ToInt32(txtidProveedor.Text);
                    HojaReqPro.DesPersona = txtProveedor.Text;
                    HojaReqPro.Opcion = HojaReqPro.Opcion;

                    if (HojaReqPro.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        HojaReqPro.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        HojaReqPro.FechaRegistro = VariablesLocales.FechaHoy;
                        HojaReqPro.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        HojaReqPro.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        HojaReqPro.UsuarioModificacion = txtUsuarioModificacion.Text;
                        HojaReqPro.FechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
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

        private void frmRequisicionProveedor_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btCredito_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaProveedor oFrm = new frmBusquedaProveedor();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProveedor != null)
                {
                    txtidProveedor.Text = oFrm.oProveedor.IdPersona.ToString();
                    txtProveedor.Text = oFrm.oProveedor.RazonSocial;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }
    }
}
