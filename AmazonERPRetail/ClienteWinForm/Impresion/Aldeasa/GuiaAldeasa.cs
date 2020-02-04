using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace ClienteWinForm.Impresion.Aldeasa
{
    public class GuiaAldeasa
    {
        #region Variables

        String[,] Datos = new String[100, 5];
        String[,] Items = new String[1000, 3];
        Int32 ContadorDatos = 0;
        Int32 ContadorItems = 0;
        Int32 Contador = 1;
        Int32 posItemsY = 0;

        Font LetraImpresion = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);
        String nomLetra = "Lucida Console";
        Int32 tamLetra = 8;
        Graphics gfx = null;

        #endregion

        #region Constructor

        public GuiaAldeasa()
        {

        }

        #endregion

        #region Procedimientos Publicos

        public Boolean RevisaImpresora(String impresora)
        {
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                if (impresora == strPrinter)
                    return true;
            }

            return false;
        }

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
            Int32 cantDigitosCab = 5;

            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[0].Length, cantDigitosCab) + itemsDatos[0];
            Items[ContadorItems, 1] = "12"; // Eje x
            Items[ContadorItems, 2] = "86"; // Eje y

            // Comprobar si es mayor a la cantidad de digitos permitido de lo contrario pasar a la siguiente linea...
            DivideItemDet(itemsDatos[1].Length, 100, itemsDatos[1]);

            // Se continua almacenando...
            ContadorItems++;
        }

        public void ImprimirGuia(String Impresora)
        {
            //printFont = new Font(fontName, fontSize, FontStyle.Regular);
            PrintDocument oPrint = new PrintDocument();
            oPrint.PrinterSettings.PrinterName = Impresora;
            oPrint.DocumentName = "Impresion de Guia";
            oPrint.PrintPage += new PrintPageEventHandler(pr_PrintPage);
            oPrint.Print();
        }

        #endregion

        #region Procedimientos Privados

        private String AlinearDerecha(Int32 lenght, Int32 maxCaracteres)
        {
            String Espacios = String.Empty;
            Int32 totEspacios = maxCaracteres - lenght;

            for (Int32 x = 0; x < totEspacios; x++)
            {
                Espacios += " ";
            }

            return Espacios;
        }        

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
                Int32 PosX = Int32.Parse(Datos[i, 1].ToString());
                Int32 PosY = Int32.Parse(Datos[i, 2].ToString());
                gfx.DrawString(Datos[i, 0], LetraImpresion, myBrush, PosX, PosY, new StringFormat());
            }
        }

        private void DrawItems()
        {
            for (Int32 i = 0; i < ContadorItems; i++)
            {
                Int32 PosX = Int32.Parse(Items[i, 1]);
                Int32 PosY = Int32.Parse(Items[i, 2]);
                gfx.DrawString(Items[i, 0], LetraImpresion, myBrush, PosX, PosY + posItemsY, new StringFormat());
                
                if (Contador == 2)
                {
                    posItemsY += 3; //Se incrementa en 3 milimitros para la proxima linea(A mayor numero se aumentael espaciado)
                    Contador = 0;
                }

                Contador++;
            }
        }       

        private void DivideItemDet(Int32 lenghtDet, Int32 maxCharDet, String detalleText)
        {
            if (lenghtDet > maxCharDet)
            {
                String[] SplitDetalle = detalleText.Split(' ');
                String Linea = String.Empty;
                Int32 i = 0;
                Int32 ContadorLineas = 0;

                while (i < SplitDetalle.Length)
                {
                    while ((Linea.Length < maxCharDet) && (i < SplitDetalle.Length))
                    {
                        Linea += SplitDetalle[i] + " ";
                        i++;
                    }

                    if (ContadorLineas < 1)
                    {
                        ContadorItems++;
                        Items[ContadorItems, 0] = Linea;
                        Items[ContadorItems, 1] = "26"; // Eje x
                        Items[ContadorItems, 2] = "86"; // Eje y
                        ContadorLineas++;
                        Linea = String.Empty;
                    }
                    else
                    {
                        ContadorItems++;
                        Items[ContadorItems, 0] = "";
                        Items[ContadorItems, 1] = "26"; // Eje x
                        Items[ContadorItems, 2] = "86"; // Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = Linea;
                        Items[ContadorItems, 1] = "26"; // Eje x
                        Items[ContadorItems, 2] = "86"; // Eje y
                        
                        Linea = "";
                    }
                }
            }
            else
            {
                ContadorItems++;
                Items[ContadorItems, 0] = detalleText;
                Items[ContadorItems, 1] = "26"; //Eje x
                Items[ContadorItems, 2] = "86"; //Eje y
            }
        }

        #endregion

    }
}
