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
    public partial class frmListadoCampana : FrmMantenimientoBase
    {

        public frmListadoCampana()
        {
            InitializeComponent();
        
            FormatoGrid(dgvDocumentos, true);
            AnchoColumnas();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<CampanaE> ListaCampana = null;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 35; //idCampana
            //dgvDocumentos.Columns[1].Width = 90; //Titulo
            dgvDocumentos.Columns[1].Width = 350; //nombre
            dgvDocumentos.Columns[2].Width = 80; //inicio
            dgvDocumentos.Columns[3].Width = 80; //fin 
            dgvDocumentos.Columns[4].Width = 63; //Focus
            dgvDocumentos.Columns[5].Width = 90; //EstadoPrecio
            dgvDocumentos.Columns[6].Width = 115; //EstadoDirectoras
            dgvDocumentos.Columns[7].Width = 64; //MostrarPedWeb
            dgvDocumentos.Columns[8].Width = 64; //MostrarDevWeb
            dgvDocumentos.Columns[9].Width = 75; //EsDiferido
            dgvDocumentos.Columns[10].Width = 105; //EstadoActivarArticulo
            dgvDocumentos.Columns[11].Width = 90; //UsuarioRegistro
            dgvDocumentos.Columns[12].Width = 126; //FechaRegistro
            dgvDocumentos.Columns[13].Width = 90; //UsuarioModificacion
            dgvDocumentos.Columns[14].Width = 126; //FechaModificacion
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
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

                oFrm = new frmCampana();
                oFrm.MdiParent = this.MdiParent;
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
                ListaCampana = AgenteVentas.Proxy.ListarCampana(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                bsCampana.DataSource = ListaCampana;
                bsCampana.ResetBindings(false);

                base.Buscar();
                lblTitulo.Text = bsCampana.Count.ToString() + " Registros";
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
                if (bsCampana.Count > 0)
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


                    oFrm = new frmCampana(((CampanaE)bsCampana.Current).idCampana,((CampanaE)bsCampana.Current).idEmpresa);
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

        public override void Anular()
        {
            try
            {
                if (bsCampana.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.EliminarCampana(((CampanaE)bsCampana.Current).idCampana,((CampanaE)bsCampana.Current).idEmpresa);
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
            frmCampana oFrm = sender as frmCampana;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoCampana_Load(object sender, EventArgs e)
        {
            Grid = true;
        }

        private void frmListadoCampana_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        } 

        #endregion

    }
}
