using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Infraestructura;
using ClienteWinForm.Util;

namespace ClienteWinForm.Ventas
{
    public partial class FrmPuntoVentasArticulos : Form
    {

        #region Constructores

        public FrmPuntoVentasArticulos()
        {
            InitializeComponent();
            Formato(DgvDetalle);
            Formato(DgvPrincipios);
            Global.CrearToolTip(BtGuardar, "Presionar Tecla F5");
        }

        public FrmPuntoVentasArticulos(IAgregar<PedidoDetE> agregar_, List<ListaPrecioE> Lista_, DateTime FechaActual, List<PedidoDetE> pedidos)
            : this()
        {
            FilaNueva = agregar_;
            listaPrecio = Lista_;
            FechaPedido = FechaActual;
            ListaPedidos = pedidos;
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        private readonly List<ListaPrecioE> listaPrecio = null;
        private List<ArticuloServE> ListaArticulos = null;
        private DateTime FechaPedido;
        private List<PedidoDetE> ListaPedidos = null;
        private IAgregar<PedidoDetE> FilaNueva { get; set; } 

        #endregion

        #region Procedimientos de Usuario

        private void Escoger(ArticuloServE articulo)
        {
            if (articulo.Stock == 0M && articulo.StockDetalle == 0M)
            {
                Global.MensajeAdvertencia(string.Format("No puede agregar el articulo {0}, porque no tiene Stock.", articulo.nomArticulo));
                return;
            }

            if (ListaPedidos != null && ListaPedidos.Count > 0)
            {
                PedidoDetE ArticuloSearch = ListaPedidos.Find
                (
                    delegate (PedidoDetE d) { return d.idArticulo == articulo.idArticulo; }
                );

                if (ArticuloSearch != null)
                {
                    Global.MensajeAdvertencia(string.Format("El articulo {0}, ya se encuentra agregado en el listado. Escoja otro o modifique su cantidad en el listado.", articulo.nomArticulo));
                    return;
                } 
            }

            PedidoDetE detalle = new PedidoDetE()
            {
                idArticulo = articulo.idArticulo,
                CodBarras = articulo.codBarra,
                codArticulo = articulo.codArticulo,
                nomArticulo = articulo.nomArticulo,
                idTipoPrecio = articulo.idListaPrecio,
                Cantidad = 1,
                PrecioUnitario = articulo.PrecioBruto,
                PrecioConImpuesto = articulo.PrecioVenta,
                //PrecioUnitarioTmp = 0M, //articulo.PrecioVenta,
                Dscto1 = 0M, //articulo.MontoDscto1,
                DsctoTmp = 0M, //articulo.MontoDscto1,                                                      
                Dscto2 = 0M, //articulo.MontoDscto2,
                Dscto3 = 0M, //articulo.MontoDscto3,
                porDscto1 = articulo.PorDscto1,
                porDscto2 = 0M, //articulo.PorDscto2,
                porDscto3 = 0M, //articulo.PorDscto3    
                flgIgv = articulo.flgigv,
                Isc = 0M, //articulo.isc,
                subTotal = 0M,// articulo.PrecioValorVenta,
                Igv = 0M,// articulo.igv,
                Total = 0M,//articulo.PrecioVenta,
                porIsc = articulo.porisc,
                porIgv = articulo.porigv,
                idMarca = articulo.codMarca,
                idUMedida = articulo.codUniMedAlmacen,
                idTipoArticulo = articulo.idTipoArticulo,
                idAlmacen = articulo.idAlmacen,
                Stock = articulo.Stock,
                StockDetalle = articulo.StockDetalle,
                Lote = string.Empty,
                indCalculo = true,
                TipoImpSelectivo = "N",
                Capacidad = articulo.Capacidad,
                Contenido = articulo.Contenido,
                indDetraccion = articulo.indDetraccion,
                tipDetraccion = articulo.tipDetraccion,

                desUnidadMed = articulo.nomUMedida,
                codUniMedAlmacen = articulo.codUniMedAlmacen.Value,
                desUniAlmacen = articulo.nomUMedida,
                idUniMedEnvase = articulo.idUniMedEnvase.Value,
                desUniEnvase = articulo.nomUMedidaEnv
            };

            if (detalle.flgIgv)
            {
                //detalle.PrecioUnitarioTmp = detalle.PrecioConImpuesto;

                if (detalle.porDscto1 > 0)
                {
                    //detalle.Dscto1 = (detalle.Cantidad * detalle.PrecioUnitario) * (detalle.porDscto1 / 100);
                    detalle.Dscto1 = detalle.PrecioConImpuesto * (detalle.porDscto1 / 100);
                    detalle.PrecioConDscto = detalle.PrecioConImpuesto - detalle.Dscto1;
                }
                else
                {
                    detalle.PrecioConDscto = detalle.PrecioConImpuesto;
                }

                detalle.Total = detalle.PrecioConDscto * detalle.Cantidad;
                detalle.subTotal = detalle.Total / (1 + (detalle.porIgv / 100));
                detalle.Igv = detalle.Total - detalle.subTotal;
                //detalle.subTotal = (detalle.Cantidad * detalle.PrecioUnitario) - detalle.Dscto1;
                //detalle.Igv = detalle.subTotal * (detalle.porIgv / 100);
                //detalle.Total = detalle.porDscto1 > 0 ? detalle.subTotal + detalle.Igv : detalle.PrecioConImpuesto;
            }
            else
            {
                //detalle.PrecioUnitarioTmp = detalle.PrecioUnitario;
                if (detalle.porDscto1 > 0)
                {
                    detalle.Dscto1 = detalle.PrecioUnitario * (detalle.porDscto1 / 100);
                    detalle.PrecioConDscto -= detalle.Dscto1;
                }
                else
                {
                    detalle.PrecioConDscto = detalle.PrecioConImpuesto;
                }

                detalle.subTotal = detalle.Cantidad * detalle.PrecioConDscto;
                detalle.Igv = 0M;
                detalle.Total = detalle.subTotal;
            }

            FilaNueva.AgregarFila(detalle);
            DialogResult = DialogResult.OK;
            Close();
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
            //Alto de la la fila de titulos
            oDgv.ColumnHeadersHeight = 30;
            //Ancho de la primera columna
            oDgv.RowHeadersWidth = 20;
            //Deshabilitando el ajuste de columnas y filas en el detalle
            oDgv.AllowUserToResizeColumns = false;
            oDgv.AllowUserToResizeRows = false;
            //Color de lineas y tipo de bordes
            oDgv.GridColor = Color.Black;
            //oDgv.BorderStyle = BorderStyle.Fixed3D;
            //Tipo de bordes en la cabecera
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //Seleccion multiple
            oDgv.MultiSelect = false;
            //Quitando los bordes en el detalle
            oDgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            //Tipo de selección de las celdas
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Tipo de letra del detalle
            oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            //Alternando colores en las filas
            //oDgv.RowsDefaultCellStyle.BackColor = Color.White;
            //oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //Color al seleccionar
            oDgv.DefaultCellStyle.SelectionForeColor = Color.White;
            oDgv.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 28;
            lineas.MinimumHeight = 10;

            //Formato por columnas
            //oDgv.Columns["nomArticulo"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //oDgv.Columns["PrecioVenta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            oDgv.Refresh();

            oDgv.ResumeLayout();
        }

        private void BuscarArticulos()
        {
            if (VariablesLocales.oSalesPoint != null)
            {
                if (VariablesLocales.oSalesPoint.idAlmacen == 0)
                {
                    Global.MensajeAdvertencia("Falta configurar el almacén en el Punto de Venta");
                    return;
                }
            }

            BsArticulos.DataSource = ListaArticulos = AgenteMaestro.Proxy.ArticulosPorListaPrecioStock2(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), listaPrecio[0].idListaPrecio, TxtArticulo.Text.Trim(), VariablesLocales.oSalesPoint.idAlmacen);
            BsArticulos.ResetBindings(false);
        }

