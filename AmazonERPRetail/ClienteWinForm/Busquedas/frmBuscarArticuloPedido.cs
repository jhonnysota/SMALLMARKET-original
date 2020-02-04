using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Generales;
using Entidades.Almacen;
using Infraestructura.Enumerados;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarArticuloPedido : FrmBusquedaBase
    {

        #region Constructores

        public frmBuscarArticuloPedido()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            if (VariablesLocales.SesionUsuario.Empresa.indCalzado)
            {
                Size = new Size(610, 452);
            }
            
            FormatoGrid(dgvArticulo, true);
            LlenarTipoArticulo();
        }

        //Con stock
        public frmBuscarArticuloPedido(AlmacenE oAlmacenTmp, String TipoListado_ = "", String Anio_ = "", String Mes_ = "", String EsCotizacion_ = "N")
            :this()
        {
            TipoArticulo = oAlmacenTmp.tipAlmacen == null ? Variables.Cero : Convert.ToInt32(oAlmacenTmp.tipAlmacen);
            TipoListado = TipoListado_;
            idAlmacen = Convert.ToInt32(oAlmacenTmp.idAlmacen);
            indLote = oAlmacenTmp.VerificaLote;
            AnioPedido = Anio_;
            MesPedido = Mes_;
            EsCotizacion = EsCotizacion_;
        } 

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public ArticuloServE Articulo = null;
        Int32 TipoArticulo = Variables.Cero;
        String TipoListado = String.Empty;
        Int32 idAlmacen = Variables.Cero;
        String AnioPedido = String.Empty;
        String MesPedido = String.Empty;
        Boolean indLote = false;
        String EsCotizacion = "N";

        List<StockE> oListaStock = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarTipoArticulo()
        {
            cboTipoArticulo.DataSource = null;
            List<ParTabla> ListaTipoArticulo = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ParTabla p = new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos };
            ListaTipoArticulo.Add(p);
            ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in ListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
        }

        void Formato(String Tipo = "")
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            if (Tipo == "stock")
            {
                if (!VariablesLocales.SesionUsuario.Empresa.indCalzado)
                {
                    dgvArticulo.Columns["idArticulo"].Visible = false;
                    dgvArticulo.Columns["idTipoArticulo"].Visible = false;
                    dgvArticulo.Columns["codTipoMedAlmacen"].Visible = false;
                    dgvArticulo.Columns["codUniMedAlmacen"].Visible = false;
                    dgvArticulo.Columns["indDetraccion"].Visible = false;
                    dgvArticulo.Columns["tipDetraccion"].Visible = false;
                    dgvArticulo.Columns["CostoUnitPromBase"].Visible = false;
                    dgvArticulo.Columns["CostoUnitPromSecu"].Visible = false;

                    dgvArticulo.Columns["codArticulo"].HeaderText = "Cód.Arti.";
                    dgvArticulo.Columns["codArticulo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgvArticulo.Columns["desArticulo"].HeaderText = "Descripción";

                    dgvArticulo.Columns["canStock"].DefaultCellStyle.Format = "N2";
                    dgvArticulo.Columns["canStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvArticulo.Columns["canStock"].HeaderText = "Stock";

                    dgvArticulo.Columns["nomUMedidaPres"].HeaderText = "U.M.Pres.";
                    dgvArticulo.Columns["Contenido"].HeaderText = "Conten.";
                    dgvArticulo.Columns["nomUMedidaEnv"].HeaderText = "U.M.Env.";
                    dgvArticulo.Columns["LoteAlmacen"].HeaderText = "Lote";
                    dgvArticulo.Columns["LoteProveedor"].HeaderText = "Lote Prov.";

                    dgvArticulo.Columns["PesoUnitario"].HeaderText = "Peso Uni.";
                    dgvArticulo.Columns["PesoUnitario"].DefaultCellStyle.Format = "N3";
                    dgvArticulo.Columns["PesoUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvArticulo.Columns["fecPrueba"].DefaultCellStyle.Format = "d";
                    dgvArticulo.Columns["fecPrueba"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvArticulo.Columns["fecPrueba"].HeaderText = "Fec.Prueba";

                    dgvArticulo.Columns["fecProceso"].DefaultCellStyle.Format = "d";
                    dgvArticulo.Columns["fecProceso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvArticulo.Columns["fecProceso"].HeaderText = "Fec.Ingre.";

                    dgvArticulo.Columns["PorcentajeGerminacion"].HeaderText = "% Ger.";
                    dgvArticulo.Columns["PorcentajeGerminacion"].DefaultCellStyle.Format = "N2";
                    dgvArticulo.Columns["PorcentajeGerminacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvArticulo.Columns["Batch"].HeaderText = "Batch";
                    dgvArticulo.Columns["RazonSocial"].HeaderText = "Proveedor";
                    dgvArticulo.Columns["NombreOrigen"].HeaderText = "Pais Origen";
                    dgvArticulo.Columns["NombreProcedencia"].HeaderText = "Pais Proced.";
                    dgvArticulo.Columns["Lote"].HeaderText = "Lote Sistema"; 
                }
                else
                {
                    dgvArticulo.Columns["idArticulo"].Visible = false;
                    dgvArticulo.Columns["idTipoArticulo"].Visible = false;
                    dgvArticulo.Columns["codTipoMedAlmacen"].Visible = false;
                    dgvArticulo.Columns["codUniMedAlmacen"].Visible = false;
                    dgvArticulo.Columns["indDetraccion"].Visible = false;
                    dgvArticulo.Columns["tipDetraccion"].Visible = false;
                    dgvArticulo.Columns["CostoUnitPromBase"].Visible = false;
                    dgvArticulo.Columns["CostoUnitPromSecu"].Visible = false;
                    dgvArticulo.Columns["nomUMedidaPres"].Visible = false;
                    dgvArticulo.Columns["Contenido"].Visible = false;
                    dgvArticulo.Columns["nomUMedidaEnv"].Visible = false;
                    dgvArticulo.Columns["LoteAlmacen"].Visible = false;
                    dgvArticulo.Columns["LoteProveedor"].Visible = false;
                    dgvArticulo.Columns["PesoUnitario"].Visible = false;
                    dgvArticulo.Columns["fecPrueba"].Visible = false;
                    dgvArticulo.Columns["fecProceso"].Visible = false;
                    dgvArticulo.Columns["PorcentajeGerminacion"].Visible = false;
                    dgvArticulo.Columns["Batch"].Visible = false;
                    dgvArticulo.Columns["RazonSocial"].Visible = false;
                    dgvArticulo.Columns["NombreOrigen"].Visible = false;
                    dgvArticulo.Columns["NombreProcedencia"].Visible = false;

                    dgvArticulo.Columns["codArticulo"].HeaderText = "Cód.Arti.";
                    dgvArticulo.Columns["codArticulo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgvArticulo.Columns["desArticulo"].HeaderText = "Descripción";

                    dgvArticulo.Columns["canStock"].DefaultCellStyle.Format = "N2";
                    dgvArticulo.Columns["canStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvArticulo.Columns["canStock"].HeaderText = "Stock";
                    
                    dgvArticulo.Columns["Lote"].HeaderText = "Talla";
                    dgvArticulo.Columns["Lote"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }

            if (Tipo == "art")
            {
                #region Articulos sin stock ni lote

                dgvArticulo.Columns[0].Visible = false;
                dgvArticulo.Columns[1].Visible = false;
                dgvArticulo.Columns[5].Visible = false;
                dgvArticulo.Columns[6].Visible = false;
                dgvArticulo.Columns[7].Visible = false;
                dgvArticulo.Columns[8].Visible = false;
                dgvArticulo.Columns[9].Visible = false;
                dgvArticulo.Columns[10].Visible = false;
                dgvArticulo.Columns[11].Visible = false;
                dgvArticulo.Columns[12].Visible = false;
                dgvArticulo.Columns[13].Visible = false;
                dgvArticulo.Columns[14].Visible = false;
                dgvArticulo.Columns[15].Visible = false;
                dgvArticulo.Columns[16].Visible = false;
                dgvArticulo.Columns[17].Visible = false;
                dgvArticulo.Columns[18].Visible = false;
                dgvArticulo.Columns[19].Visible = false;
                dgvArticulo.Columns[20].Visible = false;
                dgvArticulo.Columns[21].Visible = false;
                dgvArticulo.Columns[22].Visible = false;
                dgvArticulo.Columns[23].Visible = false;
                dgvArticulo.Columns[24].Visible = false;
                dgvArticulo.Columns[25].Visible = false;
                dgvArticulo.Columns[26].Visible = false;
                dgvArticulo.Columns[27].Visible = false;
                dgvArticulo.Columns[28].Visible = false;
                dgvArticulo.Columns[29].Visible = false;
                dgvArticulo.Columns[30].Visible = false;
                dgvArticulo.Columns[31].Visible = false;
                dgvArticulo.Columns[32].Visible = false;
                dgvArticulo.Columns[33].Visible = false;
                dgvArticulo.Columns[34].Visible = false;
                dgvArticulo.Columns[35].Visible = false;
                dgvArticulo.Columns[36].Visible = false;
                dgvArticulo.Columns[37].Visible = false;
                dgvArticulo.Columns[38].Visible = false;
                dgvArticulo.Columns[39].Visible = false;
                dgvArticulo.Columns[40].Visible = false;
                dgvArticulo.Columns[41].Visible = false;
                //dgvArticulo.Columns[42].Visible = false;

                dgvArticulo.Columns[2].HeaderText = "Tip.Articulo";
                dgvArticulo.Columns[3].HeaderText = "Cód.Articulo";
                dgvArticulo.Columns[4].HeaderText = "Descripción";

                #endregion
            }
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                if (TipoListado == "stock") //Cuando maneja Stock / Lote - Sin Lote
                {
                    if (indLote)
                    {
                        oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa, idAlmacen, Convert.ToInt32(cboTipoArticulo.SelectedValue), AnioPedido, MesPedido, true, "", "", EsCotizacion);
                    }
                    else
                    {
                        oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa, idAlmacen, Convert.ToInt32(cboTipoArticulo.SelectedValue), AnioPedido, MesPedido, false, "", "", EsCotizacion);
                    }

                    if (!String.IsNullOrWhiteSpace(txtFiltro.Text))
                    {
                        oListaStock = (from x in oListaStock where x.desArticulo.ToUpper().Contains(txtFiltro.Text.ToUpper()) select x).ToList();
                    }

                    var oListaStockTemp = (from x in oListaStock
                                           select new
                                           {
                                               x.idArticulo,
                                               x.codArticulo,
                                               x.desArticulo,
                                               x.canStock,
                                               x.nomUMedidaEnv,
                                               x.Contenido,
                                               x.nomUMedidaPres,
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

                    dgvArticulo.DataSource = bsBase.DataSource = (from x in oListaStockTemp.ToList() orderby x.idArticulo select x).ToList();
                    Formato(TipoListado);
                    dgvArticulo.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            try
            {
                if (dgvArticulo.Rows.Count > 0)
                {
                    DataGridViewRow Fila = dgvArticulo.CurrentRow;
                    Int32 FilasSeleccionadas = dgvArticulo.Rows.GetRowCount(DataGridViewElementStates.Selected);

                    if (TipoListado == "stock") //Con stock
                    {
                        Articulo = new ArticuloServE()
                        {
                            idArticulo = Convert.ToInt32(Fila.Cells["idArticulo"].Value),
                            codArticulo = Convert.ToString(Fila.Cells["codArticulo"].Value),
                            nomArticulo = Convert.ToString(Fila.Cells["desArticulo"].Value),
                            nomUMedidaPres = Convert.ToString(Fila.Cells["nomUMedidaPres"].Value),
                            Contenido = Convert.ToDecimal(Fila.Cells["Contenido"].Value),
                            PesoUnitario = Convert.ToDecimal(Fila.Cells["PesoUnitario"].Value),
                            nomUMedidaEnv = Convert.ToString(Fila.Cells["nomUMedidaEnv"].Value),
                            Lote = Convert.ToString(Fila.Cells["Lote"].Value),
                            LoteProveedor = Convert.ToString(Fila.Cells["LoteProveedor"].Value),
                            Stock = Convert.ToDecimal(Fila.Cells["canStock"].Value),
                            codUniMedAlmacen = Convert.ToInt32(Fila.Cells["codUniMedAlmacen"].Value),
                            idTipoArticulo = Convert.ToInt32(Fila.Cells["idTipoArticulo"].Value),
                            indDetraccion = Convert.ToBoolean(Fila.Cells["indDetraccion"].Value),
                            tipDetraccion = Convert.ToString(Fila.Cells["tipDetraccion"].Value)
                        };
                    }

                    #region Articulo sin stock ni lote

                    if (TipoListado == "art" || TipoListado == "")
                    {
                        //if (FilasSeleccionadas > 1)
                        //{
                        //    oListaArticulosVarios = new List<ArticuloServE>();

                        //    foreach (DataGridViewRow fil in dgvArticulo.Rows)
                        //    {
                        //        if (fil.Selected)
                        //        {
                        //            oListaArticulosVarios.Add((ArticuloServE)fil.DataBoundItem);
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    if (Articulo == null)
                        //    {
                        //        Articulo = new ArticuloServE();
                        //    }

                        //    Articulo = (ArticuloServE)Fila.DataBoundItem;
                        //}
                    }

                    #endregion

                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarArticuloPedido_Load(object sender, EventArgs e)
        {
            if (TipoArticulo != Variables.Cero)
            {
                cboTipoArticulo.SelectedValue = Convert.ToInt32(TipoArticulo);
            }
        }

        private void dgvArticulo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvArticulo, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvArticulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (TipoListado != "stock")
                //{
                //    if (dgvArticulo.Rows.GetRowCount(DataGridViewElementStates.Selected) > 1)
                //    {
                //        Global.MensajeComunicacion("Tiene que presionar el botón aceptar cuando quiere seleccionar mas de un item.");
                //        return;
                //    }
                //}

                Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void bsBase_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (bsBase.List.Count > 0)
            {
                gbResultados.Text = "Registros " + bsBase.Count.ToString();
            }
        } 

        #endregion

    }
}
