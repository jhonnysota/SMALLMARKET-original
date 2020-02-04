using Entidades.Almacen;
using Entidades.Seguridad;
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

namespace ClienteWinForm.Seguridad
{
    public partial class frmUsuarioAlmacen : FrmBusquedaBase
    {
        public frmUsuarioAlmacen()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvPuntos);
            InitializeComponent();
        }

        public frmUsuarioAlmacen(List<Int32> lista1)
         : this()
        {
            ListaComparacion = lista1;
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public AlmacenE oUsuAlmacen = null;
        List<Int32> ListaComparacion = new List<Int32>();
        List<AlmacenE> Lista1 = new List<AlmacenE>();
 
        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                Lista1 = AgenteAlmacen.Proxy.ListarAlmacenPorEmpresa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (ListaComparacion.Count > 0)
                {
                    for (int a = 0; a < ListaComparacion.Count; a++)
                    {
                        Lista1.RemoveAll(c => c.idAlmacen == ListaComparacion[a]);
                    }


                    bsBase.DataSource = Lista1;
                }
                else
                {
                    bsBase.DataSource = Lista1;
                }

                if (bsBase.Count > 0)
                {
                    dgvPuntos.Enabled = true;
                    btnAceptar.Enabled = true;
                }
                else
                {
                    dgvPuntos.Enabled = false;
                    btnAceptar.Enabled = false;


                    base.Buscar();
                }

                gbResultados.Text = " Registros Encontrados" + bsBase.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                oUsuAlmacen = (AlmacenE)bsBase.Current;

                if (oUsuAlmacen != null)
                {
                    base.Aceptar();
                }
            }
        }

        #endregion

       private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dgvPuntos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        private void frmUsuarioAlmacen_Load(object sender, EventArgs e)
        {
            dgvPuntos.AutoResizeColumns();
            Buscar();
        }
    }
}
