using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Seguridad;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Seguridad.Busquedas
{
    public partial class FrmBusquedaOpcionArbol : FrmBusquedaBase
    {
        public FrmBusquedaOpcionArbol()
        {
            InitializeComponent();
        }

        #region Variables

        public Opcion opcion = null;
        List<Opcion> listaOpcion;
        TreeNode nodo;
        public SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }

        #endregion     
  
        #region Procedimientos de Usuario

        private void CargaInicial()
        {
            listaOpcion = AgenteSeguridad.Proxy.ListarOpcion("");
            TreeNode nodoBase = new TreeNode("PRINCIPAL");
            nodoBase.Expand();
            nodoBase.Tag = 0;

            foreach (Opcion item in (from x in listaOpcion where x.GrupoOpcion == 0 orderby x.Orden select x).ToList())
            {
                nodo = new TreeNode(item.Nombre);
                nodo.Tag = item.IdOpcion;

                LlenarOpcion(nodo);
                nodoBase.Nodes.Add(nodo);
            }

            tvOpcion.Nodes.Add(nodoBase);
        }

        public void LlenarOpcion(TreeNode nodo2)
        {
            TreeNode nodoNegocio = null;
            if ((from x in listaOpcion where x.GrupoOpcion == (int)nodo2.Tag select x).Count() > 0)
            {
                foreach (Opcion item in (from x in listaOpcion where x.GrupoOpcion == (int)nodo2.Tag orderby x.Orden select x).ToList())
                {
                    nodoNegocio = new TreeNode(item.Nombre);
                    nodoNegocio.Tag = item.IdOpcion;

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
                opcion = new Opcion() { IdOpcion = (int)nodoSeleccionado.Tag, Nombre = nodoSeleccionado.Text };
                base.Aceptar();
            }
        }

        #endregion

        #region Eventos

        private void FrmBusquedaOpcionArbol_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }    

        #endregion     
        
    }
}
