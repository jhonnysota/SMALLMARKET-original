using Entidades.Maestros;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Maestros.Busqueda
{
    public partial class FrmCCostosOpcionArbol : FrmBusquedaBase
    {

        public FrmCCostosOpcionArbol()
        {
            InitializeComponent();
        }
       
        #region Variables

        public CCostosE Ccostos = null;
        List<CCostosE> listaCCostos;
        TreeNode nodo;
        public MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        private void CargaInicial()
        {
            try
            {
                listaCCostos = AgenteMaestros.Proxy.ListarCCostosPorSistema(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 1);
                TreeNode nodoBase = new TreeNode("PRINCIPAL");
                nodoBase.Expand();
                //nodoBase.Tag = 0;

                foreach (CCostosE item in (from x in listaCCostos where x.numNivel == 1 orderby x.idCCostos select x).ToList())
                {
                    nodo = new TreeNode(item.desCCostos);
                    nodo.Tag = item.idCCostos;

                    LlenarOpcion(nodo);
                    nodoBase.Nodes.Add(nodo);
                }

                tvOpcion.Nodes.Add(nodoBase);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LlenarOpcion(TreeNode nodo2)
        {
            TreeNode nodoNegocio = null;
            String idCostos = nodo2.Tag.ToString();

            if ((from x in listaCCostos where x.idCCostosSup == Convert.ToString(idCostos) select x).Count() > 0)
            {
                foreach (CCostosE item in (from x in listaCCostos where x.idCCostosSup == Convert.ToString(idCostos) orderby x.numNivel select x).ToList())
                {
                    nodoNegocio = new TreeNode(item.desCCostos);
                    nodoNegocio.Tag = item.idCCostos;

                    LlenarOpcion(nodoNegocio);
                    nodo2.Nodes.Add(nodoNegocio);
  
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Aceptar()
        {
            if (tvOpcion.SelectedNode != null)
            {
                TreeNode nodoSeleccionado = tvOpcion.SelectedNode;
                Ccostos = new CCostosE() { idCCostos = nodoSeleccionado.Tag.ToString(), numNivel = nodoSeleccionado.Level +1 };
                base.Aceptar();
            }
        }

        #endregion

       #region

        private void FrmCCostosOpcionArbol_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }

        #endregion
    }
}
