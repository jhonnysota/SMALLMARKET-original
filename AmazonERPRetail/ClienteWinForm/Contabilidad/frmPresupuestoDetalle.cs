using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmPresupuestoDetalle : frmResponseBase
    {

        #region Constructor

        public frmPresupuestoDetalle()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        public frmPresupuestoDetalle(PresupuestoDetE oPrecioTemp_ ,Int32 idEEFF, String Anio)
            : this()
        {
            oPrecioItem = oPrecioTemp_;
            idESFIN = idEEFF;
            AnioDet = Anio;
        }


        #endregion

        #region Variables

        public PresupuestoDetE oPrecioItem = null;
        Int32 idESFIN = 0;
        String AnioDet = String.Empty;
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }

        #endregion Variables

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ////Meses////
            cboMes.DataSource = Global.CargarMesParaInt();
            cboMes.ValueMember = "id";
            cboMes.DisplayMember = "Nombre";
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oPrecioItem.idEEFFItem == 0)
            {
                oPrecioItem = new PresupuestoDetE()
                {
                    Opcion = (Int32)EnumOpcionGrabar.Insertar,
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    Anio = AnioDet
                };

                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                if (oPrecioItem.Opcion == 0)
                {
                    oPrecioItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                oPrecioItem.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oPrecioItem.Anio = AnioDet;
                txtEEFF.Text  = Convert.ToString(oPrecioItem.idEEFFItem);
                cboMes.SelectedValue = oPrecioItem.Mes;
                txtMonto.Text= Convert.ToString(oPrecioItem.Monto);

                txtUsuarioRegistro.Text = oPrecioItem.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(oPrecioItem.FechaRegistro);
                txtUsuarioModificacion.Text = oPrecioItem.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(oPrecioItem.FechaModificacion);
            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (oPrecioItem != null)
                {
                    oPrecioItem.idEmpresa = oPrecioItem.idEmpresa;
                    oPrecioItem.idEEFFItem = Convert.ToInt32(txtEEFF.Text);
                    oPrecioItem.Mes = Convert.ToString(cboMes.SelectedValue);
                    oPrecioItem.Monto = Convert.ToDecimal(txtMonto.Text);
                    oPrecioItem.DesItem = txtTEXTO.Text;
                    oPrecioItem.Opcion = oPrecioItem.Opcion;

                    if (oPrecioItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        oPrecioItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oPrecioItem.FechaRegistro = VariablesLocales.FechaHoy;
                        oPrecioItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oPrecioItem.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        oPrecioItem.UsuarioModificacion = txtUsuarioModificacion.Text;
                        oPrecioItem.FechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
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

        private void frmPresupuestoDetalle_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btItem_Click(object sender, EventArgs e)
        {
            frmBuscarEEFFItem oFrm = new frmBuscarEEFFItem(idESFIN);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.eItem != null)
            {
                txtEEFF.Text = Convert.ToString(oFrm.eItem.idEEFFItem);
                txtTEXTO.Text = oFrm.eItem.desItem;
            }
        } 

        #endregion

    }
}
