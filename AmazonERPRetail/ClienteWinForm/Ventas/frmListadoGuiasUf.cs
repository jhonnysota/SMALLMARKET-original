﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Recursos;
using ClienteWinForm.Ventas.Facturacion;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Maestros;

using iTextSharp.text;
using iTextSharp.text.pdf;
using ClienteWinForm.Contabilidad;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoGuiasUf : FrmMantenimientoBase
    {

        #region Constructores

        public frmListadoGuiasUf()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new System.Drawing.Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvListadoGuias, true, true, 28, 23, false);
            AnchoColumnas();
            oListaNumControlDet = CargarDocumentos();
        }

        #endregion Constructores

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<EmisionDocumentoE> oListaDocumentos = null;
        List<NumControlDetE> oListaNumControlDet = null;
        Boolean Ordenar = false;
        String RutaPdf = String.Empty;
        String RutaImagen = @"C:\AmazonErp\Logo\";

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvListadoGuias.Columns[0].Width = 26; //Estado
            dgvListadoGuias.Columns[1].Width = 26; //Enviado a Sunat
            dgvListadoGuias.Columns[2].Width = 26; //Anulado en Sunat
            dgvListadoGuias.Columns[3].Width = 25; //TD
            dgvListadoGuias.Columns[4].Width = 40; //Serie
            dgvListadoGuias.Columns[5].Width = 75; //NUmero
            dgvListadoGuias.Columns[6].Width = 70; //fecEmision
            dgvListadoGuias.Columns[7].Width = 90; //Ruc
            dgvListadoGuias.Columns[8].Width = 300; //Razon Social
            dgvListadoGuias.Columns[9].Width = 30; //Moneda
            dgvListadoGuias.Columns[10].Width = 150; //Afectacion de Igv
            dgvListadoGuias.Columns[11].Width = 50; // Tipo de Cambio
            //dgvListadoGuias.Columns[12].Width = 70; //Total
            dgvListadoGuias.Columns[12].Width = 150; //Descripcion de Traslado
            dgvListadoGuias.Columns[13].Width = 70; // Fecha Despacho
            dgvListadoGuias.Columns[14].Width = 25; //Es guia

            dgvListadoGuias.Columns[15].Width = 90; //Usuario Registro
            dgvListadoGuias.Columns[16].Width = 120; //Fecha Registro
            dgvListadoGuias.Columns[17].Width = 90; //Usuario Modificacion
            dgvListadoGuias.Columns[18].Width = 120; //Fecha Modificacion

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292")
            {
                dgvListadoGuias.Columns[13].Visible = false;
            }
        }

        void EnviarSunat()
        {
            if (((EmisionDocumentoE)bsEmisionGuias.Current).indEstado == EnumEstadoDocumentos.E.ToString())
            {
                //EmisionDocumentoE oEmision = AgenteVentas.Proxy.RecuperarDocumentoCompleto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal,
                //                                                            ((EmisionDocumentoE)bsEmisionGuias.Current).idDocumento, ((EmisionDocumentoE)bsEmisionGuias.Current).numSerie,
                //                                                            ((EmisionDocumentoE)bsEmisionGuias.Current).numDocumento);
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

                //        ((EmisionDocumentoE)bsEmisionGuias.Current).EnviadoSunat = true;
                //        bsEmisionGuias.ResetBindings(false);
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
                                                                     where x.Grupo == EnumGrupoDocumentos.G.ToString()
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

        void CrearPdf(EmisionDocumentoE oEmision)
        {
            try
            {
                if (bsEmisionGuias.Count > 0)
                {
                    if (((EmisionDocumentoE)bsEmisionGuias.Current).indEstado == EnumEstadoDocumentos.B.ToString())
                    {
                        Global.MensajeComunicacion("Este documento no se puede Enviar porque se encuentra anulado.");
                        return;
                    }

                    Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
                    String NombreReporte = "Guias De Remisión";
                    String Extension = ".pdf";
                    String TituloCabecera = String.Empty;

                    RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

                    //Creando el directorio sino existe...
                    if (!Directory.Exists(RutaPdf))
                    {
                        Directory.CreateDirectory(RutaPdf);
                    }

                    DocumentoPdf.AddAuthor("AMAZONTIC SAC");
                    DocumentoPdf.AddCreator("AMAZONTIC SAC");
                    DocumentoPdf.AddCreationDate();
                    DocumentoPdf.AddTitle("Pedidos");
                    DocumentoPdf.AddSubject("Pedidos");

                    if (!String.IsNullOrEmpty(RutaPdf.Trim()))
                    {
                        //Para la creacion del archivo pdf
                        RutaPdf += NombreReporte + Extension;

                        if (File.Exists(RutaPdf))
                        {
                            File.Delete(RutaPdf);
                        }

                        using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                        {
                            //Decimal Total = Variables.Cero;
                            BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
                            iTextSharp.text.Font FuenteEstandar = FontFactory.GetFont("Arial", 6.25f);
                            PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                            PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                            oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                            oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                            if (DocumentoPdf.IsOpen())
                            {
                                DocumentoPdf.CloseDocument();
                            }

                            DocumentoPdf.Open();

                            #region Encabezado

                            float[] AnchoColumnas = new float[] { 0.7f, 0.35f };
                            PdfPTable Tabla = new PdfPTable(2)
                            {
                                WidthPercentage = 100
                            };

                            Tabla.SetWidths(AnchoColumnas);
                            PdfPCell CeldaImagen = null;

                            if (File.Exists(RutaImagen))
                            {
                                switch (VariablesLocales.SesionUsuario.Empresa.RUC)
                                {
                                    case "20502647009": //AgroGenesis - HuertoGenesis - Viveros - Jeritec - AyV Seeds - Power Seeds
                                    case "20523020561":
                                    case "20517933318":
                                    case "20552695217":
                                    case "20552186681":
                                    case "20552690410":
                                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 200f, 1, "N"));
                                        break;
                                    default: //Otras Empresas...
                                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 200f, 1, "N"));
                                        break;
                                }
                            }
                            else
                            {
                                CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
                            }

                            CeldaImagen.Rowspan = 4;
                            Tabla.AddCell(CeldaImagen);

                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 2, 2, "S", "N"));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda("R.U.C. N° " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "S", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 2, 2, "N"));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda("GUIA DE REMISION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 14.25f, iTextSharp.text.Font.BOLD), 1, 1));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda(oEmision.numSerie + " - " + "N° " + oEmision.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 12.25f, iTextSharp.text.Font.BOLD), 1, 1));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda("Fecha de Emisión : " + oEmision.fecEmision, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ".ToUpper(), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2"));
                            Tabla.CompleteRow();

                            DocumentoPdf.Add(Tabla);

                            #endregion Encabezado

                            #region SubTitulos

                            Tabla = new PdfPTable(4)
                            {
                                WidthPercentage = 100
                            };
                            Tabla.SetWidths(new float[] { 0.15f, 0.35f, 0.15f, 0.35f });

                            Tabla.AddCell(ReaderHelper.NuevaCelda("Punto de Partida: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(oEmision.PuntoPartida, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                            Tabla.AddCell(ReaderHelper.NuevaCelda("Punto de Llegada: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(oEmision.PuntoLlegada, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "S4"));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda("Fecha De Inicio Del Traslado: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(oEmision.fecTraslado.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                            Tabla.AddCell(ReaderHelper.NuevaCelda("Nombre, denominación o razón social del destinatario: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(oEmision.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda("Costo Mínimo: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                            Tabla.AddCell(ReaderHelper.NuevaCelda("RUC/DNI: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(oEmision.numRuc, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "S4"));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda("UNIDAD DE TRANSPORTE Y CONDUCTOR(ES) ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2"));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2"));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 1f), 1, 1, "S2", "N", 2, 2, "N", "N"));
                            Tabla.AddCell(ReaderHelper.NuevaCelda("EMPRESA DE TRANSPORTES ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2"));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda("Marca y Número de Placa: " + oEmision.MarcaTransp + " " + oEmision.PlacaTransp, null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S2", "N", 2, 2, "N", "N"));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 1f), 1, 1, "S2", "N", 2, 2, "N", "N"));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S2", "N", 2, 2, "N", "N"));
                            Tabla.AddCell(ReaderHelper.NuevaCelda("Nombre, Denominacion o Razon Social: ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S2", "N", 2, 2, "N", "N"));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda("N° de Constancia de Inscripción: " + oEmision.inscripTransp, null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S2", "N", 2, 2, "N", "N"));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(oEmision.RazonSocialTransp, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S2", "N", 2, 2, "N", "N"));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 1f), 1, 1, "S2", "N", 2, 2, "N", "N"));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 1f), 1, 1, "S2", "N", 2, 2, "N", "N"));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda("N°(s) de Licencia de Conducir: " + oEmision.LicenciaTransp, null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S2", "N", 2, 2, "N", "N"));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 1f), 1, 1, "S2", "N", 2, 2, "N", "N"));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 1f), 1, 1, "S2", "N", 2, 2, "N", "N"));
                            Tabla.AddCell(ReaderHelper.NuevaCelda("N° de RUC : " + oEmision.RucTransp, null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S2", "N", 2, 2, "N", "N"));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 1f), 1, 1, "S2", "N", 2, 2, "N"));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 1f), 1, 1, "S2", "N", 2, 2, "N"));
                            Tabla.CompleteRow();

                            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "S4"));
                            Tabla.CompleteRow();

                            DocumentoPdf.Add(Tabla);

                            #endregion SubTitulos

                            #region Detalle

                            Tabla = new PdfPTable(4);
                            Tabla.WidthPercentage = 100;
                            Tabla.SetWidths(new float[] { 0.1f, 0.7f, 0.1f, 0.1f });

                            Tabla.AddCell(ReaderHelper.NuevaCelda("CANTIDAD PEDIDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                            Tabla.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                            Tabla.AddCell(ReaderHelper.NuevaCelda("UNIDAD DE MEDIDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                            Tabla.AddCell(ReaderHelper.NuevaCelda("PESO TOTAL", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                            Tabla.CompleteRow();

                            foreach (EmisionDocumentoDetE item in oEmision.ListaItemsDocumento)
                            {
                                Tabla.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N0"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                                Tabla.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                                Tabla.AddCell(ReaderHelper.NuevaCelda(item.desUMedida, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                                Tabla.AddCell(ReaderHelper.NuevaCelda(item.PesoBrutoCad, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));

                                Tabla.CompleteRow();
                            }

                            if (oEmision.idDocumento == EnumTipoDocumentoVenta.GV.ToString())
                            {
                                Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S4"));
                                Tabla.CompleteRow();
                                Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S4"));
                                Tabla.CompleteRow();

                                Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                                Tabla.AddCell(ReaderHelper.NuevaCelda("Atención: " + oEmision.Glosa, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                                Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                                Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));

                                Tabla.CompleteRow();

                            }
                            else
                            {
                                Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S4"));
                                Tabla.CompleteRow();
                            }

                            #endregion Detalle

                            DocumentoPdf.Add(Tabla);

                            #region Final
                            String[] LANGUAGES_gc = { "1.Venta", "2.Compra", "3.Transformación", "4.Consignación" };
                            String[] LANGUAGES_gc2 = { "5.Devolución", "6.Trasl. entre establecimientos de una misma empresa", "7.Trasl. por emisor itinerante de comp." };
                            String[] LANGUAGES_gc3 = { "8.Exportación", "9.Importación", "10.Venta sujeta a confirmar", "11. Otros......................................" };
                            String[] Comprobante = { "Comprobante de Pago" };
                            String Factura = string.Empty;
                            foreach (CanjeGuiasE item in oEmision.ListaCanjeGuias)
                            {
                                Factura = item.numSerieFact + " - " + item.numDocumentoFact;
                            }
                            String[] Tipo = { "Tipo : " + Factura };
                            String[] Motivo = { "Motivo de Traslado" };
                            String[] Numero = { "Número : " + oEmision.numSerie };
                            PdfContentByte cb = oPdfw.DirectContent;
                            iTextSharp.text.Rectangle _rect;
                            //iTextSharp.text.pdf.PdfFormField _Field1;

                            //PdfAppearance[] onOff = new PdfAppearance[2];
                            //onOff[0] = cb.CreateAppearance(20, 20);
                            //onOff[0].Rectangle(1, 1, 18, 18);
                            //onOff[0].Stroke();

                            //onOff[1] = cb.CreateAppearance(20, 20);
                            //onOff[1].SetRGBColorFill(255, 128, 128);
                            //onOff[1].Rectangle(1, 1, 18, 18);
                            //onOff[1].FillStroke();
                            //onOff[1].MoveTo(1, 1);
                            //onOff[1].LineTo(19, 19);
                            //onOff[1].MoveTo(1, 19);
                            //onOff[1].LineTo(19, 1);
                            //onOff[1].Stroke();

                            iTextSharp.text.pdf.RadioCheckField _checkbox1;

                            for (int i = 0; i < LANGUAGES_gc.Length; i++)
                            {
                                _rect = new iTextSharp.text.Rectangle(220, 157 - i * 40, 230, 167 - i * 40);
                                _checkbox1 = new RadioCheckField(oPdfw, _rect, LANGUAGES_gc[i], "Yes");
                                _checkbox1.CheckType = RadioCheckField.TYPE_CROSS;
                                _checkbox1.Checked = false;
                                oPdfw.AddAnnotation(_checkbox1.CheckField);
                                //show labels
                                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(LANGUAGES_gc[i], FontFactory.GetFont("Arial", 4f)), 150, 160 - i * 40, 0);
                            }

                            for (int i = 0; i < LANGUAGES_gc2.Length; i++)
                            {
                                _rect = new iTextSharp.text.Rectangle(430, 157 - i * 40, 440, 167 - i * 40);
                                _checkbox1 = new RadioCheckField(oPdfw, _rect, LANGUAGES_gc2[i], "Yes");
                                _checkbox1.CheckType = RadioCheckField.TYPE_CROSS;
                                _checkbox1.Checked = false;
                                oPdfw.AddAnnotation(_checkbox1.CheckField);
                                //show labels
                                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(LANGUAGES_gc2[i], FontFactory.GetFont("Arial", 4f)), 240, 160 - i * 40, 0);
                            }

                            for (int i = 0; i < LANGUAGES_gc3.Length; i++)
                            {
                                _rect = new iTextSharp.text.Rectangle(570, 157 - i * 40, 580, 167 - i * 40);
                                _checkbox1 = new RadioCheckField(oPdfw, _rect, LANGUAGES_gc3[i], "Yes");
                                _checkbox1.CheckType = RadioCheckField.TYPE_CROSS;
                                _checkbox1.Checked = false;
                                oPdfw.AddAnnotation(_checkbox1.CheckField);
                                //show labels
                                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(LANGUAGES_gc3[i], FontFactory.GetFont("Arial", 4f)), 450, 160 - i * 40, 0);
                            }
                            //_rect = new iTextSharp.text.Rectangle(180, 806 - i * 40, 200, 788 - i * 40);
                            //_checkbox1 = new iTextSharp.text.pdf.RadioCheckField(oPdfw, _rect, LANGUAGES_gc[i], "On");
                            //_Field1 = _checkbox1.CheckField.;//_checkbox1.CheckField;
                            //_Field1.SetAppearance(PdfAnnotation.APPEARANCE_NORMAL, "Off", onOff[0]);
                            //_Field1.SetAppearance(PdfAnnotation.APPEARANCE_NORMAL, "On", onOff[1]);
                            //oPdfw.AddAnnotation(_Field1);
                            for (int i = 0; i < Comprobante.Length; i++)
                            {
                                _rect = new iTextSharp.text.Rectangle(570, 157 - i * 40, 580, 167 - i * 40);
                                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(Comprobante[i], FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)), 60, 180 - i * 40, 0);
                            }
                            for (int i = 0; i < Numero.Length; i++)
                            {
                                _rect = new iTextSharp.text.Rectangle(570, 157 - i * 40, 580, 167 - i * 40);
                                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(Numero[i], FontFactory.GetFont("Arial", 4f)), 60, 120 - i * 40, 0);
                            }
                            for (int i = 0; i < Tipo.Length; i++)
                            {
                                _rect = new iTextSharp.text.Rectangle(570, 157 - i * 40, 580, 167 - i * 40);
                                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(Tipo[i], FontFactory.GetFont("Arial", 4f)), 60, 140 - i * 40, 0);
                            }
                            for (int i = 0; i < Motivo.Length; i++)
                            {
                                _rect = new iTextSharp.text.Rectangle(570, 157 - i * 40, 580, 167 - i * 40);
                                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(Motivo[i], FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)), 150, 180 - i * 40, 0);
                            }

                            //ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(LANGUAGES_gc[i], FontFactory.GetFont("Arial", 7.25f)), 210, 790 - i * 40, 0);


                            #endregion Final

                            // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                            PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                            //Establecer la acción abierta para nuestro objeto escritor
                            oPdfw.SetOpenAction(action);

                            //Liberando memoria
                            oPdfw.Flush();
                            DocumentoPdf.Close();
                        }
                    }
                }

                base.Imprimir();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEmisionGuiasUf);

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

                oFrm = new frmEmisionGuiasUf(oListaNumControlDet)
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
                if (bsEmisionGuias.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEmisionGuiasUf);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionGuias.Current;

                    if (current != null)
                    {
                        oFrm = new frmEmisionGuiasUf(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento, oListaNumControlDet)
                        {
                            MdiParent = MdiParent
                        };

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
                if (bsEmisionGuias.List.Count > 0)
                {
                    if (((EmisionDocumentoE)bsEmisionGuias.Current).indEstado != EnumEstadoDocumentos.B.ToString())
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                        {
                            AgenteVentas.Proxy.CambiarEstadoDocumento(((EmisionDocumentoE)bsEmisionGuias.Current).idEmpresa, ((EmisionDocumentoE)bsEmisionGuias.Current).idLocal, 
                                                                    ((EmisionDocumentoE)bsEmisionGuias.Current).idDocumento, ((EmisionDocumentoE)bsEmisionGuias.Current).numSerie, 
                                                                    ((EmisionDocumentoE)bsEmisionGuias.Current).numDocumento, EnumEstadoDocumentos.B.ToString(), 
                                                                    VariablesLocales.SesionUsuario.Credencial);
                            Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                            Buscar();
                        }
                    }
                    else
                    {
                        string idDocumentoActual = ((EmisionDocumentoE)bsEmisionGuias.Current).idDocumento;
                        string SerieActual = ((EmisionDocumentoE)bsEmisionGuias.Current).numSerie;
                        string NumeroActual = ((EmisionDocumentoE)bsEmisionGuias.Current).numDocumento;

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
                                    Int32 resp = AgenteVentas.Proxy.EliminarEmisDocuCompleto(((EmisionDocumentoE)bsEmisionGuias.Current).idEmpresa, 
                                                                                            ((EmisionDocumentoE)bsEmisionGuias.Current).idLocal, idDocumentoActual, SerieActual, NumeroActual);

                                    if (resp > Variables.Cero)
                                    {
                                        Global.MensajeComunicacion("El documento se eliminó correctamente");

                                        oListaDocumentos.Remove((EmisionDocumentoE)bsEmisionGuias.Current);
                                        bsEmisionGuias.DataSource = oListaDocumentos;
                                        bsEmisionGuias.ResetBindings(false);

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

                bsEmisionGuias.DataSource = oListaDocumentos;
                bsEmisionGuias.ResetBindings(false);
                dgvListadoGuias.Focus();

                lblRegistros.Text = "Registros " + bsEmisionGuias.Count.ToString();
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
                if (bsEmisionGuias.Count > 0)
                {
                    EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionGuias.Current;

                    if (current.indEstado == EnumEstadoDocumentos.B.ToString())
                    {
                        Global.MensajeComunicacion("Este documento no se puede imprimir porque se encuentra anulado.");
                        return;
                    }

                    Form oFrm = null;

                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009" || //AgroGenesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20523020561" || //Huerto Genesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20517933318" || //Vivero Genesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217" || //Jeritec
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681" || //A Y V SEEDS CO. S.A.C.
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410")   //POWER SEEDS S.A.C)
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmGuiaGenesis);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmGuiaGenesis(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);

                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20523201868") //INTERMETALS
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmGuiaInter);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmGuiaInter(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if(VariablesLocales.SesionUsuario.Empresa.RUC == "20601328179") //FFS
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmGuiaFfs);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmGuiaFfs(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    //else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20513445700") //Enzo Ferré
                    //{
                    //    oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmGuiaEFerre);

                    //    if (oFrm != null)
                    //    {
                    //        if (oFrm.WindowState == FormWindowState.Minimized)
                    //        {
                    //            oFrm.WindowState = FormWindowState.Normal;
                    //        }

                    //        oFrm.BringToFront();
                    //        return;
                    //    }

                    //    oFrm = new frmGuiaEFerre(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    //}
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20536039717") //Nevados
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmGuiaNevados);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmGuiaNevados(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20535703214") //Fitocorp
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmGuiaFito);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmGuiaFito(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20509606766") //Sergensur
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmGuiaSergensur);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmGuiaSergensur(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20519167434") 
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmGuiaGenesis);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmGuiaGenesis(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else
                    {
                        if (VariablesLocales.SesionUsuario.Empresa.indCalzado)
                        {
                            oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmGuiaEFerre);

                            if (oFrm != null)
                            {
                                if (oFrm.WindowState == FormWindowState.Minimized)
                                {
                                    oFrm.WindowState = FormWindowState.Normal;
                                }

                                oFrm.BringToFront();
                                return;
                            }

                            oFrm = new frmGuiaEFerre(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                        }
                        else
                        {
                            oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmGuiaGenesis);

                            if (oFrm != null)
                            {
                                if (oFrm.WindowState == FormWindowState.Minimized)
                                {
                                    oFrm.WindowState = FormWindowState.Normal;
                                }

                                oFrm.BringToFront();
                                return;
                            }

                            oFrm = new frmGuiaGenesis(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                        }
                    }

                    oFrm.MdiParent = MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrmImpresion_FormClosing);
                    oFrm.Show();
                }

                base.Imprimir();
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
            frmEmisionGuiasUf oFrm = sender as frmEmisionGuiasUf;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
                oListaNumControlDet = CargarDocumentos();
            }
        }

        private void oFrmImpresion_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009" || //AgroGenesis
                VariablesLocales.SesionUsuario.Empresa.RUC == "20523020561" || //Huerto Genesis
                VariablesLocales.SesionUsuario.Empresa.RUC == "20517933318" || //Vivero Genesis
                VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217" || //Jeritec
                VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681" || //A Y V SEEDS CO. S.A.C.
                VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410")   //POWER SEEDS S.A.C
            {
                frmGuiaGenesis oFrm = sender as frmGuiaGenesis;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionGuias.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionGuias.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionGuias.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20523201868") //INTERMETALS
                        
            {
                frmGuiaInter oFrm = sender as frmGuiaInter;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionGuias.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionGuias.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionGuias.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20601328179") //FFS
            {
                frmGuiaFfs oFrm = sender as frmGuiaFfs;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionGuias.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionGuias.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionGuias.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20536039717") //Nevados
            {
                frmGuiaNevados oFrm = sender as frmGuiaNevados;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionGuias.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionGuias.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionGuias.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20509606766") //Sergensur
            {
                frmGuiaSergensur oFrm = sender as frmGuiaSergensur;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionGuias.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionGuias.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionGuias.ResetBindings(false);
                    }
                }
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20513445700") //ENZO
            {
                frmGuiaEFerre oFrm = sender as frmGuiaEFerre;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    if (((EmisionDocumentoE)bsEmisionGuias.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        ((EmisionDocumentoE)bsEmisionGuias.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionGuias.ResetBindings(false);
                    }
                }
            }

            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);

            if (VariablesLocales.SesionUsuario.Credencial == "ALMACEN")
            {
                BloquearOpcion(EnumOpcionMenuBarra.Editar, false);
                BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
                BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            }



        }

        #endregion

        #region Eventos

        private void frmListadoGuiasUf_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());

            Global.CrearToolTip(btEmitir, "Emitir Documento (Presionar F11)");
            Global.CrearToolTip(btRevisarEstados, "Revisar Estado de Sunat (Presionar F12)");

            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);

            if (VariablesLocales.SesionUsuario.Credencial == "ALMACEN")
            {
                BloquearOpcion(EnumOpcionMenuBarra.Editar, false);
                BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
                BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            }
        
            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20452630886") //Fundo San Miguel
            {
                tsmiPdf.Visible = true;
            }
        }

        private void rbTodosCLientes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodosCLientes.Checked)
            {
                txtIdAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                //btCliente.Enabled = false;
            }
            else
            {
                txtIdAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                //btCliente.Enabled = true;
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
                                                                             where x.idControl == 3
                                                                             select x).ToList();
                ComboHelper.LlenarCombos<NumControlDetE>(cboSeries, ListaDetalle, "Serie", "Serie");
                cboSeries.Focus();
                ListaDetalle = null;
            }
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
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

        private void txtIdAuxiliar_Validating(object sender, CancelEventArgs e)
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

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
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
                            dgvListadoGuias.Focus();
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

        private void dgvListadoGuias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (VariablesLocales.SesionUsuario.Credencial == "ALMACEN")
            {
                Global.MensajeComunicacion("No tiene Permisos para Editar.");
                return;
            }

            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvListadoGuias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Si se encuentra Emitido
            if ((String)dgvListadoGuias.Rows[e.RowIndex].Cells["indEstado"].Value == EnumEstadoDocumentos.E.ToString())
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorEmitido;
                }
            }

            //Si se encuentra Facturada
            if ((String)dgvListadoGuias.Rows[e.RowIndex].Cells["indEstado"].Value == EnumEstadoDocumentos.F.ToString())
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorFacturado;
                }
            }

            //Si se encuentra anulado
            if ((String)dgvListadoGuias.Rows[e.RowIndex].Cells["indEstado"].Value == EnumEstadoDocumentos.B.ToString())
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }

            //Si se ha enviado a Sunat
            if ((String)dgvListadoGuias.Rows[e.RowIndex].Cells["indEstado"].Value == EnumEstadoDocumentos.E.ToString() && (Boolean)dgvListadoGuias.Rows[e.RowIndex].Cells["EnviadoSunat"].Value)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorSunat;
                }
            }
        }

        private void dgvListadoGuias_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaDocumentos != null && oListaDocumentos.Count > Variables.Cero)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.ColumnIndex == dgvListadoGuias.Columns["numSerie"].Index)
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

                    if (e.ColumnIndex == dgvListadoGuias.Columns["numDocumento"].Index)
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

                    if (e.ColumnIndex == dgvListadoGuias.Columns["fecEmision"].Index)
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

                    if (e.ColumnIndex == dgvListadoGuias.Columns["numRuc"].Index)
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

                    if (e.ColumnIndex == dgvListadoGuias.Columns["RazonSocial"].Index)
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

                    if (e.ColumnIndex == dgvListadoGuias.Columns["desTraslado"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.desTraslado ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.desTraslado descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListadoGuias.Columns["fecDespacho"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.fecDespacho ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.fecDespacho descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListadoGuias.Columns["tipCambioDataGridViewTextBoxColumn"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.tipCambio ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.tipCambio descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    //if (e.ColumnIndex == dgvListadoGuias.Columns["totIgv"].Index)
                    //{
                    //    if (Ordenar)
                    //    {
                    //        oListaDocumentos = (from x in oListaDocumentos orderby x.totIgv ascending select x).ToList();
                    //        Ordenar = false;
                    //    }
                    //    else
                    //    {
                    //        oListaDocumentos = (from x in oListaDocumentos orderby x.totIgv descending select x).ToList();
                    //        Ordenar = true;
                    //    }
                    //}

                    //if (e.ColumnIndex == dgvListadoGuias.Columns["totTotal"].Index)
                    //{
                    //    if (Ordenar)
                    //    {
                    //        oListaDocumentos = (from x in oListaDocumentos orderby x.totTotal ascending select x).ToList();
                    //        Ordenar = false;
                    //    }
                    //    else
                    //    {
                    //        oListaDocumentos = (from x in oListaDocumentos orderby x.totTotal descending select x).ToList();
                    //        Ordenar = true;
                    //    }
                    //}
                }

                bsEmisionGuias.DataSource = oListaDocumentos;
            }
        }

        private void btEmitir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsEmisionGuias.Count > Variables.Cero)
                {
                    Buscar();

                    if (((EmisionDocumentoE)bsEmisionGuias.Current).indEstado == EnumEstadoDocumentos.B.ToString())
                    {
                        Global.MensajeComunicacion("Este documento no se puede emitir porque se encuentra anulado.");
                        return;
                    }

                    if (((EmisionDocumentoE)bsEmisionGuias.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        AgenteVentas.Proxy.CambiarEstadoDocumento(((EmisionDocumentoE)bsEmisionGuias.Current).idEmpresa, ((EmisionDocumentoE)bsEmisionGuias.Current).idLocal,
                                    ((EmisionDocumentoE)bsEmisionGuias.Current).idDocumento, ((EmisionDocumentoE)bsEmisionGuias.Current).numSerie, ((EmisionDocumentoE)bsEmisionGuias.Current).numDocumento,
                                    EnumEstadoDocumentos.E.ToString(), VariablesLocales.SesionUsuario.Credencial);

                        ((EmisionDocumentoE)bsEmisionGuias.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionGuias.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void frmListadoGuiasUf_KeyDown(object sender, KeyEventArgs e)
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

        private void tsmiEnviarCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                EmisionDocumentoE oEmision = AgenteVentas.Proxy.RecuperarDocumentoCompleto(((EmisionDocumentoE)bsEmisionGuias.Current).idEmpresa, ((EmisionDocumentoE)bsEmisionGuias.Current).idLocal, ((EmisionDocumentoE)bsEmisionGuias.Current).idDocumento, ((EmisionDocumentoE)bsEmisionGuias.Current).numSerie, ((EmisionDocumentoE)bsEmisionGuias.Current).numDocumento);

                if (oEmision != null)
                {
                    CrearPdf(oEmision);

                    frmEnvioCorreos oFrm = new frmEnvioCorreos(oEmision, RutaPdf);
                    oFrm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiDespacho_Click(object sender, EventArgs e)
        {
            try
            {
                EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionGuias.Current;

                frmCopiarFechaGuiaUf oFrm = new frmCopiarFechaGuiaUf(current);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Emision != null)
                {
                    oFrm.Emision = AgenteVentas.Proxy.ActualizarFecDespacho(oFrm.Emision);
                    Global.MensajeComunicacion("El Registro se Actualizo correctamente.");
                    Buscar();
                }

            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Eventos


    }
}