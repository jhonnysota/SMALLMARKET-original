using System;
using System.Drawing;
using System.Drawing.Printing;

namespace ClienteWinForm.Impresion.AgroGenesis
{
    public class NotasDeCreditoPower
    {

        #region Constructor

        public NotasDeCreditoPower()
        {

        }

        #endregion

        #region Variables

        String[,] Datos = new String[100, 5];
        String[,] Items = new String[1000, 4];
        Int32 ContadorDatos = 0;
        Int32 ContadorItems = 0;
        Int32 Contador = 1;
        Int32 posItemsY = 0;

        Font LetraImpresion = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);
        //String nomLetra = "Lucida Console";
        //Int32 tamLetra = 9;
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

        public void AgregarItems(String ItemTexto, Int32 cantCaracteres)
        {
            String[] itemsDatos = ItemTexto.Split('|');
            Int32 DigitosCant = 6;
            Int32 DigitosPu = 6;
            Int32 DigitosImporte = 10;
            Int32 DigitosArt = cantCaracteres;

            //Cantidad
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[0].Length, DigitosCant) + itemsDatos[0];
            Items[ContadorItems, 1] = "17"; // Eje x
            Items[ContadorItems, 2] = "93"; // Eje y
            //Precio Unitario
            ContadorItems++;
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[2].Length, DigitosPu) + itemsDatos[2];
            Items[ContadorItems, 1] = "163"; // Eje x
            Items[ContadorItems, 2] = "93"; // Eje y
            //Valor Venta
            ContadorItems++;
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[3].Length, DigitosImporte) + itemsDatos[3];
            Items[ContadorItems, 1] = "183";// Eje x
            Items[ContadorItems, 2] = "93"; // Eje y

            // Comprobar si es mayor a la cantidad de digitos permitido de lo contrario pasar a la siguiente linea...
            DivideItemDet(itemsDatos[1].Length, DigitosArt, itemsDatos[1]);
            // Continuo almacenando
            ContadorItems++;
        }

        public void ImprimirNC(String Impresora)
        {
            //printFont = new Font(fontName, fontSize, FontStyle.Regular);
            PrintDocument oPrint = new PrintDocument();
            oPrint.PrinterSettings.PrinterName = Impresora;
            oPrint.DocumentName = "Impresion de Nota de Credito";
            oPrint.PrintPage += new PrintPageEventHandler(pr_PrintPage);
            oPrint.Print();
        }

        public String AlinearDerecha(Int32 lenght, Int32 maxCaracteres)
        {
            String Espacios = String.Empty;
            Int32 totEspacios = maxCaracteres - lenght;

            for (Int32 x = 0; x < totEspacios; x++)
            {
                Espacios += " ";
            }

            return Espacios;
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

                if (Contador == 4)
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
                        Items[ContadorItems, 1] = "38";// Eje x
                        Items[ContadorItems, 2] = "93";// Eje y
                        ContadorLineas++;
                        Linea = String.Empty;
                    }
                    else
                    {
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "38";// Eje x
                        Items[ContadorItems, 2] = "93";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = Linea;
                        Items[ContadorItems, 1] = "38";// Eje x
                        Items[ContadorItems, 2] = "93";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "38";// Eje x
                        Items[ContadorItems, 2] = "93";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "38";// Eje x
                        Items[ContadorItems, 2] = "93";// Eje y

                        Linea = String.Empty;
                    }
                }
            }
            else
            {
                ContadorItems++;
                Items[ContadorItems, 0] = detalleText;
                Items[ContadorItems, 1] = "38";// Eje x
                Items[ContadorItems, 2] = "93";// Eje y
            }
        }

        #endregion

    }
}
