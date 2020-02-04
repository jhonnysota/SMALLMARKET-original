using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Recursos;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoPeriodoComision : FrmMantenimientoBase
    {
        
        public frmListadoPeriodoComision()
        {
            InitializeComponent();
            FormatoGrid(dgvDocumentos, true);
            AnchoColumnas();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<PeriodoComisionE> ListaComision = null;

        #endregion
        
        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 30; //idPeriodo
            dgvDocumentos.Columns[1].Width = 80; //Anio
            dgvDocumentos.Columns[2].Width = 80; //Mes 
            dgvDocumentos.Columns[3].Width = 80; //FechaInicial
            dgvDocumentos.Columns[4].Width = 80; //Fecha final
            dgvDocumentos.Columns[5].Width = 90; //Estado
            dgvDocumentos.Columns[6].Width = 90; //UsuarioRegistro
            dgvDocumentos.Columns[7].Width = 100; //FechaRegistro
            dgvDocumentos.Columns[8].Width = 90; //UsuarioModificacion
            dgvDocumentos.Columns[9].Width = 100; //FechaModificacion
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPeriodoComision);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmPeriodoComision
                {
                    MdiParent = MdiParent
                };
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();

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
                bsPeriodo.DataSource = ListaComision = AgenteVentas.Proxy.ListarPeriodoComision(VariablesLocales.SesionLocal.IdEmpresa);//agregar campos
                bsPeriodo.ResetBindings(false);
                LblTitulo.Text = bsPeriodo.Count.ToString() + " Registros";
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
                if (bsPeriodo.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCampana);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmPeriodoComision(((PeriodoComisionE)bsPeriodo.Current).idEmpresa, ((PeriodoComisionE)bsPeriodo.Current).idPeriodo)
                    {
                        MdiParent = MdiParent
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

        public override void Anular()
        {
            try
            {
                if (bsPeriodo.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.EliminarPeriodoComision(((PeriodoComisionE)bsPeriodo.Current).idEmpresa, ((PeriodoComisionE)bsPeriodo.Current).idPeriodo);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
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

        #region Eventos

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmPeriodoComision oFrm = sender as frmPeriodoComision;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoPeriodoComision_Load(object sender, EventArgs e)
        {
            Grid = true;
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void frmListadoPeriodoComision_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        #endregion
                                    
    }
}
