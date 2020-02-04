﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using ClienteWinForm.Impresion;
using ClienteWinForm.Generales;

namespace ClienteWinForm.Ventas.Facturacion
{
    public partial class frmPrevioNotaDebito : FrmMantenimientoBase
    {

        public frmPrevioNotaDebito(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String Numero)
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            pFormatoGrid(dgvDetalle);
            DocumentoPrevio = AgenteVentas.Proxy.RecuperarDocumentoCompleto(idEmpresa, idLocal, idDocumento, Serie, Numero);
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            //Cargar el Logo de la empresa...
            if (File.Exists(RutaImagen))
            {
                pictureBox1.Image = Image.FromFile(RutaImagen);
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        EmisionDocumentoE DocumentoPrevio = null;
        NumControlDetE ValoresDocumento = null;
        String RutaImagen = String.Empty;
        PrintDocument printDocumento = new PrintDocument();

        #endregion

        #region Procedimientos de Usuario

        void LlenarDatos()
        {
            String NombreDocumento = String.Empty;
            DateTime fecTraslado = Convert.ToDateTime(DocumentoPrevio.fecTraslado);
            DateTime fecDocumentoRef = Convert.ToDateTime(DocumentoPrevio.fecDocumentoRef);
            DateTime Fecha = Convert.ToDateTime(DocumentoPrevio.fecEmision);
            Decimal numDecimal = 0;
            String Moneda = String.Empty;
            String MonedaIngles = String.Empty;
            String RucComprador = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == DocumentoPrevio.idMoneda
                                select x).SingleOrDefault();

            #region Datos de NC

            lblRuc.Text = "R.U.C. " + VariablesLocales.SesionUsuario.Empresa.RUC;
            lblSerie.Text = DocumentoPrevio.numSerie + " - ";
            lblNumero.Text = "N° " + DocumentoPrevio.numDocumento;

            this.Text = "Vista Previa - Nota de Débito " + DocumentoPrevio.idDocumento + " " + DocumentoPrevio.numSerie + "-" + DocumentoPrevio.numDocumento;

            #endregion

            lblFecEmision.Text = Fecha.ToString("dd/MM/yyyy");

            if (DocumentoPrevio.idDocumentoRef == EnumTipoDocumentoVenta.FE.ToString() ||
                DocumentoPrevio.idDocumentoRef == EnumTipoDocumentoVenta.FS.ToString() ||
                DocumentoPrevio.idDocumentoRef == EnumTipoDocumentoVenta.FV.ToString())
            {
                NombreDocumento = "Factura";
            }
            else if (DocumentoPrevio.idDocumentoRef == "BV")
            {
                NombreDocumento = "Boleta";
            }

            lblNomDocumento.Text = NombreDocumento;
            lblNumDocumento.Text = DocumentoPrevio.serDocumentoRef + " - " + DocumentoPrevio.numDocumentoRef;
            lblFechaRef.Text = Convert.ToDateTime(DocumentoPrevio.fecDocumentoRef).ToString("dd/MM/yyy");
            lblRazonSocial.Text = DocumentoPrevio.RazonSocial;

            if (DocumentoPrevio.idDocumentoRef != EnumTipoDocumentoVenta.FE.ToString())
            {
                RucComprador = DocumentoPrevio.numRuc;
            }

            lblRucComprador.Text = RucComprador;
            string  porcIgv = "";
            List<EmisionDocumentoDetE> ListaItems = new List<EmisionDocumentoDetE>(DocumentoPrevio.ListaItemsDocumento);

            if (ListaItems.Count <= 20)
            {
                for (int i = ListaItems.Count; i < 30; i++)
                {
                    EmisionDocumentoDetE det = new EmisionDocumentoDetE();

                    if (det.Cantidad == 0)
                    {
                        det.Cantidad = 0;
                    }

                    ListaItems.Add(det);
                }
            }

            if (ListaItems.Count > 0)
            {
                foreach (EmisionDocumentoDetE obj in ListaItems)
                {
                    if (obj.porIgv > 0) porcIgv = Convert.ToDecimal(obj.porIgv).ToString();
                }
            }
            
            bsDetalle.DataSource = ListaItems;
            bsDetalle.ResetBindings(false);

            numDecimal = Convert.ToDecimal(DocumentoPrevio.totTotal);
            lblValorVenta.Text = numDecimal.ToString("N2");
            lblPrecio.Text = "I.G.V. "+ porcIgv +" %";
            lblIgv.Text = Convert.ToDecimal(DocumentoPrevio.totIgv).ToString("N2");
            lblTotal.Text = numDecimal.ToString("N2");
            Moneda = " " + oMoneda.desMoneda.ToUpper();
            MonedaIngles = " US DOLLARS";

            //if (Convert.ToInt32(DocumentoPrevio.idMoneda) == (Int32)EnumTipoMoneda.Soles)
            //{
            //    Moneda = " NUEVOS SOLES";
            //}
            //else if (Convert.ToInt32(DocumentoPrevio.idMoneda) == (Int32)EnumTipoMoneda.Dolares)
            //{
            //    Moneda = " DOLARES AMERICANOS";
            //    MonedaIngles = " US DOLLARS";
            //}
            //else
            //{
            //    Moneda = " EUROS";
            //}

            lblMontoLetras.Text = "SON: " + Impresion.Mercantil.Impresion.enLetras(DocumentoPrevio.totTotal.ToString()) + Moneda;
            lblMontoIngles.Text = "     " + Impresion.Mercantil.Impresion.enIngles(DocumentoPrevio.totTotal.ToString()) + MonedaIngles;

            lblDesTotal.Text = "TOTAL " + oMoneda.desAbreviatura;
            lblMotivo.Text = DocumentoPrevio.desCondicion;
            lblPartida.Text = DocumentoPrevio.Glosa;
        }

