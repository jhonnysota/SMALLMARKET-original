using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Impresion.Enzo
{
    public class ImpresionEnzo : IImpresion
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
            //LetrasFito oLetraImpresion = new LetrasFito();
            //StringBuilder CadenaDireccion = new StringBuilder();
            //Int32 totLetras = 0;
            //String PrimerParrafo = String.Empty;
            //String SegundoParrafo = String.Empty;
            //List<string> Palabras = null;

            //oLetraImpresion.AgregarDatos(oLetra.Numero, "42", "26"); //1

            //if (oLetra.ListaFacturas.Count > 1) //1
            //{
            //    oLetraImpresion.AgregarDatos(oLetra.ListaFacturas[0].idDocumento + "/" + Global.Derecha(oLetra.ListaFacturas[0].numSerie, 2) + "-" + Global.Derecha(oLetra.ListaFacturas[0].numDocumento, 5) + "\n\r" +
            //                                oLetra.ListaFacturas[1].idDocumento + "/" + Global.Derecha(oLetra.ListaFacturas[1].numSerie, 2) + "-" + Global.Derecha(oLetra.ListaFacturas[1].numDocumento, 5), "68", "26");
            //}
            //else
            //{
            //    oLetraImpresion.AgregarDatos(oLetra.ListaFacturas[0].idDocumento + "/" + Global.Derecha(oLetra.ListaFacturas[0].numSerie, 2) + "-" + Global.Derecha(oLetra.ListaFacturas[0].numDocumento, 5), "68", "26");
            //}

            //oLetraImpresion.AgregarDatos(oLetra.desPlazaGirador, "100", "26"); //2
            //oLetraImpresion.AgregarDatos(oLetra.Fecha.ToString("d"), "125", "26"); //1
            //oLetraImpresion.AgregarDatos(oLetra.FechaVenc.ToString("d"), "151", "26"); //2
            //oLetraImpresion.AgregarDatos(oLetra.desMoneda + " " + oLetra.MontoOrigen.ToString("N2"), "180", "26"); //1

            //String MonedaFinal = (from x in VariablesLocales.ListaMonedas where x.idMoneda == oLetra.idMoneda select x.desMoneda).SingleOrDefault();
            //oLetraImpresion.AgregarDatos(enLetras(oLetra.MontoOrigen.ToString()) + " " + MonedaFinal.ToUpper(), "48", "38");

            //oLetraImpresion.AgregarDatos(oLetra.GiradoA, "53", "47");
            //oLetraImpresion.AgregarDatos(oLetra.RUC, "55", "54");

            //if (oLetra.Direccion.Length > 35)
            //{
            //    Palabras = new List<String>(oLetra.Direccion.Split(' '));

            //    foreach (String item in Palabras)
            //    {
            //        totLetras = item.Length;
            //        CadenaDireccion.Append(item.Trim()).Append(" ");

            //        if (CadenaDireccion.Length <= 35)
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

            //    oLetraImpresion.AgregarDatos(PrimerParrafo, "41", "64");
            //    oLetraImpresion.AgregarDatos(SegundoParrafo, "41", "67");
            //    CadenaDireccion.Clear();
            //}
            //else
            //{
            //    oLetraImpresion.AgregarDatos(oLetra.Direccion, "41", "64");
            //}

            //oLetraImpresion.AgregarDatos(oLetra.Aval, "52", "73");
            //oLetraImpresion.AgregarDatos(oLetra.DoiAval, "53", "80");
            //oLetraImpresion.AgregarDatos(oLetra.DireccionAval, "52", "86");
            ////oLetraImpresion.AgregarDatos(oLetra.desPlazaGiradoA, "40", "90");

            ////Imprimiendo
            //oLetraImpresion.ImprimirLetra(RutaImpresion);
        }

        #endregion

        #region Procedimientos Privados

        private void GuiaVentas(EmisionDocumentoE oGuia, String nomImpresora)
        {
            GuiasEnzo oGuiaImpresion = new GuiasEnzo();
            DateTime fecTraslado = Convert.ToDateTime(oGuia.fecTraslado);
            List<String> Palabras = null;
            StringBuilder CadenaDireccion = new StringBuilder();
            String PrimerParrafo = String.Empty;
            String SegundoParrafo = String.Empty;
            Int32 totLetras = 0;

            List<String> Palabras2 = null;
            StringBuilder CadenaDireccion2 = new StringBuilder();
            String PrimerParrafo2 = String.Empty;
            String SegundoParrafo2 = String.Empty;
            Int32 totLetras2 = 0;

            Int32 correlativo = 0;
            Decimal PesoBruto = 0;

            //Fecha de Emision
            //Por revisar//oGuiaImpresion.AgregarDatos(oGuia.fecEmision.ToString("d"), "17", "55");
            //Fecha de traslado
            oGuiaImpresion.AgregarDatos(oGuia.fecTraslado.Value.ToString("d"), "78", "55");

            //Punto Partida...
            if (oGuia.Direccion.Length > 37)
            {
                Palabras = new List<String>(oGuia.Direccion.Split(' '));

                foreach (String item in Palabras)
                {
                    totLetras = item.Length;
                    CadenaDireccion.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion.Length <= 37)
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

                oGuiaImpresion.AgregarDatos(PrimerParrafo, "25", "62");
                oGuiaImpresion.AgregarDatos(SegundoParrafo, "3", "68");
                CadenaDireccion.Clear();
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.Direccion.ToLower(), "25", "62");
            }

            //Punto llegada
            if (oGuia.PuntoLlegada.Length > 37)
            {
                Palabras2 = new List<String>(oGuia.PuntoLlegada.Split(' '));

                foreach (String item in Palabras2)
                {
                    totLetras2 = item.Length;
                    CadenaDireccion2.Append(item.Trim()).Append(" ");

                    if (CadenaDireccion2.Length <= 37)
                    {
                        continue;
                    }
                    else
                    {
                        PrimerParrafo2 = CadenaDireccion2.ToString().Substring(0, CadenaDireccion2.ToString().Trim().Length - totLetras2);
                        break;
                    }
                }

                SegundoParrafo2 = oGuia.PuntoLlegada.Replace(PrimerParrafo2, "").Trim();

                oGuiaImpresion.AgregarDatos(PrimerParrafo2, "130", "62");
                oGuiaImpresion.AgregarDatos(SegundoParrafo2, "100", "68");
                CadenaDireccion2.Clear();
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.PuntoLlegada, "130", "62");
            }

            //Razón Social
            oGuiaImpresion.AgregarDatos(oGuia.RazonSocial, "27", "77.7");

            //Vehiculo, marca y placa
            oGuiaImpresion.AgregarDatos(oGuia.desVehiculoTransp + " " + oGuia.MarcaTransp + " " + oGuia.PlacaTransp, "130", "77.7");

            //Ruc/DNI
            if (oGuia.numRuc.Length == 11)
            {
                oGuiaImpresion.AgregarDatos(oGuia.numRuc, "8", "83.5");
            }
            else
            {
                oGuiaImpresion.AgregarDatos(oGuia.numRuc, "70", "83.5");
            }

            //Certificado de inscripción
            oGuiaImpresion.AgregarDatos(oGuia.inscripTransp, "132", "82");

            //Licencia
            oGuiaImpresion.AgregarDatos(oGuia.LicenciaTransp, "130", "85.6");

            //Detalle(Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oGuia.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    correlativo++;
                    oGuiaImpresion.AgregarItems(item.Cantidad.ToString("N2") + "|" + item.nomArticulo + "|" + item.Lote + "|"
                        + item.PesoBrutoCad + "|" + item.TotalCad);

                    PesoBruto += item.Cantidad * item.PesoUnitario.Value;
                }
            }

            //Guias asociadas
            if (oGuia.ListaCanjeGuias != null && oGuia.ListaCanjeGuias.Count > 0)
            {
                //Tipo
                if (oGuia.ListaCanjeGuias[0].idDocumentoFact == "FV")
                {
                    oGuiaImpresion.AgregarDatos("FACTURA", "3", "197");
                }
                else
                {
                    oGuiaImpresion.AgregarDatos("BOLETA", "3", "197");
                }

                String ser = String.Empty;
                String num = String.Empty;

                //Número Factura
                if (oGuia.ListaCanjeGuias.Count == 1)
                {
                    ser = oGuia.ListaCanjeGuias[0].numSerieFact;
                    ser = ser.TrimStart(new Char[] { '0' });

                    num = oGuia.ListaCanjeGuias[0].numDocumentoFact;
                    num = num.TrimStart(new Char[] { '0' });

                    oGuiaImpresion.AgregarDatos(ser + "-" + num, "2", "201");
                }
                else if (oGuia.ListaCanjeGuias.Count == 2)
                {
                    ser = oGuia.ListaCanjeGuias[0].numSerieFact;
                    ser = ser.TrimStart(new Char[] { '0' });

                    num = oGuia.ListaCanjeGuias[0].numDocumentoFact;
                    num = num.TrimStart(new Char[] { '0' });

                    oGuiaImpresion.AgregarDatos(ser + "-" + num + " ", "2", "201");

                    ser = oGuia.ListaCanjeGuias[1].numSerieFact;
                    ser = ser.TrimStart(new Char[] { '0' });

                    num = oGuia.ListaCanjeGuias[1].numDocumentoFact;
                    num = num.TrimStart(new Char[] { '0' });

                    oGuiaImpresion.AgregarDatos(" " + ser + "-" + num, "20", "201");
                }
            }

            //Imprimiendo la guia de traslado
            oGuiaImpresion.ImprimirGuia(nomImpresora);
        }
        
        private void Facturas(EmisionDocumentoE oFactura, String nomImpresora)
        {
            String Moneda = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oFactura.fecEmision);
            FacturaEnzo oFacturaImpresion = new FacturaEnzo();
            List<string> Palabras = null;
            StringBuilder CadenaDireccion = new StringBuilder();
            Int32 totLetras = 0;
            String PrimerParrafo = String.Empty;
            String SegundoParrafo = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oFactura.idMoneda
                                select x).SingleOrDefault();

            //(Dato, x, y)
            //Fecha Emisión
            //Por revisar//oFacturaImpresion.AgregarDatos(oFactura.fecEmision.Day.ToString("00"), "6", "55.8");
            //Por revisar//oFacturaImpresion.AgregarDatos(Global.PrimeraMayuscula(FechasHelper.NombreMes(oFactura.fecEmision.Month)), "24", "55.8");
            //Por revisar//oFacturaImpresion.AgregarDatos(Global.Derecha(oFactura.fecEmision.Year.ToString(), 1), "80", "55.8");

            //Razón Social
            oFacturaImpresion.AgregarDatos(oFactura.RazonSocial, "9", "65");

            //Ruc
            oFacturaImpresion.AgregarDatos(oFactura.numRuc, "125", "65");

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

                oFacturaImpresion.AgregarDatos(PrimerParrafo, "9", "69");
                oFacturaImpresion.AgregarDatos(SegundoParrafo, "9", "72");
                CadenaDireccion.Clear();
            }
            else
            {
                oFacturaImpresion.AgregarDatos(oFactura.Direccion, "9", "69");
            }

            StringBuilder CadenaGuias = new StringBuilder();
            String ser = String.Empty;
            String num = String.Empty;

            foreach (CanjeGuiasE item in oFactura.ListaCanjeGuias)
            {
                ser = item.numSerieGuia;
                ser = ser.TrimStart(new Char[] { '0' });

                num = item.numDocumentoGuia;
                num = num.TrimStart(new Char[] { '0' });

                CadenaGuias.Append(ser).Append("-").Append(num).Append(" ");
            }

            oFacturaImpresion.AgregarDatos(CadenaGuias.ToString().Trim(), "140", "72"); //NumGuia
            //oFacturaImpresion.AgregarDatos(!String.IsNullOrEmpty(oFactura.serDocumentoRef) ?
            //                                oFactura.serDocumentoRef + "-" + oFactura.numDocumentoRef : oFactura.numDocumentoRef, "140", "70"); //O.C.

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

                    oFacturaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N2") + "|"
                        + item.nomArticulo + "|" + item.Lote + "|" + Convert.ToDecimal(item.PrecioCad).ToString("N2") + "|" + item.SubTotalCad);
                }
            }

            //Número a Letras
            Moneda = " " + oMoneda.desMoneda.ToUpper();

            if (oFactura.desCondicion.Contains("TRANSFERENCIA"))
            {
                oFacturaImpresion.AgregarDatos(NumeroLetras.enLetras("0.00") + Moneda, "7", "192.7");
            }
            else
            {
                oFacturaImpresion.AgregarDatos(NumeroLetras.enLetras(oFactura.totTotal.ToString()) + Moneda, "7", "192.7");
            }

            //Montos
            String numDerecha = String.Empty;
            //Valor Venta
            numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totsubTotal.ToString("N2").Length, 8) + oFactura.totsubTotal.ToString("N2");
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "172", "198");

            //IGV
            //if (oFactura.totIgv > 0)
            //{
            //    oFacturaImpresion.AgregarDatos(oFactura.ListaItemsDocumento[0].porIgv.ToString("N2"), "149", "204.5");
            //    numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totIgv.Value.ToString("N2").Length, 8) + oFactura.totIgv.Value.ToString("N2");
            //    oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "172", "204.5");
            //}
            //else
            //{
            //    oFacturaImpresion.AgregarDatos(oFactura.ListaItemsDocumento[0].porIgv.ToString("N2"), "149", "204.5");
            //    numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totIgv.Value.ToString("N2").Length, 8) + oFactura.totIgv.Value.ToString("N2");
            //    oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "172", "204.5");
            //}

            numDerecha = oFacturaImpresion.AlinearDerecha(oFactura.totTotal.ToString("N2").Length, 8) + oFactura.totTotal.ToString("N2");
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura + "  " + numDerecha, "172", "211");

            //Imprimiendo
            oFacturaImpresion.ImprimirFactura(nomImpresora);
        }

        private void NotaDeCreditoNC(EmisionDocumentoE oNotaCredito, String nomImpresora)
        {
            NotasDeCreditoEnzo oNcImpresion = new NotasDeCreditoEnzo();
            String NombreDocumento = String.Empty;
            String Moneda = String.Empty;
            String Ruc = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oNotaCredito.idMoneda
                                select x).SingleOrDefault();

            //Cabecera
            //Por revisar//oNcImpresion.AgregarDatos(oNotaCredito.fecEmision.Day.ToString("00") + "                      " +
            //                            Global.PrimeraMayuscula(FechasHelper.NombreMes(oNotaCredito.fecEmision.Month)) + "                                            " + 
            //                            Global.Derecha(oNotaCredito.fecEmision.ToString("yyyy"), 1), "15", "47");

            oNcImpresion.AgregarDatos(oNotaCredito.RazonSocial, "23", "56");
            oNcImpresion.AgregarDatos(oNotaCredito.numRuc, "22", "64");
            oNcImpresion.AgregarDatos(oNotaCredito.Direccion, "20", "69.5");//, "68");

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

            oNcImpresion.AgregarDatos(NombreDocumento, "150", "58.5");
            oNcImpresion.AgregarDatos(oNotaCredito.serDocumentoRef + "-" + oNotaCredito.numDocumentoRef, "135", "63.5");
            oNcImpresion.AgregarDatos(oNotaCredito.fecDocumentoRef.Value.Day.ToString("00") + "             " +
                                        oNotaCredito.fecDocumentoRef.Value.ToString("MM") + "             " +
                                        oNotaCredito.fecDocumentoRef.Value.ToString("yy"), "150", "75");

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
                    oNcImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.nomArticulo + "|" + 
                                                Convert.ToDecimal(item.PrecioSinImpuesto).ToString(Formato) + "|" + 
                                                Convert.ToDecimal(item.Total).ToString("N2"), ControlDocumento.cantCaracteres);
                }
            }

            Moneda = " " + oMoneda.desMoneda.ToUpper();

            //Total en Letras
            oNcImpresion.AgregarDatos(enLetras(oNotaCredito.totTotal.ToString()) + Moneda, "15", "122"); //Español

            //Motivo
            oNcImpresion.AgregarDatos(oNotaCredito.desCondicion, "32.5", "142.6");

            //Totales
            string Numeros = String.Empty;
            Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
            oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "175", "130");

            oNcImpresion.AgregarDatos(oNotaCredito.ListaItemsDocumento[0].porIgv.ToString("N1"), "157.5", "139.5");

            Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2");
            oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "175", "139.5");
            Numeros = oNcImpresion.AlinearDerecha(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2");
            oNcImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "175", "147.3");

            //Imprimiendo
            oNcImpresion.ImprimirNC(nomImpresora);
        }

        private void NotaDeDebitoND(EmisionDocumentoE oNotaDebito, String nomImpresora)
        {
            NotasDeDebitoEnzo oNdImpresion = new NotasDeDebitoEnzo();
            String NombreDocumento = String.Empty;
            String Moneda = String.Empty;
            String Ruc = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oNotaDebito.idMoneda
                                select x).SingleOrDefault();

            //Cabecera
            //Por revisar//oNdImpresion.AgregarDatos(oNotaDebito.fecEmision.Day.ToString("00") + "                      " +
            //                            Global.PrimeraMayuscula(FechasHelper.NombreMes(oNotaDebito.fecEmision.Month)) + "                                            " +
            //                            Global.Derecha(oNotaDebito.fecEmision.ToString("yyyy"), 1), "15", "43.5");

            oNdImpresion.AgregarDatos(oNotaDebito.RazonSocial, "22", "53.8");
            oNdImpresion.AgregarDatos(oNotaDebito.numRuc, "21", "60.8");
            oNdImpresion.AgregarDatos(oNotaDebito.Direccion, "20", "67.5");//, "68");

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

            oNdImpresion.AgregarDatos(NombreDocumento, "150", "55");
            oNdImpresion.AgregarDatos(oNotaDebito.serDocumentoRef + "-" + oNotaDebito.numDocumentoRef, "135", "61");
            oNdImpresion.AgregarDatos(oNotaDebito.fecDocumentoRef.Value.Day.ToString("00") + "             " +
                                        oNotaDebito.fecDocumentoRef.Value.ToString("MM") + "             " +
                                        oNotaDebito.fecDocumentoRef.Value.ToString("yy"), "150", "72");

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
                    oNdImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.nomArticulo + "      " + item.Lote +  "|" +
                                                Convert.ToDecimal(item.PrecioSinImpuesto).ToString(Formato) + "|" +
                                                Convert.ToDecimal(item.Total).ToString("N2"), ControlDocumento.cantCaracteres);
                }
            }

            Moneda = " " + oMoneda.desMoneda.ToUpper();

            //Total en Letras
            oNdImpresion.AgregarDatos(enLetras(oNotaDebito.totTotal.ToString()) + Moneda, "15", "125.5"); //Español

            ////Motivo
            //oNdImpresion.AgregarDatos(oNotaDebito.desCondicion, "45", "138");

            //Totales
            string Numeros = String.Empty;
            Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totsubTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2");
            oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "173", "128");

            oNdImpresion.AgregarDatos(oNotaDebito.ListaItemsDocumento[0].porIgv.ToString("N1"), "157.5", "136");

            Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2");
            oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "173", "136");
            Numeros = oNdImpresion.AlinearDerecha(Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2").Length, 6) + Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2");
            oNdImpresion.AgregarDatos(oMoneda.desAbreviatura + " " + Numeros, "173", "143.5");

            //Imprimiendo
            oNdImpresion.ImprimirND(nomImpresora);
        }

        private void BoletaVenta(EmisionDocumentoE oBoleta, String nomImpresora)
        {          
            DateTime fecEmision = Convert.ToDateTime(oBoleta.fecEmision);
            BoletasEnzo oBoletaImpresion = new BoletasEnzo();
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oBoleta.idMoneda
                                select x).SingleOrDefault();
            String Anio = fecEmision.Year.ToString();

            //Cabecera (Dato, x, y)
            oBoletaImpresion.AgregarDatos(oBoleta.RazonSocial, "12", "29");
            oBoletaImpresion.AgregarDatos(fecEmision.Day.ToString("00") + "         " + Global.PrimeraMayuscula(FechasHelper.NombreMes(fecEmision.Month)) + "      " + Anio, "104", "29");

            oBoletaImpresion.AgregarDatos(oBoleta.Direccion, "12", "35");
            oBoletaImpresion.AgregarDatos(oBoleta.numRuc, "112", "35");

            ////Detalle (Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oBoleta.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    oBoletaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0")  + "|"+  item.nomArticulo + "|" + item.Lote +  "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString("N2") 
                        + "|" + (item.indCalculo == true ? Convert.ToDecimal(item.Total).ToString("N2") : "0.00"));
                }
            }

            oBoletaImpresion.AgregarDatos(oBoleta.totTotal.ToString("N2"), "125", "88");

            //Imprimiendo
            oBoletaImpresion.ImprimirBoleta(nomImpresora);
        }

        #endregion

    }
}
