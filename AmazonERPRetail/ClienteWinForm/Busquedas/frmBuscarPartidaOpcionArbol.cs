using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarPartidaOpcionArbol : FrmBusquedaBase
    {
        public frmBuscarPartidaOpcionArbol(String Tipo)
        {
            InitializeComponent();

            oListaPresupuestos = AgenteMaestros.Proxy.ListarPartidaPresupuestariaPorTipo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Tipo, String.Empty, 0);
        }

        #region Variables

        public PartidaPresupuestariaE oPresupuesto = null;
        List<PartidaPresupuestariaE> oListaPresupuestos;
        TreeNode nodo;
        public MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        private void CargaInicial()
        {
            try
            {
                if (oListaPresupuestos.Count > Variables.Cero && oListaPresupuestos != null)
                {
                    tvOpcion.BeginUpdate();

                    TreeNode nodoBase = new TreeNode("PARTIDA PRESUPUESTAL");
                    nodoBase.ImageIndex = 0;
                    nodoBase.Expand();
                    nodoBase.Tag = "0";

                    foreach (PartidaPresupuestariaE item in (from x in oListaPresupuestos where x.numNivel == 1 orderby x.codPartidaPresu select x).ToList())
                    {
                        nodo = new TreeNode(item.codPartidaPresu + " - " + item.desPartidaPresu);
                        nodo.Tag = item.codPartidaPresu;
                        nodo.ImageIndex = 1;
                        nodo.SelectedImageIndex = 2;

                        LlenarOpcion(nodo);
                        nodoBase.Nodes.Add(nodo);
                    }

                    tvOpcion.Nodes.Add(nodoBase);
                    tvOpcion.EndUpdate(); 
                }
                else
                {
                    Global.MensajeFault("No hay datos para mostrar...");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LlenarOpcion(TreeNode nodo2)
        {
            TreeNode nodoNegocio = null;
            String codPartidaPresu = nodo2.Tag.ToString();

            if ((from x in oListaPresupuestos where x.codPartidaPresuSup == Convert.ToString(codPartidaPresu) select x).Count() > 0)
            {
                foreach (PartidaPresupuestariaE item in (from x in oListaPresupuestos where x.codPartidaPresuSup == Convert.ToString(codPartidaPresu) orderby x.numNivel select x).ToList())
                {
                    nodoNegocio = new TreeNode(item.codPartidaPresu + " - " + item.desPartidaPresu);
                    nodoNegocio.Tag = item.codPartidaPresu;
                    nodoNegocio.ImageIndex = 1;
                    nodoNegocio.SelectedImageIndex = 2;

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
                oPresupuesto = new PartidaPresupuestariaE() { codPartidaPresu = nodoSeleccionado.Tag.ToString(), numNivel = nodoSeleccionado.Level + 1 };
                base.Aceptar();
            }
        }

        #endregion

        #region Eventos
        
        private void frmBuscarPartidaOpcionArbol_Load(object sender, EventArgs e)
        {
            tvOpcion.ImageList = imageList1;
            CargaInicial();
        } 

        #endregion
    }
}
