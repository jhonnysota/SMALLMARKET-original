using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteWinForm.Impresion.Enzo
{
    public class FacturaEnzo
    {
        #region Constructor

        public FacturaEnzo()
        {

        }

        #endregion

        #region Variables

        //String[,] Datos = new String[100, 3];
        //String[,] Items = new String[100, 6];
        String[,] Datos = new String[200, 3];
        String[,] Items = new String[500, 3];
        Int32 ContadorDatos = 0;
        Int32 ContadorItems = 0;
        Int32 Contador = 1;
        Int32 posItemsY = 0;

        Font LetraImpresion = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);
        //String nomLetra = "Verdana";
        //int tamLetra = 8;
        String nomLetra = String.IsNullOrWhiteSpace(VariablesLocales.oVenParametros.LetraImpresion.Trim()) ? "Lucida Console" : VariablesLocales.oVenParametros.LetraImpresion;
        Int32 tamLetra = VariablesLocales.oVenParametros.SizeLetra == 0 ? 9 : VariablesLocales.oVenParametros.SizeLetra;
        Graphics gfx = null;

        #endregion

        #region Procedimientos Publicos

        public void AgregarDatos(String datoTexto, String PosX, String PosY)
        {
            Datos[ContadorDatos, 0] = datoTexto;
            Datos[ContadorDatos, 1] = PosX;
            Datos[ContadorDatos, 2] = PosY;

            ContadorDatos++;
        }

        public void AgregarItems(String ItemTexto)
        {
            String[] itemsDatos = ItemTexto.Split('|');
            Int32 DigitosCant = 6;
            Int32 DigitosPu = 6;
            Int32 DigitosImporte = 10;
            Int32 DigitosArt = 60;

            // Cantidad
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[0].Length, DigitosCant) + itemsDatos[0];
            Items[ContadorItems, 1] = "3"; // Eje x
            Items[ContadorItems, 2] = "87"; // Eje y
            ContadorItems++;

            // Descripción del Articulo
            //Comprobando si en la descripción del articulo existe enter...
            bool EncontroEnter = (itemsDatos[1].IndexOf("\r\n") > 0);

            // Comprobar si es mayor a la cantidad de digitos permitido de lo contrario pasar a la siguiente linea...
            if (EncontroEnter)
            {
                DivideItemDetEnter(itemsDatos[1].Length, DigitosArt, itemsDatos[1]);
                ContadorItems++;
            }
            else
            {
                DivideItemDet(itemsDatos[1].Length, DigitosArt, itemsDatos[1]);
                // Continuo almacenando
                ContadorItems++;
            }


            //LOTE
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[2].Length, DigitosPu) + itemsDatos[2];
            Items[ContadorItems, 1] = "128"; // Eje x
            Items[ContadorItems, 2] = "87"; // Eje y
            ContadorItems++;

            // Precio Unitario
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[3].Length, DigitosPu) + itemsDatos[3];
            Items[ContadorItems, 1] = "150"; // Eje x
            Items[ContadorItems, 2] = "87"; // Eje y
            ContadorItems++;

            // Valor Venta
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[4].Length, DigitosImporte) + itemsDatos[4];
            Items[ContadorItems, 1] = "173";// Eje x
            Items[ContadorItems, 2] = "87"; // Eje y
            ContadorItems++;
        }

        public void ImprimirFactura(String Impresora)
        {
            PrintDocument pr = new PrintDocument();
            //PaperSize paper = new PaperSize("A4", 827, 1169);
            //PaperSize paper = new PaperSize
            //{
            //    RawKind = (int)PaperKind.A4
            //};

            PaperSize paperSize = new PaperSize("Custom", 850, 894)
            {
                RawKind = (int)PaperKind.Custom
            };

            pr.DefaultPageSettings.PaperSize = paperSize;
            pr.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            pr.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
            pr.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            //pr.OriginAtMargins = true;
            pr.PrinterSettings.PrinterName = Impresora;
            pr.DocumentName = "Impresion de Factura";
            //pr.DefaultPageSettings.PaperSize = new PaperSize("Custom", 216, 227);
            //pr.DefaultPageSettings.PaperSource.RawKind = PaperKind.Custom;
            //pr.DefaultPageSettings.PaperSize.Width = 216;
            //pr.DefaultPageSettings.PaperSize.Height = 227;
            
            pr.PrintPage += new PrintPageEventHandler(pr_PrintPage);
            //pr.OriginAtMargins = true;
            //pr.PrintController = new StandardPrintController();
            //pr.DefaultPageSettings.Margins.Left = 0;
            //pr.DefaultPageSettings.Margins.Right = 0;
            //pr.DefaultPageSettings.Margins.Top = 0;
            //pr.DefaultPageSettings.Margins.Bottom = 0;

            pr.Print();
        }

        public String AlinearDerecha(Int32 lenght, Int32 maxChar)
        {
            String espacios = "";
            Int32 spaces = maxChar - lenght;

            for (Int32 x = 0; x < spaces; x++)
            {
                espacios += " ";
            }

            return espacios;
        }

        #endregion

        #region Procedimientos Privados

        private void pr_PrintPage(Object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;

            LetraImpresion = new Font(nomLetra, tamLetra, FontStyle.Bold);
            DrawDatos();

            LetraImpresion = new Font(nomLetra, tamLetra, FontStyle.Bold);
            DrawItems();
        }

        private void DrawDatos()
        {
            for (Int32 i = 0; i < ContadorDatos; i++)
            {
                float PosX = float.Parse(Datos[i, 1].ToString());
                float PosY = float.Parse(Datos[i, 2].ToString());

                gfx.DrawString(Datos[i, 0], LetraImpresion, myBrush, PosX, PosY, new StringFormat());
            }
        }

        private void DrawItems()
        {
            for (Int32 i = 0; i < ContadorItems; i++)
            {
                float PosX = float.Parse(Items[i, 1]);
                float PosY = float.Parse(Items[i, 2]);

                gfx.DrawString(Items[i, 0], LetraImpresion, myBrush, PosX, PosY + posItemsY, new StringFormat());

                if (Contador == 5)
                {
                    posItemsY += 6; //incremento en 4 milimitros para la proxima linea
                    Contador = 0;
                }

                Contador++;
            }
        }

        private void DivideItemDet(Int32 lenghtDet, Int32 maxCharDet, String detalleText)
        {
            if (lenghtDet > maxCharDet)
            {
                String[] splitDetalle = detalleText.Split(' ');
                String Linea = String.Empty;
                Int32 i = 0;
                Int32 ContadorLineas = 0;

                while (i < splitDetalle.Length)
                {
                    while ((Linea.Length < maxCharDet) && (i < splitDetalle.Length))
                    {
                        Linea += splitDetalle[i] + " ";
                        i++;
                    }

                    if (Linea.Length > maxCharDet)
                    {
                        Linea = Linea.Replace(splitDetalle[i - 1] + " ", "");
                        i--;
                    }

                    if (ContadorLineas < 1)
                    {
                        Items[ContadorItems, 0] = Linea;
                        Items[ContadorItems, 1] = "20";// Eje x
                        Items[ContadorItems, 2] = "87";// Eje y
                        ContadorLineas++;
                        Linea = String.Empty;
                    }
                    else
                    {
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "20";// Eje x
                        Items[ContadorItems, 2] = "87";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "20";// Eje x
                        Items[ContadorItems, 2] = "87";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = Linea;
                        Items[ContadorItems, 1] = "20";// Eje x
                        Items[ContadorItems, 2] = "87";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "20";// Eje x
                        Items[ContadorItems, 2] = "87";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "20";// Eje x
                        Items[ContadorItems, 2] = "87";// Eje y

                        Linea = String.Empty;
                    }
                }
            }
            else
            {
                Items[ContadorItems, 0] = detalleText;
                Items[ContadorItems, 1] = "20";// Eje x
                Items[ContadorItems, 2] = "87";// Eje y
            }
        }

        private void DivideItemDetEnter(Int32 lenghtDet, Int32 maxCharDet, String detalleText)
        {
            List<string> listaTextoP = detalleText.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Int32 ContadorLineas = 0;

            foreach (string item in listaTextoP)
            {
                if (item.Length < maxCharDet)
                {
                    if (ContadorLineas < 1)
                    {
                        ContadorItems++;
                        Items[ContadorItems, 0] = item;
                        Items[ContadorItems, 1] = "20";// Eje x
                        Items[ContadorItems, 2] = "87";// Eje y
                        ContadorLineas++;
                    }
                    else
                    {
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty; // Codigo
                        Items[ContadorItems, 1] = "20";// Eje x
                        Items[ContadorItems, 2] = "87";// Eje y

                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty; // Cantidad
                        Items[ContadorItems, 1] = "20";// Eje x
                        Items[ContadorItems, 2] = "87";// Eje y

                        ContadorItems++;
                        Items[ContadorItems, 0] = item; // Descripcion
                        Items[ContadorItems, 1] = "20";// Eje x
                        Items[ContadorItems, 2] = "87";// Eje y

                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty; // Precio Unitario
                        Items[ContadorItems, 1] = "20";// Eje x
                        Items[ContadorItems, 2] = "87";// Eje y

                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty; // Valor Venta
                        Items[ContadorItems, 1] = "20";// Eje x
                        Items[ContadorItems, 2] = "87";// Eje y
                    }
                }
                else
                {
                    //ContadorItems++;
                    //Items[ContadorItems, 0] = String.Empty; // Codigo
                    //Items[ContadorItems, 1] = "42";// Eje x
                    //Items[ContadorItems, 2] = "82";// Eje y

                    //ContadorItems++;
                    //Items[ContadorItems, 0] = String.Empty; // Unidad de Medida
                    //Items[ContadorItems, 1] = "42";// Eje x
                    //Items[ContadorItems, 2] = "82";// Eje y

                    //ContadorItems++;
                    //Items[ContadorItems, 0] = String.Empty; // Cantidad
                    //Items[ContadorItems, 1] = "42";// Eje x
                    //Items[ContadorItems, 2] = "82";// Eje y

                    DivideItemDet(item.Length, maxCharDet, item); // Descripcion

                    //ContadorItems++;
                    //Items[ContadorItems, 0] = String.Empty; // Precio Unitario
                    //Items[ContadorItems, 1] = "42"; // Eje x
                    //Items[ContadorItems, 2] = "82"; // Eje y

                    //ContadorItems++;
                    //Items[ContadorItems, 0] = String.Empty; // SubTotal
                    //Items[ContadorItems, 1] = "42"; // Eje x
                    //Items[ContadorItems, 2] = "82"; // Eje y

                    //ContadorItems++;
                    //Items[ContadorItems, 0] = String.Empty; // Total
                    //Items[ContadorItems, 1] = "42"; // Eje x
                    //Items[ContadorItems, 2] = "82"; // Eje y

                    //ContadorItems++;
                    //Items[ContadorItems, 0] = String.Empty; // Uno mas en blanco
                    //Items[ContadorItems, 1] = "42";// Eje x
                    //Items[ContadorItems, 2] = "82";// Eje y
                    //ContadorItems++;
                }
            }
        }

        #endregion
    }
}
