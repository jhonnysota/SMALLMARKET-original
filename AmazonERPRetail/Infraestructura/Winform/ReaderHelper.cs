using System;
using System.IO;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using iTextSharp.text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Infraestructura.Winform
{
    public static class ReaderHelper
    {

        public static String RevisarLogo(String RutaImagen, System.Drawing.Image img)
        {
            if (!File.Exists(RutaImagen))
            {
                System.Drawing.Image imagenTmp = img;//ClienteWinForm.Properties.Resources.interrogacion;
                Byte[] Contenido = null;

                using (MemoryStream oMs = new MemoryStream())
                {
                    imagenTmp.Save(oMs, imagenTmp.RawFormat);
                    Contenido = oMs.GetBuffer();
                }

                RutaImagen = @"C:\ERPIndusoft\Logo";

                if (!Directory.Exists(RutaImagen))
                {
                    Directory.CreateDirectory(RutaImagen);
                }

                RutaImagen += "\\interrogacion.png";

                if (!File.Exists(RutaImagen))
                {
                    File.WriteAllBytes(RutaImagen, Contenido);
                }
            }

            return RutaImagen;
        }

        public static PdfContentByte DibujarLinea(PdfWriter oPdfw, float x1, float y1, float x2, float y2, BaseColor color)
        {
            PdfContentByte contentByte = oPdfw.DirectContent;

            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();

            return contentByte;
        }

        public static float[] ObtenerAnchoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];

            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }

            return values;
        }

        public static PdfPCell ImagenCell(String path, float Escala = 80, int Alineacion = Element.ALIGN_CENTER, String Bordes = "S", float GrosorLinea = 0.5f, float Espacios = 2f)
        {
            PdfPCell cell = null;

            if (!String.IsNullOrEmpty(path))
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(path);
                //image.ScalePercent(Escala);

                //image.SetAbsolutePosition(500, 10); //Posicion en el eje carteciano de X y Y
                //image.ScaleAbsolute(90, 80);//Ancho y altura de la imagen

                //image.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                image.Alignment = Alineacion;//Element.ALIGN_CENTER;
                
                //Tamaño de Imagen
                if (image.Height > image.Width)
                {
                    float percentage = 0.0f;
                    percentage = Escala / image.Height;
                    image.ScalePercent(percentage * 100);
                }
                else
                {
                    float percentage = 0.0f;
                    percentage = Escala / image.Width;
                    image.ScalePercent(percentage * 100);
                }

                //image.ScaleToFit(120f, 65f);
                //image.IndentationLeft = 9f;
                //image.SpacingAfter = 100f;
                cell = new PdfPCell(image);

                if (Bordes == Variables.SI)
                {
                    cell.BorderWidth = GrosorLinea;
                    cell.BorderColor = BaseColor.BLACK;    
                }
                else
                {
                    cell.BorderWidth = 0;
                }
                
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //cell.PaddingLeft = 2f;
                //cell.PaddingTop = 2f;
                //cell.PaddingBottom = 2f; 
                cell.Padding = Espacios;
            }

            return cell;
        }

        public static PdfPCell ImagenCellPorcentaje(System.Drawing.Image oImg, int TipoFormat, float padding = 2f, String ConEscala = "N",  float Escala = 80, Int32 AlineacionVertical = 1, Int32 AlineacionHorizontal = 1, String Bordes = "N", float GrosorLinea = 0.5f, BaseColor ColorLinea = null)
        {
            PdfPCell cell = null;

            if (oImg != null)
            {
                //Formato de la Imagen System.Drawing
                ImageFormat Format = null;

                if (TipoFormat == 1)
                {
                    Format = ImageFormat.Png;
                }
                else if (TipoFormat == 2)
                {
                    Format = ImageFormat.Jpeg;
                }
                else if (TipoFormat == 3)
                {
                    Format = ImageFormat.Gif;
                }
                else
                {
                    Format = ImageFormat.Bmp;
                }

                //Pasando de Syste.Drawing a iTextSharp.text.Image
                iTextSharp.text.Image imgPdf = iTextSharp.text.Image.GetInstance(oImg, Format);

                if (ConEscala == Variables.SI)
                {
                    //Tamaño de Imagen
                    if (imgPdf.Height > imgPdf.Width)
                    {
                        float percentage = 0.0f;
                        percentage = Escala / imgPdf.Height;
                        imgPdf.ScalePercent(percentage * 100);
                    }
                    else
                    {
                        float percentage = 0.0f;
                        percentage = Escala / imgPdf.Width;
                        imgPdf.ScalePercent(percentage * 100);
                    }
                }

                //Añadiendo la imagen a la celda
                cell = new PdfPCell(imgPdf);

                //Formateando la celda
                if (Bordes == Variables.SI)
                {
                    cell.BorderWidth = GrosorLinea;
                    cell.BorderColor = ColorLinea;
                }
                else
                {
                    cell.BorderWidth = 0;
                }

                cell.HorizontalAlignment = AlineacionHorizontal;
                cell.VerticalAlignment = AlineacionVertical;
                cell.Padding = padding;

                //Para la Imagen
                //imgPdf.Border = iTextSharp.text.Rectangle.BOX;
                //imgPdf.BorderColor = iTextSharp.text.BaseColor.BLACK;
                //imgPdf.BorderWidth = 3f;
            }

            return cell;
        }

        public static PdfPCell ImagenCellAbosoluta(System.Drawing.Image oImg, int TipoFormat, float padding = 2f, float AnchoEscala = 178f, float AltoEscala = 45f, Int32 AlineacionVertical = 1, Int32 AlineacionHorizontal = 1, String Bordes = "N", float GrosorLinea = 0.5f, BaseColor ColorLinea = null)
        {
            PdfPCell cell = null;

            if (oImg != null)
            {
                //Formato de la Imagen System.Drawing
                ImageFormat Format = null;

                if (TipoFormat == 1)
                {
                    Format = ImageFormat.Png;
                }
                else if (TipoFormat == 2)
                {
                    Format = ImageFormat.Jpeg;
                }
                else if (TipoFormat == 3)
                {
                    Format = ImageFormat.Gif;
                }
                else
                {
                    Format = ImageFormat.Bmp;
                }

                //Pasando de Syste.Drawing a iTextSharp.text.Image
                iTextSharp.text.Image imgPdf = iTextSharp.text.Image.GetInstance(oImg, Format);
                ////Tamaño de Imagen
                imgPdf.ScaleAbsolute(AnchoEscala, AltoEscala);

                //Añadiendo la imagen a la celda
                cell = new PdfPCell(imgPdf);

                //Formateando la celda
                if (Bordes == Variables.SI)
                {
                    cell.BorderWidth = GrosorLinea;
                    cell.BorderColor = ColorLinea;
                }
                else
                {
                    cell.BorderWidth = 0;
                }

                cell.HorizontalAlignment = AlineacionHorizontal;
                cell.VerticalAlignment = AlineacionVertical;
                cell.Padding = padding;
            }

            return cell;
        }

        public static PdfPCell PhraseCell(Phrase phrase, int AlineacionVertical = -1, int AlineacionHorizontal = -1, String Bordes = "S", float paddingB = 2f, float paddingT = 40f, float Borde = 0.5f)
        {
            PdfPCell cell = new PdfPCell(phrase);

            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = AlineacionVertical;
            cell.HorizontalAlignment = AlineacionHorizontal;

            if (Bordes == Variables.SI)
	        {
		        cell.BorderWidth = Borde;
                cell.BorderColor = BaseColor.BLACK;
	        }

            cell.PaddingBottom = paddingB;
            cell.PaddingTop = paddingT;
            //cell.PaddingLeft = 125f;

            return cell;
        }

        public static PdfPCell NuevaCelda(String Titulo, BaseColor ColorFondo, String Lineas, BaseColor ColorLinea, iTextSharp.text.Font FuenteEstandar, Int32 AlineacionVertical = -1, 
            Int32 AlineacionHorizontal = -1, String colspan = "N", String rowspan = "N", float paddingB = 2f, float paddingT = 2f, String TopLine = "S", String BottomLine = "S", 
            String RightLine = "S", String LeftLine = "S", float GrosorLinea = 0.5f)
        {
            PdfPCell Celda = null;

            Celda = new PdfPCell(new Paragraph(Titulo, FuenteEstandar));
            
            if (colspan.Substring(0, 1) == "S")
	        {
                Celda.Colspan = Convert.ToInt32(colspan.Substring(1, colspan.Length - 1));
	        }

            if (rowspan.Substring(0, 1) == "S")
	        {
                Celda.Rowspan = Convert.ToInt32(rowspan.Substring(1, rowspan.Length - 1));
	        }
            
            Celda.VerticalAlignment = AlineacionVertical;
            Celda.HorizontalAlignment = AlineacionHorizontal;
            Celda.BackgroundColor = ColorFondo;

            if (Lineas == Variables.SI)
            {
                Celda.BorderColor = ColorLinea;
                Celda.BorderWidth = GrosorLinea;
                Celda.Border = 15;

                if (TopLine == Variables.NO)
                {
                    Celda.DisableBorderSide(iTextSharp.text.Rectangle.TOP_BORDER);    
                }

                if (BottomLine == Variables.NO)
                {
                    Celda.DisableBorderSide(iTextSharp.text.Rectangle.BOTTOM_BORDER);    
                }

                if (RightLine == Variables.NO)
                {
                    Celda.DisableBorderSide(iTextSharp.text.Rectangle.RIGHT_BORDER);    
                }

                if (LeftLine == Variables.NO)
                {
                    Celda.DisableBorderSide(iTextSharp.text.Rectangle.LEFT_BORDER);    
                }
            }
            else
            {
                Celda.Border = 0;
            }

            Celda.PaddingBottom = paddingB;
            Celda.PaddingTop = paddingT;

            return Celda;
        }

        #region Code 128

        public enum TiposCode128
        {
            CODE128 = Barcode.CODE128,
            CODE128_RAW = Barcode.CODE128_RAW,
            CODE128_UCC = Barcode.CODE128_UCC
        }

        public static System.Drawing.Image Code128(string _code, int codeType = (int)TiposCode128.CODE128, bool PrintTextInCode = false, float Height = 0, bool GenerateChecksum = true, bool ChecksumText = true)
        {
            if (string.IsNullOrEmpty(_code.Trim()))
            {
                return null;
            }
            else
            {
                Barcode128 barcode = new Barcode128();

                barcode.CodeType = codeType;
                barcode.StartStopText = true;
                barcode.GenerateChecksum = GenerateChecksum;
                barcode.ChecksumText = ChecksumText;

                if (Height != 0)
                {
                    barcode.BarHeight = Height;
                    barcode.Code = _code;
                }

                try
                {
                    Bitmap bm = new Bitmap(barcode.CreateDrawingImage(Color.Black, Color.White));

                    if (PrintTextInCode == false)
                    {
                        return bm;
                    }
                    else
                    {
                        System.Drawing.Image bmT = default(System.Drawing.Image);
                        bmT = new Bitmap(bm.Width, bm.Height + 14);
                        Graphics g = Graphics.FromImage(bmT);
                        g.FillRectangle(new SolidBrush(Color.White), 0, 0, bm.Width, bm.Height + 14);

                        System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 8);
                        SolidBrush drawBrush = new SolidBrush(Color.Black);

                        SizeF stringSize = new SizeF();
                        stringSize = g.MeasureString(_code, drawFont);
                        float xCenter = (bm.Width - stringSize.Width) / 2;
                        float x = xCenter;
                        float y = bm.Height;

                        StringFormat drawFormat = new StringFormat();
                        drawFormat.FormatFlags = StringFormatFlags.NoWrap;

                        g.DrawImage(bm, 0, 0);
                        g.DrawString(_code, drawFont, drawBrush, x, y, drawFormat);

                        return bmT;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al generar código de barras Code128. Desc:" + ex.Message);
                }
            }
        }

        #endregion

    }
}
