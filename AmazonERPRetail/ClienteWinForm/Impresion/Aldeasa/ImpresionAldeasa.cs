using System;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Impresion.Aldeasa
{
    public class ImpresionAldeasa : IImpresion
    {

        #region Variables

        public VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        public AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }

        NumControlDetE ControlDocumento = null;
        PrintDocument oImpresora = new PrintDocument();
        Font printLetra = new Font("Arial", 7);

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

        public static String enIngles(String num)
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
                Dec = " AND " + "0" + Decimales.ToString() + "/100 ";
            }
            else
            {
                Dec = " AND " + Decimales.ToString() + "/100 ";
            }

            Retorno = toEnglish(Convert.ToDouble(Entero)) + Dec;

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

        private static String toEnglish(Double Valor)
        {
            String Num2Text = String.Empty;

            Valor = Math.Truncate(Valor);

            if (Valor == 0) Num2Text = "ZERO";
            else if (Valor == 1) Num2Text = "ONE";
            else if (Valor == 2) Num2Text = "TWO";
            else if (Valor == 3) Num2Text = "THREE";
            else if (Valor == 4) Num2Text = "FOUR";
            else if (Valor == 5) Num2Text = "FIVE";
            else if (Valor == 6) Num2Text = "SIX";
            else if (Valor == 7) Num2Text = "SEVEN";
            else if (Valor == 8) Num2Text = "EIGHT";
            else if (Valor == 9) Num2Text = "NINE";
            else if (Valor == 10) Num2Text = "TEN";
            else if (Valor == 11) Num2Text = "ELEVEN";
            else if (Valor == 12) Num2Text = "TWELVE";
            else if (Valor == 13) Num2Text = "THIRTEEN";
            else if (Valor == 14) Num2Text = "FOURTEEN";
            else if (Valor == 15) Num2Text = "FIFTEEN";
            else if (Valor == 16) Num2Text = "SIXTEEN";
            else if (Valor == 17) Num2Text = "SEVENTEEN";
            else if (Valor == 18) Num2Text = "EIGHTEEN";
            else if (Valor == 19) Num2Text = "NINETEEN";
            else if (Valor == 20) Num2Text = "TWENTY";
            else if (Valor == 30) Num2Text = "THIRTY";
            else if (Valor == 40) Num2Text = "FORTY";
            else if (Valor == 50) Num2Text = "FIFTY";
            else if (Valor == 60) Num2Text = "SIXTY";
            else if (Valor == 70) Num2Text = "SEVENTY";
            else if (Valor == 80) Num2Text = "EIGHTY";
            else if (Valor == 90) Num2Text = "NINETY";
            else if (Valor < 100) Num2Text = toEnglish(Math.Truncate(Valor / 10) * 10) + " " + toEnglish(Valor % 10);
            else if (Valor == 100) Num2Text = "HUNDRED";
            else if (Valor < 200) Num2Text = "HUNDRED " + toEnglish(Valor - 100);
            else if ((Valor == 200) || (Valor == 300) || (Valor == 400) || (Valor == 600) || (Valor == 800)) Num2Text = toEnglish(Math.Truncate(Valor / 100)) + " HUNDRED";
            else if (Valor == 500) Num2Text = "FIVE HUNDRED";
            else if (Valor == 700) Num2Text = "SEVEN HUNDRED";
            else if (Valor == 900) Num2Text = "NINE HUNDRED";
            else if (Valor < 1000) Num2Text = toEnglish(Math.Truncate(Valor / 100) * 100) + " " + toEnglish(Valor % 100);
            else if (Valor == 1000) Num2Text = "ONE THOUSAND";
            else if (Valor < 2000) Num2Text = "TWO THOUSAND " + toEnglish(Valor % 1000);

            else if (Valor < 1000000)
            {
                Num2Text = toEnglish(Math.Truncate(Valor / 1000)) + " THOUSAND";
                if ((Valor % 1000) > 0) Num2Text = Num2Text + " " + toEnglish(Valor % 1000);
            }

            else if (Valor == 1000000) Num2Text = "ONE MILLION";
            else if (Valor < 2000000) Num2Text = "ONE MILLION " + toEnglish(Valor % 1000000);
            else if (Valor < 1000000000000)
            {
                Num2Text = toEnglish(Math.Truncate(Valor / 1000000)) + " MILLIONS ";
                if ((Valor - Math.Truncate(Valor / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toEnglish(Valor - Math.Truncate(Valor / 1000000) * 1000000);
            }

            else if (Valor == 1000000000000) Num2Text = "ONE BILLION";
            else if (Valor < 2000000000000) Num2Text = "ONE BILLION " + toEnglish(Valor - Math.Truncate(Valor / 1000000000000) * 1000000000000);
            else
            {
                Num2Text = toEnglish(Math.Truncate(Valor / 1000000000000)) + " BILLIONS";
                if ((Valor - Math.Truncate(Valor / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toEnglish(Valor - Math.Truncate(Valor / 1000000000000) * 1000000000000);
            }

            return Num2Text;
        }

        private static String ObtenerMes(string mes)
        {
            switch (mes)
            {
                case "01": //Fundo San Miguel
                    return "ENERO";
                case "02":
                    return "FEBRERO";
                case "03":
                    return "MARZO";
                case "04":
                    return "ABRIL";
                case "05":
                    return "MAYO";
                case "06":
                    return "JUNIO";
                case "07":
                    return "JULIO";
                case "08":
                    return "AGOSTO";
                case "09":
                    return "SETIEMBRE";
                case "10":
                    return "OCTUBRE";
                case "11":
                    return "NOVIENBRE";
                default:
                    return "DICIEMBRE";
            }
        }

        #endregion

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
                            //ImpresionGuiaTraslado(DocumentoEmision, RutaImpresion);
                            break;
                        case (Int32)EnumTipoImpresionGuiaRemision.EXPORTACION:
                            GuiaExportacion(DocumentoEmision, RutaImpresion);
                            break;
                        case (Int32)EnumTipoImpresionGuiaRemision.TRASLADO:
                            GuiaTraslado(DocumentoEmision, RutaImpresion);
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
                    FacturaExportacion(DocumentoEmision, RutaImpresion);
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
                        //    case (Int32)EnumTipoImpresionGuiaRemision.TRASLADO:
                        //        GuiaTraslado(DocumentoEmision, RutaImpresion);
                        //        break;
                        case "NV":
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



        private void GuiaTraslado(EmisionDocumentoE oGuia, String nomImpresora)
        {
            GuiaAldeasa oGuiaImpresion = new GuiaAldeasa();
            DateTime fecTraslado = Convert.ToDateTime(oGuia.fecTraslado);
            DateTime fecDocumentoRef = Convert.ToDateTime(oGuia.fecDocumentoRef);

            //Cabecera
            oGuiaImpresion.AgregarDatos(Convert.ToDateTime(oGuia.fecTraslado).ToString("dd/MM/yyyy"), "170", "56");
            oGuiaImpresion.AgregarDatos(oGuia.PuntoPartida, "35", "66");
            oGuiaImpresion.AgregarDatos(oGuia.PuntoLlegada, "35", "72");

            //Detalle(Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oGuia.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    oGuiaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.nomArticulo);
                }
            }

            //Motivo de Traslado
            oGuiaImpresion.AgregarDatos("X", "111", "233");

            //Transportista (Lado Izquierdo)
            oGuiaImpresion.AgregarDatos(oGuia.RazonSocialTransp, "23", "249");
            oGuiaImpresion.AgregarDatos(oGuia.DireccionTransp, "23", "252");
            oGuiaImpresion.AgregarDatos(oGuia.RucTransp, "23", "255");
            oGuiaImpresion.AgregarDatos(oGuia.inscripTransp, "38", "258");
            //Transportista (Lado Derecho)
            oGuiaImpresion.AgregarDatos(oGuia.MarcaTransp + " " + oGuia.PlacaTransp, "156", "246");
            oGuiaImpresion.AgregarDatos(oGuia.PlacaRemolqueTransp, "157", "249");
            oGuiaImpresion.AgregarDatos(oGuia.LicenciaTransp, "157", "255");
            oGuiaImpresion.AgregarDatos(oGuia.ConductorTransp, "146", "258");

            //Imprimiendo la guia de traslado
            oGuiaImpresion.ImprimirGuia(nomImpresora);
        }

        private void GuiaExportacion(EmisionDocumentoE oGuia, String nomImpresora)
        {
            GuiaAldeasa oGuiaImpresion = new GuiaAldeasa();
            DateTime fecTraslado = Convert.ToDateTime(oGuia.fecTraslado);
            //DateTime fecDocumentoRef = Convert.ToDateTime(oGuia.fecDocumentoRef);

            //Cabecera
            oGuiaImpresion.AgregarDatos(oGuia.RazonSocial, "50", "56");
            oGuiaImpresion.AgregarDatos(oGuia.numRuc, "50", "60");
            oGuiaImpresion.AgregarDatos(Convert.ToDateTime(oGuia.fecTraslado).ToString("dd/MM/yyyy"), "170", "56");
            oGuiaImpresion.AgregarDatos(oGuia.PuntoPartida, "35", "66");
            oGuiaImpresion.AgregarDatos(oGuia.PuntoLlegada, "35", "72");

            //Detalle(Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oGuia.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    oGuiaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.nomArticulo);
                }
            }

            //Glosa
            oGuiaImpresion.AgregarDatos(oGuia.Glosa, "31", "185");

            //Motivo de Traslado
            oGuiaImpresion.AgregarDatos("X", "140", "225");

            //Transportista (Lado Izquierdo)
            oGuiaImpresion.AgregarDatos(oGuia.RazonSocialTransp, "23", "249");
            oGuiaImpresion.AgregarDatos(oGuia.DireccionTransp, "23", "252");
            oGuiaImpresion.AgregarDatos(oGuia.RucTransp, "23", "255");
            oGuiaImpresion.AgregarDatos(oGuia.inscripTransp, "38", "258");
            //Transportista (Lado Derecho)
            oGuiaImpresion.AgregarDatos(oGuia.MarcaTransp + " " + oGuia.PlacaTransp, "156", "246");
            oGuiaImpresion.AgregarDatos(oGuia.PlacaRemolqueTransp, "157", "249");
            oGuiaImpresion.AgregarDatos(oGuia.LicenciaTransp, "157", "255");
            oGuiaImpresion.AgregarDatos(oGuia.ConductorTransp, "146", "258");

            //Imprimiendo la guia de traslado
            oGuiaImpresion.ImprimirGuia(nomImpresora);
        }
        
        private void FacturaExportacion(EmisionDocumentoE oFactura, String nomImpresora)
        {
            String Moneda = String.Empty;
            String MonedaIngles = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oFactura.fecEmision);
            FacturaAldeasa oFacturaImpresion = new FacturaAldeasa();
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oFactura.idMoneda
                                select x).SingleOrDefault();

            //Cabecera (Dato, x, y)
            oFacturaImpresion.AgregarDatos(fecEmision.ToString("dd"), "24", "49");

            oFacturaImpresion.AgregarDatos(ObtenerMes(fecEmision.ToString("MM")), "51", "49");
            oFacturaImpresion.AgregarDatos(fecEmision.ToString("yy"), "86", "49");
            oFacturaImpresion.AgregarDatos(oFactura.RazonSocial, "29", "55");

            String dir1 = String.Empty;
            String dir2 = String.Empty;

            if (oFactura.Direccion.Length >= 53)
            {
                dir1 = oFactura.Direccion.Trim().Substring(0, 53);
                dir2 = oFactura.Direccion.Substring(dir1.Length);

                oFacturaImpresion.AgregarDatos(dir1, "29", "59");
                oFacturaImpresion.AgregarDatos(dir2, "29", "62");
            }
            else
            {
                oFacturaImpresion.AgregarDatos(oFactura.Direccion, "29", "61");
            }

            foreach (EmisionDocumentoDetE item in oFactura.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    oFacturaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString("N2") + "|" + Convert.ToDecimal(item.Total).ToString("N2"));
                }
            }

            //Glosa
            oFacturaImpresion.AgregarDatos(oFactura.Glosa, "31", "180");
            Moneda = " " + oMoneda.desMoneda.ToUpper();
            MonedaIngles = " US DOLLARS";

            //if (Convert.ToInt32(oFactura.idMoneda) == (Int32)EnumTipoMoneda.Soles)
            //{
            //    Moneda = " SOLES";
            //}
            //else if (Convert.ToInt32(oFactura.idMoneda) == (Int32)EnumTipoMoneda.Dolares)
            //{
            //    Moneda = " DOLARES AMERICANOS";
            //    MonedaIngles = " US DOLLARS";
            //}
            //else
            //{
            //    Moneda = " EUROS";
            //}

            //Total en Letras
            oFacturaImpresion.AgregarDatos("TOTAL: " + enIngles(oFactura.totTotal.ToString()) + MonedaIngles, "31", "240"); //Ingles
            oFacturaImpresion.AgregarDatos("TOTAL: " + enLetras(oFactura.totTotal.ToString()) + Moneda, "31", "248"); //Español

            //Totales
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura, "165", "258");
            oFacturaImpresion.AgregarDatos(Convert.ToDecimal(oFactura.totTotal).ToString("N2"), "176", "258");

            if (oFactura.totIgv != 0)
            {
                oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura, "165", "264");
                oFacturaImpresion.AgregarDatos(Convert.ToDecimal(oFactura.totIgv).ToString("N2"), "176", "264");
            }
            oFacturaImpresion.AgregarDatos(oMoneda.desAbreviatura, "165", "270");
            oFacturaImpresion.AgregarDatos(Convert.ToDecimal(oFactura.totTotal).ToString("N2"), "176", "270");

            //Imprimiendo
            oFacturaImpresion.ImprimirFactura(nomImpresora);
        }

        private void BoletaVenta(EmisionDocumentoE oBoleta, String nomImpresora)
        {
            String Moneda = String.Empty;
            String MonedaIngles = String.Empty;
            DateTime fecEmision = Convert.ToDateTime(oBoleta.fecEmision);
            BoletaAldeasa oBoletaImpresion = new BoletaAldeasa();
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oBoleta.idMoneda
                                select x).SingleOrDefault();

            //Cabecera (Dato, x, y)
            oBoletaImpresion.AgregarDatos(fecEmision.ToString("dd"), "24", "49");
            oBoletaImpresion.AgregarDatos(ObtenerMes(fecEmision.ToString("MM")), "51", "49");
            oBoletaImpresion.AgregarDatos(fecEmision.ToString("yy"), "86", "49");
            oBoletaImpresion.AgregarDatos(oBoleta.RazonSocial, "29", "55");

            String dir1 = String.Empty;
            String dir2 = String.Empty;

            if (oBoleta.Direccion.Length >= 53)
            {
                dir1 = oBoleta.Direccion.Trim().Substring(0, 53);
                dir2 = oBoleta.Direccion.Substring(dir1.Length);

                oBoletaImpresion.AgregarDatos(dir1, "29", "59");
                oBoletaImpresion.AgregarDatos(dir2, "29", "62");
            }
            else
            {
                oBoletaImpresion.AgregarDatos(oBoleta.Direccion, "29", "61");
            }


            //Detalle (Separarlo por Palotes)
            foreach (EmisionDocumentoDetE item in oBoleta.ListaItemsDocumento)
            {
                if (item.Cantidad > 0 && item.nomArticulo != null)
                {
                    oBoletaImpresion.AgregarItems(Convert.ToInt32(item.Cantidad).ToString("N0") + "|" + item.nomArticulo + "|" + Convert.ToDecimal(item.PrecioSinImpuesto).ToString("N2") + "|" + Convert.ToDecimal(item.Total).ToString("N2"));
                }
            }

            //Glosa
            oBoletaImpresion.AgregarDatos(oBoleta.Glosa, "31", "180");
            Moneda = " " + oMoneda.desMoneda.ToUpper();
            MonedaIngles = " US DOLLARS";

            //if (Convert.ToInt32(oBoleta.idMoneda) == (Int32)EnumTipoMoneda.Soles)
            //{
            //    Moneda = " SOLES";
            //}
            //else if (Convert.ToInt32(oBoleta.idMoneda) == (Int32)EnumTipoMoneda.Dolares)
            //{
            //    Moneda = " DOLARES AMERICANOS";
            //    MonedaIngles = " US DOLLARS";
            //}
            //else
            //{
            //    Moneda = " EUROS";
            //}

            //Total en Letras
            oBoletaImpresion.AgregarDatos("TOTAL: " + enIngles(oBoleta.totTotal.ToString()) + MonedaIngles, "31", "240"); //Ingles
            oBoletaImpresion.AgregarDatos("TOTAL: " + enLetras(oBoleta.totTotal.ToString()) + Moneda, "31", "248"); //Español

            //Totales
            oBoletaImpresion.AgregarDatos(oMoneda.desAbreviatura, "165", "258");
            oBoletaImpresion.AgregarDatos(Convert.ToDecimal(oBoleta.totTotal).ToString("N2"), "176", "258");

            if (oBoleta.totIgv != 0)
            {
                oBoletaImpresion.AgregarDatos(oMoneda.desAbreviatura, "165", "264");
                oBoletaImpresion.AgregarDatos(Convert.ToDecimal(oBoleta.totIgv).ToString("N2"), "176", "264");
            }

            oBoletaImpresion.AgregarDatos(oMoneda.desAbreviatura, "165", "270");
            oBoletaImpresion.AgregarDatos(Convert.ToDecimal(oBoleta.totTotal).ToString("N2"), "176", "270");
            
            //Imprimiendo
            oBoletaImpresion.ImprimirBoleta(nomImpresora);
        }

        private void NotaDeCreditoNC(EmisionDocumentoE oNotaCredito, String nomImpresora)
        {
            NotaDeCreditoAldeasa oNcImpresion = new NotaDeCreditoAldeasa();
            String NombreDocumento = String.Empty;
            String Moneda = String.Empty;
            String MonedaIngles = String.Empty;
            String Ruc = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oNotaCredito.idMoneda
                                select x).SingleOrDefault();

            //Cabecera
            oNcImpresion.AgregarDatos(Convert.ToDateTime(oNotaCredito.fecEmision).ToString("dd/MM/yyyy"), "150", "55");

            if (oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.FE.ToString() || oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.FS.ToString() ||
                oNotaCredito.idDocumentoRef == EnumTipoDocumentoVenta.FV.ToString())
            {
                NombreDocumento = "Factura";

                if (oNotaCredito.idDocumentoRef != EnumTipoDocumentoVenta.FE.ToString())
                {
                    Ruc = oNotaCredito.numRuc;
                }
            }

            oNcImpresion.AgregarDatos(NombreDocumento, "40", "60");
            oNcImpresion.AgregarDatos(oNotaCredito.serDocumentoRef + "-" + oNotaCredito.numDocumentoRef, "90", "60");
            oNcImpresion.AgregarDatos(Convert.ToDateTime(oNotaCredito.fecDocumentoRef).ToString("dd/MM/yyyy"), "150", "60");

            oNcImpresion.AgregarDatos(oNotaCredito.RazonSocial, "40", "70");
            oNcImpresion.AgregarDatos(Ruc, "150", "70");

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
            MonedaIngles = " US DOLLARS";

            //if (Convert.ToInt32(oNotaCredito.idMoneda) == (Int32)EnumTipoMoneda.Soles)
            //{
            //    Moneda = " SOLES";
            //}
            //else if (Convert.ToInt32(oNotaCredito.idMoneda) == (Int32)EnumTipoMoneda.Dolares)
            //{
            //    Moneda = " DOLARES AMERICANOS";
            //    MonedaIngles = " US DOLLARS";
            //}
            //else
            //{
            //    Moneda = " EUROS";
            //}

            //Total en Letras
            oNcImpresion.AgregarDatos("Son: " + enIngles(oNotaCredito.totTotal.ToString()) + MonedaIngles, "28", "128"); //Ingles
            oNcImpresion.AgregarDatos(enLetras(oNotaCredito.totTotal.ToString()) + Moneda, "37", "131"); //Español

            //Motivo
            oNcImpresion.AgregarDatos(oNotaCredito.desCondicion, "62", "140");

            if (!String.IsNullOrEmpty(oNotaCredito.Glosa))
            {
                oNcImpresion.AgregarDatos(oNotaCredito.Glosa, "50", "145");
            }

            //Totales
            oNcImpresion.AgregarDatos(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2"), "177", "139");

            if (oNotaCredito.totIgv != 0)
            {
                oNcImpresion.AgregarDatos(Convert.ToDecimal(oNotaCredito.totIgv).ToString("N2"), "177", "145");
            }

            oNcImpresion.AgregarDatos(oNotaCredito.desMoneda, "160", "150");
            oNcImpresion.AgregarDatos(Convert.ToDecimal(oNotaCredito.totTotal).ToString("N2"), "177", "150");

            //Imprimiendo
            oNcImpresion.ImprimirNC(nomImpresora);
        }

        private void NotaDeDebitoND(EmisionDocumentoE oNotaDebito, String nomImpresora)
        {
            NotaDeDebitoAldeasa oNdImpresion = new NotaDeDebitoAldeasa();
            String NombreDocumento = String.Empty;
            String Moneda = String.Empty;
            String MonedaIngles = String.Empty;
            String Ruc = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == oNotaDebito.idMoneda
                                select x).SingleOrDefault();

            //Cabecera
            oNdImpresion.AgregarDatos(Convert.ToDateTime(oNotaDebito.fecEmision).ToString("dd/MM/yyyy"), "150", "55");

            if (oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FE.ToString() || oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FS.ToString() ||
                oNotaDebito.idDocumentoRef == EnumTipoDocumentoVenta.FV.ToString())
            {
                NombreDocumento = "Factura";

                if (oNotaDebito.idDocumentoRef != EnumTipoDocumentoVenta.FE.ToString())
                {
                    Ruc = oNotaDebito.numRuc;
                }
            }

            oNdImpresion.AgregarDatos(NombreDocumento, "40", "60");
            oNdImpresion.AgregarDatos(oNotaDebito.serDocumentoRef + "-" + oNotaDebito.numDocumentoRef, "90", "60");
            oNdImpresion.AgregarDatos(Convert.ToDateTime(oNotaDebito.fecDocumentoRef).ToString("dd/MM/yyyy"), "150", "60");

            oNdImpresion.AgregarDatos(oNotaDebito.RazonSocial, "40", "70");
            oNdImpresion.AgregarDatos(Ruc, "150", "70");

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
            MonedaIngles = " US DOLLARS";

            //if (Convert.ToInt32(oNotaDebito.idMoneda) == (Int32)EnumTipoMoneda.Soles)
            //{
            //    Moneda = " SOLES";
            //}
            //else if (Convert.ToInt32(oNotaDebito.idMoneda) == (Int32)EnumTipoMoneda.Dolares)
            //{
            //    Moneda = " DOLARES AMERICANOS";
            //    MonedaIngles = " US DOLLARS";
            //}
            //else
            //{
            //    Moneda = " EUROS";
            //}

            //Total en Letras
            oNdImpresion.AgregarDatos("Son: " + enIngles(oNotaDebito.totTotal.ToString()) + MonedaIngles, "28", "128"); //Ingles
            oNdImpresion.AgregarDatos(enLetras(oNotaDebito.totTotal.ToString()) + Moneda, "37", "131"); //Español

            //Motivo
            oNdImpresion.AgregarDatos(oNotaDebito.desCondicion, "62", "140");

            if (!String.IsNullOrEmpty(oNotaDebito.Glosa))
            {
                oNdImpresion.AgregarDatos(oNotaDebito.Glosa, "50", "145");
            }

            //Totales
            //oNcImpresion.AgregarDatos(oNotaCredito.desMoneda, "165", "120");
            oNdImpresion.AgregarDatos(Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2"), "177", "139");
            if (oNotaDebito.totIgv != 0)
            {
                //                oNcImpresion.AgregarDatos(oNotaCredito.desMoneda, "160", "120");
                oNdImpresion.AgregarDatos(Convert.ToDecimal(oNotaDebito.totIgv).ToString("N2"), "177", "145");
            }
            oNdImpresion.AgregarDatos(oNotaDebito.desMoneda, "160", "150");
            oNdImpresion.AgregarDatos(Convert.ToDecimal(oNotaDebito.totTotal).ToString("N2"), "177", "150");

            //Imprimiendo
            oNdImpresion.ImprimirND(nomImpresora);
        }

    }
}
