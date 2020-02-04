using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Util;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Impresion;

namespace ClienteWinForm.Ventas
{
    public partial class frmPuntoVentas : Form, IAgregar<PedidoDetE>
    {

        public frmPuntoVentas()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            ptoVenta = VariablesLocales.oSalesPoint;
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
            
            Formato(DgvDetalle);
            ptoVenta = VariablesLocales.oSalesPoint;
            oListaPrecio = AgenteVentas.Proxy.ListarPrecioPorTipo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, true);

            if (oListaPrecio.Count > 0)
            {
                this.Shown += new EventHandler(FrmPuntoVentas_Shown);
                //oListaArticulos = AgenteMaestro.Proxy.ArticulosPorListaPrecioStock2(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, DtpFecha.Value.ToString("yyyy"), DtpFecha.Value.ToString("MM"), oListaPrecio[0].idListaPrecio);

                //if (oListaArticulos.Count > 0)
                //{
                //    this.Shown += new EventHandler(FrmPuntoVentas_Shown);
                //}
                //else
                //{
                //    Global.MensajeFault("La Lista de Precios no tiene articulos o los articulos estan sin stock.");
                //}
            }
            else
            {
                BtNuevo.Enabled = false;
                BtObtener.Enabled = false;
                BtAnular.Enabled = false;
                BtImprimir.Enabled = false;
                BtAgregar.Enabled = false;
                BtQuitar.Enabled = false;
                BtGuardar.Enabled = false;
                //TxtRuc.Enabled = false;
                //TxtRazonSocial.Enabled = false;
                //TxtDireccion.Enabled = false;
                PnlCliente.Enabled = false;
                PnlDetalle.Enabled = false;
                Global.MensajeFault("No se ha configurado ningúna Lista de Precios para el Punto de Venta.");
                return;
            }

