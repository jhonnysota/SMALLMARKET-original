using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using ClienteWinForm.Impresion;

namespace ClienteWinForm.Ventas.Facturacion
{
    public partial class frmTicketBoletaDellas : FrmMantenimientoBase
    {

        public frmTicketBoletaDellas(EmisionDocumentoE DocTemp)
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            pFormatoGrid(dgvDetalle);
            DocumentoPrevio = DocTemp;
        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        EmisionDocumentoE DocumentoPrevio = null;
        NumControlDetE ValoresDocumento = null;

        //PrintDocument printDocumento = new PrintDocument();

        //private int _rowMaxHeight = 0;
        //private int _rowDefaultHeight = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarDatos()
        {
            String Tipo = String.Empty;
            DateTime fecDocumentoRef = Convert.ToDateTime(DocumentoPrevio.fecDocumentoRef);
            DateTime Fecha = Convert.ToDateTime(DocumentoPrevio.fecEmision);
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == DocumentoPrevio.idMoneda
                                select x).SingleOrDefault();

            lbRazonSocial.Text = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
            lblLocal.Text = VariablesLocales.SesionLocal.Nombre;
            lblDireccionc.Text = VariablesLocales.SesionUsuario.Empresa.Direccion;

            lblRuc.Text = VariablesLocales.SesionUsuario.Empresa.RUC;
            lblDoc.Text = DocumentoPrevio.numSerie + "-" + DocumentoPrevio.numDocumento;
            lblFecha.Text = VariablesLocales.FechaHoy.ToString("G");

            if (ValoresDocumento != null)
            {
                lblCaja.Text = ValoresDocumento.numCaja;
                lblVendedor.Text = DocumentoPrevio.nomVendedor;
            }
            else
            {
                lblCaja.Text = "";
                lblVendedor.Text = "";
            }

            lblMonSub.Text = oMoneda.desAbreviatura;
            lblSubtotal.Text = Global.EspaciosDerecha(DocumentoPrevio.totsubTotal.ToString("N2").Length, 12) + DocumentoPrevio.totsubTotal.ToString("N2");

            lblMonDscto.Text = oMoneda.desAbreviatura;
            lblDscto.Text = Global.EspaciosDerecha(DocumentoPrevio.totDscto1.ToString("N2").Length, 12) + DocumentoPrevio.totDscto1.ToString("N2");

            lblMonIgv.Text = oMoneda.desAbreviatura;
            lblIGV.Text = Global.EspaciosDerecha(DocumentoPrevio.totIgv.Value.ToString("N2").Length, 12) + DocumentoPrevio.totIgv.Value.ToString("N2");

            lblMonIsc.Text = oMoneda.desAbreviatura;
            lblISC.Text = Global.EspaciosDerecha(DocumentoPrevio.totIsc.Value.ToString("N2").Length, 12) + DocumentoPrevio.totIsc.Value.ToString("N2");

            lblMonTot.Text = oMoneda.desAbreviatura;
            lblTotal.Text = Global.EspaciosDerecha(DocumentoPrevio.totTotal.ToString("N2").Length, 12) + DocumentoPrevio.totTotal.ToString("N2");

            //lblMontoTar.Text = oMoneda.desAbreviatura;

            lblRazonSocialProv.Text = DocumentoPrevio.RazonSocial;
            lblRucProv.Text = DocumentoPrevio.numRuc;
            lblDireccionprov.Text = DocumentoPrevio.Direccion;

            if (DocumentoPrevio.idDocumento == "FV")
            {
                lblTipoDoc.Text = "FACTURA ELECTRONICA";
                lblNroCli.Text = "R.U.C.";
                lblRazonCli.Text = "Razón Social:";
            }
            else
            {
                lblTipoDoc.Text = "BOLETA DE VENTA ELECTRONICA";
                lblNroCli.Text = "Doc.ID.";
                lblRazonCli.Text = "Nombres:";
            }

            List<EmisionDocumentoDetE> ListaItems = new List<EmisionDocumentoDetE>(DocumentoPrevio.ListaItemsDocumento);

            foreach (EmisionDocumentoDetE item in ListaItems)
            {
                item.SubTotalCad = item.subTotal.ToString("N2");
                item.CantidadCad = item.Cantidad.ToString("N2");
            }

            if (ListaItems.Count <= 20)
            {
                for (int i = ListaItems.Count; i < 30; i++)
                {
                    EmisionDocumentoDetE det = new EmisionDocumentoDetE();

                    //if (det.Cantidad == 0)
                    //{
                    //    det.Cantidad = 0;
                    //}

                    ListaItems.Add(det);
                }
            }

