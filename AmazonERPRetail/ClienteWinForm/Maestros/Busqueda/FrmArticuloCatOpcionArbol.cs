using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entidades.Maestros;
using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;

namespace ClienteWinForm.Maestros.Busqueda
{
    public partial class FrmArticuloCatOpcionArbol : FrmBusquedaBase
    {

        #region Constructores

        public FrmArticuloCatOpcionArbol()
        {
            InitializeComponent();
        }

        public FrmArticuloCatOpcionArbol(Int32 TipoArticuloTmp, Int32 numNivelTemp, String form)
            : this()
        {
            TipoArticulo = TipoArticuloTmp;
            tipodecat = form;

            if (form == "CAT")
            {
                numNivel = numNivelTemp - 1;
            }
            else if (form == "CARTCAT")
            {
                numNivel = numNivelTemp - 1;
            }
            else
            {
                numNivel = numNivelTemp;
            }
        }

        #endregion Constructores

        #region Variables

        //ARTICULOS//
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        public ArticuloCatE ArticuloCat = null;
        List<ArticuloCatE> oListaCategoriaPorTipoArticulo = null;

        //CARTAS//
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public CartaCategoriaE CartaCat = null;
        List<CartaCategoriaE> oListaCategoriaCartaPorTipoArticulo = null;

        Int32 TipoArticulo = 0;
        TreeNode Nodo;
        String tipodecat;
        Int32 numNivel;
        String Filtro ="%";
        #endregion

        #region Procedimientos de Usuario

        private void CargaInicial()
        {
            try
            {
                StringBuilder cadBusqueda = new StringBuilder();
                String cad = string.Empty;

                cadBusqueda.Append(txtFiltro.Text);
                cadBusqueda.Append("%");
                cad = cadBusqueda.ToString();

                oListaCategoriaPorTipoArticulo = AgenteMaestros.Proxy.ListarArticuloCatArbol(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, TipoArticulo, numNivel,cad);
                TreeNode nodoBase = new TreeNode("CATEGORIAS");
                nodoBase.Expand();
                nodoBase.Tag = 0;
                List<ArticuloCatE> oListaPadre = new List<ArticuloCatE>((from x in oListaCategoriaPorTipoArticulo
                                                                         where x.numNivel == 1
                                                                         orderby x.CodCategoria
                                                                         select x).ToList());
                foreach (ArticuloCatE item in oListaPadre)
                {
                    Nodo = new TreeNode(item.nombre_categoria)
                    {
                        Tag = item.CodCategoria
                    };

                    LlenarSubCategoria(Nodo);
                   nodoBase.Nodes.Add(Nodo);
                }

                oListaPadre = null;
                tvCategoria.Nodes.Add(nodoBase);
                tvCategoria.ExpandAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LlenarSubCategoria(TreeNode NodoDetalle)
        {
            TreeNode nodoNegocio = null;
            String codCategoriaSup = NodoDetalle.Tag.ToString();

            if (tipodecat != "CARTCAT")
            {
                if ((from x in oListaCategoriaPorTipoArticulo where x.CodCategoriaSup == codCategoriaSup select x).Count() > 0)
                {
                    List<ArticuloCatE> oListaItems = new List<ArticuloCatE>((from x in oListaCategoriaPorTipoArticulo
                                                                             where x.CodCategoriaSup == codCategoriaSup
                                                                             orderby x.CodCategoria
                                                                             select x).ToList());
                    foreach (ArticuloCatE item in oListaItems)
                    {
                        nodoNegocio = new TreeNode(item.nombre_categoria);
                        nodoNegocio.Tag = item.CodCategoria;

                        LlenarSubCategoria(nodoNegocio);
                        NodoDetalle.Nodes.Add(nodoNegocio);
                    }

                    oListaItems = null;
                }

                NodoDetalle.ExpandAll();
            }
            else
            {
                if ((from x in oListaCategoriaCartaPorTipoArticulo where x.CodCategoriaSup == codCategoriaSup select x).Count() > 0)
                {
                    foreach (CartaCategoriaE item in (from x in oListaCategoriaCartaPorTipoArticulo
                                                   where x.CodCategoriaSup == codCategoriaSup
                                                   orderby x.CodCategoria
                                                   select x).ToList())
                    {
                        nodoNegocio = new TreeNode(item.nombre_categoria);
                        nodoNegocio.Tag = item.CodCategoria;

                        LlenarSubCategoria(nodoNegocio);
                        NodoDetalle.Nodes.Add(nodoNegocio);
                    }
                }
            }
        }

        #endregion 

        #region Procedimientos Heredados

        protected override void Aceptar()
        {
            if (tvCategoria.SelectedNode != null)
            {
                TreeNode nodoSeleccionado = tvCategoria.SelectedNode;

                if (tipodecat != "CARTCAT")
                {
                    if (nodoSeleccionado.Level == numNivel)
                    {
                        ArticuloCat = new ArticuloCatE() { CodCategoria = nodoSeleccionado.Tag.ToString(), nombre_categoria = nodoSeleccionado.Text };
                        base.Aceptar();
                    }
                    else
                    {
                        Global.MensajeFault("Debe escoger el Ultimo Nivel.");
                    }
                }
                else
                {
                    if (nodoSeleccionado.Level + 1 > numNivel)
                    {
                        CartaCat = new CartaCategoriaE() { CodCategoria = nodoSeleccionado.Tag.ToString(), nombre_categoria = nodoSeleccionado.Text };
                        base.Aceptar();
                    }
                }
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void FrmArticuloCatOpcionArbol_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }

        private void tvCategoria_DoubleClick(object sender, EventArgs e)
        {
            Aceptar();
        }

        #endregion Eventos

    }
}
