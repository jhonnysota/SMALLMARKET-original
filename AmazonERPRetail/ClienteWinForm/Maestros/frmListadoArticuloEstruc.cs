using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoArticuloEstruc : FrmMantenimientoBase
    {

        public frmListadoArticuloEstruc()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvEstructura, true);
            AnchoColumnas();
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<ArticuloEstrucE> ListaArticulo = null;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvEstructura.Columns[0].Width = 30; //Nivel
            dgvEstructura.Columns[1].Width = 250; //Descripción
            dgvEstructura.Columns[2].Width = 40; //Longitud
            dgvEstructura.Columns[3].Width = 50; //ultimo Nivel
            dgvEstructura.Columns[4].Width = 90;
            dgvEstructura.Columns[5].Width = 120;
            dgvEstructura.Columns[6].Width = 90;
            dgvEstructura.Columns[7].Width = 120;
        }

        private void LlenarTipoArticulo()
        {
            cboTipoArticulo.DataSource = null;
            List<ParTabla> ListaTipoUnidad = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ListaTipoUnidad.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre=Variables.Seleccione });
            
            ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in ListaTipoUnidad orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);

            cboTipoArticulo.SelectedValue = 1; 
            cboTipoArticulo.SelectedIndex = 1;
           
            Buscar();
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Int32 TipoArticulo = Convert.ToInt32(cboTipoArticulo.SelectedValue);

                if (TipoArticulo > Variables.Cero)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmArticuloEstruc);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmArticuloEstruc(TipoArticulo)
                    {
                        MdiParent = this.MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show(); 
                }
                else
                {
                    Global.MensajeComunicacion("Debe escoger un tipo de articulo.");
                    cboTipoArticulo.Focus();
                    SendKeys.Send("{F4}");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                if (bsArticulos.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmArticuloEstruc);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }
                       
                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmArticuloEstruc((ArticuloEstrucE)bsArticulos.Current)
                    {
                        MdiParent = this.MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                bsArticulos.DataSource = ListaArticulo = AgenteMaestro.Proxy.ListarArticuloEstruc(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue));
                bsArticulos.ResetBindings(false);

                base.Buscar();
                lblTitulo.Text = "Registros " + bsArticulos.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsArticulos.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminacion) == DialogResult.Yes)
                    {
                        AgenteMaestro.Proxy.EliminarArticulosEstruc(((ArticuloEstrucE)bsArticulos.Current).idEmpresa, ((ArticuloEstrucE)bsArticulos.Current).idTipoArticulo, ((ArticuloEstrucE)bsArticulos.Current).numNivel);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                        base.Anular();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmArticuloEstruc oFrm = sender as frmArticuloEstruc;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion Eventos de Usuario

        #region Eventos

        private void frmListadoArticuloEstruc_Load(object sender, EventArgs e)
        {
            Grid = true;
            LlenarTipoArticulo();
            base.Grabar();
        }

        private void cboTipoArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvEstructura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        #endregion Eventos

    }
}
