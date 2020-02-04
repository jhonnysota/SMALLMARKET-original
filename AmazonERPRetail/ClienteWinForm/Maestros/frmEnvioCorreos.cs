using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Ventas;
using Entidades.Almacen;
using Entidades.Generales;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Maestros
{
    public partial class frmEnvioCorreos : frmResponseBase
    {

        #region Constructores

        public frmEnvioCorreos()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            Global.CrearToolTip(btQuitarAdjunto, "Quitar archivo adjunto");
        }

        //Fundo San Miguel
        public frmEnvioCorreos(Int32 idEmpresa_, Int32 idPedido_, String Ruta_, String Doc_)
            :this()
        {
            idEmpresa = idEmpresa_;
            idPedido = idPedido_;
            txtAdjunto.Text = Ruta_;
            txtAsunto.Text = Doc_;
        }

        //Pedidos
        public frmEnvioCorreos(PedidoCabE oPedidoTemp, String RutaArchivo)
            :this()
        {
            oPedido = oPedidoTemp;
            RutaDocumento = RutaArchivo;
        }

        //Ordenes de Compra
        public frmEnvioCorreos(OrdenCompraE orden, String RutaArchivo)
            :this()
        {
            oOrdenCompra = orden;
            RutaDocumento = RutaArchivo;
        }

        //Ordenes de Pago
        public frmEnvioCorreos(OrdenPagoE oPago, String RutaArchivo)
            :this()
        {
            oOrdenPago = oPago;
            RutaDocumento = RutaArchivo;
        }

        //Retenciones
        public frmEnvioCorreos(RetencionE oRetencion, String RutaArchivo)
            :this()
        {
            oReten = oRetencion;
            RutaDocumento = RutaArchivo;
        }

        //Requisiciones
        public frmEnvioCorreos(RequisicionE oRequisicion_, String RutaArchivo)
            :this()
        {
            oRequisicion = oRequisicion_;
            RutaDocumento = RutaArchivo;
        }

        //Comisiones
        public frmEnvioCorreos(ComisionesConfiguracionE ocomisiones, String RutaArchivo)
            :this()
        {
            ocomision = ocomisiones;
            RutaDocumento = RutaArchivo;
        }

        //Liquidaciones
        public frmEnvioCorreos(LiquidacionE oLiquidacion_, String RutaArchivo)
            :this()
        {
            oLiqui = oLiquidacion_;
            RutaDocumento = RutaArchivo;
        }

        //Liquidaciones
        public frmEnvioCorreos(EmisionDocumentoE oEmision_, String RutaArchivo)
            :this()
        {
            oEmi = oEmision_;
            RutaDocumento = RutaArchivo;
        }

        //Orden
        public frmEnvioCorreos(OrdenTrabajoServicioE oOrden_, String RutaArchivo)
            :this()
        {
            oOrden = oOrden_;
            RutaDocumento = RutaArchivo;
        }

        #endregion Constructores

        #region Variables

        public Boolean CorreoEnviado = false;
        PedidoCabE oPedido = null;
        OrdenCompraE oOrdenCompra = null;
        RetencionE oReten = null;
        RequisicionE oRequisicion = null;
        OrdenPagoE oOrdenPago = null;
        ComisionesConfiguracionE ocomision = null;
        LiquidacionE oLiqui = null;
        EmisionDocumentoE oEmi = null;
        OrdenTrabajoServicioE oOrden = null;

        Int32 idEmpresa = Variables.Cero;
        Int32 idPedido = Variables.Cero;
        String codPedidoCad = String.Empty;

        String RutaDocumento = String.Empty;
        String De = VariablesLocales.SesionUsuario.Empresa.sEmailOtros;
        String ServidorSalida = VariablesLocales.SesionUsuario.Empresa.ServidorSalienteOtros;
        Int32 PuertoSalida = VariablesLocales.SesionUsuario.Empresa.PuertoOtros;
        String Clave = VariablesLocales.SesionUsuario.Empresa.ClaveOtros;
        Boolean SSL = VariablesLocales.SesionUsuario.Empresa.HabilitaSslOtros;

        #endregion

        #region Procedimientos de Usuario

        String EnviarCorreo(String To, String CC, String Asunto, String Msg, List<String> Adjunto)
        {
            MailMessage Mensaje = new MailMessage();
            List<String> ListaCC;
            List<String> ListaDestinatarios;
            String MensajeDevuelto = "Correo Enviado...";
            
            try
            {
                ListaDestinatarios = To.Split(';').ToList();

                foreach (String item in ListaDestinatarios)
                {
                    Mensaje.To.Add(new MailAddress(item));  
                }

                //Mensaje.To.Add(new MailAddress(To));
                Mensaje.From = new MailAddress(De);
                Mensaje.Subject = Asunto;
                Mensaje.Body = Msg;
                Mensaje.IsBodyHtml = false;

                //Con copias a otros...
                if (!String.IsNullOrEmpty(CC))
                {
                    ListaCC = CC.Split(';').ToList();

                    foreach (String item in ListaCC)
                    {
                        Mensaje.CC.Add(new MailAddress(item));
                    }
                }

                //Si hay algun archivo adjunto...
                if (Adjunto != null)
                {
                    //Varios
                    foreach (String item in Adjunto)
                    {
                        Mensaje.Attachments.Add(new Attachment(@item, MediaTypeNames.Application.Octet));
                    }

                    //Uno solo
                    //Attachment ArchivoAdjunto = new Attachment(Adjunto, MediaTypeNames.Application.Octet);
                    //Mensaje.Attachments.Add(ArchivoAdjunto);
                }

                //Configuración del servidor saliente...
                using (SmtpClient Smtp = new SmtpClient())
                {
                    try
                    {
                        Smtp.Host = ServidorSalida;
                        Smtp.Port = PuertoSalida;
                        Smtp.Credentials = new NetworkCredential(De, Clave);
                        Smtp.EnableSsl = SSL; //Mercantil estaba en false
                        Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                        Smtp.Send(Mensaje);
                    }
                    catch (SmtpFailedRecipientsException ex)
                    {
                        for (int i = 0; i < ex.InnerExceptions.Length; i++)
                        {
                            SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;

                            if (status == SmtpStatusCode.MailboxBusy || status == SmtpStatusCode.MailboxUnavailable)
                            {
                                Global.MensajeFault("Se ha producido un error en la entrega - Se reintentará nuevamente en 5 segundos.");
                                System.Threading.Thread.Sleep(5000);
                                Smtp.Send(Mensaje);
                            }
                            else
                            {
                                MensajeDevuelto = String.Format("Error al enviar el mensaje a {0}", ex.InnerExceptions[i].FailedRecipient);
                            }
                        }
                    }
                }
            }
            catch (SmtpException exSmtp)
            {
                return "Fallo el envio del correo, por " + exSmtp.Message;
            }

            Mensaje.Dispose();
            return MensajeDevuelto;
        }

        #endregion

        #region Eventos

        private void frmEnvioCorreos_Load(object sender, EventArgs e)
        {
            StringBuilder CadenaMensaje = new StringBuilder();

            try
            {
                #region Pedidos de Ventas o Cotizaciones

                if (oPedido != null)
                {
                    if (oPedido.indCotPed == "P")
                    {
                        CadenaMensaje.Append("Estimados Señores:").Append("\r\n\r\n");
                        CadenaMensaje.Append("Se adjunta el de Pedido N° ").Append(oPedido.codPedidoCad.ToString()).Append(" de ");
                        CadenaMensaje.Append(oPedido.desFacturar).Append(" en formato PDF.");
                        txtMensaje.Text = CadenaMensaje.ToString();
                        CadenaMensaje.Clear();

                        txtAsunto.Text = "Pedido de " + VariablesLocales.SesionUsuario.Empresa.RazonSocial + " N° " + oPedido.codPedidoCad.ToString() + " - " + oPedido.desFacturar;
                    }
                    else
                    {
                        CadenaMensaje.Append("Estimados Señores:").Append("\r\n\r\n");
                        CadenaMensaje.Append("Se adjunta la Cotización N° ").Append(oPedido.codPedidoCad.ToString()).Append(" de ");
                        CadenaMensaje.Append(oPedido.desFacturar).Append(" en formato PDF.");
                        txtMensaje.Text = CadenaMensaje.ToString();
                        CadenaMensaje.Clear();

                        txtAsunto.Text = "Cotización de " + VariablesLocales.SesionUsuario.Empresa.RazonSocial + " N° " + oPedido.codPedidoCad.ToString() + " - " + oPedido.desFacturar;
                    }

                    txtAdjunto.Text = RutaDocumento;
                    codPedidoCad = oPedido.codPedidoCad;

                    List<ContactosCorreosE> oListaCorreos = new GeneralesServiceAgent().Proxy.ListarCorreosPorDefecto(VariablesLocales.SesionUsuario.IdPersona);

                    if (oListaCorreos != null && oListaCorreos.Count > 0)
                    {
                        foreach (ContactosCorreosE item in oListaCorreos)
                        {
                            CadenaMensaje.Append(item.Correo).Append("; ");
                        }

                        txtPara.Text = CadenaMensaje.ToString().Substring(0, CadenaMensaje.ToString().Length - 2);
                    }

                    Persona vendedores = new MaestrosServiceAgent().Proxy.RecuperarPersonaPorID(Convert.ToInt32(oPedido.idVendedor));

                    if (vendedores != null)
                    {
                        txtCC.Text = vendedores.Correo.Trim();
                    }
                }

                #endregion

                #region Ordenes de compra

                if (oOrdenCompra != null)
                {
                    CadenaMensaje.Append("Estimado Señores:").Append("\r\n\r\n");
                    CadenaMensaje.Append("Se adjunta El Orden de Compra N° ").Append(oOrdenCompra.RUC.ToString()).Append(" de ");
                    CadenaMensaje.Append(oOrdenCompra.RazonSocial).Append(" en formato PDF.");
                    txtMensaje.Text = CadenaMensaje.ToString();
                    CadenaMensaje.Clear();

                    txtPara.Text = oOrdenCompra.Correo.ToString();

                    List<ContactosCorreosE> oListaCorreos = new GeneralesServiceAgent().Proxy.ListarCorreosPorDefecto(VariablesLocales.SesionUsuario.IdPersona);

                    if (oListaCorreos != null && oListaCorreos.Count > 0)
                    {
                        foreach (ContactosCorreosE item in oListaCorreos)
                        {
                            CadenaMensaje.Append(item.Correo).Append("; ");
                        }

                        txtPara.Text = CadenaMensaje.ToString().Substring(0, CadenaMensaje.ToString().Length - 2);
                    }

                    //txtCC.Text = "administrador@indusoftperu.com";
                    txtAsunto.Text = "Orden De Compra de " + VariablesLocales.SesionUsuario.Empresa.RazonSocial + " N° " + oOrdenCompra.RUC.ToString();
                    txtAdjunto.Text = RutaDocumento;
                }

                #endregion

                #region Retenciones

                if (oReten != null)
                {
                    CadenaMensaje.Append("Estimado Señores:").Append("\r\n\r\n");
                    CadenaMensaje.Append("Se adjunta la Retención N° ").Append(oReten.serieCompRete.ToString()).Append("-").Append(oReten.numeroCompRete.ToString()).Append(" de ");
                    CadenaMensaje.Append(oReten.DesPersona).Append(" Ruc: ").Append(oReten.RUC.ToString()).Append(" en formato PDF.");
                    txtMensaje.Text = CadenaMensaje.ToString();
                    CadenaMensaje.Clear();

                    txtPara.Text = oReten.Correo.ToString();
                    txtCC.Text = "retencioneselectronicas@viale.com.pe";
                    txtAsunto.Text = "Retencion " + oReten.serieCompRete.ToString()+"-"+ oReten.numeroCompRete.ToString() +" - "+ VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                    txtAdjunto.Text = RutaDocumento;
                }

                #endregion

                #region Requesiciones

                if (oRequisicion != null)
                {
                    CadenaMensaje.Append("Estimado Señores:").Append("\r\n\r\n");
                    CadenaMensaje.Append("Se adjunta la Requisicion con el N° ").Append(oRequisicion.numRequisicion.ToString()).Append(" de ");
                    CadenaMensaje.Append(oRequisicion.Nombre).Append(" en formato PDF.");
                    txtMensaje.Text = CadenaMensaje.ToString();
                    CadenaMensaje.Clear();

                    //txtPara.Text = oRequisicion.Correo.ToString();
                    //txtCC.Text = "administrador@indusoftperu.com";
                    txtAsunto.Text = "Requisicion No. " + oRequisicion.numRequisicion.ToString() + VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                    txtAdjunto.Text = RutaDocumento;

                    List<ContactosCorreosE> oListaCorreos = new GeneralesServiceAgent().Proxy.ListarCorreosPorDefecto(VariablesLocales.SesionUsuario.IdPersona);

                    if (oListaCorreos != null && oListaCorreos.Count > 0)
                    {
                        foreach (ContactosCorreosE item in oListaCorreos)
                        {
                            CadenaMensaje.Append(item.Correo).Append("; ");
                        }

                        txtPara.Text = CadenaMensaje.ToString().Substring(0, CadenaMensaje.ToString().Length - 2);
                    }
                }

                #endregion

                #region Ordenes de Pago

                if (oOrdenPago != null)
                {
                    CadenaMensaje.Append("Estimado Señores:").Append("\r\n\r\n");
                    CadenaMensaje.Append("Se adjunta O.P. con el N° ").Append(oOrdenPago.codOrdenPago).Append(" de ");
                    CadenaMensaje.Append(oOrdenPago.RazonSocial).Append(" en formato PDF.");
                    txtMensaje.Text = CadenaMensaje.ToString();
                    CadenaMensaje.Clear();

                    txtAsunto.Text = "Orden de Pago N° " + oOrdenPago.codOrdenPago + " - " + VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                    txtAdjunto.Text = RutaDocumento;

                    //List<ContactosCorreosE> oListaCorreos = new GeneralesServiceAgent().Proxy.ListarCorreosPorDefecto();

                    //if (oListaCorreos != null && oListaCorreos.Count > 0)
                    //{
                    //    foreach (ContactosCorreosE item in oListaCorreos)
                    //    {
                    //        CadenaMensaje.Append(item.Correo).Append("; ");
                    //    }

                    //    txtPara.Text = CadenaMensaje.ToString().Substring(0, CadenaMensaje.ToString().Length - 2);
                    //}
                }

                #endregion

                #region Liquidaciones

                if (oLiqui != null)
                {
                    CadenaMensaje.Append("Estimado Señores:").Append("\r\n\r\n");
                    CadenaMensaje.Append("Se adjunta la Liquidación con el N° ").Append(oLiqui.idLiquidacion.ToString("0000")).Append(" de ");
                    CadenaMensaje.Append(oLiqui.RazonSocial).Append(" en formato PDF.");
                    txtMensaje.Text = CadenaMensaje.ToString();
                    CadenaMensaje.Clear();

                    txtAsunto.Text = "Liquidación N° " + oLiqui.idLiquidacion.ToString("0000") + " - " + VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                    txtAdjunto.Text = RutaDocumento;
                }

                #endregion

                #region Comisiones Conf.

                if (ocomision != null)
                {
                    CadenaMensaje.Append("Estimado Señores:").Append("\r\n\r\n");
                    CadenaMensaje.Append("Se adjunta con el Nombre de Zona ").Append(ocomision.NombreZona.ToString()).Append(" en formato PDF."); 
                    txtMensaje.Text = CadenaMensaje.ToString();
                    CadenaMensaje.Clear();

                    //txtPara.Text = oRequisicion.Correo.ToString();
                    //txtCC.Text = "administrador@indusoftperu.com";
                    txtAsunto.Text =  VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                    txtAdjunto.Text = RutaDocumento;

                    //List<ContactosCorreosE> oListaCorreos = new GeneralesServiceAgent().Proxy.ListarCorreosPorDefecto();

                    //if (oListaCorreos != null && oListaCorreos.Count > 0)
                    //{
                    //    foreach (ContactosCorreosE item in oListaCorreos)
                    //    {
                    //        CadenaMensaje.Append(item.Correo).Append("; ");
                    //    }

                    //    txtPara.Text = CadenaMensaje.ToString().Substring(0, CadenaMensaje.ToString().Length - 2);
                    //}
                }

                #endregion

                #region EmisionDocumento

                if (oEmi != null)
                {
                    CadenaMensaje.Append("Estimado Señores:").Append("\r\n\r\n");
                    CadenaMensaje.Append("Se adjunta la Guia con el N° ").Append(oEmi.numSerie).Append(oEmi.numDocumento).Append(" de ");
                    CadenaMensaje.Append(oEmi.RazonSocial).Append(" en formato PDF.");
                    txtMensaje.Text = CadenaMensaje.ToString();
                    CadenaMensaje.Clear();

                    txtAsunto.Text = "Guia N° " + oEmi.numSerie + " - " + oEmi.numDocumento + " - " + VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                    txtAdjunto.Text = RutaDocumento;

                    //List<ContactosCorreosE> oListaCorreos = new GeneralesServiceAgent().Proxy.ListarCorreosPorDefecto();

                    //if (oListaCorreos != null && oListaCorreos.Count > 0)
                    //{
                    //    foreach (ContactosCorreosE item in oListaCorreos)
                    //    {
                    //        CadenaMensaje.Append(item.Correo).Append("; ");
                    //    }

                    //    txtPara.Text = CadenaMensaje.ToString().Substring(0, CadenaMensaje.ToString().Length - 2);
                    //}
                }

                #endregion

                #region Ordenes de Trabajo

                if (oOrden != null)
                {
                    CadenaMensaje.Append("Estimado Señores:").Append("\r\n\r\n");
                    CadenaMensaje.Append("Se adjunta El Orden de Trabajo Serv. N° ").Append(oOrden.RUC.ToString()).Append(" de ");
                    CadenaMensaje.Append(oOrden.RazonSocial).Append(" en formato PDF.");
                    txtMensaje.Text = CadenaMensaje.ToString();
                    CadenaMensaje.Clear();

                    //txtPara.Text = oOrdenCompra.Correo.ToString();

                    List<ContactosCorreosE> oListaCorreos = new GeneralesServiceAgent().Proxy.ListarCorreosPorDefecto(VariablesLocales.SesionUsuario.IdPersona);

                    if (oListaCorreos != null && oListaCorreos.Count > 0)
                    {
                        foreach (ContactosCorreosE item in oListaCorreos)
                        {
                            CadenaMensaje.Append(item.Correo).Append("; ");
                        }

                        //txtPara.Text = CadenaMensaje.ToString().Substring(0, CadenaMensaje.ToString().Length - 2);
                    }

                    //txtCC.Text = "administrador@indusoftperu.com";
                    txtAsunto.Text = "Orden De Trabajo " + VariablesLocales.SesionUsuario.Empresa.RazonSocial + " N° " + oOrden.RUC.ToString();
                    txtAdjunto.Text = RutaDocumento;
                }

                #endregion

            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btPara_Click(object sender, EventArgs e)
        {
            frmContactosCorreos oFrm = new frmContactosCorreos(idEmpresa, idPedido, codPedidoCad);
            StringBuilder cadDestinatario = new StringBuilder();

            if (!String.IsNullOrEmpty(txtPara.Text))
            {
                cadDestinatario.Append(txtPara.Text).Append("; ");
            }

            if (oFrm.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(oFrm.Correo))
            {
                cadDestinatario.Append(oFrm.Correo);
                txtPara.Text = cadDestinatario.ToString();
            }
        }

        private void btCC_Click(object sender, EventArgs e)
        {
            frmContactosCorreos oFrm = new frmContactosCorreos(idEmpresa, idPedido, codPedidoCad);
            StringBuilder cadCC = new StringBuilder();

            if (!String.IsNullOrEmpty(txtCC.Text))
            {
                cadCC.Append(txtCC.Text).Append("; ");
            }

            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                cadCC.Append(oFrm.Correo);
                txtCC.Text = cadCC.ToString();
            }
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPara.Text))
            {
                Global.MensajeFault("Debe de ingresar un destinatario...");
                txtPara.Focus();
                return;
            }

            try
            {
                List<String> ListaTemp = txtAdjunto.Text.Split(';').ToList();
                List<String> ListaArchivos = new List<String>();
                String ArchivoAdjunto = String.Empty;
                String MensajeDevuelto = String.Empty;

                foreach (String item in ListaTemp)
                {
                    ArchivoAdjunto = item.Trim().Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, "");

                    if (File.Exists(ArchivoAdjunto))
                    {
                        ListaArchivos.Add(ArchivoAdjunto);
                    }
                }

                MensajeDevuelto = EnviarCorreo(txtPara.Text, txtCC.Text, txtAsunto.Text, txtMensaje.Text, ListaArchivos);

                if (MensajeDevuelto == "Correo Enviado...")
                {
                    Global.MensajeComunicacion(MensajeDevuelto);
                    CorreoEnviado = true;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btAdjuntar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAdjunto.Text.Trim()))
                {
                    txtAdjunto.Text = CuadrosDialogo.BuscarArchivo("Buscar Archivo...");
                }
                else
                {
                    if (Global.MensajeConfirmacion("Desea adjuntar mas archivos.") == DialogResult.Yes)
                    {
                        txtAdjunto.Text += ";\r\n" + CuadrosDialogo.BuscarArchivo("Buscar Archivo...");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }            
        } 

        private void btQuitarAdjunto_Click(object sender, EventArgs e)
        {
            txtAdjunto.Text = String.Empty;
        }

        #endregion Eventos

    }
}
