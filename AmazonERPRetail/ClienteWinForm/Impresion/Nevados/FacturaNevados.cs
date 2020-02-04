using System;
using System.Drawing;
using System.Drawing.Printing;

namespace ClienteWinForm.Impresion.Nevados
{
    class FacturaNevados
    {

        #region Constructor

        public FacturaNevados()
        {

        }

        #endregion

        #region Variables

        String[,] Datos = new String[100, 3];
        String[,] Items = new String[1000, 6];
        Int32 ContadorDatos = 0;
        Int32 ContadorItems = 0;
        Int32 Contador = 1;
        Int32 posItemsY = 0;

        Font LetraImpresion = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);
        String nomLetra = "Lucida Console";
        Int32 tamLetra = 9;
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

        public void AgregarItems(String ItemTexto, Int32 cantCaracteres)
        {
            String[] itemsDatos = ItemTexto.Split('|');
            Int32 DigItem = 5;
            Int32 DigCodArt = 10;
            Int32 DigitosCant = 6;
            Int32 DigitosPu = 6;
            Int32 DigitosImporte = 8;
            Int32 DigitosArt = cantCaracteres;

            // Item
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[0].Length, DigItem) + itemsDatos[0];
            Items[ContadorItems, 1] = "3.5"; // Eje x
            Items[ContadorItems, 2] = "75.5"; // Eje y

            //// Codigo Articulo
            ContadorItems++;
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[1].Length, DigCodArt) + itemsDatos[1];
            Items[ContadorItems, 1] = "12"; // Eje x
            Items[ContadorItems, 2] = "75.5"; // Eje y

            //// Cantidad
            ContadorItems++;
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[3].Length, DigitosCant) + itemsDatos[3];
            Items[ContadorItems, 1] = "118"; // Eje x
            Items[ContadorItems, 2] = "75.5"; // Eje y

            // Precio Unitario
            ContadorItems++;
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[4].Length, DigitosPu) + itemsDatos[4];
            Items[ContadorItems, 1] = "134.5"; // Eje x
            Items[ContadorItems, 2] = "75.5"; // Eje y

            // Subtotal
            ContadorItems++;
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[5].Length, DigitosImporte) + itemsDatos[5];
            Items[ContadorItems, 1] = "148.5";// Eje x
            Items[ContadorItems, 2] = "75.5"; // Eje y

            // Descuento
            ContadorItems++;
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[6].Length, DigitosPu) + itemsDatos[6];
            Items[ContadorItems, 1] = "167"; // Eje x
            Items[ContadorItems, 2] = "75.5"; // Eje y

            // Subtotal
            ContadorItems++;
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[7].Length, DigitosImporte) + itemsDatos[7];
            Items[ContadorItems, 1] = "184";// Eje x
            Items[ContadorItems, 2] = "75.5"; // Eje y

            // Articulo
            // Comprobar si es mayor a la cantidad de digitos permitido de lo contrario pasar a la siguiente linea...
            DivideItemDet(itemsDatos[2].Length, DigitosArt, itemsDatos[2]);
            // Continuo almacenando
            ContadorItems++;
        }

        public void ImprimirFactura(String Impresora)
        {
            //LetraImpresion = new Font(nomLetra, tamLetra, FontStyle.Regular);
            PrintDocument pr = new PrintDocument();
            pr.PrinterSettings.PrinterName = Impresora;
            pr.DocumentName = "Impresion de Factura";
            pr.PrintPage += new PrintPageEventHandler(pr_PrintPage);
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

            LetraImpresion = new Font(nomLetra, tamLetra, FontStyle.Regular);
            DrawDatos();

            LetraImpresion = new Font(nomLetra, tamLetra, FontStyle.Regular);
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

                if (Contador == 8)
                {
                    posItemsY += 4; //incremento en 4 milimitros para la proxima linea
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

                    if (ContadorLineas < 1)
                    {
                        ContadorItems++;
                        Items[ContadorItems, 0] = Linea;
                        Items[ContadorItems, 1] = "34";// Eje x
                        Items[ContadorItems, 2] = "75.5";// Eje y
                        ContadorLineas++;
                        Linea = String.Empty;
                    }
                    else
                    {
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "34";// Eje x
                        Items[ContadorItems, 2] = "75.5";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = Linea;
                        Items[ContadorItems, 1] = "34";// Eje x
                        Items[ContadorItems, 2] = "75.5";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "34";// Eje x
                        Items[ContadorItems, 2] = "75.5";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "34";// Eje x
                        Items[ContadorItems, 2] = "75.5";// Eje y

                        Linea = String.Empty;
                    }
                }
            }
            else
            {
                ContadorItems++;
                Items[ContadorItems, 0] = detalleText;
                Items[ContadorItems, 1] = "34";// Eje x
                Items[ContadorItems, 2] = "75.5";// Eje y
            }
        }

        #endregion

    }

}
