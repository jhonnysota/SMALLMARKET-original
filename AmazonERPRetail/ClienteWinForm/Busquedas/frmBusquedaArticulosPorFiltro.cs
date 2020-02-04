using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using Entidades.Maestros;
using Entidades.Almacen;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBusquedaArticulosPorFiltro : frmResponseBase
    {

        #region Constructores

        public frmBusquedaArticulosPorFiltro()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvArticulos, false);
        }

        public frmBusquedaArticulosPorFiltro(Boolean indLote_, List<StockE> oListaStock_ = null, List<ArticuloServE> oListaArticulos_ = null, String ConLista_ = "N", String EsReque = "N")
            : this()
        {
            if (oListaStock_ != null)
            {
                if (EsReque == "N")
                {
                    Tipo = "Stock";
                }
                else
                {
                    Tipo = "StockReque";
                    Size = new Size(700, 342);
                }

                oListaStock = oListaStock_;
                indLote = indLote_;
            }

            if (oListaArticulos_ != null)
            {
                Tipo = "Articulo";
                oListaArticulos = oListaArticulos_;

                if (ConLista_ == "N")
                {
                    Size = new Size(880, 342);
                }
                else
                {
                    lblTituloPrincipal.Text = lblTituloPrincipal.Text + " por Lista de Precio";
                    Size = new Size(900, 342);
                }
            }

            ConLista = ConLista_;
        } 

        #endregion

        #region Variables

        List<StockE> oListaStock = null;
        List<ArticuloServE> oListaArticulos = null;
        public ArticuloServE oArticulo = null;
        String Tipo = String.Empty;
        Boolean indLote = false;
        String ConLista = "N";

        #endregion Variables

        #region Procedimientos de Usuario

        void FormatoGrid(string TipoFormato)
        {
            if (TipoFormato == "Stock")
            {
                #region Con Stock

                dgvArticulos.Columns["idArticulo"].Visible = false;
                dgvArticulos.Columns["idTipoArticulo"].Visible = false;
                dgvArticulos.Columns["codTipoMedAlmacen"].Visible = false;
                dgvArticulos.Columns["codUniMedAlmacen"].Visible = false;
                dgvArticulos.Columns["indDetraccion"].Visible = false;
                dgvArticulos.Columns["tipDetraccion"].Visible = false;
                dgvArticulos.Columns["CostoUnitPromBase"].Visible = false;
                dgvArticulos.Columns["CostoUnitPromSecu"].Visible = false;

                dgvArticulos.Columns["codArticulo"].HeaderText = "Cód.Arti.";
                dgvArticulos.Columns["codArticulo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvArticulos.Columns["desArticulo"].HeaderText = "Descripción";

                dgvArticulos.Columns["canStock"].DefaultCellStyle.Format = "N2";
                dgvArticulos.Columns["canStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvArticulos.Columns["canStock"].HeaderText = "Stock";

                dgvArticulos.Columns["nomUMedidaPres"].HeaderText = "U.M.Pres.";
                dgvArticulos.Columns["Contenido"].HeaderText = "Conten.";
                dgvArticulos.Columns["nomUMedidaEnv"].HeaderText = "U.M.Env.";
                dgvArticulos.Columns["LoteAlmacen"].HeaderText = "Lote";
                dgvArticulos.Columns["LoteProveedor"].HeaderText = "Lote Prov.";

                dgvArticulos.Columns["PesoUnitario"].HeaderText = "Peso Uni.";
                dgvArticulos.Columns["PesoUnitario"].DefaultCellStyle.Format = "N2";
                dgvArticulos.Columns["PesoUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvArticulos.Columns["fecPrueba"].DefaultCellStyle.Format = "d";
                dgvArticulos.Columns["fecPrueba"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvArticulos.Columns["fecPrueba"].HeaderText = "Fec.Prueba";

                dgvArticulos.Columns["fecProceso"].DefaultCellStyle.Format = "d";
                dgvArticulos.Columns["fecProceso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvArticulos.Columns["fecProceso"].HeaderText = "Fec.Proc.";

                dgvArticulos.Columns["PorcentajeGerminacion"].HeaderText = "% Ger.";
                dgvArticulos.Columns["PorcentajeGerminacion"].DefaultCellStyle.Format = "N2";
                dgvArticulos.Columns["PorcentajeGerminacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvArticulos.Columns["Batch"].HeaderText = "Batch";
                dgvArticulos.Columns["RazonSocial"].HeaderText = "Proveedor";
                dgvArticulos.Columns["NombreOrigen"].HeaderText = "Pais Origen";
                dgvArticulos.Columns["NombreProcedencia"].HeaderText = "Pais Proced.";
                dgvArticulos.Columns["Lote"].HeaderText = "Lote Sistema";

                #endregion
            }

            if (TipoFormato == "StockReque")
            {
                dgvArticulos.Columns[5].Visible = false;
                dgvArticulos.Columns[6].Visible = false;
                dgvArticulos.Columns[7].Visible = false;

                dgvArticulos.Columns[0].HeaderText = "ID.";
                dgvArticulos.Columns[1].HeaderText = "Cód.Articulo";
                dgvArticulos.Columns[2].HeaderText = "Descripción";
                dgvArticulos.Columns[3].HeaderText = "Stock";
                dgvArticulos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvArticulos.Columns[3].DefaultCellStyle.Format = "N2";
                dgvArticulos.Columns[4].HeaderText = "U.Med.";

                dgvArticulos.Columns[0].Width = 50;
                dgvArticulos.Columns[1].Width = 90;
                dgvArticulos.Columns[2].Width = 350;
                dgvArticulos.Columns[3].Width = 80;
                dgvArticulos.Columns[4].Width = 95;

                dgvArticulos.Columns["indDetraccion"].Visible = false;
                dgvArticulos.Columns["tipDetraccion"].Visible = false;
                //dgvArticulos.Columns["TasaDetraccion"].Visible = false;
            }

            if (Tipo == "Articulo")
            {
                if (ConLista == "N")
                {
                    #region Articulos sin Lista de Precio
 
                    dgvArticulos.Columns[0].Visible = false;
                    dgvArticulos.Columns[3].Visible = false;
                    dgvArticulos.Columns[4].Visible = false;
                    dgvArticulos.Columns[5].Visible = false;
                    dgvArticulos.Columns[6].Visible = false;
                    dgvArticulos.Columns[7].Visible = false;
                    dgvArticulos.Columns[8].Visible = false;
                    dgvArticulos.Columns[10].Visible = false;
                    dgvArticulos.Columns[11].Visible = false;
                    dgvArticulos.Columns[14].Visible = false;
                    dgvArticulos.Columns[16].Visible = false;
                    dgvArticulos.Columns[17].Visible = false;
                    //dgvArticulos.Columns[18].Visible = false;
                    dgvArticulos.Columns[19].Visible = false;

                    dgvArticulos.Columns[1].Width = 75;
                    dgvArticulos.Columns[1].HeaderText = "Cód.Arti.";
                    dgvArticulos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgvArticulos.Columns[2].Width = 420;
                    dgvArticulos.Columns[2].HeaderText = "Descripción";

                    dgvArticulos.Columns[9].Width = 90;
                    dgvArticulos.Columns[9].HeaderText = "Unid.Envase";

                    dgvArticulos.Columns[12].Width = 90;
                    dgvArticulos.Columns[12].HeaderText = "Unid.Present.";

                    dgvArticulos.Columns[13].Width = 50;
                    dgvArticulos.Columns[13].HeaderText = "Cont.";
                    dgvArticulos.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvArticulos.Columns[13].DefaultCellStyle.Format = "N2";                   

                    dgvArticulos.Columns[15].Width = 50;
                    dgvArticulos.Columns[15].HeaderText = "Peso";
                    dgvArticulos.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvArticulos.Columns[15].DefaultCellStyle.Format = "N2";

                    dgvArticulos.Columns[18].Width = 70;
                    dgvArticulos.Columns[18].HeaderText = "Lote";
                    dgvArticulos.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgvArticulos.Columns["indDetraccion"].Visible = false;
                    dgvArticulos.Columns["tipDetraccion"].Visible = false;
                    //dgvArticulos.Columns["TasaDetraccion"].Visible = false;

                    #endregion
                }
                else
                {
                    #region Articulos con Lista de Precio

                    dgvArticulos.Columns[0].Visible = false;
                    dgvArticulos.Columns[6].Visible = false;
                    dgvArticulos.Columns[7].Visible = false;
                    dgvArticulos.Columns[8].Visible = false;
                    dgvArticulos.Columns[9].Visible = false;
                    dgvArticulos.Columns[10].Visible = false;
                    dgvArticulos.Columns[11].Visible = false;
                    dgvArticulos.Columns[12].Visible = false;
                    dgvArticulos.Columns[13].Visible = false;
                    dgvArticulos.Columns[14].Visible = false;
                    dgvArticulos.Columns[15].Visible = false;
                    dgvArticulos.Columns[16].Visible = false;
                    dgvArticulos.Columns[17].Visible = false;
                    dgvArticulos.Columns[18].Visible = false;
                    dgvArticulos.Columns[19].Visible = false;
                    dgvArticulos.Columns[20].Visible = false;
                    dgvArticulos.Columns[21].Visible = false;
                    dgvArticulos.Columns[22].Visible = false;
                    dgvArticulos.Columns[23].Visible = false;
                    dgvArticulos.Columns[24].Visible = false;
                    dgvArticulos.Columns[25].Visible = false;
                    dgvArticulos.Columns[26].Visible = false;
                    dgvArticulos.Columns[27].Visible = false;
                    dgvArticulos.Columns[28].Visible = false;
                    dgvArticulos.Columns[29].Visible = false;
                    dgvArticulos.Columns[30].Visible = false;

                    dgvArticulos.Columns[1].Width = 90;
                    dgvArticulos.Columns[1].HeaderText = "Cód.Arti.";
                    dgvArticulos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgvArticulos.Columns[2].Width = 500;
                    dgvArticulos.Columns[2].HeaderText = "Descripción";

                    dgvArticulos.Columns[3].Width = 70;
                    dgvArticulos.Columns[3].HeaderText = "Contenido";
                    dgvArticulos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvArticulos.Columns[4].Width = 70;
                    dgvArticulos.Columns[4].HeaderText = "Capacidad";
                    dgvArticulos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvArticulos.Columns[5].Width = 90;
                    dgvArticulos.Columns[5].HeaderText = "Precio B.";
                    dgvArticulos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvArticulos.Columns["indDetraccion"].Visible = false;
                    dgvArticulos.Columns["tipDetraccion"].Visible = false;
                    //dgvArticulos.Columns["TasaDetraccion"].Visible = false;

                    #endregion
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                if (Tipo == "Stock")
                {
                    #region Con Stock
                    
                    var oListaStockTemp = (from x in oListaStock
                                           select new
                                           {
                                               x.idArticulo,
                                               x.codArticulo,
                                               x.desArticulo,
                                               x.canStock,
                                               x.nomUMedidaPres,
                                               x.Contenido,
                                               x.nomUMedidaEnv,
                                               x.LoteAlmacen,
                                               x.LoteProveedor,
                                               x.PesoUnitario,
                                               x.fecPrueba,
                                               x.fecProceso,
                                               x.PorcentajeGerminacion,
                                               x.Batch,
                                               x.RazonSocial,
                                               x.NombreOrigen,
                                               x.NombreProcedencia,
                                               x.Lote,
                                               x.idTipoArticulo,
                                               x.codTipoMedAlmacen,
                                               x.codUniMedAlmacen,
                                               x.indDetraccion,
                                               x.tipDetraccion,
                                               x.CostoUnitPromBase,
                                               x.CostoUnitPromSecu
                                           });

                    dgvArticulos.DataSource = oListaStockTemp.ToList();
                    FormatoGrid(Tipo);
                    dgvArticulos.AutoResizeColumns();

                    #endregion
                }

                if (Tipo == "StockReque")
                {
                    #region Con Stock

                    var oListaStockTemp = (from x in oListaStock
                                           select new
                                           {
                                               x.idArticulo,
                                               x.codArticulo,
                                               x.desArticulo,
                                               x.canStock,
                                               x.nomUMedida,
                                               x.idTipoArticulo,
                                               x.codTipoMedAlmacen,
                                               x.codUniMedAlmacen,
                                               x.indDetraccion,
                                               x.tipDetraccion,
                                               x.TasaDetraccion
                                           });

                    dgvArticulos.DataSource = oListaStockTemp.ToList();
                    FormatoGrid(Tipo);

                    #endregion
                }

                if (Tipo == "Articulo")
                {
                    if (ConLista == "N")
                    {
                        #region Articulos sin Lista de Precio

                        var oListaArticulosTemp = (from x in oListaArticulos
                                                   select new
                                                   {
                                                       x.idArticulo,
                                                       x.codArticulo,
                                                       x.nomArticulo,
                                                       x.numVerPlanCuentas,
                                                       x.codCuentaAdm,
                                                       x.codCuentaVta,
                                                       x.codCuentaPro,
                                                       x.idUniMedEnvase,
                                                       x.nomUMedidaEnv,
                                                       x.codTipoMedPresentacion,
                                                       x.codUniMedPresentacion,
                                                       x.nomUMedidaPres,
                                                       x.Contenido,
                                                       x.idTipoArticulo,
                                                       x.PesoUnitario,
                                                       x.codUniMedAlmacen,
                                                       x.Lote,
                                                       x.LoteProveedor,
                                                       x.indDetraccion,
                                                       x.tipDetraccion
                                                   });

                        dgvArticulos.DataSource = oListaArticulosTemp.ToList();  

                        #endregion
                    }
                    else
                    {
                        #region Articulos con Lista de Precio

                        var oListaArticulosTemp = (from x in oListaArticulos
                                                   select new
                                                   {
                                                       x.idArticulo,
                                                       x.codArticulo,
                                                       x.nomArticulo,
                                                       x.Contenido,
                                                       x.Capacidad,
                                                       x.PrecioBruto,
                                                       x.numVerPlanCuentas,
                                                       x.codCuentaAdm,
                                                       x.codCuentaVta,
                                                       x.codCuentaPro,
                                                       x.idUniMedEnvase,
                                                       x.codTipoMedPresentacion,
                                                       x.codUniMedPresentacion,
                                                       x.codUniMedAlmacen,
                                                       x.PorDscto1,
                                                       x.PorDscto2,
                                                       x.PorDscto3,
                                                       x.MontoDscto1,
                                                       x.MontoDscto2,
                                                       x.MontoDscto3,
                                                       x.PrecioValorVenta,
                                                       x.flgisc,
                                                       x.TipoImpSelectivo,
                                                       x.porisc,
                                                       x.isc,
                                                       x.flgigv,
                                                       x.porigv,
                                                       x.igv,
                                                       x.PrecioVenta,
                                                       x.indDetraccion,
                                                       x.tipDetraccion
                                                   });

                        dgvArticulos.DataSource = oListaArticulosTemp.ToList(); 

                        #endregion
                    }

                    FormatoGrid(Tipo);
                }

                lblTitPnlBase.Text = "Registros " + dgvArticulos.RowCount.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Aceptar()
        {
            try
            {
                if (dgvArticulos.Rows.Count > Variables.Cero)
                {
                    DataGridViewRow Fila = dgvArticulos.CurrentRow;
                    oArticulo = new ArticuloServE();

                    if (Tipo == "Stock")
                    {
                        oArticulo.idArticulo = Convert.ToInt32(Fila.Cells["idArticulo"].Value);
                        oArticulo.codArticulo = Convert.ToString(Fila.Cells["codArticulo"].Value);
                        oArticulo.nomArticulo = Convert.ToString(Fila.Cells["desArticulo"].Value);
                        oArticulo.nomUMedidaPres = Convert.ToString(Fila.Cells["nomUMedidaPres"].Value);
                        oArticulo.Contenido = Convert.ToDecimal(Fila.Cells["Contenido"].Value);
                        oArticulo.PesoUnitario = Convert.ToDecimal(Fila.Cells["PesoUnitario"].Value);
                        oArticulo.nomUMedidaEnv = Convert.ToString(Fila.Cells["nomUMedidaEnv"].Value);
                        oArticulo.Lote = Convert.ToString(Fila.Cells["Lote"].Value);
                        oArticulo.LoteProveedor = Convert.ToString(Fila.Cells["LoteProveedor"].Value);
                        oArticulo.Stock = Convert.ToDecimal(Fila.Cells["canStock"].Value);
                        oArticulo.codUniMedAlmacen = Convert.ToInt32(Fila.Cells["codUniMedAlmacen"].Value);
                        oArticulo.idTipoArticulo = Convert.ToInt32(Fila.Cells["idTipoArticulo"].Value);
                        oArticulo.indDetraccion = Convert.ToBoolean(Fila.Cells["indDetraccion"].Value);
                        oArticulo.tipDetraccion = Convert.ToString(Fila.Cells["tipDetraccion"].Value);
                    }

                    if (Tipo == "StockReque")
                    {
                        oArticulo.idArticulo = Convert.ToInt32(Fila.Cells[0].Value);
                        oArticulo.codArticulo = Convert.ToString(Fila.Cells[1].Value);
                        oArticulo.nomArticulo = Convert.ToString(Fila.Cells[2].Value);
                        oArticulo.Stock = Convert.ToDecimal(Fila.Cells[3].Value);
                        oArticulo.idTipoArticulo = Convert.ToInt32(Fila.Cells[5].Value);
                        oArticulo.codUniMedAlmacen = Convert.ToInt32(Fila.Cells[7].Value);
                        oArticulo.indDetraccion = Convert.ToBoolean(Fila.Cells["indDetraccion"].Value);
                        oArticulo.tipDetraccion = Convert.ToString(Fila.Cells["tipDetraccion"].Value);
                        //oArticulo.TasaDetraccion = Convert.ToDecimal(Fila.Cells["TasaDetraccion"].Value);
                    }

                    if (Tipo == "Articulo")
                    {
                        oArticulo = new ArticuloServE();

                        if (ConLista == "N")
                        {
                            oArticulo.idArticulo = Convert.ToInt32(Fila.Cells[0].Value);
                            oArticulo.codArticulo = Convert.ToString(Fila.Cells[1].Value);
                            oArticulo.nomArticulo = Convert.ToString(Fila.Cells[2].Value);
                            oArticulo.numVerPlanCuentas = Convert.ToString(Fila.Cells[3].Value);
                            oArticulo.codCuentaAdm = Convert.ToString(Fila.Cells[4].Value);
                            oArticulo.codCuentaVta = Convert.ToString(Fila.Cells[5].Value);
                            oArticulo.codCuentaPro = Convert.ToString(Fila.Cells[6].Value);
                            oArticulo.nomUMedidaEnv = Convert.ToString(Fila.Cells[9].Value);
                            oArticulo.nomUMedidaPres = Convert.ToString(Fila.Cells[12].Value);
                            oArticulo.Contenido = Convert.ToDecimal(Fila.Cells[13].Value);
                            oArticulo.Lote = Convert.ToString(Fila.Cells[14].Value);
                            oArticulo.LoteProveedor = Convert.ToString(Fila.Cells[15].Value);
                            //oArticulo.PesoUnitario = Convert.ToDecimal(Fila.Cells[15].Value);
                            oArticulo.codUniMedAlmacen = Convert.ToInt32(Fila.Cells[17].Value);
                            oArticulo.indDetraccion = Convert.ToBoolean(Fila.Cells["indDetraccion"].Value);
                            oArticulo.tipDetraccion = Convert.ToString(Fila.Cells["tipDetraccion"].Value);
                            //oArticulo.TasaDetraccion = Convert.ToDecimal(Fila.Cells["TasaDetraccion"].Value);
                        }
                        else
                        {
                            oArticulo.idArticulo = Convert.ToInt32(Fila.Cells[0].Value);
                            oArticulo.codArticulo = Convert.ToString(Fila.Cells[1].Value);
                            oArticulo.nomArticulo = Convert.ToString(Fila.Cells[2].Value);
                            oArticulo.Contenido = Convert.ToDecimal(Fila.Cells[3].Value);
                            oArticulo.Capacidad = Convert.ToDecimal(Fila.Cells[4].Value);
                            oArticulo.PrecioBruto = Convert.ToDecimal(Fila.Cells[5].Value);
                            oArticulo.numVerPlanCuentas = Convert.ToString(Fila.Cells[6].Value);
                            oArticulo.codCuentaAdm = Convert.ToString(Fila.Cells[7].Value);
                            oArticulo.codCuentaVta = Convert.ToString(Fila.Cells[8].Value);
                            oArticulo.codCuentaPro = Convert.ToString(Fila.Cells[9].Value);
                            oArticulo.idUniMedEnvase = Convert.ToInt32(Fila.Cells[11].Value);
                            oArticulo.codTipoMedPresentacion = Convert.ToInt32(Fila.Cells[12].Value);
                            oArticulo.codUniMedPresentacion = Convert.ToInt32(Fila.Cells[13].Value);
                            oArticulo.codUniMedAlmacen = Convert.ToInt32(Fila.Cells[15].Value);
                            oArticulo.PorDscto1 = Convert.ToDecimal(Fila.Cells[16].Value);
                            oArticulo.PorDscto2 = Convert.ToDecimal(Fila.Cells[17].Value);
                            oArticulo.PorDscto3 = Convert.ToDecimal(Fila.Cells[18].Value);
                            oArticulo.MontoDscto1 = Convert.ToDecimal(Fila.Cells[19].Value);
                            oArticulo.MontoDscto2 = Convert.ToDecimal(Fila.Cells[20].Value);
                            oArticulo.MontoDscto3 = Convert.ToDecimal(Fila.Cells[21].Value);
                            oArticulo.PrecioValorVenta = Convert.ToDecimal(Fila.Cells[22].Value);
                            oArticulo.flgisc = Convert.ToBoolean(Fila.Cells[23].Value);
                            oArticulo.TipoImpSelectivo = Convert.ToString(Fila.Cells[24].Value);
                            oArticulo.porisc = Convert.ToDecimal(Fila.Cells[25].Value);
                            oArticulo.isc = Convert.ToDecimal(Fila.Cells[26].Value);
                            oArticulo.flgigv = Convert.ToBoolean(Fila.Cells[27].Value);
                            oArticulo.porigv = Convert.ToDecimal(Fila.Cells[28].Value);
                            oArticulo.igv = Convert.ToDecimal(Fila.Cells[29].Value);
                            oArticulo.PrecioVenta = Convert.ToDecimal(Fila.Cells[30].Value);
                            oArticulo.indDetraccion = Convert.ToBoolean(Fila.Cells["indDetraccion"].Value);
                            oArticulo.tipDetraccion = Convert.ToString(Fila.Cells["tipDetraccion"].Value);
                            //oArticulo.TasaDetraccion = Convert.ToDecimal(Fila.Cells["TasaDetraccion"].Value);
                        }
                    }

                    base.Aceptar();
                }
                else
                {
                    Global.MensajeFault("No hay datos. Cierre la ventana.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmBusquedaArticulosPorFiltro_Load(object sender, EventArgs e)
        {
            dgvArticulos.Focus();
            Buscar();
        }

        private void dgvArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Aceptar();
            }
        }

        private void dgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvArticulos.Rows.Count > 0)
                {
                    Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtArticulos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (oListaArticulos != null && oListaArticulos.Count > Variables.Cero)
                //{
                //    BuscarFiltro();
                //}

                //if (oListaStock != null && oListaStock.Count > Variables.Cero)
                //{
                //    BuscarFiltro();
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

    }
}
