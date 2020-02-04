using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Impresion.AgroGenesis
{
    public class ImpresionAgro : IImpresion
    {

        #region Variables

        public VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        NumControlDetE ControlDocumento = null;
        Boolean UsarNombreCompuesto = VariablesLocales.oVenParametros.indNomArtCompuesto;

        #endregion

        #region Procedimientos Publicos

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
        }

        #endregion

        #region Procedimientos Privados

        private void GuiaVentas(EmisionDocumentoE oGuia, String nomImpresora)
        {
            GuiasAgro oGuiaImpresion = new GuiasAgro();
            String NombreArticulo = String.Empty;
            DateTime fecTraslado = Convert.ToDateTime(oGuia.fecTraslado);
            List<String> Palabras = null;
            StringBuilder CadenaDireccion = new StringBuilder();
            Int32 totLetras = 0;
            String PrimerParrafo = String.Empty;
            String SegundoParrafo = String.Empty;

            //Fecha de Emisión de la Guia
            //oGuiaImpresion.AgregarDatos(oGuia.fecEmision.ToString("d"), "40", "55"); //Por revisar

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

                oGuiaImpresion.AgregarDatos(PrimerParrafo, "10", "68.8");
                oGuiaImpresion.AgregarDatos(SegundoParrafo, "10", "71.8");
                CadenaDireccion.Clear();
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.PuntoPartida, "10", "68.8");
            }

            //Punto de Llegada
            if (oGuia.PuntoLlegada.Length > 45)
            {
                CadenaDireccion.Clear();
                Palabras = new List<String>(oGuia.PuntoLlegada.Split(' '));
                String TercerParrafo = String.Empty;

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    CadenaDireccion.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion.Length <= 40)
                    {
                        continue;
                    }
                    else
                    {
                        PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
                        break;
                    }
                }

                CadenaDireccion.Clear();
                Palabras = new List<String>(oGuia.PuntoLlegada.Replace(PrimerParrafo, "").Trim().Split(' '));

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    CadenaDireccion.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion.Length <= 60)
                    {
                        continue;
                    }
                    else
                    {
                        SegundoParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
                        break;
                    }
                }

                TercerParrafo = oGuia.PuntoLlegada.Replace(PrimerParrafo, "").Trim().Replace(SegundoParrafo, "").Trim();

                oGuiaImpresion.AgregarDatos(PrimerParrafo, "130", "63.6");
                oGuiaImpresion.AgregarDatos(SegundoParrafo, "104", "66.8");
                oGuiaImpresion.AgregarDatos(TercerParrafo, "104", "69.8");

                CadenaDireccion.Clear();
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.PuntoLlegada, "104", "68.8");
            }

            //Fecha de traslado
            oGuiaImpresion.AgregarDatos(Convert.ToDateTime(oGuia.fecTraslado).ToString("dd/MM/yyyy"), "11", "81.5");
            oGuiaImpresion.AgregarDatos(oGuia.RazonSocial, "104", "81.5");
            oGuiaImpresion.AgregarDatos(oGuia.numRuc, "125", "88");

            //Transporte y Conductores (Lado Izquierdo)
            oGuiaImpresion.AgregarDatos(oGuia.MarcaTransp + " " + oGuia.PlacaTransp, "53", "106");
            oGuiaImpresion.AgregarDatos(oGuia.inscripTransp, "60", "112.5");
            oGuiaImpresion.AgregarDatos(oGuia.LicenciaTransp, "58", "118.5");

            //Transportista (Lado Derecho)
            if (oGuia.RazonSocialTransp.Length >= 45)
            {
                CadenaDireccion.Clear();
                Palabras = new List<String>(oGuia.RazonSocialTransp.Split(' '));

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

                SegundoParrafo = oGuia.RazonSocialTransp.Replace(PrimerParrafo, "").Trim();

                oGuiaImpresion.AgregarDatos(PrimerParrafo, "105", "110");
                oGuiaImpresion.AgregarDatos(SegundoParrafo, "105", "113");
                CadenaDireccion.Clear();
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.RazonSocialTransp, "105", "110");
            }

            oGuiaImpresion.AgregarDatos(oGuia.RucTransp, "125", "119");

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
            oGuiaImpresion.AgregarItems(" | | | ", ControlDocumento.cantCaracteres);
            oGuiaImpresion.AgregarItems(" |Atencion: " + oGuia.Glosa + "|" + " | ", ControlDocumento.cantCaracteres);
            
            if (oGuia.ListaCanjeGuias != null && oGuia.ListaCanjeGuias.Count > 0)
            {
                //Tipo
                if (oGuia.ListaCanjeGuias[0].idDocumentoFact == "FV")
                {
                    oGuiaImpresion.AgregarDatos("FACTURA", "15", "239.5");
                }
                else
                {
                    oGuiaImpresion.AgregarDatos("BOLETA", "15", "239.5");
                }

                //Numero factura
                oGuiaImpresion.AgregarDatos(oGuia.ListaCanjeGuias[0].numSerieFact + "-" + oGuia.ListaCanjeGuias[0].numDocumentoFact, "22", "246.5");
            }
            else
            {
                oGuiaImpresion.AgregarDatos("FACTURA", "15", "239.5");
                oGuiaImpresion.AgregarDatos("XXXX-XXXXXXXX", "22", "246.5");
            }
            
            //Imprimiendo la guia de traslado
            oGuiaImpresion.ImprimirGuia(nomImpresora);
        }

        private void Facturas(EmisionDocumentoE oFactura, String nomImpresora)
        {
            String Moneda = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oFactura.fecEmision);
            FacturasAgro oFacturaImpresion = new FacturasAgro();
            String NombreArticulo = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oFactura.idMoneda
                                select x).SingleOrDefault();
            string IGV = "0.00";
            string SubTotal = "0.00";
            String ToTotal = "0.00";

            //Cabecera (Dato, x, y)

            oFacturaImpresion.AgregarDatos(oFactura.RazonSocial, "28", "49");
            oFacturaImpresion.AgregarDatos(oFactura.Direccion, "25", "59");
            oFacturaImpresion.AgregarDatos(oFactura.numRuc, "155", "52");

            //oFacturaImpresion.AgregarDatos(oFactura.RazonSocial, "29", "75.5");
            //oFacturaImpresion.AgregarDatos(oFactura.Direccion, "28", "84.5");
            //oFacturaImpresion.AgregarDatos(oFactura.numRuc, "157", "75.5");


            /*oFacturaImpresion.AgregarDatos(Convert.ToDateTime(oFactura.fecEmision).ToString("dd/MM/yyyy"), "157", "82.2"); *///Por revisar
            oFacturaImpresion.AgregarDatos(Convert.ToDateTime(oFactura.fecEmisionFact).ToString("dd"), "19", " 43");
            oFacturaImpresion.AgregarDatos(Convert.ToDateTime(oFactura.fecEmisionFact).ToString("MMMM"), "45", " 43");
            oFacturaImpresion.AgregarDatos(Convert.ToDateTime(oFactura.fecEmisionFact).ToString("yyyy"), "75", "43");
            ///

            if (oFactura.ListaCanjeGuias != null && oFactura.ListaCanjeGuias.Count > 0)
            {
              //  oFacturaImpresion.AgregarDatos("Lista de Guia" +oFactura.ListaCanjeGuias[0].numSerieGuia + "-" + oFactura.ListaCanjeGuias[0].numDocumentoGuia, "39.5", "73.2"); //guia
            }
            else
            {
                oFacturaImpresion.AgregarDatos(" ", "39.5", "88.5"); //guia
            }

           // oFacturaImpresion.AgregarDatos(oFactura.desCondicion, "157", "88.5");

            ////Detalle (Separarlo por Palotes)
            string tot = String.Empty;
            string Precio = String.Empty;

            foreach (EmisionDocumentoDetE item in oFactura.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    NombreArticulo = (!UsarNombreCompuesto ? item.nomArticulo : (item.tipArticulo == "AR" ? item.desNomArtCompuesto : item.nomArticulo));
                    tot = oFacturaImpresion.AlinearDerecha(Convert.ToDecimal(item.subTotal).ToString("N2").Length, 6) + Convert.ToDecimal(item.subTotal).ToString("N2");
                    Precio = oFacturaImpresion.AlinearDerecha(Convert.ToDecimal(item.PrecioCad).ToString("N2").Length, 6) + Convert.ToDecimal(item.PrecioCad).ToString("N2");

                    oFacturaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + NombreArticulo + "|" + oMoneda.desAbreviatura + Precio + "|"
                        + (item.indCalculo == true ? oMoneda.desAbreviatura + tot : (oFactura.DsctoGlobal > 0 ? item.SubTotalCad : "")), ControlDocumento.cantCaracteres);
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
            SubTotal = oFacturaImpresion.AlinearDerecha(oFactura.totsubTotal.ToString("N2").Length, 10) +Convert.ToDecimal(oFactura.totsubTotal).ToString("N2");
            IGV = oFacturaImpresion.AlinearDerecha(oFactura.totIgv.ToString().Length, 13 ) + Convert.ToDecimal(oFactura.totIgv).ToString("N2");
            ToTotal = oFacturaImpresion.AlinearDerecha(oFactura.totTotal.ToString("N2").Length, 9) + Convert.ToDecimal(oFactura.totTotal).ToString("N2");
            //oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oFactura.totsubTotal.ToString("N2"), "171", "125");
            //oFacturaImpresion.AgregarDatos(oFactura.totIgv.ToString(), "171", "131.5");
            //oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oFactura.totTotal.ToString("N2"), "171", "138");
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + SubTotal, "169", "128");
            oFacturaImpresion.AgregarDatos(IGV, "169", "133.5");
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + ToTotal, "169", "138.5");
           
            
            //Fecha de Cancelacion 
            //oFacturaImpresion.AgregarDatos("Cancelacion  " + Convert.ToDateTime(oFactura.FechaPago).ToString("dd"), "40", " 150");
            //oFacturaImpresion.AgregarDatos(" " + Convert.ToDateTime(oFactura.FechaPago).ToString("MMMM"), "90", " 150");
            //oFacturaImpresion.AgregarDatos(" " + Convert.ToDateTime(oFactura.FechaPago).ToString("yyyy"), "130", " 150");
            //if (oFactura.totIgv > 0)
            //{
            //    oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oFactura.totIgv.Value.ToString("N2"), "134", "247");
            //}

            Moneda = " " + oMoneda.desMoneda.ToUpper();

            //if (Convert.ToInt32(oFactura.idMoneda) == (Int32)EnumTipoMoneda.Soles)
            //{
            //    Moneda = " SOLES";
            //}
            //else if (Convert.ToInt32(oFactura.idMoneda) == (Int32)EnumTipoMoneda.Dolares)
            //{
            //    Moneda = " DOLARES AMERICANOS";
            //}
            //else
            //{
            //    Moneda = " EUROS";
            //}

            if (oFactura.desCondicion.Contains("TRANSFERENCIA"))
            {
                //oFacturaImpresion.AgregarDatos("TRANSFERENCIA A TITULO GRATUITO.", "25", "220");
                             
                oFacturaImpresion.AgregarDatos( oMoneda.desAbreviatura + " 0.00", "166", "166");
                oFacturaImpresion.AgregarDatos(enLetras("0.00") + Moneda, "25", "120");
            }
            else
            {
               // oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oFactura.totTotal.ToString("N2"), "172", "170");
                ////Total en Letras
                oFacturaImpresion.AgregarDatos(enLetras(oFactura.totTotal.ToString()) + Moneda, "25", "120");
                
            }

            //Imprimiendo
            oFacturaImpresion.ImprimirFactura(nomImpresora);
        }

        private void BoletaVenta(EmisionDocumentoE oBoleta, String nomImpresora)
        {
            String Moneda = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oBoleta.fecEmision);
            BoletasAgro oBoletaImpresion = new BoletasAgro();
            String NombreArticulo = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oBoleta.idMoneda
                                select x).SingleOrDefault();

            //Cabecera (Dato, x, y)
            oBoletaImpresion.AgregarDatos(oBoleta.RazonSocial, "32", "55");
            oBoletaImpresion.AgregarDatos(oBoleta.Direccion, "32", "60");
            oBoletaImpresion.AgregarDatos(oBoleta.numRuc, "155", "60");
            //oBoletaImpresion.AgregarDatos(fecEmision.ToString("dd"), "154", "82.2");
            oBoletaImpresion.AgregarDatos(Convert.ToDateTime(oBoleta.fecEmision).ToString("dd"), "30", "45");
            oBoletaImpresion.AgregarDatos(Convert.ToDateTime(oBoleta.fecEmision).ToString("MMMM"), "66", "45");
            oBoletaImpresion.AgregarDatos(Convert.ToDateTime(oBoleta.fecEmision).ToString("yyyy"), "95", "45");
            if (oBoleta.ListaCanjeGuias != null && oBoleta.ListaCanjeGuias.Count > 0)
            {
               // oBoletaImpresion.AgregarDatos(oBoleta.ListaCanjeGuias[0].numSerieGuia + "-" + oBoleta.ListaCanjeGuias[0].numDocumentoGuia, "37", "89"); //guia empresa store herrajes no admiten guia
            }
            else
            {
                //oBoletaImpresion.AgregarDatos(" ", "37", "89"); //guia
            }

            //oBoletaImpresion.AgregarDatos(oBoleta.desCondicion, "154", "90");

            ////Detalle (Separarlo por Palotes)
            String subtot = String.Empty;
            String Precio = String.Empty;

            foreach (EmisionDocumentoDetE item in oBoleta.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    NombreArticulo = (!UsarNombreCompuesto ? item.nomArticulo : (item.tipArticulo == "AR" ? item.desNomArtCompuesto : item.nomArticulo));
                    subtot = oBoletaImpresion.AlinearDerecha(Convert.ToDecimal(item.subTotal).ToString("N2").Length, 6) + Convert.ToDecimal(item.subTotal).ToString("N2");
                    Precio = oBoletaImpresion.AlinearDerecha(Convert.ToDecimal(item.PrecioCad).ToString("N2").Length, 6) + Convert.ToDecimal(item.PrecioCad).ToString("N2");

                    oBoletaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + NombreArticulo + "|" + oMoneda.desAbreviatura + Precio + "|"
                        + (item.indCalculo == true ? oMoneda.desAbreviatura + subtot : (oBoleta.DsctoGlobal > 0 ? item.SubTotalCad : "")), ControlDocumento.cantCaracteres);
                }
                else
                {
                    if (oBoleta.desCondicion.Contains("TRANSFERENCIA"))
                    {
                        oBoletaImpresion.AgregarItems("|" + item.nomArticulo + "||", ControlDocumento.cantCaracteres);
                    }
                }
            }

            if (oBoleta.desCondicion.Contains("TRANSFERENCIA"))
            {
                oBoletaImpresion.AgregarDatos("TRANSFERENCIA A TITULO GRATUITO.", "25", "220");
                oBoletaImpresion.AgregarDatos(oMoneda.desAbreviatura + " 0.00", "171", "244");
                oBoletaImpresion.AgregarDatos(enLetras("0.00") + Moneda, "23", "259");
            }
            else
            {
                string Total = "0.000";

                //SubTotal = oFacturaImpresion.AlinearDerecha(oFactura.totsubTotal.ToString("N2").Length, 10) + Convert.ToDecimal(oFactura.totsubTotal).ToString("N2");
                //IGV = oFacturaImpresion.AlinearDerecha(oFactura.totIgv.ToString().Length, 13) + Convert.ToDecimal(oFactura.totIgv).ToString("N2");
                //ToTotal = oFacturaImpresion.AlinearDerecha(oFactura.totTotal.ToString("N2").Length, 9) + Convert.ToDecimal(oFactura.totTotal).ToString("N2");

                Total = oBoletaImpresion.AlinearDerecha(oBoleta.totTotal.ToString("N2").Length, 6) + Convert.ToDecimal(oBoleta.totTotal).ToString("N2");
                oBoletaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + Total,"181","138.7");
                //oBoletaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oBoleta.totTotal.ToString("N2"), "185", "135.7");
                ////Total en Letras
                oBoletaImpresion.AgregarDatos(enLetras(oBoleta.totTotal.ToString()) + Moneda, "51", "136");




                
            }

            //Imprimiendo
            oBoletaImpresion.ImprimirBoleta(nomImpresora);
        }

        private void NotaDeCreditoNC(EmisionDocumentoE oNotaCredito, String nomImpresora)
        {
            NotasDeCreditoAgro oNcImpresion = new NotasDeCreditoAgro();
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

            oNcImpresion.AgregarDatos(oNotaCredito.RazonSocial, "26", "53.6");

            //Dirección
            if (oNotaCredito.Direccion.Length >= 47)
            {
                Int32 totLetras = 0;
                StringBuilder CadenaDireccion = new StringBuilder();
                List<String> Palabras = new List<String>(oNotaCredito.Direccion.Split(' '));
                String PrimerParrafo = String.Empty;
                String SegundoParrafo = String.Empty;

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

                oNcImpresion.AgregarDatos(PrimerParrafo, "25", "60");
                oNcImpresion.AgregarDatos(SegundoParrafo, "25", "63");
                CadenaDireccion.Clear();
            }
            else
            {
                oNcImpresion.AgregarDatos(oNotaCredito.Direccion, "32", "60");

            }

            //oNcImpresion.AgregarDatos(oNotaCredito.fecEmision.ToString("d"), "21", "68"); //Por revisar
            oNcImpresion.AgregarDatos(oNotaCredito.numRuc, "25", "66");

            oNcImpresion.AgregarDatos(NombreDocumento, "135", "60");
            oNcImpresion.AgregarDatos(oNotaCredito.serDocumentoRef + "-" + oNotaCredito.numDocumentoRef, "135", "68");
            oNcImpresion.AgregarDatos(Convert.ToDateTime(oNotaCredito.fecDocumentoRef).ToString("dd/MM/yyyy"), "90", "66");

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
            oNcImpresion.AgregarDatos(oNotaCredito.desCondicion, "50", "133.5");

            if (!String.IsNullOrEmpty(oNotaCredito.Glosa))
            {
                oNcImpresion.AgregarDatos(oNotaCredito.Glosa, "50", "138");
            }

            //Total en Letras
            String LetrasNumeros = String.Empty;


            //Totales
            string Numeros = String.Empty;

            if (oNotaCredito.desCondicionRef.Contains("TRANSFERENCIA"))
            {
                Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totsubTotal).ToString("N2");
                oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "180", "126");
                Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2").Length, 8) + Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2");
                oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "180", "132");
                Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
                oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "180", "137");

                LetrasNumeros = "Son: " + enLetras("0.00") + Moneda;
            }
            else
            {
                Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totsubTotal).ToString("N2");
                oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "180", "126");
                Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2").Length, 8) + Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2");
                oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "180", "132");
                Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
                oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "180", "137");

                LetrasNumeros = "Son: " + enLetras(oNotaCredito.totTotal.ToString()) + Moneda;
            }


       


            if (LetrasNumeros.Length >= 57)
            {
                Int32 totLetras = 0;
                StringBuilder Cadena = new StringBuilder();
                List<String> Palabras = new List<String>(LetrasNumeros.Split(' '));
                String PrimerParrafo = String.Empty;
                String SegundoParrafo = String.Empty;

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    Cadena.Append(item.Trim()).Append(" ");

                    if (Cadena.Length <= 57)
                    {
                        continue;
                    }
                    else
                    {
                        PrimerParrafo = Cadena.ToString().Substring(0, Cadena.ToString().Trim().Length - totLetras);
                        break;
                    }
                }

                SegundoParrafo = LetrasNumeros.Replace(PrimerParrafo, "").Trim();

                if (String.IsNullOrEmpty(SegundoParrafo))
                {
                    oNcImpresion.AgregarDatos(PrimerParrafo, "30", "84");
                }
                else
                {
                    
                        oNcImpresion.AgregarDatos(PrimerParrafo, "30", "84");
                         oNcImpresion.AgregarDatos(SegundoParrafo, "30", "84");
                }

                Cadena.Clear();
            }
            else
            {
                oNcImpresion.AgregarDatos(LetrasNumeros, "33", "118");
            }

            //Imprimiendo
            oNcImpresion.ImprimirNC(nomImpresora);
        }

        private void NotaDeDebitoND(EmisionDocumentoE oNotaDebito, String nomImpresora)
        {
            NotasDeDebitoAgro oNdImpresion = new NotasDeDebitoAgro();
            String NombreDocumento = String.Empty;
            String Moneda = String.Empty;
            String Ruc = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oNotaDebito.idMoneda
                                select x).SingleOrDefault();

            //Cabecera
            if (oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FE.ToString() || oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FS.ToString() ||
                oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FV.ToString())
            {
                NombreDocumento = "Factura de Venta";
            }
            else if (oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.BV.ToString())
            {
                NombreDocumento = "Boleta de Venta";
            }

            oNdImpresion.AgregarDatos(oNotaDebito.RazonSocial, "21", "54.5");

            //Dirección
            if (oNotaDebito.Direccion.Length >= 47)
            {
                Int32 totLetras = 0;
                StringBuilder CadenaDireccion = new StringBuilder();
                List<String> Palabras = new List<String>(oNotaDebito.Direccion.Split(' '));
                String PrimerParrafo = String.Empty;
                String SegundoParrafo = String.Empty;

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

                oNdImpresion.AgregarDatos(PrimerParrafo, "21", "62.5");
                oNdImpresion.AgregarDatos(SegundoParrafo, "7", "66");
                CadenaDireccion.Clear();
            }
            else
            {
                oNdImpresion.AgregarDatos(oNotaDebito.Direccion, "21", "63");
            }

            //oNdImpresion.AgregarDatos(oNotaDebito.fecEmision.ToString("d"), "21", "70"); //Por revisar
            oNdImpresion.AgregarDatos(oNotaDebito.numRuc, "21", "76");

            oNdImpresion.AgregarDatos(NombreDocumento, "135", "62.5");
            oNdImpresion.AgregarDatos(oNotaDebito.serDocumentoRef + "-" + oNotaDebito.numDocumentoRef, "135", "70");
            oNdImpresion.AgregarDatos(Convert.ToDateTime(oNotaDebito.fecDocumentoRef).ToString("dd/MM/yyyy"), "135", "76");

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

            //Total en Letras
            String LetrasNumeros = "Son: " + enLetras(oNotaDebito.totTotal.ToString()) + Moneda;

            if (LetrasNumeros.Length >= 57)
            {
                Int32 totLetras = 0;
                StringBuilder Cadena = new StringBuilder();
                List<String> Palabras = new List<String>(LetrasNumeros.Split(' '));
                String PrimerParrafo = String.Empty;
                String SegundoParrafo = String.Empty;

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    Cadena.Append(item.Trim()).Append(" ");

                    if (Cadena.Length <= 57)
                    {
                        continue;
                    }
                    else
                    {
                        PrimerParrafo = Cadena.ToString().Substring(0, Cadena.ToString().Trim().Length - totLetras);
                        break;
                    }
                }

                SegundoParrafo = LetrasNumeros.Replace(PrimerParrafo, "").Trim();

                if (String.IsNullOrEmpty(SegundoParrafo))
                {
                    oNdImpresion.AgregarDatos(PrimerParrafo, "33", "123");
                }
                else
                {
                    oNdImpresion.AgregarDatos(PrimerParrafo, "33", "120");
                    oNdImpresion.AgregarDatos(SegundoParrafo, "33", "123");
                }

                Cadena.Clear();
            }
            else
            {
                oNdImpresion.AgregarDatos("Son: " + enLetras(oNotaDebito.totTotal.ToString()) + Moneda, "33", "123");
            }

            //Motivo
            oNdImpresion.AgregarDatos(oNotaDebito.desCondicion, "50", "128.5");

            if (!String.IsNullOrEmpty(oNotaDebito.Glosa))
            {
                oNdImpresion.AgregarDatos(oNotaDebito.Glosa, "50", "131.5");
            }

            //Totales
            String Numeros = String.Empty;

            if (oNotaDebito.desCondicionRef.Contains("TRANSFERENCIA"))
            {
                Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totsubTotal).ToString("N2");
                oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "174", "128.5");
                Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2");
                oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "174", "134.5");
                Numeros = oNdImpresion.AlinearDerecha("0.00".Length, 6) + "0.00";
                oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "174", "146.8");
            }
            else
            {
                Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totsubTotal).ToString("N2");
                oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "174", "128.5");
                Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2");
                oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "174", "134.5");
                Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2");
                oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "174", "146.8");
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
            oLetraImpresion.AgregarDatos(oLetra.desMoneda + " " + oLetra.MontoOrigen.ToString("N2"), "178", "24.5"); //1

            String MonedaFinal = (from x in VariablesLocales.ListaMonedas where x.idMoneda == oLetra.idMoneda select x.desMoneda).SingleOrDefault();
            oLetraImpresion.AgregarDatos(enLetras(oLetra.MontoOrigen.ToString()) + " " + MonedaFinal.ToUpper(), "42", "39.8");

            oLetraImpresion.AgregarDatos(oLetra.GiradoA, "53", "50");
            oLetraImpresion.AgregarDatos(oLetra.Direccion, "52", "55");
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

        private static String enLetras(String num)
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

        private static String toText(Double Valor)
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
