using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
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
    public partial class frmSolicitudFactura : FrmMantenimientoBase
    {

        public frmSolicitudFactura(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String Numero)
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            pFormatoGrid(dgvDetalle);
            DocumentoPrevio = AgenteVentas.Proxy.RecuperarDocumentoCompleto(idEmpresa, idLocal, idDocumento, Serie, Numero);

            dgvDetalle.Columns[0].Width = 50;
            dgvDetalle.Columns[1].Width = 540;
            dgvDetalle.Columns[2].Width = 68;
            dgvDetalle.Columns[3].Width = 58;

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
            if (DocumentoPrevio != null)
            {
                String Tipo = String.Empty;
                DateTime fecTraslado = Convert.ToDateTime(DocumentoPrevio.fecTraslado);
                MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                    where x.idMoneda == DocumentoPrevio.idMoneda
                                    select x).SingleOrDefault();

                lblRuc.Text = "R.U.C. " + VariablesLocales.SesionUsuario.Empresa.RUC;
                lblSerie.Text = DocumentoPrevio.numSerie + " - ";
                lblNumero.Text = "N° " + DocumentoPrevio.numDocumento;

                //lblFecEmision.Text = DocumentoPrevio.fecEmision.ToString("d");
                lblSenior.Text = DocumentoPrevio.RazonSocial;
                lblRucCliente.Text = DocumentoPrevio.numRuc;
                lblPartida.Text = DocumentoPrevio.PuntoPartida;
                lblLlegada.Text = "".PadLeft(18, ' ') + DocumentoPrevio.PuntoLlegada;
                lblFechaTraslado.Text = fecTraslado.ToString("dd/MM/yyyy");
                lblfactura.Text = DocumentoPrevio.serDocumentoRef + " " + DocumentoPrevio.numDocumentoRef;

                lblTransporte.Text = DocumentoPrevio.RazonSocialTransp;
                lblRucTransporte.Text = DocumentoPrevio.RucTransp;
                lblInscripcion.Text = DocumentoPrevio.inscripTransp;
                lblPlaca.Text = DocumentoPrevio.MarcaTransp + " " + DocumentoPrevio.PlacaTransp;
                lblLicencia.Text = DocumentoPrevio.LicenciaTransp;

                if (DocumentoPrevio.idDocumento == EnumTipoDocumentoVenta.GV.ToString())
                {
                    lblGlosa.Visible = true;
                    lblGlosa.Text = "Atención: " + DocumentoPrevio.Glosa;

                    Tipo = "Venta ";
                }
                else
                {
                    lblGlosa.Visible = false;
                    lblGlosa.Text = String.Empty;
                    Tipo = "Traslado ";
                }

                foreach (EmisionDocumentoDetE item in DocumentoPrevio.ListaItemsDocumento)
                {
                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009") //Agrogenesis
                    {
                        item.nomArticulo = item.nomArticulo + "(" + item.LoteProveedor + ")";
                    }
                    else
                    {
                        item.nomArticulo = item.nomArticulo;
                    }

                    if (!item.indCalculo)
                    {
                        item.nomArticulo = item.nomArticulo + "(BONIFICACION)";
                    }
                }

                List<EmisionDocumentoDetE> ListaItems = new List<EmisionDocumentoDetE>(DocumentoPrevio.ListaItemsDocumento);

                if (ListaItems.Count <= 30)
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

                if (DocumentoPrevio.ListaCanjeGuias != null && DocumentoPrevio.ListaCanjeGuias.Count > Variables.Cero)
                {
                    StringBuilder oSb = new StringBuilder();

                    foreach (CanjeGuiasE item in DocumentoPrevio.ListaCanjeGuias)
                    {
                        oSb.Append(item.numSerieFact).Append("-").Append(item.numDocumentoFact).Append(" ");
                    }

                    lblfactura.Text = oSb.ToString().Trim();

                    if (DocumentoPrevio.ListaCanjeGuias[0].idDocumentoFact == "FV")
                    {
                        lblTipo.Text = "Factura de Venta";
                    }
                    else
                    {
                        lblTipo.Text = "Boleta de Venta";
                    }
                }
                else
                {
                    lblfactura.Text = String.Empty;
                    lblTipo.Text = String.Empty;
                }

                Text = "Vista Previa - Solicitud de Factura " + Tipo + " " + DocumentoPrevio.numSerie + "-" + DocumentoPrevio.numDocumento;
            }
        }

        void pFormatoGrid(DataGridView oDgv)
        {
            ////Para que la primera columan no aparesca
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
            oDgv.ColumnHeadersHeight = 30;
            oDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 14;
            lineas.MinimumHeight = 10;
            lineas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            oDgv.Refresh();
        }

        void CargarValores(Int32 idEmpresa_, Int32 idLocal_, Int32 idControl_, String idDocumento_, String Serie_)
        {
            ValoresDocumento = new NumControlDetE();
            ValoresDocumento = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(idEmpresa_, idLocal_, idControl_, idDocumento_, Serie_);
        }

        Boolean VerificarImpresora(string Nombre)
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
                    TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(), e.CellStyle.Font, e.CellBounds, clrTextoCelda, flag);
                }

                e.Handled = true;
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
                            if (DocumentoPrevio.indEstado == EnumEstadoDocumentos.C.ToString())
                            {
                                AgenteVentas.Proxy.CambiarEstadoDocumento(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie, DocumentoPrevio.numDocumento, EnumEstadoDocumentos.E.ToString(), VariablesLocales.SesionUsuario.Credencial);
                            }
                            else if (DocumentoPrevio.indEstado == EnumEstadoDocumentos.F.ToString())
                            {
                                AgenteVentas.Proxy.CambiarEstadoDocumento(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie, DocumentoPrevio.numDocumento, EnumEstadoDocumentos.F.ToString(), VariablesLocales.SesionUsuario.Credencial);
                            }

                            //Imprimiendo...
                            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20523201868" || VariablesLocales.SesionUsuario.Empresa.RUC == "20601328179")
                            {
                                ImpresionManager.RecuperarUtilImpresion("20552695217").ImprimirGuiaRemision(DocumentoPrevio, NombreImpresora, (int)EnumTipoImpresionGuiaRemision.VENTA);
                            }
                            else
                            {
                                ImpresionManager.RecuperarUtilImpresion(VariablesLocales.SesionUsuario.Empresa.RUC).ImprimirGuiaRemision(DocumentoPrevio, NombreImpresora, (int)EnumTipoImpresionGuiaRemision.VENTA);
                            }
                        }
                        else
                        {
                            printDocumento.PrinterSettings.PrinterName = NombreImpresora;
                            printDocumento.DocumentName = "Impresion de Guia";
                            printDocumento.Print();
                        }
                    }
                    else
                    {
                        if (oFrm.oImpresora.EsMatricial)
                        {
                            //Imprimiendo...
                            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20523201868" || VariablesLocales.SesionUsuario.Empresa.RUC == "20601328179")
                            {
                                ImpresionManager.RecuperarUtilImpresion("20552695217").ImprimirGuiaRemision(DocumentoPrevio, NombreImpresora, (int)EnumTipoImpresionGuiaRemision.VENTA);
                            }
                            else
                            {
                                ImpresionManager.RecuperarUtilImpresion(VariablesLocales.SesionUsuario.Empresa.RUC).ImprimirGuiaRemision(DocumentoPrevio, NombreImpresora, (int)EnumTipoImpresionGuiaRemision.VENTA);
                            }
                        }
                        else
                        {
                            printDocumento.PrinterSettings.PrinterName = NombreImpresora;
                            printDocumento.DocumentName = "Impresion de Guia";
                            printDocumento.Print();
                        }
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeComunicacion(ex.Message);
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

        private void frmSolicitudFactura_Load(object sender, EventArgs e)
        {
            Grid = false;

            if (DocumentoPrevio != null)
            {
                CargarValores(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, 3, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie);
            }

            LlenarDatos();
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            printDocumento.PrintPage += new PrintPageEventHandler(printDocumento_PrintPage);
        }

        private void dgvDetalle_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //// comprobar que la fila y columna son las adecuadas
            //if (e.RowIndex >= 0 && (e.ColumnIndex == 0))
            //{
            //    Color clrFondoCelda;
            //    Color clrTextoCelda;
            //    // en función de si la celda está o no seleccionada establecer los colores
            //    //if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            //    //{
            //    //    clrFondoCelda = SystemColors.Highlight;
            //    //    clrTextoCelda = SystemColors.Window;
            //    //}
            //    //else
            //    //{
            //    clrFondoCelda = SystemColors.Window;
            //    clrTextoCelda = SystemColors.WindowText;
            //    //}

            //    // rellenar el rectángulo de la celda con el color correspondiente
            //    e.Graphics.FillRectangle(new SolidBrush(clrFondoCelda), e.CellBounds);

            //    // dibujar solamente la línea vertical de la celda
            //    e.Graphics.DrawLine(new Pen(SystemColors.ActiveBorder),
            //        new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y),
            //        new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height));

            //    // si la celda tiene valor
            //    if (e.Value != null)
            //    {
            //        // dibujar el texto
            //        TextRenderer.DrawText(e.Graphics,
            //            e.FormattedValue.ToString(),
            //            e.CellStyle.Font,
            //            e.CellBounds,
            //            clrTextoCelda);
            //    }

            //    e.Handled = true;
            //}

            QuitarLineas(e, 0, 0, TextFormatFlags.Right);
            QuitarLineas(e, 0, 1, TextFormatFlags.Left);
            QuitarLineas(e, 0, 2, TextFormatFlags.HorizontalCenter);
            QuitarLineas(e, 0, 3, TextFormatFlags.Right);
        }

        private void frmSolicitudFactura_SizeChanged(object sender, EventArgs e)
        {
            pnlBase.Left = (ClientSize.Width - pnlBase.Size.Width) / 2;
        }

        #endregion

    }
}