        private List<ArticuloServE> ListaPrincipios(string valor)   
        {
            if (VariablesLocales.oSalesPoint != null)
            {
                if (VariablesLocales.oSalesPoint.idAlmacen == 0)
                {
                    Global.MensajeAdvertencia("Falta configurar el almacén en el Punto de Venta");
                    return null;
                }
            }

            List<ArticuloServE> Lista = AgenteMaestro.Proxy.ArticulosListaPrecioStockPa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), listaPrecio[0].idListaPrecio, valor, VariablesLocales.oSalesPoint.idAlmacen);
            Lista = (from x in Lista where x.idArticulo != ((ArticuloServE)BsArticulos.Current).idArticulo select x).ToList();
            return Lista;
        }

        #endregion

        #region Eventos

        private void FrmPuntoVentasArticulos_Load(object sender, EventArgs e)
        {

        }

        private void DgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Escoger((ArticuloServE)DgvDetalle.CurrentRow.DataBoundItem);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvDetalle.CurrentRow != null)
                {
                    Escoger((ArticuloServE)DgvDetalle.CurrentRow.DataBoundItem); 
                }
                //string hostName = System.Net.Dns.GetHostName();
                //MessageBox.Show(hostName);

                //hostName = Environment.GetEnvironmentVariable("COMPUTERNAME");
                //MessageBox.Show(hostName);

                //hostName = SystemInformation.ComputerName;
                //MessageBox.Show(hostName);

                //hostName = System.Net.Dns.GetHostEntry("").HostName;
                //MessageBox.Show(hostName);

                //hostName = Environment.MachineName;
                //MessageBox.Show(hostName);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void TxtArticulo_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    BsArticulos.DataSource = (from x in ListaArticulos
            //                              where x.nomArticulo.ToUpper().Contains(TxtArticulo.Text.ToUpper())
            //                              select x).ToList();
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeFault(ex.Message);
            //}
        }

        private void DgvDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    Escoger((ArticuloServE)DgvDetalle.CurrentRow.DataBoundItem);
                    //TxtArticulo.Focus();
                    //TxtArticulo.SelectAll();
                }

                if (e.KeyCode == Keys.F6)
                {
                    if (DgvDetalle.Focused)
                    {
                        string valor = ((ArticuloServE)DgvDetalle.CurrentRow.DataBoundItem).nomArticuloLargo;

                        if (!string.IsNullOrWhiteSpace(valor))
                        {
                            List<ArticuloServE> Lista = ListaPrincipios(valor);

                            if (Lista != null && Lista.Count > 0)
                            {
                                BsPrincipio.DataSource = Lista;
                                BsPrincipio.ResetBindings(false);

                                DgvDetalle.CurrentCell = null;
                                DgvDetalle.ClearSelection();
                                DgvPrincipios.Focus();
                            } 
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("No hay productos con los Pinrcipios Activos de este producto.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void TxtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Global.EventoEnter(e, BtBuscar);

                //if (ListaArticulos != null && ListaArticulos.Count > 0)
                //{
                if (e.KeyCode == Keys.Enter)
                {
                    BtBuscar_Click(null, null);

                    if (ListaArticulos != null && ListaArticulos.Count > 0)
                    {
                        DgvDetalle.Focus();
                    }
                }
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void TxtBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    BsArticulos.DataSource = (from x in ListaArticulos
                                              where x.codBarra.ToUpper().Contains(TxtBarras.Text.ToUpper())
                                              select x).ToList();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void FrmPuntoVentasArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    TxtArticulo.KeyDown -= TxtArticulo_KeyDown;
                    DgvDetalle.KeyDown -= DgvDetalle_KeyDown;
                    Dispose();
                }
                else if (e.KeyCode == Keys.F5)
                {
                    BtGuardar_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarArticulos();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void DgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    //if (DgvDetalle.Columns["nomArticuloLargo"].Name == "nomArticuloLargo")
                    //{
                    //    string valor = DgvDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    //    if (!string.IsNullOrWhiteSpace(valor))
                    //    {
                    //        BsPrincipio.DataSource = ListaPrincipios(valor);
                    //        BsPrincipio.ResetBindings(false);
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void DgvPrincipios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    Escoger((ArticuloServE)DgvPrincipios.CurrentRow.DataBoundItem); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void DgvPrincipios_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    Escoger((ArticuloServE)DgvPrincipios.CurrentRow.DataBoundItem);
                    //TxtArticulo.Focus();
                    //TxtArticulo.SelectAll();
                }

                if (e.KeyCode == Keys.F6)
                {
                    if (DgvPrincipios.Focused)
                    {
                        DgvPrincipios.CurrentCell = null;
                        DgvPrincipios.ClearSelection();
                        DgvDetalle.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
