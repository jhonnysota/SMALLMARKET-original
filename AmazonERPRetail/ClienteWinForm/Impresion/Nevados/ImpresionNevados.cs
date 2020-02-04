using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Impresion.Nevados
{
    public class ImpresionNevados : IImpresion
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

        public void ImprimirBoletas(EmisionDocumentoE DocumentoEmision, string RutaImpresion)
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

        public void ImprimirFacturas(EmisionDocumentoE DocumentoEmision, string RutaImpresion)
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

        public void ImprimirGuiaRemision(EmisionDocumentoE DocumentoEmision, string RutaImpresion, int TipoGuia)
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
                    switch (TipoGuia)
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

        public void ImprimirNotaDeCredito(EmisionDocumentoE Documento, string RutaImpresion)
        {
            throw new NotImplementedException();
        }

        public void ImprimirNotaDeDebito(EmisionDocumentoE Documento, string RutaImpresion)
        {
            throw new NotImplementedException();
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
            GuiaNevados oGuiaImpresion = new GuiaNevados();
            DateTime fecTraslado = Convert.ToDateTime(oGuia.fecTraslado);
            List<String> Palabras = null;
            StringBuilder CadenaDireccion = new StringBuilder();
            Int32 totLetras = 0;
            String PrimerParrafo = String.Empty;
            String SegundoParrafo = String.Empty;

            //Serie y número de guia
            oGuiaImpresion.AgregarDatos(oGuia.numSerie + "-" + oGuia.numDocumento, "155", "30");
            //Razón Social del destinatario
            oGuiaImpresion.AgregarDatos(oGuia.RazonSocial, "8", "35");
            //Ruc del destinatario
            oGuiaImpresion.AgregarDatos(oGuia.numRuc, "20", "41.8");

            //Numero factura
            if (oGuia.ListaCanjeGuias.Count > 0)
            {
                if (!String.IsNullOrWhiteSpace(oGuia.ListaCanjeGuias[0].numSerieFact) && !String.IsNullOrWhiteSpace(oGuia.ListaCanjeGuias[0].numDocumentoFact))
                {
                    oGuiaImpresion.AgregarDatos(oGuia.ListaCanjeGuias[0].numSerieFact + "-" + oGuia.ListaCanjeGuias[0].numDocumentoFact, "88", "41.8");
                } 
            }

            // X
            oGuiaImpresion.AgregarDatos("X", "5.8", "52.2");

            //Fecha de Emisión de la Guia
            //oGuiaImpresion.AgregarDatos(oGuia.fecEmision.ToString("d"), "20", "72"); //Por revisar
            //Fecha de traslado
            oGuiaImpresion.AgregarDatos(Convert.ToDateTime(oGuia.fecTraslado).ToString("d"), "72", "72");

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
                oGuiaImpresion.AgregarDatos(PrimerParrafo, "121.2", "46");
                oGuiaImpresion.AgregarDatos(SegundoParrafo, "121.2", "49");
                CadenaDireccion.Clear();
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.PuntoPartida, "121.2", "47");
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
                oGuiaImpresion.AgregarDatos(PrimerParrafo, "121.2", "56");
                oGuiaImpresion.AgregarDatos(SegundoParrafo, "121.2", "59");
                CadenaDireccion.Clear();
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.PuntoLlegada, "121.2", "57");
            }

            ////Transporte y Conductores (Lado Izquierdo)
            oGuiaImpresion.AgregarDatos(oGuia.MarcaTransp + " " + oGuia.PlacaTransp, "151", "68.3");
            oGuiaImpresion.AgregarDatos(oGuia.inscripTransp, "151", "72.3");
            oGuiaImpresion.AgregarDatos(oGuia.LicenciaTransp, "151", "75.6");

            //Detalle(Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oGuia.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    oGuiaImpresion.AgregarItems(item.nomArticulo + "|" + Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.desUMedida + "|"
                        + item.PesoBrutoCad, ControlDocumento.cantCaracteres);
                }
            }

            ////Glosa
            oGuiaImpresion.AgregarDatos(oGuia.Glosa, "10", "183");
            oGuiaImpresion.AgregarDatos(oGuia.RazonSocialTransp, "55.3", "195.2");
            oGuiaImpresion.AgregarDatos(oGuia.RucTransp, "79", "199");

            ////Imprimiendo la guia de traslado
            oGuiaImpresion.ImprimirGuia(nomImpresora);
        }

        private void Facturas(EmisionDocumentoE oFactura, String nomImpresora)
        {
            String Moneda = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oFactura.fecEmision);
            FacturaNevados oFacturaImpresion = new FacturaNevados();
            List<string> Palabras = null;
            StringBuilder CadenaDireccion = new StringBuilder();
            Int32 totLetras = 0;
            String PrimerParrafo = String.Empty;
            String SegundoParrafo = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oFactura.idMoneda
                                select x).SingleOrDefault();

            //Cabecera (Dato, x, y)
            oFacturaImpresion.AgregarDatos(oFactura.RazonSocial, "23", "46.5"); //28, 65.2

            //Dirección...
            if (oFactura.Direccion.Length > 40)
            {
                Palabras = new List<String>(oFactura.Direccion.Split(' '));

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

                SegundoParrafo = oFactura.Direccion.Replace(PrimerParrafo, "").Trim();
                oFacturaImpresion.AgregarDatos(PrimerParrafo, "23", "52.5");
                oFacturaImpresion.AgregarDatos(SegundoParrafo, "23", "56.5");
                CadenaDireccion.Clear();
            }
            else
            {
                oFacturaImpresion.AgregarDatos(oFactura.Direccion, "23", "53");
            }

            oFacturaImpresion.AgregarDatos(oFactura.numRuc, "80", "59.2");

            oFacturaImpresion.AgregarDatos(oFactura.numSerie + "-" + oFactura.numDocumento, "155", "30");
            //oFacturaImpresion.AgregarDatos(oFactura.fecEmision.ToString("d"), "140", "46.5"); //Por revisar
            oFacturaImpresion.AgregarDatos(Convert.ToString(oFactura.idPersona), "140", "54");
            oFacturaImpresion.AgregarDatos(!String.IsNullOrWhiteSpace(oFactura.serDocumentoRef) ? oFactura.serDocumentoRef + "-" + oFactura.numDocumentoRef : oFactura.numDocumentoRef, "140", "59.2");
            oFacturaImpresion.AgregarDatos(oFactura.idVendedor.ToString(), "170", "59.2");

            //////Detalle (Separarlo por Palotes)
            string Total = String.Empty;
            String subTotal = String.Empty;
            string Precio = String.Empty;
            Decimal Descuento = 0;
            string des = String.Empty;

            foreach (EmisionDocumentoDetE item in oFactura.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    Precio = oFacturaImpresion.AlinearDerecha(Convert.ToDecimal(item.PrecioSinImpuesto).ToString("N2").Length, 6) + Convert.ToDecimal(item.PrecioSinImpuesto).ToString("N2");
                    des = oFacturaImpresion.AlinearDerecha(Convert.ToDecimal(Descuento).ToString("N2").Length, 6) + Convert.ToDecimal(Descuento).ToString("N2");
                    Total = oFacturaImpresion.AlinearDerecha(Convert.ToDecimal(item.Total).ToString("N2").Length, 8) + Convert.ToDecimal(item.Total).ToString("N2");
                    subTotal = oFacturaImpresion.AlinearDerecha(Convert.ToDecimal(item.subTotal).ToString("N2").Length, 8) + Convert.ToDecimal(item.subTotal).ToString("N2");

                    oFacturaImpresion.AgregarItems(item.Item + "|" +
                                                   item.codArticulo + "|" +
                                                   item.nomArticulo + "|" +
                                                   Convert.ToInt32(item.Cantidad).ToString("N0") + "|" +
                                                   Precio + "|" +
                                                   Total + "|" +
                                                   des + "|" +
                                                   subTotal, ControlDocumento.cantCaracteres);
                }
                else
                {
                    if (oFactura.desCondicion.Contains("TRANSFERENCIA"))
                    {
                        oFacturaImpresion.AgregarItems("|" + item.nomArticulo + "||", ControlDocumento.cantCaracteres);
                    }
                }
            }

            //Guias
            if (oFactura.ListaCanjeGuias != null && oFactura.ListaCanjeGuias.Count > 0)
            {
                if (oFactura.ListaCanjeGuias.Count == 1) //guia1
                {
                    oFacturaImpresion.AgregarDatos(oFactura.ListaCanjeGuias[0].numSerieGuia + "-" + oFactura.ListaCanjeGuias[0].numDocumentoGuia, "35", "146"); //guia1
                }
                else if (oFactura.ListaCanjeGuias.Count == 2) //guia1 //guia2
                {
                    oFacturaImpresion.AgregarDatos(oFactura.ListaCanjeGuias[0].numSerieGuia + "-" + oFactura.ListaCanjeGuias[0].numDocumentoGuia + " " +
                                                    oFactura.ListaCanjeGuias[1].numSerieGuia + "-" + oFactura.ListaCanjeGuias[1].numDocumentoGuia, "35", "146"); 
                }
                else if (oFactura.ListaCanjeGuias.Count == 3) //guia1 //guia2 //guia3
                {
                    oFacturaImpresion.AgregarDatos(oFactura.ListaCanjeGuias[0].numSerieGuia + "-" + oFactura.ListaCanjeGuias[0].numDocumentoGuia + " " +
                                                    oFactura.ListaCanjeGuias[1].numSerieGuia + "-" + oFactura.ListaCanjeGuias[1].numDocumentoGuia + " " +
                                                    oFactura.ListaCanjeGuias[2].numSerieGuia + "-" + oFactura.ListaCanjeGuias[2].numDocumentoGuia, "35", "146"); //guia1
                }
                else if (oFactura.ListaCanjeGuias.Count == 4) //guia1 //guia2 //guia3 //guia4
                {
                    oFacturaImpresion.AgregarDatos(oFactura.ListaCanjeGuias[0].numSerieGuia + "-" + oFactura.ListaCanjeGuias[0].numDocumentoGuia + " " +
                                                    oFactura.ListaCanjeGuias[1].numSerieGuia + "-" + oFactura.ListaCanjeGuias[1].numDocumentoGuia + " " +
                                                    oFactura.ListaCanjeGuias[2].numSerieGuia + "-" + oFactura.ListaCanjeGuias[2].numDocumentoGuia + " " +
                                                    oFactura.ListaCanjeGuias[3].numSerieGuia + "-" + oFactura.ListaCanjeGuias[3].numDocumentoGuia, "35", "146");
                }
            }

            //Total
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oFactura.totTotal.ToString("N2"), "18", "165");
            //Descuento
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + " 0.00", "65", "165");
            //Subtotal
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oFactura.totsubTotal.ToString("N2"), "95", "165");

            //if (oFactura.totIgv > 0)
            //{
            //    Int32 porIgv = Convert.ToInt32(oFactura.ListaItemsDocumento[0].porIgv);
            //    oFacturaImpresion.AgregarDatos(porIgv.ToString(""), "145", "159.7");
            //    oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oFactura.totIgv.Value.ToString("N2"), "139", "165");
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

            //if (oFactura.desCondicion.Contains("TRANSFERENCIA"))
            //{
            //    //oFacturaImpresion.AgregarDatos("TRANSFERENCIA A TITULO GRATUITO.", "25", "220");
            //    oFacturaImpresion.AgregarDatos(oFactura.desMoneda + " 0.00", "172", "247");
            //    oFacturaImpresion.AgregarDatos(enLetras("0.00") + Moneda, "25", "259");
            //}
            //else
            //{
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oFactura.totTotal.ToString("N2"), "176", "165");
            ////Total en Letras
            oFacturaImpresion.AgregarDatos(enLetras(oFactura.totTotal.ToString()) + Moneda, "29", "175");
            //}

            //Imprimiendo
            oFacturaImpresion.ImprimirFactura(nomImpresora);
        }

        private void BoletaVenta(EmisionDocumentoE oBoleta, String nomImpresora)
        {
            String Moneda = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oBoleta.fecEmision);
            BoletaNevados oBoletaImpresion = new BoletaNevados();

            //Cabecera (Dato, x, y)
            //Fecha de emisión
            oBoletaImpresion.AgregarDatos(fecEmision.ToString("dd"), "20", "45");
            oBoletaImpresion.AgregarDatos(FechasHelper.NombreMes(fecEmision.Month).ToUpper(), "35", "45");
            oBoletaImpresion.AgregarDatos(fecEmision.ToString("yy"), "80", "45");

            oBoletaImpresion.AgregarDatos(oBoleta.RazonSocial, "29", "52");
            oBoletaImpresion.AgregarDatos(oBoleta.Direccion, "29", "57");
            oBoletaImpresion.AgregarDatos(oBoleta.numRuc, "165", "52");

            ////Detalle (Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oBoleta.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    oBoletaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|"
                        + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString("N2") + "|"
                        + (item.indCalculo == true ? Convert.ToDecimal(item.Total).ToString("N2") : ""), ControlDocumento.cantCaracteres);
                }
                else
                {
                    if (oBoleta.desCondicion.Contains("TRANSFERENCIA"))
                    {
                        oBoletaImpresion.AgregarItems("|" + item.nomArticulo + "||", ControlDocumento.cantCaracteres);
                    }
                }
            }

            //Imprimiendo
            oBoletaImpresion.ImprimirBoleta(nomImpresora);
        }

        private void NotaDeCreditoNC(EmisionDocumentoE oNotaCredito, String nomImpresora)
        {
            //NotasDeCreditoAgro oNcImpresion = new NotasDeCreditoAgro();
            //String NombreDocumento = String.Empty;
            //String Moneda = String.Empty;
            //String Ruc = String.Empty;

            ////Cabecera
            //if (oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.FE.ToString() ||
            //    oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.FS.ToString() ||
            //    oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.FV.ToString())
            //{
            //    NombreDocumento = "Factura de Venta";
            //}
            //else if (oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.BV.ToString())
            //{
            //    NombreDocumento = "Boleta de Venta";
            //}

            //oNcImpresion.AgregarDatos(oNotaCredito.RazonSocial, "21", "51.5");

            ////Dirección
            //if (oNotaCredito.Direccion.Length >= 47)
            //{
            //    Int32 totLetras = 0;
            //    StringBuilder CadenaDireccion = new StringBuilder();
            //    List<String> Palabras = new List<String>(oNotaCredito.Direccion.Split(' '));
            //    String PrimerParrafo = String.Empty;
            //    String SegundoParrafo = String.Empty;

            //    foreach (String item in Palabras)
            //    {
            //        totLetras = item.Length;
            //        CadenaDireccion.Append(item.Trim()).Append(" ");

            //        if (CadenaDireccion.Length <= 47)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
            //            break;
            //        }
            //    }

            //    SegundoParrafo = oNotaCredito.Direccion.Replace(PrimerParrafo, "").Trim();

            //    oNcImpresion.AgregarDatos(PrimerParrafo, "21", "60");
            //    oNcImpresion.AgregarDatos(SegundoParrafo, "7", "63");
            //    CadenaDireccion.Clear();
            //}
            //else
            //{
            //    oNcImpresion.AgregarDatos(oNotaCredito.Direccion, "21", "60");
            //}

            //oNcImpresion.AgregarDatos(oNotaCredito.fecEmision.ToString("d"), "21", "68");
            //oNcImpresion.AgregarDatos(oNotaCredito.numRuc, "21", "76");

            //oNcImpresion.AgregarDatos(NombreDocumento, "135", "60");
            //oNcImpresion.AgregarDatos(oNotaCredito.serDocumentoRef + "-" + oNotaCredito.numDocumentoRef, "135", "68");
            //oNcImpresion.AgregarDatos(Convert.ToDateTime(oNotaCredito.fecDocumentoRef).ToString("dd/MM/yyyy"), "135", "76");

            //String Formato = String.Empty;

            //if (ControlDocumento.cantDigDecimales == 3)
            //{
            //    Formato = "N3";
            //}
            //else if (ControlDocumento.cantDigDecimales == 4)
            //{
            //    Formato = "N4";
            //}
            //else if (ControlDocumento.cantDigDecimales == 5)
            //{
            //    Formato = "N5";
            //}
            //else if (ControlDocumento.cantDigDecimales == 6)
            //{
            //    Formato = "N6";
            //}
            //else if (ControlDocumento.cantDigDecimales == 7)
            //{
            //    Formato = "###,###,##0.0000000";
            //}
            //else
            //{
            //    Formato = "N2";
            //}

            ////Detalle(Separarlo por Palotes)
            //foreach (EmisionDocumentoDetE item in oNotaCredito.ListaItemsDocumento)
            //{
            //    if (item.Cantidad > 0 && item.nomArticulo != null)
            //    {
            //        oNcImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" +
            //        item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString(Formato) + "|"
            //        + Convert.ToDecimal(item.Total).ToString("N2"), ControlDocumento.cantCaracteres);
            //    }
            //}

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

            ////Total en Letras
            //String LetrasNumeros = "Son: " + enLetras(oNotaCredito.totTotal.ToString()) + Moneda;

            //if (LetrasNumeros.Length >= 57)
            //{
            //    Int32 totLetras = 0;
            //    StringBuilder Cadena = new StringBuilder();
            //    List<String> Palabras = new List<String>(LetrasNumeros.Split(' '));
            //    String PrimerParrafo = String.Empty;
            //    String SegundoParrafo = String.Empty;

            //    foreach (String item in Palabras)
            //    {
            //        totLetras = item.Length;
            //        Cadena.Append(item.Trim()).Append(" ");

            //        if (Cadena.Length <= 57)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            PrimerParrafo = Cadena.ToString().Substring(0, Cadena.ToString().Trim().Length - totLetras);
            //            break;
            //        }
            //    }

            //    SegundoParrafo = LetrasNumeros.Replace(PrimerParrafo, "").Trim();

            //    if (String.IsNullOrEmpty(SegundoParrafo))
            //    {
            //        oNcImpresion.AgregarDatos(PrimerParrafo, "33", "125.4");
            //    }
            //    else
            //    {
            //        oNcImpresion.AgregarDatos(PrimerParrafo, "33", "123.5");
            //        oNcImpresion.AgregarDatos(SegundoParrafo, "33", "127.4");
            //    }

            //    Cadena.Clear();
            //}
            //else
            //{
            //    oNcImpresion.AgregarDatos("Son: " + enLetras(oNotaCredito.totTotal.ToString()) + Moneda, "33", "125.4");
            //}

            ////Motivo
            //oNcImpresion.AgregarDatos(oNotaCredito.desCondicion, "50", "133.5");

            //if (!String.IsNullOrEmpty(oNotaCredito.Glosa))
            //{
            //    oNcImpresion.AgregarDatos(oNotaCredito.Glosa, "50", "138");
            //}

            ////Totales
            //string Numeros = String.Empty;
            //Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
            //oNcImpresion.AgregarDatos(oNotaCredito.desMoneda + " " + Numeros, "179", "132");
            //Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2");
            //oNcImpresion.AgregarDatos(oNotaCredito.desMoneda + " " + Numeros, "179", "138.5");
            //Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
            //oNcImpresion.AgregarDatos(oNotaCredito.desMoneda + " " + Numeros, "179", "145.5");

            ////Imprimiendo
            //oNcImpresion.ImprimirNC(nomImpresora);
        }

        private void NotaDeDebitoND(EmisionDocumentoE oNotaDebito, String nomImpresora)
        {
            //NotasDeDebitoAgro oNdImpresion = new NotasDeDebitoAgro();
            //String NombreDocumento = String.Empty;
            //String Moneda = String.Empty;
            //String Ruc = String.Empty;

            ////Cabecera
            //if (oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FE.ToString() ||
            //    oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FS.ToString() ||
            //    oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FV.ToString())
            //{
            //    NombreDocumento = "Factura de Venta";
            //}
            //else if (oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.BV.ToString())
            //{
            //    NombreDocumento = "Boleta de Venta";
            //}

            //oNdImpresion.AgregarDatos(oNotaDebito.RazonSocial, "21", "54.5");

            ////Dirección
            //if (oNotaDebito.Direccion.Length >= 47)
            //{
            //    Int32 totLetras = 0;
            //    StringBuilder CadenaDireccion = new StringBuilder();
            //    List<String> Palabras = new List<String>(oNotaDebito.Direccion.Split(' '));
            //    String PrimerParrafo = String.Empty;
            //    String SegundoParrafo = String.Empty;

            //    foreach (String item in Palabras)
            //    {
            //        totLetras = item.Length;
            //        CadenaDireccion.Append(item.Trim()).Append(" ");

            //        if (CadenaDireccion.Length <= 47)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
            //            break;
            //        }
            //    }

            //    SegundoParrafo = oNotaDebito.Direccion.Replace(PrimerParrafo, "").Trim();

            //    oNdImpresion.AgregarDatos(PrimerParrafo, "21", "62.5");
            //    oNdImpresion.AgregarDatos(SegundoParrafo, "7", "66");
            //    CadenaDireccion.Clear();
            //}
            //else
            //{
            //    oNdImpresion.AgregarDatos(oNotaDebito.Direccion, "21", "63");
            //}

            //oNdImpresion.AgregarDatos(oNotaDebito.fecEmision.ToString("d"), "21", "70");
            //oNdImpresion.AgregarDatos(oNotaDebito.numRuc, "21", "76");

            //oNdImpresion.AgregarDatos(NombreDocumento, "135", "62.5");
            //oNdImpresion.AgregarDatos(oNotaDebito.serDocumentoRef + "-" + oNotaDebito.numDocumentoRef, "135", "70");
            //oNdImpresion.AgregarDatos(Convert.ToDateTime(oNotaDebito.fecDocumentoRef).ToString("dd/MM/yyyy"), "135", "76");

            //String Formato = String.Empty;

            //if (ControlDocumento.cantDigDecimales == 3)
            //{
            //    Formato = "N3";
            //}
            //else if (ControlDocumento.cantDigDecimales == 4)
            //{
            //    Formato = "N4";
            //}
            //else if (ControlDocumento.cantDigDecimales == 5)
            //{
            //    Formato = "N5";
            //}
            //else if (ControlDocumento.cantDigDecimales == 6)
            //{
            //    Formato = "N6";
            //}
            //else if (ControlDocumento.cantDigDecimales == 7)
            //{
            //    Formato = "###,###,##0.0000000";
            //}
            //else
            //{
            //    Formato = "N2";
            //}

            ////Detalle(Separarlo por Palotes)
            //foreach (EmisionDocumentoDetE item in oNotaDebito.ListaItemsDocumento)
            //{
            //    if (item.Cantidad > 0 && item.nomArticulo != null)
            //    {
            //        oNdImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.nomArticulo + "|" +
            //            Convert.ToDecimal(item.PrecioSinImpuesto).ToString(Formato) + "|" +
            //            Convert.ToDecimal(item.Total).ToString("N2"), ControlDocumento.cantCaracteres);
            //    }
            //}

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

            ////Total en Letras
            //String LetrasNumeros = "Son: " + enLetras(oNotaDebito.totTotal.ToString()) + Moneda;

            //if (LetrasNumeros.Length >= 57)
            //{
            //    Int32 totLetras = 0;
            //    StringBuilder Cadena = new StringBuilder();
            //    List<String> Palabras = new List<String>(LetrasNumeros.Split(' '));
            //    String PrimerParrafo = String.Empty;
            //    String SegundoParrafo = String.Empty;

            //    foreach (String item in Palabras)
            //    {
            //        totLetras = item.Length;
            //        Cadena.Append(item.Trim()).Append(" ");

            //        if (Cadena.Length <= 57)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            PrimerParrafo = Cadena.ToString().Substring(0, Cadena.ToString().Trim().Length - totLetras);
            //            break;
            //        }
            //    }

            //    SegundoParrafo = LetrasNumeros.Replace(PrimerParrafo, "").Trim();

            //    if (String.IsNullOrEmpty(SegundoParrafo))
            //    {
            //        oNdImpresion.AgregarDatos(PrimerParrafo, "33", "123");
            //    }
            //    else
            //    {
            //        oNdImpresion.AgregarDatos(PrimerParrafo, "33", "120");
            //        oNdImpresion.AgregarDatos(SegundoParrafo, "33", "123");
            //    }

            //    Cadena.Clear();
            //}
            //else
            //{
            //    oNdImpresion.AgregarDatos("Son: " + enLetras(oNotaDebito.totTotal.ToString()) + Moneda, "33", "123");
            //}

            ////Motivo
            //oNdImpresion.AgregarDatos(oNotaDebito.desCondicion, "50", "128.5");

            //if (!String.IsNullOrEmpty(oNotaDebito.Glosa))
            //{
            //    oNdImpresion.AgregarDatos(oNotaDebito.Glosa, "50", "131.5");
            //}

            ////Totales
            //string Numeros = String.Empty;
            //Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2");
            //oNdImpresion.AgregarDatos(oNotaDebito.desMoneda + " " + Numeros, "174", "128.5");
            //Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2");
            //oNdImpresion.AgregarDatos(oNotaDebito.desMoneda + " " + Numeros, "174", "134.5");
            //Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2");
            //oNdImpresion.AgregarDatos(oNotaDebito.desMoneda + " " + Numeros, "174", "146.8");

            ////Imprimiendo
            //oNdImpresion.ImprimirND(nomImpresora);
        }

        #endregion

    }
}
