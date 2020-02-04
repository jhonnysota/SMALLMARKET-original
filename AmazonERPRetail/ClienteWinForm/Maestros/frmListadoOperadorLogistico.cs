using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using Negocio;
//using ClienteWinForm.Maestros.Proveedores;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Presentadora.AgenteServicio;
using Entidades.Maestros;
//using Entidades.Asistencia;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoOperadorLogistico : FrmMantenimientoBase
    {
        
        public frmListadoOperadorLogistico()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvOperadores, true);
            AnchoColumnas();
            
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<OpeLogisticoE> ListaOpeLog = null;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvOperadores.Columns[0].Width = 70;
            dgvOperadores.Columns[1].Width = 300;
            dgvOperadores.Columns[2].Width = 100;
            dgvOperadores.Columns[3].Width = 90;
            dgvOperadores.Columns[4].Width = 120;
            dgvOperadores.Columns[5].Width = 90;
            dgvOperadores.Columns[6].Width = 120;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                FrmDlgPersona oFrm = new FrmDlgPersona();

                if (oFrm.ValidarIngresoVentana())
                {
                    oFrm.Enumerado = EnumTipoRolPersona.OperadorLog;
                    oFrm.OpcionVentana = 7;
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.Show();
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
                if (bsOperadorLogistico.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = this.MdiChildren.FirstOrDefault(x => x is frmOperadorLogistico);

                    if (oFrm != null)
                    {
                        //Si esta minimizado
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    Persona per = AgenteMaestros.Proxy.RecuperarPersonaPorID(((OpeLogisticoE)bsOperadorLogistico.Current).idPersona);
                    OpeLogisticoE ope = AgenteMaestros.Proxy.RecuperarOpeLogPorId(((OpeLogisticoE)bsOperadorLogistico.Current).idPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmOperadorLogistico(ope, per, Convert.ToInt32(EnumOpcionGrabar.Actualizar));
                    oFrm.MdiParent = this.MdiParent;
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
                String RazonSocial = String.Empty;
                String NroDocumento = String.Empty;

                if (!String.IsNullOrEmpty(txtRazonSocial.Text))
                {
                    RazonSocial = txtRazonSocial.Text;
                }

                if (!String.IsNullOrEmpty(txtNroDocumento.Text))
                {
                    NroDocumento = txtNroDocumento.Text;
                }
                
                if (chkIndBaja.Checked)
                {
                    ListaOpeLog = AgenteMaestros.Proxy.ListarOpeLogPorParametro(VariablesLocales.SesionLocal.IdEmpresa, RazonSocial, NroDocumento, false, false);
                }
                else
                {
                    ListaOpeLog = AgenteMaestros.Proxy.ListarOpeLogPorParametro(VariablesLocales.SesionLocal.IdEmpresa, RazonSocial, NroDocumento, true, false);
                }
                
                bsOperadorLogistico.DataSource = ListaOpeLog;
                bsOperadorLogistico.ResetBindings(false);

                base.Buscar();
                lblTitulo.Text = "Registros [ " + bsOperadorLogistico.Count.ToString() + " ]";
            }

            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmOperadorLogistico oFrm = sender as frmOperadorLogistico;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoOperadorLogistico_Load(object sender, EventArgs e)
        {
            Grid = true;
        }

        private void frmListadoOperadorLogistico_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        private void dgvOperadores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvOperadores.Rows[e.RowIndex].Cells["chkIndEstado"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;//Color.FromArgb(255, 150, 150);
                }
            }

            if (e.ColumnIndex == Variables.Cero)
            {
                dgvOperadores.Columns[0].DefaultCellStyle.Format = "000000";
            }
        }

        private void dgvOperadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        #endregion

    }
}
