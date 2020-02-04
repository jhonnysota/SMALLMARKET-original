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

namespace ClienteWinForm.Contabilidad
{
    public partial class frmRevisarEstadosSunat : frmResponseBase
    {
        public frmRevisarEstadosSunat(EmisionDocumentoE oDocumentoRecibido)
        {
            InitializeComponent();

            if (oDocumentoRecibido != null)
            {
                oDocumentoEstados = oDocumentoRecibido;

                if (oDocumentoEstados.EnviadoSunat)
                {
                    Int32 Posicion = Variables.Cero;
                    String MensajeSunat = String.Empty;

                    if (!String.IsNullOrEmpty(oDocumentoEstados.MensajeSunat))
                    {
                        Boolean Banderita = (oDocumentoEstados.MensajeSunat.IndexOf("\"mensaje\":\"") > 0);

                        if (Banderita)
                        {
                            Posicion = oDocumentoEstados.MensajeSunat.IndexOf("\"mensaje\":\"");
                            MensajeSunat = oDocumentoEstados.MensajeSunat.Substring(Posicion + 11);
                            MensajeSunat = MensajeSunat.Substring(0, MensajeSunat.Length - 2);
                        }
                    }
                    
                    lblEnvio.Text = "SI";
                    lblFechaEnvio.Text = oDocumentoEstados.fecEnvioSunat.Value.ToString("dd/MM/yyyy");

                    lblEstadoEnvio.Text = oDocumentoEstados.EstadoRegistro.ToString();
                    lblMensajeEnvio.Text = oDocumentoEstados.MensajeRegistro;
                    lblMensajeSunat.Text = MensajeSunat;

                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20452630886") //Fundo San Miguel
                    {
                        switch (oDocumentoEstados.EstadoRegistro)
                        {
                            case 1:
                                lblEstadoSunat.Text = "Pendiente de respuesta.";
                                break;
                            case 2:
                                lblEstadoSunat.Text = "Error en Bizlinks.";
                                break;
                            case 3:
                                lblEstadoSunat.Text = "Documento Aceptado.";
                                break;
                            default:
                                lblEstadoSunat.Text = "Documento Rechazado.";
                                break;
                        }
                    }

                    if (oDocumentoEstados.EstadoSunat != Variables.Cero)
                    {
                        lblAnulado.Text = "SI";
                        lblFechaAnulacion.Text = oDocumentoEstados.fecAnuladoSunat.Value.ToString("dd/MM/yyyy");
                        lblEstadoSunat.Text = oDocumentoEstados.EstadoSunat.ToString();
                        lblMensajeSunat.Text = oDocumentoEstados.MensajeSunat;
                        lblMotivoAnulacion.Text = oDocumentoEstados.MotivoAnulacion;
                    }
                }
                
            }
        }

        EmisionDocumentoE oDocumentoEstados = null;

        private void frmRevisarEstadosSunat_Load(object sender, EventArgs e)
        {
            
        }

    }
}
