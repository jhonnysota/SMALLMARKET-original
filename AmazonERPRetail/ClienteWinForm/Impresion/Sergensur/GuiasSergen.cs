﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteWinForm.Impresion.Sergensur
{
    public class GuiasSergen
    {
        #region Constructor

        public GuiasSergen()
        {

        }

        #endregion

        #region Variables
        
        String[,] Datos = new String[200, 3];
        String[,] Items = new String[500, 3];
        Int32 ContadorDatos = 0;
        Int32 ContadorItems = 0;
        Int32 Contador = 1;
        Int32 posItemsY = 0;

        Font LetraImpresion = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);
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
            Int32 DigitosArt = 60;

            // Correlativo
            Items[ContadorItems, 0] = itemsDatos[0];
            Items[ContadorItems, 1] = "9"; // Eje x
            Items[ContadorItems, 2] = "95"; // Eje y
            ContadorItems++;

            // Cantidad
            Items[ContadorItems, 0] = itemsDatos[1];
            Items[ContadorItems, 1] = "15"; // Eje x
            Items[ContadorItems, 2] = "95"; // Eje y
            ContadorItems++;

            // Descripción del Articulo
            //Comprobando si en la descripción del articulo existe enter...
            bool EncontroEnter = (itemsDatos[2].IndexOf("\r\n") > 0);

            // Comprobar si es mayor a la cantidad de digitos permitido de lo contrario pasar a la siguiente linea...
            if (EncontroEnter)
            {
                DivideItemDetEnter(itemsDatos[2].Length, DigitosArt, itemsDatos[2]);
                ContadorItems++;
            }
            else
            {
                // Comprobar si es mayor a la cantidad de digitos permitido de lo contrario pasar a la siguiente linea...
                DivideItemDet(itemsDatos[2].Length, DigitosArt, itemsDatos[2]);
                // Continuo almacenando
                ContadorItems++;
            }

            // Peso
            Items[ContadorItems, 0] = itemsDatos[3];
            Items[ContadorItems, 1] = "170";// Eje x
            Items[ContadorItems, 2] = "95"; // Eje y
            ContadorItems++;

         

            // UniMed
            Items[ContadorItems, 0] = AlinearDerecha(itemsDatos[4].Length, DigitosCant) + itemsDatos[4];
            Items[ContadorItems, 1] = "180"; // Eje x
            Items[ContadorItems, 2] = "95"; // Eje y
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
                        Items[ContadorItems, 1] = "40"; // Eje x
                        Items[ContadorItems, 2] = "95"; // Eje y
                        ContadorLineas++;
                        Linea = String.Empty;
                    }
                    else
                    {
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "40";// Eje x
                        Items[ContadorItems, 2] = "95";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "40";// Eje x
                        Items[ContadorItems, 2] = "95";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = Linea;
                        Items[ContadorItems, 1] = "40";// Eje x
                        Items[ContadorItems, 2] = "95";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "40";// Eje x
                        Items[ContadorItems, 2] = "95";// Eje y
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty;
                        Items[ContadorItems, 1] = "40";// Eje x
                        Items[ContadorItems, 2] = "95";// Eje y


                        Linea = String.Empty;
                    }
                }
            }
            else
            {
                Items[ContadorItems, 0] = detalleText;
                Items[ContadorItems, 1] = "40"; //Eje x
                Items[ContadorItems, 2] = "95"; //Eje y
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
                        Items[ContadorItems, 1] = "40";// Eje x
                        Items[ContadorItems, 2] = "95";// Eje y
                        ContadorLineas++;
                    }
                    else
                    {
                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty; // Correlativo
                        Items[ContadorItems, 1] = "40";// Eje x
                        Items[ContadorItems, 2] = "95";// Eje y

                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty; // Codigo
                        Items[ContadorItems, 1] = "40";// Eje x
                        Items[ContadorItems, 2] = "95";// Eje y

                        ContadorItems++;
                        Items[ContadorItems, 0] = item; //Descripcion
                        Items[ContadorItems, 1] = "40";// Eje x
                        Items[ContadorItems, 2] = "95";// Eje y

                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty; // Unidad de Medida
                        Items[ContadorItems, 1] = "40";// Eje x
                        Items[ContadorItems, 2] = "95";// Eje y


                        ContadorItems++;
                        Items[ContadorItems, 0] = String.Empty; // Cantidad
                        Items[ContadorItems, 1] = "40";// Eje x
                        Items[ContadorItems, 2] = "95";// Eje y


                    }
                }
                else
                {
                    ContadorItems++;
                    Items[ContadorItems, 0] = String.Empty; // Correlativo
                    Items[ContadorItems, 1] = "40";// Eje x
                    Items[ContadorItems, 2] = "95";// Eje y

                    ContadorItems++;
                    Items[ContadorItems, 0] = String.Empty; // Codigo
                    Items[ContadorItems, 1] = "40";// Eje x
                    Items[ContadorItems, 2] = "95";// Eje y

                    DivideItemDet(item.Length, maxCharDet, item); // Descripcion

                    ContadorItems++;
                    Items[ContadorItems, 0] = String.Empty; // Cantidad
                    Items[ContadorItems, 1] = "40";// Eje x
                    Items[ContadorItems, 2] = "95";// Eje y

                    ContadorItems++;
                    Items[ContadorItems, 0] = String.Empty; // Unidad de Medida
                    Items[ContadorItems, 1] = "40";// Eje x
                    Items[ContadorItems, 2] = "95";// Eje y


                    ContadorItems++;
                    Items[ContadorItems, 0] = String.Empty; // Uno mas en blanco
                    Items[ContadorItems, 1] = "40";// Eje x
                    Items[ContadorItems, 2] = "95";// Eje y
                    ContadorItems++;
                }
            }
        }

        #endregion
    }
}