            //Decimal TotalEfectivo = DocumentoPrevio.ListaCancelaciones.Where(e => e.idMedioPago == 1).Sum(e => e.MontoAplicar);
            //Decimal TotalTarjetas = DocumentoPrevio.ListaCancelaciones.Where(t => t.idMedioPago != 1).Sum(t => t.MontoAplicar);
            //Decimal MontoVuelto = DocumentoPrevio.ListaCancelaciones.Where(e => e.idMedioPago == 1).Sum(e => e.Vuelto);

            //if (TotalEfectivo > 0 && TotalTarjetas == 0)
            //{
            //    lblFormaPago.Text = "EN EFECTIVO";
            //    lblMontoEfectivo.Text = TotalEfectivo.ToString("N2");
            //    lblMontoTar.Text = "0.00";
            //    lblMonVuelto.Text = oMoneda.desAbreviatura;
            //    lblMontoVuelto.Text = Global.EspaciosDerecha(MontoVuelto.ToString("N2").Length, 12) + MontoVuelto.ToString("N2");

            //}
            //else if (TotalEfectivo == 0 && TotalTarjetas > 0)
            //{
            //    lblFormaPago.Text = "CON TARJETA DE CREDITO";
            //    lblMontoEfectivo.Text = "0.00";
            //    lblMontoTar.Text = TotalTarjetas.ToString("N2");
            //    lblMonVuelto.Text = oMoneda.desAbreviatura;
            //    lblMontoVuelto.Text = Global.EspaciosDerecha(MontoVuelto.ToString("N2").Length, 12) + MontoVuelto.ToString("N2");
            //}
            //else if (TotalEfectivo > 0 && TotalTarjetas > 0)
            //{
            //    lblFormaPago.Text = "EN EFECTIVO Y TARJETA";
            //    lblMontoEfectivo.Text = TotalEfectivo.ToString("N2");
            //    lblMontoTar.Text = TotalTarjetas.ToString("N2");
            //    lblMonVuelto.Text = oMoneda.desAbreviatura;
            //    lblMontoVuelto.Text = Global.EspaciosDerecha(MontoVuelto.ToString("N2").Length, 12) + MontoVuelto.ToString("N2");
            //}

            if (VariablesLocales.oVenParametros != null)
            {
                lblGlosa.Text = VariablesLocales.oVenParametros.Glosa;

                if (!String.IsNullOrWhiteSpace(VariablesLocales.oVenParametros.Glosa))
                {
                    StringBuilder Cadena = new StringBuilder();

                    String Parrafo = VariablesLocales.oVenParametros.Glosa;
                    List<String> Parrafos = new List<String>(VariablesLocales.oVenParametros.Glosa.Split('|'));

                    foreach (String item in Parrafos)
                    {
                        Cadena.Append(item).Append("\n\r");
                    }

                    lblGlosa.Text = Cadena.ToString();
                }
                else
                {
                    lblGlosa.Text = "";
                }
            }
            else
            {
                lblGlosa.Text = "";
            }

            bsDetalle.DataSource = ListaItems;
            bsDetalle.ResetBindings(false);

            Text = "Vista Previa - Boleta " + Tipo + DocumentoPrevio.idDocumento + " " + DocumentoPrevio.numSerie + "-" + DocumentoPrevio.numDocumento;
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
            oDgv.ColumnHeadersHeight = 28;
            oDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 14;
            lineas.MinimumHeight = 10;
            //lineas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            oDgv.Refresh();
        }

