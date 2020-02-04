using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

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
using ClienteWinForm.Ventas.Reportes;
using ClienteWinForm.Contabilidad.CtasPorPagar;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoFacturasUf : FrmMantenimientoBase
    {

        #region Constructores

        public frmListadoFacturasUf()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvListadoFacturas, true, true, 28, 23, false);
            AnchoColumnas();
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
        String Impresion = "MANTENIMIENTO";

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20452630886") //Solo Fundo San Miguel
            {
                dgvListadoFacturas.Columns[13].Visible = true;
            }
        }

        void EnviarSunat()
        {
            EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionFacturas.Current;

            if (current != null)
            {
                if (current.indEstado == EnumEstadoDocumentos.E.ToString())
                {
                    //EmisionDocumentoE oEmision = AgenteVentas.Proxy.RecuperarDocumentoCompleto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    //OperacionesSunat Archivo = new OperacionesSunat();
                    //List<String> oLista = new List<String>();
                    //Archivo.VersionUbl = VariablesLocales.oVenParametros.idUbl; //Versión del UBL 2.0 ó 2.1 
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
                                                                     where x.Grupo == EnumGrupoDocumentos.F.ToString() 
                                                                     select x).ToList();//AgenteVentas.Proxy.ListarNumControlDetPorGrupo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, EnumGrupoDocumentos.F.ToString());
            return ListaDoc;
        }

        void DevolverMotivoAnulacion(String Titulo, out String Motivo, out String Tipo)
        {
            Motivo = String.Empty;
            Tipo = String.Empty;

            frmTextoLargo oFrm = new frmTextoLargo(Titulo);

            if (oFrm.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(oFrm.Texto))
            {
                Motivo = oFrm.Texto;
                Tipo = oFrm.Tipo;
            }
        }

        Boolean RevisarDocumentosBaja(List<EmisionDocumentoE> oListaTemporal)
        {
            /* Campo EstadoRegistro:
             * BIZLINKS
                L: Pendiente de respuesta
                E: Error de Bizlinks
                P: Procesado: (Para facturas y sus notas asociadas el documento ya ha sido aceptado por SUNAT.
                                Para Boletas y sus notas asociadas indica que fueron procesadas correctamente y 
                                se encuentran listas para ser declaradas a través de un resumen de comprobantes)
                R: Rechazado (El documento ha sido rechazado por SUNAT)
             
             * PARA INDUSOFT:
                L = 1 --Pendiente de respuesta
				E = 2 --Error de Bizlinks
				P = 3 --Procesado
				R = 4 --Rechazado
             
             * Campo EstadoBaja
                N o null: nuevo (está siendo agregado y no será leído por el componente)
                A: Agregado (la data está completa y lista para ser leída)
                L: Leído (el componente de integración ha leído el registro y está siendo procesado)
                E: Error (se encontró un error en la validación local)
            */
            DateTime FechaEmisionAnte = Convert.ToDateTime(oListaTemporal[0].fecEmision);

            foreach (EmisionDocumentoE item in oListaTemporal)
            {
                if (item.indEstado == "B") //Estado en Indusoft
                {
                    if (item.EstadoRegistro == 3) //Estado de Procesado en Bislink
                    {
                        if (item.EstadoBaja == "P") //Estado de Baja en Bislink(Procesado)
                        {
                            Global.MensajeFault(String.Format("El documento {0}-{1} ya esta dado de baja.", item.numSerie, item.numDocumento));
                            return false;
                        }
                        else
                        {
                            if (FechaEmisionAnte == Convert.ToDateTime(item.fecEmision))
                            {
                                FechaEmisionAnte = Convert.ToDateTime(item.fecEmision);
                            }
                            else
                            {
                                Global.MensajeFault(String.Format("Todos los documentos tienen que tener la misma fecha de emisión.", item.numSerie, item.numDocumento));
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if (item.EstadoRegistro == 4)
                        {
                            Global.MensajeFault(String.Format("El documento {0}-{1} ha sido rechazado y ya no puede ser anulado.", item.numSerie, item.numDocumento));
                            return false;
                        }
                        else if (item.EstadoRegistro == 2)
                        {
                            Global.MensajeFault(String.Format("El documento {0}-{1} tiene problemas en Bislink. Revisar", item.numSerie, item.numDocumento));
                            return false;
                        }
                        else if (item.EstadoRegistro == 1)
                        {
                            Global.MensajeFault(String.Format("El documento {0}-{1} ya ha sido enviado y esta pendiente de respuesta.", item.numSerie, item.numDocumento));
                            return false;
                        }
                        else
                        {
                            Global.MensajeFault(String.Format("El documento {0}-{1} no ha sido enviado a Sunat.", item.numSerie, item.numDocumento));
                            return false;
                        }
                    }
                }
                else
                {
                    Global.MensajeFault(String.Format("El documento {0}-{1} tiene que estar anulado en el sistema.", item.numSerie, item.numDocumento));
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEmisionFacturaUf);

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
                    Global.MensajeFault("No se ha configurado ningún item para Facturas en Control de Documentos.");
                    return;
                }

                oFrm = new frmEmisionFacturaUf(oListaNumControlDet)
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
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEmisionFacturaUf);

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
                        oFrm = new frmEmisionFacturaUf(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento, oListaNumControlDet)
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
                dgvListadoFacturas.Focus();

                lblRegistros.Text = "Registros " + bsEmisionFacturas.Count.ToString();
                oListTemp = null;
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
                            if (!((EmisionDocumentoE)bsEmisionFacturas.Current).indCancelacion)
                            {
                                Global.MensajeFault("Falta ingresar la cancelación del documento.");
                                return;
                            }
                        }
                    }

                    Form oFrm = null;
                    String Letra = current.numSerie.Substring(0, 1);

                    if ((Letra == "F" || Letra == "B") && VariablesLocales.oVenParametros.indFacElec)
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmDocumentoElectronicoPDF);
                        Impresion = "WEB";

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmDocumentoElectronicoPDF(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento, "F");
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009" || //AgroGenesis
                             VariablesLocales.SesionUsuario.Empresa.RUC == "20523020561" || //Huerto Genesis
                             VariablesLocales.SesionUsuario.Empresa.RUC == "20517933318" || //Vivero Genesis
                             VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217" || //Jeritec
                             VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681" || //A Y V SEEDS CO. S.A.C.
                             VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410")   //POWER SEEDS S.A.C
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmFacturaGenesis);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmFacturaGenesis(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20523201868")//INTERMETALS
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmFacturaInter);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmFacturaInter(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if(VariablesLocales.SesionUsuario.Empresa.RUC == "20601328179") //FFS
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmFacturaFfs);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmFacturaFfs(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20476115711") //SCINGENIERIA
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteFacturaExportacion);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmReporteFacturaExportacion(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20536039717") //Nevados
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmFacturaNevados);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmFacturaNevados(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20519167434") //WSS
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPrevioFacturaExportacion);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmPrevioFacturaWSS(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20535703214") //FITOCORP
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPrevioFacturaFitocorp);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmPrevioFacturaFitocorp(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20513445700") //Enzo Ferré
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

                        oFrm = new frmFacturaEFerre(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20509606766") //sergensur
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPrevioFacturaSergensur);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmPrevioFacturaSergensur(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else
                    {
                        
                        if (!VariablesLocales.SesionUsuario.Empresa.indCalzado)
                        {
                            oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPrevioFacturaExportacion);

                            if (oFrm != null)
                            {
                                if (oFrm.WindowState == FormWindowState.Minimized)
                                {
                                    oFrm.WindowState = FormWindowState.Normal;
                                }

                                oFrm.BringToFront();
                                return;
                            }

                            oFrm = new frmPrevioFacturaExportacion(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento); 
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

                            oFrm = new frmFacturaEFerre(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
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

        #endregion Procedimientos Heredados

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmEmisionFacturaUf oFrm = sender as frmEmisionFacturaUf;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
                oListaNumControlDet = CargarDocumentos();
            }
        }

        private void oFrmImpresion_FormClosing(Object sender, FormClosingEventArgs e)
        {
        
            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20523201868") //Intermetal
            {
                frmFacturaInter oFrm = sender as frmFacturaInter;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20601328179") //FFS
            {
                frmFacturaFfs oFrm = sender as frmFacturaFfs;

                if (oFrm.DialogResult == DialogResult.OK && oFrm.Emitir)
                {
                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20476115711") //SCIngenieria
            {
                frmReporteFacturaExportacion oFrm = sender as frmReporteFacturaExportacion;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20536039717") //Nevados
            {
                frmFacturaNevados oFrm = sender as frmFacturaNevados;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20519167434") //WSS
            {
                if (Impresion == "WEB")
                {
                    frmDocumentoElectronicoPDF oFrm = sender as frmDocumentoElectronicoPDF;

                    if (oFrm.DialogResult == DialogResult.OK)
                    {
                        if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                        {
                            ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                            bsEmisionFacturas.ResetBindings(false);
                        }
                    }
                }
                else if (Impresion == "MANTENIMIENTO")
                {
                    frmPrevioFacturaWSS oFrm = sender as frmPrevioFacturaWSS;

                    if (oFrm.DialogResult == DialogResult.OK)
                    {
                        if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                        {
                            ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                            bsEmisionFacturas.ResetBindings(false);
                        }
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20535703214") //FITOCORP
            {
                frmPrevioFacturaFitocorp oFrm = sender as frmPrevioFacturaFitocorp;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }

            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20509606766") //SERGENSUR
            {
                frmPrevioFacturaSergensur oFrm = sender as frmPrevioFacturaSergensur;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }

            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20513445700") //ferre
            {
                frmFacturaEFerre oFrm = sender as frmFacturaEFerre;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20513445700") //ferre
            {
                frmFacturaEFerre oFrm = sender as frmFacturaEFerre;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20602659594") //ferre
            {
                frmFacturaEFerre oFrm = sender as frmFacturaEFerre;
                //if (oFrm.DialogResult == DialogResult.OK)
                //{

                    if (((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionFacturas.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                //}
                
            }

            else
            {
                frmFacturaGenesis oFrm = sender as frmFacturaGenesis;

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

        #region Eventos

        private void frmListadoFacturasUf_Load(object sender, EventArgs e)
        {
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            Grid = true;

            Global.CrearToolTip(btCliente, "Buscar Clientes...");
            Global.CrearToolTip(btEmitir, "Emitir Documento (Presionar F11)");
            Global.CrearToolTip(btRevisarEstados, "Revisar Estado de Sunat (Presionar F12)");

            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);

            if (VariablesLocales.oVenParametros.TipoFacturacion == "B") // Todos aquellos envian Factura electronica Fundo San Miguel
            {
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
                                                                             where x.idControl == 1
                                                                             select x).ToList();
                ComboHelper.LlenarCombos<NumControlDetE>(cboSeries, ListaDetalle, "Serie", "Serie");
                cboSeries.Focus();
                ListaDetalle = null;
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

        private void txtIdAuxiliar_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdAuxiliar.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "ID", txtIdAuxiliar.Text);

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
                            dgvListadoFacturas.Focus();
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

        private void dtpInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dgvListadoFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvListadoFacturas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Si se encuentra Emitido
            if ((String)dgvListadoFacturas.Rows[e.RowIndex].Cells["indEstado"].Value == EnumEstadoDocumentos.E.ToString())
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorEmitido;
                }
            }

            if ((Boolean)dgvListadoFacturas.Rows[e.RowIndex].Cells["indVoucher"].Value == true)
            {
                if (e.Value != null)
                {
                    tsmiGenerarVoucher.Enabled = false;
                }
            }
            else
            {
                if (e.Value != null)
                {
                    tsmiGenerarVoucher.Enabled = true;
                }
            }

            //Si se encuentra anulado
            if ((String)dgvListadoFacturas.Rows[e.RowIndex].Cells["indEstado"].Value == EnumEstadoDocumentos.B.ToString())
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }

            //Si se ha enviado a Sunat
            if ((String)dgvListadoFacturas.Rows[e.RowIndex].Cells["indEstado"].Value == EnumEstadoDocumentos.E.ToString() && (Boolean)dgvListadoFacturas.Rows[e.RowIndex].Cells["EnviadoSunat"].Value)
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
                    //EnviarSunat();
                }
                else if (VariablesLocales.oVenParametros.TipoFacturacion == "B")  //Fundo San Miguel y WSS Bizlinks
                {
                    int TipoError = 0;
                    EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionFacturas.Current;
                    Persona oPersona = AgenteMaestro.Proxy.RecuperarPersonaPorID(Convert.ToInt32(current.idPersona));

                    if (oPersona != null)
                    {
                        if (String.IsNullOrEmpty(oPersona.idUbigeo.Trim()))
                        {
                            Global.MensajeFault("Cliente no Tiene Ubigeo.");
                            return;
                        }

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
                    else
                    {
                        if (Global.MensajeConfirmacion(String.Format("Se enviará correo a {0} Conforme S/N", oPersona.Correo)) == DialogResult.No)
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

                    String numLetras = NumeroLetras.enLetras(current.totTotal.ToString());
                    Int32 Resp = AgenteVentas.Proxy.InsertarFacturaElectronica(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento, numLetras, current.EsGuia, current.idPersona.Value);

                    if (Resp > Variables.Cero)
                    {
                        Global.MensajeComunicacion("Se a enviado la factura correctamente");
                        Buscar();
                        btEmitir.PerformClick();
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

        private void tsmiVer_Click(object sender, EventArgs e)
        {
            EmisionDocumentoE oDocumento = (EmisionDocumentoE)bsEmisionFacturas.Current;
            frmRevisarEstadosSunat oFrm = new frmRevisarEstadosSunat(oDocumento);
            oFrm.ShowDialog();
        }

        private void tsmiDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaDocumentos != null && oListaDocumentos.Count > Variables.Cero)
                {
                    List<EmisionDocumentoE> oListaBaja = new List<EmisionDocumentoE>();

                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Aldeasa
                    {
                        //if (Global.MensajeConfirmacion("Desea dar de baja a los documentos seleccionados") == DialogResult.Yes)
                        //{
                        //    frmTextoLargo oFrm = new frmTextoLargo("Motivo de Baja");

                        //    if (oFrm.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(oFrm.Texto))
                        //    {
                        //        foreach (DataGridViewRow Fila in dgvListadoFacturas.Rows)
                        //        {
                        //            if (Fila.Selected)
                        //            {
                        //                if (Fila.Cells[0].Value.ToString() == "E")
                        //                {
                        //                    ((EmisionDocumentoE)Fila.DataBoundItem).MotivoAnulacion = oFrm.Texto;
                        //                    ((EmisionDocumentoE)Fila.DataBoundItem).UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        //                    oListaBaja.Add((EmisionDocumentoE)Fila.DataBoundItem);
                        //                }
                        //                else if (Fila.Cells[0].Value.ToString() == "C")
                        //                {
                        //                    Global.MensajeFault(String.Format("El documento {0}-{1} debe estar emitido antes de dar baja en SUNAT. No se tomara en cuenta.", Fila.Cells[4].Value, Fila.Cells[5].Value));
                        //                }
                        //                else
                        //                {
                        //                    if ((Boolean)Fila.Cells[2].Value && Fila.Cells[0].Value.ToString() == "B")
                        //                    {
                        //                        Global.MensajeFault(String.Format("El documento {0}-{1} ya se encuentra anulado y dado de baja en SUNAT. No se tomara en cuenta.", Fila.Cells[4].Value, Fila.Cells[5].Value));
                        //                    }

                        //                    if (Fila.Cells[0].Value.ToString() == "B" && !(Boolean)Fila.Cells[2].Value)
                        //                    {
                        //                        if (Global.MensajeConfirmacion(String.Format("El documento {0}-{1} se encuentra anulado, pero no ha sido dado de baja en SUNAT. Desea mandarlo ?", Fila.Cells[4].Value, Fila.Cells[5].Value)) == DialogResult.Yes)
                        //                        {
                        //                            ((EmisionDocumentoE)Fila.DataBoundItem).MotivoAnulacion = oFrm.Texto;
                        //                            ((EmisionDocumentoE)Fila.DataBoundItem).UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        //                            oListaBaja.Add((EmisionDocumentoE)Fila.DataBoundItem);
                        //                        }
                        //                    }
                        //                }
                        //            }
                        //        }

                        //        if (oListaBaja.Count > Variables.Cero)
                        //        {
                        //            OperacionesSunat ArchivoBaja = new OperacionesSunat();
                        //            ArchivoBaja.GenerarArchivoBaja(oListaBaja);
                        //            Int32 regActualizados = AgenteVentas.Proxy.DarBajaDocumentosVentasSunat(oListaBaja, VariablesLocales.SesionUsuario.Empresa.RUC);

                        //            if (regActualizados > Variables.Cero)
                        //            {
                        //                Global.MensajeComunicacion(String.Format("Se dieron de baja {0} documentos.", regActualizados.ToString()));
                        //                Buscar();
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        Global.MensajeFault("Tiene que colocar un motivo de anulación para dar de baja...");
                        //    }
                        //}
                    }
                    else if (VariablesLocales.oVenParametros.TipoFacturacion == "B") // BIZLINKS Fundo San Miguel
                    {
                        foreach (DataGridViewRow Fila in dgvListadoFacturas.Rows)
                        {
                            if (Fila.Selected)
                            {
                                oListaBaja.Add((EmisionDocumentoE)Fila.DataBoundItem);
                            }
                        }

                        if (oListaBaja.Count == Variables.Cero)
                        {
                            Global.MensajeComunicacion("No existe ningún registro seleccionado.");
                            return;
                        }

                        if (Global.MensajeConfirmacion("Desea dar de baja a los documentos seleccionados") == DialogResult.Yes)
                        {
                            if (RevisarDocumentosBaja(oListaBaja))
                            {
                                String MotivoAnulacion = String.Empty;
                                String Tipo = "U";

                                foreach (EmisionDocumentoE item in oListaBaja)
                                {
                                    if (Tipo == "U")
                                    {
                                        DevolverMotivoAnulacion("Motivo de Baja", out MotivoAnulacion, out Tipo);
                                        item.MotivoAnulacion = MotivoAnulacion;
                                    }
                                    else
                                    {
                                        item.MotivoAnulacion = MotivoAnulacion;
                                    }

                                    item.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                }

                                Int32 regActualizados = AgenteVentas.Proxy.DarBajaDocumentosVentasSunat(oListaBaja, VariablesLocales.SesionUsuario.Empresa.RUC, "CB");

                                if (regActualizados > Variables.Cero)
                                {
                                    Global.MensajeComunicacion(String.Format("Se dieron de baja {0} documentos.", regActualizados.ToString()));
                                    Buscar();
                                }
                            }
                        }
                    }
                    else //Otras
                    {
                        Global.MensajeFault("No tiene autorización para la Facturación Electrónica.");
                    }

                    oListaBaja = null;
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
                        List<EmisionDocumentoE> oListaDocumentosSunat = new List<EmisionDocumentoE>();

                        if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Aldeasa
                        {
                            //OperacionesSunat ConsultaEstados = new OperacionesSunat();
                            //String Folio = String.Empty;
                            //Int16 Tipo = Variables.Cero;

                            //foreach (EmisionDocumentoE item in bsEmisionFacturas.List)
                            //{
                            //    if (item.EnviadoSunat && item.EstadoSunat < 1)
                            //    {
                            //        Folio = "F" + Global.Derecha(item.numSerie.Trim(), 3) + "-" + Convert.ToInt32(item.numDocumento).ToString();
                            //        Tipo = 1;

                            //        List<String> oListaRespuesta = ConsultaEstados.ConsultarEstados(item.numRuc, Tipo, Folio);

                            //        if (oListaRespuesta.Count > Variables.Cero)
                            //        {
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

                        oListaDocumentosSunat = null;
                    }

                    Buscar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCliente_Click(object sender, EventArgs e)
        {


        } 

        private void btEmitir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsEmisionFacturas.Count > Variables.Cero)
                {
                    Buscar();
                    EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionFacturas.Current;

                    if (current.indEstado == EnumEstadoDocumentos.B.ToString())
                    {
                        Global.MensajeComunicacion("Este documento no se puede emitir porque se encuentra anulado.");
                        return;
                    }

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

                    if (current.indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        String ConCtaCte = Variables.SI;
                        String ConCobranza = Variables.SI;

                        if (VariablesLocales.SesionUsuario.Empresa.RUC == "20452630886") //Fundo San Miguel
                        {
                            ConCtaCte = Variables.NO;
                            ConCobranza = Variables.NO;
                        }

                        AgenteVentas.Proxy.CambiarEstadoDocumento(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento, EnumEstadoDocumentos.E.ToString(),
                                                                    VariablesLocales.SesionUsuario.Credencial, ConCtaCte, ConCobranza);

                        current.indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionFacturas.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void frmListadoFacturasUf_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvListadoFacturas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaDocumentos != null && oListaDocumentos.Count > Variables.Cero)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.ColumnIndex == dgvListadoFacturas.Columns["numSerie"].Index)
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

                    if (e.ColumnIndex == dgvListadoFacturas.Columns["numDocumento"].Index)
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

                    if (e.ColumnIndex == dgvListadoFacturas.Columns["fecEmision"].Index)
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

                    if (e.ColumnIndex == dgvListadoFacturas.Columns["numRuc"].Index)
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

                    if (e.ColumnIndex == dgvListadoFacturas.Columns["RazonSocial"].Index)
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

                    if (e.ColumnIndex == dgvListadoFacturas.Columns["totsubTotal"].Index)
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

                    if (e.ColumnIndex == dgvListadoFacturas.Columns["totIgv"].Index)
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

                    if (e.ColumnIndex == dgvListadoFacturas.Columns["totTotal"].Index)
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

        private void tsmiPdf_Click(object sender, EventArgs e)
        {
            try
            {
                EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionFacturas.Current;
                String UrlFactura = AgenteVentas.Proxy.FacturaElectronicaUrlPdf("6", VariablesLocales.SesionUsuario.Empresa.RUC, current.idDocumento, current.numSerie, current.numDocumento);

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

                    oFrm = new frmPrevioDocElectronico(UrlFactura)
                    {
                        MdiParent = this.MdiParent
                    };

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
            Int32 FilasSeleccionadas = dgvListadoFacturas.Rows.GetRowCount(DataGridViewElementStates.Selected);
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
                            Global.MensajeComunicacion(string.Format("Para el documento {0} {1}-{2} ya se han generado Letras, \r\ncon el Canje {3} {4}", current.idDocumento, current.numSerie, current.numDocumento, oCanjeTemp.tipCanje, oCanjeTemp.codCanje));
                            oListaDocumentos = null;
                            return;
                        }

                        oListaDocumentos.Add(AgenteVentas.Proxy.ObtenerEmisionDocumento(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento));
                    }
                    else
                    {
                        foreach (DataGridViewRow fila in dgvListadoFacturas.Rows)
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

        private void tsmiEliminarVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 idEmpresa = ((EmisionDocumentoE)bsEmisionFacturas.Current).idEmpresa;
                Int32 idLocal = ((EmisionDocumentoE)bsEmisionFacturas.Current).idLocal;
                String idDocumento = ((EmisionDocumentoE)bsEmisionFacturas.Current).idDocumento;
                String numSerie = ((EmisionDocumentoE)bsEmisionFacturas.Current).numSerie;
                String numDocumento = ((EmisionDocumentoE)bsEmisionFacturas.Current).numDocumento;
                String UsuarioRegistro = ((EmisionDocumentoE)bsEmisionFacturas.Current).UsuarioRegistro;

                Int32 Resp = AgenteVentas.Proxy.EliminarVoucherEmiDoc(idEmpresa, idLocal, idDocumento, numSerie, numDocumento, UsuarioRegistro);

                if (Resp > 0)
                {
                    Global.MensajeComunicacion("El Voucher fue eliminado");
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmiGenerarVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsEmisionFacturas.List.Count > 0)
                {
                    Int32 idEmpresa = ((EmisionDocumentoE)bsEmisionFacturas.Current).idEmpresa;
                    Int32 idLocal = ((EmisionDocumentoE)bsEmisionFacturas.Current).idLocal;
                    String idDocumento = ((EmisionDocumentoE)bsEmisionFacturas.Current).idDocumento;
                    String numSerie = ((EmisionDocumentoE)bsEmisionFacturas.Current).numSerie;
                    String numDocumento = ((EmisionDocumentoE)bsEmisionFacturas.Current).numDocumento;
                    String UsuarioRegistro = ((EmisionDocumentoE)bsEmisionFacturas.Current).UsuarioRegistro;

                    if (Global.MensajeConfirmacion("Seguro de Generar Asiento S/N") == DialogResult.Yes)
                    {
                        EmisionDocumentoE oEmision = AgenteVentas.Proxy.GenerarVoucherEmiDoc(idEmpresa, idLocal, idDocumento, numSerie, numDocumento, UsuarioRegistro);
                        if (oEmision != null)
                        {
                            Global.MensajeComunicacion(String.Format("Se generó el Voucher"));
                            Buscar();
                        }
                        else
                        {
                            Global.MensajeFault("Hubo algunos inconvenientes al generar el Voucher");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
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

        private void tsmiCopiarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaDocumentos.Count != 0)
                {
                    EmisionDocumentoE EmisionDoc = (EmisionDocumentoE)bsEmisionFacturas.Current;
                    frmCopiarFacturas oFrm = new frmCopiarFacturas(EmisionDoc);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.EmiDoc != null)
                    {
                        EmisionDocumentoE oEmisionDoc = AgenteVentas.Proxy.GenerarFacturaCopia(EmisionDoc.idEmpresa, EmisionDoc.idLocal, EmisionDoc.idDocumento,EmisionDoc.numDocumento,EmisionDoc.numSerie, oFrm.EmiDocTMP);
                        Global.MensajeComunicacion("La factura se generaro correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void editarDatosVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oListaDocumentos.Count != 0)
            {
                EmisionDocumentoE EmisionDoc = AgenteVentas.Proxy.RecuperarDocumentoCompleto(((EmisionDocumentoE)bsEmisionFacturas.Current).idEmpresa, ((EmisionDocumentoE)bsEmisionFacturas.Current).idLocal,
                                                    ((EmisionDocumentoE)bsEmisionFacturas.Current).idDocumento, ((EmisionDocumentoE)bsEmisionFacturas.Current).numSerie,
                                                    ((EmisionDocumentoE)bsEmisionFacturas.Current).numDocumento);
                frmEditarVendedor oFrm = new frmEditarVendedor(EmisionDoc,"Fact");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.EmiDoc != null)
                {
                    oFrm.EmiDoc = AgenteVentas.Proxy.ActualizarEmisionDocumentoVendedor(oFrm.EmiDoc);
                }
            }

        }

        #endregion Eventos

    }
}
