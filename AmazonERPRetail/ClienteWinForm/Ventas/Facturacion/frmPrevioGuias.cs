using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using ClienteWinForm.Impresion;
using System.Drawing.Printing;
using System.IO;
using ClienteWinForm.Generales;

namespace ClienteWinForm.Ventas.Facturacion
{
    public partial class frmPrevioGuias : FrmMantenimientoBase
    {

        public frmPrevioGuias(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String Numero)
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            
            pFormatoGrid(dgvDetalle);
            DocumentoPrevio = AgenteVentas.Proxy.RecuperarDocumentoCompleto(idEmpresa, idLocal, idDocumento, Serie, Numero);
            dgvDetalle.Columns[0].Width = 80;
            dgvDetalle.Columns[1].Width = 650;

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
        String RutaImagen = @"C:\AmazonErp\Logo\";
        PrintDocument printDocumento = new PrintDocument();

        #endregion

        #region Procedimientos de Usuario

        void LlenarDatos()
        {
            if (DocumentoPrevio != null)
            {
                String Tipo = String.Empty;
                DateTime fecTraslado = Convert.ToDateTime(DocumentoPrevio.fecTraslado);

                lblRuc.Text = "R.U.C. " + VariablesLocales.SesionUsuario.Empresa.RUC;
                lblSerie.Text = DocumentoPrevio.numSerie + " - ";
                lblNumero.Text = "N° " + DocumentoPrevio.numDocumento;
                lblSenior.Text = DocumentoPrevio.RazonSocial;
                lblRucCliente.Text = DocumentoPrevio.numRuc;
                lblPartida.Text = DocumentoPrevio.PuntoPartida;
                lblLlegada.Text = DocumentoPrevio.PuntoLlegada;
                lblFechaTraslado.Text = fecTraslado.ToString("dd/MM/yyyy");
                lblfactura.Text = DocumentoPrevio.serDocumentoRef + " " + DocumentoPrevio.numDocumentoRef;

                if (!String.IsNullOrEmpty(DocumentoPrevio.fecDocumentoRef.ToString()))
                {
                    lblFecFactura.Text = Convert.ToDateTime(DocumentoPrevio.fecDocumentoRef).ToString();
                }
                
                lblTransporte.Text = DocumentoPrevio.RazonSocialTransp;
                lblDomicilio.Text = DocumentoPrevio.DireccionTransp;
                lblRucTransporte.Text = DocumentoPrevio.RucTransp;
                lblInscripcion.Text = DocumentoPrevio.inscripTransp;
                lblPlaca.Text = DocumentoPrevio.PlacaTransp;
                lblPlacaRemolque.Text = DocumentoPrevio.PlacaRemolqueTransp;
                lblConfigVehicular.Text = String.Empty;
                lblLicencia.Text = DocumentoPrevio.LicenciaTransp;
                lblChofer.Text = DocumentoPrevio.ConductorTransp;

                if (DocumentoPrevio.idDocumento == EnumTipoDocumentoVenta.GV.ToString())
                {
                    lblGlosa.Visible = true;
                    lblGlosa.Text = DocumentoPrevio.Glosa;

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
                    case 1:
                    case 2:
                        chkVenta.Checked = true;
                        break;
                    case 3:
                        chkCompra.Checked = true;
                        break;
                    case 4:
                        chkConsignacion.Checked = true;
                        break;
                    case 5:
                        chkDevolucion.Checked = true;
                        break;
                    case 6:
                        chkTrasEstablecimientos.Checked = true;
                        break;
                    case 7:
                        chkTransformacion.Checked = true;
                        break;
                    case 10:
                        chkTraslado.Checked = true;
                        break;
                    case 12:
                        chkExportacion.Checked = true;
                        break;
                    case 14:
                        chkOtros.Checked = true;
                        lblOtros.Text = DocumentoPrevio.OtroTipoTraslado;
                        break;
                    default:
                        break;
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
            oDgv.ColumnHeadersHeight = 26;
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

        Boolean VerificarImpresora(String Nombre)
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
                            if (DocumentoPrevio.idDocumento != EnumTipoDocumentoVenta.GV.ToString())
                            {
                                ImpresionManager.RecuperarUtilImpresion(VariablesLocales.SesionUsuario.Empresa.RUC).ImprimirGuiaRemision(DocumentoPrevio, NombreImpresora, (int)EnumTipoImpresionGuiaRemision.TRASLADO);
                            }
                            else
                            {
                                ImpresionManager.RecuperarUtilImpresion(VariablesLocales.SesionUsuario.Empresa.RUC).ImprimirGuiaRemision(DocumentoPrevio, NombreImpresora, (int)EnumTipoImpresionGuiaRemision.EXPORTACION);
                            }

                            if (DocumentoPrevio.indEstado == EnumEstadoDocumentos.C.ToString())
                            {
                                AgenteVentas.Proxy.CambiarEstadoDocumento(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie, DocumentoPrevio.numDocumento, EnumEstadoDocumentos.E.ToString(), VariablesLocales.SesionUsuario.Credencial);
                            }
                            else if (DocumentoPrevio.indEstado == EnumEstadoDocumentos.F.ToString())
                            {
                                AgenteVentas.Proxy.CambiarEstadoDocumento(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie, DocumentoPrevio.numDocumento, EnumEstadoDocumentos.F.ToString(), VariablesLocales.SesionUsuario.Credencial);
                            }
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

        #region Eventos

        private void frmPrevioGuias_Load(object sender, EventArgs e)
        {
            if (DocumentoPrevio != null)
            {
                CargarValores(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, 3, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie);
            }

            LlenarDatos();
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }

        private void dgvDetalle_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // comprobar que la fila y columna son las adecuadas
            if (e.RowIndex >= 0 && (e.ColumnIndex == 0))
            {
                Color clrFondoCelda;
                Color clrTextoCelda;
                // en función de si la celda está o no seleccionada establecer los colores
                //if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
                //{
                //    clrFondoCelda = SystemColors.Highlight;
                //    clrTextoCelda = SystemColors.Window;
                //}
                //else
                //{
                clrFondoCelda = SystemColors.Window;
                clrTextoCelda = SystemColors.WindowText;
                //}

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
                        clrTextoCelda);
                }

                e.Handled = true;
            }

            if (e.RowIndex >= 0 && (e.ColumnIndex == 1))
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
                        TextFormatFlags.Left);
                }

                e.Handled = true;
            }
        }

        #endregion

    }
}
