using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Text;
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
    public partial class frmBoletaGenesis : FrmMantenimientoBase
    {

        public frmBoletaGenesis(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String Numero)
        {
            Global.AjustarResolucion(this);
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
        //EmpresaImagenesE oEmpresaImagen = null;
        PrintDocument printDocumento = new PrintDocument();

        #endregion

        #region Procedimientos de Usuario

        void LlenarDatos()
        {
            String Tipo = String.Empty;
            DateTime fecDocumentoRef = Convert.ToDateTime(DocumentoPrevio.fecDocumentoRef);
            DateTime Fecha = Convert.ToDateTime(DocumentoPrevio.fecEmision);
            String Moneda = String.Empty;
            Boolean UsarNombreCompuesto = VariablesLocales.oVenParametros.indNomArtCompuesto;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == DocumentoPrevio.idMoneda
                                select x).SingleOrDefault();

            lblRuc.Text = "R.U.C. " + VariablesLocales.SesionUsuario.Empresa.RUC;
            lblSerie.Text = DocumentoPrevio.numSerie + " - ";
            lblNumero.Text = "N° " + DocumentoPrevio.numDocumento;

            lblSenior.Text = DocumentoPrevio.RazonSocial;
            lblDireccion.Text = DocumentoPrevio.Direccion;
            lblRucCliente.Text = DocumentoPrevio.numRuc;

            if (DocumentoPrevio.ListaCanjeGuias != null && DocumentoPrevio.ListaCanjeGuias.Count > Variables.Cero)
            {
                StringBuilder CadenaGuias = new StringBuilder();

                foreach (CanjeGuiasE item in DocumentoPrevio.ListaCanjeGuias)
                {
                    CadenaGuias.Append(item.numSerieGuia).Append("-").Append(item.numDocumentoGuia).Append(" ");
                }

                lblGuia.Text = CadenaGuias.ToString().Trim();
                //lblGuia.Text = DocumentoPrevio.ListaCanjeGuias[0].numSerieGuia + "-" + DocumentoPrevio.ListaCanjeGuias[0].numDocumentoGuia;
            }
            else
            {
                lblGuia.Text = String.Empty;
            }

            lblGlosa.Text = DocumentoPrevio.Glosa;
            //lblFecEmision.Text = DocumentoPrevio.fecEmision.ToString("d"); //Por revisar
            lblCondicion.Text = DocumentoPrevio.desCondicion;

            foreach (EmisionDocumentoDetE item in DocumentoPrevio.ListaItemsDocumento)
            {
                if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009" || //AgroGenesis
                    VariablesLocales.SesionUsuario.Empresa.RUC == "20523020561" || //Huerto Genesis
                    VariablesLocales.SesionUsuario.Empresa.RUC == "20517933318") //Vivero Genesis
                {
                    item.nomArticulo = (!UsarNombreCompuesto ? item.nomArticulo : (item.tipArticulo == "AR" ? item.desNomArtCompuesto : item.nomArticulo));

                    item.PrecioCad = oMoneda.desAbreviatura + Global.Derecha("            " + item.PrecioCad, 12);
                    item.SubTotalCad = oMoneda.desAbreviatura + Global.Derecha("            " + item.SubTotalCad, 12);
                }
                else
                {
                    item.nomArticulo = (!UsarNombreCompuesto ? item.nomArticulo : (item.tipArticulo == "AR" ? item.desNomArtCompuesto : item.nomArticulo));
                }

                if (!item.indCalculo)
                {
                    item.nomArticulo = item.nomArticulo + "(BONIFICACION)";
                    item.SubTotalCad = oMoneda.desAbreviatura + "        0.00";
                }
            }

            //Descuento Global
            if (DocumentoPrevio.DsctoGlobal > Variables.Cero && DocumentoPrevio.porDscto > Variables.Cero)
            {
                EmisionDocumentoDetE Item = new EmisionDocumentoDetE()
                {
                    Cantidad = 1,
                    nomArticulo = DocumentoPrevio.Glosa,
                    indCalculo = false,
                    SubTotalCad = "-" + DocumentoPrevio.DsctoGlobal.Value.ToString("N2")
                };

                DocumentoPrevio.ListaItemsDocumento.Add(Item);
            }

            if (DocumentoPrevio.desCondicion.Contains("TRANSFERENCIA"))
            {
                EmisionDocumentoDetE Item = new EmisionDocumentoDetE()
                {
                    CantidadCad = string.Empty,
                    nomArticulo = string.Empty,
                    PrecioCad = string.Empty,
                    TotalCad = string.Empty
                };

                DocumentoPrevio.ListaItemsDocumento.Add(Item);

                Item = new EmisionDocumentoDetE()
                {
                    CantidadCad = string.Empty,
                    nomArticulo = "TRANSFERENCIA A TITULO GRATUITO.",
                    PrecioCad = string.Empty,
                    TotalCad = string.Empty
                };

                DocumentoPrevio.ListaItemsDocumento.Add(Item);
            }

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

            bsDetalle.DataSource = ListaItems;
            bsDetalle.ResetBindings(false);

            lblTotal.Text = DocumentoPrevio.desMoneda + "  " + DocumentoPrevio.totTotal.ToString("N2");
            Moneda = " " + oMoneda.desMoneda.ToUpper();

            if (DocumentoPrevio.desCondicion.Contains("TRANSFERENCIA"))
            {
                lblGlosa.Visible = true;
                //lblGlosa.Text = "TRANSFERENCIA A TITULO GRATUITO.";
                lblTotal.Text = oMoneda.desAbreviatura + " 0.00";
                lblMontoLetras.Text = "SON: " + NumeroLetras.enLetras("0.00") + Moneda;
            }
            else
            {
                lblMontoLetras.Text = "SON: " + NumeroLetras.enLetras(DocumentoPrevio.totTotal.ToString()) + Moneda;
            }

            Text = "Vista Previa - Boleta " + Tipo + DocumentoPrevio.idDocumento + " " + DocumentoPrevio.numSerie + "-" + DocumentoPrevio.numDocumento;
        }

        void pFormatoGrid(DataGridView oDgv)
        {
            //Para que la primera columan no aparesca
            oDgv.RowHeadersVisible = false;

            //Inicializar propiedades básicas DataGridView.
            oDgv.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 7.25f, FontStyle.Bold, GraphicsUnit.Point);
            oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            oDgv.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
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
            lineas.Height = 12;
            lineas.MinimumHeight = 8;
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
            ValoresDocumento = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(idEmpresa_, idLocal_, idControl_, idDocumento_, Serie_);
        }

        Boolean VerificarImpresora(string Nombre)
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
                    string NombreImpresora = oFrm.oImpresora.Descripcion;

                    if (!VerificarImpresora(NombreImpresora))
                    {
                        return;
                    }

                    if (oFrm.oImpresora.PorDefecto) //Solo cuando la impresora es la principal se emite y es matricial
                    {
                        if (oFrm.oImpresora.EsMatricial)
                        {
                            //Cambiando el estado del documento si es la primera vez...
                            //if (DocumentoPrevio.indEstado == EnumEstadoDocumentos.C.ToString())
                            //{
                            //    AgenteVentas.Proxy.CambiarEstadoDocumento(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie, DocumentoPrevio.numDocumento, EnumEstadoDocumentos.E.ToString(), VariablesLocales.SesionUsuario.Credencial);
                            //}

                            //Imprimiendo...

                            //ImpresionManager.RecuperarUtilImpresion("20602659594").ImprimirBoletas(DocumentoPrevio, NombreImpresora);
                            ImpresionManager.RecuperarUtilImpresion().ImprimirBoletas(DocumentoPrevio, NombreImpresora); 
                        }
                        else
                        {
                            printDocumento.PrinterSettings.PrinterName = NombreImpresora;
                            printDocumento.DocumentName = "Impresion de Boleta";
                            printDocumento.Print();
                        }
                    }
                    else
                    {
                        if (oFrm.oImpresora.EsMatricial)
                        {

                            //Imprimiendo...
                        //    ImpresionManager.RecuperarUtilImpresion("20502647009").ImprimirBoletas(DocumentoPrevio, NombreImpresora);

                        ImpresionManager.RecuperarUtilImpresion().ImprimirBoletas(DocumentoPrevio, NombreImpresora);
                        }
                        else
                        {
                            printDocumento.PrinterSettings.PrinterName = NombreImpresora;
                            printDocumento.DocumentName = "Impresion de Boleta";
                            printDocumento.Print();
                        }
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
                DialogResult = DialogResult.Cancel;
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

        private void frmBoletaGenesis_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;

                if (DocumentoPrevio != null)
                {
                    CargarValores(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, 2, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie);
                }

                dgvDetalle.Columns[0].Width = 60;
                dgvDetalle.Columns[1].Width = 500;
                dgvDetalle.Columns[2].Width = 80;
                dgvDetalle.Columns[3].Width = 80;

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

        private void lblGlosa_SizeChanged(object sender, EventArgs e)
        {
            lblGlosa.Left = (ClientSize.Width - lblGlosa.Size.Width) / 2;
            lblGlosa.Top = (ClientSize.Height - lblGlosa.Height) / 2;
        }

        private void frmBoletaGenesis_Resize(object sender, EventArgs e)
        {
            pnlBase.Left = (ClientSize.Width - pnlBase.Size.Width) / 2;
        }

        #endregion

    }
}