        String DevuelveRutaArchivo(DateTime Fecha, String NumeroDoc)
        {
            string RutaDevuelta = @"C:\AmazonErp\Tickets\";
            String Anio = Fecha.ToString("yy");
            String Mes = FechasHelper.NombreMes(Fecha.Month).ToUpper();

            if (!Directory.Exists(RutaDevuelta))
            {
                Directory.CreateDirectory(RutaDevuelta);
            }

            RutaDevuelta += Mes.Substring(0, 3) + " " + Anio;

            if (!Directory.Exists(RutaDevuelta))
            {
                Directory.CreateDirectory(RutaDevuelta);
            }

            RutaDevuelta += @"\Ticket " + NumeroDoc + ".txt";

            return RutaDevuelta;
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

            //if (e.Value == null || e.RowIndex < 0)
            //{
            //    // The WordWrap code is ony executed if requested the cell has a value,
            //    // and if this is not the heading row.
            //    return;
            //}

            //if (e.ColumnIndex == 0)
            //{
            //    // Resetting row max height on each row's first cell
            //    _rowMaxHeight = 0;

            //    if (_rowDefaultHeight == 0)
            //    {
            //        /* The default DataGridView row height is saved when the first cell
            //         * inside the first row is populated the first time. This is later
            //         * used as the minimum row height, to avoid 
            //         * smaller-than-default rows. */
            //        _rowDefaultHeight = dgvDetalle.Rows[e.RowIndex].Height;
            //    }
            //}

            //// Word wrap code
            //var sOriginal = e.Graphics.MeasureString(e.Value.ToString(), dgvDetalle.Font);
            //var sWrapped = e.Graphics.MeasureString(e.Value.ToString(), dgvDetalle.Font,
            //    // Is is MeasureString that determines the height given the width, so
            //    // that it properly takes the actual wrapping into account
            //    dgvDetalle.Columns[e.ColumnIndex].Width);

            //if (sOriginal.Width != dgvDetalle.Columns[e.ColumnIndex].Width)
            //{
            //    using (Brush gridBrush = new SolidBrush(this.dgvDetalle.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor), fontBrush = new SolidBrush(e.CellStyle.ForeColor))
            //    {
            //        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
            //        // The DrawLine calls restore the missing borders: which borders
            //        // miss and how to paint them depends on border style settings
            //        //e.Graphics.DrawLine(new Pen(gridBrush, 1), new Point(e.CellBounds.X - 1, e.CellBounds.Y + e.CellBounds.Height - 1), new Point(e.CellBounds.X + e.CellBounds.Width - 1,
            //        //        e.CellBounds.Y + e.CellBounds.Height - 1));
            //        //e.Graphics.DrawLine(new Pen(gridBrush, 1), 
            //        //    new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y - 1), 
            //        //    new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1));
            //        e.Graphics.DrawLine(new Pen(gridBrush, 1),
            //            new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y),
            //            new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height));

            //        // dibujar solamente la línea vertical de la celda
            //        //e.Graphics.DrawLine(new Pen(SystemColors.ActiveBorder),
            //        //    new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y),
            //        //    new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height));

            //        //Updating the maximum cell height for wrapped text inside the row:
            //        // it will later be set to the row height to avoid the flickering
            //        // that would occur by setting the height multiple times.
            //        _rowMaxHeight = (Math.Ceiling(sWrapped.Height) > _rowMaxHeight) ? (int)Math.Ceiling(sWrapped.Height) : _rowMaxHeight;
            //        // The text is generated inside the row.
            //        e.Graphics.DrawString(e.Value.ToString(), dgvDetalle.Font, fontBrush, e.CellBounds, StringFormat.GenericDefault);
            //        e.Handled = true;
            //    }
            //}
            //if (e.ColumnIndex == dgvDetalle.ColumnCount - 1 && _rowMaxHeight > 0 && _rowMaxHeight != dgvDetalle.Rows[e.RowIndex].Height)
            //{
            //    // Setting the height only in the last cell, when the full row has been
            //    // painted, helps to avoid flickering when more than one row 
            //    // needs the wrap.
            //    dgvDetalle.Rows[e.RowIndex].Height = (_rowMaxHeight > _rowDefaultHeight) ? _rowMaxHeight : _rowDefaultHeight;
            //}
            ////}
        }

        #endregion

        #region Procedimientos Heredados

