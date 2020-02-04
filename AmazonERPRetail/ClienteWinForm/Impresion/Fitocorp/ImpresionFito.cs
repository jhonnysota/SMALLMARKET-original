using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Infraestructura.Enumerados;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Impresion.Fitocorp
{
    public class ImpresionFito : IImpresion
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
            LetrasFito oLetraImpresion = new LetrasFito();
            StringBuilder CadenaDireccion = new StringBuilder();
            Int32 totLetras = 0;
            String PrimerParrafo = String.Empty;
            String SegundoParrafo = String.Empty;
            List<string> Palabras = null;

            oLetraImpresion.AgregarDatos(oLetra.Numero, "42", "26"); //1

            if (oLetra.ListaFacturas.Count > 1) //1
            {
                oLetraImpresion.AgregarDatos(oLetra.ListaFacturas[0].idDocumento + "/" + Global.Derecha(oLetra.ListaFacturas[0].numSerie, 2) + "-" + Global.Derecha(oLetra.ListaFacturas[0].numDocumento, 5) + "\n\r" +
                                            oLetra.ListaFacturas[1].idDocumento + "/" + Global.Derecha(oLetra.ListaFacturas[1].numSerie, 2) + "-" + Global.Derecha(oLetra.ListaFacturas[1].numDocumento, 5), "68", "26");
            }
            else
            {
                oLetraImpresion.AgregarDatos(oLetra.ListaFacturas[0].idDocumento + "/" + Global.Derecha(oLetra.ListaFacturas[0].numSerie, 2) + "-" + Global.Derecha(oLetra.ListaFacturas[0].numDocumento, 5), "68", "26");
            }

            oLetraImpresion.AgregarDatos(oLetra.desPlazaGirador, "100", "26"); //2
            oLetraImpresion.AgregarDatos(oLetra.Fecha.ToString("d"), "125", "26"); //1
            oLetraImpresion.AgregarDatos(oLetra.FechaVenc.ToString("d"), "151", "26"); //2
            oLetraImpresion.AgregarDatos(oLetra.desMoneda + " " + oLetra.MontoOrigen.ToString("N2"), "180", "26"); //1

            String MonedaFinal = (from x in VariablesLocales.ListaMonedas where x.idMoneda == oLetra.idMoneda select x.desMoneda).SingleOrDefault();
            oLetraImpresion.AgregarDatos(enLetras(oLetra.MontoOrigen.ToString()) + " " + MonedaFinal.ToUpper(), "48", "38");

            oLetraImpresion.AgregarDatos(oLetra.GiradoA, "53", "47");
            oLetraImpresion.AgregarDatos(oLetra.RUC, "55", "54");

            if (oLetra.Direccion.Length > 35)
            {
                Palabras = new List<String>(oLetra.Direccion.Split(' '));

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    CadenaDireccion.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion.Length <= 35)
                    {
                        continue;
                    }
                    else
                    {
                        PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
                        break;
                    }
                }

                SegundoParrafo = oLetra.Direccion.Replace(PrimerParrafo, "").Trim();

                oLetraImpresion.AgregarDatos(PrimerParrafo, "41", "64");
                oLetraImpresion.AgregarDatos(SegundoParrafo, "41", "67");
                CadenaDireccion.Clear();
            }
            else
            {
                oLetraImpresion.AgregarDatos(oLetra.Direccion, "41", "64");
            }

            oLetraImpresion.AgregarDatos(oLetra.Aval, "52", "73");
            oLetraImpresion.AgregarDatos(oLetra.DoiAval, "53", "80");
            oLetraImpresion.AgregarDatos(oLetra.DireccionAval, "52", "86");
            //oLetraImpresion.AgregarDatos(oLetra.desPlazaGiradoA, "40", "90");

            //Imprimiendo
            oLetraImpresion.ImprimirLetra(RutaImpresion);
        }

        #endregion

        #region Procedimientos Privados

        private void GuiaVentas(EmisionDocumentoE oGuia, String nomImpresora)
        {
            GuiasFito oGuiaImpresion = new GuiasFito();
            DateTime fecTraslado = Convert.ToDateTime(oGuia.fecTraslado);
            List<String> Palabras = null;
            StringBuilder CadenaDireccion = new StringBuilder();
            String PrimerParrafo = String.Empty;
            String SegundoParrafo = String.Empty;

            List<String> Palabras1 = null;
            StringBuilder CadenaDireccion1 = new StringBuilder();
            String PrimerParrafo1 = String.Empty;
            String SegundoParrafo1 = String.Empty;
            Int32 totLetras1 = 0;

            Int32 correlativo = 0;
            Decimal PesoBruto = 0;
            Int32 totLetras = 0;

            //Destinatario
            oGuiaImpresion.AgregarDatos(oGuia.RazonSocial, "32", "27");

            if (oGuia.Direccion.Length > 45)
            {
                Palabras = new List<String>(oGuia.Direccion.Split(' '));

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

                SegundoParrafo = oGuia.Direccion.Replace(PrimerParrafo, "").Trim();

                oGuiaImpresion.AgregarDatos(PrimerParrafo, "32", "35");
                oGuiaImpresion.AgregarDatos(SegundoParrafo, "32", "38");
                CadenaDireccion.Clear();
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.Direccion, "32", "35");
            }
            
            oGuiaImpresion.AgregarDatos(oGuia.numRuc, "32", "45");



            //oGuiaImpresion.AgregarDatos(oGuia.fecEmision.ToString("d"), "25", "66"); //Por revisar
            if (oGuia.ListaCanjeGuias.Count > 0)
            {
                oGuiaImpresion.AgregarDatos(oGuia.ListaCanjeGuias[0].numSerieFact + "-" + oGuia.ListaCanjeGuias[0].numDocumentoFact, "90", "66");
            }
            oGuiaImpresion.AgregarDatos(oGuia.numDocumentoRef, "150", "66");

            //Detalle(Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oGuia.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    correlativo++;
                    oGuiaImpresion.AgregarItems(string.Format("{0:0000}", correlativo) +'|' +item.codArticulo + '|' + item.desUMedida + "|"
                        + item.LoteProveedor  + "|" + item.nomArticulo + "|" + Convert.ToInt32(item.Cantidad).ToString("N2") );
                    PesoBruto += item.Cantidad * item.PesoUnitario.Value;

                }
            }

            //Titulos del detalle
            oGuiaImpresion.AgregarDatos(oGuia.PesoBruto, "25", "90");

            oGuiaImpresion.AgregarDatos(oGuia.Glosa, "51", "80");
            oGuiaImpresion.AgregarDatos(oGuia.fecTraslado.Value.ToString("d"), "51", "146");


            if (oGuia.PuntoLlegada.Length > 35)
            {
                Palabras1 = new List<String>(oGuia.PuntoLlegada.Split(' '));

                foreach (String item in Palabras1)
                {
                    totLetras1 = item.Length;
                    CadenaDireccion1.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion1.Length <= 35)
                    {
                        continue;
                    }
                    else
                    {
                        PrimerParrafo1 = CadenaDireccion1.ToString().Substring(0, CadenaDireccion1.ToString().Trim().Length - totLetras1);
                        break;
                    }
                }

                SegundoParrafo1 = oGuia.PuntoLlegada.Replace(PrimerParrafo1, "").Trim();

                oGuiaImpresion.AgregarDatos(PrimerParrafo1, "135", "194");
                oGuiaImpresion.AgregarDatos(SegundoParrafo1, "135", "198");
                CadenaDireccion1.Clear();
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.PuntoLlegada, "135", "195");
            }



            oGuiaImpresion.AgregarDatos(oGuia.PuntoPartida.ToLower(), "15", "200");
            oGuiaImpresion.AgregarDatos(oGuia.RucTransp, "155", "204");

            oGuiaImpresion.AgregarDatos(oGuia.RazonSocialTransp, "15", "206");
            

            oGuiaImpresion.AgregarDatos(oGuia.DireccionTransp, "18", "211");


            //Imprimiendo la guia de traslado
            oGuiaImpresion.ImprimirGuia(nomImpresora);
        }

        private void Facturas(EmisionDocumentoE oFactura, String nomImpresora)
        {
            String Moneda = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oFactura.fecEmision);
            FacturasFito oFacturaImpresion = new FacturasFito();
            List<string> Palabras = null;
            StringBuilder CadenaDireccion = new StringBuilder();
            Int32 totLetras = 0;
            String PrimerParrafo = String.Empty;
            String SegundoParrafo = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oFactura.idMoneda
                                select x).SingleOrDefault();


            //Cabecera (Dato, x, y)
            oFacturaImpresion.AgregarDatos(oFactura.RazonSocial, "35", "52");

            //Dirección...
            if (oFactura.Direccion.Length > 90)
            {
                Palabras = new List<String>(oFactura.Direccion.Split(' '));

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    CadenaDireccion.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion.Length <= 90)
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

                oFacturaImpresion.AgregarDatos(PrimerParrafo, "35", "65");
                oFacturaImpresion.AgregarDatos(SegundoParrafo, "37", "68");
                CadenaDireccion.Clear();
            }
            else
            {
                oFacturaImpresion.AgregarDatos(oFactura.Direccion, "35", "65");
                oFacturaImpresion.AgregarDatos(oFactura.EsGuia, "45", "75");
            }


            //Por revisar //oFacturaImpresion.AgregarDatos(oFactura.fecEmision.Day + " " + FechasHelper.NombreMes(oFactura.fecEmision.Month) + " "+ oFactura.fecEmision.Year, "150", "52");
            oFacturaImpresion.AgregarDatos(oFactura.numRuc, "35", "74");

            StringBuilder CadenaGuias = new StringBuilder();

            foreach (CanjeGuiasE item in oFactura.ListaCanjeGuias)
            {
                CadenaGuias.Append(item.numSerieGuia).Append("-").Append(item.numDocumentoGuia).Append(" ");
            }
            
            oFacturaImpresion.AgregarDatos(CadenaGuias.ToString().Trim(), "100", "74"); //NumGuia
            oFacturaImpresion.AgregarDatos(!String.IsNullOrEmpty(oFactura.serDocumentoRef) ?
                                            oFactura.serDocumentoRef + "-" + oFactura.numDocumentoRef : oFactura.numDocumentoRef, "170", "74"); //O.C.

            ////Detalle (Separarlo por Palotes)
            String Subtotal = String.Empty;
            Decimal Valorcero = 0;

            foreach (EmisionDocumentoDetE item in oFactura.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    if (!item.indCalculo)
                    {
                        Subtotal = Valorcero.ToString("N2");
                    }
                    else
                    {
                        Subtotal = Convert.ToDecimal(item.subTotal).ToString("N2");
                    }

                    oFacturaImpresion.AgregarItems(item.codArticulo + "|" + Convert.ToInt32(item.Cantidad).ToString("N2") + "|" 
                        + item.nomArticulo + "|" + item.PrecioCad + "|" + Subtotal);
                }
                else
                {
                    oFacturaImpresion.AgregarItems(item.codArticulo + "|" + String.Empty + "|" + item.nomArticulo + "|" + item.PrecioCad + "|" + item.SubTotalCad);
                }
            }

            Moneda = " " + oMoneda.desMoneda.ToUpper();

            string numDerecha = String.Empty;


            //Valor Venta
            numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totsubTotal.ToString("N2").Length, 8) + oFactura.totsubTotal.ToString("N2");

            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "170", "192");

            ////IGV
            //if (oFactura.totIgv > 0)
            //{
            //    numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totIgv.Value.ToString("N2").Length, 8) + oFactura.totIgv.Value.ToString("N2");
            //    oFacturaImpresion.AgregarDatos(oFactura.ListaItemsDocumento[0].porIgv.ToString("N2"), "160", "199");
            //    oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "170", "199");
            //}
            //else
            //{
            //    oFacturaImpresion.AgregarDatos(oFactura.ListaItemsDocumento[0].porIgv.ToString("N2"), "160", "199");
            //    numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totIgv.Value.ToString("N2").Length, 8) + oFactura.totIgv.Value.ToString("N2");
            //    oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "170", "199");
            //}

            if (oFactura.desCondicion.Contains("TRANSFERENCIA"))
            {
                numDerecha = oFacturaImpresion.AlinearDerecha(4, 8) + "0.00";
            }
            else
            {
                numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totTotal.ToString("N2").Length, 8) + oFactura.totTotal.ToString("N2");
            }

            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "170", "206");
            oFacturaImpresion.AgregarDatos(NumeroLetras.enLetras(oFactura.totTotal.ToString()) + Moneda, "35", "178");
            
            //Imprimiendo
            oFacturaImpresion.ImprimirFactura(nomImpresora);
        }

        private void NotaDeCreditoNC(EmisionDocumentoE oNotaCredito, String nomImpresora)
        {
            NotasDeCreditoFito oNcImpresion = new NotasDeCreditoFito();
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
            //Por revisar//oNcImpresion.AgregarDatos(oNotaCredito.fecEmision.Day + "      " + oNotaCredito.fecEmision.Month + "       "+ oNotaCredito.fecEmision.Year, "36", "37");
            oNcImpresion.AgregarDatos(oNotaCredito.RazonSocial, "37", "44");
            oNcImpresion.AgregarDatos(oNotaCredito.Direccion, "28", "51.5");
            oNcImpresion.AgregarDatos(oNotaCredito.numRuc, "25", "58");

            oNcImpresion.AgregarDatos(NombreDocumento, "150", "51.5");
            oNcImpresion.AgregarDatos(oNotaCredito.serDocumentoRef + "-" + oNotaCredito.numDocumentoRef, "135", "58");
            oNcImpresion.AgregarDatos(Convert.ToDateTime(oNotaCredito.fecDocumentoRef).ToString("dd/MM/yyyy"), "165", "66.5");

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
                    oNcImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString(Formato) + "|" + Convert.ToDecimal(item.subTotal).ToString("N2"));
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
            oNcImpresion.AgregarDatos(enLetras(oNotaCredito.totTotal.ToString()) + Moneda, "17", "115"); //Español

            //Motivo
            //oNcImpresion.AgregarDatos(oNotaCredito.desCondicion, "58", "133.5");

            //if (!String.IsNullOrEmpty(oNotaCredito.Glosa))
            //{
            //    oNcImpresion.AgregarDatos(oNotaCredito.Glosa, "58", "138");
            //}

            //Totales
            string Numeros = String.Empty;
            Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totsubTotal).ToString("N2");
            oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "123", "132");
            Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2");
            oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "153", "132");
            Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
            oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "132");

            //Imprimiendo
            oNcImpresion.ImprimirNC(nomImpresora);
        }

        private void NotaDeDebitoND(EmisionDocumentoE oNotaDebito, String nomImpresora)
        {
            NotasDeDebitoFito oNdImpresion = new NotasDeDebitoFito();
            String NombreDocumento = String.Empty;
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


            //Por revisar//oNdImpresion.AgregarDatos(oNotaDebito.fecEmision.Day.ToString("00") + "         " + oNotaDebito.fecEmision.Month.ToString("00") + "         " + oNotaDebito.fecEmision.Year, "24", "44");
            oNdImpresion.AgregarDatos(oNotaDebito.RazonSocial, "28", "50");
            oNdImpresion.AgregarDatos(oNotaDebito.numRuc, "28", "58");
            oNdImpresion.AgregarDatos(oNotaDebito.Direccion, "30", "66");

            oNdImpresion.AgregarDatos(NombreDocumento, "173", "55");
            oNdImpresion.AgregarDatos(oNotaDebito.serDocumentoRef + "-" + oNotaDebito.numDocumentoRef, "170", "61");
            oNdImpresion.AgregarDatos(Convert.ToDateTime(oNotaDebito.fecDocumentoRef).ToString("dd/MM/yyyy"), "173", "67");

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

            if (!String.IsNullOrEmpty(oNotaDebito.Glosa))
            {
                oNdImpresion.AgregarDatos(oNotaDebito.Glosa, "58", "133");
            }

            //Totales
            string Numeros = String.Empty;
            Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totsubTotal).ToString("N2");
            oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "180", "134.5");
            Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2");
            oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "180", "140.5");
            Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2");
            oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "180", "146.5");

            //Imprimiendo
            oNdImpresion.ImprimirND(nomImpresora);
        }

        private void BoletaVenta(EmisionDocumentoE oBoleta, String nomImpresora)
        {
            String Moneda = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oBoleta.fecEmision);
            BoletasFito oBoletaImpresion = new BoletasFito();
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oBoleta.idMoneda
                                select x).SingleOrDefault();
            String Anio = fecEmision.Year.ToString();


            if (oBoleta.ListaCanjeGuias != null && oBoleta.ListaCanjeGuias.Count > Variables.Cero)
            {
                StringBuilder CadenaGuias = new StringBuilder();

                foreach (CanjeGuiasE item in oBoleta.ListaCanjeGuias)
                {
                    CadenaGuias.Append(item.numSerieGuia).Append("-").Append(item.numDocumentoGuia).Append(" ");
                }
                
                oBoletaImpresion.AgregarDatos(CadenaGuias.ToString().Trim(), "165", "59");
            }
            else
            {
                oBoletaImpresion.AgregarDatos(String.Empty, "165", "59");
            }

            //Cabecera (Dato, x, y)
            oBoletaImpresion.AgregarDatos(oBoleta.RazonSocial, "36", "46");
            oBoletaImpresion.AgregarDatos(oBoleta.Direccion, "34", "52");
            oBoletaImpresion.AgregarDatos(fecEmision.Day + "           " + FechasHelper.NombreMes(fecEmision.Month) + "                   " + Anio.Substring(2,2), "150", "52");
            oBoletaImpresion.AgregarDatos(oBoleta.numRuc, "32", "59");

            ////Detalle (Separarlo por Palotes)
            String Subtotal = String.Empty;
            Decimal Valorcero = 0;

            foreach (EmisionDocumentoDetE item in oBoleta.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    if (!item.indCalculo)
                    {
                        Subtotal = Valorcero.ToString("N2");
                    }
                    else
                    {
                        Subtotal = Convert.ToDecimal(item.Total).ToString("N2");
                    }

                    oBoletaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.codArticulo + "|"
                        + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioConImpuesto).ToString("N2") + "|" + Subtotal); 
                }
                else
                {
                    oBoletaImpresion.AgregarItems(item.CantidadCad + "|" + item.codArticulo + "|" + item.nomArticulo + "|" + item.PrecioCad + "|" + item.TotalCad);
                }
            }

            //Total
            Moneda = " " + oMoneda.desMoneda.ToUpper();

            if (oBoleta.desCondicion.Contains("TRANSFERENCIA"))
            {
                oBoletaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  0.00", "185", "138");
            }
            else
            {
                oBoletaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oBoleta.totTotal.ToString("N2"), "185", "138");
            }

            //Imprimiendo
            oBoletaImpresion.ImprimirBoleta(nomImpresora);
        }

        #endregion

    }
}
