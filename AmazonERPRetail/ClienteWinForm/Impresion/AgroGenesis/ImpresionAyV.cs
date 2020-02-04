using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Infraestructura.Enumerados;
using Infraestructura;

namespace ClienteWinForm.Impresion.AgroGenesis
{
    public class ImpresionAyV : IImpresion
    {

        #region Variables

        public VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        NumControlDetE ControlDocumento = null;
        List<String> Palabras = null;
        StringBuilder CadenaDireccion = new StringBuilder();
        Int32 totLetras = 0;
        String PrimerParrafo = String.Empty;
        String SegundoParrafo = String.Empty;
        Boolean UsarNombreCompuesto = VariablesLocales.oVenParametros.indNomArtCompuesto;

        #endregion

        #region Procedimientos Públicos

        public void ImprimirGuiaRemision(EmisionDocumentoE DocumentoEmision, String RutaImpresion, Int32 Tipoguia)
        {
            if (String.IsNullOrEmpty(RutaImpresion.Trim()))
            {
                throw new Exception("No se encontró la ruta o el nombre de le impresora.");
            }

            ControlDocumento = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(DocumentoEmision.idEmpresa, DocumentoEmision.idLocal, 3, DocumentoEmision.idDocumento, DocumentoEmision.numSerie);

            if (ControlDocumento != null)
            {
                Int32 CantidadLineas = DocumentoEmision.ListaItemsDocumento.Count;

                if (CantidadLineas > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de items a sobrepasado el limite permitido en el Control de Documentos.");
                }

                CantidadLineas = HelperImpresion.CantidadLineas(DocumentoEmision.ListaItemsDocumento, ControlDocumento);

                if (CantidadLineas > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de lineas en el detalle a sobrepasado el limite permitido dado que hay articulos presentados en mas de una linea.");
                }

                for (int i = 0; i < ControlDocumento.cantCopias; i++)
                {
                    switch (Tipoguia)
                    {
                        case (Int32)EnumTipoImpresionGuiaRemision.VENTA:
                            GuiaVentas(DocumentoEmision, RutaImpresion);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                throw new Exception("Este documento no tiene ningún tipo de configuración. Revisar en Menú > Control de Documentos.");
            }
        }

        public void ImprimirFacturas(EmisionDocumentoE DocumentoEmision, String RutaImpresion)
        {
            if (String.IsNullOrEmpty(RutaImpresion.Trim()))
            {
                throw new Exception("No se encontró la ruta o el nombre de le impresora.");
            }

            ControlDocumento = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(DocumentoEmision.idEmpresa, DocumentoEmision.idLocal, 1, DocumentoEmision.idDocumento, DocumentoEmision.numSerie);

            if (ControlDocumento != null)
            {
                Int32 CantidadLineas = DocumentoEmision.ListaItemsDocumento.Count;

                if (CantidadLineas > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de items a sobrepasado el limite permitido en el Control de Documentos.");
                }

                CantidadLineas = HelperImpresion.CantidadLineas(DocumentoEmision.ListaItemsDocumento, ControlDocumento);

                if (CantidadLineas > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de lineas en el detalle a sobrepasado el limite permitido dado que hay articulos presentados en mas de una linea.");
                }

                for (int i = 0; i < ControlDocumento.cantCopias; i++)
                {
                    Facturas(DocumentoEmision, RutaImpresion);
                }
            }
            else
            {
                throw new Exception("Este documento no tiene ningún tipo de configuración. Revisar en Menú > Control de Documentos.");
            }
        }

        public void ImprimirBoletas(EmisionDocumentoE DocumentoEmision, String RutaImpresion)
        {
            if (String.IsNullOrEmpty(RutaImpresion.Trim()))
            {
                throw new Exception("No se encontró la ruta o el nombre de le impresora.");
            }

            ControlDocumento = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(DocumentoEmision.idEmpresa, DocumentoEmision.idLocal, 2, DocumentoEmision.idDocumento, DocumentoEmision.numSerie);

            if (ControlDocumento != null)
            {
                Int32 CantidadLineas = DocumentoEmision.ListaItemsDocumento.Count;

                if (CantidadLineas > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de items a sobrepasado el limite permitido en el Control de Documentos.");
                }

                CantidadLineas = HelperImpresion.CantidadLineas(DocumentoEmision.ListaItemsDocumento, ControlDocumento);

                if (CantidadLineas > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de lineas en el detalle a sobrepasado el limite permitido dado que hay articulos presentados en mas de una linea.");
                }

                for (int i = 0; i < ControlDocumento.cantCopias; i++)
                {
                    BoletaVenta(DocumentoEmision, RutaImpresion);
                }

            }
            else
            {
                throw new Exception("Este documento no tiene ningún tipo de configuración. Revisar en Menú > Control de Documentos.");
            }
        }

        public void ImprimirNotaDeCredito(EmisionDocumentoE DocumentoEmision, String RutaImpresion)
        {
            if (String.IsNullOrEmpty(RutaImpresion.Trim()))
            {
                throw new Exception("No se encontró la ruta o el nombre de le impresora.");
            }

            ControlDocumento = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(DocumentoEmision.idEmpresa, DocumentoEmision.idLocal, 4, DocumentoEmision.idDocumento, DocumentoEmision.numSerie);

            if (ControlDocumento != null)
            {
                Int32 CantidadLineas = DocumentoEmision.ListaItemsDocumento.Count;

                if (CantidadLineas > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de items a sobrepasado el limite permitido en el Control de Documentos.");
                }

                CantidadLineas = HelperImpresion.CantidadLineas(DocumentoEmision.ListaItemsDocumento, ControlDocumento);

                if (CantidadLineas > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de lineas en el detalle a sobrepasado el limite permitido dado que hay articulos presentados en mas de una linea.");
                }

                for (int i = 0; i < ControlDocumento.cantCopias; i++)
                {
                    switch (DocumentoEmision.idDocumento)
                    {
                        case "NC":
                            NotaDeCreditoNC(DocumentoEmision, RutaImpresion);
                            break;
                        case "NP":
                            NotaDeCreditoNC(DocumentoEmision, RutaImpresion);
                            break;
                        //    case (Int32)EnumTipoImpresionGuiaRemision.TRASLADO:
                        //        GuiaTraslado(DocumentoEmision, RutaImpresion);
                        //        break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                throw new Exception("Este documento no tiene ningún tipo de configuración. Revisar en Menú > Control de Documentos.");
            }
        }

        public void ImprimirNotaDeDebito(EmisionDocumentoE DocumentoEmision, String RutaImpresion)
        {
            if (String.IsNullOrEmpty(RutaImpresion.Trim()))
            {
                throw new Exception("No se encontró la ruta o el nombre de le impresora.");
            }

            ControlDocumento = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(DocumentoEmision.idEmpresa, DocumentoEmision.idLocal, 5, DocumentoEmision.idDocumento, DocumentoEmision.numSerie);

            if (ControlDocumento != null)
            {
                Int32 CantidadLineas = DocumentoEmision.ListaItemsDocumento.Count;

                if (CantidadLineas > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de items a sobrepasado el limite permitido en el Control de Documentos.");
                }

                CantidadLineas = HelperImpresion.CantidadLineas(DocumentoEmision.ListaItemsDocumento, ControlDocumento);

                if (CantidadLineas > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de lineas en el detalle a sobrepasado el limite permitido dado que hay articulos presentados en mas de una linea.");
                }

                for (int i = 0; i < ControlDocumento.cantCopias; i++)
                {
                    switch (DocumentoEmision.idDocumento)
                    {
                        case "ND":
                            NotaDeDebitoND(DocumentoEmision, RutaImpresion);
                            break;
                        case "NI":
                            NotaDeDebitoND(DocumentoEmision, RutaImpresion);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                throw new Exception("Este documento no tiene ningún tipo de configuración. Revisar en Menú > Control de Documentos.");
            }
        }

        public void ImprimirLetras(LetrasE oLetra, String RutaImpresion)
        {
            if (String.IsNullOrEmpty(RutaImpresion.Trim()))
            {
                throw new Exception("No se encontró la ruta o el nombre de le impresora.");
            }

            Letras(oLetra, RutaImpresion);

            //ControlDocumento = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(DocumentoEmision.idEmpresa, DocumentoEmision.idLocal, 5, DocumentoEmision.idDocumento, DocumentoEmision.numSerie);

            //if (ControlDocumento != null)
            //{
            //    Int32 CantidadLineas = DocumentoEmision.ListaItemsDocumento.Count;

            //    if (CantidadLineas > ControlDocumento.cantItems)
            //    {
            //        throw new Exception("La cantidad de items a sobrepasado el limite permitido en el Control de Documentos.");
            //    }

            //    CantidadLineas = HelperImpresion.CantidadLineas(DocumentoEmision.ListaItemsDocumento, ControlDocumento);

            //    if (CantidadLineas > ControlDocumento.cantItems)
            //    {
            //        throw new Exception("La cantidad de lineas en el detalle a sobrepasado el limite permitido dado que hay articulos presentados en mas de una linea.");
            //    }

            //    for (int i = 0; i < ControlDocumento.cantCopias; i++)
            //    {
            //        switch (DocumentoEmision.idDocumento)
            //        {
            //            case "ND":
            //                NotaDeDebitoND(DocumentoEmision, RutaImpresion);
            //                break;
            //            case "NI":
            //                NotaDeDebitoND(DocumentoEmision, RutaImpresion);
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //}
            //else
            //{
            //    throw new Exception("Este documento no tiene ningún tipo de configuración. Revisar en Menú > Control de Documentos.");
            //}
        }

        #endregion

        #region Procedimientos Privados

        private void GuiaVentas(EmisionDocumentoE oGuia, String nomImpresora)
        {
            GuiasAyV oGuiaImpresion = new GuiasAyV();
            DateTime fecTraslado = Convert.ToDateTime(oGuia.fecTraslado);
            List<String> Palabras = null;
            StringBuilder CadenaDireccion = new StringBuilder();
            String NombreArticulo = String.Empty;
            Int32 totLetras = 0;
            String PrimerParrafo = String.Empty;
            String SegundoParrafo = String.Empty;

            //Fecha de Emisión de la Guia
            //oGuiaImpresion.AgregarDatos(oGuia.fecEmision.ToString("d"), "45", "56"); //Por revisar

            //Punto de Partida
            if (oGuia.PuntoPartida.Length > 45)
            {
                Palabras = new List<String>(oGuia.PuntoPartida.Split(' '));

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    CadenaDireccion.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion.Length <= 45)
                    {
                        continue;
                    }
                    else
                    {
                        PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
                        break;
                    }
                }

                SegundoParrafo = oGuia.PuntoPartida.Replace(PrimerParrafo, "").Trim();

                oGuiaImpresion.AgregarDatos(PrimerParrafo, "15.5", "69");
                oGuiaImpresion.AgregarDatos(SegundoParrafo, "15.5", "72");
                CadenaDireccion.Clear();
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.PuntoPartida, "15.5", "69");
            }

            //Punto de Llegada
            if (oGuia.PuntoLlegada.Length > 45)
            {
                CadenaDireccion.Clear();
                Palabras = new List<String>(oGuia.PuntoLlegada.Split(' '));

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    CadenaDireccion.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion.Length <= 45)
                    {
                        continue;
                    }
                    else
                    {
                        PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
                        break;
                    }
                }

                SegundoParrafo = oGuia.PuntoLlegada.Replace(PrimerParrafo, "").Trim();

                oGuiaImpresion.AgregarDatos(PrimerParrafo, "112", "69");
                oGuiaImpresion.AgregarDatos(SegundoParrafo, "112", "72");
                CadenaDireccion.Clear();
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.PuntoLlegada, "112", "69");
            }

            //Fecha de traslado
            oGuiaImpresion.AgregarDatos(Convert.ToDateTime(oGuia.fecTraslado).ToString("dd/MM/yyyy"), "58.5", "78.5");
            oGuiaImpresion.AgregarDatos(oGuia.RazonSocial, "112", "82");
            oGuiaImpresion.AgregarDatos(oGuia.numRuc, "132", "89");

            //Transporte y Conductores (Lado Izquierdo)
            oGuiaImpresion.AgregarDatos(oGuia.MarcaTransp + " " + oGuia.PlacaTransp, "57", "107");
            oGuiaImpresion.AgregarDatos(oGuia.inscripTransp, "66", "115");
            oGuiaImpresion.AgregarDatos(oGuia.LicenciaTransp, "64", "121");

            //Transportista (Lado Derecho)
            oGuiaImpresion.AgregarDatos(oGuia.RazonSocialTransp, "112", "112");
            oGuiaImpresion.AgregarDatos(oGuia.RucTransp, "130", "119.5");

            //Detalle(Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oGuia.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    NombreArticulo = (!UsarNombreCompuesto ? item.nomArticulo : (item.tipArticulo == "AR" ? item.desNomArtCompuesto : item.nomArticulo));
                    oGuiaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + NombreArticulo + "|" + item.desUMedida + "|"
                        + item.PesoBrutoCad, ControlDocumento.cantCaracteres);
                }
            }

            //Glosa
            List<String> oLista = new List<String>(oGuia.Glosa.Split('/'));

            if (oLista != null && oLista.Count > 0)
            {
                Int16 conta = 0;
                StringBuilder Cadena = new StringBuilder();

                foreach (String item in oLista)
                {
                    if (conta == 2)
                    {
                        Cadena.Append("\n\r").Append(item.Trim());
                        conta = 0;
                    }
                    else
                    {
                        Cadena.Append(item.Trim()).Append(" ");
                        conta++;
                    }
                }

                oGuiaImpresion.AgregarDatos("Atencion: " + Cadena.ToString(), "30", "219");
            }
            else
            {
                oGuiaImpresion.AgregarDatos("Atencion: " + oGuia.Glosa, "30", "219");
            }

            //Guias asociadas
            if (oGuia.ListaCanjeGuias != null && oGuia.ListaCanjeGuias.Count > 0)
            {
                //Tipo
                if (oGuia.ListaCanjeGuias[0].idDocumentoFact == "FV")
                {
                    oGuiaImpresion.AgregarDatos("FACTURA", "22", "241");
                }
                else
                {
                    oGuiaImpresion.AgregarDatos("BOLETA", "22", "241");
                }

                //Numero factura
                oGuiaImpresion.AgregarDatos(oGuia.ListaCanjeGuias[0].numSerieFact + "-" + oGuia.ListaCanjeGuias[0].numDocumentoFact, "30", "248");
            }
            else
            {
                oGuiaImpresion.AgregarDatos(" ", "22", "241");
                oGuiaImpresion.AgregarDatos(" ", "30", "248");
            }

            //Imprimiendo la guia de traslado
            oGuiaImpresion.ImprimirGuia(nomImpresora);
        }

        private void Facturas(EmisionDocumentoE oFactura, String nomImpresora)
        {
            String Moneda = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oFactura.fecEmision);
            FacturasAyV oFacturaImpresion = new FacturasAyV();
            String NombreArticulo = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oFactura.idMoneda
                                select x).SingleOrDefault();

            //Razón Social
            oFacturaImpresion.AgregarDatos(oFactura.RazonSocial, "30", "65.8");

            //Dicrección
            if (oFactura.Direccion.Length > 85)
            {
                Palabras = new List<String>(oFactura.Direccion.Split(' '));

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    CadenaDireccion.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion.Length <= 85)
                    {
                        continue;
                    }
                    else
                    {
                        PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
                        break;
                    }
                }

                SegundoParrafo = oFactura.Direccion.Replace(PrimerParrafo, "").Trim();

                oFacturaImpresion.AgregarDatos(PrimerParrafo, "30", "73.8");
                oFacturaImpresion.AgregarDatos(SegundoParrafo, "30", "77");
                CadenaDireccion.Clear();
            }
            else
            {
                oFacturaImpresion.AgregarDatos(oFactura.Direccion, "30", "73.8");
            }

            oFacturaImpresion.AgregarDatos(oFactura.numRuc, "30", "82.6");
            //oFacturaImpresion.AgregarDatos(oFactura.fecEmision.ToString("d"), "160", "82.5"); //Por revisar

            if (oFactura.ListaCanjeGuias != null && oFactura.ListaCanjeGuias.Count > 0)
            {
                StringBuilder CadenaGuias = new StringBuilder();
                Int32 Salto = 1;

                foreach (CanjeGuiasE item in oFactura.ListaCanjeGuias)
                {
                    if (Salto == 3)
                    {
                        CadenaGuias.Append(item.numSerieGuia).Append("-").Append(item.numDocumentoGuia).Append("\n\r");
                    }
                    else
                    {
                        CadenaGuias.Append(item.numSerieGuia).Append("-").Append(item.numDocumentoGuia).Append(" ");
                    }

                    Salto++;
                }

                oFacturaImpresion.AgregarDatos(CadenaGuias.ToString().Trim(), "43", "90"); //guias
            }
            else
            {
                oFacturaImpresion.AgregarDatos(" ", "43", "90"); //guia
            }

            oFacturaImpresion.AgregarDatos(oFactura.desCondicion, "160", "90");

            ////Detalle (Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oFactura.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    NombreArticulo = (!UsarNombreCompuesto ? item.nomArticulo : (item.tipArticulo == "AR" ? item.desNomArtCompuesto : item.nomArticulo));

                    oFacturaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|"
                    + NombreArticulo + "|" + item.PrecioCad + "|"//Convert.ToDecimal(item.PrecioSinImpuesto).ToString("N2") + "|"
                    + (item.indCalculo == true ? Convert.ToDecimal(item.subTotal).ToString("N2") : (oFactura.DsctoGlobal > 0 ? item.SubTotalCad : "")), ControlDocumento.cantCaracteres);
                }
                else
                {
                    if (oFactura.desCondicion.Contains("TRANSFERENCIA"))
                    {
                        oFacturaImpresion.AgregarItems("|" + item.nomArticulo + "||", ControlDocumento.cantCaracteres);
                    }
                }
            }

            //Valor Venta
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oFactura.totsubTotal.ToString("N2"), "24", "247");
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oFactura.totsubTotal.ToString("N2"), "96", "247");

            if (oFactura.totIgv > 0)
            {
                oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oFactura.totIgv.Value.ToString("N2"), "140", "247");
            }

            Moneda = " " + oMoneda.desMoneda.ToUpper();

            if (oFactura.desCondicion.Contains("TRANSFERENCIA"))
            {
                //oFacturaImpresion.AgregarDatos("TRANSFERENCIA A TITULO GRATUITO.", "31", "220");
                oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + " 0.00", "176", "247");
                oFacturaImpresion.AgregarDatos(enLetras("0.00") + Moneda, "31", "259");
            }
            else
            {
                oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oFactura.totTotal.ToString("N2"), "176", "247");
                ////Total en Letras
                oFacturaImpresion.AgregarDatos(enLetras(oFactura.totTotal.ToString()) + Moneda, "31", "259");
            }

            //Imprimiendo
            oFacturaImpresion.ImprimirFactura(nomImpresora);
        }

        private void BoletaVenta(EmisionDocumentoE oBoleta, String nomImpresora)
        {
            String Moneda = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oBoleta.fecEmision);
            BoletasAyV oBoletaImpresion = new BoletasAyV();
            String NombreArticulo = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oBoleta.idMoneda
                                select x).SingleOrDefault();

            //Razón Social
            oBoletaImpresion.AgregarDatos(oBoleta.RazonSocial, "32", "65.5");

            //Dicrección
            if (oBoleta.Direccion.Length > 85)
            {
                Palabras = new List<String>(oBoleta.Direccion.Split(' '));

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    CadenaDireccion.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion.Length <= 85)
                    {
                        continue;
                    }
                    else
                    {
                        PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
                        break;
                    }
                }

                SegundoParrafo = oBoleta.Direccion.Replace(PrimerParrafo, "").Trim();
                oBoletaImpresion.AgregarDatos(PrimerParrafo, "32", "73.5");
                oBoletaImpresion.AgregarDatos(SegundoParrafo, "32", "77");
                CadenaDireccion.Clear();
            }
            else
            {
                oBoletaImpresion.AgregarDatos(oBoleta.Direccion, "32", "73.5");
            }

            oBoletaImpresion.AgregarDatos(oBoleta.numRuc, "32", "82.5");
            oBoletaImpresion.AgregarDatos(fecEmision.ToString("d"), "162", "82.2");

            if (oBoleta.ListaCanjeGuias != null && oBoleta.ListaCanjeGuias.Count > 0)
            {
                StringBuilder CadenaGuias = new StringBuilder();

                foreach (CanjeGuiasE item in oBoleta.ListaCanjeGuias)
                {
                    CadenaGuias.Append(item.numSerieGuia).Append("-").Append(item.numDocumentoGuia).Append(" ");
                }

                oBoletaImpresion.AgregarDatos(CadenaGuias.ToString().Trim(), "45", "90"); //guias
            }
            else
            {
                oBoletaImpresion.AgregarDatos(" ", "45", "90"); //guia
            }

            oBoletaImpresion.AgregarDatos(oBoleta.desCondicion, "162", "90");

            ////Detalle (Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oBoleta.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    NombreArticulo = (!UsarNombreCompuesto ? item.nomArticulo : (item.tipArticulo == "AR" ? item.desNomArtCompuesto : item.nomArticulo));

                    oBoletaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|"
                    + NombreArticulo + "|" + item.PrecioCad + "|"//Convert.ToDecimal(item.PrecioSinImpuesto).ToString("N2") + "|"
                    + (item.indCalculo == true ? Convert.ToDecimal(item.subTotal).ToString("N2") : (oBoleta.DsctoGlobal > 0 ? item.SubTotalCad : "")), ControlDocumento.cantCaracteres);
                }
                else
                {
                    if (oBoleta.desCondicion.Contains("TRANSFERENCIA"))
                    {
                        oBoletaImpresion.AgregarItems("|" + item.nomArticulo + "||", ControlDocumento.cantCaracteres);
                    }
                }
            }

            Moneda = " " + oMoneda.desMoneda.ToUpper();

            if (oBoleta.desCondicion.Contains("TRANSFERENCIA"))
            {
                oBoletaImpresion.AgregarDatos("TRANSFERENCIA A TITULO GRATUITO.", "31", "220");
                oBoletaImpresion.AgregarDatos(oMoneda.desAbreviatura + " 0.00", "179.8", "244");
                oBoletaImpresion.AgregarDatos(enLetras("0.00") + Moneda, "31", "259");
            }
            else
            {
                oBoletaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oBoleta.totTotal.ToString("N2"), "179.8", "244");
                ////Total en Letras
                oBoletaImpresion.AgregarDatos(enLetras(oBoleta.totTotal.ToString()) + Moneda, "31", "259");
            }

            //Imprimiendo
            oBoletaImpresion.ImprimirBoleta(nomImpresora);
        }

        private void NotaDeCreditoNC(EmisionDocumentoE oNotaCredito, String nomImpresora)
        {
            NotasDeCreditoAyV oNcImpresion = new NotasDeCreditoAyV();
            String NombreDocumento = String.Empty;
            String Moneda = String.Empty;
            String Ruc = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oNotaCredito.idMoneda
                                select x).SingleOrDefault();

            //Cabecera
            if (oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.FE.ToString() ||
                oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.FS.ToString() ||
                oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.FV.ToString())
            {
                NombreDocumento = "Factura de Venta";
            }
            else if (oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.BV.ToString())
            {
                NombreDocumento = "Boleta de Venta";
            }

            //Razón Social
            oNcImpresion.AgregarDatos(oNotaCredito.RazonSocial, "35", "51.7");

            //Dicrección
            if (oNotaCredito.Direccion.Length > 47)
            {
                Palabras = new List<String>(oNotaCredito.Direccion.Split(' '));

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    CadenaDireccion.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion.Length <= 47)
                    {
                        continue;
                    }
                    else
                    {
                        PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
                        break;
                    }
                }

                SegundoParrafo = oNotaCredito.Direccion.Replace(PrimerParrafo, "").Trim();

                oNcImpresion.AgregarDatos(PrimerParrafo, "35", "60");
                oNcImpresion.AgregarDatos(SegundoParrafo, "35", "64");
                CadenaDireccion.Clear();
            }
            else
            {
                oNcImpresion.AgregarDatos(oNotaCredito.Direccion, "35", "60");
            }

            //oNcImpresion.AgregarDatos(oNotaCredito.fecEmision.ToString("d"), "35", "69"); //Por revisar
            oNcImpresion.AgregarDatos(oNotaCredito.numRuc, "35", "76");

            oNcImpresion.AgregarDatos(NombreDocumento, "150", "60");
            oNcImpresion.AgregarDatos(oNotaCredito.serDocumentoRef + "-" + oNotaCredito.numDocumentoRef, "150", "69");
            oNcImpresion.AgregarDatos(Convert.ToDateTime(oNotaCredito.fecDocumentoRef).ToString("dd/MM/yyyy"), "150", "76");

            String Formato = String.Empty;

            if (ControlDocumento.cantDigDecimales == 3)
            {
                Formato = "N3";
            }
            else if (ControlDocumento.cantDigDecimales == 4)
            {
                Formato = "N4";
            }
            else if (ControlDocumento.cantDigDecimales == 5)
            {
                Formato = "N5";
            }
            else if (ControlDocumento.cantDigDecimales == 6)
            {
                Formato = "N6";
            }
            else if (ControlDocumento.cantDigDecimales == 7)
            {
                Formato = "###,###,##0.0000000";
            }
            else
            {
                Formato = "N2";
            }

            //Detalle(Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oNotaCredito.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    if (item.Cantidad > 0 && item.nomArticulo != null)
                    {
                        oNcImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" +
                                                    item.nomArticulo + "|" +
                                                    Convert.ToDecimal(item.PrecioSinImpuesto).ToString(Formato) + "|" +
                                                    Convert.ToDecimal(item.subTotal).ToString("N2"), ControlDocumento.cantCaracteres);
                    }
                }
                else
                {
                    if (oNotaCredito.desCondicionRef.Contains("TRANSFERENCIA"))
                    {
                        oNcImpresion.AgregarItems("|" + item.nomArticulo + "||", ControlDocumento.cantCaracteres);
                    }
                }
            }

            Moneda = " " + oMoneda.desMoneda.ToUpper();

            //Motivo
            oNcImpresion.AgregarDatos(oNotaCredito.desCondicion, "58", "133.5");

            if (!String.IsNullOrEmpty(oNotaCredito.Glosa))
            {
                oNcImpresion.AgregarDatos(oNotaCredito.Glosa, "58", "138");
            }

            //Totales
            string Numeros = String.Empty;

            if (oNotaCredito.desCondicionRef.Contains("TRANSFERENCIA"))
            {
                //Total en Letras
                oNcImpresion.AgregarDatos(enLetras("0.00") + Moneda, "38", "125.4");

                Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totsubTotal).ToString("N2");
                oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "184", "132");
                Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2");
                oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "184", "138.5");
                Numeros = oNcImpresion.AlinearDerecha("0.00".Length, 6) + "0.00";
                oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "184", "144");
            }
            else
            {
                //Total en Letras
                oNcImpresion.AgregarDatos(enLetras(oNotaCredito.totTotal.ToString()) + Moneda, "38", "125.4");

                Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totsubTotal).ToString("N2");
                oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "184", "132");
                Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2");
                oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "184", "138.5");
                Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
                oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "184", "144");
            }

            //Imprimiendo
            oNcImpresion.ImprimirNC(nomImpresora);
        }

        private void NotaDeDebitoND(EmisionDocumentoE oNotaDebito, String nomImpresora)
        {
            NotasDeDebitoAyV oNdImpresion = new NotasDeDebitoAyV();
            String NombreDocumento = String.Empty;
            String Moneda = String.Empty;
            String Ruc = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oNotaDebito.idMoneda
                                select x).SingleOrDefault();

            //Cabecera
            if (oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FE.ToString() ||
                oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FS.ToString() ||
                oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FV.ToString())
            {
                NombreDocumento = "Factura de Venta";
            }
            else if (oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.BV.ToString())
            {
                NombreDocumento = "Boleta de Venta";
            }

            oNdImpresion.AgregarDatos(oNotaDebito.RazonSocial, "35", "54");

            //Dicrección
            if (oNotaDebito.Direccion.Length > 47)
            {
                Palabras = new List<String>(oNotaDebito.Direccion.Split(' '));

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    CadenaDireccion.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion.Length <= 47)
                    {
                        continue;
                    }
                    else
                    {
                        PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
                        break;
                    }
                }

                SegundoParrafo = oNotaDebito.Direccion.Replace(PrimerParrafo, "").Trim();

                oNdImpresion.AgregarDatos(PrimerParrafo, "35", "61");
                oNdImpresion.AgregarDatos(SegundoParrafo, "35", "64.6");
                CadenaDireccion.Clear();
            }
            else
            {
                oNdImpresion.AgregarDatos(oNotaDebito.Direccion, "35", "61");
            }

            //oNdImpresion.AgregarDatos(oNotaDebito.fecEmision.ToString("d"), "37", "69"); //Por revisar
            oNdImpresion.AgregarDatos(oNotaDebito.numRuc, "35", "75.5");

            oNdImpresion.AgregarDatos(NombreDocumento, "150", "61");
            oNdImpresion.AgregarDatos(oNotaDebito.serDocumentoRef + "-" + oNotaDebito.numDocumentoRef, "150", "69");
            oNdImpresion.AgregarDatos(Convert.ToDateTime(oNotaDebito.fecDocumentoRef).ToString("dd/MM/yyyy"), "150", "75.5");

            String Formato = String.Empty;

            if (ControlDocumento.cantDigDecimales == 3)
            {
                Formato = "N3";
            }
            else if (ControlDocumento.cantDigDecimales == 4)
            {
                Formato = "N4";
            }
            else if (ControlDocumento.cantDigDecimales == 5)
            {
                Formato = "N5";
            }
            else if (ControlDocumento.cantDigDecimales == 6)
            {
                Formato = "N6";
            }
            else if (ControlDocumento.cantDigDecimales == 7)
            {
                Formato = "###,###,##0.0000000";
            }
            else
            {
                Formato = "N2";
            }

            //Detalle(Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oNotaDebito.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    if (item.Cantidad > 0 && item.nomArticulo != null)
                    {
                        oNdImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" +
                                                    item.nomArticulo + "|" +
                                                    Convert.ToDecimal(item.PrecioSinImpuesto).ToString(Formato) + "|" +
                                                    Convert.ToDecimal(item.subTotal).ToString("N2"), ControlDocumento.cantCaracteres);
                    }
                }
                else
                {
                    if (oNotaDebito.desCondicionRef.Contains("TRANSFERENCIA"))
                    {
                        oNdImpresion.AgregarItems("|" + item.nomArticulo + "||", ControlDocumento.cantCaracteres);
                    }
                }
            }

            Moneda = " " + oMoneda.desMoneda.ToUpper();

            //Motivo
            oNdImpresion.AgregarDatos(oNotaDebito.desCondicion, "58", "128");

            if (!String.IsNullOrEmpty(oNotaDebito.Glosa))
            {
                oNdImpresion.AgregarDatos(oNotaDebito.Glosa, "58", "131");
            }

            //Totales
            String Numeros = String.Empty;

            if (oNotaDebito.desCondicionRef.Contains("TRANSFERENCIA"))
            {
                //Total en Letras
                oNdImpresion.AgregarDatos(enLetras("0.00") + Moneda, "38", "122");

                Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totsubTotal).ToString("N2");
                oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "129.5");
                Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2");
                oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "135.5");
                Numeros = oNdImpresion.AlinearDerecha("0.00".Length, 6) + "0.00";
                oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "141.8");
            }
            else
            {
                //Total en Letras
                oNdImpresion.AgregarDatos(enLetras(oNotaDebito.totTotal.ToString()) + Moneda, "38", "122");

                Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totsubTotal).ToString("N2");
                oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "129.5");
                Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2");
                oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "135.5");
                Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2");
                oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "141.8");
            }

            //Imprimiendo
            oNdImpresion.ImprimirND(nomImpresora);
        }

        private void Letras(LetrasE oLetra, String nomImpresora)
        {
            LetrasAgrogenesis oLetraImpresion = new LetrasAgrogenesis();

            oLetraImpresion.AgregarDatos(oLetra.Numero, "42", "24"); //1

            if (oLetra.ListaFacturas.Count > 1) //1
            {
                oLetraImpresion.AgregarDatos(oLetra.ListaFacturas[0].idDocumento + "/" + Global.Derecha(oLetra.ListaFacturas[0].numSerie, 2) + "-" + Global.Derecha(oLetra.ListaFacturas[0].numDocumento, 5) + "\n\r" +
                                            oLetra.ListaFacturas[1].idDocumento + "/" + Global.Derecha(oLetra.ListaFacturas[1].numSerie, 2) + "-" + Global.Derecha(oLetra.ListaFacturas[1].numDocumento, 5), "66", "23.5");
            }
            else
            {
                oLetraImpresion.AgregarDatos(oLetra.ListaFacturas[0].idDocumento + "/" + Global.Derecha(oLetra.ListaFacturas[0].numSerie, 2) + "-" + Global.Derecha(oLetra.ListaFacturas[0].numDocumento, 5), "66", "23.5");
            }

            oLetraImpresion.AgregarDatos(oLetra.Fecha.ToString("d"), "95", "26.6"); //2
            oLetraImpresion.AgregarDatos(oLetra.desPlazaGirador, "128", "23.5"); //1
            oLetraImpresion.AgregarDatos(oLetra.FechaVenc.ToString("d"), "152", "26.8"); //2
            oLetraImpresion.AgregarDatos(oLetra.desMoneda + " " + oLetra.MontoOrigen.ToString("N2"), "177", "24.5"); //1

            String MonedaFinal = (from x in VariablesLocales.ListaMonedas where x.idMoneda == oLetra.idMoneda select x.desMoneda).SingleOrDefault();
            oLetraImpresion.AgregarDatos(enLetras(oLetra.MontoOrigen.ToString()) + " " + MonedaFinal.ToUpper(), "42", "39.8");

            oLetraImpresion.AgregarDatos(oLetra.GiradoA, "53", "50");
            oLetraImpresion.AgregarDatos(oLetra.Direccion, "50", "55");
            oLetraImpresion.AgregarDatos(oLetra.desPlazaGiradoA, "51.5", "59.6");
            oLetraImpresion.AgregarDatos(oLetra.RUC, "55.6", "64");

            oLetraImpresion.AgregarDatos(oLetra.Aval, "59", "85");
            oLetraImpresion.AgregarDatos(oLetra.DireccionAval, "51", "90");
            //oLetraImpresion.AgregarDatos(oLetra.desPlazaGiradoA, "40", "90");
            oLetraImpresion.AgregarDatos(oLetra.DoiAval, "56", "95");

            //Imprimiendo
            oLetraImpresion.ImprimirLetra(nomImpresora);
        }

        #endregion

        #region Numeros a Letras

        static String enLetras(String num)
        {
            String Retorno = String.Empty;
            String Dec = String.Empty;
            Int64 Entero;
            Int32 Decimales;
            Double Nro;

            try
            {
                Nro = Convert.ToDouble(num);
            }
            catch
            {
                return String.Empty;
            }

            Entero = Convert.ToInt64(Math.Truncate(Nro));
            Decimales = Convert.ToInt32(Math.Round((Nro - Entero) * 100, 2));

            if (Decimales < 10)
            {
                Dec = " Y " + "0" + Decimales.ToString() + "/100 ";
            }
            else
            {
                Dec = " Y " + Decimales.ToString() + "/100 ";
            }

            Retorno = toText(Convert.ToDouble(Entero)) + Dec;

            return Retorno;
        }

        static String toText(Double Valor)
        {
            String Num2Text = String.Empty;

            Valor = Math.Truncate(Valor);

            if (Valor == 0) Num2Text = "CERO";
            else if (Valor == 1) Num2Text = "UNO";
            else if (Valor == 2) Num2Text = "DOS";
            else if (Valor == 3) Num2Text = "TRES";
            else if (Valor == 4) Num2Text = "CUATRO";
            else if (Valor == 5) Num2Text = "CINCO";
            else if (Valor == 6) Num2Text = "SEIS";
            else if (Valor == 7) Num2Text = "SIETE";
            else if (Valor == 8) Num2Text = "OCHO";
            else if (Valor == 9) Num2Text = "NUEVE";
            else if (Valor == 10) Num2Text = "DIEZ";
            else if (Valor == 11) Num2Text = "ONCE";
            else if (Valor == 12) Num2Text = "DOCE";
            else if (Valor == 13) Num2Text = "TRECE";
            else if (Valor == 14) Num2Text = "CATORCE";
            else if (Valor == 15) Num2Text = "QUINCE";
            else if (Valor < 20) Num2Text = "DIECI" + toText(Valor - 10);
            else if (Valor == 20) Num2Text = "VEINTE";
            else if (Valor < 30)
            {
                if (toText(Valor - 20) == "UNO")
                {
                    Num2Text = "VEINTIUN";
                }
                else
                {
                    Num2Text = "VEINTI" + toText(Valor - 20);
                }
            }
            else if (Valor == 30) Num2Text = "TREINTA";
            else if (Valor == 40) Num2Text = "CUARENTA";
            else if (Valor == 50) Num2Text = "CINCUENTA";
            else if (Valor == 60) Num2Text = "SESENTA";
            else if (Valor == 70) Num2Text = "SETENTA";
            else if (Valor == 80) Num2Text = "OCHENTA";
            else if (Valor == 90) Num2Text = "NOVENTA";
            else if (Valor < 100) Num2Text = toText(Math.Truncate(Valor / 10) * 10) + " Y " + toText(Valor % 10);
            else if (Valor == 100) Num2Text = "CIEN";
            else if (Valor < 200) Num2Text = "CIENTO " + toText(Valor - 100);
            else if ((Valor == 200) || (Valor == 300) || (Valor == 400) || (Valor == 600) || (Valor == 800)) Num2Text = toText(Math.Truncate(Valor / 100)) + "CIENTOS";
            else if (Valor == 500) Num2Text = "QUINIENTOS";
            else if (Valor == 700) Num2Text = "SETECIENTOS";
            else if (Valor == 900) Num2Text = "NOVECIENTOS";
            else if (Valor < 1000) Num2Text = toText(Math.Truncate(Valor / 100) * 100) + " " + toText(Valor % 100);
            else if (Valor == 1000) Num2Text = "MIL";
            else if (Valor < 2000) Num2Text = "MIL " + toText(Valor % 1000);

            else if (Valor < 1000000)
            {
                Num2Text = toText(Math.Truncate(Valor / 1000)) + " MIL";
                if ((Valor % 1000) > 0) Num2Text = Num2Text + " " + toText(Valor % 1000);
            }

            else if (Valor == 1000000) Num2Text = "UN MILLON";
            else if (Valor < 2000000) Num2Text = "UN MILLON " + toText(Valor % 1000000);
            else if (Valor < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(Valor / 1000000)) + " MILLONES ";
                if ((Valor - Math.Truncate(Valor / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(Valor - Math.Truncate(Valor / 1000000) * 1000000);
            }

            else if (Valor == 1000000000000) Num2Text = "UN BILLON";
            else if (Valor < 2000000000000) Num2Text = "UN BILLON " + toText(Valor - Math.Truncate(Valor / 1000000000000) * 1000000000000);
            else
            {
                Num2Text = toText(Math.Truncate(Valor / 1000000000000)) + " BILLONES";
                if ((Valor - Math.Truncate(Valor / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(Valor - Math.Truncate(Valor / 1000000000000) * 1000000000000);
            }

            return Num2Text;
        }

        #endregion

    }
}
