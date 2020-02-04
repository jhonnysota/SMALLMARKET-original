using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using ClienteWinForm.Impresion;
using ClienteWinForm.Generales;
using Infraestructura.Winform;

namespace ClienteWinForm.Ventas.Facturacion
{
    public partial class frmGuiaSergensur : FrmMantenimientoBase
    {

        public frmGuiaSergensur(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String Numero)
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            pFormatoGrid(dgvDetalle);
            dgvDetalle.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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

            dgvDetalle.Columns[0].Width = 60;
            dgvDetalle.Columns[1].Width = 500;
            dgvDetalle.Columns[2].Width = 70;
            dgvDetalle.Columns[3].Width = 76;
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
                DateTime fecEmision = Convert.ToDateTime(DocumentoPrevio.fecEmision);

                lblRuc.Text = "R.U.C. N° " + VariablesLocales.SesionUsuario.Empresa.RUC;
                lblSerie.Text = DocumentoPrevio.numSerie + " - ";
                lblNumero.Text = "N° " + DocumentoPrevio.numDocumento;

                //lblSenior.Text = DocumentoPrevio.RazonSocial;
                //lblRucCliente.Text = DocumentoPrevio.numRuc;
                //label9.Text = DocumentoPrevio.fecEmision.Day.ToString(); //Por revisar
                //label19.Text = FechasHelper.NombreMes(DocumentoPrevio.fecEmision.Month); //Por revisar
                //label26.Text = DocumentoPrevio.fecEmision.Year.ToString().Substring(2, 2); //Por revisar

                lblPartida.Text = DocumentoPrevio.PuntoPartida;
                lblLlegada.Text = DocumentoPrevio.PuntoLlegada;
                //lblCondicion.Text = DocumentoPrevio.desCondicion;
                //lblFechaTraslado.Text = fecTraslado.ToString("dd/MM/yyyy");
                //lblFecEmision.Text = fecEmision.ToString("dd/MM/yyyy");

                //lblTransporte.Text = DocumentoPrevio.RazonSocialTransp;
                //lblRucTransporte.Text = DocumentoPrevio.RucTransp;
                lblInscripcion.Text = DocumentoPrevio.RazonSocial;
                lblPlaca.Text = DocumentoPrevio.MarcaTransp + " " + DocumentoPrevio.PlacaTransp;
                lblLicencia.Text = DocumentoPrevio.numRuc;
                label4.Text = DocumentoPrevio.fecTraslado.Value.ToString("d");

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

                switch (DocumentoPrevio.idTipTraslado)
                {
                    case 1: //Venta
                        //chkVenta.Checked = true;
                        break;
                    case 2: //Venta sujeta a confirmación del comprador
                        //chkVentaSujeta.Checked = true;
                        break;
                    case 3: //Consignacion
                        ////chkConsignacion.Checked = true;
                        break;
                    case 4: //Devolucion
                        //chkDevolucion.Checked = true;
                        break;
                    case 5: //Traslado de bienes para transformación
                        //chkTransformacion.Checked = true;
                        break;
                    case 6: //Traslado de bienes para transformación
                        //chkPrimaria.Checked = true;
                        break;
                    case 7: //Otros
                        //chkBienes.Checked = true;
                        //lblOtros.Text = DocumentoPrevio.OtroTipoTraslado;
                        break;
                    case 8: //Otros
                        chkOtros.Checked = true;
                        //lblOtros.Text = DocumentoPrevio.OtroTipoTraslado;
                        break;

                    default:
                        break;
                }

                foreach (EmisionDocumentoDetE item in DocumentoPrevio.ListaItemsDocumento)
                {
                    item.nomArticulo = item.nomArticulo;
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
                    //lblFactura.Text = DocumentoPrevio.ListaCanjeGuias[0].numSerieFact + "-" + DocumentoPrevio.ListaCanjeGuias[0].numDocumentoFact;
                }

                Text = "Vista Previa - Guia de Remisión " + Tipo + DocumentoPrevio.idDocumento + " " + DocumentoPrevio.numSerie + "-" + DocumentoPrevio.numDocumento;
            }
        }

        void pFormatoGrid(DataGridView oDgv)
        {
            ////Para que la primera columan no aparesca
            oDgv.RowHeadersVisible = false;

            //Inicializar propiedades básicas DataGridView.
            oDgv.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 6.25f, FontStyle.Bold, GraphicsUnit.Point);
            oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 176, 198);
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
                            ImpresionManager.RecuperarUtilImpresion(VariablesLocales.SesionUsuario.Empresa.RUC).ImprimirGuiaRemision(DocumentoPrevio, NombreImpresora, (int)EnumTipoImpresionGuiaRemision.VENTA);
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
                            ImpresionManager.RecuperarUtilImpresion(VariablesLocales.SesionUsuario.Empresa.RUC).ImprimirGuiaRemision(DocumentoPrevio, NombreImpresora, (int)EnumTipoImpresionGuiaRemision.VENTA);
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

        private void frmGuiaNevados_Load(object sender, EventArgs e)
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

            //Creando el evento para imprimir
            printDocumento.PrintPage += new PrintPageEventHandler(printDocumento_PrintPage);
        }

        private void dgvDetalle_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            QuitarLineas(e, 0, 0, TextFormatFlags.Right);
            QuitarLineas(e, 0, 1, TextFormatFlags.Left);
            QuitarLineas(e, 0, 2, TextFormatFlags.Right);
            QuitarLineas(e, 0, 3, TextFormatFlags.HorizontalCenter);
        }

        private void frmGuiaNevados_Resize(object sender, EventArgs e)
        {
            pnlBase.Left = (ClientSize.Width - pnlBase.Size.Width) / 2;
        }

        #endregion

        private void label33_Click(object sender, EventArgs e)
        {

        }
    }
}
