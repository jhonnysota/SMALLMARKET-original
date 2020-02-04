using Entidades.Maestros;
using Infraestructura;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Maestros.Busqueda
{
    public partial class frmCostosCatOpcionArbol : FrmBusquedaBase
    {
        public frmCostosCatOpcionArbol()
        {
            InitializeComponent();
        }

        public frmCostosCatOpcionArbol(Int32 Empresa_,Int32 NumNivel_)
            : this()
        {
            numNivel = Empresa_;
            Empresa = NumNivel_;
        }

        #region Variables

        //CostosCat//
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        public CostosClasificacionE ClasificacionCostosCat = null;
        List<CostosClasificacionE> oListaCostos = null;
        TreeNode Nodo;
        Int32 Empresa;
        Int32 numNivel;

        #endregion

        #region Procedimientos de Usuario

        private void CargaInicial()
        {
            try
            {
                    oListaCostos = AgenteMaestros.Proxy.ListarClasificacionCat(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, numNivel);
                    TreeNode nodoBase = new TreeNode("CATEGORIAS");
                    nodoBase.Expand();
                    nodoBase.Tag = 0;
                    List<CostosClasificacionE> oListaPadre = new List<CostosClasificacionE>((from x in oListaCostos
                                                                             where x.numNivel == 1
                                                                             orderby x.CodClasificacion
                                                                             select x).ToList());
                    foreach (CostosClasificacionE item in oListaPadre)
                    {
                        Nodo = new TreeNode(item.nombreClasificacion);
                        Nodo.Tag = item.CodClasificacion;

                        LlenarSubCategoria(Nodo);
                        nodoBase.Nodes.Add(Nodo);
                    }

                    oListaPadre = null;
                    TVCategoria.Nodes.Add(nodoBase);                
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

                if ((from x in oListaCostos where x.CodCategoriaSup == codCategoriaSup select x).Count() > 0)
                {
                    List<CostosClasificacionE> oListaItems = new List<CostosClasificacionE>((from x in oListaCostos
                                                                             where x.CodCategoriaSup == codCategoriaSup
                                                                             orderby x.CodClasificacion
                                                                             select x).ToList());
                    foreach (CostosClasificacionE item in oListaItems)
                    {
                        nodoNegocio = new TreeNode(item.nombreClasificacion);
                        nodoNegocio.Tag = item.CodClasificacion;

                        LlenarSubCategoria(nodoNegocio);
                        NodoDetalle.Nodes.Add(nodoNegocio);
                    }

                    oListaItems = null;
                }

                NodoDetalle.ExpandAll();
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Aceptar()
        {
            if (TVCategoria.SelectedNode != null)
            {
                TreeNode nodoSeleccionado = TVCategoria.SelectedNode;



                    ClasificacionCostosCat = new CostosClasificacionE() { CodClasificacion = nodoSeleccionado.Tag.ToString(), nombreClasificacion = nodoSeleccionado.Text };
                    base.Aceptar();


                if (nodoSeleccionado.Level + 1 > numNivel)
                    {
                       ClasificacionCostosCat = new CostosClasificacionE() { CodClasificacion = nodoSeleccionado.Tag.ToString(), nombreClasificacion = nodoSeleccionado.Text };
                        base.Aceptar();
                    }
                
            }
        }


        #endregion

        #region Eventos

        private void frmCostosCatOpcionArbol_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }

        private void TVCategoria_DoubleClick(object sender, EventArgs e)
        {
            Aceptar();
        }

        #endregion

    }
}
