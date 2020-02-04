using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Infraestructura.Enumerados;
using Presentadora.AgenteServicio;
using Infraestructura.Winform;
using Entidades.Generales;

namespace ClienteWinForm.Generales.Busqueda
{
    public partial class FrmBusquedaPartabla : FrmBusquedaBase
    {
        #region Variables

        public EnumParTabla enumParTabla = 0;
        public ParTabla parTabla;
        public List<ParTabla>  lista= null;
        public bool BoolManuel = true;

        #endregion

        #region Agentes

        public GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }

        #endregion

        public FrmBusquedaPartabla()
        {
            InitializeComponent();
        }
        #region Heredados

        protected override void Buscar()
        {
            
            parTablaBindingSource.DataSource = AgenteGenerales.Proxy.ListarParTablaPorGrupo((int)cbGruposParTabla.SelectedValue, txtFiltro.Text);
            base.Buscar();
        }

        protected override void Aceptar()
        {
            if (BoolManuel)
            {
                if (parTablaBindingSource.Current != null)
                {
                    //parTabla = (ParTabla)parTablaBindingSource.Current;
                    lista = (List<ParTabla>)parTablaBindingSource.DataSource;
                    lista = ((from x in lista where x.CkeckAgregar select x).ToList());
                    base.Aceptar();
                }
            }
            else
            {                
                parTabla = (ParTabla)parTablaBindingSource.Current;
                base.Aceptar();
            }
           
        }

        #endregion

        

        private void FrmBusquedaPartabla_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargaInicial();
        }

        #region Metodos Nuevos

        private void CargaInicial()
        {
            if (enumParTabla == 0)
            {
                cbGruposParTabla.SelectedIndex = 0;
                cbGruposParTabla.Enabled = true;
            }
            else
            {
                cbGruposParTabla.Enabled = false;
                cbGruposParTabla.SelectedValue = (int)enumParTabla;
            }

            if (BoolManuel)
            {
                parTablaDataGridView.Columns["CkeckAgregar"].Visible = true;
            }
            else
            {
                parTablaDataGridView.Columns["CkeckAgregar"].Visible = false;
            }
        }

        private void CargarCombos()
        {
            ComboHelper.LlenarCombos<ParTabla>(cbGruposParTabla, AgenteGenerales.Proxy.ListarParTablaCabecera(""));
        }

        #endregion

        private void parTablaDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }



    }
}
