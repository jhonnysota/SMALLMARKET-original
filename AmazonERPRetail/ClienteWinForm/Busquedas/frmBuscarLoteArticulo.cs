using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarLoteArticulo : FrmBusquedaBase
    {

        #region Contructores

        public frmBuscarLoteArticulo()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvStock, true);
        }

        //Salida de Almacén
        public frmBuscarLoteArticulo(Int32 idEmpresa_, Int32 idAlmacen_, Int32 idTipoArt_, Int32 idArticulo_, String Anio_, String Mes_, Boolean conLote_)
            : this()
        {
            idEmpresa = idEmpresa_;
            idAlmacen = idAlmacen_;
            idTipoArt = idTipoArt_;
            idArticulo = idArticulo_;
            Anio = Anio_;
            Mes = Mes_;
            conLote = conLote_;

            Tipo = "alm";
        }

        //Conversiones - Ingresos
        public frmBuscarLoteArticulo(Int32 idEmpresa_, String Anio_, String Mes_, Int32 idAlmacen_, Int32 idArticulo_)
            : this()
        {
            idEmpresa = idEmpresa_;
            idAlmacen = idAlmacen_;
            idArticulo = idArticulo_;
            Anio = Anio_;
            Mes = Mes_;

            Tipo = "conver";
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteMaestros { get { return new AlmacenServiceAgent(); } }
        public StockE oStock = null;
        public AlmacenArticuloLoteE oLoteArticulo = null;
        List<StockE> oListaStock = null;
        List<AlmacenArticuloLoteE> oListaLoteArticulo = null;
        Int32 idEmpresa;
        Int32 idAlmacen;
        Int32 idTipoArt;
        Int32 idArticulo;
        String Anio;
        String Mes;
        Boolean conLote;
        String Tipo = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void BuscarFiltro()
        {
            if (oListaStock != null && oListaStock.Count > 0)
            {
                if (Tipo == "alm")
                {
                    bsBase.DataSource = (from x in oListaStock
                                         where x.desArticulo.ToUpper().Contains(txtFiltro.Text.ToUpper())
                                         select x).ToList();
                }
                else if (Tipo == "conver")
                {
                    bsBase.DataSource = (from x in oListaLoteArticulo
                                         where x.desArticulo.ToUpper().Contains(txtFiltro.Text.ToUpper())
                                         select x).ToList();
                }
            }
        }

        void Formato()
        {
            if (Tipo == "alm")
            {
                dgvStock.Columns[0].HeaderText = "Lote Indu.";
                dgvStock.Columns[1].HeaderText = "Lote Prov.";
                dgvStock.Columns[2].HeaderText = "Id.";
                dgvStock.Columns[3].HeaderText = "Cód.Articulo";
                dgvStock.Columns[4].HeaderText = "Descripción";
                dgvStock.Columns[5].HeaderText = "Stock";
                dgvStock.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvStock.Columns[5].DefaultCellStyle.Format = "N2";
                dgvStock.Columns[6].HeaderText = "U.Med.Pres.";
                dgvStock.Columns[7].HeaderText = "Conte.";
                dgvStock.Columns[8].HeaderText = "Peso Unit.";
                dgvStock.Columns[9].HeaderText = "U.Med.Env.";
            }
            else if (Tipo == "conver")
            {
                //dgvStock.Columns[0].HeaderText = "Lote Indu.";
                dgvStock.Columns[1].HeaderText = "Lote Prov.";
                dgvStock.Columns[2].HeaderText = "Id.";
                dgvStock.Columns[3].HeaderText = "Cód.Articulo";
                dgvStock.Columns[4].HeaderText = "Descripción";
                dgvStock.Columns[5].HeaderText = "Stock";
                dgvStock.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvStock.Columns[5].DefaultCellStyle.Format = "N2";
            }

            if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
            {
                dgvStock.Columns[2].Visible = false;
            }
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                if (Tipo == "alm")
                {
                    oListaStock = AgenteMaestros.Proxy.StockPorIdArticulo(VariablesLocales.SesionLocal.IdEmpresa, idAlmacen, idTipoArt, idArticulo, Anio, Mes, conLote);

                    var oListaStockTemp = (from x in oListaStock
                                           select new
                                           {
                                               x.Lote,
                                               x.LoteProveedor,
                                               x.idArticulo,
                                               x.codArticulo,
                                               x.desArticulo,
                                               x.canStock,
                                               x.nomUMedidaPres,
                                               x.Contenido,
                                               x.PesoUnitario,
                                               x.nomUMedidaEnv
                                           });

                    dgvStock.DataSource = bsBase.DataSource = (from x in oListaStockTemp.ToList() orderby x.codArticulo select x).ToList();
                }
                else if (Tipo == "conver")
                {
                    oListaLoteArticulo = AgenteMaestros.Proxy.ListarAlmacenArticuloLote(VariablesLocales.SesionLocal.IdEmpresa, Anio, Mes, idAlmacen, idArticulo);

                    var oListaArticuloLote = (from x in oListaLoteArticulo
                                              select new
                                              {
                                                  x.Lote,
                                                  x.LoteProveedor,
                                                  x.idArticulo,
                                                  x.codArticulo,
                                                  x.desArticulo,
                                                  x.canStock
                                              });

                    dgvStock.DataSource = bsBase.DataSource = (from x in oListaArticuloLote.ToList() orderby x.codArticulo select x).ToList();
                }
                
                //bsBase.ResetBindings(false);
                Formato();
                dgvStock.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                DataGridViewRow Fila = dgvStock.CurrentRow;

                if (Tipo == "alm")
                {
                    oStock = new StockE()
                    {
                        idArticulo = Convert.ToInt32(Fila.Cells["idArticulo"].Value),
                        codArticulo = Convert.ToString(Fila.Cells["codArticulo"].Value),
                        desArticulo = Convert.ToString(Fila.Cells["desArticulo"].Value),
                        Lote = Convert.ToString(Fila.Cells["Lote"].Value),
                        LoteProveedor = Convert.ToString(Fila.Cells["LoteProveedor"].Value),
                    };
                }
                else if (Tipo == "conver")
                {
                    oLoteArticulo = new AlmacenArticuloLoteE()
                    {
                        idArticulo = Convert.ToInt32(Fila.Cells["idArticulo"].Value),
                        codArticulo = Convert.ToString(Fila.Cells["codArticulo"].Value),
                        desArticulo = Convert.ToString(Fila.Cells["desArticulo"].Value),
                        Lote = Convert.ToString(Fila.Cells["Lote"].Value),
                        LoteProveedor = Convert.ToString(Fila.Cells["LoteProveedor"].Value),
                    };
                }

                base.Aceptar();
            }
            else
            {
                Global.MensajeComunicacion("No hay datos, presione el botón Cancelar.");
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarLoteArticulo_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        private void dgvStock_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvStock, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        } 

        #endregion

    }
}
