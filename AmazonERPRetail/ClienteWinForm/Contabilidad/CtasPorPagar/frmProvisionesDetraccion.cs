using Entidades.CtasPorPagar;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
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

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmProvisionesDetraccion : FrmMantenimientoBase
    {

        #region Constructores

        public frmProvisionesDetraccion()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public frmProvisionesDetraccion(ProvisionesE oProv_)
           :this()
        {
            oProv = oProv_;
        } 

        #endregion

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        ProvisionesE oProv = null;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oProv.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            oProv.retFecha = dtpConstancia.Value;
            oProv.retNumero = txtConstancia.Text;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oProv != null)
            {
                dtpConstancia.Value = oProv.retFecha.Value;
                txtConstancia.Text = oProv.retNumero;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oProv != null)
                {
                    GuardarDatos();

                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        oProv = AgenteCtasPorPagar.Proxy.ActualizarProvisionesDetraccion(oProv);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
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

        private void frmProvisionesDetraccion_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }
    }
}
