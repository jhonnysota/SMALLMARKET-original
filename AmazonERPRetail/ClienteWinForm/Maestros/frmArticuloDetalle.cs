using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using Presentadora.AgenteServicio;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Maestros
{
    public partial class frmArticuloDetalle : frmResponseBase
    {

        #region Constructores
        
        public frmArticuloDetalle()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            oArticulodet = new ArticuloDetalleE();
            oArticulodet.idArticulo = 0;
            oArticulodet.idCaracteristica = 0;
            oArticulodet.idEmpresa = 0;
        }

        public frmArticuloDetalle(ArticuloDetalleE oArticuloDetalleE, Int32 Opcion)
            : this()
        {
            try
            {
                oArticulodet = oArticuloDetalleE;

                txtDes.Text = oArticulodet.Descripcion;

                // AUDITORIA
                txtUsuRegistro.Text = oArticulodet.UsuarioRegistro;
                txtFechaRegistro.Text = oArticulodet.fechaRegistro.ToString();
                txtUsuModificacion.Text = oArticulodet.UsuarioModificacion;
                txtFechaModificacion.Text = oArticulodet.fechaModificacion.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion Constructores

        #region Variables
        
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public ArticuloDetalleE oArticulodet = null;

        #endregion

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            try
            {
                if (cboCarac.SelectedValue.ToString() == "0")
                {
                    Global.MensajeFault("Debe de seleccionar una caracteristica");
                    return;
                }

                if (txtDes.Text.Trim().Length == 0)
                {
                    Global.MensajeFault("Debe de ingresar la Descripcion");
                    txtDes.Focus();
                }
                else
                {
                    //CARGAMOS VARIABLES
                    oArticulodet.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    oArticulodet.Descripcion = Global.DejarSoloUnEspacio(txtDes.Text.Trim());
                    oArticulodet.idCaracteristica = Convert.ToInt32(cboCarac.SelectedValue);
                    oArticulodet.DesArticulo = ((ParTabla)cboCarac.SelectedItem).Nombre;

                    if (oArticulodet.idArticulo == Variables.Cero)
                    {
                        oArticulodet.Opcion = (Int32)EnumOpcionGrabar.Insertar;

                        oArticulodet.UsuarioRegistro = txtUsuRegistro.Text;
                        oArticulodet.fechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);
                        oArticulodet.UsuarioModificacion = txtUsuModificacion.Text;
                        oArticulodet.fechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
                    }
                    else
                    {
                        oArticulodet.Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                        oArticulodet.UsuarioModificacion = txtUsuModificacion.Text;
                        oArticulodet.fechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
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
            List<ParTabla> ListaDetalle = AgenteGeneral.Proxy.ListarParTablaPorNemo("ICARAC");
            ParTabla p = new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione };
            ListaDetalle.Add(p);

            ComboHelper.RellenarCombos<ParTabla>(cboCarac, (from x in ListaDetalle orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
        } 

        #endregion

        #region Eventos
        
        private void frmArticuloDetalle_Load(object sender, EventArgs e)
        {
            CargarCombos();

            if (oArticulodet.idArticulo != 0)
            {
                cboCarac.SelectedValue = oArticulodet.idCaracteristica;
            }
            else
            {
                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
        }

        private void cboCarac_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        #endregion Eventos

    }
}