        public override void Imprimir()
        {
            try
            {
                List<UsuarioImpresorasE> oListaImpresoras = AgenteGeneral.Proxy.ListarUsuarioImpresoras(VariablesLocales.SesionUsuario.IdPersona);

                UsuarioImpresorasE printer = oListaImpresoras.Find
                (
                    delegate (UsuarioImpresorasE ui) { return ui.ParaTicket == true; }
                );

                if (printer == null)
                {
                    MessageBox.Show("Falta Configurar La Impresora para Ticket de Este Usuario");
                    return;
                }

                //Creamos una instancia d ela clase CrearTicket
                CrearTicketVenta Ticket = new CrearTicketVenta();
                MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                    where x.idMoneda == DocumentoPrevio.idMoneda
                                    select x).SingleOrDefault();

                //Datos de la cabecera del Ticket.
                //Ticket.TextoIzquierda("1B 1D 74 32");
                Ticket.TextoCentro(VariablesLocales.SesionUsuario.Empresa.RazonSocial);
                Ticket.TextoCentro(VariablesLocales.SesionLocal.Nombre);
                Ticket.TextoCentro(VariablesLocales.SesionUsuario.Empresa.Direccion);
                Ticket.TextoIzquierda(""); //Espacio en blanco

                if (DocumentoPrevio.idDocumento == "FV")
                {
                    Ticket.TextoCentro("FACTURA ELECTRONICA");
                }
                else
                {
                    Ticket.TextoCentro("BOLETA DE VENTA ELECTRONICA");
                }

                Ticket.LineasIgual(); //Lineas

                Ticket.TextoExtremos("Fecha: " + VariablesLocales.FechaHoy.ToString("dd/MM/yyyy"), "HORA: " + VariablesLocales.FechaHoy.ToString("hh:mm:ss tt"));
                Ticket.TextoIzquierda("R.U.C: " + VariablesLocales.SesionUsuario.Empresa.RUC);
                Ticket.TextoIzquierda("Nro.DOCUM: " + DocumentoPrevio.numSerie + "-" + DocumentoPrevio.numDocumento);//, "FECHA: " + VariablesLocales.FechaHoy.ToString("G"));

                if (ValoresDocumento != null)
                {
                    Ticket.TextoIzquierda("CAJA: " + ValoresDocumento.numCaja);
                    Ticket.TextoIzquierda("CAJERO: " + DocumentoPrevio.nomVendedor);
                }
                else
                {
                    Ticket.TextoIzquierda("CAJA:");
                    Ticket.TextoIzquierda("CAJERO:");
                }

                Ticket.TextoIzquierda(""); //Espacio en blanco
                Ticket.LineasIgual(); //Lineas
                Ticket.EncabezadoVenta("CANT  PRODUCTO                     TOTAL");
                Ticket.LineasIgual();

                foreach (EmisionDocumentoDetE item in DocumentoPrevio.ListaItemsDocumento)//dgvLista es el nombre del datagridview
                {
                    Ticket.AgregaArticuloS3(Convert.ToDecimal(item.Cantidad.ToString("N2")), item.nomArticulo, decimal.Round(item.Total, 2));
                }

                Ticket.LineasIgual();
                Ticket.AgregarTotales(String.Format("Dscto: {0} ", oMoneda.desAbreviatura), decimal.Round(DocumentoPrevio.totDscto1, 2));
                Ticket.AgregarTotales(String.Format("Sub-Total: {0} ", oMoneda.desAbreviatura), decimal.Round(DocumentoPrevio.totsubTotal, 2));
                Ticket.AgregarTotales("ISC " + oMoneda.desAbreviatura + " ", Convert.ToDecimal(DocumentoPrevio.totIsc));//La M indica que es un decimal en C#

                if (VariablesLocales.oListaImpuestos != null && VariablesLocales.oListaImpuestos.Count > 0)
                {
                    Decimal IgvPor = VariablesLocales.oListaImpuestos[0].Porcentaje;
                    Ticket.AgregarTotales("I.G.V. " + IgvPor.ToString("N2") + "% " + oMoneda.desAbreviatura + " ", decimal.Round(Convert.ToDecimal(DocumentoPrevio.totIgv), 2));//La M indica que es un decimal en C#
                }
                else
                {
                    Global.MensajeComunicacion("No esta configurado el párametro del IGV en la Ventana de Impuestos.");
                    Ticket.AgregarTotales("I.G.V. " + oMoneda.desAbreviatura + " ", Convert.ToDecimal(DocumentoPrevio.totIgv));
                }

                Ticket.LineasIgual();
                Decimal MontoVuelto = DocumentoPrevio.ListaCancelaciones.Where(e => e.idMedioPago == 1).Sum(e => e.Vuelto);
                Ticket.AgregarTotales(String.Format("TOTAL: {0} ", oMoneda.desAbreviatura), decimal.Round(DocumentoPrevio.totTotal, 2));
                Ticket.AgregarTotales(String.Format("VUELTO: {0} ", oMoneda.desAbreviatura), decimal.Round(MontoVuelto, 2));
                Ticket.LineasIgual();

                Ticket.TextoIzquierda(NumeroLetras.enLetras(DocumentoPrevio.totTotal.ToString()) + oMoneda.desMoneda);
                Ticket.LineasIgual();

                //Decimal TotalEfectivo = DocumentoPrevio.ListaCancelaciones.Where(e => e.idMedioPago == 1).Sum(e => e.MontoAplicar);
                //Decimal TotalTarjetas = DocumentoPrevio.ListaCancelaciones.Where(t => t.idMedioPago != 1).Sum(t => t.MontoAplicar);

                //if (TotalEfectivo > 0 && TotalTarjetas == 0)
                //{
                //    Ticket.TextoIzquierda("FORMA DE PAGO: EN EFECTIVO");
                //    Ticket.TextoExtremos("EFECTIVO: " + TotalEfectivo.ToString("N2"), "TARJETA: 0.00");
                //}
                //else if (TotalEfectivo == 0 && TotalTarjetas > 0)
                //{
                //    Ticket.TextoIzquierda("FORMA DE PAGO: CON TARJETA DE CREDITO");
                //    Ticket.TextoExtremos("EFECTIVO: 0.00", "TARJETA: " + TotalTarjetas.ToString("N2"));
                //}
                //else if (TotalEfectivo > 0 && TotalTarjetas > 0)
                //{
                //    Ticket.TextoIzquierda("FORMA DE PAGO: EN EFECTIVO Y TARJETA");
                //    Ticket.TextoExtremos("EFECTIVO: " + TotalEfectivo.ToString("N2"), "TARJETA: " + TotalTarjetas.ToString("N2"));
                //}

                //Ticket.LineasIgual();

                if (DocumentoPrevio.idDocumento == "FV")
                {
                    Ticket.TextoIzquierda("RAZON SOCIAL: ");
                    Ticket.TextoIzquierda(DocumentoPrevio.RazonSocial);
                    Ticket.TextoIzquierda("R.U.C.: ");
                    Ticket.TextoIzquierda(DocumentoPrevio.numRuc);
                }
                else
                {
                    Ticket.TextoIzquierda("NOMBRES: ");
                    Ticket.TextoIzquierda(DocumentoPrevio.RazonSocial);
                    Ticket.TextoIzquierda("Doc.ID.: ");
                    Ticket.TextoIzquierda(DocumentoPrevio.numRuc);
                }

                Ticket.TextoIzquierda("DIRECCION:");
                Ticket.TextoIzquierda(DocumentoPrevio.Direccion);
                Ticket.LineasIgual();

                if (VariablesLocales.oVenParametros != null)
                {
                    if (!String.IsNullOrWhiteSpace(VariablesLocales.oVenParametros.Glosa))
                    {
                        String Parrafo = VariablesLocales.oVenParametros.Glosa;
                        List<String> Parrafos = new List<string>(VariablesLocales.oVenParametros.Glosa.Split('|'));

                        foreach (String item in Parrafos)
                        {
                            Ticket.TextoIzquierda(item.Trim());
                        }
                    }
                    else
                    {
                        Ticket.TextoIzquierda("");
                    }
                }
                else
                {
                    Ticket.TextoIzquierda("");
                }

                Ticket.TextoIzquierda("");
                Ticket.TextoIzquierda("");
                Ticket.TextoIzquierda("");
                Ticket.TextoIzquierda("");
                Ticket.TextoIzquierda("");
                Ticket.TextoIzquierda("");
                Ticket.TextoIzquierda("");
                Ticket.TextoIzquierda("");
                Ticket.TextoIzquierda("");
                Ticket.TextoIzquierda("");

                Ticket.CortaTicket();

                //String Ruta = DevuelveRutaArchivo(DocumentoPrevio.fecEmision, DocumentoPrevio.idDocumento + " " + DocumentoPrevio.numSerie + "-" + DocumentoPrevio.numDocumento);
                //Ticket.ImprimirTicket(printer.Descripcion, 2, Ruta);//Nombre de la impresora ticketera, Metodo, l¿la ruta donde se va a crear el archivo.

                ////Cambiando el estado del documento si es la primera vez...
                //if (DocumentoPrevio.indEstado == "C")
                //{
                //    AgenteVentas.Proxy.CambiarEstadoDocumento(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie, DocumentoPrevio.numDocumento, EnumEstadoDocumentos.E.ToString(), VariablesLocales.SesionUsuario.Credencial);
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
                DialogResult = DialogResult.Cancel;
            }
        }

        #endregion

        #region Eventos

        private void frmTicketBoletaDellas_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;

                if (DocumentoPrevio != null)
                {
                    if (DocumentoPrevio.idDocumento == "FV")
                    {
                        ValoresDocumento = (from x in VariablesLocales.ListaDetalleNumControl
                                            where x.idControl == 1
                                            && x.idDocumento == DocumentoPrevio.idDocumento
                                            && x.Serie == DocumentoPrevio.numSerie
                                            select x).FirstOrDefault();
                    }
                    else
                    {
                        ValoresDocumento = (from x in VariablesLocales.ListaDetalleNumControl
                                            where x.idControl == 2
                                            && x.idDocumento == DocumentoPrevio.idDocumento
                                            && x.Serie == DocumentoPrevio.numSerie
                                            select x).FirstOrDefault();
                    }
                }

                LlenarDatos();

                //printDocumento.PrintPage += new PrintPageEventHandler(printDocumento_PrintPage);
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
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Imprimir();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

    }
}
