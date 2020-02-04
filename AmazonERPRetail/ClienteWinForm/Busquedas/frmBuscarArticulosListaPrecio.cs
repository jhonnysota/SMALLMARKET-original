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
    public partial class frmBuscarArticulosListaPrecio : FrmBusquedaBase
    {

        #region Constructores

        public frmBuscarArticulosListaPrecio()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvArticulo, true);
            LlenarTipoArticulo();
            txtFiltro.Focus();

            if (VariablesLocales.SesionUsuario.Empresa.indCalzado)
            {
                Size = new Size(705, 452);
            }
        }

        //Lista de Precio...
        public frmBuscarArticulosListaPrecio(AlmacenE oAlmacenTmp, String TipoListado_, Int32 idListaPrecioPed, String Anio_, String Mes_)
            : this()
        {
            oAlmacen = oAlmacenTmp;
            TipoArticulo = oAlmacenTmp.tipAlmacen == null ? Variables.Cero : Convert.ToInt32(oAlmacenTmp.tipAlmacen);
            TipoListado = TipoListado_;
            idListaPrecioReal = idListaPrecioPed;
            Anio = Anio_;
            Mes = Mes_;
        }

        //Lista de Precio...para mantenimiento de la lista de precio
        public frmBuscarArticulosListaPrecio(Int32 tipArticulo_, String TipoListado_ = "")
            : this()
        {
            TipoArticulo = tipArticulo_;
            TipoListado = TipoListado_;
        }

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        AlmacenE oAlmacen = null;
        String Anio = String.Empty;
        String Mes = String.Empty;
        Int32 TipoArticulo = Variables.Cero;
        String TipoListado = String.Empty;
        Int32 idListaPrecioReal = 0;
        String Talla = String.Empty;
        List<ArticuloServE> oListaArticulos = null;

        public ArticuloServE Articulo = null;
        public List<ArticuloServE> oListaArticulosVarios = null;

        #endregion Variables

        #region Procedimientos de Usuario

        private void LlenarTipoArticulo()
        {
            cboTipoArticulo.DataSource = null;
            List<ParTabla> ListaTipoArticulo = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ListaTipoArticulo.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in ListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
        }

        private void BuscarFiltro()
        {
            bsBase.DataSource = (from x in oListaArticulos
                                 where x.nomArticulo.ToUpper().Contains(txtFiltro.Text.ToUpper())
                                 select x).ToList();
        }

        private void Formato(String Tipo = "")
        {
            if (Tipo == "PrecioListaArti") //Para el mantenimiento de la Lista de Precio
            {
                #region Lista de Precios

                dgvArticulo.Columns["Stock"].Visible = false;
                dgvArticulo.Columns["Lote"].Visible = false;
                dgvArticulo.Columns["PrecioBruto"].Visible = false;

                #endregion
            }

            if (Tipo == "SinStockListaPrecio")
            {
                #region Articulos sin stock con Lista de Precio

                //dgvArticulo.Columns[3].Width = 70;
                //dgvArticulo.Columns[3].HeaderText = "Contenido";
                //dgvArticulo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //dgvArticulo.Columns[4].Width = 70;
                //dgvArticulo.Columns[4].HeaderText = "Capacidad";
                //dgvArticulo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //dgvArticulo.Columns[5].Width = 90;
                //dgvArticulo.Columns[5].HeaderText = "Precio B.";
                //dgvArticulo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                if (VariablesLocales.SesionUsuario.Empresa.indCalzado)
                {
                    dgvArticulo.Columns["Lote"].HeaderText = "Talla";
                    dgvArticulo.Columns["Lote"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                #endregion
            }

            if (Tipo == "ConListaPrecioStock")
            {
                if (VariablesLocales.SesionUsuario.Empresa.indCalzado)
                {
                    dgvArticulo.Columns["Lote"].HeaderText = "Talla";
                    dgvArticulo.Columns["Lote"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                if (TipoListado == "PrecioListaArti") //Para el mantenimiento de la Lista de Precio
                {
                    #region Lista de Precios (Articulos)

                    String Filtro = "";

                    if (!String.IsNullOrEmpty(txtFiltro.Text))
                    {
                        Filtro = txtFiltro.Text;
                    }

                    oListaArticulos = AgenteMaestros.Proxy.ListarArticulosBusqueda(VariablesLocales.SesionLocal.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue), Filtro);
                    bsBase.DataSource = (from x in oListaArticulos.ToList() orderby x.idArticulo select x).ToList();

                    //if (oListaArticulos != null && oListaArticulos.Count > Variables.Cero)
                    //{
                    //    if (!String.IsNullOrEmpty(txtFiltro.Text))
                    //    {
                    //        BuscarFiltro();
                    //    }
                    //}

                    #endregion
                }

                if (TipoListado == "ConListaPrecio") //Con Lista de precio
                {
                    #region Sin Stock (Lista de Precio - Articulos)

                    oListaArticulos = AgenteMaestros.Proxy.ArticulosPorListaPrecio(VariablesLocales.SesionLocal.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue), "", "", idListaPrecioReal);
                    bsBase.DataSource = (from x in oListaArticulos.ToList() orderby x.idArticulo select x).ToList();

                    if (oListaArticulos != null && oListaArticulos.Count > Variables.Cero)
                    {
                        if (!String.IsNullOrEmpty(txtFiltro.Text))
                        {
                            BuscarFiltro();
                        }
                    }

                    #endregion
                }

                if (TipoListado == "ConListaPrecioStock") //Con Lista de precio y stock
                {
                    #region Con Stock (Lista de Precio - Articulos)

                    oListaArticulos = AgenteMaestros.Proxy.ArticulosPorListaPrecioStock(VariablesLocales.SesionLocal.IdEmpresa, oAlmacen.idAlmacen, Convert.ToInt32(cboTipoArticulo.SelectedValue), Anio, Mes, "", txtFiltro.Text.Trim(), idListaPrecioReal, true);
                    bsBase.DataSource = (from x in oListaArticulos.ToList() orderby x.idArticulo select x).ToList();

                    if (oListaArticulos != null && oListaArticulos.Count > Variables.Cero)
                    {
                        if (!String.IsNullOrEmpty(txtFiltro.Text))
                        {
                            BuscarFiltro();
                        }
                    }

                    #endregion
                }

                Formato(TipoListado);
                dgvArticulo.AutoResizeColumns();

                base.Buscar();
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

                    #region Para el mantenimiento de Lista de Precio

                    if (TipoListado == "PrecioListaArti")
                    {
                        if (FilasSeleccionadas > 1)
                        {
                            oListaArticulosVarios = new List<ArticuloServE>();

                            foreach (DataGridViewRow fil in dgvArticulo.Rows)
                            {
                                if (fil.Selected)
                                {
                                    oListaArticulosVarios.Add((ArticuloServE)bsBase.Current);
                                }
                            }

                            Articulo = null;
                        }
                        else
                        {
                            Articulo = (ArticuloServE)bsBase.Current;
                        }
                    }

                    #endregion

                    #region Lista de Precio

                    if (TipoListado == "ConListaPrecio" || TipoListado == "ConListaPrecioStock") //Sin stock y con stock
                    {
                        if (FilasSeleccionadas > 1)
                        {
                            oListaArticulosVarios = new List<ArticuloServE>();

                            foreach (DataGridViewRow fil in dgvArticulo.Rows)
                            {
                                if (fil.Selected)
                                {
                                    oListaArticulosVarios.Add((ArticuloServE)bsBase.Current);
                                }
                            }

                            Articulo = null;
                        }
                        else
                        {
                            oListaArticulosVarios = null;
                            Articulo = (ArticuloServE)bsBase.Current;
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

        private void frmBuscarArticulosListaPrecio_Load(object sender, EventArgs e)
        {
            if (TipoArticulo != Variables.Cero)
            {
                cboTipoArticulo.SelectedValue = Convert.ToInt32(TipoArticulo);
            }

            if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
            {
                dgvArticulo.Columns[0].Visible = false;
            }

            if (TipoListado == "PrecioListaArti") //Para el mantenimiento de la Lista de Precio
            {
                Size = new Size(800, 388);
                cboTipoArticulo.SelectedIndex = 1;
            }
        }

        private void dgvArticulo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvArticulo, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TipoListado != "PrecioListaArti")
                {
                    if (oListaArticulos != null && oListaArticulos.Count > Variables.Cero)
                    {
                        BuscarFiltro();
                    } 
                }

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

        private void cboTipoArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvArticulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

    }
}
