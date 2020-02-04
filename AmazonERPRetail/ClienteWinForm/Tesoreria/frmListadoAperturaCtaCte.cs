using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmListadoAperturaCtaCte : FrmMantenimientoBase
    {
        
        public frmListadoAperturaCtaCte()
        {
            InitializeComponent();
            FormatoGrid(dgvDocumentos, true);
            
            AnchoColumnas();
            
        }

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        List<AperturaCtaCteE> ListaCtaCte = null;

        #endregion

        #region ProcedimientosUsuario

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 80; //PERSONA
            dgvDocumentos.Columns[1].Width = 50; //DOCUMENTO
            dgvDocumentos.Columns[2].Width = 300; //GLOSA
            dgvDocumentos.Columns[3].Width = 80; //CODCUENTA
            dgvDocumentos.Columns[4].Width = 60; //SERIE
            dgvDocumentos.Columns[5].Width = 60; //NUMERO
            dgvDocumentos.Columns[6].Width = 80; //FECHA EMISION
            dgvDocumentos.Columns[7].Width = 70; //INDDEBEHABER
            dgvDocumentos.Columns[8].Width = 90; //USUARIOREG
            dgvDocumentos.Columns[9].Width = 120; //FECHA REG
            dgvDocumentos.Columns[10].Width = 90; //USUARIOMOD
            dgvDocumentos.Columns[11].Width = 120; // FECHA MOD
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmAperturaCtaCte);

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
                oFrm = new frmAperturaCtaCte();
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
                ListaCtaCte = AgenteTesoreria.Proxy.ListarAperturaCtaCte(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                bsApertura.DataSource = ListaCtaCte;
                bsApertura.ResetBindings(false);

                base.Buscar();
                lblTitulo.Text = String.Format("Registros [{0}]", ListaCtaCte.Count.ToString());
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
                if (bsApertura.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoPago);

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
                    oFrm = new frmAperturaCtaCte(((AperturaCtaCteE)bsApertura.Current).idEmpresa, ((AperturaCtaCteE)bsApertura.Current).idRegistro);
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
                if (bsApertura.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteTesoreria.Proxy.EliminarAperturaCtaCte(((AperturaCtaCteE)bsApertura.Current).idEmpresa, ((AperturaCtaCteE)bsApertura.Current).idRegistro);
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
            frmAperturaCtaCte oFrm = sender as frmAperturaCtaCte;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoAperturaCtaCte_Load(object sender, EventArgs e)
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

        private void frmListadoAperturaCtaCte_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        #endregion

    }
}
