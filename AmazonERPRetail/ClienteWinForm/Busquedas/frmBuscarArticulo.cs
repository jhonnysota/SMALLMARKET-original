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
    public partial class frmBuscarArticulo : FrmBusquedaBase
    {

        #region Constructores

        public frmBuscarArticulo()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvArticulo, true);
        }

        //Con stock
        public frmBuscarArticulo(AlmacenE oAlmacenTmp, String TipoListado_ = "", String Anio_ =  "", String Mes_ = "", String EsCotizacion_ = "N")
            : this()
        {
            TipoArticulo = oAlmacenTmp.tipAlmacen == null ? Variables.Cero : Convert.ToInt32(oAlmacenTmp.tipAlmacen);
            TipoListado = TipoListado_;
            idAlmacen = Convert.ToInt32(oAlmacenTmp.idAlmacen);
            indLote = oAlmacenTmp.VerificaLote;
            AnioPedido = Anio_;
            MesPedido = Mes_;
            EsCotizacion = EsCotizacion_;
        }

        public frmBuscarArticulo(Int32 tipArticulo, String TipoListado_ = "")
            : this()
        {
            TipoArticulo = tipArticulo;
            TipoListado = TipoListado_;

            //Para el Item de Orden de Compra...
            if (TipoListado_ == "E" || TipoListado_ == "S")
            {
                cboTipoArticulo.Enabled = true;
            }
            else
            {
                cboTipoArticulo.Enabled = false;
            }
        }

        //Lista de Precio...
        public frmBuscarArticulo(AlmacenE oAlmacenTmp, String TipoListado_, Int32 idListaPrecioPed)
            : this()
        {
            TipoArticulo = oAlmacenTmp.tipAlmacen == null ? Variables.Cero : Convert.ToInt32(oAlmacenTmp.tipAlmacen);
            TipoListado = TipoListado_;
            idAlmacen = Convert.ToInt32(oAlmacenTmp.idAlmacen);
            indLote = oAlmacenTmp.VerificaLote;
            idListaPrecioReal = idListaPrecioPed;
        }

        #endregion Constructores

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }

        public ArticuloServE Articulo = null;
        public List<ArticuloServE> oListaArticulosVarios = null;
        Int32 TipoArticulo = Variables.Cero;
        String TipoListado = String.Empty;
        Int32 idAlmacen = Variables.Cero;
        String AnioPedido = String.Empty;
        String MesPedido = String.Empty;
        Boolean indLote = false;
        Int32 idListaPrecioReal = 0;
        List<ArticuloServE> oListaArticulos = null;
        List<StockE> oListaStock = null;
        String EsCotizacion = "N";

        #endregion Variables

        #region Procedimientos de Usuario

        void LlenarTipoArticulo()
        {
            cboTipoArticulo.DataSource = null;
            List<ParTabla> ListaTipoArticulo = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");

            if (TipoListado == "E" || TipoListado == "S")
            {
                ListaTipoArticulo = (from z in ListaTipoArticulo
                                     where z.NemoTecnico != "O1" && z.NemoTecnico != "O10"
                                     select z).ToList();
            }

            ListaTipoArticulo.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in ListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
        }

        void BuscarFiltro()
        {
            if (TipoListado != "stock")
            {
                bsBase.DataSource = (from x in oListaArticulos
                                     where x.nomArticulo.ToUpper().Contains(txtFiltro.Text.ToUpper())
                                     select x).ToList();
            }
            //else
            //{
            //    bsBase.DataSource = (from x in oListaStock
            //                         where x.desArticulo.ToUpper().Contains(txtFiltro.Text.ToUpper())
            //                         select x).ToList();
            //}
        }

        void Formato(String Tipo = "")
        {
            if (Tipo == "stock")
            {
                dgvArticulo.Columns[0].Visible = false;
                dgvArticulo.Columns[1].Visible = false;
                //dgvArticulo.Columns[4].Visible = false;
                dgvArticulo.Columns[5].Visible = false;
                dgvArticulo.Columns[6].Visible = false;

                dgvArticulo.Columns[8].Visible = false;
                dgvArticulo.Columns[11].Visible = false;
                dgvArticulo.Columns[12].Visible = false;

                dgvArticulo.Columns[15].Visible = false;
                dgvArticulo.Columns[16].Visible = false;
                dgvArticulo.Columns[17].Visible = false;

                //dgvArticulo.Columns[18].Visible = false;
                //dgvArticulo.Columns[19].Visible = false;
                //dgvArticulo.Columns[20].Visible = false;
                //dgvArticulo.Columns[21].Visible = false;
                //dgvArticulo.Columns[25].Visible = false;
                //dgvArticulo.Columns[26].Visible = false;

                if (!indLote)
                {
                    dgvArticulo.Columns[7].Visible = false;
                    dgvArticulo.Columns[8].Visible = false;
                    dgvArticulo.Columns[9].Visible = false;
                    dgvArticulo.Columns[10].Visible = false;
                    //dgvArticulo.Columns[13].Visible = false;
                    //dgvArticulo.Columns[14].Visible = false;
                    //dgvArticulo.Columns[18].Visible = false;
                    //dgvArticulo.Columns[23].Visible = false;
                }

                dgvArticulo.Columns[2].Width = 90;
                dgvArticulo.Columns[2].HeaderText = "Cód.Arti.";
                dgvArticulo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvArticulo.Columns[3].Width = 300;
                dgvArticulo.Columns[3].HeaderText = "Descripción";

                dgvArticulo.Columns[4].Width = 70;
                dgvArticulo.Columns[4].DefaultCellStyle.Format = "N4";
                dgvArticulo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvArticulo.Columns[4].HeaderText = "Stock";

                dgvArticulo.Columns[7].Width = 70;
                dgvArticulo.Columns[7].DefaultCellStyle.Format = "d";
                dgvArticulo.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvArticulo.Columns[7].HeaderText = "Fec.Venc.";

                dgvArticulo.Columns[9].Width = 70;
                dgvArticulo.Columns[9].HeaderText = "Lote";

                dgvArticulo.Columns[10].Width = 70;
                dgvArticulo.Columns[10].HeaderText = "Lote Prov.";

                dgvArticulo.Columns[13].Width = 80;
                dgvArticulo.Columns[13].HeaderText = "U.Med.Al.";

                dgvArticulo.Columns[14].Width = 50;
                dgvArticulo.Columns[14].DefaultCellStyle.Format = "##0.00";
                dgvArticulo.Columns[14].HeaderText = "Conten.";

                dgvArticulo.Columns[18].Width = 80;
                dgvArticulo.Columns[18].HeaderText = "U.Med.Det.";
                
                dgvArticulo.Columns[19].Width = 100;
                dgvArticulo.Columns[19].HeaderText = "Marca";
            }

            if (Tipo == "art" || Tipo == "")
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

            if (Tipo == "ArtAlmacen" || Tipo == "E" || Tipo == "N" || Tipo == "S")
            {
                if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
                {
                    dgvArticulo.Columns[0].Visible = false;
                }

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

                dgvArticulo.Columns[0].HeaderText = "ID.";
                dgvArticulo.Columns[1].HeaderText = "Cód.Arti.";
                dgvArticulo.Columns[2].HeaderText = "Descripción";
                dgvArticulo.Columns[3].HeaderText = "U.Med.Env.";
                dgvArticulo.Columns[4].HeaderText = "U.Med.Pres.";
                dgvArticulo.Columns[5].HeaderText = "Conte.";
                dgvArticulo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvArticulo.Columns[5].DefaultCellStyle.Format = "N2";
                dgvArticulo.Columns[6].HeaderText = "Peso Kg.";
                dgvArticulo.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvArticulo.Columns[6].DefaultCellStyle.Format = "N3";

                dgvArticulo.Columns[0].Width = 50;
                dgvArticulo.Columns[1].Width = 85;
                dgvArticulo.Columns[2].Width = 350;
                dgvArticulo.Columns[3].Width = 80;
                dgvArticulo.Columns[4].Width = 80;
                dgvArticulo.Columns[5].Width = 90;
                dgvArticulo.Columns[6].Width = 95;
            }

            if (Tipo == "ArtCalzado")
            {
                if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
                {
                    dgvArticulo.Columns[0].Visible = false;
                }

                dgvArticulo.Columns[3].Visible = false;
                dgvArticulo.Columns[4].Visible = false;
                dgvArticulo.Columns[6].Visible = false;

                for (int i = 8; i <= 43; i++)
                {
                    dgvArticulo.Columns[i].Visible = false;
                }

                dgvArticulo.Columns[0].HeaderText = "ID.";
                dgvArticulo.Columns[1].HeaderText = "Cód.Arti.";
                dgvArticulo.Columns[2].HeaderText = "Descripción";
                dgvArticulo.Columns[5].HeaderText = "U.Med.";
                dgvArticulo.Columns[7].HeaderText = "Serie";
                dgvArticulo.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvArticulo.Columns[7].DefaultCellStyle.Format = "N2";

                dgvArticulo.Columns[0].Width = 50;
                dgvArticulo.Columns[1].Width = 85;
                dgvArticulo.Columns[2].Width = 350;
                dgvArticulo.Columns[5].Width = 80;
                dgvArticulo.Columns[7].Width = 85;
            }

            #region Requerimientos

            if (Tipo == "StockReque")
            {
                dgvArticulo.Columns[5].Visible = false;
                dgvArticulo.Columns[6].Visible = false;
                dgvArticulo.Columns[7].Visible = false;

                dgvArticulo.Columns[0].HeaderText = "ID.";
                dgvArticulo.Columns[1].HeaderText = "Cód.Articulo";
                dgvArticulo.Columns[2].HeaderText = "Descripción";
                dgvArticulo.Columns[3].HeaderText = "Stock";
                dgvArticulo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvArticulo.Columns[3].DefaultCellStyle.Format = "N2";
                dgvArticulo.Columns[4].HeaderText = "U.Med.";

                dgvArticulo.Columns[0].Width = 50;
                dgvArticulo.Columns[1].Width = 90;
                dgvArticulo.Columns[2].Width = 350;
                dgvArticulo.Columns[3].Width = 80;
                dgvArticulo.Columns[4].Width = 95;
            }

            #endregion
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                String Filtro = "";

                if (!String.IsNullOrEmpty(txtFiltro.Text))
                {
                    Filtro = txtFiltro.Text;
                }

                if (TipoListado == "stock") //Cuando maneja Stock / Lote - Sin Lote
                {
                    #region Articulos cuando maneja Stock

                    if (indLote)
                    {
                        oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa, idAlmacen, Convert.ToInt32(cboTipoArticulo.SelectedValue), AnioPedido, MesPedido, true, "", "", EsCotizacion);
                    }
                    else
                    {
                        oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa, idAlmacen, Convert.ToInt32(cboTipoArticulo.SelectedValue), AnioPedido, MesPedido, false, "", "", EsCotizacion);
                    }

                    var oListaStockTemp = (from x in oListaStock
                                           select new
                                           {
                                               x.idTipoArticulo,
                                               x.idArticulo,
                                               x.codArticulo,
                                               x.desArticulo,
                                               x.canStock,
                                               x.CostoUnitPromBase,
                                               x.CostoUnitPromSecu,
                                               x.fecPrueba,
                                               x.fecProceso,
                                               x.Lote,
                                               x.LoteProveedor,
                                               x.codTipoMedAlmacen,
                                               x.codUniMedAlmacen,
                                               x.nomUMedida,
                                               x.Contenido,
                                               x.PesoUnitario,
                                               x.idTipoMedEnvase,
                                               x.idUniMedEnvase,
                                               x.nomUMedidaEnv,
                                               x.Marca
                                           });

                    //dgvArticulo.DataSource = oListaStockTemp;
                    dgvArticulo.DataSource = bsBase.DataSource = (from x in oListaStockTemp.ToList() orderby x.idArticulo select x).ToList();
                    Formato(TipoListado);

                    if (oListaStock != null && oListaStock.Count > Variables.Cero)
                    {
                        if (!String.IsNullOrEmpty(txtFiltro.Text))
                        {
                            //BuscarFiltro();
                            dgvArticulo.DataSource = bsBase.DataSource = (from x in oListaStockTemp
                                                                          where x.desArticulo.ToUpper().Contains(txtFiltro.Text.ToUpper())
                                                                          select x).ToList();
                        }
                    } 

                    #endregion
                }

                if (TipoListado == "art" || TipoListado == "") //Articulos sin stock ni lote
                {
                    #region Articulos

                    oListaArticulos = AgenteMaestros.Proxy.ListarArticulosBusqueda(VariablesLocales.SesionLocal.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue), Filtro);
                    bsBase.DataSource = (from x in oListaArticulos orderby x.idArticulo select x).ToList();

                    dgvArticulo.DataSource = bsBase;
                    Formato(TipoListado);

                    if (oListaArticulos != null && oListaArticulos.Count > Variables.Cero)
                    {
                        if (!String.IsNullOrEmpty(txtFiltro.Text))
                        {
                            BuscarFiltro();
                        }
                    }

                    dgvArticulo.AutoResizeColumns(); 

                    #endregion
                }

                if (TipoListado == "ArtAlmacen" || TipoListado == "E" || TipoListado == "N" || TipoListado == "S") //Almacen y Orden de Compra
                {
                    #region Para el Almacén

                    oListaArticulos = AgenteMaestros.Proxy.ListarArticulosBusqueda(VariablesLocales.SesionLocal.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue), Filtro);

                    var oListaStockTemp = (from x in oListaArticulos
                                           select new
                                           {
                                               x.idArticulo,
                                               x.codArticulo,
                                               x.nomArticulo,
                                               x.nomUMedidaEnv,
                                               x.nomUMedidaPres,
                                               x.Contenido,
                                               x.PesoUnitario,
                                               x.idUniMedEnvase,
                                               x.codTipoMedPresentacion,
                                               x.codUniMedPresentacion,
                                               x.codUniMedAlmacen,
                                               x.numVerPlanCuentas,
                                               x.codCuentaAdm,
                                               x.codCuentaVta,
                                               x.codCuentaPro,
                                               x.idTipoArticulo,
                                               x.indDetraccion,
                                               x.tipDetraccion
                                           });

                    dgvArticulo.DataSource = bsBase.DataSource = (from x in oListaStockTemp.ToList() orderby x.idArticulo select x).ToList();
                    Formato(TipoListado);
                    dgvArticulo.AutoResizeColumns();

                    #endregion
                }

                #region Requerimientos

                if (TipoListado == "StockReque")
                {
                    //#region Requerimientos con Stock

                    //if (indLote)
                    //{
                    //    bsBase.DataSource = oListaStock = AgenteAlmacen.Proxy.ListarStockArticuloRequeri(VariablesLocales.SesionLocal.IdEmpresa, idAlmacen,
                    //                                                                                    Convert.ToInt32(cboTipoArticulo.SelectedValue), AnioPedido, MesPedido, true, "", "");
                    //}
                    //else
                    //{
                    //    bsBase.DataSource = oListaStock = AgenteAlmacen.Proxy.ListarStockArticuloRequeri(VariablesLocales.SesionLocal.IdEmpresa, idAlmacen,
                    //                                                                                    Convert.ToInt32(cboTipoArticulo.SelectedValue), AnioPedido, MesPedido, false, "", "");
                    //}

                    //var oListaStockTemp = (from x in oListaStock
                    //                       select new
                    //                       {
                    //                           x.idArticulo,
                    //                           x.codArticulo,
                    //                           x.desArticulo,
                    //                           x.canStock,
                    //                           x.nomUMedida,
                    //                           x.idTipoArticulo,
                    //                           x.codTipoMedAlmacen,
                    //                           x.codUniMedAlmacen
                    //                       });

                    //dgvArticulo.DataSource = bsBase.DataSource = (from x in oListaStockTemp.ToList() orderby x.idArticulo select x).ToList();
                    //Formato(TipoListado);

                    //if (oListaStock != null && oListaStock.Count > Variables.Cero)
                    //{
                    //    if (!String.IsNullOrEmpty(txtFiltro.Text))
                    //    {
                    //        BuscarFiltro();
                    //    }
                    //}

                    //#endregion
                }

                if (TipoListado == "ArtiReque")
                {
                    //#region Requerimientos sin Stock

                    //#endregion
                }

                #endregion

                if (dgvArticulo.RowCount > 0)
                {
                    dgvArticulo.Focus();
                }

                //base.Buscar();
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

                   if (Fila == null)
                    {
                        Global.MensajeComunicacion("Seleccione un item dando click !!.");
                        return;
                    }

                    Int32 FilasSeleccionadas = dgvArticulo.Rows.GetRowCount(DataGridViewElementStates.Selected);

                    if (TipoListado == "stock") //Con stock
                    {
                        Articulo = new ArticuloServE()
                        {
                            idTipoArticulo = Convert.ToInt32(Fila.Cells["idTipoArticulo"].Value),
                            idArticulo = Convert.ToInt32(Fila.Cells["idArticulo"].Value),
                            codArticulo = Convert.ToString(Fila.Cells["codArticulo"].Value),
                            nomArticulo = Convert.ToString(Fila.Cells["desArticulo"].Value),
                            Stock = Convert.ToDecimal(Fila.Cells["canStock"].Value),
                            CostoSoles = Convert.ToDecimal(Fila.Cells["CostoUnitPromBase"].Value),
                            CostoDolares = Convert.ToDecimal(Fila.Cells["CostoUnitPromSecu"].Value),
                            Lote = Convert.ToString(Fila.Cells["Lote"].Value),
                            LoteProveedor = Convert.ToString(Fila.Cells["LoteProveedor"].Value),
                            codUniMedAlmacen = Convert.ToInt32(Fila.Cells["codUniMedAlmacen"].Value),
                            nomUMedida = Convert.ToString(Fila.Cells["nomUMedida"].Value),
                            Contenido = Convert.ToInt32(Fila.Cells["Contenido"].Value),
                            idUniMedEnvase = Convert.ToInt32(Fila.Cells["idUniMedEnvase"].Value),
                            nomUMedidaEnv = Convert.ToString(Fila.Cells["nomUMedidaEnv"].Value),
                            PesoUnitario = Convert.ToInt32(Fila.Cells["PesoUnitario"].Value)
                        };
                    }

                    #region Articulo sin stock ni lote

                    if (TipoListado == "art" || TipoListado == "")
                    {
                        if (FilasSeleccionadas > 1)
                        {
                            oListaArticulosVarios = new List<ArticuloServE>();

                            foreach (DataGridViewRow fil in dgvArticulo.Rows)
                            {
                                if (fil.Selected)
                                {
                                    oListaArticulosVarios.Add((ArticuloServE)fil.DataBoundItem);
                                }
                            }
                        }
                        else
                        {
                            if (Articulo == null)
                            {
                                Articulo = new ArticuloServE();
                            }

                            Articulo = (ArticuloServE)Fila.DataBoundItem;
                        }
                    }

                    #endregion

                    #region Para el Almacén y Orden de Compra

                    if (TipoListado == "ArtAlmacen" || TipoListado == "E" || TipoListado == "N" || TipoListado == "S") //Almacen y Orden de Compra
                    {
                        if (FilasSeleccionadas > 1)
                        {
                            oListaArticulosVarios = new List<ArticuloServE>();

                            foreach (DataGridViewRow fil in dgvArticulo.Rows)
                            {
                                if (fil.Selected)
                                {
                                    Articulo = new ArticuloServE()
                                    {
                                        idArticulo = Convert.ToInt32(fil.Cells["idArticulo"].Value),
                                        codArticulo = Convert.ToString(fil.Cells["codArticulo"].Value),
                                        nomArticulo = Convert.ToString(fil.Cells["nomArticulo"].Value),
                                        nomUMedidaPres = Convert.ToString(fil.Cells["nomUMedidaPres"].Value),
                                        Contenido = Convert.ToDecimal(fil.Cells["Contenido"].Value),
                                        PesoUnitario = Convert.ToDecimal(fil.Cells["PesoUnitario"].Value),
                                        idUniMedEnvase = Convert.ToInt32(fil.Cells["idUniMedEnvase"].Value),
                                        nomUMedidaEnv = Convert.ToString(fil.Cells["nomUMedidaEnv"].Value),
                                        codTipoMedPresentacion = Convert.ToInt32(fil.Cells["codTipoMedPresentacion"].Value),
                                        codUniMedPresentacion = Convert.ToInt32(fil.Cells["codUniMedPresentacion"].Value),
                                        codUniMedAlmacen = Convert.ToInt32(fil.Cells["codUniMedAlmacen"].Value),
                                        numVerPlanCuentas = Convert.ToString(fil.Cells["numVerPlanCuentas"].Value),
                                        codCuentaAdm = Convert.ToString(fil.Cells["codCuentaAdm"].Value),
                                        codCuentaVta = Convert.ToString(fil.Cells["codCuentaVta"].Value),
                                        codCuentaPro = Convert.ToString(fil.Cells["codCuentaPro"].Value),
                                        indDetraccion = Convert.ToBoolean(fil.Cells["indDetraccion"].Value),
                                        tipDetraccion = Convert.ToString(fil.Cells["tipDetraccion"].Value)
                                    };

                                    oListaArticulosVarios.Add(Articulo);
                                }
                            }

                            Articulo = null;
                        }
                        else
                        {
                            Articulo = new ArticuloServE()
                            {
                                idArticulo = Convert.ToInt32(Fila.Cells["idArticulo"].Value),
                                codArticulo = Convert.ToString(Fila.Cells["codArticulo"].Value),
                                nomArticulo = Convert.ToString(Fila.Cells["nomArticulo"].Value),
                                nomUMedidaPres = Convert.ToString(Fila.Cells["nomUMedidaPres"].Value),
                                Contenido = Convert.ToDecimal(Fila.Cells["Contenido"].Value),
                                PesoUnitario = Convert.ToDecimal(Fila.Cells["PesoUnitario"].Value),
                                idUniMedEnvase = Convert.ToInt32(Fila.Cells["idUniMedEnvase"].Value),
                                nomUMedidaEnv = Convert.ToString(Fila.Cells["nomUMedidaEnv"].Value),
                                codTipoMedPresentacion = Convert.ToInt32(Fila.Cells["codTipoMedPresentacion"].Value),
                                codUniMedPresentacion = Convert.ToInt32(Fila.Cells["codUniMedPresentacion"].Value),
                                codUniMedAlmacen = Convert.ToInt32(Fila.Cells["codUniMedAlmacen"].Value),
                                numVerPlanCuentas = Convert.ToString(Fila.Cells["numVerPlanCuentas"].Value),
                                codCuentaAdm = Convert.ToString(Fila.Cells["codCuentaAdm"].Value),
                                codCuentaVta = Convert.ToString(Fila.Cells["codCuentaVta"].Value),
                                codCuentaPro = Convert.ToString(Fila.Cells["codCuentaPro"].Value),
                                idTipoArticulo = Convert.ToInt32(Fila.Cells["idTipoArticulo"].Value),
                                indDetraccion = Convert.ToBoolean(Fila.Cells["indDetraccion"].Value),
                                tipDetraccion = Convert.ToString(Fila.Cells["tipDetraccion"].Value)
                            };
                        }
                    }

                    #endregion

                    #region Requerimientos

                    if (TipoListado == "StockReque")
                    {
                        #region Requerimientos con Stock

                        if (FilasSeleccionadas > 1)
                        {
                            oListaArticulosVarios = new List<ArticuloServE>();

                            foreach (DataGridViewRow fil in dgvArticulo.Rows)
                            {
                                if (fil.Selected)
                                {
                                    Articulo = new ArticuloServE()
                                    {
                                        idArticulo = Convert.ToInt32(Fila.Cells["idArticulo"].Value),
                                        codArticulo = Convert.ToString(Fila.Cells["codArticulo"].Value),
                                        nomArticulo = Convert.ToString(Fila.Cells["desArticulo"].Value),
                                        Stock = Convert.ToDecimal(Fila.Cells["canStock"].Value),
                                        idTipoArticulo = Convert.ToInt32(Fila.Cells["idTipoArticulo"].Value),
                                        codUniMedAlmacen = Convert.ToInt32(Fila.Cells["codUniMedAlmacen"].Value),
                                        indDetraccion = Convert.ToBoolean(Fila.Cells["indDetraccion"].Value),
                                        tipDetraccion = Convert.ToString(Fila.Cells["tipDetraccion"].Value)
                                    };

                                    oListaArticulosVarios.Add(Articulo);
                                }
                            }

                            Articulo = null;
                        }
                        else
                        {
                            Articulo = new ArticuloServE()
                            {
                                idArticulo = Convert.ToInt32(Fila.Cells["idArticulo"].Value),
                                codArticulo = Convert.ToString(Fila.Cells["codArticulo"].Value),
                                nomArticulo = Convert.ToString(Fila.Cells["desArticulo"].Value),
                                Stock = Convert.ToDecimal(Fila.Cells["canStock"].Value),
                                idTipoArticulo = Convert.ToInt32(Fila.Cells["idTipoArticulo"].Value),
                                codUniMedAlmacen = Convert.ToInt32(Fila.Cells["codUniMedAlmacen"].Value),
                                indDetraccion = Convert.ToBoolean(Fila.Cells["indDetraccion"].Value),
                                tipDetraccion = Convert.ToString(Fila.Cells["tipDetraccion"].Value)
                            };
                        }

                        #endregion
                    }

                    if (TipoListado == "ArtiReque")
                    {
                        #region Requerimientos sin Stock

                        #endregion
                    }

                    #endregion

                    #region Para el Calzado

                    if (TipoListado == "ArtCalzado") //Calzado
                    {
                        if (FilasSeleccionadas > 1)
                        {
                            oListaArticulosVarios = new List<ArticuloServE>();

                            foreach (DataGridViewRow fil in dgvArticulo.Rows)
                            {
                                if (fil.Selected)
                                {
                                    Articulo = new ArticuloServE()
                                    {
                                        idArticulo = Convert.ToInt32(fil.Cells["idArticulo"].Value),
                                        codArticulo = Convert.ToString(fil.Cells["codArticulo"].Value),
                                        nomArticulo = Convert.ToString(fil.Cells["nomArticulo"].Value),
                                        codUniMedAlmacen = Convert.ToInt32(fil.Cells["codUniMedAlmacen"].Value),
                                        codSerie = Convert.ToInt32(fil.Cells["CodSerie"].Value),
                                        numVerPlanCuentas = Convert.ToString(fil.Cells["numVerPlanCuentas"].Value),
                                        codCuentaAdm = Convert.ToString(fil.Cells["codCuentaAdm"].Value),
                                        codCuentaVta = Convert.ToString(fil.Cells["codCuentaVta"].Value),
                                        codCuentaPro = Convert.ToString(fil.Cells["codCuentaPro"].Value)
                                        //indDetraccion = Convert.ToBoolean(fil.Cells["indDetraccion"].Value),
                                        //tipDetraccion = Convert.ToString(fil.Cells["tipDetraccion"].Value)
                                    };

                                    oListaArticulosVarios.Add(Articulo);
                                }
                            }

                            Articulo = null;
                        }
                        else
                        {
                            Articulo = new ArticuloServE()
                            {
                                idArticulo = Convert.ToInt32(Fila.Cells["idArticulo"].Value),
                                codArticulo = Convert.ToString(Fila.Cells["codArticulo"].Value),
                                nomArticulo = Convert.ToString(Fila.Cells["nomArticulo"].Value),
                                codUniMedAlmacen = Convert.ToInt32(Fila.Cells["codUniMedAlmacen"].Value),
                                codSerie = Convert.ToInt32(Fila.Cells["CodSerie"].Value),
                                numVerPlanCuentas = Convert.ToString(Fila.Cells["numVerPlanCuentas"].Value),
                                codCuentaAdm = Convert.ToString(Fila.Cells["codCuentaAdm"].Value),
                                codCuentaVta = Convert.ToString(Fila.Cells["codCuentaVta"].Value),
                                codCuentaPro = Convert.ToString(Fila.Cells["codCuentaPro"].Value)
                                //indDetraccion = Convert.ToBoolean(Fila.Cells["indDetraccion"].Value),
                                //tipDetraccion = Convert.ToString(Fila.Cells["tipDetraccion"].Value)
                            };
                        }
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

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmBuscarArticulo_Load(object sender, EventArgs e)
        {
            LlenarTipoArticulo();

            if (TipoArticulo != Variables.Cero)
            {
                cboTipoArticulo.SelectedValue = Convert.ToInt32(TipoArticulo);
            }

            if (TipoListado == "stock")
            {
                if (!indLote)
                {
                    Size = new Size(880, 384);
                }
            }
            else if (TipoListado == "PrecioListaArti") //Del Mantenimiento de Lista de Precios
            {
                Size = new Size(750, 384);
            }
            else if (TipoListado == "SinStockListaPrecio" || TipoListado == "StockListaPrecio") //Sin Stock con Lista de Precio - Pedidos
            {
                Size = new Size(780, 384);
                cboTipoArticulo.Enabled = false;
            }
            else if (TipoListado == "StockReque" || TipoListado == "ArtiReque")
            {
                Size = new Size(700, 384);
                cboTipoArticulo.Enabled = false;
            }
            else if (TipoListado == "ArtAlmacen" || TipoListado == "N") //Almacén y Orden de Compra -- se cambio TipoListado == "E" ||
            {
                Size = new Size(880, 384);
                cboTipoArticulo.Enabled = false;
            }
            else if (TipoListado == "ArtCalzado") //Calzado
            {
                Size = new Size(720, 384);
                cboTipoArticulo.Enabled = false;
            }
            else
            {
                Size = new Size(680, 384);
            }

            txtFiltro.Focus();
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
                if (TipoListado != "stock")
                {
                    if (dgvArticulo.Rows.GetRowCount(DataGridViewElementStates.Selected) > 1)
                    {
                        Global.MensajeComunicacion("Tiene que presionar el botón aceptar cuando quiere seleccionar mas de un item.");
                        return;
                    }
                }                

                Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        } 

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (oListaArticulos != null && oListaArticulos.Count > Variables.Cero)
                {
                    BuscarFiltro();
                }

                if (oListaStock != null && oListaStock.Count > Variables.Cero)
                {
                    BuscarFiltro();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipoArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void TxtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void DgvArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Aceptar();
            }
        }

        private void DgvArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dgvArticulo.Focus();
            }
        }

        private void bsBase_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                gbResultados.Text = "Registros Encontrados " + bsBase.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
