using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Impresion.Intermetal
{
    public class ImpresionInter : IImpresion
    {

        #region Variables

        public VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        NumControlDetE ControlDocumento = null;

        #endregion

        #region Numeros a Letras

        public static String enLetras(String num)
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
                Int32 CantidadRegistros = DocumentoEmision.ListaItemsDocumento.Count;

                if (CantidadRegistros > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de items a sobrepasado la configuración guardada para este documento.");
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
                Int32 CantidadRegistros = DocumentoEmision.ListaItemsDocumento.Count;

                if (CantidadRegistros > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de items a sobrepasado la configuración guardada para este documento.");
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
                Int32 CantidadRegistros = DocumentoEmision.ListaItemsDocumento.Count;

                if (CantidadRegistros > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de items a sobrepasado la configuración guardada para este documento.");
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
                Int32 CantidadRegistros = DocumentoEmision.ListaItemsDocumento.Count;

                if (CantidadRegistros > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de items a sobrepasado la configuración guardada para este documento.");
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
                Int32 CantidadRegistros = DocumentoEmision.ListaItemsDocumento.Count;

                if (CantidadRegistros > ControlDocumento.cantItems)
                {
                    throw new Exception("La cantidad de items a sobrepasado la configuración guardada para este documento.");
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
            //if (String.IsNullOrEmpty(RutaImpresion.Trim()))
            //{
            //    throw new Exception("No se encontró la ruta o el nombre de le impresora.");
            //}

            //Letras(oLetra, RutaImpresion);
        }

        #endregion

        #region Procedimientos Privados

        private void GuiaVentas(EmisionDocumentoE oGuia, String nomImpresora)
        {
            GuiasInter oGuiaImpresion = new GuiasInter();
            DateTime fecTraslado = Convert.ToDateTime(oGuia.fecTraslado);
            StringBuilder CadenaDireccion = new StringBuilder();
            String PrimerParrafo = String.Empty;
            String SegundoParrafo = String.Empty;

            //Fecha de Emisión de la Guia
            //Por revisar//oGuiaImpresion.AgregarDatos(oGuia.fecEmision.ToString("dd"), "16", "41");
            //Por revisar//oGuiaImpresion.AgregarDatos(oGuia.fecEmision.ToString("MM"), "25", "41");
            //Por revisar//oGuiaImpresion.AgregarDatos(oGuia.fecEmision.ToString("yyyy"), "34", "41");

            //Destinatario
            oGuiaImpresion.AgregarDatos("DESTINATARIO", "2", "51");
            oGuiaImpresion.AgregarDatos("Razón Social: " + oGuia.RazonSocial, "2", "55");
            oGuiaImpresion.AgregarDatos("Dirección: " + oGuia.Direccion, "2", "59");
            oGuiaImpresion.AgregarDatos("R.U.C.: " + oGuia.numRuc, "2", "63");
            oGuiaImpresion.AgregarDatos("N° Orden de Compra: " + oGuia.numDocumentoRef, "2", "67");

            //Unidad de Transporte/Conductor
            oGuiaImpresion.AgregarDatos("UNIDAD DE TRANSPORTE/CONDUCTOR", "118", "51");
            oGuiaImpresion.AgregarDatos("Vehículo Marca y Placa: " + oGuia.MarcaTransp + " " + oGuia.PlacaTransp, "118", "55");
            oGuiaImpresion.AgregarDatos("Certificado de Inspección: " + oGuia.inscripTransp, "118", "63");
            oGuiaImpresion.AgregarDatos("Licencia de Conducir: " + oGuia.LicenciaTransp, "118", "67");

            //Titulos del detalle
            oGuiaImpresion.AgregarDatos("".PadLeft(140, '-'), "2", "72");
            oGuiaImpresion.AgregarDatos("Código", "5", "74");
            oGuiaImpresion.AgregarDatos("Cantidad", "22", "74");
            oGuiaImpresion.AgregarDatos("Und.Med.", "40", "74");
            oGuiaImpresion.AgregarDatos("Descripción", "115", "74");
            oGuiaImpresion.AgregarDatos("".PadLeft(140, '-'), "2", "76");

            //Detalle(Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oGuia.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    oGuiaImpresion.AgregarItems(item.codArticulo + '|' + Convert.ToInt32(item.Cantidad).ToString("N2") + "|"
                        + item.desUMedida + "|" + item.nomArticulo);
                }
            }

            oGuiaImpresion.AgregarDatos("Domicilio de Partida: " + oGuia.PuntoPartida, "2", "165");
            oGuiaImpresion.AgregarDatos("Domicilio de Llegada: " + oGuia.PuntoLlegada, "2", "168");

            //Imprimiendo la guia de traslado
            oGuiaImpresion.ImprimirGuia(nomImpresora);
        }

        private void Facturas(EmisionDocumentoE oFactura, String nomImpresora)
        {
            String Moneda = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oFactura.fecEmision);
            FacturasInter oFacturaImpresion = new FacturasInter();
            List<string> Palabras = null;
            StringBuilder CadenaDireccion = new StringBuilder();
            Int32 totLetras = 0;
            String PrimerParrafo = String.Empty;
            String SegundoParrafo = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oFactura.idMoneda
                                select x).SingleOrDefault();

            //Cabecera (Dato, x, y)
            oFacturaImpresion.AgregarDatos(oFactura.RazonSocial, "23", "55");

            //Dirección...
            if (oFactura.Direccion.Length > 60)
            {
                Palabras = new List<String>(oFactura.Direccion.Split(' '));

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
                        PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
                        break;
                    }
                }

                SegundoParrafo = oFactura.Direccion.Replace(PrimerParrafo, "").Trim();

                oFacturaImpresion.AgregarDatos(PrimerParrafo, "15", "62");
                oFacturaImpresion.AgregarDatos(SegundoParrafo, "3", "65");
                CadenaDireccion.Clear();
            }
            else
            {
                oFacturaImpresion.AgregarDatos(oFactura.Direccion, "15", "63");
            }

            oFacturaImpresion.AgregarDatos(oFactura.numRuc, "12", "68");
            //oFacturaImpresion.AgregarDatos(oFactura.fecEmision.ToString("d"), "123", "55"); //Por revisar
            //oFacturaImpresion.AgregarDatos(oFactura.fecVencimiento.Value.ToString("d"), "172", "55"); //Por revisar
            oFacturaImpresion.AgregarDatos(!String.IsNullOrEmpty(oFactura.serDocumentoRef) ? 
                                            oFactura.serDocumentoRef + "-" + oFactura.numDocumentoRef : oFactura.numDocumentoRef, "123", "60"); //O.C.

            if (oFactura.ListaCanjeGuias != null && oFactura.ListaCanjeGuias.Count > 0)
            {
                if (oFactura.ListaCanjeGuias.Count == 2)
                {
                    oFacturaImpresion.AgregarDatos(oFactura.ListaCanjeGuias[0].numSerieGuia + "-" + oFactura.ListaCanjeGuias[0].numDocumentoGuia, "162", "59"); //guia 1
                    oFacturaImpresion.AgregarDatos(oFactura.ListaCanjeGuias[1].numSerieGuia + "-" + oFactura.ListaCanjeGuias[1].numDocumentoGuia, "162", "62"); //Guia 2
                }
                else
                {
                    oFacturaImpresion.AgregarDatos(oFactura.ListaCanjeGuias[0].numSerieGuia + "-" + oFactura.ListaCanjeGuias[0].numDocumentoGuia, "162", "60"); //guia 1
                }
            }
            else
            {
                oFacturaImpresion.AgregarDatos(" ", "162", "60"); //guia
            }

            oFacturaImpresion.AgregarDatos(oFactura.nomVendedor, "122", "65.6");
            oFacturaImpresion.AgregarDatos(oFactura.desCondicion, "163", "65.6");

            ////Detalle (Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oFactura.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    oFacturaImpresion.AgregarItems(item.codArticulo + "|" + item.desUMedida + "|" + Convert.ToInt32(item.Cantidad).ToString("N2") + "|"
                        + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString("N2") + "|" + Convert.ToDecimal(item.subTotal).ToString("N2") + "|"
                        + (item.indCalculo == true ? Convert.ToDecimal(item.TotalCad).ToString("N2") : ""));
                }
            }

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

            ////Total en Letras
            oFacturaImpresion.AgregarDatos(enLetras(oFactura.totTotal.ToString()) + Moneda, "3", "174");

            string numDerecha = String.Empty;
            //Valor Venta
            oFacturaImpresion.AgregarDatos("SUB TOTAL", "145", "174");
            numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totsubTotal.ToString("N2").Length, 8) + oFactura.totsubTotal.ToString("N2");
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "165", "174");

            //IGV
            if (oFactura.totIgv > 0)
            {
                oFacturaImpresion.AgregarDatos("IGV " + oFactura.ListaItemsDocumento[0].porIgv.ToString("N2"), "145", "178");
                numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totIgv.Value.ToString("N2").Length, 8) + oFactura.totIgv.Value.ToString("N2");
                oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "165", "178");
            }
            else
            {
                oFacturaImpresion.AgregarDatos("IGV " + oFactura.ListaItemsDocumento[0].porIgv.ToString("N2"), "145", "178");
                numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totIgv.Value.ToString("N2").Length, 8) + oFactura.totIgv.Value.ToString("N2");
                oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "165", "178");
            }

            //Total
            oFacturaImpresion.AgregarDatos("TOTAL", "145", "182");
            numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totTotal.ToString("N2").Length, 8) + oFactura.totTotal.ToString("N2");
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "165", "182");

            //Imprimiendo
            oFacturaImpresion.ImprimirFactura(nomImpresora);
        }

        private void BoletaVenta(EmisionDocumentoE oBoleta, String nomImpresora)
        {
            String Moneda = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oBoleta.fecEmision);
            BoletasInter oBoletaImpresion = new BoletasInter();
            List<String> Vendedor = null;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oBoleta.idMoneda
                                select x).SingleOrDefault();

            //Cabecera (Dato, x, y)
            oBoletaImpresion.AgregarDatos(oBoleta.RazonSocial, "33", "65.5");
            oBoletaImpresion.AgregarDatos(oBoleta.Direccion, "32", "73.5");
            oBoletaImpresion.AgregarDatos(oBoleta.numRuc, "32", "82.5");
            oBoletaImpresion.AgregarDatos(fecEmision.ToString("d"), "162", "82.2");

            if (oBoleta.ListaCanjeGuias != null && oBoleta.ListaCanjeGuias.Count > 0)
            {
                oBoletaImpresion.AgregarDatos(oBoleta.ListaCanjeGuias[0].numSerieGuia + "-" + oBoleta.ListaCanjeGuias[0].numDocumentoGuia, "45", "90"); //guia
            }
            else
            {
                oBoletaImpresion.AgregarDatos(" ", "45", "90"); //guia
            }

            if (!String.IsNullOrEmpty(oBoleta.nomVendedor.Trim()))
            {
                Vendedor = new List<String>(oBoleta.nomVendedor.Split(' '));

                if (Vendedor.Count > 0)
                {
                    oBoletaImpresion.AgregarDatos("Vend.: " + Vendedor[0], "90", "90");
                }
            }

            oBoletaImpresion.AgregarDatos(oBoleta.desCondicion, "162", "90");

            ////Detalle (Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oBoleta.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    oBoletaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|"
                        + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString("N2") + "|"
                        + (item.indCalculo == true ? Convert.ToDecimal(item.Total).ToString("N2") : ""));
                }
            }

            Moneda = " " + oMoneda.desMoneda.ToUpper();

            //if (Convert.ToInt32(oBoleta.idMoneda) == (Int32)EnumTipoMoneda.Soles)
            //{
            //    Moneda = " SOLES";
            //}
            //else if (Convert.ToInt32(oBoleta.idMoneda) == (Int32)EnumTipoMoneda.Dolares)
            //{
            //    Moneda = " DOLARES AMERICANOS";
            //}
            //else
            //{
            //    Moneda = " EUROS";
            //}

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
            NotasDeCreditoInter oNcImpresion = new NotasDeCreditoInter();
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

            oNcImpresion.AgregarDatos(oNotaCredito.RazonSocial, "37", "51.5");
            oNcImpresion.AgregarDatos(oNotaCredito.Direccion, "37", "60");
            //oNcImpresion.AgregarDatos(oNotaCredito.fecEmision.ToString("d"), "37", "69.5"); //Por revisar
            oNcImpresion.AgregarDatos(oNotaCredito.numRuc, "37", "77");

            oNcImpresion.AgregarDatos(NombreDocumento, "150", "60");
            oNcImpresion.AgregarDatos(oNotaCredito.serDocumentoRef + "-" + oNotaCredito.numDocumentoRef, "150", "69.5");
            oNcImpresion.AgregarDatos(Convert.ToDateTime(oNotaCredito.fecDocumentoRef).ToString("dd/MM/yyyy"), "150", "77");

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
                    oNcImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString(Formato) + "|" + Convert.ToDecimal(item.Total).ToString("N2"));
                }
            }

            Moneda = " " + oMoneda.desMoneda.ToUpper();
            //if (Convert.ToInt32(oNotaCredito.idMoneda) == (Int32)EnumTipoMoneda.Soles)
            //{
            //    Moneda = " SOLES";
            //}
            //else if (Convert.ToInt32(oNotaCredito.idMoneda) == (Int32)EnumTipoMoneda.Dolares)
            //{
            //    Moneda = " DOLARES AMERICANOS";
            //}
            //else
            //{
            //    Moneda = " EUROS";
            //}

            //Total en Letras
            oNcImpresion.AgregarDatos(enLetras(oNotaCredito.totTotal.ToString()) + Moneda, "38", "125.4"); //Español

            //Motivo
            oNcImpresion.AgregarDatos(oNotaCredito.desCondicion, "58", "133.5");

            if (!String.IsNullOrEmpty(oNotaCredito.Glosa))
            {
                oNcImpresion.AgregarDatos(oNotaCredito.Glosa, "58", "138");
            }

            //Totales
            string Numeros = String.Empty;
            Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
            oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "132");
            Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2");
            oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "138.5");
            Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
            oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "144");

            //Imprimiendo
            oNcImpresion.ImprimirNC(nomImpresora);
        }

        private void NotaDeDebitoND(EmisionDocumentoE oNotaDebito, String nomImpresora)
        {
            NotasDeDebitoInter oNdImpresion = new NotasDeDebitoInter();
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

            oNdImpresion.AgregarDatos(oNotaDebito.RazonSocial, "37", "56.2");
            oNdImpresion.AgregarDatos(oNotaDebito.Direccion, "37", "63.5");
            //oNdImpresion.AgregarDatos(oNotaDebito.fecEmision.ToString("d"), "37", "71"); //Por revisar
            oNdImpresion.AgregarDatos(oNotaDebito.numRuc, "37", "77.3");

            oNdImpresion.AgregarDatos(NombreDocumento, "150", "63.5");
            oNdImpresion.AgregarDatos(oNotaDebito.serDocumentoRef + "-" + oNotaDebito.numDocumentoRef, "150", "71");
            oNdImpresion.AgregarDatos(Convert.ToDateTime(oNotaDebito.fecDocumentoRef).ToString("dd/MM/yyyy"), "150", "77.3");

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
                    oNdImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString(Formato) + "|" + Convert.ToDecimal(item.Total).ToString("N2"));
                }
            }

            Moneda = " " + oMoneda.desMoneda.ToUpper();

            //if (Convert.ToInt32(oNotaDebito.idMoneda) == (Int32)EnumTipoMoneda.Soles)
            //{
            //    Moneda = " SOLES";
            //}
            //else if (Convert.ToInt32(oNotaDebito.idMoneda) == (Int32)EnumTipoMoneda.Dolares)
            //{
            //    Moneda = " DOLARES AMERICANOS";
            //}
            //else
            //{
            //    Moneda = " EUROS";
            //}

            //Total en Letras
            oNdImpresion.AgregarDatos(enLetras(oNotaDebito.totTotal.ToString()) + Moneda, "38", "124.5"); //Español

            //Motivo
            oNdImpresion.AgregarDatos(oNotaDebito.desCondicion, "58", "130");

            if (!String.IsNullOrEmpty(oNotaDebito.Glosa))
            {
                oNdImpresion.AgregarDatos(oNotaDebito.Glosa, "58", "133");
            }

            //Totales
            string Numeros = String.Empty;
            Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2");
            oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "129.5");
            Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2");
            oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "135.5");
            Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2");
            oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "141.8");

            //Imprimiendo
            oNdImpresion.ImprimirND(nomImpresora);
        } 

        #endregion

    }
}
