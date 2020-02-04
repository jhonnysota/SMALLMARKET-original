using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;

namespace ClienteWinForm.Ventas
{
    public partial class frmConductores : frmResponseBase
    {
        #region Contructores

        public frmConductores()
        {
            InitializeComponent();
        }

        public frmConductores(Int32 idTransporte_, Int32 idConductor_)
            :this()
        {
            oConductor = AgenteVentas.Proxy.ObtenerTransporteConductores(idTransporte_, idConductor_);
        }

        #endregion

        #region Variables

        public TransporteConductoresE oConductor = null;

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        void EsNuevo()
        {
            if (oConductor == null)
            {
                oConductor = new TransporteConductoresE();

                Global.LimpiarControlesPaneles(pnlBase);
                txtIdConductor.Text = oConductor.idConductor.ToString();
                oConductor.indEstado = false;
                txtUsuRegistra.Text = oConductor.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oConductor.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oConductor.FechaRegistro.ToString();
                txtUsuModifica.Text = oConductor.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oConductor.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oConductor.FechaModificacion.ToString();
            }
            else
            {
                txtIdConductor.Text = oConductor.idConductor.ToString("00");
                txtLicencia.Text = oConductor.Licencia;
                txtNombres.Text = oConductor.Nombres;
                txtNombreCorto.Text = oConductor.nomResumido;

                txtUsuRegistra.Text = oConductor.UsuarioRegistro;
                txtRegistro.Text = oConductor.FechaRegistro.ToString();
                txtUsuModifica.Text = oConductor.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oConductor.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oConductor.FechaModificacion.ToString();
            }

            base.Nuevo();
        }

        void Datos()
        {
            oConductor.Licencia = txtLicencia.Text;
            oConductor.Nombres = txtNombres.Text;
            oConductor.nomResumido = txtNombreCorto.Text;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            Datos();

            if (ValidarGrabacion())
            {
                if (oConductor != null)
                {
                    if (String.IsNullOrEmpty(txtIdConductor.Text))
                    {
                        oConductor.idConductor = Variables.Cero;
                    }
                    else
                    {
                        oConductor.idConductor = Convert.ToInt32(txtIdConductor.Text);
                    }
                    
                    base.Aceptar();
                }
            }
        }

        public override bool ValidarGrabacion()
        {
            string respuesta = ValidarEntidad<TransporteConductoresE>(oConductor);

            if (!string.IsNullOrEmpty(respuesta))
            {
                Global.MensajeComunicacion(respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        private void frmConductores_Load(object sender, EventArgs e)
        {
            EsNuevo();
        }
    }
}
