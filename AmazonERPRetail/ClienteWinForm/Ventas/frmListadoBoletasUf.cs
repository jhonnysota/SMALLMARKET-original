using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Recursos;
using ClienteWinForm.Ventas.Facturacion;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Contabilidad;
using ClienteWinForm.Contabilidad.CtasPorPagar;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoBoletasUf : FrmMantenimientoBase
    {

        #region Constructores

        public frmListadoBoletasUf()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvListado, true, true, 28, 23, false);
            oListaNumControlDet = CargarDocumentos();

            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        List<EmisionDocumentoE> oListaDocumentos = null;
        List<NumControlDetE> oListaNumControlDet = null;
        Boolean Ordenar = false;

        #endregion

        #region Procedimientos de Usuario

        void EnviarSunat()
        {
            if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.E.ToString())
            {
                //EmisionDocumentoE oEmision = AgenteVentas.Proxy.RecuperarDocumentoCompleto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal,
                //                                                            ((EmisionDocumentoE)bsEmisionFacturas.Current).idDocumento, ((EmisionDocumentoE)bsEmisionFacturas.Current).numSerie,
                //                                                            ((EmisionDocumentoE)bsEmisionFacturas.Current).numDocumento);
                //OperacionesSunat Archivo = new OperacionesSunat();
                //List<String> oLista = new List<String>();
                //oLista = Archivo.GenerarFile(oEmision);

                //if (oLista.Count > Variables.Cero)
                //{
                //    if (oLista[0] == Variables.Cero.ToString())
                //    {
                //        oEmision.EnviadoSunat = true;
                //        oEmision.fecEnvioSunat = VariablesLocales.FechaHoy.Date;
                //        oEmision.EstadoRegistro = Convert.ToInt32(oLista[0]);
                //        oEmision.MensajeRegistro = RevisarEstados(Convert.ToInt32(oLista[0])) + String.Empty + oLista[1].ToString();
                //        oEmision.idRegistro = Convert.ToInt32(oLista[2]);
                //        oEmision.EstadoSunat = (Nullable<Int32>)null;
                //        oEmision.MensajeSunat = String.Empty;
                //        oEmision.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                //        AgenteVentas.Proxy.ActualizarDocumentosSunat(oEmision);

                //        Global.MensajeComunicacion("Se ha enviado con éxito el documento al Servidor de Facturación Electrónica.");

                //        ((EmisionDocumentoE)bsEmisionFacturas.Current).EnviadoSunat = true;
                //        bsEmisionFacturas.ResetBindings(false);
                //    }
                //    else
                //    {
                //        String Ruta = @"C:\AmazonErp\Facturas Electronicas\Errores.txt";
                //        //Si existe lo borramos para volverlo a crear...
                //        if (File.Exists(Ruta))
                //        {
                //            File.Delete(Ruta);
                //        }

                //        //Creamos el archivo de errores...
                //        using (StreamWriter sw = new StreamWriter(Ruta))
                //        {
                //            sw.WriteLine(oLista[1]);
                //        }

                //        throw new Exception(oLista[1]);
                //    }
                //}
            }
            else
            {
                throw new Exception("Es obligatorio que el comprobante se encuentre Emitido");
            }
        }

        String RevisarEstados(Int32 Estado)
        {
            String MensajeDevuelto = String.Empty;

            switch (Estado)
            {
                case 0:
                    MensajeDevuelto = "Respuesta Solicitada.\n\r";

                    break;
                case -1:
                    MensajeDevuelto = "Error, archivo Xml inválido.\n\r";

                    break;
                case -2:
                    MensajeDevuelto = "Error, el archivo debe contener solo 1 documento.\n\r";

                    break;
                case -3:
                    MensajeDevuelto = "Error, falta información del emisor.\n\r";

                    break;
                case -4:
                    MensajeDevuelto = "Error, Emisor no registrado.\n\r";

                    break;
                case -5:
                    MensajeDevuelto = "Error al recuperar el Certificado de la Empresa.\n\r";

                    break;
                case -6:
                    MensajeDevuelto = "Error al Foliar el documento.\n\rNo se pudo asignar un correlativo al documento.";

                    break;
                case -8:
                    MensajeDevuelto = "Error al firmar el documento.\n\r";

                    break;
                case -9:
                    MensajeDevuelto = "Error al firmar el envío.\n\r";

                    break;
                case -10:
                    MensajeDevuelto = "Error al enviar documento.\n\r";

                    break;
                case -11:
                    MensajeDevuelto = "Error de conexión DB.\n\r";

                    break;
                case -12:
                    MensajeDevuelto = "Error, documento no encontrado.\n\r.";

                    break;
                case -14:
                    MensajeDevuelto = "Error al validar usuario.\n\r";

                    break;
                case -19:
                    MensajeDevuelto = "Error de Schema.\n\r";

                    break;
                case -98:
                    MensajeDevuelto = "Mensaje de Error.\n\r";

                    break;
                case -99:
                    MensajeDevuelto = "Error, opción de retorno inválida.\n\r";

                    break;
                default:
                    break;
            }

            return MensajeDevuelto;
        }

        List<NumControlDetE> CargarDocumentos()
        {
            List<NumControlDetE> ListaDoc = new List<NumControlDetE>(from x in VariablesLocales.ListaDetalleNumControl
                                                                     where x.Grupo == EnumGrupoDocumentos.B.ToString()
                                                                     select x).ToList();
            return ListaDoc;
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmBoletaUf oFrm = sender as frmBoletaUf;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
                oListaNumControlDet = CargarDocumentos();
            }
        }

        private void oFrmImpresion_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20536039717") //Nevados
            {
                frmBoletasNevados oFrm = sender as frmBoletasNevados;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20535703214") //FITO
            {
                frmBoletasFitocorp oFrm = sender as frmBoletasFitocorp;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20513445700") //ENZOFERRE
            {
                frmBoletasEnzo oFrm = sender as frmBoletasEnzo;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20481894825") //D'Ellas
            {
                frmTicketBoletaDellas oFrm = sender as frmTicketBoletaDellas;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    Buscar();
                }
            }
            else
            {
                frmBoletaGenesis oFrm = sender as frmBoletaGenesis;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        Buscar();
                        //((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        //bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }

            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmBoletaUf);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                if (oListaNumControlDet.Count == Variables.Cero)
                {
                    Global.MensajeFault("No se ha configurado ningún item para Boletas de Ventas en Control de Documentos.");
                    return;
                }

                oFrm = new frmBoletaUf(oListaNumControlDet)
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                if (bsEmisionFacturas.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmBoletaUf);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionFacturas.Current;

                    if (current != null)
                    {
                        oFrm = new frmBoletaUf(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento, oListaNumControlDet)
                        {
                            MdiParent = MdiParent
                        };
                        oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                        oFrm.Show(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsEmisionFacturas.List.Count > 0)
                {
                    EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionFacturas.Current;

                    if (current.indEstado != EnumEstadoDocumentos.B.ToString())
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                        {
                            LetrasCanjeE oCanjeTemp = AgenteVentas.Proxy.LetrasCanjePorDocumento(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);

                            if (oCanjeTemp != null)
                            {
                                Global.MensajeComunicacion(String.Format("No puede Anular el documento {0} {1}-{2}, porque ya tiene Letras generadas con el Canje N° {3} {4}", current.idDocumento, current.numSerie, current.numDocumento, oCanjeTemp.tipCanje, oCanjeTemp.codCanje));
                                oListaDocumentos = null;
                                return;
                            }

                            AgenteVentas.Proxy.CambiarEstadoDocumento(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento, EnumEstadoDocumentos.B.ToString(), VariablesLocales.SesionUsuario.Credencial);
                            Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                            Buscar();
                        }
                    }
                    else
                    {
                        string idDocumentoActual = current.idDocumento;
                        string SerieActual = current.numSerie;
                        string NumeroActual = current.numDocumento;

                        NumControlDetE ControlDetalle = oListaNumControlDet.Find
                        (
                            delegate (NumControlDetE ncd)
                            {
                                return ncd.idDocumento == idDocumentoActual
                                && ncd.Serie == SerieActual;
                            }
                        );

                        if (ControlDetalle != null)
                        {
                            if (idDocumentoActual == ControlDetalle.idDocumento && SerieActual == ControlDetalle.Serie && NumeroActual == ControlDetalle.numCorrelativo)
                            {
                                if (Global.MensajeConfirmacion("Desea eliminar el registro ?") == DialogResult.Yes)
                                {
                                    Int32 resp = AgenteVentas.Proxy.EliminarEmisDocuCompleto(current.idEmpresa, current.idLocal, idDocumentoActual, SerieActual, NumeroActual);

                                    if (resp > Variables.Cero)
                                    {
                                        Global.MensajeComunicacion("El documento se eliminó correctamente");

                                        oListaDocumentos.Remove((EmisionDocumentoE)bsEmisionFacturas.Current);
                                        bsEmisionFacturas.DataSource = oListaDocumentos;
                                        bsEmisionFacturas.ResetBindings(false);

                                        VariablesLocales.ListaDetalleNumControl = AgenteVentas.Proxy.ListarNumControlDetPorEmpresa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
                                        oListaNumControlDet = CargarDocumentos();
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                Global.MensajeFault("El documento no es el último generado. Tiene que empezar desde último, según correlativo.");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                string fecIni;
                string fecFin;
                String Serie = String.Empty;
                Int32 idCliente;
                List<EmisionDocumentoE> ListaTemp = null;

                if (rbTodas.Checked)
                {
                    fecIni = "19000101";
                    fecFin = "29991231";
                }
                else
                {
                    fecIni = dtpInicio.Value.ToString("yyyyMMdd");
                    fecFin = dtpFinal.Value.ToString("yyyyMMdd");
                }

                if (rbTodasSeries.Checked)
                {
                    Serie = "%";
                }
                else
                {
                    Serie = cboSeries.SelectedValue.ToString();
                }

                if (rbTodosCLientes.Checked)
                {
                    idCliente = Variables.Cero;
                }
                else
                {
                    idCliente = !String.IsNullOrEmpty(txtIdAuxiliar.Text) ? Convert.ToInt32(txtIdAuxiliar.Text) : Variables.Cero;
                }

                oListaDocumentos = new List<EmisionDocumentoE>();
                var oListTemp = oListaNumControlDet.GroupBy(x => x.idDocumento).Select(p => p.First()).ToList();

                foreach (NumControlDetE item in oListTemp)
                {
                    ListaTemp = AgenteVentas.Proxy.ListarDocumentosVentas(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, item.idDocumento, idCliente, Serie, fecIni, fecFin);
                    oListaDocumentos.AddRange(ListaTemp);
                }

                bsEmisionFacturas.DataSource = oListaDocumentos;
                bsEmisionFacturas.ResetBindings(false);
                dgvListado.Focus();

                lblRegistros.Text = "Registros " + bsEmisionFacturas.Count.ToString();
                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Imprimir()
        {
            try
            {
                if (bsEmisionFacturas.Count > 0)
                {
                    EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionFacturas.Current;

                    if (current.idCondicion != 0)
                    {
                        CondicionE oCondicion = AgenteVentas.Proxy.ObtenerCondicion(Convert.ToInt32(EnumTipoCondicionVenta.FacBol), Convert.ToInt32(current.idCondicion));

                        if (oCondicion.indCreditoCobranza && Convert.ToDecimal(current.totTotal) > 0)
                        {
                            if (!current.indCancelacion)
                            {
                                Global.MensajeFault("Falta ingresar la cancelación del documento.");
                                return;
                            }
                        }
                    }

                    if (current.indEstado == EnumEstadoDocumentos.B.ToString())
                    {
                        Global.MensajeComunicacion("Este documento no se puede imprimir porque se encuentra anulado.");
                        return;
                    }

                    Form oFrm = null;

                    String Letra = current.numSerie.Substring(0, 1);

                    if ((Letra == "F" || Letra == "B") && VariablesLocales.oVenParametros.indFacElec)
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmDocumentoElectronicoPDF);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmDocumentoElectronicoPDF(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento, "B");

                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009" || //AgroGenesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20523020561" || //Huerto Genesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20517933318" || //Vivero Genesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217" || //Jeritec
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681" || //A Y V SEEDS CO. S.A.C.
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410")   //POWER SEEDS S.A.C
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmBoletaGenesis);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmBoletaGenesis(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20536039717") //Nevados
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmBoletasNevados);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmBoletasNevados(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20535703214") //FITOCORP
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmBoletasFitocorp);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmBoletasFitocorp(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20481894825") //D'Ellas
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTicketBoletaDellas);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        EmisionDocumentoE DocumentoEmitido = AgenteVentas.Proxy.RecuperarDocumentoCompleto(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);

                        oFrm = new frmTicketBoletaDellas(DocumentoEmitido);
                    }
                    else
                    {
                        if (!VariablesLocales.SesionUsuario.Empresa.indCalzado)
                        {
                            oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPreviaBoleta);

                            if (oFrm != null)
                            {
                                if (oFrm.WindowState == FormWindowState.Minimized)
                                {
                                    oFrm.WindowState = FormWindowState.Normal;
                                }

                                oFrm.BringToFront();
                                return;
                            }

                            //oFrm = new frmPreviaBoleta(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento); 
                            oFrm = new frmBoletaGenesis(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                        }
                        else
                        {
                            oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmFacturaEFerre);

                            if (oFrm != null)
                            {
                                if (oFrm.WindowState == FormWindowState.Minimized)
                                {
                                    oFrm.WindowState = FormWindowState.Normal;
                                }

                                oFrm.BringToFront();
                                return;
                            }

                            oFrm = new frmBoletasEnzo(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                        }
                    }

                    oFrm.MdiParent = MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrmImpresion_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarIngresoVentana()
        {
            if (VariablesLocales.TipoCambioDelDia == null)
            {
                Global.MensajeComunicacion("No se ha ingresado el Tipo de Cambio del dia.");
                return false;
            }

            return base.ValidarIngresoVentana();
        }

        #endregion

        #region Eventos

        private void frmListadoBoletasUf_Load(object sender, EventArgs e)
        {
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            Grid = true;

            Global.CrearToolTip(btCliente, "Buscar Clientes...");
            Global.CrearToolTip(btEmitir, "Emitir Documento (Presionar F11)");
            Global.CrearToolTip(btRevisarEstados, "Revisar Estado de Sunat (Presionar F12)");

            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);

            if (VariablesLocales.oVenParametros.TipoFacturacion == "B") // Obligatorio usado en Fundo san miguel y Empresas con Bizlinks
            {
                tsmiResumen.Visible = true;
                tsmiPdf.Visible = true;
            }

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009" || //AgroGenesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20523020561" || //Huerto Genesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20517933318" || //Vivero Genesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217" || //Jeritec
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681" || //A Y V SEEDS CO. S.A.C.
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410")   //POWER SEEDS S.A.C
            {
                Global.CrearToolTip(btInsertaCtaCte, "Ingresar a Cta.Cte.");
                btInsertaCtaCte.Visible = true;
            }
        }

        private void rbDesde_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicio.Enabled = rbDesde.Checked;
            dtpFinal.Enabled = rbDesde.Checked;
        }

        private void rbTodasSeries_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodasSeries.Checked)
            {
                cboSeries.DataSource = null;
                cboSeries.Enabled = false;
            }
            else
            {
                cboSeries.Enabled = true;
                List<NumControlDetE> ListaDetalle = new List<NumControlDetE>(from x in VariablesLocales.ListaDetalleNumControl
                                                                             where x.idControl == 2
                                                                             select x).ToList();
                ComboHelper.LlenarCombos<NumControlDetE>(cboSeries, ListaDetalle, "Serie", "Serie");
                cboSeries.Focus();
                ListaDetalle = null;
            }
        }

        private void rbTodosCLientes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodosCLientes.Checked)
            {
                txtIdAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                btCliente.Enabled = false;
            }
            else
            {
                txtIdAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                btCliente.Enabled = true;
                txtRuc.Focus();
            }
        }

        private void dtpInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtIdAuxiliar_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdAuxiliar.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "ID", txtIdAuxiliar.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRuc.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El ID del Auxiliar ingresado no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtIdAuxiliar.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            dgvListado.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Si se encuentra Emitido
            if ((String)dgvListado.Rows[e.RowIndex].Cells["indEstado"].Value == EnumEstadoDocumentos.E.ToString())
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorEmitido;
                }
            }

            //Si se encuentra Anulado
            if ((String)dgvListado.Rows[e.RowIndex].Cells["indEstado"].Value == EnumEstadoDocumentos.B.ToString())
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }

            //Si se ha enviado a Sunat
            if ((String)dgvListado.Rows[e.RowIndex].Cells["indEstado"].Value == EnumEstadoDocumentos.E.ToString() && (Boolean)dgvListado.Rows[e.RowIndex].Cells["EnviadoSunat"].Value)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorSunat;
                }
            }
        }

        private void tsmiFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(VariablesLocales.SesionUsuario.Empresa.sEmailFe))
                {
                    Global.MensajeFault("Falta definir el Correo Electrónico de la Empresa Emisora.");
                    return;
                }

                if (!Global.RevisarEmail(VariablesLocales.SesionUsuario.Empresa.sEmailFe))
                {
                    Global.MensajeFault("Correo electrónico de la Empresa Emisora no válido.");
                    return;
                }

                if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Aldeasa
                {
                    EnviarSunat();
                }
                else if (VariablesLocales.oVenParametros.TipoFacturacion == "B")  //Fundo San Miguel
                {
                    int TipoError = 0;
                    EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionFacturas.Current;
                    Persona oPersona = AgenteMaestro.Proxy.RecuperarPersonaPorID(Convert.ToInt32(current.idPersona));

                    if (oPersona != null)
                    {
    
                        List<String> Correos = Correos = new List<String>(oPersona.Correo.Split(';'));

                        foreach (String item in Correos)
                        {
                            if (String.IsNullOrEmpty(item.Trim()))
                            {
                                Global.MensajeFault("El cliente no tiene correo electrónico.");
                                TipoError = 1;
                            }

                            if (!Global.RevisarEmail(item.Trim()) && TipoError == 0)
                            {
                                Global.MensajeFault("Correo electrónico no válido.");
                                TipoError = 2;
                            }
                        }
                    }

                    if (TipoError == 1 || TipoError == 2)
                    {
                        if (Global.MensajeConfirmacion("Se enviará al correo de la Empresa Emisora S/N") == DialogResult.No)
                        {
                            return;
                        }
                    }

                    if (current.EnviadoSunat)
                    {
                        Global.MensajeComunicacion("El documento ya ha sido enviado a Sunat.");

                        if (Global.MensajeConfirmacion("Desea Reenviar el Documento S/N") == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            EinvoiceHeaderE oEinvoiceHeader = AgenteVentas.Proxy.ObtenerEinvoiceHeader(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);

                            if (oEinvoiceHeader != null)
                            {
                                if (oEinvoiceHeader.estado == "P")
                                {
                                    Global.MensajeComunicacion("Documento ya Fue Aprobado en Sunat no se puede Reenviar !!");
                                    return;
                                }

                                Int32 Resul = AgenteVentas.Proxy.EliminarEinvoiceHeader(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);

                                if (Resul > 0)
                                {
                                    Global.MensajeComunicacion("Fue eliminado Correctamente !!");
                                }
                            }
                        }
                    }

                    String numLetras = NumeroLetras.enLetras(((EmisionDocumentoE)bsEmisionFacturas.Current).totTotal.ToString());
                    Int32 Resp = AgenteVentas.Proxy.InsertarFacturaElectronica(((EmisionDocumentoE)bsEmisionFacturas.Current).idEmpresa,
                                                                                ((EmisionDocumentoE)bsEmisionFacturas.Current).idLocal,
                                                                                ((EmisionDocumentoE)bsEmisionFacturas.Current).idDocumento,
                                                                                ((EmisionDocumentoE)bsEmisionFacturas.Current).numSerie,
                                                                                ((EmisionDocumentoE)bsEmisionFacturas.Current).numDocumento,
                                                                                numLetras,
                                                                                ((EmisionDocumentoE)bsEmisionFacturas.Current).EsGuia,
                                                                                ((EmisionDocumentoE)bsEmisionFacturas.Current).idPersona.Value);

                    if (Resp > Variables.Cero)
                    {
                        Global.MensajeComunicacion("Se a enviado la Boleta correctamente");
                        btEmitir.PerformClick();
                        Buscar();
                    }
                }
                else //Otras
                {
                    Global.MensajeFault("No tiene autorización para la Facturación Electrónica.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btEmitir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsEmisionFacturas.Count > Variables.Cero)
                {
                    Buscar();

                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.B.ToString())
                    {
                        Global.MensajeComunicacion("Este documento no se puede emitir porque se encuentra anulado.");
                        return;
                    }

                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).idCondicion != 0)
                    {
                        CondicionE oCondicion = AgenteVentas.Proxy.ObtenerCondicion(Convert.ToInt32(EnumTipoCondicionVenta.FacBol), Convert.ToInt32(((EmisionDocumentoE)bsEmisionFacturas.Current).idCondicion));

                        if (oCondicion.indCreditoCobranza && Convert.ToDecimal(((EmisionDocumentoE)bsEmisionFacturas.Current).totTotal) > 0)
                        {
                            if (!((EmisionDocumentoE)bsEmisionFacturas.Current).indCancelacion)
                            {
                                Global.MensajeFault("Falta ingresar la cancelación del documento.");
                                return;
                            }
                        }
                    }

                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        String ConCtaCte = Variables.SI;
                        String ConCobranza = Variables.SI;

                        if (VariablesLocales.SesionUsuario.Empresa.RUC == "20452630886") //Fundo San Miguel
                        {
                            ConCtaCte = Variables.NO;
                            ConCobranza = Variables.NO;
                        }

                        AgenteVentas.Proxy.CambiarEstadoDocumento(((EmisionDocumentoE)bsEmisionFacturas.Current).idEmpresa, ((EmisionDocumentoE)bsEmisionFacturas.Current).idLocal,
                                                                    ((EmisionDocumentoE)bsEmisionFacturas.Current).idDocumento, ((EmisionDocumentoE)bsEmisionFacturas.Current).numSerie,
                                                                    ((EmisionDocumentoE)bsEmisionFacturas.Current).numDocumento, EnumEstadoDocumentos.E.ToString(),
                                                                    VariablesLocales.SesionUsuario.Credencial, ConCtaCte, ConCobranza);

                        ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btRevisarEstados_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaDocumentos != null)
                {
                    if (oListaDocumentos.Count > Variables.Cero)
                    {
                        //OperacionesSunat ConsultaEstados = new OperacionesSunat();
                        String Folio = String.Empty;
                        Int16 Tipo = Variables.Cero;
                        String Serie = String.Empty;
                        List<EmisionDocumentoE> oListaDocumentosSunat = new List<EmisionDocumentoE>();

                        if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Aldeasa
                        {
                            //foreach (EmisionDocumentoE item in bsEmisionFacturas.List)
                            //{
                            //    if (item.EnviadoSunat && item.EstadoSunat < 1)
                            //    {
                            //        Folio = "B" + Global.Derecha(item.numSerie.Trim(), 3) + "-" + Convert.ToInt32(item.numDocumento).ToString();
                            //        Tipo = 3;

                            //        List<String> oListaRespuesta = ConsultaEstados.ConsultarEstados(item.numRuc, Tipo, Folio);

                            //        if (oListaRespuesta.Count > Variables.Cero)
                            //        {
                            //            //item.fecAnuladoSunat = (Nullable<DateTime>)null;
                            //            item.EstadoSunat = Convert.ToInt32(oListaRespuesta[0]);
                            //            item.MensajeSunat = oListaRespuesta[1].ToString();
                            //            item.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                            //            oListaDocumentosSunat.Add(item);

                            //            ((EmisionDocumentoE)bsEmisionFacturas.Current).EstadoSunat = item.EstadoSunat;
                            //            ((EmisionDocumentoE)bsEmisionFacturas.Current).MensajeSunat = item.MensajeSunat;
                            //            ((EmisionDocumentoE)bsEmisionFacturas.Current).UsuarioModificacion = item.UsuarioModificacion;
                            //        }
                            //    }
                            //}

                            //if (oListaDocumentosSunat.Count > Variables.Cero)
                            //{
                            //    Int32 resp = AgenteVentas.Proxy.ActualizarEstadoSunat(oListaDocumentosSunat);

                            //    if (resp > Variables.Cero)
                            //    {
                            //        Global.MensajeComunicacion("Termino la revisión de los estados.");
                            //    }
                            //}
                            //else
                            //{
                            //    Global.MensajeComunicacion("No hay datos para revisar...");
                            //}

                        }
                        else
                        {
                            foreach (EmisionDocumentoE item in bsEmisionFacturas.List)
                            {
                                if (item.EnviadoSunat)// && item.EstadoRegistro < 3)
                                {
                                    oListaDocumentosSunat.Add(item);
                                }
                            }

                            if (oListaDocumentosSunat.Count > Variables.Cero)
                            {
                                Int32 resp = AgenteVentas.Proxy.RecuperarEstadoSunat(oListaDocumentosSunat);

                                if (resp > Variables.Cero)
                                {
                                    Global.MensajeComunicacion("Terminó la revisión de los estados.");
                                }
                            }
                            else
                            {
                                Global.MensajeComunicacion("No hay datos para revisar...");
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmiVer_Click(object sender, EventArgs e)
        {
            EmisionDocumentoE oDocumento = (EmisionDocumentoE)bsEmisionFacturas.Current;
            frmRevisarEstadosSunat oFrm = new frmRevisarEstadosSunat(oDocumento);
            oFrm.ShowDialog();
        }

        private void frmListadoBoletasUf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                btEmitir.PerformClick();
            }

            if (e.KeyCode == Keys.F12)
            {
                btRevisarEstados.PerformClick();
            }
        }

        private void dgvListado_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaDocumentos != null && oListaDocumentos.Count > Variables.Cero)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.ColumnIndex == dgvListado.Columns["numSerie"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.numSerie ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.numSerie descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["numDocumento"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.numDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.numDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["fecEmision"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.fecEmision ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.fecEmision descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["numRuc"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.numRuc ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.numRuc descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["RazonSocial"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.RazonSocial ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.RazonSocial descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["totsubTotal"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.totsubTotal ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.totsubTotal descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["totIgv"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.totIgv ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.totIgv descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["totTotal"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.totTotal ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.totTotal descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                }

                bsEmisionFacturas.DataSource = oListaDocumentos;
            }
        }

        private void tsmiDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaDocumentos != null && oListaDocumentos.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion("Desea dar de baja a los documentos seleccionados") == DialogResult.Yes)
                    {
                        frmTextoLargo oFrm = new frmTextoLargo("Motivo de Baja");

                        if (oFrm.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(oFrm.Texto))
                        {
                            List<EmisionDocumentoE> oListaBaja = new List<EmisionDocumentoE>();

                            foreach (DataGridViewRow Fila in dgvListado.Rows)
                            {
                                if (Fila.Selected)
                                {
                                    if (Fila.Cells[0].Value.ToString() == "E")
                                    {
                                        ((EmisionDocumentoE)Fila.DataBoundItem).MotivoAnulacion = oFrm.Texto;
                                        ((EmisionDocumentoE)Fila.DataBoundItem).UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                        oListaBaja.Add((EmisionDocumentoE)Fila.DataBoundItem);
                                    }
                                    else if (Fila.Cells[0].Value.ToString() == "C")
                                    {
                                        Global.MensajeFault(String.Format("El documento {0}-{1} debe estar emitido antes de dar baja en SUNAT. No se tomara en cuenta.", Fila.Cells[4].Value, Fila.Cells[5].Value));
                                    }
                                    else
                                    {
                                        if ((Boolean)Fila.Cells[2].Value && Fila.Cells[0].Value.ToString() == "B")
                                        {
                                            Global.MensajeFault(String.Format("El documento {0}-{1} ya se encuentra anulado y dado de baja en SUNAT. No se tomara en cuenta.", Fila.Cells[4].Value, Fila.Cells[5].Value));
                                        }

                                        if (Fila.Cells[0].Value.ToString() == "B" && !(Boolean)Fila.Cells[2].Value)
                                        {
                                            if (Global.MensajeConfirmacion(String.Format("El documento {0}-{1} se encuentra anulado, pero no ha sido dado de baja en SUNAT. Desea mandarlo ?", Fila.Cells[4].Value, Fila.Cells[5].Value)) == DialogResult.Yes)
                                            {
                                                ((EmisionDocumentoE)Fila.DataBoundItem).MotivoAnulacion = oFrm.Texto;
                                                ((EmisionDocumentoE)Fila.DataBoundItem).UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                                oListaBaja.Add((EmisionDocumentoE)Fila.DataBoundItem);
                                            }
                                        }
                                    }
                                }
                            }

                            if (oListaBaja.Count > Variables.Cero)
                            {
                                //OperacionesSunat ArchivoBaja = new OperacionesSunat();
                                //ArchivoBaja.GenerarArchivoBaja(oListaBaja);
                                //Int32 regActualizados = AgenteVentas.Proxy.DarBajaDocumentosVentasSunat(oListaBaja);

                                //if (regActualizados > Variables.Cero)
                                //{
                                //    Global.MensajeComunicacion(String.Format("Se dieron de baja {0} documentos.", regActualizados.ToString()));
                                //    Buscar();
                                //}
                            }
                        }
                        else
                        {
                            Global.MensajeFault("Tiene que colocar un motivo de anulación para dar de baja...");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiResumen_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListado.Rows.Count > Variables.Cero)
                {
                    //DateTime FechaEnvio = oListaDocumentos[dgvListado.CurrentRow.Index].fecEmision;
                    //List<String> oListaNoEnviados = new List<String>();
                    //List<String> oListaEnviados = new List<String>();
                    //Boolean MismaFecha = true;
                    //String SerieEnviar = String.Empty;

                    //foreach (DataGridViewRow Fila in dgvListado.Rows)
                    //{
                    //    if (Fila.Selected)
                    //    {
                    //        if (((EmisionDocumentoE)Fila.DataBoundItem).fecEmision.Date == FechaEnvio.Date)
                    //        {
                    //            if (!((EmisionDocumentoE)Fila.DataBoundItem).EnviadoSunat)
                    //            {
                    //                oListaNoEnviados.Add(((EmisionDocumentoE)Fila.DataBoundItem).numDocumento);
                    //            }
                    //            else
                    //            {
                    //                oListaEnviados.Add(((EmisionDocumentoE)Fila.DataBoundItem).numDocumento);
                    //                SerieEnviar = ((EmisionDocumentoE)Fila.DataBoundItem).numSerie;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            MismaFecha = false;
                    //        }
                    //    }
                    //}

                    //if (MismaFecha)
                    //{

                    //    if (oListaNoEnviados.Count == Variables.Cero && oListaEnviados.Count > Variables.Cero)
                    //    {
                    //        String Desde = oListaEnviados[0];
                    //        String Hasta = oListaEnviados[oListaEnviados.Count - 1];

                    //        if (Global.MensajeConfirmacion(String.Format("Enviar Resumen Serie {0} Desde {1} Hasta {2} con fecha {3}", SerieEnviar , Desde, Hasta, FechaEnvio.ToString("d"))) == DialogResult.Yes)
                    //        {
                    //            Int32 idEmpresa = Convert.ToInt32(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                    //            Int32 Respuesta = AgenteVentas.Proxy.ResumenBoletas(idEmpresa, FechaEnvio.ToString("yyyy-MM-dd"), SerieEnviar, Desde, Hasta);

                    //            if (Respuesta > Variables.Cero)
                    //            {
                    //                Global.MensajeComunicacion("Resumen enviado correctamente.");
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        Global.MensajeComunicacion("Todos los documentos con la misma fecha de emisión previamente tienen que haber sido enviados a Sunat.");
                    //    }

                    //}
                    //else
                    //{
                    //    Global.MensajeComunicacion("Todos los documentos seleccionados deben pertener a la misma fecha ");
                    //}
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiPdf_Click(object sender, EventArgs e)
        {
            try
            {
                String UrlFactura = AgenteVentas.Proxy.FacturaElectronicaUrlPdf("6", VariablesLocales.SesionUsuario.Empresa.RUC, ((EmisionDocumentoE)bsEmisionFacturas.Current).idDocumento,
                                                                                ((EmisionDocumentoE)bsEmisionFacturas.Current).numSerie, ((EmisionDocumentoE)bsEmisionFacturas.Current).numDocumento);

                if (!String.IsNullOrEmpty(UrlFactura))
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPrevioDocElectronico);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmPrevioDocElectronico(UrlFactura);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmiGenerarLetras_Click(object sender, EventArgs e)
        {
            Int32 FilasSeleccionadas = dgvListado.Rows.GetRowCount(DataGridViewElementStates.Selected);
            List<EmisionDocumentoE> oListaDocumentos = new List<EmisionDocumentoE>();
            List<CondicionDiasE> ListaDias = null;
            EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionFacturas.Current;

            try
            {
                if (FilasSeleccionadas > 0 && current != null)
                {
                    LetrasCanjeE oCanjeTemp = null;

                    if (FilasSeleccionadas == 1)
                    {
                        if (current.indEstado != EnumEstadoDocumentos.E.ToString())
                        {
                            Global.MensajeComunicacion("Solo se puede generar letras en documentos Emitidos.");
                            oListaDocumentos = null;
                            return;
                        }

                        if (current.totsubTotal == 0 && current.totTotal == 0)
                        {
                            Global.MensajeComunicacion("Solo se puede generar letras en documentos con valores mayores que cero.");
                            oListaDocumentos = null;
                            return;
                        }

                        oCanjeTemp = AgenteVentas.Proxy.LetrasCanjePorDocumento(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                        if (oCanjeTemp != null)
                        {
                            Global.MensajeComunicacion(string.Format("Para el documento {0} {1}-{2} ya se han generado Letras, \r\ncon el Canje {3} {4}",
                                                                    current.idDocumento, current.numSerie, current.numDocumento, oCanjeTemp.tipCanje, oCanjeTemp.codCanje));
                            oListaDocumentos = null;
                            return;
                        }

                        oListaDocumentos.Add(AgenteVentas.Proxy.ObtenerEmisionDocumento(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento));
                    }
                    else
                    {
                        foreach (DataGridViewRow fila in dgvListado.Rows)
                        {
                            if (fila.Selected)
                            {
                                if (((EmisionDocumentoE)fila.DataBoundItem).indEstado != EnumEstadoDocumentos.E.ToString())
                                {
                                    Global.MensajeComunicacion(string.Format("El documento {0} {1}-{2} no se encuentra emitido.", ((EmisionDocumentoE)fila.DataBoundItem).idDocumento,
                                                                                                                                    ((EmisionDocumentoE)fila.DataBoundItem).numSerie,
                                                                                                                                    ((EmisionDocumentoE)fila.DataBoundItem).numDocumento));
                                    oListaDocumentos = null;
                                    return;
                                }

                                if (((EmisionDocumentoE)fila.DataBoundItem).totsubTotal == 0 && ((EmisionDocumentoE)fila.DataBoundItem).totIgv == 0 && ((EmisionDocumentoE)fila.DataBoundItem).totTotal == 0)
                                {
                                    Global.MensajeComunicacion(string.Format("El documento {0} {1}-{2} tiene valores 0.", ((EmisionDocumentoE)fila.DataBoundItem).idDocumento,
                                                                                                                        ((EmisionDocumentoE)fila.DataBoundItem).numSerie,
                                                                                                                        ((EmisionDocumentoE)fila.DataBoundItem).numDocumento));
                                    oListaDocumentos = null;
                                    return;
                                }

                                oCanjeTemp = AgenteVentas.Proxy.LetrasCanjePorDocumento(((EmisionDocumentoE)fila.DataBoundItem).idEmpresa, ((EmisionDocumentoE)fila.DataBoundItem).idLocal,
                                                                                        ((EmisionDocumentoE)fila.DataBoundItem).idDocumento, ((EmisionDocumentoE)fila.DataBoundItem).numSerie,
                                                                                        ((EmisionDocumentoE)fila.DataBoundItem).numDocumento);
                                if (oCanjeTemp != null)
                                {
                                    Global.MensajeComunicacion(string.Format("Para el documento {0} {1}-{2} ya se han generado Letras, \r\ncon el Canje {3} {4}",
                                                                            ((EmisionDocumentoE)fila.DataBoundItem).idDocumento, ((EmisionDocumentoE)fila.DataBoundItem).numSerie,
                                                                            ((EmisionDocumentoE)fila.DataBoundItem).numDocumento, oCanjeTemp.tipCanje, oCanjeTemp.codCanje));
                                    oListaDocumentos = null;
                                    return;
                                }

                                oListaDocumentos.Add(AgenteVentas.Proxy.ObtenerEmisionDocumento(((EmisionDocumentoE)fila.DataBoundItem).idEmpresa, ((EmisionDocumentoE)fila.DataBoundItem).idLocal,
                                                                                                ((EmisionDocumentoE)fila.DataBoundItem).idDocumento, ((EmisionDocumentoE)fila.DataBoundItem).numSerie,
                                                                                                ((EmisionDocumentoE)fila.DataBoundItem).numDocumento));
                            }
                        }

                        var ListaTemp = oListaDocumentos.GroupBy(x => x.RazonSocial).Select(p => p.First()).ToList();

                        if (ListaTemp.ToList().Count > 1)
                        {
                            Global.MensajeComunicacion("Para la generación de Letras tienen que ser del mismo cliente.");
                            oListaDocumentos = null;
                            return;
                        }

                        ListaTemp = null;
                        oListaDocumentos = AgenteVentas.Proxy.ListarDocumentosCanje(oListaDocumentos);
                    }

                    EmisionDocumentoE TempDias = (from d in oListaDocumentos
                                                  where d.fecEmision == (oListaDocumentos.Min(x => x.fecEmision))
                                                  select d).SingleOrDefault();

                    ListaDias = AgenteVentas.Proxy.ListarCondicionDias(Convert.ToInt32(TempDias.idTipCondicion), Convert.ToInt32(TempDias.idCondicion));

                    if (VariablesLocales.TipoCambioDelDia == null)
                    {
                        Global.MensajeFault("No se ha ingresado aun el Tipo de Cambio del dia.");
                        oListaDocumentos = null;
                        return;
                    }

                    if (oListaDocumentos != null && oListaDocumentos.Count > 0)
                    {
                        //se localiza el formulario buscandolo entre los forms abiertos 
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLetrasCanje);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            //si la instancia existe la pongo en primer plano
                            oFrm.BringToFront();
                            return;
                        }

                        //sino existe la instancia se crea una nueva
                        oFrm = new frmLetrasCanje(oListaDocumentos, ListaDias)
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btInsertaCtaCte_Click(object sender, EventArgs e)
        {
            try
            {
                CtaCteE oCtaCteDoc = AgenteTesoreria.Proxy.ObtenerMaeCtaCtePorDocumento(((EmisionDocumentoE)bsEmisionFacturas.Current).idEmpresa,
                                                                                        ((EmisionDocumentoE)bsEmisionFacturas.Current).idDocumento,
                                                                                        ((EmisionDocumentoE)bsEmisionFacturas.Current).numSerie,
                                                                                        ((EmisionDocumentoE)bsEmisionFacturas.Current).numDocumento);

                if (oCtaCteDoc == null)
                {
                    Int32 resp = AgenteVentas.Proxy.IngresarDocCtaCte(((EmisionDocumentoE)bsEmisionFacturas.Current).idEmpresa, ((EmisionDocumentoE)bsEmisionFacturas.Current).idLocal,
                                                                    ((EmisionDocumentoE)bsEmisionFacturas.Current).idDocumento, ((EmisionDocumentoE)bsEmisionFacturas.Current).numSerie,
                                                                    ((EmisionDocumentoE)bsEmisionFacturas.Current).numDocumento, VariablesLocales.SesionUsuario.Credencial);

                    if (resp > 0)
                    {
                        Global.MensajeFault("Documento ingresado a la Cta.Cte. correctamente.");
                    }
                }
                else
                {
                    Global.MensajeFault("El documento ya se encuentra en la Cta.Cte.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkAnticipos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnticipos.Checked)
            {
                Buscar();
                bsEmisionFacturas.DataSource = oListaDocumentos = (from x in oListaDocumentos where x.EsAnticipo == true && x.indEstado == "B" select x).ToList();
                bsEmisionFacturas.ResetBindings(false);
            }
            else
            {
                Buscar();
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == "B")
                {
                    Int32 resp = AgenteVentas.Proxy.EliminarAnticipoAnulados((EmisionDocumentoE)bsEmisionFacturas.Current);

                    if (resp > 0)
                    {
                        Global.MensajeComunicacion("Anticipo quitado");
                    }
                }
                else
                {
                    Global.MensajeComunicacion("El documento tiene que estar anulado de quitar el Anticipo");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiVendedor_Click(object sender, EventArgs e)
        {
            if (oListaDocumentos.Count != 0)
            {
                EmisionDocumentoE EmisionDoc = AgenteVentas.Proxy.RecuperarDocumentoCompleto(((EmisionDocumentoE)bsEmisionFacturas.Current).idEmpresa, ((EmisionDocumentoE)bsEmisionFacturas.Current).idLocal,
                                                    ((EmisionDocumentoE)bsEmisionFacturas.Current).idDocumento, ((EmisionDocumentoE)bsEmisionFacturas.Current).numSerie,
                                                    ((EmisionDocumentoE)bsEmisionFacturas.Current).numDocumento);
                frmEditarVendedor oFrm = new frmEditarVendedor(EmisionDoc,"Vendedor");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.EmiDoc != null)
                {
                    oFrm.EmiDoc = AgenteVentas.Proxy.ActualizarEmisionDocumentoVendedor(oFrm.EmiDoc);
                }
            }
        }

        #endregion Eventos

    }
}
