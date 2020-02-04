using ClienteWinForm.Busquedas;
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

namespace ClienteWinForm.Maestros
{
    public partial class frmCostosMovimientosDetalle : frmResponseBase
    {
        #region Constructor

        public frmCostosMovimientosDetalle()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            CargarCombos();
        }

        //Nuevo
        public frmCostosMovimientosDetalle(String CodClas_)
          : this()
        {
            CodClas = CodClas_;
        }


        //Editar
        public frmCostosMovimientosDetalle(CostosMovimientosItemE oMovItem)
            : this()
        {
            try
            {
                cboMes.Enabled = false;
                //btCodClas.Enabled = false;
                oCostosMovItem = oMovItem;

                txtMonto.Text = oMovItem.Monto;
                //txtCodClas.Text = oMovItem.CodClasificacion;
                cboMes.SelectedValue = oMovItem.Mes;
                // AUDITORIA
                txtUsuRegistro.Text = oMovItem.UsuarioRegistro;
                txtFechaRegistro.Text = oMovItem.FechaRegistro.ToString();
                txtUsuModificacion.Text = oMovItem.UsuarioModificacion;
                txtFechaModificacion.Text = oMovItem.FechaModificacion.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Variables
        String CodClas = String.Empty;
        public CostosMovimientosItemE oCostosMovItem = null;

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oCostosMovItem == null)
                {
                    oCostosMovItem = new CostosMovimientosItemE();
                    oCostosMovItem.CodClasificacion = CodClas;
                    oCostosMovItem.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Aceptar()
        {
            try
            {
                    //CARGAMOS VARIABLES
                    oCostosMovItem.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    //oCostosMovItem.CodClasificacion = txtCodClas.Text;
                    oCostosMovItem.Mes = Convert.ToString(cboMes.SelectedValue);
                    oCostosMovItem.Monto = txtMonto.Text;

                    if (oCostosMovItem.idElemento == Variables.Cero)
                    {
                    oCostosMovItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;

                    oCostosMovItem.UsuarioRegistro = txtUsuRegistro.Text;
                    oCostosMovItem.FechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);
                    oCostosMovItem.UsuarioModificacion = txtUsuModificacion.Text;
                    oCostosMovItem.FechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
                    }
                    else
                    {
                        oCostosMovItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                    oCostosMovItem.UsuarioModificacion = txtUsuModificacion.Text;
                    oCostosMovItem.FechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
                    }

                    DialogResult = DialogResult.OK;
                    Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos de Usuario

        void CargarCombos()
        {
            //Cargando Meses Contables
            DataTable dataMes = FechasHelper.CargarMeses(1, true, "MA");
            DataRow dt;
            dt = dataMes.NewRow();
            dt["MesId"] = "00";
            dt["MesDes"] = Variables.Todos;
            dataMes.Rows.Add(dt);

            cboMes.DataSource = dataMes;
            cboMes.ValueMember = "MesId";
            cboMes.DisplayMember = "MesDes";
            cboMes.SelectedValue = VariablesLocales.FechaHoy.Month.ToString("00");
        }

        #endregion

        #region Eventos

        private void frmCostosMovimientosDetalle_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btProveedor_Click(object sender, EventArgs e)
        {

            //frmBuscarCostosClasificacion oFrm = new frmBuscarCostosClasificacion();

            //if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCostosClasificacion != null)
            //{
            //    txtCodClas.Text = oFrm.oCostosClasificacion.CodClasificacion;
            //}
        }

        #endregion

    }
}
