using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
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
    public partial class frmPrevioFacturaExportacion : FrmMantenimientoBase
    {

        public frmPrevioFacturaExportacion(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String Numero)
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            pFormatoGrid(dgvDetalle);
            DocumentoPrevio = AgenteVentas.Proxy.RecuperarDocumentoCompleto(idEmpresa, idLocal, idDocumento, Serie, Numero);
            DocumentoPrevio.ListaItemsDocumento = AgenteVentas.Proxy.ObtenerEmisionDocumentoDet2(idEmpresa, idLocal, idDocumento, Serie, Numero);

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
        List<EmisionDocumentoDetE> documentoDet =null;
        
        NumControlDetE ValoresDocumento = null;
        String RutaImagen = String.Empty;
        PrintDocument printDocumento = new PrintDocument();

        #endregion

        #region Procedimientos de Usuario

        void LlenarDatos()
        {
            String Tipo = String.Empty;
            DateTime fecTraslado = Convert.ToDateTime(DocumentoPrevio.fecTraslado);
            DateTime fecDocumentoRef = Convert.ToDateTime(DocumentoPrevio.fecDocumentoRef);
            DateTime Fecha = Convert.ToDateTime(DocumentoPrevio.fecEmision);
            Decimal numDecimal = 0;
            Decimal totIgv = 0;
            String Moneda = String.Empty;
            String MonedaIngles = String.Empty;
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == DocumentoPrevio.idMoneda
                                select x).SingleOrDefault();

            lblFecha.Text = "Lima,          " + Fecha.ToString("dd") + "          de          " + ObtenerMes(Fecha.ToString("MM")) + "          del          " + Fecha.ToString("yyyy");
            lblRuc.Text = "R.U.C. " + VariablesLocales.SesionUsuario.Empresa.RUC;
            lblSerie.Text = DocumentoPrevio.numSerie + " - ";
            lblNumero.Text = "N° " + DocumentoPrevio.numDocumento;

            lblSenior.Text = DocumentoPrevio.RazonSocial;
            lblDireccion.Text = DocumentoPrevio.Direccion;
            lblRef.Text = DocumentoPrevio.serDocumentoRef + " " + DocumentoPrevio.numDocumentoRef;
            lblGuia.Text = String.Empty;
            lblBook.Text = DocumentoPrevio.numReserva;
            lblDesTotal.Text = "Total " + oMoneda.desAbreviatura;
            lblDesValor.Text = "Valor Venta " + oMoneda.desAbreviatura;
            lblGlosa.Text = DocumentoPrevio.Glosa;

            List<EmisionDocumentoDetE> ListaItems = new List<EmisionDocumentoDetE>(DocumentoPrevio.ListaItemsDocumento);
            List<EmisionDocumentoDetE> nuevoItems =new List<EmisionDocumentoDetE>();
            
            if (ListaItems.Count <= 20)
            {


                //for (int i = 0; i <= ListaItems.Count; i++)
                //{
                    //EmisionDocumentoDetE det = new EmisionDocumentoDetE();
                    foreach(EmisionDocumentoDetE item in ListaItems)
                    {
                         if(item.idTipoArticulo==(333011))
                         {
                            item.nomArticulo = item.codArticulo;
    
                         }
                    nuevoItems.Add(item);

                }
                //if (det.Cantidad == 0)
                //{
                //    det.Cantidad = 0;
                //}




                //}




            }

            bsDetalle.DataSource = nuevoItems;
            bsDetalle.ResetBindings(false);

            numDecimal = Convert.ToDecimal(DocumentoPrevio.totTotal);
            lblValorVenta.Text = numDecimal.ToString("N2");
            totIgv = Convert.ToDecimal(DocumentoPrevio.totIgv);
            lblIgv.Text = totIgv.ToString("N2");
            lblTotal.Text = numDecimal.ToString("N2");
                        
            Text = "Vista Previa - Factura " + Tipo + DocumentoPrevio.idDocumento + " " + DocumentoPrevio.numSerie + "-" + DocumentoPrevio.numDocumento;
            Moneda = " " + oMoneda.desMoneda.ToUpper();
            MonedaIngles = " US DOLLARS";
            lblMontoLetras.Text = "SON:              TOTAL: " + Impresion.Mercantil.Impresion.enLetras(DocumentoPrevio.totTotal.ToString()) + Moneda;
            lblMontoIngles.Text = "TOTAL: " + Impresion.Mercantil.Impresion.enIngles(DocumentoPrevio.totTotal.ToString()) + MonedaIngles;
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

        String ObtenerMes(string mes)
        {
            switch (mes)
            {
                case "01": //Fundo San Miguel
                    return "ENERO";
                case "02":
                    return "FEBRERO";
                case "03":
                    return "MARZO";
                case "04":
                    return "ABRIL";
                case "05":
                    return "MAYO";
                case "06":
                    return "JUNIO";
                case "07":
                    return "JULIO";
                case "08":
                    return "AGOSTO";
                case "09":
                    return "SETIEMBRE";
                case "10":
                    return "OCTUBRE";
                case "11":
                    return "NOVIENBRE";
                default:
                    return "DICIEMBRE";
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

                    String ConCtaCte = Variables.SI;
                    String ConCobranza = Variables.SI;


                    if (!VerificarImpresora(NombreImpresora))
                    {
                        return;
                    }

                    if (oFrm.oImpresora.PorDefecto) //Solo cuando la impresora es la principal y es matricial, se emite...
                    {
                    
                        if (oFrm.oImpresora.EsMatricial)
                        {
                            ImpresionManager.RecuperarUtilImpresion(VariablesLocales.SesionUsuario.Empresa.RUC).ImprimirFacturas(DocumentoPrevio, NombreImpresora);

                       

                            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20452630886") //Fundo San Miguel
                            {
                                ConCtaCte = Variables.NO;
                                ConCobranza = Variables.NO;
                            }
                            //decimal cantidad = documentoDet.Cantidad;
                            //string item = documentoDet.Item;

                      
                          

                        }
                        else
                        {
                            printDocumento.PrinterSettings.PrinterName = NombreImpresora;
                            printDocumento.DocumentName = "Impresion de Nota de Crédito";
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
                            printDocumento.DocumentName = "Impresion de Nota de Crédito";
                            printDocumento.Print();
                        }
                    }

                    //Cambiando el estado del documento...
                    AgenteVentas.Proxy.CambiarEstadoDocumento(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie,
                                                               DocumentoPrevio.numDocumento, EnumEstadoDocumentos.F.ToString(), VariablesLocales.SesionUsuario.Credencial,
                                                                ConCtaCte, ConCobranza);
                 

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.Cancel;
                Global.MensajeError(ex.Message);
            }
        }

   
        #endregion

        #region Eventos

        private void frmPrevioFacturaExportacion_Load(object sender, EventArgs e)
        {
            try
            {
                if (DocumentoPrevio != null)
                {
                    CargarValores(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, 1, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie);
                }

                dgvDetalle.Columns[0].Width = 60;
                dgvDetalle.Columns[1].Width = 530;
                dgvDetalle.Columns[2].Width = 65;
                dgvDetalle.Columns[3].Width = 65;

                LlenarDatos();
                BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                Grid = false;



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
            // comprobar que la fila y columna son las adecuadas
            //if (e.RowIndex >= 0 && (e.ColumnIndex == 0))
            //{
            //    Color clrFondoCelda;
            //    Color clrTextoCelda;
                
            //    clrFondoCelda = SystemColors.Window;
            //    clrTextoCelda = SystemColors.WindowText;

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
            //}

            //if (e.RowIndex >= 0 && (e.ColumnIndex == 1))
            //{
            //    Color clrFondoCelda;
            //    Color clrTextoCelda;

            //    clrFondoCelda = SystemColors.Window;
            //    clrTextoCelda = SystemColors.WindowText;

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
            //            clrTextoCelda,
            //            TextFormatFlags.Left);
            //    }                
            //}


        }

        #endregion

    }
}