            Global.CrearToolTip(BtNuevo, "Presionar Tecla F2");
            Global.CrearToolTip(BtGuardar, "Presionar Tecla F5");
            Global.CrearToolTip(BtAnular, "Presionar Tecla F7");
            Global.CrearToolTip(BtAgregar, "Presionar Tecla INS");
            Global.CrearToolTip(BtQuitar, "Presionar Tecla DEL");
            Global.CrearToolTip(BtImprimir, "Presionar Tecla F9");
            Global.CrearToolTip(BtCobrar, "Presionar Tecla F12");
        }

        #region DLL's

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

        #endregion
        
        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<ListaPrecioE> oListaPrecio = null;
        PedidoCabE PedidoPtoVta = null;
        Decimal totdsc1 = 0;
        Decimal totdsc2 = 0;
        Decimal totdsc3 = 0;
        SalesPointE ptoVenta = null;
        TipoCambioE oTica = null;

        #endregion

        #region Procedimientos Heredados

        public void Nuevo()
        {
            TxtRuc.TextChanged -= new EventHandler(TxtRuc_TextChanged);
            TxtRazonSocial.TextChanged -= new EventHandler(TxtRazonSocial_TextChanged);

            PedidoPtoVta = new PedidoCabE()
            {
                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                idLocal = VariablesLocales.SesionLocal.IdLocal,
                //codPedidoCad = AgenteVentas.Proxy.GenerarNroPedido(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, DtpFecha.Value.Date),
                indCotPed = "P",
                idFacturar = VariablesLocales.oVenParametros.ClienteVarios,
                Estado = string.Empty,
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
            };

            LblPedido.Text = "N° PEDIDO ";// + PedidoPtoVta.codPedidoCad;
            TxtRuc.Tag = VariablesLocales.oVenParametros.ClienteVarios;
            TxtRuc.Text = VariablesLocales.oVenParametros.RUC;
            TxtRazonSocial.Text = VariablesLocales.oVenParametros.RazonSocial;
            TxtDireccion.Text = string.Empty;
            LblIdPedido.Text = "ID: " + PedidoPtoVta.idPedido.ToString();

            BsDetalle.DataSource = PedidoPtoVta.ListaPedidoDet;
            BsDetalle.ResetBindings(false);
            SumarTotal(PedidoPtoVta.ListaPedidoDet);

            TxtRuc.TextChanged += new EventHandler(TxtRuc_TextChanged);
            TxtRazonSocial.TextChanged += new EventHandler(TxtRazonSocial_TextChanged);
        }

        public void Grabar()
        {
            if (ValidarGrabacion())
            {
                if (Global.MensajeConfirmacion("Se va a guardar el Pedido. Continuar??") == DialogResult.Yes)
                {
                    Datos();
                    PedidoPtoVta = AgenteVentas.Proxy.GrabarPedidoPtoVta(PedidoPtoVta);
                    PedidoPtoVta.Estado = "P";
                    LblPedido.Text = "N° PEDIDO " + PedidoPtoVta.codPedidoCad;
                    LblIdPedido.Text = "ID: " + PedidoPtoVta.idPedido.ToString();

                    if (!ptoVenta.PtoCobro)
                    {
                        Nuevo();
                        AgregarDetalle();
                    }
                    else
                    {
                        Cobranza();
                    }
                }
            }
        }

        public void AgregarDetalle()
        {
            List<PedidoDetE> ListaTemp = new List<PedidoDetE>((List<PedidoDetE>)BsDetalle.List);
            FrmPuntoVentasArticulos oFrm = new FrmPuntoVentasArticulos(this, oListaPrecio, DtpFecha.Value.Date, ListaTemp);

            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                if (DgvDetalle.Rows.Count > 0)
                {
                    BsDetalle.MoveLast();
                    DgvDetalle.Focus();
                    DgvDetalle.CurrentRow.Cells["Cantidad"].Selected = true;
                }
            }
        }

        public void QuitarDetalle()
        {
            PedidoPtoVta.ListaPedidoDet.Remove((PedidoDetE)BsDetalle.Current);
            BsDetalle.DataSource = PedidoPtoVta.ListaPedidoDet;
            BsDetalle.ResetBindings(false);

            SumarTotal(PedidoPtoVta.ListaPedidoDet);
        }

        public bool ValidarGrabacion()
        {
            if (LblTica.Text == "0.000")
            {
                Global.MensajeFault("Debe ingresar el Tipo de cambio del dia.");
                return false;
            }

            if (TxtRuc.Text.Length == 11)
            {
                if (string.IsNullOrWhiteSpace(TxtRazonSocial.Text))
                {
                    Global.MensajeFault("Debe ingresar algún cliente.");
                    return false;
                }

                if (Convert.ToInt32(TxtRuc.Tag) == 0)
                {
                    Global.MensajeFault("Debe agregar el cliente antes de grabar el Pedido.");
                    return false;
                }

                if (TxtRuc.Text.Substring(0, 1) != "1" && TxtRuc.Text.Substring(0, 1) != "2")
                {

                }
            }
            else
            {
                decimal.TryParse(lblTotal.Text, out decimal total);

                if (total > VariablesLocales.oVenParametros.MontoBoleta)
                {
                    if (string.IsNullOrWhiteSpace(TxtRuc.Text))
                    {
                        Global.MensajeFault(string.Format("El monto supera los {0}, es obligatorio colocar una razón social.", VariablesLocales.oVenParametros.MontoBoleta.ToString("N2")));
                        return false;
                    }

                    if (VariablesLocales.oVenParametros.ClienteVarios == 0)
                    {
                        Global.MensajeFault("Falta configurar el auxiliar para Clientes Varios en los parámetros de ventas.");
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        #region Procedimientos de Usuario

        private void Datos()
        {
            PedidoPtoVta.FecPedido = DtpFecha.Value.ToString("yyyyMMdd");
            PedidoPtoVta.idFacturar = Convert.ToInt32(TxtRuc.Tag);
            PedidoPtoVta.RucCliente = TxtRuc.Text.Trim();
            PedidoPtoVta.RazonSocial = TxtRazonSocial.Text.Trim();
            PedidoPtoVta.DireccionCompleta = TxtDireccion.Text.Trim();
            PedidoPtoVta.idMoneda = VariablesLocales.oVenParametros.monPedido;
            PedidoPtoVta.desMoneda = (from x in VariablesLocales.ListaMonedas where x.idMoneda == PedidoPtoVta.idMoneda select x.desAbreviatura).FirstOrDefault();
            PedidoPtoVta.Observacion = string.Empty;
            PedidoPtoVta.idTipCondicion = (int)EnumTipoCondicionVenta.FacBol;
            PedidoPtoVta.idCondicion = 1;
            PedidoPtoVta.totsubTotal = Convert.ToDecimal(lblSubTotal.Text);
            PedidoPtoVta.totDscto1 = totdsc1;
            PedidoPtoVta.totDscto2 = totdsc2;
            PedidoPtoVta.totDscto3 = totdsc3;
            PedidoPtoVta.totIgv = Convert.ToDecimal(lblIgv.Text);
            PedidoPtoVta.totIsc = 0M;
            PedidoPtoVta.totTotal = Convert.ToDecimal(lblTotal.Text);
            PedidoPtoVta.Redondeo = Convert.ToDecimal(LblRedondeo.Text);
            ParTabla tabla;

            if (TxtRuc.Text.Length == 11 && (TxtRuc.Text.Substring(0, 1) == "2" || TxtRuc.Text.Substring(0, 1) == "1"))
            {
                tabla = AgenteGeneral.Proxy.ParTablaPorNemo("TIPFACT");
            }
            else
            {
                tabla = AgenteGeneral.Proxy.ParTablaPorNemo("TIPBOL");
            }

            PedidoPtoVta.TipoDoc = tabla.IdParTabla;

            if (PedidoPtoVta.idPedido > 0)
            {
                PedidoPtoVta.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        public void AgregarFila(PedidoDetE DetalleItem)
        {
            if (PedidoPtoVta.ListaPedidoDet.Count == 0)
            {
                DetalleItem.idItem = 1;
            }
            else
            {
                DetalleItem.idItem = Convert.ToInt32(PedidoPtoVta.ListaPedidoDet.Max(z => z.idItem)) + 1;
            }

            if (DetalleItem.indDetraccion)
            {
                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(DtpFecha.Value.Date, DetalleItem.tipDetraccion);

                if (DetraccionDet != null && DetraccionDet.Count > 0)
                {
                    DetalleItem.TasaDetraccion = DetraccionDet[0].Porcentaje;
                }
                else
                {
                    DetalleItem.TasaDetraccion = 0M;
                }
            }

            BsDetalle.EndEdit();
            PedidoPtoVta.ListaPedidoDet.Add(DetalleItem);
            BsDetalle.DataSource = PedidoPtoVta.ListaPedidoDet;
            BsDetalle.ResetBindings(false);
            BsDetalle.MoveLast();
            SumarTotal(PedidoPtoVta.ListaPedidoDet);
        }

        private void SumarTotal(List<PedidoDetE> oListaDetalle)
        {
            if (oListaDetalle != null && oListaDetalle.Count > Variables.Cero)
            {
                Decimal SubTotal = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.subTotal).Sum(), 2);
                Decimal ValorGravado = Decimal.Round((from x in oListaDetalle where x.flgIgv == true && x.indCalculo == true select x.subTotal).Sum(), 2);
                Decimal ValorNoGravado = Decimal.Round((from x in oListaDetalle where x.flgIgv == false && x.indCalculo == true select x.subTotal).Sum(), 2);
                Decimal Igv = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Igv).Sum(), 2);
                //Decimal Isc = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Isc).Sum(), 2);
                totdsc1 = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Dscto1).Sum(), 2);
                totdsc2 = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Dscto2).Sum(), 2);
                totdsc3 = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Dscto3).Sum(), 2);
                Decimal Dsctos = totdsc1 + totdsc2 + totdsc3;
                Decimal Total = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Total).Sum(), 2);

                lblGravado.Text = ValorGravado.ToString("###,###,##0.00");
                lblNoGravado.Text = ValorNoGravado.ToString("###,###,##0.00");
                //lblIsc.Text = Isc.ToString("N2");
                lblIgv.Text = Igv.ToString("###,###,##0.00");
                lblDsct.Text = Dsctos.ToString("###,###,##0.00");
                lblSubTotal.Text = SubTotal.ToString("###,###,##0.00");
                lblTotal.Text = Total.ToString("###,###,##0.00");

                decimal redondeo = Math.Round(Total % 0.1M, 2);
                LblRedondeo.Text = redondeo.ToString("###,###,##0.00");

                if (redondeo > 0)
                {
                    if (redondeo.ToString("#0.00") == "0.10")
                    {
                        redondeo = 0M;
                    }

                    lblTotal.Text = (Total - redondeo).ToString("###,###,##0.00");
                }
            }
            else
            {
                totdsc1 = 0;
                totdsc2 = 0;
                totdsc3 = 0;

                lblGravado.Text = "0.00";
                lblNoGravado.Text = "0.00";
                //lblIsc.Text = "0.00";
                lblIgv.Text = "0.00";
                lblDsct.Text = "0.00";
                lblSubTotal.Text = "0.00";
                lblTotal.Text = "0.00";
                LblRedondeo.Text = "0.00";
            }
        }

        private void Formato(DataGridView oDgv)
        {
            oDgv.SuspendLayout();
            //Barra de titulos
            oDgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(126, 212, 255),
                Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = Color.Black,
                WrapMode = DataGridViewTriState.True
            };

            //La primera columna
            oDgv.RowHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(126, 212, 255),
                Font = new Font("Tahoma", 8.25F),
                ForeColor = Color.Black
            };

            //Sin lineas
            oDgv.BorderStyle = BorderStyle.None;
            //Color de fondo
            oDgv.BackgroundColor = Color.Azure;
            //Deshabilitando el ajuste de columnas de la cabecera y la primera columna
            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //Alto de la la fila de titutlos
            oDgv.ColumnHeadersHeight = 36;
            //Ancho de la primera columna
            oDgv.RowHeadersWidth = 22;
            //Deshabilitando el ajuste de columnas y filas en el detalle
            oDgv.AllowUserToResizeColumns = false;
            oDgv.AllowUserToResizeRows = false;
            //Color de lineas
            oDgv.GridColor = Color.Black;
            //oDgv.BorderStyle = BorderStyle.Fixed3D;
            //Tipo de bordes en la cabecera
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //Seleccion multuiple
            oDgv.MultiSelect = false;
            //Quitando los bordes en el detalle
            oDgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            //Tipo de selección de las celdas
            //oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Tipo de letra del detalle
            oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 9.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            //Alternando colores en las filas
            //oDgv.RowsDefaultCellStyle.BackColor = Color.White;
            //oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //Color al seleccionar
            oDgv.DefaultCellStyle.SelectionForeColor = Color.White;
            oDgv.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 33;
            lineas.MinimumHeight = 10;

            //Formato por columnas
            oDgv.Columns["nomArticulo"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            oDgv.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            oDgv.Refresh();

            oDgv.ResumeLayout();

            //oDgv.DefaultCellStyle.ForeColor = Color.Blue;
            //oDgv.DefaultCellStyle.BackColor = Color.Beige;
        }

        private void Calcular()
        {
            DataGridViewRow Fila = DgvDetalle.CurrentRow;
            Int32 Fil = Fila.Index;
            decimal Cantidad = PedidoPtoVta.ListaPedidoDet[Fil].Cantidad;
            //decimal Precio = PedidoPtoVta.ListaPedidoDet[Fil].PrecioUnitario;
            decimal PrecioConImp = PedidoPtoVta.ListaPedidoDet[Fil].PrecioConImpuesto;
            decimal PrecioConDscto = PedidoPtoVta.ListaPedidoDet[Fil].PrecioConDscto;

            //string Tipo = Convert.ToString(PedidoPtoVta.ListaPedidoDet[Fil].TipoImpSelectivo);
            //decimal porDscto1 = PedidoPtoVta.ListaPedidoDet[Fil].porDscto1 / 100;
            //decimal porDscto2 = Convert.ToDecimal(PedidoPtoVta.ListaPedidoDet[Fil].porDscto2) / 100;
            //decimal porDscto3 = Convert.ToDecimal(PedidoPtoVta.ListaPedidoDet[Fil].porDscto3) / 100;
            decimal Dscto1; //(Precio * Cantidad) * porDscto1;
            //decimal Dscto2 = (Precio * Cantidad) * porDscto2;
            //decimal Dscto3 = (Precio * Cantidad) * porDscto3;
            decimal SubTotal; //(Precio * Cantidad) - Dscto1; // + Dscto2 + Dscto3);
            //decimal porIsc;
            //decimal ISC = 0;
            decimal porIgv = PedidoPtoVta.ListaPedidoDet[Fil].porIgv / 100;
            decimal Total;
            decimal IGV;

            //Si el precio incluye IGV
            if (PedidoPtoVta.ListaPedidoDet[Fil].flgIgv)
            {
                Total = PrecioConDscto * Cantidad;
                SubTotal = porIgv > 0 ? Total / (1 + porIgv) : Total;
                IGV = Total - SubTotal;
                Dscto1 = PrecioConImp - PrecioConDscto;
                //if (porDscto1 > 0)
                //{
                //    Dscto1 = (Cantidad * Precio) * porDscto1;
                //}

                //SubTotal = (Cantidad * Precio) - Dscto1;
                //IGV = SubTotal * porIgv;
                //Total = SubTotal + IGV;

                PedidoPtoVta.ListaPedidoDet[Fil].Cantidad = Cantidad;
                PedidoPtoVta.ListaPedidoDet[Fil].Dscto1 = decimal.Round(Dscto1, 2);
                PedidoPtoVta.ListaPedidoDet[Fil].Dscto2 = 0M;
                PedidoPtoVta.ListaPedidoDet[Fil].Dscto3 = 0M;
                PedidoPtoVta.ListaPedidoDet[Fil].subTotal = decimal.Round(SubTotal, 2);
                PedidoPtoVta.ListaPedidoDet[Fil].Isc = 0M;
                PedidoPtoVta.ListaPedidoDet[Fil].Igv = decimal.Round(IGV, 2);
                PedidoPtoVta.ListaPedidoDet[Fil].Total = decimal.Round(Total, 2);
            }
            else
            {
                //if (porDscto1 > 0)
                //{
                //    Dscto1 = (Cantidad * Precio) * porDscto1;
                //}

                //SubTotal = (Cantidad * Precio) - Dscto1;
                //IGV = 0M;
                //Total = SubTotal + IGV;

                //PedidoPtoVta.ListaPedidoDet[Fil].Cantidad = Cantidad;
                //PedidoPtoVta.ListaPedidoDet[Fil].Dscto1 = decimal.Round(Dscto1, 2);
                //PedidoPtoVta.ListaPedidoDet[Fil].Dscto2 = 0M;
                //PedidoPtoVta.ListaPedidoDet[Fil].Dscto3 = 0M;
                //PedidoPtoVta.ListaPedidoDet[Fil].subTotal = decimal.Round(SubTotal, 2);
                //PedidoPtoVta.ListaPedidoDet[Fil].Isc = 0M;
                //PedidoPtoVta.ListaPedidoDet[Fil].Igv = decimal.Round(IGV, 2);
                //PedidoPtoVta.ListaPedidoDet[Fil].Total = decimal.Round(Total, 2);
            }
            //if (Tipo == "L") //Pisco - Por Litro 1.5
            //{
            //    decimal cantLitros = Convert.ToDecimal(PedidoPtoVta.ListaPedidoDet[Fil].Capacidad);
            //    decimal Factor = Cantidad * cantLitros;

            //    porIsc = Convert.ToDecimal(PedidoPtoVta.ListaPedidoDet[Fil].porIsc);

            //    if (Precio == 0)
            //    {
            //        ISC = 0;
            //    }
            //    else
            //    {
            //        ISC = Factor * porIsc;
            //    }
            //}
            //else //Otros - Por porcentaje 25%
            //{
            //    porIsc = Convert.ToDecimal(PedidoPtoVta.ListaPedidoDet[Fil].porIsc) / 100;

            //    if (Precio == 0)
            //    {
            //        ISC = 0;
            //    }
            //    else
            //    {
            //        ISC = SubTotal * porIsc;
            //    }
            //}

            //if (!PedidoPtoVta.ListaPedidoDet[Fil].flgIgv)
            //{
            //    IGV = 0;
            //}
            //else
            //{
            //    IGV = SubTotal * porIgv;
            //}

            //decimal Total = SubTotal + IGV;

            //PedidoPtoVta.ListaPedidoDet[Fil].Cantidad = Cantidad;
            //PedidoPtoVta.ListaPedidoDet[Fil].Dscto1 = Dscto1;
            //PedidoPtoVta.ListaPedidoDet[Fil].Dscto2 = 0M;
            //PedidoPtoVta.ListaPedidoDet[Fil].Dscto3 = 0M;
            //PedidoPtoVta.ListaPedidoDet[Fil].subTotal = SubTotal;
            //PedidoPtoVta.ListaPedidoDet[Fil].Isc = 0M;
            //PedidoPtoVta.ListaPedidoDet[Fil].Igv = IGV;
            //PedidoPtoVta.ListaPedidoDet[Fil].Total = Total;

            SumarTotal(PedidoPtoVta.ListaPedidoDet);
        }

        private void CalcularPorColumna(int Columna) // 3=Cantidad 5=Precio 6=Dscto
        {
            Int32 Fil = DgvDetalle.CurrentRow.Index;
            decimal Cantidad = PedidoPtoVta.ListaPedidoDet[Fil].Cantidad;
            decimal Precio = PedidoPtoVta.ListaPedidoDet[Fil].PrecioUnitario;
            decimal PrecioConImp = PedidoPtoVta.ListaPedidoDet[Fil].PrecioConImpuesto;
            decimal PrecioConDscto = PedidoPtoVta.ListaPedidoDet[Fil].PrecioConDscto;
            //decimal PrecioReal = PedidoPtoVta.ListaPedidoDet[Fil].flgIgv == true ? PedidoPtoVta.ListaPedidoDet[Fil].PrecioConImpuesto : PedidoPtoVta.ListaPedidoDet[Fil].PrecioUnitario;
            //decimal PrecioTmp = PedidoPtoVta.ListaPedidoDet[Fil].PrecioUnitarioTmp;
            decimal Dscto = Convert.ToDecimal(PedidoPtoVta.ListaPedidoDet[Fil].Dscto1);
            //decimal DsctoTmp = Convert.ToDecimal(PedidoPtoVta.ListaPedidoDet[Fil].DsctoTmp);
            decimal porDscto = PedidoPtoVta.ListaPedidoDet[Fil].porDscto1 / 100;
            decimal SubTotal = 0M;
            //decimal ISC = 0M;
            decimal porIgv = Convert.ToDecimal(PedidoPtoVta.ListaPedidoDet[Fil].porIgv) / 100;
            decimal Total = 0M;
            decimal IGV = 0M;

            //Cantidad
            if (Columna == 3)
            {
                //if (porDscto > 0)
                //{
                //    Dscto = (Precio * Cantidad) * porDscto;
                //}
                if (PedidoPtoVta.ListaPedidoDet[Fil].flgIgv)
                {
                    Total = PrecioConDscto * Cantidad;
                    SubTotal = Total / (1 + porIgv);
                    IGV = Total - SubTotal;
                }
                else
                {
                    SubTotal = PrecioConDscto * Cantidad;
                    IGV = 0;
                    Total = SubTotal;
                }
                //SubTotal = PrecioConDscto * Cantidad;
            }

            //Precio
            if (Columna == 7)
            {
                if (PrecioConDscto < PrecioConImp)
                {
                    //if (PedidoPtoVta.ListaPedidoDet[Fil].flgIgv)
                    //{
                    //    Precio = PrecioConImp / (1 + (porIgv));
                    //}

                    //if (porDscto > 0)
                    //{
                    //    Dscto = (Precio * Cantidad) * porDscto;
                    //}

                    ////porDscto1 = decimal.Round((Dscto1 * 100M) / PrecioReal, 2);
                    //SubTotal = (Precio * Cantidad) - Dscto;
                    if (PedidoPtoVta.ListaPedidoDet[Fil].flgIgv)
                    {
                        porDscto = 1 - (PrecioConDscto / PrecioConImp);
                        Dscto = PrecioConImp - PrecioConDscto;
                        Total = PrecioConDscto * Cantidad;
                        SubTotal = Total / (1 + porIgv);
                        IGV = Total - SubTotal;
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (PedidoPtoVta.ListaPedidoDet[Fil].flgIgv)
                    {
                        Dscto = 0M;
                        porDscto = 0M;
                        Total = PrecioConDscto * Cantidad;
                        SubTotal = Total / (1 + porIgv);
                        IGV = Total - SubTotal;
                    }
                    else
                    {

                    }
                }
            }

            //Descuento
            if (Columna == 6)
            {
                //if (Dscto1 < DsctoTmp || Dscto1 > DsctoTmp)
                //{
                //PrecioReal -= Dscto1;
                //porDscto1 = decimal.Round((Dscto1 * 100M) / PrecioReal, 2);
                //Dscto1 = PrecioReal * porDscto1;
                //Dscto = (Precio * Cantidad) * porDscto;
                //SubTotal = (Precio * Cantidad) - Dscto;
                //}

                if (PedidoPtoVta.ListaPedidoDet[Fil].flgIgv)
                {
                    PrecioConDscto = PrecioConImp * (1 - porDscto);
                    Dscto = PrecioConImp - PrecioConDscto;
                    Total = PrecioConDscto * Cantidad;
                    SubTotal = Total / (1 + porIgv);
                    IGV = Total - SubTotal;
                }
                else
                {

                }
            }

            //decimal IGV;

            //if (!PedidoPtoVta.ListaPedidoDet[Fil].flgIgv)
            //{
            //    IGV = 0;
            //}
            //else
            //{
            //    IGV = SubTotal * porIgv;
            //}

            //decimal Total = SubTotal + IGV;

            PedidoPtoVta.ListaPedidoDet[Fil].Cantidad = Cantidad;
            PedidoPtoVta.ListaPedidoDet[Fil].PrecioUnitario = Precio;
            //PedidoPtoVta.ListaPedidoDet[Fil].PrecioUnitarioTmp = PedidoPtoVta.ListaPedidoDet[Fil].flgIgv == true ? PrecioConImp : Precio;
            //PedidoPtoVta.ListaPedidoDet[Fil].PrecioConImpuesto = PrecioConImp;
            PedidoPtoVta.ListaPedidoDet[Fil].PrecioConDscto = PrecioConDscto;
            PedidoPtoVta.ListaPedidoDet[Fil].porDscto1 = decimal.Round(porDscto * 100, 2);
            PedidoPtoVta.ListaPedidoDet[Fil].porDscto2 = 0M;
            PedidoPtoVta.ListaPedidoDet[Fil].porDscto3 = 0M;
            PedidoPtoVta.ListaPedidoDet[Fil].Dscto1 = decimal.Round(Dscto, 2);
            PedidoPtoVta.ListaPedidoDet[Fil].Dscto2 = 0M;
            PedidoPtoVta.ListaPedidoDet[Fil].Dscto3 = 0M;
            PedidoPtoVta.ListaPedidoDet[Fil].subTotal = decimal.Round(SubTotal, 2);
            PedidoPtoVta.ListaPedidoDet[Fil].Isc = 0M;
            PedidoPtoVta.ListaPedidoDet[Fil].Igv = decimal.Round(IGV, 2);
            PedidoPtoVta.ListaPedidoDet[Fil].Total = decimal.Round(Total, 2);

            SumarTotal(PedidoPtoVta.ListaPedidoDet);
        }

        private void Cobranza()
        {
            if (PedidoPtoVta != null && PedidoPtoVta.Estado == "P")
            {
                FrmPuntoVentasPagos oFrm = new FrmPuntoVentasPagos(PedidoPtoVta, Convert.ToDecimal(LblTica.Text), ptoVenta);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Documento != null)
                {
                    BtGuardar.Enabled = true;
                    BtAgregar.Enabled = true;
                    BtQuitar.Enabled = true;

                    Impresion(oFrm.Documento);

                    if (ptoVenta.PtoCobro)
                    {
                        Nuevo();
                        AgregarDetalle();
                    };
                }
            }
            else
            {
                Global.MensajeComunicacion("Tiene que guardar el Pedido.");
            }
        }

        private void Impresion(EmisionDocumentoE DocumentoPrevio)
        {
            string printer = ptoVenta.Impresora;
            string Fecha = "Fecha: " + VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            string Hora = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            if (Hora.ToUpper().Contains("P"))
            {
                Hora = "Hora: " + Hora.Substring(0, 8) + " p.m.";
            }
            else
            {
                Hora = "Hora: " + Hora.Substring(0, 8) + " a.m.";
            }

            if (string.IsNullOrWhiteSpace(ptoVenta.Impresora))
            {
                MessageBox.Show("Falta Configurar la Impresora para el Punto de Venta.");
            }

            //Creamos una instancia de la clase CrearTicket
            CrearTicketVenta Ticket = new CrearTicketVenta();
            MonedasE oMoneda = (from x in VariablesLocales.ListaMonedas
                                where x.idMoneda == DocumentoPrevio.idMoneda
                                select x).SingleOrDefault();

            #region Cabeceras

            if (!string.IsNullOrWhiteSpace(ptoVenta.Head1))
            {
                Ticket.TextoCentro(ptoVenta.Head1);
            }

            if (!string.IsNullOrWhiteSpace(ptoVenta.Head2))
            {
                Ticket.TextoCentro(ptoVenta.Head2);
            }

            if (!string.IsNullOrWhiteSpace(ptoVenta.Head3))
            {
                Ticket.TextoCentro(ptoVenta.Head3);
            }

            if (!string.IsNullOrWhiteSpace(ptoVenta.Head4))
            {
                Ticket.TextoCentro(ptoVenta.Head4);
            }

            if (!string.IsNullOrWhiteSpace(ptoVenta.Head5))
            {
                Ticket.TextoCentro(ptoVenta.Head5);
            }

            if (!string.IsNullOrWhiteSpace(ptoVenta.Head6))
            {
                Ticket.TextoCentro(ptoVenta.Head6);
            }

            Ticket.TextoIzquierda(""); //Espacio en blanco

            if (DocumentoPrevio.idDocumento == "FV")
            {
                if (!string.IsNullOrWhiteSpace(ptoVenta.TituloFac))
                {
                    Ticket.TextoCentro(ptoVenta.TituloFac);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(ptoVenta.TituloBol))
                {
                    Ticket.TextoCentro(ptoVenta.TituloBol);
                }
            }

            Ticket.LineasIgual(); //Lineas 

            #endregion

            Ticket.TextoExtremos(Fecha, Hora);
            Ticket.TextoIzquierda("Nro.Docum: " + DocumentoPrevio.numSerie + "-" + DocumentoPrevio.numDocumento);
            Ticket.TextoIzquierda("Serie    : " + ptoVenta.SerieCaja);
            Ticket.TextoIzquierda("Cajero   : " + VariablesLocales.SesionUsuario.NombreCompleto);

            Ticket.TextoIzquierda(""); //Espacio en blanco
            Ticket.LineasIgual(); //Lineas
            Ticket.EncabezadoVenta(" CANT  U.M.    PRODUCTO           TOTAL ");
            Ticket.LineasIgual();

            //Detalle
            foreach (EmisionDocumentoDetE item in DocumentoPrevio.ListaItemsDocumento)
            {
                Ticket.AgregaArticuloS2(Convert.ToDecimal(item.Cantidad.ToString("N2")), item.desUMedidaCorta, item.nomArticulo, decimal.Round(item.Total, 2));
            }

            #region Totales

            Ticket.LineasIgual();
            Ticket.ImprimeTresColumnas(10, "Dscto:", false, false, 20, oMoneda.desAbreviatura, false, true, 10, decimal.Round(DocumentoPrevio.totDscto1, 2).ToString(), false, true);
            Ticket.ImprimeTresColumnas(10, "Sub-Total:", false, false, 20, oMoneda.desAbreviatura, false, true, 10, decimal.Round(DocumentoPrevio.totsubTotal, 2).ToString(), false, true);

            if (VariablesLocales.oListaImpuestos != null && VariablesLocales.oListaImpuestos.Count > 0)
            {
                Decimal IgvPor = VariablesLocales.oListaImpuestos[0].Porcentaje;
                Ticket.ImprimeTresColumnas(15, "I.G.V. " + IgvPor.ToString("N2") + "% ", false, false, 15, oMoneda.desAbreviatura, false, true, 10, decimal.Round(Convert.ToDecimal(DocumentoPrevio.ListaItemsDocumento.Sum(x => x.Igv)), 2).ToString(), false, true);
            }
            else
            {
                Global.MensajeComunicacion("No esta configurado el párametro del IGV en la Ventana de Impuestos.");
                Ticket.ImprimeTresColumnas(10, "I.G.V.", false, false, 20, oMoneda.desAbreviatura, false, true, 10, decimal.Round(DocumentoPrevio.totIgv.Value, 2).ToString(), false, true);
            }

            Ticket.LineasIgual();
            Decimal MontoVuelto = (from x in DocumentoPrevio.ListaCancelaciones where x.IndTarjCredito == false select x.Vuelto).FirstOrDefault();// DocumentoPrevio.ListaCancelaciones.Where(e => e.IndTarjCredito == false).Sum(e => e.Vuelto);
            Ticket.ImprimeTresColumnas(10, "Total:", false, false, 20, oMoneda.desAbreviatura, false, true, 10, decimal.Round(DocumentoPrevio.totTotal, 2).ToString(), false, true);
            Ticket.ImprimeTresColumnas(10, "Vuelto:", false, false, 20, oMoneda.desAbreviatura, false, true, 10, decimal.Round(MontoVuelto, 2).ToString(), false, true);
            Ticket.LineasIgual(); 

            #endregion

            //Número a letras
            Ticket.TextoIzquierda(NumeroLetras.enLetras(DocumentoPrevio.totTotal.ToString()) + oMoneda.desMoneda);
            Ticket.LineasIgual();

            #region Formas de pago

            decimal TotalEfectivo = DocumentoPrevio.ListaCancelaciones.Where(e => e.IndTarjCredito == false).Sum(e => e.MontoAplicar);
            decimal TotalTarjetas = DocumentoPrevio.ListaCancelaciones.Where(t => t.IndTarjCredito == true).Sum(t => t.MontoAplicar);

            if (TotalEfectivo > 0 && TotalTarjetas == 0)
            {
                Ticket.TextoIzquierda("Forma de Pago: En Efectivo");
                Ticket.TextoExtremos("Efectivo: " + TotalEfectivo.ToString("N2"), "Tarjeta: 0.00");
            }
            else if (TotalEfectivo == 0 && TotalTarjetas > 0)
            {
                Ticket.TextoIzquierda("Forma de Pago: Con Tarjeta de Crédito");
                Ticket.TextoExtremos("Efectivo: 0.00", "Tarjeta: " + TotalTarjetas.ToString("N2"));
            }
            else if (TotalEfectivo > 0 && TotalTarjetas > 0)
            {
                Ticket.TextoIzquierda("Forma de Pago: En Efectivo y Tarjeta");
                Ticket.TextoExtremos("Efectivo: " + TotalEfectivo.ToString("N2"), "Tarjeta: " + TotalTarjetas.ToString("N2"));
            } 

            #endregion

            Ticket.LineasIgual();

            #region Cliente

            string RazonSocial;
            string RazonSocialTmp;

            if (DocumentoPrevio.idDocumento == "FV")
            {
                RazonSocialTmp = ("Razón Social: " + DocumentoPrevio.RazonSocial).Trim();

                if (RazonSocialTmp.Length > 40)
                {
                    RazonSocial = ("Razón Social: " + DocumentoPrevio.RazonSocial).Trim().Substring(0, 40);
                    RazonSocialTmp = RazonSocialTmp.Replace(RazonSocial, "");
                    Ticket.TextoIzquierda(RazonSocial);
                    Ticket.TextoIzquierda(RazonSocialTmp);
                }
                else
                {
                    RazonSocial = ("Razón Social: " + DocumentoPrevio.RazonSocial).Trim();
                    Ticket.TextoIzquierda(RazonSocial);
                }

                Ticket.TextoIzquierda("R.U.C.      : " + DocumentoPrevio.numRuc);
            }
            else
            {
                RazonSocialTmp = ("Nombres  : " + DocumentoPrevio.RazonSocial).Trim();

                if (RazonSocialTmp.Length > 40)
                {
                    RazonSocial = ("Nombres  : " + DocumentoPrevio.RazonSocial).Trim().Substring(0, 40);
                    RazonSocialTmp = RazonSocialTmp.Replace(RazonSocial, "");
                    Ticket.TextoIzquierda(RazonSocial);
                    Ticket.TextoIzquierda(RazonSocialTmp);
                }
                else
                {
                    RazonSocial = ("Nombres  : " + DocumentoPrevio.RazonSocial).Trim();
                    Ticket.TextoIzquierda(RazonSocial);
                }

                Ticket.TextoIzquierda("Doc.Iden.: " + DocumentoPrevio.numRuc);
            }

            string Direccion;
            string DireccionTmp = ((DocumentoPrevio.idDocumento == "FV" ? "Dirección   : " : "Dirección: ") + DocumentoPrevio.Direccion).Trim();

            if (DireccionTmp.Length > 40)
            {
                Direccion = ("Dirección: " + DocumentoPrevio.Direccion).Trim().Substring(0, 40);
                DireccionTmp = DireccionTmp.Replace(Direccion, "");
                Ticket.TextoIzquierda(Direccion);
                Ticket.TextoIzquierda(DireccionTmp);
            }
            else
            {
                Direccion = ("Dirección: " + DocumentoPrevio.Direccion).Trim();
                Ticket.TextoIzquierda(Direccion);
            } 

            #endregion

            Ticket.LineasIgual();

            #region Pie de Página

            if (!string.IsNullOrWhiteSpace(ptoVenta.Foot1))
            {
                Ticket.TextoCentro(ptoVenta.Foot1);
            }

            if (!string.IsNullOrWhiteSpace(ptoVenta.Foot2))
            {
                Ticket.TextoCentro(ptoVenta.Foot2);
            }

            if (!string.IsNullOrWhiteSpace(ptoVenta.Foot3))
            {
                Ticket.TextoCentro(ptoVenta.Foot3);
            }

            if (!string.IsNullOrWhiteSpace(ptoVenta.Foot4))
            {
                Ticket.TextoCentro(ptoVenta.Foot4);
            }

            if (!string.IsNullOrWhiteSpace(ptoVenta.Foot5))
            {
                Ticket.TextoCentro(ptoVenta.Foot5);
            }

            if (!string.IsNullOrWhiteSpace(ptoVenta.Foot6))
            {
                Ticket.TextoCentro(ptoVenta.Foot6);
            }

            Ticket.TextoIzquierda("");
            Ticket.TextoIzquierda("");
            Ticket.TextoIzquierda("");
            Ticket.TextoIzquierda("");
            Ticket.TextoIzquierda("");

            #endregion

            if (ptoVenta.MostrarPrevio)
            {
                frmPuntoVentasPrintPrevio oFrm = new frmPuntoVentasPrintPrevio(Ticket.Linea.ToString());

                if (oFrm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            Ticket.CortaTicket();

            string FechaDoc = DocumentoPrevio.fecEmision;
            bool Encontro = FechaDoc.Contains("-");

            if (!Encontro)
            {
                Encontro = FechaDoc.Contains("/");
            }

            if (!Encontro)
            {
                FechaDoc = DocumentoPrevio.fecEmision.Insert(6, "-").Insert(4, "-");
            }

            String Ruta = DevuelveRutaArchivo(Convert.ToDateTime(FechaDoc), DocumentoPrevio.idDocumento + " " + DocumentoPrevio.numSerie + "-" + DocumentoPrevio.numDocumento);
            Ticket.ImprimirTicket(printer, 2, Ruta);//Nombre de la impresora ticketera, Metodo, la ruta donde se va a crear el archivo.
        }

        private String DevuelveRutaArchivo(DateTime Fecha, String NumeroDoc)
        {
            string RutaDevuelta = @"C:\AmazonErp\Ventas\";
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

            RutaDevuelta += @"\Documento " + NumeroDoc + ".txt";

            return RutaDevuelta;
        }

        private void EscogerUnidadMedida(PedidoDetE pedidoDet)
        {
            ListaPrecioItemE listaPrecio = AgenteVentas.Proxy.ObtenerListaPrecioItemArticulo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, ((PedidoDetE)BsDetalle.Current).idTipoPrecio, ((PedidoDetE)BsDetalle.Current).idArticulo);

            if (listaPrecio != null)
            {
                if (pedidoDet.idUMedida == listaPrecio.IdUMedidaD)
                {
                    ((PedidoDetE)BsDetalle.Current).PrecioUnitario = listaPrecio.PrecioBruto;
                    ((PedidoDetE)BsDetalle.Current).PrecioConImpuesto = listaPrecio.PrecioVenta;
                    ((PedidoDetE)BsDetalle.Current).Dscto1 = listaPrecio.PorDscto1 > 0 ? listaPrecio.PrecioVenta * (listaPrecio.PorDscto1 / 100) : 0M;
                    ((PedidoDetE)BsDetalle.Current).PrecioConDscto = listaPrecio.PrecioVenta - ((PedidoDetE)BsDetalle.Current).Dscto1;
                    ((PedidoDetE)BsDetalle.Current).Dscto2 = 0M;
                    ((PedidoDetE)BsDetalle.Current).Dscto3 = 0M;
                    ((PedidoDetE)BsDetalle.Current).porDscto1 = listaPrecio.PorDscto1;
                    ((PedidoDetE)BsDetalle.Current).porDscto2 = 0M;
                    ((PedidoDetE)BsDetalle.Current).porDscto3 = 0M;
                    ((PedidoDetE)BsDetalle.Current).flgIgv = listaPrecio.flgigv;
                    ((PedidoDetE)BsDetalle.Current).Isc = 0M;
                    ((PedidoDetE)BsDetalle.Current).Total = listaPrecio.PrecioVenta;
                    ((PedidoDetE)BsDetalle.Current).subTotal = listaPrecio.PrecioVenta / (1 + (listaPrecio.porigv / 100M));
                    ((PedidoDetE)BsDetalle.Current).Igv = ((PedidoDetE)BsDetalle.Current).Total - ((PedidoDetE)BsDetalle.Current).subTotal;
                    ((PedidoDetE)BsDetalle.Current).porIsc = 0M;
                    ((PedidoDetE)BsDetalle.Current).porIgv = listaPrecio.porigv;
                    ((PedidoDetE)BsDetalle.Current).idUMedida = listaPrecio.IdUMedida;
                    ((PedidoDetE)BsDetalle.Current).desUnidadMed = listaPrecio.nomUMedida;
                }
                else if (pedidoDet.idUMedida == listaPrecio.IdUMedida)
                {
                    ((PedidoDetE)BsDetalle.Current).PrecioUnitario = listaPrecio.PrecioD;
                    ((PedidoDetE)BsDetalle.Current).PrecioConImpuesto = listaPrecio.PrecioVentaD;
                    ((PedidoDetE)BsDetalle.Current).Dscto1 = listaPrecio.PorDsctoD > 0 ? listaPrecio.PrecioVentaD * (listaPrecio.PorDsctoD / 100) : 0M;
                    ((PedidoDetE)BsDetalle.Current).PrecioConDscto = listaPrecio.PrecioVentaD - ((PedidoDetE)BsDetalle.Current).Dscto1;
                    ((PedidoDetE)BsDetalle.Current).Dscto2 = 0M;
                    ((PedidoDetE)BsDetalle.Current).Dscto3 = 0M;
                    ((PedidoDetE)BsDetalle.Current).porDscto1 = listaPrecio.PorDsctoD;
                    ((PedidoDetE)BsDetalle.Current).porDscto2 = 0M;
                    ((PedidoDetE)BsDetalle.Current).porDscto3 = 0M;
                    ((PedidoDetE)BsDetalle.Current).flgIgv = listaPrecio.FlgIgvD;
                    ((PedidoDetE)BsDetalle.Current).Isc = 0M;
                    ((PedidoDetE)BsDetalle.Current).Total = listaPrecio.PrecioVentaD;
                    ((PedidoDetE)BsDetalle.Current).subTotal = listaPrecio.PrecioValorVentaD;
                    ((PedidoDetE)BsDetalle.Current).Igv = listaPrecio.IgvD;
                    ((PedidoDetE)BsDetalle.Current).porIsc = 0M;
                    ((PedidoDetE)BsDetalle.Current).porIgv = listaPrecio.PorIgvD;
                    ((PedidoDetE)BsDetalle.Current).idUMedida = listaPrecio.IdUMedidaD;
                    ((PedidoDetE)BsDetalle.Current).desUnidadMed = listaPrecio.nomUMedidaEnv;
                }

                BsDetalle.ResetBindings(false);
                Calcular();
                SumarTotal((List<PedidoDetE>)BsDetalle.List);
                DgvDetalle.Focus();
                DgvDetalle.CurrentRow.Cells["desUnidadMed"].Selected = true;
            }
        }

        private void AgregarCliente()
        {
            ParTabla tabla;

            if (TxtRuc.Text.Length == 11 && (TxtRuc.Text.Substring(0, 1) == "2" || TxtRuc.Text.Substring(0, 1) == "1"))
            {
                tabla = AgenteGeneral.Proxy.ParTablaPorNemo("PERJU");
            }
            else if (TxtRuc.Text.Length == 8)
            {
                tabla = AgenteGeneral.Proxy.ParTablaPorNemo("PERSR");
            }
            else
            {
                tabla = AgenteGeneral.Proxy.ParTablaPorNemo("OTR");
            }

            int codPar = tabla.IdParTabla;

            if (TxtRuc.Text.Length == 11 && (TxtRuc.Text.Substring(0, 1) == "2" || TxtRuc.Text.Substring(0, 1) == "1"))
            {
                tabla = AgenteGeneral.Proxy.ParTablaPorNemo("PERRUC");
            }
            else if (TxtRuc.Text.Length == 8)
            {
                tabla = AgenteGeneral.Proxy.ParTablaPorNemo("PERDNI");
            }
            else
            {
                tabla = AgenteGeneral.Proxy.ParTablaPorNemo("PEROTR");
            }

            int tipDocPer = tabla.IdParTabla;

            Persona persona = new Persona()
            {
                TipoPersona = codPar,
                RazonSocial = TxtRazonSocial.Text.Trim(),
                RUC = TxtRuc.Text,
                ApePaterno = string.Empty,
                ApeMaterno = string.Empty,
                Nombres = string.Empty,
                TipoDocumento = tipDocPer,
                NroDocumento = TxtRuc.Text,
                Telefonos = string.Empty,
                Fax = string.Empty,
                Correo = string.Empty,
                Web = string.Empty,
                DireccionCompleta = TxtDireccion.Text.Trim(),
                idPais = 90,
                idUbigeo = string.Empty,
                PrincipalContribuyente = false,
                AgenteRetenedor = false,
                idCanalVenta = null,
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
            };

            //Insertando Persona
            persona = AgenteMaestro.Proxy.InsertarPersona(persona);

            ClienteE oCliente = new ClienteE()
            {
                idPersona = persona.IdPersona,
                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                SiglaComercial = TxtRazonSocial.Text.Trim(),
                TipoCliente = 0,
                fecInscripcion = null,
                fecInicioEmpresa = null,
                tipConstitucion = 0,
                tipRegimen = 0,
                catCliente = 0,
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
            };

            //Insertando el cliente
            AgenteMaestro.Proxy.InsertarCliente(oCliente);
            TxtRuc.Tag = persona.IdPersona;
        }

        #endregion

        #region Override

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //  Si el control DataGridView no tiene el foco...
            if (!DgvDetalle.Focused && !DgvDetalle.IsCurrentCellInEditMode)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            ////  Si la tecla presionada es distinta de la tecla Enter
            ////  abandonamos el procedimiento.
            if ((keyData != Keys.Return))
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            Int32 iColumnIndex = DgvDetalle.CurrentCell.ColumnIndex;
            Int32 iRowIndex = DgvDetalle.CurrentCell.RowIndex;

            if (keyData == Keys.Enter)
            {
                if (iColumnIndex == DgvDetalle.Columns.Count - 1)
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
                else
                {
                    DgvDetalle.CurrentCell = DgvDetalle[iColumnIndex + 1, iRowIndex];
                }

                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_CHAR = 0x102;
            const int WM_SYSCHAR = 0x106;
            const int WM_SYSKEYDOWN = 0x104;
            const int WM_IME_CHAR = 0x286;

            if ((m.Msg != WM_CHAR) && (m.Msg != WM_SYSCHAR) && (m.Msg != WM_IME_CHAR))
            {
                KeyEventArgs e = new KeyEventArgs(((Keys)((int)((long)m.WParam))) | ModifierKeys);

                if ((m.Msg == WM_KEYDOWN) || (m.Msg == WM_SYSKEYDOWN))
                {
                    //sinEvento = false;
                    FrmPuntoVentas_KeyDown(this, e);
                }

                if (e.Handled)
                {
                    return e.Handled;
                }
            }

            return base.ProcessKeyPreview(ref m);
        }

        #endregion

        #region Eventos de Usuario

        private void FrmPuntoVentas_Shown(object sender, EventArgs e)
        {
            if (ptoVenta == null)
            {
                BtNuevo.Enabled = false;
                BtObtener.Enabled = false;
                BtAnular.Enabled = false;
                BtImprimir.Enabled = false;
                BtAgregar.Enabled = false;
                BtQuitar.Enabled = false;
                BtGuardar.Enabled = false;
                BtCobrar.Enabled = false;
                //TxtRuc.Enabled = false;
                //TxtRazonSocial.Enabled = false;
                //TxtDireccion.Enabled = false;
                PnlCliente.Enabled = false;
                Global.MensajeFault("El punto de venta no esta configurado...");
            }
            else
            {
                labelDegradado1.Text = ptoVenta.Descripcion;
                //TxtRuc.Enabled = true;
                //TxtRazonSocial.Enabled = true;
                //TxtDireccion.Enabled = true;
                PnlCliente.Enabled = true;

                if (ptoVenta.PtoCobro)
                {
                    BtObtener.Enabled = true;
                    BtGuardar.Enabled = true;
                    BtCobrar.Enabled = true;
                    BtAgregar.Enabled = true;
                    BtQuitar.Enabled = true;
                }
                else
                {
                    BtObtener.Enabled = false;
                    BtGuardar.Enabled = true;
                    BtCobrar.Enabled = false;
                    BtAgregar.Enabled = true;
                    BtQuitar.Enabled = true;
                }

                FrmPuntoVentasArticulos oFrm = new FrmPuntoVentasArticulos(this, oListaPrecio, DtpFecha.Value.Date, null);
                oFrm.ShowDialog();

                if (DgvDetalle.Rows.Count > 0)
                {
                    BsDetalle.MoveLast();
                    DgvDetalle.Focus();
                    DgvDetalle.CurrentRow.Cells["Cantidad"].Selected = true; 
                }
            }
        }

        #endregion

        #region Eventos

        private void FrmPuntoVentas_Load(object sender, EventArgs e)
        {
            Location = new Point(0, 0);
            oTica = VariablesLocales.RetornaTipoCambio("02", DtpFecha.Value.Date);

            if (oTica != null)
            {
                LblTica.Text = oTica.valVenta.ToString();
            }
            else
            {
                LblTica.Text = "0.000";
                Global.MensajeFault("No existe tipo de cambio para el dia de hoy.");
                return;
            }

            if (VariablesLocales.oVenParametros == null)
            {
                Global.MensajeFault("Falta configurar los parámetros de ventas.");
                return;
            }

            Nuevo();

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                LblIdPedido.Visible = true;
            }
        }

        private void LabelDegradado1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PbMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void PbCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Grabar();
            }
            catch (Exception ex)
            {
                BtNuevo.Enabled = true;
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarDetalle();
            }
            catch (Exception ex)
            {
                BtNuevo.Enabled = true;
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (PedidoPtoVta.ListaPedidoDet.Count > 0)
                {
                    QuitarDetalle();
                }
            }
            catch (Exception ex)
            {
                BtNuevo.Enabled = true;
                Global.MensajeFault(ex.Message);
            }
        }

        private void DgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    if (DgvDetalle.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
                    {
                        DgvDetalle.BeginEdit(true);
                        ComboBox cbo = (ComboBox)DgvDetalle.EditingControl;

                        if (cbo != null)
                        {
                            cbo.DroppedDown = true; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void TxtRuc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TxtRuc.Text.Trim()) && String.IsNullOrEmpty(TxtRazonSocial.Text.Trim()))
                {
                    TxtRuc.TextChanged -= TxtRuc_TextChanged;
                    TxtRazonSocial.TextChanged -= TxtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", TxtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            TxtRuc.Text = oFrm.oPersona.RUC;
                            TxtRuc.Tag = oFrm.oPersona.IdPersona;
                            TxtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            TxtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                        }
                        else
                        {
                            TxtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        TxtRuc.Tag = oListaPersonas[0].IdPersona;
                        TxtRuc.Text = oListaPersonas[0].RUC;
                        TxtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        TxtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                    }
                    else
                    {
                        Global.MensajeComunicacion("El Ruc ingresado no existe. Complete los datos y presione el Botón Agregar Cliente.");
                        TxtRuc.Tag = 0;
                        TxtRazonSocial.Focus();
                        BtAgregarCliente.Enabled = true;
                    }

                    TxtRuc.TextChanged += TxtRuc_TextChanged;
                    TxtRazonSocial.TextChanged += TxtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                TxtRuc.TextChanged += TxtRuc_TextChanged;
                TxtRazonSocial.TextChanged += TxtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void TxtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TxtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(TxtRuc.Text.Trim()))
                {
                    TxtRuc.TextChanged -= TxtRuc_TextChanged;
                    TxtRazonSocial.TextChanged -= TxtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", TxtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            TxtRuc.Tag = oFrm.oPersona.IdPersona;
                            TxtRuc.Text = oFrm.oPersona.RUC;
                            TxtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            TxtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                        }
                        else
                        {
                            DgvDetalle.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        TxtRuc.Tag = oListaPersonas[0].IdPersona;
                        TxtRuc.Text = oListaPersonas[0].RUC;
                        TxtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        TxtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                    }
                    else
                    {
                        Global.MensajeComunicacion("El Ruc ingresado no existe. Complete los datos y presione el Botón Agregar Cliente.");
                        TxtRuc.Tag = 0;
                        BtAgregarCliente.Enabled = true;
                        TxtDireccion.Focus();
                    }

                    TxtRuc.TextChanged += TxtRuc_TextChanged;
                    TxtRazonSocial.TextChanged += TxtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                TxtRuc.TextChanged += TxtRuc_TextChanged;
                TxtRazonSocial.TextChanged += TxtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void TxtRuc_TextChanged(object sender, EventArgs e)
        {
            //TxtRuc.Tag = 0;
            //TxtRazonSocial.Text = String.Empty;
            //TxtDireccion.Text = String.Empty;
        }

        private void TxtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            //TxtRuc.Tag = 0;
            //TxtRuc.Text = String.Empty;
            //TxtDireccion.Text = String.Empty;
        }

        private void BtObtener_Click(object sender, EventArgs e)
        {
            try
            {
                BtNuevo.Enabled = true;

                FrmPuntoVentasPedidos oFrm = new FrmPuntoVentasPedidos();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Pedido != null)
                {
                    PedidoPtoVta = AgenteVentas.Proxy.RecuperarPedidoPtoVta(oFrm.Pedido.idPedido);

                    TxtRuc.TextChanged -= new EventHandler(TxtRuc_TextChanged);
                    TxtRazonSocial.TextChanged -= new EventHandler(TxtRazonSocial_TextChanged);

                    LblPedido.Text = "N° PEDIDO " + PedidoPtoVta.codPedidoCad;
                    TxtRuc.Tag = PedidoPtoVta.idFacturar;
                    TxtRuc.Text = PedidoPtoVta.RucCliente;
                    TxtRazonSocial.Text = PedidoPtoVta.RazonSocial;
                    TxtDireccion.Text = PedidoPtoVta.DireccionCompleta;
                    oTica = VariablesLocales.RetornaTipoCambio("02", Convert.ToDateTime(PedidoPtoVta.FecPedido));
                    LblTica.Text = oTica.valVenta.ToString();

                    BsDetalle.DataSource = PedidoPtoVta.ListaPedidoDet;
                    BsDetalle.ResetBindings(false);
                    SumarTotal(PedidoPtoVta.ListaPedidoDet);

                    LblIdPedido.Text = "ID: " + PedidoPtoVta.idPedido.ToString();

                    if (DgvDetalle.Rows.Count > 0)
                    {
                        BsDetalle.MoveLast();
                        DgvDetalle.Focus();
                        DgvDetalle.CurrentRow.Cells["Cantidad"].Selected = true;
                    }

                    TxtRuc.TextChanged += new EventHandler(TxtRuc_TextChanged);
                    TxtRazonSocial.TextChanged += new EventHandler(TxtRazonSocial_TextChanged);
                }
            }
            catch (Exception ex)
            {
                BtNuevo.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void BtCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cobranza();
            }
            catch (Exception ex)
            {
                BtNuevo.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void BtNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Nuevo();
                AgregarDetalle();
                BtNuevo.Enabled = false;
                BtGuardar.Enabled = true;
                BtAgregar.Enabled = true;
                BtQuitar.Enabled = true;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void BtImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPuntoVentasReimpresion oFrm = new FrmPuntoVentasReimpresion();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.DocumentoVenta != null)
                {
                    Impresion(oFrm.DocumentoVenta);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void BtAnular_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPuntoVentasReimpresion oFrm = new FrmPuntoVentasReimpresion("A");
                oFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void DgvDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                DgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (DgvDetalle.CurrentCell != null)
                {
                    if (DgvDetalle.CurrentCell.ColumnIndex == 3 || DgvDetalle.CurrentCell.ColumnIndex == 6 || DgvDetalle.CurrentCell.ColumnIndex == 7)
                    {
                        if (e.Control is TextBox txt)
                        {
                            txt.KeyPress -= new KeyPressEventHandler(DgvDetalle_KeyPress);
                            txt.KeyPress += new KeyPressEventHandler(DgvDetalle_KeyPress);
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void DgvDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Validando la columna de porcentaje y el total para que acepte solo números
                if (DgvDetalle.CurrentRow != null)
                {
                    if (DgvDetalle.CurrentCell.ColumnIndex == 3 || DgvDetalle.CurrentCell.ColumnIndex == 6 || DgvDetalle.CurrentCell.ColumnIndex == 7)
                    {
                        if (e.KeyChar == (char)Keys.Back || char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void DgvDetalle_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.RowIndex != -1) && (e.ColumnIndex == DgvDetalle.Columns["desUnidadMed"].Index))
                {
                    string Mensaje = "Presentación en \n";

                    if (!string.IsNullOrWhiteSpace(((PedidoDetE)BsDetalle.Current).desUniAlmacen))
                    {
                        Mensaje += "** " + ((PedidoDetE)BsDetalle.Current).desUniAlmacen + "\n";
                    }

                    if (!string.IsNullOrWhiteSpace(((PedidoDetE)BsDetalle.Current).desUniEnvase))
                    {
                        Mensaje += "** " + ((PedidoDetE)BsDetalle.Current).desUniEnvase + "\n";
                    }

                    DataGridViewCell cell = DgvDetalle.CurrentCell;
                    var cellDisplayRect = DgvDetalle.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    ToolTip toolTipAyuda = new ToolTip
                    {
                        ToolTipTitle = "Punto de Venta",
                        ToolTipIcon = ToolTipIcon.Info,
                        IsBalloon = true,
                        InitialDelay = 10
                    };
                    DgvDetalle.ShowCellToolTips = false;
                    toolTipAyuda.Show(Mensaje + "Puede presionar la tecla X para cambiar de Und.Med.", DgvDetalle, cellDisplayRect.X + cell.Size.Width / 2, cellDisplayRect.Y + cell.Size.Height / 2, 2000);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void DgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Elimina el mensaje de error de la cabecera de la fila
                DgvDetalle.Rows[e.RowIndex].ErrorText = string.Empty;

                if (e.ColumnIndex == 3 || e.ColumnIndex == 6 || e.ColumnIndex == 7)
                {
                    CalcularPorColumna(e.ColumnIndex);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void FrmPuntoVentas_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape: //Cerrar el formulario activo...
                        Dispose();
                        break;
                    case Keys.F2: //Realizar un registro nuevo...
                        Nuevo();
                        break;
                    case Keys.F5: //Grabar un registro nuevo o algun cambio pendiente...
                        Grabar();
                        break;
                    case Keys.F7: //Anular o eliminar el registro...
                        FrmPuntoVentasReimpresion oFrm = new FrmPuntoVentasReimpresion("A");
                        oFrm.ShowDialog();
                        break;
                    case Keys.F9:
                        BtImprimir_Click(null, null);
                        break;
                    case Keys.Insert: //Agregar o insertar detalle (datagridview)...
                        AgregarDetalle();
                        break;
                    case Keys.Delete: //Quitar o Borrar detalle (datagridview)...
                        QuitarDetalle();
                        break;
                    case Keys.F12:
                        BtCobrar_Click(null, null);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void DgvDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (DgvDetalle.CurrentCell != null)
                {
                    if (DgvDetalle.CurrentCell.ColumnIndex == 4)
                    {
                        if (e.KeyCode == Keys.X)
                        {
                            if (BsDetalle.Current == null || ((PedidoDetE)BsDetalle.Current).codUniMedAlmacen <= 0 || ((PedidoDetE)BsDetalle.Current).idUniMedEnvase <= 0)
                            {
                                return;
                            }

                            EscogerUnidadMedida((PedidoDetE)BsDetalle.Current);
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarCliente();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
