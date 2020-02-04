using System;
using System.Text;
using System.Windows.Forms;

using Entidades.Maestros;
using Presentadora.AgenteServicio;
using Infraestructura;

namespace ClienteWinForm.Maestros.Busqueda
{
    public partial class FrmArticuloCatOpcionArbol2 : FrmBusquedaBase
    {

        #region Constructores

        public FrmArticuloCatOpcionArbol2()
        {
            InitializeComponent();
            FormatoGrid(dgvArticuloArbol);
        }

        public FrmArticuloCatOpcionArbol2(Int32 TipoArticuloTmp, Int32 numNivelTemp, String form)
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

        Int32 TipoArticulo = 0;
        String tipodecat;
        Int32 numNivel;
        String Filtro = "%";

        #endregion

        #region Procedimientos de Usuario

        private void CargaInicial()
        {
            try
            {
                StringBuilder cadBusqueda = new StringBuilder();
                String cad;

                if (string.IsNullOrEmpty(txtFiltro.Text))
                {
                    cad = "%";
                }
                else
                {
                    cad = txtFiltro.Text;
                }

                bsBase.DataSource = AgenteMaestros.Proxy.ListarArticuloCategoria(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, TipoArticulo, numNivel,cad);
                
                base.Buscar(); 
                
                if (dgvArticuloArbol.Rows.Count >= 1)
                {
                    dgvArticuloArbol.Focus();
                }
                else
                {
                    txtFiltro.Focus();
                }  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            try
            {
                if (bsBase.Count > 0)
                {
                    ArticuloCat = (ArticuloCatE)bsBase.Current;
                    base.Aceptar();
                }
                else
                {
                    Global.MensajeComunicacion("No hay datos, presione el botón Cancelar.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos 

        private void dgvArticuloArbol_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dgvArticuloArbol, e, ClienteWinForm.Properties.Resources.CabeceraGrid, Infraestructura.Enumerados.DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvArticuloArbol_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }
        private void FrmArticuloCatOpcionArbol2_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }

        private void dgvArticuloArbol_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (e.KeyCode == Keys.F2)
            {
                txtFiltro.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Aceptar();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaInicial();
        }

        #endregion
      
    }
}