        void pFormatoGrid(DataGridView oDgv)
        {
            ////Para que la primera columan no aparesca
            oDgv.RowHeadersVisible = false;

            oDgv.GridColor = SystemColors.ActiveBorder;
            //Inicializar propiedades básicas DataGridView.
            oDgv.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 7.25f, FontStyle.Bold, GraphicsUnit.Point);
            oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            //oDgv.RowHeadersDefaultCellStyle.BackColor = Color.Black;
            oDgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //Alternando colores en las filas
            oDgv.RowsDefaultCellStyle.BackColor = Color.White;
            oDgv.RowsDefaultCellStyle.Font = new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point);

            //Valores de propiedad, conjunto adecuado para la visualización.
            oDgv.AllowUserToAddRows = false;
            oDgv.AllowUserToDeleteRows = false;
            oDgv.AllowUserToOrderColumns = false;
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oDgv.MultiSelect = false;

            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            //Estableciendo el el alto de los titulos
            oDgv.ColumnHeadersHeight = 28;
            oDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 14;
            lineas.MinimumHeight = 10;
            lineas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            oDgv.Refresh();
        }

        void QuitarLineas(DataGridViewCellPaintingEventArgs e, Int32 numIni, Int32 numFin, TextFormatFlags flag)
        {
            if (e.RowIndex >= numIni && (e.ColumnIndex == numFin))
            {
                Color clrFondoCelda;
                Color clrTextoCelda;

                clrFondoCelda = SystemColors.Window;
                clrTextoCelda = SystemColors.WindowText;

                // rellenar el rectángulo de la celda con el color correspondiente
                e.Graphics.FillRectangle(new SolidBrush(clrFondoCelda), e.CellBounds);

                // dibujar solamente la línea vertical de la celda
                e.Graphics.DrawLine(new Pen(SystemColors.ActiveBorder),
                    new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y),
                    new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height));

                // si la celda tiene valor
                if (e.Value != null)
                {
                    // dibujar el texto
                    TextRenderer.DrawText(e.Graphics,
                        e.FormattedValue.ToString(),
                        e.CellStyle.Font,
                        e.CellBounds,
                        clrTextoCelda,
                        flag);
                }

                e.Handled = true;
            }
        }

        void CargarValores(Int32 idEmpresa_, Int32 idLocal_, Int32 idControl_, String idDocumento_, String Serie_)
        {
            ValoresDocumento = new NumControlDetE();
            //ValoresDocumento = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(idEmpresa_, idLocal_, idControl_, idDocumento_, Serie_);

            ValoresDocumento = VariablesLocales.ListaDetalleNumControl.Find
            (
                delegate(NumControlDetE item) 
                { return item.idEmpresa == idEmpresa_ 
                        && item.idLocal == idLocal_
                        && item.idControl == idControl_
                        && item.idDocumento == idDocumento_
                        && item.Serie == Serie_; 
                }
            );
        }

        Boolean VerificarImpresora(String Nombre)
        {
            try
            {
                Boolean Encontro = false;

                if (String.IsNullOrEmpty(Nombre))
                {
                    Global.MensajeComunicacion("El documento no tiene asignado una impresora...");
                    return false;
                }

                foreach (String NombreImpresora in PrinterSettings.InstalledPrinters)
                {
                    if (Nombre == NombreImpresora)
                    {
                        Encontro = true;
                        break;
                    }
                }

                if (!Encontro)
                {
                    Global.MensajeComunicacion("La impresora asignada a este documento no se encuentra.\n\rVerifique si se encuentra encendida.");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
                return false;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Imprimir()
        {
            try
            {
                frmEscogerImpresora oFrm = new frmEscogerImpresora();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oImpresora != null)
                {
                    String NombreImpresora = oFrm.oImpresora.Descripcion;

                    if (!VerificarImpresora(NombreImpresora))
                    {
                        return;
                    }

                    if (oFrm.oImpresora.PorDefecto) //Solo cuando la impresora es la principal y es matricial, se emite...
                    {
                        if (oFrm.oImpresora.EsMatricial)
                        {
                            if (DocumentoPrevio.indEstado == EnumEstadoDocumentos.C.ToString())
                            {
                                AgenteVentas.Proxy.CambiarEstadoDocumento(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie, DocumentoPrevio.numDocumento, EnumEstadoDocumentos.E.ToString(), VariablesLocales.SesionUsuario.Credencial);
                            }

                            if (DocumentoPrevio.indEstado == EnumEstadoDocumentos.F.ToString())
                            {
                                AgenteVentas.Proxy.CambiarEstadoDocumento(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie, DocumentoPrevio.numDocumento, EnumEstadoDocumentos.F.ToString(), VariablesLocales.SesionUsuario.Credencial);
                            }

                            //Imprimiendo...
                            ImpresionManager.RecuperarUtilImpresion(VariablesLocales.SesionUsuario.Empresa.RUC).ImprimirNotaDeDebito(DocumentoPrevio, NombreImpresora);
                        }
                        else
                        {
                            printDocumento.PrinterSettings.PrinterName = NombreImpresora;
                            printDocumento.DocumentName = "Impresion de Nota de Débito";
                            printDocumento.Print();
                        }
                    }
                    else
                    {
                        if (oFrm.oImpresora.EsMatricial)
                        {
                            //Imprimiendo...
                            ImpresionManager.RecuperarUtilImpresion(VariablesLocales.SesionUsuario.Empresa.RUC).ImprimirNotaDeCredito(DocumentoPrevio, NombreImpresora);
                        }
                        else
                        {
                            printDocumento.PrinterSettings.PrinterName = NombreImpresora;
                            printDocumento.DocumentName = "Impresion de Nota de Débito";
                            printDocumento.Print();
                        }
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.Cancel;
                Global.MensajeComunicacion(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void printDocumento_PrintPage(Object sender, PrintPageEventArgs e)
        {
            pnlBase.BorderStyle = BorderStyle.None;

            using (Bitmap bmp = new Bitmap(pnlBase.Width, pnlBase.Height, pnlBase.CreateGraphics()))
            {
                pnlBase.DrawToBitmap(bmp, new Rectangle(0, 0, pnlBase.Width, pnlBase.Height));

                RectangleF bounds = e.PageSettings.PrintableArea;
                float factor = ((float)bmp.Height / (float)bmp.Width);
                e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
            }

            pnlBase.BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion

        #region Eventos

        private void frmPrevioNotaDebito_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;

                if (DocumentoPrevio != null)
                {
                    CargarValores(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, 5, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie);
                }

                dgvDetalle.Columns[0].Width = 60;
                dgvDetalle.Columns[1].Width = 530;
                dgvDetalle.Columns[2].Width = 65;
                dgvDetalle.Columns[3].Width = 65;

                LlenarDatos();
                BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

                Location = new Point(0, 0);
                Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

                printDocumento.PrintPage += new PrintPageEventHandler(printDocumento_PrintPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDetalle_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            QuitarLineas(e, 0, 0, TextFormatFlags.Right);
            QuitarLineas(e, 0, 1, TextFormatFlags.Left);
            QuitarLineas(e, 0, 2, TextFormatFlags.Right);
            QuitarLineas(e, 0, 3, TextFormatFlags.Right);
        } 

        private void dgvDetalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    if (ValoresDocumento != null)
                    {
                        if (ValoresDocumento.cantDigDecimales == 3)
                        {
                            dgvDetalle.Columns[e.ColumnIndex].DefaultCellStyle.Format = "###,###,##0.000";
                        }
                        else if (ValoresDocumento.cantDigDecimales == 4)
                        {
                            dgvDetalle.Columns[e.ColumnIndex].DefaultCellStyle.Format = "###,###,##0.0000";
                        }
                        else if (ValoresDocumento.cantDigDecimales == 5)
                        {
                            dgvDetalle.Columns[e.ColumnIndex].DefaultCellStyle.Format = "###,###,##0.00000";
                        }
                        else if (ValoresDocumento.cantDigDecimales == 6)
                        {
                            dgvDetalle.Columns[e.ColumnIndex].DefaultCellStyle.Format = "###,###,##0.000000";
                        }
                        else if (ValoresDocumento.cantDigDecimales == 7)
                        {
                            dgvDetalle.Columns[e.ColumnIndex].DefaultCellStyle.Format = "###,###,##0.0000000";
                        }
                        else
                        {
                            dgvDetalle.Columns[e.ColumnIndex].DefaultCellStyle.Format = "###,###,##0.00";
                        }
                    }
                    else
                    {
                        dgvDetalle.Columns[e.ColumnIndex].DefaultCellStyle.Format = "###,###,##0.00";
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void frmPrevioNotaDebito_SizeChanged(object sender, EventArgs e)
        {
            pnlBase.Left = (ClientSize.Width - pnlBase.Size.Width) / 2;
        }

        #endregion

    }
}