using Entidades.Generales;
using Entidades.Ventas;
using Infraestructura.Enumerados;
using Presentadora.AgenteServicio;
using Infraestructura;
using Infraestructura.Winform;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteWinForm.Impresion.Sergensur
{
    public class ImpresionSergen : IImpresion
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
            //if (String.IsNullOrEmpty(RutaImpresion.Trim()))
            //{
            //    throw new Exception("No se encontró la ruta o el nombre de le impresora.");
            //}

            //ControlDocumento = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(DocumentoEmision.idEmpresa, DocumentoEmision.idLocal, 2, DocumentoEmision.idDocumento, DocumentoEmision.numSerie);

            //if (ControlDocumento != null)
            //{
            //    Int32 CantidadRegistros = DocumentoEmision.ListaItemsDocumento.Count;

            //    if (CantidadRegistros > ControlDocumento.cantItems)
            //    {
            //        throw new Exception("La cantidad de items a sobrepasado la configuración guardada para este documento.");
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
            //    Int32 CantidadRegistros = DocumentoEmision.ListaItemsDocumento.Count;

            //    if (CantidadRegistros > ControlDocumento.cantItems)
            //    {
            //        throw new Exception("La cantidad de items a sobrepasado la configuración guardada para este documento.");
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
            //    Int32 CantidadRegistros = DocumentoEmision.ListaItemsDocumento.Count;

            //    if (CantidadRegistros > ControlDocumento.cantItems)
            //    {
            //        throw new Exception("La cantidad de items a sobrepasado la configuración guardada para este documento.");
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
            //LetrasFito oLetraImpresion = new LetrasFito();
            //StringBuilder CadenaDireccion = new StringBuilder();
            //Int32 totLetras = 0;
            //String PrimerParrafo = String.Empty;
            //String SegundoParrafo = String.Empty;
            //List<string> Palabras = null;

            //oLetraImpresion.AgregarDatos(oLetra.Numero, "38", "35"); //1

            //if (oLetra.ListaFacturas.Count > 1) //1
            //{
            //    oLetraImpresion.AgregarDatos(oLetra.ListaFacturas[0].idDocumento + "/" + Global.Derecha(oLetra.ListaFacturas[0].numSerie, 2) + "-" + Global.Derecha(oLetra.ListaFacturas[0].numDocumento, 5) + "\n\r" +
            //                                oLetra.ListaFacturas[1].idDocumento + "/" + Global.Derecha(oLetra.ListaFacturas[1].numSerie, 2) + "-" + Global.Derecha(oLetra.ListaFacturas[1].numDocumento, 5), "64", "36");
            //}
            //else
            //{
            //    oLetraImpresion.AgregarDatos(oLetra.ListaFacturas[0].idDocumento + "/" + Global.Derecha(oLetra.ListaFacturas[0].numSerie, 2) + "-" + Global.Derecha(oLetra.ListaFacturas[0].numDocumento, 5), "64", "36");
            //}

            //oLetraImpresion.AgregarDatos(oLetra.desPlazaGirador, "95", "36"); //2
            //oLetraImpresion.AgregarDatos(oLetra.Fecha.ToString("d"), "122", "38"); //1
            //oLetraImpresion.AgregarDatos(oLetra.FechaVenc.ToString("d"), "148", "38"); //2
            //oLetraImpresion.AgregarDatos(oLetra.desMoneda + " " + oLetra.MontoOrigen.ToString("N2"), "177", "36"); //1

            //String MonedaFinal = (from x in VariablesLocales.ListaMonedas where x.idMoneda == oLetra.idMoneda select x.desMoneda).SingleOrDefault();
            //oLetraImpresion.AgregarDatos(enLetras(oLetra.MontoOrigen.ToString()) + " " + MonedaFinal.ToUpper(), "42", "48");

            //oLetraImpresion.AgregarDatos(oLetra.GiradoA, "54.5", "60");
            ////oLetraImpresion.AgregarDatos(oLetra.Direccion, "50", "55");
            //oLetraImpresion.AgregarDatos(oLetra.RUC, "54.5", "68");

            //if (oLetra.Direccion.Length > 28)
            //{
            //    Palabras = new List<String>(oLetra.Direccion.Split(' '));

            //    foreach (String item in Palabras)
            //    {
            //        totLetras = item.Length;
            //        CadenaDireccion.Append(item.Trim()).Append(" ");

            //        if (CadenaDireccion.Length <= 28)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            PrimerParrafo = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
            //            break;
            //        }
            //    }

            //    SegundoParrafo = oLetra.Direccion.Replace(PrimerParrafo, "").Trim();

            //    oLetraImpresion.AgregarDatos(PrimerParrafo, "54.5", "74");
            //    oLetraImpresion.AgregarDatos(SegundoParrafo, "54.5", "77");
            //    CadenaDireccion.Clear();
            //}
            //else
            //{
            //    oLetraImpresion.AgregarDatos(oLetra.Direccion, "54.5", "74");
            //}

            ////Imprimiendo
            //oLetraImpresion.ImprimirLetra(RutaImpresion);
        }

        #endregion

        #region Procedimientos Privados

        private void GuiaVentas(EmisionDocumentoE oGuia, String nomImpresora)
        {
            GuiasSergen oGuiaImpresion = new GuiasSergen();
            DateTime fecTraslado = Convert.ToDateTime(oGuia.fecTraslado);
            StringBuilder CadenaDireccion = new StringBuilder();
            String PrimerParrafo = String.Empty;
            String SegundoParrafo = String.Empty;
            String PrimerParrafo1 = String.Empty;
            String SegundoParrafo2 = String.Empty;
            Int32 correlativo = 0;
            Decimal PesoBruto = 0;
            Int32 totLetras = 0;
            List<string> Palabras = null;
            //Destinatario
            //Por revisar//oGuiaImpresion.AgregarDatos(oGuia.fecEmision.Day + "                " + FechasHelper.NombreMes(oGuia.fecEmision.Month) + "                                  " + oGuia.fecEmision.Year.ToString().Substring(2,2), "12", "46");


            //PUNTO DE PARTIDA
            //oGuiaImpresion.AgregarDatos(oGuia.PuntoPartida, "30", "55");

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
                        PrimerParrafo1 = CadenaDireccion.ToString().Substring(0, CadenaDireccion.ToString().Trim().Length - totLetras);
                        break;
                    }
                }

                SegundoParrafo2 = oGuia.PuntoPartida.Replace(PrimerParrafo1, "").Trim();

                oGuiaImpresion.AgregarDatos(PrimerParrafo1, "40", "55");
                oGuiaImpresion.AgregarDatos(SegundoParrafo2, "20", "60");
                CadenaDireccion.Clear();
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.PuntoPartida, "30", "55");
            }


            oGuiaImpresion.AgregarDatos(oGuia.fecTraslado.Value.ToString("d"), "50", "64");
            oGuiaImpresion.AgregarDatos(oGuia.MarcaTransp, "70", "67");
            oGuiaImpresion.AgregarDatos(oGuia.PlacaTransp, "35", "71");
            oGuiaImpresion.AgregarDatos(oGuia.inscripTransp, "50", "71");
            oGuiaImpresion.AgregarDatos(oGuia.LicenciaTransp, "85", "71");
            oGuiaImpresion.AgregarDatos(oGuia.ConductorTransp, "50", "75");



            //PUNTO DE LLEGADA
            if (oGuia.PuntoLlegada.ToString().Length <= 45)
            {
                oGuiaImpresion.AgregarDatos(oGuia.PuntoLlegada.ToString(), "138", "55");
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.PuntoLlegada.ToString().Substring(0, 45), "138", "55");
            }
            oGuiaImpresion.AgregarDatos(oGuia.RazonSocial, "158", "59");
            oGuiaImpresion.AgregarDatos(oGuia.numRuc, "165", "63");            
            if (oGuia.RazonSocialTransp.Length > 23)
            {
                Palabras = new List<String>(oGuia.RazonSocialTransp.Split(' '));

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    CadenaDireccion.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion.Length <= 23)
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

                oGuiaImpresion.AgregarDatos(PrimerParrafo, "170", "67");
                oGuiaImpresion.AgregarDatos(SegundoParrafo, "120", "72");
                CadenaDireccion.Clear();
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.RazonSocialTransp, "170", "67");
            }
            oGuiaImpresion.AgregarDatos(oGuia.RucTransp, "135", "77");                   
            oGuiaImpresion.AgregarDatos(oGuia.numDocumentoRef, "125", "65");


            oGuiaImpresion.AgregarDatos(oGuia.desTipoCompra, "100", "220");

            //Titulos del detalle
            //oGuiaImpresion.AgregarDatos(oGuia.fecTraslado.Value.ToString("d"), "45", "145");
            //oGuiaImpresion.AgregarDatos(oGuia.RazonSocialTransp, "35", "191");
            //oGuiaImpresion.AgregarDatos(oGuia.RucTransp, "140", "191");
            //oGuiaImpresion.AgregarDatos(oGuia.PuntoPartida.ToLower(), "4", "200");
            //oGuiaImpresion.AgregarDatos(oGuia.PuntoLlegada.ToLower(), "155", "200");

            //Detalle(Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oGuia.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    correlativo++;
                    oGuiaImpresion.AgregarItems("" + '|' + Convert.ToInt32(item.Cantidad).ToString() + '|' + item.nomArticulo + "|"
                        + item.PesoBrutoCad + "|" + item.desUMedida);
                    PesoBruto += item.Cantidad * item.PesoUnitario.Value;

                }
            }
            

            //Imprimiendo la guia de traslado
            oGuiaImpresion.ImprimirGuia(nomImpresora);
        }

        private void Facturas(EmisionDocumentoE oFactura, String nomImpresora)
        {
            String Moneda = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oFactura.fecEmision);
            FacturasSergen oFacturaImpresion = new FacturasSergen();
            List<string> Palabras = null;
            StringBuilder CadenaDireccion = new StringBuilder();
            Int32 totLetras = 0;
            String PrimerParrafo = String.Empty;
            String SegundoParrafo = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oFactura.idMoneda
                                select x).SingleOrDefault();

            //Cabecera (Dato, x, y)
            oFacturaImpresion.AgregarDatos(oFactura.RazonSocial, "37", "43");

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

                oFacturaImpresion.AgregarDatos(PrimerParrafo, "37", "48");
                oFacturaImpresion.AgregarDatos(SegundoParrafo, "37", "52");
                CadenaDireccion.Clear();
            }
            else
            {
                oFacturaImpresion.AgregarDatos(oFactura.Direccion, "37", "49");
            }


            //Por revisar//oFacturaImpresion.AgregarDatos(oFactura.fecEmision.Day + "                " + FechasHelper.NombreMes(oFactura.fecEmision.Month) + "                          " + oFactura.fecEmision.Year.ToString().Substring(2, 2), "142", "49");

            oFacturaImpresion.AgregarDatos(oFactura.numRuc, "37", "56");

            StringBuilder CadenaGuias = new StringBuilder();

            foreach (CanjeGuiasE item in oFactura.ListaCanjeGuias)
            {
                CadenaGuias.Append(item.numSerieGuia).Append("-").Append(item.numDocumentoGuia).Append(" ");
            }

            oFacturaImpresion.AgregarDatos(CadenaGuias.ToString().Trim(), "180", "54"); //NumGuia
            //oFacturaImpresion.AgregarDatos(!String.IsNullOrEmpty(oFactura.serDocumentoRef) ?
            //                                oFactura.serDocumentoRef + "-" + oFactura.numDocumentoRef : oFactura.numDocumentoRef, "180", "56"); //O.C.




            ////Detalle (Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oFactura.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    oFacturaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N2") + "|"
                        + item.nomArticulo + "|" + item.PrecioCad + "|" +item.TotalCad);
                }
            }

            Moneda = " " + oMoneda.desMoneda.ToUpper();

            string numDerecha = String.Empty;
            //Valor Venta
            numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totsubTotal.ToString("N2").Length, 8) + oFactura.totsubTotal.ToString("N2");
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "190", "248 ");

            //IGV
            if (oFactura.totIgv > 0)
            {
                oFacturaImpresion.AgregarDatos(oFactura.ListaItemsDocumento[0].porIgv.ToString("N2"), "182", "255");
                numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totIgv.Value.ToString("N2").Length, 8) + oFactura.totIgv.Value.ToString("N2");
                oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "190", "255");
            }
            else
            {
                oFacturaImpresion.AgregarDatos(oFactura.ListaItemsDocumento[0].porIgv.ToString("N2"), "182", "255");
                numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totIgv.Value.ToString("N2").Length, 8) + oFactura.totIgv.Value.ToString("N2");
                oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "190", "255");
            }

            numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totTotal.ToString("N2").Length, 8) + oFactura.totTotal.ToString("N2");
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "190", "262");


            if (oFactura.desCondicion.Contains("TRANSFERENCIA"))
            {
                oFacturaImpresion.AgregarDatos(NumeroLetras.enLetras("0.00") + Moneda, "35", "245");
            }
            else
            {
                oFacturaImpresion.AgregarDatos(NumeroLetras.enLetras(oFactura.totTotal.ToString()) + Moneda, "35", "245");
            }

            //Imprimiendo
            oFacturaImpresion.ImprimirFactura(nomImpresora);
        }

        //private void NotaDeCreditoNC(EmisionDocumentoE oNotaCredito, String nomImpresora)
        //{
        //    NotasDeCreditoFito oNcImpresion = new NotasDeCreditoFito();
        //    String NombreDocumento = String.Empty;
        //    String Moneda = String.Empty;
        //    String Ruc = String.Empty;
        //    MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
        //                        where x.idMoneda == oNotaCredito.idMoneda
        //                        select x).SingleOrDefault();

        //    //Cabecera
        //    if (oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.FE.ToString() ||
        //        oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.FS.ToString() ||
        //        oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.FV.ToString())
        //    {
        //        NombreDocumento = "Factura de Venta";
        //    }
        //    else if (oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.BV.ToString())
        //    {
        //        NombreDocumento = "Boleta de Venta";
        //    }
        //    oNcImpresion.AgregarDatos(oNotaCredito.fecEmision.Day + "      " + oNotaCredito.fecEmision.Month + "       " + oNotaCredito.fecEmision.Year, "36", "37");
        //    oNcImpresion.AgregarDatos(oNotaCredito.RazonSocial, "37", "44");
        //    oNcImpresion.AgregarDatos(oNotaCredito.Direccion, "28", "51.5");
        //    oNcImpresion.AgregarDatos(oNotaCredito.numRuc, "25", "58");



        //    oNcImpresion.AgregarDatos(NombreDocumento, "150", "51.5");
        //    oNcImpresion.AgregarDatos(oNotaCredito.serDocumentoRef + "-" + oNotaCredito.numDocumentoRef, "135", "58");
        //    oNcImpresion.AgregarDatos(Convert.ToDateTime(oNotaCredito.fecDocumentoRef).ToString("dd/MM/yyyy"), "165", "66.5");

        //    String Formato = String.Empty;

        //    if (ControlDocumento.cantDigDecimales == 3)
        //    {
        //        Formato = "N3";
        //    }
        //    else if (ControlDocumento.cantDigDecimales == 4)
        //    {
        //        Formato = "N4";
        //    }
        //    else if (ControlDocumento.cantDigDecimales == 5)
        //    {
        //        Formato = "N5";
        //    }
        //    else if (ControlDocumento.cantDigDecimales == 6)
        //    {
        //        Formato = "N6";
        //    }
        //    else if (ControlDocumento.cantDigDecimales == 7)
        //    {
        //        Formato = "###,###,##0.0000000";
        //    }
        //    else
        //    {
        //        Formato = "N2";
        //    }

        //    //Detalle(Separarlo por Palotes)
        //    foreach (EmisionDocumentoDetE item in oNotaCredito.ListaItemsDocumento)
        //    {
        //        if (item.Cantidad > 0 && item.nomArticulo != null)
        //        {
        //            oNcImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString(Formato) + "|" + Convert.ToDecimal(item.Total).ToString("N2"));
        //        }
        //    }

        //    Moneda = " " + oMoneda.desMoneda.ToUpper();
        //    //if (Convert.ToInt32(oNotaCredito.idMoneda) == (Int32)EnumTipoMoneda.Soles)
        //    //{
        //    //    Moneda = " SOLES";
        //    //}
        //    //else if (Convert.ToInt32(oNotaCredito.idMoneda) == (Int32)EnumTipoMoneda.Dolares)
        //    //{
        //    //    Moneda = " DOLARES AMERICANOS";
        //    //}
        //    //else
        //    //{
        //    //    Moneda = " EUROS";
        //    //}

        //    //Total en Letras
        //    oNcImpresion.AgregarDatos(enLetras(oNotaCredito.totTotal.ToString()) + Moneda, "17", "115"); //Español

        //    //Motivo
        //    //oNcImpresion.AgregarDatos(oNotaCredito.desCondicion, "58", "133.5");

        //    //if (!String.IsNullOrEmpty(oNotaCredito.Glosa))
        //    //{
        //    //    oNcImpresion.AgregarDatos(oNotaCredito.Glosa, "58", "138");
        //    //}

        //    //Totales
        //    string Numeros = String.Empty;
        //    Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
        //    oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "123", "132");
        //    Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2");
        //    oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "153", "132");
        //    Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
        //    oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "183", "132");

        //    //Imprimiendo
        //    oNcImpresion.ImprimirNC(nomImpresora);
        //}

        //private void NotaDeDebitoND(EmisionDocumentoE oNotaDebito, String nomImpresora)
        //{
        //    NotasDeDebitoFito oNdImpresion = new NotasDeDebitoFito();
        //    String NombreDocumento = String.Empty;
        //    String Ruc = String.Empty;
        //    MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
        //                        where x.idMoneda == oNotaDebito.idMoneda
        //                        select x).SingleOrDefault();

        //    //Cabecera
        //    if (oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FE.ToString() || oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FS.ToString() ||
        //        oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FV.ToString())
        //    {
        //        NombreDocumento = "Factura de Venta";
        //    }
        //    else if (oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.BV.ToString())
        //    {
        //        NombreDocumento = "Boleta de Venta";
        //    }
        //    oNdImpresion.AgregarDatos(oNotaDebito.fecEmision.Day + "         " + oNotaDebito.fecEmision.Month + "         " + oNotaDebito.fecEmision.Year, "30", "40");
        //    oNdImpresion.AgregarDatos(oNotaDebito.RazonSocial, "28", "50");
        //    oNdImpresion.AgregarDatos(oNotaDebito.numRuc, "28", "58");
        //    oNdImpresion.AgregarDatos(oNotaDebito.Direccion, "30", "66");



        //    oNdImpresion.AgregarDatos(NombreDocumento, "173", "55");
        //    oNdImpresion.AgregarDatos(oNotaDebito.serDocumentoRef + "-" + oNotaDebito.numDocumentoRef, "170", "61");
        //    oNdImpresion.AgregarDatos(Convert.ToDateTime(oNotaDebito.fecDocumentoRef).ToString("dd/MM/yyyy"), "173", "67");

        //    String Formato = String.Empty;

        //    if (ControlDocumento.cantDigDecimales == 3)
        //    {
        //        Formato = "N3";
        //    }
        //    else if (ControlDocumento.cantDigDecimales == 4)
        //    {
        //        Formato = "N4";
        //    }
        //    else if (ControlDocumento.cantDigDecimales == 5)
        //    {
        //        Formato = "N5";
        //    }
        //    else if (ControlDocumento.cantDigDecimales == 6)
        //    {
        //        Formato = "N6";
        //    }
        //    else if (ControlDocumento.cantDigDecimales == 7)
        //    {
        //        Formato = "###,###,##0.0000000";
        //    }
        //    else
        //    {
        //        Formato = "N2";
        //    }

        //    //Detalle(Separarlo por Palotes)
        //    foreach (EmisionDocumentoDetE item in oNotaDebito.ListaItemsDocumento)
        //    {
        //        if (item.Cantidad > 0 && item.nomArticulo != null)
        //        {
        //            oNdImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString(Formato) + "|" + Convert.ToDecimal(item.Total).ToString("N2"));
        //        }
        //    }

        //    if (!String.IsNullOrEmpty(oNotaDebito.Glosa))
        //    {
        //        oNdImpresion.AgregarDatos(oNotaDebito.Glosa, "58", "133");
        //    }

        //    //Totales
        //    string Numeros = String.Empty;
        //    Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totsubTotal).ToString("N2");
        //    oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "180", "134.5");
        //    Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2");
        //    oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "180", "140.5");
        //    Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2");
        //    oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "180", "146.5");

        //    //Imprimiendo
        //    oNdImpresion.ImprimirND(nomImpresora);
        //}

        //private void BoletaVenta(EmisionDocumentoE oBoleta, String nomImpresora)
        //{
        //    String Moneda = String.Empty;
        //    DateTime fecEmision = Convert.ToDateTime(oBoleta.fecEmision);
        //    BoletasFito oBoletaImpresion = new BoletasFito();
        //    MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
        //                        where x.idMoneda == oBoleta.idMoneda
        //                        select x).SingleOrDefault();
        //    String Anio = fecEmision.Year.ToString();

        //    //Cabecera (Dato, x, y)
        //    oBoletaImpresion.AgregarDatos(oBoleta.RazonSocial, "36", "46");
        //    oBoletaImpresion.AgregarDatos(oBoleta.Direccion, "32", "54");
        //    oBoletaImpresion.AgregarDatos(fecEmision.Day + "       " + FechasHelper.NombreMes(fecEmision.Month) + "                   " + Anio.Substring(2, 2), "162", "54");
        //    oBoletaImpresion.AgregarDatos(oBoleta.numRuc, "32", "60");

        //    ////Detalle (Separarlo por Palotes)
        //    foreach (EmisionDocumentoDetE item in oBoleta.ListaItemsDocumento)
        //    {
        //        if (item.Cantidad > 0 && item.nomArticulo != null)
        //        {
        //            oBoletaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|"
        //                + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString("N2") + "|"
        //                + (item.indCalculo == true ? Convert.ToDecimal(item.Total).ToString("N2") : ""));
        //        }
        //    }

        //    Moneda = " " + oMoneda.desMoneda.ToUpper();



        //    oBoletaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + oBoleta.totTotal.ToString("N2"), "195", "140");


        //    //Imprimiendo
        //    oBoletaImpresion.ImprimirBoleta(nomImpresora);
        //}

        #endregion
    }
}
