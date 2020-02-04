using System;
using System.Text;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Infraestructura.Enumerados;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Impresion.SCIngenieros
{
    public class ImpresionSC: IImpresion
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
            //if (String.IsNullOrEmpty(RutaImpresion.Trim()))
            //{
            //    throw new Exception("No se encontró la ruta o el nombre de le impresora.");
            //}

            //ControlDocumento = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(DocumentoEmision.idEmpresa, DocumentoEmision.idLocal, 3, DocumentoEmision.idDocumento, DocumentoEmision.numSerie);

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
            //        switch (Tipoguia)
            //        {
            //            case (Int32)EnumTipoImpresionGuiaRemision.VENTA:
            //                GuiaVentas(DocumentoEmision, RutaImpresion);
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
            //if (String.IsNullOrEmpty(RutaImpresion.Trim()))
            //{
            //    throw new Exception("No se encontró la ruta o el nombre de le impresora.");
            //}

            //ControlDocumento = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(DocumentoEmision.idEmpresa, DocumentoEmision.idLocal, 2, DocumentoEmision.idDocumento, DocumentoEmision.numSerie);

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
            //        BoletaVenta(DocumentoEmision, RutaImpresion);
            //    }

            //}
            //else
            //{
            //    throw new Exception("Este documento no tiene ningún tipo de configuración. Revisar en Menú > Control de Documentos.");
            //}
        }

        public void ImprimirNotaDeCredito(EmisionDocumentoE DocumentoEmision, String RutaImpresion)
        {
            //if (String.IsNullOrEmpty(RutaImpresion.Trim()))
            //{
            //    throw new Exception("No se encontró la ruta o el nombre de le impresora.");
            //}

            //ControlDocumento = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(DocumentoEmision.idEmpresa, DocumentoEmision.idLocal, 4, DocumentoEmision.idDocumento, DocumentoEmision.numSerie);

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
            //            case "NC":
            //                NotaDeCreditoNC(DocumentoEmision, RutaImpresion);
            //                break;
            //            case "NP":
            //                NotaDeCreditoNC(DocumentoEmision, RutaImpresion);
            //                break;
            //            //    case (Int32)EnumTipoImpresionGuiaRemision.TRASLADO:
            //            //        GuiaTraslado(DocumentoEmision, RutaImpresion);
            //            //        break;
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

        public void ImprimirNotaDeDebito(EmisionDocumentoE DocumentoEmision, String RutaImpresion)
        {
            //if (String.IsNullOrEmpty(RutaImpresion.Trim()))
            //{
            //    throw new Exception("No se encontró la ruta o el nombre de le impresora.");
            //}

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
            //GuiasJeri oGuiaImpresion = new GuiasJeri();
            //DateTime fecTraslado = Convert.ToDateTime(oGuia.fecTraslado);
            //List<String> Palabras = null;
            //StringBuilder CadenaDireccion = new StringBuilder();
            //Int32 totLetras = 0;
            //String PrimerParrafo = String.Empty;
            //String SegundoParrafo = String.Empty;

            ////Fecha de Emisión de la Guia
            //oGuiaImpresion.AgregarDatos(oGuia.fecEmision.ToString("d"), "45", "56");

            ////Punto de Partida
            //if (oGuia.PuntoPartida.Length > 45)
            //{
            //    Palabras = new List<String>(oGuia.PuntoPartida.Split(' '));

            //    foreach (String item in Palabras)
            //    {
            //        totLetras = item.Length;
            //        CadenaDireccion.Append(item.Trim()).Append(" ");

            //        if (CadenaDireccion.Length <= 45)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
            //            break;
            //        }
            //    }

            //    SegundoParrafo = oGuia.PuntoPartida.Replace(PrimerParrafo, "").Trim();

            //    oGuiaImpresion.AgregarDatos(PrimerParrafo, "15.5", "70");
            //    oGuiaImpresion.AgregarDatos(SegundoParrafo, "15.5", "73");
            //    CadenaDireccion.Clear();
            //}
            //else
            //{
            //    oGuiaImpresion.AgregarDatos(oGuia.PuntoPartida, "15.5", "70");
            //}

            ////Punto de Llegada
            //if (oGuia.PuntoLlegada.Length > 45)
            //{
            //    CadenaDireccion.Clear();
            //    Palabras = new List<String>(oGuia.PuntoLlegada.Split(' '));

            //    foreach (String item in Palabras)
            //    {
            //        totLetras = item.Length;
            //        CadenaDireccion.Append(item.Trim()).Append(" ");

            //        if (CadenaDireccion.Length <= 45)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
            //            break;
            //        }
            //    }

            //    SegundoParrafo = oGuia.PuntoLlegada.Replace(PrimerParrafo, "").Trim();

            //    oGuiaImpresion.AgregarDatos(PrimerParrafo, "112", "70");
            //    oGuiaImpresion.AgregarDatos(SegundoParrafo, "112", "73");
            //    CadenaDireccion.Clear();
            //}
            //else
            //{
            //    oGuiaImpresion.AgregarDatos(oGuia.PuntoLlegada, "112", "70");
            //}

            ////Fecha de traslado
            //oGuiaImpresion.AgregarDatos(Convert.ToDateTime(oGuia.fecTraslado).ToString("dd/MM/yyyy"), "58.5", "78.5");
            //oGuiaImpresion.AgregarDatos(oGuia.RazonSocial, "112", "82");
            //oGuiaImpresion.AgregarDatos(oGuia.numRuc, "132", "89");

            ////Transporte y Conductores (Lado Izquierdo)
            //oGuiaImpresion.AgregarDatos(oGuia.MarcaTransp + " " + oGuia.PlacaTransp, "55", "105");
            //oGuiaImpresion.AgregarDatos(oGuia.PlacaRemolqueTransp, "55", "107.5");
            //oGuiaImpresion.AgregarDatos(oGuia.inscripTransp, "65", "115");
            //oGuiaImpresion.AgregarDatos(oGuia.LicenciaTransp, "64", "121");

            ////Transportista (Lado Derecho)
            //oGuiaImpresion.AgregarDatos(oGuia.RazonSocialTransp, "112", "112");
            //oGuiaImpresion.AgregarDatos(oGuia.RucTransp, "130", "119.5");

            ////Detalle(Separarlo por Palotes)
            //foreach (EmisionDocumentoDetE item in oGuia.ListaItemsDocumento)
            //{
            //    if (item.Cantidad > 0 && item.nomArticulo != null)
            //    {
            //        oGuiaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|"
            //            + item.nomArticulo + "|" + item.desUMedida + "|"
            //            + item.PesoBrutoCad, ControlDocumento.cantCaracteres);
            //    }
            //}

            ////Glosa
            //oGuiaImpresion.AgregarDatos("Atencion: " + oGuia.Glosa, "31", "220");

            //if (oGuia.ListaCanjeGuias != null && oGuia.ListaCanjeGuias.Count > 0)
            //{
            //    //Tipo
            //    if (oGuia.ListaCanjeGuias[0].idDocumentoFact == "FV")
            //    {
            //        oGuiaImpresion.AgregarDatos("FACTURA", "22", "241");
            //    }
            //    else
            //    {
            //        oGuiaImpresion.AgregarDatos("BOLETA", "22", "241");
            //    }

            //    //Numero factura
            //    oGuiaImpresion.AgregarDatos(oGuia.ListaCanjeGuias[0].numSerieFact + "-" + oGuia.ListaCanjeGuias[0].numDocumentoFact, "30", "248");
            //}
            //else
            //{
            //    oGuiaImpresion.AgregarDatos(" ", "22", "241");
            //    oGuiaImpresion.AgregarDatos(" ", "30", "248");
            //}

            ////Motivo de Traslado
            //switch (oGuia.idTipTraslado)
            //{
            //    case 1: //Venta
            //        oGuiaImpresion.AgregarDatos("X", "62.8", "239"); //////////////
            //        break;
            //    case 2: //Venta sujeta a confirmación del comprador
            //        oGuiaImpresion.AgregarDatos("X", "143.7", "244.5"); ///////////////
            //        break;
            //    case 3: //Compra
            //        oGuiaImpresion.AgregarDatos("X", "62.8", "241"); ////////////
            //        break;
            //    case 4: //Consignacion
            //        oGuiaImpresion.AgregarDatos("X", "62.8", "248"); ////////////////
            //        break;
            //    case 5: //Devolucion
            //        oGuiaImpresion.AgregarDatos("X", "88", "237.5"); ///////////////
            //        break;
            //    case 6: //Traslado entre establecimientos de la misma empresa
            //        oGuiaImpresion.AgregarDatos("X", "88", "241"); ////////////////
            //        break;
            //    case 7: //Traslado de bienes para transformación
            //        oGuiaImpresion.AgregarDatos("X", "62.8", "244.5"); /////////////////
            //        break;
            //    case 9: //Traslado por emisor itinerante de comprobantes de pago
            //        oGuiaImpresion.AgregarDatos("X", "88", "248"); ///////////////////
            //        break;
            //    case 11: //Importación
            //        oGuiaImpresion.AgregarDatos("X", "143.7", "241"); ////////////////
            //        break;
            //    case 12: //Exportación
            //        oGuiaImpresion.AgregarDatos("X", "143.7", "237.5"); /////////////////
            //        break;
            //    case 14: //Otros
            //        oGuiaImpresion.AgregarDatos("X", "143.7", "248");
            //        oGuiaImpresion.AgregarDatos(oGuia.OtroTipoTraslado, "155", "248");
            //        break;
            //    default:
            //        break;
            //}

            ////Imprimiendo la guia de traslado
            //oGuiaImpresion.ImprimirGuia(nomImpresora);
        }

        private void Facturas(EmisionDocumentoE oFactura, String nomImpresora)
        {
            String Moneda = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oFactura.fecEmision);
            FacturaSC oFacturaImpresion = new FacturaSC();
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oFactura.idMoneda
                                select x).SingleOrDefault();

            //Cabecera (Dato, x, y)
            //oFacturaImpresion.AgregarDatos(oFactura.fecEmision.ToString("d"), "50", "55.5");
            //Fecha de Emisión
            //Por revisar//oFacturaImpresion.AgregarDatos(oFactura.fecEmision.ToString("dd"), "17", "45.5");
            //Por revisar//oFacturaImpresion.AgregarDatos(Global.PrimeraMayuscula(FechasHelper.NombreMes(Convert.ToInt32(oFactura.fecEmision.ToString("MM")))), "35", "45.5");
            //Por revisar//oFacturaImpresion.AgregarDatos(oFactura.fecEmision.ToString("yy"), "75", "45.5");

            oFacturaImpresion.AgregarDatos(oFactura.idDocumento+' '+oFactura.numSerie+'-'+oFactura.numDocumento, "158", "42.5");

            oFacturaImpresion.AgregarDatos(oFactura.RazonSocial, "23", "52.5");
            oFacturaImpresion.AgregarDatos(oFactura.Direccion, "23", "57.5");
            oFacturaImpresion.AgregarDatos(oFactura.numRuc, "158", "52.5");
            

            if (oFactura.ListaCanjeGuias != null && oFactura.ListaCanjeGuias.Count > 0)
            {
                StringBuilder CadenaGuias = new StringBuilder();

                foreach (CanjeGuiasE item in oFactura.ListaCanjeGuias)
                {
                    CadenaGuias.Append(item.numSerieGuia).Append("-").Append(item.numDocumentoGuia).Append(" ");
                }

                oFacturaImpresion.AgregarDatos(CadenaGuias.ToString().Trim(), "35", "90"); //guias
            }
            else
            {
                oFacturaImpresion.AgregarDatos(" ", "35", "90"); //guia
            }
            
            ////Detalle (Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oFactura.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    oFacturaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|"
                        + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString("N2") + "|"
                        + (item.indCalculo == true ? Convert.ToDecimal(item.subTotal).ToString("N2") : ""), ControlDocumento.cantCaracteres);
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
            //Totales
            String Numeros = String.Empty;

            Numeros = oFacturaImpresion.AlinearDerecha(Convert.ToDecimal(oFactura.totsubTotal).ToString("N2").Length, 10) + Convert.ToDecimal(oFactura.totsubTotal).ToString("N2");
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "175", "130");//140

            if (oFactura.totIgv > 0)
            {
                Numeros = oFacturaImpresion.AlinearDerecha(Convert.ToDecimal(oFactura.totIgv).ToString("N2").Length, 10) + Convert.ToDecimal(oFactura.totIgv).ToString("N2");
                oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "175", "137");//145
            }

            Moneda = " " + oMoneda.desMoneda.ToUpper();
           
            if (oFactura.desCondicion.Contains("TRANSFERENCIA"))
            {
              Numeros = oFacturaImpresion.AlinearDerecha(("0.00").Length, 10) + "0.00";
              oFacturaImpresion.AgregarDatos(enLetras("0.00") + Moneda, "25", "128");//140
              oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "" + Numeros, "175", "142");//160
            }
            else
            {
              // Total en Letras
              Numeros = oFacturaImpresion.AlinearDerecha(Convert.ToDecimal(oFactura.totTotal).ToString("N2").Length, 10) + Convert.ToDecimal(oFactura.totTotal).ToString("N2");
              oFacturaImpresion.AgregarDatos(enLetras(oFactura.totTotal.ToString()) + Moneda, "25", "128");//140
              oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "175", "142");//155      
            }

            //Imprimiendo
            oFacturaImpresion.ImprimirFactura(nomImpresora);
        }

        private void BoletaVenta(EmisionDocumentoE oBoleta, String nomImpresora)
        {
            //String Moneda = String.Empty;
            //DateTime fecEmision = Convert.ToDateTime(oBoleta.fecEmision);
            //BoletasJeri oBoletaImpresion = new BoletasJeri();
            ////List<String> Vendedor = null;

            ////Cabecera (Dato, x, y)
            //oBoletaImpresion.AgregarDatos(oBoleta.RazonSocial, "33", "65.5");
            //oBoletaImpresion.AgregarDatos(oBoleta.Direccion, "32", "73.5");
            //oBoletaImpresion.AgregarDatos(oBoleta.numRuc, "32", "82.5");
            //oBoletaImpresion.AgregarDatos(fecEmision.ToString("d"), "162", "82.2");

            //if (oBoleta.ListaCanjeGuias != null && oBoleta.ListaCanjeGuias.Count > 0)
            //{
            //    StringBuilder CadenaGuias = new StringBuilder();

            //    foreach (CanjeGuiasE item in oBoleta.ListaCanjeGuias)
            //    {
            //        CadenaGuias.Append(item.numSerieGuia).Append("-").Append(item.numDocumentoGuia).Append(" ");
            //    }

            //    oBoletaImpresion.AgregarDatos(CadenaGuias.ToString().Trim(), "45", "90"); //guias
            //    //oBoletaImpresion.AgregarDatos(oBoleta.ListaCanjeGuias[0].numSerieGuia + "-" + oBoleta.ListaCanjeGuias[0].numDocumentoGuia, "45", "90"); //guia
            //}
            //else
            //{
            //    oBoletaImpresion.AgregarDatos(" ", "45", "90"); //guia
            //}

            ////if (!String.IsNullOrEmpty(oBoleta.nomVendedor.Trim()))
            ////{
            ////    Vendedor = new List<String>(oBoleta.nomVendedor.Split(' '));

            ////    if (Vendedor.Count > 0)
            ////    {
            ////        oBoletaImpresion.AgregarDatos("Vend.: " + Vendedor[0], "90", "90");
            ////    }
            ////}

            //oBoletaImpresion.AgregarDatos(oBoleta.desCondicion, "162", "90");

            //////Detalle (Separarlo por Palotes)
            //foreach (EmisionDocumentoDetE item in oBoleta.ListaItemsDocumento)
            //{
            //    if (item.Cantidad > 0 && item.nomArticulo != null)
            //    {
            //        oBoletaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|"
            //            + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString("N2") + "|"
            //            + (item.indCalculo == true ? Convert.ToDecimal(item.Total).ToString("N2") : ""), ControlDocumento.cantCaracteres);
            //    }
            //    else
            //    {
            //        if (oBoleta.desCondicion.Contains("TRANSFERENCIA"))
            //        {
            //            oBoletaImpresion.AgregarItems("|" + item.nomArticulo + "||", ControlDocumento.cantCaracteres);
            //        }
            //    }
            //}

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

            //if (oBoleta.desCondicion.Contains("TRANSFERENCIA"))
            //{
            //    //oBoletaImpresion.AgregarDatos("TRANSFERENCIA A TITULO GRATUITO.", "31", "220");
            //    oBoletaImpresion.AgregarDatos(oBoleta.desMoneda + " 0.00", "179", "244");
            //    oBoletaImpresion.AgregarDatos(enLetras("0.00") + Moneda, "31", "259");
            //}
            //else
            //{
            //    oBoletaImpresion.AgregarDatos(oBoleta.desMoneda + "  " + oBoleta.totTotal.ToString("N2"), "179", "244");
            //    ////Total en Letras
            //    oBoletaImpresion.AgregarDatos(enLetras(oBoleta.totTotal.ToString()) + Moneda, "31", "259");
            //}

            ////Imprimiendo
            //oBoletaImpresion.ImprimirBoleta(nomImpresora);
        }

        private void NotaDeCreditoNC(EmisionDocumentoE oNotaCredito, String nomImpresora)
        {
            //NotasDeCreditoJeri oNcImpresion = new NotasDeCreditoJeri();
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

            //oNcImpresion.AgregarDatos(oNotaCredito.RazonSocial, "37", "51.5");
            //oNcImpresion.AgregarDatos(oNotaCredito.Direccion, "37", "60");
            //oNcImpresion.AgregarDatos(oNotaCredito.fecEmision.ToString("d"), "37", "69.5");
            //oNcImpresion.AgregarDatos(oNotaCredito.numRuc, "37", "77");

            //oNcImpresion.AgregarDatos(NombreDocumento, "150", "60");
            //oNcImpresion.AgregarDatos(oNotaCredito.serDocumentoRef + "-" + oNotaCredito.numDocumentoRef, "150", "69.5");
            //oNcImpresion.AgregarDatos(Convert.ToDateTime(oNotaCredito.fecDocumentoRef).ToString("dd/MM/yyyy"), "150", "77");

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
            //                                    item.nomArticulo + "|" +
            //                                    Convert.ToDecimal(item.PrecioSinImpuesto).ToString(Formato) + "|" +
            //                                    Convert.ToDecimal(item.Total).ToString("N2"), ControlDocumento.cantCaracteres);
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
            //oNcImpresion.AgregarDatos(enLetras(oNotaCredito.totTotal.ToString()) + Moneda, "38", "125.4"); //Español

            ////Motivo
            //oNcImpresion.AgregarDatos(oNotaCredito.desCondicion, "58", "133.5");

            //if (!String.IsNullOrEmpty(oNotaCredito.Glosa))
            //{
            //    oNcImpresion.AgregarDatos(oNotaCredito.Glosa, "58", "138");
            //}

            ////Totales
            //string Numeros = String.Empty;
            //Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
            //oNcImpresion.AgregarDatos(oNotaCredito.desMoneda + " " + Numeros, "183", "132");
            //Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2");
            //oNcImpresion.AgregarDatos(oNotaCredito.desMoneda + " " + Numeros, "183", "138.5");
            //Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
            //oNcImpresion.AgregarDatos(oNotaCredito.desMoneda + " " + Numeros, "183", "144");

            ////Imprimiendo
            //oNcImpresion.ImprimirNC(nomImpresora);
        }

        private void NotaDeDebitoND(EmisionDocumentoE oNotaDebito, String nomImpresora)
        {
            //NotasDeDebitoJeri oNdImpresion = new NotasDeDebitoJeri();
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

            //oNdImpresion.AgregarDatos(oNotaDebito.RazonSocial, "37", "56.2");
            //oNdImpresion.AgregarDatos(oNotaDebito.Direccion, "37", "63.5");
            //oNdImpresion.AgregarDatos(oNotaDebito.fecEmision.ToString("d"), "37", "71");
            //oNdImpresion.AgregarDatos(oNotaDebito.numRuc, "37", "77.3");

            //oNdImpresion.AgregarDatos(NombreDocumento, "150", "63.5");
            //oNdImpresion.AgregarDatos(oNotaDebito.serDocumentoRef + "-" + oNotaDebito.numDocumentoRef, "150", "71");
            //oNdImpresion.AgregarDatos(Convert.ToDateTime(oNotaDebito.fecDocumentoRef).ToString("dd/MM/yyyy"), "150", "77.3");

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
            //        oNdImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" +
            //                                item.nomArticulo + "|" +
            //                                Convert.ToDecimal(item.PrecioSinImpuesto).ToString(Formato) + "|" +
            //                                Convert.ToDecimal(item.Total).ToString("N2"), ControlDocumento.cantCaracteres);
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
            //oNdImpresion.AgregarDatos(enLetras(oNotaDebito.totTotal.ToString()) + Moneda, "38", "124.5"); //Español

            ////Motivo
            //oNdImpresion.AgregarDatos(oNotaDebito.desCondicion, "58", "130");

            //if (!String.IsNullOrEmpty(oNotaDebito.Glosa))
            //{
            //    oNdImpresion.AgregarDatos(oNotaDebito.Glosa, "58", "133");
            //}

            ////Totales
            //string Numeros = String.Empty;
            //Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2");
            //oNdImpresion.AgregarDatos(oNotaDebito.desMoneda + " " + Numeros, "183", "129.5");
            //Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2");
            //oNdImpresion.AgregarDatos(oNotaDebito.desMoneda + " " + Numeros, "183", "135.5");
            //Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2");
            //oNdImpresion.AgregarDatos(oNotaDebito.desMoneda + " " + Numeros, "183", "141.8");

            ////Imprimiendo
            //oNdImpresion.ImprimirND(nomImpresora);
        }

        #endregion

    }
}
